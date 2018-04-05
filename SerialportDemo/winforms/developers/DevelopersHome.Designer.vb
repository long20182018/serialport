<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DevelopersHome
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DevelopersHome))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DS按钮1 = New DSControls.DS按钮()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(51, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "起始地址"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(110, 26)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(245, 21)
        Me.TextBox1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "每个点几个位置："
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(110, 74)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(245, 21)
        Me.TextBox2.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "每个位置名称："
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(110, 133)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(245, 21)
        Me.TextBox3.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(108, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "*第一点地址"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(115, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(167, 12)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "*如:第1点有3个位置（x,y,z）"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(115, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 12)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "*如：X轴，Y轴，Z轴"
        '
        'DS按钮1
        '
        Me.DS按钮1.BackColor = System.Drawing.Color.Transparent
        Me.DS按钮1.BackgroundImage = CType(resources.GetObject("DS按钮1.BackgroundImage"), System.Drawing.Image)
        Me.DS按钮1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DS按钮1.ForeColor = System.Drawing.Color.White
        Me.DS按钮1.Location = New System.Drawing.Point(259, 168)
        Me.DS按钮1.Margin = New System.Windows.Forms.Padding(1)
        Me.DS按钮1.Name = "DS按钮1"
        Me.DS按钮1.Size = New System.Drawing.Size(96, 24)
        Me.DS按钮1.TabIndex = 10
        Me.DS按钮1.Text = "应用"
        Me.DS按钮1.光泽 = True
        Me.DS按钮1.图像 = Nothing
        Me.DS按钮1.圆角角度 = 8
        Me.DS按钮1.文字描边 = System.Drawing.Color.Black
        Me.DS按钮1.文本 = "应用"
        Me.DS按钮1.文本对齐 = DSControls.DS按钮.Text_Align.Center
        Me.DS按钮1.文本水平偏移 = 0
        Me.DS按钮1.渐变 = True
        Me.DS按钮1.绘制边框 = DSControls.DS按钮.边框.全部
        Me.DS按钮1.自动尺寸扩展 = New System.Drawing.Size(20, 20)
        Me.DS按钮1.贴图 = Nothing
        Me.DS按钮1.贴图模式 = DSControls.DS按钮._贴图模式.默认
        Me.DS按钮1.边框颜色 = System.Drawing.Color.Transparent
        Me.DS按钮1.选定 = False
        Me.DS按钮1.选定模式 = False
        Me.DS按钮1.选定颜色 = System.Drawing.Color.SteelBlue
        Me.DS按钮1.透明度 = 1.0!
        Me.DS按钮1.颜色 = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        '
        'DevelopersHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 201)
        Me.Controls.Add(Me.DS按钮1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "DevelopersHome"
        Me.Text = "程序配方生成"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents DS按钮1 As DSControls.DS按钮
End Class
