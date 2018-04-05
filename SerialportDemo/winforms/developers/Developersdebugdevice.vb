
Imports System.Threading

Public Class Developersdebugdevice
    '实例化数据库连接
    Private conn As New Connectiondatabase
    'listview中选中的程序名称
    Private programselectName As String = ""
    '加载选中的程序数据到数组
    Private loadingprogramdata
    '加载显示区数据到数组
    Private Showdata As Object
    '当前位置点
    Private currentPoint As Integer = 1
    '添加坐标数据到数据库
    Private addPoint(7) As Double
    '加载程序时将表名记录下来
    Private loadingTabelname As String = ""
    '记录上一次保存的值，用于判断是否重复保存
    Private LastValuesave(7) As Double

    ' Private WithEvents syste As New SystemHook
    '    Dim systemHook As New SystemHook
    'listview有一个很重要的属性，view 
    '  listviewitem item = New ListViewItem('行头值');
    'item.subitem.add('值');
    'item.subitem.add('值');
    'ListView1.Items.Add(item);
    '有个很重要的属性要设计view 改为Details

#Region "系统初始化"
    Private Sub Developersdebugdevice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim arr()() As Double = {New Double() {2, 3.1, 4.2}, New Double() {1.5, 2.4, 3.2}, New Double() {1, 3, 2.9}}
        Dim arrnew = arr.OrderBy(Function(a) a(1)).ToArray


        '设置屏幕居中
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        Me.FormBorderStyle = FormBorderStyle.None
        'UI初始化
        UIinitialization()
        '取得数据库程序列表
        getprogramlist()
        Showdata = conn.GetRowsarrayList("settings.mdb", "调机显示区")

        getShowname()
    End Sub

#End Region

#Region "UI初始化"

    Private Sub UIinitialization()

        PictureBox2.Parent = PictureBox1
        PictureBox3.Parent = PictureBox1
        Label14.Parent = PictureBox1
        Label15.Parent = PictureBox1
        '   Label1.Parent = PictureBox1
        Dim x As Integer = PictureBox1.Location.Y

        Label15.Location = New Point(Label15.Location.X, Label15.Location.Y - x)
        Label14.Location = New Point(Label14.Location.X, Label14.Location.Y - x)
        PictureBox2.Location = New Point(PictureBox2.Location.X, PictureBox2.Location.Y - x)
        PictureBox3.Location = New Point(PictureBox3.Location.X, PictureBox3.Location.Y - x)

    End Sub

#End Region

#Region "更新UI值"
    '上一位置点
    Private Sub Previouspoints_ButtonClick(Sender As Object) Handles Previouspoints.ButtonClick
        currentPoint -= 1
        Call UpdataUIvalue(loadingprogramdata, currentPoint)
        currentPoints.Text = currentPoint
    End Sub
    '下一位置点
    Private Sub Nextpoints_ButtonClick(Sender As Object) Handles Nextpoints.ButtonClick
        currentPoint += 1
        Call UpdataUIvalue(loadingprogramdata, currentPoint)
        currentPoints.Text = currentPoint
    End Sub

    Private Sub UpdataUIvalue(arr As Object, movepoint As Integer)
        Dim frm As New Mssgbox
        Dim findvalue As Boolean = False
        If (movepoint < 1) Then
            frm.Label1.Text = "没有上一点了，当前为第一点"
            currentPoint = 1
            frm.ShowDialog()
            Exit Sub
        End If

        Try

            For y As Byte = 0 To UBound(arr, 2)
                If (arr(0, y) = movepoint) Then
                    findvalue = True
                    Dim listRows = y
                    Dim UIcount As Byte = 21
                    Dim tempTextbox As TextBox
                    For x As Byte = 2 To UBound(arr, 1)
                        If (IsDBNull(arr(x, y))) Then
                        Else
                            tempTextbox = Me.Controls.Find("TextBox" & UIcount, True)(0)
                            tempTextbox.Text = arr(x, y)
                            UIcount += 1
                        End If
                    Next
                End If
            Next

            If (findvalue = False) Then
                frm.Label1.Text = "没有下一点了，当前最大的点数为：" & movepoint - 1
                currentPoint -= 1
                frm.ShowDialog()
            End If

        Catch ex As Exception
            frm.Label1.Text = vbNewLine + ErrorToString()
            frm.ShowDialog()
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Me.Close()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Me.Close()
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

#Region "加载程序列表"
    Private Sub getprogramlist()
        Dim Tablenamelist = conn.GetRowsarrayList("program.mdb", "配方列表")
        ListView1.Clear()
        Try
            ListView1.Columns.Add("序号", 40, HorizontalAlignment.Center)
            ListView1.Columns.Add("程序名称", 150, HorizontalAlignment.Center)
            ListView1.Columns.Add("最后修改日期", 102, HorizontalAlignment.Center)
            ListView1.GridLines = True
            ListView1.FullRowSelect = True
            Dim listv As New ListViewItem
            ListView1.LargeImageList = ImageList1

            For x As Integer = 0 To Tablenamelist.length / 2 - 1

                ListView1.Items.Add((x + 1).ToString)
                ListView1.Items(x).SubItems.Add(Tablenamelist(0, x))
                ListView1.Items(x).SubItems.Add(Tablenamelist(1, x))
                ListView1.Items(x).BackColor = Color.DarkOrange
                ListView1.Items(x).ForeColor = Color.Blue
            Next
            GroupBox3.Text = "程序列表  >>>--程序读取完成！"
        Catch ex As Exception
            GroupBox3.Text = "程序列表  >>>--读取失败，没有程序或表被删除！"
        End Try
    End Sub
#End Region

#Region "窗体操作"
    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click
        programselectName = ListView1.SelectedItems(0).SubItems(1).Text
        programtext.Text = ListView1.SelectedItems(0).SubItems(1).Text
    End Sub

    Private Sub Settingprogarn_ButtonClick(Sender As Object) Handles Settingprogarn.ButtonClick
        Dim frm As New DevelopersHome
        frm.ShowDialog()
    End Sub
#End Region

#Region "鼠标特效"

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        PictureBox2.Visible = True
        PictureBox3.Visible = False
    End Sub

    Private Sub PictureBox2_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.Visible = False
        PictureBox3.Visible = True
    End Sub

    Private Sub Downloadprogram_MouseEnter(sender As Object, e As EventArgs) Handles Downloadprogram.MouseEnter
        Downloadprogram.颜色 = Color.DarkOrange
        Label1.Text = "*注意！下载程序前必须先停机，以免造成不必要的损失！"
        Label1.Location = New Point(Downloadprogram.Location.X, Downloadprogram.Location.Y + 40)
    End Sub

    Private Sub Downloadprogram_MouseLeave(sender As Object, e As EventArgs) Handles Downloadprogram.MouseLeave
        Downloadprogram.颜色 = Color.FromArgb(50, 50, 50)
        Label1.Text = ""
        Label1.Location = New Point(930, 210)
    End Sub

    Private Sub newfile_MouseEnter(sender As Object, e As EventArgs) Handles newfile.MouseEnter
        Dim templist = conn.GetRowsarrayList("settings.mdb", "程序配方配置")
        newfile.颜色 = Color.DarkOrange
        If (templist.length = 3) Then
            Label1.Text = "*注意！创建程序时须要先配置配方！当前配方配置" & vbCrLf & "起始地址：" & templist(0, 0) & vbCrLf & "每个点有几个坐标：" & templist(1, 0) _
            & vbCrLf & "每一个坐标名称：" & templist(2, 0)
        Else
            Label1.Text = "*注意！创建程序时须要先配置配方！"
        End If
        Label1.Location = New Point(newfile.Location.X, newfile.Location.Y + 40)
    End Sub

    Private Sub newfile_MouseLeave(sender As Object, e As EventArgs) Handles newfile.MouseLeave
        newfile.颜色 = Color.FromArgb(50, 50, 50)
        Label1.Text = ""
        Label1.Location = New Point(930, 210)
    End Sub

#End Region

#Region "新建文件"
    '建立文件
    Private Sub newfile_ButtonClick(Sender As Object) Handles newfile.ButtonClick
        '输入程序名称
        Dim tempstr = InputBox("请输入程序名称")
        '如果没有输入程序名称，退出过程，不执行创建文件操作
        If (tempstr = "") Then
            Label16.Text = "你没有输入程序配方名称，创建文件失败！"
            Exit Sub
        End If
        '开始创建文件
        conn.CreateDatabase(tempstr)
        '添加文件后获得最新程序列表更新到UI
        getprogramlist()
    End Sub
#End Region

#Region "加载程序"
    Private Sub loadingprpgram_ButtonClick(Sender As Object) Handles loadingprpgram.ButtonClick

        If (programtext.Text = "") Then
            Dim frm As New Mssgbox
            frm.Label1.Text = "*注意：请先选中程序再加载！"
            frm.ShowDialog()
            Exit Sub
        End If
        '禁止重复加载 
        If (loadingTabelname = programtext.Text) Then
            Dim frm As New Mssgbox
            frm.Label1.Text = "请勿重复加载!" & vbCrLf & vbCrLf & "                        天龙软件工作室！By:龙"
            frm.ShowDialog()
            Exit Sub
        End If
        '将表名记录下来
        loadingTabelname = programtext.Text
        '把表内数据提取到数组
        loadingprogramdata = conn.GetRowsarrayList("program.mdb", programtext.Text)
        ' Dim arrnew = loadingprogramdata.OrderBy(Function(a) a(1)).ToArray

        '更新UI名称
        Dim UILabel As Label
        For x As Byte = 0 To UBound(loadingprogramdata, 2)
            If (IsDBNull(loadingprogramdata(0, x) = False)) Then
                UILabel = Me.Controls.Find(loadingprogramdata(0, x), True)(0)
                UILabel.Text = loadingprogramdata(1, x)
            End If

        Next
        '更新UI值
        currentPoints.Text = currentPoint
        Call UpdataUIvalue(loadingprogramdata, currentPoint)

    End Sub
#End Region

#Region "添加数据"

    Private Sub Savefile_ButtonClick(Sender As Object) Handles Savefile.ButtonClick
        '统计字段个数
        Dim fieldCount As Byte = 0
        '用于遍历控件
        Dim tempTextbox As TextBox
        '添加数据时要先加载程序
        If (loadingTabelname = "") Then
            Dim frm As New Mssgbox
            frm.Label1.Text = "请先加载程序!" & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & vbCrLf & "                   天龙软件工作室 QQ:614021330"
            frm.ShowDialog()
            Exit Sub
        End If
        '遍历21--28 的textbox控件 
        For x As Byte = 21 To 28
            tempTextbox = Me.Controls.Find("TextBox" & x, True)(0)
            If (tempTextbox.Text <> "") Then
                addPoint(fieldCount) = tempTextbox.Text
                fieldCount += 1
            End If
        Next
        conn.debug_adddata(loadingTabelname, fieldCount, addPoint)
    End Sub

    Private Function Lastvalue() As String

    End Function

#End Region



End Class