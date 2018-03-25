Imports System.IO
Imports System.Threading


Public Class DevelopersAbnormal
    '键盘勾子线程，监控键盘输入 
    Dim GetAsyncKey As Thread
    Dim AbnormalarrayList(0 To 32, 0 To 2)
    Dim conn As New Connectiondatabase

    Private Sub DevelopersAbnormal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '屏幕居中
        '***************************************************************
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '***************************************************************
        DataGridView1.Rows.Add(32)
    End Sub

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
                        Call add_data()
                    End If
                End If
            Next
        Loop
    End Sub


    Private Sub add_data()

        For x = 0 To 32
            If DataGridView1.Rows(x).Cells(1).Value <> "" Then
                AbnormalarrayList(x, 0) = DataGridView1.Rows(x).Cells(0).Value
                AbnormalarrayList(x, 1) = DataGridView1.Rows(x).Cells(1).Value
            End If
        Next
        Dim tempstr = conn.add_Abnormaldata("报警值", AbnormalarrayList)
        MsgBox(tempstr)
    End Sub
End Class