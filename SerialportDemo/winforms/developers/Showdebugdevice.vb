Public Class Showdebugdevice
    '实例化数据库连接
    Private conn As New Connectiondatabase
    '写入数据
    Private Writingdata As Object(,)
    '读取数据 
    Private getdata As Object

    Private Sub DevelopersManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '屏幕居中
        '***************************************************************
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '***************************************************************
        Me.FormBorderStyle = FormBorderStyle.None
        UIinitialization()
        getFields()
    End Sub

    Private Sub UIinitialization()

        'PictureBox11.Visible = False
        ''   GroupBox1.Parent = PictureBox9
        'PictureBox10.Parent = PictureBox9
        'PictureBox11.Parent = PictureBox9
        'Label12.Parent = PictureBox9
        'Dim x As Integer = PictureBox9.Location.Y
        'Label12.Location = New Point(Label12.Location.X, Label12.Location.Y - x)
        'PictureBox11.Location = New Point(PictureBox11.Location.X, PictureBox11.Location.Y - x)
        'PictureBox10.Location = New Point(PictureBox10.Location.X, PictureBox10.Location.Y - x)
        '   GroupBox1.Location = New Point(GroupBox1.Location.X, GroupBox1.Location.Y - x)
    End Sub

    Private Sub getFields()
        Dim temparraylist = conn.GetRowsarrayList("settings.mdb", "调机显示区")
        For x = 0 To UBound(temparraylist, 2)
            ListBox1.Items.Add(temparraylist(2, x))
        Next
    End Sub

    Private Sub PictureBox10_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox10.MouseEnter
        PictureBox10.Visible = False
        PictureBox11.Visible = True
    End Sub

    Private Sub PictureBox11_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox11.MouseLeave
        PictureBox11.Visible = False
        PictureBox10.Visible = True
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        '更改后的值存放在文本框，文本框的名字从textbox21----textbox28，循环遍历
        Dim col As Control

        For x As Byte = 21 To 28
            col = GroupBox1.Controls.Find("TextBox" & x, True)(0)
            If (col.Text <> "") Then
                conn.Modifydata("settings.mdb", "调机显示区", "名称", "Label" & x, "更改后的名称", col.Text)
            End If
        Next
    End Sub




    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus

    End Sub
End Class