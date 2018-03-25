Imports System.Management
Imports Scripting '获取硬盘序列号命名空间，须要引用 microsoft Scripting re....

Module index
    'MD5一机一码加密模块
    Dim frm As New WinSerialportManager


    Public Declare Auto Function GetVolumeInformation Lib "kernel32.dll" Alias _
    "GetVolumeInformationA" (ByVal lpRootPathName As String,
    ByVal lpVolumeNameBuffer As String, ByVal nVolumeNameSize As Integer,
    lpVolumeSerialNumber As Long, lpMaximumComponentLength As Long,
    lpFileSystemFlags As Long, ByVal lpFileSystemNameBuffer As String,
    ByVal nFileSystemNameSize As Long) As Long
    Const MAX_FILENAME_LEN = 256
    Public registrationsuccess As Boolean
    Dim PanRetval As Long
    Dim Panstr As String = Panstr * MAX_FILENAME_LEN
    Dim Panstr2 As String = Panstr2 * MAX_FILENAME_LEN
    Dim PanA As Long
    Dim PanB As Long
    Public Md5YesNo As Boolean


    Public Sub Main() '程序启动前的初始化过程
        Dim Pass1$, Pass2$, i%
        Dim yonghu1!, yonghu2$, yonghu3, yonghu4$
        Dim c1 As New GetVolum.getHarddisksequence
        'On Error Resume Next

        If Dir("C:\记事本配置文件.ini") <> "" Then
            Pass1 = GetIniS("注册参数", "用户名", "") '注册后保存在电脑上的用户名
            Pass2 = GetIniS("注册参数", "注册码", "") '注册后保存在电脑上的注册码
            For i = 1 To Len(Pass1)
                yonghu1 = yonghu1 + Asc(Mid$(Pass1, i, 1))
            Next i
            If yonghu1 < 0 Then yonghu1 = yonghu1 * -1 '如果负数，则转成整数
            yonghu2 = Mkey() + yonghu1 * 9
            yonghu3 = c1.DigestStrToHexStr(yonghu2) '用户名的md5
            yonghu4 = Microsoft.VisualBasic.Left(yonghu3, 10) '真正的注册码

            If Pass2 = yonghu4 Then
                frm.Show()

            Else

            End If
        Else

        End If
    End Sub


    Public Sub Regtimes() '调用次数限制的过程
        Dim RemainDay As Long
        RemainDay = GetSetting("记事本程序", "次数限制", "times", 0)
        If RemainDay >= 1000 Then
            MsgBox("试用次数已满，请注册！", vbOKOnly, "重要提醒")

            Exit Sub
        End If
        MsgBox("现在剩下：" & 1000 - RemainDay & "次试用，！QQ：614021330", vbOKOnly, "提示")
        RemainDay = RemainDay + 1
        SaveSetting("记事本程序", "次数限制", "times", RemainDay)

    End Sub


    Public Function Mkey() '调用机器码
        Dim Fso As New FileSystemObject
        Dim drvDisk As Drive, strResult As String
        drvDisk = Fso.GetDrive("C:\")
        strResult = "Drive " & "C:\" & vbCrLf
        strResult += "磁盘卷标:" & drvDisk.VolumeName & vbCrLf
        Dim codeNumber = drvDisk.SerialNumber & vbCrLf
        If codeNumber < 0 Then codeNumber *= -1
        strResult += "磁盘类型:" & drvDisk.DriveType & vbCrLf
        strResult += "文件系统:" & drvDisk.FileSystem & vbCrLf
        strResult += "磁盘容量(G): " & FormatNumber(((drvDisk.TotalSize / 1024) / 1024) / 1024, 2,
Microsoft.VisualBasic.TriState.True) & vbCrLf
        strResult += "可用空间(G): " & FormatNumber(((drvDisk.FreeSpace / 1024) / 1024) / 1024, 2,
Microsoft.VisualBasic.TriState.True) & vbCrLf
        strResult += "已用空间(G):" & FormatNumber(((((drvDisk.TotalSize - drvDisk.FreeSpace) /
1024) / 1024) / 1024), 2, , , Microsoft.VisualBasic.TriState.True)
        Return codeNumber
    End Function

End Module

