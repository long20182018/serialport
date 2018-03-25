﻿Imports ADODB

Public Class Connectiondatabase
    Dim conn As New ADODB.Connection
    Dim Rst As New ADODB.Recordset
    Dim Sqlstring As String
    Dim ConString As String

#Region "设置参数"

    Public Sub SettingsSpeed(TabelName, NewarrayListvalue)

        If conn.State = 1 Then conn.Close()
        Sqlstring = ("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\Speed.mdb;Persist Security Info=False")
        conn.Open(Sqlstring)

        For x = 0 To UBound(NewarrayListvalue)
            If (NewarrayListvalue(x, 0) <> "") Then
                Sqlstring = "Select * from " & TabelName & " where 名称='" & NewarrayListvalue（x, 0) & "'"
                Rst.Open(Sqlstring, conn, 1, 4)
                Rst.Update(("值"), (NewarrayListvalue（x, 1)))
                Rst.Close()
            End If
        Next

        conn.Close()
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
                Sqlstring = "Insert into " & TabelName & " (Modbus, Plc,Hex) VALUES('" & Newvalue(x, 0) & "', '" & Newvalue(x, 1) & "', '" & Newvalue(x, 2) & "')"
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
            Add_SurveillanceAddress = "添加成功"
        Catch ex As Exception
            Add_SurveillanceAddress = ex.ToString
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
    Public Function GetRowsarrayList(DatabaseName As String, TableName As String)
        On Error Resume Next
        If TableName <> "" Then
            Sqlstring = "select * from " & TableName & " "
            conn.Open（"provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & AppPath & "\config\" & DatabaseName & ";Persist Security Info=False"）
            Rst = conn.Execute(Sqlstring)
            GetRowsarrayList = Rst.GetRows
            conn.Close()
        Else
            GetRowsarrayList = "表名不能为空"
        End If

    End Function

#End Region

#End Region

#Region "清空数据表"
    Public Sub ClearanceDataTabel(DatabaseName As String, TabelName As String)
        If conn.State = 1 Then conn.Close()
        conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\" & DatabaseName & ";Persist Security Info=False")
        Sqlstring = "delete from " & TabelName & ""
        conn.Execute(Sqlstring)
        conn.Close()
    End Sub
#End Region

#Region "连接数据库"
    Private Sub ConnModbusaddress()
        If conn.State = 1 Then conn.Close()
        If Rst.State = 1 Then Rst.Close()
        conn.Open("provider=Microsoft.jet.OLEDB.4.0;data source=" & AppPath & "\config\Modbus.mdb;Persist Security Info=False")
    End Sub
#End Region

End Class