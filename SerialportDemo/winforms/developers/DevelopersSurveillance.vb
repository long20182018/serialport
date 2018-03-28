

Public Class DevelopersSurveillance
    '实例化连接数据库
    Dim conn As New Connectiondatabase
    '监视地址
    Dim SurveillanceAddressX() As String
    Dim SurveillanceAddressY() As String
    '监视端口
    Dim SurveillanceSerialportX() As String
    Dim SurveillanceSerialportY() As String

    Private Sub DevelopersSurveillance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '设置窗体剧中
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        '**********************************************************
        '先将用户填写数据进行分割
        Dim Xserialport = Split(TextBox1.Text, ",")
        Dim XSurveillanceAddress = Split(TextBox2.Text, ",")
        Dim Yserialport = Split(TextBox3.Text, ",")
        Dim YSurveillanceAddress = Split(TextBox4.Text, ",")
        '***********************************************************

        If (Xserialport(0) = "" Or XSurveillanceAddress(0) = "" Or Yserialport(0) = "" Or YSurveillanceAddress(0) = "") Then
            MsgBox("请填写完整资料")
            Exit Sub
        End If

        '重新声明数组长度
        '***********************************************************************************************
        ReDim Preserve SurveillanceSerialportX(UBound(Xserialport))
        ReDim Preserve SurveillanceSerialportY(UBound(Yserialport))
        ReDim Preserve SurveillanceAddressX(UBound(XSurveillanceAddress))
        ReDim Preserve SurveillanceAddressY(UBound(YSurveillanceAddress))
        '************************************************************************************************

        '循环遍历装入数组
        '*************************************************************************************************
        Dim byteCount As Byte = 0

        '装入X端口
        For x = 0 To UBound(Xserialport)
            SurveillanceSerialportX(byteCount) = Xserialport(x)
            byteCount += 1
        Next
        '装入Y端口
        byteCount = 0
        For x = 0 To UBound(Yserialport)
            SurveillanceSerialportY(byteCount) = Yserialport(x)
            byteCount += 1
        Next

        byteCount = 0

        '装入X监视地址
        For x = 0 To UBound(XSurveillanceAddress)
            SurveillanceAddressX(byteCount) = XSurveillanceAddress(x)
            byteCount += 1
        Next

        '装入Y监视地址
        byteCount = 0

        For x = 0 To UBound(YSurveillanceAddress)
            SurveillanceAddressY(byteCount) = YSurveillanceAddress(x)
            byteCount += 1
        Next

        '*************************************************************************************************
        Label7.Text = conn.Add_SurveillanceAddress("监视端口X", "PLC地址", Xserialport)
        Label7.Text = conn.Add_SurveillanceAddress("监视端口Y", "PLC地址", Yserialport)
        Label7.Text = conn.Add_SurveillanceAddress("监视端口X", "监视地址", XSurveillanceAddress)
        Label7.Text = conn.Add_SurveillanceAddress("监视端口Y", "监视地址", YSurveillanceAddress)

    End Sub
End Class