Public Class Mssgbox

    Private Sub Mssgbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.DoubleBuffer, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
        '设置屏幕居中
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2 + 40
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2 + 25
        Label1.Parent = PictureBox1
        PictureBox2.Parent = PictureBox1
        PictureBox3.Parent = PictureBox1

        Me.FormBorderStyle = FormBorderStyle.None
        Dim x As Integer = PictureBox1.Location.Y
        Label1.Location = New Point(Label1.Location.X, Label1.Location.Y - 50)
        PictureBox2.Location = New Point(PictureBox2.Location.X + 80, PictureBox2.Location.Y + 70)
        PictureBox3.Location = New Point(PictureBox3.Location.X + 80, PictureBox3.Location.Y + 70)


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub
End Class