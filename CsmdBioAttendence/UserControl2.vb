Imports System.Data.Entity
Imports DevExpress.XtraEditors

Public Class UserControl2

    Dim db As New CsmdBioAttendenceEntities

    Sub New()
        InitializeComponent()
        db = New CsmdBioAttendenceEntities
        db.Employees.Load()
        BindingSource1.DataSource = db.Employees.Local.ToBindingList()
    End Sub
    Private Sub AdvBandedGridView1_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles AdvBandedGridView1.RowUpdated
        db.SaveChanges()
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        AdvBandedGridView1.OptionsBehavior.Editable = True
        SimpleButton1.Enabled = False
        SimpleButton2.Enabled = True
        SimpleButton3.Enabled = False
        SimpleButton4.Enabled = False
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        AdvBandedGridView1.OptionsBehavior.Editable = False
        SimpleButton1.Enabled = True
        SimpleButton2.Enabled = False
        SimpleButton3.Enabled = True
        SimpleButton4.Enabled = True
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        AdvBandedGridView1.OptionsBehavior.Editable = False
        db = New CsmdBioAttendenceEntities
        db.Employees.Load()
        BindingSource1.DataSource = db.Employees.Local.ToBindingList()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        AdvBandedGridView1.OptionsBehavior.Editable = False
        AdvBandedGridView1.ShowPrintPreview()
    End Sub

    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles AdvBandedGridView1.DoubleClick
        frmLoadAction = frmEditAction
        frmMain.BackstageViewControl1.SelectedTab = frmMain.BackstageViewTabItem1
        intMultiFee = AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID")
    End Sub

    Private Sub AdvBandedGridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles AdvBandedGridView1.RowClick
        intMultiFee = AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID")
    End Sub

    Private Sub RepositoryItemTimeEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTimeEdit1.EditValueChanged
        Dim kk As TimeEdit = TryCast(sender, TimeEdit)
        kk.EditValue = CDate(kk.EditValue).ToString("HH:mm")
    End Sub
    Private Sub RepositoryItemTimeEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTimeEdit2.EditValueChanged
        Dim kk As TimeEdit = TryCast(sender, TimeEdit)
        kk.EditValue = CDate(kk.EditValue).ToString("HH:mm")
    End Sub

    Private Sub UserControl2_Load(sender As Object, e As EventArgs) Handles Me.Load
        frmLoadAction = frmNewAction
    End Sub
End Class
