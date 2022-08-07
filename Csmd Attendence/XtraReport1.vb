Public Class XtraReport1
    Private Sub XrTableCell8_PreviewClick(sender As Object, e As DevExpress.XtraReports.UI.PreviewMouseEventArgs) Handles XrTableCell8.PreviewClick
        MsgBox(XrTableCell8.Text)
        frmEmployeesAdds.Show()
    End Sub

    Private Sub XrTableCell91_PreviewDoubleClick(sender As Object, e As DevExpress.XtraReports.UI.PreviewMouseEventArgs) Handles XrTableCell91.PreviewDoubleClick

    End Sub
End Class