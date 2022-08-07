<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProReports
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.VGridControl1 = New DevExpress.XtraVerticalGrid.VGridControl()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource()
        Me.rowEmp_Att_Payment_ID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_ID = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Issue_Date = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_From_Date = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_To_Date = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Absent_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Late_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Early_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_OverTime_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Private_Late_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Short_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Lunch_Late_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Lunch_OverTime_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Prayer_Late_Amount = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Fix = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Beg = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Advance = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Fine = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Bonus = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Total = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Paid = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        Me.rowEmp_Att_Payment_Balance = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'VGridControl1
        '
        Me.VGridControl1.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.VGridControl1.Appearance.RowHeaderPanel.Options.UseFont = True
        Me.VGridControl1.Cursor = System.Windows.Forms.Cursors.SizeWE
        Me.VGridControl1.DataSource = Me.BindingSource1
        Me.VGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VGridControl1.Location = New System.Drawing.Point(0, 0)
        Me.VGridControl1.Name = "VGridControl1"
        Me.VGridControl1.RowHeaderWidth = 200
        Me.VGridControl1.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowEmp_Att_Payment_ID, Me.rowEmp_ID, Me.rowEmp_Att_Payment_Issue_Date, Me.rowEmp_Att_Payment_From_Date, Me.rowEmp_Att_Payment_To_Date, Me.rowEmp_Att_Payment_Fix, Me.rowEmp_Att_Payment_Absent_Amount, Me.rowEmp_Att_Payment_Late_Amount, Me.rowEmp_Att_Payment_Early_Amount, Me.rowEmp_Att_Payment_OverTime_Amount, Me.rowEmp_Att_Payment_Prayer_Late_Amount, Me.rowEmp_Att_Payment_Short_Amount, Me.rowEmp_Att_Payment_Lunch_OverTime_Amount, Me.rowEmp_Att_Payment_Lunch_Late_Amount, Me.rowEmp_Att_Payment_Private_Late_Amount, Me.rowEmp_Att_Payment_Beg, Me.rowEmp_Att_Payment_Advance, Me.rowEmp_Att_Payment_Fine, Me.rowEmp_Att_Payment_Bonus, Me.rowEmp_Att_Payment_Total, Me.rowEmp_Att_Payment_Paid, Me.rowEmp_Att_Payment_Balance})
        Me.VGridControl1.Size = New System.Drawing.Size(863, 501)
        Me.VGridControl1.TabIndex = 0
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CsmdBioDatabase.Emp_Att_Payment)
        '
        'rowEmp_Att_Payment_ID
        '
        Me.rowEmp_Att_Payment_ID.Name = "rowEmp_Att_Payment_ID"
        Me.rowEmp_Att_Payment_ID.Properties.Caption = "Emp_Att_Payment_ID"
        Me.rowEmp_Att_Payment_ID.Properties.FieldName = "Emp_Att_Payment_ID"
        Me.rowEmp_Att_Payment_ID.Visible = False
        '
        'rowEmp_ID
        '
        Me.rowEmp_ID.Name = "rowEmp_ID"
        Me.rowEmp_ID.Properties.Caption = "Name"
        Me.rowEmp_ID.Properties.FieldName = "Employee.Emp_Name"
        '
        'rowEmp_Att_Payment_Issue_Date
        '
        Me.rowEmp_Att_Payment_Issue_Date.Name = "rowEmp_Att_Payment_Issue_Date"
        Me.rowEmp_Att_Payment_Issue_Date.Properties.Caption = "Issue Date"
        Me.rowEmp_Att_Payment_Issue_Date.Properties.FieldName = "Emp_Att_Payment_Issue_Date"
        '
        'rowEmp_Att_Payment_From_Date
        '
        Me.rowEmp_Att_Payment_From_Date.Name = "rowEmp_Att_Payment_From_Date"
        Me.rowEmp_Att_Payment_From_Date.Properties.Caption = "From Date"
        Me.rowEmp_Att_Payment_From_Date.Properties.FieldName = "Emp_Att_Payment_From_Date"
        '
        'rowEmp_Att_Payment_To_Date
        '
        Me.rowEmp_Att_Payment_To_Date.Name = "rowEmp_Att_Payment_To_Date"
        Me.rowEmp_Att_Payment_To_Date.Properties.Caption = "To Date"
        Me.rowEmp_Att_Payment_To_Date.Properties.FieldName = "Emp_Att_Payment_To_Date"
        '
        'rowEmp_Att_Payment_Absent_Amount
        '
        Me.rowEmp_Att_Payment_Absent_Amount.Name = "rowEmp_Att_Payment_Absent_Amount"
        Me.rowEmp_Att_Payment_Absent_Amount.Properties.Caption = "Absent"
        Me.rowEmp_Att_Payment_Absent_Amount.Properties.FieldName = "Emp_Att_Payment_Absent_Amount"
        '
        'rowEmp_Att_Payment_Late_Amount
        '
        Me.rowEmp_Att_Payment_Late_Amount.Name = "rowEmp_Att_Payment_Late_Amount"
        Me.rowEmp_Att_Payment_Late_Amount.Properties.Caption = "Late Arrival"
        Me.rowEmp_Att_Payment_Late_Amount.Properties.FieldName = "Emp_Att_Payment_Late_Amount"
        '
        'rowEmp_Att_Payment_Early_Amount
        '
        Me.rowEmp_Att_Payment_Early_Amount.Name = "rowEmp_Att_Payment_Early_Amount"
        Me.rowEmp_Att_Payment_Early_Amount.Properties.Caption = "Early Departure"
        Me.rowEmp_Att_Payment_Early_Amount.Properties.FieldName = "Emp_Att_Payment_Early_Amount"
        '
        'rowEmp_Att_Payment_OverTime_Amount
        '
        Me.rowEmp_Att_Payment_OverTime_Amount.Name = "rowEmp_Att_Payment_OverTime_Amount"
        Me.rowEmp_Att_Payment_OverTime_Amount.Properties.Caption = "Over Time"
        Me.rowEmp_Att_Payment_OverTime_Amount.Properties.FieldName = "Emp_Att_Payment_OverTime_Amount"
        '
        'rowEmp_Att_Payment_Private_Late_Amount
        '
        Me.rowEmp_Att_Payment_Private_Late_Amount.Name = "rowEmp_Att_Payment_Private_Late_Amount"
        Me.rowEmp_Att_Payment_Private_Late_Amount.Properties.Caption = "Private Late"
        Me.rowEmp_Att_Payment_Private_Late_Amount.Properties.FieldName = "Emp_Att_Payment_Private_Late_Amount"
        '
        'rowEmp_Att_Payment_Short_Amount
        '
        Me.rowEmp_Att_Payment_Short_Amount.Name = "rowEmp_Att_Payment_Short_Amount"
        Me.rowEmp_Att_Payment_Short_Amount.Properties.Caption = "Short Leave"
        Me.rowEmp_Att_Payment_Short_Amount.Properties.FieldName = "Emp_Att_Payment_Short_Amount"
        '
        'rowEmp_Att_Payment_Lunch_Late_Amount
        '
        Me.rowEmp_Att_Payment_Lunch_Late_Amount.Name = "rowEmp_Att_Payment_Lunch_Late_Amount"
        Me.rowEmp_Att_Payment_Lunch_Late_Amount.Properties.Caption = "Lunch Late"
        Me.rowEmp_Att_Payment_Lunch_Late_Amount.Properties.FieldName = "Emp_Att_Payment_Lunch_Late_Amount"
        '
        'rowEmp_Att_Payment_Lunch_OverTime_Amount
        '
        Me.rowEmp_Att_Payment_Lunch_OverTime_Amount.Name = "rowEmp_Att_Payment_Lunch_OverTime_Amount"
        Me.rowEmp_Att_Payment_Lunch_OverTime_Amount.Properties.Caption = "Lunch Over Time"
        Me.rowEmp_Att_Payment_Lunch_OverTime_Amount.Properties.FieldName = "Emp_Att_Payment_Lunch_OverTime_Amount"
        '
        'rowEmp_Att_Payment_Prayer_Late_Amount
        '
        Me.rowEmp_Att_Payment_Prayer_Late_Amount.Name = "rowEmp_Att_Payment_Prayer_Late_Amount"
        Me.rowEmp_Att_Payment_Prayer_Late_Amount.Properties.Caption = "Prayer Late"
        Me.rowEmp_Att_Payment_Prayer_Late_Amount.Properties.FieldName = "Emp_Att_Payment_Prayer_Late_Amount"
        '
        'rowEmp_Att_Payment_Fix
        '
        Me.rowEmp_Att_Payment_Fix.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.rowEmp_Att_Payment_Fix.Appearance.Options.UseFont = True
        Me.rowEmp_Att_Payment_Fix.Name = "rowEmp_Att_Payment_Fix"
        Me.rowEmp_Att_Payment_Fix.Properties.Caption = "Salary"
        Me.rowEmp_Att_Payment_Fix.Properties.FieldName = "Emp_Att_Payment_Fix"
        '
        'rowEmp_Att_Payment_Beg
        '
        Me.rowEmp_Att_Payment_Beg.Name = "rowEmp_Att_Payment_Beg"
        Me.rowEmp_Att_Payment_Beg.Properties.Caption = "Old Due"
        Me.rowEmp_Att_Payment_Beg.Properties.FieldName = "Emp_Att_Payment_Beg"
        '
        'rowEmp_Att_Payment_Advance
        '
        Me.rowEmp_Att_Payment_Advance.Name = "rowEmp_Att_Payment_Advance"
        Me.rowEmp_Att_Payment_Advance.Properties.Caption = "Advance"
        Me.rowEmp_Att_Payment_Advance.Properties.FieldName = "Emp_Att_Payment_Advance"
        '
        'rowEmp_Att_Payment_Fine
        '
        Me.rowEmp_Att_Payment_Fine.Name = "rowEmp_Att_Payment_Fine"
        Me.rowEmp_Att_Payment_Fine.Properties.Caption = "Fine"
        Me.rowEmp_Att_Payment_Fine.Properties.FieldName = "Emp_Att_Payment_Fine"
        '
        'rowEmp_Att_Payment_Bonus
        '
        Me.rowEmp_Att_Payment_Bonus.Name = "rowEmp_Att_Payment_Bonus"
        Me.rowEmp_Att_Payment_Bonus.Properties.Caption = "Bonus"
        Me.rowEmp_Att_Payment_Bonus.Properties.FieldName = "Emp_Att_Payment_Bonus"
        '
        'rowEmp_Att_Payment_Total
        '
        Me.rowEmp_Att_Payment_Total.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.rowEmp_Att_Payment_Total.Appearance.Options.UseFont = True
        Me.rowEmp_Att_Payment_Total.Name = "rowEmp_Att_Payment_Total"
        Me.rowEmp_Att_Payment_Total.Properties.Caption = "Total"
        Me.rowEmp_Att_Payment_Total.Properties.FieldName = "Emp_Att_Payment_Total"
        '
        'rowEmp_Att_Payment_Paid
        '
        Me.rowEmp_Att_Payment_Paid.Name = "rowEmp_Att_Payment_Paid"
        Me.rowEmp_Att_Payment_Paid.Properties.Caption = "Paid"
        Me.rowEmp_Att_Payment_Paid.Properties.FieldName = "Emp_Att_Payment_Paid"
        '
        'rowEmp_Att_Payment_Balance
        '
        Me.rowEmp_Att_Payment_Balance.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.rowEmp_Att_Payment_Balance.Appearance.Options.UseFont = True
        Me.rowEmp_Att_Payment_Balance.Name = "rowEmp_Att_Payment_Balance"
        Me.rowEmp_Att_Payment_Balance.Properties.Caption = "Balance"
        Me.rowEmp_Att_Payment_Balance.Properties.FieldName = "Emp_Att_Payment_Balance"
        '
        'frmProReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(863, 501)
        Me.Controls.Add(Me.VGridControl1)
        Me.Name = "frmProReports"
        Me.Text = "frmProReports"
        CType(Me.VGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents VGridControl1 As DevExpress.XtraVerticalGrid.VGridControl
    Friend WithEvents BindingSource1 As Windows.Forms.BindingSource
    Friend WithEvents rowEmp_Att_Payment_ID As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_ID As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Issue_Date As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_From_Date As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_To_Date As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Absent_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Late_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Early_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_OverTime_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Private_Late_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Short_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Lunch_Late_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Lunch_OverTime_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Prayer_Late_Amount As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Fix As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Beg As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Advance As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Fine As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Bonus As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Total As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Paid As DevExpress.XtraVerticalGrid.Rows.EditorRow
    Friend WithEvents rowEmp_Att_Payment_Balance As DevExpress.XtraVerticalGrid.Rows.EditorRow
End Class
