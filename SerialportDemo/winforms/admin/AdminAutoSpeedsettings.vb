Imports System.IO
Imports System.Threading

Public Class AdminAutoSpeedsettings

#Region "声明"
    '实例化数据库连接
    Dim conn As New Connectiondatabase
    '从数据库取出所须生成的UI名称，类型，个数
    Dim UIarrayList
    '键盘勾子线程，监控键盘输入 
    Dim GetAsyncKey As Thread
    '生成UI线程，当生成的UI太多卡顿时，让窗体处理其他事务
    Dim UIGeneration As Thread
    '生成UI线程委托，附带一个参数（控件名）实例化须要委托访问
    Public Delegate Sub UIthreadCommission(ControlName, ControlPositionX, ControlPositionY）
    '生成标签UI
    Dim UIGenerationLabel
    '生成Textbox UI
    Dim UIGenerationTextbox
    'UI间隔距离值X
    Dim UIIntervalvalueX As Integer = 262
    'UI间隔距离值Y
    Dim UIIntervalvalueY As Integer = 35
    'UI Label 开始方向位置X
    Dim UI_LabelStartPositionX As Integer = 20
    'UI Label 开始方向位置Y
    Dim UI_LabelStartPositionY As Integer = 29
    'UI Textbox开始方向位置X
    Dim UI_TextboxStartPositionX As Integer = 163
    'UI Textbox 开始方向位置Y
    Dim UI_TextboxStartPositionY As Integer = 26
    '记住UI添加了多少行，窗体分为二列，当添加了
    '1行时，须要把X方向的值重新设回初始值
    Dim UI_addRows As Byte = 0
    Dim UI_nameCount As Byte = 1
    Dim UI_Count As Byte = 0
    '根据生成的UI个数重新调整窗体高度
    Dim FormsHeight As Integer
#End Region

    Private Sub AdminAutoSpeedsettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            '从数据库中提取生成UI的设置（包括个数，地址，类型）
            UIarrayList = conn.GetRowsarrayList("自动速度")
            '创建UI更新线程
            CheckForIllegalCrossThreadCalls = False
            UIGeneration = New Thread(AddressOf PreparationGenerationUI)
            '激活线程
            UIGeneration.Start()
            GetAsyncKey = New Thread(AddressOf Get_AsyncKey)  '创建键盘勾子线程
            GetAsyncKey.Start()    '启动线程
            If (UBound(UIarrayList) > 0) Then
                '注意：生成的控件间隔距离为35,窗体顶部有大约60的高度为空白，所以窗体的高度为 个数*35+60
                '宽度不变
                Me.Size = New Point(592, (UBound(UIarrayList) * UIIntervalvalueY) + 100)

            End If

            '屏幕居中
            '***************************************************************
            Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
            Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
            '***************************************************************




        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

#Region "委托线程动态生成控件"

    Private Sub PreparationGenerationUI()
        Dim UI_Label(UBound(UIarrayList)) As Label
        Dim UI_Textbox(UBound(UIarrayList)) As TextBox

        For x = 0 To UBound(UI_Label)
            Me.Invoke(New UIthreadCommission(AddressOf StartGenerationUILabel), UI_Label(x), UI_LabelStartPositionX, UI_LabelStartPositionY)
            '添加计数，防止X方向超出窗体边界
            UI_addRows = UI_addRows + 1

            'UI在原来的基础位置XY上加上间隔距离值
            UI_LabelStartPositionX = UI_LabelStartPositionX + UIIntervalvalueX


            '如果已添加了一行，第二行须要将X方向的位置设回默认位置，只调整Y方向的位置
            If (UI_addRows = 2) Then
                UI_LabelStartPositionY = UI_LabelStartPositionY + UIIntervalvalueY
                UI_LabelStartPositionX = 20
                UI_addRows = 0
            End If

        Next


        UI_addRows = 0
        UI_Count = 0
        For x = 0 To UBound(UI_Textbox)
            Me.Invoke(New UIthreadCommission(AddressOf StartGenerationUITextbox), UI_Label(x), UI_TextboxStartPositionX, UI_TextboxStartPositionY)

            '添加计数，防止X方向超出窗体边界
            UI_addRows = UI_addRows + 1

            'UI在原来的基础位置XY上加上间隔距离值
            UI_TextboxStartPositionX = UI_TextboxStartPositionX + UIIntervalvalueX


            '如果已添加了一行，第二行须要将X方向的位置设回默认位置，只调整Y方向的位置
            If (UI_addRows = 2) Then
                UI_TextboxStartPositionY = UI_TextboxStartPositionY + UIIntervalvalueY
                UI_TextboxStartPositionX = 163
                UI_addRows = 0
            End If
        Next

        Dim arraylist As Byte = 0
        For Each ct In Me.Controls
            If (TypeOf ct Is TextBox) Then
                ct.text = UIarrayList(2, arraylist)
                arraylist += 1

            End If
        Next

    End Sub
    Private Sub StartGenerationUILabel(UIname, UIpositionX, UIpositionY)
        Try

            UIname = New Label

            Me.Controls.Add(UIname)

            With UIname
                '将数据库内的速度名称赋值给控件
                .Text = UIarrayList(0, UI_Count)
                '指定生成位置
                .Location = New Point(UIpositionX, UIpositionY)

            End With

            UI_Count = UI_Count + 1


        Catch ex As Exception

        End Try

    End Sub
    Private Sub StartGenerationUITextbox(UIname, UIpositionX, UIpositionY)
        Try

            '  UIname = New TextBox
            Dim UI As New TextBox
            ' UIname = UI
            ' Me.Controls.Add(UIname)
            Me.Controls.Add(UI)
            With UI
                '将数据库内的速度名称赋值给控件
                ' .Text = UIarrayList(x, 0)
                '指定生成位置
                .Location = New Point(UIpositionX, UIpositionY)
                .Name = "Textbox" & UI_nameCount
            End With
            '  AddHandler UIname.TextChanged, AddressOf UIname_Change
            'AddHandler UI.TextChanged, AddressOf UI_change
            AddHandler UI.KeyDown, AddressOf UI_Keydown
            UI_nameCount = UI_nameCount + 1
        Catch ex As Exception

        End Try
    End Sub
    Private Sub UI_Keydown(sender As Object, e As KeyEventArgs)
        '  AddStrone = sender.text

        '创建UI并添加数据到UI时同样会触发该事件，增加一个判断禁止将数据
        '写入设备
        '如果UI创建完毕了，用户修改了数据，马上执行更新到设备

        If e.KeyCode = Keys.Enter Then

            Dim Namestr As String = sender.name
            Dim Writelist As Integer = Val(Namestr.Substring(Namestr.Length - 1, 1))
            Dim Writevalue As String = "000" & Hex(UIarrayList(2, Writelist - 1))
            Writevalue = Writevalue.Substring(Writevalue.Length - 4)
            Writevalue = Writevalue.Substring(0, 2) & " " & Writevalue.Substring(2)
            Dim Writeaddress As String = UIarrayList(1, Writelist - 1)
            Dim Senddata As String = "01 06" & " " & Writeaddress & " " & Writevalue

        End If
    End Sub
#End Region

#Region "保存数据"

    Private Sub Savedata()
        Dim tempdata(0 To 100, 0 To 1) As String
        Dim tempCount As Byte = 0
        Dim tempbytes As Byte = 0
        Label1.Text = "正在写入数据库，写入设备"
        For Each ct In Me.Controls
            If (TypeOf ct Is TextBox) Then
                tempdata(tempCount, 1) = ct.text
                tempCount = tempCount + 1
            Else
                tempdata(tempbytes, 0) = ct.text
                tempbytes = tempbytes + 1
            End If
        Next
        Dim con As New DatabConnection.DatabaseConnection
        '  conn.SettingsSpeed("手动速度", tempdata)
        con.ChangedData(AppPath, "自动速度", tempdata)
        MsgBox("写入成功")
    End Sub

    Private Sub WritingPlc()


    End Sub

#End Region

#Region "键盘勾子"
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
                    If i = 116 Then
                        '按下了F5
                        Call Savedata()
                    End If
                End If
            Next
        Loop
    End Sub


#End Region
End Class