Imports System.IO
Imports System.Threading

Public Class DevelopersSpeedsettings

    '实例化连接数据库类
    Dim conn As New Connectiondatabase
    'MOsbus地址数组列表,窗体初始化时先将数据库的数据提取到该数组，
    '用于计算PLC速度设置的对应地址
    Dim ModbusAddressArraylist() As String
    '将手动速度设置上的DataGridView数据转换为Modbus协议格式后存入数组
    Dim ManualSpeedArraylist(0 To 50, 0 To 1) As String
    '将自动速度设置上的DataGridView数据转换为Modbus协议格式后存入数组
    Dim AutoSpeedArraylist(0 To 50, 0 To 1) As String

#Region "初始化"
    Private Sub Speedsettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '屏幕居中
        '***************************************************************
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '***************************************************************

        '数据控件添加50行
        '***************************************************************
        DataGridView1.Rows.Add(50)
        DataGridView2.Rows.Add(50)
        '***************************************************************
        MsgBox("请注意，该窗口设置直接影响到速度设置的UI生成" & vbCrLf & "内容请按顺序添加！" & vbCrLf & "By:QQ 614021130", vbDefaultButton1, "温馨提示")
    End Sub
#End Region


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        '返回Modbus地址
        Dim ReturnModbussAddress As String
        '返回添加数据是否成功
        Dim ReturnaddManual As String
        Dim ReturnaddAuto As String

        '循环将DataGridview上的数据装入数组 
        For x = 0 To 50
            If (DataGridView1.Rows(x).Cells(0).Value <> "") Then
                ManualSpeedArraylist(x, 0) = DataGridView1.Rows(x).Cells(1).Value
                ReturnModbussAddress = Modbusaddress(DataGridView1.Rows(x).Cells(2).Value)
                ManualSpeedArraylist(x, 1) = ReturnModbussAddress
                ReturnModbussAddress = ""
            End If
            If (DataGridView2.Rows(x).Cells(0).Value <> "") Then
                AutoSpeedArraylist(x, 0) = DataGridView2.Rows(x).Cells(1).Value
                ReturnModbussAddress = Modbusaddress(DataGridView2.Rows(x).Cells(2).Value)
                AutoSpeedArraylist(x, 1) = ReturnModbussAddress
                ReturnModbussAddress = ""
            End If
        Next

        '先将表中原来的数据清空
        conn.ClearanceDataTabel("Speed.mdb", "手动速度")
        conn.ClearanceDataTabel("Speed.mdb", "自动速度")

        '向数据库表中添加数据
        ReturnaddManual = conn.add_Speed("手动速度", ManualSpeedArraylist)
        ReturnaddAuto = conn.add_Speed("自动速度", AutoSpeedArraylist)

        '将添加数据是否成功返回值显示到标签中
        Label1.Text = "手动速度:" & ReturnaddManual & "----  自动速度:" & ReturnaddAuto
    End Sub

    '将速度寄存器地址转为Modbus协议16进制地址
    Private Function Modbusaddress(address As String) As String
        Dim Hextempstring As String
        '不足4位数据时前面补0，补够4位
        Hextempstring = Microsoft.VisualBasic.Right("000" & Hex(address), 4)
        '将16进制数据拆开连接一个空格 如 "0000" 拆开连接空格 "00 00”
        '因为在发送时是一串字符，添加空格是为了split分割后转成10进制
        Hextempstring = Hextempstring.Substring(0, 2) & " " & Hextempstring.Substring(2)
        Modbusaddress = Hextempstring
    End Function


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As New DevelopersSpeedset
        frm.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub
End Class