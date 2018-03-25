Public Class Form1
    Dim myPicture As New System.Windows.Forms.PictureBox()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '   My_Control_label() '生成label1标签控件函数 
        ComboBox1.Items.Add(0)
    End Sub
    Private Sub My_Control_label()
        Dim label1 As New Label '定义一个标签控件对象  
        Me.Controls.Add(label1) '添加到窗体控件集中，你也可以添加到其他控件集中，  
        '如(Panel1.Controls.Add(label1))就是添加到panel1控件中  
        With label1
            .Text = "新建标签"
            .Location = New Point(10, 20) '定义控件位置，默认的是（0，0）  
            .AutoSize = True
            .ForeColor = Color.Red
            .Font = New Font("楷体", 20) '定义字体  
        End With
        AddHandler label1.Click, AddressOf label_Click '添加click事件  
    End Sub
    '标签的click事件，点击该标签后，释放该控件资源  
    Private Sub label_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim label1 As Label = CType(sender, Label) '获取当前操作的控件对象，只有这样才能对该控件进行操作  
        Me.Controls.Remove(label1) '将控件移除  
        label1.Dispose() '释放控件资源  
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_TextChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged

    End Sub

    Private Sub ComboBox1_FontChanged(sender As Object, e As EventArgs) Handles ComboBox1.FontChanged

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown

    End Sub
End Class