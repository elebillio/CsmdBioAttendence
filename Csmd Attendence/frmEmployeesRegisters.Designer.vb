<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEmployeesRegisters
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmployeesRegisters))
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem3 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem4 = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPageCategory1 = New DevExpress.XtraBars.Ribbon.RibbonPageCategory()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.AdvBandedGridView1 = New DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView()
        Me.GridBand1 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_ID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Emp_Reg = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Emp_Status = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand7 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand6 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_Image = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand2 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_Name = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Emp_Father = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand4 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_Nic_No = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Emp_Birth_Date = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand3 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_Phone = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Emp_Address = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand12 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_Quali = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Emp_Designation = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand10 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_DutyOn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
        Me.Emp_DutyOff = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.RepositoryItemTimeEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit()
        Me.gridBand11 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand5 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_Date_Hired = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.Emp_Date_Terminated = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.gridBand8 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.gridBand9 = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
        Me.Emp_Balance = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.User_ID = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTimeEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CsmdBioDatabase.Employee)
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.BarButtonItem1, Me.BarButtonItem2, Me.BarButtonItem3, Me.BarButtonItem4})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 5
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.PageCategories.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageCategory() {Me.RibbonPageCategory1})
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.Size = New System.Drawing.Size(1105, 143)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Edit"
        Me.BarButtonItem1.Glyph = CType(resources.GetObject("BarButtonItem1.Glyph"), System.Drawing.Image)
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.LargeGlyph = CType(resources.GetObject("BarButtonItem1.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Save"
        Me.BarButtonItem2.Glyph = CType(resources.GetObject("BarButtonItem2.Glyph"), System.Drawing.Image)
        Me.BarButtonItem2.Id = 2
        Me.BarButtonItem2.LargeGlyph = CType(resources.GetObject("BarButtonItem2.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem2.Name = "BarButtonItem2"
        '
        'BarButtonItem3
        '
        Me.BarButtonItem3.Caption = "Refresh"
        Me.BarButtonItem3.Glyph = CType(resources.GetObject("BarButtonItem3.Glyph"), System.Drawing.Image)
        Me.BarButtonItem3.Id = 3
        Me.BarButtonItem3.LargeGlyph = CType(resources.GetObject("BarButtonItem3.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem3.Name = "BarButtonItem3"
        '
        'BarButtonItem4
        '
        Me.BarButtonItem4.Caption = "Print Preview"
        Me.BarButtonItem4.Glyph = CType(resources.GetObject("BarButtonItem4.Glyph"), System.Drawing.Image)
        Me.BarButtonItem4.Id = 4
        Me.BarButtonItem4.LargeGlyph = CType(resources.GetObject("BarButtonItem4.LargeGlyph"), System.Drawing.Image)
        Me.BarButtonItem4.Name = "BarButtonItem4"
        '
        'RibbonPageCategory1
        '
        Me.RibbonPageCategory1.Name = "RibbonPageCategory1"
        Me.RibbonPageCategory1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonPageCategory1.Text = "Employees Register"
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        Me.RibbonPage1.Text = "Controls"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.AllowTextClipping = False
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem2, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem3, True)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem4, True)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.ShowCaptionButton = False
        Me.RibbonPageGroup1.Text = "Register Control"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridControl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 143)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1105, 294)
        Me.LayoutControl1.TabIndex = 6
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridControl1
        '
        Me.GridControl1.DataSource = Me.BindingSource1
        Me.GridControl1.Location = New System.Drawing.Point(12, 12)
        Me.GridControl1.MainView = Me.AdvBandedGridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTimeEdit1, Me.RepositoryItemTimeEdit2})
        Me.GridControl1.Size = New System.Drawing.Size(1081, 270)
        Me.GridControl1.TabIndex = 8
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.AdvBandedGridView1})
        '
        'AdvBandedGridView1
        '
        Me.AdvBandedGridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.AdvBandedGridView1.Appearance.HeaderPanel.Options.UseFont = True
        Me.AdvBandedGridView1.Appearance.Row.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.AdvBandedGridView1.Appearance.Row.Options.UseFont = True
        Me.AdvBandedGridView1.Bands.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.GridBand() {Me.GridBand1, Me.gridBand7, Me.gridBand6, Me.gridBand2, Me.gridBand4, Me.gridBand3, Me.gridBand12, Me.gridBand10, Me.gridBand11, Me.gridBand5, Me.gridBand8, Me.gridBand9})
        Me.AdvBandedGridView1.Columns.AddRange(New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn() {Me.Emp_ID, Me.Emp_Status, Me.Emp_Reg, Me.Emp_Name, Me.Emp_Image, Me.Emp_Father, Me.Emp_Nic_No, Me.Emp_Phone, Me.Emp_Address, Me.Emp_Quali, Me.Emp_Designation, Me.Emp_Date_Hired, Me.Emp_Date_Terminated, Me.Emp_Balance, Me.User_ID, Me.Emp_DutyOn, Me.Emp_DutyOff, Me.Emp_Birth_Date})
        Me.AdvBandedGridView1.CustomizationFormBounds = New System.Drawing.Rectangle(797, 336, 222, 261)
        Me.AdvBandedGridView1.GridControl = Me.GridControl1
        Me.AdvBandedGridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Emp_Status", Nothing, "(Status: Count={0})")})
        Me.AdvBandedGridView1.Name = "AdvBandedGridView1"
        Me.AdvBandedGridView1.OptionsBehavior.Editable = False
        Me.AdvBandedGridView1.OptionsSelection.InvertSelection = True
        Me.AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
        Me.AdvBandedGridView1.OptionsView.EnableAppearanceEvenRow = True
        Me.AdvBandedGridView1.OptionsView.EnableAppearanceOddRow = True
        Me.AdvBandedGridView1.OptionsView.ShowBands = False
        Me.AdvBandedGridView1.OptionsView.ShowGroupPanel = False
        Me.AdvBandedGridView1.RowHeight = 50
        Me.AdvBandedGridView1.RowSeparatorHeight = 10
        '
        'GridBand1
        '
        Me.GridBand1.Columns.Add(Me.Emp_ID)
        Me.GridBand1.Columns.Add(Me.Emp_Reg)
        Me.GridBand1.Columns.Add(Me.Emp_Status)
        Me.GridBand1.Name = "GridBand1"
        Me.GridBand1.VisibleIndex = 0
        Me.GridBand1.Width = 65
        '
        'Emp_ID
        '
        Me.Emp_ID.Caption = "ID"
        Me.Emp_ID.FieldName = "Emp_ID"
        Me.Emp_ID.Name = "Emp_ID"
        Me.Emp_ID.Width = 88
        '
        'Emp_Reg
        '
        Me.Emp_Reg.Caption = "Reg#"
        Me.Emp_Reg.FieldName = "Emp_Reg"
        Me.Emp_Reg.Name = "Emp_Reg"
        Me.Emp_Reg.Visible = True
        Me.Emp_Reg.Width = 65
        '
        'Emp_Status
        '
        Me.Emp_Status.Caption = "Status"
        Me.Emp_Status.FieldName = "Emp_Status"
        Me.Emp_Status.Name = "Emp_Status"
        Me.Emp_Status.RowIndex = 1
        Me.Emp_Status.Visible = True
        Me.Emp_Status.Width = 65
        '
        'gridBand7
        '
        Me.gridBand7.Name = "gridBand7"
        Me.gridBand7.Visible = False
        Me.gridBand7.VisibleIndex = -1
        Me.gridBand7.Width = 65
        '
        'gridBand6
        '
        Me.gridBand6.Columns.Add(Me.Emp_Image)
        Me.gridBand6.Name = "gridBand6"
        Me.gridBand6.VisibleIndex = 1
        Me.gridBand6.Width = 63
        '
        'Emp_Image
        '
        Me.Emp_Image.AutoFillDown = True
        Me.Emp_Image.Caption = "Image"
        Me.Emp_Image.FieldName = "Emp_Image"
        Me.Emp_Image.Name = "Emp_Image"
        Me.Emp_Image.Visible = True
        Me.Emp_Image.Width = 63
        '
        'gridBand2
        '
        Me.gridBand2.Columns.Add(Me.Emp_Name)
        Me.gridBand2.Columns.Add(Me.Emp_Father)
        Me.gridBand2.Name = "gridBand2"
        Me.gridBand2.VisibleIndex = 2
        Me.gridBand2.Width = 187
        '
        'Emp_Name
        '
        Me.Emp_Name.Caption = "Name"
        Me.Emp_Name.FieldName = "Emp_Name"
        Me.Emp_Name.Name = "Emp_Name"
        Me.Emp_Name.Visible = True
        Me.Emp_Name.Width = 187
        '
        'Emp_Father
        '
        Me.Emp_Father.Caption = "Father"
        Me.Emp_Father.FieldName = "Emp_Father"
        Me.Emp_Father.Name = "Emp_Father"
        Me.Emp_Father.RowIndex = 1
        Me.Emp_Father.Visible = True
        Me.Emp_Father.Width = 187
        '
        'gridBand4
        '
        Me.gridBand4.Columns.Add(Me.Emp_Nic_No)
        Me.gridBand4.Columns.Add(Me.Emp_Birth_Date)
        Me.gridBand4.Name = "gridBand4"
        Me.gridBand4.VisibleIndex = 3
        Me.gridBand4.Width = 150
        '
        'Emp_Nic_No
        '
        Me.Emp_Nic_No.AutoFillDown = True
        Me.Emp_Nic_No.Caption = "Nic"
        Me.Emp_Nic_No.FieldName = "Emp_Nic_No"
        Me.Emp_Nic_No.Name = "Emp_Nic_No"
        Me.Emp_Nic_No.Visible = True
        Me.Emp_Nic_No.Width = 150
        '
        'Emp_Birth_Date
        '
        Me.Emp_Birth_Date.Caption = "D.O.B"
        Me.Emp_Birth_Date.FieldName = "Emp_Birth_Date"
        Me.Emp_Birth_Date.Name = "Emp_Birth_Date"
        Me.Emp_Birth_Date.RowIndex = 1
        Me.Emp_Birth_Date.Visible = True
        Me.Emp_Birth_Date.Width = 150
        '
        'gridBand3
        '
        Me.gridBand3.Columns.Add(Me.Emp_Phone)
        Me.gridBand3.Columns.Add(Me.Emp_Address)
        Me.gridBand3.Name = "gridBand3"
        Me.gridBand3.VisibleIndex = 4
        Me.gridBand3.Width = 108
        '
        'Emp_Phone
        '
        Me.Emp_Phone.Caption = "Phone"
        Me.Emp_Phone.FieldName = "Emp_Phone"
        Me.Emp_Phone.Name = "Emp_Phone"
        Me.Emp_Phone.Visible = True
        Me.Emp_Phone.Width = 108
        '
        'Emp_Address
        '
        Me.Emp_Address.Caption = "Address"
        Me.Emp_Address.FieldName = "Emp_Address"
        Me.Emp_Address.Name = "Emp_Address"
        Me.Emp_Address.RowIndex = 1
        Me.Emp_Address.Visible = True
        Me.Emp_Address.Width = 108
        '
        'gridBand12
        '
        Me.gridBand12.Caption = "gridBand12"
        Me.gridBand12.Columns.Add(Me.Emp_Quali)
        Me.gridBand12.Columns.Add(Me.Emp_Designation)
        Me.gridBand12.Name = "gridBand12"
        Me.gridBand12.VisibleIndex = 5
        Me.gridBand12.Width = 113
        '
        'Emp_Quali
        '
        Me.Emp_Quali.Caption = "Quali"
        Me.Emp_Quali.FieldName = "Emp_Quali"
        Me.Emp_Quali.Name = "Emp_Quali"
        Me.Emp_Quali.Visible = True
        Me.Emp_Quali.Width = 113
        '
        'Emp_Designation
        '
        Me.Emp_Designation.Caption = "Designation"
        Me.Emp_Designation.FieldName = "Emp_Designation"
        Me.Emp_Designation.Name = "Emp_Designation"
        Me.Emp_Designation.RowIndex = 1
        Me.Emp_Designation.Visible = True
        Me.Emp_Designation.Width = 113
        '
        'gridBand10
        '
        Me.gridBand10.Caption = "gridBand10"
        Me.gridBand10.Columns.Add(Me.Emp_DutyOn)
        Me.gridBand10.Columns.Add(Me.Emp_DutyOff)
        Me.gridBand10.Name = "gridBand10"
        Me.gridBand10.VisibleIndex = 6
        Me.gridBand10.Width = 176
        '
        'Emp_DutyOn
        '
        Me.Emp_DutyOn.AutoFillDown = True
        Me.Emp_DutyOn.Caption = "DutyOn"
        Me.Emp_DutyOn.ColumnEdit = Me.RepositoryItemTimeEdit1
        Me.Emp_DutyOn.DisplayFormat.FormatString = "HH:mm"
        Me.Emp_DutyOn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Emp_DutyOn.FieldName = "Emp_DutyOn"
        Me.Emp_DutyOn.GroupFormat.FormatString = "t"
        Me.Emp_DutyOn.GroupFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Emp_DutyOn.Name = "Emp_DutyOn"
        Me.Emp_DutyOn.Visible = True
        Me.Emp_DutyOn.Width = 87
        '
        'RepositoryItemTimeEdit1
        '
        Me.RepositoryItemTimeEdit1.AutoHeight = False
        Me.RepositoryItemTimeEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeEdit1.DisplayFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit1.EditFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit1.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeEdit1.Name = "RepositoryItemTimeEdit1"
        Me.RepositoryItemTimeEdit1.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI
        '
        'Emp_DutyOff
        '
        Me.Emp_DutyOff.AutoFillDown = True
        Me.Emp_DutyOff.Caption = "DutyOff"
        Me.Emp_DutyOff.ColumnEdit = Me.RepositoryItemTimeEdit2
        Me.Emp_DutyOff.DisplayFormat.FormatString = "HH:mm"
        Me.Emp_DutyOff.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Emp_DutyOff.FieldName = "Emp_Duty_Off"
        Me.Emp_DutyOff.Name = "Emp_DutyOff"
        Me.Emp_DutyOff.Visible = True
        Me.Emp_DutyOff.Width = 89
        '
        'RepositoryItemTimeEdit2
        '
        Me.RepositoryItemTimeEdit2.AutoHeight = False
        Me.RepositoryItemTimeEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemTimeEdit2.DisplayFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit2.EditFormat.FormatString = "HH:mm"
        Me.RepositoryItemTimeEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.RepositoryItemTimeEdit2.Mask.EditMask = "HH:mm"
        Me.RepositoryItemTimeEdit2.Name = "RepositoryItemTimeEdit2"
        Me.RepositoryItemTimeEdit2.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI
        '
        'gridBand11
        '
        Me.gridBand11.Caption = "gridBand11"
        Me.gridBand11.Name = "gridBand11"
        Me.gridBand11.Visible = False
        Me.gridBand11.VisibleIndex = -1
        Me.gridBand11.Width = 105
        '
        'gridBand5
        '
        Me.gridBand5.Columns.Add(Me.Emp_Date_Hired)
        Me.gridBand5.Columns.Add(Me.Emp_Date_Terminated)
        Me.gridBand5.Name = "gridBand5"
        Me.gridBand5.VisibleIndex = 7
        Me.gridBand5.Width = 131
        '
        'Emp_Date_Hired
        '
        Me.Emp_Date_Hired.Caption = "Added Date"
        Me.Emp_Date_Hired.FieldName = "Emp_Date_Hired"
        Me.Emp_Date_Hired.Name = "Emp_Date_Hired"
        Me.Emp_Date_Hired.Visible = True
        Me.Emp_Date_Hired.Width = 131
        '
        'Emp_Date_Terminated
        '
        Me.Emp_Date_Terminated.Caption = "Terminated Date"
        Me.Emp_Date_Terminated.FieldName = "Emp_Date_Terminated"
        Me.Emp_Date_Terminated.Name = "Emp_Date_Terminated"
        Me.Emp_Date_Terminated.RowIndex = 1
        Me.Emp_Date_Terminated.Visible = True
        Me.Emp_Date_Terminated.Width = 131
        '
        'gridBand8
        '
        Me.gridBand8.Name = "gridBand8"
        Me.gridBand8.Visible = False
        Me.gridBand8.VisibleIndex = -1
        Me.gridBand8.Width = 77
        '
        'gridBand9
        '
        Me.gridBand9.Columns.Add(Me.Emp_Balance)
        Me.gridBand9.Columns.Add(Me.User_ID)
        Me.gridBand9.Name = "gridBand9"
        Me.gridBand9.VisibleIndex = 8
        Me.gridBand9.Width = 82
        '
        'Emp_Balance
        '
        Me.Emp_Balance.Caption = "Salary"
        Me.Emp_Balance.FieldName = "Emp_Salary"
        Me.Emp_Balance.Name = "Emp_Balance"
        Me.Emp_Balance.Visible = True
        Me.Emp_Balance.Width = 82
        '
        'User_ID
        '
        Me.User_ID.Caption = "User"
        Me.User_ID.FieldName = "Plaza_User.User_Name"
        Me.User_ID.Name = "User_ID"
        Me.User_ID.RowIndex = 1
        Me.User_ID.Visible = True
        Me.User_ID.Width = 82
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1105, 294)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridControl1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1085, 274)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'frmEmployeesRegisters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1105, 437)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Name = "frmEmployeesRegisters"
        Me.Ribbon = Me.RibbonControl1
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvBandedGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTimeEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents AdvBandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView
    Friend WithEvents GridBand1 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_ID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Emp_Reg As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Emp_Status As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand7 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand6 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_Image As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand2 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_Name As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Emp_Father As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand4 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_Nic_No As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Emp_Birth_Date As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand3 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_Phone As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Emp_Address As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand12 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_Quali As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Emp_Designation As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand10 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_DutyOn As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit
    Friend WithEvents Emp_DutyOff As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents RepositoryItemTimeEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit
    Friend WithEvents gridBand11 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand5 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_Date_Hired As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents Emp_Date_Terminated As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents gridBand8 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents gridBand9 As DevExpress.XtraGrid.Views.BandedGrid.GridBand
    Friend WithEvents Emp_Balance As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents User_ID As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem3 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem4 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageCategory1 As DevExpress.XtraBars.Ribbon.RibbonPageCategory

End Class
