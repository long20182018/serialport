Public Class DevelopersManager



    Private Sub DevelopersManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '屏幕居中
        '***************************************************************
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
        '***************************************************************
        'TreeView1.Enabled = False

        'Dim frm As New DevelopersLogin
        'frm.Close()
    End Sub

    'Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
    '    Select Case e.Node.Text
    '        Case "手动速度设置"
    '            OpenForms(DevelopersSpeedsettings)
    '        Case "自动速度设置"
    '            OpenForms(DevelopersSpeedsettings)
    '        Case "速度定义"
    '            OpenForms(DevelopersSpeedset)
    '        Case "报警值设置"
    '            OpenForms(DevelopersAbnormal)
    '        Case "MOdbus地址设置"
    '            OpenForms(DevelopersModbusaddress)
    '        Case "参数定义"
    '            OpenForms(DevelopersParametersetting)
    '        Case "发送指令"
    '            OpenForms(DevelopersSendDataSettings)
    '        Case "读取设置"
    '            OpenForms(DevelopersReadSettings)
    '        Case "监视地址设置"
    '            OpenForms(DevelopersSurveillance)
    '    End Select
    'End Sub

    Private Sub OpenForms(formsname As Form)
        formsname.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub 打开_Click(sender As Object, e As EventArgs) Handles 打开.Click
        Select Case 工具.SourceControl.Name
            Case "PictureBox1"
                OpenForms(DevelopersAbnormal)
            Case "PictureBox2"
                OpenForms(DevelopersModbusaddress)
            Case "PictureBox3"
                OpenForms(DevelopersParametersetting)
            Case "PictureBox4"
                OpenForms(DevelopersReadSettings)
            Case "PictureBox5"
                OpenForms(DevelopersSpeedsettings)
            Case "PictureBox6"
                OpenForms(DevelopersSurveillance)
        End Select
    End Sub
End Class