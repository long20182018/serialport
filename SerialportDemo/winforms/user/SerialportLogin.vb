Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO.Ports
Imports System.Windows.Forms.DataVisualization.Charting
Public Class SerialportLogin
    Dim frm As New WinSerialportManager
    Dim login As New Mainsystem


    Private Sub SerialportLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '设置屏幕居中
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '如果程序没注册，直接退出程序
        If ((redisteredstaet = login.registered) = False) Then Application.Exit()

        Label1.Parent = PictureBox1
        Label2.Parent = PictureBox1
        Label3.Parent = PictureBox1
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

        Dim tempstr As String = login.loginsystem(TextBox1.Text, TextBox2.Text)

        If (tempstr = "开发者" Or tempstr = "管理员" Or tempstr = "使用者") Then
            Label3.Text = tempstr & "、你好！，即将进入系统，请稍等!"
            Dim _time = 1
            Do
                My.Application.DoEvents()
                _time += 1
            Loop Until _time > 900000
            frm.ShowDialog()
        Else
            Label3.Text = tempstr
        End If

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        End

    End Sub
End Class