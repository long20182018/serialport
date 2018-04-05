<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WinSerialportManager
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WinSerialportManager))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.文件FToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.打开OToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存SToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.编辑EToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.项目PToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.程序编程ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.工具TToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.选项ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.编辑脚本ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.连接设备ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.帮助HToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.协议相关ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.软件激活ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.关于我们ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.DS进度条2 = New DSControls.DS进度条()
        Me.DS进度条1 = New DSControls.DS进度条()
        Me.DS进度条4 = New DSControls.DS进度条()
        Me.DS进度条3 = New DSControls.DS进度条()
        Me.DS进度条5 = New DSControls.DS进度条()
        Me.DS进度条6 = New DSControls.DS进度条()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.abnormalGdi = New System.Windows.Forms.Timer(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.DS按钮1 = New DSControls.DS按钮()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DS按钮8 = New DSControls.DS按钮()
        Me.DS按钮7 = New DSControls.DS按钮()
        Me.DS按钮6 = New DSControls.DS按钮()
        Me.DS按钮5 = New DSControls.DS按钮()
        Me.DS按钮4 = New DSControls.DS按钮()
        Me.DS按钮3 = New DSControls.DS按钮()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.心形投票1 = New DSControls.心形投票()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Black
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.文件FToolStripMenuItem, Me.编辑EToolStripMenuItem, Me.项目PToolStripMenuItem, Me.工具TToolStripMenuItem, Me.帮助HToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(982, 25)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '文件FToolStripMenuItem
        '
        Me.文件FToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开OToolStripMenuItem, Me.保存SToolStripMenuItem})
        Me.文件FToolStripMenuItem.ForeColor = System.Drawing.Color.Orange
        Me.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem"
        Me.文件FToolStripMenuItem.Size = New System.Drawing.Size(58, 21)
        Me.文件FToolStripMenuItem.Text = "文件(&F)"
        '
        '打开OToolStripMenuItem
        '
        Me.打开OToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.打开OToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOrange
        Me.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem"
        Me.打开OToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.打开OToolStripMenuItem.Text = "打开(&O)"
        '
        '保存SToolStripMenuItem
        '
        Me.保存SToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.保存SToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOrange
        Me.保存SToolStripMenuItem.Name = "保存SToolStripMenuItem"
        Me.保存SToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.保存SToolStripMenuItem.Text = "保存(&S)"
        '
        '编辑EToolStripMenuItem
        '
        Me.编辑EToolStripMenuItem.ForeColor = System.Drawing.Color.Orange
        Me.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem"
        Me.编辑EToolStripMenuItem.Size = New System.Drawing.Size(59, 21)
        Me.编辑EToolStripMenuItem.Text = "编辑(&E)"
        '
        '项目PToolStripMenuItem
        '
        Me.项目PToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.程序编程ToolStripMenuItem})
        Me.项目PToolStripMenuItem.ForeColor = System.Drawing.Color.Orange
        Me.项目PToolStripMenuItem.Name = "项目PToolStripMenuItem"
        Me.项目PToolStripMenuItem.Size = New System.Drawing.Size(59, 21)
        Me.项目PToolStripMenuItem.Text = "项目(&P)"
        '
        '程序编程ToolStripMenuItem
        '
        Me.程序编程ToolStripMenuItem.Image = Global.SerialportDemo.My.Resources.Resources.set_system_64px_12353_easyicon_net
        Me.程序编程ToolStripMenuItem.Name = "程序编程ToolStripMenuItem"
        Me.程序编程ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.程序编程ToolStripMenuItem.Text = "程序编程"
        '
        '工具TToolStripMenuItem
        '
        Me.工具TToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.选项ToolStripMenuItem, Me.编辑脚本ToolStripMenuItem, Me.连接设备ToolStripMenuItem})
        Me.工具TToolStripMenuItem.ForeColor = System.Drawing.Color.Orange
        Me.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem"
        Me.工具TToolStripMenuItem.Size = New System.Drawing.Size(59, 21)
        Me.工具TToolStripMenuItem.Text = "工具(&T)"
        '
        '选项ToolStripMenuItem
        '
        Me.选项ToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.选项ToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOrange
        Me.选项ToolStripMenuItem.Name = "选项ToolStripMenuItem"
        Me.选项ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.选项ToolStripMenuItem.Text = "选项"
        '
        '编辑脚本ToolStripMenuItem
        '
        Me.编辑脚本ToolStripMenuItem.Name = "编辑脚本ToolStripMenuItem"
        Me.编辑脚本ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.编辑脚本ToolStripMenuItem.Text = "编辑脚本"
        '
        '连接设备ToolStripMenuItem
        '
        Me.连接设备ToolStripMenuItem.Name = "连接设备ToolStripMenuItem"
        Me.连接设备ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.连接设备ToolStripMenuItem.Text = "连接设备"
        '
        '帮助HToolStripMenuItem
        '
        Me.帮助HToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.协议相关ToolStripMenuItem, Me.软件激活ToolStripMenuItem, Me.关于我们ToolStripMenuItem})
        Me.帮助HToolStripMenuItem.ForeColor = System.Drawing.Color.Orange
        Me.帮助HToolStripMenuItem.Name = "帮助HToolStripMenuItem"
        Me.帮助HToolStripMenuItem.Size = New System.Drawing.Size(61, 21)
        Me.帮助HToolStripMenuItem.Text = "帮助(&H)"
        '
        '协议相关ToolStripMenuItem
        '
        Me.协议相关ToolStripMenuItem.Name = "协议相关ToolStripMenuItem"
        Me.协议相关ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.协议相关ToolStripMenuItem.Text = "通讯协议相关"
        '
        '软件激活ToolStripMenuItem
        '
        Me.软件激活ToolStripMenuItem.Name = "软件激活ToolStripMenuItem"
        Me.软件激活ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.软件激活ToolStripMenuItem.Text = "软件激活"
        '
        '关于我们ToolStripMenuItem
        '
        Me.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem"
        Me.关于我们ToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.关于我们ToolStripMenuItem.Text = "关于我们"
        '
        'SerialPort1
        '
        '
        'DS进度条2
        '
        Me.DS进度条2.BackColor = System.Drawing.Color.Transparent
        Me.DS进度条2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS进度条2.Location = New System.Drawing.Point(642, 104)
        Me.DS进度条2.Name = "DS进度条2"
        Me.DS进度条2.Size = New System.Drawing.Size(325, 10)
        Me.DS进度条2.TabIndex = 8
        Me.DS进度条2.允许手动调整进度 = True
        Me.DS进度条2.光泽强度百分比 = 1.0!
        Me.DS进度条2.前景颜色 = System.Drawing.Color.MediumSpringGreen
        Me.DS进度条2.圆角 = True
        Me.DS进度条2.底层颜色 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DS进度条2.当前值 = 100
        Me.DS进度条2.文本描边颜色 = System.Drawing.Color.Black
        Me.DS进度条2.文本颜色 = System.Drawing.Color.White
        Me.DS进度条2.显示圆头结尾 = DSControls.DS进度条._末端样式.圆头
        Me.DS进度条2.显示进度文本 = DSControls.DS进度条.进度显示.值
        Me.DS进度条2.最大值 = 500
        Me.DS进度条2.最小值 = 10
        '
        'DS进度条1
        '
        Me.DS进度条1.BackColor = System.Drawing.Color.Transparent
        Me.DS进度条1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS进度条1.Location = New System.Drawing.Point(641, 68)
        Me.DS进度条1.Name = "DS进度条1"
        Me.DS进度条1.Size = New System.Drawing.Size(326, 10)
        Me.DS进度条1.TabIndex = 9
        Me.DS进度条1.允许手动调整进度 = True
        Me.DS进度条1.光泽强度百分比 = 1.0!
        Me.DS进度条1.前景颜色 = System.Drawing.Color.MediumSpringGreen
        Me.DS进度条1.圆角 = True
        Me.DS进度条1.底层颜色 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DS进度条1.当前值 = 100
        Me.DS进度条1.文本描边颜色 = System.Drawing.Color.Black
        Me.DS进度条1.文本颜色 = System.Drawing.Color.White
        Me.DS进度条1.显示圆头结尾 = DSControls.DS进度条._末端样式.圆头
        Me.DS进度条1.显示进度文本 = DSControls.DS进度条.进度显示.值
        Me.DS进度条1.最大值 = 500
        Me.DS进度条1.最小值 = 10
        '
        'DS进度条4
        '
        Me.DS进度条4.BackColor = System.Drawing.Color.Transparent
        Me.DS进度条4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS进度条4.Location = New System.Drawing.Point(640, 187)
        Me.DS进度条4.Name = "DS进度条4"
        Me.DS进度条4.Size = New System.Drawing.Size(327, 10)
        Me.DS进度条4.TabIndex = 10
        Me.DS进度条4.允许手动调整进度 = True
        Me.DS进度条4.光泽强度百分比 = 1.0!
        Me.DS进度条4.前景颜色 = System.Drawing.Color.MediumSpringGreen
        Me.DS进度条4.圆角 = True
        Me.DS进度条4.底层颜色 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DS进度条4.当前值 = 100
        Me.DS进度条4.文本描边颜色 = System.Drawing.Color.Black
        Me.DS进度条4.文本颜色 = System.Drawing.Color.White
        Me.DS进度条4.显示圆头结尾 = DSControls.DS进度条._末端样式.圆头
        Me.DS进度条4.显示进度文本 = DSControls.DS进度条.进度显示.值
        Me.DS进度条4.最大值 = 500
        Me.DS进度条4.最小值 = 10
        '
        'DS进度条3
        '
        Me.DS进度条3.BackColor = System.Drawing.Color.Transparent
        Me.DS进度条3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS进度条3.Location = New System.Drawing.Point(643, 141)
        Me.DS进度条3.Name = "DS进度条3"
        Me.DS进度条3.Size = New System.Drawing.Size(325, 10)
        Me.DS进度条3.TabIndex = 13
        Me.DS进度条3.允许手动调整进度 = True
        Me.DS进度条3.光泽强度百分比 = 1.0!
        Me.DS进度条3.前景颜色 = System.Drawing.Color.MediumSpringGreen
        Me.DS进度条3.圆角 = True
        Me.DS进度条3.底层颜色 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DS进度条3.当前值 = 100
        Me.DS进度条3.文本描边颜色 = System.Drawing.Color.Black
        Me.DS进度条3.文本颜色 = System.Drawing.Color.White
        Me.DS进度条3.显示圆头结尾 = DSControls.DS进度条._末端样式.圆头
        Me.DS进度条3.显示进度文本 = DSControls.DS进度条.进度显示.值
        Me.DS进度条3.最大值 = 500
        Me.DS进度条3.最小值 = 10
        '
        'DS进度条5
        '
        Me.DS进度条5.BackColor = System.Drawing.Color.Transparent
        Me.DS进度条5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS进度条5.Location = New System.Drawing.Point(642, 223)
        Me.DS进度条5.Name = "DS进度条5"
        Me.DS进度条5.Size = New System.Drawing.Size(327, 10)
        Me.DS进度条5.TabIndex = 14
        Me.DS进度条5.允许手动调整进度 = True
        Me.DS进度条5.光泽强度百分比 = 1.0!
        Me.DS进度条5.前景颜色 = System.Drawing.Color.MediumSpringGreen
        Me.DS进度条5.圆角 = True
        Me.DS进度条5.底层颜色 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DS进度条5.当前值 = 100
        Me.DS进度条5.文本描边颜色 = System.Drawing.Color.Black
        Me.DS进度条5.文本颜色 = System.Drawing.Color.White
        Me.DS进度条5.显示圆头结尾 = DSControls.DS进度条._末端样式.圆头
        Me.DS进度条5.显示进度文本 = DSControls.DS进度条.进度显示.值
        Me.DS进度条5.最大值 = 500
        Me.DS进度条5.最小值 = 10
        '
        'DS进度条6
        '
        Me.DS进度条6.BackColor = System.Drawing.Color.Transparent
        Me.DS进度条6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS进度条6.Location = New System.Drawing.Point(642, 260)
        Me.DS进度条6.Name = "DS进度条6"
        Me.DS进度条6.Size = New System.Drawing.Size(327, 10)
        Me.DS进度条6.TabIndex = 15
        Me.DS进度条6.允许手动调整进度 = True
        Me.DS进度条6.光泽强度百分比 = 1.0!
        Me.DS进度条6.前景颜色 = System.Drawing.Color.MediumSpringGreen
        Me.DS进度条6.圆角 = True
        Me.DS进度条6.底层颜色 = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.DS进度条6.当前值 = 100
        Me.DS进度条6.文本描边颜色 = System.Drawing.Color.Black
        Me.DS进度条6.文本颜色 = System.Drawing.Color.White
        Me.DS进度条6.显示圆头结尾 = DSControls.DS进度条._末端样式.圆头
        Me.DS进度条6.显示进度文本 = DSControls.DS进度条.进度显示.值
        Me.DS进度条6.最大值 = 500
        Me.DS进度条6.最小值 = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(573, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "1#轴速度"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(573, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 12)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "2#轴速度"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(573, 139)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "3#轴速度"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(573, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "4#轴速度"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(573, 221)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "5#轴速度"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(573, 258)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "6#轴速度"
        '
        'abnormalGdi
        '
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label7.Location = New System.Drawing.Point(775, 329)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 12)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "日期"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label8.Location = New System.Drawing.Point(852, 329)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 12)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "事件"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label9.Location = New System.Drawing.Point(927, 329)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 12)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "级别"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.BulletIndent = 5
        Me.RichTextBox1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RichTextBox1.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.RichTextBox1.HideSelection = False
        Me.RichTextBox1.Location = New System.Drawing.Point(29, 159)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBox1.ShowSelectionMargin = True
        Me.RichTextBox1.Size = New System.Drawing.Size(505, 111)
        Me.RichTextBox1.TabIndex = 30
        Me.RichTextBox1.Text = ""
        '
        'Timer1
        '
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label10.Location = New System.Drawing.Point(532, 329)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 12)
        Me.Label10.TabIndex = 46
        Me.Label10.Text = "网格颜色设置"
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.Gray
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(615, 326)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(101, 20)
        Me.ComboBox1.TabIndex = 47
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label11.Location = New System.Drawing.Point(532, 360)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 12)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "曲线颜色设置"
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.Gray
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(615, 357)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(101, 20)
        Me.ComboBox2.TabIndex = 49
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label12.Location = New System.Drawing.Point(532, 391)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 12)
        Me.Label12.TabIndex = 50
        Me.Label12.Text = "外框颜色设置"
        '
        'ComboBox3
        '
        Me.ComboBox3.BackColor = System.Drawing.Color.Gray
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(615, 388)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(101, 20)
        Me.ComboBox3.TabIndex = 51
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label13.Location = New System.Drawing.Point(534, 422)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 12)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "刻度颜色设置"
        '
        'ComboBox4
        '
        Me.ComboBox4.BackColor = System.Drawing.Color.Gray
        Me.ComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(615, 419)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(101, 20)
        Me.ComboBox4.TabIndex = 53
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label14.Location = New System.Drawing.Point(558, 453)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 12)
        Me.Label14.TabIndex = 54
        Me.Label14.Text = "刻度设置"
        '
        'ComboBox5
        '
        Me.ComboBox5.BackColor = System.Drawing.Color.Gray
        Me.ComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(615, 450)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(101, 20)
        Me.ComboBox5.TabIndex = 55
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Label15.Location = New System.Drawing.Point(535, 485)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(77, 12)
        Me.Label15.TabIndex = 56
        Me.Label15.Text = "数据刷新频率"
        '
        'ComboBox6
        '
        Me.ComboBox6.BackColor = System.Drawing.Color.Gray
        Me.ComboBox6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(615, 477)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(101, 20)
        Me.ComboBox6.TabIndex = 57
        '
        'DS按钮1
        '
        Me.DS按钮1.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮1.BackgroundImage = CType(resources.GetObject("DS按钮1.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮1.DialogResult = System.Windows.Forms.DialogResult.None
        Me.DS按钮1.ForeColor = System.Drawing.Color.White
        Me.DS按钮1.Location = New System.Drawing.Point(41, 117)
        Me.DS按钮1.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮1.Name = "DS按钮1"
        Me.DS按钮1.Size = New System.Drawing.Size(87, 26)
        Me.DS按钮1.TabIndex = 58
        Me.DS按钮1.Text = "单步"
        Me.DS按钮1.光泽 = True
        Me.DS按钮1.图像 = Nothing
        Me.DS按钮1.圆角角度 = 8
        Me.DS按钮1.文字描边 = System.Drawing.Color.Black
        Me.DS按钮1.文本 = "单步"
        Me.DS按钮1.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮1.文本水平偏移 = 0
        Me.DS按钮1.渐变 = True
        Me.DS按钮1.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮1.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮1.贴图 = Nothing
        Me.DS按钮1.贴图切割边距.上 = 0
        Me.DS按钮1.贴图切割边距.下 = 0
        Me.DS按钮1.贴图切割边距.右 = 0
        Me.DS按钮1.贴图切割边距.左 = 0
        Me.DS按钮1.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮1.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮1.选定 = False
        Me.DS按钮1.选定模式 = False
        Me.DS按钮1.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮1.透明区域不引发鼠标事件 = True
        Me.DS按钮1.透明度 = 1.0!
        Me.DS按钮1.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(28, 320)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(498, 181)
        Me.PictureBox2.TabIndex = 45
        Me.PictureBox2.TabStop = False
        '
        'DS按钮8
        '
        Me.DS按钮8.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮8.BackgroundImage = CType(resources.GetObject("DS按钮8.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮8.DialogResult = System.Windows.Forms.DialogResult.None
        Me.DS按钮8.ForeColor = System.Drawing.Color.White
        Me.DS按钮8.Location = New System.Drawing.Point(130, 68)
        Me.DS按钮8.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮8.Name = "DS按钮8"
        Me.DS按钮8.Size = New System.Drawing.Size(87, 26)
        Me.DS按钮8.TabIndex = 44
        Me.DS按钮8.Text = "自动"
        Me.DS按钮8.光泽 = True
        Me.DS按钮8.图像 = Nothing
        Me.DS按钮8.圆角角度 = 8
        Me.DS按钮8.文字描边 = System.Drawing.Color.Black
        Me.DS按钮8.文本 = "自动"
        Me.DS按钮8.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮8.文本水平偏移 = 0
        Me.DS按钮8.渐变 = True
        Me.DS按钮8.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮8.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮8.贴图 = Nothing
        Me.DS按钮8.贴图切割边距.上 = 0
        Me.DS按钮8.贴图切割边距.下 = 0
        Me.DS按钮8.贴图切割边距.右 = 0
        Me.DS按钮8.贴图切割边距.左 = 0
        Me.DS按钮8.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮8.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮8.选定 = False
        Me.DS按钮8.选定模式 = False
        Me.DS按钮8.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮8.透明区域不引发鼠标事件 = True
        Me.DS按钮8.透明度 = 1.0!
        Me.DS按钮8.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'DS按钮7
        '
        Me.DS按钮7.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮7.BackgroundImage = CType(resources.GetObject("DS按钮7.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮7.DialogResult = System.Windows.Forms.DialogResult.None
        Me.DS按钮7.ForeColor = System.Drawing.Color.White
        Me.DS按钮7.Location = New System.Drawing.Point(397, 68)
        Me.DS按钮7.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮7.Name = "DS按钮7"
        Me.DS按钮7.Size = New System.Drawing.Size(87, 26)
        Me.DS按钮7.TabIndex = 43
        Me.DS按钮7.Text = "故障复位"
        Me.DS按钮7.光泽 = True
        Me.DS按钮7.图像 = Nothing
        Me.DS按钮7.圆角角度 = 8
        Me.DS按钮7.文字描边 = System.Drawing.Color.Black
        Me.DS按钮7.文本 = "故障复位"
        Me.DS按钮7.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮7.文本水平偏移 = 0
        Me.DS按钮7.渐变 = True
        Me.DS按钮7.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮7.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮7.贴图 = Nothing
        Me.DS按钮7.贴图切割边距.上 = 0
        Me.DS按钮7.贴图切割边距.下 = 0
        Me.DS按钮7.贴图切割边距.右 = 0
        Me.DS按钮7.贴图切割边距.左 = 0
        Me.DS按钮7.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮7.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮7.选定 = False
        Me.DS按钮7.选定模式 = False
        Me.DS按钮7.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮7.透明区域不引发鼠标事件 = True
        Me.DS按钮7.透明度 = 1.0!
        Me.DS按钮7.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'DS按钮6
        '
        Me.DS按钮6.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮6.BackgroundImage = CType(resources.GetObject("DS按钮6.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮6.DialogResult = System.Windows.Forms.DialogResult.None
        Me.DS按钮6.ForeColor = System.Drawing.Color.White
        Me.DS按钮6.Location = New System.Drawing.Point(396, 117)
        Me.DS按钮6.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮6.Name = "DS按钮6"
        Me.DS按钮6.Size = New System.Drawing.Size(88, 29)
        Me.DS按钮6.TabIndex = 42
        Me.DS按钮6.Text = "测试日志"
        Me.DS按钮6.光泽 = True
        Me.DS按钮6.图像 = Nothing
        Me.DS按钮6.圆角角度 = 8
        Me.DS按钮6.文字描边 = System.Drawing.Color.Black
        Me.DS按钮6.文本 = "测试日志"
        Me.DS按钮6.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮6.文本水平偏移 = 0
        Me.DS按钮6.渐变 = True
        Me.DS按钮6.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮6.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮6.贴图 = Nothing
        Me.DS按钮6.贴图切割边距.上 = 0
        Me.DS按钮6.贴图切割边距.下 = 0
        Me.DS按钮6.贴图切割边距.右 = 0
        Me.DS按钮6.贴图切割边距.左 = 0
        Me.DS按钮6.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮6.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮6.选定 = False
        Me.DS按钮6.选定模式 = False
        Me.DS按钮6.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮6.透明区域不引发鼠标事件 = True
        Me.DS按钮6.透明度 = 1.0!
        Me.DS按钮6.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'DS按钮5
        '
        Me.DS按钮5.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮5.BackgroundImage = CType(resources.GetObject("DS按钮5.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮5.DialogResult = System.Windows.Forms.DialogResult.None
        Me.DS按钮5.ForeColor = System.Drawing.Color.White
        Me.DS按钮5.Location = New System.Drawing.Point(308, 68)
        Me.DS按钮5.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮5.Name = "DS按钮5"
        Me.DS按钮5.Size = New System.Drawing.Size(87, 26)
        Me.DS按钮5.TabIndex = 41
        Me.DS按钮5.Text = "复位"
        Me.DS按钮5.光泽 = True
        Me.DS按钮5.图像 = Nothing
        Me.DS按钮5.圆角角度 = 8
        Me.DS按钮5.文字描边 = System.Drawing.Color.Black
        Me.DS按钮5.文本 = "复位"
        Me.DS按钮5.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮5.文本水平偏移 = 0
        Me.DS按钮5.渐变 = True
        Me.DS按钮5.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮5.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮5.贴图 = Nothing
        Me.DS按钮5.贴图切割边距.上 = 0
        Me.DS按钮5.贴图切割边距.下 = 0
        Me.DS按钮5.贴图切割边距.右 = 0
        Me.DS按钮5.贴图切割边距.左 = 0
        Me.DS按钮5.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮5.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮5.选定 = False
        Me.DS按钮5.选定模式 = False
        Me.DS按钮5.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮5.透明区域不引发鼠标事件 = True
        Me.DS按钮5.透明度 = 1.0!
        Me.DS按钮5.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'DS按钮4
        '
        Me.DS按钮4.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮4.BackgroundImage = CType(resources.GetObject("DS按钮4.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮4.DialogResult = System.Windows.Forms.DialogResult.None
        Me.DS按钮4.ForeColor = System.Drawing.Color.White
        Me.DS按钮4.Location = New System.Drawing.Point(219, 68)
        Me.DS按钮4.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮4.Name = "DS按钮4"
        Me.DS按钮4.Size = New System.Drawing.Size(87, 26)
        Me.DS按钮4.TabIndex = 40
        Me.DS按钮4.Text = "暂停"
        Me.DS按钮4.光泽 = True
        Me.DS按钮4.图像 = Nothing
        Me.DS按钮4.圆角角度 = 8
        Me.DS按钮4.文字描边 = System.Drawing.Color.Black
        Me.DS按钮4.文本 = "暂停"
        Me.DS按钮4.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮4.文本水平偏移 = 0
        Me.DS按钮4.渐变 = True
        Me.DS按钮4.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮4.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮4.贴图 = Nothing
        Me.DS按钮4.贴图切割边距.上 = 0
        Me.DS按钮4.贴图切割边距.下 = 0
        Me.DS按钮4.贴图切割边距.右 = 0
        Me.DS按钮4.贴图切割边距.左 = 0
        Me.DS按钮4.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮4.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮4.选定 = False
        Me.DS按钮4.选定模式 = False
        Me.DS按钮4.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮4.透明区域不引发鼠标事件 = True
        Me.DS按钮4.透明度 = 1.0!
        Me.DS按钮4.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'DS按钮3
        '
        Me.DS按钮3.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮3.BackgroundImage = CType(resources.GetObject("DS按钮3.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮3.DialogResult = System.Windows.Forms.DialogResult.None
        Me.DS按钮3.ForeColor = System.Drawing.Color.White
        Me.DS按钮3.Location = New System.Drawing.Point(41, 68)
        Me.DS按钮3.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮3.Name = "DS按钮3"
        Me.DS按钮3.Size = New System.Drawing.Size(87, 26)
        Me.DS按钮3.TabIndex = 39
        Me.DS按钮3.Text = "启动"
        Me.DS按钮3.光泽 = True
        Me.DS按钮3.图像 = Nothing
        Me.DS按钮3.圆角角度 = 8
        Me.DS按钮3.文字描边 = System.Drawing.Color.Black
        Me.DS按钮3.文本 = "启动"
        Me.DS按钮3.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮3.文本水平偏移 = 0
        Me.DS按钮3.渐变 = True
        Me.DS按钮3.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮3.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮3.贴图 = Nothing
        Me.DS按钮3.贴图切割边距.上 = 0
        Me.DS按钮3.贴图切割边距.下 = 0
        Me.DS按钮3.贴图切割边距.右 = 0
        Me.DS按钮3.贴图切割边距.左 = 0
        Me.DS按钮3.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮3.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮3.选定 = False
        Me.DS按钮3.选定模式 = False
        Me.DS按钮3.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮3.透明区域不引发鼠标事件 = True
        Me.DS按钮3.透明度 = 1.0!
        Me.DS按钮3.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(758, 320)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(210, 181)
        Me.PictureBox3.TabIndex = 26
        Me.PictureBox3.TabStop = False
        '
        '心形投票1
        '
        Me.心形投票1.BackColor = System.Drawing.Color.Transparent
        Me.心形投票1.BackgroundImage = CType(resources.GetObject("心形投票1.BackgroundImage"), System.Drawing.Image)
        Me.心形投票1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.心形投票1.Location = New System.Drawing.Point(-23, -45)
        Me.心形投票1.MaximumSize = New System.Drawing.Size(160, 32)
        Me.心形投票1.MinimumSize = New System.Drawing.Size(160, 32)
        Me.心形投票1.Name = "心形投票1"
        Me.心形投票1.Size = New System.Drawing.Size(160, 32)
        Me.心形投票1.TabIndex = 16
        Me.心形投票1.当前票数 = 2
        Me.心形投票1.心形大小 = 32
        Me.心形投票1.总票数 = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gray
        Me.PictureBox1.BackgroundImage = Global.SerialportDemo.My.Resources.Resources.win1
        Me.PictureBox1.Location = New System.Drawing.Point(0, 28)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1095, 517)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'WinSerialportManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(982, 519)
        Me.Controls.Add(Me.DS按钮1)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.DS按钮8)
        Me.Controls.Add(Me.DS按钮7)
        Me.Controls.Add(Me.DS按钮6)
        Me.Controls.Add(Me.DS按钮5)
        Me.Controls.Add(Me.DS按钮4)
        Me.Controls.Add(Me.DS按钮3)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.心形投票1)
        Me.Controls.Add(Me.DS进度条6)
        Me.Controls.Add(Me.DS进度条5)
        Me.Controls.Add(Me.DS进度条3)
        Me.Controls.Add(Me.DS进度条4)
        Me.Controls.Add(Me.DS进度条1)
        Me.Controls.Add(Me.DS进度条2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "WinSerialportManager"
        Me.Text = "串口通讯管理系统"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 文件FToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 打开OToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 保存SToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 编辑EToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 项目PToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 工具TToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 帮助HToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 协议相关ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 软件激活ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 关于我们ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 选项ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents 编辑脚本ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DS进度条2 As DSControls.DS进度条
    Friend WithEvents DS进度条1 As DSControls.DS进度条
    Friend WithEvents DS进度条4 As DSControls.DS进度条
    Friend WithEvents DS进度条3 As DSControls.DS进度条
    Friend WithEvents DS进度条5 As DSControls.DS进度条
    Friend WithEvents DS进度条6 As DSControls.DS进度条
    Friend WithEvents 心形投票1 As DSControls.心形投票
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents abnormalGdi As Timer
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents DS按钮3 As DSControls.DS按钮
    Friend WithEvents DS按钮4 As DSControls.DS按钮
    Friend WithEvents DS按钮5 As DSControls.DS按钮
    Friend WithEvents DS按钮6 As DSControls.DS按钮
    Friend WithEvents DS按钮7 As DSControls.DS按钮
    Friend WithEvents DS按钮8 As DSControls.DS按钮
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label10 As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents ComboBox4 As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents Label15 As Label
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents DS按钮1 As DSControls.DS按钮
    Friend WithEvents 连接设备ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 程序编程ToolStripMenuItem As ToolStripMenuItem
End Class
