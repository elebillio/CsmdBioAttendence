Imports DevExpress.LookAndFeel

Public Class Form1
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", UserLookAndFeel.Default.ActiveSkinName)

        'frmLogin.Show()
        'frmPlazaOpening.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            UserLookAndFeel.Default.SetSkinStyle(GetSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", ""))
        Catch ex As Exception
            UserLookAndFeel.Default.SetSkinStyle("Sharp")
            SaveSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", UserLookAndFeel.Default.ActiveSkinName)
        End Try
        Dim uc As UserControl = New UserControl5
        uc.Dock = DockStyle.Fill
        Me.Controls.Add(uc)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Text = "Csmd Employees Attendence Software with Device Live Preview > " & Now
    End Sub
End Class
