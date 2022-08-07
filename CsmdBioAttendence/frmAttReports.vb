'Option Explicit On
'Option Strict On

Imports System.Data.OleDb
Imports DevExpress.XtraEditors
Imports System.Linq
Imports System.Data.Entity
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.Utils.Helpers
Imports DevExpress.XtraGrid
Imports DevExpress.Data

Public Class frmAttReports
    Dim Load_Employees_RepositoryItemLookUpEdit As New Employees_RepositoryItemLookUpEdit
    Dim Load_Attendence_Status_RepositoryItemLookUpEdit As New Attendence_Status_RepositoryItemLookUpEdit
    Private Sub frmAttReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = Environment.UserName
        Load_Att_Setting()
        LoadEmp()
        Load_Employees_RepositoryItemLookUpEdit.ColumnsAndData(RepositoryItemLookUpEdit1)
        Load_Attendence_Status_RepositoryItemLookUpEdit.ColumnsAndData(RepositoryItemLookUpEdit2)
        FromDate.EditValue = Today
    End Sub

    Private Sub LoadEmp()
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Where a.Emp_Status = True Order By a.Emp_Name Select New With {.ID = a.Emp_ID, a.Emp_Name}).ToList
            If dt.Count > 0 Then
                GridControl2.DataSource = dt
            Else
                GridControl2.DataSource = Nothing
            End If
        End Using
    End Sub
    Public EmpIDs As Integer


    Dim db As New CsmdBioAttendenceEntities
    Dim objdt As New DataTable
    Private Sub LoadImportDate(fileP As String, fileN As String)
        Using db As New CsmdBioAttendenceEntities


            Dim ExcelCon As New OleDbConnection
            Dim ExcelAdp As OleDbDataAdapter
            Dim ExcelComm As OleDbCommand
            Dim StrSql As String
            Dim successfulImport As Boolean = False
            Dim fileAlreadyAdded As Integer = 0
            Dim dts As DataSet
            objdt.Rows.Clear()
            ExcelCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileP & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
            ExcelCon.Open()

            StrSql = "Select * From [" & fileN & "$]  ;"
            ExcelComm = New OleDbCommand(StrSql, ExcelCon)
            ExcelAdp = New OleDbDataAdapter(ExcelComm)
            dts = New DataSet
            ExcelAdp.Fill(dts)
            ExcelCon.Close()
            Dim k As Integer = 1
            Dim dXA As String = ""
            Dim dXB As String = ""
            Dim ckA As String = ""
            Dim ckB As String = ""
            Dim lnA As String = ""
            Dim lnB As String = ""
            Dim prA As String = ""
            Dim prB As String = ""
            Dim shA As String = ""
            Dim shB As String = ""
            Dim FromDat As DateTime = CDate(FromDate.EditValue)
            Dim firstDay As Date = FirstDayOfMonth(FromDat)
            Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))
            Dim dtx = (From a In db.Employees Where a.Emp_Status = True Select a.Emp_ID, a.Emp_Name).ToList
            If dtx.Count > 0 Then
                ProgressBarControl1.Properties.Maximum = dts.Tables(0).Rows.Count - 1
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 0
                ProgressBarControl1.Update()
                For Each dg In dtx
                    For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate
                        Dim thisDate As Date = DateTime.FromOADate(loopDate)
                        Dim Toti As Double = 0
                        For Each row In dts.Tables(0).Rows
                            Dim datet As DateTime = CStr(row.Item(3)).ToString
                            If dg.Emp_Name = row.item(2).ToString Then
                                If thisDate.Date = datet.Date Then

                                    Dim ToCi As Double = 0
                                    Dim finNa As String = CStr(row.Item(1))
                                    Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                                    Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                                    Dim timg As String = bb.ToString("HH:mm").ToString
                                    Dim vvv = (From a In db.Attendence_Status Where a.Attendence_Status_Type = finNa Select a).FirstOrDefault
                                    Me.Text = "Employee: " & dg.Emp_Name & " Date: " & aa.Date & " Finger: " & finNa & " Time: " & timg
                                    ProgressBarControl1.Position = k
                                    ProgressBarControl1.Update()
                                    k += 1
                                    Dim dth = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dg.Emp_ID And a.Attendence_Status_ID = vvv.Attendence_Status_ID And a.Emp_Attendence_Device_Date = datet.Date And a.Emp_Attendence_Device_Time = timg Select a).FirstOrDefault
                                    If dth IsNot Nothing Then
                                        With dth
                                            .Emp_ID = dg.Emp_ID
                                            .Attendence_Status_ID = vvv.Attendence_Status_ID
                                            .Emp_Attendence_Device_Date = CType(aa.ToString("dd-MMM-yyyy").ToString, Date?)
                                            .Emp_Attendence_Device_Time = bb.ToString("HH:mm").ToString
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RP-Private A" Then
                                                dXA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LP-Private B" Then
                                                dXB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(dXA = "", "00:00", dXA))
                                                Dim ggg As DateTime = CDate(If(dXB = "", "00:00", dXB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = CStr(duration)
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RT-Check In" Then
                                                ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LT-Check Out" Then
                                                ckB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(ckA = "", "00:00", ckA))
                                                Dim ggg As DateTime = CDate(If(ckB = "", "00:00", ckB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                ToCi = duration
                                                .Emp_Attendence_Device_Cal2 = CStr(ToCi)

                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RR-Lunch A" Then
                                                lnA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LR-Lunch B" Then
                                                lnB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(lnA = "", "00:00", lnA))
                                                Dim ggg As DateTime = CDate(If(lnB = "", "00:00", lnB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RI-Prayer A" Then
                                                prA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LI-Prayer B" Then
                                                prB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(prA = "", "00:00", prA))
                                                Dim ggg As DateTime = CDate(If(prB = "", "00:00", prB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RM-Short Leave A" Then
                                                shA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LM-Short Leave B" Then
                                                shB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(shA = "", "00:00", shA))
                                                Dim ggg As DateTime = CDate(If(shB = "", "00:00", shB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                        End With
                                    Else
                                        Dim dtNew = New Emp_Attendence_Device
                                        With dtNew
                                            .Emp_ID = dg.Emp_ID
                                            .Attendence_Status_ID = vvv.Attendence_Status_ID
                                            .Emp_Attendence_Device_Date = CType(aa.ToString("dd-MMM-yyyy").ToString, Date?)
                                            .Emp_Attendence_Device_Time = bb.ToString("HH:mm").ToString
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RP-Private A" Then
                                                dXA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LP-Private B" Then
                                                dXB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(dXA = "", "00:00", dXA))
                                                Dim ggg As DateTime = CDate(If(dXB = "", "00:00", dXB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = CStr(duration)
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RT-Check In" Then
                                                ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LT-Check Out" Then
                                                ckB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(ckA = "", "00:00", ckA))
                                                Dim ggg As DateTime = CDate(If(ckB = "", "00:00", ckB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                ToCi = duration
                                                .Emp_Attendence_Device_Cal2 = CStr(ToCi)
                                                'sssssssssssssssssssssssssssssssssssssssssssssss
                                                Dim dtNewX = New Emp_Attendence_Device
                                                With dtNewX
                                                    .Emp_ID = dg.Emp_ID
                                                    '.Attendence_Status_ID = vvv.Attendence_Status_ID
                                                    .Emp_Attendence_Device_Date = CType(aa.ToString("dd-MMM-yyyy").ToString, Date?)
                                                    .Emp_Attendence_Device_Time = "23:59" 'bb.ToString("HH:mm").ToString
                                                    Dim TotMins As Integer = 194

                                                    'Dim Durationx As TimeSpan = New TimeSpan(0, ToCi, 0)
                                                    'Dim Hoursx = Durationx.Hours
                                                    'Dim Minutesx = Durationx.Minutes
                                                    'Dim Durationy As TimeSpan = New TimeSpan(0, Toti, 0)
                                                    'Dim Hoursy = Durationy.Hours
                                                    'Dim Minutesy = Durationy.Minutes
                                                    Dim Togi As Integer = ToCi - Toti
                                                    Dim Durationx As TimeSpan = TimeSpan.FromMinutes(ToCi)
                                                    Dim Durationy As TimeSpan = TimeSpan.FromMinutes(Toti)
                                                    Dim Durationz As TimeSpan = TimeSpan.FromMinutes(Togi)

                                                    .Emp_Attendence_Device_Cal2 = Durationx.ToString("hh\:mm") ' Durationx.Hours & ":" & Durationx.Minutes
                                                    .Emp_Attendence_Device_Cal1 = Durationy.ToString("hh\:mm")
                                                    .Emp_Attendence_Device_Cal3 = Durationz.ToString("hh\:mm")
                                                End With
                                                db.Emp_Attendence_Device.Add(dtNewX)
                                                'MsgBox(Toti)
                                                Toti = 0
                                                'ssssssssssssssssssssssssssssssssssssssssssssssssssssss
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RR-Lunch A" Then
                                                lnA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LR-Lunch B" Then
                                                lnB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(lnA = "", "00:00", lnA))
                                                Dim ggg As DateTime = CDate(If(lnB = "", "00:00", lnB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RI-Prayer A" Then
                                                prA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LI-Prayer B" Then
                                                prB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(prA = "", "00:00", prA))
                                                Dim ggg As DateTime = CDate(If(prB = "", "00:00", prB))
                                                Dim duration As Integer = DateDiff(DateInterval.Minute, fff, ggg)
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If CStr(row.Item(1)) = "RM-Short Leave A" Then
                                                shA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If CStr(row.Item(1)) = "LM-Short Leave B" Then
                                                shB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(shA = "", "00:00", shA))
                                                Dim ggg As DateTime = CDate(If(shB = "", "00:00", shB))
                                                Dim duration As Integer = DateDiff(DateInterval.Minute, fff, ggg)
                                                Toti += duration
                                                .Emp_Attendence_Device_Cal1 = duration 'fff.ToString("HH:mm") & " to " & ggg.ToString("HH:mm") & "  " & shT.Hours & ":" & shT.Minutes
                                            End If
                                        End With
                                        db.Emp_Attendence_Device.Add(dtNew)
                                    End If
                                    db.SaveChanges()
                                End If
                            End If
                        Next
                    Next
                Next
                LoadAtt(FromDate.EditValue)

                ProgressBarControl1.Properties.Appearance.BackColor = Color.Green
                ProgressBarControl1.Update()
                MsgBox("Import Biometric Device to Plaza Database Successfull")
            End If
        End Using
    End Sub

    Private Sub LoadImportDateCalcu()
        Using db As New CsmdBioAttendenceEntities


            'DeleteAllEmpty()
            'Dim ExcelCon As New OleDbConnection
            'Dim ExcelAdp As OleDbDataAdapter
            'Dim ExcelComm As OleDbCommand
            'Dim StrSql As String
            Dim successfulImport As Boolean = False
            Dim fileAlreadyAdded As Integer = 0
            'Dim dts As DataSet
            'objdt.Rows.Clear()
            'ExcelCon.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & fileP & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
            'ExcelCon.Open()

            'StrSql = "Select * From [" & fileN & "$]  ;"
            'ExcelComm = New OleDbCommand(StrSql, ExcelCon)
            'ExcelAdp = New OleDbDataAdapter(ExcelComm)
            'dts = New DataSet
            'ExcelAdp.Fill(dts)
            'ExcelCon.Close()
            Dim DutyOnX As DateTime = CDate(CDate(DutyOn.EditValue).ToString("HH:mm"))
            Dim DutyOffX As DateTime = CDate(CDate(DutyOff.EditValue).ToString("HH:mm"))
            Dim DutyFriX As DateTime = CDate(CDate(DutyFri.EditValue).ToString("HH:mm"))
            Dim SpX1 As Integer = CInt(Sp1.EditValue)
            Dim SpX2 As Integer = CInt(Sp2.EditValue)
            Dim SpX3 As Integer = CInt(Sp3.EditValue)
            Dim SpX4 As Integer = CInt(Sp4.EditValue)
            Dim SpX5 As Integer = CInt(Sp5.EditValue)


            Dim k As Integer = 1
            Dim dXA As String = ""
            Dim dXB As String = ""
            Dim ckA As String = ""
            Dim ckB As String = ""
            Dim lnA As String = ""
            Dim lnB As String = ""
            Dim prA As String = ""
            Dim prB As String = ""
            Dim shA As String = ""
            Dim shB As String = ""
            Dim FromDat As DateTime = CDate(FromDate.EditValue)
            Dim dts = (From a In db.Emp_Attendence_Device Where a.Employee.Emp_Status = True And a.Emp_Attendence_Device_Date.Value.Year = FromDat.Year And a.Emp_Attendence_Device_Date.Value.Month = FromDat.Month Order By a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time Select a).ToList

            Dim firstDay As Date = FirstDayOfMonth(FromDat)
            Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))
            Dim dtx = (From a In db.Employees Where a.Emp_Status = True Select a.Emp_ID, a.Emp_Name).ToList
            If dtx.Count > 0 Then
                ProgressBarControl1.Properties.Maximum = dts.Count - 1
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 0
                ProgressBarControl1.Update()
                For Each dg In dtx
                    For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate
                        Dim thisDate As Date = DateTime.FromOADate(loopDate)
                        Dim CalStatus As Double = 0
                        Dim CalUpTime As Double = 0
                        Dim oo As Integer = 0
                        Dim SavTime As Double = 0
                        Dim SavAmt As Double = 0

                        For Each row In dts
                            Dim datet As DateTime = CDate(CStr(row.Emp_Attendence_Device_Date).ToString)

                            If dg.Emp_ID = row.Emp_ID Then
                                If thisDate.Date = datet.Date Then

                                    Dim CalInOut As Double = 0
                                    Dim finNa As Integer = If(IsNothing(row.Attendence_Status_ID), 0, CInt(row.Attendence_Status_ID))
                                    Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                                    Dim bb As DateTime = CDate(row.Emp_Attendence_Device_Time) 'datet.TimeOfDay.ToString
                                    Dim timg As String = row.Emp_Attendence_Device_Time ' bb.ToString("HH:mm").ToString
                                    'Dim vvv = (From a In db.Attendence_Status Where a.Attendence_Status_ID = finNa Select a).FirstOrDefault
                                    Me.Text = "Employee: " & dg.Emp_Name & " Date: " & aa.Date & " Finger: " & finNa & " Time: " & timg
                                    Dim kkkkkk As Integer = finNa ' If(IsNothing(row.Attendence_Status_ID), 0, vvv.Attendence_Status_ID)
                                    ProgressBarControl1.Position = k

                                    ProgressBarControl1.Update()
                                    k += 1
                                    Dim dth = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dg.Emp_ID And a.Attendence_Status_ID = kkkkkk And a.Emp_Attendence_Device_Date = datet.Date And a.Emp_Attendence_Device_Time = timg Select a).FirstOrDefault
                                    If dth IsNot Nothing Then
                                        With dth
                                            .Emp_ID = dg.Emp_ID
                                            '.Attendence_Status_ID = finNa ' vvv.Attendence_Status_ID
                                            .Emp_Attendence_Device_Date = CType(aa.ToString("dd-MMM-yyyy").ToString, Date?)
                                            .Emp_Attendence_Device_Time = bb.ToString("HH:mm").ToString
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 9 Then
                                                dXA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 10 Then
                                                dXB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(dXA = "", "00:00", dXA))
                                                Dim ggg As DateTime = CDate(If(dXB = "", "00:00", dXB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                CalStatus += duration

                                                .Emp_Attendence_Device_Cal1 = CStr(duration)
                                                If duration > SpX5 Then
                                                    CalUpTime += CStr(duration - SpX5)
                                                    .Emp_Attendence_Device_Cal2 = CStr(duration - SpX5)
                                                End If

                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 1 Then
                                                ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim ggg As DateTime = CDate(If(ckA = "", "00:00", ckA))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, DutyOnX, ggg))
                                                If duration > SpX1 Then
                                                    CalUpTime += CStr(duration - SpX1)
                                                    .Emp_Attendence_Device_Cal2 = CStr(duration - SpX1)
                                                End If
                                            End If
                                            If finNa = 2 Then
                                                ckB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(ckA = "", "00:00", ckA))
                                                Dim ggg As DateTime = CDate(If(ckB = "", "00:00", ckB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                CalInOut = duration
                                                .Emp_Attendence_Device_Cal3 = CStr(CalInOut)

                                                'If duration > SpX1 Then
                                                If thisDate.DayOfWeek = DayOfWeek.Friday Then
                                                    Dim durationXf As Integer = CInt(DateDiff(DateInterval.Minute, ggg, DutyFriX))
                                                    CalUpTime += durationXf
                                                    .Emp_Attendence_Device_Cal2 = CStr(durationXf) ' - 10
                                                    Dim CalDutyTimeY As Integer = CInt(DateDiff(DateInterval.Minute, DutyOnX, DutyFriX))
                                                    .Emp_Attendence_Device_Cal4 = CalDutyTimeY
                                                Else
                                                    Dim durationXf As Integer = CInt(DateDiff(DateInterval.Minute, ggg, DutyOffX))
                                                    CalUpTime += durationXf
                                                    .Emp_Attendence_Device_Cal2 = CStr(durationXf) ' - 10
                                                    Dim CalDutyTimeY As Integer = CInt(DateDiff(DateInterval.Minute, DutyOnX, DutyOffX))
                                                    .Emp_Attendence_Device_Cal4 = CalDutyTimeY
                                                End If
                                                'Dim gggX As DateTime = CDate(If(ckA = "", "00:00", ckA))

                                                'End If
                                                Dim dtNewX = New Emp_Attendence_Device
                                                With dtNewX
                                                    .Emp_ID = dg.Emp_ID
                                                    '.Attendence_Status_ID = vvv.Attendence_Status_ID
                                                    .Emp_Attendence_Device_Date = CType(aa.ToString("dd-MMM-yyyy").ToString, Date?)
                                                    .Emp_Attendence_Device_Time = "23:59" 'bb.ToString("HH:mm").ToString
                                                    'Dim TotMins As Integer = 194

                                                    'Dim Durationx As TimeSpan = New TimeSpan(0, ToCi, 0)
                                                    'Dim Hoursx = Durationx.Hours
                                                    'Dim Minutesx = Durationx.Minutes
                                                    'Dim Durationy As TimeSpan = New TimeSpan(0, Toti, 0)
                                                    'Dim Hoursy = Durationy.Hours
                                                    'Dim Minutesy = Durationy.Minutes
                                                    Dim CalStatusX As TimeSpan = TimeSpan.FromMinutes(CalStatus)
                                                    Dim CalUpTimeX As TimeSpan = TimeSpan.FromMinutes(CalUpTime)
                                                    Dim CalInOutX As TimeSpan = TimeSpan.FromMinutes(CalInOut)


                                                    .Emp_Attendence_Device_Cal1 = "PHPL - " & CalStatusX.ToString("hh\:mm")
                                                    .Emp_Attendence_Device_Cal2 = "Sub - " & CalUpTimeX.ToString("hh\:mm")
                                                    .Emp_Attendence_Device_Cal3 = "InOut - " & CalInOutX.ToString("hh\:mm")

                                                    If thisDate.DayOfWeek = DayOfWeek.Friday Then
                                                        Dim CalDutyTimeX As Integer = CInt(DateDiff(DateInterval.Minute, DutyOnX, DutyFriX))
                                                        .Emp_Attendence_Device_Cal4 = thisDate.ToString("dddd") & " - " & TimeSpan.FromMinutes(CalDutyTimeX).ToString("hh\:mm")
                                                    Else
                                                        Dim CalDutyTimeX As Integer = CInt(DateDiff(DateInterval.Minute, DutyOnX, DutyOffX))
                                                        .Emp_Attendence_Device_Cal4 = thisDate.ToString("dddd") & " - " & TimeSpan.FromMinutes(CalDutyTimeX).ToString("hh\:mm")
                                                    End If

                                                End With
                                                db.Emp_Attendence_Device.Add(dtNewX)
                                                'MsgBox(Toti)
                                                CalStatus = 0
                                                CalUpTime = 0
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 7 Then
                                                lnA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 8 Then
                                                lnB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(lnA = "", "00:00", lnA))
                                                Dim ggg As DateTime = CDate(If(lnB = "", "00:00", lnB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                CalStatus += duration
                                                .Emp_Attendence_Device_Cal1 = CStr(duration)
                                                'If duration > SpX4 Then
                                                '    CalUpTime += CStr(duration - SpX4)
                                                '    .Emp_Attendence_Device_Cal2 = CStr(duration - SpX4)
                                                'End If
                                                'If duration < SpX4 Then

                                                'SavAmt += CStr(duration)

                                                If oo = 0 Then
                                                    SavTime = CStr(duration - SpX4)
                                                    .Emp_Attendence_Device_Cal2 = CStr(duration - SpX4)
                                                    CalUpTime += CStr(duration - SpX4)
                                                    SavAmt = CStr(duration - SpX4)
                                                    oo += 1
                                                Else
                                                    If SavTime < 0 Then
                                                        SavTime = CStr(duration - Math.Abs(SavTime))

                                                        .Emp_Attendence_Device_Cal2 = SavTime ' CStr(duration - Math.Abs(SavTime))


                                                        CalUpTime = CalUpTime - SavAmt
                                                        SavAmt = SavTime
                                                        'SavTime = CStr(duration - Math.Abs(SavTime))
                                                        CalUpTime += SavTime ' CStr(CalStatus - Math.Abs(SavTime)) '- Math.Abs(SavAmt)
                                                        'SavAmt = 0
                                                    Else
                                                        SavTime = CStr(duration + Math.Abs(SavTime))

                                                        .Emp_Attendence_Device_Cal2 = SavTime ' CStr(duration - Math.Abs(SavTime))


                                                        CalUpTime = CalUpTime - SavAmt
                                                        SavAmt = SavTime
                                                        'SavTime = CStr(duration - Math.Abs(SavTime))
                                                        CalUpTime += SavTime ' CStr(CalStatus - Math.Abs(SavTime)) '- Math.Abs(SavAmt)
                                                        'SavAmt = 0
                                                    End If
                                                    oo += 1
                                                End If
                                                'CalUpTime += SavTime
                                                'End If
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 3 Then
                                                prA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 4 Then
                                                prB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(prA = "", "00:00", prA))
                                                Dim ggg As DateTime = CDate(If(prB = "", "00:00", prB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                CalStatus += duration
                                                .Emp_Attendence_Device_Cal1 = CStr(duration)
                                                If duration > SpX2 Then
                                                    CalUpTime += CStr(duration - SpX2)
                                                    .Emp_Attendence_Device_Cal2 = CStr(duration - SpX2)
                                                End If
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 5 Then
                                                shA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 6 Then
                                                shB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(shA = "", "00:00", shA))
                                                Dim ggg As DateTime = CDate(If(shB = "", "00:00", shB))
                                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
                                                CalStatus += duration
                                                .Emp_Attendence_Device_Cal1 = CStr(duration)
                                                If duration > SpX3 Then
                                                    CalUpTime += CStr(duration - SpX3)
                                                    .Emp_Attendence_Device_Cal2 = CStr(duration)
                                                End If
                                            End If
                                        End With
                                    Else
                                        Dim dtNew = New Emp_Attendence_Device
                                        With dtNew
                                            .Emp_ID = dg.Emp_ID
                                            If finNa = 0 Then

                                            Else
                                                .Attendence_Status_ID = finNa
                                            End If
                                            '.Attendence_Status_ID = If(finNa = 0, DBNull.Value, finNa) ' vvv.Attendence_Status_ID
                                            .Emp_Attendence_Device_Date = CType(aa.ToString("dd-MMM-yyyy").ToString, Date?)
                                            .Emp_Attendence_Device_Time = bb.ToString("HH:mm").ToString
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 9 Then
                                                dXA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 10 Then
                                                dXB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(dXA = "", "00:00", dXA))
                                                Dim ggg As DateTime = CDate(If(dXB = "", "00:00", dXB))
                                                Dim duration As Integer = DateDiff(DateInterval.Minute, fff, ggg)
                                                CalStatus += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 1 Then
                                                ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 2 Then
                                                ckB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(ckA = "", "00:00", ckA))
                                                Dim ggg As DateTime = CDate(If(ckB = "", "00:00", ckB))
                                                Dim duration As Integer = DateDiff(DateInterval.Minute, fff, ggg)
                                                CalInOut = duration
                                                .Emp_Attendence_Device_Cal2 = CalInOut
                                                'sssssssssssssssssssssssssssssssssssssssssssssss
                                                Dim dtNewX = New Emp_Attendence_Device
                                                With dtNewX
                                                    .Emp_ID = dg.Emp_ID
                                                    '.Attendence_Status_ID = vvv.Attendence_Status_ID
                                                    .Emp_Attendence_Device_Date = aa.ToString("dd-MMM-yyyy").ToString
                                                    .Emp_Attendence_Device_Time = "23:59" 'bb.ToString("HH:mm").ToString
                                                    'Dim TotMins As Integer = 194

                                                    'Dim Durationx As TimeSpan = New TimeSpan(0, ToCi, 0)
                                                    'Dim Hoursx = Durationx.Hours
                                                    'Dim Minutesx = Durationx.Minutes
                                                    'Dim Durationy As TimeSpan = New TimeSpan(0, Toti, 0)
                                                    'Dim Hoursy = Durationy.Hours
                                                    'Dim Minutesy = Durationy.Minutes
                                                    'Dim Togi As Integer = ToCi - Toti
                                                    'Dim Durationx As TimeSpan = TimeSpan.FromMinutes(ToCi)
                                                    'Dim Durationy As TimeSpan = TimeSpan.FromMinutes(Toti)
                                                    'Dim Durationz As TimeSpan = TimeSpan.FromMinutes(Togi)

                                                    '.Emp_Attendence_Device_Cal2 = Durationx.ToString("hh\:mm") ' Durationx.Hours & ":" & Durationx.Minutes
                                                    '.Emp_Attendence_Device_Cal1 = Durationy.ToString("hh\:mm")
                                                    '.Emp_Attendence_Device_Cal3 = Durationz.ToString("hh\:mm")
                                                End With
                                                db.Emp_Attendence_Device.Add(dtNewX)
                                                'MsgBox(Toti)
                                                CalStatus = 0
                                                'ssssssssssssssssssssssssssssssssssssssssssssssssssssss
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 7 Then
                                                lnA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 8 Then
                                                lnB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(lnA = "", "00:00", lnA))
                                                Dim ggg As DateTime = CDate(If(lnB = "", "00:00", lnB))
                                                Dim duration As Integer = DateDiff(DateInterval.Minute, fff, ggg)
                                                CalStatus += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 3 Then
                                                prA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 4 Then
                                                prB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(prA = "", "00:00", prA))
                                                Dim ggg As DateTime = CDate(If(prB = "", "00:00", prB))
                                                Dim duration As Integer = DateDiff(DateInterval.Minute, fff, ggg)
                                                CalStatus += duration
                                                .Emp_Attendence_Device_Cal1 = duration
                                            End If
                                            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                            If finNa = 5 Then
                                                shA = CStr(CDate(bb.ToString("HH:mm").ToString))
                                            End If
                                            If finNa = 6 Then
                                                shB = CStr(CDate(bb.ToString("HH:mm").ToString))
                                                Dim fff As DateTime = CDate(If(shA = "", "00:00", shA))
                                                Dim ggg As DateTime = CDate(If(shB = "", "00:00", shB))
                                                Dim duration As Integer = DateDiff(DateInterval.Minute, fff, ggg)
                                                CalStatus += duration
                                                .Emp_Attendence_Device_Cal1 = duration 'fff.ToString("HH:mm") & " to " & ggg.ToString("HH:mm") & "  " & shT.Hours & ":" & shT.Minutes
                                            End If
                                        End With
                                        db.Emp_Attendence_Device.Add(dtNew)
                                    End If
                                    db.SaveChanges()
                                End If
                            End If
                        Next
                    Next
                Next
                LoadAtt(FromDate.EditValue)

                MsgBox("Import Biometric Device to Plaza Database Successfull")

                ProgressBarControl1.Properties.Appearance.BackColor = Color.Green

                ProgressBarControl1.Update()
            End If
        End Using
    End Sub
    Dim sum As Double = 0
    Private Sub GridView1_CustomSummaryCalculate(sender As Object, e As DevExpress.Data.CustomSummaryEventArgs) Handles GridView1.CustomSummaryCalculate
        Dim view As GridView = TryCast(sender, GridView)
        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Emp_Attendence_Device_Cal1" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Emp_Attendence_Device_Cal1" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sum = 0
                    Case CustomSummaryProcess.Calculate
                        Dim strr As String = view.GetRowCellValue(e.RowHandle, "Emp_Attendence_Device_Cal1")
                        If Not strr = "" Then
                            If IsNumeric(strr) Then
                                'If shouldSum Then
                                sum += CDbl(e.FieldValue)
                            End If
                        End If
                    Case CustomSummaryProcess.Finalize
                        Dim hours As Integer = sum \ 60
                        Dim minutes As Integer = sum - (hours * 60)
                        Dim timeElapsed As String = "PHPL= " & CType(hours, String) & ":" & CType(minutes, String)
                        e.TotalValue = timeElapsed '" Hour-" & TimeSpan.FromMinutes(sum).Hours & " Min-" & TimeSpan.FromMinutes(sum).Minutes
                End Select
            End If
        End If
        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Emp_Attendence_Device_Cal2" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Emp_Attendence_Device_Cal2" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sum = 0
                    Case CustomSummaryProcess.Calculate
                        Dim strr As String = view.GetRowCellValue(e.RowHandle, "Emp_Attendence_Device_Cal2")
                        If Not strr = "" Then
                            If IsNumeric(strr) Then
                                'If shouldSum Then
                                sum += CDbl(e.FieldValue)
                            End If
                        End If
                    Case CustomSummaryProcess.Finalize
                        Dim hours As Integer = sum \ 60
                        Dim minutes As Integer = sum - (hours * 60)
                        Dim timeElapsed As String = "Sub= " & CType(hours, String) & ":" & CType(minutes, String)
                        e.TotalValue = timeElapsed '" Hour-" & TimeSpan.FromMinutes(sum).Hours & " Min-" & TimeSpan.FromMinutes(sum).Minutes
                End Select
            End If
        End If
        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Emp_Attendence_Device_Cal3" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Emp_Attendence_Device_Cal3" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sum = 0
                    Case CustomSummaryProcess.Calculate
                        Dim strr As String = view.GetRowCellValue(e.RowHandle, "Emp_Attendence_Device_Cal3")
                        If Not strr = "" Then
                            If IsNumeric(strr) Then
                                'If shouldSum Then
                                sum += CDbl(e.FieldValue)
                            End If
                        End If
                    Case CustomSummaryProcess.Finalize
                        Dim hours As Integer = sum \ 60
                        Dim minutes As Integer = sum - (hours * 60)
                        Dim timeElapsed As String = "InOut= " & CType(hours, String) & ":" & CType(minutes, String)
                        e.TotalValue = timeElapsed ' " Hour-" & TimeSpan.FromMinutes(sum).Hours & " Min-" & TimeSpan.FromMinutes(sum).Minutes
                End Select
            End If
        End If
        If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Emp_Attendence_Device_Cal4" Then
            Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
            If item.FieldName = "Emp_Attendence_Device_Cal4" Then
                Select Case e.SummaryProcess
                    Case CustomSummaryProcess.Start
                        sum = 0
                    Case CustomSummaryProcess.Calculate
                        Dim strr As String = view.GetRowCellValue(e.RowHandle, "Emp_Attendence_Device_Cal4")
                        If Not strr = "" Then
                            If IsNumeric(strr) Then
                                'If shouldSum Then
                                sum += CDbl(e.FieldValue)
                            End If
                        End If
                    Case CustomSummaryProcess.Finalize
                        Dim hours As Integer = sum \ 60
                        Dim minutes As Integer = sum - (hours * 60)
                        Dim timeElapsed As String = "DutyTime= " & CType(hours, String) & ":" & CType(minutes, String)
                        e.TotalValue = timeElapsed ' " Hour-" & TimeSpan.FromMinutes(sum).Hours & " Min-" & TimeSpan.FromMinutes(sum).Minutes
                End Select
            End If
        End If

    End Sub

    'Public Sub LoadTimeAdd()
    '    Using db As New CsmdBioAttendenceEntities
    '        Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Cal1 = 1 And a.Emp_Attendence_Device_Cal2 = 2 And a.Emp_Attendence_Device_Cal3 = 3 And a.Emp_Attendence_Device_Cal4 = 4 And a.Emp_Attendence_Device_Cal5 = 5 Order By a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time
    '                 Select New With {a}).ToList
    '    End Using
    'End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs)
        'Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
        'Dim view As GridView = TryCast(sender, GridView)
        'Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
        'If info.InRow OrElse info.InRowCell Then
        '    'Dim colCaption As String = If(info.Column Is Nothing, "N/A", info.Column.GetCaption())
        '    'MessageBox.Show(String.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption))
        '    intEmpID = GridView1.GetRowCellValue(info.RowHandle, "Emp_ID")
        '    intDate = GridView1.GetRowCellValue(info.RowHandle, "Emp_Attendence_Device_Date")
        '    frmAttSingleEdit.ShowDialog()
        '    'PropertyGridControl1.SelectedObject = GridView1.FocusedColumn
        '    'PropertyGridControl1 .
        'End If
    End Sub
    Private Sub GridView1_FocusedColumnChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs)
        'If BarButtonItem27.Down = False Then
        '    ProType = "Grid"
        'PropertyGridControl1.SelectedObject = e.FocusedColumn
        'PropertyGridControl1.RetrieveFields()
        'Else
        'ProType = ""
        ''PropertyGridControl1.SelectedObject = GridView1
        ''PropertyGridControl1.RetrieveFields()
        'End If
    End Sub
    Private Sub GridView1_EditFormShowing(sender As Object, e As DevExpress.XtraGrid.Views.Grid.EditFormShowingEventArgs)
        'Dim view As GridView = TryCast(sender, GridView)
        'e.Allow = view.IsNewItemRow(e.RowHandle)
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If e.Column.FieldName = "Attendence_Status_ID" Then
            Select Case e.CellValue
                Case 1 '"RT-Check In"
                    e.Appearance.BackColor = Color.Aqua
                    e.Appearance.BackColor2 = Color.Bisque
                Case 2 '"LT-Check Out"
                    e.Appearance.BackColor = Color.Aqua
                    e.Appearance.BackColor2 = Color.Bisque
                Case 3 '"RI-Prayer A"
                    e.Appearance.BackColor = Color.Lime
                    e.Appearance.BackColor2 = Color.RosyBrown
                Case 4 '"LI-Prayer B"
                    e.Appearance.BackColor = Color.Lime
                    e.Appearance.BackColor2 = Color.RosyBrown
                Case 5 '"RM-Short Leave A"
                    e.Appearance.BackColor = Color.Orchid
                    e.Appearance.BackColor2 = Color.OrangeRed
                Case 6 '"LM-Short Leave B"
                    e.Appearance.BackColor = Color.Orchid
                    e.Appearance.BackColor2 = Color.OrangeRed

                Case 7 '"RR-Lunch A"
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.RosyBrown
                Case 8 '"LR-Lunch B"
                    e.Appearance.BackColor = Color.Yellow
                    e.Appearance.BackColor2 = Color.RosyBrown
                Case 9 '"RP-Private A"
                    e.Appearance.BackColor = Color.Wheat
                    e.Appearance.BackColor2 = Color.Tomato
                Case 10 '"LP-Private B"
                    e.Appearance.BackColor = Color.Tomato
                    e.Appearance.BackColor2 = Color.Wheat
                Case Else
                    e.Appearance.BackColor = Color.Pink
                    e.Appearance.BackColor2 = Color.LightPink
                    e.Appearance.FontStyleDelta = FontStyle.Bold
                    e.Appearance.TextOptions.HAlignment = HorzAlignment.Far
                    e.Appearance.FontSizeDelta = 2
            End Select
        End If
        If e.Column.FieldName = "Emp_Attendence_Device_Time" Then
            Dim val As Integer = GridView1.GetRowCellValue(e.RowHandle, "Attendence_Status_ID")
            Select Case val
                Case 1 '"RT-Check In"
                    e.Appearance.BackColor = Color.Bisque
                    e.Appearance.BackColor2 = Color.Aqua
                Case 2 '"LT-Check Out"
                    e.Appearance.BackColor = Color.Bisque
                    e.Appearance.BackColor2 = Color.Aqua
                Case 3 '"RI-Prayer A"
                    e.Appearance.BackColor = Color.RosyBrown
                    e.Appearance.BackColor2 = Color.Lime
                Case 4 '"LI-Prayer B"
                    e.Appearance.BackColor = Color.RosyBrown
                    e.Appearance.BackColor2 = Color.Lime
                Case 5 '"RM-Short Leave A"
                    e.Appearance.BackColor = Color.OrangeRed
                    e.Appearance.BackColor2 = Color.Orchid
                Case 6 '"LM-Short Leave B"
                    e.Appearance.BackColor = Color.OrangeRed
                    e.Appearance.BackColor2 = Color.Orchid

                Case 7 '"RR-Lunch A"
                    e.Appearance.BackColor = Color.RosyBrown
                    e.Appearance.BackColor2 = Color.Yellow
                Case 8 '"LR-Lunch B"
                    e.Appearance.BackColor = Color.RosyBrown
                    e.Appearance.BackColor2 = Color.Yellow
                Case 9 '"RP-Private A"
                    e.Appearance.BackColor = Color.Tomato
                    e.Appearance.BackColor2 = Color.Wheat
                Case 10 '"LP-Private B"
                    e.Appearance.BackColor = Color.Wheat
                    e.Appearance.BackColor2 = Color.Tomato
            End Select
            Dim dis As String = GridView1.GetRowCellDisplayText(e.RowHandle, "Attendence_Status_ID")
            If dis = "Total= " Then
                e.Appearance.BackColor = Color.Pink
                e.Appearance.BackColor2 = Color.LightPink
                e.Appearance.ForeColor = Color.Pink
                e.Appearance.FontStyleDelta = FontStyle.Bold
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far
                e.Appearance.FontSizeDelta = 2
            End If
        End If
        If e.Column.FieldName = "Emp_Attendence_Device_Cal2" Then
            Dim val As Integer = GridView1.GetRowCellValue(e.RowHandle, "Attendence_Status_ID")
            Select Case val
                Case 1 '"RT-Check In"
                    'e.Appearance.BackColor = Color.Bisque
                    'e.Appearance.BackColor2 = Color.Aqua
                Case 2 '"LT-Check Out"
                    e.Appearance.BackColor = Color.Bisque
                    e.Appearance.BackColor2 = Color.Aqua
                    'Case 3 '"RI-Prayer A"
                    'e.Appearance.BackColor = Color.RosyBrown
                    'e.Appearance.BackColor2 = Color.Lime
                    'Case 4 '"LI-Prayer B"
                    '    e.Appearance.BackColor = Color.RosyBrown
                    '    e.Appearance.BackColor2 = Color.Lime
                    'Case 5 '"RM-Short Leave A"
                    '    'e.Appearance.BackColor = Color.OrangeRed
                    '    'e.Appearance.BackColor2 = Color.Orchid
                    'Case 6 '"LM-Short Leave B"
                    '    e.Appearance.BackColor = Color.OrangeRed
                    '    e.Appearance.BackColor2 = Color.Orchid

                    'Case 7 '"RR-Lunch A"
                    '    'e.Appearance.BackColor = Color.RosyBrown
                    '    'e.Appearance.BackColor2 = Color.Yellow
                    'Case 8 '"LR-Lunch B"
                    '    e.Appearance.BackColor = Color.RosyBrown
                    '    e.Appearance.BackColor2 = Color.Yellow
                    'Case 9 '"RP-Private A"
                    '    'e.Appearance.BackColor = Color.Tomato
                    '    'e.Appearance.BackColor2 = Color.MediumPurple
                    'Case 10 '"LP-Private B"
                    '    e.Appearance.BackColor = Color.MediumPurple
                    '    e.Appearance.BackColor2 = Color.Tomato
                    'Case Else
                    '    e.Appearance.BackColor = Color.Pink
                    '    e.Appearance.BackColor2 = Color.LightPink
            End Select
            Dim dis As String = GridView1.GetRowCellDisplayText(e.RowHandle, "Attendence_Status_ID")
            If dis = "Total= " Then
                e.Appearance.BackColor = Color.Pink
                e.Appearance.BackColor2 = Color.LightPink
                e.Appearance.FontStyleDelta = FontStyle.Bold
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far
                e.Appearance.FontSizeDelta = 2
            End If
        End If

        If e.Column.FieldName = "Emp_Attendence_Device_Cal1" Then
            'If e.CellValue IsNot Nothing Then
            '    e.Appearance.BackColor = Color.Lime
            '    e.Appearance.BackColor2 = Color.RosyBrown
            'End If
            Dim val As Integer = GridView1.GetRowCellValue(e.RowHandle, "Attendence_Status_ID")
            Select Case val
                Case 1 '"RT-Check In"
                    'e.Appearance.BackColor = Color.Bisque
                    'e.Appearance.BackColor2 = Color.Aqua
                Case 2 '"LT-Check Out"
                    'e.Appearance.BackColor = Color.Bisque
                    'e.Appearance.BackColor2 = Color.Aqua
                Case 3 '"RI-Prayer A"
                    'e.Appearance.BackColor = Color.RosyBrown
                    'e.Appearance.BackColor2 = Color.Lime
                Case 4 '"LI-Prayer B"
                    e.Appearance.BackColor = Color.RosyBrown
                    e.Appearance.BackColor2 = Color.Lime
                Case 5 '"RM-Short Leave A"
                    'e.Appearance.BackColor = Color.OrangeRed
                    'e.Appearance.BackColor2 = Color.Orchid
                Case 6 '"LM-Short Leave B"
                    e.Appearance.BackColor = Color.OrangeRed
                    e.Appearance.BackColor2 = Color.Orchid

                Case 7 '"RR-Lunch A"
                    'e.Appearance.BackColor = Color.RosyBrown
                    'e.Appearance.BackColor2 = Color.Yellow
                Case 8 '"LR-Lunch B"
                    e.Appearance.BackColor = Color.RosyBrown
                    e.Appearance.BackColor2 = Color.Yellow
                Case 9 '"RP-Private A"
                    'e.Appearance.BackColor = Color.Tomato
                    'e.Appearance.BackColor2 = Color.MediumPurple
                Case 10 '"LP-Private B"
                    e.Appearance.BackColor = Color.Tomato
                    e.Appearance.BackColor2 = Color.Wheat
                    'Case Else
                    '    e.Appearance.BackColor = Color.Pink
                    '    e.Appearance.BackColor2 = Color.LightPink
            End Select
            Dim dis As String = GridView1.GetRowCellDisplayText(e.RowHandle, "Attendence_Status_ID")
            If dis = "Total= " Then
                e.Appearance.BackColor = Color.Pink
                e.Appearance.BackColor2 = Color.LightPink
                e.Appearance.FontStyleDelta = FontStyle.Bold
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far
                e.Appearance.FontSizeDelta = 2
            End If
        End If
        If e.Column.FieldName = "Emp_Attendence_Device_Cal3" Then
            Dim dis As String = GridView1.GetRowCellDisplayText(e.RowHandle, "Attendence_Status_ID")
            If dis = "Total= " Then
                e.Appearance.BackColor = Color.Pink
                e.Appearance.BackColor2 = Color.LightPink
                e.Appearance.FontStyleDelta = FontStyle.Bold
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far
                e.Appearance.FontSizeDelta = 2
            End If
        End If
        If e.Column.FieldName = "Emp_Attendence_Device_Cal4" Then
            Dim val As Integer = GridView1.GetRowCellValue(e.RowHandle, "Attendence_Status_ID")
            If Not e.CellValue = "" Then
                Select Case val
                    Case 1 '"RT-Check In"
                        e.Appearance.BackColor = Color.Aqua
                        e.Appearance.BackColor2 = Color.Bisque
                    Case 2 '"LT-Check Out"
                        e.Appearance.BackColor = Color.Aqua
                        e.Appearance.BackColor2 = Color.Bisque
                    Case 3 '"RI-Prayer A"
                        'e.Appearance.BackColor = Color.RosyBrown
                        'e.Appearance.BackColor2 = Color.Lime
                    Case 4 '"LI-Prayer B"
                        e.Appearance.BackColor = Color.Lime
                        e.Appearance.BackColor2 = Color.RosyBrown
                    Case 5 '"RM-Short Leave A"
                        'e.Appearance.BackColor = Color.OrangeRed
                        'e.Appearance.BackColor2 = Color.Orchid
                    Case 6 '"LM-Short Leave B"
                        e.Appearance.BackColor = Color.Orchid
                        e.Appearance.BackColor2 = Color.OrangeRed

                    Case 7 '"RR-Lunch A"
                        'e.Appearance.BackColor = Color.RosyBrown
                        'e.Appearance.BackColor2 = Color.Yellow
                    Case 8 '"LR-Lunch B"
                        e.Appearance.BackColor = Color.Yellow
                        e.Appearance.BackColor2 = Color.RosyBrown
                    Case 9 '"RP-Private A"
                        'e.Appearance.BackColor = Color.Tomato
                        'e.Appearance.BackColor2 = Color.MediumPurple
                    Case 10 '"LP-Private B"
                        e.Appearance.BackColor = Color.Wheat
                        e.Appearance.BackColor2 = Color.Tomato
                        'Case Else
                        '    e.Appearance.BackColor = Color.Pink
                        '    e.Appearance.BackColor2 = Color.LightPink
                End Select
            End If
        End If
        If e.Column.FieldName = "Emp_Attendence_Device_Date" Then
            Dim dis As String = GridView1.GetRowCellDisplayText(e.RowHandle, "Attendence_Status_ID")
            If dis = "Total= " Then
                e.Appearance.BackColor = Color.Pink
                e.Appearance.BackColor2 = Color.LightPink
                e.Appearance.FontStyleDelta = FontStyle.Bold
                e.Appearance.TextOptions.HAlignment = HorzAlignment.Far
                e.Appearance.FontSizeDelta = 2
            End If
        End If
        'If e.Column.FieldName = "Emp_Attendence_Device_Cal4" Then
        '    Dim dis As String = GridView1.GetRowCellDisplayText(e.RowHandle, "Attendence_Status_ID")
        '    If dis = "Total= " Then
        '        e.Appearance.BackColor = Color.Pink
        '        e.Appearance.BackColor2 = Color.LightPink
        '        e.Appearance.FontStyleDelta = FontStyle.Bold
        '    End If
        'End If
        'If e.Column.FieldName = "Emp_Attendence_Device_Cal5" Then
        '    If e.CellValue IsNot Nothing Then
        '        e.Appearance.BackColor = Color.Tomato
        '        e.Appearance.BackColor2 = Color.MediumPurple
        '    End If
        'End If
    End Sub

    'Private Sub gridView1_CustomColumnSort(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs)
    '    If e.Column.FieldName = "Emp_Attendence_Device_Time" Then
    '        Dim val1 As Integer = Convert.ToInt32(Convert.ToString(e.Value1).Remove(0, 2)) Mod 10
    '        Dim val2 As Integer = Convert.ToInt32(Convert.ToString(e.Value2).Remove(0, 2)) Mod 10

    '        e.Result = System.Collections.Comparer.Default.Compare(val1, val2)
    '        e.Handled = True
    '    End If
    'End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarEditItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarEditItem1.ItemClick

    End Sub

    Private Sub RepositoryItemButtonEdit2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2.ButtonClick
        Select Case e.Button.Index
            Case 0
                'Dim sd As New OpenFileDialog()
                'sd.Filter = "Excel Files(.xls)|*.xls"
                'sd.Title = "Load Attendence File"
                'If sd.ShowDialog() = DialogResult.OK Then
                'Dim txt As ButtonEdit = TryCast(sender, ButtonEdit)
                LoadExcel()

                Dim fffff As String = "C:\Users\" & Environment.UserName & "\Documents\CsmdSoft.xls"
                BarEditItem1.EditValue = fffff ' sd.FileName
                'MsgBox(System.IO.Path.GetFileNameWithoutExtension(sd.FileName))
                LoadImportDate(fffff, System.IO.Path.GetFileNameWithoutExtension(fffff))
                'LoadImportDate(sd.FileName, System.IO.Path.GetFileNameWithoutExtension(sd.FileName))
                'End If
        End Select
    End Sub
    Private Sub LoadExcel()
        Try
            Dim excel As Microsoft.Office.Interop.Excel.Application
            Dim wb As Microsoft.Office.Interop.Excel.Workbook
            'Dim xlapp As Object = CreateObject("Excel.Application")
            'Dim xlWorkbook As Object = xlapp.WorkBooks.Open("C:\Users\" & Environment.UserName & "\Documents\Attt.xls")
            'Try

            excel = New Microsoft.Office.Interop.Excel.Application
            wb = excel.Workbooks.Open("C:\Users\" & Environment.UserName & "\Documents\AttFromDevice.xls")
            ''excel.Visible = True
            ''wb.Activate()
            Dim WS As Microsoft.Office.Interop.Excel.Worksheet = wb.Sheets("AttFromDevice")
            WS.Name = "CsmdSoft"

            '   Catch ex As COMException
            '	MessageBox.Show("Error accessing Excel: " + ex.ToString())
            wb.SaveAs("C:\Users\" & Environment.UserName & "\Documents\CsmdSoft.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, True, False, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Microsoft.Office.Interop.Excel.XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing)
            'Catch ex As Exception
            '    MessageBox.Show("Error: " + ex.ToString())
            wb.Close()
            excel.Quit()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "CsmdSoft")
        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        LoadAtt(FromDate.EditValue)
    End Sub
    Public Sub LoadAtt(FromDat As DateTime)
        Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Date.Value.Month = FromDat.Month And a.Emp_Attendence_Device_Date.Value.Year = FromDat.Year
                  Order By a.Employee.Emp_Name
                  Select New With {.Emp_Attendence_Device_ID = a.Emp_Attendence_Device_ID,
                                   .Emp_ID = a.Emp_ID,
                                   .Emp_Attendence_Device_Date = a.Emp_Attendence_Device_Date,
                                   .Emp_Attendence_Device_Time = a.Emp_Attendence_Device_Time,
                                   .Attendence_Status_ID = a.Attendence_Status_ID,
                                   .Emp_Attendence_Device_Cal1 = a.Emp_Attendence_Device_Cal1,
                                   .Emp_Attendence_Device_Cal2 = a.Emp_Attendence_Device_Cal2,
                                   .Emp_Attendence_Device_Cal3 = a.Emp_Attendence_Device_Cal3,
                                   .Emp_Attendence_Device_Cal4 = a.Emp_Attendence_Device_Cal4,
                                   .Emp_Attendence_Device_Cal5 = a.Emp_Attendence_Device_Cal5}).ToList
        If dt.Count > 0 Then
            GridControl1.DataSource = dt
            GridView1.Columns("Emp_Attendence_Device_Date").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            GridView1.Columns("Emp_Attendence_Device_Time").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            GridView1.FocusedRowHandle = (intr)
            'GridView1.Columns("Emp_Attendence_Device_Cal3").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, "6060")
        Else
            GridControl1.DataSource = Nothing
        End If
    End Sub
    Public Sub LoadAtt(Emp As Integer, FromDat As DateTime)
        Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_ID = Emp And a.Emp_Attendence_Device_Date.Value.Month = FromDat.Month And a.Emp_Attendence_Device_Date.Value.Year = FromDat.Year
                  Order By a.Employee.Emp_Name
                  Select New With {a.Emp_Attendence_Device_ID,
                                   a.Emp_ID, a.Emp_Attendence_Device_Date,
                                   a.Emp_Attendence_Device_Time,
                                   a.Attendence_Status_ID,
                                   a.Emp_Attendence_Device_Cal1,
                                   a.Emp_Attendence_Device_Cal2,
                                   a.Emp_Attendence_Device_Cal3,
                                   a.Emp_Attendence_Device_Cal4,
                                   a.Emp_Attendence_Device_Cal5}).ToList
        If dt.Count > 0 Then
            GridControl1.DataSource = dt
            GridView1.Columns("Emp_Attendence_Device_Date").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            GridView1.Columns("Emp_Attendence_Device_Time").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
            GridView1.FocusedRowHandle = (intr)
            'GridView1.Columns("Emp_Attendence_Device_Cal3").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, "5050")
        Else
            GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub GridView1_RowUpdated(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectEventArgs) Handles GridView1.RowUpdated
        db.SaveChanges()
    End Sub
    Dim intr As Integer = 0
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        'GridView1.AddNewRow()
        'this.grView.AddNewRow();
        'GridView1.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
        ''GridView1.TopRowIndex = GridView1.RowCount - 1
        'GridView1.ShowInplaceEditForm()
        GridView1.FocusedRowHandle = (intr)
        'MsgBox(intr)
    End Sub

    'Public Sub LoadAttendence()
    '    Using db As New CsmdBioAttendenceEntities

    '        Dim emp = (From a In db.Employees Select a).ToList
    '        If emp.Count > 0 Then
    '            For Each emps In emp
    '                Dim Att = (From a In db.Attendence_Status Select a).ToList
    '                If Att.Count > 0 Then
    '                    For Each atts In Att
    '                        Dim dt = (From a In db.Emp_Attendence_Device
    '                         Where a.Emp_ID = emps.Emp_ID And a.Attendence_Status_ID = atts.Attendence_Status_ID And
    '                         a.Emp_Attendence_Device_Date.Value.Month = FromDat.Month And a.Emp_Attendence_Device_Date.Value.Year = FromDat.Year
    '                         Select New With {a.Emp_Attendence_Device_Time,
    '                         a.Emp_Attendence_Device_Cal1,
    '                         a.Emp_Attendence_Device_Cal2,
    '                         a.Emp_Attendence_Device_Cal3,
    '                         a.Emp_Attendence_Device_Cal4,
    '                         a.Emp_Attendence_Device_Cal5,
    '                         a.Emp_Attendence_Device_Cal6,
    '                         a.Emp_Attendence_Device_Cal7}).FirstOrDefault


    '                        If dt IsNot Nothing Then

    '                        Else

    '                        End If
    '                    Next
    '                End If
    '            Next
    '        End If




    '    End Using
    'End Sub

    'Public Function GetAttendence() As String
    '    Using db As New CsmdBioAttendenceEntities
    '        Dim Tim As String = ""

    '        Dim dt = (From a In db.Emp_Attendence_Device Select a).ToList
    '        If dt.Count > 0 Then

    '        Else

    '        End If

    '        Return Tim
    '    End Using
    'End Function
    'Public Sub LoadAttendence()
    '    Using db As New CsmdBioAttendenceEntities
    '        Dim dt = (From a In db.Emp_Attendence_Device Select a).ToList
    '        If dt.Count > 0 Then
    '            For Each dts In dt

    '            Next
    '        End If
    '    End Using
    'End Sub
    'Public Function GetDayTime() As String
    '    Using db As New CsmdBioAttendenceEntities
    '        Dim tim As String = ""
    '        Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_ID = 1 And a.Emp_Attendence_Device_Date.Value.Month = Today.Month And a.Emp_Attendence_Device_Date.Value.Year = Today.Year Select a).FirstOrDefault
    '        If dt IsNot Nothing Then

    '        Else

    '        End If
    '        Return tim
    '    End Using
    'End Function


    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        GridView1.OptionsBehavior.Editable = True
    End Sub

    Private Sub popAddNew_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles popAddNew.ItemClick
        frmAttReporstEdit.ShowDialog()
    End Sub

    Private Sub popEdit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles popEdit.ItemClick
        'GridView1.OptionsBehavior.Editable = True
    End Sub

    Private Sub popDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles popDelete.ItemClick
        'GridView1.DeleteSelectedRows()
        Try
            Using db As New CsmdBioAttendenceEntities
                Dim intDT = (From a In intList Select a).ToList
                If intDT.Count > 0 Then
                    For Each intD In intDT
                        Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = intD Select a).FirstOrDefault
                        If dt IsNot Nothing Then
                            db.Emp_Attendence_Device.Remove(dt)
                        End If


                    Next
                    db.SaveChanges()
                    LoadAtt(intEmpID, FromDate.EditValue)
                    GridView1.FocusedRowHandle = (intr - 1)
                End If
            End Using
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        If e.Button.IsRight Then
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As GridView = TryCast(sender, GridView)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                intEmpID = GridView1.GetRowCellValue(info.RowHandle, "Emp_ID")
                'Dim colCaption As String = If(info.Column Is Nothing, "N/A", info.Column.GetCaption())
                'MessageBox.Show(String.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption))
                intPngID = GridView1.GetRowCellValue(info.RowHandle, "Emp_Attendence_Device_ID")
                intr = info.RowHandle
                PopupMenu1.ShowPopup(MousePosition)
            End If

            'intPngID = GridView1.GetFocusedRowCellValue("Emp_Attendence_Device_ID")
        End If
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        'GridView1.OptionsBehavior.Editable = False
        intr = e.RowHandle

    End Sub

    Private Sub ProgressBarControl1_CustomDisplayText(sender As Object, e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs) Handles ProgressBarControl1.CustomDisplayText
        Dim val As String = e.Value.ToString()
        e.DisplayText = "The progress is: " & val
    End Sub

    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        GridView1.ShowRibbonPrintPreview()
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs)
        'Dim val As Integer = GridView1.GetRowCellValue(e.RowHandle, "Attendence_Status_ID")
        'Select Case val
        '    Case 1 '"RT-Check In"
        '        'e.Appearance.BackColor = Color.Aqua
        '        'e.Appearance.BackColor2 = Color.Bisque
        '    Case 2 '"LT-Check Out"
        '        e.Appearance.BackColor = Color.Aqua
        '        e.Appearance.BackColor2 = Color.Bisque
        '    Case 3 '"RI-Prayer A"
        '        'e.Appearance.BackColor = Color.Lime
        '        'e.Appearance.BackColor2 = Color.RosyBrown
        '    Case 4 '"LI-Prayer B"
        '        e.Appearance.BackColor = Color.Lime
        '        e.Appearance.BackColor2 = Color.RosyBrown
        '    Case 5 '"RM-Short Leave A"
        '        'e.Appearance.BackColor = Color.Orchid
        '        'e.Appearance.BackColor2 = Color.OrangeRed
        '    Case 6 '"LM-Short Leave B"
        '        e.Appearance.BackColor = Color.Orchid
        '        e.Appearance.BackColor2 = Color.OrangeRed

        '    Case 7 '"RR-Lunch A"
        '        'e.Appearance.BackColor = Color.Yellow
        '        'e.Appearance.BackColor2 = Color.RosyBrown
        '    Case 8 '"LR-Lunch B"
        '        e.Appearance.BackColor = Color.Yellow
        '        e.Appearance.BackColor2 = Color.RosyBrown
        '    Case 9 '"RP-Private A"
        '        'e.Appearance.BackColor = Color.MediumPurple
        '        'e.Appearance.BackColor2 = Color.Tomato
        '    Case 10 '"LP-Private B"
        '        e.Appearance.BackColor = Color.Tomato
        '        e.Appearance.BackColor2 = Color.MediumPurple
        'End Select
        ''End If
        'e.HighPriority = True
    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub gridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Call ShowSelection()
    End Sub

    Private Sub ShowSelection()
        Try
            Dim RowCount As Integer = GridView1.SelectedRowsCount - 1
            ReDim intList(RowCount)
            'ReDim intList2
            For i As Integer = 0 To RowCount
                Dim row As Integer = (GridView1.GetSelectedRows()(i))
                Dim obj As Object = TryCast(GridView1.GetRowCellValue(row, "Emp_Attendence_Device_ID"), Object)
                If obj Is Nothing Then
                    Return
                End If
                intList(i) = obj
                'intList2 = GridView1.GetRowCellValue(row, "RB_Pay_Detail_IssueDate")
            Next i
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        LoadImportDateCalcu()
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        DeleteAllEmpty()
    End Sub

    Public Sub DeleteAllEmpty()
        Using db As New CsmdBioAttendenceEntities
            Dim FromDat As DateTime = FromDate.EditValue
            Dim k As Integer
            Dim dt = (From a In db.Emp_Attendence_Device Where String.IsNullOrEmpty(a.Attendence_Status_ID) And a.Emp_Attendence_Device_Date.Value.Month = FromDat.Month And a.Emp_Attendence_Device_Date.Value.Year = FromDat.Year Select a).ToList
            If dt.Count > 0 Then
                ProgressBarControl1.Properties.Maximum = dt.Count - 1
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Red
                ProgressBarControl1.Position = 0
                ProgressBarControl1.Update()

                For Each dts In dt
                    ProgressBarControl1.Position = k

                    ProgressBarControl1.Update()
                    Me.Text = "Deleting Process on Record No. " & k
                    k += 1

                    db.Emp_Attendence_Device.Remove(dts)
                Next
                db.SaveChanges()
                'UpdateAllSummaray()
            End If
        End Using
    End Sub
    Public Sub UpdateAllSummaray()
        Using db As New CsmdBioAttendenceEntities
            Dim FromDat As DateTime = FromDate.EditValue
            Dim k As Integer
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Date.Value.Month = FromDat.Month And a.Emp_Attendence_Device_Date.Value.Year = FromDat.Year Select a).ToList
            If dt.Count > 0 Then
                ProgressBarControl1.Properties.Maximum = dt.Count - 1
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Purple
                ProgressBarControl1.Position = 0
                ProgressBarControl1.Update()

                For Each dts In dt
                    ProgressBarControl1.Position = k

                    ProgressBarControl1.Update()
                    Me.Text = "Deleting Process on Record No. " & k
                    k += 1

                    dts.Emp_Attendence_Device_Cal1 = ""
                    dts.Emp_Attendence_Device_Cal2 = ""
                    dts.Emp_Attendence_Device_Cal3 = ""
                    dts.Emp_Attendence_Device_Cal4 = ""
                Next
                db.SaveChanges()

            End If
        End Using
    End Sub
    'Private Sub BarEditItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FromDate.ItemClick

    'End Sub

    Private Sub RepositoryItemDateEdit2_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemDateEdit2.ButtonClick
        Select Case e.Button.Index
            Case 1
                FromDate.EditValue = DateTime.Parse(FromDate.EditValue).AddMonths(-1)
            Case 2
                FromDate.EditValue = DateTime.Parse(FromDate.EditValue).AddMonths(1)

        End Select
    End Sub

    Private Sub RepositoryItemDateEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit2.EditValueChanged
        Load_Att_Setting()
        LoadAtt(FromDate.EditValue)
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        intEmpID = GridView2.GetFocusedRowCellValue("ID")
        intAttDate = FromDate.EditValue
        Dim frm As New frmAttCalculations
        frm.ShowDialog()
    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView2.RowClick
        'Dim IDs As Integer = GridView2.GetFocusedRowCellValue("ID")
        'EmpIDs =
        intEmpID = GridView2.GetFocusedRowCellValue("ID")
        LoadAtt(intEmpID, FromDate.EditValue)
    End Sub
    ' ''Private Sub gridView1_CustomDrawFooterCell(ByVal sender As Object, ByVal e As FooterCellCustomDrawEventArgs) Handles GridView1.CustomDrawFooterCell
    ' ''    If ReflectionHelper.GetMemberDescriptor(View.ObjectType, e.Column.FieldName).MemberType = GetType(TimeSpan) Then
    ' ''        Dim gridView As GridView = (CType(sender, GridView))
    ' ''        Dim totalTime As TimeSpan = New TimeSpan()

    ' ''        For i As Integer = 0 To gridView.DataRowCount - 1
    ' ''            Dim temp As TimeSpan = TimeSpan.Parse(gridView.GetRowCellValue(i, e.Column.FieldName).ToString())
    ' ''            totalTime = New TimeSpan(totalTime.Ticks + temp.Ticks)
    ' ''        Next

    ' ''        If e.Column.SummaryItem.SummaryType = SummaryItemType.Sum Then
    ' ''            e.Info.DisplayText = "Sum: " & totalTime
    ' ''        End If

    ' ''        If e.Column.SummaryItem.SummaryType = SummaryItemType.Average Then
    ' ''            totalTime = New TimeSpan(totalTime.Ticks / gridView.DataRowCount)
    ' ''            e.Info.DisplayText = "Average: " & totalTime
    ' ''        End If
    ' ''    End If
    ' ''End Sub
    Private Sub Load_Att_Setting()
        Using db As New CsmdBioAttendenceEntities
            Dim datX As Date = CDate(FromDate.EditValue)
            Dim dt = (From a In db.Emp_Att_Set Where a.Emp_Att_Set_Date.Value.Month = datX.Month And a.Emp_Att_Set_Date.Value.Year = datX.Year Select a).FirstOrDefault
            If dt IsNot Nothing Then
                With dt
                    DutyOn.EditValue = .Emp_Att_Set_DutyOn
                    DutyOff.EditValue = .Emp_Att_Set_DutyOff
                    DutyFri.EditValue = .Emp_Att_Set_FridayOff
                    Sp1.EditValue = .Emp_Att_Set_1
                    Sp2.EditValue = .Emp_Att_Set_2
                    Sp3.EditValue = .Emp_Att_Set_3
                    Sp4.EditValue = .Emp_Att_Set_4
                    Sp5.EditValue = .Emp_Att_Set_5
                    intSp4 = .Emp_Att_Set_4
                End With

            Else

            End If
        End Using
    End Sub

    Private Sub SaveUpdate_Att_Setting()
        Using db As New CsmdBioAttendenceEntities
            Dim DutyOnX As DateTime = CDate(CDate(DutyOn.EditValue).ToString("HH:mm"))
            Dim DutyOffX As DateTime = CDate(CDate(DutyOff.EditValue).ToString("HH:mm"))
            Dim DutyFriX As DateTime = CDate(CDate(DutyFri.EditValue).ToString("HH:mm"))
            Dim datX As Date = CDate(FromDate.EditValue)
            Dim dt = (From a In db.Emp_Att_Set Where a.Emp_Att_Set_Date.Value.Month = datX.Month And a.Emp_Att_Set_Date.Value.Year = datX.Year Select a).FirstOrDefault
            If dt IsNot Nothing Then
                With dt
                    .Emp_Att_Set_DutyOn = DutyOnX.ToString("HH:mm")
                    .Emp_Att_Set_DutyOff = DutyOffX.ToString("HH:mm")
                    .Emp_Att_Set_FridayOff = DutyFriX.ToString("HH:mm")
                    .Emp_Att_Set_1 = Sp1.EditValue
                    .Emp_Att_Set_2 = Sp2.EditValue
                    .Emp_Att_Set_3 = Sp3.EditValue
                    .Emp_Att_Set_4 = Sp4.EditValue
                    .Emp_Att_Set_5 = Sp5.EditValue
                    .Emp_Att_Set_Date = CDate(FromDate.EditValue)
                End With
                db.SaveChanges()
            Else
                Dim dtNew = New Emp_Att_Set
                With dtNew
                    .Emp_Att_Set_DutyOn = DutyOnX.ToString("HH:mm")
                    .Emp_Att_Set_DutyOff = DutyOffX.ToString("HH:mm")
                    .Emp_Att_Set_FridayOff = DutyFriX.ToString("HH:mm")
                    .Emp_Att_Set_1 = Sp1.EditValue
                    .Emp_Att_Set_2 = Sp2.EditValue
                    .Emp_Att_Set_3 = Sp3.EditValue
                    .Emp_Att_Set_4 = Sp4.EditValue
                    .Emp_Att_Set_5 = Sp5.EditValue
                    .Emp_Att_Set_Date = CDate(FromDate.EditValue)
                End With
                db.Emp_Att_Set.Add(dtNew)
                db.SaveChanges()
            End If
            Call Load_Att_Setting()
        End Using
    End Sub



    Private Sub Att_Settings(sender As Object, e As EventArgs) Handles DutyOn.EditValueChanged, DutyOff.EditValueChanged, DutyFri.EditValueChanged, Sp1.EditValueChanged, Sp2.EditValueChanged, Sp3.EditValueChanged, Sp4.EditValueChanged, Sp5.EditValueChanged
        SaveUpdate_Att_Setting()
    End Sub

    Private Sub BarButtonItem5_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        GridView1.ActiveFilterString = "[Attendence_Status_ID] = '1' Or [Attendence_Status_ID] = '2'"
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        GridView1.ActiveFilterString = "[Attendence_Status_ID] = '3' Or [Attendence_Status_ID] = '4'"
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        GridView1.ActiveFilterString = "[Attendence_Status_ID] = '5' Or [Attendence_Status_ID] = '6'"
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        GridView1.ActiveFilterString = "[Attendence_Status_ID] = '7' Or [Attendence_Status_ID] = '8'"
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        GridView1.ActiveFilterString = "[Attendence_Status_ID] = '9' Or [Attendence_Status_ID] = '10'"
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        GridView1.ClearColumnsFilter()
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        frmAttPayments.ShowDialog()
    End Sub

  

    Private Sub Sp4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Sp4.ItemClick

    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        'GridView1.OptionsView.AllowCellMerge = False
        'GridView1.OptionsSelection.MultiSelect = True
        'GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
    End Sub

    Private Sub GridControl1_Click_2(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub GridControl4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BarEditItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarEditItem2.ItemClick

    End Sub

    Private Sub RepositoryItemCheckEdit2_CheckedChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.CheckedChanged
        Dim chk As CheckEdit = TryCast(sender, CheckEdit)
        If chk.Checked = True Then

        End If
        'MsgBox(GridView1.GetFocusedRowCellValue("Emp_Attendence_Device_ID"))
        Select Case chk.Checked
            Case True
                chk.Checked = True
                'GridView1.OptionsView.AllowCellMerge = True
                'GridView1.OptionsSelection.MultiSelect = True
                'GridView1.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect
            Case False
                chk.Checked = False
                'GridView1.OptionsView.AllowCellMerge = False
        End Select
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        DeleteAllEmpty()
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        UpdateAllSummaray()
    End Sub

    Private Sub Sp1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Sp1.ItemClick

    End Sub
End Class