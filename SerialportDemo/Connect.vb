
Imports System.IO.Ports

Public Class Connect

    Private Sub Connect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2

        Dim ports As String() = SerialPort.GetPortNames() '必须用命名空间，用SerialPort,获取计算机的有效串口
        Dim port As String
        For Each port In ports
            ComboBox1.Items.Add(port) '向combobox1中添加项
        Next port
        ComboBox2.Items.Add("奇校验")
        ComboBox2.Items.Add("偶校验")
        ComboBox2.Items.Add("无校验")
        ComboBox3.Items.Add(1)
        ComboBox3.Items.Add(1.5)
        ComboBox3.Items.Add(2)
        ComboBox4.Items.Add(4800)
        ComboBox4.Items.Add(9600)
        ComboBox4.Items.Add(14400)
        ComboBox4.Items.Add(19200)
        ComboBox4.Items.Add(38400)
        ComboBox4.Items.Add(56000)
        ComboBox4.Items.Add(57600)
        ComboBox4.Items.Add(115200)
        ComboBox5.Items.Add(5)
        ComboBox5.Items.Add(6)
        ComboBox5.Items.Add(7)
        ComboBox5.Items.Add(8)
    End Sub
End Class