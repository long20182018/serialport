Public Class DevelopersParametersetting
    Private Sub DevelopersParametersetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '屏幕居中
        '***************************************************************
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '***************************************************************
    End Sub
End Class