Public Class DevelopersModbusaddress
    Dim conn As New Connectiondatabase
    Dim ReturnString As String


#Region "初始化"
    Private Sub Modbusaddress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        For Each ct In GroupBox1.Controls
            If (TypeOf ct Is ComboBox) Then
                ct.Items.Add(16)
                ct.Items.Add(32)
                ct.Items.Add(64)
            End If
        Next
        For Each ct In GroupBox2.Controls
            If (TypeOf ct Is ComboBox) Then
                ct.Items.Add(16)
                ct.Items.Add(32)
                ct.Items.Add(64)
            End If
        Next
    End Sub
#End Region
#Region "添加数据到数据库"
    Private Sub Adddata()
        Dim inputXcount As Byte
        Dim inputYcount As Byte

        For Each ct In GroupBox1.Controls
            If (TypeOf ct Is ComboBox) Then
                If ct.text <> "" Then inputXcount = inputXcount + 1
            End If
        Next

        For Each ct In GroupBox2.Controls
            If (TypeOf ct Is ComboBox) Then
                If ct.text <> "" Then inputYcount = inputYcount + 1
            End If
        Next

        Select Case inputXcount
            '如果为单个plc时（没有扩展）
            Case Is = 1
                ReDim DeveloperModbus(0 To ComboBox1.Text - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    DeveloperModbus(x, 0) = x
                    DeveloperModbus(x, 1) = "X" & Hex(x)
                    Dim tempstr As String = "000" & Hex(x)
                    DeveloperModbus(x, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                Next

                '如果为2个plc时（有扩展）
            Case Is = 2
                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox1.Text) + Val(ComboBox2.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "X" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next



                '如果为3个plc时（有扩展）
            Case Is = 3

                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox1.Text) + Val(ComboBox2.Text) + Val(ComboBox3.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "X" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1024 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next


                 '如果为4个plc时（有扩展）
            Case Is = 4

                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox1.Text) + Val(ComboBox2.Text) + Val(ComboBox3.Text) + Val(ComboBox4.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "X" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1024 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1280 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next


                '如果为5个plc时（有扩展）
            Case Is = 5
                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox1.Text) + Val(ComboBox2.Text) + Val(ComboBox3.Text) + Val(ComboBox4.Text) + Val(ComboBox5.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "X" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1024 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1280 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1536 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "X" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next


        End Select
        ReturnString = conn.add_Modbusaddress("AddressX", DeveloperModbus)

        'Y输出

        Select Case inputYcount
            Case Is = 1
                ReDim DeveloperModbus(0 To ComboBox10.Text - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    DeveloperModbus(x, 0) = x
                    DeveloperModbus(x, 1) = "Y" & Hex(x)
                    Dim tempstr As String = "000" & Hex(x)
                    DeveloperModbus(x, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                Next

                '如果为2个plc时（有扩展）
            Case Is = 2
                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox10.Text) + Val(ComboBox11.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next



                '如果为3个plc时（有扩展）
            Case Is = 3

                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox10.Text) + Val(ComboBox11.Text) + Val(ComboBox12.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1024 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next


                 '如果为4个plc时（有扩展）
            Case Is = 4

                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox10.Text) + Val(ComboBox11.Text) + Val(ComboBox12.Text) + Val(ComboBox13.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1024 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1280 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next


                '如果为5个plc时（有扩展）
            Case Is = 5
                Dim indexCount As Byte = 0

                ReDim DeveloperModbus(0 To Val(ComboBox10.Text) + Val(ComboBox11.Text) + Val(ComboBox12.Text) + Val(ComboBox13.Text) + Val(ComboBox14.Text) - 1, 0 To 2)

                For x = 0 To ComboBox1.Text - 1
                    Dim kkkk = Val(ComboBox1.Text) + Val(ComboBox2.Text)
                    DeveloperModbus(indexCount, 0) = x
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                Dim tempHex = 768 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1024 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1280 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next

                tempHex = 1536 - indexCount

                For x = 0 To ComboBox2.Text - 1
                    DeveloperModbus(indexCount, 0) = indexCount
                    DeveloperModbus(indexCount, 1) = "Y" & Hex(tempHex + indexCount)
                    Dim tempstr As String = Microsoft.VisualBasic.Right(("000" & Hex(indexCount)), 4)
                    DeveloperModbus(indexCount, 2) = tempstr.Substring(0, 2) & " " & tempstr.Substring(2)
                    indexCount = indexCount + 1
                Next
                ReturnString = conn.add_Modbusaddress("AddressY", DeveloperModbus)
        End Select

        MsgBox(ReturnString)
    End Sub
#End Region
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Call Adddata()
    End Sub
End Class