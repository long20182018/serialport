
Public Class Mainsystem
    Private loginyesno As Boolean = False
    Private passworderrorcount As Byte = 6

#Region "loginsystem"
    Public Function loginsystem(username As String, password As String) As String
        Try
            Select Case username
                Case "long2018"
                    If (My.Settings.developespassworderrorcount < 6) Then
                        If (username = My.Settings.DevelopersName And password = My.Settings.Developerspassword) Then
                            loginsystem = "开发者"
                        Else
                            My.Settings.developespassworderrorcount += 1
                            My.Settings.Save()
                            loginsystem = "帐号或密码错误,错误" & passworderrorcount - My.Settings.developespassworderrorcount & "次将锁定"
                        End If
                    Else
                        loginsystem = "帐号已锁定，请联系作者QQ614021330"

                    End If
                    Exit Function

                Case "serialport"

                    If (My.Settings.adminpassworderrorcount < 6) Then
                        If (username = My.Settings.adminname And password = My.Settings.adminpassword) Then
                            loginsystem = "管理员"
                        Else
                            My.Settings.adminpassworderrorcount += 1
                            My.Settings.Save()
                            loginsystem = "帐号或密码错误,错误" & passworderrorcount - My.Settings.adminpassworderrorcount & "次将锁定"
                        End If
                    Else
                        loginsystem = "帐号已锁定，请联系开发者"

                    End If
                    Exit Function
                Case "user"
                    If (My.Settings.userpassworderrorcount < 6) Then
                        If (username = My.Settings.username And password = My.Settings.userpassword) Then
                            loginsystem = "使用者"
                        Else
                            My.Settings.userpassworderrorcount += 1
                            My.Settings.Save()
                            loginsystem = "帐号或密码错误,错误" & passworderrorcount - My.Settings.userpassworderrorcount & "次将锁定"
                        End If

                    Else
                        loginsystem = "帐号已锁定，请联系管理员"
                    End If
                    Exit Function
            End Select

            loginsystem = "帐号不存在！"
        Catch ex As Exception
            Return ex.ToString
        End Try

    End Function

#End Region

    Public Function registered() As Boolean
        Return registeredsystems()
    End Function

End Class
