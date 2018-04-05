Imports System.Data.OleDb
Imports ADODB
Imports DAO

Public Class Connectiondatabase
    Dim conn As New ADODB.Connection
    Dim Rst As New ADODB.Recordset
    Dim Sqlstring As String
    Dim ConString As String
    'adLockReadOnly = 1 
    'adLockPessimistic = 2 
    'adLockOptimistic = 3 
    'adLockBatchOptimistic = 4 


#Region "调机类"

    Public Sub debug_adddata(TabelName As String, Updatafield As Object, UpdataValue As Object)
        Dim strcn As String
        Try
            If conn.State = 1 Then conn.Close()
            If Rst.State = 1 Then Rst.Close()
            strcn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & AppPath & "\config\program.mdb;Persist Security Info=False"
            conn.Open(strcn)
            Rst.Open("select *  from " & TabelName & " ", conn, 1, 3)
            Rst.AddNew()
            For x As Byte = 0 To Updatafield
                Rst.Fields(x + 2).Value = UpdataValue(x)
            Next
            Rst.Update()
            Rst.Clone()
            conn.Close()
        Catch ex As Exception
            Dim frm As New Mssgbox
            frm.Label1.Text = vbNewLine + ErrorToString()
            frm.ShowDialog()
        End Try

    End Sub

#End Region

    Public Function gettablename(basename As String) As Object
        Try
            Dim sr = ("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\" & basename & ";Persist Security Info=False")
            Dim con As New OleDbConnection(sr)
            con.Open()
            Dim shemaTable As DataTable

            shemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {vbNull, vbNull, vbNull, "TABLE"})
        Catch ex As Exception
            Return ex.ToString
        End Try
        Closebase()
    End Function

    Public Function CreateDatabase(TableName As String) As String
        Try

            '先取得配置文件
            Dim arrlist = GetRowsarrayList("settings.mdb", "程序配方配置")
            If conn.State = 1 Then conn.Close()
            If Rst.State = 1 Then Rst.Close()
            Dim strCn As String
            If TableName <> "" Then
                '把表名添记录起来
                strCn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & AppPath & "\config\program.mdb;Persist Security Info=False"
                conn.Open(strCn)
                Sqlstring = "Insert into 配方列表(配方名,最后修改日期) VALUES('" & TableName & "','" & Format(Now, "yyyy/MM/dd") & "')"
                conn.Execute(Sqlstring)
                '将数据进行分割
                Dim splitstr = Split(arrlist(2, 0), ",")

                strCn = "create table " & TableName & "(配方点 AutoIncrement,起始地址 text(10))"
                conn.Execute(strCn)
                For x As Byte = 0 To UBound(splitstr)
                    strCn = "ALTER TABLE " & TableName & " ADD " & splitstr(x) & " text(20)"
                    conn.Execute(strCn)
                Next
                Sqlstring = "Insert into " & TableName & "(起始地址) VALUES('" & arrlist(0, 0) & "')"
                conn.Execute(Sqlstring)
                Closebase()
                Return "文件创建成功"
                Exit Function
            End If
            Return "文件创建失败"
            Closebase()
        Catch ex As Exception
            Return ex.ToString
        End Try
        Closebase()
    End Function

    Public Sub Modifydata(basename As String, Tabelname As String, findfield As String, findvalue As String, Updatafield As String, Updatavalue As Object)

        If conn.State = 1 Then conn.Close()
        If Rst.State = 1 Then Rst.Close()
        conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\" & basename & ";Persist Security Info=False")
        Sqlstring = "update " & Tabelname & " set " & Updatafield & " ='" & Updatavalue & "' where " & findfield & "='" & findvalue & "'"
        conn.Execute(Sqlstring)
        Closebase()

    End Sub

#Region "设置参数"

    Public Sub Settingprogram(Startaddress As String, Countpoint As String, correspondencefield As String)
        Dim templist = GetRowsarrayList("settings.mdb", "程序配方配置")
        ConnModbusaddress()
        Try

            Sqlstring = "delete  from 程序配方配置 where 起始地址='" & templist(0, 0) & " '"
            conn.Execute(Sqlstring)
            Sqlstring = "Insert into 程序配方配置(起始地址,每个点几个位置,每个位置对应字段) VALUES('" & Startaddress & "','" & Countpoint & "','" & correspondencefield & "')"
            conn.Execute(Sqlstring)
        Catch ex As Exception
            Sqlstring = "Insert into 程序配方配置(起始地址,每个点几个位置,每个位置对应字段) VALUES('" & Startaddress & "','" & Countpoint & "','" & correspondencefield & "')"
            conn.Execute(Sqlstring)
        End Try
        Closebase()
    End Sub

    Public Sub SettingsSpeed(TabelName, NewarrayListvalue)
        ConnModbusaddress()
        For x = 0 To UBound(NewarrayListvalue)
            If (NewarrayListvalue(x, 0) <> "") Then
                Sqlstring = "Select * from " & TabelName & " where 名称='" & NewarrayListvalue（x, 0) & "'"
                Rst.Open(Sqlstring, conn, 1, 4)
                Rst.Update(("值"), (NewarrayListvalue（x, 1)))
                Rst.Close()
            End If
        Next
        Closebase()
    End Sub

#End Region

#Region "添加数据"

#Region "添加Modbus地址"
    Public Function add_Modbusaddress(TabelName, Newvalue) As String
        Try

            Call ConnModbusaddress()
            Sqlstring = "delete from " & TabelName & ""
            conn.Execute(Sqlstring)

            For x = 0 To UBound(Newvalue)
                Dim k = UBound(Newvalue) - 1
                Sqlstring = "Insert into " & TabelName & " (Modbus,Plc,Hex) VALUES('" & Newvalue(x, 0) & "', '" & Newvalue(x, 1) & "', '" & Newvalue(x, 2) & "')"
                conn.Execute(Sqlstring)
            Next
            conn.Close()
            add_Modbusaddress = "成功添加数据"

        Catch ex As Exception
            add_Modbusaddress = ex.ToString
        End Try

    End Function
#End Region

#Region "添加发送数据"
    Public Function add_senddata(TabelName As String, DataOne As String, DataTwo As String, Datathreee As String,
                                 DataFour As String, Datafive As String, Datasix As String, CRC16 As String) As String

        Call ConnModbusaddress()
        Try
            Sqlstring = "Insert into " & TabelName & " (站号, 功能码,地址高位,地址低位,数据高位,数据低位,校验码) VALUES('" & DataOne & "','" & DataTwo & "', '" & Datathreee & "','" & DataFour & "','" & Datafive & "','" & Datasix & "','" & CRC16 & "')"
            conn.Execute(Sqlstring)
            conn.Close()
            add_senddata = "添加成功"
        Catch ex As Exception
            add_senddata = ex.ToString
        End Try
    End Function
#End Region

#Region "开发者设置发送数据"

    Public Function Senddata(TableName As String, identifier As String, Sendstr As String, Mappingaddress As String) As String
        If conn.State = 1 Then conn.Close()
        conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\Speed.mdb;Persist Security Info=False")

        Sqlstring = "Insert into " & TableName & "(标识符,发送数据,映射地址) VALUES('" & identifier & "','" & Sendstr & "','" & Mappingaddress & "')"
        conn.Execute(Sqlstring)

        conn.Close()
        Senddata = "添加成功"

    End Function

#End Region


#Region "添加速度数据"
    Public Function add_Speed(TabelName, SpeedArraylist) As String
        If conn.State = 1 Then conn.Close()
        conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\Speed.mdb;Persist Security Info=False")
        For x = 0 To UBound(SpeedArraylist)
            If (SpeedArraylist(x, 0) <> "") Then
                Sqlstring = "Insert into " & TabelName & "(名称,modbus地址) VALUES('" & SpeedArraylist(x, 0） & "','" & SpeedArraylist（x, 1) & "')"
                conn.Execute(Sqlstring)
            End If
        Next
        conn.Close()
        add_Speed = "添加成功"
    End Function
#End Region

#Region "添加监视地址"

    Public Function Add_SurveillanceAddress(TabelName As String, fieldName As String, NewvalueArraylist() As String) As String
        Try



            If conn.State = 1 Then conn.Close()
            conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\Speed.mdb;Persist Security Info=False")
            For x = 0 To UBound(NewvalueArraylist)
                If (NewvalueArraylist(x) <> "") Then
                    Sqlstring = "Insert into " & TabelName & "(" & fieldName & ") VALUES('" & NewvalueArraylist(x） & "')"
                    conn.Execute(Sqlstring)
                End If
            Next
            conn.Close()
            Return "添加成功"
        Catch ex As Exception
            Return ex.ToString
        End Try
    End Function


#End Region

#Region "添加报警值"

    Public Function add_Abnormaldata(TabelName, AbnormalArrlist) As String
        Try

            Call ConnModbusaddress()
            Sqlstring = "delete from " & TabelName & ""
            conn.Execute(Sqlstring)

            For x = 0 To UBound(AbnormalArrlist)
                If (AbnormalArrlist(x, 0) <> "") Then
                    Dim k = UBound(AbnormalArrlist) - 1
                    Sqlstring = "Insert into " & TabelName & " (报警值,地址) VALUES('" & AbnormalArrlist(x, 0) & "', '" & AbnormalArrlist(x, 1) & "')"
                    conn.Execute(Sqlstring)
                End If
            Next
            conn.Close()
            add_Abnormaldata = "成功添加数据"

        Catch ex As Exception
            add_Abnormaldata = ex.ToString
        End Try

    End Function

#End Region

#End Region

#Region "获取数据"

#Region "GetRows"
    Public Function GetRowsarrayList(baseName As String, TableName As String)
        Try
            If conn.State = 1 Then conn.Close()
            If Rst.State = 1 Then Rst.Close()
            conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\" & baseName & ";Persist Security Info=False")
            If TableName <> "" Then
                Sqlstring = "select * from " & TableName & " "

                Rst = conn.Execute(Sqlstring)
                Return Rst.GetRows
                Rst.Clone()

            Else
                Return "表名不能为空"
            End If
        Catch ex As Exception
            Return "没有记录，或表被删除"
        End Try
        Closebase()
    End Function

#End Region

#End Region

#Region "清空数据表"
    Public Sub ClearanceDataTabel(DatabaseName As String, TabelName As String)
        If conn.State = 1 Then conn.Close()
        conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\" & DatabaseName & ";Persist Security Info=False")
        Sqlstring = "delete from " & TabelName & ""
        conn.Execute(Sqlstring)
        Closebase()
    End Sub
#End Region

#Region "连接数据库"

    Private Sub Closebase()
        If conn.State = 1 Then conn.Close()
        If Rst.State = 1 Then Rst.Close()
    End Sub
    Private Sub ConnModbusaddress()
        If conn.State = 1 Then conn.Close()
        If Rst.State = 1 Then Rst.Close()
        conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\settings.mdb;Persist Security Info=False")
    End Sub
#End Region

End Class

