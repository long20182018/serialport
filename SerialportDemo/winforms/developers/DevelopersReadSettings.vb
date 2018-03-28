Public Class DevelopersReadSettings
    Private Sub ReadSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Rows.Add(20)
        Me.Top = (My.Computer.Screen.Bounds.Height - Me.Height) / 2
        Me.Left = (My.Computer.Screen.Bounds.Width - Me.Width) / 2
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim frm As New DevelopersReadadd
        frm.ShowDialog()

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Dim conn As New Connectiondatabase
        Dim tempReturn As String
        conn.ClearanceDataTabel("Modbus.mdb", "Readdata")

        For x = 0 To 20
            If DataGridView1.Rows(x).Cells(0).Value <> "" Then
                tempReturn = conn.add_senddata("Readdata", "0" & DataGridView1.Rows(x).Cells(0).Value, "0" & DataGridView1.Rows(x).Cells(1).Value,
                              DataGridView1.Rows(x).Cells(2).Value, DataGridView1.Rows(x).Cells(3).Value,
                              DataGridView1.Rows(x).Cells(4).Value, DataGridView1.Rows(x).Cells(5).Value,
                              DataGridView1.Rows(x).Cells(6).Value)
            End If
        Next
        If tempReturn <> "" Then Label1.Text = "状态：" & tempReturn
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Me.Close()
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class