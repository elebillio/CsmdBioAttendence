Imports CsmdBioDatabase

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Public Class XtraReport1
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim EfConnectionParameters1 As DevExpress.DataAccess.EntityFramework.EFConnectionParameters = New DevExpress.DataAccess.EntityFramework.EFConnectionParameters()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XtraReport1))
        Dim DynamicListLookUpSettings1 As DevExpress.XtraReports.Parameters.DynamicListLookUpSettings = New DevExpress.XtraReports.Parameters.DynamicListLookUpSettings()
        Me.EfDataSource1 = New DevExpress.DataAccess.EntityFramework.EFDataSource(Me.components)
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable18 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow18 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell25 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell94 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable27 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow27 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell95 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell97 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell98 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell99 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable28 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow28 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell100 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell102 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell103 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell104 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable29 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow29 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell105 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell107 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell108 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell109 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable30 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow30 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell110 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell112 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell113 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell114 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable31 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow31 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell115 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell117 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell118 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell119 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable32 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow32 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell120 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell122 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell123 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell124 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable3 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable4 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow4 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell8 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell10 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrPictureBox2 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell6 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable8 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow8 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell23 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell24 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell26 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell27 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable9 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow9 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell28 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell29 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell31 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell32 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable5 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow5 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell11 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell12 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell13 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell14 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell15 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable10 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow10 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell36 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell37 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell38 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell39 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell40 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable11 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow11 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell41 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell42 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell43 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell44 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell45 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable12 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow12 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell46 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell47 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell48 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell49 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell50 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable13 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow13 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell51 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell52 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell53 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell54 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell55 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable14 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow14 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell56 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell57 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell58 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell59 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell60 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable15 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow15 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell61 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell62 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell63 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell64 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell65 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable16 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow16 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell66 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell67 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell68 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell69 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell70 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable17 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow17 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell71 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell72 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell73 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell74 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell75 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable19 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow19 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell77 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell78 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable20 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow20 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell79 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell81 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable21 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow21 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell82 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell83 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable22 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow22 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell84 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell85 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable23 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow23 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell86 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell87 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable24 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow24 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell88 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell89 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable25 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow25 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell90 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell91 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTable26 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow26 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell92 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell93 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrPictureBox1 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.Parameter1 = New DevExpress.XtraReports.Parameters.Parameter()
        CType(Me.EfDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'EfDataSource1
        '
        EfConnectionParameters1.ConnectionString = ""
        EfConnectionParameters1.ConnectionStringName = "CsmdBioAttendenceEntities"
        EfConnectionParameters1.Source = GetType(CsmdBioDatabase.CsmdBioAttendenceEntities)
        Me.EfDataSource1.ConnectionParameters = EfConnectionParameters1
        Me.EfDataSource1.Name = "EfDataSource1"
        '
        'Detail
        '
        Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable18, Me.XrTable27, Me.XrTable28, Me.XrTable29, Me.XrTable30, Me.XrTable31, Me.XrTable32, Me.XrTable1, Me.XrTable3, Me.XrTable4, Me.XrTable2, Me.XrTable8, Me.XrTable9, Me.XrTable5, Me.XrTable10, Me.XrTable11, Me.XrTable12, Me.XrTable13, Me.XrTable14, Me.XrTable15, Me.XrTable16, Me.XrTable17, Me.XrTable19, Me.XrTable20, Me.XrTable21, Me.XrTable22, Me.XrTable23, Me.XrTable24, Me.XrTable25, Me.XrTable26, Me.XrPictureBox1})
        Me.Detail.HeightF = 958.3333!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'XrTable18
        '
        Me.XrTable18.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable18.LocationFloat = New DevExpress.Utils.PointFloat(9.999973!, 469.6667!)
        Me.XrTable18.Name = "XrTable18"
        Me.XrTable18.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow18})
        Me.XrTable18.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable18.StylePriority.UseFont = False
        Me.XrTable18.StylePriority.UseTextAlignment = False
        Me.XrTable18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow18
        '
        Me.XrTableRow18.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell25, Me.XrTableCell94})
        Me.XrTableRow18.Name = "XrTableRow18"
        Me.XrTableRow18.Weight = 1.0R
        '
        'XrTableCell25
        '
        Me.XrTableCell25.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell25.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell25.Name = "XrTableCell25"
        Me.XrTableCell25.StylePriority.UseBackColor = False
        Me.XrTableCell25.StylePriority.UseFont = False
        Me.XrTableCell25.StylePriority.UseTextAlignment = False
        Me.XrTableCell25.Text = "Salary Total:"
        Me.XrTableCell25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell25.Weight = 3.5989050554875091R
        Me.XrTableCell25.WordWrap = False
        '
        'XrTableCell94
        '
        Me.XrTableCell94.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTableCell94.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Salaray_Total")})
        Me.XrTableCell94.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell94.Name = "XrTableCell94"
        Me.XrTableCell94.StylePriority.UseBackColor = False
        Me.XrTableCell94.StylePriority.UseFont = False
        Me.XrTableCell94.StylePriority.UseTextAlignment = False
        Me.XrTableCell94.Text = "Amount"
        Me.XrTableCell94.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell94.Weight = 1.0796649367337792R
        '
        'XrTable27
        '
        Me.XrTable27.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable27.LocationFloat = New DevExpress.Utils.PointFloat(9.999973!, 444.6667!)
        Me.XrTable27.Name = "XrTable27"
        Me.XrTable27.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow27})
        Me.XrTable27.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable27.StylePriority.UseFont = False
        Me.XrTable27.StylePriority.UseTextAlignment = False
        Me.XrTable27.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow27
        '
        Me.XrTableRow27.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell95, Me.XrTableCell97, Me.XrTableCell98, Me.XrTableCell99})
        Me.XrTableRow27.Name = "XrTableRow27"
        Me.XrTableRow27.Weight = 1.0R
        '
        'XrTableCell95
        '
        Me.XrTableCell95.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell95.Name = "XrTableCell95"
        Me.XrTableCell95.StylePriority.UseFont = False
        Me.XrTableCell95.StylePriority.UseTextAlignment = False
        Me.XrTableCell95.Text = "Extra Days"
        Me.XrTableCell95.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell95.Weight = 2.1799497993260686R
        Me.XrTableCell95.WordWrap = False
        '
        'XrTableCell97
        '
        Me.XrTableCell97.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_ExtraDays")})
        Me.XrTableCell97.Name = "XrTableCell97"
        Me.XrTableCell97.Text = "Hours"
        Me.XrTableCell97.Weight = 0.699171853682435R
        '
        'XrTableCell98
        '
        Me.XrTableCell98.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_DayRate")})
        Me.XrTableCell98.Name = "XrTableCell98"
        Me.XrTableCell98.Text = "Rate"
        Me.XrTableCell98.Weight = 0.71978045030056359R
        '
        'XrTableCell99
        '
        Me.XrTableCell99.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_ExtraDays_Amount")})
        Me.XrTableCell99.Name = "XrTableCell99"
        Me.XrTableCell99.StylePriority.UseTextAlignment = False
        Me.XrTableCell99.Text = "Amount"
        Me.XrTableCell99.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell99.Weight = 1.0796678889122209R
        '
        'XrTable28
        '
        Me.XrTable28.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable28.LocationFloat = New DevExpress.Utils.PointFloat(9.999973!, 419.6667!)
        Me.XrTable28.Name = "XrTable28"
        Me.XrTable28.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow28})
        Me.XrTable28.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable28.StylePriority.UseFont = False
        Me.XrTable28.StylePriority.UseTextAlignment = False
        Me.XrTable28.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow28
        '
        Me.XrTableRow28.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell100, Me.XrTableCell102, Me.XrTableCell103, Me.XrTableCell104})
        Me.XrTableRow28.Name = "XrTableRow28"
        Me.XrTableRow28.Weight = 1.0R
        '
        'XrTableCell100
        '
        Me.XrTableCell100.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell100.Name = "XrTableCell100"
        Me.XrTableCell100.StylePriority.UseFont = False
        Me.XrTableCell100.StylePriority.UseTextAlignment = False
        Me.XrTableCell100.Text = "InOut Days"
        Me.XrTableCell100.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell100.Weight = 2.1799492501770588R
        Me.XrTableCell100.WordWrap = False
        '
        'XrTableCell102
        '
        Me.XrTableCell102.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_InOutDays")})
        Me.XrTableCell102.Name = "XrTableCell102"
        Me.XrTableCell102.Text = "Hours"
        Me.XrTableCell102.Weight = 0.69917240283144477R
        '
        'XrTableCell103
        '
        Me.XrTableCell103.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_DayRate")})
        Me.XrTableCell103.Name = "XrTableCell103"
        Me.XrTableCell103.Text = "Rate"
        Me.XrTableCell103.Weight = 0.71978045030056359R
        '
        'XrTableCell104
        '
        Me.XrTableCell104.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_InOutDays_Amount")})
        Me.XrTableCell104.Name = "XrTableCell104"
        Me.XrTableCell104.StylePriority.UseTextAlignment = False
        Me.XrTableCell104.Text = "Amount"
        Me.XrTableCell104.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell104.Weight = 1.0796678889122209R
        '
        'XrTable29
        '
        Me.XrTable29.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable29.LocationFloat = New DevExpress.Utils.PointFloat(9.999973!, 394.6666!)
        Me.XrTable29.Name = "XrTable29"
        Me.XrTable29.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow29})
        Me.XrTable29.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable29.StylePriority.UseFont = False
        Me.XrTable29.StylePriority.UseTextAlignment = False
        Me.XrTable29.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow29
        '
        Me.XrTableRow29.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell105, Me.XrTableCell107, Me.XrTableCell108, Me.XrTableCell109})
        Me.XrTableRow29.Name = "XrTableRow29"
        Me.XrTableRow29.Weight = 1.0R
        '
        'XrTableCell105
        '
        Me.XrTableCell105.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell105.Name = "XrTableCell105"
        Me.XrTableCell105.StylePriority.UseFont = False
        Me.XrTableCell105.StylePriority.UseTextAlignment = False
        Me.XrTableCell105.Text = "Off Days"
        Me.XrTableCell105.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell105.Weight = 2.1799484264535445R
        Me.XrTableCell105.WordWrap = False
        '
        'XrTableCell107
        '
        Me.XrTableCell107.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_OffDays")})
        Me.XrTableCell107.Name = "XrTableCell107"
        Me.XrTableCell107.Text = "Hours"
        Me.XrTableCell107.Weight = 0.69917322655495961R
        '
        'XrTableCell108
        '
        Me.XrTableCell108.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_DayRate")})
        Me.XrTableCell108.Name = "XrTableCell108"
        Me.XrTableCell108.Text = "Rate"
        Me.XrTableCell108.Weight = 0.71978045030056359R
        '
        'XrTableCell109
        '
        Me.XrTableCell109.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_OffDays_Amount")})
        Me.XrTableCell109.Name = "XrTableCell109"
        Me.XrTableCell109.StylePriority.UseTextAlignment = False
        Me.XrTableCell109.Text = "Amount"
        Me.XrTableCell109.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell109.Weight = 1.0796678889122209R
        '
        'XrTable30
        '
        Me.XrTable30.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable30.LocationFloat = New DevExpress.Utils.PointFloat(9.999973!, 369.6666!)
        Me.XrTable30.Name = "XrTable30"
        Me.XrTable30.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow30})
        Me.XrTable30.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable30.StylePriority.UseFont = False
        Me.XrTable30.StylePriority.UseTextAlignment = False
        Me.XrTable30.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow30
        '
        Me.XrTableRow30.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell110, Me.XrTableCell112, Me.XrTableCell113, Me.XrTableCell114})
        Me.XrTableRow30.Name = "XrTableRow30"
        Me.XrTableRow30.Weight = 1.0R
        '
        'XrTableCell110
        '
        Me.XrTableCell110.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell110.Name = "XrTableCell110"
        Me.XrTableCell110.StylePriority.UseFont = False
        Me.XrTableCell110.StylePriority.UseTextAlignment = False
        Me.XrTableCell110.Text = "Absentees"
        Me.XrTableCell110.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell110.Weight = 2.1799487010280489R
        Me.XrTableCell110.WordWrap = False
        '
        'XrTableCell112
        '
        Me.XrTableCell112.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Absent_D")})
        Me.XrTableCell112.Name = "XrTableCell112"
        Me.XrTableCell112.Text = "Hours"
        Me.XrTableCell112.Weight = 0.69917295198045459R
        '
        'XrTableCell113
        '
        Me.XrTableCell113.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_DayRate")})
        Me.XrTableCell113.Name = "XrTableCell113"
        Me.XrTableCell113.Text = "Rate"
        Me.XrTableCell113.Weight = 0.71978045030056359R
        '
        'XrTableCell114
        '
        Me.XrTableCell114.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Absent_Amount")})
        Me.XrTableCell114.Name = "XrTableCell114"
        Me.XrTableCell114.StylePriority.UseTextAlignment = False
        Me.XrTableCell114.Text = "Amount"
        Me.XrTableCell114.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell114.Weight = 1.0796678889122209R
        '
        'XrTable31
        '
        Me.XrTable31.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable31.LocationFloat = New DevExpress.Utils.PointFloat(9.999973!, 344.6666!)
        Me.XrTable31.Name = "XrTable31"
        Me.XrTable31.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow31})
        Me.XrTable31.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable31.StylePriority.UseFont = False
        Me.XrTable31.StylePriority.UseTextAlignment = False
        Me.XrTable31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow31
        '
        Me.XrTableRow31.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell115, Me.XrTableCell117, Me.XrTableCell118, Me.XrTableCell119})
        Me.XrTableRow31.Name = "XrTableRow31"
        Me.XrTableRow31.Weight = 1.0R
        '
        'XrTableCell115
        '
        Me.XrTableCell115.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell115.Name = "XrTableCell115"
        Me.XrTableCell115.StylePriority.UseFont = False
        Me.XrTableCell115.StylePriority.UseTextAlignment = False
        Me.XrTableCell115.Text = "Salary Days"
        Me.XrTableCell115.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell115.Weight = 2.1593440810293547R
        Me.XrTableCell115.WordWrap = False
        '
        'XrTableCell117
        '
        Me.XrTableCell117.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_Salaray_Days")})
        Me.XrTableCell117.Name = "XrTableCell117"
        Me.XrTableCell117.Text = "Hours"
        Me.XrTableCell117.Weight = 0.71977757197914882R
        '
        'XrTableCell118
        '
        Me.XrTableCell118.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_DayRate")})
        Me.XrTableCell118.Name = "XrTableCell118"
        Me.XrTableCell118.Text = "Rate"
        Me.XrTableCell118.Weight = 0.71978045030056359R
        '
        'XrTableCell119
        '
        Me.XrTableCell119.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Fix")})
        Me.XrTableCell119.Name = "XrTableCell119"
        Me.XrTableCell119.StylePriority.UseTextAlignment = False
        Me.XrTableCell119.Text = "Amount"
        Me.XrTableCell119.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell119.Weight = 1.0796678889122209R
        '
        'XrTable32
        '
        Me.XrTable32.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTable32.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTable32.LocationFloat = New DevExpress.Utils.PointFloat(9.999973!, 319.6667!)
        Me.XrTable32.Name = "XrTable32"
        Me.XrTable32.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow32})
        Me.XrTable32.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable32.StylePriority.UseBackColor = False
        Me.XrTable32.StylePriority.UseFont = False
        Me.XrTable32.StylePriority.UseTextAlignment = False
        Me.XrTable32.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow32
        '
        Me.XrTableRow32.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell120, Me.XrTableCell122, Me.XrTableCell123, Me.XrTableCell124})
        Me.XrTableRow32.Name = "XrTableRow32"
        Me.XrTableRow32.Weight = 1.0R
        '
        'XrTableCell120
        '
        Me.XrTableCell120.Name = "XrTableCell120"
        Me.XrTableCell120.Text = "Description"
        Me.XrTableCell120.Weight = 1.4395608137334155R
        '
        'XrTableCell122
        '
        Me.XrTableCell122.Name = "XrTableCell122"
        Me.XrTableCell122.Text = "Days"
        Me.XrTableCell122.Weight = 1.4395608392750883R
        '
        'XrTableCell123
        '
        Me.XrTableCell123.Name = "XrTableCell123"
        Me.XrTableCell123.Text = "Rate"
        Me.XrTableCell123.Weight = 0.71978045030056359R
        '
        'XrTableCell124
        '
        Me.XrTableCell124.Name = "XrTableCell124"
        Me.XrTableCell124.Text = "Amount"
        Me.XrTableCell124.Weight = 1.0796678889122209R
        '
        'XrTable1
        '
        Me.XrTable1.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTable1.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 209.6666!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(260.0!, 25.0!)
        Me.XrTable1.StylePriority.UseBackColor = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell2, Me.XrTableCell3})
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.Text = "Issue Date"
        Me.XrTableCell1.Weight = 1.0R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.Text = "Duty From"
        Me.XrTableCell2.Weight = 1.0R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.Text = "Duty To"
        Me.XrTableCell3.Weight = 0.89285666407376274R
        '
        'XrTable3
        '
        Me.XrTable3.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTable3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable3.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 113.1667!)
        Me.XrTable3.Name = "XrTable3"
        Me.XrTable3.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow3})
        Me.XrTable3.SizeF = New System.Drawing.SizeF(260.0!, 25.0!)
        Me.XrTable3.StylePriority.UseBackColor = False
        Me.XrTable3.StylePriority.UseFont = False
        Me.XrTable3.StylePriority.UseTextAlignment = False
        Me.XrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow3
        '
        Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell7, Me.XrTableCell9})
        Me.XrTableRow3.Name = "XrTableRow3"
        Me.XrTableRow3.Weight = 1.0R
        '
        'XrTableCell7
        '
        Me.XrTableCell7.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTableCell7.Name = "XrTableCell7"
        Me.XrTableCell7.StylePriority.UseFont = False
        Me.XrTableCell7.Text = "Name of Employees"
        Me.XrTableCell7.Weight = 2.0769231261817245R
        '
        'XrTableCell9
        '
        Me.XrTableCell9.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTableCell9.Name = "XrTableCell9"
        Me.XrTableCell9.StylePriority.UseFont = False
        Me.XrTableCell9.Text = "Image"
        Me.XrTableCell9.Weight = 0.92719690313153835R
        '
        'XrTable4
        '
        Me.XrTable4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable4.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 138.1667!)
        Me.XrTable4.Name = "XrTable4"
        Me.XrTable4.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow4})
        Me.XrTable4.SizeF = New System.Drawing.SizeF(260.0!, 67.5!)
        Me.XrTable4.StylePriority.UseFont = False
        Me.XrTable4.StylePriority.UseTextAlignment = False
        Me.XrTable4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow4
        '
        Me.XrTableRow4.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell8, Me.XrTableCell10})
        Me.XrTableRow4.Name = "XrTableRow4"
        Me.XrTableRow4.Weight = 1.0R
        '
        'XrTableCell8
        '
        Me.XrTableCell8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Employee.Emp_Name")})
        Me.XrTableCell8.Name = "XrTableCell8"
        Me.XrTableCell8.Weight = 2.0769231261817245R
        '
        'XrTableCell10
        '
        Me.XrTableCell10.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBox2})
        Me.XrTableCell10.Name = "XrTableCell10"
        Me.XrTableCell10.Weight = 0.92719690313153835R
        '
        'XrPictureBox2
        '
        Me.XrPictureBox2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Image", Nothing, "Emp_Att_Payment.Employee.Emp_Image")})
        Me.XrPictureBox2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrPictureBox2.Name = "XrPictureBox2"
        Me.XrPictureBox2.SizeF = New System.Drawing.SizeF(80.24649!, 67.5!)
        Me.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'XrTable2
        '
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 234.6667!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(260.0!, 25.0!)
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell4, Me.XrTableCell5, Me.XrTableCell6})
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Issue_Date", "{0:dd/MM/yyyy}")})
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.Weight = 1.0R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_From_Date", "{0:dd/MM/yyyy}")})
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.Weight = 1.0R
        '
        'XrTableCell6
        '
        Me.XrTableCell6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_To_Date", "{0:dd/MM/yyyy}")})
        Me.XrTableCell6.Name = "XrTableCell6"
        Me.XrTableCell6.Weight = 0.89285666407376274R
        '
        'XrTable8
        '
        Me.XrTable8.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTable8.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTable8.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 264.6667!)
        Me.XrTable8.Name = "XrTable8"
        Me.XrTable8.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow8})
        Me.XrTable8.SizeF = New System.Drawing.SizeF(260.0!, 25.0!)
        Me.XrTable8.StylePriority.UseBackColor = False
        Me.XrTable8.StylePriority.UseFont = False
        Me.XrTable8.StylePriority.UseTextAlignment = False
        Me.XrTable8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow8
        '
        Me.XrTableRow8.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell23, Me.XrTableCell24, Me.XrTableCell26, Me.XrTableCell27})
        Me.XrTableRow8.Name = "XrTableRow8"
        Me.XrTableRow8.Weight = 1.0R
        '
        'XrTableCell23
        '
        Me.XrTableCell23.Name = "XrTableCell23"
        Me.XrTableCell23.Text = "On"
        Me.XrTableCell23.Weight = 1.0R
        '
        'XrTableCell24
        '
        Me.XrTableCell24.Name = "XrTableCell24"
        Me.XrTableCell24.Text = "Off"
        Me.XrTableCell24.Weight = 1.0R
        '
        'XrTableCell26
        '
        Me.XrTableCell26.Name = "XrTableCell26"
        Me.XrTableCell26.Text = "MinRate"
        Me.XrTableCell26.Weight = 1.2345666924595671R
        '
        'XrTableCell27
        '
        Me.XrTableCell27.Name = "XrTableCell27"
        Me.XrTableCell27.Text = "Hours"
        Me.XrTableCell27.Weight = 1.4440032997617212R
        '
        'XrTable9
        '
        Me.XrTable9.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 289.6667!)
        Me.XrTable9.Name = "XrTable9"
        Me.XrTable9.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow9})
        Me.XrTable9.SizeF = New System.Drawing.SizeF(259.9999!, 25.0!)
        Me.XrTable9.StylePriority.UseTextAlignment = False
        Me.XrTable9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow9
        '
        Me.XrTableRow9.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell28, Me.XrTableCell29, Me.XrTableCell31, Me.XrTableCell32})
        Me.XrTableRow9.Name = "XrTableRow9"
        Me.XrTableRow9.Weight = 1.0R
        '
        'XrTableCell28
        '
        Me.XrTableCell28.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_DutyOn")})
        Me.XrTableCell28.Name = "XrTableCell28"
        Me.XrTableCell28.Weight = 1.0R
        '
        'XrTableCell29
        '
        Me.XrTableCell29.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_DutyOff")})
        Me.XrTableCell29.Name = "XrTableCell29"
        Me.XrTableCell29.Weight = 1.0R
        '
        'XrTableCell31
        '
        Me.XrTableCell31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell31.Name = "XrTableCell31"
        Me.XrTableCell31.Weight = 1.234568832268689R
        '
        'XrTableCell32
        '
        Me.XrTableCell32.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_Hours")})
        Me.XrTableCell32.Name = "XrTableCell32"
        Me.XrTableCell32.Weight = 1.4440011599525993R
        '
        'XrTable5
        '
        Me.XrTable5.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTable5.Font = New System.Drawing.Font("Times New Roman", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
        Me.XrTable5.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 500.6667!)
        Me.XrTable5.Name = "XrTable5"
        Me.XrTable5.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow5})
        Me.XrTable5.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable5.StylePriority.UseBackColor = False
        Me.XrTable5.StylePriority.UseFont = False
        Me.XrTable5.StylePriority.UseTextAlignment = False
        Me.XrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow5
        '
        Me.XrTableRow5.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell11, Me.XrTableCell12, Me.XrTableCell13, Me.XrTableCell14, Me.XrTableCell15})
        Me.XrTableRow5.Name = "XrTableRow5"
        Me.XrTableRow5.Weight = 1.0R
        '
        'XrTableCell11
        '
        Me.XrTableCell11.Name = "XrTableCell11"
        Me.XrTableCell11.Text = "Description"
        Me.XrTableCell11.Weight = 1.4395608137334155R
        '
        'XrTableCell12
        '
        Me.XrTableCell12.Name = "XrTableCell12"
        Me.XrTableCell12.Text = "Days"
        Me.XrTableCell12.Weight = 0.7197804314909243R
        '
        'XrTableCell13
        '
        Me.XrTableCell13.Name = "XrTableCell13"
        Me.XrTableCell13.Text = "Hours"
        Me.XrTableCell13.Weight = 0.71978040778416408R
        '
        'XrTableCell14
        '
        Me.XrTableCell14.Name = "XrTableCell14"
        Me.XrTableCell14.Text = "Rate"
        Me.XrTableCell14.Weight = 0.71978045030056359R
        '
        'XrTableCell15
        '
        Me.XrTableCell15.Name = "XrTableCell15"
        Me.XrTableCell15.Text = "Amount"
        Me.XrTableCell15.Weight = 1.0796678889122209R
        '
        'XrTable10
        '
        Me.XrTable10.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable10.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 525.6666!)
        Me.XrTable10.Name = "XrTable10"
        Me.XrTable10.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow10})
        Me.XrTable10.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable10.StylePriority.UseFont = False
        Me.XrTable10.StylePriority.UseTextAlignment = False
        Me.XrTable10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow10
        '
        Me.XrTableRow10.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell36, Me.XrTableCell37, Me.XrTableCell38, Me.XrTableCell39, Me.XrTableCell40})
        Me.XrTableRow10.Name = "XrTableRow10"
        Me.XrTableRow10.Weight = 1.0R
        '
        'XrTableCell36
        '
        Me.XrTableCell36.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell36.Name = "XrTableCell36"
        Me.XrTableCell36.StylePriority.UseFont = False
        Me.XrTableCell36.StylePriority.UseTextAlignment = False
        Me.XrTableCell36.Text = "Late Arrival"
        Me.XrTableCell36.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell36.Weight = 1.4395608137334155R
        Me.XrTableCell36.WordWrap = False
        '
        'XrTableCell37
        '
        Me.XrTableCell37.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Late_D")})
        Me.XrTableCell37.Name = "XrTableCell37"
        Me.XrTableCell37.Text = "Days"
        Me.XrTableCell37.Weight = 0.7197804314909243R
        '
        'XrTableCell38
        '
        Me.XrTableCell38.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Late_H")})
        Me.XrTableCell38.Name = "XrTableCell38"
        Me.XrTableCell38.Text = "Hours"
        Me.XrTableCell38.Weight = 0.71978040778416408R
        '
        'XrTableCell39
        '
        Me.XrTableCell39.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Late")})
        Me.XrTableCell39.Name = "XrTableCell39"
        Me.XrTableCell39.Text = "Rate"
        Me.XrTableCell39.Weight = 0.71978045030056359R
        '
        'XrTableCell40
        '
        Me.XrTableCell40.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Late_Amount")})
        Me.XrTableCell40.Name = "XrTableCell40"
        Me.XrTableCell40.StylePriority.UseTextAlignment = False
        Me.XrTableCell40.Text = "Amount"
        Me.XrTableCell40.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell40.Weight = 1.0796678889122209R
        '
        'XrTable11
        '
        Me.XrTable11.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable11.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 550.6667!)
        Me.XrTable11.Name = "XrTable11"
        Me.XrTable11.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow11})
        Me.XrTable11.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable11.StylePriority.UseFont = False
        Me.XrTable11.StylePriority.UseTextAlignment = False
        Me.XrTable11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow11
        '
        Me.XrTableRow11.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell41, Me.XrTableCell42, Me.XrTableCell43, Me.XrTableCell44, Me.XrTableCell45})
        Me.XrTableRow11.Name = "XrTableRow11"
        Me.XrTableRow11.Weight = 1.0R
        '
        'XrTableCell41
        '
        Me.XrTableCell41.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell41.Name = "XrTableCell41"
        Me.XrTableCell41.StylePriority.UseFont = False
        Me.XrTableCell41.StylePriority.UseTextAlignment = False
        Me.XrTableCell41.Text = "Early Departure"
        Me.XrTableCell41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell41.Weight = 1.4395608137334155R
        Me.XrTableCell41.WordWrap = False
        '
        'XrTableCell42
        '
        Me.XrTableCell42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Early_D")})
        Me.XrTableCell42.Name = "XrTableCell42"
        Me.XrTableCell42.Text = "Days"
        Me.XrTableCell42.Weight = 0.7197804314909243R
        '
        'XrTableCell43
        '
        Me.XrTableCell43.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Early_H")})
        Me.XrTableCell43.Name = "XrTableCell43"
        Me.XrTableCell43.Text = "Hours"
        Me.XrTableCell43.Weight = 0.71978040778416408R
        '
        'XrTableCell44
        '
        Me.XrTableCell44.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell44.Name = "XrTableCell44"
        Me.XrTableCell44.Text = "Rate"
        Me.XrTableCell44.Weight = 0.71978045030056359R
        '
        'XrTableCell45
        '
        Me.XrTableCell45.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Early_Amount")})
        Me.XrTableCell45.Name = "XrTableCell45"
        Me.XrTableCell45.StylePriority.UseTextAlignment = False
        Me.XrTableCell45.Text = "Amount"
        Me.XrTableCell45.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell45.Weight = 1.0796678889122209R
        '
        'XrTable12
        '
        Me.XrTable12.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable12.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 575.6667!)
        Me.XrTable12.Name = "XrTable12"
        Me.XrTable12.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow12})
        Me.XrTable12.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable12.StylePriority.UseFont = False
        Me.XrTable12.StylePriority.UseTextAlignment = False
        Me.XrTable12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow12
        '
        Me.XrTableRow12.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell46, Me.XrTableCell47, Me.XrTableCell48, Me.XrTableCell49, Me.XrTableCell50})
        Me.XrTableRow12.Name = "XrTableRow12"
        Me.XrTableRow12.Weight = 1.0R
        '
        'XrTableCell46
        '
        Me.XrTableCell46.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell46.Name = "XrTableCell46"
        Me.XrTableCell46.StylePriority.UseFont = False
        Me.XrTableCell46.StylePriority.UseTextAlignment = False
        Me.XrTableCell46.Text = "Duty OverT"
        Me.XrTableCell46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell46.Weight = 1.4395608137334155R
        Me.XrTableCell46.WordWrap = False
        '
        'XrTableCell47
        '
        Me.XrTableCell47.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_OverTime_D")})
        Me.XrTableCell47.Name = "XrTableCell47"
        Me.XrTableCell47.Text = "Days"
        Me.XrTableCell47.Weight = 0.7197804314909243R
        '
        'XrTableCell48
        '
        Me.XrTableCell48.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_OverTime_H")})
        Me.XrTableCell48.Name = "XrTableCell48"
        Me.XrTableCell48.Text = "Hours"
        Me.XrTableCell48.Weight = 0.71978040778416408R
        '
        'XrTableCell49
        '
        Me.XrTableCell49.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell49.Name = "XrTableCell49"
        Me.XrTableCell49.Text = "Rate"
        Me.XrTableCell49.Weight = 0.71978045030056359R
        '
        'XrTableCell50
        '
        Me.XrTableCell50.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_OverTime_Amount")})
        Me.XrTableCell50.Name = "XrTableCell50"
        Me.XrTableCell50.StylePriority.UseTextAlignment = False
        Me.XrTableCell50.Text = "Amount"
        Me.XrTableCell50.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell50.Weight = 1.0796678889122209R
        '
        'XrTable13
        '
        Me.XrTable13.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable13.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 600.6667!)
        Me.XrTable13.Name = "XrTable13"
        Me.XrTable13.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow13})
        Me.XrTable13.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable13.StylePriority.UseFont = False
        Me.XrTable13.StylePriority.UseTextAlignment = False
        Me.XrTable13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow13
        '
        Me.XrTableRow13.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell51, Me.XrTableCell52, Me.XrTableCell53, Me.XrTableCell54, Me.XrTableCell55})
        Me.XrTableRow13.Name = "XrTableRow13"
        Me.XrTableRow13.Weight = 1.0R
        '
        'XrTableCell51
        '
        Me.XrTableCell51.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell51.Name = "XrTableCell51"
        Me.XrTableCell51.StylePriority.UseFont = False
        Me.XrTableCell51.StylePriority.UseTextAlignment = False
        Me.XrTableCell51.Text = "Prayer Late"
        Me.XrTableCell51.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell51.Weight = 1.4395608137334155R
        Me.XrTableCell51.WordWrap = False
        '
        'XrTableCell52
        '
        Me.XrTableCell52.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Prayer_Late_D")})
        Me.XrTableCell52.Name = "XrTableCell52"
        Me.XrTableCell52.Text = "Days"
        Me.XrTableCell52.Weight = 0.7197804314909243R
        '
        'XrTableCell53
        '
        Me.XrTableCell53.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Prayer_Late_H")})
        Me.XrTableCell53.Name = "XrTableCell53"
        Me.XrTableCell53.Text = "Hours"
        Me.XrTableCell53.Weight = 0.71978040778416408R
        '
        'XrTableCell54
        '
        Me.XrTableCell54.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell54.Name = "XrTableCell54"
        Me.XrTableCell54.Text = "Rate"
        Me.XrTableCell54.Weight = 0.71978045030056359R
        '
        'XrTableCell55
        '
        Me.XrTableCell55.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Prayer_Late_Amount")})
        Me.XrTableCell55.Name = "XrTableCell55"
        Me.XrTableCell55.StylePriority.UseTextAlignment = False
        Me.XrTableCell55.Text = "Amount"
        Me.XrTableCell55.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell55.Weight = 1.0796678889122209R
        '
        'XrTable14
        '
        Me.XrTable14.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable14.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 625.6667!)
        Me.XrTable14.Name = "XrTable14"
        Me.XrTable14.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow14})
        Me.XrTable14.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable14.StylePriority.UseFont = False
        Me.XrTable14.StylePriority.UseTextAlignment = False
        Me.XrTable14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow14
        '
        Me.XrTableRow14.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell56, Me.XrTableCell57, Me.XrTableCell58, Me.XrTableCell59, Me.XrTableCell60})
        Me.XrTableRow14.Name = "XrTableRow14"
        Me.XrTableRow14.Weight = 1.0R
        '
        'XrTableCell56
        '
        Me.XrTableCell56.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell56.Name = "XrTableCell56"
        Me.XrTableCell56.StylePriority.UseFont = False
        Me.XrTableCell56.StylePriority.UseTextAlignment = False
        Me.XrTableCell56.Text = "Short Leave"
        Me.XrTableCell56.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell56.Weight = 1.4395608137334155R
        Me.XrTableCell56.WordWrap = False
        '
        'XrTableCell57
        '
        Me.XrTableCell57.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Short_D")})
        Me.XrTableCell57.Name = "XrTableCell57"
        Me.XrTableCell57.Text = "Days"
        Me.XrTableCell57.Weight = 0.7197804314909243R
        '
        'XrTableCell58
        '
        Me.XrTableCell58.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Short_H")})
        Me.XrTableCell58.Name = "XrTableCell58"
        Me.XrTableCell58.Text = "Hours"
        Me.XrTableCell58.Weight = 0.71978040778416408R
        '
        'XrTableCell59
        '
        Me.XrTableCell59.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell59.Name = "XrTableCell59"
        Me.XrTableCell59.Text = "Rate"
        Me.XrTableCell59.Weight = 0.71978045030056359R
        '
        'XrTableCell60
        '
        Me.XrTableCell60.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Short_Amount")})
        Me.XrTableCell60.Name = "XrTableCell60"
        Me.XrTableCell60.StylePriority.UseTextAlignment = False
        Me.XrTableCell60.Text = "Amount"
        Me.XrTableCell60.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell60.Weight = 1.0796678889122209R
        '
        'XrTable15
        '
        Me.XrTable15.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable15.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 650.6667!)
        Me.XrTable15.Name = "XrTable15"
        Me.XrTable15.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow15})
        Me.XrTable15.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable15.StylePriority.UseFont = False
        Me.XrTable15.StylePriority.UseTextAlignment = False
        Me.XrTable15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow15
        '
        Me.XrTableRow15.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell61, Me.XrTableCell62, Me.XrTableCell63, Me.XrTableCell64, Me.XrTableCell65})
        Me.XrTableRow15.Name = "XrTableRow15"
        Me.XrTableRow15.Weight = 1.0R
        '
        'XrTableCell61
        '
        Me.XrTableCell61.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell61.Name = "XrTableCell61"
        Me.XrTableCell61.StylePriority.UseFont = False
        Me.XrTableCell61.StylePriority.UseTextAlignment = False
        Me.XrTableCell61.Text = "Lunch Late"
        Me.XrTableCell61.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell61.Weight = 1.4395608137334155R
        Me.XrTableCell61.WordWrap = False
        '
        'XrTableCell62
        '
        Me.XrTableCell62.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Lunch_Late_D")})
        Me.XrTableCell62.Name = "XrTableCell62"
        Me.XrTableCell62.Text = "Days"
        Me.XrTableCell62.Weight = 0.7197804314909243R
        '
        'XrTableCell63
        '
        Me.XrTableCell63.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Lunch_Late_H")})
        Me.XrTableCell63.Name = "XrTableCell63"
        Me.XrTableCell63.Text = "Hours"
        Me.XrTableCell63.Weight = 0.71978040778416408R
        '
        'XrTableCell64
        '
        Me.XrTableCell64.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell64.Name = "XrTableCell64"
        Me.XrTableCell64.Text = "Rate"
        Me.XrTableCell64.Weight = 0.71978045030056359R
        '
        'XrTableCell65
        '
        Me.XrTableCell65.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Lunch_Late_Amount")})
        Me.XrTableCell65.Name = "XrTableCell65"
        Me.XrTableCell65.StylePriority.UseTextAlignment = False
        Me.XrTableCell65.Text = "Amount"
        Me.XrTableCell65.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell65.Weight = 1.0796678889122209R
        '
        'XrTable16
        '
        Me.XrTable16.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable16.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 675.6666!)
        Me.XrTable16.Name = "XrTable16"
        Me.XrTable16.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow16})
        Me.XrTable16.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable16.StylePriority.UseFont = False
        Me.XrTable16.StylePriority.UseTextAlignment = False
        Me.XrTable16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow16
        '
        Me.XrTableRow16.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell66, Me.XrTableCell67, Me.XrTableCell68, Me.XrTableCell69, Me.XrTableCell70})
        Me.XrTableRow16.Name = "XrTableRow16"
        Me.XrTableRow16.Weight = 1.0R
        '
        'XrTableCell66
        '
        Me.XrTableCell66.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell66.Name = "XrTableCell66"
        Me.XrTableCell66.StylePriority.UseFont = False
        Me.XrTableCell66.StylePriority.UseTextAlignment = False
        Me.XrTableCell66.Text = "Lunch OverT"
        Me.XrTableCell66.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell66.Weight = 1.4395608137334155R
        Me.XrTableCell66.WordWrap = False
        '
        'XrTableCell67
        '
        Me.XrTableCell67.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Lunch_OverTime_D")})
        Me.XrTableCell67.Name = "XrTableCell67"
        Me.XrTableCell67.Text = "Days"
        Me.XrTableCell67.Weight = 0.7197804314909243R
        '
        'XrTableCell68
        '
        Me.XrTableCell68.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Lunch_OverTime_H")})
        Me.XrTableCell68.Name = "XrTableCell68"
        Me.XrTableCell68.Text = "Hours"
        Me.XrTableCell68.Weight = 0.71978040778416408R
        '
        'XrTableCell69
        '
        Me.XrTableCell69.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell69.Name = "XrTableCell69"
        Me.XrTableCell69.Text = "Rate"
        Me.XrTableCell69.Weight = 0.71978045030056359R
        '
        'XrTableCell70
        '
        Me.XrTableCell70.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Lunch_OverTime_Amount")})
        Me.XrTableCell70.Name = "XrTableCell70"
        Me.XrTableCell70.StylePriority.UseTextAlignment = False
        Me.XrTableCell70.Text = "Amount"
        Me.XrTableCell70.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell70.Weight = 1.0796678889122209R
        '
        'XrTable17
        '
        Me.XrTable17.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable17.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 700.6666!)
        Me.XrTable17.Name = "XrTable17"
        Me.XrTable17.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow17})
        Me.XrTable17.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable17.StylePriority.UseFont = False
        Me.XrTable17.StylePriority.UseTextAlignment = False
        Me.XrTable17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow17
        '
        Me.XrTableRow17.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell71, Me.XrTableCell72, Me.XrTableCell73, Me.XrTableCell74, Me.XrTableCell75})
        Me.XrTableRow17.Name = "XrTableRow17"
        Me.XrTableRow17.Weight = 1.0R
        '
        'XrTableCell71
        '
        Me.XrTableCell71.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell71.Name = "XrTableCell71"
        Me.XrTableCell71.StylePriority.UseFont = False
        Me.XrTableCell71.StylePriority.UseTextAlignment = False
        Me.XrTableCell71.Text = "Private Late"
        Me.XrTableCell71.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        Me.XrTableCell71.Weight = 1.4395608137334155R
        Me.XrTableCell71.WordWrap = False
        '
        'XrTableCell72
        '
        Me.XrTableCell72.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Private_Late_D")})
        Me.XrTableCell72.Name = "XrTableCell72"
        Me.XrTableCell72.Text = "Days"
        Me.XrTableCell72.Weight = 0.7197804314909243R
        '
        'XrTableCell73
        '
        Me.XrTableCell73.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Private_Late_H")})
        Me.XrTableCell73.Name = "XrTableCell73"
        Me.XrTableCell73.Text = "Hours"
        Me.XrTableCell73.Weight = 0.71978040778416408R
        '
        'XrTableCell74
        '
        Me.XrTableCell74.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total_MinRate")})
        Me.XrTableCell74.Name = "XrTableCell74"
        Me.XrTableCell74.Text = "Rate"
        Me.XrTableCell74.Weight = 0.71978045030056359R
        '
        'XrTableCell75
        '
        Me.XrTableCell75.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Private_Late_Amount")})
        Me.XrTableCell75.Name = "XrTableCell75"
        Me.XrTableCell75.StylePriority.UseTextAlignment = False
        Me.XrTableCell75.Text = "Amount"
        Me.XrTableCell75.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell75.Weight = 1.0796678889122209R
        '
        'XrTable19
        '
        Me.XrTable19.BackColor = System.Drawing.Color.Gainsboro
        Me.XrTable19.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable19.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 725.6666!)
        Me.XrTable19.Name = "XrTable19"
        Me.XrTable19.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow19})
        Me.XrTable19.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable19.StylePriority.UseBackColor = False
        Me.XrTable19.StylePriority.UseFont = False
        Me.XrTable19.StylePriority.UseTextAlignment = False
        Me.XrTable19.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow19
        '
        Me.XrTableRow19.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell77, Me.XrTableCell78})
        Me.XrTableRow19.Name = "XrTableRow19"
        Me.XrTableRow19.Weight = 1.0R
        '
        'XrTableCell77
        '
        Me.XrTableCell77.Name = "XrTableCell77"
        Me.XrTableCell77.StylePriority.UseTextAlignment = False
        Me.XrTableCell77.Text = "Summary of Month:"
        Me.XrTableCell77.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell77.Weight = 3.5989023519843295R
        '
        'XrTableCell78
        '
        Me.XrTableCell78.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Amount")})
        Me.XrTableCell78.Name = "XrTableCell78"
        Me.XrTableCell78.StylePriority.UseTextAlignment = False
        Me.XrTableCell78.Text = "Amount"
        Me.XrTableCell78.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell78.Weight = 1.0796676402369585R
        '
        'XrTable20
        '
        Me.XrTable20.BackColor = System.Drawing.Color.Transparent
        Me.XrTable20.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable20.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 750.6667!)
        Me.XrTable20.Name = "XrTable20"
        Me.XrTable20.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow20})
        Me.XrTable20.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable20.StylePriority.UseBackColor = False
        Me.XrTable20.StylePriority.UseFont = False
        Me.XrTable20.StylePriority.UseTextAlignment = False
        Me.XrTable20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow20
        '
        Me.XrTableRow20.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell79, Me.XrTableCell81})
        Me.XrTableRow20.Name = "XrTableRow20"
        Me.XrTableRow20.Weight = 1.0R
        '
        'XrTableCell79
        '
        Me.XrTableCell79.Name = "XrTableCell79"
        Me.XrTableCell79.StylePriority.UseTextAlignment = False
        Me.XrTableCell79.Text = "Old Due"
        Me.XrTableCell79.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell79.Weight = 3.5989023519843295R
        '
        'XrTableCell81
        '
        Me.XrTableCell81.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Beg")})
        Me.XrTableCell81.Name = "XrTableCell81"
        Me.XrTableCell81.StylePriority.UseTextAlignment = False
        Me.XrTableCell81.Text = "Amount"
        Me.XrTableCell81.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell81.Weight = 1.0796676402369585R
        '
        'XrTable21
        '
        Me.XrTable21.BackColor = System.Drawing.Color.Transparent
        Me.XrTable21.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable21.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 775.6667!)
        Me.XrTable21.Name = "XrTable21"
        Me.XrTable21.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow21})
        Me.XrTable21.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable21.StylePriority.UseBackColor = False
        Me.XrTable21.StylePriority.UseFont = False
        Me.XrTable21.StylePriority.UseTextAlignment = False
        Me.XrTable21.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow21
        '
        Me.XrTableRow21.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell82, Me.XrTableCell83})
        Me.XrTableRow21.Name = "XrTableRow21"
        Me.XrTableRow21.Weight = 1.0R
        '
        'XrTableCell82
        '
        Me.XrTableCell82.Name = "XrTableCell82"
        Me.XrTableCell82.StylePriority.UseTextAlignment = False
        Me.XrTableCell82.Text = "Advances:"
        Me.XrTableCell82.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell82.Weight = 3.5989023519843295R
        '
        'XrTableCell83
        '
        Me.XrTableCell83.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Advance")})
        Me.XrTableCell83.Name = "XrTableCell83"
        Me.XrTableCell83.StylePriority.UseTextAlignment = False
        Me.XrTableCell83.Text = "Amount"
        Me.XrTableCell83.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell83.Weight = 1.0796676402369585R
        '
        'XrTable22
        '
        Me.XrTable22.BackColor = System.Drawing.Color.Transparent
        Me.XrTable22.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable22.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 800.6666!)
        Me.XrTable22.Name = "XrTable22"
        Me.XrTable22.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow22})
        Me.XrTable22.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable22.StylePriority.UseBackColor = False
        Me.XrTable22.StylePriority.UseFont = False
        Me.XrTable22.StylePriority.UseTextAlignment = False
        Me.XrTable22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow22
        '
        Me.XrTableRow22.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell84, Me.XrTableCell85})
        Me.XrTableRow22.Name = "XrTableRow22"
        Me.XrTableRow22.Weight = 1.0R
        '
        'XrTableCell84
        '
        Me.XrTableCell84.Name = "XrTableCell84"
        Me.XrTableCell84.StylePriority.UseTextAlignment = False
        Me.XrTableCell84.Text = "Fine:"
        Me.XrTableCell84.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell84.Weight = 3.5989023519843295R
        '
        'XrTableCell85
        '
        Me.XrTableCell85.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Fine")})
        Me.XrTableCell85.Name = "XrTableCell85"
        Me.XrTableCell85.StylePriority.UseTextAlignment = False
        Me.XrTableCell85.Text = "Amount"
        Me.XrTableCell85.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell85.Weight = 1.0796676402369585R
        '
        'XrTable23
        '
        Me.XrTable23.BackColor = System.Drawing.Color.Transparent
        Me.XrTable23.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable23.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 825.6666!)
        Me.XrTable23.Name = "XrTable23"
        Me.XrTable23.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow23})
        Me.XrTable23.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable23.StylePriority.UseBackColor = False
        Me.XrTable23.StylePriority.UseFont = False
        Me.XrTable23.StylePriority.UseTextAlignment = False
        Me.XrTable23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow23
        '
        Me.XrTableRow23.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell86, Me.XrTableCell87})
        Me.XrTableRow23.Name = "XrTableRow23"
        Me.XrTableRow23.Weight = 1.0R
        '
        'XrTableCell86
        '
        Me.XrTableCell86.Name = "XrTableCell86"
        Me.XrTableCell86.StylePriority.UseTextAlignment = False
        Me.XrTableCell86.Text = "Bonus:"
        Me.XrTableCell86.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell86.Weight = 3.5989023519843295R
        '
        'XrTableCell87
        '
        Me.XrTableCell87.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Bonus")})
        Me.XrTableCell87.Name = "XrTableCell87"
        Me.XrTableCell87.StylePriority.UseTextAlignment = False
        Me.XrTableCell87.Text = "Amount"
        Me.XrTableCell87.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell87.Weight = 1.0796676402369585R
        '
        'XrTable24
        '
        Me.XrTable24.BackColor = System.Drawing.Color.Transparent
        Me.XrTable24.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable24.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 850.6666!)
        Me.XrTable24.Name = "XrTable24"
        Me.XrTable24.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow24})
        Me.XrTable24.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable24.StylePriority.UseBackColor = False
        Me.XrTable24.StylePriority.UseFont = False
        Me.XrTable24.StylePriority.UseTextAlignment = False
        Me.XrTable24.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow24
        '
        Me.XrTableRow24.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell88, Me.XrTableCell89})
        Me.XrTableRow24.Name = "XrTableRow24"
        Me.XrTableRow24.Weight = 1.0R
        '
        'XrTableCell88
        '
        Me.XrTableCell88.Name = "XrTableCell88"
        Me.XrTableCell88.StylePriority.UseTextAlignment = False
        Me.XrTableCell88.Text = "Total:"
        Me.XrTableCell88.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell88.Weight = 3.5989023519843295R
        '
        'XrTableCell89
        '
        Me.XrTableCell89.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Total")})
        Me.XrTableCell89.Name = "XrTableCell89"
        Me.XrTableCell89.StylePriority.UseTextAlignment = False
        Me.XrTableCell89.Text = "Amount"
        Me.XrTableCell89.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell89.Weight = 1.0796676402369585R
        '
        'XrTable25
        '
        Me.XrTable25.BackColor = System.Drawing.Color.Transparent
        Me.XrTable25.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.XrTable25.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 875.6666!)
        Me.XrTable25.Name = "XrTable25"
        Me.XrTable25.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow25})
        Me.XrTable25.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable25.StylePriority.UseBackColor = False
        Me.XrTable25.StylePriority.UseFont = False
        Me.XrTable25.StylePriority.UseTextAlignment = False
        Me.XrTable25.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow25
        '
        Me.XrTableRow25.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell90, Me.XrTableCell91})
        Me.XrTableRow25.Name = "XrTableRow25"
        Me.XrTableRow25.Weight = 1.0R
        '
        'XrTableCell90
        '
        Me.XrTableCell90.Name = "XrTableCell90"
        Me.XrTableCell90.StylePriority.UseTextAlignment = False
        Me.XrTableCell90.Text = "Paid:"
        Me.XrTableCell90.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell90.Weight = 3.5989023519843295R
        '
        'XrTableCell91
        '
        Me.XrTableCell91.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Paid")})
        Me.XrTableCell91.Name = "XrTableCell91"
        Me.XrTableCell91.StylePriority.UseTextAlignment = False
        Me.XrTableCell91.Text = "Amount"
        Me.XrTableCell91.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell91.Weight = 1.0796676402369585R
        '
        'XrTable26
        '
        Me.XrTable26.BackColor = System.Drawing.Color.Transparent
        Me.XrTable26.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.XrTable26.LocationFloat = New DevExpress.Utils.PointFloat(10.00011!, 900.6666!)
        Me.XrTable26.Name = "XrTable26"
        Me.XrTable26.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow26})
        Me.XrTable26.SizeF = New System.Drawing.SizeF(259.9998!, 25.0!)
        Me.XrTable26.StylePriority.UseBackColor = False
        Me.XrTable26.StylePriority.UseFont = False
        Me.XrTable26.StylePriority.UseTextAlignment = False
        Me.XrTable26.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow26
        '
        Me.XrTableRow26.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell92, Me.XrTableCell93})
        Me.XrTableRow26.Name = "XrTableRow26"
        Me.XrTableRow26.Weight = 1.0R
        '
        'XrTableCell92
        '
        Me.XrTableCell92.Name = "XrTableCell92"
        Me.XrTableCell92.StylePriority.UseTextAlignment = False
        Me.XrTableCell92.Text = "Balance:"
        Me.XrTableCell92.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell92.Weight = 3.5989023519843295R
        '
        'XrTableCell93
        '
        Me.XrTableCell93.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Emp_Att_Payment.Emp_Att_Payment_Balance")})
        Me.XrTableCell93.Name = "XrTableCell93"
        Me.XrTableCell93.StylePriority.UseTextAlignment = False
        Me.XrTableCell93.Text = "Amount"
        Me.XrTableCell93.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
        Me.XrTableCell93.Weight = 1.0796676402369585R
        '
        'XrPictureBox1
        '
        Me.XrPictureBox1.Image = CType(resources.GetObject("XrPictureBox1.Image"), System.Drawing.Image)
        Me.XrPictureBox1.LocationFloat = New DevExpress.Utils.PointFloat(9.999978!, 0!)
        Me.XrPictureBox1.Name = "XrPictureBox1"
        Me.XrPictureBox1.SizeF = New System.Drawing.SizeF(259.9996!, 110.7916!)
        Me.XrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage
        '
        'TopMargin
        '
        Me.TopMargin.HeightF = 0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.HeightF = 31.28561!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.BorderColor = System.Drawing.Color.Black
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1.0!
        Me.Title.Font = New System.Drawing.Font("Times New Roman", 20.0!, System.Drawing.FontStyle.Bold)
        Me.Title.ForeColor = System.Drawing.Color.Maroon
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.Transparent
        Me.FieldCaption.BorderColor = System.Drawing.Color.Black
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.FieldCaption.BorderWidth = 1.0!
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Maroon
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.Transparent
        Me.PageInfo.BorderColor = System.Drawing.Color.Black
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.BorderWidth = 1.0!
        Me.PageInfo.Font = New System.Drawing.Font("Times New Roman", 10.0!, System.Drawing.FontStyle.Bold)
        Me.PageInfo.ForeColor = System.Drawing.Color.Black
        Me.PageInfo.Name = "PageInfo"
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.Transparent
        Me.DataField.BorderColor = System.Drawing.Color.Black
        Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DataField.BorderWidth = 1.0!
        Me.DataField.Font = New System.Drawing.Font("Times New Roman", 10.0!)
        Me.DataField.ForeColor = System.Drawing.Color.Black
        Me.DataField.Name = "DataField"
        Me.DataField.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        '
        'Parameter1
        '
        Me.Parameter1.Description = "Employees Ids"
        DynamicListLookUpSettings1.DataAdapter = Nothing
        DynamicListLookUpSettings1.DataMember = "Emp_Att_Payment"
        DynamicListLookUpSettings1.DataSource = Me.EfDataSource1
        DynamicListLookUpSettings1.DisplayMember = "Emp_Att_Payment_Issue_Date"
        DynamicListLookUpSettings1.FilterString = "[Emp_Status] = True"
        DynamicListLookUpSettings1.ValueMember = "Emp_Att_Payment_ID"
        Me.Parameter1.LookUpSettings = DynamicListLookUpSettings1
        Me.Parameter1.MultiValue = True
        Me.Parameter1.Name = "Parameter1"
        Me.Parameter1.Type = GetType(Integer)
        '
        'XtraReport1
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.EfDataSource1})
        Me.DataMember = "Emp_Att_Payment"
        Me.DataSource = Me.EfDataSource1
        Me.FilterString = "[Emp_Att_Payment_ID] In (?Parameter1)"
        Me.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 31)
        Me.PageHeight = 900
        Me.PageWidth = 280
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.Parameter1})
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
        Me.Version = "15.1"
        CType(Me.EfDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    'Friend WithEvents EfDataSource1 As DevExpress.DataAccess.EntityFramework.EFDataSource
    Friend WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable9 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow9 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell28 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell29 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell31 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell32 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable8 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow8 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell23 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell24 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell26 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell27 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell6 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable26 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow26 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell92 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell93 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable25 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow25 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell90 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell91 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable24 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow24 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell88 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell89 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable23 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow23 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell86 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell87 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable22 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow22 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell84 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell85 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable21 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow21 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell82 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell83 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable20 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow20 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell79 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell81 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable19 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow19 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell77 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell78 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable17 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow17 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell71 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell72 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell73 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell74 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell75 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable16 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow16 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell66 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell67 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell68 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell69 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell70 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable15 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow15 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell61 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell62 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell63 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell64 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell65 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable14 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow14 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell56 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell57 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell58 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell59 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell60 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable13 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow13 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell51 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell52 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell53 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell54 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell55 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable12 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow12 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell46 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell47 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell48 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell49 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell50 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable11 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow11 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell41 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell42 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell43 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell44 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell45 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable10 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow10 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell36 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell37 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell38 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell39 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell40 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable5 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow5 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell11 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell12 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell13 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell14 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell15 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable3 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable4 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow4 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell8 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell10 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents Parameter1 As DevExpress.XtraReports.Parameters.Parameter
    Friend WithEvents XrPictureBox2 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrTable18 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow18 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell25 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell94 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable27 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow27 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell95 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell97 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell98 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell99 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable28 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow28 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell100 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell102 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell103 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell104 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable29 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow29 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell105 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell107 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell108 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell109 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable30 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow30 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell110 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell112 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell113 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell114 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable31 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow31 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell115 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell117 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell118 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell119 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTable32 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow32 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell120 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell122 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell123 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell124 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrPictureBox1 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents EfDataSource1 As DevExpress.DataAccess.EntityFramework.EFDataSource
End Class
