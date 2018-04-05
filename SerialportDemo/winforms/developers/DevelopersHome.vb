Public Class DevelopersHome
    Private conn As New Connectiondatabase

    Private Sub DS按钮1_ButtonClick(Sender As Object) Handles DS按钮1.ButtonClick
        conn.Settingprogram(TextBox1.Text, TextBox2.Text, TextBox3.Text)

    End Sub
End Class