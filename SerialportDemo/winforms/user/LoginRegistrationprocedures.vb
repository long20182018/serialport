Imports System.Management
Imports Scripting
Imports System.IO


Public Class LoginRegistrationprocedures
    Dim frm As New WinSerialportManager
    Dim mystream As FileStream
    Dim writer As StreamWriter
    Private Sub LoginRegistrationprocedures_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call registeredsystems()

        TextBox1.Text = Mkey()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a1!, a2$, a3$, a4$, i%
        Dim c1 As New GetVolum.getHarddisksequence
        For i = 1 To Len(TextBox2.Text)
            a1 = a1 + Asc(Microsoft.VisualBasic.Mid(TextBox2.Text, i, 1))
        Next i
        If a1 < 0 Then a1 = a1 * -1 '如果负数，则转成整数
        a2 = Mkey() + a1 * 9
        a3 = c1.DigestStrToHexStr(a2) '用户名的md5
        a4 = Microsoft.VisualBasic.Left(a3, 10) '真正的注册码
        If TextBox3.Text = a4 Then

            If Not System.IO.File.Exists("C:\记事本配置文件.ini") Then

                mystream = New System.IO.FileStream("C:\记事本配置文件.ini", FileMode.Create)

                writer = New System.IO.StreamWriter(mystream)

            End If
            writer = New System.IO.StreamWriter(mystream)
            writer.WriteLine("[注册参数]")
            writer.WriteLine("用户名=" & TextBox2.Text)
            writer.WriteLine("注册码=" & TextBox3.Text)
            writer.Close()
            MsgBox("注册成功！", vbOKOnly, "恭喜")

            '   SetIniS("注册参数", "用户名", TextBox2.Text)
            '  SetIniS("注册参数", "注册码", TextBox3.Text)
            Me.Close()
            frm.Show()

        Else
            MsgBox("注册码错误，请重新输入！", vbOKOnly + vbExclamation, "提示")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call Regtimes()
    End Sub
End Class