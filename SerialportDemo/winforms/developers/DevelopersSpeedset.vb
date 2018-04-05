Imports System.IO
Imports System.Threading

Public Class DevelopersSpeedset
    '键盘勾子线程
    '用于监视键盘按下状态线程，因光标焦点不在窗体上
    '按下键盘时响应不到，所以要用到键盘勾子
    Dim GetAsyncKey As Thread
    '更新UI线程
    Dim UpdataUIThread As Thread
    '跨线程委托，将数据委托更新到SpeedSettings窗体中
    '委托带4个参数 
    Public Delegate Sub UpdataUI(ManualSpeedName As String, ManualSpeedplcaddress As String,
                                 AutoSpeedName As String, AutoSpeedplcaddress As String）

    '********************************************************************
    Dim UImanualspeedname As String                                    '*
    Dim UImanualspeedplcaddress As String                              '*
    Dim UIautospeedname As String                                      '*
    Dim UIautospeedplcaddress As String                                '*
    Dim UIrowsCount As Byte = 0                                        '*
    '********************************************************************


    Private Sub Speedset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        GetAsyncKey = New Thread(AddressOf Get_AsyncKey)  '创建键盘勾子线程
        GetAsyncKey.Start()    '启动线程
    End Sub

    '开始委托，准备更新UI
    Public Sub PreparationUpdataUI()

        Me.Invoke(New UpdataUI(AddressOf StartUpdataUI), UImanualspeedname, UImanualspeedplcaddress,
                UIautospeedname, UIautospeedplcaddress)

    End Sub

    '开始更新UI
    Public Sub StartUpdataUI(Manualname As String, Manualaddress As String, Autoname As String, Autoaddress As String)
        DevelopersSpeedsettings.DataGridView1.Rows(UIrowsCount).Cells(0).Value = UIrowsCount + 1
        DevelopersSpeedsettings.DataGridView1.Rows(UIrowsCount).Cells(1).Value = Manualname
        DevelopersSpeedsettings.DataGridView1.Rows(UIrowsCount).Cells(2).Value = Manualaddress
        DevelopersSpeedsettings.DataGridView2.Rows(UIrowsCount).Cells(0).Value = UIrowsCount + 1
        DevelopersSpeedsettings.DataGridView2.Rows(UIrowsCount).Cells(1).Value = Autoname
        DevelopersSpeedsettings.DataGridView2.Rows(UIrowsCount).Cells(2).Value = Autoaddress
        UIrowsCount = UIrowsCount + 1
    End Sub
    Private Sub Get_AsyncKey()
        '键盘勾子，注意该勾子在模块中声明了api
        '  Public Declare Auto Function GetAsyncKeyState Lib "user32 " (ByVal vKey As Integer) As Integer
        'Public Declare Auto Function GetKeyState Lib "user32 " (ByVal nVirtKey As Long) As Integer
        '     Public Declare Auto Function GetKeyboardState Lib "user32 " (pbKeyState As Byte) As Long
        '     Const VK_CAPITAL = &H14
        '  Const VK_SHIFT = &H10
        '  Public myarr(0 To 255) As Byte
        Dim Shift_Ctrl_D As Byte = 0
        Dim frm As New Showdebugdevice

        Dim returncrc As New ReturnCRC
        Do
            If Shift_Ctrl_D = 3 Then
                frm.ShowDialog()
            End If
            System.Threading.Thread.Sleep(10)
            For i = 0 To 128 Step 1
                Dim KeyResult = GetAsyncKeyState(i)
                If KeyResult = -32767 Then
                    If i = 13 Then
                        '按下了回车键
                        UpdataUIThread = New Thread(AddressOf PreparationUpdataUI)
                        UpdataUIThread.Start()
                    End If
                End If
            Next
        Loop
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        UImanualspeedname = TextBox1.Text
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        UImanualspeedplcaddress = TextBox2.Text
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        UIautospeedname = TextBox3.Text
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        UIautospeedplcaddress = TextBox4.Text
    End Sub

    Private Sub Speedset_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Try

            If (GetAsyncKey.IsAlive = True) Then GetAsyncKey.Abort()
            If (UpdataUIThread.IsAlive = True) Then UpdataUIThread.Abort()

        Catch ex As Exception

        End Try
    End Sub
End Class