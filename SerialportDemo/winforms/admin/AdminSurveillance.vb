Imports System.IO
Imports System.Threading
Imports System.Windows.Forms

Public Class AdminSurveillance

#Region "声明"
    '实例化数据库连接
    Dim conn As New Connectiondatabase
    '取得监视端口数据，根据数据生成UI
    Dim SurveillanceserialportX
    Dim SurveillanceserialportY
    'UI高度
    Const UIheight As Byte = 21
    'UI宽度
    Const UIwidth As Byte = 33
    'UI字体对齐方式
    Private Property TextAlign As HorizontalAlignment
    'UI X端口X方向开始位置
    Dim UI_Xport_Startposition_X As Integer = 6
    'UI X端口Y方向开始位置
    Dim UI_Xport_Startposition_Y As Integer = 30
    'UI Y端口X方向开始位置
    Dim UI_Yport_Startposition_X As Integer = 6
    'UI Y端口Y方向开始位置
    Dim UI_Yport_Startposition_Y As Integer = 30
    'UI  X方向间隔距离
    Dim UI_Intervaldistance_X As Integer = 39
    'UI  Y方向间隔距离
    Dim UI_Intervaldistance_Y As Integer = 40
    'UI  排列列数
    Dim UI_ColumnCount As Byte = 16
    'UI  生成计数
    Dim UI_generateCount As Byte = 0
    '创建UI线程
    Dim UI_createThread As Thread
    '创建UI线程委托,带三个参数，控件名，X方向位置,Y方向位置
    Public Delegate Sub UI_createtrust(controlName As String, controlposition_X As Integer, controlposition_Y As Integer)
    '处理2进制数据线程
    Dim ProcessingdataThread As Thread
    '监视UI是否创建完成，如果创建完成，则委托线程更新UI数据 
    Dim SurveillanceUI As Boolean = False
    '用于指定生成XY端口类型
    Dim UI_XYtype As Boolean = False
    Dim newXport()
    Dim NewYport()
    Dim tempbyte As Byte = 0
#End Region

#Region "初始化"
    Private Sub AdminSurveillance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''读取数据库提取UI数据 
        SurveillanceserialportX = conn.GetRowsarrayList("监视端口X")
        SurveillanceserialportY = conn.GetRowsarrayList("监视端口Y")
        ''如果读取到UI数据，激活创建UI线程
        If (UBound(SurveillanceserialportX) > 0) Then
            UI_createThread = New Thread(AddressOf UI_Preparationcreate)
            UI_createThread.Start()
        End If

        ''设置窗体剧中
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2

    End Sub
#End Region

#Region "创建UI线程"
    Private Sub UI_Preparationcreate(arrayList() As String)


        '循环遍历数组，防止有空数据

        For x = 0 To UBound(SurveillanceserialportX, 2)
            If (IsDBNull((SurveillanceserialportX(0, x))) = False) Then
                ReDim Preserve newXport(tempbyte)
                newXport(tempbyte) = SurveillanceserialportX(0, x)
                tempbyte += 1
            End If
        Next

        newXport = Hex16conversion(newXport)

        '根据实际个数创建UI
        Dim UI_Textbox(tempbyte - 1) As String

        '循环逐个创建UI      X端口UI
        For x As Byte = 0 To UBound(UI_Textbox)


            '委托 UI_Startcreate 创建UI
            Me.Invoke(New UI_createtrust(AddressOf UI_Startcreate), UI_Textbox(x), UI_Xport_Startposition_X, UI_Xport_Startposition_Y)
            'X端口的UI的X方向开始位置在原来的基础位置XY上加上间隔距离值
            UI_Xport_Startposition_X += UI_Intervaldistance_X
            'UI生成计数，计够16个后另起一行
            UI_generateCount += 1
            '如果已添加16个，第二行须要将X方向的位置设回默认位置，只调整Y方向的位置
            If (UI_generateCount = 16) Then
                UI_Xport_Startposition_X = 6
                UI_Xport_Startposition_Y += UI_Intervaldistance_Y

            End If
        Next

        tempbyte = 0
        UI_generateCount = 0

        '循环遍历数组，防止有空数据

        For x = 0 To UBound(SurveillanceserialportY, 2)
            If (IsDBNull((SurveillanceserialportY(0, x))) = False) Then
                ReDim Preserve NewYport(tempbyte)
                NewYport(tempbyte) = SurveillanceserialportY(0, x)
                tempbyte += 1
            End If
        Next


        '根据实际个数创建UI
        ReDim UI_Textbox(tempbyte - 1)
        UI_XYtype = True
        UI_generateCount = 0

        '先把16进制数据转为10进制排序后再转回16进制
        NewYport = Hex16conversion(NewYport)
        '循环逐个创建UI      X端口UI
        For x As Byte = 0 To UBound(UI_Textbox)
            '委托 UI_Startcreate 创建UI
            Me.Invoke(New UI_createtrust(AddressOf UI_Startcreate), UI_Textbox(x), UI_Yport_Startposition_X, UI_Yport_Startposition_Y)
            'UI在原来的基础位置XY上加上间隔距离值
            UI_Yport_Startposition_X += UI_Intervaldistance_X
            'UI生成计数，计够16个后另起一行
            UI_generateCount += 1
            '如果已添加16个，第二行须要将X方向的位置设回默认位置，只调整Y方向的位置
            If (UI_generateCount = 16) Then
                UI_Yport_Startposition_X = 6
                UI_Yport_Startposition_Y += UI_Intervaldistance_Y
            End If
        Next

        'UI创建完毕 ，激活时钟，进行周期扫描监视实时状态
        Timer1.Enabled = True
        Timer1.Interval = 100
    End Sub
#End Region

#Region "委托线程创建UI"
    Private Sub UI_Startcreate(UIname, UIpositionX, UIpositionY)

        Try
            '指定UI类型
            UIname = New TextBox
            '在GroupBox1 中 添加UI

            If (UI_XYtype = False) Then
                Me.GroupBox1.Controls.Add(UIname)
            Else
                Me.GroupBox2.Controls.Add(UIname)
            End If

            With UIname

                '设定控件生成大小
                .Size = New Size(UIwidth, UIheight)
                '将数据库数据名称赋值给控件
                If (UI_XYtype = False) Then
                    .Text = newXport(UI_generateCount)
                Else
                    .Text = NewYport(UI_generateCount)
                End If
                '设置字体居中
                .TextAlign = HorizontalAlignment.Center
                '指定生成位置,位置坐标由委托传递
                .Location = New Point(UIpositionX, UIpositionY)
                '设为不可编辑状态
                .Enabled = False
                .ForeColor = Color.Red

            End With




        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "16进制数据排序"
    '16进制转换回10进制进行排序，排好后再转回16进制
    Private Function Hex16conversion(arrayList())
        Dim templist(UBound(arrayList))
        Dim tempstr As String

        For x As Byte = 0 To UBound(arrayList)
            '先把16进制数据取出来转为10进制 
            tempstr = arrayList(x)
            templist(x) = Val("&H" & tempstr.Substring(1, tempstr.Length - 1))
        Next
        '对10进制进行排序 
        Array.Sort(templist)

        '再转回16进制 
        For x = 0 To UBound(templist)
            If (UI_XYtype = False) Then
                templist(x) = "X" & Hex(templist(x))
            Else
                templist(x) = "Y" & Hex(templist(x))
            End If
        Next

        Hex16conversion = templist
    End Function


#End Region

#Region "周期扫描监视实时状态"

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim x As Byte
        Dim inp As Byte
        Dim Outvalue As Byte
        Dim Inputvalue As Byte
        Dim frm As New Form1

        Inputvalue = 0
        Outvalue = 0
        Dim ct As Object
        Try

            inp = 0
            For inputx = 0 To FunctionCodearraylistTwoRows - 1
                For inputy = Len(FunctionCodearraylistTwo(inputx)) To 1 Step -1
                    If FunctionCodearraylistTwo(inputx).substring(inputy - 1, 1) = 1 Then
                        InputState(inp) = True
                    Else
                        InputState(inp) = False
                    End If
                    inp = inp + 1
                Next
            Next
            inp = 0

            For inputx = 0 To FunctioncodearraylistOneRows - 1
                For inputy = Len(FunctionCodearraylistOne(inputx)) To 1 Step -1
                    If FunctionCodearraylistOne(inputx).substring(inputy - 1, 1) = 1 Then
                        OutState(inp) = True
                    Else
                        OutState(inp) = False
                    End If
                    inp = inp + 1
                Next
            Next



            For x = 1 To 32
                For Each ct In GroupBox1.Controls
                    If (TypeOf ct Is TextBox) Then
                        If (ct.name) = "TextBox" & x Then
                            If (InputState(Inputvalue)) = True Then
                                ct.BackColor = Color.FromArgb(0, 255, 0)
                                Exit For
                            Else
                                ct.BackColor = Color.FromArgb(100, 100, 100)
                                Exit For
                            End If
                        End If

                    End If
                Next
                Inputvalue = Inputvalue + 1
            Next


            Outvalue = 0
            For x = 33 To 62
                '  MsgBox(OutState(x - 32))
                For Each ct In GroupBox2.Controls
                    If (TypeOf ct Is TextBox) Then


                        If (ct.name) = "TextBox" & x Then
                            If (OutState(Outvalue)) = True Then
                                ct.BackColor = Color.FromArgb(0, 255, 0)
                                Exit For
                            Else
                                ct.BackColor = Color.FromArgb(100, 100, 100)

                                Exit For
                            End If

                        End If

                    End If
                Next
                Outvalue = Outvalue + 1
            Next


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

#End Region

End Class