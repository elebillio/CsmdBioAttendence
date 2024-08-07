﻿Imports DevExpress.XtraBars
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars.Docking2010.Views
Imports DevExpress.XtraEditors
Imports CsmdBioDatabase
Imports Csmd_RM_Live
Imports CsmdBioDashBoard
Imports CsmdBioReports
Imports DevExpress.XtraNavBar
Imports CsmdUpdater
Imports System.Data.SqlClient

Public Class frmMain

#Region "Get Reports"
    Dim gp() As NavBarGroup
    Dim itg() As NavBarItem
    Dim mm As Integer
    Dim i As Integer
    Public Sub LoadReportFromFile(Path As String)
        Dim di As New IO.DirectoryInfo(My.Application.Info.DirectoryPath + Path)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        For Each dra In diar1
            If dra.Extension = ".repx" Then
                ReDim itg(mm)
                itg(mm) = NavReports.Items.Add
                itg(mm).Caption = System.IO.Path.GetFileNameWithoutExtension(dra.Name)
                gp(i).ItemLinks.Add(itg(mm))
                mm = mm + 1
            End If
        Next
    End Sub

    Public Sub Folder()
        Dim objFSO As Object
        Dim objFolder As Object
        Dim objFile As Object
        NavReports.Groups.Clear()
        NavReports.Items.Clear()
        objFSO = CreateObject("Scripting.FileSystemObject")
        objFolder = objFSO.GetFolder(".\")
        For Each objFile In objFolder.subfolders
            If objFile.name.ToString = "Reports" Then
                ReDim gp(i)
                gp(i) = NavReports.Groups.Add
                gp(i).Caption = objFile.name
                gp(i).Expanded = True
                LoadReportFromFile(".\" & objFile.Name & "")
                i = i + 1
                Exit For
            End If
        Next objFile
    End Sub

#End Region

#Region "Theme & Color Functions"
    Private Sub BarButtonItem8_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim form As New DevExpress.XtraEditors.ColorWheel.ColorWheelForm
        DefaultLookAndFeel1.LookAndFeel.SkinMaskColor.ToKnownColor()
        form.StartPosition = FormStartPosition.CenterParent
        form.SkinMaskColor = DefaultLookAndFeel1.LookAndFeel.SkinMaskColor
        form.SkinMaskColor2 = DefaultLookAndFeel1.LookAndFeel.SkinMaskColor2
        form.ShowDialog(Me)
    End Sub
    Private Sub RepositoryItemColorPickEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemColorPickEdit1.EditValueChanged
        Dim col As String = TryCast(sender, ColorPickEdit).EditValue.ToString
        DefaultLookAndFeel1.LookAndFeel.SkinMaskColor = CsmdColorArgb(col)
    End Sub

    Public Function CsmdColorArgb(ColorName As String) As Color
        Dim col As String = Replace(Replace(ColorName, "Color [", ""), "]", "")
        If Microsoft.VisualBasic.Left(col, 2) = "A=" Then
            Dim inm(2) As Integer
            inm(0) = Replace(col.Split(",")(0), "A=", "")
            inm(1) = Replace(col.Split(",")(1), "R=", "")
            inm(2) = Replace(col.Split(",")(2), "G=", "")
            Return Color.FromArgb(inm(0), inm(1), inm(2))
        Else
            Return Color.FromName(col)
        End If
    End Function
#End Region

#Region "Main Form Functions"

    Private Sub RibbonControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles RibbonControl1.KeyDown

    End Sub
    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.H Then
            frmEmpA.Show()
        End If


    End Sub
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting(Application.ProductName, "CsmdUserLookAndFeel", "CsmdActiveSkinName", UserLookAndFeel.Default.ActiveSkinName)
        SaveSetting(Application.ProductName, "CsmdUserLookAndFeel0", "CsmdSkinMaskColor", UserLookAndFeel.Default.SkinMaskColor.Name)
        frmLogin.Show()
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RibbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always
        Folder()
        Try
            UserLookAndFeel.Default.SetSkinStyle(GetSetting(Application.ProductName, "CsmdUserLookAndFeel", "CsmdActiveSkinName", ""))
            UserLookAndFeel.Default.SkinMaskColor = CsmdColorArgb(GetSetting(Application.ProductName, "CsmdUserLookAndFeel0", "CsmdSkinMaskColor", "").ToString)
        Catch ex As Exception
            UserLookAndFeel.Default.SetSkinStyle("Sharp")
            SaveSetting(Application.ProductName, "CsmdUserLookAndFeel", "CsmdActiveSkinName", UserLookAndFeel.Default.ActiveSkinName)
            SaveSetting(Application.ProductName, "CsmdUserLookAndFeel0", "CsmdSkinMaskColor", UserLookAndFeel.Default.SkinMaskColor.Name)
        End Try

    End Sub
#End Region

#Region "Tab Function"

    Private Function CheckActivateControl1(ByVal type As String) As Boolean
        For Each item As BaseDocument In TabX1.Documents
            If item.ControlName Is type Then
                TabX1.Controller.Activate(item)
                Return True
            End If
        Next item
        Return False
    End Function

    Public Sub ShowCreateDocumentControl1(ByVal type As String)
        Try
            If (Not CheckActivateControl1(type)) Then
                Dim document As BaseDocument = TabX1.AddDocument(type, type)
                TabX1.Controller.Activate(document)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Public Sub ShowCreateDocumentControl2(ByVal capt As String, ByVal type As String)
        ' If (CheckActivateControl1(type)) Then
        Dim document As BaseDocument = TabX1.AddDocument(capt, type)
        TabX1.Controller.Activate(document)
        ' End If
    End Sub
    Private Sub SetPage()
        If RibbonControl1.MergedCategories.Count > 0 Then
            RibbonControl1.SelectedPage = RibbonControl1.MergedCategories(0).Pages(0)
        End If
    End Sub
#End Region

#Region "Tab Active Function"
    Private Sub TabX1_DocumentActivated(sender As Object, e As DocumentEventArgs) Handles TabX1.DocumentActivated
        BeginInvoke(New MethodInvoker(AddressOf SetPage))
    End Sub

    Private Sub TabX1_QueryControl(sender As Object, e As QueryControlEventArgs) Handles TabX1.QueryControl
        'Try

        If e.Document.ControlName = CsmdFrm.frmDashBoardPreview And CsmdFrm.frmDashBoardPreview = CsmdFrm.frmDashBoardPreviewX Then
            Dim Form As New frmDashBoardPreview
            Form.Text = e.Document.ControlName
            e.Control = Form
        End If

        If e.Document.ControlName = CsmdFrm.frmEmployeesAdd And CsmdFrm.frmEmployeesAdd = CsmdFrm.frmEmployeesAddX Then
            Dim Form As New frmEmployeesAdds
            Form.Text = e.Document.ControlName
            e.Control = Form
        End If

        If e.Document.ControlName = CsmdFrm.frmEmployeesRegister And CsmdFrm.frmEmployeesRegister = CsmdFrm.frmEmployeesRegisterX Then
            Dim Form As New frmEmployeesRegisters
            Form.Text = e.Document.ControlName
            e.Control = Form
        End If

        If e.Document.ControlName = CsmdFrm.frmAttendanceLive And CsmdFrm.frmAttendanceLive = CsmdFrm.frmAttendanceLiveX Then
            Dim Form As New Csmd_RM_Live.frmAttendanceLives
            Form.Text = e.Document.ControlName
            e.Control = Form
        End If

        If e.Document.ControlName = CsmdFrm.frmEmployeesAttCalculation And CsmdFrm.frmEmployeesAttCalculation = CsmdFrm.frmEmployeesAttCalculationX Then
            Dim Form As New frmEmployeesCalculations
            Form.Text = e.Document.ControlName
            e.Control = Form
        End If
        If e.Document.ControlName = CsmdFrm.frmPaymentsShow And CsmdFrm.frmPaymentsShow = CsmdFrm.frmPaymentsShowX Then
            Dim Form As New frmPayments
            Form.Text = e.Document.ControlName
            e.Control = Form
        End If
        If e.Document.ControlName = CsmdFrm.frmDeviceRegisters And CsmdFrm.frmDeviceRegisters = CsmdFrm.frmDeviceRegistersX Then
            Dim Form As New frmDeviceRegister
            Form.Text = e.Document.ControlName
            e.Control = Form
        End If
        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        'Catch ex As Exception
        '    XtraMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
#End Region

#Region "DashBoard"
    Private Sub BarButtonItem9_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Try
            CsmdFrm.frmDashBoardPreviewX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp5", "")

            ShowCreateDocumentControl1(CsmdFrm.frmDashBoardPreview)
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try
    End Sub
    Private Sub BarButtonItem10_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Try
            CsmdFrm.frmDashBoardX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp6", "")
            If CsmdFrm.frmDashBoard = CsmdFrm.frmDashBoardX Then
                Dim Form As New frmDashBoard
                Form.Text = CsmdFrm.frmDashBoard
                Form.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try


    End Sub
#End Region

#Region "Reports Button"
    Private Sub BarButtonItem11_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        If DockPanel1.Visibility = Docking.DockVisibility.Hidden Then
            DockPanel1.Visibility = Docking.DockVisibility.Visible
            Folder()
        Else
            DockPanel1.Visibility = Docking.DockVisibility.Hidden
        End If
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Try
            CsmdFrm.frmPrintDesignerX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp8", "")
            If CsmdFrm.frmPrintDesigner = CsmdFrm.frmPrintDesignerX Then
                'Dim Form As New frmPrintDesigner
                'Form.Text = CsmdFrm.frmPrintDesigner
                'Form.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try

    End Sub
    Private Sub NavReports_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles NavReports.LinkClicked
        OpenReportByid(e.Link.Item.Caption)
    End Sub
#End Region

#Region "Employees"
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        frmLoadAction = frmNewAction
        Try
            CsmdFrm.frmEmployeesAddX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp0", "")

            ShowCreateDocumentControl1(CsmdFrm.frmEmployeesAdd)
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            CsmdFrm.frmEmployeesRegisterX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp1", "")

            ShowCreateDocumentControl1(CsmdFrm.frmEmployeesRegister)
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try

    End Sub
    Private Sub BarButtonItem13_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Try
            CsmdFrm.frmDeviceRegistersX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp11", "")

            ShowCreateDocumentControl1(CsmdFrm.frmDeviceRegisters)
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try
    End Sub
#End Region

#Region "Attendance Live, Calculate and Cash"
    Private Sub BarButtonItem3_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Class1.MasterLive = "OpenAdmin"
        Try
            CsmdFrm.frmAttendanceLiveX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp2", "")
            ShowCreateDocumentControl1(CsmdFrm.frmAttendanceLive)
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try

    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Try
            CsmdFrm.frmEmployeesAttCalculationX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp3", "")
            ShowCreateDocumentControl1(CsmdFrm.frmEmployeesAttCalculation)
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try


    End Sub
    Private Sub BarButtonItem7_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        Try
            CsmdFrm.frmPaymentsShowX = GetSetting(Application.ProductName, "CsmdUserLookAndFeelIp", "CsmdActiveSkinNameIp10", "")
            ShowCreateDocumentControl1(CsmdFrm.frmPaymentsShow)
        Catch ex As Exception
            MsgBox("Permission Deniend")
            Exit Sub
        End Try
    End Sub
    Private Sub BarButtonItem6_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        frmEmpCashRegisterLock.ShowDialog()
    End Sub

#End Region

#Region "Backup & Restore"
    Private Sub BarButtonItem5_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        frmBackupRestore.ShowDialog()
    End Sub

    Private Sub BarButtonItem14_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem14.ItemClick
        'Dim frm As New frmUpdater
        'frm.Show()
        '  CsmdVarible.updatePath = Application.StartupPath
        UpdaterSW = True
        Process.Start(Application.StartupPath & "\CsmdUpdater.exe")
        Me.Close()

    End Sub

    Private Sub BarButtonItem15_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem15.ItemClick
        '        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
        '    Dim dt = (From a In db.Employees Select a.Emp_Name, a.Emp_Father, a.Emp_Salary, a.Emp_DutyOn, a.Emp_Duty_Off).ToList
        '    If dt.Count > 0 Then
        '        For Each dts In dt
        '            Dim EmployeesName As String = dts.Emp_Name
        '            Dim EmployeesFather As String = dts.Emp_Father
        '            Dim EmployeesSalary As Decimal = dts.Emp_Salary
        '            Dim EmployeesDutyON As String = CType(dts.Emp_DutyOn, String)
        '            Dim EmployeesDutyOFF As String = CType(dts.Emp_Duty_Off, String)

        '            Select Case EmployeesDutyON
        '                Case "08:00"
        '                    Dim LateArrival As String = "A"
        '                    Dim EarlyDeparture As String = "B"
        '                    If LateArrival = "08:00" Then
        '                        MsgBox("Successfull")
        '                    Else
        '                        If EarlyDeparture = "20:00" Then
        '                            MsgBox("Successfull")
        '                        Else
        '                            MsgBox("Early Departure", vbCritical, "Duty time Error")
        '                        End If
        '                    End If
        '                Case "09:00"

        '                Case "10:00"

        '                Case "11:00"


        '            End Select

        '        Next
        '    End If
        'End Using
    End Sub


#Region "Backup and Restore"
    Private Sub BarButtonItem16_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem16.ItemClick
        'Try
        'Dim sd As New SaveFileDialog()
        'sd.Filter = "SQL Server database backup files"
        'sd.Title = "Create Database Backup"
        'sd.FileName = "CsmdBioAttendence_Backup_" & Now.ToString("d-M-yyyy_hh-mm tt" & ".bak")
        Dim SDD As String = Application.StartupPath & "\DATA\CsmdBioAttendence_Backup_" & Now.ToString("d-M-yyyy_hh-mm tt" & ".bak")
        'CsmdTheLeadsSchool_Backup_" & sd.FileName & Now.ToString("d-mm-yyyy") & "
        'If sd.ShowDialog() = DialogResult.OK Then
        'MsgBox(sd.FileName)
        Using conn As New SqlConnection("Data Source=CASHIER-PC\SQLEXPRESS,786;Initial Catalog=CsmdBioAttendence;user id=sa; password=123;")
            Dim sqlStmt As String = String.Format("backup database [CsmdBioAttendence] to disk='{0}'", SDD)
            'Dim sqlStmt As String = String.Format("backup database [" & cmbdatabase.Text.Trim & "] to disk='{0}'", System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak")
            Using bu2 As New SqlCommand(sqlStmt, conn)
                conn.Open()
                bu2.ExecuteNonQuery()
                conn.Close()
                'ProgressBarControl1.Position = 3
                'ProgressBarControl1.Update()
                MessageBox.Show("Backup Created Sucessfully")
            End Using
        End Using
        'End If
        'Catch generatedExceptionName As Exception
        '    MessageBox.Show(generatedExceptionName.Message)
        'End Try
        ' Dim Asd As New OpenFileDialog()
        'sd.Filter = "SQL Server database backup files|*.bak"
        '  Asd.Title = "Create Database Backup"
        '  If Asd.ShowDialog() = DialogResult.OK Then
        'Using conn As New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";AttachDbFilename=|DataDirectory|DATA\CsmdTheLeadsSchool.mdf;integrated security=True;")
        Using conn As New SqlConnection("Data Source=DESKTOP-DLTNMHS\SQLEXPRESS;Initial Catalog=master; integrated security=true;")
            'Dim sqlStmt As String = String.Format("backup database [" + System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool.mdf] to disk='{0}'", sd.FileName)
            'System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak
            'query("DROP DATABASE " & ComboBoxdb.Text)
            Dim ff = "alter database [CsmdBioAttendence]  set offline with rollback immediate"
            Dim sqlStmt As String = String.Format("RESTORE database [CsmdBioAttendence] from disk='" + SDD + "'WITH REPLACE, RECOVERY")
            Dim ggg = "alter database [CsmdBioAttendence] set online"
            Using bu1 As New SqlCommand(ff, conn)
                conn.Open()
                bu1.ExecuteNonQuery()
                conn.Close()
                'ProgressBarControl1.Position = 1
                'ProgressBarControl1.Update()
                'MessageBox.Show("Offline Created Sucessfully")
            End Using
            Try
                Using bu2 As New SqlCommand(sqlStmt, conn)
                    conn.Open()
                    bu2.ExecuteNonQuery()
                    conn.Close()
                    'ProgressBarControl1.Position = 2
                    'ProgressBarControl1.Update()
                    'MessageBox.Show("Restore Created Sucessfully")
                End Using
            Catch ex As Exception
                MsgBox("Please Paste a Backup File in Drive:D", vbCritical, "File Path Error")
                Exit Sub
            End Try
            Using bu3 As New SqlCommand(ggg, conn)
                conn.Open()
                bu3.ExecuteNonQuery()
                conn.Close()
                'ProgressBarControl1.Position = 3
                'ProgressBarControl1.Update()
                MessageBox.Show("Database Restore Sucessfully")
            End Using
        End Using
        ' End If
    End Sub
    Private Sub BarButtonItem17_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem17.ItemClick
        Dim SDD As String = Application.StartupPath & "\DATA\CsmdBioAttendence_Backup_" & Now.ToString("d-M-yyyy_hh-mm tt" & ".bak")
        'CsmdTheLeadsSchool_Backup_" & sd.FileName & Now.ToString("d-mm-yyyy") & "
        'If sd.ShowDialog() = DialogResult.OK Then
        'MsgBox(sd.FileName)
        Using conn As New SqlConnection("Data Source=DESKTOP-DLTNMHS\SQLEXPRESS;Initial Catalog=CsmdBioAttendence; integrated security=true;")
            Dim sqlStmt As String = String.Format("backup database [CsmdBioAttendence] to disk='{0}'", SDD)
            'Dim sqlStmt As String = String.Format("backup database [" & cmbdatabase.Text.Trim & "] to disk='{0}'", System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak")
            Using bu2 As New SqlCommand(sqlStmt, conn)
                conn.Open()
                bu2.ExecuteNonQuery()
                conn.Close()
                'ProgressBarControl1.Position = 3
                'ProgressBarControl1.Update()
                MessageBox.Show("Backup Created Sucessfully")
            End Using
        End Using


        'Try
        '  Dim sd As New OpenFileDialog()
        'sd.Filter = "SQL Server database backup files|*.bak"
        '  sd.Title = "Create Database Backup"
        '  If sd.ShowDialog() = DialogResult.OK Then
        'Using conn As New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";AttachDbFilename=|DataDirectory|DATA\CsmdTheLeadsSchool.mdf;integrated security=True;")
        Using conn As New SqlConnection("Data Source=CASHIER-PC\SQLEXPRESS,786;Initial Catalog=master; user id=sa; password=123;")
                'Dim sqlStmt As String = String.Format("backup database [" + System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool.mdf] to disk='{0}'", sd.FileName)
                'System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak
                'query("DROP DATABASE " & ComboBoxdb.Text)
                Dim ff = "alter database [CsmdBioAttendence]  set offline with rollback immediate"
            Dim sqlStmt As String = String.Format("RESTORE database [CsmdBioAttendence] from disk='" + SDD + "'WITH REPLACE, RECOVERY")
            Dim ggg = "alter database [CsmdBioAttendence] set online"
                Using bu1 As New SqlCommand(ff, conn)
                    conn.Open()
                    bu1.ExecuteNonQuery()
                    conn.Close()
                    'ProgressBarControl1.Position = 1
                    'ProgressBarControl1.Update()
                    'MessageBox.Show("Offline Created Sucessfully")
                End Using
                Try
                    Using bu2 As New SqlCommand(sqlStmt, conn)
                        conn.Open()
                        bu2.ExecuteNonQuery()
                        conn.Close()
                        'ProgressBarControl1.Position = 2
                        'ProgressBarControl1.Update()
                        'MessageBox.Show("Restore Created Sucessfully")
                    End Using
                Catch ex As Exception
                    MsgBox("Please Paste a Backup File in Drive:D", vbCritical, "File Path Error")
                    Exit Sub
                End Try
                Using bu3 As New SqlCommand(ggg, conn)
                    conn.Open()
                    bu3.ExecuteNonQuery()
                    conn.Close()
                    'ProgressBarControl1.Position = 3
                    'ProgressBarControl1.Update()
                    MessageBox.Show("Database Restore Sucessfully")
                End Using
            End Using
        '  End If
        'Catch generatedExceptionName As Exception
        '    MessageBox.Show(generatedExceptionName.Message)
        'End Try
    End Sub

    Private Sub BarButtonItem18_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem18.ItemClick
        Dim SDD As String = Application.StartupPath & "\DATA\CsmdBioAttendence_Backup_" & Now.ToString("d-M-yyyy_hh-mm tt" & ".bak")
        'CsmdTheLeadsSchool_Backup_" & sd.FileName & Now.ToString("d-mm-yyyy") & "
        'If sd.ShowDialog() = DialogResult.OK Then
        'MsgBox(sd.FileName)
        Using conn As New SqlConnection("Data Source=CASHIER-PC\SQLEXPRESS,786;Initial Catalog=CsmdBioAttendence;user id=sa; password=123;")
            Dim sqlStmt As String = "backup database [CsmdBioAttendence] to disk='" + SDD + "' with FORMAT"
            'Dim sqlStmt As String = String.Format("backup database [" & cmbdatabase.Text.Trim & "] to disk='{0}'", System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak")
            Using bu2 As New SqlCommand(sqlStmt, conn)
                conn.Open()
                bu2.ExecuteNonQuery()
                conn.Close()
                'ProgressBarControl1.Position = 3
                'ProgressBarControl1.Update()
                MessageBox.Show("Backup Created Sucessfully")
            End Using
        End Using
    End Sub

    Private Sub BarButtonItem19_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BarButtonItem19.ItemClick
        Using conn As New SqlConnection("Data Source=FAAZAL-PLAZA\SQLEXPRESS;Initial Catalog=master; integrated security=true;")
            'Dim sqlStmt As String = String.Format("backup database [" + System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool.mdf] to disk='{0}'", sd.FileName)
            'System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak
            'query("DROP DATABASE " & ComboBoxdb.Text)
            Dim SDD As String = Application.StartupPath & "\DATA\CsmdBioAttendence_Backup_" & Now.ToString("d-M-yyyy_hh-mm tt" & ".bak")
            Dim ff = "alter database [CsmdBioAttendence]  set offline with rollback immediate"
            Dim sqlStmt As String = String.Format("RESTORE database [CsmdBioAttendence] from disk='" + SDD + "' WITH REPLACE, RECOVERY")
            Dim ggg = "alter database [CsmdBioAttendence] set online"
            Using bu1 As New SqlCommand(ff, conn)
                conn.Open()
                bu1.ExecuteNonQuery()
                conn.Close()
                'ProgressBarControl1.Position = 1
                'ProgressBarControl1.Update()
                'MessageBox.Show("Offline Created Sucessfully")
            End Using
            Try
                Using bu2 As New SqlCommand(sqlStmt, conn)
                    conn.Open()
                    bu2.ExecuteNonQuery()
                    conn.Close()
                    'ProgressBarControl1.Position = 2
                    'ProgressBarControl1.Update()
                    'MessageBox.Show("Restore Created Sucessfully")
                End Using
            Catch ex As Exception
                MsgBox("Please Paste a Backup File in Drive:D", vbCritical, "File Path Error")
                Exit Sub
            End Try
            Using bu3 As New SqlCommand(ggg, conn)
                conn.Open()
                bu3.ExecuteNonQuery()
                conn.Close()
                'ProgressBarControl1.Position = 3
                'ProgressBarControl1.Update()
                MessageBox.Show("Database Restore Sucessfully")
            End Using
        End Using
    End Sub

#End Region

#End Region

End Class