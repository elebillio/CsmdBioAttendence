Imports CsmdBioDatabase
Public Class frmEmpCashRegisterLock
    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Dim pw As String = TextEdit1.Text
        frmUnlock(pw)
    End Sub
    Private Sub frmUnlock(Pw As String)
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Plaza_User Where a.User_Pass = Pw Select a).FirstOrDefault
            If dt IsNot Nothing Then
                frmEmpCashRegister.ShowDialog()
                Close()
            Else
                MsgBox("Wrong Password")
            End If
        End Using
    End Sub

    Private Sub TextEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEdit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim pw As String = TextEdit1.Text
            frmUnlock(pw)
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub

    Private Sub frmEmpCashRegisterLock_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextEdit1.Text = ""
    End Sub
End Class