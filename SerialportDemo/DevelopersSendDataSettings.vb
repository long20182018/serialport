Imports System.IO
Imports System.Threading

Public Class DevelopersSendDataSettings
    '实例化数据库连接
    Dim conn As New Connectiondatabase
    '发送的数据 
    Dim SenddataOne As String
    Dim SenddataTwo As String
    Dim SenddataThree As String
    Dim SenddataFour As String
    Dim SenddataFive As String
    Dim SendSplitone
    Dim SendSplitTwo
    Dim SendSplitThree
    Dim SendSplitFour
    Dim SendSplitFive

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim identifier As String
        Dim tempStr

        If TextBox3.Text <> "" Then
            SenddataOne = TextBox3.Text
            SendSplitone = Split(TextBox1.Text, ",")
            identifier = Microsoft.VisualBasic.Left(SendSplitone(0), 1)
            tempStr = Splitdata(SendSplitone, SendSplitone)
            conn.Senddata("发送的数据", identifier, SenddataOne, tempStr)
        End If

        If TextBox4.Text <> "" Then
            SenddataTwo = TextBox4.Text
            SendSplitTwo = Split(TextBox2.Text, ",")
            identifier = Microsoft.VisualBasic.Left(SendSplitTwo(0), 1)
            tempStr = Splitdata(SendSplitTwo, SendSplitTwo)
            conn.Senddata("发送的数据", identifier, SenddataTwo, tempStr)
        End If

        If TextBox6.Text <> "" Then
            SenddataThree = TextBox6.Text
            SendSplitThree = Split(TextBox5.Text, ",")
            identifier = Microsoft.VisualBasic.Left(SendSplitThree(0), 1)
            tempStr = Splitdata(SendSplitThree, SendSplitThree)
            conn.Senddata("发送的数据", identifier, SenddataThree, tempStr)
        End If

        If TextBox8.Text <> "" Then
            SenddataFour = TextBox8.Text
            SendSplitFour = Split(TextBox7.Text, ",")
            identifier = Microsoft.VisualBasic.Left(SendSplitFour(0), 1)
            tempStr = Splitdata(SendSplitFour, SendSplitFour)
            conn.Senddata("发送的数据", identifier, SenddataFour, tempStr)
        End If

        If TextBox10.Text <> "" Then
            SenddataFive = TextBox10.Text
            SendSplitFive = Split(TextBox9.Text, ",")
            identifier = Microsoft.VisualBasic.Left(SendSplitFive(0), 1)
            tempStr = Splitdata(SendSplitFive, SendSplitFive)
            conn.Senddata("发送的数据", identifier, SenddataFive, tempStr)
        End If
    End Sub

    Private Function Splitdata(data(), Strname)
        Dim tempList As String
        Dim tempCount As Byte = 0
        Dim NewName As String
        Dim _name As String
        _name = Microsoft.VisualBasic.Left(Strname(0), 1)
        For x = 0 To UBound(data)
            NewName = Microsoft.VisualBasic.Left(Strname(x), 1)
            If NewName <> _name Then
                tempCount = 0
            End If

            For y = 0 To 15
                tempList = tempList & NewName & Hex(tempCount) & ","
                tempCount += 1
            Next

        Next
        Splitdata = tempList

    End Function

    Private Sub DevelopersSendDataSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '屏幕居中
        '***************************************************************
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '***************************************************************
    End Sub
End Class