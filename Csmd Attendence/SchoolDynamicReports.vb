Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraPrinting
Imports System.Drawing.Imaging
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports DevExpress.XtraPrinting.Drawing

Module SchoolDynamicReports
    Public Const Students_Report As String = "Happy Birthday Cards"
    Public Const Students_Movement_Slip As String = "School Half Leave Slip"
    Public Const Students_Fee_Invoice_Slip As String = "Invoice Test A6 Final A476"
    Public Const Students_Fee_Invoice_Slip_Multi As String = "SingleInvoice"
    Public Const Students_Fee_Receipt_Slip As String = "Receipt Test A6 Final A476"
    Public Const Students_Fee_Receipt_Slip_Multi As String = "SingleReceipt"
    'Student Cards X
    'Happy Birthday Cards X
    Public Const Students_Student_Cards_Slip As String = "Student Cards X"
    Public Const Students_Happy_Birthday_Cards_Slip As String = "Happy Birthday Cards X"
    Public Const Students_Happy_Eid_Cards_Slip As String = "Happy Eid Cards"
    Public Const Students_Character_Certificate_Slip As String = "Character Certificate X"
    Public Const Students_Studentship_certificate_Slip As String = "Studentship Certificate"
    Public Const Students_School_Leaving_Certificate_Slip As String = "School Leaving Certificate"
    'Studentship certificate

    Public Const Students_Single_Exam_Result_Play_Group As String = "Single Exam Result Play Group"
    Public Const Students_Exam_Result_SingleX As String = "Exam Result SingleX"
    Public Const Students_Exam_Result_SingleX2 As String = "Exam Result SingleX2"
    Public Const Students_Exam_Result_Single_With_Papers As String = "Exam Result Single With Papers"
    Public Const Students_Date_Sheet As String = "Date Sheet"
    Public Const Students_Syllabus As String = "Syllabus"

    Public Const Students_Student_Notifications As String = "Student Notifications"
    Public Const Students_Student_Subjects As String = "Student Subjects"
    Public Const Students_Student_Subjects_Time_Table As String = "Student Subjects Time Table"
    'Exam Result Single With Papers
    'Attendence Single
    Public Const Students_Attendence_Single As String = "Attendence Single"

    Public Const Students_DataMember As String = "Students"
    Public Const Students_DisplayMember As String = "Stu_Name"
    Public Const Students_ValueMember As String = "Stu_ID"
    Public Const Students_Description As String = "Student List: "
    Public Const Students_FilterString As String = "[Stu_ID] = ?Stu_ID"

    Public Const Students_Half_Leave_Slip_DataMember As String = "Stu_Half_Slip"
    Public Const Students_Half_Leave_Slip_DisplayMember As String = "Student.Stu_Name"
    Public Const Students_Half_Leave_Slip_ValueMember As String = "Student.Stu_ID"
    Public Const Students_Half_Leave_Slip_Description As String = "Student List: "
    Public Const Students_Half_Leave_Slip_FilterString As String = "[Stu_ID] = ?[Student.Stu_ID]"
    '[Booking_Detail_Status] = 'Yes'

    Public Sub OpenReportInPrintPreview(OpenReport As String, DataMember As String, DisplayMember As String,
                                        ValueMember As String, FilterString As String, Description As String, GetByIdInt As Integer)
        Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
        'report.Parameters("parameter1").Value = 78
        Dim param1 As New Parameter()
        param1.Name = ValueMember
        param1.Type = GetType(System.Int32)
        param1.Value = GetByIdInt
        param1.Description = Description
        param1.Visible = True

        Dim lookUpSettings As New DynamicListLookUpSettings()
        lookUpSettings.DataSource = report.DataSource
        lookUpSettings.DataMember = DataMember
        lookUpSettings.DisplayMember = DisplayMember
        lookUpSettings.ValueMember = ValueMember
        param1.LookUpSettings = lookUpSettings
        report.Parameters.Add(param1)
        report.FilterString = FilterString
        report.RequestParameters = False
        ' ''report.MasterReport.DataSource = report.DataSource
        ''report.MasterReport.DataMember = "Booking_Detail"
        ''report.MasterReport.FilterString = "[Booking_Detail_Status] = 'Yes'"
        'CType(report.Bands(BandKind.DetailReport), DetailReportBand).FilterString = "[Booking_Detail_Status] = Yes"
        'CType(__report.Bands(BandKind.DetailReport), DetailReportBand).FilterString = "[LineItemNo] = 3"
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = True

        report.Parameters.Item(0).Value = GetByIdInt

        'frmPrintPreview.DocumentViewer2.DocumentSource = report
        'report.CreateDocument(False)
        'frmPrintPreview.DocumentViewer2.ViewControl.Show()
        pt.Print()
        'Dim reportData As IReportDataV2 = DirectCast(ObjectSpace.FindObject(Application.Modules.FindModule(Of ReportsModuleV2)().ReportDataType, New BinaryOperator("DisplayName", "Bill")), IReportDataV2)
        'Dim report = ReportDataProvider.ReportsStorage.LoadReport(reportData)
        'Dim reportsModule As ReportsModuleV2 = ReportsModuleV2.FindReportsModule(Application.Modules)
        'Dim printTool As New ReportPrintTool(report)
        'With report
        '    report.RequestParameters = False
        '    report.Parameters("p_key").Value = hdr.bill_hdr_key
        '    reportsModule.ReportsDataSourceHelper.SetupBeforePrint(report)
        '    printTool.Print()
        'End With
    End Sub
    Public Sub OpenReportByid(OpenReport As String)
        Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
        report.RequestParameters = False
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = False
        'report.Parameters.Item(0).Value = GetByIdInt
        pt.ShowRibbonPreview()
        'frmPrintPreview.DocumentViewer2.DocumentSource = report
        'report.CreateDocument(False)
        'frmPrintPreview.DocumentViewer2.ViewControl.Show()
    End Sub
    Public Sub OpenReportByid(OpenReport As String, GetByIdInt As Integer)
        Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
        report.RequestParameters = False
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = False
        report.Parameters.Item(0).Value = GetByIdInt
        pt.ShowRibbonPreview()
        'frmPrintPreview.DocumentViewer2.DocumentSource = report
        'report.CreateDocument(False)
        'frmPrintPreview.DocumentViewer2.ViewControl.Show()
    End Sub
    Public Sub OpenReportByidMulti(OpenReport As String, GetByIdInt As Integer())
        Try
            Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
            report.RequestParameters = False
            SetPictureWatermark(report)
            report.Parameters.Item(0).Value = GetByIdInt
            'report.CreateDocument(False)
            Dim pt As New ReportPrintTool(report)
            pt.AutoShowParametersPanel = False
            pt.ShowRibbonPreview()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub OpenReportByidMulti(OpenReport As String, GetByIdInt As Integer(), IssueDate As DateTime)
        Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
        report.RequestParameters = False
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = False
        report.Parameters.Item(0).Value = GetByIdInt
        report.Parameters.Item(1).Value = IssueDate
        pt.ShowRibbonPreview()
        'frmPrintPreview.DocumentViewer2.DocumentSource = report
        'report.CreateDocument(False)
        'frmPrintPreview.DocumentViewer2.ViewControl.Show()
        'pt.Print()
    End Sub
    Public Sub OpenReportByidMultiTwoParameter(OpenReport As String, GetByIdInt As Integer(), ExamTypeIdInt As Integer)
        Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
        report.RequestParameters = False
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = False
        report.Parameters.Item(0).Value = GetByIdInt
        report.Parameters.Item(1).Value = ExamTypeIdInt
        pt.ShowRibbonPreview()
        'frmPrintPreview.DocumentViewer2.DocumentSource = report
        'report.CreateDocument(False)
        'frmPrintPreview.DocumentViewer2.ViewControl.Show()
    End Sub
    Public Sub OpenReportByidMultiTwoParameterWithDate(OpenReport As String, GetByIdInt As Integer(), FilterDate As DateTime)
        Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
        report.RequestParameters = False
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = False
        report.Parameters.Item(0).Value = GetByIdInt
        report.Parameters.Item(1).Value = FilterDate
        pt.ShowRibbonPreview()
        'frmPrintPreview.DocumentViewer2.DocumentSource = report
        'report.CreateDocument(False)
        'frmPrintPreview.DocumentViewer2.ViewControl.Show()
    End Sub
    Public Sub OpenReportByidMultiThreeParameter(OpenReport As String, GetByIdInt As Integer(), ExamTypeIdInt As Integer, ClassIdInt As Integer)
        Try
            Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
            report.RequestParameters = False
            Dim pt As New ReportPrintTool(report)
            pt.AutoShowParametersPanel = False
            report.Parameters.Item(0).Value = GetByIdInt
            report.Parameters.Item(1).Value = ExamTypeIdInt
            report.Parameters.Item(2).Value = ClassIdInt
            pt.ShowRibbonPreview()
            'frmPrintPreview.DocumentViewer2.DocumentSource = report
            'report.CreateDocument(False)
            'frmPrintPreview.DocumentViewer2.ViewControl.Show()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub OpenReportByidMultiDirect(report As XtraReport, GetByIdInt As Integer(), PrintPreview As Boolean)
        report.RequestParameters = False
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = False
        report.Parameters.Item(0).Value = GetByIdInt
        If PrintPreview = True Then
            pt.ShowRibbonPreview()
        Else
            pt.PrintDialog()
        End If
    End Sub

    'Public Sub OpenReportByidMultiTwoParameterDateSheet(OpenReport As String, GetByIdInt As Integer(), ExamTypeIdInt As Integer)
    '    Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
    '    report.RequestParameters = False
    '    Dim pt As New ReportPrintTool(report)
    '    pt.AutoShowParametersPanel = False
    '    report.Parameters.Item(0).Value = ExamTypeIdInt
    '    report.Parameters.Item(1).Value = GetByIdInt
    '    frmPrintPreview.DocumentViewer2.DocumentSource = report
    '    report.CreateDocument(False)
    '    frmPrintPreview.DocumentViewer2.ViewControl.Show()
    'End Sub
    Public Sub ExportToHTML(OpenReport As String, GetByIdInt As Integer())
        Dim report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
        report.Parameters.Item(0).Value = GetByIdInt
        report.ExportToHtml("Test.html")
        StartProcess("Test.html")
    End Sub


    Public Sub ExportToPdf(OpenReport As String, GetByIdInt As Integer())
        Using report As XtraReport = XtraReport.FromFile(".\Reports\" & OpenReport & ".repx", True)
            report.Parameters.Item(0).Value = GetByIdInt
            Dim options As New PdfExportOptions()
            options.PdfACompatibility = PdfACompatibility.PdfA2b
            options.PasswordSecurityOptions.PermissionsPassword = "pwd"
            options.ShowPrintDialogOnOpen = True
            report.ExportToPdf("Result.pdf", options)
        End Using
    End Sub
    Public Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub

    Public Sub OpenReportInReportDesigner(OpenReport As String)
        'Try
        '    Dim Report As New XtraReport
        '    Dim GetReportName As String = ".\Reports\" & OpenReport & ".repx"
        '    Report.LoadLayout(GetReportName)
        '    frmReportDesigner.ReportDesigner1.OpenReport(Report)
        '    frmReportDesigner.Text = OpenReport
        '    frmReportDesigner.ShowDialog()
        'Catch ex As Exception

        'End Try
    End Sub

    Public Sub SetTextWatermark(report As XtraReport)
        ' Adjust text watermark settings.
        report.Watermark.Text = "" ' ImgName()
        report.Watermark.TextDirection = DirectionMode.ForwardDiagonal
        report.Watermark.Font = New Font(report.Watermark.Font.FontFamily, 40)
        report.Watermark.ForeColor = Color.DodgerBlue
        'report.Watermark.Transparency = 150
        report.Watermark.TextTransparency = 150
        report.Watermark.ShowBehind = False
        'report.Watermark.PageRange = "1,3-5"




    End Sub

    Public Sub SetPictureWatermark(report As XtraReport)
        ' Adjust image watermark settings.
        'report.Watermark.Image = ImgLogo() ' Bitmap.FromFile(Application.StartupPath & "\Reports\Watermarks\LOGO.jpg")
        report.Watermark.ImageAlign = ContentAlignment.MiddleCenter
        report.Watermark.ImageTiling = False
        report.Watermark.ImageViewMode = ImageViewMode.Clip
        report.Watermark.ImageTransparency = 245
        report.Watermark.ShowBehind = True
        'report.Watermark.PageRange = "2,4"
    End Sub

End Module
