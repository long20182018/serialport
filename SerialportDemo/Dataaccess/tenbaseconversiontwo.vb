Public Class tenbaseconversiontwo
    '10进制转换到2进制
    Public Function DecimaliZation(Numten As Long) As String

        Dim a
        Dim s As String
        s = ""
        Do While Numten <> 0
            a = Numten Mod 2
            Numten = Numten \ 2
            s = Chr(48 + a) & s
        Loop
        Return s
    End Function

End Class
