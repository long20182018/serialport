Imports System.IO
Imports System.IO.Ports

Module Publicmodule
    '   My.Settings.DevelopersName = "long2018"
    '   My.Settings.DevelopersName = "qq614021330"
    '   My.Settings.adminname = "serialport"
    '   My.Settings.adminpassword = "qq614021330"
    '   My.Settings.username = "user"
    '   My.Settings.userpassword = "qq614021330"
#Region "Modbus方法属性"
    '****************** Modbus 地址 *************************
    'Y0---Y109F   0000-06DF
    'R0---R511F   0800-27FF
    'X0---X109F   0000-06DF
    'DT0-DT65532  0000-FFFC
    'WL0-WL127    0000-007F
    'LD0-LD255    07D0-08CF

    '***************** Modbus 功能码 ************************
    '01读线圈状态 
    '功能码               站号    功能码 起始地址高  起始地址低 数据总位数高 数据总位数低 校验码
    '   01                 01       01       08         00           00            10           读取10个线圈状态
    '返 ON            站号 01    功能码 01  字节数 02  位状态 FF FF 
    '返回OFF          站号 01    功能码 01  字节数 02  位状态 00 00
    '一次读取多个线圈时,会返回一个10进制数,转换成2进制后,可以根据2进制得出那一个线圈处于ON那一个处于OFF

    '02读输入状态 
    '功能码               站号    功能码 起始地址高  起始地址低 数据总位数高 数据总位数低 校验码
    '  02                   01       02      08          00          00           10           读取10个输入状态 
    '返 ON            站号 01    功能码 02  字节数 02  位状态 FF FF 
    '返回OFF          站号 01    功能码 02  字节数 02  位状态 00 00

    '02读取保持寄存器(D0--松下DT ) 
    '功能码               站号    功能码 起始地址高  起始地址低 数据总位数高 数据总位数低 校验码
    '  03                   01       03      00          00          00           4          读取10个寄存器
    '假设读取的4个寄存器为 DT00=4,DT01=5,DT02=1,DT03=2,返回  01 03 08 00 04 00 05 00 01 00 02
    '返回 站号01 功能码 03  字节数 08 寄存器值高位00 寄存器低位04 寄存器高位00 寄存器低位05 寄存器高位00 寄存器低位01 寄存器高位00 寄存器低位02  校验

    '05强制写单线圈(以松下Ｒ０为例)
    '功能码               站号    功能码 起始地址高  起始地址低 线圈状态 线圈状态 校验码
    '  05                   01       05      08          00        FF        00          发送ON 发送OFF时,将FF00更改为0000

#End Region
    Public serialport As SerialPort
    Public 端口 As String
    Public 波特率 As String
    Public 数据位 As String
    Public 停止位 As String
    Public 校验 As String
    Public Splitdata                            '分割数据
    Public getCRC As New ReturnCRC
#Region "键盘勾子"
    Public Declare Auto Function GetAsyncKeyState Lib "user32 " (ByVal vKey As Integer) As Integer
    Public Declare Auto Function GetKeyState Lib "user32 " (ByVal nVirtKey As Long) As Integer
    Public Declare Auto Function GetKeyboardState Lib "user32 " (pbKeyState As Byte) As Long
    Const VK_CAPITAL = &H14
    Const VK_SHIFT = &H10

    Public myarr(0 To 255) As Byte
    Public AddStrone As String
    Public AddStrtwo As String
    Public AddStrthree As String
    Public AddStrfour As String
    Public AddStrfive As String
    Public AddStrSix As String
    Public CRC16bit As String
#End Region

#Region "开发人员变量"
    Public AppPath As String = Directory.GetCurrentDirectory()   '获得根目录
    Public DeveloperSpeedsettings(0 To 3, 0 To 30)               '开发人员速度设置
    Public DeveloperParametersetting(0 To 50)                    '开发人员参数设置
    Public DeveloperModbus                                       '开发人员Modbus
    Public loginname As String                                   '登录人员
    Public Mssage As Mssgbox
#End Region

#Region "返回数据公有变量"
    Public InputState(500) As Boolean           '设备输入端状态
    Public OutState(500) As Boolean             '设备输出端状态
    Public plcReporting(0 To 100, 0 To 1)       '存放设备报警值
    Public PlcRaddress(0 To 8888, 0 To 2)       '装载R0-Rn 个地址
    Public FunctionCodearraylistOne(100)
    Public FunctioncodearraylistOneRows As Byte
    Public FunctionCodearraylistTwo(100)
    Public FunctionCodearraylistTwoRows As Byte
    Public tempabnormaladdress(0 To 100, 0 To 1)
    Public tempDtaddress As Integer
    Public Form1Serialdata As String
    Public Formuladata(0 To 100, 0 To 1) As String '存放配方数组，
#End Region

#Region "发送共有变量"
    Public allowSend As Boolean = False

#End Region

#Region "注册相关"
    '注册状态
    Public redisteredstaet As Boolean = False


#End Region

End Module
