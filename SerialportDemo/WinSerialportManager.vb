Imports System.Windows.Forms
Imports System.Threading
Imports System.IO.Ports
Imports System.Windows.Forms.DataVisualization.Charting

Public Class WinSerialportManager

    Dim conn As New Connectiondatabase

#Region "声明"
    Dim i  '测试用
    Dim MainThreadManager As Thread                     '主线程管理器
    Dim Movelogo As Thread                              'logo移动线程
    Dim maxThreads As Integer                           '最多线程数
    Dim minThreads As Integer                           '最少线程数
    Dim maxIdleTime As Integer                          '最长空闲时间（超时删除对应线程)  
    Shared _debug As Boolean                            '是否调试  
    Dim pendingJobs As ArrayList                        '等待的作业量（数组形式，以便列队进入线程池)  
    Dim availableThreads As ArrayList                   '可用线程数 
    Dim Verifyuserreg As Boolean = False                '验证用户注册
    Dim Verifyuserper As Byte = 0                       '验证用户权限
    Dim CRCHighNumberten As Integer                     '记录发送数据时的高低位10进制校验码
    Dim CRCLowNumberten As Integer                      '用于判断接收到的校验码是否一致，如果一致则数据接收完毕
    Dim KeyboardDownUpstate As Boolean                  '记录键盘按下弹起的状态
    Dim GetCRC16Bit As New ReturnCRC                   '16BitCRC校验实例化CRC类
    Dim Databyte() As Byte                              '数据字节数组
    Dim CRC16Bit_paity As String                        'CRC校验码
    Dim tempsenddata As String                          '保存发送时的临时数据
    Dim keyShift As Boolean = False
    Dim keyCtrl As Boolean = False
    Dim KeyD As Boolean = False
    Dim keydownBoole As Boolean = False
    Private WithEvents systemhook As New SystemHook
#End Region

#Region "参数设定，UI生成相关变量"
    '主页面速度UI
    Dim HomespeedUI As Object
    '获得可用端口名称
    Dim getportName As String()
#End Region

#Region "Gdi声明相关变量"

    '///// GDI+ Chart

    Dim scalefont As New Font("宋体", 8)
    '创建一个画板
    Dim G As Graphics
    '创建一支画笔，大小为2，用于绘制外框
    Dim Framecolor As Object
    '创建一支黄绿色画笔，大小为1，用于绘制网格线
    Dim gridcolor As Object
    '创建一支画笔，大小为1，用于绘制刻度线
    Dim scalecolor As Object
    '绘制曲线颜色
    Dim Dwgcolor As Object
    '字体设置
    Dim fontcolor As New Font("新宋体", 8)
    '曲线移动步长
    Dim Movestep As Integer = 30
    '移动速度 
    Dim movespeed As Integer
    '刻度
    Dim scalenumber As Integer
    '队列方法，存储临时数据，暂定为16个，超出16个元素后剔除前面的元素
    Dim temparraylist As New Queue
    Dim queueCount As Integer = 15

    Dim scalepoiont As Byte = 13
    Dim Settingscalenumber As Integer = 200

#End Region


#Region "程序初始化"
    Private Sub WinSerialport_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        '设置屏幕居中
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '获得可用端口名称 
        getportName = SerialPort.GetPortNames()
        '偿试连接设备
        Connectdevice()
        '如果连接不成功则须要用户选择连接方式
        If (SerialPort1.IsOpen = False) Then
            Dim frm As New Connect
            frm.ShowDialog()
        End If
        '获取数据库UI参数,处理UI数据
        Call HandleUI(HomespeedUI = conn.GetRowsarrayList("UI.mdb", "主页面UI"))
        '创建系统主线程
        MainThreadManager = New Thread(AddressOf MainManager)
        MainThreadManager.Start()
        '启动钩子线程
        systemhook.StartHook()

        Timer1.Interval = 100
        Timer1.Enabled = True


        Call UI()
        GDIdefault()
        DS按钮1.BringToFront()
        abnormalGdi.Interval = movespeed
        abnormalGdi.Enabled = True
    End Sub
#End Region

#Region "处理UI数据"

    Private Sub HandleUI(arr As Object)
        For x = 1 To arr.length / (UBound(arr) + 1)
            For Each ct In Me.Controls
                If (ct.name = arr(0, x - 1)) Then
                    ct.text = arr(1, x - 1)
                    Dim Progressbar As Object
                    Dim str = Microsoft.VisualBasic.Right(ct.name, 1)
                    Progressbar = Controls.Find("DS进度条" & str, True)(0)
                    Progressbar.当前值 = arr(2, x - 1)
                End If
            Next
        Next
    End Sub
#End Region

#Region "线程池队列"

    Private Sub MainManager()

    End Sub

#End Region

#Region "指定控件父级,并重新指定位置"
    Private Sub UI()
        Label1.Parent = PictureBox1
        Label2.Parent = PictureBox1
        Label3.Parent = PictureBox1
        Label4.Parent = PictureBox1
        Label5.Parent = PictureBox1
        Label6.Parent = PictureBox1
        Label10.Parent = PictureBox1
        Label11.Parent = PictureBox1
        Label12.Parent = PictureBox1
        Label13.Parent = PictureBox1
        Label14.Parent = PictureBox1
        Label15.Parent = PictureBox1
        Dim x As Integer = PictureBox1.Location.Y

        Label1.Location = New Point(Label1.Location.X, Label1.Location.Y - x)

        Label2.Location = New Point(Label2.Location.X, Label2.Location.Y - x)

        Label3.Location = New Point(Label3.Location.X, Label3.Location.Y - x)

        Label4.Location = New Point(Label4.Location.X, Label4.Location.Y - x)

        Label5.Location = New Point(Label5.Location.X, Label5.Location.Y - x)

        Label6.Location = New Point(Label6.Location.X, Label6.Location.Y - x)

        Label10.Location = New Point(Label10.Location.X, Label10.Location.Y - x)

        Label11.Location = New Point(Label11.Location.X, Label11.Location.Y - x)

        Label12.Location = New Point(Label12.Location.X, Label12.Location.Y - x)

        Label13.Location = New Point(Label13.Location.X, Label13.Location.Y - x)

        Label14.Location = New Point(Label14.Location.X, Label14.Location.Y - x)

        Label15.Location = New Point(Label15.Location.X, Label15.Location.Y - x)
    End Sub
#End Region

#Region "GDI初始值"

#Region "默认设置"
    Private Sub GDIdefault()
        scalenumber = 1000
        movespeed = 1000
        Framecolor = New Pen(Color.RoyalBlue, 2)
        gridcolor = New Pen(Color.YellowGreen, 1)
        scalecolor = New Pen(Color.Blue, 2)
        Dwgcolor = New Pen(Color.OrangeRed, 2)
        ComboBox5.Items.Add(500)
        ComboBox5.Items.Add(1000)
        ComboBox5.Items.Add(1500)
        ComboBox6.Items.Add(100)
        ComboBox6.Items.Add(200)
        ComboBox6.Items.Add(300)
        ComboBox6.Items.Add(500)
        ComboBox6.Items.Add(1000)
        ComboBox6.Items.Add(2000)
        Call loadingsystemcolor(ComboBox1)
        Call loadingsystemcolor(ComboBox2)
        Call loadingsystemcolor(ComboBox3)
        Call loadingsystemcolor(ComboBox4)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "" Then Exit Sub
        Dim tempcolor As Color = Color.FromName(ComboBox1.Text)
        gridcolor = New Pen(tempcolor, 1)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "" Then Exit Sub
        Dim tempcolor As Color = Color.FromName(ComboBox2.Text)
        Dwgcolor = New Pen(tempcolor, 2)
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "" Then Exit Sub
        Dim tempcolor As Color = Color.FromName(ComboBox3.Text)
        Framecolor = New Pen(tempcolor, 2)
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "" Then Exit Sub
        Dim tempcolor As Color = Color.FromName(ComboBox4.Text)
        scalecolor = New Pen(tempcolor, 2)
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        If ComboBox5.Text = "" Then Exit Sub
        scalenumber = ComboBox5.Text
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6.Text = "" Then Exit Sub
        abnormalGdi.Enabled = False
        abnormalGdi.Interval = ComboBox6.Text
        abnormalGdi.Enabled = True
    End Sub

#End Region

#Region "加载颜色"
    Private Sub loadingsystemcolor(obj As ComboBox)
        obj.DrawMode = DrawMode.OwnerDrawFixed
        obj.DropDownStyle = ComboBoxStyle.DropDownList
        obj.ItemHeight = 15
        '避免闪烁beginupdate  
        obj.BeginUpdate()
        obj.Items.Clear()
        Dim pi As Reflection.PropertyInfo
        For Each pi In GetType(Color).GetProperties(Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)
            obj.Items.Add(pi.Name)
        Next
        obj.EndUpdate()
    End Sub

    Private Sub ComboBox1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox1.DrawItem
        If e.Index < 0 Then Exit Sub

        Dim rect As Rectangle = e.Bounds '每一项的边框  

        '绘制项如果被选中则显示高亮显示背景,否则用白色  
        'If e.State And DrawItemState.Selected Then
        '    e.Graphics.FillRectangle(SystemBrushes.Highlight, rect)
        'Else
        '    e.Graphics.FillRectangle(SystemBrushes.Window, rect)
        'End If

        Dim colorname As String = ComboBox1.Items(e.Index)
        Dim b As New SolidBrush(Color.FromName(colorname))

        '缩小选定项区域()  
        rect.Inflate(-5, -1)
        '填充颜色(文字对应的颜色)  
        e.Graphics.FillRectangle(b, rect)
        '绘制边框()  
        '  e.Graphics.DrawRectangle(Pens.Black, rect)
        Dim b2 As Brush
        '确定显示的文字的颜色()  
        If CInt(b.Color.R) + CInt(b.Color.G) + CInt(b.Color.B) > 128 * 3 Then
            b2 = Brushes.Black
        Else
            b2 = Brushes.White

        End If
        e.Graphics.DrawString(colorname, Me.ComboBox1.Font, b2, rect.X, rect.Y)

    End Sub
    Private Sub ComboBox2_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox2.DrawItem
        If e.Index < 0 Then Exit Sub

        Dim rect As Rectangle = e.Bounds '每一项的边框  
        Dim colorname As String = ComboBox2.Items(e.Index)
        Dim b As New SolidBrush(Color.FromName(colorname))

        '缩小选定项区域()  
        rect.Inflate(-5, -1)
        '填充颜色(文字对应的颜色)  
        e.Graphics.FillRectangle(b, rect)
        '绘制边框()  
        '  e.Graphics.DrawRectangle(Pens.Black, rect)
        Dim b2 As Brush
        '确定显示的文字的颜色()  
        If CInt(b.Color.R) + CInt(b.Color.G) + CInt(b.Color.B) > 128 * 3 Then
            b2 = Brushes.Black
        Else
            b2 = Brushes.White

        End If
        e.Graphics.DrawString(colorname, Me.ComboBox2.Font, b2, rect.X, rect.Y)

    End Sub

    Private Sub ComboBox3_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox3.DrawItem
        If e.Index < 0 Then Exit Sub

        Dim rect As Rectangle = e.Bounds '每一项的边框  
        Dim colorname As String = ComboBox3.Items(e.Index)
        Dim b As New SolidBrush(Color.FromName(colorname))

        '缩小选定项区域()  
        rect.Inflate(-5, -1)
        '填充颜色(文字对应的颜色)  
        e.Graphics.FillRectangle(b, rect)
        '绘制边框()  
        '  e.Graphics.DrawRectangle(Pens.Black, rect)
        Dim b2 As Brush
        '确定显示的文字的颜色()  
        If CInt(b.Color.R) + CInt(b.Color.G) + CInt(b.Color.B) > 128 * 3 Then
            b2 = Brushes.Black
        Else
            b2 = Brushes.White

        End If
        e.Graphics.DrawString(colorname, Me.ComboBox3.Font, b2, rect.X, rect.Y)

    End Sub
    Private Sub ComboBox4_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox4.DrawItem
        If e.Index < 0 Then Exit Sub

        Dim rect As Rectangle = e.Bounds '每一项的边框  
        Dim colorname As String = ComboBox4.Items(e.Index)
        Dim b As New SolidBrush(Color.FromName(colorname))

        '缩小选定项区域()  
        rect.Inflate(-5, -1)
        '填充颜色(文字对应的颜色)  
        e.Graphics.FillRectangle(b, rect)
        '绘制边框()  
        '  e.Graphics.DrawRectangle(Pens.Black, rect)
        Dim b2 As Brush
        '确定显示的文字的颜色()  
        If CInt(b.Color.R) + CInt(b.Color.G) + CInt(b.Color.B) > 128 * 3 Then
            b2 = Brushes.Black
        Else
            b2 = Brushes.White

        End If
        e.Graphics.DrawString(colorname, Me.ComboBox4.Font, b2, rect.X, rect.Y)

    End Sub
#End Region

#End Region

#Region "键盘钩子"

    Private Sub systemhook_KeyDown(sender As Object, e As KeyEventArgs) Handles systemhook.KeyDown
        If (keydownBoole = False) Then
            If (e.KeyCode = 160) Then
                keyShift = True
            End If
            If (e.KeyCode = 162) Then
                keyCtrl = True
            End If
            If (e.KeyCode = 68) Then
                KeyD = True
            End If

            If (keyShift = True And keyCtrl = True And KeyD = True) Then
                If (loginname = "开发者") Then
                    Dim frm As New DevelopersManager
                    frm.ShowDialog()
                End If
                keydownBoole = True
            End If
        End If

    End Sub

    Private Sub systemhook_KeyUp(sender As Object, e As KeyEventArgs) Handles systemhook.KeyUp
        If (e.KeyCode = 160) Then
            keydownBoole = False
            keyShift = False
        End If
        If (e.KeyCode = 162) Then
            keydownBoole = False
            keyCtrl = False
        End If
        If (e.KeyCode = 68) Then
            keydownBoole = False
            KeyD = False
        End If
    End Sub


#End Region

#Region "菜单"

    Private Sub 协议相关ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 协议相关ToolStripMenuItem.Click
        Dim proc As New Process
        proc.Start(AppPath + "\MODBUS通讯协议.pdf")
    End Sub

    Private Sub 开发人员ToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub 编辑脚本ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 编辑脚本ToolStripMenuItem.Click
        Dim frm As New ScriptManager
        frm.ShowDialog()
    End Sub
#End Region

#Region "速度条控制"
    Private Sub DS进度条5_ProcessValueChanged(Sender As Object, Db As Single) Handles DS进度条5.ProcessValueChanged
        If DS进度条5.当前值 > 350 Then
            DS进度条5.前景颜色 = Color.IndianRed
            Label5.ForeColor = Color.IndianRed
        ElseIf DS进度条5.当前值 > 200 Then
            DS进度条5.前景颜色 = Color.DarkOrange
            Label5.ForeColor = Color.DarkOrange
        ElseIf DS进度条5.当前值 < 200 Then
            DS进度条5.前景颜色 = Color.DarkOliveGreen
            Label5.ForeColor = Color.DarkOliveGreen
        End If
    End Sub

    Private Sub DS进度条6_ProcessValueChanged(Sender As Object, Db As Single) Handles DS进度条6.ProcessValueChanged
        If DS进度条6.当前值 > 350 Then
            DS进度条6.前景颜色 = Color.IndianRed
            Label6.ForeColor = Color.IndianRed
        ElseIf DS进度条6.当前值 > 200 Then
            DS进度条6.前景颜色 = Color.DarkOrange
            Label6.ForeColor = Color.DarkOrange
        ElseIf DS进度条6.当前值 < 200 Then
            DS进度条6.前景颜色 = Color.DarkOliveGreen
            Label6.ForeColor = Color.DarkOliveGreen
        End If
    End Sub

    Private Sub DS进度条4_ProcessValueChanged(Sender As Object, Db As Single) Handles DS进度条4.ProcessValueChanged
        If DS进度条4.当前值 > 350 Then
            DS进度条4.前景颜色 = Color.IndianRed
            Label4.ForeColor = Color.IndianRed
        ElseIf DS进度条4.当前值 > 200 Then
            Label4.ForeColor = Color.DarkOrange
            DS进度条4.前景颜色 = Color.DarkOrange
        ElseIf DS进度条4.当前值 < 200 Then
            Label4.ForeColor = Color.DarkOliveGreen
            DS进度条4.前景颜色 = Color.DarkOliveGreen
        End If
    End Sub

    Private Sub DS进度条3_ProcessValueChanged(Sender As Object, Db As Single) Handles DS进度条3.ProcessValueChanged
        If DS进度条3.当前值 > 350 Then
            DS进度条3.前景颜色 = Color.IndianRed
            Label3.ForeColor = Color.IndianRed
        ElseIf DS进度条3.当前值 > 200 Then
            DS进度条3.前景颜色 = Color.DarkOrange
            Label3.ForeColor = Color.DarkOrange
        ElseIf DS进度条3.当前值 < 200 Then
            DS进度条3.前景颜色 = Color.DarkOliveGreen
            Label3.ForeColor = Color.DarkOliveGreen
        End If
    End Sub

    Private Sub DS进度条2_ProcessValueChanged(Sender As Object, Db As Single) Handles DS进度条1.ProcessValueChanged
        If DS进度条1.当前值 > 350 Then
            DS进度条1.前景颜色 = Color.IndianRed
            Label2.ForeColor = Color.IndianRed
        ElseIf DS进度条1.当前值 > 200 Then
            DS进度条1.前景颜色 = Color.DarkOrange
            Label2.ForeColor = Color.DarkOrange
        ElseIf DS进度条1.当前值 < 200 Then
            DS进度条1.前景颜色 = Color.DarkOliveGreen
            Label2.ForeColor = Color.DarkOliveGreen
        End If
    End Sub

    Private Sub DS进度条1_ProcessValueChanged(Sender As Object, Db As Single) Handles DS进度条2.ProcessValueChanged
        If DS进度条2.当前值 > 350 Then
            DS进度条2.前景颜色 = Color.IndianRed
            Label1.ForeColor = Color.IndianRed
        ElseIf DS进度条2.当前值 > 200 Then
            DS进度条2.前景颜色 = Color.DarkOrange
            Label1.ForeColor = Color.DarkOrange
        ElseIf DS进度条2.当前值 < 200 Then
            DS进度条2.前景颜色 = Color.DarkOliveGreen
            Label1.ForeColor = Color.DarkOliveGreen
        End If
    End Sub
#End Region

#Region "连接设备"
    Public Sub Connectdevice()
        CheckForIllegalCrossThreadCalls = False
        Try
            SerialPort1.PortName = 端口
            SerialPort1.BaudRate = 波特率
            If 校验 = "奇校验" Then
                SerialPort1.Parity = IO.Ports.Parity.Odd
            ElseIf 校验 = "偶校验" Then
                SerialPort1.Parity = IO.Ports.Parity.Even
            Else
                SerialPort1.Parity = IO.Ports.Parity.None
            End If
            SerialPort1.DataBits = 数据位
            If 停止位 = 1 Then
                SerialPort1.StopBits = IO.Ports.StopBits.One
            ElseIf 停止位 = 1.5 Then
                SerialPort1.StopBits = IO.Ports.StopBits.OnePointFive
            Else
                SerialPort1.StopBits = IO.Ports.StopBits.Two
            End If
            SerialPort1.Encoding = System.Text.Encoding.Default
            SerialPort1.DtrEnable = True
            SerialPort1.NewLine = vbCrLf
            SerialPort1.ReadTimeout = 2000
            SerialPort1.ReadBufferSize = 6
            SerialPort1.Open()

        Catch ex As Exception
            MsgBox("连接失败" + vbNewLine + ErrorToString(), vbDefaultButton1, "错误")
        End Try
    End Sub
#End Region

#Region "向设备发送数据"
    Public Function send_plcdata(data As String)      '发送数据 
        Try
            tempsenddata = data
            If data = "" Then Exit Function

            CRC16Bit_paity = GetCRC16Bit.Get_CRC16(data)
            Splitdata = Split(data, " ")

            If Splitdata.length < 6 Then Exit Function

            ReDim Databyte(Splitdata.Length + 1)

            For i As Integer = 0 To Splitdata.Length - 1
                Databyte(i) = "&H" & Splitdata(i)
            Next
            Databyte(Splitdata.Length) = "&H" & CRC16Bit_paity.Substring(0, 2)
            CRCHighNumberten = Databyte(Splitdata.length)
            Databyte(Splitdata.Length + 1) = "&H" & CRC16Bit_paity.Substring(2)
            CRCLowNumberten = Databyte(Splitdata.length + 1)
            System.Threading.Thread.Sleep(10)
            SerialPort1.DiscardInBuffer()
            SerialPort1.DiscardOutBuffer()

            SerialPort1.Write(Databyte, 0, Databyte.Length)

        Catch ex As Exception

            Call Connectdevice()
            SerialPort1.Write(Databyte, 0, Databyte.Length)
            ' MsgBox("出错了" + vbNewLine + ErrorToString(), vbDefaultButton1, "错误")
        End Try
    End Function


#End Region

#Region "动态曲线"

#Region "Chart控件，暂时不用"

#Region "图表样式"

    'Chart1.BackGradientStyle= = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;//指定图表元素的渐变样式(中心向外，从左到右，从上到下等等)

    'Chart1.BackSecondaryColor = System.Drawing.Color.Yellow;//设置背景的辅助颜色

    'Chart1.BorderlineColor = System.Drawing.Color.Yellow;//设置图像边框的颜色

    'Chart1.BorderlineDashStyle=  System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;//设置图像边框线的样式(实线、虚线、点线)

    'Chart1.BorderlineWidth = 2;//设置图像的边框宽度

    'Chart1.BorderSkin.SkinStyle=  System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;//设置图像的边框外观样式

    'Chart1.BackColor = System.Drawing.Color.Yellow;//设置图表的背景颜色

    '#endregion





    '#region 数据样式

    'Chart1.Series["Series1"].XValueMember = "name";//设置X轴的数据源

    'Chart1.Series["Series1"].YValueMembers = "mobile";//设置Y轴的数据源

    'Chart1.Series["Series2"].XValueMember = "name";

    'Chart1.Series["Series2"].YValueMembers = "id";

    'Chart1.Series["Series2"].Color = System.Drawing.Color.Red;//设置颜色

    'Chart1.Series["Series2"].ChartType= System.Web.UI.DataVisualization.Charting.SeriesChartType.Line;//设置图表的类型(饼状、线状等等)

    'Chart1.Series["Series1"].IsValueShownAsLabel = true;//设置是否在Chart中显示坐标点值

    'Chart1.Series["Series1"].BorderColor = System.Drawing.Color.Red;//设置数据边框的颜色

    'Chart1.BackColor = System.Drawing.Color.Red;//设置图表的背景颜色

    'Chart1.Series["Series1"].Color = System.Drawing.Color.Black;//设置数据的颜色

    'Chart1.Series["Series1"].Name = "数据1";//设置数据名称

    'Chart1.Series["数据1"].ShadowOffset = 1;//设置阴影偏移量

    'Chart1.Series["数据1"].ShadowColor = System.Drawing.Color.PaleGreen;//设置阴影颜色

#End Region

#Region "图表区域样式"



    'Chart1.ChartAreas["ChartArea1"].Name = "图表区域";

    'Chart1.ChartAreas["图表区域"].Position.Auto = true;//设置是否自动设置合适的图表元素

    'Chart1.ChartAreas["图表区域"].ShadowColor = System.Drawing.Color.YellowGreen;//设置图表的阴影颜色

    'Chart1.ChartAreas["图表区域"].Position.X=5.089137F;//设置图表元素左上角对应的X坐标

    'Chart1.ChartAreas["图表区域"].Position.Y = 5.895753F;//设置图表元素左上角对应的Y坐标

    'Chart1.ChartAreas["图表区域"].Position.Height = 86.76062F;//设置图表元素的高度

    'Chart1.ChartAreas["图表区域"].Position.Width = 88F;//设置图表元素的宽度



    'Chart1.ChartAreas["图表区域"].InnerPlotPosition.Auto = false;//设置是否在内部绘图区域中自动设置合适的图表元素

    'Chart1.ChartAreas["图表区域"].InnerPlotPosition.Height = 85F;//设置图表元素内部绘图区域的高度

    'Chart1.ChartAreas["图表区域"].InnerPlotPosition.Width = 86F;//设置图表元素内部绘图区域的宽度

    'Chart1.ChartAreas["图表区域"].InnerPlotPosition.X = 8.3969F;//设置图表元素内部绘图区域左上角对应的X坐标

    'Chart1.ChartAreas["图表区域"].InnerPlotPosition.Y = 3.63068F;//设置图表元素内部绘图区域左上角对应的Y坐标



    'Chart1.ChartAreas["图表区域"].Area3DStyle.Inclination = 10;//设置三维图表的旋转角度

    'Chart1.ChartAreas["图表区域"].Area3DStyle.IsClustered = true;//设置条形图或柱形图的的数据系列是否为簇状

    'Chart1.ChartAreas["图表区域"].Area3DStyle.IsRightAngleAxes = true;//设置图表区域是否使用等角投影显示

    'Chart1.ChartAreas["图表区域"].Area3DStyle.LightStyle = System.Web.UI.DataVisualization.Charting.LightStyle.Realistic;//设置图表的照明类型(色调随旋转角度改变而改变，不应用照明，色调不改变)

    'Chart1.ChartAreas["图表区域"].Area3DStyle.Perspective = 50;//设置三维图区的透视百分比

    'Chart1.ChartAreas["图表区域"].Area3DStyle.Rotation = 60;//设置三维图表区域绕垂直轴旋转的角度

    'Chart1.ChartAreas["图表区域"].Area3DStyle.WallWidth = 0;//设置三维图区中显示的墙的宽度

    'Chart1.ChartAreas["图表区域"].Area3DStyle.Enable3D = true;//设置是否显示3D效果



    'Chart1.ChartAreas["图表区域"].BackColor = System.Drawing.Color.Green;//设置图表区域的背景颜色

    'Chart1.ChartAreas["图表区域"].BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;//指定图表元素的渐变样式(中心向外，从左到右，从上到下等等)

    'Chart1.ChartAreas["图表区域"].BackSecondaryColor = System.Drawing.Color.White;//设置图表区域的辅助颜色

    'Chart1.ChartAreas["图表区域"].BorderColor = System.Drawing.Color.White;//设置图表区域边框颜色

    'Chart1.ChartAreas["图表区域"].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;//设置图像边框线的样式(实线、虚线、点线)



    'Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);//设置X轴下方的提示信息的字体属性

    'Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.Format = "";//设置标签文本中的格式字符串

    'Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.Interval=5D;//设置标签间隔的大小

    'Chart1.ChartAreas["图表区域"].AxisX.LabelStyle.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;//设置间隔大小的度量单位

    'Chart1.ChartAreas["图表区域"].AxisX.LineColor = System.Drawing.Color.White;//设置X轴的线条颜色

    'Chart1.ChartAreas["图表区域"].AxisX.MajorGrid.Interval=5D;//设置主网格线与次要网格线的间隔

    'Chart1.ChartAreas["图表区域"].AxisX.MajorGrid.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;//设置主网格线与次网格线的间隔的度量单位

    'Chart1.ChartAreas["图表区域"].AxisX.MajorGrid.LineColor = System.Drawing.Color.Snow;//设置网格线的颜色

    'Chart1.ChartAreas["图表区域"].AxisX.MajorTickMark.Interval = 5D;//设置刻度线的间隔

    'Chart1.ChartAreas["图表区域"].AxisX.MajorTickMark.IntervalType = System.Web.UI.DataVisualization.Charting.DateTimeIntervalType.Number;//设置刻度线的间隔的度量单位



    'Chart1.ChartAreas["图表区域"].AxisY.IsLabelAutoFit = false;//设置是否自动调整轴标签

    'Chart1.ChartAreas["图表区域"].AxisY.IsStartedFromZero = false;//设置是否自动将数据值均为正值时轴的最小值设置为0，存在负数据值时，将使用数据轴最小值

    'Chart1.ChartAreas["图表区域"].AxisY.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);//设置Y轴左侧的提示信息的字体属性

    'Chart1.ChartAreas["图表区域"].AxisY.LineColor = System.Drawing.Color.DarkBlue;//设置轴的线条颜色

    'Chart1.ChartAreas["图表区域"].AxisY.MajorGrid.LineColor = System.Drawing.Color.White;//设置网格线颜色



    'Chart1.ChartAreas["图表区域"].AxisY.Maximum = getmax() + 100;//设置Y轴最大值

    'Chart1.ChartAreas["图表区域"].AxisY.Minimum=0;//设置Y轴最小值



#End Region

#Region "图例样式"

    'Legend l = New Legend();//初始化一个图例的实例

    'l.Alignment = System.Drawing.StringAlignment.Near;//设置图表的对齐方式(中间对齐，靠近原点对齐，远离原点对齐)

    'l.BackColor = System.Drawing.Color.Black;//设置图例的背景颜色

    'l.DockedToChartArea = "ChartArea1";//设置图例要停靠在哪个区域上

    'l.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;//设置停靠在图表区域的位置(底部、顶部、左侧、右侧)

    'l.Font =New System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);//设置图例的字体属性

    'l.IsTextAutoFit = true;//设置图例文本是否可以自动调节大小

    'l.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;//设置显示图例项方式(多列一行、一列多行、多列多行)

    'l.Name = "l1";//设置图例的名称

    'Chart1.Legends.Add(l.Name);

#End Region


    'Private Sub DS按钮1_ButtonClick(Sender As Object) Handles DS按钮1.ButtonClick

    '    Dim k

    '    Chart1.ChartAreas(0).AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkSeaGreen     '设置网格线颜色
    '    Chart1.ChartAreas(0).AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkSeaGreen     '设置网格线颜色
    '    Chart1.ChartAreas（0）.AxisX.LineColor = System.Drawing.Color.White ';//设置X轴的线条颜色
    '    ' Chart1.ChartAreas（0）.AxisX.LabelStyle.Font = New System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold) ';//设置X轴下方的提示信息的字体属性

    '    '设置X、Y轴的提示信息的字体颜色
    '    Chart1.ChartAreas（0）.AxisX.LabelStyle.ForeColor = Color.AliceBlue
    '    Chart1.ChartAreas（0）.AxisY.LabelStyle.ForeColor = Color.AliceBlue

    '    '设置X轴坐标的间隔为10
    '    Chart1.ChartAreas（0）.AxisX.Interval = 1
    '    '设置X轴坐标的偏移为1
    '    '  Chart1.ChartAreas（0）.AxisX.IntervalOffset = 1
    '    '设置X轴坐标的值的间隔为1
    '    Chart1.ChartAreas(0).AxisX.LabelStyle.Interval = 1
    '    '设置交错显示，例如数据多时可分两行显示
    '    Chart1.ChartAreas（0）.AxisX.LabelStyle.IsStaggered = True
    '    Chart1.Series(0).ChartType = SeriesChartType.Line
    '    Do
    '        My.Application.DoEvents()
    '        k += 1
    '        yy = GetValue()
    '        Dim i As Integer
    '        For i = 0 To yy.Length - 1
    '            y(i) = yy(i)
    '        Next

    '        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
    '        Chart1.Series(0).Points.DataBindXY(x, y)

    '        '   Chart1.Series(0).IsValueShownAsLabel = True
    '        ' Chart1.Series(0).LabelForeColor = Color.Red
    '        '  Chart1.Legends(0).ForeColor = Color.Red
    '        Chart1.ChartAreas(0).AxisX.Minimum = 0
    '        Chart1.ChartAreas(0).AxisX.Maximum = yy.Length
    '        Chart1.ChartAreas(0).AxisX.Interval = 1
    '        System.Threading.Thread.Sleep(1000)
    '    Loop Until k > 100
    'End Sub

    'Function GetValue() As Array '这是一个模拟取数的函数
    '    Dim a As Integer = 0
    '    If yy Is Nothing Then
    '        a = 0
    '    Else
    '        a = yy.Length
    '    End If
    '    If a = 11 Then
    '        For i As Integer = 0 To 9
    '            yy(i) = yy(i + 1)
    '            x(i) = x(i + 1)
    '        Next
    '        yy(10) = Math.Round(a * Rnd(100) * 4.0264, 2)
    '        x(10) = Format(Now, "hh:mm:ss")
    '    Else
    '        ReDim Preserve yy(a)
    '        yy(a) = Math.Round(a * Rnd(100) * 4.0264, 2)
    '        x(a) = Format(Now, "hh:mm:ss")
    '    End If
    '    Return yy
    'End Function

#End Region



#End Region

#Region "GDI+绘图"

    Private Sub PictureBox2_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox2.Paint
        Dim G = e.Graphics

        '绘制图表外框三条线
        G.DrawLine(Framecolor, 50, 15, 50, 165)
        G.DrawLine(Framecolor, 50, 165, 490, 165)
        G.DrawLine(Framecolor, 485, 15, 485, 165)
        G.DrawLine(Framecolor, 490, 15, 490, 165)
        G.DrawLine(Framecolor, 469, 15, 490, 15)
        'Y方向绘制
        For x = 150 To 15 Step -15
            '绘制Y刻度线
            G.DrawLine(scalecolor, 40, x, 50, x)
            '绘制X方向网格线
            G.DrawLine(gridcolor, 51, x, 469, x)
        Next
        'Y轴刻度线有10格，设置的刻度值/10，得出一平均个刻度的数值
        Dim newvalue% = scalenumber / 10
        For x = 10 To 1 Step -1
            '将Y刻度绘上数字，平均一个网格刻度*网格，得到实际刻度
            G.DrawString(newvalue * x, fontcolor, Brushes.Red, 10, scalepoiont)
            '每个网格间距为15，在当前刻度的位置的基础上+15，得到下一个刻度的坐标位置
            scalepoiont += 15

        Next
        '因为重绘事件实时刷新，须要将Y轴刻度的初始位置初始化
        scalepoiont = 10

        '绘制Y方向网络线
        For x = 80 To 490 Step 30
            G.DrawLine(gridcolor, x, 15, x, 163)
        Next

        '准备绘制曲线

        '每人网络的间距为15，用刻度除去15，得出每一个实际所占长度
        Dim newval = scalenumber / 10
        Dim n = newval / 15

        For x = 1 To temparraylist.Count - 1
            '第一个点的Y位置220(刻度基准0点)-当前值/每格长度，220-y/n
            Dim LineOne% = (165 - temparraylist(x - 1)(0, 0) / n)
            '第二个点的Y位置220(刻度基准0点)-当前值/每格长度，220-y/n
            Dim Linetwo% = (165 - temparraylist(x)(0, 0) / n)
            '开始绘制曲线
            G.DrawLine(Dwgcolor, temparraylist(x - 1)(0, 1), LineOne,
                       temparraylist(x)(0, 1), Linetwo)
            '绘制曲线点文字
            G.DrawString(temparraylist(x - 1)(0, 0), fontcolor, Brushes.Tomato, temparraylist(x - 1)(0, 1), LineOne)
            '因为x方向的网格太小，无法装下太多文字，错开位置显示
            If x Mod 2 = 0 Then
                '错开显示到第二排，x轴向左移 时间刻度
                G.DrawString(temparraylist(x)(0, 2), fontcolor, Brushes.OrangeRed,
                             temparraylist(x - 1)(0, 1) - 30, 180)
            Else
                '错开显示到第一排，x轴向左移 时间刻度
                G.DrawString(temparraylist(x)(0, 2), fontcolor, Brushes.OrangeRed,
                            temparraylist(x - 1)(0, 1) - 30, 170)
            End If

        Next

    End Sub

    Public Sub add(obj As Object)
        '队列方法，入队后高入低出
        If temparraylist.Count >= queueCount Then
            temparraylist.Dequeue()
        End If
        temparraylist.Enqueue(obj)

        '遍历队例，在原基础上减去移动步长（30），因为y轴网格间距为30，每一步移动一格
        For x = 1 To temparraylist.Count
            temparraylist(x - 1)(0, 1) = temparraylist(x - 1)(0, 1) - Movestep
        Next

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '如果队列的数据大于1个，调用画板重绘
        If temparraylist.Count <= 1 Then Exit Sub
        PictureBox2.Refresh()
    End Sub

    Private Sub abnormalGdi_Tick(sender As Object, e As EventArgs) Handles abnormalGdi.Tick
        '模拟数据并加入队列 
        Dim currentvalue(0 To 0, 0 To 2)
        '该数组位置存放曲线数值，实际数据
        currentvalue(0, 0) = scalenumber - （Int(Rnd() * scalenumber - 20)）
        '移动时的初始位置，即右边的第一条y轴线位置
        currentvalue(0, 1) = 500
        'X轴刻度标签
        currentvalue(0, 2) = Format(Now, "hh:mm:ss")
        '将数据添加到队列
        add(currentvalue)
        PictureBox3.Refresh()
        Dim G As Graphics = PictureBox3.CreateGraphics()

        '绘制事件级别实心五角星
        DrawStar（Me.CreateGraphics， New Point（158， 35）， 7， True）
        DrawStar（Me.CreateGraphics， New Point（173， 35）， 7， True）
        DrawStar（Me.CreateGraphics， New Point（188， 35）， 7， True）
        DrawStar（Me.CreateGraphics， New Point（203， 35）， 7， True）


    End Sub
    Private Sub PictureBox3_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox3.Paint
        ' Dim mpen As New Pen(Color.Blue)
        Dim G As Graphics = e.Graphics

        Dim fontcolor As New Font("新宋体", 8)
        Dim fontcolor1 As New Font("新宋体", 9)
        ' Dim fontpoint As New PointF(1, 30)
        G.DrawLine(Pens.YellowGreen, 70, 5, 70, 180)
        G.DrawLine(Pens.YellowGreen, 150, 5, 150, 180)
        '测试用
        '绘制日期时间
        G.DrawString("03-17 23:55", fontcolor, Brushes.CadetBlue, 1, 30)
        '绘制事件信息
        G.DrawString("X轴行程超限", fontcolor, Drawing.Brushes.CadetBlue, 77, 30)
        '矩形点位置
        Dim rectangle As Point() = {New Point(0, 5), New Point(209, 5), New Point(209, 180),
                                                         New Point(0, 180), New Point(0, 5)}
        '绘制矩形  
        G.DrawLines(Pens.YellowGreen, rectangle)

        G.DrawLine(Pens.YellowGreen, 1, 25, 208, 25)
        G.DrawLine(Pens.PaleVioletRed, 1, 45, 208, 45)
        G.DrawLine(Pens.PaleVioletRed, 1, 65, 208, 65)
        G.DrawLine(Pens.PaleVioletRed, 1, 85, 208, 85)
        G.DrawLine(Pens.PaleVioletRed, 1, 105, 208, 105)
        G.DrawLine(Pens.PaleVioletRed, 1, 125, 208, 125)
        G.DrawLine(Pens.PaleVioletRed, 1, 145, 208, 145)
        G.DrawLine(Pens.PaleVioletRed, 1, 165, 208, 165)
        G.DrawLine(Pens.PaleVioletRed, 1, 185, 208, 185)
    End Sub

    Sub DrawStar（ByVal g As Graphics， ByVal center As Point， ByVal radius As Integer， ByVal isSolid As Boolean）
        Dim Grap As Graphics = PictureBox3.CreateGraphics()
        Dim pts（9） As Point

        pts（0） = New Point（center.X， center.Y - radius）

        pts（1） = RotateTheta（pts（0）， center， 36.0）

        Dim len As Double = radius * Math.Sin（（18.0 * Math.PI / 180.0）） / Math.Sin（（126.0 * Math.PI / 180.0））

        pts（1）.X = CInt（center.X + len * （pts（1）.X - center.X） / radius）

        pts（1）.Y = CInt（center.Y + len * （pts（1）.Y - center.Y） / radius）

        Dim i As Integer

        For i = 1 To 4

            pts（（2 * i）） = RotateTheta（pts（（2 * （i - 1）））， center， 72.0）

            pts（（2 * i + 1）） = RotateTheta（pts（（2 * i - 1））， center， 72.0）

        Next i

        If isSolid = False Then

            Dim mPen As New Pen（New SolidBrush（Color.CadetBlue））

            Grap.DrawPolygon（mPen， pts） '画一个空心五角星

        Else

            Dim mBrush As New SolidBrush（Color.CadetBlue）

            Grap.FillPolygon（mBrush， pts） '画一个实心的五角星

        End If

    End Sub

    Function RotateTheta（ByVal pt As Point， ByVal center As Point， ByVal theta As Double） As Point

        Dim x As Integer = CInt（center.X + （pt.X - center.X） * Math.Cos（（theta * Math.PI / 180）） - （pt.Y - center.Y） * Math.Sin（（theta * Math.PI / 180）））

        Dim y As Integer = CInt（center.Y + （pt.X - center.X） * Math.Sin（（theta * Math.PI / 180）） + （pt.Y - center.Y） * Math.Cos（（theta * Math.PI / 180）））

        Return New Point（x， y）

    End Function



#End Region

#Region "用户操作状态"

    Private Sub systemJournal()
        i += 1
        Select Case i
            Case Is = 1
                Richtext("System", "启动线程", "0x1304", "成功")
            Case Is = 2
                Richtext("System", "关闭线程", "0x1304", "-1 (0xffffffff)")
            Case Is = 3
                Richtext("Admin", "脚本操作", "添加了脚本Start事件", "成功")
            Case Is = 4
                Richtext("Admin", "脚本操作", "添加了脚本Updata事件", "成功")
        End Select

    End Sub

    Private Sub Richtext(username As String, Eventname As String, Execution As String, state As String)
        RichTextBox1.ScrollBars = 2
        Dim str() As String
        str = {Now & " ", "[" & username & "]" & " ", Eventname & " ", "[" & Execution & "]" & " ", "状态：", state}
        Dim lenth = RichTextBox1.Text.Length

        For y As Byte = 0 To UBound(str)
            RichTextBox1.AppendText(str(y))
        Next

        If str(3) <> "" Then
            RichTextBox1.Select(lenth + RichTextBox1.Lines（i - 1).IndexOf(str(3)), str(3).Length)
            RichTextBox1.SelectionColor = Color.BlueViolet
        End If
        If ((str(1)).Contains("[System]")) Then
            RichTextBox1.Select(lenth + RichTextBox1.Lines（i - 1).IndexOf("System"), 6)
            RichTextBox1.SelectionColor = Color.Red
        ElseIf (str(1)).Contains("[Admin]") Then
            RichTextBox1.Select(lenth + RichTextBox1.Lines（i - 1).IndexOf("Admin"), 5)
            RichTextBox1.SelectionColor = Color.Orange
        ElseIf (str(1)).Contains("[User]") Then
            RichTextBox1.Select(lenth + RichTextBox1.Lines（i - 1).IndexOf("User"), 4)
            RichTextBox1.SelectionColor = Color.Green
        End If
        If ((str(5)).Contains("成功")) Then
            RichTextBox1.Select(lenth + RichTextBox1.Lines（i - 1).IndexOf("成功"), 2)
            RichTextBox1.SelectionColor = Color.Green
        Else
            RichTextBox1.Select(lenth + RichTextBox1.Lines（i - 1).IndexOf(str(5)), Len(str(5)))
            RichTextBox1.SelectionColor = Color.Red
        End If


        'For x As Byte = 0 To str.Length - 1

        '    Dim lenth = RichTextBox1.Text.Length

        '    RichTextBox1.AppendText(str(x))
        '    '  RichTextBox1.ForeColor = Color.White
        '    If (RichTextBox1.Lines(0).Contains("System")) Then
        '        RichTextBox1.Select(lenth + RichTextBox1.Lines（0).IndexOf("System"), 6)
        '        RichTextBox1.SelectionColor = Color.Red
        '        RichTextBox1.SelectionLength = 0
        '    End If
        '    If (RichTextBox1.Lines(0).Contains("成功")) Then
        '        RichTextBox1.Select(lenth + RichTextBox1.Lines（0).IndexOf("成功"), 2)
        '        RichTextBox1.SelectionColor = Color.Green
        '        RichTextBox1.SelectionLength = 0
        '    End If
        'Next

        '' Clear all text from the RichTextBox;
        'RichTextBox1.Clear()
        '' Indent bulleted text 30 pixels away from the bullet.
        'RichTextBox1.BulletIndent = 30
        '' Set the font for the opening text to a larger Arial font;
        'RichTextBox1.SelectionFont = New Font("Arial", 16)
        '' Assign the introduction text to the RichTextBox control.
        'RichTextBox1.SelectedText = "The following is a list of bulleted items:" + ControlChars.Cr
        '' Set the Font for the first item to a smaller size Arial font.
        'RichTextBox1.SelectionFont = New Font("Arial", 12)
        '' Specify that the following items are to be added to a bulleted list.
        'RichTextBox1.SelectionBullet = True
        '' Set the color of the item text.
        'RichTextBox1.SelectionColor = Color.Red
        '' Assign the text to the bulleted item.
        'RichTextBox1.SelectedText = "Apples" + ControlChars.Cr
        '' Apply same font since font settings do not carry to next line.
        'RichTextBox1.SelectionFont = New Font("Arial", 12)
        'RichTextBox1.SelectionColor = Color.Orange
        'RichTextBox1.SelectedText = "Oranges" + ControlChars.Cr
        'RichTextBox1.SelectionFont = New Font("Arial", 12)
        'RichTextBox1.SelectionColor = Color.Purple
        'RichTextBox1.SelectedText = "Grapes" + ControlChars.Cr
        '' End the bulleted list.
        'RichTextBox1.SelectionBullet = False
        '' Specify the font size and string for text displayed below bulleted list.
        'RichTextBox1.SelectionFont = New Font("Verdana", 10)
        'RichTextBox1.SelectedText = "The bulleted text is indented 30 pixels from the bullet symbol using the BulletIndent property." + ControlChars.Cr
        RichTextBox1.SelectionBullet = True
        RichTextBox1.AppendText(vbCrLf)
        RichTextBox1.SelectionBullet = False
    End Sub

    Private Sub DS按钮6_ButtonClick(Sender As Object) Handles DS按钮6.ButtonClick
        Call systemJournal()
    End Sub

    Private Sub DS按钮3_ButtonClick(Sender As Object) Handles DS按钮3.ButtonClick

    End Sub

#End Region

#Region "接收到设备数据"
    Private Sub SerialPort11_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived, SerialPort1.DataReceived

        Dim _time As Integer
        Dim chone
        Dim crc As New ReturnCRC
        System.Threading.Thread.Sleep(200)
        ' awaitThereEnd = True

        Dim tempSplit = Split(tempsenddata, " ")


        Dim byteToRead = SerialPort1.BytesToRead()
        Dim ch(byteToRead) As Byte
        Dim bytesRead


        ' Dim tempCRCstring As String

        '  Dim tempCRC As String

        Try

            bytesRead = SerialPort1.Read(ch, 0, ch.Length)

            If Val(ch(2)) > 0 Then

                Select Case ch(1)

                    Case Is = 1



                    Case 2

                    Case 3


                    Case 5

                End Select
            End If
        Catch ex As Exception

        End Try



    End Sub




#End Region

#Region "按钮渐变效果"
    Private Sub DS按钮3_MouseMove(sender As Object, e As MouseEventArgs) Handles DS按钮3.MouseMove
        DS按钮3.颜色 = Color.DarkOrange
    End Sub

    Private Sub DS按钮3_MouseLeave(sender As Object, e As EventArgs) Handles DS按钮3.MouseLeave
        DS按钮3.颜色 = Color.FromArgb(50, 50, 50)
    End Sub
    Private Sub DS按钮4_MouseMove(sender As Object, e As MouseEventArgs) Handles DS按钮4.MouseMove
        DS按钮4.颜色 = Color.DarkOrange
    End Sub

    Private Sub DS按钮4_MouseLeave(sender As Object, e As EventArgs) Handles DS按钮4.MouseLeave
        DS按钮4.颜色 = Color.FromArgb(50, 50, 50)
    End Sub
    Private Sub DS按钮5_MouseMove(sender As Object, e As MouseEventArgs) Handles DS按钮5.MouseMove
        DS按钮5.颜色 = Color.DarkOrange
    End Sub

    Private Sub DS按钮5_MouseLeave(sender As Object, e As EventArgs) Handles DS按钮5.MouseLeave
        DS按钮5.颜色 = Color.FromArgb(50, 50, 50)
    End Sub
    Private Sub DS按钮6_MouseMove(sender As Object, e As MouseEventArgs) Handles DS按钮6.MouseMove
        DS按钮6.颜色 = Color.DarkOrange
    End Sub

    Private Sub DS按钮6_MouseLeave(sender As Object, e As EventArgs) Handles DS按钮6.MouseLeave
        DS按钮6.颜色 = Color.FromArgb(50, 50, 50)
    End Sub
    Private Sub DS按钮7_MouseMove(sender As Object, e As MouseEventArgs) Handles DS按钮7.MouseMove
        DS按钮7.颜色 = Color.DarkOrange
    End Sub

    Private Sub DS按钮7_MouseLeave(sender As Object, e As EventArgs) Handles DS按钮7.MouseLeave
        DS按钮7.颜色 = Color.FromArgb(50, 50, 50)
    End Sub
    Private Sub DS按钮8_MouseMove(sender As Object, e As MouseEventArgs) Handles DS按钮8.MouseMove
        DS按钮8.颜色 = Color.DarkOrange
    End Sub

    Private Sub DS按钮8_MouseLeave(sender As Object, e As EventArgs) Handles DS按钮8.MouseLeave
        DS按钮8.颜色 = Color.FromArgb(50, 50, 50)
    End Sub

#End Region

#Region "属性方法"
    '让richtextbox不可编辑把readonly属性设为true，并且把BackColor这是为White。
#End Region
End Class
