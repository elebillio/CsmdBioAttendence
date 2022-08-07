Public Class Form5
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Dim v As Integer = If(TextBox1.Text = "", 0, TextBox1.Text)

        Dim a As Integer = v * 10

        Dim b As Integer = a - 9




        ListBox1.Items.Clear()
        For k As Integer = b To a
            ListBox1.Items.Add(k)
        Next



    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class