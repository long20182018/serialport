Imports System.Threading


Public Class serialClass

    Public Class connect

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
                serialport.ReadBufferSize = 1
                serialport.Open()
            Catch ex As Exception
                MsgBox("连接失败" + vbNewLine + ErrorToString(), vbDefaultButton1, "错误")
            End Try
        End Sub

        Public Sub Closedevice()
            If (serialport.IsOpen = True) Then serialport.Close()
        End Sub

    End Class

    Public Class send
        'CRC校验类
        Private GetCRC As New ReturnCRC
        '存放CRC校验码
        Private leaveCRC As String
        '分割后的字符串
        Private splitstr()
        '字节数组
        Private Databytelist
        Public Sub send_plcdata(data As String)      '发送数据 
            Try

                If data = "" Then Exit Sub

                leaveCRC = GetCRC.Get_CRC16(data)
                splitstr = Split(data, " ")

                If splitstr.Length < 6 Then Exit Sub

                ReDim Databytelist(Splitdata.Length + 1)

                For i As Integer = 0 To Splitdata.Length - 1
                    Databytelist(i) = "&H" & Splitdata(i)
                Next

                Databytelist(Splitdata.Length) = "&H" & leaveCRC.Substring(0, 2)
                Databytelist(Splitdata.Length + 1) = "&H" & leaveCRC.Substring(2)

                serialport.DiscardInBuffer()
                serialport.DiscardOutBuffer()

                serialport.Write(Databytelist, 0, Databytelist.Length)

            Catch ex As Exception
                MsgBox(ex.ToString, vbDefaultButton1, "出错了")
            End Try

        End Sub

    End Class

    Public Class getdata

        Public Sub addhandl()
            AddHandler serialport.DataReceived, AddressOf SerialPort_DataReceived
        End Sub



        Private Sub SerialPort_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs)

            Dim _time As Long = 0
            Dim byteToRead = serialport.BytesToRead()
            Dim ch(byteToRead) As Byte
            '等待时间，等待接收完缓冲区数据
            Do
                _time += 1
                Dim tempstr As String = ""
                If (ch.Length > 3) Then
                    For x As Byte = 0 To UBound(ch) - 3
                        tempstr = tempstr & ch(x) & " "
                    Next
                End If
                If tempstr <> "" Then Dim tempcrc = getCRC.Get_CRC16(tempstr)

            Loop Until _time >= 5000




            Dim bytesRead
            bytesRead = serialport.Read(ch, 0, ch.Length)

            If Val(ch(2)) > 0 Then

                Select Case ch(1)

                    Case Is = 1

                    Case Is = 2

                    Case Is = 3

                    Case Is = 5

                End Select
            End If


        End Sub
    End Class



End Class
