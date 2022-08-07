'Imports CsmdBioDatabase

Public Class frmEmpA

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        Me.Text = TextEdit1.Text
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & SpinEdit1.EditValue, TextEdit1.Text)
    End Sub

    Private Sub TextEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEdit1.KeyDown

        If e.KeyCode = Keys.Enter Then
            Select Case SpinEdit1.EditValue
                Case 0
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 0, TextEdit1.Text)
                Case 1
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 1, TextEdit1.Text)
                Case 2
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 2, TextEdit1.Text)
                Case 3
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 3, TextEdit1.Text)
                Case 4
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 4, TextEdit1.Text)
                Case 5
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 5, TextEdit1.Text)
                Case 6
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 6, TextEdit1.Text)
                Case 7
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 7, TextEdit1.Text)
                Case 8
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 8, TextEdit1.Text)
                Case 9
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 9, TextEdit1.Text)
                Case 10
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 10, TextEdit1.Text)
                Case 11
                    SaveSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp" & 11, TextEdit1.Text)
            End Select
            'TextEdit1.Text = ""
        End If
    End Sub

    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged

    End Sub

    Private Sub frmEmpA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub
End Class