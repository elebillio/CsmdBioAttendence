Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraNavBar

Public Class frmMain



    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(Application.ProductName, "CsmdUserLookAndFeel", "CsmdActiveSkinName", UserLookAndFeel.Default.ActiveSkinName)

        frmLogin.Show()
        'frmPlazaOpening.Close()
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            UserLookAndFeel.Default.SetSkinStyle(GetSetting(Application.ProductName, "CsmdUserLookAndFeel", "CsmdActiveSkinName", ""))
        Catch ex As Exception
            UserLookAndFeel.Default.SetSkinStyle("Sharp")
            SaveSetting(Application.ProductName, UserLookAndFeel.Default.ActiveSkinName, UserLookAndFeel.Default.ActiveSkinName, UserLookAndFeel.Default.ActiveSkinName)
        End Try
    End Sub

    Private Sub BackstageViewTabItem1_SelectedChanged(sender As Object, e As BackstageViewItemEventArgs) Handles BackstageViewTabItem1.SelectedChanged
        BackstageViewClientControl1.Controls.Clear()
        Dim uc As New UserControl1
        uc.Dock = DockStyle.Fill
        If frmLoadAction = frmEditAction Then
            frmLoadAction = frmEditAction
        Else
            frmLoadAction = frmNewAction
        End If
        'uc.LoadTeachersRecords(intMultiFee)
        'uc.SearchLookUpEdit1.EditValue = intMultiFee
        'uc.SimpleButton2.PerformClick()
        BackstageViewClientControl1.Controls.Add(uc)

    End Sub

    Private Sub BackstageViewTabItem2_SelectedChanged(sender As Object, e As BackstageViewItemEventArgs) Handles BackstageViewTabItem2.SelectedChanged
        'frmLoadAction = frmNewAction
        BackstageViewClientControl2.Controls.Clear()
        Dim uc As New UserControl2
        uc.Dock = DockStyle.Fill
        BackstageViewClientControl2.Controls.Add(uc)


    End Sub

    Private Sub BackstageViewTabItem3_SelectedChanged(sender As Object, e As BackstageViewItemEventArgs) Handles BackstageViewTabItem3.SelectedChanged
        BackstageViewClientControl3.Controls.Clear()
        Dim uc As New UserControl3
        uc.Dock = DockStyle.Fill
        BackstageViewClientControl3.Controls.Add(uc)
    End Sub

    Private Sub BackstageViewTabItem4_SelectedChanged(sender As Object, e As BackstageViewItemEventArgs) Handles BackstageViewTabItem4.SelectedChanged
        BackstageViewClientControl4.Controls.Clear()
        Dim uc As New UserControl4
        uc.Dock = DockStyle.Fill
        BackstageViewClientControl4.Controls.Add(uc)
    End Sub


    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        LabelControl1.Width = Me.Width - 230

    End Sub

    Private Sub BackstageViewTabItem5_SelectedChanged(sender As Object, e As BackstageViewItemEventArgs) Handles BackstageViewTabItem5.SelectedChanged
        BackstageViewClientControl5.Controls.Clear()
        Dim uc As New RM_Live.UserControl5
        uc.Dock = DockStyle.Fill
        BackstageViewClientControl5.Controls.Add(uc)
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim form As New DevExpress.XtraEditors.ColorWheel.ColorWheelForm
        form.StartPosition = FormStartPosition.CenterParent
        form.SkinMaskColor = UserLookAndFeel.Default.SkinMaskColor
        form.SkinMaskColor2 = UserLookAndFeel.Default.SkinMaskColor2
        form.ShowDialog(Me)
    End Sub


End Class
