Public Class ReturnCRC
    Function Get_CRC16(Tstr$) As String
        Dim Cval, CrcvalA, CrcvalB, Hexval
        Cval = 65535

        For i = 1 To Len(Tstr) Step 3
            Hexval = Val("&H" & Mid(Tstr, i, 2))
            Cval = (Cval Xor Hexval) And 65535
            For j = 1 To 8
                If (Cval And &H1) Then
                    Cval = (Cval \ 2) Xor &HA001
                Else
                    Cval = (Cval \ 2)
                End If
                Cval = Cval And 65535
            Next j
        Next i

        CrcvalA = (Cval And 255) * 256
        CrcvalB = (Cval And 65280) / 256

        Select Case CrcvalA + CrcvalB
            Case Is < 16
                Get_CRC16 = "000" & Hex(CrcvalA + CrcvalB)
            Case Is < 256
                Get_CRC16 = "00" + Hex(CrcvalA + CrcvalB)
            Case Is < 4096
                Get_CRC16 = "0" + Hex(CrcvalA + CrcvalB)
            Case Else
                Get_CRC16 = Hex(CrcvalA + CrcvalB)
        End Select

    End Function
End Class
