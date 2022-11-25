
Imports System.Data.Entity
'Imports CsmdPlazaDatabase
Imports CsmdBioDatabase
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmEmployeesRegisters

    Dim db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities

    Sub New()
        InitializeComponent()
        db = New CsmdBioAttendenceEntities
        db.Employees.Load()
        BindingSource1.DataSource = db.Employees.Local.ToBindingList()
    End Sub
    Private Sub AdvBandedGridView1_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles AdvBandedGridView1.RowUpdated
        db.SaveChanges()
    End Sub


    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles AdvBandedGridView1.DoubleClick
        frmLoadAction = frmEditAction
        intMultiFee = AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID")
        frmEmployeesAdds.ShowDialog()
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
        AdvBandedGridView1.IndicatorWidth = 35
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        AdvBandedGridView1.OptionsBehavior.Editable = True
        BarButtonItem1.Enabled = False
        BarButtonItem2.Enabled = True
        BarButtonItem3.Enabled = False
        BarButtonItem4.Enabled = False
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        AdvBandedGridView1.OptionsBehavior.Editable = False
        BarButtonItem1.Enabled = True
        BarButtonItem2.Enabled = False
        BarButtonItem3.Enabled = True
        BarButtonItem4.Enabled = True
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        AdvBandedGridView1.OptionsBehavior.Editable = False
        db = New CsmdBioAttendenceEntities
        db.Employees.Load()
        BindingSource1.DataSource = db.Employees.Local.ToBindingList()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        AdvBandedGridView1.OptionsBehavior.Editable = False
        AdvBandedGridView1.ShowPrintPreview()
    End Sub

    Private Sub AdvBandedGridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub
End Class