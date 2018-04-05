Imports System.Threading

Public Class connecteddevice

    Public Sub connect_device()
        Try
            serialport.PortName = 端口
            serialport.BaudRate = 波特率
            If 校验 = "奇校验" Then
                serialport.Parity = IO.Ports.Parity.Odd
            ElseIf 校验 = "偶校验" Then
                serialport.Parity = IO.Ports.Parity.Even
            Else
                serialport.Parity = IO.Ports.Parity.None
            End If
            serialport.DataBits = 数据位
            If 停止位 = 1 Then
                serialport.StopBits = IO.Ports.StopBits.One
            ElseIf 停止位 = 1.5 Then
                serialport.StopBits = IO.Ports.StopBits.OnePointFive
            Else
                serialport.StopBits = IO.Ports.StopBits.Two
            End If
            serialport.Encoding = System.Text.Encoding.Default
            serialport.DtrEnable = True
            serialport.NewLine = vbCrLf
            serialport.ReadTimeout = 2000
            serialport.ReadBufferSize = 6
            serialport.Open()
        Catch ex As Exception
            Dim ms As New Mssgbox
            ms.Label1.Text = "连接失败" + vbNewLine + ErrorToString()
            ms.ShowDialog()
        End Try
    End Sub

    Public Sub Closedevice()
        If (serialport.IsOpen = True) Then serialport.Close()
    End Sub
End Class
