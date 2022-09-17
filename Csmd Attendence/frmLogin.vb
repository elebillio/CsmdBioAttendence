Imports System.Text
'Imports CsmdPlazaDatabase
Imports CsmdBioDatabase
Imports DevExpress.LookAndFeel

Public Class frmLogin

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Using db As New CsmdBioAttendenceEntities
            Dim Unm As String = uName.Text
            Dim uPs As String = uPass.Text
            Dim dt = (From a In db.Plaza_User Where a.User_Name = Unm And a.User_Pass = uPs Select a).FirstOrDefault
            If dt IsNot Nothing Then
                '
                Me.Hide()
                'frmPlazaOpening.Show()
                PlazaUserID = dt.User_ID
                frmMain.Show()
            Else
                MsgBox("Wrong Password")
            End If
        End Using
    End Sub

    Private Sub uPass_EditValueChanged(sender As Object, e As EventArgs) Handles uPass.EditValueChanged

    End Sub

    Private Sub uPass_KeyDown(sender As Object, e As KeyEventArgs) Handles uPass.KeyDown
        If e.KeyCode = Keys.Enter Then
            SimpleButton1.PerformClick()
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            UserLookAndFeel.Default.SetSkinStyle(GetSetting(Application.ProductName, "CsmdUserLookAndFeel", "CsmdActiveSkinName", ""))
        Catch ex As Exception
            UserLookAndFeel.Default.SetSkinStyle("Sharp")
            SaveSetting(Application.ProductName, "CsmdUserLookAndFeel", "CsmdActiveSkinName", UserLookAndFeel.Default.ActiveSkinName)
        End Try
        'MsgBox(SplitOnCapitals("ThisIsMyCapsDelimitedString"))
        uName.Text = "Csmd Softwares"
        ' uName.Text = "moaz"
        ''uName.Text = "ch imran"
        uPass.Text = "12321"
        uPass.Focus()

    End Sub
    Public Function SplitOnCapitals(ByVal str As String) As String
        Dim sb As New StringBuilder()
        For Each c As Char In str
            If Char.IsUpper(c) AndAlso sb.Length > 0 Then
                sb.Append(" "c)
            End If
            sb.Append(c)
        Next
        Return sb.ToString()
    End Function

    Private Sub PictureEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles PictureEdit1.EditValueChanged

    End Sub

    Private Sub frmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If UpdaterSW = True Then
            Close()
        End If
    End Sub
End Class