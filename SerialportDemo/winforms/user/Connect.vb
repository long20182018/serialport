
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
        Label1.Parent = PictureBox1
        Label2.Parent = PictureBox1
        Label3.Parent = PictureBox1
        Label4.Parent = PictureBox1
        Label5.Parent = PictureBox1
        Label6.Parent = PictureBox1
        Label7.Parent = PictureBox1
        PictureBox2.Parent = PictureBox1
        PictureBox3.Parent = PictureBox1
        Dim x As Integer = PictureBox1.Location.Y
        Label1.Location = New Point(Label1.Location.X, Label1.Location.Y - x)
        Label2.Location = New Point(Label2.Location.X, Label2.Location.Y - x)
        Label3.Location = New Point(Label3.Location.X, Label3.Location.Y - x)
        Label4.Location = New Point(Label4.Location.X, Label4.Location.Y - x)
        Label5.Location = New Point(Label5.Location.X, Label5.Location.Y - x)
        Label6.Location = New Point(Label6.Location.X, Label6.Location.Y - x)
        Label7.Location = New Point(Label7.Location.X, Label7.Location.Y - x)
        PictureBox2.Location = New Point(PictureBox2.Location.X, PictureBox2.Location.Y - x)
        PictureBox3.Location = New Point(PictureBox3.Location.X, PictureBox3.Location.Y - x)
        Me.FormBorderStyle = FormBorderStyle.None



    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim connect As New connecteddevice
        connect.connect_device()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub
End Class