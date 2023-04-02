

Option Explicit On
'Option Strict On


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
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports System.ComponentModel
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraBars.Docking
Imports DevExpress.XtraBars
Imports System.Drawing.Drawing2D
Imports DevExpress.XtraBars.Ribbon.ViewInfo
Imports DevExpress.XtraBars.Ribbon.Drawing
Imports DevExpress.Utils.Drawing
Imports CsmdOnline
Imports DevExpress.XtraTab
Imports DevExpress.XtraTab.ViewInfo
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

        If CStr(GetSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", "")) = "" Then
            SaveSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", "192.168.1.201")
            txtIP.EditValue = "192.168.1.201"
        Else
            txtIP.EditValue = GetSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", "")

        End If
        CsmdVarible.PlazaUserID = 1
        RibbonControl1.Minimized = True
        cmbStatus.TextEditStyle = TextEditStyles.DisableTextEditor
        AddHandler cmbStatus.EditValueChanged, AddressOf cmbStatus_EditValueChanged
        AddHandler cmbStatus.Popup, AddressOf cmbStatus_Popup
        Load_cmb_Attendance_Duty_Status.ColumnsAndData(cmbStatus)
        TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(AdvBandedGridView1)
        TempGridCheckMarksSelection.View.OptionsSelection.InvertSelection = True
        TempGridCheckMarksSelection.View.OptionsSelection.MultiSelect = True
        FF1.EditValue = Today
        FF2.EditValue = CsmdDateTime.LastDayOfMonth(Today)
        If Class1.MasterLive = "OpenAdmin" Then
            Me.TopMost = False
            SkinRibbonGalleryBarItem1.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
            BarButtonItem6.Enabled = True
            BarButtonItem3.Enabled = True
            BarButtonItem8.Enabled = True
            BarButtonItem5.Enabled = True
            GridView2.OptionsBehavior.Editable = True
            BtnDelete.Visible = False
            GridView2.OptionsSelection.MultiSelect = True
        Else
            'BarButtonItem6.Enabled = False
            'BarButtonItem3.Enabled = False
            'BarButtonItem8.Enabled = False
            'BarButtonItem5.Enabled = False
            'GridView2.OptionsBehavior.Editable = False
            'BtnDelete.Visible = True
            'GridView2.OptionsSelection.MultiSelect = False
            '''''Me.TopMost = True
            Try

                UserLookAndFeel.Default.SetSkinStyle(GetSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", ""))
            Catch ex As Exception
                UserLookAndFeel.Default.SetSkinStyle("Sharp")
                SaveSetting(Application.ProductName, "CsmdUserLookAndFeelLive", "CsmdActiveSkinNameLive", UserLookAndFeel.Default.ActiveSkinName)
            End Try
        End If
        FormSize(CInt(8.25))
        Dtp1.EditValue = Today.Date
        GridView1.IndicatorWidth = 35
        GridView3.IndicatorWidth = 35
        GridView2.IndicatorWidth = 45
        AdvBandedGridView1.IndicatorWidth = 35
        lblState.Text = "Disconnected"
        'CsmdScroll1.Timer1.Enabled = True
        'CsmdScroll1.M.BackColor = Color.Transparent
        'CsmdScroll1.M.Text = "Total Employees =30  @  Present Today =23 @ Absent Today =7"
        'CustomDrawRowIndicator(GridControl4, AdvBandedGridView1)
    End Sub
    'Public Shared Sub CustomDrawRowIndicator(ByVal gridControl As GridControl, ByVal gridView As AdvBandedGridView)
    '    gridView.IndicatorWidth = 50
    '    ' Handle this event to paint RowIndicator manually
    '    AddHandler gridView.CustomDrawRowIndicator, Sub(s As Object, e As RowIndicatorCustomDrawEventArgs)
    '                                                    If Not e.Info.IsRowIndicator Then
    '                                                        Return
    '                                                    End If
    '                                                    Dim view As AdvBandedGridView = TryCast(s, AdvBandedGridView)
    '                                                    e.Handled = True

    '                                                    'e.Appearance.BackColor = If(view.FocusedRowHandle = e.RowHandle, Color.Chocolate, Color.MediumSpringGreen)
    '                                                    'e.Appearance.FillRectangle(e.Cache, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width - 4, e.Bounds.Y - 4))
    '                                                    'If e.Info.ImageIndex < 0 Then
    '                                                    '    Return
    '                                                    'End If
    '                                                    'Dim ic As DevExpress.Utils.ImageCollection = TryCast(e.Info.ImageCollection, DevExpress.Utils.ImageCollection)
    '                                                    'Dim indicator As Image = ic.Images(e.Info.ImageIndex)
    '                                                    'e.Graphics.DrawImage(indicator, New Rectangle(e.Bounds.X + 20, e.Bounds.Y + 6, indicator.Width, indicator.Height))
    '                                                    e.Info.DisplayText = e.RowHandle.ToString()
    '                                                End Sub
    'End Sub
    Public Sub FormSize(k As Integer)
        'Dim k As Integer = If(BarEditItem4.EditValue.ToString = "", 8.25, BarEditItem4.EditValue)
        'GridView1.Appearance.BandPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        GridView1.Appearance.HeaderPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        GridView1.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)
        GridView1.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)
        GridView3.Appearance.HeaderPanel.Font = New Font("Tahoma", k, FontStyle.Bold)
        GridView3.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)
        GridView3.Appearance.Row.Font = New Font("Tahoma", k, FontStyle.Regular)

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
        ''''''Using DBCon As New SqlConnection(CsmdCon.ConSqlDB)

        'Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT 
        '                USERINFO.USERID, 
        '                USERINFO.Badgenumber,
        '                USERINFO.SSN, 
        '                USERINFO.Name, 
        '                CHECKINOUT.CHECKTIME FROM CHECKINOUT INNER JOIN USERINFO ON
        '                CHECKINOUT.USERID = USERINFO.USERID where DateValue(CHECKINOUT.CHECKTIME) = '" & CDate(Dtp1.EditValue) & "';", DBCon2)
        '''''''            Dim sqlStr As String = "SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID, " &
        '''''''        "dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time " &
        '''''''"FROM dbo.Emp_Attendence_Device INNER JOIN " &
        '''''''                             "dbo.Employees ON dbo.Emp_Attendence_Device.Emp_ID = dbo.Employees.Emp_ID INNER JOIN " &
        '''''''                         "dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
        '''''''                         "dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
        '''''''"WHERE (dbo.Employees.Emp_Status='true' and dbo.Emp_Attendence_Device.User_ID =" & CsmdVarible.PlazaUserID & " and dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date = '" & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy/MM/dd") & "') and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true')"



        'Select Case dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, 
        '                         dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time
        'From dbo.Emp_Attendence_Device INNER Join
        '              dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER Join
        '              dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID
        ''''''Dim cmd As SqlCommand = New SqlCommand(sqlStr, DBCon)
        ''''''DBCon.Open()
        ''''''Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        ''''''Dim ds As New DataSet()
        ''''''da.Fill(ds)
        ''''''If ds.Tables(0).Rows.Count > 0 Then
        ''''''    GridControl4.DataSource = ds.Tables(0)
        ''''''Else
        ''''''    GridControl4.DataSource = Nothing
        ''''''End If
        ''''''DBCon.Close()
        ''''''da.Dispose()
        Using db As New CsmdBioDatabase.CsmdBioAttendenceEntities
            'Dim datx As DateTime = CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy/MM/dd")
            Dim datx As DateTime = CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy-MM-dd")
            Dim dt = (From a In db.Emp_Attendence_Device
                      Where a.User_ID = CsmdVarible.PlazaUserID And
                              a.Emp_Attendence_Device_Day = datx And
                              a.Emp_Attendence_Device_Status = True
                      Select a.Emp_Attendence_Device_ID, a.Emp_Bio_Device_Users_UserID, a.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name,
                              a.Emp_Bio_Device_Users.Emp_ID, a.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type,
                              a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time).ToList
            If dt.Count > 0 Then
                GridControl4.DataSource = dt
            Else
                GridControl4.DataSource = Nothing
            End If
        End Using
        ''''''End Using





    End Sub
    Public Sub Load_From_DeviceDBonline()
        If CsmdCon.CheckForInternetConnection = True Then


            '''''Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)

            'Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT 
            '                USERINFO.USERID, 
            '                USERINFO.Badgenumber,
            '                USERINFO.SSN, 
            '                USERINFO.Name, 
            '                CHECKINOUT.CHECKTIME FROM CHECKINOUT INNER JOIN USERINFO ON
            '''''''            '                CHECKINOUT.USERID = USERINFO.USERID where DateValue(CHECKINOUT.CHECKTIME) = '" & CDate(Dtp1.EditValue) & "';", DBCon2)
            '''''''            Dim strd As String = "SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID, " &
            '''''''        "dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time " &
            '''''''"FROM dbo.Emp_Attendence_Device INNER JOIN " &
            '''''''                         "dbo.Employees ON dbo.Emp_Attendence_Device.Emp_ID = dbo.Employees.Emp_ID INNER JOIN " &
            '''''''                         "dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
            '''''''                         "dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
            '''''''"WHERE (dbo.Employees.Emp_Status='true' and dbo.Emp_Attendence_Device.User_ID = " & CsmdVarible.PlazaUserID & " and dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date = '" & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy/MM/dd") & "') and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true')"
            '''''''            Dim da2 As SqlDataAdapter = New SqlDataAdapter(strd, DBCon2)


            'Select Case dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, 
            '                         dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time
            'From dbo.Emp_Attendence_Device INNER Join
            '              dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER Join
            '              dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID

            '''''''Dim ds2 As New DataSet()
            '''''''    da2.Fill(ds2)
            '''''''    If ds2.Tables(0).Rows.Count > 0 Then
            '''''''        GridControl1.DataSource = ds2.Tables(0)
            '''''''    Else
            '''''''        GridControl1.DataSource = Nothing
            '''''''    End If
            '''''''    DBCon2.Close()
            '            "SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, 
            'dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID,
            'dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, 
            'dbo.Emp_Bio_Device_Users.Emp_ID,
            ' dbo.Attendence_Status.Attendence_Status_Type, 
            ' dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time 
            Using db As New CsmdOnline.CsmdBioAttendenceEntitiesOnline
                Dim datx As DateTime = CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy/MM/dd")
                Dim dt = (From a In db.Emp_Attendence_Device
                          Where a.User_ID = CsmdVarible.PlazaUserID And
                              a.Emp_Attendence_Device_Day = datx And
                              a.Emp_Attendence_Device_Status = True
                          Select a.Emp_Attendence_Device_ID, a.Emp_Bio_Device_Users_UserID, a.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name,
                              a.Emp_Bio_Device_Users.Emp_ID, a.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type,
                              a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time).ToList
                If dt.Count > 0 Then
                    GridControl1.DataSource = dt
                Else
                    GridControl1.DataSource = Nothing
                End If
            End Using
        Else
            MsgBox("Please Check Internet Connection", vbCritical, "Internet Error")
            GridControl1.DataSource = Nothing
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

        Dim FromDat As DateTime = CDate(Datx.Date).ToString("yyyy-MM-dd")
        Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat)
        Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))

        'Dim RAW As New CsmdBioAttendenceEntities
        Dim DBCon As New SqlConnection(CsmdCon.ConSqlDB)
        'Dim FAZ As New CsmdBioAttendenceEntities
        'Dim DBCon As New SqlConnection(FAZ.Database.Connection.ConnectionString)
        Dim SqlStr As String = "Select * From Employees WHERE Emp_Status='true'"
        Dim cmd As SqlCommand = New SqlCommand(SqlStr, DBCon)
        DBCon.Open()
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dsEmp As New DataSet()
        da.Fill(dsEmp)
        If dsEmp.Tables(0).Rows.Count > 0 Then
            GridControl2.DataSource = Nothing
            DataT.Rows.Clear()
            Dim k As Integer = 1
            ProgressBarControl1.Properties.Maximum = dsEmp.Tables(0).Rows.Count
            ProgressBarControl1.Properties.Minimum = 1
            ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
            ProgressBarControl1.Position = 1
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

                Dim SqlStr2 As String = "SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID, " &
"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Duty_On_Off, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time " &
"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
 "               WHERE " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date = '" & thisDate.ToString("yyyy/MM/dd") & "') AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & CInt(Emp.Item("Emp_ID")) & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime"
                Dim cmd2 As SqlCommand = New SqlCommand(SqlStr2, DBCon2)
                DBCon2.Open()
                Dim da2 As SqlDataAdapter = New SqlDataAdapter(cmd2)
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
                da2.Dispose()
                Application.DoEvents()
            Next
            'GridControl4.DataSource = ds2.Tables(0)
            GridControl2.DataSource = DataT
            ShowSelectionAtt00000000()
             
            GridControl5.DataSource = Nothing

            'Dim dt = (From a In DataT Select New With {.USERID = a.Item("USERID"), .Emp_ID = EmpID,
            '                              .SSN = a.Item("SSN"),
            '                              .Sn1 = a.Item("Date"),
            '                              .Sn2 = a.Item("Date"), .AllDay = True, .Label = 4}).ToList


            'SchedulerStorage1.Appointments.DataSource = DataT
        End If
        DBCon.Close()
        da.Dispose()
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
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & thisDate.ToString("yyyy/MM/dd") & "')  AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & CInt(Emp.Item("Emp_ID")) & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true')ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
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
        Dim ddd As String = "SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID,  " &
"dbo.Attendence_Status.Attendence_Status_Type,dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID  " &
"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
"WHERE  " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & thisDate.ToString("yyyy/MM/dd") & "') AND  (dbo.Emp_Bio_Device_Users.Emp_ID = " & EmpID & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime"
        Dim da2 As SqlDataAdapter = New SqlDataAdapter(ddd, DBCon2)
        '        Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, dbo.Emp_Bio_Device_Users.Emp_ID,  " &
        '"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID  " &
        '"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
        '"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
        '"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
        '"WHERE  " &
        '"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime >= '" & thisDate.ToString("yyyy/MM/dd HH:mm") & "') AND  " &
        '"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Datetime <= '" & ToDate.ToString("yyyy/MM/dd HH:mm") & "')  AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & EmpID & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
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

        Using db As New CsmdBioAttendenceEntities

            Dim DataT As New DataTable
            Dim Mtr As DataRow
            DataT.Columns.Clear()
            DataT.Columns.Add("USERID", GetType(String))
            DataT.Columns.Add("Sd1", GetType(String))
            DataT.Columns.Add("Sd2", GetType(String))
            DataT.Columns.Add("Date", GetType(String))
            DataT.Columns.Add("Day", GetType(String))
            DataT.Columns.Add("SSN", GetType(String))
            DataT.Columns.Add("Sn1", GetType(String))

            Dim FromDat As DateTime = DateX.Date.ToString("yyyy-MM-dd")
            Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat).ToString("yyyy-MM-dd")
            Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month)).ToString("yyyy-MM-dd")
            'ClickforMonthly.Caption = "Now " & EmpName & " >>>"
            Dim k As Integer = 1
            ProgressBarControl3.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate))
            ProgressBarControl3.Properties.Minimum = 0
            ProgressBarControl3.Properties.Appearance.BackColor = Color.Yellow
            ProgressBarControl3.Position = 0
            ProgressBarControl3.Update()

            For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate - 1


                Dim thisDate As Date = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(DateX.Date))
                Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(DateX.Date))
                Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
                Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))

                'MsgBox(TiA)
                'MsgBox(TiB)

                ProgressBarControl3.Position = k
                ProgressBarControl3.Update()
                k += 1

                Mtr = DataT.NewRow
                Mtr.Item("USERID") = EmpCode
                Mtr.Item("Sd1") = thisDate.Date.ToString("dd")
                Mtr.Item("Sd2") = "-"
                Mtr.Item("Date") = thisDate.ToString("dd-MM-yyyy HH:mm:ss")
                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                'Mtr.Item("SSN") = "Duty ON " & EmpDutyOn & " - OFF " & EmpDutyOff & " - " & thisDate.Date.ToString("dddd")
                Mtr.Item("SSN") = thisDate.Date.ToString("dddd")
                Mtr.Item("Sn1") = "---"
                DataT.Rows.Add(Mtr)

                'Dim hh As String = ConfigurationManager.ConnectionStrings("att2000ConnectionString").ConnectionString
                '            Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
                '            Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, " &
                '"dbo.Attendence_Status.Attendence_Status_Type,dbo.Emp_Attendence_Device.Emp_Attendence_Device_Duty_On_Off, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day,dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Attendence_Device.Emp_ID,dbo.Attendance_Duty_Status.Attendance_Duty_Status_Type " &
                '"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
                '"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
                '"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID INNER JOIN " &
                '"dbo.Attendance_Duty_Status ON dbo.Attendance_Duty_Status.Attendance_Duty_Status_ID = dbo.Emp_Attendence_Device.Attendance_Duty_Status_ID " &
                '"            WHERE " &
                '"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & thisDate.ToString("yyyy-MM-dd") & "')  " &
                '"AND (dbo.Emp_Attendence_Device.Emp_ID = " & EmpID & ") AND (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
                '            Dim ds2 As New DataSet()
                '            da2.Fill(ds2)

                Dim datteb As Date = CDate(thisDate.ToString("yyyy-MM-dd"))
                Dim dt = (From a In db.Emp_Attendence_Device
                          Where a.Emp_ID = EmpID And
                              a.Emp_Attendence_Device_Day = datteb.Date And
                              a.Emp_Attendence_Device_Status = True
                          Order By a.Emp_Attendence_Device_DateTime Ascending
                          Select a.Emp_Attendence_Device_ID, a.Emp_Attendence_Device_DateTime,
                              a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time, a.Emp_Attendence_Device_Day,
                              a.Attendance_Duty_Status_ID, a.Emp_Bio_Device_Users_UserID,
                              a.Emp_Attendence_Device_Status, a.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type,
                              a.Attendance_Duty_Status.Attendance_Duty_Status_Type, a.Emp_ID, a.Emp_Attendence_Device_Duty_On_Off).ToList
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
                Dim ChkAdate As String = ""
                Dim ChkAtime As String = ""

                Dim PrayAdate As String = ""
                Dim PrayAtime As String = ""
                Dim PrayAtimeN As String = ""
                'Dim PrayBdate As String = ""
                'Dim PrayBtime As String = ""
                Dim ShAdate As String = ""
                Dim ShAtime As String = ""
                Dim ShAtimeN As String = ""
                'Dim ShBdate As String = ""
                'Dim ShBtime As String = ""
                Dim LuAdate As String = ""
                Dim LuAtime As String = ""
                Dim LuAtimeN As String = ""
                'Dim LuBdate As String = ""
                'Dim LuBtime As String = ""
                Dim PriAdate As String = ""
                Dim PriAtime As String = ""
                Dim PriAtimeN As String = ""
                'Dim PriBdate As String = ""
                'Dim PriBtime As String = ""
                'Dim praID As Integer
                'Dim shlID As Integer
                'Dim lunID As Integer
                'Dim priID As Integer
                'If ds2.Tables(0).Rows.Count > 0 Then
                If dt.Count > 0 Then
                    Dim rowNo As Integer = 0
                    'Dim k As Integer = 1
                    'ProgressBarControl3.Properties.Maximum = dt.Count - 1
                    'ProgressBarControl3.Properties.Minimum = 0
                    'ProgressBarControl3.Properties.Appearance.BackColor = Color.Yellow
                    'ProgressBarControl3.Position = 0
                    'ProgressBarControl3.Update()
                    For Each dsx In dt
                        'ProgressBarControl3.Position = rowNo
                        'ProgressBarControl3.Update()
                        'k += 1


                        If CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy-MM-dd HH") >= thisDate.ToString("yyyy-MM-dd HH") And CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy-MM-dd HH") <= ToDate.ToString("yyyy-MM-dd HH") Then

                            If Not IsNothing(dsx.Emp_Bio_Device_Users_UserID) Then
                                If dsx.Attendence_Status_Type.ToString = "RT-Check In" Then
                                    If chkA2 = False Then
                                        chkA = True
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sd1") = dsx.Emp_Attendence_Device_Duty_On_Off
                                        Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        DataT.Rows.Add(Mtr)
                                        chkA2 = True
                                    Else
                                        chkA = False
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sd1") = dsx.Emp_Attendence_Device_Duty_On_Off
                                        Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        DataT.Rows.Add(Mtr)

                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) + 1

                                        ChkAdate = thisDate.ToString("dd-MM-yyyy").ToString '("dd-MM-yyyy HHmm  ss")
                                        ChkAtime = CDate(TT2.EditValue).ToString("HH:mm:ss")

                                        Mtr.Item("Date") = DateTime.ParseExact(ChkAdate & " " & ChkAtime, "dd-MM-yyyy HH:mm:ss", Nothing).ToString
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = "LT-Check Out"
                                        Mtr.Item("Sd1") = TT2.EditValue.ToString & " zz"
                                        Mtr.Item("Sn1") = "" ' ChkAtime & " vv"
                                        DataT.Rows.Add(Mtr)

                                    End If

                                Else
                                    If dsx.Attendence_Status_Type.ToString = "LT-Check Out" Then
                                        If chkA = False Then
                                            ChkAdate = thisDate.ToString("dd-MM-yyyy").ToString '("dd-MM-yyyy HHmm:ss")
                                            ChkAtime = CDate(TT1.EditValue).ToString("HH:mm:ss")
                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                            Mtr.Item("Date") = DateTime.ParseExact(ChkAdate & " " & ChkAtime, "dd-MM-yyyy HH:mm:ss", Nothing).ToString
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = "RT-Check In"
                                            Mtr.Item("Sd1") = TT1.EditValue.ToString & " ss"
                                            Mtr.Item("Sn1") = "" 'ChkAtime & " xx"
                                            DataT.Rows.Add(Mtr)

                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sd1") = dsx.Emp_Attendence_Device_Duty_On_Off
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkA2 = False
                                        Else
                                            chkA = False
                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sd1") = dsx.Emp_Attendence_Device_Duty_On_Off
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkA2 = False
                                        End If
                                        'Else
                                        '    If chkA = True Then
                                        '        chkA = False
                                        '        Mtr = DataT.NewRow
                                        '        Mtr.Item("Date") = dsx.CHECKTIME")
                                        '        Mtr.Item("SSN") = "LT-Check Out"
                                        '        Mtr.Item("Sn1") = ""
                                        '        DataT.Rows.Add(Mtr)
                                        '    End If
                                    End If
                                End If
                                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                If dsx.Attendence_Status_Type.ToString = "RI-Prayer A" Then
                                    If chkB2 = False Then
                                        PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'praID = CInt(dsx.Emp_Bio_Device_Users_UserID"))
                                        'PrayAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = PrayAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = PrayAtime
                                        DataT.Rows.Add(Mtr)
                                        chkB2 = True
                                        chkB = True
                                    Else
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) + 1
                                        Mtr.Item("Date") = PrayAdate ' CDate(dsx.Emp_Attendence_Device_DateTime")).ToString("dd-MM-yyyy HH:mm:ss")
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = "LI-Prayer B"
                                        Mtr.Item("Sn1") = "" ' PrayAtime & " hh"
                                        DataT.Rows.Add(Mtr)
                                        'PrayAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtime), CDate(PrayAtimeN)))
                                        'If duration > CInt(Pra.EditValue) Then
                                        '    EditDEviceWithPSLP(praID + 1, True, CDate(PrayAtime).AddMinutes(CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(CDbl(Pra.EditValue)))
                                        'Else
                                        '    EditDEviceWithPSLP(praID + 1, True, CDate(PrayAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PrayAtimeN))
                                        'End If
                                        PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'praID = CInt(dsx.Emp_Bio_Device_Users_UserID"))

                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = PrayAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = PrayAtime
                                        DataT.Rows.Add(Mtr)
                                        chkB2 = True
                                        chkB = True
                                    End If
                                Else
                                    If dsx.Attendence_Status_Type.ToString = "LI-Prayer B" Then
                                        If chkB2 = False Then
                                            If chkB = True Then
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = PrayAdate
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RI-Prayer A"
                                                Mtr.Item("Sn1") = "" ' PrayAtime & " hh"
                                                DataT.Rows.Add(Mtr)
                                                chkB = False
                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtimeN), CDate(PrayAtime)))
                                                'If duration > CInt(Pra.EditValue) Then
                                                '    EditDEviceWithPSLP(praID - 1, True, CDate(PrayAtime).AddMinutes(-CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(-CDbl(Pra.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(praID - 1, True, CDate(PrayAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PrayAtimeN))
                                                'End If
                                            Else
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RI-Prayer A"
                                                Mtr.Item("Sn1") = "" ' CDate(dsx.Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                DataT.Rows.Add(Mtr)
                                                chkB = False
                                                PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                'praID = CInt(dsx.Emp_Bio_Device_Users_UserID"))
                                                'PrayAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtimeN), CDate(PrayAtime)))
                                                'If duration > CInt(Pra.EditValue) Then
                                                '    EditDEviceWithPSLP(praID - 1, True, CDate(PrayAtime).AddMinutes(-CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(-CDbl(Pra.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(praID - 1, True, CDate(PrayAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PrayAtimeN))
                                                'End If
                                            End If

                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkB2 = False
                                        Else
                                            PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            'praID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            'PrayAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")

                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = PrayAdate
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = PrayAtime
                                            DataT.Rows.Add(Mtr)
                                            chkB2 = False
                                            chkB = False
                                        End If
                                    End If
                                End If
                                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                If dsx.Attendence_Status_Type.ToString = "RM-Short Leave A" Then
                                    If chkC2 = False Then
                                        ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        'ShAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = ShAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = ShAtime
                                        DataT.Rows.Add(Mtr)
                                        chkC2 = True
                                        chkC = True
                                    Else
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) + 1
                                        Mtr.Item("Date") = ShAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = "LM-Short Leave B"
                                        Mtr.Item("Sn1") = "" ' ShAtime & " hh"
                                        DataT.Rows.Add(Mtr)
                                        'ShAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time).ToString("HHmm")
                                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtime), CDate(ShAtimeN)))
                                        'If duration > CInt(Shl.EditValue) Then
                                        '    EditDEviceWithPSLP(shlID + 1, True, CDate(ShAtime).AddMinutes(CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(CDbl(Shl.EditValue)))
                                        'Else
                                        '    EditDEviceWithPSLP(shlID + 1, True, CDate(ShAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & ShAtimeN))
                                        'End If
                                        ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)

                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = ShAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = ShAtime
                                        DataT.Rows.Add(Mtr)
                                        chkC2 = True
                                        chkC = True
                                    End If

                                Else
                                    If dsx.Attendence_Status_Type.ToString = "LM-Short Leave B" Then

                                        If chkC2 = False Then
                                            If chkC = True Then
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = ShAdate
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RM-Short Leave A"
                                                Mtr.Item("Sn1") = "" ' ShAtime & " hh"
                                                DataT.Rows.Add(Mtr)
                                                chkC = False
                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtimeN), CDate(ShAtime)))
                                                'If duration > CInt(Shl.EditValue) Then
                                                '    EditDEviceWithPSLP(shlID - 1, True, CDate(ShAtime).AddMinutes(-CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(-CDbl(Shl.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(shlID - 1, True, CDate(ShAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & ShAtimeN))
                                                'End If
                                            Else
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RM-Short Leave A"
                                                Mtr.Item("Sn1") = "" ' CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                DataT.Rows.Add(Mtr)
                                                chkC = False
                                                ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                'shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                'ShAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")
                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtimeN), CDate(ShAtime)))
                                                'If duration > CInt(Shl.EditValue) Then
                                                '    EditDEviceWithPSLP(shlID - 1, True, CDate(ShAtime).AddMinutes(-CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(-CDbl(Shl.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(shlID - 1, True, CDate(ShAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & ShAtimeN))
                                                'End If
                                            End If


                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkC2 = False
                                        Else
                                            ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            'shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            'ShAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")

                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkC2 = False
                                            chkC = False
                                        End If
                                    End If
                                End If
                                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                If dsx.Attendence_Status_Type.ToString = "RR-Lunch A" Then
                                    If chkD2 = False Then
                                        LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        'LuAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")

                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = LuAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = LuAtime
                                        DataT.Rows.Add(Mtr)
                                        chkD2 = True
                                        chkD = True
                                    Else
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) + 1
                                        Mtr.Item("Date") = LuAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = "LR-Lunch B"
                                        Mtr.Item("Sn1") = "" ' LuAtime & " hh"
                                        DataT.Rows.Add(Mtr)

                                        'LuAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time).ToString("HHmm")
                                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtime), CDate(LuAtimeN)))
                                        'If duration > CInt(Lun.EditValue) Then
                                        '    EditDEviceWithPSLP(lunID + 1, True, CDate(LuAtime).AddMinutes(CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(CDbl(Lun.EditValue)))
                                        'Else
                                        '    EditDEviceWithPSLP(lunID + 1, True, CDate(LuAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & LuAtimeN))
                                        'End If
                                        LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = LuAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = LuAtime
                                        DataT.Rows.Add(Mtr)
                                        chkD2 = True
                                        chkD = True
                                    End If
                                Else
                                    If dsx.Attendence_Status_Type.ToString = "LR-Lunch B" Then

                                        If chkD2 = False Then
                                            If chkD = True Then
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = LuAdate
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RR-Lunch A"
                                                Mtr.Item("Sn1") = "" ' LuAtime & " hh"
                                                DataT.Rows.Add(Mtr)
                                                chkD = False
                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtimeN), CDate(LuAtime)))
                                                'If duration > CInt(Lun.EditValue) Then
                                                '    EditDEviceWithPSLP(lunID - 1, True, CDate(LuAtime).AddMinutes(-CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(-CDbl(Lun.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(lunID - 1, True, CDate(LuAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & LuAtimeN))
                                                'End If
                                            Else
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RR-Lunch A"
                                                Mtr.Item("Sn1") = "" ' CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                DataT.Rows.Add(Mtr)
                                                chkD = False
                                                LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                'lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                'LuAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")
                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtimeN), CDate(LuAtime)))
                                                'If duration > CInt(Lun.EditValue) Then
                                                '    EditDEviceWithPSLP(lunID - 1, True, CDate(LuAtime).AddMinutes(-CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(-CDbl(Lun.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(lunID - 1, True, CDate(LuAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & LuAtimeN))
                                                'End If
                                            End If


                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkD2 = False
                                        Else
                                            LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            'lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            'LuAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")

                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = LuAdate
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkD2 = False
                                            chkD = False
                                        End If
                                    End If
                                End If
                                'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                If dsx.Attendence_Status_Type.ToString = "RP-Private A" Then
                                    If chkE2 = False Then
                                        PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'priID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        'PriAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")

                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = PriAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = PriAtime
                                        DataT.Rows.Add(Mtr)
                                        chkE2 = True
                                        chkE = True
                                    Else

                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) + 1
                                        Mtr.Item("Date") = PriAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = "LP-Private B"
                                        Mtr.Item("Sn1") = "" ' PriAtime & " hh"
                                        DataT.Rows.Add(Mtr)

                                        'PriAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time).ToString("HHmm")
                                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtime), CDate(PriAtimeN)))
                                        'If duration > CInt(Pri.EditValue) Then
                                        '    EditDEviceWithPSLP(priID + 1, True, CDate(PriAtime).AddMinutes(CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(CDbl(Pri.EditValue)))
                                        'Else
                                        '    EditDEviceWithPSLP(priID + 1, True, CDate(PriAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PriAtimeN))
                                        'End If

                                        PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                        PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                        'priID = CInt(dsx.Emp_Bio_Device_Users_UserID)

                                        Mtr = DataT.NewRow
                                        Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                        Mtr.Item("Date") = PriAdate
                                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                        Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                        Mtr.Item("Sn1") = PriAtime
                                        DataT.Rows.Add(Mtr)
                                        chkE2 = True
                                        chkE = True
                                    End If


                                Else

                                    If dsx.Attendence_Status_Type.ToString = "LP-Private B" Then

                                        If chkE2 = False Then
                                            If chkE = True Then
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = PriAdate
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RP-Private A"
                                                Mtr.Item("Sn1") = "" ' PriAtime & " hh"
                                                DataT.Rows.Add(Mtr)
                                                chkE = False

                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtimeN), CDate(PriAtime)))
                                                'If duration > CInt(Pri.EditValue) Then
                                                '    EditDEviceWithPSLP(priID - 1, True, CDate(PriAtime).AddMinutes(-CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(-CDbl(Pri.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(priID - 1, True, CDate(PriAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PriAtimeN))
                                                'End If
                                            Else
                                                Mtr = DataT.NewRow
                                                Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID) - 1
                                                Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                                Mtr.Item("SSN") = "RP-Private A"
                                                Mtr.Item("Sn1") = "" ' CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                DataT.Rows.Add(Mtr)
                                                chkE = False
                                                PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                                PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                'priID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                'PriAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")
                                                'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtimeN), CDate(PriAtime)))
                                                'If duration > CInt(Pri.EditValue) Then
                                                '    EditDEviceWithPSLP(priID - 1, True, CDate(PriAtime).AddMinutes(-CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(-CDbl(Pri.EditValue)))
                                                'Else
                                                '    EditDEviceWithPSLP(priID - 1, True, CDate(PriAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PriAtimeN))
                                                'End If
                                            End If


                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            DataT.Rows.Add(Mtr)
                                            chkE2 = False
                                        Else
                                            PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                            PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                            'priID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            'PriAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo - 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")
                                            Mtr = DataT.NewRow
                                            Mtr.Item("USERID") = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            Mtr.Item("Date") = PriAdate
                                            Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                            Mtr.Item("SSN") = dsx.Attendence_Status_Type
                                            Mtr.Item("Sn1") = PriAtime
                                            DataT.Rows.Add(Mtr)
                                            chkE2 = False
                                            chkE = False
                                        End If

                                    End If
                                End If
                            End If
                            If Not IsNothing(dsx.Attendance_Duty_Status_ID) Then
                                If Not dsx.Attendance_Duty_Status_ID = 1 Then
                                    'Else
                                    ''PriAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                    ''PriAtime = CDate(dsx.Item("Emp_Attendence_Device_Time).ToString("HH:mm")
                                    'priID = CInt(dsx.Item("Emp_Bio_Device_Users_UserID)
                                    'PriAtimeN = CDate(ds2.Tables(0).Rows.Item(rowNo + 1).Item("Emp_Attendence_Device_Time).ToString("HH:mm")

                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Emp_ID)
                                    Mtr.Item("Sd1") = "OFF"
                                    Mtr.Item("Date") = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("dd-MM-yyyy HH:mm:ss")
                                    Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                                    Mtr.Item("SSN") = dsx.Attendance_Duty_Status_ID
                                    Mtr.Item("Sn1") = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                End If
                            End If
                        End If

                        rowNo += 1
                    Next

                    If chkA = True Then
                        chkA = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = EmpCode
                        ChkAdate = thisDate.ToString("dd-MM-yyyy").ToString '("dd-MM-yyyy HH:mm:ss")
                        ChkAtime = CDate(TT2.EditValue).ToString("HH:mm:ss")


                        Mtr.Item("Date") = DateTime.ParseExact(ChkAdate & " " & ChkAtime, "dd-MM-yyyy HH:mm:ss", Nothing).ToString

                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                        Mtr.Item("SSN") = "LT-Check Out"
                        Mtr.Item("Sd1") = "" ' ChkAtime & " dd"
                        Mtr.Item("Sn1") = "" ' ChkAtime & " cc"
                        DataT.Rows.Add(Mtr)
                    End If
                    If chkB = True Then
                        chkB = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = EmpCode
                        Mtr.Item("Date") = PrayAdate
                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                        Mtr.Item("SSN") = "LI-Prayer B"
                        Mtr.Item("Sn1") = "" ' PrayAtime & " rr"
                        DataT.Rows.Add(Mtr)
                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtime), CDate(PrayAtimeN)))
                        'If duration > CInt(Pra.EditValue) Then
                        '    EditDEviceWithPSLP(praID + 1, True, CDate(PrayAtime).AddMinutes(CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(CDbl(Pra.EditValue)))
                        'Else
                        '    EditDEviceWithPSLP(praID + 1, True, CDate(PrayAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PrayAtimeN))
                        'End If
                    End If
                    If chkC = True Then
                        chkC = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = EmpCode
                        Mtr.Item("Date") = ShAdate
                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                        Mtr.Item("SSN") = "LM-Short Leave B"
                        Mtr.Item("Sn1") = "" ' ShAtime & " rr"
                        DataT.Rows.Add(Mtr)
                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtime), CDate(ShAtimeN)))
                        'If duration > CInt(Shl.EditValue) Then
                        '    EditDEviceWithPSLP(shlID + 1, True, CDate(ShAtime).AddMinutes(CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(CDbl(Shl.EditValue)))
                        'Else
                        '    EditDEviceWithPSLP(shlID + 1, True, CDate(shAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & shAtimeN))
                        'End If
                    End If
                    If chkD = True Then
                        chkD = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = EmpCode
                        Mtr.Item("Date") = LuAdate
                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                        Mtr.Item("SSN") = "LR-Lunch B"
                        Mtr.Item("Sn1") = "" ' LuAtime & " rr"
                        DataT.Rows.Add(Mtr)

                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtime), CDate(LuAtimeN)))
                        'If duration > CInt(Lun.EditValue) Then
                        '    EditDEviceWithPSLP(lunID + 1, True, CDate(LuAtime).AddMinutes(CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(CDbl(Lun.EditValue)))
                        'Else
                        '    EditDEviceWithPSLP(lunID + 1, True, CDate(LuAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & LuAtimeN))
                        'End If
                    End If
                    If chkE = True Then
                        chkE = False
                        Mtr = DataT.NewRow
                        Mtr.Item("USERID") = EmpCode
                        Mtr.Item("Date") = PriAdate
                        Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                        Mtr.Item("SSN") = "LP-Private B"
                        Mtr.Item("Sn1") = "" ' PriAtime & " rr"
                        DataT.Rows.Add(Mtr)
                        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtime), CDate(PriAtimeN)))
                        'If duration > CInt(Lun.EditValue) Then
                        '    EditDEviceWithPSLP(priID + 1, True, CDate(PriAtime).AddMinutes(CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(CDbl(Pri.EditValue)))
                        'Else
                        '    EditDEviceWithPSLP(priID + 1, True, CDate(PriAtimeN), CDate(thisDate.ToString("dd-MM-yyyy") & " " & PriAtimeN))
                        'End If

                        'EditDEviceWithPSLP(priID + 1, True, CDate(PriAtime).AddMinutes(CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(CDbl(Pri.EditValue)))
                    End If

                Else
                    Mtr = DataT.NewRow
                    Mtr.Item("USERID") = EmpID
                    Mtr.Item("Sd1") = "OFF"
                    'Mtr.Item("Sd2") = "-."
                    Mtr.Item("Date") = thisDate.Date
                    Mtr.Item("Day") = thisDate.ToString("yyyy-MM-dd")
                    Mtr.Item("SSN") = 2
                    Mtr.Item("Sn1") = ""
                    DataT.Rows.Add(Mtr)

                End If



                'DBCon2.Close()
                Application.DoEvents()
            Next
            GridControl5.DataSource = Nothing
            GridControl5.DataSource = DataT
        End Using
    End Sub
    Public Sub Load_Detail_View_DeviceBy_MonthBy_Edit(DateX As Date)
        Using db As New CsmdBioAttendenceEntities

            Dim FromDat As DateTime = DateX.Date

            Dim firstDay As DateTime = CDate(FF1.EditValue) ' CsmdDateTime.FirstDayOfMonth(FromDat)
            Dim lastDay As DateTime = CDate(FF2.EditValue) ' DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))
            'ClickforMonthly.Caption = "Now " & EmpName & " >>>"
            If intListE.Count > 0 Then
                Dim k2 As Integer = 1
                ProgressBarControl1.Properties.Maximum = intListE.Count
                ProgressBarControl1.Properties.Minimum = 0
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 0
                ProgressBarControl1.Update()
                For i As Integer = 0 To intListE.Count - 1
                    Class1.EmpID = intListE(i)
                    ProgressBarControl1.Position = k2
                    ProgressBarControl1.Update()
                    k2 += 1
                    Class1.EmpID = intListE(i)
                    Dim dtz = (From a In db.Employees Where a.Emp_ID = Class1.EmpID Select a).FirstOrDefault
                    If dtz IsNot Nothing Then
                        Dim k As Integer = 1
                        ProgressBarControl3.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate)) + 1
                        ProgressBarControl3.Properties.Minimum = 1
                        ProgressBarControl3.Properties.Appearance.BackColor = Color.Cyan
                        ProgressBarControl3.Position = 1
                        ProgressBarControl3.Update()
                        Dim sec As Integer = 0
                        For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate


                            Dim thisDate As Date = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(DateX.Date))
                            Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(DateX.Date))
                            'Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
                            'Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))

                            'MsgBox(TiA)
                            'MsgBox(TiB)

                            ProgressBarControl3.Position = k
                            ProgressBarControl3.Update()
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
                            '                    Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
                            '                    Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, " &
                            '"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Attendence_Device.Emp_ID " &
                            '"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
                            '"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
                            '"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
                            '"            WHERE " &
                            '"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & thisDate.ToString("yyyy/MM/dd") & "')  " &
                            '"AND (dbo.Emp_Attendence_Device.Emp_ID = " & Class1.EmpID & ") AND (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)

                            '                    Dim ds2 As New DataSet()
                            '                    da2.Fill(ds2)
                            Dim datteb As Date = CDate(thisDate.ToString("yyyy/MM/dd"))
                            Dim dtx = (From a In db.Emp_Attendence_Device
                                       Where a.Emp_ID = dtz.Emp_ID And
                              a.Emp_Attendence_Device_Day = datteb.Date And
                              a.Emp_Attendence_Device_Status = True
                                       Order By a.Emp_Attendence_Device_DateTime Ascending
                                       Select a.Emp_Attendence_Device_ID, a.Emp_Attendence_Device_DateTime,
                              a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time, a.Emp_Attendence_Device_Day,
                              a.Attendance_Duty_Status_ID, a.Emp_Bio_Device_Users_UserID,
                              a.Emp_Attendence_Device_Status, a.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type,
                              a.Attendance_Duty_Status.Attendance_Duty_Status_Type, a.Emp_ID, a.Emp_Attendence_Device_Duty_On_Off).ToList

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

                            Dim PrayAdate As String = ""
                            Dim PrayAtime As String = ""
                            Dim PrayAtimeN As String = ""
                            'Dim PrayBdate As String = ""
                            'Dim PrayBtime As String = ""
                            Dim ShAdate As String = ""
                            Dim ShAtime As String = ""
                            Dim ShAtimeN As String = ""
                            'Dim ShBdate As String = ""
                            'Dim ShBtime As String = ""
                            Dim LuAdate As String = ""
                            Dim LuAtime As String = ""
                            Dim LuAtimeN As String = ""
                            'Dim LuBdate As String = ""
                            'Dim LuBtime As String = ""
                            Dim PriAdate As String = ""
                            Dim PriAtime As String = ""
                            Dim PriAtimeN As String = ""
                            'Dim PriBdate As String = ""
                            'Dim PriBtime As String = ""
                            'Dim praID As Integer
                            'Dim shlID As Integer
                            'Dim lunID As Integer
                            'Dim priID As Integer
                            Dim uID As Integer
                            Dim dd As String = Microsoft.VisualBasic.Left(thisDate.ToString("dd-MM-yyyy"), 2)
                            Dim MM As String = Microsoft.VisualBasic.Mid(thisDate.ToString("dd-MM-yyyy"), 4, 2)
                            Dim yyyy As String = Microsoft.VisualBasic.Mid(thisDate.ToString("dd-MM-yyyy"), 7, 4)
                            Dim dat As String = yyyy & "-" & MM & "-" & dd
                            If dtx.Count > 0 Then
                                Dim rowNo As Integer = 0
                                'ProgressBarControl3.Properties.Maximum = dtx.Count - 1
                                'ProgressBarControl3.Properties.Minimum = 0
                                'ProgressBarControl3.Properties.Appearance.BackColor = Color.Yellow
                                'ProgressBarControl3.Position = 0
                                'ProgressBarControl3.Update()
                                For Each dsx In dtx
                                    'ProgressBarControl3.Position = rowNo
                                    'ProgressBarControl3.Update()
                                    If CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH") >= thisDate.ToString("yyyy/MM/dd HH") And CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH") <= ToDate.ToString("yyyy/MM/dd HH") Then

                                        If Not IsNothing(dsx.Emp_Bio_Device_Users_UserID) Then
                                            chkADate = CDate(CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd"))

                                            If dsx.Attendence_Status_Type.ToString = "RT-Check In" Then
                                                If chkA2 = False Then
                                                    cdd = CType(CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), String)
                                                    uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                    EditDEvice(uID, 1, Class1.EmpID, True, CType(TT1.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))
                                                    uIDs = uID

                                                    chkA = True
                                                    chkA2 = True
                                                    'Lst1.Items.Add("c1" & "" & thisDate.ToString("dd"))
                                                Else
                                                    EditDEvice(uID, 1, Class1.EmpID, False, CType(TT1.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))

                                                    chkA = False
                                                    chkA2 = True

                                                    'Lst1.Items.Add("c2" & "" & thisDate.ToString("dd"))
                                                End If
                                                'aph 828
                                            Else
                                                If dsx.Attendence_Status_Type.ToString = "LT-Check Out" Then
                                                    If mn = 0 And chkA = True Then
                                                        uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                        EditDEvice(uID, Nothing, Class1.EmpID, True, CType(TT2.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))
                                                        mn = 1
                                                        chkA = False
                                                        'Lst1.Items.Add("c4a" & "" & thisDate.ToString("dd"))
                                                    Else
                                                        If mn = 0 Then
                                                            Dim dti As String = CDate(TT1.EditValue).AddMinutes(CDbl(ck1.EditValue)).ToString("HH:mm")
                                                            Dim dStr As String = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd") & " " & dti
                                                            uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                            EditDEvice(uID - 1, 1, Class1.EmpID, True, CType(TT1.EditValue, String), CDate(dti), CDate(dStr))
                                                            chkA2 = True
                                                            chkA = False
                                                            'Lst1.Items.Add("c4b" & "" & thisDate.ToString("dd"))
                                                            mn = 1
                                                        Else
                                                            If mn = 1 Then
                                                                uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                                EditDEvice(uID, Nothing, Class1.EmpID, False, CType(TT2.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))

                                                                'Lst1.Items.Add("c4c" & "" & thisDate.ToString("dd"))
                                                                chkA2 = False
                                                                chkA = False
                                                            End If
                                                        End If

                                                    End If


                                                End If
                                            End If
                                            'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                        Else
                                            If dsx.Attendance_Duty_Status_ID < 2 Then

                                                EditDEvice(Nothing, 2, Class1.EmpID, True, CType(TT1.EditValue, String), CType(TT1.EditValue, String), DateTime.ParseExact(dat & " " & CType(TT1.EditValue, String) & ":" & "00", "yyyy-MM-dd HH:mm:ss", Nothing))
                                            End If
                                        End If
                                    End If
                                    'chkA2 = False
                                    'chkA = False
                                    rowNo += 1
                                    Application.DoEvents()
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

                                    EditDEvice(uIDs + 1, Nothing, Class1.EmpID, True, CType(TT2.EditValue, String), CDate(CDate(dti).ToString("HH:mm")), CDate(CDate(dStr).ToString("yyyy/MM/dd HH:mm")))
                                    'mn = 1
                                End If
                            Else

                                Dim HH As String = CDate(TT1.EditValue).Hour
                                Dim mmm As String = CDate(TT1.EditValue).Minute
                                Dim ss As String = CDate(TT1.EditValue).Second
                                Dim timX As String = HH.PadLeft(2, "0") & ":" & mmm.PadLeft(2, "0") & ":" & ss.PadLeft(2, "0")

                                '  intLists(i) =
                                EditDEvice(Nothing, 2, Class1.EmpID, True, CType(TT1.EditValue, String), CType(TT1.EditValue, String), DateTime.ParseExact(dat & " " & timX, "yyyy-MM-dd HH:mm:ss", Nothing))
                            End If

                            chkA2 = False

                            'DBCon2.Close()
                            Application.DoEvents()
                        Next

                    End If
                    Application.DoEvents()
                Next
            End If

            '746320344

            'GridControl5.DataSource = Nothing
            ''GridControl5.DataSource = DataT
            'Dim dt = (From a In db.Employees Where a.Emp_ID = Class1.EmpID Select a).FirstOrDefault
            'If dt IsNot Nothing Then
            '    Load_Detail_View_DeviceBy_Month(Class1.EmpID, dt.Emp_Reg, Class1.EmpDate)
            'Else
            '    GridControl5.DataSource = Nothing
            'End If
        End Using
    End Sub

    Public Sub Load_Detail_View_DeviceBy_MonthBy_EditOthers(DateX As Date)
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities

            Dim FromDat As DateTime = DateX.Date

            Dim firstDay As Date = CDate(FF1.EditValue) ' CsmdDateTime.FirstDayOfMonth(FromDat)
            Dim lastDay As Date = CDate(FF2.EditValue) ' DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))
            'ClickforMonthly.Caption = "Now " & EmpName & " >>>"
            If intListE.Count > 0 Then
                Dim k2 As Integer = 1
                ProgressBarControl1.Properties.Maximum = intListE.Count
                ProgressBarControl1.Properties.Minimum = 1
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 1
                ProgressBarControl1.Update()
                For i As Integer = 0 To intListE.Count - 1
                    Class1.EmpID = intListE(i)
                    ProgressBarControl1.Position = k2
                    ProgressBarControl1.Update()
                    k2 += 1

                    Dim dtz = (From a In db.Employees Where a.Emp_ID = Class1.EmpID Select a).FirstOrDefault
                    If dtz IsNot Nothing Then
                        GridColumn17.Caption = dtz.Emp_Name
                        Dim k As Integer = 1
                        ProgressBarControl3.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate)) + 1
                        ProgressBarControl3.Properties.Minimum = 1
                        ProgressBarControl3.Properties.Appearance.BackColor = Color.Yellow
                        ProgressBarControl3.Position = 1
                        ProgressBarControl3.Update()
                        Dim sec As Integer = 0
                        For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate


                            Dim thisDate As Date = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(DateX.Date))
                            Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(DateX.Date))
                            'Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
                            'Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))

                            'MsgBox(TiA)
                            'MsgBox(TiB)

                            ProgressBarControl3.Position = k
                            ProgressBarControl3.Update()
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
                            '                    Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
                            '                    Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name, " &
                            '"dbo.Attendence_Status.Attendence_Status_Type, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Attendence_Device.Emp_ID " &
                            '"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
                            '"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
                            '"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
                            '"            WHERE " &
                            '"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & thisDate.ToString("yyyy/MM/dd") & "')  " &
                            '"AND (dbo.Emp_Attendence_Device.Emp_ID = " & Class1.EmpID & ") AND (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)

                            '                    Dim ds2 As New DataSet()
                            '                    da2.Fill(ds2)
                            Dim datteb As Date = CDate(thisDate.ToString("yyyy/MM/dd"))
                            Dim dtx = (From a In db.Emp_Attendence_Device
                                       Where a.Emp_ID = dtz.Emp_ID And
                              a.Emp_Attendence_Device_Day = datteb.Date And
                              a.Emp_Attendence_Device_Status = True
                                       Order By a.Emp_Attendence_Device_DateTime Ascending
                                       Select a.Emp_Attendence_Device_ID, a.Emp_Attendence_Device_DateTime,
                              a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time, a.Emp_Attendence_Device_Day,
                              a.Attendance_Duty_Status_ID, a.Emp_Bio_Device_Users_UserID,
                              a.Emp_Attendence_Device_Status, a.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type,
                              a.Attendance_Duty_Status.Attendance_Duty_Status_Type, a.Emp_ID, a.Emp_Attendence_Device_Duty_On_Off).ToList

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

                            Dim PrayAdate As String = ""
                            Dim PrayAtime As String = ""
                            Dim PrayAtimeN As String = ""
                            'Dim PrayBdate As String = ""
                            'Dim PrayBtime As String = ""
                            Dim ShAdate As String = ""
                            Dim ShAtime As String = ""
                            Dim ShAtimeN As String = ""
                            'Dim ShBdate As String = ""
                            'Dim ShBtime As String = ""
                            Dim LuAdate As String = ""
                            Dim LuAtime As String = ""
                            Dim LuAtimeN As String = ""
                            'Dim LuBdate As String = ""
                            'Dim LuBtime As String = ""
                            Dim PriAdate As String = ""
                            Dim PriAtime As String = ""
                            Dim PriAtimeN As String = ""
                            'Dim PriBdate As String = ""
                            'Dim PriBtime As String = ""
                            Dim praID As Integer
                            Dim shlID As Integer
                            Dim lunID As Integer
                            Dim priID As Integer
                            Dim uID As Integer

                            If dtx.Count > 0 Then
                                Dim rowNo As Integer = 0
                                'ProgressBarControl3.Properties.Maximum = dtx.Count - 1
                                'ProgressBarControl3.Properties.Minimum = 0
                                'ProgressBarControl3.Properties.Appearance.BackColor = Color.Yellow
                                'ProgressBarControl3.Position = 0
                                'ProgressBarControl3.Update()
                                For Each dsx In dtx

                                    'ProgressBarControl3.Position = rowNo
                                    'ProgressBarControl3.Update()
                                    If CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH") >= thisDate.ToString("yyyy/MM/dd HH") And CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH") <= ToDate.ToString("yyyy/MM/dd HH") Then

                                        If Not IsNothing(dsx.Emp_Bio_Device_Users_UserID) Then
                                            'chkADate = CDate(CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd"))

                                            'If dsx.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type.ToString = "RT-Check In" Then
                                            '    If chkA2 = False Then
                                            '        cdd = CType(CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), String)
                                            '        uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            '        EditDEvice(uID, 1, Class1.EmpID, True, CType(TT1.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))
                                            '        uIDs = uID

                                            '        chkA = True
                                            '        chkA2 = True
                                            '        'Lst1.Items.Add("c1" & "" & thisDate.ToString("dd"))
                                            '    Else
                                            '        EditDEvice(uID, 1, Class1.EmpID, False, CType(TT1.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))

                                            '        chkA = False
                                            '        chkA2 = True

                                            '        'Lst1.Items.Add("c2" & "" & thisDate.ToString("dd"))
                                            '    End If
                                            '    'aph 828
                                            'Else
                                            '    If dsx.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type.ToString = "LT-Check Out" Then
                                            '        If mn = 0 And chkA = True Then
                                            '            uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            '            EditDEvice(uID, 1, Class1.EmpID, True, CType(TT2.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))
                                            '            mn = 1
                                            '            chkA = False
                                            '            'Lst1.Items.Add("c4a" & "" & thisDate.ToString("dd"))
                                            '        Else
                                            '            If mn = 0 Then
                                            '                Dim dti As String = CDate(TT1.EditValue).AddMinutes(CDbl(ck1.EditValue)).ToString("HH:mm")
                                            '                Dim dStr As String = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd") & " " & dti
                                            '                uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            '                EditDEvice(uID - 1, 1, Class1.EmpID, True, CType(TT1.EditValue, String), CDate(dti), CDate(dStr))
                                            '                chkA2 = True
                                            '                chkA = False
                                            '                'Lst1.Items.Add("c4b" & "" & thisDate.ToString("dd"))
                                            '                mn = 1
                                            '            Else
                                            '                If mn = 1 Then
                                            '                    uID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                            '                    EditDEvice(uID, 1, Class1.EmpID, False, CType(TT2.EditValue, String), CDate(CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")), CDate(dsx.Emp_Attendence_Device_DateTime))

                                            '                    'Lst1.Items.Add("c4c" & "" & thisDate.ToString("dd"))
                                            '                    chkA2 = False
                                            '                    chkA = False
                                            '                End If
                                            '            End If

                                            '        End If


                                            '    End If
                                            'End If
                                            'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                            If dsx.Attendence_Status_Type.ToString = "RI-Prayer A" Then
                                                If chkB2 = False Then
                                                    PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    praID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                    PrayAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")

                                                    chkB2 = True
                                                    chkB = True
                                                Else

                                                    'PrayAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtime), CDate(PrayAtimeN)))
                                                    If duration >= CInt(Pra.EditValue) Then
                                                        EditDEviceWithPSLP(praID + 1, 1, Class1.EmpID, True, CDate(PrayAtime).AddMinutes(CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(CDbl(Pra.EditValue)))
                                                    Else
                                                        EditDEviceWithPSLP(praID + 1, 1, Class1.EmpID, True, CDate(PrayAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & CDate(PrayAtimeN)))
                                                    End If
                                                    PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    praID = CInt(dsx.Emp_Bio_Device_Users_UserID)


                                                    chkB2 = True
                                                    chkB = True
                                                End If
                                            Else
                                                If dsx.Attendence_Status_Type.ToString = "LI-Prayer B" Then
                                                    If chkB2 = False Then
                                                        If chkB = True Then

                                                            chkB = False
                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtimeN), CDate(PrayAtime)))
                                                            If duration >= CInt(Pra.EditValue) Then
                                                                EditDEviceWithPSLP(praID - 1, 1, Class1.EmpID, True, CDate(PrayAtime).AddMinutes(-CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(-CDbl(Pra.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(praID - 1, 1, Class1.EmpID, True, CDate(PrayAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & CDate(PrayAtimeN)))
                                                            End If
                                                        Else

                                                            chkB = False
                                                            PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                            PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            praID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                            PrayAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtimeN), CDate(PrayAtime)))
                                                            If duration >= CInt(Pra.EditValue) Then
                                                                EditDEviceWithPSLP(praID - 1, 1, Class1.EmpID, True, CDate(PrayAtime).AddMinutes(-CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(-CDbl(Pra.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(praID - 1, 1, Class1.EmpID, True, CDate(PrayAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & CDate(PrayAtimeN)))
                                                            End If
                                                        End If


                                                        chkB2 = False
                                                    Else
                                                        PrayAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                        PrayAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                        praID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                        PrayAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")


                                                        chkB2 = False
                                                        chkB = False
                                                    End If
                                                End If
                                            End If
                                            'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                            If dsx.Attendence_Status_Type.ToString = "RM-Short Leave A" Then
                                                If chkC2 = False Then
                                                    ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                    ShAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")

                                                    chkC2 = True
                                                    chkC = True
                                                Else

                                                    ShAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtime), CDate(ShAtimeN)))
                                                    If duration > CInt(Shl.EditValue) Then
                                                        EditDEviceWithPSLP(shlID + 1, 1, Class1.EmpID, True, CDate(ShAtime).AddMinutes(CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(CDbl(Shl.EditValue)))
                                                    Else
                                                        EditDEviceWithPSLP(shlID + 1, 1, Class1.EmpID, True, CDate(ShAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & ShAtimeN))
                                                    End If
                                                    ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)


                                                    chkC2 = True
                                                    chkC = True
                                                End If

                                            Else
                                                If dsx.Attendence_Status_Type.ToString = "LM-Short Leave B" Then

                                                    If chkC2 = False Then
                                                        If chkC = True Then

                                                            chkC = False
                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtimeN), CDate(ShAtime)))
                                                            If duration > CInt(Shl.EditValue) Then
                                                                EditDEviceWithPSLP(shlID - 1, 1, Class1.EmpID, True, CDate(ShAtime).AddMinutes(-CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(-CDbl(Shl.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(shlID - 1, 1, Class1.EmpID, True, CDate(ShAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & ShAtimeN))
                                                            End If
                                                        Else

                                                            chkC = False
                                                            ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                            ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                            ShAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtimeN), CDate(ShAtime)))
                                                            If duration >= CInt(Shl.EditValue) Then
                                                                EditDEviceWithPSLP(shlID - 1, 1, Class1.EmpID, True, CDate(ShAtime).AddMinutes(-CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(-CDbl(Shl.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(shlID - 1, 1, Class1.EmpID, True, CDate(ShAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & ShAtimeN))
                                                            End If
                                                        End If



                                                        chkC2 = False
                                                    Else
                                                        ShAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                        ShAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                        shlID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                        ShAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")


                                                        chkC2 = False
                                                        chkC = False
                                                    End If
                                                End If
                                            End If
                                            'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                            If dsx.Attendence_Status_Type.ToString = "RR-Lunch A" Then
                                                If chkD2 = False Then
                                                    LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                    LuAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")


                                                    chkD2 = True
                                                    chkD = True
                                                Else

                                                    LuAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtime), CDate(LuAtimeN)))
                                                    If duration > CInt(Lun.EditValue) Then
                                                        EditDEviceWithPSLP(lunID + 1, 1, Class1.EmpID, True, CDate(LuAtime).AddMinutes(CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(CDbl(Lun.EditValue)))
                                                    Else
                                                        EditDEviceWithPSLP(lunID + 1, 1, Class1.EmpID, True, CDate(LuAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & LuAtimeN))
                                                    End If
                                                    LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)

                                                    chkD2 = True
                                                    chkD = True
                                                End If
                                            Else
                                                If dsx.Attendence_Status_Type.ToString = "LR-Lunch B" Then

                                                    If chkD2 = False Then
                                                        If chkD = True Then

                                                            chkD = False
                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtimeN), CDate(LuAtime)))
                                                            If duration > CInt(Lun.EditValue) Then
                                                                EditDEviceWithPSLP(lunID - 1, 1, Class1.EmpID, True, CDate(LuAtime).AddMinutes(-CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(-CDbl(Lun.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(lunID - 1, 1, Class1.EmpID, True, CDate(LuAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & LuAtimeN))
                                                            End If
                                                        Else

                                                            chkD = False
                                                            LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                            LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                            LuAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtimeN), CDate(LuAtime)))
                                                            If duration > CInt(Lun.EditValue) Then
                                                                EditDEviceWithPSLP(lunID - 1, 1, Class1.EmpID, True, CDate(LuAtime).AddMinutes(-CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(-CDbl(Lun.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(lunID - 1, 1, Class1.EmpID, True, CDate(LuAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & LuAtimeN))
                                                            End If
                                                        End If

                                                        chkD2 = False
                                                    Else
                                                        LuAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                        LuAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                        lunID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                        LuAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")

                                                        chkD2 = False
                                                        chkD = False
                                                    End If
                                                End If
                                            End If
                                            'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                                            If dsx.Attendence_Status_Type.ToString = "RP-Private A" Then
                                                If chkE2 = False Then
                                                    PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    priID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                    PriAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")

                                                    chkE2 = True
                                                    chkE = True
                                                Else


                                                    PriAtimeN = CDate(dtx.Item(rowNo + 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtime), CDate(PriAtimeN)))
                                                    If duration > CInt(Pri.EditValue) Then
                                                        EditDEviceWithPSLP(priID + 1, 1, Class1.EmpID, True, CDate(PriAtime).AddMinutes(CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(CDbl(Pri.EditValue)))
                                                    Else
                                                        EditDEviceWithPSLP(priID + 1, 1, Class1.EmpID, True, CDate(PriAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & PriAtimeN))
                                                    End If

                                                    PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                    PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                    priID = CInt(dsx.Emp_Bio_Device_Users_UserID)

                                                    chkE2 = True
                                                    chkE = True
                                                End If


                                            Else

                                                If dsx.Attendence_Status_Type.ToString = "LP-Private B" Then

                                                    If chkE2 = False Then
                                                        If chkE = True Then

                                                            chkE = False

                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtimeN), CDate(PriAtime)))
                                                            If duration > CInt(Pri.EditValue) Then
                                                                EditDEviceWithPSLP(priID - 1, 1, Class1.EmpID, True, CDate(PriAtime).AddMinutes(-CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(-CDbl(Pri.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(priID - 1, 1, Class1.EmpID, True, CDate(PriAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & PriAtimeN))
                                                            End If
                                                        Else

                                                            chkE = False
                                                            PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                            PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            priID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                            PriAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")
                                                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtimeN), CDate(PriAtime)))
                                                            If duration > CInt(Pri.EditValue) Then
                                                                EditDEviceWithPSLP(priID - 1, 1, Class1.EmpID, True, CDate(PriAtime).AddMinutes(-CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(-CDbl(Pri.EditValue)))
                                                            Else
                                                                EditDEviceWithPSLP(priID - 1, 1, Class1.EmpID, True, CDate(PriAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & PriAtimeN))
                                                            End If
                                                        End If

                                                        chkE2 = False
                                                    Else
                                                        PriAdate = CDate(dsx.Emp_Attendence_Device_DateTime).ToString("yyyy/MM/dd HH:mm:ss")
                                                        PriAtime = CDate(dsx.Emp_Attendence_Device_Time).ToString("HH:mm")
                                                        priID = CInt(dsx.Emp_Bio_Device_Users_UserID)
                                                        PriAtimeN = CDate(dtx.Item(rowNo - 1).Emp_Attendence_Device_Time).ToString("HH:mm")

                                                        chkE2 = False
                                                        chkE = False
                                                    End If

                                                End If
                                            End If
                                            'Else
                                            '    EditDEvice(Nothing, 2, Class1.EmpID, True, CType(TT1.EditValue, String), CDate("08:00"), CDate(thisDate.ToString("yyyy/MM/dd") & " " & CDate("08:00")))
                                        End If
                                    End If
                                    'chkA2 = False
                                    'chkA = False
                                    rowNo += 1
                                    Application.DoEvents()
                                Next

                                'If chkA = True Then
                                '    chkA = False
                                '    'Mtr = DataT.NewRow
                                '    'Mtr.Item("USERID") = EmpCode
                                '    'Mtr.Item("Date") = thisDate.Date
                                '    'Mtr.Item("SSN") = "LT-Check Out"
                                '    'Mtr.Item("Sn1") = ""
                                '    'DataT.Rows.Add(Mtr)
                                '    Dim dti As String = CDate(TT2.EditValue).AddMinutes(CDbl(ck2.EditValue)).ToString("HH:mm")
                                '    Dim dStr As String = chkADate & " " & dti

                                '    EditDEvice(uIDs + 1, 1, Class1.EmpID, True, CType(TT2.EditValue, String), CDate(CDate(dti).ToString("HH:mm")), CDate(CDate(dStr).ToString("yyyy/MM/dd HH:mm")))
                                '    'mn = 1
                                'End If
                                If chkB = True Then
                                    chkB = False
                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PrayAtime), CDate(PrayAtimeN)))
                                    If duration > CInt(Pra.EditValue) Then
                                        EditDEviceWithPSLP(praID + 1, 1, Class1.EmpID, True, CDate(PrayAtime).AddMinutes(CDbl(Pra.EditValue)), CDate(PrayAdate).AddMinutes(CDbl(Pra.EditValue)))
                                    Else
                                        EditDEviceWithPSLP(praID + 1, 1, Class1.EmpID, True, CDate(PrayAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & PrayAtimeN))
                                    End If
                                End If
                                If chkC = True Then
                                    chkC = False
                                    'EditDEviceWithPSLP(shlID + 1, True, CDate(ShAtime).AddMinutes(CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(CDbl(Shl.EditValue)))
                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(ShAtime), CDate(ShAtimeN)))
                                    If duration > CInt(Shl.EditValue) Then
                                        EditDEviceWithPSLP(shlID + 1, 1, Class1.EmpID, True, CDate(ShAtime).AddMinutes(CDbl(Shl.EditValue)), CDate(ShAdate).AddMinutes(CDbl(Shl.EditValue)))
                                    Else
                                        EditDEviceWithPSLP(shlID + 1, 1, Class1.EmpID, True, CDate(ShAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & ShAtimeN))
                                    End If
                                End If
                                If chkD = True Then
                                    chkD = False
                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(LuAtime), CDate(LuAtimeN)))
                                    If duration > CInt(Lun.EditValue) Then
                                        EditDEviceWithPSLP(lunID + 1, 1, Class1.EmpID, True, CDate(LuAtime).AddMinutes(CDbl(Lun.EditValue)), CDate(LuAdate).AddMinutes(CDbl(Lun.EditValue)))
                                    Else
                                        EditDEviceWithPSLP(lunID + 1, 1, Class1.EmpID, True, CDate(LuAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & LuAtimeN))
                                    End If
                                End If
                                If chkE = True Then
                                    chkE = False
                                    Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, CDate(PriAtime), CDate(PriAtimeN)))
                                    If duration > CInt(Lun.EditValue) Then
                                        EditDEviceWithPSLP(priID + 1, 1, Class1.EmpID, True, CDate(PriAtime).AddMinutes(CDbl(Pri.EditValue)), CDate(PriAdate).AddMinutes(CDbl(Pri.EditValue)))
                                    Else
                                        EditDEviceWithPSLP(priID + 1, 1, Class1.EmpID, True, CDate(PriAtimeN), CDate(thisDate.ToString("yyyy/MM/dd") & " " & PriAtimeN))
                                    End If
                                End If
                            Else
                                'EditDEvice(Nothing, 2, Class1.EmpID, True, CType(TT1.EditValue, String), CDate("08:00"), CDate(thisDate.ToString("yyyy/MM/dd") & " " & CDate("08:00")))

                            End If

                            chkA2 = False

                            'DBCon2.Close()
                            Application.DoEvents()
                        Next

                    End If
                    Application.DoEvents()
                Next
            End If

            '746320344

            'GridControl5.DataSource = Nothing
            ''GridControl5.DataSource = DataT
            'Dim dt = (From a In db.Employees Where a.Emp_ID = Class1.EmpID Select a).FirstOrDefault
            'If dt IsNot Nothing Then
            '    Load_Detail_View_DeviceBy_Month(Class1.EmpID, dt.Emp_Reg, Class1.EmpDate)
            'Else
            '    GridControl5.DataSource = Nothing
            'End If
        End Using
    End Sub

    'Private Sub BarButtonItem7_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
    '    Dim tt As String
    '    Dim ck As Integer = 1
    '    Dim pr As Integer = 1
    '    For k As Integer = 0 To GridView2.RowCount - 1

    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "RT-Check In" Then
    '            If ck = 1 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", "0800")
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                ck = 2
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", "2000")
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                ck = 1
    '            End If

    '        End If
    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "LT-Check Out" Then
    '            If ck = 2 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                ck = 2
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                ck = 1
    '            End If

    '        End If

    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "RI-Prayer A" Then
    '            If pr = 1 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    'tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            End If

    '        End If
    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "LI-Prayer B" Then
    '            If pr = 2 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    'tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            End If

    '        End If

    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "RM-Short Leave A" Then
    '            If pr = 1 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            End If

    '        End If
    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "LM-Short Leave B" Then
    '            If pr = 2 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            End If

    '        End If

    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "RR-Lunch A" Then
    '            If pr = 1 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            End If

    '        End If
    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "LR-Lunch B" Then
    '            If pr = 2 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            End If

    '        End If

    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "RP-Private A" Then
    '            If pr = 1 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            End If

    '        End If
    '        If CStr(GridView2.GetRowCellValue(k, "SSN")) = "LP-Private B" Then
    '            If pr = 2 Then
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 1
    '            Else
    '                If CStr(GridView2.GetRowCellValue(k, "Sn1")) = "" Then
    '                    GridView2.SetRowCellValue(k, "Sn1", tt)
    '                Else
    '                    tt = CStr(GridView2.GetRowCellValue(k, "Sn1"))
    '                End If
    '                pr = 2
    '            End If

    '        End If

    '    Next
    'End Sub
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

            Class1.DrawVertical("Emp_DutyOn", e)
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
            Class1.EmpID = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            Class1.EmpName = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Name"), String)
            Class1.EmpDate = CDate(AdvBandedGridView1.GetFocusedRowCellValue("Date"))
            'BarStaticItem2.Caption = EmpName & " isOn " & Class1.EmpDate
            FilterMonth = False
            GridColumn17.Caption = Class1.EmpName
            'Load_Detail_View_DeviceBy_Day(Class1.EmpID, Class1.EmpDate)
            'GridControl5.DataSource = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles AdvBandedGridView1.DoubleClick
        'Try
        'If bn = True Then
        '    Dtp1.EditValue = Class1.EmpDate
        '    Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate) '(EmpName, EmpDate)
        '    'TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(Nothing)
        '    bn = False
        'Else
        'Load_MainView_Single_Emp_DeviceBy_Month(Class1.EmpID, EmpDate)
        'TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(AdvBandedGridView1)
        'Dim frm As New Form3
        '    frm.ShowDialog()
        '    bn = True
        'End If
        TempGridCheckMarksSelection.ClearSelection()
        TempGridCheckMarksSelection.SelectRow(AdvBandedGridView1.FocusedRowHandle, True)
        LoadDock()

        'BarStaticItem2.Caption = EmpName & " isOn " & EmpDate

        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub AdvBandedGridView1_MouseUp(sender As Object, e As MouseEventArgs) Handles AdvBandedGridView1.MouseUp
        Try
            ShowSelection()
        Catch ex As Exception

        End Try
    End Sub
    'Dim intList() As Integer
    'Dim intLists() As String
    'Dim intListsX() As String

    Dim intListE() As Integer
    'Dim intLists() As String
    Dim intListRow As List(Of Integer) = New List(Of Integer)
    'Dim intListsX() As String
    Dim intListRows As List(Of Integer) = New List(Of Integer)

    Private Sub ShowSelection()
        Dim intL As Integer = 0
        Dim RowCount As Integer = TempGridCheckMarksSelection.SelectedCount - 1
        ReDim intListE(RowCount)
        intListRow.Clear()
        For ff As Integer = 0 To AdvBandedGridView1.RowCount - 1
            If TempGridCheckMarksSelection.IsRowSelected(ff) Then
                Dim obj1 As Object = TryCast(AdvBandedGridView1.GetRowCellValue(ff, "Emp_ID"), Object)
                If obj1 Is Nothing Then
                    Return
                End If
                intListRow.Add(CInt(obj1))
                intListE(intL) = CInt(obj1)
                intL += 1
            End If
        Next
        If intListRow.Count = 1 Then
            BtnLoad.Enabled = True
            BtnInOut.Enabled = True
            BtnActivity.Enabled = True
            BtnDelete.Enabled = False
            GridColumn17.Caption = Class1.EmpName
        ElseIf intListRow.Count > 1 Then
            BtnLoad.Enabled = False
            BtnInOut.Enabled = True
            BtnActivity.Enabled = True
            BtnDelete.Enabled = False
            GridColumn17.Caption = "Multi Selection"
            GridControl5.DataSource = Nothing
        Else
            BtnLoad.Enabled = False
            BtnInOut.Enabled = False
            BtnActivity.Enabled = False
            BtnDelete.Enabled = False
            GridColumn17.Caption = "No Selection"
            GridControl5.DataSource = Nothing
        End If
    End Sub
    Private Sub ShowSelectionAtt00000000()
        Try
            intListRows.Clear()
            For i As Integer = 0 To intListRow.Count - 1
                intListRows.Add(intListRow.Item(i))
            Next
            'Dim RowCount As Integer = GridView2.SelectedRowsCount - 1
            'ReDim intList(RowCount)
            'ReDim intLists(RowCount)
            'ReDim intListsX(RowCount)

            For i As Integer = 0 To intListRows.Count - 1
                'Dim row As Integer = (GridView2.GetSelectedRows()(i))
                TempGridCheckMarksSelection.SelectRow(intListRows.Item(i), True)
                'Dim obj As Object = TryCast(GridView2.GetRowCellValue(row, "ID"), Object)
                'If obj Is Nothing Then
                '    Return
                'End If
                'intList(i) = CInt(obj)
            Next i
            If intListRows.Count > 0 Then
                'CsmdVarible.intEmpID = CInt(GridView2.GetRowCellValue(intListRows.Item(0), "ID"))

                'LoadAtt(CsmdVarible.intEmpID, CDate(Issue_Date.EditValue))
                'Load_Payment_Month_Single(CsmdVarible.intEmpID, CDate(Issue_Date.EditValue))
            End If
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region "GridView1"
    Private Sub GridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView1.RowClick
        Try
            Class1.EmpID = CType(GridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            Class1.EmpName = CType(GridView1.GetFocusedRowCellValue("Emp_Bio_Device_User_Name"), String)
            Class1.EmpDate = CDate(GridView1.GetFocusedRowCellValue("Emp_Attendence_Device_Date"))
            'BarStaticItem2.Caption = EmpName & " isOn " & EmpDate
            FilterMonth = False
            GridColumn17.Caption = Class1.EmpName
            Load_Detail_View_DeviceBy_Day(Class1.EmpID, CDate(Dtp1.EditValue))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GridView3_RowClick(sender As Object, e As RowClickEventArgs) Handles GridView3.RowClick
        Try
            'Class1.EmpID = CType(GridView3.GetFocusedRowCellValue("Emp_ID"), Integer)
            'Class1.EmpName = CType(GridView3.GetFocusedRowCellValue("Emp_Bio_Device_User_Name"), String)
            'Class1.EmpDate = CDate(GridView3.GetFocusedRowCellValue("Emp_Attendence_Device_Date"))
            ''BarStaticItem2.Caption = EmpName & " isOn " & EmpDate
            'FilterMonth = False
            'GridColumn17.Caption = Class1.EmpName
            'Load_Detail_View_DeviceBy_Day(Class1.EmpID, CDate(Dtp1.EditValue))
        Catch ex As Exception

        End Try
    End Sub
    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle, GridView3.RowCellStyle
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

    Private Sub ex1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub ex2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub



#End Region
#Region "GridView2"
    Private Sub GridView2_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        Try
            If e.Column.FieldName = "SSN" Then
                Select Case e.CellValue.ToString
                    Case "RT-Check In"
                        e.Appearance.BackColor2 = Color.Cyan
                        e.Appearance.BackColor = Color.White
                    Case "LT-Check Out"
                        e.Appearance.BackColor = Color.Cyan
                        e.Appearance.BackColor2 = Color.White
                    Case "RI-Prayer A"

                        e.Appearance.BackColor = Color.White
                        e.Appearance.BackColor2 = Color.Lime
                    Case "LI-Prayer B"
                        e.Appearance.BackColor = Color.Lime
                        e.Appearance.BackColor2 = Color.White
                    Case "RM-Short Leave A", "LM-Short Leave B"
                        e.Appearance.BackColor = Color.LightBlue
                    Case "RR-Lunch A", "LR-Lunch B"
                        e.Appearance.BackColor = Color.Orange
                    Case "RP-Private A", "LP-Private B"
                        e.Appearance.BackColor = Color.Pink
                    Case "2"
                        e.Appearance.BackColor = Color.Blue
                        e.Appearance.ForeColor = Color.White
                    Case "3"
                        e.Appearance.BackColor = Color.Yellow
                        e.Appearance.ForeColor = Color.Black
                    Case "4"
                        e.Appearance.BackColor = Color.Purple
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


            End If
            If e.Column.FieldName = "Sd1" Then
                If Not CBool(InStr(e.CellValue.ToString, ":")) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.LimeGreen
                    e.Appearance.ForeColor = Color.Black
                    If e.CellValue.ToString = "OFF" Then
                        e.Appearance.BackColor = Color.Blue
                        e.Appearance.ForeColor = Color.White
                    End If
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
    Private Sub GridView2_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridView2.CustomDrawCell

    End Sub
    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.FieldName = "Sn1" Then
            Dim DBCon As New SqlConnection(CsmdCon.ConSqlDB)
            'Dim FAZ As New CsmdBioAttendenceEntities
            'Dim DBCon As New SqlConnection(FAZ.Database.Connection.ConnectionString)
            'Dim uID As Integer = CInt(GridView2.GetFocusedRowCellValue("USERID"))
            Dim dAT As Date = CDate(GridView2.GetFocusedRowCellValue("Day"))

            Dim uID As Integer = 0
            Dim sSN As String = CType(GridView2.GetFocusedRowCellValue("SSN"), String)


            'MsgBox(EmpName & "   " & sSN)
            'MsgBox(e.Value.ToString)



            Dim datX As DateTime = CDate(CDate(dAT.Date & " " & CDate(e.Value).ToString("HH:mm:ss")))

            'MsgBox(datX)

            Dim da As SqlDataAdapter = New SqlDataAdapter("Select        dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_ID, dbo.Attendence_Status.Attendence_Status_Type " &
"FROM            dbo.Attendence_Status INNER JOIN " &
 "                        dbo.Emp_Bio_Device_Users ON dbo.Attendence_Status.Attendence_Status_ID = dbo.Emp_Bio_Device_Users.Attendence_Status_ID " &
"WHERE      (dbo.Emp_Bio_Device_Users.Emp_ID = " & Class1.EmpID & ") And (dbo.Attendence_Status.Attendence_Status_Type = '" & sSN & "')", DBCon)
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
        Dim maxID As Integer
        Using db As New CsmdBioAttendenceEntities
            Try
                maxID = (From a In db.Emp_Attendence_Device Select a.Emp_Attendence_Device_ID).Max + 1
            Catch ex As Exception
                maxID = 1
            End Try
        End Using
        'Dim Crt_Login As String = "create login " & UserID.EditValue & " with password='" & UserPass.EditValue & "'"
        Dim Crt_User As String = "INSERT INTO Emp_Attendence_Device (Emp_Attendence_Device_ID,Emp_Bio_Device_Users_UserID,Emp_Attendence_Device_DateTime,Emp_Attendence_Device_Date,Emp_Attendence_Device_Day,Emp_Attendence_Device_Time,Emp_Attendence_Device_Status,Emp_ID,User_ID) VALUES (" & maxID & "," & UserID & ",'" & datX & "','" & datc & "','" & datc & "','" & tim & "','true'," & Class1.EmpID & "," & CsmdVarible.PlazaUserID & ")"
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
        Class1.EmpDate = CDate(GridView2.GetFocusedRowCellValue("Day"))
    End Sub

    Dim intList() As Integer
    Dim intLists() As String
    Dim intListsX() As String

    Private Sub ShowSelectionAtt()
        'Try
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
            'DateTime.ParseExact(ChkAdate & " " & ChkAtime, "dd-MM-yyyy HH:mm:ss", Nothing).ToString

            Dim dd As String = Microsoft.VisualBasic.Left(objs.ToString, 2)
            Dim MM As String = Microsoft.VisualBasic.Mid(objs.ToString, 4, 2)
            Dim yyyy As String = Microsoft.VisualBasic.Mid(objs.ToString, 7, 4)
            Dim dat As String = yyyy & "-" & MM & "-" & dd
            Dim HH As String = Microsoft.VisualBasic.Mid(objs.ToString, 12, 2)
            Dim mmm As String = Microsoft.VisualBasic.Mid(objs.ToString, 15, 2)
            Dim ss As String = Microsoft.VisualBasic.Mid(objs.ToString, 18, 2)
            Dim timX As String = HH & ":" & mmm & ":" & ss

            intLists(i) = DateTime.ParseExact(dat & " " & timX, "yyyy-MM-dd HH:mm:ss", Nothing).ToString
            intListsX(i) = objsx.ToString
        Next i
        If intList.Count > 0 Then
            BtnDelete.Enabled = True
        Else
            BtnDelete.Enabled = False
        End If
        'Catch ex As Exception

        'End Try
    End Sub

#End Region

#Region "Live Editors"
    Private Sub BarButtonItem3_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        RibbonMiniToolbar2.Hide()
        Call Load_Detail_View_DeviceBy_MonthBy_Edit(CDate(Dtp1.EditValue))

        If intListE.Count > 1 Then
            GridControl5.DataSource = Nothing
            MsgBox("Missing object (CheckIn-CheckOut) fill Successfull")
        Else
            LoadDock()
            MsgBox("Missing object (CheckIn-CheckOut) fill Successfull")
        End If

        'If bn = True Then
        'Dtp1.EditValue = EmpDate
        ''''Load_MainView_Single_Emp_DeviceBy_Month(Class1.EmpID, Class1.EmpDate)
        'bn = False
        'Else
        '    Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate) '(EmpName, EmpDate)
        '    'bn = True
        'End If
    End Sub
    Private Sub BarButtonItem8_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        RibbonMiniToolbar3.Hide()
        Call Load_Detail_View_DeviceBy_MonthBy_EditOthers(CDate(Dtp1.EditValue))
        LoadDock()
    End Sub
    Public Sub EditDEvice(uID As Integer, AttStatus As Integer, EmpID As Integer, Status As Boolean, dutyOnOff As String, timeX As Date, datetimeX As DateTime)
        Using db As New CsmdBioAttendenceEntities
            '  Dim datt As Date = CDate(CType(datetimeX.ToString("yyyy/MM/dd"), Date?))
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Status = True And a.Emp_ID = EmpID And a.Emp_Attendence_Device_DateTime = datetimeX Select a).FirstOrDefault
            If dt IsNot Nothing Then
                If Not dutyOnOff = "" Then
                    dt.Emp_Attendence_Device_Duty_On_Off = CDate(dutyOnOff).ToString("HH:mm")
                End If
                dt.Emp_ID = EmpID
                If AttStatus = 1 Then
                    dt.Attendance_Duty_Status_ID = AttStatus
                    dt.Emp_Bio_Device_Users_UserID = uID
                ElseIf AttStatus = 2 Or AttStatus = 3 Or AttStatus = 4 Then
                    'Else
                    dt.Attendance_Duty_Status_ID = AttStatus
                Else
                    dt.Attendance_Duty_Status_ID = Nothing
                    dt.Emp_Bio_Device_Users_UserID = uID
                End If
                dt.Emp_Attendence_Device_Status = Status
                dt.Emp_Attendence_Device_Time = timeX.ToString("HH:mm")
                'dt.Emp_Attendence_Device_DateTime = datetimeX
                dt.Emp_Attendence_Device_Date = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                dt.Emp_Attendence_Device_Day = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                db.SaveChanges()
            Else
                Try
                    Dim maxID As Integer
                    Try
                        maxID = (From a In db.Emp_Attendence_Device Select a.Emp_Attendence_Device_ID).Max + 1
                    Catch ex As Exception
                        maxID = 1
                    End Try
                    Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
                    With dtNew
                        .Emp_Attendence_Device_ID = maxID
                        If AttStatus = 1 Then
                            .Attendance_Duty_Status_ID = AttStatus
                            .Emp_Bio_Device_Users_UserID = uID
                        ElseIf AttStatus = 2 Or AttStatus = 3 Or AttStatus = 4 Then
                            .Attendance_Duty_Status_ID = AttStatus
                        Else
                            .Attendance_Duty_Status_ID = Nothing
                            .Emp_Bio_Device_Users_UserID = uID
                        End If
                        If Not dutyOnOff = "" Then
                            .Emp_Attendence_Device_Duty_On_Off = CDate(dutyOnOff).ToString("HH:mm")
                        End If
                        .Emp_ID = EmpID

                        .Emp_Attendence_Device_Status = Status
                        .Emp_Attendence_Device_Time = timeX.ToString("HH:mm")
                        .Emp_Attendence_Device_DateTime = datetimeX
                        .Emp_Attendence_Device_Date = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                        .Emp_Attendence_Device_Day = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                        .User_ID = CsmdVarible.PlazaUserID
                    End With
                    db.Emp_Attendence_Device.Add(dtNew)
                    db.SaveChanges()


                Catch ex As Exception

                End Try
            End If

        End Using
    End Sub
    Public Sub EditDEviceWithPSLP(uID As Integer, AttStatus As Integer, EmpID As Integer, Status As Boolean, timeX As Date, datetimeX As DateTime)
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            '  Dim datt As Date = CDate(CType(datetimeX.ToString("yyyy/MM/dd"), Date?))
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Status = True And a.Emp_ID = EmpID And a.Emp_Attendence_Device_DateTime = datetimeX Select a).FirstOrDefault
            If dt IsNot Nothing Then

                dt.Emp_ID = EmpID
                'dt.Attendance_Duty_Status_ID = AttStatus
                dt.Emp_Attendence_Device_Status = Status
                dt.Emp_Attendence_Device_Time = timeX.ToString("HH:mm")
                'dt.Emp_Attendence_Device_DateTime = datetimeX
                dt.Emp_Attendence_Device_Date = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                dt.Emp_Attendence_Device_Day = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                db.SaveChanges()
            Else
                Dim maxID As Integer
                Try
                    maxID = (From a In db.Emp_Attendence_Device Select a.Emp_Attendence_Device_ID).Max + 1
                Catch ex As Exception
                    maxID = 1
                End Try
                Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
                With dtNew
                    .Emp_Attendence_Device_ID = maxID
                    If AttStatus = 1 Then
                        .Emp_Bio_Device_Users_UserID = uID
                    End If
                    .Emp_ID = EmpID
                    '.Attendance_Duty_Status_ID = AttStatus
                    .Emp_Attendence_Device_Status = Status
                    .Emp_Attendence_Device_Time = timeX.ToString("HH:mm")
                    .Emp_Attendence_Device_DateTime = datetimeX
                    .Emp_Attendence_Device_Date = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                    .Emp_Attendence_Device_Day = CType(datetimeX.ToString("yyyy/MM/dd"), Date?)
                    .User_ID = CsmdVarible.PlazaUserID
                End With
                db.Emp_Attendence_Device.Add(dtNew)
                db.SaveChanges()
            End If

        End Using
    End Sub
#End Region
    Dim bn As Boolean = False




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
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Class1.EmpID = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            'EmpName = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Name"), String)
            Class1.EmpDate = CDate(Dtp1.EditValue) ' CDate(AdvBandedGridView1.GetFocusedRowCellValue("Date"))
            Dim dt = (From a In db.Employees Where a.Emp_ID = Class1.EmpID Select a).FirstOrDefault
            If dt IsNot Nothing Then
                FilterMonth = True
                GridColumn17.Caption = "MonthView " & dt.Emp_Name
                Load_Detail_View_DeviceBy_Month(Class1.EmpID, dt.Emp_Reg, Class1.EmpDate)
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

    Private Sub RepositoryItemDateEdit3_ButtonClick(sender As Object, e As ButtonPressedEventArgs)
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
                'FF1.EditValue = DateTime.Parse(CType(FF1.EditValue, String)).AddMonths(-1)
                'FF2.EditValue = DateTime.Parse(CType(FF2.EditValue, String)).AddMonths(-1)
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

                'Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
        End Select
        FF1.EditValue = CsmdDateTime.FirstDayOfMonth(CType(Dtp1.EditValue, DateTime))
        FF2.EditValue = CsmdDateTime.LastDayOfMonth(CType(Dtp1.EditValue, DateTime))
        'Timer2.Enabled = False
        'BarEditItem9.EditValue = False
        'BarStaticItem3.Caption = "Stop"
    End Sub

#End Region
    Dim FilterMonth As Boolean = False

#Region "BarButtonItem"
    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Load_MainView_Single_Emp_DeviceBy_Month(Class1.EmpID, Class1.EmpDate)
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        bn = False
        Class1.EmpDate = CDate(Dtp1.EditValue)
        Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate)
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick




    End Sub
    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

        'Load_Detail_View_DeviceBy_Day(EmpName, Class1.EmpDate)
        'Load_Detail_View_DeviceBy_Month(EmpName, Dtp1.EditValue)
        'Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
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

    Private Sub BarButtonItem17_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        bn = False
        Class1.EmpDate = CDate(Dtp1.EditValue)
        LabelControl1.Text = "Attendance Month of (" & Class1.EmpDate.ToString("MMMM-yyyy") & ")"
        Load_From_DeviceDB()

        Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate)
    End Sub

    Private Sub BarButtonItem16_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        'bn = False
        'Dtp1.EditValue = Today
        'Load_From_DeviceDB()
        'Class1.EmpDate = CDate(Dtp1.EditValue)
        'Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate)
        Form2.Show()
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Load_MainView_Single_Emp_DeviceBy_Month(Class1.EmpID, Class1.EmpDate)
        '    Lst1.Items.Clear()
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Me.Close()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick


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
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            ' Dim empID As Integer = 1
            Dim dateX As Date = CDate(Dtp1.EditValue)
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_ID = Class1.EmpID And a.Emp_Attendence_Device_Date.Value.Month = dateX.Month And a.Emp_Attendence_Device_Date.Value.Year = dateX.Year Select a).ToList
            If dt.Count > 0 Then
                For Each dts In dt
                    If dts.Emp_Attendence_Device_Status = False Then
                        dts.Emp_Attendence_Device_Status = True
                    End If
                Next
                db.SaveChanges()
                MsgBox("Reset Successfull")
                LoadDock()
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
    Private Sub btnConnect_ItemClick(sender As Object, e As EventArgs) Handles btnConnect.Click
        If txtIP.EditValue.ToString = "" Then
            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor
        If btnConnect.Text = "Disconnect" Then
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
            btnConnect.Text = "Connect"
            lblState.Text = "Disconnected"
            lblState.Appearance.BackColor = Color.Red
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected = axCZKEM1.Connect_Net(txtIP.EditValue.ToString, 4370)
        If bIsConnected = True Then
            btnConnect.Text = "Disconnect"
            btnConnect.Refresh()
            lblState.Text = "Connected"
            lblState.Appearance.BackColor = Color.LimeGreen
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            'If GetSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", "") = "" Then
            SaveSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", txtIP.EditValue.ToString)
            'End If

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
            lblState.Text = "No Found Device"
            '  MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub
    Dim interNetonOFF As Boolean = False
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'If lblState.Text = "No Found Device" Or lblState.Text = "Disconnected" Then
        '    btnConnect.PerformClick()
        'End If
        If CsmdCon.CheckForInternetConnection = True Then
            interNetonOFF = True
        Else
            interNetonOFF = False
        End If
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'If bIsConnected = True Then
        '    Timer2.Enabled = False
        'Else
        '    btnConnect.Text = "Connect"
        '    lblState.Text = "Disconnected"
        '    Timer2.Enabled = True
        'End If
    End Sub
    Private Sub lblState_TextChanged(sender As Object, e As EventArgs) Handles lblState.TextChanged
        'If lblState.Text = "No Found Device" Or lblState.Text = "Disconnected" Then
        '    Timer2.Enabled = True
        'Else
        '    Timer2.Enabled = False
        'End If
    End Sub
    Private Sub BarButtonItem15_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

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
        dow = True
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
        Dim k As Integer = 0
        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        'If axCZKEM1.ReadTimeGLogData(iMachineNumber, fromtime, totime) Then
        If axCZKEM1.ReadGeneralLogData(iMachineNumber) Then



            'ProgressBarControl2.Properties.Appearance.BackColor = Color.Yellow
            'ProgressBarControl2.Position = 0
            'ProgressBarControl2.Update()
            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode)
                If Not idwEnrollNumber = "" Then
                    k += 1
                End If
            End While
            ProgressBarControl2.Properties.Maximum = k
            ProgressBarControl2.Properties.Minimum = 0
            ProgressBarControl2.Position = 0
            ProgressBarControl2.Update()
        Else
            Cursor = Cursors.Default
            axCZKEM1.GetLastError(idwErrorCode)
            If idwErrorCode <> 0 Then
                MsgBox("Reading data from terminal failed,ErrorCode: " & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
            Else
                MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
            End If
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.WaitCursor
        axCZKEM1.EnableDevice(iMachineNumber, False)
        If axCZKEM1.ReadAllGLogData(iMachineNumber) Then
            While axCZKEM1.SSR_GetGeneralLogData(iMachineNumber, idwEnrollNumber, idwVerifyMode, idwInOutMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode) 'iGLCount += 1
                'axCZKEM1.GetDeviceStatus(iMachineNumber, 6, k)
                'axCZKEM1.SSR_GetDeviceDataCount()
                'lvItem = lvLogs.Items.Add(iGLCount.ToString())
                'lvItem.SubItems.Add(idwEnrollNumber.ToString())
                'lvItem.SubItems.Add(idwVerifyMode.ToString())
                'lvItem.SubItems.Add(idwInOutMode.ToString())
                Dim kk As String = (idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString() & " " & idwHour.ToString() & ":" & idwMinute.ToString() & ":" & idwSecond.ToString())
                Dim dd As DateTime = CDate(CType(kk, DateTime).ToString("yyyy-MM-dd HH:mm:ss"))

                Dim bb As String = (idwYear.ToString() & "-" + idwMonth.ToString() & "-" & idwDay.ToString())
                Dim ee As String = CType(bb, DateTime).ToString("yyyy-MM-dd")

                Dim nn As String = (idwHour.ToString() & ":" & idwMinute.ToString())
                Dim ff As String = CType(nn, DateTime).ToString("HH:mm")

                If Not idwEnrollNumber = "" Then
                    Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
                        Dim fg = (From a In db.Emp_Attendence_Device Where a.User_ID = CsmdVarible.PlazaUserID And a.Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?) And a.Emp_Attendence_Device_DateTime = dd Select a).FirstOrDefault
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
                            'db.SaveChanges()
                            'MsgBox(dd)
                            'RibbonPageGroup4.Text = dd
                        Else
                            Dim maxID As Integer = 0
                            'Try

                            Try
                                    maxID = CInt((From a In db.Emp_Attendence_Device Where a.User_ID = CsmdVarible.PlazaUserID Select a.Emp_Attendence_Device_ID).Max) + 1
                                    '  MsgBox(maxID)
                                Catch ex As Exception
                                    maxID = 1
                                    '  MsgBox(maxID)
                                End Try
                                Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
                                With dtNew
                                    .Emp_Attendence_Device_ID = maxID
                                    .Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?)
                                    .Emp_ID = db.Emp_Bio_Device_Users.Where(Function(o) o.Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?)).FirstOrDefault.Emp_ID
                                    .Emp_Attendence_Device_Day = CType(ee, Date?)
                                    .Emp_Attendence_Device_DateTime = dd
                                    .Emp_Attendence_Device_Date = CType(ee, Date?)
                                    .Emp_Attendence_Device_Time = ff
                                    .Emp_Attendence_Device_Status = True
                                    .User_ID = CsmdVarible.PlazaUserID
                                'MsgBox(.User_ID)
                            End With
                                '  MsgBox(dtNew.Emp_ID)
                                db.Emp_Attendence_Device.Add(dtNew)

                                ' MsgBox(dtNew.Emp_Bio_Device_Users_UserID)
                                db.SaveChanges()

                            'Catch ex As Exception
                            '    'MsgBox(maxID & " ex")
                            'End Try
                            'MsgBox(dd)
                            'MsgBox("mk")
                        End If
                        Application.DoEvents()
                    End Using
                    'MsgBox("mj")
                    'iGLCount += 1
                    'k += 1
                    iGLCount += 1
                    ProgressBarControl2.Position = iGLCount ' CInt((100 / 100) * iGLCount)
                    ProgressBarControl2.Update()

                Else
                    MsgBox("No data from terminal returns!", MsgBoxStyle.Exclamation, "Error")
                End If

                Application.DoEvents()
            End While
            'ProgressBarControl2.Position = 100
            'ProgressBarControl2.Update()
            dow = False
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

        Dim dd As DateTime = CDate(CType(kk, DateTime).ToString("yyyy-MM-dd HH:mm:ss"))

        Dim bb As String = (iYear.ToString() & "-" + iMonth.ToString() & "-" & iDay.ToString())
        Dim ee As String = CType(bb, DateTime).ToString("yyyy-MM-dd")

        Dim nn As String = (iHour.ToString() & ":" & iMinute.ToString())
        Dim ff As String = CType(nn, DateTime).ToString("HH:mm")
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim fg = (From a In db.Emp_Attendence_Device Where a.Emp_Bio_Device_Users_UserID = CType(sEnrollNumber, Integer?) And a.Emp_Attendence_Device_DateTime = dd Select a).FirstOrDefault
            Dim maxID As Integer
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
                Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
                With dtNew

                    Try
                        maxID = (From a In db.Emp_Attendence_Device Select a.Emp_Attendence_Device_ID).Max + 1
                    Catch ex As Exception
                        maxID = 1
                    End Try
                    .Emp_Attendence_Device_ID = maxID
                    .Emp_Bio_Device_Users_UserID = CType(sEnrollNumber, Integer?)
                    .Emp_ID = db.Emp_Bio_Device_Users.Where(Function(o) o.Emp_Bio_Device_Users_UserID = CType(sEnrollNumber, Integer?)).FirstOrDefault.Emp_ID
                    .Emp_Attendence_Device_Day = CType(ee, Date?)
                    .Emp_Attendence_Device_DateTime = dd
                    .Emp_Attendence_Device_Date = CType(ee, Date?)
                    .Emp_Attendence_Device_Time = ff
                    .Emp_Attendence_Device_Status = True
                    .User_ID = CsmdVarible.PlazaUserID
                End With
                db.Emp_Attendence_Device.Add(dtNew)
                db.SaveChanges()
            End If
            Try
                If My.Computer.Network.Ping("www.google.com") = True Then
                    'Load_From_DeviceDB()
                    DevOnline(maxID)

                End If
            Catch ex As Exception

                XtraTabControl1.SelectedTabPage = XtraTabPage1
                Load_From_DeviceDB()
            End Try



        End Using



        'Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
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

    Private Sub GridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub
    Private Sub GridView3_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView3.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub
    Private Sub GridView2_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles GridView2.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub

    Private Sub AdvBandedGridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub



    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        Dim frm As New Form3
        frm.ShowDialog()
    End Sub

    Private Sub txtIP_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub Dtp1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem7_ItemClick_2(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Form2.Show()
    End Sub

    Private Sub GridView2_ShowingEditor(sender As Object, e As CancelEventArgs) Handles GridView2.ShowingEditor
        If GridView2.FocusedColumn.FieldName = "SSN" AndAlso IsShipToUSCanada(GridView2, GridView2.FocusedRowHandle) Then
            e.Cancel = True
        End If
    End Sub

    Private Function IsShipToUSCanada(ByVal view As GridView, ByVal row As Integer) As Boolean
        Try
            Dim val As String = Convert.ToString(view.GetRowCellValue(row, "SSN"))
            Return (val = "RT-Check In" OrElse
            val = "LT-Check Out" OrElse
            val = "RI-Prayer A" OrElse
            val = "LI-Prayer B" OrElse
            val = "RM-Short Leave A" OrElse
            val = "LM-Short Leave B" OrElse
            val = "RR-Lunch A" OrElse
            val = "LR-Lunch B" OrElse
            val = "RP-Private A" OrElse
            val = "LP-Private B" OrElse
            val = "Saturday" OrElse
            val = "Sunday" OrElse
            val = "Monday" OrElse
            val = "Tuesday" OrElse
            val = "Wednesday" OrElse
            val = "Thursday" OrElse
            val = "Friday")
            'Return (val = "DayUse - CheckOut" OrElse val = "DayUse - Clean" OrElse val = "DayUse - Clean" OrElse val = "DayUse - Repair" OrElse val = "DayUse - Empty")
            'Return (val = "FOC - CheckOut" OrElse val = "FOC - Clean" OrElse val = "FOC - Clean" OrElse val = "FOC - Repair" OrElse val = "FOC - Empty")
        Catch
            Return False
        End Try
    End Function
    Dim cmbStatus As RepositoryItemLookUpEdit = New RepositoryItemLookUpEdit
    Dim Load_cmb_Attendance_Duty_Status As New cmb_Attendance_Duty_Status
    Dim oldV As Integer
    Private Sub cmbStatus_Popup(sender As Object, e As EventArgs)
        'Dim editor As LookUpEdit = TryCast(sender, LookUpEdit)
        oldV = CInt(GridView2.GetFocusedRowCellValue("SSN"))
        ' MsgBox(oldV)
    End Sub
    Private Sub cmbStatus_EditValueChanged(sender As Object, e As EventArgs)
        'Dim editor As GridLookUpEdit = TryCast(sender, GridLookUpEdit)
        ''Dim ExamTy As Integer = LookExamTerms.EditValue
        ''MsgBox(editor.EditValue.ToString)
        ''MsgBox(AdvBandedGridView1.GetFocusedRowCellValue("ClassRoom"))
        'Dim TeacXx As String = AdvBandedGridView1.Columns(AdvBandedGridView1.FocusedColumn.VisibleIndex).OwnerBand.ParentBand.Caption
        ''MsgBox(TeacXx)
        'Dim TeacX As String = Replace(TeacXx, Microsoft.VisualBasic.Right(TeacXx, 4), "")
        ''MsgBox(TeacX)
        'Dim Teac As String = Db.Period_Time.Where(Function(o) o.Period_Time_No = TeacX).FirstOrDefault.Period_Time_ID
        'Dim Dataa As Integer = editor.EditValue ' AdvBandedGridView1.GetFocusedRowCellValue(AdvBandedGridView1.FocusedColumn.FieldName)
        ''Dim Mnooc As Integer = AdvBandedGridView1.GetFocusedRowCellValue(AdvBandedGridView1.FocusedColumn.FieldName)
        'Dim Claa As Integer = AdvBandedGridView1.GetFocusedRowCellValue("ClassRoom")
        ''Dim Subb As Integer = editor.EditValue

        'Dim dt = (From a In Db.Subjects Where a.Sub_ClassRoom_ID = Claa And a.Sub_ID = Dataa Select a.Sub_ID, a.Subject_Books.Subject_Books_Name).FirstOrDefault
        ''MsgBox(dt.Sub_ID.ToString)

        ''MsgBox(dt.Sub_ID)
        Using db As New CsmdBioAttendenceEntities
            Dim editor As LookUpEdit = TryCast(sender, LookUpEdit)
            Dim StatusID As Integer = CInt(editor.EditValue)
            'Dim StatusID As Integer = CInt(GridView2.GetFocusedRowCellValue("SSN"))
            Dim EmpID As Integer = CInt(GridView2.GetFocusedRowCellValue("USERID"))
            Dim DateX As Date = CDate(GridView2.GetFocusedRowCellValue("Day"))
            'Dim Claa As Integer = AdvBandedGridView1.GetFocusedRowCellValue("ClassRoom")
            Dim dta = (From a In db.Emp_Attendence_Device Where a.Emp_ID = EmpID And a.Emp_Attendence_Device_Day = DateX And a.Emp_Attendence_Device_Status = True Select a).FirstOrDefault
            If dta IsNot Nothing Then
                With dta
                    '.Exam_Date_Sheet_Exam_Type_ID = ExamTy
                    'Dim kk As Integer = .Emp_Attendence_Device_ID
                    If StatusID = 1 Then
                        Dim dtl = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = EmpID Select a).ToList
                        If dtl.Count > 0 Then
                            Dim dd As Integer = 1
                            For Each dx In dtl
                                If dd < 3 Then
                                    Dim dtm = (From a In db.Emp_Attendence_Device Where a.Emp_ID = EmpID And a.Emp_Bio_Device_Users_UserID = dx.Emp_Bio_Device_Users_UserID And a.Emp_Attendence_Device_Day = DateX And a.Emp_Attendence_Device_Status = True Select a).FirstOrDefault
                                    If dtm IsNot Nothing Then
                                        With dtm

                                        End With
                                    Else
                                        Dim maxID As Integer
                                        Try
                                            maxID = (From a In db.Emp_Attendence_Device Select a.Emp_Attendence_Device_ID).Max + 1
                                        Catch ex As Exception
                                            maxID = 1
                                        End Try
                                        Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
                                        With dtNew
                                            .Emp_Attendence_Device_ID = maxID
                                            .Emp_ID = EmpID
                                            .Emp_Bio_Device_Users_UserID = dx.Emp_Bio_Device_Users_UserID
                                            .Emp_Attendence_Device_Date = CType(DateX.ToString("yyyy/MM/dd"), Date?)
                                            .Emp_Attendence_Device_Day = CType(DateX.ToString("yyyy/MM/dd"), Date?)
                                            .Emp_Attendence_Device_Status = True
                                            If dd = 1 Then
                                                .Attendance_Duty_Status_ID = StatusID
                                                .Emp_Attendence_Device_Time = CDate(TT1.EditValue).ToString("HH:mm")
                                                .Emp_Attendence_Device_DateTime = CDate(DateX.ToString("yyyy/MM/dd") & " " & .Emp_Attendence_Device_Time)
                                                .Emp_Attendence_Device_Duty_On_Off = .Emp_Attendence_Device_Time
                                            Else
                                                .Attendance_Duty_Status_ID = Nothing
                                                .Emp_Attendence_Device_Time = CDate(TT2.EditValue).ToString("HH:mm")
                                                .Emp_Attendence_Device_DateTime = CDate(DateX.ToString("yyyy/MM/dd") & " " & .Emp_Attendence_Device_Time)
                                                .Emp_Attendence_Device_Duty_On_Off = .Emp_Attendence_Device_Time
                                            End If
                                            .User_ID = CsmdVarible.PlazaUserID
                                        End With
                                        db.Emp_Attendence_Device.Add(dtNew)
                                        db.SaveChanges()

                                    End If
                                    dd += 1
                                End If
                            Next
                        End If

                        Dim kok As Integer = oldV
                        If kok > 1 Then
                            Dim dtn = (From a In db.Emp_Attendence_Device
                                       Where a.Emp_ID = EmpID And
                                        a.Attendance_Duty_Status_ID = kok And a.Emp_Attendence_Device_Day = DateX And a.Emp_Attendence_Device_Status = True Select a).FirstOrDefault
                            If dtn IsNot Nothing Then
                                With dtn
                                    .Emp_Attendence_Device_Status = False
                                End With
                                db.SaveChanges()
                            End If
                        End If


                    Else
                        dta.Attendance_Duty_Status_ID = StatusID
                    End If
                    '.Exam_Date_Sheet_Day = Dataa
                    '.T_Class_Period_Time_ID = Teac
                End With


                db.SaveChanges()
                'MsgBox("Update Status with " & editor.Text)
                'Dim messageBoxArgs As New XtraMessageBoxArgs() With {.Text = "This is an XtraMessageBox", .Caption = "Use XtraMessageBoxArgs"}

                'AddHandler messageBoxArgs.Showing, AddressOf MessageBoxArgs_Showing

                'XtraMessageBox.Show(messageBoxArgs)
                Dim frm As New MyXtraMessageBoxForm()
                frm.Location = MousePosition
                frm.ShowMessageBoxDialog(New XtraMessageBoxArgs(Me, "Update Status with " & editor.Text, "Csmd Editors", New DialogResult() {DialogResult.OK}, Nothing, 0))
                LoadDock()
            Else
                'Dim NewDt = New Teacher_Class_Period
                'With NewDt
                '    '.Exam_Date_Sheet_Exam_Type_ID = ExamTy
                '    .T_Class_Period_Sub_ID = dt.Sub_ID
                '    .T_Class_Period_Class_ID = Claa
                '    .T_Class_Period_Time_ID = Teac
                '    .User_ID = 1
                'End With
                'db.Teacher_Class_Period.Add(NewDt)


            End If


        End Using

    End Sub
    'Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click

    'End Sub
    'Private Sub MessageBoxArgs_Showing(ByVal sender As Object, ByVal e As XtraMessageShowingArgs)
    '    e.Form.StartPosition = FormStartPosition.CenterScreen
    'End Sub
    Private Sub GridView2_CustomRowCellEdit(sender As Object, e As CustomRowCellEditEventArgs) Handles GridView2.CustomRowCellEdit
        'Try
        If e.Column.FieldName Is "SSN" Then

            If GridView2.GetRowCellValue(e.RowHandle, "Sd1").ToString = "OFF" Then
                e.RepositoryItem = cmbStatus
                'ElseIf GridView1.GetRowCellDisplayText(e.RowHandle, GridColumn1).ToString = "TEXT" Then
                '    e.RepositoryItem = RepositoryItemGridLookUpEdit1
                'ElseIf GridView1.GetRowCellDisplayText(e.RowHandle, GridColumn1).ToString = "NUMBER" Then
                '    e.RepositoryItem = RepositoryItemSpinEdit1
                'ElseIf GridView1.GetRowCellDisplayText(e.RowHandle, GridColumn1).ToString = "COMBO" Then
                '    e.RepositoryItem = RepositoryItemComboBox1
                'ElseIf GridView1.GetRowCellDisplayText(e.RowHandle, GridColumn1).ToString = "CHECK" Then
                '    e.RepositoryItem = RepositoryItemCheckEdit1
            End If

        End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub frmAttendanceLives_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        'If (Me.WindowState = FormWindowState.Minimized) Then
        '    DockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Visible
        '    DockPanel1.MakeFloat(New Point(200, 0))
        '    'Dim gg As FloatForm
        '    'gg = CType(DockPanel1.Parent, FloatForm)
        '    CType(DockPanel1.Parent, FloatForm).Owner = Nothing
        'End If
    End Sub

    Private Sub DockManager1_EndDocking(sender As Object, e As EndDockingEventArgs)
        'If e.Panel.Dock = DockingStyle.Float Then
        '    Dim form = e.Panel.FindForm()
        '    If form IsNot Nothing Then
        '        form.Owner = Nothing
        '    End If
        'End If
    End Sub
    Dim frm As Form
    Private Sub BarButtonItem7_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)


        'Dim p1 As DockPanel = DockManager1.AddPanel(DockingStyle.Float)
        'p1.Text = "Panel 1"
        ''''DockPanel1.Height = Screen.PrimaryScreen.WorkingArea.Height
        ''''DockPanel1.FloatSize = New Size(326, Screen.PrimaryScreen.WorkingArea.Height)

        '''''' Move the panel to the bottom right corner of the screen.
        ''''DockPanel1.MakeFloat(pt)

        'DockPanel1.Height = Screen.PrimaryScreen.WorkingArea.Height

    End Sub


    'Private Sub BarButtonItem7_ItemClick_3(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
    '    If BarButtonItem7.Down = True Then
    '        'BarButtonItem7.Caption = "Back Main"
    '        'frm = New Form
    '        'LayoutControl3.Dock = DockStyle.Fill
    '        'frm.Controls.Add(LayoutControl3)

    '        'frm.Size = New Size(326, Screen.PrimaryScreen.WorkingArea.Height - 25)
    '        'Dim pt As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width - 320, 30)
    '        'frm.StartPosition = FormStartPosition.Manual
    '        'frm.Location = pt
    '        'frm.TopMost = True
    '        'frm.FormBorderStyle = FormBorderStyle.FixedDialog
    '        'frm.MinimizeBox = False
    '        'frm.MaximizeBox = False
    '        'frm.Show()
    '        'AddHandler frm.FormClosing, AddressOf frm_FormClosing
    '        Me.WindowState = FormWindowState.Minimized
    '    Else
    '        BarButtonItem7.Caption = "Floating"
    '        frm.Close()
    '        'LayoutControl3.Dock = DockStyle.Fill
    '        'DockPanel1.Controls.Add(LayoutControl3)
    '        'Me.WindowState = FormWindowState.Maximized
    '    End If

    'End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)
        Download_By_Month()
    End Sub
    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        If BarButtonItem6.Down = True Then
            strF = "Side"
            Me.WindowState = FormWindowState.Minimized
        Else
            BarButtonItem6.Caption = "Goto SidePanel"
            strF = "Full"
            frm.Close()
        End If
    End Sub
    Private Sub Form1_SizeChanged(ByVal sender As Object,
                              ByVal e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            BarButtonItem6.Caption = "Back Main"
            strF = "Side"
            BarButtonItem6.Down = True
            frm = New Form
            frm.Size = New Size(270, Screen.PrimaryScreen.WorkingArea.Height - 30)
            Dim pt As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width - 270, 30)
            frm.StartPosition = FormStartPosition.Manual
            frm.Location = pt
            frm.TopMost = True
            frm.FormBorderStyle = FormBorderStyle.None
            frm.MinimizeBox = False
            frm.MaximizeBox = False

            LayoutControl3.Dock = DockStyle.Fill
            frm.Controls.Add(LayoutControl3)
            frm.Show()
            AddHandler frm.FormClosing, AddressOf frm_FormClosing

            Me.NotifyIcon1.Visible = True
            Me.ShowInTaskbar = False
            frm.ShowInTaskbar = False
        Else
            Try
                frm.Close()
            Catch ex As Exception

            End Try

            Me.NotifyIcon1.Visible = False
            Me.ShowInTaskbar = True
        End If
    End Sub
    Dim frmX As Form
    Dim strF As String = "Full"
    Private Sub SimpleButton4_Click_2(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        If strF = "Full" Then
            strF = "Side"
            Me.WindowState = FormWindowState.Minimized
        ElseIf strF = "Side" Then
            strF = "SideHide"
            'frm.TopMost = False
            frm.Hide()
            frmX = New Form
            'MsgBox(SimpleButton4.Height)
            frmX.Size = New Size(26, 22)
            Dim pt As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width - 26, 30)
            frmX.StartPosition = FormStartPosition.Manual
            frmX.Location = pt
            frmX.TopMost = True
            frmX.FormBorderStyle = FormBorderStyle.None
            frmX.MinimizeBox = False
            frmX.MaximizeBox = False
            'MsgBox(frmX.Height)
            SimpleButton4.Dock = DockStyle.Fill
            frmX.Controls.Add(SimpleButton4)
            frmX.Show()

            AddHandler frmX.FormClosing, AddressOf frmX_FormClosing

            frmX.ShowInTaskbar = False
            frmX.Size = New Size(26, 24)
            'SimpleButton4.Location = New Point(-2, 0)

        ElseIf strF = "SideHide" Then
            frmX.Close()
            frm.Show()
            strF = "Side"
        End If
        'Dim pt As Point = New Point(Screen.PrimaryScreen.WorkingArea.Width - 50, 30)
        'frm.StartPosition = FormStartPosition.Manual

        'SimpleButton4.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - 100, 30)

        'frm.Location = pt
    End Sub
    'Private Sub SimpleButton4_DoubleClick(sender As Object, e As EventArgs) Handles SimpleButton4.DoubleClick
    '    frm.Close()
    'End Sub
    Private Sub SimpleButton4_MouseDown(sender As Object, e As MouseEventArgs) Handles SimpleButton4.MouseDown
        If e.Button.IsRight Then
            If strF = "Full" Then
            Else
                If strF = "SideHide" Then
                    frmX.Close()
                    frm.Close()
                Else
                    frm.Close()
                End If
            End If
        End If
    End Sub
    Private Sub frmX_FormClosing(sender As Object, e As FormClosingEventArgs)
        'strF = "Side"
        'BarButtonItem6.Down = False
        'LayoutControl3.Dock = DockStyle.Fill
        LayoutControlItem23.Control = SimpleButton4
        'Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub frm_FormClosing(sender As Object, e As FormClosingEventArgs)
        BarButtonItem6.Caption = "Goto SidePanel"
        BarButtonItem6.Down = False
        strF = "Full"
        LayoutControl3.Dock = DockStyle.Fill
        DockPanel1.Controls.Add(LayoutControl3)

        Me.WindowState = FormWindowState.Maximized
    End Sub
    Private Sub NotifyIcon1_DoubleClick(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick
        Me.WindowState = FormWindowState.Maximized
    End Sub
    'Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
    '    Dim filePath As String = Replace(System.Reflection.Assembly.GetExecutingAssembly().Location, ".exe", "") + ".exe.config"
    '    Dim objDoc As XDocument = XDocument.Load(filePath)
    '    Dim conEl = objDoc.Descendants("connectionStrings").Elements().First()
    '    conEl.Attribute("name").Value = "CsmdBioAttendenceEntities1"
    '    conEl.Attribute("connectionString").Value = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string='data source=" & sIP.EditValue.ToString & "," & sPort.EditValue.ToString & "; initial catalog=CsmdBioAttendence ;user id=sa; password=123;multipleactiveresultsets=True;application name=EntityFramework;'"
    '    'conEl.Attribute("connectionString").Value = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\sqlexpress; AttachDbFileName=|DataDirectory|DATA\CsmdTheLeadsSchool.mdf ;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;"
    '    objDoc.Save(filePath)

    '    lblState.Caption = "Current State: Connected"
    '    lblState.ItemAppearance.Normal.BackColor = Color.LimeGreen

    '    Dim datx As Date = CDate(Dtp1.EditValue)
    '    Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities1
    '        Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Date.Value.Month >= datx.Month And
    '                                                                      a.Emp_Attendence_Device_Date.Value.Month <= datx.Month And
    '                                                                      a.Emp_Attendence_Device_Date.Value.Year >= datx.Year And
    '                                                                      a.Emp_Attendence_Device_Date.Value.Year <= datx.Year
    '                  Select a).ToList
    '        If dt.Count > 0 Then
    '            Dim k As Integer = 0
    '            ProgressBarControl1.Properties.Maximum = dt.Count
    '            ProgressBarControl1.Properties.Minimum = 0
    '            ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
    '            ProgressBarControl1.Position = 0
    '            ProgressBarControl1.Update()
    '            For Each dts In dt
    '                ProgressBarControl1.Position = k
    '                ProgressBarControl1.Update()
    '                k += 1
    '                Using db2 As New CsmdBioAttendenceEntities
    '                    Dim df = (From a In db2.Emp_Attendence_Device Where a.Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID And
    '                                                                      a.Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
    '                              Select a).FirstOrDefault
    '                    If df IsNot Nothing Then

    '                    Else
    '                        Dim dfNew = New Emp_Attendence_Device
    '                        With dfNew
    '                            .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
    '                            .Emp_Attendence_Device_Date = dts.Emp_Attendence_Device_Date
    '                            .Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
    '                            .Emp_Attendence_Device_Time = dts.Emp_Attendence_Device_Time
    '                            .Emp_Attendence_Device_Status = dts.Emp_Attendence_Device_Status

    '                        End With
    '                        db2.Emp_Attendence_Device.Add(dfNew)
    '                        db2.SaveChanges()
    '                    End If
    '                End Using
    '            Next
    '            MsgBox("Import Done")
    '            bn = False
    '            Load_From_DeviceDB()
    '            EmpDate = CDate(Dtp1.EditValue)
    '            Load_MainView_Multi_Emp_DeviceBy_Day(EmpDate)
    '            lblState.Caption = "Status: Disconnected"
    '            lblState.ItemAppearance.Normal.BackColor = Color.Red
    '        End If

    '    End Using
    'End Sub

#End Region
#Region "Ribbon Color"
    '''''Private Sub RibbonControl1_CustomDrawItem(ByVal sender As Object, ByVal e As DevExpress.XtraBars.BarItemCustomDrawEventArgs) Handles RibbonControl1.CustomDrawItem
    '''''If e.RibbonItemInfo Is Nothing Then
    '''''    Return
    '''''End If
    '''''Dim link = TryCast(e.RibbonItemInfo.Item, BarItemLink)
    '''''If TypeOf link Is BarSubItemLink Then
    '''''    e.RibbonItemInfo.Appearance.ForeColor = Color.Red
    '''''End If
    '''''Dim linkb = TryCast(e.RibbonItemInfo.Item, BarEditItemLink)
    ''''''If TypeOf linkb Is BarEditItemLink Then
    ''''''    e.RibbonItemInfo.Appearance.ForeColor = Color.Red
    ''''''End If

    '''''If link.Item.Name = "BarButtonItem3" Then

    '''''    Draw(Brushes.Cyan, e)
    '''''End If
    '''''If link.Item.Name = "ck1" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.Cyan, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "ck2" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.Cyan, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "TT1" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.Cyan, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "TT2" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.Cyan, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "FF2" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.Cyan, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "FF1" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        'e.RibbonItemInfo.Appearance.BackColor = Color.Green
    '''''        Dim group As RibbonPageGroupViewInfo = TryCast(e.RibbonItemInfo.OwnerPageGroup, RibbonPageGroupViewInfo)
    '''''        If group.PageGroup.Name = "RibbonPageGroup6" Then
    '''''            e.Graphics.FillRectangle(Brushes.Cyan, group.ContentBounds)
    '''''        End If
    '''''        e.Cache.FillRectangle(Color.Cyan, e.Bounds)
    '''''    End If
    '''''End If

    '''''If link.Item.Name = "BarButtonItem8" Then
    '''''    Draw(Brushes.White, e)
    '''''End If
    '''''If link.Item.Name = "BarButtonItem6" Then
    '''''    'If e.State = DevExpress.XtraBars.ViewInfo.BarLinkState.Highlighted Then
    '''''    '    Using backBrush = New LinearGradientBrush(e.Bounds, Color.DarkOrange, Color.LightYellow, LinearGradientMode.BackwardDiagonal)
    '''''    '        e.Cache.Graphics.FillRectangle(backBrush, e.Bounds)
    '''''    '        e.Cache.Graphics.DrawLine(Pens.White, e.Bounds.Location, New Point(e.Bounds.Right, e.Bounds.Y))
    '''''    '        e.Cache.Graphics.DrawLine(Pens.Black, New Point(e.Bounds.X, e.Bounds.Bottom), New Point(e.Bounds.Right, e.Bounds.Bottom))
    '''''    '        e.Cache.Graphics.DrawLine(Pens.White, e.Bounds.Location, New Point(e.Bounds.X, e.Bounds.Bottom))
    '''''    '        e.Cache.Graphics.DrawLine(Pens.Black, New Point(e.Bounds.Right, e.Bounds.Y), New Point(e.Bounds.Right, e.Bounds.Bottom))
    '''''    '    End Using
    '''''    'Else
    '''''    '    e.Cache.FillRectangle(Brushes.Pink, e.Bounds)
    '''''    'End If
    '''''    'e.DrawText()
    '''''    'e.DrawGlyph()
    '''''    'e.Handled = True
    '''''    Draw(Brushes.Pink, e)
    '''''End If

    '''''If link.Item.Name = "BarButtonItem17" Then
    '''''    Draw(Brushes.Thistle, e)
    '''''End If
    '''''If link.Item.Name = "Dtp1" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        'e.RibbonItemInfo.Appearance.BackColor = Color.Green
    '''''        e.Cache.FillRectangle(Color.Thistle, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "BarButtonItem16" Then
    '''''    Dim group As RibbonPageGroupViewInfo = TryCast(e.RibbonItemInfo.OwnerPageGroup, RibbonPageGroupViewInfo)
    '''''    If group.PageGroup.Name = "RibbonPageGroup4" Then
    '''''        e.Graphics.FillRectangle(Brushes.Thistle, group.ContentBounds)
    '''''    End If
    '''''    Draw(Brushes.Thistle, e)
    '''''End If
    '''''If link.Item.Name = "Shl" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.LightBlue, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "Lun" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.Orange, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "Pri" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        e.Cache.FillRectangle(Color.Pink, e.Bounds)
    '''''    End If
    '''''End If
    '''''If link.Item.Name = "Pra" Then
    '''''    If TypeOf link Is BarEditItemLink Then
    '''''        'e.RibbonItemInfo.Appearance.BackColor = Color.Green
    '''''        Dim group As RibbonPageGroupViewInfo = TryCast(e.RibbonItemInfo.OwnerPageGroup, RibbonPageGroupViewInfo)
    '''''        If group.PageGroup.Name = "RibbonPageGroup3" Then
    '''''            e.Graphics.FillRectangle(Brushes.White, group.ContentBounds)
    '''''        End If
    '''''        e.Cache.FillRectangle(Color.Lime, e.Bounds)
    '''''    End If
    '''''End If

    ''''''e.Appearance.BackColor = Color.LightBlue
    ''''''Case "RR-Lunch A", "LR-Lunch B"
    ''''''e.Appearance.BackColor = Color.Orange
    ''''''Case "RP-Private A", "LP-Private B"
    ''''''e.Appearance.BackColor = Color.Pink

    ''''''If link.PageGroupName = "RibbonPageGroup6" Then
    ''''''    'If e.State = DevExpress.XtraBars.ViewInfo.BarLinkState.Highlighted Then
    ''''''    'Using backBrush = New LinearGradientBrush(e.Bounds, Color.DarkOrange, Color.LightYellow, LinearGradientMode.BackwardDiagonal)
    ''''''    '    e.Cache.Graphics.FillRectangle(backBrush, e.Bounds)
    ''''''    '    e.Cache.Graphics.DrawLine(Pens.White, e.Bounds.Location, New Point(e.Bounds.Right, e.Bounds.Y))
    ''''''    '    e.Cache.Graphics.DrawLine(Pens.Black, New Point(e.Bounds.X, e.Bounds.Bottom), New Point(e.Bounds.Right, e.Bounds.Bottom))
    ''''''    '    e.Cache.Graphics.DrawLine(Pens.White, e.Bounds.Location, New Point(e.Bounds.X, e.Bounds.Bottom))
    ''''''    '    e.Cache.Graphics.DrawLine(Pens.Black, New Point(e.Bounds.Right, e.Bounds.Y), New Point(e.Bounds.Right, e.Bounds.Bottom))
    ''''''    'End Using
    ''''''    'Else
    ''''''    e.Cache.FillRectangle(Brushes.Yellow, e.Bounds)
    ''''''    'End If
    ''''''    e.DrawText()
    ''''''    e.DrawGlyph()
    ''''''    e.DrawBackground()
    ''''''    'e.DrawEditor()
    ''''''    e.Handled = True
    ''''''End If
    ''''''Dim group As RibbonPageGroupViewInfo = TryCast(sender, RibbonPageGroupViewInfo)
    '''''''Dim group As RibbonPageGroupViewInfo = TryCast(e.RibbonItemInfo.OwnerPageGroup, RibbonPageGroupViewInfo)
    ''''''''group.ri
    '''''''''If (group.PageGroup.Name == "YOUR_RibbonPageGroup_NAME") Then
    '''''''''    e.Graphics.FillRectangle(Brushes.Yellow, group.ContentBounds);
    '''''''''Dim group As RibbonPageGroupViewInfo = CType((CType(e, RibbonDrawInfo)).ViewInfo, RibbonPageGroupViewInfo)
    '''''''If group.PageGroup.Name = "RibbonPageGroup6" Then
    '''''''    e.Graphics.FillRectangle(Brushes.Yellow, group.ContentBounds)
    '''''''End If
    ''''''Dim group As RibbonPageGroupViewInfo = CType((CType(e, RibbonDrawInfo)).ViewInfo, RibbonPageGroupViewInfo)
    ''''''Dim infoArgs As GroupObjectInfoArgs = group.GetDrawInfo()
    ''''''ObjectPainter.DrawObject(e.Cache, group.Painter, infoArgs)
    ''''''e.Graphics.FillRectangle(Brushes.IndianRed, group.CaptionBounds)
    ''''''e.Graphics.DrawString(group.PageGroup.Text, infoArgs.AppearanceCaption.Font, Brushes.Green, group.CaptionBounds)
    '''''End Sub
    '''''Private Sub Draw(ByVal Brush As Brush, ByVal e As DevExpress.XtraBars.BarItemCustomDrawEventArgs)
    '''''    If e.State = DevExpress.XtraBars.ViewInfo.BarLinkState.Highlighted Then
    '''''        Using backBrush = New LinearGradientBrush(e.Bounds, Color.DarkOrange, Color.LightYellow, LinearGradientMode.BackwardDiagonal)
    '''''            e.Cache.Graphics.FillRectangle(backBrush, e.Bounds)
    '''''            e.Cache.Graphics.DrawLine(Pens.White, e.Bounds.Location, New Point(e.Bounds.Right, e.Bounds.Y))
    '''''            e.Cache.Graphics.DrawLine(Pens.Black, New Point(e.Bounds.X, e.Bounds.Bottom), New Point(e.Bounds.Right, e.Bounds.Bottom))
    '''''            e.Cache.Graphics.DrawLine(Pens.White, e.Bounds.Location, New Point(e.Bounds.X, e.Bounds.Bottom))
    '''''            e.Cache.Graphics.DrawLine(Pens.Black, New Point(e.Bounds.Right, e.Bounds.Y), New Point(e.Bounds.Right, e.Bounds.Bottom))
    '''''        End Using
    '''''    Else
    '''''        e.Cache.FillRectangle(Brush, e.Bounds)
    '''''    End If
    '''''    e.DrawText()
    '''''    e.DrawGlyph()
    '''''    e.Handled = True
    '''''End Sub
#End Region


    Private Sub DockPanel2_CustomButtonClick(sender As Object, e As Docking2010.ButtonEventArgs)
        Select Case e.Button.Properties.Caption
            Case "Load"
                LoadDock()
            Case "Delete"
                If MsgBox("Are you sure want to Delete a this record", MsgBoxStyle.YesNo, "Delete") = vbYes Then
                    If intList.Count > 0 Then
                        For i As Integer = 0 To intList.Count - 1
                            Dim uID As Integer = intList(i)
                            If Not intLists(i) = "" Then
                                Dim dAT As Date = CDate(intLists(i))
                                Dim datX As Date = CDate(CDate(dAT).ToString("G")) '& " " & CDate(intListsX(i)).ToString("HH:mm")).ToString("G")
                                Dim Crt_User As String = "UPDATE [dbo].[Emp_Attendence_Device]  " &
        "SET [Emp_Attendence_Device_Status] = 'false' WHERE Emp_Bio_Device_Users_UserID = @USERID AND Emp_Attendence_Device_DateTime = @DateT ;"

                                Dim cmd As New SqlCommand
                                Dim con As New SqlConnection(CsmdCon.ConSqlDB)


                                cmd.Connection = con
                                con.Open()
                                cmd.Parameters.AddWithValue("@USERID", uID)
                                cmd.Parameters.AddWithValue("@DateT", datX)
                                cmd.CommandText = Crt_User
                                cmd.ExecuteNonQuery()
                                cmd.Dispose()
                                con.Close()


                            End If

                        Next
                        MsgBox("Delete is Success", MsgBoxStyle.Information, "Delete Done")
                        LoadDock()

                    Else
                        MsgBox("Please Select Record for DELETE", MsgBoxStyle.Critical, "Selection Error")
                    End If
                Else
                    Exit Sub
                End If

        End Select
    End Sub
    Public Sub LoadDock()
        Using db As New CsmdBioAttendenceEntities

            Class1.EmpID = CType(AdvBandedGridView1.GetFocusedRowCellValue("Emp_ID"), Integer)
            Class1.EmpDate = CDate(AdvBandedGridView1.GetFocusedRowCellValue("Date"))
            sum1 = 0
            sum2 = 0
            Dim dt = (From a In db.Employees Where a.Emp_ID = Class1.EmpID Select a).FirstOrDefault
            If dt IsNot Nothing Then
                Load_Detail_View_DeviceBy_Month(Class1.EmpID, dt.Emp_Reg, Class1.EmpDate)
            Else
                GridControl5.DataSource = Nothing
            End If

        End Using
    End Sub

    Private Sub DockPanel2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnLoad_Click(sender As Object, e As EventArgs) Handles BtnLoad.Click
        LoadDock()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If MsgBox("Are you sure want to Delete a this record", MsgBoxStyle.YesNo, "Delete") = vbYes Then
            If intList.Count > 0 Then
                For i As Integer = 0 To intList.Count - 1
                    Dim uID As Integer = intList(i)
                    If Not intLists(i) = "" Then
                        Dim dAT As String = CType(intLists(i), DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                        'Dim datX As DateTime = CDate(CDate(dAT).ToString("G")) '& " " & CDate(intListsX(i)).ToString("HH:mm")).ToString("G")

                        'Dim x1 As String = dAT.Day
                        'Dim x2 As String = dAT.Month
                        'Dim x3 As String = dAT.Year
                        'Dim x4 As String = dAT.Hour
                        'Dim x5 As String = dAT.Minute
                        'Dim x6 As String = dAT.Second

                        'Dim fDat As String = x3 & "-" & x2 & "-" & x1 & " " & x4 & ":" & x5 & ":" & x6


                        'CType(dAT, DateTime).ToString("yyyy-MM-dd HH:mm:ss")
                        Dim Crt_User As String = "UPDATE [dbo].[Emp_Attendence_Device]  " &
"SET [Emp_Attendence_Device_Status] = 'false' WHERE Emp_Bio_Device_Users_UserID = " & uID & " AND Emp_Attendence_Device_DateTime = '" & dAT & "' ;"

                        Dim cmd As New SqlCommand
                        Dim con As New SqlConnection(CsmdCon.ConSqlDB)


                        cmd.Connection = con
                        con.Open()
                        ' cmd.Parameters.AddWithValue("@USERID", uID)
                        ' cmd.Parameters.AddWithValue("@DateT", dAT.ToString("yyyy-MM-dd HH:mm:ss"))
                        cmd.CommandText = Crt_User
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        con.Close()


                    End If

                Next
                MsgBox("Delete is Success", MsgBoxStyle.Information, "Delete Done")
                LoadDock()

            Else
                MsgBox("Please Select Record for DELETE", MsgBoxStyle.Critical, "Selection Error")
            End If
        Else
            Exit Sub
        End If
    End Sub

    Private Sub CheckButton1_Click(sender As Object, e As EventArgs) Handles CheckButton1.CheckedChanged
        If CheckButton1.Checked = True Then
            gridBand4.Visible = True
        Else
            gridBand4.Visible = False
        End If
    End Sub

    Private Sub CheckButton2_Click(sender As Object, e As EventArgs) Handles CheckButton2.CheckedChanged
        If CheckButton2.Checked = True Then
            gridBand5.Visible = True
        Else
            gridBand5.Visible = False
        End If
    End Sub

    Private Sub CheckButton3_Click(sender As Object, e As EventArgs) Handles CheckButton3.CheckedChanged
        If CheckButton3.Checked = True Then
            gridBand8.Visible = True
        Else
            gridBand8.Visible = False
        End If
    End Sub

    Private Sub CheckButton4_Click(sender As Object, e As EventArgs) Handles CheckButton4.CheckedChanged
        If CheckButton4.Checked = True Then
            gridBand6.Visible = True
        Else
            gridBand6.Visible = False
        End If
    End Sub

    Private Sub CheckButton5_Click(sender As Object, e As EventArgs) Handles CheckButton5.CheckedChanged
        If CheckButton5.Checked = True Then
            gridBand7.Visible = True
        Else
            gridBand7.Visible = False
        End If
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        Try


            If My.Computer.Network.Ping("www.google.com") = True Then
                '  If CsmdCon.CheckForInternetConnection = True Then
                Using DBCon1 As New SqlConnection(CsmdCon.ConSqlDB)
                        Dim dat As Date = CDate(Dtp1.EditValue)
                        'Dim idd As Integer = CInt(TextBox1.Text)
                        Dim sqlStr As String = "SELECT * " &
                        "FROM dbo.Emp_Attendence_Device inner join Employees on dbo.Emp_Attendence_Device.Emp_ID=Employees.Emp_ID " &
                        "WHERE (dbo.Emp_Attendence_Device.User_ID=" & CsmdVarible.PlazaUserID & " and dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy-MM-dd") & "') and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') and Employees.Emp_Status='true'"
                        Dim da1 As SqlDataAdapter = New SqlDataAdapter(sqlStr, DBCon1)



                        Dim ds1 As New DataSet()
                        da1.Fill(ds1)
                        If ds1.Tables(0).Rows.Count > 0 Then
                            Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                                Dim k As Integer = 1
                                ProgressBarControl2.Properties.Maximum = ds1.Tables(0).Rows.Count
                                ProgressBarControl2.Properties.Minimum = 1
                                ProgressBarControl2.Properties.Appearance.BackColor = Color.Yellow
                                ProgressBarControl2.Position = 1
                                ProgressBarControl2.Update()
                                Dim Crt_User As String = ""
                                Dim connection As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                                For Each dts As DataRow In ds1.Tables(0).Rows
                                    ProgressBarControl2.Position = k
                                    ProgressBarControl2.Update()
                                    k += 1
                                    Dim devID As Integer = CInt(dts.Item("Emp_Attendence_Device_ID")) + 100000


                                    Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT * " &
                                                                                   "FROM dbo.Emp_Attendence_Device " &
                        "WHERE (dbo.Emp_Attendence_Device.User_ID=" & CsmdVarible.PlazaUserID & " and dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID = " & devID & ")", DBCon2)

                                    Dim ds2 As New DataSet()
                                    da2.Fill(ds2)
                                    If ds2.Tables(0).Rows.Count > 0 Then


                                    Else
                                        Try
                                            Crt_User = " INSERT INTO Emp_Attendence_Device " &
                                                                           " (Emp_Attendence_Device_ID, " &
                                                                           " User_ID, " &
                                                                           " Emp_Bio_Device_Users_UserID, " &
                                                                           " Attendance_Duty_Status_ID, " &
                                                                           " Emp_ID, " &
                                                                           " Emp_Attendence_Device_Duty_On_Off, " &
                                                                           " Emp_Attendence_Device_Cal1, " &
                                                                           " Emp_Attendence_Device_Cal2, " &
                                                                           " Emp_Attendence_Device_Cal3, " &
                                                                           " Emp_Attendence_Device_Cal4, " &
                                                                           " Emp_Attendence_Device_Cal5, " &
                                                                           " Emp_Attendence_Device_Cal6, " &
                                                                           " Emp_Attendence_Device_Cal7, " &
                                                                           " Emp_Attendence_Device_DateTime, " &
                                                                           " Emp_Attendence_Device_Date, " &
                                                                           " Emp_Attendence_Device_Day, " &
                                                                           " Emp_Attendence_Device_Time, " &
                                                                           " Emp_Attendence_Device_Status) " &
                                                                           "  VALUES  " &
                                                                           " (" & devID &
                                                                               "," & If(Not IsDBNull(dts.Item("User_ID")), dts.Item("User_ID"), "NULL") & ", " &
                                                                               "" & If(Not IsDBNull(dts.Item("Emp_Bio_Device_Users_UserID")), dts.Item("Emp_Bio_Device_Users_UserID"), "NULL") & ", " &
                                                                        "" & If(Not IsDBNull(dts.Item("Attendance_Duty_Status_ID")), dts.Item("Attendance_Duty_Status_ID"), "NULL") &
                                                                            "," & If(Not IsDBNull(dts.Item("Emp_ID")), dts.Item("Emp_ID"), "NULL") & ", " &
                                                                         " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Duty_On_Off")), CStr(dts.Item("Emp_Attendence_Device_Duty_On_Off")), "") & "', " &
                                                                           " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal1")), CStr(dts.Item("Emp_Attendence_Device_Cal1")), "") & "', " &
                                                                          " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal2")), CStr(dts.Item("Emp_Attendence_Device_Cal2")), "") & "', " &
                                                                          " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal3")), CStr(dts.Item("Emp_Attendence_Device_Cal3")), "") & "', " &
                                                                          " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal4")), CStr(dts.Item("Emp_Attendence_Device_Cal4")), "") & "', " &
                                                                          " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal5")), CStr(dts.Item("Emp_Attendence_Device_Cal5")), "") & "', " &
                                                                          " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal6")), CStr(dts.Item("Emp_Attendence_Device_Cal6")), "") & "', " &
                                                                          " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal7")), CStr(dts.Item("Emp_Attendence_Device_Cal7")), "") & "', " &
                                                                          " '" & CDate(dts.Item("Emp_Attendence_Device_DateTime")).ToString("yyyy/MM/dd HH:mm:ss") & "', " &
                                                                           " '" & CDate(dts.Item("Emp_Attendence_Device_Date")).ToString("yyyy/MM/dd") & "', " &
                                                                           " '" & CDate(dts.Item("Emp_Attendence_Device_Day")).ToString("yyyy/MM/dd") & "', " &
                                                                           " '" & CDate(dts.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "', " &
                                                                           " '" & CBool(dts.Item("Emp_Attendence_Device_Status")) & "')"
                                            Dim SqldataSet As New DataSet()
                                            Dim dataadapter As New SqlDataAdapter
                                            Dim cmd As New SqlCommand

                                            connection.Open()
                                            cmd.Connection = connection
                                            'cmd.CommandText = Crt_Login
                                            'cmd.ExecuteScalar()
                                            cmd.CommandText = Crt_User
                                            cmd.ExecuteNonQuery()
                                            connection.Close()
                                        Catch ex As Exception
                                            'MsgBox("Aa")
                                        End Try

                                    End If
                                    Application.DoEvents()
                                Next



                                DBCon2.Close()
                            End Using
                        End If
                        DBCon1.Close()
                        XtraTabControl1.SelectedTabPage = XtraTabPage2
                        Load_From_DeviceDBonline()
                    End Using
                ' Else
                '  MsgBox("Please Check Internet Connection", vbCritical, "Internet Error")
                'End If
            End If
        Catch ex As Exception
            MsgBox("Please Check Internet Connection", vbCritical, "Internet Error")
        End Try
    End Sub
    Public Sub DevOnline(DevIDs As Integer)

        'If CsmdCon.CheckForInternetConnection = True Then
        Using DBCon1 As New SqlConnection(CsmdCon.ConSqlDB)
                Dim dat As Date = CDate(Dtp1.EditValue)
                'Dim idd As Integer = CInt(TextBox1.Text)
                Dim sqlStr As String = "SELECT * " &
                "FROM dbo.Emp_Attendence_Device inner join Employees on dbo.Emp_Attendence_Device.Emp_ID=Employees.Emp_ID " &
                "WHERE (dbo.Emp_Attendence_Device.User_ID=" & CsmdVarible.PlazaUserID & " and dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy-MM-dd") & "') and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') and Employees.Emp_Status='true' and Emp_Attendence_Device_ID=" & DevIDs
                Dim da1 As SqlDataAdapter = New SqlDataAdapter(sqlStr, DBCon1)



                Dim ds1 As New DataSet()
                da1.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                        'Dim k As Integer = 1
                        'ProgressBarControl2.Properties.Maximum = ds1.Tables(0).Rows.Count
                        'ProgressBarControl2.Properties.Minimum = 1
                        'ProgressBarControl2.Properties.Appearance.BackColor = Color.Yellow
                        'ProgressBarControl2.Position = 1
                        'ProgressBarControl2.Update()
                        Dim Crt_User As String = ""
                        Dim connection As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                        For Each dts As DataRow In ds1.Tables(0).Rows
                            'ProgressBarControl2.Position = k
                            'ProgressBarControl2.Update()
                            'k += 1
                            Dim devID As Integer = CInt(dts.Item("Emp_Attendence_Device_ID")) + 100000


                            Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT * " &
                                                                           "FROM dbo.Emp_Attendence_Device " &
                "WHERE (dbo.Emp_Attendence_Device.User_ID=" & CsmdVarible.PlazaUserID & " and dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID = " & devID & ")", DBCon2)

                            Dim ds2 As New DataSet()
                            da2.Fill(ds2)
                            If ds2.Tables(0).Rows.Count > 0 Then


                            Else
                                Try
                                    Crt_User = " INSERT INTO Emp_Attendence_Device " &
                                                                   " (Emp_Attendence_Device_ID, " &
                                                                   " User_ID, " &
                                                                   " Emp_Bio_Device_Users_UserID, " &
                                                                   " Attendance_Duty_Status_ID, " &
                                                                   " Emp_ID, " &
                                                                   " Emp_Attendence_Device_Duty_On_Off, " &
                                                                   " Emp_Attendence_Device_Cal1, " &
                                                                   " Emp_Attendence_Device_Cal2, " &
                                                                   " Emp_Attendence_Device_Cal3, " &
                                                                   " Emp_Attendence_Device_Cal4, " &
                                                                   " Emp_Attendence_Device_Cal5, " &
                                                                   " Emp_Attendence_Device_Cal6, " &
                                                                   " Emp_Attendence_Device_Cal7, " &
                                                                   " Emp_Attendence_Device_DateTime, " &
                                                                   " Emp_Attendence_Device_Date, " &
                                                                   " Emp_Attendence_Device_Day, " &
                                                                   " Emp_Attendence_Device_Time, " &
                                                                   " Emp_Attendence_Device_Status) " &
                                                                   "  VALUES  " &
                                                                   " (" & devID &
                                                                       "," & If(Not IsDBNull(dts.Item("User_ID")), dts.Item("User_ID"), "NULL") & ", " &
                                                                       "" & If(Not IsDBNull(dts.Item("Emp_Bio_Device_Users_UserID")), dts.Item("Emp_Bio_Device_Users_UserID"), "NULL") & ", " &
                                                                "" & If(Not IsDBNull(dts.Item("Attendance_Duty_Status_ID")), dts.Item("Attendance_Duty_Status_ID"), "NULL") &
                                                                    "," & If(Not IsDBNull(dts.Item("Emp_ID")), dts.Item("Emp_ID"), "NULL") & ", " &
                                                                 " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Duty_On_Off")), CStr(dts.Item("Emp_Attendence_Device_Duty_On_Off")), "") & "', " &
                                                                   " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal1")), CStr(dts.Item("Emp_Attendence_Device_Cal1")), "") & "', " &
                                                                  " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal2")), CStr(dts.Item("Emp_Attendence_Device_Cal2")), "") & "', " &
                                                                  " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal3")), CStr(dts.Item("Emp_Attendence_Device_Cal3")), "") & "', " &
                                                                  " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal4")), CStr(dts.Item("Emp_Attendence_Device_Cal4")), "") & "', " &
                                                                  " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal5")), CStr(dts.Item("Emp_Attendence_Device_Cal5")), "") & "', " &
                                                                  " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal6")), CStr(dts.Item("Emp_Attendence_Device_Cal6")), "") & "', " &
                                                                  " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal7")), CStr(dts.Item("Emp_Attendence_Device_Cal7")), "") & "', " &
                                                                  " '" & CDate(dts.Item("Emp_Attendence_Device_DateTime")).ToString("yyyy/MM/dd HH:mm:ss") & "', " &
                                                                   " '" & CDate(dts.Item("Emp_Attendence_Device_Date")).ToString("yyyy/MM/dd") & "', " &
                                                                   " '" & CDate(dts.Item("Emp_Attendence_Device_Day")).ToString("yyyy/MM/dd") & "', " &
                                                                   " '" & CDate(dts.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "', " &
                                                                   " '" & CBool(dts.Item("Emp_Attendence_Device_Status")) & "')"
                                    Dim SqldataSet As New DataSet()
                                    Dim dataadapter As New SqlDataAdapter
                                    Dim cmd As New SqlCommand

                                    connection.Open()
                                    cmd.Connection = connection
                                    'cmd.CommandText = Crt_Login
                                    'cmd.ExecuteScalar()
                                    cmd.CommandText = Crt_User
                                    cmd.ExecuteNonQuery()
                                    connection.Close()
                                Catch ex As Exception
                                    'MsgBox("Aa")
                                End Try

                            End If
                            Application.DoEvents()
                        Next



                        DBCon2.Close()
                    End Using
                End If
                DBCon1.Close()
                XtraTabControl1.SelectedTabPage = XtraTabPage2
                Load_From_DeviceDBonline()
            End Using
        'Else
        '    MsgBox("Please Check Internet Connection", vbCritical, "Internet Error")
        'End If

    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Download_By_Month()
    End Sub

    Private Sub CheckButton6_CheckedChanged(sender As Object, e As EventArgs)
        'If CheckButton6.Checked = True Then
        '    GridView1.Columns("Emp_Bio_Device_User_Name").Group()
        'Else
        '    GridView1.Columns("Emp_Bio_Device_User_Name").UnGroup()
        'End If
        LayoutControl3.Dock = DockStyle.Fill
    End Sub

    Private Sub CheckButton7_CheckedChanged(sender As Object, e As EventArgs)
        'If CheckButton7.Checked = True Then
        '    GridView1.Columns("Attendence_Status_Type").Group()
        'Else
        '    GridView1.Columns("Attendence_Status_Type").UnGroup()
        'End If
        'bn = False
        'Dtp1.EditValue = Today
        XtraTabControl1.SelectedTabPage = XtraTabPage1
        Load_From_DeviceDB()
        Class1.EmpDate = CDate(Dtp1.EditValue)
        'Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate)
    End Sub
    Private Sub shafqat_ItemClick(sender As Object, e As EventArgs)
        'If shafqat.Checked = True Then
        '    GridView1.ExpandAllGroups()
        '    shafqat.Text = "Collapse All"
        'Else
        '    GridView1.CollapseAllGroups()
        '    shafqat.Text = "Expand All"
        'End If

        XtraTabControl1.SelectedTabPage = XtraTabPage1
        Load_From_DeviceDBonline()
    End Sub
    Private Sub ProgressBarControl1_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs) Handles ProgressBarControl1.CustomDisplayText
        Dim val As String = e.Value.ToString()
        e.DisplayText = "The progress is: " & val & " of " & ProgressBarControl1.Properties.Maximum
    End Sub
    Private Sub ProgressBarControl2_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs) Handles ProgressBarControl2.CustomDisplayText
        Dim val As String = e.Value.ToString()
        If dow = True Then
            e.DisplayText = "The progress is: " & val & " of " & ProgressBarControl2.Properties.Maximum
        Else
            e.DisplayText = "The progress is: " & val & " of " & ProgressBarControl2.Properties.Maximum
        End If
    End Sub
    Dim dow As Boolean = False
    Private Sub ProgressBarControl3_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs) Handles ProgressBarControl3.CustomDisplayText
        Dim val As String = e.Value.ToString()
        If dow = True Then
            'e.DisplayText = "The progress is: " & val '& " of " & ProgressBarControl3.Properties.Maximum
        Else
            e.DisplayText = "The progress is: " & val & " of " & ProgressBarControl3.Properties.Maximum
        End If




    End Sub

    Private Sub Dtp1_Properties_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Dtp1.Properties.ButtonClick
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
                'FF1.EditValue = DateTime.Parse(CType(FF1.EditValue, String)).AddMonths(-1)
                'FF2.EditValue = DateTime.Parse(CType(FF2.EditValue, String)).AddMonths(-1)
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

                'Load_MainView_Single_Emp_DeviceBy_Month(EmpID, EmpDate)
        End Select
        FF1.EditValue = CsmdDateTime.FirstDayOfMonth(CDate(Dtp1.EditValue))
        FF2.EditValue = CsmdDateTime.LastDayOfMonth(CDate(Dtp1.EditValue))
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        'Select Case e.Page.Text
        '    Case "Offline"
        '        Load_From_DeviceDB()
        '    Case "Online"
        '        Load_From_DeviceDBonline()
        'End Select
    End Sub

    Private Sub XtraTabControl1_TabMiddleClick(sender As Object, e As PageEventArgs) Handles XtraTabControl1.TabMiddleClick
        'Select Case e.Page.Text
        '    Case "Offline"
        '        Load_From_DeviceDB()
        '    Case "Online"
        '        Load_From_DeviceDBonline()
        'End Select
    End Sub

    'Private Sub XtraTabPage1_Click(sender As Object, e As EventArgs) Handles XtraTabPage1.Click
    '    MsgBox("fff")
    'End Sub

    'Private Sub XtraTabPage1_DoubleClick(sender As Object, e As EventArgs) Handles XtraTabPage1.DoubleClick
    '    MsgBox("ggg")
    'End Sub

    'Private Sub XtraTabPage1_MouseDown(sender As Object, e As MouseEventArgs) Handles XtraTabPage1.MouseDown

    'End Sub

    Private Sub XtraTabControl1_MouseDown(sender As Object, e As MouseEventArgs) Handles XtraTabControl1.MouseDown
        Dim xtc As XtraTabControl = TryCast(sender, XtraTabControl)
        Dim pos As Point = New Point(e.X, e.Y)
        Dim xthi As DevExpress.XtraTab.ViewInfo.XtraTabHitInfo = xtc.CalcHitInfo(pos)
        Dim tp As String = xthi.Page.Name
        Class1.EmpDate = CDate(Dtp1.EditValue)
        If tp = XtraTabPage1.Name Then
            Load_From_DeviceDB()
        End If
        If tp = XtraTabPage2.Name Then
            Load_From_DeviceDBonline()
        End If
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Load_From_DeviceDB()
        Class1.EmpDate = CDate(Dtp1.EditValue)
        Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate)
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        bn = False
        Class1.EmpDate = CDate(Dtp1.EditValue)
        LabelControl1.Text = "Attendance Month of (" & Class1.EmpDate.ToString("MMMM-yyyy") & ")"
        Load_From_DeviceDB()

        Load_MainView_Multi_Emp_DeviceBy_Day(Class1.EmpDate)
    End Sub

    Private Sub lblState_DoubleClick(sender As Object, e As EventArgs) Handles lblState.DoubleClick
        frm.Close()
    End Sub

    Private Sub BarButtonItem7_ItemClick_3(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Using db As New CsmdBioAttendenceEntities
            Dim FromDat As DateTime = CDate(Dtp1.EditValue)
            Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat)
            Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))

            Dim AAz As Date = CDate(firstDay & " " & CsmdDateTime.StartDayTime(FromDat.Date))
            Dim AAx As Date = CDate(lastDay & " " & CsmdDateTime.EndDayTime(FromDat.Date))
            Dim kk As Integer = 0
            Dim k2 As Integer = 0
            ProgressBarControl1.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate))
            ProgressBarControl1.Properties.Minimum = 0
            ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
            ProgressBarControl1.Position = 0
            ProgressBarControl1.Update()
            For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate
                Application.DoEvents()
                ProgressBarControl1.Position = k2
                ProgressBarControl1.Update()
                k2 += 1
                Dim thisDate As DateTime = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(FromDat.Date))
                Dim ToDate As DateTime = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(FromDat.Date))

                Dim dts = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Status = True And
                                                                  a.Emp_Bio_Device_Users.Employee.Emp_Status = True And
                                                                             a.Emp_Attendence_Device_DateTime >= thisDate And
                                                                             a.Emp_Attendence_Device_DateTime <= ToDate
                           Order By a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time Select a).ToList
                If dts.Count > 0 Then
                    For Each row0 In dts
                        Dim datet As DateTime = CDate(CStr(row0.Emp_Attendence_Device_DateTime).ToString)
                        If datet.ToString("yyyy/MM/dd HH:mm") >= thisDate.ToString("yyyy/MM/dd HH:mm") And datet.ToString("yyyy/MM/dd HH:mm") <= ToDate.ToString("yyyy/MM/dd HH:mm") Then
                            row0.Emp_ID = row0.Emp_Bio_Device_Users.Emp_ID

                            If row0.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type.ToString = "RT-Check In" Then
                                row0.Attendance_Duty_Status_ID = 1
                            Else
                                row0.Attendance_Duty_Status_ID = Nothing
                            End If
                            row0.Emp_Attendence_Device_Day = thisDate.Date
                        End If
                        db.SaveChanges()
                        kk += 1
                        'Application.DoEvents()
                    Next
                Else

                End If

            Next
            SimpleButton2.PerformClick()
        End Using
    End Sub




    Private Sub SimpleButton4_Click_1(sender As Object, e As EventArgs) Handles BtnInOut.Click
        RibbonMiniToolbar2.Show(MousePosition)
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles BtnActivity.Click
        RibbonMiniToolbar3.Show(MousePosition)
    End Sub

    Private Sub lblState_Click(sender As Object, e As EventArgs) Handles lblState.Click

    End Sub

    Private Sub RibbonControl1_ShowCustomizationMenu(sender As Object, e As Ribbon.RibbonCustomizationMenuEventArgs) Handles RibbonControl1.ShowCustomizationMenu
        '  If (e.HitInfo.InItem And e.HitInfo.InToolbar) Then
        e.ShowCustomizationMenu = False
        ' End If
    End Sub

    Private Sub BarButtonItem9_ItemClick_1(sender As Object, e As ItemClickEventArgs)
        'Using db1 As New CsmdUpdater.CsmdBioAttendence2Entities   ' CsmdBioAttendence2Entities
        '    Dim d11 As DateTime = CDate(FF1.EditValue).ToString("dd-MM-yyyy")
        '    Dim d22 As DateTime = CDate(FF2.EditValue).ToString("dd-MM-yyyy")
        '    Dim dt = (From a In db1.Emp_Attendence_Device Where a.Emp_Attendence_Device_DateTime >= d11 And a.Emp_Attendence_Device_DateTime <= d22 Select a).ToList
        '    If dt.Count > 0 Then
        '        For Each dts In dt
        '            Using db As New CsmdBioDatabase.CsmdBioAttendenceEntities
        '                Dim df = (From a In db.Emp_Attendence_Device Where a.Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID And a.Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime Select a).FirstOrDefault
        '                If df IsNot Nothing Then

        '                Else
        '                    Dim maxID As Integer = 0
        '                    Try

        '                        Try
        '                            maxID = CInt((From a In db.Emp_Attendence_Device Select a.Emp_Attendence_Device_ID).Max) + 1
        '                            '  MsgBox(maxID)
        '                        Catch ex As Exception
        '                            maxID = 1
        '                            '  MsgBox(maxID)
        '                        End Try
        '                        Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
        '                        With dtNew
        '                            .Emp_Attendence_Device_ID = maxID
        '                            .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
        '                            .Emp_ID = dts.Emp_Bio_Device_Users.Emp_ID ' db.Emp_Bio_Device_Users.Where(Function(o) o.Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?)).FirstOrDefault.Emp_ID
        '                            '.Emp_Attendence_Device_Day = dts.Emp_Attendence_Device_Day
        '                            .Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
        '                            .Emp_Attendence_Device_Date = dts.Emp_Attendence_Device_Date
        '                            .Emp_Attendence_Device_Time = dts.Emp_Attendence_Device_Time
        '                            .Emp_Attendence_Device_Status = dts.Emp_Attendence_Device_Status
        '                        End With
        '                        '  MsgBox(dtNew.Emp_ID)
        '                        db.Emp_Attendence_Device.Add(dtNew)

        '                        ' MsgBox(dtNew.Emp_Bio_Device_Users_UserID)
        '                        db.SaveChanges()

        '                    Catch ex As Exception
        '                        'MsgBox(maxID & " ex")
        '                    End Try
        '                End If
        '            End Using
        '        Next

        '        MsgBox(dt.Count & " Done")
        '    End If

        'End Using
    End Sub
    Dim sum1 As Double = 0
    Dim sum2 As Double = 0
    'Dim intr As Integer = 0
    Private Sub GridView2_CustomSummaryCalculate(sender As Object, e As CustomSummaryEventArgs) Handles GridView2.CustomSummaryCalculate
        Try
            Dim view As GridView = TryCast(sender, GridView)

            If e.IsTotalSummary AndAlso (TryCast(e.Item, GridSummaryItem)).FieldName = "Sn1" Then
                Dim item As GridSummaryItem = TryCast(e.Item, GridSummaryItem)
                If item.FieldName = "Sn1" Then
                    Select Case e.SummaryProcess
                        Case CustomSummaryProcess.Start
                            sum1 = 0
                            sum1 = 0
                        Case CustomSummaryProcess.Calculate
                            Dim strr As String = CType(view.GetRowCellValue(e.RowHandle, "Sn1"), String)
                            Dim strchk As String = CType(view.GetRowCellValue(e.RowHandle, "SSN"), String)
                            Dim strout As String = CType(view.GetRowCellValue(e.RowHandle, "SSN"), String)

                            If strchk = "RT-Check In" Or strout = "LT-Check Out" Then
                                If strr = "" Then
                                    sum1 += 1
                                End If
                            Else
                                If strr = "" Then
                                    sum2 += 1
                                End If
                            End If

                        Case CustomSummaryProcess.Finalize
                            'Dim hours As Integer = CInt(sum) \ 60
                            'Dim minutes As Integer = CInt(sum - (hours * 60))
                            BtnInOut.Text = "InOut (" & CStr(sum1) & ")"
                            BtnActivity.Text = "Activity (" & CStr(sum2) & ")"
                            'e.TotalValue = timeElapsed
                    End Select
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnConnect_CheckedChanged(sender As Object, e As EventArgs) Handles btnConnect.CheckedChanged

    End Sub

    Private Sub SimpleButton5_Click_1(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        SimpleButton1.PerformClick()

        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        'lvLogs.Items.Clear()
        axCZKEM1.EnableDevice(iMachineNumber, False) 'disable the device
        If axCZKEM1.ClearGLog(iMachineNumber) = True Then
            axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
            MsgBox("All att Logs have been cleared from teiminal!", MsgBoxStyle.Information, "Success")
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If

        axCZKEM1.EnableDevice(iMachineNumber, True) 'enable the device
    End Sub

    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Using db As New CsmdBioAttendenceEntities1
            Dim datX As Date = CDate(Dtp1.EditValue)
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Day.Value.Month = datX.Month And a.Emp_Attendence_Device_Day.Value.Year = datX.Year Select a).ToList
            If dt.Count > 0 Then
                Dim k As Integer = 1
                ProgressBarControl2.Properties.Maximum = dt.Count
                ProgressBarControl2.Properties.Minimum = 0
                ProgressBarControl2.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl2.Position = 0
                ProgressBarControl2.Update()
                Using dbX As New CsmdBioAttendenceEntities
                    For Each dts In dt
                        ProgressBarControl2.Position = k
                        ProgressBarControl2.Update()
                        k += 1

                        Dim df = (From a In dbX.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = dts.Emp_Attendence_Device_ID Select a).FirstOrDefault
                        If df IsNot Nothing Then

                        Else
                            Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
                            With dtNew
                                .Attendance_Duty_Status_ID = dts.Attendance_Duty_Status_ID
                                .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
                                .Emp_Attendence_Device_ID = dts.Emp_Attendence_Device_ID
                                .Emp_ID = dts.Emp_ID
                                .User_ID = dts.User_ID
                                .Emp_Attendence_Device_Date = dts.Emp_Attendence_Device_Date
                                .Emp_Attendence_Device_Time = dts.Emp_Attendence_Device_Time
                                .Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
                                .Emp_Attendence_Device_Day = dts.Emp_Attendence_Device_Day
                                .Emp_Attendence_Device_Duty_On_Off = dts.Emp_Attendence_Device_Duty_On_Off
                                .Emp_Attendence_Device_Status = dts.Emp_Attendence_Device_Status
                                .Emp_Attendence_Device_Cal1 = dts.Emp_Attendence_Device_Cal1
                                .Emp_Attendence_Device_Cal2 = dts.Emp_Attendence_Device_Cal2
                                .Emp_Attendence_Device_Cal3 = dts.Emp_Attendence_Device_Cal3
                                .Emp_Attendence_Device_Cal4 = dts.Emp_Attendence_Device_Cal4
                                .Emp_Attendence_Device_Cal5 = dts.Emp_Attendence_Device_Cal5
                                .Emp_Attendence_Device_Cal6 = dts.Emp_Attendence_Device_Cal6
                                .Emp_Attendence_Device_Cal7 = dts.Emp_Attendence_Device_Cal7
                            End With
                            dbX.Emp_Attendence_Device.Add(dtNew)

                        End If

                        Application.DoEvents()
                    Next
                    dbX.SaveChanges()
                End Using

                MsgBox("Attendance Log Import Successfull", vbInformation, "Importing")
            End If
        End Using
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Using db As New CsmdBioAttendenceEntities
            Dim datX As Date = CDate(Dtp1.EditValue)
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_Day.Value.Month = datX.Month And a.Emp_Attendence_Device_Day.Value.Year = datX.Year Select a).ToList
            If dt.Count > 0 Then
                Dim k As Integer = 1
                ProgressBarControl2.Properties.Maximum = dt.Count
                ProgressBarControl2.Properties.Minimum = 0
                ProgressBarControl2.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl2.Position = 0
                ProgressBarControl2.Update()
                Using dbX As New CsmdBioAttendenceEntities1
                    For Each dts In dt
                        ProgressBarControl2.Position = k
                        ProgressBarControl2.Update()
                        k += 1

                        Dim df = (From a In dbX.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = dts.Emp_Attendence_Device_ID Select a).FirstOrDefault
                        If df IsNot Nothing Then

                        Else
                            Dim dtNew = New CsmdBioDatabase.Emp_Attendence_Device
                            With dtNew
                                .Attendance_Duty_Status_ID = dts.Attendance_Duty_Status_ID
                                .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
                                .Emp_Attendence_Device_ID = dts.Emp_Attendence_Device_ID
                                .Emp_ID = dts.Emp_ID
                                .User_ID = dts.User_ID
                                .Emp_Attendence_Device_Date = dts.Emp_Attendence_Device_Date
                                .Emp_Attendence_Device_Time = dts.Emp_Attendence_Device_Time
                                .Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
                                .Emp_Attendence_Device_Day = dts.Emp_Attendence_Device_Day
                                .Emp_Attendence_Device_Duty_On_Off = dts.Emp_Attendence_Device_Duty_On_Off
                                .Emp_Attendence_Device_Status = dts.Emp_Attendence_Device_Status
                                .Emp_Attendence_Device_Cal1 = dts.Emp_Attendence_Device_Cal1
                                .Emp_Attendence_Device_Cal2 = dts.Emp_Attendence_Device_Cal2
                                .Emp_Attendence_Device_Cal3 = dts.Emp_Attendence_Device_Cal3
                                .Emp_Attendence_Device_Cal4 = dts.Emp_Attendence_Device_Cal4
                                .Emp_Attendence_Device_Cal5 = dts.Emp_Attendence_Device_Cal5
                                .Emp_Attendence_Device_Cal6 = dts.Emp_Attendence_Device_Cal6
                                .Emp_Attendence_Device_Cal7 = dts.Emp_Attendence_Device_Cal7
                            End With
                            dbX.Emp_Attendence_Device.Add(dtNew)

                        End If

                        Application.DoEvents()
                    Next
                    dbX.SaveChanges()
                End Using

                MsgBox("Attendance Log Export Successfull", vbInformation, "Exporting")
            End If
        End Using
    End Sub
End Class

Public Class MyXtraMessageBoxForm
    Inherits XtraMessageBoxForm
    Public Sub New()

    End Sub

    Protected Overrides Function DoShowDialog(owner As IWin32Window) As DialogResult
        Me.StartPosition = FormStartPosition.Manual
        Return MyBase.DoShowDialog(owner)
    End Function
End Class


'dd/ mm / yyyy hh:nn : ss" tt"