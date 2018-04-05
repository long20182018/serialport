Imports System.Threading

Public Class Showed

#Region "声明"
    '是否允许窗体移动
    Private formmove As Boolean
    '记录窗体位置
    Private formpoint As Point
    '实例化数据库连接
    Private conn As New Connectiondatabase
    '写入数据
    Private Writingdata As Object(,)
    '获取数据 
    Private getdata As Object
    '标记点击了那一个textbox
    Private ClickTextbox As TextBox
    '等待list单击完成才隐藏
    Private waitListClick As Boolean = False
#End Region

#Region "加载窗体"
    Private Sub Showed_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '屏幕居中
        '***************************************************************
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '***************************************************************
        '隐藏窗体标题
        Me.FormBorderStyle = FormBorderStyle.None
        '初始化UI
        UIinitialization()
        '获得显示标题
        getShowname()
        '获得对应字段
        getFields()
    End Sub
#End Region

#Region "取得显示名称"

    Private Sub getShowname()
        Dim tempLabel As Label
        Dim Shownamelist = conn.GetRowsarrayList("settings.mdb", "调机显示区")
        For x As Byte = 0 To UBound(Shownamelist, 2)
            If (IsDBNull(Shownamelist(1, x)) = False) Then
                tempLabel = Me.Controls.Find(Shownamelist(0, x), True)(0)
                tempLabel.Text = Shownamelist(1, x)
            End If
        Next
    End Sub

#End Region

#Region "UI初始化"
    Private Sub UIinitialization()
        Dim ct As Control
        Dim x As Integer = PictureBox1.Location.Y

        For Each ct In Me.Controls

            If (TypeOf ct Is Label) Then

                ct.Parent = PictureBox1
                ct.Location = New Point(ct.Location.X, ct.Location.Y - x)

            End If
        Next
        Label11.Parent = PictureBox1
        Label11.Location = New Point(Label11.Location.X, Label11.Location.Y - x)
        Label28.Parent = PictureBox1
        Label28.Location = New Point(Label28.Location.X, Label28.Location.Y - x)
        PictureBox10.Parent = PictureBox1
        PictureBox11.Parent = PictureBox1
        PictureBox2.Parent = PictureBox1
        PictureBox2.Location = New Point(PictureBox2.Location.X, PictureBox2.Location.Y - x)
        PictureBox10.Location = New Point(PictureBox10.Location.X, PictureBox10.Location.Y - x)
        PictureBox11.Location = New Point(PictureBox11.Location.X, PictureBox11.Location.Y - x)
    End Sub
#End Region

#Region "UI特效"
    Private Sub PictureBox10_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox10.MouseEnter
        PictureBox10.Visible = False
        PictureBox11.Visible = True
    End Sub

    Private Sub PictureBox11_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox11.MouseLeave
        PictureBox11.Visible = False
        PictureBox10.Visible = True
    End Sub
#End Region

#Region "获得显示区设置字段名称"
    Private Sub getFields()
        Dim temparraylist = conn.GetRowsarrayList("settings.mdb", "调机显示区")
        For x = 0 To UBound(temparraylist, 2)
            ListBox1.Items.Add(temparraylist(2, x))
        Next
    End Sub
#End Region

#Region "写入数据"
    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        '更改后的值存放在文本框，文本框的名字从textbox21----textbox28，循环遍历
        Dim col As Control

        For x As Byte = 21 To 28
            col = Me.Controls.Find("TextBox" & x, True)(0)
            If (col.Text <> "") Then
                conn.Modifydata("settings.mdb", "调机显示区", "名称", "Label" & x, "更改后的名称", col.Text)
            End If
        Next

        Dim frm As New Mssgbox
        frm.Label1.Text = "已处理完成"
        System.Threading.Thread.Sleep(10)
        frm.ShowDialog()
    End Sub
#End Region

#Region "移动窗体"

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        formpoint = New Point
        Dim move_x As Int32
        Dim move_y As Int32
        If (e.Button = MouseButtons.Left) Then
            move_x = -e.X - SystemInformation.FrameBorderSize.Width
            move_y = -e.Y - SystemInformation.CaptionHeight - SystemInformation.FrameBorderSize.Height
            formpoint = New Point(move_x, move_y)
            formmove = True
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If (formmove = True) Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(formpoint.X, formpoint.Y)
            Location = mousePos
        End If
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        If (e.Button = MouseButtons.Left) Then
            formmove = False
        End If
    End Sub
#End Region

#Region "列表框跟随"

    Private Sub ListBox1_Click(sender As Object, e As EventArgs) Handles ListBox1.Click
        ClickTextbox.Text = ListBox1.Text
        ListBox1.Location = New Point(850, 150)
    End Sub

    Private Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        ListBox1.Location = New Point(TextBox1.Location.X, TextBox1.Location.Y + 20)
        ClickTextbox = TextBox1
    End Sub

    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        ListBox1.Location = New Point(TextBox2.Location.X, TextBox2.Location.Y + 20)
        ClickTextbox = TextBox2
    End Sub

    Private Sub TextBox3_GotFocus(sender As Object, e As EventArgs) Handles TextBox3.GotFocus
        ListBox1.Location = New Point(TextBox3.Location.X, TextBox3.Location.Y + 20)
        ClickTextbox = TextBox3
    End Sub

    Private Sub TextBox4_GotFocus(sender As Object, e As EventArgs) Handles TextBox4.GotFocus
        ListBox1.Location = New Point(TextBox4.Location.X, TextBox4.Location.Y + 20)
        ClickTextbox = TextBox4
    End Sub

    Private Sub TextBox5_GotFocus(sender As Object, e As EventArgs) Handles TextBox5.GotFocus
        ListBox1.Location = New Point(TextBox5.Location.X, TextBox5.Location.Y + 20)
        ClickTextbox = TextBox5
    End Sub

    Private Sub TextBox6_GotFocus(sender As Object, e As EventArgs) Handles TextBox6.GotFocus
        ListBox1.Location = New Point(TextBox6.Location.X, TextBox6.Location.Y + 20)
        ClickTextbox = TextBox6
    End Sub

    Private Sub TextBox7_GotFocus(sender As Object, e As EventArgs) Handles TextBox7.GotFocus
        ListBox1.Location = New Point(TextBox7.Location.X, TextBox7.Location.Y + 20)
        ClickTextbox = TextBox7
    End Sub

    Private Sub TextBox8_GotFocus(sender As Object, e As EventArgs) Handles TextBox8.GotFocus
        ListBox1.Location = New Point(TextBox8.Location.X, TextBox8.Location.Y + 20)
        ClickTextbox = TextBox8
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub

#End Region

End Class