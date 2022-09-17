

Option Explicit On
Option Strict On


Imports System.Data.SqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
'Imports CsmdPlazaDatabase
Imports CsmdBioDatabase
Imports System.Data.OleDb
Imports DevExpress.LookAndFeel
Imports DevExpress.Data
Imports System.Net
'Imports DevExpress.Data

Public Class frmAttendanceLives
    Dim Class1 As New Class1
    Dim TempGridCheckMarksSelection As New GridCheckMarksSelectionxx
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Class1.MasterLive = "OpenAdmin" Then

        Else
            SaveSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", UserLookAndFeel.Default.ActiveSkinName)
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(AdvBandedGridView1)
        TempGridCheckMarksSelection.View.OptionsSelection.InvertSelection = True
        TempGridCheckMarksSelection.View.OptionsSelection.MultiSelect = True
        FF1.EditValue = Today
        FF2.EditValue = CsmdDateTime.LastDayOfMonth(Today)
        If Class1.MasterLive = "OpenAdmin" Then
            Me.TopMost = False
            SkinRibbonGalleryBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never

            GridView2.OptionsBehavior.Editable = True
            BarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Always
            GridView2.OptionsSelection.MultiSelect = True
        Else
            GridView2.OptionsBehavior.Editable = False
            BarButtonItem4.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            GridView2.OptionsSelection.MultiSelect = False
            Me.TopMost = True
            Try

                UserLookAndFeel.Default.SetSkinStyle(GetSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", ""))
            Catch ex As Exception
                UserLookAndFeel.Default.SetSkinStyle("Sharp")
                SaveSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", UserLookAndFeel.Default.ActiveSkinName)
            End Try
        End If
        FormSize(CInt(8.25))
        Dtp1.EditValue = Today.Date
    End Sub
    Public Sub FormSize(k As Integer)
        'Dim k As Integer = If(BarEditItem4.EditValue.ToString = "", 8.25, BarEditItem4.EditValue)
        'GridView1.Appearance.BandPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        GridView1.Appearance.HeaderPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        GridView1.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)
        GridView1.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)

        GridView2.Appearance.HeaderPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        GridView2.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)
        GridView2.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)

        AdvBandedGridView1.Appearance.BandPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        AdvBandedGridView1.Appearance.HeaderPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        AdvBandedGridView1.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)
        AdvBandedGridView1.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)

        'BarStaticItem2.Appearance.Font = New Font("Tahoma", k, FontStyle.Regular)
    End Sub


    'Public Sub LoadEmp()
    '    'Dim RAW As New CsmdBioAttendenceEntities
    '    Dim DBCon As New SqlConnection(CsmdCon.ConSqlDB)
    '    'Dim FAZ As New CsmdBioAttendenceEntities
    '    'Dim DBCon As New SqlConnection(FAZ.Database.Connection.ConnectionString)
    '    Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT Emp_ID,Emp_Name From Employees WHERE Emp_Status='true'", DBCon)
    '    Dim dsEmp As New DataSet()
    '    da.Fill(dsEmp)
    '    If dsEmp.Tables(0).Rows.Count > 0 Then
    '        GridControl4.DataSource = dsEmp.Tables(0)
    '    Else
    '        GridControl4.DataSource = Nothing
    '    End If
    '    DBCon.Close()
    'End Sub
    'Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    'End Sub
#Region "Data Load Queries"


    Public Sub Load_From_DeviceDB()
        Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
        'Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT 
        '                USERINFO.USERID, 
        '                USERINFO.Badgenumber,
        '                USERINFO.SSN, 
        '                USERINFO.Name, 
        '                CHECKINOUT.CHECKTIME FROM CHECKINOUT INNER JOIN USERINFO ON
        '                CHECKINOUT.USERID = USERINFO.USERID where DateValue(CHECKINOUT.CHECKTIME) = '" & CDate(Dtp1.EditValue) & "';", DBCon2)
        Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID, " & _
        "dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time " & _
"FROM dbo.Emp_Attendence_Device INNER JOIN " & _
                         "dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " & _
                         "dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " & _
"WHERE (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date = '" & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy/MM/dd") & "') and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true')", DBCon2)


        'Select Case dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, 
        '                         dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time
        'From dbo.Emp_Attendence_Device INNER Join
        '              dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER Join
        '              dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID

        Dim ds2 As New DataSet()
        da2.Fill(ds2)
        If ds2.Tables(0).Rows.Count > 0 Then
            GridControl4.DataSource = ds2.Tables(0)
        Else
            GridControl4.DataSource = Nothing
        End If
    End Sub

    Public Sub Load_MainView_Multi_Emp_DeviceBy_Day(Datx As Date)
        Dim DataT As New DataTable
        Dim Mtr As DataRow
        Dim Mtr2 As DataRow = Nothing
        DataT.Columns.Clear()
        DataT.Columns.Add("Emp_ID", GetType(Integer))
        DataT.Columns.Add("Emp_Name", GetType(String))
        DataT.Columns.Add("Fing", GetType(Integer))
        DataT.Columns.Add("Emp_DutyOn", GetType(String))
        DataT.Columns.Add("Emp_Duty_Off", GetType(String))
        DataT.Columns.Add("SSN", GetType(String))
        DataT.Columns.Add("Date", GetType(Date))
        DataT.Columns.Add("Days_Week", GetType(String))
        'Days_Week
        DataT.Columns.Add("Sn1", GetType(String))
        DataT.Columns.Add("Sn2", GetType(String))
        DataT.Columns.Add("Sn3", GetType(String))
        DataT.Columns.Add("Sn4", GetType(String))
        DataT.Columns.Add("Sn5", GetType(String))
        DataT.Columns.Add("Sn6", GetType(String))
        DataT.Columns.Add("Sn7", GetType(String))
        DataT.Columns.Add("Sn8", GetType(String))
        DataT.Columns.Add("Sn9", GetType(String))
        DataT.Columns.Add("Sn10", GetType(String))

        Dim FromDat As DateTime = CDate(Datx.Date)
        Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat)
        Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))

        'Dim RAW As New CsmdBioAttendenceEntities
        Dim DBCon As New SqlConnection(CsmdCon.ConSqlDB)
        'Dim FAZ As New CsmdBioAttendenceEntities
        'Dim DBCon As New SqlConnection(FAZ.Database.Connection.ConnectionString)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT * From Employees WHERE Emp_Status='true'", DBCon)
        Dim dsEmp As New DataSet()
        da.Fill(dsEmp)
        If dsEmp.Tables(0).Rows.Count > 0 Then
            GridControl2.DataSource = Nothing
            DataT.Rows.Clear()
            Dim k As Integer = 0
            ProgressBarControl1.Properties.Maximum = dsEmp.Tables(0).Rows.Count - 1
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
            ProgressBarControl1.Position = 0
            ProgressBarControl1.Update()
            For Each Emp As DataRow In dsEmp.Tables(0).Rows
                ProgressBarControl1.Position = k
                ProgressBarControl1.Update()
                k += 1

                Mtr = DataT.NewRow
                Mtr.Item("Emp_ID") = Emp.Item("Emp_ID")
                Mtr.Item("Emp_Name") = Emp.Item("Emp_Name")


                Mtr.Item("Days_Week") = Datx.Date.ToString("ddd")
                Mtr.Item("Date") = Datx.Date

                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                Dim thisDate As DateTime = CDate(Datx.Date & " " & CsmdDateTime.StartDayTime(Datx.Date))
                Dim ToDate As DateTime = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(Datx.Date))
                'Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
                'Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))
                Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)

                Dim SqlStr As String = "SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID, " &
"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Duty_On_Off, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID " &
"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
 "               WHERE " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime >= '" & thisDate.ToString("yyyy/MM/dd HH:mm") & "') AND " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime <= '" & ToDate.ToString("yyyy/MM/dd HH:mm") & "') AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & CInt(Emp.Item("Emp_ID")) & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime"

                'MsgBox(SqlStr)
                Dim da2 As SqlDataAdapter = New SqlDataAdapter(SqlStr, DBCon2)
                Dim ds2 As New DataSet()
                da2.Fill(ds2)

                Dim kok As Integer = 0

                Dim sw0 As Boolean = False

                If ds2.Tables(0).Rows.Count > 0 Then
                    Dim pra As Integer = 1
                    Dim pri As Integer = 1
                    'Mtr2 = DataT.NewRow
                    Dim pray As Boolean = False
                    Dim gh As Boolean = False
                    Dim s3 As String = ""
                    Dim s4 As String = ""
                    Dim s9 As String = ""
                    Dim s10 As String = ""
                    For Each dsx As DataRow In ds2.Tables(0).Rows
                        'xxxxxxxxxxxxxxxxxxx
                        'If pri > 1 Then

                        'End If



                        kok += 1
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")

                        Select Case CStr(dsx.Item("Attendence_Status_Type"))
                            Case "RT-Check In"
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                If sw0 = False Then
                                    Mtr.Item("Emp_DutyOn") = dsx.Item("Emp_Attendence_Device_Duty_On_Off").ToString
                                End If
                            Case "LT-Check Out"
                                Mtr.Item("Sn2") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                If sw0 = False Then
                                    Mtr.Item("Emp_Duty_Off") = dsx.Item("Emp_Attendence_Device_Duty_On_Off").ToString
                                    sw0 = True
                                End If
                            Case "RI-Prayer A"
                                'If pra = 1 Then
                                Mtr.Item("Sn3") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                'End If
                                'If pra > 1 Then
                                '    s3 = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                'End If

                            Case "LI-Prayer B"
                                'If pra = 1 Then
                                Mtr.Item("Sn4") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                '    pra += 1
                                'Else
                                '    If pra > 1 Then
                                '        s4 = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                '        pra += 1
                                '        pray = True
                                '    End If
                                'End If


                            Case "RM-Short Leave A"
                                Mtr.Item("Sn5") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Case "LM-Short Leave B"
                                Mtr.Item("Sn6") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Case "RR-Lunch A"
                                Mtr.Item("Sn7") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Case "LR-Lunch B"
                                Mtr.Item("Sn8") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                            Case "RP-Private A"
                                'If pri = 1 Then
                                Mtr.Item("Sn9") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                'End If
                                'If pri > 1 Then
                                '    s9 = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                'End If
                            Case "LP-Private B"
                                'If pri = 1 Then
                                Mtr.Item("Sn10") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                '    pri += 1
                                'Else
                                '    If pri > 1 Then
                                '        s10 = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                '        pri += 1
                                '        gh = True
                                '    End If
                                'End If

                        End Select


                        'If pray = True Then
                        '    Mtr2 = DataT.NewRow
                        '    Mtr2.Item("Emp_ID") = Emp.Item("Emp_ID")
                        '    Mtr2.Item("Emp_Name") = Emp.Item("Emp_Name")
                        '    Mtr2.Item("Emp_DutyOn") = Emp.Item("Emp_DutyOn").ToString
                        '    Mtr2.Item("Emp_Duty_Off") = Emp.Item("Emp_Duty_Off")

                        '    Mtr2.Item("Days_Week") = CDate(Dtp1.EditValue).Date.ToString("ddd")
                        '    Mtr2.Item("Date") = Dtp1.EditValue
                        '    Mtr2.Item("SSN") = dsx.Item("SSN")
                        '    Mtr2.Item("Sn3") = s3
                        '    Mtr2.Item("Sn4") = s4
                        '    Mtr2.Item("Sn9") = s9
                        '    Mtr2.Item("Sn10") = s10
                        '    Mtr2.Item("Fing") = kok
                        '    DataT.Rows.Add(Mtr2)
                        '    pray = False
                        'End If

                        'If gh = True Then
                        '    Mtr2 = DataT.NewRow
                        '    Mtr2.Item("Emp_ID") = Emp.Item("Emp_ID")
                        '    Mtr2.Item("Emp_Name") = Emp.Item("Emp_Name")
                        '    Mtr2.Item("Emp_DutyOn") = Emp.Item("Emp_DutyOn").ToString
                        '    Mtr2.Item("Emp_Duty_Off") = Emp.Item("Emp_Duty_Off")

                        '    Mtr2.Item("Days_Week") = CDate(Dtp1.EditValue).Date.ToString("ddd")
                        '    Mtr2.Item("Date") = Dtp1.EditValue
                        '    Mtr2.Item("SSN") = dsx.Item("SSN")
                        '    Mtr2.Item("Sn3") = s3
                        '    Mtr2.Item("Sn4") = s4
                        '    Mtr2.Item("Sn9") = s9
                        '    Mtr2.Item("Sn10") = s10
                        '    Mtr2.Item("Fing") = kok
                        '    DataT.Rows.Add(Mtr2)
                        '    gh = False
                        'End If


                    Next
                End If
                Mtr.Item("Fing") = kok
                DataT.Rows.Add(Mtr)
                DBCon2.Close()

            Next
            'GridControl4.DataSource = ds2.Tables(0)
            GridControl2.DataSource = DataT


            GridControl5.DataSource = Nothing

            'Dim dt = (From a In DataT Select New With {.USERID = a.Item("USERID"), .Emp_ID = EmpID,
            '                              .SSN = a.Item("SSN"),
            '                              .Sn1 = a.Item("Date"),
            '                              .Sn2 = a.Item("Date"), .AllDay = True, .Label = 4}).ToList


            'SchedulerStorage1.Appointments.DataSource = DataT
        End If
        DBCon.Close()
    End Sub

    Public Sub Load_MainView_Single_Emp_DeviceBy_Month(EmpID As Integer, DateX As Date)

        Dim DataT As New DataTable
        Dim Mtr As DataRow
        DataT.Columns.Clear()
        DataT.Columns.Add("Emp_ID", GetType(Integer))
        DataT.Columns.Add("Emp_Name", GetType(String))
        DataT.Columns.Add("Fing", GetType(Integer))
        DataT.Columns.Add("Emp_DutyOn", GetType(String))
        DataT.Columns.Add("Emp_Duty_Off", GetType(String))
        DataT.Columns.Add("SSN", GetType(String))
        DataT.Columns.Add("Date", GetType(Date))
        DataT.Columns.Add("Days_Week", GetType(String))
        'Days_Week
        DataT.Columns.Add("Sn1", GetType(String))
        DataT.Columns.Add("Sn2", GetType(String))
        DataT.Columns.Add("Sn3", GetType(String))
        DataT.Columns.Add("Sn4", GetType(String))
        DataT.Columns.Add("Sn5", GetType(String))
        DataT.Columns.Add("Sn6", GetType(String))
        DataT.Columns.Add("Sn7", GetType(String))
        DataT.Columns.Add("Sn8", GetType(String))
        DataT.Columns.Add("Sn9", GetType(String))
        DataT.Columns.Add("Sn10", GetType(String))

        Dim FromDat As DateTime = DateX.Date
        Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat)
        Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))

        'Dim RAW As New CsmdBioAttendenceEntities
        Dim DBCon As New SqlConnection(CsmdCon.ConSqlDB)
        'Dim FAZ As New CsmdBioAttendenceEntities
        'Dim DBCon As New SqlConnection(FAZ.Database.Connection.ConnectionString)
        Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT * From Employees WHERE Emp_Status='true' and Emp_ID=" & EmpID, DBCon)
        Dim dsEmp As New DataSet()
        da.Fill(dsEmp)
        If dsEmp.Tables(0).Rows.Count > 0 Then
            GridControl2.DataSource = Nothing
            DataT.Rows.Clear()
            Dim k As Integer = 1
            ProgressBarControl1.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate))
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
            ProgressBarControl1.Position = 0
            ProgressBarControl1.Update()

            For Each Emp As DataRow In dsEmp.Tables(0).Rows


                For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate - 1

                    Dim thisDate As Date = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(DateX.Date))
                    Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(DateX.Date))
                    Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
                    Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))
                    ProgressBarControl1.Position = k
                    ProgressBarControl1.Update()
                    k += 1

                    Mtr = DataT.NewRow
                    Mtr.Item("Emp_ID") = Emp.Item("Emp_ID")
                    Mtr.Item("Emp_Name") = Emp.Item("Emp_Name")
                    'Mtr.Item("Emp_DutyOn") = Emp.Item("Emp_DutyOn").ToString
                    'Mtr.Item("Emp_Duty_Off") = Emp.Item("Emp_Duty_Off")
                    Mtr.Item("Date") = thisDate.Date
                    Mtr.Item("Days_Week") = thisDate.Date.ToString("ddd")

                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
                    Dim da2 As SqlDataAdapter = New SqlDataAdapter("Select dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID, " &
"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Duty_On_Off, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID  " &
"From  dbo.Emp_Attendence_Device INNER JOIN " &
"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
"WHERE  " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime >= '" & thisDate.ToString("yyyy/MM/dd HH:mm") & "') AND  " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime <= '" & ToDate.ToString("yyyy/MM/dd HH:mm") & "')  AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & CInt(Emp.Item("Emp_ID")) & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true')ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
                    Dim ds2 As New DataSet()
                    da2.Fill(ds2)
                    Dim klk As Integer = 0
                    If ds2.Tables(0).Rows.Count > 0 Then
                        Dim kok As Boolean = False
                        Dim sw0 As Boolean = False
                        For Each dsx As DataRow In ds2.Tables(0).Rows
                            klk += 1
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Select Case CStr(dsx.Item("Attendence_Status_Type"))
                                Case "RT-Check In"
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    If sw0 = False Then
                                        Mtr.Item("Emp_DutyOn") = dsx.Item("Emp_Attendence_Device_Duty_On_Off").ToString
                                    End If
                                Case "LT-Check Out"
                                    Mtr.Item("Sn2") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    If sw0 = False Then
                                        Mtr.Item("Emp_Duty_Off") = dsx.Item("Emp_Attendence_Device_Duty_On_Off").ToString
                                        sw0 = True
                                    End If
                                Case "RI-Prayer A"
                                    Mtr.Item("Sn3") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Case "LI-Prayer B"
                                    Mtr.Item("Sn4") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Case "RM-Short Leave A"
                                    Mtr.Item("Sn5") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Case "LM-Short Leave B"
                                    Mtr.Item("Sn6") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Case "RR-Lunch A"
                                    Mtr.Item("Sn7") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Case "LR-Lunch B"
                                    Mtr.Item("Sn8") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Case "RP-Private A"
                                    Mtr.Item("Sn9") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Case "LP-Private B"
                                    Mtr.Item("Sn10") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            End Select
                        Next
                    End If

                    Mtr.Item("Fing") = klk
                    DataT.Rows.Add(Mtr)
                    DBCon2.Close()

                Next
            Next
            GridControl2.DataSource = DataT
        End If
        DBCon.Close()
    End Sub

    Public Sub Load_Detail_View_DeviceBy_Day(EmpID As Integer, DateX As Date)
        Dim DataT As New DataTable
        Dim Mtr As DataRow
        DataT.Columns.Clear()
        DataT.Columns.Add("USERID", GetType(Integer))
        DataT.Columns.Add("Sd1", GetType(String))
        DataT.Columns.Add("Sd2", GetType(String))
        DataT.Columns.Add("Date", GetType(String))
        DataT.Columns.Add("SSN", GetType(String))
        DataT.Columns.Add("Sn1", GetType(String))

        'Dim hh As String = ConfigurationManager.ConnectionStrings("att2000ConnectionString").ConnectionString
        Dim thisDate As Date = CDate(DateX.Date & " " & CsmdDateTime.StartDayTime(DateX.Date))
        Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(DateX.Date))
        Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
        Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))
        Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
        Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID,  " & _
"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID  " & _
"FROM  dbo.Emp_Attendence_Device INNER JOIN " & _
"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " & _
"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " & _
"WHERE  " & _
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime >= '" & thisDate.ToString("yyyy/MM/dd HH:mm") & "') AND  " & _
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime <= '" & ToDate.ToString("yyyy/MM/dd HH:mm") & "')  AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & EmpID & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
        Dim ds2 As New DataSet()
        da2.Fill(ds2)

        Dim chkA As Boolean = False
        Dim chkB As Boolean = False
        Dim chkC As Boolean = False
        Dim chkD As Boolean = False
        Dim chkE As Boolean = False
        Dim chkA2 As Boolean = False
        Dim chkB2 As Boolean = False
        Dim chkC2 As Boolean = False
        Dim chkD2 As Boolean = False
        Dim chkE2 As Boolean = False
        If ds2.Tables(0).Rows.Count > 0 Then
            Mtr = DataT.NewRow
            Mtr.Item("USERID") = 0 ' ds2.Tables(0).Rows(0).Item("USERID")
            Mtr.Item("Date") = DateX.Date  ' ds2.Tables(0).Rows(0).Item("Date")
            Mtr.Item("Sd1") = DateX.Date.ToString("dd")
            Mtr.Item("Sd2") = "-"
            Mtr.Item("SSN") = DateX.Date.ToString("dddd")
            Mtr.Item("Sn1") = "---"
            DataT.Rows.Add(Mtr)
            For Each dsx As DataRow In ds2.Tables(0).Rows
                'Mtr.Item("USERID") = CInt(dsx.Item("USERID"))
                'cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc
                If dsx.Item("Attendence_Status_Type").ToString = "RT-Check In" Then
                    If chkA2 = False Then
                        chkA = True
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)
                        chkA2 = True
                    Else
                        chkA = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)

                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                        Mtr.Item("Date") = DateX.Date
                        Mtr.Item("SSN") = "LT-Check Out"
                        Mtr.Item("Sn1") = ""
                        DataT.Rows.Add(Mtr)

                    End If

                Else
                    If dsx.Item("Attendence_Status_Type").ToString = "LT-Check Out" Then
                        If chkA = False Then
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                            Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                            Mtr.Item("SSN") = "RT-Check In"
                            Mtr.Item("Sn1") = ""
                            DataT.Rows.Add(Mtr)

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkA2 = False
                        Else
                            chkA = False
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkA2 = False
                        End If
                        'Else
                        '    If chkA = True Then
                        '        chkA = False
                        '        Mtr = DataT.NewRow
                        '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                        '        Mtr.Item("SSN") = "LT-Check Out"
                        '        Mtr.Item("Sn1") = ""
                        '        DataT.Rows.Add(Mtr)
                        '    End If
                    End If
                End If
                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                If dsx.Item("Attendence_Status_Type").ToString = "RI-Prayer A" Then
                    If chkB2 = False Then
                        chkB = True
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)
                        chkB2 = True
                    Else
                        chkB = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)

                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                        Mtr.Item("Date") = DateX.Date
                        Mtr.Item("SSN") = "LI-Prayer B"
                        Mtr.Item("Sn1") = ""
                        DataT.Rows.Add(Mtr)

                    End If

                Else
                    If dsx.Item("Attendence_Status_Type").ToString = "LI-Prayer B" Then

                        If chkB = False Then
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = "RI-Prayer A"
                            Mtr.Item("Sn1") = ""
                            DataT.Rows.Add(Mtr)

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkB2 = False
                        Else
                            chkB = False
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkB2 = False
                        End If
                        'Else
                        '    If chkB = True Then
                        '        chkB = False
                        '        Mtr = DataT.NewRow
                        '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                        '        Mtr.Item("SSN") = "LI-Prayer B"
                        '        Mtr.Item("Sn1") = ""
                        '        DataT.Rows.Add(Mtr)
                        '    End If
                    End If
                End If
                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                If dsx.Item("Attendence_Status_Type").ToString = "RM-Short Leave A" Then
                    If chkC2 = False Then
                        chkC = True
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)
                        chkC2 = True
                    Else
                        chkC = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)

                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                        Mtr.Item("Date") = DateX.Date
                        Mtr.Item("SSN") = "LM-Short Leave B"
                        Mtr.Item("Sn1") = ""
                        DataT.Rows.Add(Mtr)

                    End If

                Else
                    If dsx.Item("Attendence_Status_Type").ToString = "LM-Short Leave B" Then

                        If chkC = False Then
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = "RM-Short Leave A"
                            Mtr.Item("Sn1") = ""
                            DataT.Rows.Add(Mtr)

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkC2 = False
                        Else
                            chkC = False
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkC2 = False
                        End If
                        'Else
                        '    If chkC = True Then
                        '        chkC = False
                        '        Mtr = DataT.NewRow
                        '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                        '        Mtr.Item("SSN") = "LM-Short Leave B"
                        '        Mtr.Item("Sn1") = ""
                        '        DataT.Rows.Add(Mtr)
                        '    End If
                    End If
                End If
                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                If dsx.Item("Attendence_Status_Type").ToString = "RR-Lunch A" Then
                    If chkD2 = False Then
                        chkD = True
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)
                        chkD2 = True
                    Else
                        chkD = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)

                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                        Mtr.Item("Date") = DateX.Date
                        Mtr.Item("SSN") = "LR-Lunch B"
                        Mtr.Item("Sn1") = ""
                        DataT.Rows.Add(Mtr)

                    End If


                Else
                    If dsx.Item("Attendence_Status_Type").ToString = "LR-Lunch B" Then

                        If chkD = False Then
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = "RR-Lunch A"
                            Mtr.Item("Sn1") = ""
                            DataT.Rows.Add(Mtr)

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkD2 = False
                        Else
                            chkD = False
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkD2 = False
                        End If
                        'Else
                        '    If chkD = True Then
                        '        chkD = False
                        '        Mtr = DataT.NewRow
                        '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                        '        Mtr.Item("SSN") = "LR-Lunch B"
                        '        Mtr.Item("Sn1") = ""
                        '        DataT.Rows.Add(Mtr)
                        '    End If
                    End If
                End If
                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                If dsx.Item("Attendence_Status_Type").ToString = "RP-Private A" Then
                    If chkE2 = False Then
                        chkE = True
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)
                        chkE2 = True
                    Else
                        chkE = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                        Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                        Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                        Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                        DataT.Rows.Add(Mtr)

                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                        Mtr.Item("Date") = DateX.Date
                        Mtr.Item("SSN") = "LP-Private B"
                        Mtr.Item("Sn1") = ""
                        DataT.Rows.Add(Mtr)


                    End If


                Else

                    If dsx.Item("Attendence_Status_Type").ToString = "LP-Private B" Then

                        If chkE = False Then
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = "RP-Private A"
                            Mtr.Item("Sn1") = ""
                            DataT.Rows.Add(Mtr)

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkE2 = False
                        Else
                            chkE = False
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkE2 = False
                        End If

                        'Else
                        '    If chkE = True Then
                        '        chkE = False
                        '        Mtr = DataT.NewRow
                        '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                        '        Mtr.Item("SSN") = "LP-Private B"
                        '        Mtr.Item("Sn1") = ""
                        '        DataT.Rows.Add(Mtr)
                        '    End If
                    End If
                End If


                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
            Next
            If chkA = True Then
                chkA = False
                Mtr = DataT.NewRow
                Mtr.Item("Date") = DateX.Date
                Mtr.Item("SSN") = "LT-Check Out"
                Mtr.Item("Sn1") = ""
                DataT.Rows.Add(Mtr)
            End If
            If chkB = True Then
                chkB = False
                Mtr = DataT.NewRow
                Mtr.Item("Date") = DateX.Date
                Mtr.Item("SSN") = "LI-Prayer B"
                Mtr.Item("Sn1") = ""
                DataT.Rows.Add(Mtr)
            End If
            If chkC = True Then
                chkC = False
                Mtr = DataT.NewRow
                Mtr.Item("Date") = DateX.Date
                Mtr.Item("SSN") = "LM-Short Leave B"
                Mtr.Item("Sn1") = ""
                DataT.Rows.Add(Mtr)
            End If
            If chkD = True Then
                chkD = False
                Mtr = DataT.NewRow
                Mtr.Item("Date") = DateX.Date
                Mtr.Item("SSN") = "LR-Lunch B"
                Mtr.Item("Sn1") = ""
                DataT.Rows.Add(Mtr)
            End If
            If chkE = True Then
                chkE = False
                Mtr = DataT.NewRow
                Mtr.Item("Date") = DateX.Date
                Mtr.Item("SSN") = "LP-Private B"
                Mtr.Item("Sn1") = ""
                DataT.Rows.Add(Mtr)
            End If

        Else

            Mtr = DataT.NewRow
            Mtr.Item("USERID") = 0
            Mtr.Item("Sd1") = ""
            'Mtr.Item("Sd2") = "-."
            Mtr.Item("Date") = DateX.Date
            Mtr.Item("SSN") = "Absent"
            Mtr.Item("Sn1") = "OFF"
            DataT.Rows.Add(Mtr)


        End If


        DBCon2.Close()
        GridControl5.DataSource = Nothing
        GridControl5.DataSource = DataT
    End Sub

    Public Sub Load_Detail_View_DeviceBy_Month(EmpID As Integer, EmpCode As String, DateX As Date)
        Dim DataT As New DataTable
        Dim Mtr As DataRow
        DataT.Columns.Clear()
        DataT.Columns.Add("USERID", GetType(String))
        DataT.Columns.Add("Sd1", GetType(String))
        DataT.Columns.Add("Sd2", GetType(String))
        DataT.Columns.Add("Date", GetType(String))
        DataT.Columns.Add("SSN", GetType(String))
        DataT.Columns.Add("Sn1", GetType(String))

        Dim FromDat As DateTime = DateX.Date
        Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat)
        Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))
        'ClickforMonthly.Caption = "Now " & EmpName & " >>>"
        Dim k As Integer = 1
        ProgressBarControl1.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate))
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
        ProgressBarControl1.Position = 0
        ProgressBarControl1.Update()

        For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate - 1


            Dim thisDate As Date = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(DateX.Date))
            Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(DateX.Date))
            Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
            Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))

            'MsgBox(TiA)
            'MsgBox(TiB)

            ProgressBarControl1.Position = k
            ProgressBarControl1.Update()
            k += 1

            Mtr = DataT.NewRow
            Mtr.Item("USERID") = EmpCode
            Mtr.Item("Sd1") = thisDate.Date.ToString("dd")
            Mtr.Item("Sd2") = "-"
            Mtr.Item("Date") = thisDate.Date
            'Mtr.Item("SSN") = "Duty ON " & EmpDutyOn & " - OFF " & EmpDutyOff & " - " & thisDate.Date.ToString("dddd")
            Mtr.Item("SSN") = thisDate.Date.ToString("dddd")
            Mtr.Item("Sn1") = "---"
            DataT.Rows.Add(Mtr)

            'Dim hh As String = ConfigurationManager.ConnectionStrings("att2000ConnectionString").ConnectionString
            Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
            Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name,dbo.Emp_Bio_Device_Users.Emp_ID, " &
"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID " &
"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
"            WHERE " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime >= '" & thisDate.ToString("yyyy/MM/dd HH:mm") & "') AND  " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime <= '" & ToDate.ToString("yyyy/MM/dd HH:mm") & "')  " &
"AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & EmpID & ") AND (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
            Dim ds2 As New DataSet()
            da2.Fill(ds2)
            Dim chkA As Boolean = False
            Dim chkB As Boolean = False
            Dim chkC As Boolean = False
            Dim chkD As Boolean = False
            Dim chkE As Boolean = False
            Dim chkA2 As Boolean = False
            Dim chkB2 As Boolean = False
            Dim chkC2 As Boolean = False
            Dim chkD2 As Boolean = False
            Dim chkE2 As Boolean = False
            If ds2.Tables(0).Rows.Count > 0 Then

                For Each dsx As DataRow In ds2.Tables(0).Rows
                    If CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") >= thisDate.ToString("yyyy/MM/dd HH") And CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") <= ToDate.ToString("yyyy/MM/dd HH") Then
                        If dsx.Item("Attendence_Status_Type").ToString = "RT-Check In" Then
                            If chkA2 = False Then
                                chkA = True
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkA2 = True
                            Else
                                chkA = False
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                Mtr.Item("Date") = DateX.Date
                                Mtr.Item("SSN") = "LT-Check Out"
                                Mtr.Item("Sn1") = ""
                                DataT.Rows.Add(Mtr)

                            End If

                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LT-Check Out" Then
                                If chkA = False Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                                    Mtr.Item("SSN") = "RT-Check In"
                                    Mtr.Item("Sn1") = ""
                                    DataT.Rows.Add(Mtr)

                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkA2 = False
                                Else
                                    chkA = False
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime"))
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkA2 = False
                                End If
                                'Else
                                '    If chkA = True Then
                                '        chkA = False
                                '        Mtr = DataT.NewRow
                                '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                                '        Mtr.Item("SSN") = "LT-Check Out"
                                '        Mtr.Item("Sn1") = ""
                                '        DataT.Rows.Add(Mtr)
                                '    End If
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RI-Prayer A" Then
                            If chkB2 = False Then
                                chkB = True
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkB2 = True
                            Else
                                chkB = False
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                Mtr.Item("Date") = DateX.Date
                                Mtr.Item("SSN") = "LI-Prayer B"
                                Mtr.Item("Sn1") = ""
                                DataT.Rows.Add(Mtr)

                            End If

                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LI-Prayer B" Then

                                If chkB = False Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = "RI-Prayer A"
                                    Mtr.Item("Sn1") = ""
                                    DataT.Rows.Add(Mtr)

                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkB2 = False
                                Else
                                    chkB = False
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkB2 = False
                                End If
                                'Else
                                '    If chkB = True Then
                                '        chkB = False
                                '        Mtr = DataT.NewRow
                                '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                                '        Mtr.Item("SSN") = "LI-Prayer B"
                                '        Mtr.Item("Sn1") = ""
                                '        DataT.Rows.Add(Mtr)
                                '    End If
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RM-Short Leave A" Then
                            If chkC2 = False Then
                                chkC = True
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkC2 = True
                            Else
                                chkC = False
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                Mtr.Item("Date") = DateX.Date
                                Mtr.Item("SSN") = "LM-Short Leave B"
                                Mtr.Item("Sn1") = ""
                                DataT.Rows.Add(Mtr)

                            End If

                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LM-Short Leave B" Then

                                If chkC = False Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = "RM-Short Leave A"
                                    Mtr.Item("Sn1") = ""
                                    DataT.Rows.Add(Mtr)

                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkC2 = False
                                Else
                                    chkC = False
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkC2 = False
                                End If
                                'Else
                                '    If chkC = True Then
                                '        chkC = False
                                '        Mtr = DataT.NewRow
                                '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                                '        Mtr.Item("SSN") = "LM-Short Leave B"
                                '        Mtr.Item("Sn1") = ""
                                '        DataT.Rows.Add(Mtr)
                                '    End If
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RR-Lunch A" Then
                            If chkD2 = False Then
                                chkD = True
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkD2 = True
                            Else
                                chkD = False
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                Mtr.Item("Date") = DateX.Date
                                Mtr.Item("SSN") = "LR-Lunch B"
                                Mtr.Item("Sn1") = ""
                                DataT.Rows.Add(Mtr)

                            End If


                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LR-Lunch B" Then

                                If chkD = False Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = "RR-Lunch A"
                                    Mtr.Item("Sn1") = ""
                                    DataT.Rows.Add(Mtr)

                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkD2 = False
                                Else
                                    chkD = False
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkD2 = False
                                End If
                                'Else
                                '    If chkD = True Then
                                '        chkD = False
                                '        Mtr = DataT.NewRow
                                '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                                '        Mtr.Item("SSN") = "LR-Lunch B"
                                '        Mtr.Item("Sn1") = ""
                                '        DataT.Rows.Add(Mtr)
                                '    End If
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RP-Private A" Then
                            If chkE2 = False Then
                                chkE = True
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkE2 = True
                            Else
                                chkE = False
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                Mtr.Item("Date") = DateX.Date
                                Mtr.Item("SSN") = "LP-Private B"
                                Mtr.Item("Sn1") = ""
                                DataT.Rows.Add(Mtr)


                            End If


                        Else

                            If dsx.Item("Attendence_Status_Type").ToString = "LP-Private B" Then

                                If chkE = False Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = "RP-Private A"
                                    Mtr.Item("Sn1") = ""
                                    DataT.Rows.Add(Mtr)

                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkE2 = False
                                Else
                                    chkE = False
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                    Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                    Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkE2 = False
                                End If

                                'Else
                                '    If chkE = True Then
                                '        chkE = False
                                '        Mtr = DataT.NewRow
                                '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                                '        Mtr.Item("SSN") = "LP-Private B"
                                '        Mtr.Item("Sn1") = ""
                                '        DataT.Rows.Add(Mtr)
                                '    End If
                            End If
                        End If
                    End If
                Next

                If chkA = True Then
                    chkA = False
                    Mtr = DataT.NewRow
                    Mtr.Item("USERID") = EmpCode
                    Mtr.Item("Date") = thisDate.Date
                    Mtr.Item("SSN") = "LT-Check Out"
                    Mtr.Item("Sn1") = ""
                    DataT.Rows.Add(Mtr)
                End If
                If chkB = True Then
                    chkB = False
                    Mtr = DataT.NewRow
                    Mtr.Item("USERID") = EmpCode
                    Mtr.Item("Date") = thisDate.Date
                    Mtr.Item("SSN") = "LI-Prayer B"
                    Mtr.Item("Sn1") = ""
                    DataT.Rows.Add(Mtr)
                End If
                If chkC = True Then
                    chkC = False
                    Mtr = DataT.NewRow
                    Mtr.Item("USERID") = EmpCode
                    Mtr.Item("Date") = thisDate.Date
                    Mtr.Item("SSN") = "LM-Short Leave B"
                    Mtr.Item("Sn1") = ""
                    DataT.Rows.Add(Mtr)
                End If
                If chkD = True Then
                    chkD = False
                    Mtr = DataT.NewRow
                    Mtr.Item("USERID") = EmpCode
                    Mtr.Item("Date") = thisDate.Date
                    Mtr.Item("SSN") = "LR-Lunch B"
                    Mtr.Item("Sn1") = ""
                    DataT.Rows.Add(Mtr)
                End If
                If chkE = True Then
                    chkE = False
                    Mtr = DataT.NewRow
                    Mtr.Item("USERID") = EmpCode
                    Mtr.Item("Date") = thisDate.Date
                    Mtr.Item("SSN") = "LP-Private B"
                    Mtr.Item("Sn1") = ""
                    DataT.Rows.Add(Mtr)
                End If

            Else
                Mtr = DataT.NewRow
                Mtr.Item("USERID") = EmpCode
                Mtr.Item("Sd1") = ""
                'Mtr.Item("Sd2") = "-."
                Mtr.Item("Date") = thisDate.Date
                Mtr.Item("SSN") = "Absent"
                Mtr.Item("Sn1") = "OFF"
                DataT.Rows.Add(Mtr)

            End If



            DBCon2.Close()
        Next
        GridControl5.DataSource = Nothing
        GridControl5.DataSource = DataT
    End Sub

#End Region



#Region "AdvBandedGridView1"

    Public Sub AdvBandedGridView1_Csmd_CustomDrawColumnHeader(SSN As String, Color As Color, e As ColumnHeaderCustomDrawEventArgs)
        'Dim vv As BandedGrid.BandHeaderCustomDrawEventArgs
        If e.Column.FieldName = SSN Then
            e.Info.AllowColoring = True
            e.Appearance.BackColor = Color
        End If
    End Sub

    Private Sub AdvBandedGridView1_CustomDrawColumnHeader(sender As Object, e As ColumnHeaderCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawColumnHeader
        Try
            AdvBandedGridView1_Csmd_CustomDrawColumnHeader("Sn1", Color.Cyan, e)
            AdvBandedGridView1_Csmd_CustomDrawColumnHeader("Sn3", Color.Lime, e)
            AdvBandedGridView1_Csmd_CustomDrawColumnHeader("Sn5", Color.LightBlue, e)
            AdvBandedGridView1_Csmd_CustomDrawColumnHeader("Sn7", Color.Orange, e)
            AdvBandedGridView1_Csmd_CustomDrawColumnHeader("Sn9", Color.Pink, e)

            'If e.Column.FieldName = "Sn1" Then
            '    e.Appearance.BackColor = Color.Cyan
            '    e.Info.AllowColoring = True
            'End If
            'If e.Column.FieldName = "Sn3" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.Lime
            'End If
            'If e.Column.FieldName = "Sn5" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.LightBlue
            'End If
            'If e.Column.FieldName = "Sn7" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.Orange
            'End If
            'If e.Column.FieldName = "Sn9" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.Pink
            'End If

            class1.DrawVertical("Emp_DutyOn", e)
            Class1.DrawVertical("Emp_Duty_Off", e)
            Class1.DrawVertical("Sn1", e)
            Class1.DrawVertical("Sn2", e)
            Class1.DrawVertical("Sn3", e)
            Class1.DrawVertical("Sn4", e)
            Class1.DrawVertical("Sn5", e)
            Class1.DrawVertical("Sn6", e)
            Class1.DrawVertical("Sn7", e)
            Class1.DrawVertical("Sn8", e)
            Class1.DrawVertical("Sn9", e)
            Class1.DrawVertical("Sn10", e)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdvBandedGridView1_CustomDrawBandHeader(sender As Object, e As BandHeaderCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawBandHeader
        Try
            AdvBandedGridView1_Csmd_BandHeader("Check In-Out", Color.Cyan, e)
            AdvBandedGridView1_Csmd_BandHeader("Prayer A-B", Color.Lime, e)
            AdvBandedGridView1_Csmd_BandHeader("SH Leave A-B", Color.LightBlue, e)
            AdvBandedGridView1_Csmd_BandHeader("Lunch A-B", Color.Orange, e)
            AdvBandedGridView1_Csmd_BandHeader("Private A-B", Color.Pink, e)
            'If e.Band.Caption = "Check In-Out" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.Cyan
            'End If
            'If e.Band.Caption = "Prayer A-B" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.Lime
            'End If
            'If e.Band.Caption = "SH Leave A-B" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.LightBlue
            'End If
            'If e.Band.Caption = "Lunch A-B" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.Orange
            'End If
            'If e.Band.Caption = "Private A-B" Then
            '    e.Info.AllowColoring = True
            '    e.Appearance.BackColor = Color.Pink
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AdvBandedGridView1_Csmd_BandHeader(SSN As String, Color As Color, e As BandHeaderCustomDrawEventArgs)
        'Dim vv As BandedGrid.BandHeaderCustomDrawEventArgs
        If e.Band.Caption = SSN Then
            e.Info.AllowColoring = True
            e.Appearance.BackColor = Color
        End If
    End Sub

    Private Sub AdvBandedGridView1_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawCell
        If e.Column.FieldName = "Days_Week" Then
            If e.CellValue.ToString = "Fri" Then
                e.Appearance.BackColor = Color.Aquamarine
            End If
        End If
    End Sub

    Private Sub AdvBandedGridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles AdvBandedGridView1.RowCellStyle

        AdvBandedGridView1_Csmd_RowCellStyle("Sn1", "Sn2", Color.Cyan, e)
        AdvBandedGridView1_Csmd_RowCellStyle("Sn2", "Sn1", Color.Cyan, e)

        AdvBandedGridView1_Csmd_RowCellStyle("Sn3", "Sn4", Color.Lime, e)
        AdvBandedGridView1_Csmd_RowCellStyle("Sn4", "Sn3", Color.Lime, e)

        AdvBandedGridView1_Csmd_RowCellStyle("Sn5", "Sn6", Color.LightBlue, e)
        AdvBandedGridView1_Csmd_RowCellStyle("Sn6", "Sn5", Color.LightBlue, e)

        AdvBandedGridView1_Csmd_RowCellStyle("Sn7", "Sn8", Color.Orange, e)
        AdvBandedGridView1_Csmd_RowCellStyle("Sn8", "Sn7", Color.Orange, e)

        AdvBandedGridView1_Csmd_RowCellStyle("Sn9", "Sn10", Color.Pink, e)
        AdvBandedGridView1_Csmd_RowCellStyle("Sn10", "Sn9", Color.Pink, e)

        'If e.Column.FieldName = "Sn1" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Cyan
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn2").ToString = "" Then
        '            e.Appearance.BackColor = Color.Red
        '        End If
        '    End If
        'End If
        'If e.Column.FieldName = "Sn2" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Cyan
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn1").ToString = "" Then
        '            e.Appearance.BackColor = Color.Red
        '        End If
        '    End If
        'End If
        'If e.Column.FieldName = "Sn3" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Lime
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn4").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
        'If e.Column.FieldName = "Sn4" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Lime
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn3").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
        'If e.Column.FieldName = "Sn5" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.LightBlue
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn6").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
        'If e.Column.FieldName = "Sn6" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.LightBlue
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn5").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
        'If e.Column.FieldName = "Sn7" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Orange
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn8").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
        'If e.Column.FieldName = "Sn8" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Orange
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn7").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
        'If e.Column.FieldName = "Sn9" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Pink
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn10").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
        'If e.Column.FieldName = "Sn10" Then
        '    If Not e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Pink
        '    Else
        '        If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn9").ToString = "" Then e.Appearance.BackColor = Color.Red
        '    End If
        'End If
    End Sub

    Public Sub AdvBandedGridView1_Csmd_RowCellStyle(Col1 As String, Col2 As String, Color As Color, e As RowCellStyleEventArgs)
        If e.Column.FieldName = Col1 Then
            If Not e.CellValue.ToString = "" Then
                e.Appearance.BackColor = Color
            Else
                If Not AdvBandedGridView1.GetRowCellValue(e.RowHandle, Col2).ToString = "" Then e.Appearance.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub AdvBandedGridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles AdvBandedGridView1.RowStyle
        Try
            'If AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn1").ToString = "" And AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Sn2").ToString = "" Then
            '    e.Appearance.BackColor = Color.DarkKhaki
            '    e.Appearance.ForeColor = Color.White
            'End If
            If AdvBandedGridView1.GetRowCellValue(e.RowHandle, "Fing").ToString = "0" Then
                e.Appearance.BackColor = Color.Blue
                e.Appearance.ForeColor = Color.White
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdvBandedGridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles AdvBandedGridView1.RowClick
        Try
            EmpID = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            EmpName = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Name"), String)
            EmpDate = CDate(AdvBandedGridView1.GetFocusedRowCellValue("Date"))
            'BarStaticItem2.Caption = EmpName & " isOn " & EmpDate
            FilterMonth = False
            GridColumn17.Caption = "DayView " & EmpID
            Load_Detail_View_DeviceBy_Day(EmpID, EmpDate)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles AdvBandedGridView1.DoubleClick
        Try
            If bn = True Then
                Dtp1.EditValue = EmpDate
                Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate) '(EmpName, EmpDate)
                'TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(Nothing)
                bn = False
            Else
                Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
                'TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(AdvBandedGridView1)
                bn = True
            End If


            'BarStaticItem2.Caption = EmpName & " isOn " & EmpDate

        Catch ex As Exception

        End Try
    End Sub
    Private Sub AdvBandedGridView1_MouseUp(sender As Object, e As MouseEventArgs) Handles AdvBandedGridView1.MouseUp
        Try
            ShowSelection()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ShowSelection()
        Dim intL As Integer = 0
        Dim RowCount As Integer = TempGridCheckMarksSelection.SelectedCount - 1
        ReDim intList(RowCount)
        For ff As Integer = 0 To AdvBandedGridView1.RowCount - 1
            If TempGridCheckMarksSelection.IsRowSelected(ff) Then
                Dim obj1 As Object = TryCast(AdvBandedGridView1.GetRowCellValue(ff, "Emp_ID"), Object)
                If obj1 Is Nothing Then
                    Return
                End If
                intList(intL) = CInt(obj1)
                intL += 1
            End If
        Next
    End Sub


#End Region

#Region "GridView1"
    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        Try
            EmpID = CType(GridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            'EmpName = CType(GridView1.GetFocusedRowCellValue("Emp_Bio_Device_User_Name"), String)
            EmpDate = CDate(GridView1.GetFocusedRowCellValue("Emp_Attendence_Device_Date"))
            'BarStaticItem2.Caption = EmpName & " isOn " & EmpDate
            FilterMonth = False
            GridColumn17.Caption = "DayView " & EmpID
            Load_Detail_View_DeviceBy_Day(EmpID, CDate(Dtp1.EditValue))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            If e.Column.FieldName = "Attendence_Status_Type" Then
                Select Case e.CellValue.ToString
                    Case "RT-Check In", "LT-Check Out"
                        e.Appearance.BackColor = Color.Cyan
                    Case "RI-Prayer A", "LI-Prayer B"
                        e.Appearance.BackColor = Color.Lime
                    Case "RM-Short Leave A", "LM-Short Leave B"
                        e.Appearance.BackColor = Color.LightBlue
                    Case "RR-Lunch A", "LR-Lunch B"
                        e.Appearance.BackColor = Color.Orange
                    Case "RP-Private A", "LP-Private B"
                        e.Appearance.BackColor = Color.Pink
                        'Case "Absent"
                        '    e.Appearance.BackColor = Color.Blue
                        '    e.Appearance.ForeColor = Color.White
                        'Case DayOfWeek.Friday.ToString, DayOfWeek.Monday.ToString, DayOfWeek.Saturday.ToString, DayOfWeek.Sunday.ToString, DayOfWeek.Thursday.ToString, DayOfWeek.Tuesday.ToString, DayOfWeek.Wednesday.ToString
                        '    e.Appearance.BackColor = Color.Black
                        '    e.Appearance.ForeColor = Color.White
                End Select
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ex1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ex1.ItemClick
        If ex1.Down = True Then
            GridView1.Columns("Emp_Bio_Device_User_Name").Group()
        Else
            GridView1.Columns("Emp_Bio_Device_User_Name").UnGroup()
        End If
    End Sub

    Private Sub ex2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ex2.ItemClick
        If ex2.Down = True Then
            GridView1.Columns("Attendence_Status_Type").Group()
        Else
            GridView1.Columns("Attendence_Status_Type").UnGroup()
        End If
    End Sub

    Private Sub shafqat_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles shafqat.ItemClick
        If shafqat.Down = True Then
            GridView1.ExpandAllGroups()
            shafqat.Caption = "Collapse All"
        Else
            GridView1.CollapseAllGroups()
            shafqat.Caption = "Expand All"
        End If
    End Sub

#End Region
#Region "GridView2"
    Private Sub GridView2_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        Try
            If e.Column.FieldName = "SSN" Then
                Select Case e.CellValue.ToString
                    Case "RT-Check In", "LT-Check Out"
                        e.Appearance.BackColor = Color.Cyan
                    Case "RI-Prayer A", "LI-Prayer B"
                        e.Appearance.BackColor = Color.Lime
                    Case "RM-Short Leave A", "LM-Short Leave B"
                        e.Appearance.BackColor = Color.LightBlue
                    Case "RR-Lunch A", "LR-Lunch B"
                        e.Appearance.BackColor = Color.Orange
                    Case "RP-Private A", "LP-Private B"
                        e.Appearance.BackColor = Color.Pink
                    Case "Absent"
                        e.Appearance.BackColor = Color.Blue
                        e.Appearance.ForeColor = Color.White
                    Case DayOfWeek.Friday.ToString, DayOfWeek.Monday.ToString, DayOfWeek.Saturday.ToString, DayOfWeek.Sunday.ToString, DayOfWeek.Thursday.ToString, DayOfWeek.Tuesday.ToString, DayOfWeek.Wednesday.ToString
                        e.Appearance.BackColor = Color.Black
                        e.Appearance.ForeColor = Color.White
                End Select
            End If

            If e.Column.FieldName = "Sn1" Then
                If e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Red
                End If
                If e.CellValue.ToString = "---" Then
                    e.Appearance.BackColor = Color.Black
                    e.Appearance.ForeColor = Color.Black
                End If
                If e.CellValue.ToString = "OFF" Then
                    e.Appearance.BackColor = Color.Blue
                    e.Appearance.ForeColor = Color.White
                End If

            End If

            If e.Column.FieldName = "Sd2" Then
                If e.CellValue.ToString = "-" Then
                    e.Appearance.BackColor = Color.Black
                    e.Appearance.ForeColor = Color.Black
                End If
                If e.CellValue.ToString = "-." Then
                    e.Appearance.BackColor = Color.Blue
                    e.Appearance.ForeColor = Color.Blue
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GridView2_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView2.SelectionChanged
        ShowSelectionAtt()
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.FieldName = "Sn1" Then
            Dim DBCon As New SqlConnection(CsmdCon.ConSqlDB)
            'Dim FAZ As New CsmdBioAttendenceEntities
            'Dim DBCon As New SqlConnection(FAZ.Database.Connection.ConnectionString)
            'Dim uID As Integer = CInt(GridView2.GetFocusedRowCellValue("USERID"))
            Dim dAT As Date = CDate(GridView2.GetFocusedRowCellValue("Date"))

            Dim uID As Integer = 0
            Dim sSN As String = CType(GridView2.GetFocusedRowCellValue("SSN"), String)


            'MsgBox(EmpName & "   " & sSN)
            'MsgBox(e.Value.ToString)



            Dim datX As DateTime = CDate(CDate(dAT.Date & " " & CDate(e.Value).ToString("HH:mm:ss")))

            'MsgBox(datX)

            Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT        dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_ID, dbo.Attendence_Status.Attendence_Status_Type " &
"FROM            dbo.Attendence_Status INNER JOIN " &
 "                        dbo.Emp_Bio_Device_Users ON dbo.Attendence_Status.Attendence_Status_ID = dbo.Emp_Bio_Device_Users.Attendence_Status_ID " &
"WHERE      (dbo.Emp_Bio_Device_Users.Emp_ID = " & EmpID & ") AND (dbo.Attendence_Status.Attendence_Status_Type = '" & sSN & "')", DBCon)
            Dim dsEmp As New DataSet()
            da.Fill(dsEmp)
            If dsEmp.Tables(0).Rows.Count > 0 Then
                uID = CInt(dsEmp.Tables(0).Rows(0).Item("Emp_Bio_Device_Users_UserID"))


                Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT * From Emp_Attendence_Device WHERE Emp_Attendence_Device_Status = 'true' and Emp_Bio_Device_Users_UserID=" & uID & " AND Emp_Attendence_Device_DateTime = '" & datX.ToString("yyyy/MM/dd HH:mm:ss") & "'", DBCon)
                Dim dsEmp2 As New DataSet()
                da2.Fill(dsEmp2)
                If dsEmp2.Tables(0).Rows.Count > 0 Then

                Else
                    'MsgBox("Not have")
                    Insert_CheckInOut(uID, CType(datX, String), datX.ToString("HH:mm"))
                End If
            End If
            '    'MsgBox(uID)

        End If
    End Sub
    Public Sub Insert_CheckInOut(UserID As Integer, DateTim As String, tim As String)
        'Try
        Dim datX As String = CDate(DateTim).ToString("yyyy/MM/dd HH:mm:ss")
        Dim datc As String = CDate(DateTim).ToString("yyyy/MM/dd")
        'Dim Crt_Login As String = "create login " & UserID.EditValue & " with password='" & UserPass.EditValue & "'"
        Dim Crt_User As String = "INSERT INTO Emp_Attendence_Device (Emp_Bio_Device_Users_UserID,Emp_Attendence_Device_DateTime,Emp_Attendence_Device_Date,Emp_Attendence_Device_Time,Emp_Attendence_Device_Status) VALUES (" & UserID & ",'" & datX & "','" & datc & "','" & tim & "','true')"
        Dim SqldataSet As New DataSet()
        Dim dataadapter As New SqlDataAdapter
        Dim cmd As New SqlCommand
        Dim connection As New SqlConnection(CsmdCon.ConSqlDB)
        connection.Open()
        cmd.Connection = connection
        'cmd.CommandText = Crt_Login
        'cmd.ExecuteScalar()
        cmd.CommandText = Crt_User
        cmd.ExecuteNonQuery()
        connection.Close()

        MsgBox("Add new Success")

        'Load_Detail_View_DeviceBy_Day(EmpName, EmpDate)
        'Load_Detail_View_DeviceBy_Month(EmpName, Dtp1.EditValue)
        'Catch ex As sqlException
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub GridView2_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView2.RowClick
        RowFocus = e.RowHandle
        EmpDate = CDate(GridView2.GetFocusedRowCellValue("Date"))
    End Sub

    Dim intList() As Integer
    Dim intLists() As String
    Dim intListsX() As String

    Private Sub ShowSelectionAtt()
        Try
            Dim RowCount As Integer = GridView2.SelectedRowsCount - 1
            ReDim intList(RowCount)
            ReDim intLists(RowCount)
            ReDim intListsX(RowCount)
            For i As Integer = 0 To RowCount
                Dim row As Integer = (GridView2.GetSelectedRows()(i))
                Dim obj As Object = TryCast(GridView2.GetRowCellValue(row, "USERID"), Object)
                Dim objs As Object = TryCast(GridView2.GetRowCellValue(row, "Date"), Object)
                Dim objsx As Object = TryCast(GridView2.GetRowCellValue(row, "Sn1"), Object)
                If obj Is Nothing Then
                    Return
                End If
                If objs Is Nothing Then
                    Return
                End If
                If objsx Is Nothing Then
                    Return
                End If
                intList(i) = CInt(obj)
                intLists(i) = objs.ToString
                intListsX(i) = objsx.ToString
            Next i
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Live Editors"
    Private Sub BarButtonItem3_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick

        Call Load_Detail_View_DeviceBy_MonthBy_Edit(CDate(Dtp1.EditValue))
        If bn = True Then
            'Dtp1.EditValue = EmpDate
            Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
            'bn = False
        Else
            Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate) '(EmpName, EmpDate)
            'bn = True
        End If
    End Sub
    Public Sub Load_Detail_View_DeviceBy_MonthBy_Edit(DateX As Date)
        Using db As New CsmdBioAttendenceEntities

            Dim FromDat As DateTime = DateX.Date

            Dim firstDay As Date = CDate(FF1.EditValue) ' CsmdDateTime.FirstDayOfMonth(FromDat)
            Dim lastDay As Date = CDate(FF2.EditValue) ' DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))
            'ClickforMonthly.Caption = "Now " & EmpName & " >>>"
            If intList.Count > 0 Then
                For i As Integer = 0 To intList.Count - 1
                    Dim EmpID As Integer = intList(i)
                    Dim dtz = (From a In db.Employees Where a.Emp_ID = EmpID Select a).FirstOrDefault
                    If dtz IsNot Nothing Then
                        Dim k As Integer = 1
                        ProgressBarControl1.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate))
                        ProgressBarControl1.Properties.Minimum = 0
                        ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                        ProgressBarControl1.Position = 0
                        ProgressBarControl1.Update()

                        For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate


                            Dim thisDate As Date = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(DateX.Date))
                            Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(DateX.Date))
                            'Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
                            'Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))

                            'MsgBox(TiA)
                            'MsgBox(TiB)

                            ProgressBarControl1.Position = k
                            ProgressBarControl1.Update()
                            k += 1

                            'Mtr = DataT.NewRow
                            'Mtr.Item("USERID") = EmpCode
                            'Mtr.Item("Sd1") = thisDate.Date.ToString("dd")
                            'Mtr.Item("Sd2") = "-"
                            'Mtr.Item("Date") = thisDate.Date
                            ''Mtr.Item("SSN") = "Duty ON " & EmpDutyOn & " - OFF " & EmpDutyOff & " - " & thisDate.Date.ToString("dddd")
                            'Mtr.Item("SSN") = thisDate.Date.ToString("dddd")
                            'Mtr.Item("Sn1") = "---"
                            'DataT.Rows.Add(Mtr)

                            'Dim hh As String = ConfigurationManager.ConnectionStrings("att2000ConnectionString").ConnectionString
                            Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
                            Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name,dbo.Emp_Bio_Device_Users.Emp_ID, " &
        "dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID " &
        "FROM  dbo.Emp_Attendence_Device INNER JOIN " &
        "dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
        "dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
        "            WHERE " &
        "(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime >= '" & thisDate.ToString("yyyy/MM/dd HH:mm") & "') AND  " &
        "(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime <= '" & ToDate.ToString("yyyy/MM/dd HH:mm") & "')  " &
        "AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & EmpID & ") AND (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
                            Dim ds2 As New DataSet()
                            da2.Fill(ds2)
                            Dim chkA As Boolean = False
                            Dim chkADate As Date
                            Dim chkB As Boolean = False
                            Dim chkBtime As String = ""
                            Dim chkC As Boolean = False
                            Dim chkD As Boolean = False
                            Dim chkE As Boolean = False
                            Dim chkA2 As Boolean = False
                            Dim chkAA2 As Boolean = False
                            Dim chkB2 As Boolean = False
                            Dim chkC2 As Boolean = False
                            Dim chkD2 As Boolean = False
                            Dim chkE2 As Boolean = False

                            Dim mn As Integer = 0
                            Dim pR As Integer = 0
                            Dim vdd As String = ""
                            Dim cdd As String = ""
                            Dim uIDs As Integer
                            If ds2.Tables(0).Rows.Count > 0 Then

                                For Each dsx As DataRow In ds2.Tables(0).Rows
                                    If CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") >= thisDate.ToString("yyyy/MM/dd HH") And CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") <= ToDate.ToString("yyyy/MM/dd HH") Then

                                        Dim uID As Integer = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                        chkADate = CDate(CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy"))
                                        If dsx.Item("Attendence_Status_Type").ToString = "RT-Check In" Then
                                            If chkA2 = False Then
                                                cdd = CType(CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), String)

                                                EditDEvice(uID, True, CType(TT1.EditValue, String), CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), CDate(dsx.Item("Emp_Attendence_Device_DateTime")))
                                                uIDs = uID

                                                chkA = True
                                                chkA2 = True
                                                'Lst1.Items.Add("c1" & "" & thisDate.ToString("dd"))
                                            Else
                                                EditDEvice(uID, False, CType(TT1.EditValue, String), CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), CDate(dsx.Item("Emp_Attendence_Device_DateTime")))

                                                chkA = False
                                                chkA2 = True

                                                'Lst1.Items.Add("c2" & "" & thisDate.ToString("dd"))
                                            End If

                                        Else
                                            If dsx.Item("Attendence_Status_Type").ToString = "LT-Check Out" Then
                                                If mn = 0 And chkA = True Then
                                                    EditDEvice(uID, True, CType(TT2.EditValue, String), CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), CDate(dsx.Item("Emp_Attendence_Device_DateTime")))
                                                    mn = 1
                                                    chkA = False
                                                    'Lst1.Items.Add("c4a" & "" & thisDate.ToString("dd"))
                                                Else
                                                    If mn = 0 Then
                                                        Dim dti As String = CDate(TT1.EditValue).AddMinutes(CDbl(ck1.EditValue)).ToString("HH:mm")
                                                        Dim dStr As String = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy") & " " & dti

                                                        EditDEvice(uID - 1, True, CType(TT1.EditValue, String), CDate(dti), CDate(dStr))
                                                        chkA2 = True
                                                        chkA = False
                                                        'Lst1.Items.Add("c4b" & "" & thisDate.ToString("dd"))
                                                        mn = 1
                                                    Else
                                                        If mn = 1 Then
                                                            EditDEvice(uID, False, CType(TT2.EditValue, String), CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), CDate(dsx.Item("Emp_Attendence_Device_DateTime")))

                                                            'Lst1.Items.Add("c4c" & "" & thisDate.ToString("dd"))
                                                            chkA2 = False
                                                            chkA = False
                                                        End If
                                                    End If

                                                End If

                                                'If chkA = True And chkA2 = True Then
                                                '    



                                                '    Lst1.Items.Add("c3" & "" & thisDate.ToString("dd"))
                                                'Else
                                                '    If chkA2 = False Then
                                                '        Dim dti As String = CDate(TT1.EditValue).AddMinutes(CDbl(ck1.EditValue)).ToString("HH:mm")
                                                '        Dim dStr As String = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy") & " " & dti

                                                '        EditDEvice(uID - 1, True, CType(TT1.EditValue, String), CDate(dti), CDate(dStr))
                                                '        chkA2 = True
                                                '        Lst1.Items.Add("c4a" & "" & thisDate.ToString("dd"))
                                                '    Else
                                                '        EditDEvice(uID, False, CType(TT2.EditValue, String), CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), CDate(dsx.Item("Emp_Attendence_Device_DateTime")))

                                                '        'chkA2 = False
                                                '        chkA = False
                                                '        Lst1.Items.Add("c4b" & "" & thisDate.ToString("dd"))
                                                '    End If
                                                'End If

                                            End If
                                        End If
                                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                        If dsx.Item("Attendence_Status_Type").ToString = "RI-Prayer A" Then
                                            'If pR = 0 Then
                                            '    cdd = CType(CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), String)
                                            '    Lst1.Items.Add("c4a" & "" & thisDate.ToString("dd"))
                                            '    chkB = True
                                            '    pR = 1
                                            '    uIDs = uID
                                            'Else
                                            '    vdd = CType(CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), String)
                                            '    If cdd = vdd Then
                                            '        Lst1.Items.Add("c4bbbb" & "" & thisDate.ToString("dd"))
                                            '    Else

                                            '        Lst1.Items.Add("c4a" & "" & thisDate.ToString("dd"))
                                            '    End If

                                            'End If
                                        Else
                                            'If dsx.Item("Attendence_Status_Type").ToString = "LI-Prayer B" Then
                                            '    If cdd = vdd Then
                                            '        EditDEvice(uID, False, "", CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), CDate(dsx.Item("Emp_Attendence_Device_DateTime")))
                                            '    Else
                                            '        vdd = CType(CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), String)
                                            '        If cdd = vdd Then
                                            '            EditDEvice(uID, False, "", CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), CDate(dsx.Item("Emp_Attendence_Device_DateTime")))

                                            '        End If
                                            '        cdd = CType(CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), String)
                                            '        Lst1.Items.Add("c4b" & "" & thisDate.ToString("dd"))
                                            '        pR = 0
                                            '        chkB = False
                                            '    End If
                                            'End If
                                        End If
                                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                        If dsx.Item("Attendence_Status_Type").ToString = "RM-Short Leave A" Then
                                            If chkC2 = False Then
                                                chkC = True
                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                'DataT.Rows.Add(Mtr)
                                                chkC2 = True
                                            Else
                                                chkC = False
                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                'DataT.Rows.Add(Mtr)

                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                                'Mtr.Item("Date") = DateX.Date
                                                'Mtr.Item("SSN") = "LM-Short Leave B"
                                                'Mtr.Item("Sn1") = ""
                                                'DataT.Rows.Add(Mtr)

                                            End If

                                        Else
                                            If dsx.Item("Attendence_Status_Type").ToString = "LM-Short Leave B" Then

                                                If chkC = False Then
                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = "RM-Short Leave A"
                                                    'Mtr.Item("Sn1") = ""
                                                    'DataT.Rows.Add(Mtr)

                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                    'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                    'DataT.Rows.Add(Mtr)
                                                    chkC2 = False
                                                Else
                                                    chkC = False
                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                    'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                    'DataT.Rows.Add(Mtr)
                                                    chkC2 = False
                                                End If

                                            End If
                                        End If
                                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                        If dsx.Item("Attendence_Status_Type").ToString = "RR-Lunch A" Then
                                            If chkD2 = False Then
                                                chkD = True
                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                'DataT.Rows.Add(Mtr)
                                                chkD2 = True
                                            Else
                                                chkD = False
                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                'DataT.Rows.Add(Mtr)

                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                                'Mtr.Item("Date") = DateX.Date
                                                'Mtr.Item("SSN") = "LR-Lunch B"
                                                'Mtr.Item("Sn1") = ""
                                                'DataT.Rows.Add(Mtr)

                                            End If


                                        Else
                                            If dsx.Item("Attendence_Status_Type").ToString = "LR-Lunch B" Then

                                                If chkD = False Then
                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = "RR-Lunch A"
                                                    'Mtr.Item("Sn1") = ""
                                                    'DataT.Rows.Add(Mtr)

                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                    'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                    'DataT.Rows.Add(Mtr)
                                                    chkD2 = False
                                                Else
                                                    chkD = False
                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                    'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                    'DataT.Rows.Add(Mtr)
                                                    chkD2 = False
                                                End If
                                                'Else
                                                '    If chkD = True Then
                                                '        chkD = False
                                                '        Mtr = DataT.NewRow
                                                '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                                                '        Mtr.Item("SSN") = "LR-Lunch B"
                                                '        Mtr.Item("Sn1") = ""
                                                '        DataT.Rows.Add(Mtr)
                                                '    End If
                                            End If
                                        End If
                                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                        If dsx.Item("Attendence_Status_Type").ToString = "RP-Private A" Then
                                            cdd = CType(CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), String)
                                            If chkE2 = False Then
                                                chkE = True

                                                chkE2 = True
                                            Else
                                                chkE = False
                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                                'DataT.Rows.Add(Mtr)

                                                'Mtr = DataT.NewRow
                                                'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                                                'Mtr.Item("Date") = DateX.Date
                                                'Mtr.Item("SSN") = "LP-Private B"
                                                'Mtr.Item("Sn1") = ""
                                                'DataT.Rows.Add(Mtr)


                                            End If


                                        Else

                                            If dsx.Item("Attendence_Status_Type").ToString = "LP-Private B" Then
                                                cdd = CType(CDate(CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")), String)
                                                If chkE = False Then
                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = "RP-Private A"
                                                    'Mtr.Item("Sn1") = ""
                                                    'DataT.Rows.Add(Mtr)

                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                    'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                                    'DataT.Rows.Add(Mtr)
                                                    chkE2 = False
                                                Else
                                                    chkE = False
                                                    'Mtr = DataT.NewRow
                                                    'Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                                    'Mtr.Item("Date") = dsx.Item("Emp_Attendence_Device_DateTime")
                                                    'Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                                    'Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                                    'DataT.Rows.Add(Mtr)
                                                    chkE2 = False
                                                End If

                                            End If
                                        End If

                                    End If
                                    'chkA2 = False
                                    'chkA = False
                                Next

                                If chkA = True Then
                                    chkA = False
                                    'Mtr = DataT.NewRow
                                    'Mtr.Item("USERID") = EmpCode
                                    'Mtr.Item("Date") = thisDate.Date
                                    'Mtr.Item("SSN") = "LT-Check Out"
                                    'Mtr.Item("Sn1") = ""
                                    'DataT.Rows.Add(Mtr)
                                    Dim dti As String = CDate(TT2.EditValue).AddMinutes(CDbl(ck2.EditValue)).ToString("HH:mm")
                                    Dim dStr As String = chkADate & " " & dti

                                    EditDEvice(uIDs + 1, True, CType(TT2.EditValue, String), CDate(CDate(dti).ToString("HH:mm")), CDate(CDate(dStr).ToString("dd/MM/yyyy HH:mm")))
                                    'mn = 1
                                End If
                                If chkB = True Then
                                    chkB = False
                                    Dim dti As String = CDate(cdd).AddMinutes(CDbl(ck2.EditValue)).ToString("HH:mm")
                                    Dim dStr As String = chkADate & " " & dti

                                    EditDEvice(uIDs + 1, True, "", CDate(CDate(dti).ToString("HH:mm")), CDate(CDate(dStr).ToString("dd/MM/yyyy HH:mm")))

                                    'Lst1.Items.Add("c4bb" & "" & thisDate.ToString("dd"))
                                    'Mtr = DataT.NewRow
                                    'Mtr.Item("USERID") = EmpCode
                                    'Mtr.Item("Date") = thisDate.Date
                                    'Mtr.Item("SSN") = "LI-Prayer B"
                                    'Mtr.Item("Sn1") = ""
                                    'DataT.Rows.Add(Mtr)
                                    '''''Dim dStrA As String = CDate(chkBtime).ToString("HH:mm")

                                    '''''Dim dti As String = CDate(dStrA).AddMinutes(CDbl(ck3.EditValue)).ToString("HH:mm")
                                    '''''Dim dStr As String = chkADate & " " & dti

                                    '''''EditDEvice(uIDs + 1, True, "", CDate(dti), CDate(dStr))
                                End If
                                If chkC = True Then
                                    chkC = False
                                    'Mtr = DataT.NewRow
                                    'Mtr.Item("USERID") = EmpCode
                                    'Mtr.Item("Date") = thisDate.Date
                                    'Mtr.Item("SSN") = "LM-Short Leave B"
                                    'Mtr.Item("Sn1") = ""
                                    'DataT.Rows.Add(Mtr)
                                End If
                                If chkD = True Then
                                    chkD = False
                                    'Mtr = DataT.NewRow
                                    'Mtr.Item("USERID") = EmpCode
                                    'Mtr.Item("Date") = thisDate.Date
                                    'Mtr.Item("SSN") = "LR-Lunch B"
                                    'Mtr.Item("Sn1") = ""
                                    'DataT.Rows.Add(Mtr)
                                End If
                                If chkE = True Then
                                    chkE = False
                                    'Mtr = DataT.NewRow
                                    'Mtr.Item("USERID") = EmpCode
                                    'Mtr.Item("Date") = thisDate.Date
                                    'Mtr.Item("SSN") = "LP-Private B"
                                    'Mtr.Item("Sn1") = ""
                                    'DataT.Rows.Add(Mtr)
                                End If

                            Else
                                'Mtr = DataT.NewRow
                                'Mtr.Item("USERID") = EmpCode
                                'Mtr.Item("Sd1") = ""
                                ''Mtr.Item("Sd2") = "-."
                                'Mtr.Item("Date") = thisDate.Date
                                'Mtr.Item("SSN") = "Absent"
                                'Mtr.Item("Sn1") = "OFF"
                                'DataT.Rows.Add(Mtr)

                            End If

                            chkA2 = False

                            'DBCon2.Close()
                        Next

                    End If
                Next
            End If


            GridControl5.DataSource = Nothing
            'GridControl5.DataSource = DataT
            Dim dt = (From a In db.Employees Where a.Emp_ID = EmpID Select a).FirstOrDefault
            If dt IsNot Nothing Then
                Load_Detail_View_DeviceBy_Month(EmpID, dt.Emp_Reg, EmpDate)
            Else
                GridControl5.DataSource = Nothing
            End If
        End Using
    End Sub
    Public Sub EditDEvice(uID As Integer, Status As Boolean, dutyOnOff As String, timeX As Date, datetimeX As DateTime)
        Using db As New CsmdBioAttendenceEntities
            '  Dim datt As Date = CDate(CType(datetimeX.ToString("dd/MM/yyyy"), Date?))
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Status = True And a.Emp_Bio_Device_Users_UserID = uID And a.Emp_Attendence_Device_DateTime = datetimeX Select a).FirstOrDefault
            If dt IsNot Nothing Then
                If Not dutyOnOff = "" Then
                    dt.Emp_Attendence_Device_Duty_On_Off = CDate(dutyOnOff).ToString("HH:mm")
                End If

                dt.Emp_Attendence_Device_Status = Status
                dt.Emp_Attendence_Device_Time = timeX.ToString("HH:mm")
                'dt.Emp_Attendence_Device_DateTime = datetimeX
                dt.Emp_Attendence_Device_Date = CType(datetimeX.ToString("dd/MM/yyyy"), Date?)
                db.SaveChanges()
            Else
                Dim dtNew = New Emp_Attendence_Device
                With dtNew
                    .Emp_Bio_Device_Users_UserID = uID
                    If Not dutyOnOff = "" Then
                        .Emp_Attendence_Device_Duty_On_Off = CDate(dutyOnOff).ToString("HH:mm")
                    End If
                    .Emp_Attendence_Device_Status = Status
                    .Emp_Attendence_Device_Time = timeX.ToString("HH:mm")
                    .Emp_Attendence_Device_DateTime = datetimeX
                    .Emp_Attendence_Device_Date = CType(datetimeX.ToString("dd/MM/yyyy"), Date?)
                End With
                db.Emp_Attendence_Device.Add(dtNew)
                db.SaveChanges()
            End If

        End Using
    End Sub

#End Region
    Dim bn As Boolean = False

    Dim EmpID As Integer = 0
    Dim EmpName As String = ""
    Dim EmpDate As Date


    ''DELETE FROM DATABASE
    'Private Sub Delete(id As String)
    '    'ELETE SQL STATEMENT
    '    Dim sql As String = "DELETE FROM spacecraftsTB WHERE ID=" + id + ""
    '    cmd = New OleDbCommand(sql, con)

    '    'OPEN CONNECTION,EXECUTE DELETE,CLOSE CONNECTION
    '    Try
    '        con.Open()
    '        adapter = New OleDbDataAdapter(cmd)
    '        adapter.DeleteCommand = con.CreateCommand()
    '        adapter.DeleteCommand.CommandText = sql

    '        'PROMPT FOR CONFIRMATION BEFORE DELETE
    '        If MessageBox.Show("Are you sure to permanently delete this?", "DELETE", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.OK Then
    '            If cmd.ExecuteNonQuery() > 0 Then
    '                CleartextBoxes()
    '                MsgBox("Successfully deleted")
    '            End If
    '        End If
    '        con.Close()
    '        Retrieve()

    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        con.Close()
    '    End Try
    'End Sub

    Dim RowFocus As Integer = 0



    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick

    End Sub


#Region "RepositoryItem"
    Private Sub RepositoryItemTimeEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTimeEdit2.EditValueChanged
        Dim kk As TimeEdit = TryCast(sender, TimeEdit)
        kk.EditValue = CDate(kk.EditValue).ToString("HH:mm")
    End Sub


    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click

    End Sub

    Private Sub RepositoryItemButtonEdit2_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit2.Click
        Using db As New CsmdBioAttendenceEntities
            EmpID = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            'EmpName = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Name"), String)
            EmpDate = CDate(Dtp1.EditValue) ' CDate(AdvBandedGridView1.GetFocusedRowCellValue("Date"))
            Dim dt = (From a In db.Employees Where a.Emp_ID = EmpID Select a).FirstOrDefault
            If dt IsNot Nothing Then
                FilterMonth = True
                GridColumn17.Caption = "MonthView " & dt.Emp_Name
                Load_Detail_View_DeviceBy_Month(EmpID, dt.Emp_Reg, EmpDate)
                GridView2.MoveBy(RowFocus)
            Else
                GridControl5.DataSource = Nothing
            End If
        End Using
    End Sub
    Private Sub RepositoryItemSpinEdit1_Spin(sender As Object, e As SpinEventArgs) Handles RepositoryItemSpinEdit1.Spin
        Dim spn As SpinEdit = TryCast(sender, SpinEdit)
        FormSize(CInt(If(spn.EditValue.ToString = "", 8.25, spn.EditValue)))
    End Sub

    Private Sub RepositoryItemDateEdit3_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemDateEdit3.ButtonClick
        Select Case e.Button.Index
            Case 1
                Dim d1 As DateTime = CDate(Dtp1.EditValue)
                Dtp1.EditValue = DateTime.Parse(CType(d1, String)).AddDays(-1)
                'bn = False
                'EmpDate = CDate(Dtp1.EditValue)
                'Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate)
            Case 2
                Dim d1 As DateTime = CDate(Dtp1.EditValue)
                Dtp1.EditValue = DateTime.Parse(CType(d1, String)).AddMonths(-1)
                FF1.EditValue = DateTime.Parse(CType(FF1.EditValue, String)).AddMonths(-1)
                FF2.EditValue = DateTime.Parse(CType(FF2.EditValue, String)).AddMonths(-1)
                'Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
            Case 3
                Dim d1 As DateTime = CDate(Dtp1.EditValue)
                Dtp1.EditValue = DateTime.Parse(CType(d1, String)).AddDays(1)
                'bn = False
                'EmpDate = CDate(Dtp1.EditValue)
                'Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate)
            Case 4
                Dim d1 As DateTime = CDate(Dtp1.EditValue)
                Dtp1.EditValue = DateTime.Parse(CType(d1, String)).AddMonths(1)
                FF1.EditValue = DateTime.Parse(CType(FF1.EditValue, String)).AddMonths(1)
                FF2.EditValue = DateTime.Parse(CType(FF2.EditValue, String)).AddMonths(1)
                'Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
        End Select

        'Timer2.Enabled = False
        'BarEditItem9.EditValue = False
        'BarStaticItem3.Caption = "Stop"
    End Sub

#End Region
    Dim FilterMonth As Boolean = False

#Region "BarButtonItem"
    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        bn = False
        EmpDate = CDate(Dtp1.EditValue)
        Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate)
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick

        'Try
        If MsgBox("Are you sure want to Delete a this record", MsgBoxStyle.YesNo, "Delete") = vbYes Then
            If intList.Count > 0 Then
                For i As Integer = 0 To intList.Count - 1
                    Dim uID As Integer = intList(i)
                    'MsgBox(datX)
                    If Not intLists(i) = "" Then
                        Dim dAT As Date = CDate(intLists(i))
                        'Dim datX As Date = CDate(CDate(dAT).ToString("G")) '& " " & CDate(intListsX(i)).ToString("HH: mm")).ToString("G")
                        'Dim Crt_User As String = "DELETE * FROM CHECKINOUT WHERE USERID=" & uID & " And CHECKTIME = #" & datX & "#"
                        'BarEditItem2.EditValue = Crt_User
                        'Dim SqldataSet As New DataSet()
                        'Dim dataadapter As New OleDb.OleDbDataAdapter


                        'Dim cmd As New OleDb.OleDbCommand
                        'Dim con As New OleDb.OleDbConnection(CsmdCon.ConOleDB)
                        'Dim adapter As New OleDbDataAdapter
                        'con.Open()
                        'adapter = New OleDbDataAdapter(cmd)
                        'adapter.DeleteCommand = con.CreateCommand()
                        'adapter.DeleteCommand.CommandText = Crt_User

                        'If cmd.ExecuteNonQuery() > 0 Then
                        '    MsgBox("Delete Is Success", MsgBoxStyle.Information, "Delete Done")
                        'End If
                        ''cmd.Connection = con
                        ''cmd.CommandText = Crt_User
                        ''cmd.ExecuteNonQuery()
                        'con.Close()

                        'MsgBox(Crt_User)


                        Dim datX As Date = CDate(CDate(dAT).ToString("G")) '& " " & CDate(intListsX(i)).ToString("HH: mm")).ToString("G")
                        Dim Crt_User As String = "UPDATE [dbo].[Emp_Attendence_Device]  " &
"SET [Emp_Attendence_Device_Status] = 'false' WHERE Emp_Bio_Device_Users_UserID = @USERID AND Emp_Attendence_Device_DateTime = @DateT ;"

                        'BarEditItem2.EditValue = Crt_User
                        'Dim SqldataSet As New DataSet()
                        'Dim dataadapter As New OleDb.OleDbDataAdapter
                        Dim cmd As New SqlCommand
                        Dim con As New SqlConnection(CsmdCon.ConSqlDB)


                        cmd.Connection = con
                        con.Open()
                        cmd.Parameters.AddWithValue("@USERID", uID)
                        cmd.Parameters.AddWithValue("@DateT", datX)
                        cmd.CommandText = Crt_User
                        cmd.ExecuteNonQuery()
                        'If cmd.ExecuteNonQuery() > 0 Then
                        '    MsgBox("Delete is Success", MsgBoxStyle.Information, "Delete Done")
                        'End If
                        cmd.Dispose()
                        con.Close()


                    End If

                Next
                'MsgBox(intList.Count)
                'intList
                'Load_Detail_View_DeviceBy_Day(EmpName, EmpDate)
                MsgBox("Delete is Success", MsgBoxStyle.Information, "Delete Done")
                If FilterMonth = False Then
                    Load_Detail_View_DeviceBy_Day(EmpID, EmpDate)
                Else
                    BarButtonItem1.PerformClick()
                End If
                'Load_Detail_View_DeviceBy_Month(EmpName, Dtp1.EditValue)
                'GridView2.ClearSelection()
                'GridView2.MoveBy(RowFocus)
            Else
                MsgBox("Please Select Record for DELETE", MsgBoxStyle.Critical, "Selection Error")
            End If
        Else
            Exit Sub
        End If
        'Catch ex As Exception

        'End Try
        '        DELETE From CHECKINOUT Where USERID = 513 And CHECKTIME = #
        '28/08/2021 8:43:08 am#
    End Sub
    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

        'Load_Detail_View_DeviceBy_Day(EmpName, EmpDate)
        'Load_Detail_View_DeviceBy_Month(EmpName, Dtp1.EditValue)
        'Using db As New CsmdBioAttendenceEntities
        '    Dim mm = (From a In db.Emp_CheckInOut_Detail Select a).ToList
        '    If mm.Count > 0 Then
        '        GridControl5.DataSource = mm
        '    Else
        '        GridControl5.DataSource = Nothing
        '    End If

        'End Using
    End Sub

    Private Sub BarEditItem4_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem4.EditValueChanged
        FormSize(CInt(If(BarEditItem4.EditValue.ToString = "", 8.25, BarEditItem4.EditValue)))
    End Sub

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        bn = False
        Load_From_DeviceDB()
        EmpDate = CDate(Dtp1.EditValue)
        Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate)
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        bn = False
        Dtp1.EditValue = Today
        Load_From_DeviceDB()
        EmpDate = CDate(Dtp1.EditValue)
        Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate)
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
        '    Lst1.Items.Clear()
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick

        Using db As New CsmdBioAttendenceEntities

            EmpID = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            EmpDate = CDate(AdvBandedGridView1.GetFocusedRowCellValue("Date"))
            Dim dt = (From a In db.Employees Where a.Emp_ID = EmpID Select a).FirstOrDefault
            If dt IsNot Nothing Then
                Load_Detail_View_DeviceBy_Month(EmpID, dt.Emp_Reg, EmpDate)
            Else
                GridControl5.DataSource = Nothing
            End If

        End Using
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Class1.MasterLive = "OpenAdmin"
        Me.Show()
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Me.Close()
    End Sub

    Private Sub BarButtonItem3_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim strr As String = "The Leads High School (RajaPur) CSMD Attendance Software Online"
        Dim fr As System.Net.HttpWebRequest
        'Dim targetURI As New Uri("https://api.callmebot.com/whatsapp.php?phone=+923327117786&text=" & strr & "&apikey=506371")
        'Dim targetURI As New Uri("http://api.callmebot.com/whatsapp.php?phone=+923456914893&text=" & strr & "&apikey=758488")
        Dim targetURI As New Uri("http://api.callmebot.com/whatsapp.php?phone=+923005474470&text=" & strr & "&apikey=179837")
        fr = DirectCast(HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
        If (fr.GetResponse().ContentLength > 0) Then
            Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
            'Response.Write(str.ReadToEnd())
            str.Close()
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Using db As New CsmdBioAttendenceEntities
            ' Dim empID As Integer = 1
            Dim dateX As Date = CDate(Dtp1.EditValue)
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Bio_Device_Users.Emp_ID = EmpID And a.Emp_Attendence_Device_Date.Value.Month = dateX.Month And a.Emp_Attendence_Device_Date.Value.Year = dateX.Year Select a).ToList
            If dt.Count > 0 Then
                For Each dts In dt
                    If dts.Emp_Attendence_Device_Status = False Then
                        dts.Emp_Attendence_Device_Status = True
                    End If
                Next
                db.SaveChanges()
                MsgBox("Reset Successfull")
                BarButtonItem1.PerformClick()
            End If
        End Using
    End Sub

#End Region



#Region "Communication"
    Public axCZKEM1 As New zkemkeeper.CZKEM
    Private bIsConnected As Boolean = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer 'the serial number of the device.After connecting the device ,this value will be changed.

    'If your device supports the TCP/IP communications, you can refer to this.
    'when you are using the tcp/ip communication,you can distinguish different devices by their IP address.
    Private Sub btnConnect_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnConnect.ItemClick
        If txtIP.EditValue.ToString = "" Or txtPort.EditValue.ToString = "" Then
            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor
        If btnConnect.Caption = "Disconnect" Then
            axCZKEM1.Disconnect()
            'RemoveHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
            'RemoveHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
            'RemoveHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
            'RemoveHandler axCZKEM1.OnAttTransaction, AddressOf AxCZKEM1_OnAttTransaction
            RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            'RemoveHandler axCZKEM1.OnKeyPress, AddressOf AxCZKEM1_OnKeyPress
            'RemoveHandler axCZKEM1.OnEnrollFinger, AddressOf AxCZKEM1_OnEnrollFinger
            'RemoveHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
            'RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
            'RemoveHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
            'RemoveHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
            'RemoveHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
            'RemoveHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
            'RemoveHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum
            bIsConnected = False
            btnConnect.Caption = "Connect"
            lblState.Caption = "Status: Disconnected"
            lblState.ItemAppearance.Normal.BackColor = Color.Red
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected = axCZKEM1.Connect_Net(txtIP.EditValue.ToString, Convert.ToInt32(txtPort.EditValue.ToString))
        If bIsConnected = True Then
            btnConnect.Caption = "Disconnect"
            btnConnect.Refresh()
            lblState.Caption = "Current State: Connected"
            lblState.ItemAppearance.Normal.BackColor = Color.LimeGreen
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            'Download_By_Month()
            'axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                'AddHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
                'AddHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
                'AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                'AddHandler axCZKEM1.OnAttTransaction, AddressOf AxCZKEM1_OnAttTransaction
                AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                'AddHandler axCZKEM1.OnKeyPress, AddressOf AxCZKEM1_OnKeyPress
                'AddHandler axCZKEM1.OnEnrollFinger, AddressOf AxCZKEM1_OnEnrollFinger
                'AddHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
                'AddHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
                'AddHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
                'AddHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
                'AddHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
                'AddHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
                'AddHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum

            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        Download_By_Month()
    End Sub
    'Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
    '    KK()
    'End Sub
    'Public Sub KK()
    '    If bIsConnected = False Then
    '        MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
    '        Return
    '    End If

    '    Dim ret As Integer = 0
    '    axCZKEM1.EnableDevice(iMachineNumber, False)
    '    Dim sdwEnrollNumber As String = ""
    '    Dim idwVerifyMode As Integer = 0
    '    Dim idwInOutMode As Integer = 0
    '    Dim idwYear As Integer = 0
    '    Dim idwMonth As Integer = 0
    '    Dim idwDay As Integer = 0
    '    Dim idwHour As Integer = 0
    '    Dim idwMinute As Integer = 0
    '    Dim idwSecond As Integer = 0
    '    Dim idwWorkcode As Integer = 0
    '    Dim f1 As Date = CType(CsmdDateTime.FirstDayOfMonth(CDate(Dtp1.EditValue)), Date)
    '    Dim f2 As Date = CType(CsmdDateTime.LastDayOfMonth(CDate(Dtp1.EditValue)), Date)
    '    Dim idwErrorCode As Integer
    '    Dim iGLCount = 0
    '    Dim fromtime As String = f1.ToString("yyyy-MM-dd HH:mm:ss")
    '    Dim totime As String = f2.ToString("yyyy-MM-dd HH:mm:ss")
    '    'If axCZKEM1.ReadTimeGLogData(iMachineNumber, fromtime, totime) Then
    '    If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then
    '        'ReadGeneralLogData
    '        While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, sdwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
    '            'Dim dr As DataRow = dt_logPeriod.NewRow()
    '            'dr("User ID") = sdwEnrollNumber
    '            'dr("Verify Date") = idwYear & "-" & idwMonth & "-" & idwDay & " " & idwHour & ":" & idwMinute & ":" & idwSecond
    '            'dr("Verify Type") = idwVerifyMode
    '            'dr("Verify State") = idwInOutMode
    '            'dr("WorkCode") = idwWorkcode
    '            'dt_logPeriod.Rows.Add(dr)
    '        End While

    '        ret = 1
    '    Else
    '        axCZKEM1.GetLastError(idwErrorCode)
    '        ret = idwErrorCode

    '        If idwErrorCode <> 0 Then
    '            '   lblOutputInfo.Items.Add("*Read attlog by period failed,ErrorCode: " & idwErrorCode.ToString())
    '        Else
    '            '   lblOutputInfo.Items.Add("No data from terminal returns!")
    '        End If
    '    End If

    '    axCZKEM1.EnableDevice(iMachineNumber, True)
    'End Sub
    Private Sub Download_By_Month()
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim idwSecond As Integer
        Dim idwEnrollNumber As String = ""
        Dim idwWorkcode As Integer
        Dim idwVerifyMode As Integer
        Dim idwInOutMode As Integer
        Dim idwYear As Integer
        Dim idwMonth As Integer
        Dim idwDay As Integer
        Dim idwHour As Integer
        Dim idwMinute As Integer

        Dim idwErrorCode As Integer
        Dim iGLCount = 0
        'Dim lvItem As New ListViewItem("Items", 0)
        Dim f1 As Date = CType(CsmdDateTime.FirstDayOfMonth(CDate(Dtp1.EditValue)), Date)
        Dim f2 As Date = CType(CsmdDateTime.LastDayOfMonth(CDate(Dtp1.EditValue)), Date)

        Dim fromtime As String = f1.ToString("yyyy-MM-dd HH:mm:ss")
        Dim totime As String = f2.ToString("yyyy-MM-dd HH:mm:ss") ' f2.Year.ToString("yyyy") & "-" + f2.Month.ToString("MM") & "-" & f2.Day.ToString("dd") & " " & f2.Hour.ToString("HH") & ":" & f2.Minute.ToString("mm") & ":" & f2.Second.ToString("ss")
        Cursor = Cursors.WaitCursor

        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then

            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode) 'iGLCount += 1
                'lvItem = lvLogs.Items.Add(iGLCount.ToString())
                'lvItem.SubItems.Add(idwEnrollNumber.ToString())
                'lvItem.SubItems.Add(idwVerifyMode.ToString())
                'lvItem.SubItems.Add(idwInOutMode.ToString())
                Dim kk As String = (idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString())
                Dim dd As DateTime = CDate(CType(kk, DateTime).ToString("yyyy/MM/dd HH:mm:ss"))

                Dim bb As String = (idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString())
                Dim ee As String = CType(bb, DateTime).ToString("yyyy/MM/dd")

                Dim nn As String = (idwHour.ToString() & ":" & idwMinute.ToString())
                Dim ff As String = CType(nn, DateTime).ToString("HH:mm")

                If Not idwEnrollNumber = "" Then
                    Using db As New CsmdBioAttendenceEntities
                        Dim fg = (From a In db.Emp_Attendence_Device Where a.Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?) And a.Emp_Attendence_Device_DateTime = dd Select a).FirstOrDefault
                        If fg IsNot Nothing Then
                            With fg
                                '.Emp_ID = EmpID
                                '.Attendence_Status_ID = dts.Attendence_Status_ID
                                '.Emp_Bio_Device_Users_UserID = nn
                                '.Emp_Bio_Device_User_Name = dty.Emp_Name
                                '.Emp_Bio_Device_User_Finger = 0
                                '.Emp_Bio_Device_User_tmpData = ""
                                '.Emp_Bio_Device_User_Privilege = 0
                                '.Emp_Bio_Device_User_Password = ""
                                '.Emp_Bio_Device_User_Enabled = True
                            End With
                            db.SaveChanges()
                        Else
                            Try
                                Dim dtNew = New Emp_Attendence_Device
                                With dtNew
                                    .Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?)
                                    .Emp_Attendence_Device_DateTime = dd
                                    .Emp_Attendence_Device_Date = CType(ee, Date?)
                                    .Emp_Attendence_Device_Time = ff
                                    .Emp_Attendence_Device_Status = True
                                End With
                                db.Emp_Attendence_Device.Add(dtNew)
                                db.SaveChanges()
                            Catch ex As Exception

                            End Try
                        End If
                    End Using
                    'Else
                    '    MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
                End If

                iGLCount += 1
                'ProgressBarControl1. = (100 / 100) * iGLCount

                ProgressBarControl1.Position = CInt((100 / 100) * iGLCount)
                ProgressBarControl1.Update()
            End While
            ProgressBarControl1.Position = 100
            ProgressBarControl1.Update()
            Load_From_DeviceDB()
        Else
            Cursor = Cursors.Default
            axCZKEM1.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
            End If
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
        Cursor = Cursors.Default
    End Sub

    'Private Sub BarButtonItem2_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
    '    If bIsConnected = False Then
    '        MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
    '        Return
    '    End If

    '    Dim idwSecond As Integer
    '    Dim idwEnrollNumber As String = ""
    '    Dim idwWorkcode As Integer
    '    Dim idwVerifyMode As Integer
    '    Dim idwInOutMode As Integer
    '    Dim idwYear As Integer
    '    Dim idwMonth As Integer
    '    Dim idwDay As Integer
    '    Dim idwHour As Integer
    '    Dim idwMinute As Integer

    '    Dim idwErrorCode As Integer
    '    Dim iGLCount = 0
    '    Dim lvItem As New ListViewItem("Items", 0)
    '    Dim f1 As Date = CType(CsmdDateTime.FirstDayOfMonth(CDate(Dtp1.EditValue)), Date)
    '    Dim f2 As Date = CType(CsmdDateTime.LastDayOfMonth(CDate(Dtp1.EditValue)), Date)

    '    Dim fromtime As String = f1.Year.ToString() & "-" + f1.Month.ToString() & "-" & f1.Day.ToString() & " " & f1.Hour.ToString() & ":" & f1.Minute.ToString() & ":" & f1.Second.ToString()
    '    Dim totime As String = f2.Year.ToString() & "-" + f2.Month.ToString() & "-" & f2.Day.ToString() & " " & f2.Hour.ToString() & ":" & f2.Minute.ToString() & ":" & f2.Second.ToString()
    '    Cursor = Cursors.WaitCursor
    '    lvLogs.Items.Clear()
    '    axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
    '    If axCZKEM1.ReadNewGLogData(iMachineNumber) Then 'read all the attendance records to the memory
    '        'get records from the memory
    '        While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
    '            iGLCount += 1
    '            lvItem = lvLogs.Items.Add(iGLCount.ToString())
    '            lvItem.SubItems.Add(idwEnrollNumber.ToString())
    '            lvItem.SubItems.Add(idwVerifyMode.ToString())
    '            lvItem.SubItems.Add(idwInOutMode.ToString())
    '            lvItem.SubItems.Add(idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString())
    '        End While
    '    Else
    '        Cursor = Cursors.Default
    '        axCZKEM1.GetLastError(idwErrorCode)
    '        If idwErrorCode <> 0 Then
    '            MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
    '        Else
    '            MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
    '        End If
    '    End If

    '    axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
    '    Cursor = Cursors.Default
    'End Sub

#End Region
#Region "RealTime Events"
    Private Sub AxCZKEM1_OnAttTransactionEx(ByVal sEnrollNumber As String, ByVal iIsInValid As Integer, ByVal iAttState As Integer, ByVal iVerifyMethod As Integer,
                   ByVal iYear As Integer, ByVal iMonth As Integer, ByVal iDay As Integer, ByVal iHour As Integer, ByVal iMinute As Integer, ByVal iSecond As Integer, ByVal iWorkCode As Integer)
        'lbRTShow.Items.Add("RTEvent OnAttTrasaction Has been Triggered,Verified OK")
        'lbRTShow.Items.Add("...UserID:" & iEnrollNumber.ToString())
        'lbRTShow.Items.Add("...isInvalid:" & iIsInValid.ToString())
        'lbRTShow.Items.Add("...attState:" & iAttState.ToString())
        'lbRTShow.Items.Add("...VerifyMethod:" & iVerifyMethod.ToString())
        'lbRTShow.Items.Add("...Time:" & iYear.ToString() & "-" & iMonth.ToString() & "-" & iDay.ToString() & " " & iHour.ToString() & ":" & iMinute.ToString() & ":" & iSecond.ToString())

        Dim kk As String = (iYear.ToString() & "-" + iMonth.ToString() & "-" & iDay.ToString() & " " & iHour.ToString() & ":" & iMinute.ToString() & ":" & iSecond.ToString())
        'Dim kk As String = (idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString())

        Dim dd As DateTime = CDate(CType(kk, DateTime).ToString("yyyy/MM/dd HH:mm:ss"))

        Dim bb As String = (iYear.ToString() & "-" + iMonth.ToString() & "-" & iDay.ToString())
        Dim ee As String = CType(bb, DateTime).ToString("yyyy/MM/dd")

        Dim nn As String = (iHour.ToString() & ":" & iMinute.ToString())
        Dim ff As String = CType(nn, DateTime).ToString("HH:mm")
        Using db As New CsmdBioAttendenceEntities
            Dim fg = (From a In db.Emp_Attendence_Device Where a.Emp_Bio_Device_Users_UserID = CType(sEnrollNumber, Integer?) And a.Emp_Attendence_Device_DateTime = dd Select a).FirstOrDefault
            If fg IsNot Nothing Then
                'With fg
                '    '.Emp_ID = EmpID
                '    '.Attendence_Status_ID = dts.Attendence_Status_ID
                '    '.Emp_Bio_Device_Users_UserID = nn
                '    '.Emp_Bio_Device_User_Name = dty.Emp_Name
                '    '.Emp_Bio_Device_User_Finger = 0
                '    '.Emp_Bio_Device_User_tmpData = ""
                '    '.Emp_Bio_Device_User_Privilege = 0
                '    '.Emp_Bio_Device_User_Password = ""
                '    '.Emp_Bio_Device_User_Enabled = True
                'End With
                'db.SaveChanges()
            Else
                Dim dtNew = New Emp_Attendence_Device
                With dtNew
                    .Emp_Bio_Device_Users_UserID = CType(sEnrollNumber, Integer?)
                    .Emp_Attendence_Device_DateTime = dd
                    .Emp_Attendence_Device_Date = CType(ee, Date?)
                    .Emp_Attendence_Device_Time = ff
                    .Emp_Attendence_Device_Status = True
                End With
                db.Emp_Attendence_Device.Add(dtNew)
                db.SaveChanges()
            End If
            Load_From_DeviceDB()
        End Using
        'Using db As New CsmdBioAttendenceEntities
        '    Dim po = (From a In db.Emp_Attendence_Device Where a.Emp_Bio_Device_Users_UserID = CType(sEnrollNumber, Integer?) And a.Emp_Attendence_Device_DateTime = dd Select a).FirstOrDefault
        '    If po IsNot Nothing Then
        '        Try
        '            Dim strr As String = po.Emp_Bio_Device_Users.Employee.Emp_Name & " activity " & po.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type & " ON " & CType(ee, Date?) & " " & ff
        '            Dim fr As System.Net.HttpWebRequest
        '            'Dim targetURI As New Uri("https://api.callmebot.com/whatsapp.php?phone=+923327117786&text=" & strr & "&apikey=506371")
        '            'Dim targetURI As New Uri("http://api.callmebot.com/whatsapp.php?phone=+923456914893&text=" & strr & "&apikey=758488")
        '            Dim targetURI As New Uri("http://api.callmebot.com/whatsapp.php?phone=+923005474470&text=" & strr & "&apikey=179837")
        '            'Dim targetURI As New Uri("https://api.callmebot.com/whatsapp.php?phone=+923456914893&text=ParisMart&apikey=758488")

        '            fr = DirectCast(HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
        '            If (fr.GetResponse().ContentLength > 0) Then
        '                Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
        '                'Response.Write(str.ReadToEnd())
        '                str.Close()
        '            End If
        '        Catch ex As System.Net.WebException
        '            'Error in accessing the resource, handle it
        '            MsgBox(ex.Message)
        '        End Try
        '    End If
        'End Using
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Dim filePath As String = Replace(System.Reflection.Assembly.GetExecutingAssembly().Location, ".exe", "") + ".exe.config"
        Dim objDoc As XDocument = XDocument.Load(filePath)
        Dim conEl = objDoc.Descendants("connectionStrings").Elements().First()
        conEl.Attribute("name").Value = "CsmdBioAttendenceEntities1"
        conEl.Attribute("connectionString").Value = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string='data source=" & sIP.EditValue.ToString & "," & sPort.EditValue.ToString & "; initial catalog=CsmdBioAttendence ;user id=sa; password=123;multipleactiveresultsets=True;application name=EntityFramework;'"
        'conEl.Attribute("connectionString").Value = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\sqlexpress; AttachDbFileName=|DataDirectory|DATA\CsmdTheLeadsSchool.mdf ;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;"
        objDoc.Save(filePath)

        lblState.Caption = "Current State: Connected"
        lblState.ItemAppearance.Normal.BackColor = Color.LimeGreen

        Dim datx As Date = CDate(Dtp1.EditValue)
        Using db As New CsmdBioAttendenceEntities1
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Date.Value.Month >= datx.Month And
                                                                          a.Emp_Attendence_Device_Date.Value.Month <= datx.Month And
                                                                          a.Emp_Attendence_Device_Date.Value.Year >= datx.Year And
                                                                          a.Emp_Attendence_Device_Date.Value.Year <= datx.Year
                      Select a).ToList
            If dt.Count > 0 Then
                Dim k As Integer = 0
                ProgressBarControl1.Properties.Maximum = dt.Count
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 0
                ProgressBarControl1.Update()
                For Each dts In dt
                    ProgressBarControl1.Position = k
                    ProgressBarControl1.Update()
                    k += 1
                    Using db2 As New CsmdBioAttendenceEntities
                        Dim df = (From a In db2.Emp_Attendence_Device Where a.Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID And
                                                                          a.Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
                                  Select a).FirstOrDefault
                        If df IsNot Nothing Then

                        Else
                            Dim dfNew = New Emp_Attendence_Device
                            With dfNew
                                .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
                                .Emp_Attendence_Device_Date = dts.Emp_Attendence_Device_Date
                                .Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
                                .Emp_Attendence_Device_Time = dts.Emp_Attendence_Device_Time
                                .Emp_Attendence_Device_Status = dts.Emp_Attendence_Device_Status

                            End With
                            db2.Emp_Attendence_Device.Add(dfNew)
                            db2.SaveChanges()
                        End If
                    End Using
                Next
                MsgBox("Import Done")
                bn = False
                Load_From_DeviceDB()
                EmpDate = CDate(Dtp1.EditValue)
                Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate)
                lblState.Caption = "Status: Disconnected"
                lblState.ItemAppearance.Normal.BackColor = Color.Red
            End If

        End Using
    End Sub

#End Region

End Class




'dd/ mm / yyyy hh:nn : ss" tt"