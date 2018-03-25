Imports System.IO
Imports System.Threading

Public Class DevelopersReadadd
    '键盘勾子线程，监控键盘输入 
    Dim GetAsyncKey As Thread
    '更新UI线程
    Dim UpdataUIThread As Thread
    '更新UI委托
    Public Delegate Sub UpdataUI(strone As String, strtwo As String, Strthree As String,
                                 Strfour As String, Strfive As String, StrSix As String, CRC As String)
    Dim RowsCount As Byte
    Dim DataCount As Byte
    Dim tempCRC16 As String



    Private Sub Readadd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RowsCount = 0
        DataCount = 0
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        ComboBox1.Items.Add(1)
        ComboBox1.Items.Add(2)
        ComboBox1.Items.Add(3)
        ComboBox1.Items.Add(4)
        ComboBox1.Items.Add(5)
        ComboBox2.Items.Add(1)
        ComboBox2.Items.Add(2)
        ComboBox2.Items.Add(3)
        ComboBox2.Items.Add(5)
        ComboBox2.Items.Add(6)
        GetAsyncKey = New Thread(AddressOf Get_AsyncKey)  '创建线程
        GetAsyncKey.Start()    '启动线程
    End Sub

#Region "动态生成控件并绑定事件"
    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        For x = 1 To 5
            For Each ct In Me.Controls
                If (TypeOf ct Is ComboBox Or TypeOf ct Is Label) Then
                    If (ct.name <> "Label1" And ct.name <> "Label2" And ct.name <> "ComboBox1" And ct.name <> "ComboBox2") Then
                        Me.Controls.Remove(ct)
                        ct.Dispose()
                    End If
                End If
            Next
        Next

        If (ComboBox2.Text = 1 Or ComboBox2.Text = 2 Or ComboBox2.Text = 3 Or ComboBox2.Text = 6) Then
            Call Generation_Combox_four()
        ElseIf (ComboBox2.Text = 5) Then
            Call Generation_Combox_two()
        End If
        AddStrtwo = sender.text
    End Sub

    Private Sub Generation_Combox_four()
        Dim labell3 As New Label
        Dim labell4 As New Label
        Dim labell5 As New Label
        Dim labell6 As New Label
        Dim Comboboxx3 As New ComboBox
        Dim Comboboxx4 As New ComboBox
        Dim Comboboxx5 As New ComboBox
        Dim Comboboxx6 As New ComboBox

        Me.Controls.Add(labell3)
        Me.Controls.Add(labell4)
        Me.Controls.Add(labell5)
        Me.Controls.Add(labell6)
        Me.Controls.Add(Comboboxx3) '添加到窗体控件集中，你也可以添加到其他控件集中，  '如(Panel1.Controls.Add(label1))就是添加到panel1控件中  
        Me.Controls.Add(Comboboxx4)
        Me.Controls.Add(Comboboxx5)
        Me.Controls.Add(Comboboxx6)

        With labell3
            .Text = "地址高位"
            .Location = New Point(12, 94) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With
        With labell4
            .Text = "地址低位"
            .Location = New Point(12, 134) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With
        With labell5
            .Text = "数据高位"
            .Location = New Point(12, 176) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With
        With labell6
            .Text = "数据低位"
            .Location = New Point(12, 216) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With

        With Comboboxx3
            .Name = "ComboBox3"
            .Location = New Point(87, 94) '定义控件位置，默认的是（0，0）  
        End With
        ' AddHandler Label1.Click, AddressOf label11_Click '添加click事件  
        AddHandler Comboboxx3.TextChanged, AddressOf Comboboxx3_Change

        With Comboboxx4
            .Name = "ComboBox4"
            .Location = New Point(87, 134) '定义控件位置，默认的是（0，0）  
        End With
        AddHandler Comboboxx4.TextChanged, AddressOf Comboboxx4_Change
        With Comboboxx5
            .Name = "ComboBox4"
            .Location = New Point(87, 176) '定义控件位置，默认的是（0，0）  
        End With
        AddHandler Comboboxx5.TextChanged, AddressOf Comboboxx5_Change
        With Comboboxx6
            .Name = "ComboBox4"
            .Location = New Point(87, 216) '定义控件位置，默认的是（0，0）  
        End With
        AddHandler Comboboxx6.TextChanged, AddressOf Comboboxx6_Change
        '  AddHandler Label1.Click, AddressOf label11_Click '添加click事件 

    End Sub

    Private Sub Generation_Combox_two()
        Dim labell3 As New Label
        Dim labell4 As New Label
        Dim labell5 As New Label
        Dim labell6 As New Label
        Dim Comboboxx3 As New ComboBox
        Dim Comboboxx4 As New ComboBox
        Dim Comboboxx5 As New ComboBox
        Dim Comboboxx6 As New ComboBox

        Me.Controls.Add(labell3)
        Me.Controls.Add(labell4)
        Me.Controls.Add(labell5)
        Me.Controls.Add(labell6)
        Me.Controls.Add(Comboboxx3) '添加到窗体控件集中，你也可以添加到其他控件集中，  '如(Panel1.Controls.Add(label1))就是添加到panel1控件中  
        Me.Controls.Add(Comboboxx4)
        Me.Controls.Add(Comboboxx5)
        Me.Controls.Add(Comboboxx6)

        With labell3
            .Text = "地址高位"
            .Location = New Point(12, 94) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With
        With labell4
            .Text = "地址低位"
            .Location = New Point(12, 134) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With
        With labell5
            .Text = "开关状态"
            .Location = New Point(12, 176) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With
        With labell6
            .Text = "开关状态"
            .Location = New Point(12, 216) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            '     .ForeColor = Color.Red
            '    .Font = New Font("楷体", 20) '定义字体  
        End With

        With Comboboxx3
            .Name = "ComboBox3"
            .Location = New Point(87, 94) '定义控件位置，默认的是（0，0）  
        End With
        ' AddHandler Label1.Click, AddressOf label11_Click '添加click事件  
        AddHandler Comboboxx3.TextChanged, AddressOf Comboboxx3_Change

        With Comboboxx4
            .Name = "ComboBox4"
            .Location = New Point(87, 134) '定义控件位置，默认的是（0，0）  
        End With
        AddHandler Comboboxx4.TextChanged, AddressOf Comboboxx4_Change
        With Comboboxx5
            .Name = "ComboBox4"
            .Location = New Point(87, 176) '定义控件位置，默认的是（0，0）  
        End With
        AddHandler Comboboxx5.TextChanged, AddressOf Comboboxx5_Change
        With Comboboxx6
            .Name = "ComboBox4"
            .Location = New Point(87, 216) '定义控件位置，默认的是（0，0）  
        End With
        AddHandler Comboboxx6.TextChanged, AddressOf Comboboxx6_Change
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        AddStrone = sender.text
    End Sub
    Private Sub Comboboxx3_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim label1 As Label = CType(sender, Label) '获取当前操作的控件对象，只有这样才能对该控件进行操作  
        'Me.Controls.Remove(label1) '将控件移除  
        'label1.Dispose() '释放控件资源  
        AddStrthree = sender.text
    End Sub
    Private Sub Comboboxx4_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddStrfour = sender.text
    End Sub
    Private Sub Comboboxx5_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddStrfive = sender.text
    End Sub
    Private Sub Comboboxx6_Change(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AddStrSix = sender.text
    End Sub



#End Region
#Region "快捷键"
    '该快捷设置线程监视键盘勾子

    Public Sub addtoforms()

        Me.Invoke(New UpdataUI(AddressOf OutUI), AddStrone, AddStrtwo, AddStrthree, AddStrfour, AddStrfive, AddStrSix, CRC16bit)

    End Sub

    Private Sub OutUI(Sone As String, Stwo As String, Sthree As String, Sfour As String, Sfive As String, Ssix As String, SCRC As String)

        DevelopersReadSettings.DataGridView1.Rows(RowsCount).Cells(0).Value = Sone
        DevelopersReadSettings.DataGridView1.Rows(RowsCount).Cells(1).Value = Stwo
        DevelopersReadSettings.DataGridView1.Rows(RowsCount).Cells(2).Value = Sthree
        DevelopersReadSettings.DataGridView1.Rows(RowsCount).Cells(3).Value = Sfour
        DevelopersReadSettings.DataGridView1.Rows(RowsCount).Cells(4).Value = Sfive
        DevelopersReadSettings.DataGridView1.Rows(RowsCount).Cells(5).Value = Ssix
        DevelopersReadSettings.DataGridView1.Rows(RowsCount).Cells(6).Value = SCRC
        RowsCount = RowsCount + 1
    End Sub



#End Region



    Private Sub Get_AsyncKey()
        '键盘勾子，注意该勾子在模块中声明了api
        '  Public Declare Auto Function GetAsyncKeyState Lib "user32 " (ByVal vKey As Integer) As Integer
        'Public Declare Auto Function GetKeyState Lib "user32 " (ByVal nVirtKey As Long) As Integer
        '     Public Declare Auto Function GetKeyboardState Lib "user32 " (pbKeyState As Byte) As Long
        '     Const VK_CAPITAL = &H14
        '  Const VK_SHIFT = &H10
        '  Public myarr(0 To 255) As Byte

        '返回CRC校验码
        Dim returncrc As New ReturnCRC
        Do
            System.Threading.Thread.Sleep(10)
            For i = 0 To 128 Step 1
                Dim KeyResult = GetAsyncKeyState(i)
                If KeyResult = -32767 Then
                    If i = 13 Then
                        '按下了回车键
                        tempCRC16 = "0" & AddStrone & " " & "0" & AddStrtwo & " " & AddStrthree & " " _
                            & AddStrfour & " " & AddStrfive & " " & AddStrSix
                        tempCRC16 = returncrc.Get_CRC16(tempCRC16)
                        CRC16bit = tempCRC16.Substring(0, 2) & " " & tempCRC16.Substring(2)
                        UpdataUIThread = New Thread(AddressOf addtoforms)
                        UpdataUIThread.Start()
                    End If
                End If
            Next
        Loop
    End Sub


End Class