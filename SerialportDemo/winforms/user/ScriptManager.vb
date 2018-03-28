Imports MSScriptControl

Public Class ScriptManager
    Dim ScriptControl As New MSScriptControl.ScriptControl


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        ScriptControl.AddCode(RichTextBox1.Text)
        ScriptControl.Run("startrun", TextBox1)
        TextBox1.Text = "VBScript  Output>>>>  QQ:641021330" & vbCrLf & TextBox1.Text

    End Sub

    Private Sub ScriptManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ScriptControl.Language = "VBScript"
    End Sub


End Class