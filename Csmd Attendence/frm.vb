

Imports DevExpress.XtraBars
Imports System.IO
Imports System.Drawing.Imaging
Imports DevExpress.XtraEditors
Imports System.Configuration

Module frm
    'Public Const SqlConnectionString2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\ZKTeco\att2000.mdb"
    'Public Const SqlConnectionString As String = "Data Source=.\sqlexpress;Initial Catalog=D:\PLAZA 1-12-18\DATA\CsmdFazalPlazaMain.MDF; user id=sa;password=123"
    'Public Const SqlConnectionString As String = "Data Source=.\sqlexpress;Initial Catalog=D:\PLAZA 1-12-18\DATA\CsmdFazalPlazaMain.MDF; user id=sa;password=123"


    Public Const frmEmployees As String = "frmEmployee"
    Public Const frmEmployeesAdds As String = "Employees Add and Edit"
    Public Const frmPayrollAdds As String = "Employees Payroll"
    Public Const frmChartOfAccountsAdds As String = "Employees PayrollChart of Accounts"
    Public Const frmMultiAccounts As String = "Multi Chart of Accounts"
    Public Const frmDashBoardPreviews As String = "DashBoard Preview"
    'frmDashBoardPreview
    Public Const frmMultiAttendences As String = "Employees Attendence"
    Public Const frmEmployeeAttendenceReportss As String = "Employee Attendence Reports"
    Public Const frmSingleEmployeeAttendenceReports As String = "Single Employee Attendence Report"
    Public Const frmCustomerss As String = "Customers Register"

    Public Const frmCustomersDeposit As String = "Customers Deposit Report"

    Public Const frmCustomersBalances As String = "Cutomers Balance Report"
    Public Const frmPlazaAdjusts As String = "Plaza Shop Adjust"
    Public Const frmMultiBills As String = "Multi Bill"
    Public Const frmGenerateBillss As String = "Generate Bills"
    Public Const frmMultiBillGenerates As String = "Multi Bill Generate"
    Public Const frmMultiPlazaBillGenerates As String = "Plaza Multi Bill Generate"

    Public Const frmMultiRentGenerates As String = "Multi Rent Generate"
    'Public Const frmMultiBills As String = "Single Rent Payment"
    Public Const frmEmployeeEdits As String = "Employee Edits"
    Public Const frmCusAdds As String = "frmCusAdd"
    Public Const frmCusDetails As String = "frmCusDetails"

    Public Const frmShops As String = "Shops"
    'cxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    Public Const frmAttReportss As String = "Attendence Reports"
    Public Const frmAttPaymentss As String = "Attendence Payments"

    'cxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    Public dttNote As New DataTable
    Public dtrNote As DataRow
    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    Public mnb As String
    Public Des As String
    Public ExamT As Integer
    Public MultiPrintIds As String
    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

    Public intAttDate As Date
    Public intSp4 As Integer

    Public intPngID As Integer
    Public intDate As Date

    ' FOR ONLY ONLINE CONST IS HERE


    'frmMultiAttendence
    Public Const SingleRecordViewFromWhere As String = "SingleRecordViewFromWhere"
    Public Const MultiRecordViewFromWhere As String = "MultiRecordViewFromWhere"
    Public Const MultiRecordViewForNavigator As String = "MultiRecordViewForNavigator"

    Public Const FirstRecordsAndPreviousRecordsEnd As String = "FirstAndPreviousEnd"
    Public Const PreviousRecordsAndNextRecords As String = "PreviousAndNext"
    Public Const LastRecordsAndNextRecordsEnd As String = "LastAndNextEnd"


    Public Const NewButton As String = "NewButton Button"
    Public Const SaveButton As String = "SaveButton Button"
    Public Const SaveAndNewButton As String = "SaveAndNewButton Button"
    Public Const SaveAndCloseButton As String = "SaveAndCloseButton Button"
    Public Const DeleteButton As String = "DeleteButton Button"
    Public Const ResetButton As String = "ResetButton Button"
    Public Const ValidateButton As String = "ValidateButton Button"
    Public Const RefreshButton As String = "RefreshButton Button"
    Public Const CloseButton As String = "CloseButton Button"
    Public Const FirstButton As String = "FirstButton Button"
    Public Const PreviousButton As String = "PreviousButton Button"
    Public Const NextButton As String = "NextButton Button"
    Public Const LastButton As String = "LastButton Button"


    Public intMultiGrid As String
    Public frmLoadAction As String
    Public Const frmNewAction As String = "NewRecords"
    Public Const frmEditAction As String = "EditRecords"
    Public Const frmMultiAction As String = "Multi Report"
    Public Const frmSingleAction As String = "Single Report"
    Public intMultiFee As Integer
    Public intInvoice As String
    Public intMultiGroup As String
    Public intMultiExamType As Integer
    Public intMultiClass As Integer
    Public intMultiDate As DateTime

    Public Global_RB_Pay_Detail_ID As Integer
    'Public frmDialog As New frmMultiBill
    Public frmLoad As String
    Public Const AddMode As String = "AddMode"
    Public Const LoadMode As String = "LoadMode"

    Public PlazaUserID As Integer
    Public UpdaterSW As Boolean = False
    Public intMultiAccount As Integer
    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '    MULTI TABLES FOR frmMultiGrid
    'STUDENT FUNCTIONS
    Public intList() As Integer
    Public intList2() As Integer
    Public intListSelected() As Integer



    ' EMBULANCE

    Public Const frmEmbulanceAddS As String = "frmEmbulanceAdd"
    Public Const frmDriversAddS As String = "frmDriversAdd"
    Public Const frmDriversPayrollAdds As String = "frmDriversPayrollAdd"
    Public Const frmEmbulanceCallsAdds As String = "frmEmbulanceCallsAdd"
    Public Const frmEmbulanceDetailAdds As String = "frmEmbulanceDetailAdd"
    Public Const frmEmbulanceMaintinanceAdds As String = "frmEmbulanceMaintinanceAdd"
    Public Const frmPatientAdds As String = "frmPatientAdd"
    'frmDriversPayrollAdd

    Public Const frmEmbulanceBalanceViews As String = "Journal Entries"
    Public Const frmEmbulanceCalculations As String = "Calculating Accounting Balances"
    Public Const frmBalanceSheets As String = "Balance Sheet and Income Statement"



    Public frmAction As String

    'TEACHER FUNCTIONS

    ' Acc_1_L As TextEdit,
    ' Acc_1_R As textedit,

    ' Acc_2_L As textedit,
    ' Acc_2_R As textedit,

    ' Acc_3_1_L As textedit,
    ' Acc_3_2_L As textedit,
    ' Acc_3_1_2_R As textedit,

    ' Acc_4_1_L As textedit,
    ' Acc_4_2_L As textedit,
    ' Acc_4_1_2_R As textedit,
    ''vvvvvvvvvvvvvvvvvvvvv
    ' Acc_5_R As textedit,
    ' Acc_5_1_L As textedit,
    ' Acc_5_2_L As textedit,
    ' Acc_5_3_L As textedit,

    ' Acc_6_1_L As textedit,
    ' Acc_6_2_L As textedit,
    ' Acc_6_1_2_R As textedit,

    ' Acc_7_1_L As textedit,
    ' Acc_7_1_R As textedit,
    ' Acc_7_2_L As textedit,
    ' Acc_7_2_R As textedit,


    'Private Sub LoadData(DriverID As Integer, VehicelID As Integer, Datx As DateTime, Acc_1_L As TextEdit,
    ' Acc_1_R As TextEdit,
    ' Acc_2_L As TextEdit,
    ' Acc_2_R As TextEdit,
    ' Acc_3_1_L As TextEdit,
    ' Acc_3_2_L As TextEdit,
    ' Acc_3_1_2_R As TextEdit,
    ' Acc_4_1_L As TextEdit,
    ' Acc_4_2_L As TextEdit,
    ' Acc_4_1_2_R As TextEdit,
    ' Acc_5_R As TextEdit,
    ' Acc_5_1_L As TextEdit,
    ' Acc_5_2_L As TextEdit,
    ' Acc_5_3_L As TextEdit,
    ' Acc_6_1_L As TextEdit,
    ' Acc_6_2_L As TextEdit,
    ' Acc_6_1_2_R As TextEdit,
    ' Acc_7_1_L As TextEdit,
    ' Acc_7_1_R As TextEdit,
    ' Acc_7_2_L As TextEdit,
    ' Acc_7_2_R As TextEdit)
    '            Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
    '        'Dim DriverID As Integer = Driver_ID.EditValue
    '        'Dim VehicelID As Integer = Vehicle_ID.EditValue
    '        'Dim Datx As DateTime = DateX.EditValue
    '        Dim EmbulanceDeposit = (From a In db.Driver_Payroll Where a.Driver_Payroll_Date.Value.Month = Datx.Month And a.Driver_Payroll_Date.Value.Year = Datx.Year And a.Driver_ID = DriverID And a.Driver_Pay_Type_ID = 1 Select a.Driver_Payroll_Amount).Sum
    '        Acc_1_L.Text = If(EmbulanceDeposit IsNot Nothing, EmbulanceDeposit, 0)
    '        Acc_1_R.Text = Acc_1_L.Text

    '        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '        Dim VehFuelAmount = (From a In db.Veh_Fuel_Detail Where a.Veh_Fuel_Detail_Date.Value.Month = Datx.Month And a.Veh_Fuel_Detail_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID Select a.Veh_Fuel_Detail_Amount).Sum
    '        Acc_2_L.Text = If(VehFuelAmount IsNot Nothing, VehFuelAmount, 0)
    '        Acc_2_R.Text = Acc_2_L.Text

    '        'xxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '        Dim VehSmallRepairingAmount = (From a In db.Veh_Maintinance Where a.Veh_Maintinance_Date.Value.Month = Datx.Month And a.Veh_Maintinance_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID And a.Veh_Expensee_Type_ID = 1 Select a.Veh_Maintinance_Repairing_Amount).Sum
    '        Acc_3_1_L.Text = If(VehSmallRepairingAmount IsNot Nothing, VehSmallRepairingAmount, 0)

    '        Dim VehSmallPartsAmount = (From a In db.Veh_Maintinance Where a.Veh_Maintinance_Date.Value.Month = Datx.Month And a.Veh_Maintinance_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID And a.Veh_Expensee_Type_ID = 1 Select a.Veh_Maintinance_Amount).Sum
    '        Acc_3_2_L.Text = If(VehSmallPartsAmount IsNot Nothing, VehSmallPartsAmount, 0)

    '        Acc_3_1_2_R.Text = CDbl(Acc_3_1_L.Text) + CDbl(Acc_3_2_L.Text)

    '        'xxxxxxxxxxxxxxxxxxxxxxxxxx
    '        Dim VehMLRepairingAmount = (From a In db.Veh_Maintinance Where a.Veh_Maintinance_Date.Value.Month = Datx.Month And a.Veh_Maintinance_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID And a.Veh_Expensee_Type_ID = 2 Or a.Veh_Expensee_Type_ID = 3 Select a.Veh_Maintinance_Repairing_Amount).Sum
    '        Acc_4_1_L.Text = If(VehMLRepairingAmount IsNot Nothing, VehMLRepairingAmount, 0)

    '        Dim VehMLPartsAmount = (From a In db.Veh_Maintinance Where a.Veh_Maintinance_Date.Value.Month = Datx.Month And a.Veh_Maintinance_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID And a.Veh_Expensee_Type_ID = 2 Or a.Veh_Expensee_Type_ID = 3 Select a.Veh_Maintinance_Amount).Sum
    '        Acc_4_1_L.Text = If(VehMLPartsAmount IsNot Nothing, VehMLPartsAmount, 0)

    '        Acc_4_1_2_R.Text = CDbl(Acc_4_1_L.Text) + CDbl(Acc_4_2_L.Text)
    '        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

    '        Dim VehEmb_Calls_Total_Amount = (From a In db.Emb_Calls Where a.Emb_Calls_Call_Date.Value.Month = Datx.Month And a.Emb_Calls_Call_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID And a.Driver_ID = DriverID Select a.Emb_Calls_Total_Amount).Sum
    '        Acc_5_R.Text = If(VehEmb_Calls_Total_Amount IsNot Nothing, VehEmb_Calls_Total_Amount, 0)

    '        Dim VehEmb_Calls_Paid_Amount = (From a In db.Emb_Calls Where a.Emb_Calls_Call_Date.Value.Month = Datx.Month And a.Emb_Calls_Call_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID And a.Driver_ID = DriverID Select a.Emb_Calls_Paid_Amount).Sum
    '        Acc_5_1_L.Text = If(VehEmb_Calls_Paid_Amount IsNot Nothing, VehEmb_Calls_Paid_Amount, 0)

    '        Dim VeEmb_Calls_Due = (From a In db.Emb_Calls Where a.Emb_Calls_Call_Date.Value.Month = Datx.Month And a.Emb_Calls_Call_Date.Value.Year = Datx.Year And a.Vehicle_ID = VehicelID And a.Driver_ID = DriverID Select a.Emb_Calls_Due).Sum
    '        Acc_5_2_L.Text = If(VeEmb_Calls_Due IsNot Nothing, VeEmb_Calls_Due, 0)

    '        'Dim TotalExpensee As Double = CDbl(TxtVehSmallRepPartsAmount.Text) + CDbl(TxtVehMLRepPartsAmount.Text)

    '        'EndingDeposit.text = (CDbl(TxtEmbulanceDeposit.Text) - CDbl(TxtVehFuelAmount.Text)) - CDbl(TotalExpensee)

    '        'EndTxtVehSmallRepPartsAmount.text = TxtVehSmallRepPartsAmount.Text

    '        Dim EndPaid_And_Expensee As Double = CDbl(Acc_5_1_L.Text) - CDbl(Acc_3_1_2_R.Text)
    '        Acc_6_1_L.Text = (EndPaid_And_Expensee / 100) * 10

    '        Dim SalaryAmount = (From a In db.Drivers Where a.Driver_ID = DriverID Select a.Driver_Salary).FirstOrDefault
    '        Acc_6_2_L.Text = If(SalaryAmount IsNot Nothing, SalaryAmount, 0)
    '        Acc_6_1_2_R.Text = (CDbl(Acc_6_1_L.Text) + CDbl(Acc_6_2_L.Text))

    '        Dim DriversAdvances = (From a In db.Driver_Payroll Where a.Driver_Payroll_Date.Value.Month = Datx.Month And a.Driver_Payroll_Date.Value.Year = Datx.Year And a.Driver_ID = DriverID And a.Driver_Pay_Type_ID = 2 Select a.Driver_Payroll_Amount).Sum
    '        Acc_7_1_L.Text = If(DriversAdvances IsNot Nothing, DriversAdvances, 0)
    '        Acc_7_1_R.Text = Acc_7_1_R.Text
    '        Dim DriversSalary = (From a In db.Driver_Payroll Where a.Driver_Payroll_Date.Value.Month = Datx.Month And a.Driver_Payroll_Date.Value.Year = Datx.Year And a.Driver_ID = DriverID And a.Driver_Pay_Type_ID = 3 Select a.Driver_Payroll_Amount).Sum
    '        Acc_7_2_L.Text = If(DriversSalary IsNot Nothing, DriversSalary, 0)
    '        Acc_7_2_R.Text = Acc_7_2_L.Text


    '        'Debtt.Text = CDbl(TxtVehFuelAmount.Text) + CDbl(TotalExpensee) + CDbl(TxtVehEmb_Calls_Paid_Amount.Text) + CDbl(TxtVeEmb_Calls_Due.Text) + CDbl(TxtCommission.Text) + CDbl(TxtSalaryAmount.Text)
    '        'Crett.Text = CDbl(TxtEmbulanceDeposit.Text) + CDbl(TxtVehEmb_Calls_Total_Amount.Text) + CDbl(TxtDriversAdvances.Text) + CDbl(EndingDriverSalary.Text)
    '    End Using
    'End Sub







#Region "All Form Navigation System"



    Dim Record As Integer
    Public Function RecordNumber(ByVal aa As Integer, TableCount As Integer, ByRef R1 As BarButtonItem, ByRef R2 As BarButtonItem, ByRef R3 As BarButtonItem, ByRef R4 As BarButtonItem) As Integer
        Select Case aa
            Case 0
                Record = 0
                Navi(FirstRecordsAndPreviousRecordsEnd, R1, R2, R3, R4)
                Return Record
            Case 1
                If Record > 0 Then
                    Record -= 1
                    Navi(PreviousRecordsAndNextRecords, R1, R2, R3, R4)
                Else
                    Navi(FirstRecordsAndPreviousRecordsEnd, R1, R2, R3, R4)
                End If
                Return Record
            Case 2
                If Record = TableCount Then
                    Navi(LastRecordsAndNextRecordsEnd, R1, R2, R3, R4)
                Else
                    Record += 1
                    Navi(PreviousRecordsAndNextRecords, R1, R2, R3, R4)
                End If
                Return Record
            Case 3
                Record = TableCount
                Navi(LastRecordsAndNextRecordsEnd, R1, R2, R3, R4)
                Return Record
        End Select
        Return Record
    End Function

    Public Sub Navi(ButtonName As String, ByRef R1 As BarButtonItem, ByRef R2 As BarButtonItem, ByRef R3 As BarButtonItem, ByRef R4 As BarButtonItem)
        Select Case ButtonName
            Case FirstRecordsAndPreviousRecordsEnd
                EnableRibbonButton(R1, False, R2, False, R3, True, R4, True)
            Case PreviousRecordsAndNextRecords
                EnableRibbonButton(R1, True, R2, True, R3, True, R4, True)
            Case LastRecordsAndNextRecordsEnd
                EnableRibbonButton(R1, True, R2, True, R3, False, R4, False)
        End Select
    End Sub

    Public Function EnableRibbonButton(ByRef R1 As BarButtonItem, E1 As Boolean, ByRef R2 As BarButtonItem, E2 As Boolean, ByRef R3 As BarButtonItem, E3 As Boolean, ByRef R4 As BarButtonItem, E4 As Boolean) As Boolean
        R1.Enabled = E1 : R2.Enabled = E2 : R3.Enabled = E3 : R4.Enabled = E4
        Return False
    End Function
#End Region
    'Dim Load_cmb_Vehicle As New cmb_Vehicle_Lookup

    'Public Sub Load_cmb_Vehicle_frmEmbulanceDetailAdd()
    '    Dim frmEmbulanceDetailAdd As New frmEmbulanceDetailAdd
    '    Load_cmb_Vehicle.ColumnsAndData(frmEmbulanceDetailAdd.Vehicle_ID)

    '    MsgBox(frmEmbulanceDetailAdd.Name)
    'End Sub

    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    Public Function CsmdWaFont(txt As String) As String
        Dim kk As String = ""
        If txt Is Nothing Then
            txt = "00"
        End If
        For k As Integer = 0 To txt.Length - 1
            Select Case txt(k)
                Case "1"
                    kk = kk + "%C2%B9"
                Case "2"
                    kk = kk + "%C2%B2"
                Case "3"
                    kk = kk + "%C2%B3"
                Case "4"
                    kk = kk + "%E2%81%B4"
                Case "5"
                    kk = kk + "%E2%81%B5"
                Case "6"
                    kk = kk + "%E2%81%B6"
                Case "7"
                    kk = kk + "%E2%81%B7"
                Case "8"
                    kk = kk + "%E2%81%B8"
                Case "9"
                    kk = kk + "%E2%81%B9"
                Case "0"
                    kk = kk + "%E2%81%B0"
                Case "."
                    kk = kk + "."
                Case ":"
                    kk = kk + ":"
            End Select
        Next

        Return kk


    End Function
    Public Function ImgToDb(info As FileInfo) As Byte()
        Dim content As Byte() = New Byte(info.Length - 1) {}
        Dim imagestream As FileStream = info.OpenRead()
        imagestream.Read(content, 0, content.Length)
        imagestream.Close()
        Return content
    End Function
    Public Function DbToImg(Imag As Byte()) As Image
        Dim Img As Image
        Dim ImgByte As Byte() = Nothing
        Dim stream As MemoryStream
        ImgByte = CType(Imag.ToArray(), Byte())
        stream = New MemoryStream(ImgByte, 0, ImgByte.Length)
        Img = Image.FromStream(stream)
        Return Img
    End Function
    Public Function ImgToByteArray(img As Image, imgFormat As ImageFormat) As Byte()
        Dim tmpData As Byte()
        Using ms As New MemoryStream()
            img.Save(ms, imgFormat)

            tmpData = ms.ToArray
        End Using              ' dispose of memstream
        Return tmpData
    End Function

    Public Function IfNull(txt As TextEdit) As Double
        Return If(txt.Text = "", 0, txt.Text)
    End Function
    Public Function IfNulll(txt As TextEdit) As String
        Return If(txt.Text = "", "00:00", txt.Text)
    End Function
    Public Sub cashAccountMulti()
        '        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
        '    Dim dtC = (From a In db.Chart_Of_Accounts Where a.Chart_Of_Accounts_Type_ID = 1 Select a).ToList
        '    If dtC.Count > 0 Then
        '        For Each dtX In dtC
        '            Dim TotalPaid_RB_Pay_Detail As Double = 0
        '            Dim TotalPaid_Pay_Roll As Double = 0
        '            Dim dt = (From a In db.RB_Pay_Detail Where a.Chart_Of_Accounts_ID = dtX.Chart_Of_Accounts_ID Group a By a.Chart_Of_Accounts_ID Into z = Group, TotalPaid = Sum(a.RB_Pay_Detail_Paid) Select TotalPaid).FirstOrDefault
        '            If dt IsNot Nothing Then
        '                TotalPaid_RB_Pay_Detail = dt
        '            Else
        '                TotalPaid_RB_Pay_Detail = 0
        '            End If
        '            Dim dtz = (From a In db.Pay_Roll Where a.Chart_Of_Accounts_ID = dtX.Chart_Of_Accounts_ID Group a By a.Chart_Of_Accounts_ID Into z = Group, TotalPaid = Sum(a.Pay_Roll_Paid) Select TotalPaid).FirstOrDefault
        '            If dtz IsNot Nothing Then
        '                TotalPaid_Pay_Roll = dtz
        '            Else
        '                TotalPaid_Pay_Roll = 0
        '            End If
        '            dtX.Chart_Of_Accounts_Beginning_Balances = TotalPaid_RB_Pay_Detail - TotalPaid_Pay_Roll
        '        Next
        '        db.SaveChanges()
        '    End If
        'End Using
    End Sub
    Public Sub cashAccountSingle(AccountID As Integer)
        '        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
        '    Dim dtC = (From a In db.Chart_Of_Accounts Where a.Chart_Of_Accounts_ID = AccountID Select a).FirstOrDefault
        '    If dtC IsNot Nothing Then
        '        Dim dt = (From a In db.RB_Pay_Detail Where a.Chart_Of_Accounts_ID = dtC.Chart_Of_Accounts_ID Group a By a.Chart_Of_Accounts_ID Into z = Group, TotalPaid = Sum(a.RB_Pay_Detail_Paid) Select TotalPaid).FirstOrDefault
        '        If dt IsNot Nothing Then
        '            dtC.Chart_Of_Accounts_Beginning_Balances = dt
        '        Else
        '            dtC.Chart_Of_Accounts_Beginning_Balances = 0
        '        End If
        '        db.SaveChanges()
        '    End If
        'End Using
    End Sub

    'If dsx.Item("SSN") = "RT-Check In" Then
    '    Mtr.Item("Sn1") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")
    'End If
    'If dsx.Item("SSN") = "LT-Check Out" Then
    '    Mtr.Item("Sn2") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")
    'End If
    'If dsx.Item("SSN") = "RI-Prayer A" Then
    '    Mtr.Item("Sn3") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    'End If
    'If dsx.Item("SSN") = "LI-Prayer B" Then
    '    Mtr.Item("Sn4") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    'End If
    'If dsx.Item("SSN") = "RM-Short Leave A" Then
    '    Mtr.Item("Sn5") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    'End If
    'If dsx.Item("SSN") = "LM-Short Leave B" Then
    '    Mtr.Item("Sn6") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    'End If
    'If dsx.Item("SSN") = "RR-Lunch A" Then
    '    Mtr.Item("Sn7") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    'End If
    'If dsx.Item("SSN") = "LR-Lunch B" Then
    '    Mtr.Item("Sn8") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    'End If
    'If dsx.Item("SSN") = "RP-Private A" Then
    '    Mtr.Item("Sn9") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    'End If
    'If dsx.Item("SSN") = "LP-Private B" Then
    '    Mtr.Item("Sn10") = CDate(dsx.Item("CHECKTIME")).ToString("HH:mm")

    '    'End If
    'End If
End Module
