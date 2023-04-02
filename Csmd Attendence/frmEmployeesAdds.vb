

Option Explicit On
Option Strict On
Imports System.Runtime.InteropServices
Imports DevExpress.XtraEditors
Imports System.Drawing.Imaging
Imports DevExpress.XtraBars.Navigation
Imports System.Data.SqlClient
'Imports CsmdPlazaDatabase
Imports CsmdBioDatabase
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Grid
Imports CsmdOnline

Public Class frmEmployeesAdds

    Dim db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
    Dim Load_cmb_Employee_Search_Look As New cmb_Employee_Search_Look
    Dim Load_cmb_Emp_Report_To As New cmb_Emp_Report_To
    Dim ghj As Integer
    <DllImport("kernel32")>
    Public Shared Function Beep(ByVal dwFreg As Integer, ByVal dwDuration As Integer) As Integer
    End Function

#Region "EMPLOYEES MODIFIED VIEWER UserControl1_LOAD"
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CStr(GetSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", "")) = "" Then
            SaveSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", "192.168.1.201")
            txtIP.EditValue = "192.168.1.201"
        Else
            txtIP.EditValue = GetSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", "")

        End If
        Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
        Load_cmb_Emp_Report_To.ColumnsAndData(Emp_Report_To)
        LoadTile()

        If frmLoadAction = frmNewAction Then
            'LoadTeachersRecords(0)
            For Each textEdit As Control In Me.LayoutControl1.Controls
                If TypeOf textEdit Is TextEdit Then
                    TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                End If
            Next textEdit
            For Each textEdit As Control In Me.LayoutControl5.Controls
                If TypeOf textEdit Is TextEdit Then
                    TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                End If
            Next textEdit
            SearchLookUpEdit1.Properties.ReadOnly = False
            BarButtonItem1.Enabled = True
            BarButtonItem2.Enabled = False
            BarButtonItem3.Enabled = False
            BarButtonItem4.Enabled = False
        Else
            LoadTeachersRecords(intMultiFee)
            SearchLookUpEdit1.EditValue = intMultiFee
            BarButtonItem2.PerformClick()
        End If


    End Sub
#End Region
#Region "EMPLOYEES ADD NEW RECORD"

    Public Sub NewStudentData()
        For Each textEdit As Control In Me.LayoutControl1.Controls
            If TypeOf textEdit Is TextEdit Then
                TryCast(textEdit, TextEdit).ResetText()
                TryCast(textEdit, TextEdit).Properties.ReadOnly = False
            End If
        Next textEdit
        For Each textEdit As Control In Me.LayoutControl5.Controls
            If TypeOf textEdit Is TextEdit Then
                TryCast(textEdit, TextEdit).ResetText()
                TryCast(textEdit, TextEdit).Properties.ReadOnly = False
            End If
        Next textEdit
        BarButtonItem1.Enabled = False
        BarButtonItem2.Enabled = False
        BarButtonItem3.Enabled = True
        BarButtonItem4.Enabled = False
        btnConnect.Enabled = False
        'SimpleButton1.Enabled = False
        'GridView1.OptionsBehavior.Editable = False
        SearchLookUpEdit1.Properties.ReadOnly = True
        Emp_Reg.Properties.ReadOnly = True
        Emp_Reg.Text = AutoRegisterNumber()
        Emp_Date_Join.EditValue = Today
        Emp_Image.Image = Image.FromFile(Application.StartupPath & "\Images\Empty.jpg")
        GridControl1.DataSource = Nothing
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim hh = (From a In db.Employees Where a.Emp_Reg = Emp_Reg.Text Select a).FirstOrDefault
            If hh IsNot Nothing Then
                LoadTeachersRecords(hh.Emp_ID)
            End If
        End Using
    End Sub
#End Region
#Region "EMPLOYEES RECORDS SAVE AND UPDATE FUNCTION"
    Public Sub SaveAndUpdateData()
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            If Emp_Name.EditValue Is Nothing Then
                MsgBox("Please Enter a Name of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Name, "Please Enter a Name of this Employee")
                Exit Sub
            ElseIf Emp_Father.EditValue Is Nothing Then
                MsgBox("Please Enter a Father's name of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Father, "Please Enter a Father's name of this Employee")
                Exit Sub
            ElseIf Emp_Birth_Date.EditValue Is Nothing Then
                MsgBox("Please Enter a BirthDate of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Birth_Date, "Please Enter a BirthDate of this Employee")
                Exit Sub
            ElseIf Emp_Address_ID.EditValue Is Nothing Then
                MsgBox("Please Enter a Address of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Address_ID, "Please Enter a Address of this Employee")
                Exit Sub
            ElseIf Emp_DutyOn.EditValue Is Nothing Then
                MsgBox("Please Enter a Duty On time of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_DutyOn, "Please Enter a Duty On time of this Employee")
                Exit Sub
            ElseIf Emp_Duty_Off.EditValue Is Nothing Then
                MsgBox("Please Enter a Duty Off time of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Duty_Off, "Please Enter a Duty Off time of this Employee")
                Exit Sub
            ElseIf Emp_Salary.Text = "" Then
                MsgBox("Please Enter a Salary Amount of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Salary, "Please Enter a Salary Amount of this Employee")
                Exit Sub
            Else

                Dim Tea = (From a In db.Employees Where a.Emp_Reg = Emp_Reg.Text Select a).FirstOrDefault
                If Not IsNothing(Tea) Then
                    With Tea
                        .Emp_Name = Emp_Name.Text
                        .Emp_Father = Emp_Father.Text
                        .Emp_Phone = Emp_Phone.Text
                        .Emp_Phone2 = Emp_Phone2.Text
                        .Emp_Address = CType(Emp_Address_ID.EditValue, String)
                        .Emp_Quali = Emp_Quali.Text
                        .Emp_Designation = CType(Emp_Designation_ID.EditValue, String)
                        .Emp_Date_Hired = CType(Emp_Date_Join.EditValue, Date?)
                        Try
                            .Emp_Date_Terminated = CType(Emp_Date_Leave.EditValue, Date?)
                            .Emp_Date_ReHired = CType(Emp_Date_ReHired.EditValue, Date?)
                        Catch ex As Exception

                        End Try
                        '.Emp_Image = ImgToByteArray(Emp_Image.Image, ImageFormat.Png)
                        'Try
                        '    .Emp_Signature = ImgToByteArray(Emp_Signature.Image, ImageFormat.Png)
                        'Catch ex As Exception

                        'End Try
                        .Emp_NIC_No = CType(Emp_NIC_No.EditValue, String)
                        .Emp_Report_To = CType(Emp_Report_To.EditValue, Integer?)
                        .Emp_Birth_Date = CType(Emp_Birth_Date.EditValue, Date?)
                        .Emp_Status = Emp_Status.Checked

                        .Emp_DutyOn = CStr(CDate(Emp_DutyOn.EditValue).ToString("HH:mm"))
                        .Emp_Duty_Off = CDate(Emp_Duty_Off.EditValue).ToString("HH:mm")
                        .Emp_Salary = CType(Emp_Salary.Text, Double?)
                        Dim kkk As String = .Emp_DutyOn
                        .User_ID = CsmdVarible.PlazaUserID
                        db.SaveChanges()
                    End With
                    XtraMessageBox.Show("Update Employee Successfull")
                    LoadTile()
                    BarButtonItem1.Enabled = True
                    BarButtonItem2.Enabled = True
                    BarButtonItem3.Enabled = False
                    BarButtonItem4.Enabled = True
                    btnConnect.Enabled = False
                    'SimpleButton1.Enabled = False
                    'GridView1.OptionsBehavior.Editable = False
                    For Each textEdit As Control In Me.LayoutControl1.Controls
                        If TypeOf textEdit Is TextEdit Then
                            TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                        End If
                    Next textEdit
                    For Each textEdit As Control In Me.LayoutControl5.Controls
                        If TypeOf textEdit Is TextEdit Then
                            TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                        End If
                    Next textEdit
                    SearchLookUpEdit1.Properties.ReadOnly = False
                Else
                    Dim TeaNew = New CsmdBioDatabase.Employee
                    With TeaNew
                        Dim maxID As Integer
                        Try
                            maxID = (From a In db.Employees Select a.Emp_ID).Max + 1
                        Catch ex As Exception
                            maxID = 1
                        End Try
                        .Emp_ID = maxID
                        .Emp_Reg = Emp_Reg.Text
                        .Emp_Name = Emp_Name.Text
                        .Emp_Father = Emp_Father.Text
                        .Emp_Phone = Emp_Phone.Text
                        .Emp_Phone2 = Emp_Phone2.Text
                        .Emp_Address = CType(Emp_Address_ID.EditValue, String)
                        .Emp_Quali = Emp_Quali.Text
                        .Emp_Designation = CType(Emp_Designation_ID.EditValue, String)
                        .Emp_Date_Hired = CType(Emp_Date_Join.EditValue, Date?)
                        Try
                            .Emp_Date_Terminated = CType(Emp_Date_Leave.EditValue, Date?)
                            .Emp_Date_ReHired = CType(Emp_Date_ReHired.EditValue, Date?)
                        Catch ex As Exception

                        End Try
                        '.Emp_Image = ImgToByteArray(Emp_Image.Image, ImageFormat.Png)
                        'Try
                        '    .Emp_Signature = ImgToByteArray(Emp_Signature.Image, ImageFormat.Png)
                        'Catch ex As Exception

                        'End Try
                        .Emp_NIC_No = CType(Emp_NIC_No.EditValue, String)
                        .Emp_Report_To = CType(Emp_Report_To.EditValue, Integer?)
                        .Emp_Birth_Date = CType(Emp_Birth_Date.EditValue, Date?)
                        .Emp_Status = Emp_Status.Checked
                        .Emp_DutyOn = CStr(CDate(Emp_DutyOn.EditValue).ToString("HH:mm"))
                        .Emp_Duty_Off = CStr(CDate(Emp_Duty_Off.EditValue).ToString("HH:mm"))
                        .Emp_Salary = CType(Emp_Salary.Text, Double?)
                        .User_ID = CsmdVarible.PlazaUserID
                    End With
                    db.Employees.Add(TeaNew)
                    Dim AddNum = (From a In db.Auto_Number Select a).FirstOrDefault
                    If AddNum IsNot Nothing Then
                        AddNum.Auto_Emp_Num = CType(Replace(Replace(AutoRegisterNumber(), "R-", ""), Microsoft.VisualBasic.Right(Replace(AutoRegisterNumber(), "R-", ""), 3), ""), Integer?)
                    End If
                    db.SaveChanges()
                    XtraMessageBox.Show("Add new Employee Successfull")
                    Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
                    Load_cmb_Emp_Report_To.ColumnsAndData(Emp_Report_To)
                    LoadTile()
                    BarButtonItem1.Enabled = True
                    BarButtonItem2.Enabled = True
                    BarButtonItem3.Enabled = False
                    BarButtonItem4.Enabled = True
                    btnConnect.Enabled = False
                    'SimpleButton1.Enabled = False
                    'GridView1.OptionsBehavior.Editable = False
                    For Each textEdit As Control In Me.LayoutControl1.Controls
                        If TypeOf textEdit Is TextEdit Then
                            TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                        End If
                    Next textEdit
                    For Each textEdit As Control In Me.LayoutControl5.Controls
                        If TypeOf textEdit Is TextEdit Then
                            TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                        End If
                    Next textEdit
                    SearchLookUpEdit1.Properties.ReadOnly = False
                End If
            End If
        End Using
    End Sub
#End Region
#Region "EMPLOYEES RECORDS LOAD"
    Public Sub LoadTeachersRecords(RecordRow As Integer)
        'Try
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            BarButtonItem1.Enabled = True
            BarButtonItem2.Enabled = True
            BarButtonItem3.Enabled = False
            BarButtonItem4.Enabled = True
            btnConnect.Enabled = False
            'SimpleButton1.Enabled = False
            'GridView1.OptionsBehavior.Editable = False

            For Each textEdit As Control In Me.LayoutControl1.Controls
                If TypeOf textEdit Is TextEdit Then
                    TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                End If
            Next textEdit
            For Each textEdit As Control In Me.LayoutControl5.Controls
                If TypeOf textEdit Is TextEdit Then
                    TryCast(textEdit, TextEdit).Properties.ReadOnly = True
                End If
            Next textEdit
            SearchLookUpEdit1.Properties.ReadOnly = False
            Dim LoadStudents = (From a In db.Employees Where a.Emp_ID = RecordRow Select a).FirstOrDefault
            If LoadStudents IsNot Nothing Then
                With LoadStudents
                    ghj = .Emp_ID
                    Try
                        'Emp_Image.Image = DbToImg(.Emp_Image)
                    Catch ex As Exception
                        Emp_Image.Image = Image.FromFile(Application.StartupPath & "\Images\Empty.jpg")
                    End Try
                    Emp_Reg.Text = .Emp_Reg
                    Emp_Name.Text = .Emp_Name
                    Emp_Father.Text = .Emp_Father
                    Emp_Phone.Text = .Emp_Phone
                    Emp_Phone2.Text = .Emp_Phone2
                    Emp_Address_ID.EditValue = .Emp_Address
                    Emp_Quali.Text = .Emp_Quali
                    Emp_Designation_ID.EditValue = .Emp_Designation
                    Emp_Date_Join.EditValue = .Emp_Date_Hired
                    Emp_Date_Leave.EditValue = .Emp_Date_Terminated
                    Emp_Date_ReHired.EditValue = .Emp_Date_ReHired
                    'Try
                    '    Emp_Signature.Image = DbToImg(.Emp_Signature)
                    'Catch ex As Exception

                    'End Try
                    Emp_NIC_No.EditValue = .Emp_NIC_No
                    Emp_Report_To.EditValue = .Emp_Report_To
                    Emp_Birth_Date.EditValue = .Emp_Birth_Date
                    Emp_Status.Checked = CBool(.Emp_Status)
                    Emp_DutyOn.EditValue = .Emp_DutyOn
                    Emp_Duty_Off.EditValue = .Emp_Duty_Off

                    Emp_Salary.EditValue = .Emp_Salary
                    Call LoadEmployeeFingerDetail(.Emp_ID)
                End With

            End If
        End Using
        'Catch ex As Exception
        '    XtraMessageBox.Show("See Your Text")
        'End Try
    End Sub
#End Region

    Private Sub SearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles SearchLookUpEdit1.EditValueChanged
        Try
            LoadTeachersRecords(CInt(SearchLookUpEdit1.EditValue))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadTile()
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Where a.Emp_Status = True Select a).ToList
            If dt.Count > 0 Then

                Dim grp As New TileBarGroup
                TileBar1.Groups.Clear()
                For Each dts In dt

                    'TileEle.
                    Dim item As New TileBarItem
                    Dim TileEle As New TileItemElement
                    Try
                        'TileEle.Image = DbToImg(dts.Emp_Image)
                    Catch ex As Exception
                        TileEle.Image = Image.FromFile(Application.StartupPath & "\Images\Empty.jpg")
                    End Try
                    TileEle.ImageScaleMode = TileItemImageScaleMode.Stretch
                    TileEle.ImageLocation = New Point(-13, 0)
                    TileEle.ImageSize = New Size(35, 40)
                    TileEle.ImageAlignment = TileItemContentAlignment.MiddleLeft

                    item.Elements.Add(TileEle)
                    item.Elements.Add(New TileItemElement With {.Text = dts.Emp_Name, .TextAlignment = TileItemContentAlignment.TopLeft, .TextLocation = New Point(25, -7)})
                    item.Elements.Add(New TileItemElement With {.Text = dts.Emp_Designation, .TextAlignment = TileItemContentAlignment.MiddleLeft, .TextLocation = New Point(25, 0)})
                    item.Elements.Add(New TileItemElement With {.Text = If(Not IsNothing(dts.Emp_DutyOn), dts.Emp_DutyOn, ""), .TextAlignment = TileItemContentAlignment.BottomLeft, .TextLocation = New Point(25, 6)})
                    item.Elements.Add(New TileItemElement With {.Text = If(Not IsNothing(dts.Emp_Duty_Off), dts.Emp_Duty_Off, ""), .TextAlignment = TileItemContentAlignment.BottomRight, .TextLocation = New Point(5, 6)})
                    item.Elements.Add(New TileItemElement With {.Text = CType(dts.Emp_ID, String), .TextAlignment = TileItemContentAlignment.TopLeft, .TextLocation = New Point(-50, 0)})

                    item.ItemSize = CType(TileItemSize.Wide, TileBarItemSize)
                    item.ShowItemShadow = DevExpress.Utils.DefaultBoolean.True
                    grp.Items.Add(item)

                Next
                'TileBar1.ShowItemShadow = True
                TileBar1.Groups.Add(grp)
            End If
        End Using
    End Sub

    Private Sub TileBar1_ItemClick(sender As Object, e As TileItemEventArgs) Handles TileBar1.ItemClick
        SearchLookUpEdit1.EditValue = e.Item.Elements(5).Text
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)
        SaveAndUpdateData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        NewStudentData()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs)
        Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
        LoadTeachersRecords(intMultiFee)
        LoadTile()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs)
        BarButtonItem1.Enabled = False
        BarButtonItem2.Enabled = False
        BarButtonItem3.Enabled = True
        BarButtonItem4.Enabled = False
        btnConnect.Enabled = True
        'SimpleButton1.Enabled = True
        'GridView1.OptionsBehavior.Editable = True

        For Each textEdit As Control In Me.LayoutControl1.Controls
            If TypeOf textEdit Is TextEdit Then
                TryCast(textEdit, TextEdit).Properties.ReadOnly = False
            End If
        Next textEdit
        For Each textEdit As Control In Me.LayoutControl5.Controls
            If TypeOf textEdit Is TextEdit Then
                TryCast(textEdit, TextEdit).Properties.ReadOnly = False
            End If
        Next textEdit
        SearchLookUpEdit1.Properties.ReadOnly = True
        Emp_Reg.Properties.ReadOnly = True
    End Sub

    Private Sub Emp_Address_ID_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Address_ID.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    Private Sub Emp_Birth_Date_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Birth_Date.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    Private Sub Emp_Name_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Name.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    Private Sub Emp_Father_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Father.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub


    Public Sub LoadEmployeeFingerDetail(EmpID As Integer)
        'Dim DBCon2 As New OleDb.OleDbConnection(CsmdCon.ConOleDB)
        'Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.Name, USERINFO.Gender, USERINFO.DEFAULTDEPTID FROM USERINFO WHERE Name='" & Namex & "'", DBCon2)
        'Dim ds2 As New DataSet()
        'da2.Fill(ds2)

        'If ds2.Tables(0).Rows.Count > 0 Then
        '    GridControl1.DataSource = ds2.Tables(0)
        'Else
        '    GridControl1.DataSource = Nothing
        'End If
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Try
                Dim dt = (From a In db.Attendence_Status Group Join b In db.Emp_Bio_Device_Users.Where(Function(o) CBool(o.Emp_ID = EmpID)) On a.Attendence_Status_ID Equals b.Attendence_Status_ID Into z = Group From b In z.DefaultIfEmpty()
                          Select New With {a.Attendence_Status_Type, a.Attendence_Status_Finger,
                               b.Emp_Bio_Device_Users_UserID,
                               b.Emp_Bio_Device_User_Name,
                               b.Emp_Bio_Device_User_Finger,
                              .Emp_Bio_Device_User_tmpData = b.Emp_Bio_Device_User_tmpData, b.Emp_Bio_Device_User_FacetmpData, b.Emp_Bio_Device_User_iLength,
                              b.Emp_Bio_Device_User_Privilege,
                               b.Emp_Bio_Device_User_Enabled, b.Emp_Bio_Device_User_Password,
                              .Fing = If(b.Emp_Bio_Device_User_tmpData Is Nothing Or b.Emp_Bio_Device_User_tmpData = "", "No", "Yes"),
                          .Face = If(b.Emp_Bio_Device_User_FacetmpData Is Nothing Or b.Emp_Bio_Device_User_FacetmpData = "", "No", "Yes")}).ToList
                If dt.Count > 0 Then
                    GridControl1.DataSource = dt
                Else
                    GridControl1.DataSource = Nothing
                End If
            Catch ex As Exception
                GridControl1.DataSource = Nothing
            End Try
        End Using
    End Sub

    'Private Sub LoadFormAdmin(EmpID As String)
    '    'Dim mm As Integer = If(TextBox1.Text = "", 0, TextBox1.Text)
    '    Dim DBCon4 As New SqlConnection(CsmdCon.ConSqlDB)
    '    Dim da4 As SqlDataAdapter = New SqlDataAdapter("Select * FROM Employees WHERE Emp_Name='" & EmpID & "'", DBCon4)
    '    Dim ds4 As New DataSet()
    '    da4.Fill(ds4)
    '    Dim MyTableCount4 As Integer = ds4.Tables.Count
    '    Dim k4 As Integer = 1

    '    If MyTableCount4 = 1 Then
    '        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '        Dim v As Integer = CInt(ds4.Tables(0).Rows(0).Item("Emp_ID"))
    '        Dim a As Integer = v * 10
    '        Dim b As Integer = a - 9
    '        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '        Dim DBCon As New SqlConnection(CsmdCon.ConSqlDB)
    '        Dim da As SqlDataAdapter = New SqlDataAdapter("Select * FROM Attendence_Status", DBCon)
    '        Dim ds As New DataSet()
    '        da.Fill(ds)
    '        Dim MyTableCount As Integer = ds.Tables.Count
    '        Dim k As Integer = 1
    '        'DataT.Rows.Clear()
    '        For Each row As DataRow In ds.Tables(0).Rows
    '            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '            Dim DBCon2 As New OleDb.OleDbConnection(CsmdCon.ConOleDB)
    '            Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT * FROM USERINFO WHERE DEFAULTDEPTID=" & row.Item("Attendence_Status_Dep").ToString & " and Name='" & ds4.Tables(0).Rows(0).Item("Emp_Name").ToString & "' and Badgenumber='" & b & "'", DBCon2)
    '            Dim ds2 As New DataSet()
    '            da2.Fill(ds2)
    '            Dim MyTableCount2 As Integer = ds2.Tables(0).Rows.Count
    '            Dim k2 As Integer = 1
    '            If MyTableCount2 = 0 Then
    '                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '                Dim SqldataSet3 As New DataSet()
    '                Dim dataadapter3 As New OleDb.OleDbDataAdapter
    '                Dim cmd3 As New OleDb.OleDbCommand
    '                Dim connection3 As New OleDb.OleDbConnection(CsmdCon.ConOleDB)
    '                connection3.Open()
    '                cmd3.Connection = connection3
    '                Dim Crt_User As String = "INSERT INTO USERINFO (Badgenumber,SSN,Name,Gender,DEFAULTDEPTID) VALUES ('" & b & "','" & row.Item("Attendence_Status_Type").ToString & "','" & ds4.Tables(0).Rows(0).Item("Emp_Name").ToString & "','M'," & row.Item("Attendence_Status_Dep").ToString & ")"
    '                cmd3.CommandText = Crt_User
    '                cmd3.ExecuteNonQuery()
    '                connection3.Close()
    '                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '            Else
    '            End If
    '            DBCon2.Close()
    '            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '            k += 1
    '            b += 1
    '        Next row

    '        DBCon.Close()

    '        'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    '    End If
    '    DBCon4.Close()

    '    LoadEmployeeFingerDetail(Emp_Name.Text)
    'End Sub
    Public Sub LoadFromDb(EmpID As Integer)
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Attendence_Status Group Join b In db.Emp_Bio_Device_Users.Where(Function(o) CBool(o.Emp_ID = EmpID)) On a.Attendence_Status_ID Equals b.Attendence_Status_ID Into z = Group From b In z.DefaultIfEmpty()
                      Select New With {a.Attendence_Status_Type, a.Attendence_Status_Finger,
                           b.Emp_Bio_Device_Users_UserID,
                           b.Emp_Bio_Device_User_Name,
                           b.Emp_Bio_Device_User_Finger,
                          .Emp_Bio_Device_User_tmpData = b.Emp_Bio_Device_User_tmpData, b.Emp_Bio_Device_User_FacetmpData, b.Emp_Bio_Device_User_iLength,
                          b.Emp_Bio_Device_User_Privilege,
                           b.Emp_Bio_Device_User_Enabled, b.Emp_Bio_Device_User_Password,
                          .Fing = If(b.Emp_Bio_Device_User_tmpData Is Nothing Or b.Emp_Bio_Device_User_tmpData = "", "No", "Yes"),
                          .Face = If(b.Emp_Bio_Device_User_FacetmpData Is Nothing Or b.Emp_Bio_Device_User_FacetmpData = "", "No", "Yes")}).ToList
            If dt.Count > 0 Then
                GridControl1.DataSource = dt
            Else
                GridControl1.DataSource = Nothing
            End If
        End Using
    End Sub
    Public Sub Generate()
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim EmpID As Integer = ghj
            Dim mm As Integer = EmpID * 10
            Dim nn As Integer = mm - 9
            Dim dty = (From a In db.Employees Where a.Emp_ID = EmpID Select a).FirstOrDefault
            If dty IsNot Nothing Then
                Dim dt = (From a In db.Attendence_Status Select a).ToList
                If dt.Count > 0 Then
                    Dim k As Integer = 0
                    For Each dts In dt
                        Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = EmpID And a.Attendence_Status_ID = dts.Attendence_Status_ID Select a).FirstOrDefault
                        If fg IsNot Nothing Then
                            With fg
                                .Emp_ID = EmpID
                                .Attendence_Status_ID = dts.Attendence_Status_ID
                                .Emp_Bio_Device_Users_UserID = nn
                                .Emp_Bio_Device_User_Name = dty.Emp_Name
                                '.Emp_Bio_Device_User_Finger = 0
                                '.Emp_Bio_Device_User_tmpData = ""
                                '.Emp_Bio_Device_User_Privilege = 0
                                .Emp_Bio_Device_User_Password = CType(GridView1.GetRowCellValue(k, "Emp_Bio_Device_User_Password"), String)
                                '.Emp_Bio_Device_User_Enabled = True
                            End With
                            db.SaveChanges()
                        Else
                            Dim dtNew = New CsmdBioDatabase.Emp_Bio_Device_Users
                            With dtNew
                                .Emp_ID = EmpID
                                .Attendence_Status_ID = dts.Attendence_Status_ID
                                .Emp_Bio_Device_Users_UserID = nn
                                .Emp_Bio_Device_User_Name = dty.Emp_Name
                                .Emp_Bio_Device_User_Finger = 0
                                .Emp_Bio_Device_User_tmpData = ""
                                .Emp_Bio_Device_User_FacetmpData = ""
                                .Emp_Bio_Device_User_iLength = 0
                                .Emp_Bio_Device_User_Privilege = 0
                                .Emp_Bio_Device_User_Password = ""
                                .Emp_Bio_Device_User_Enabled = True
                                .User_ID = CsmdVarible.PlazaUserID
                            End With
                            db.Emp_Bio_Device_Users.Add(dtNew)
                            db.SaveChanges()
                        End If
                        nn += 1
                        k += 1
                    Next

                End If
            End If
            Dim dfg = (From a In db.Attendence_Status Group Join b In db.Emp_Bio_Device_Users.Where(Function(o) CBool(o.Emp_ID = ghj)) On a.Attendence_Status_ID Equals b.Attendence_Status_ID Into z = Group From b In z.DefaultIfEmpty()
                       Select New With {a.Attendence_Status_Type, a.Attendence_Status_Finger,
                           b.Emp_Bio_Device_Users_UserID,
                           b.Emp_Bio_Device_User_Name,
                           b.Emp_Bio_Device_User_Finger,
                           b.Emp_Bio_Device_User_tmpData,
                           b.Emp_Bio_Device_User_FacetmpData,
                           b.Emp_Bio_Device_User_iLength,
                           b.Emp_Bio_Device_User_Privilege,
                           b.Emp_Bio_Device_User_Enabled,
                           b.Emp_Bio_Device_User_Password,
                           .Fing = If(b.Emp_Bio_Device_User_tmpData Is Nothing Or b.Emp_Bio_Device_User_tmpData = "", "No", "Yes"),
                          .Face = If(b.Emp_Bio_Device_User_FacetmpData Is Nothing Or b.Emp_Bio_Device_User_FacetmpData = "", "No", "Yes")}).ToList
            If dfg.Count > 0 Then
                GridControl1.DataSource = dfg

            Else
                GridControl1.DataSource = Nothing
            End If
        End Using
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Generate()
        UploadUser()
        'MCSD
    End Sub
    Public Sub UploadUser()

        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        If GridView1.RowCount = 0 Then
            MsgBox("There is no data to upload!", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer

        Dim idwEnrollNumber As Integer
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim idwFingerIndex As Integer

        Dim iFaceIndex As Integer = 50
        Dim sTmpData As String = ""
        Dim sFaceTmpData As String = ""
        Dim sEnabled As String = ""
        Dim iFlag As Integer = 0
        Dim bEnabled As Boolean = False

        Dim iUpdateFlag As Integer = 1
        'Dim lvItem As New ListViewItem
        Dim iLength As Integer = 0
        Cursor = Cursors.WaitCursor
        axCZKEM1.EnableDevice(iMachineNumber, False)

        If axCZKEM1.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            For lvItem As Integer = 0 To GridView1.RowCount - 1
                idwEnrollNumber = CInt(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_Users_UserID")) 'Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                sName = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Name"), String)
                idwFingerIndex = CInt(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Finger"))
                sTmpData = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_tmpData"), String)
                sFaceTmpData = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_FacetmpData"), String)
                iPrivilege = CInt(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Privilege"))
                sPassword = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Password"), String)
                sEnabled = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Enabled"), String)
                iLength = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_iLength"), Integer)
                If CBool(sEnabled) = True Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If

                'If idwEnrollNumber <> iLastEnrollNumber Then 'identify whether the user information(except fingerprint templates) has been uploaded
                If axCZKEM1.SSR_SetUserInfo(iMachineNumber, CType(idwEnrollNumber, String), sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                    axCZKEM1.SetUserTmpExStr(iMachineNumber, CType(idwEnrollNumber, String), idwFingerIndex, iFlag, sTmpData) 'upload templates information to the device

                    'If sFaceTmpData IsNot Nothing Then
                    '        axCZKEM1.SetUserFaceStr(iMachineNumber, CType(idwEnrollNumber, String), iFaceIndex, sFaceTmpData, iLength)
                    '    End If

                Else
                    axCZKEM1.GetLastError(idwErrorCode)
                    MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                    Cursor = Cursors.Default
                    axCZKEM1.EnableDevice(iMachineNumber, True)
                    Return
                End If
                'If axCZKEM1.SSR_SetUserInfo(iMachineNumber, CType(idwEnrollNumber, String), sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                '    axCZKEM1.SetUserFaceStr(iMachineNumber, CType(idwEnrollNumber, String), iFaceIndex, sFaceTmpData, iLength) 'upload templates information to the device
                'Else
                '    axCZKEM1.GetLastError(idwErrorCode)
                '    MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                '    Cursor = Cursors.Default
                '    axCZKEM1.EnableDevice(iMachineNumber, True)
                '    Return
                'End If
                'Else 'the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                '    axCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData) 'upload tempates information to the memory
                'End If
                'iLastEnrollNumber = idwEnrollNumber 'change the value of iLastEnrollNumber dynamicly
            Next
        End If
        axCZKEM1.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        axCZKEM1.EnableDevice(iMachineNumber, False)
        Cursor = Cursors.WaitCursor
        axCZKEM1.EnableDevice(iMachineNumber, False)

        If axCZKEM1.BeginBatchUpdate(iMachineNumber, iUpdateFlag) Then 'create memory space for batching data
            Dim iLastEnrollNumber As Integer = 0 'the former enrollnumber you have upload(define original value as 0)
            For lvItem As Integer = 0 To GridView1.RowCount - 1
                idwEnrollNumber = CInt(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_Users_UserID")) 'Convert.ToInt32(lvItem.SubItems(0).Text.Trim())
                sName = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Name"), String)
                idwFingerIndex = CInt(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Finger"))
                sTmpData = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_tmpData"), String)
                sFaceTmpData = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_FacetmpData"), String)
                iPrivilege = CInt(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Privilege"))
                sPassword = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Password"), String)
                sEnabled = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_Enabled"), String)
                iLength = CType(GridView1.GetRowCellValue(lvItem, "Emp_Bio_Device_User_iLength"), Integer)
                If CBool(sEnabled) = True Then
                    bEnabled = True
                Else
                    bEnabled = False
                End If

                'If idwEnrollNumber <> iLastEnrollNumber Then 'identify whether the user information(except fingerprint templates) has been uploaded
                If axCZKEM1.SSR_SetUserInfo(iMachineNumber, CType(idwEnrollNumber, String), sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                    '    axCZKEM1.SetUserTmpExStr(iMachineNumber, CType(idwEnrollNumber, String), idwFingerIndex, iFlag, sTmpData) 'upload templates information to the device

                    If sFaceTmpData IsNot Nothing Then
                        axCZKEM1.SetUserFaceStr(iMachineNumber, CType(idwEnrollNumber, String), iFaceIndex, sFaceTmpData, iLength)
                    End If

                Else
                    axCZKEM1.GetLastError(idwErrorCode)
                    MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                    Cursor = Cursors.Default
                    axCZKEM1.EnableDevice(iMachineNumber, True)
                    Return
                End If
                'If axCZKEM1.SSR_SetUserInfo(iMachineNumber, CType(idwEnrollNumber, String), sName, sPassword, iPrivilege, bEnabled) Then 'upload user information to the device
                '    axCZKEM1.SetUserFaceStr(iMachineNumber, CType(idwEnrollNumber, String), iFaceIndex, sFaceTmpData, iLength) 'upload templates information to the device
                'Else
                '    axCZKEM1.GetLastError(idwErrorCode)
                '    MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
                '    Cursor = Cursors.Default
                '    axCZKEM1.EnableDevice(iMachineNumber, True)
                '    Return
                'End If
                'Else 'the current fingerprint and the former one belongs the same user,that is ,one user has more than one template
                '    axCZKEM1.SetUserTmpStr(iMachineNumber, idwEnrollNumber, idwFingerIndex, sTmpData) 'upload tempates information to the memory
                'End If
                'iLastEnrollNumber = idwEnrollNumber 'change the value of iLastEnrollNumber dynamicly
            Next
        End If
        axCZKEM1.BatchUpdate(iMachineNumber) 'upload all the information in the memory
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        axCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
        MsgBox("Successfully upload fingerprint templates in batches , " + "total:" + GridView1.RowCount.ToString(), MsgBoxStyle.Information, "Success")


    End Sub
    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Generate()
        DownloadUser()
    End Sub
    Public Sub DownloadUser()
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim idwEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer
        Dim bEnabled As Boolean = False
        Dim idwFingerIndex As Integer = 0
        Dim sTmpData As String = ""
        Dim sFaceTmpData As String = ""
        Dim iTmpLength As Integer
        Dim iFlag As Integer = 0
        Dim iFaceIndex As Integer = 50
        Dim iLength As Integer = 0
        axCZKEM1.EnableDevice(iMachineNumber, False)
        Dim EmpID As Integer = ghj
        Cursor = Cursors.WaitCursor
        axCZKEM1.BeginBatchUpdate(iMachineNumber, 1) 'create memory space for batching data
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        axCZKEM1.ReadAllTemplate(iMachineNumber) 'read all the users' fingerprint templates to the memory
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim finID As Integer = CInt(txtFin.Text)
            'get the corresponding templates string and length from the memory
            ' Dim ddd As Integer = If(CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)) = 0, 10, CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)))
            Dim khk As Boolean = False
            Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = EmpID Select a).ToList
            If fg.Count > 0 Then
                For Each dts In fg
                    With dts
                        '.Emp_ID = EmpID
                        '.Attendence_Status_ID = dts.Attendence_Status_ID
                        '.Emp_Bio_Device_User_Name = sName

                        If axCZKEM1.GetUserTmpExStr(iMachineNumber, .Emp_Bio_Device_Users_UserID.ToString, finID, iFlag, sTmpData, iTmpLength) Then
                            .Emp_Bio_Device_User_Finger = finID
                            .Emp_Bio_Device_User_tmpData = sTmpData
                            .Emp_Bio_Device_User_Privilege = iPrivilege
                            .Emp_Bio_Device_User_Password = sPassword
                        End If
                        If khk = False Then
                            If axCZKEM1.GetUserFaceStr(iMachineNumber, .Emp_Bio_Device_Users_UserID.ToString, iFaceIndex, sFaceTmpData, iLength) Then
                                .Emp_Bio_Device_User_FacetmpData = sFaceTmpData
                                .Emp_Bio_Device_User_iLength = iLength
                                khk = True
                            End If
                        End If
                        .Emp_Bio_Device_User_Enabled = True

                    End With
                Next
                db.SaveChanges()
            End If


            'get the corresponding templates string and length from the memory

            '    Dim ddd As Integer = If(CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)) = 0, 10, CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)))
            'Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = EmpID And a.Emp_Bio_Device_Users_UserID = 11 Select a).FirstOrDefault
            '    If fg IsNot Nothing Then
            '        With fg
            '            .Emp_ID = EmpID
            '            .Attendence_Status_ID = 1
            '            .Emp_Bio_Device_User_Name = sName
            '            ' .Emp_Bio_Device_User_Finger = 0
            '            .Emp_Bio_Device_User_FacetmpData = sFaceTmpData
            '            '.Emp_Bio_Device_User_Privilege = iPrivilege
            '            .Emp_Bio_Device_User_iLength = iLength
            '            '.Emp_Bio_Device_User_Password = sPassword
            '            .Emp_Bio_Device_User_Enabled = bEnabled
            '        End With
            '        db.SaveChanges()
            '    End If



        End Using
        'axCZKEM1.EnableDevice(iMachineNumber, False)
        Cursor = Cursors.WaitCursor
        axCZKEM1.BatchUpdate(iMachineNumber) 'download all the information in the memory
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed

        axCZKEM1.EnableDevice(iMachineNumber, True)

        'axCZKEM1.BeginBatchUpdate(iMachineNumber, 1) 'create memory space for batching data
        'axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        'axCZKEM1.ReadAllTemplate(iMachineNumber)
        'While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
        '    'For idwFingerIndex = 0 To 9
        '            Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities

        '    End Using
        '    'Next
        'End While
        ''lvDownload.EndUpdate()
        'axCZKEM1.BatchUpdate(iMachineNumber) 'download all the information in the memory
        'axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        'axCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
        LoadFromDb(EmpID)
    End Sub

    Private Sub Emp_DutyOn_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_DutyOn.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    Private Sub Emp_Duty_Off_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Duty_Off.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    Private Sub Emp_Salary_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Salary.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        NewStudentData()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        BarButtonItem1.Enabled = False
        BarButtonItem2.Enabled = False
        BarButtonItem3.Enabled = True
        BarButtonItem4.Enabled = False
        btnConnect.Enabled = True
        'SimpleButton1.Enabled = True
        'GridView1.OptionsBehavior.Editable = True

        For Each textEdit As Control In Me.LayoutControl1.Controls
            If TypeOf textEdit Is TextEdit Then
                TryCast(textEdit, TextEdit).Properties.ReadOnly = False
            End If
        Next textEdit
        For Each textEdit As Control In Me.LayoutControl5.Controls
            If TypeOf textEdit Is TextEdit Then
                TryCast(textEdit, TextEdit).Properties.ReadOnly = False
            End If
        Next textEdit
        SearchLookUpEdit1.Properties.ReadOnly = True
        Emp_Reg.Properties.ReadOnly = True
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        SaveAndUpdateData()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
        LoadTeachersRecords(intMultiFee)
        LoadTile()
    End Sub



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
            'RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            'RemoveHandler axCZKEM1.OnKeyPress, AddressOf AxCZKEM1_OnKeyPress
            RemoveHandler axCZKEM1.OnEnrollFinger, AddressOf AxCZKEM1_OnEnrollFinger
            RemoveHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
            'RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
            'RemoveHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
            'RemoveHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
            'RemoveHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
            'RemoveHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
            'RemoveHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum
            bIsConnected = False
            btnConnect.Caption = "Connect"
            lblState.Caption = "Current State:Disconnected"
            btnConnect.ItemAppearance.Normal.BackColor = Color.Red
            lblState.ItemAppearance.Normal.BackColor = Color.Red
            SimpleButton5.Enabled = False
            SimpleButton1.Enabled = False
            GridView1.OptionsBehavior.Editable = False
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected = axCZKEM1.Connect_Net(txtIP.EditValue.ToString, Convert.ToInt32(txtPort.EditValue.ToString))
        bIsConnected = True
        If bIsConnected = True Then
            btnConnect.Caption = "Disconnect"
            btnConnect.Refresh()
            lblState.Caption = "Current State:Connected"
            btnConnect.ItemAppearance.Normal.BackColor = Color.LimeGreen
            lblState.ItemAppearance.Normal.BackColor = Color.LimeGreen
            SimpleButton5.Enabled = True
            SimpleButton1.Enabled = True
            GridView1.OptionsBehavior.Editable = True
            SaveSetting(Application.StartupPath, "CsmdAtt", "CsmdAttIP", txtIP.EditValue.ToString)
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            'axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                'AddHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
                'AddHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
                'AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                'AddHandler axCZKEM1.OnAttTransaction, AddressOf AxCZKEM1_OnAttTransaction
                'AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                'AddHandler axCZKEM1.OnKeyPress, AddressOf AxCZKEM1_OnKeyPress
                AddHandler axCZKEM1.OnEnrollFinger, AddressOf AxCZKEM1_OnEnrollFinger
                AddHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
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
    Dim iCanSaveTmp As Integer = 0
    Private Sub RepositoryItemButtonEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit1.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        'If txtUserID.Text.Trim() = "" Or cbFingerIndex.Text.Trim() = "" Then
        '    MsgBox("UserID,FingerIndex must be inputted first!", MsgBoxStyle.Information, "Error")
        '    Return
        'End If
        Dim idwErrorCode As Integer

        Dim iUserID As String = CType(GridView1.GetFocusedRowCellValue("Emp_Bio_Device_Users_UserID"), String) 'Convert.ToInt32(txtUserID.Text.Trim())
        'Dim sUserID = txtUserID.Text.Trim()
        Dim iFingerIndex = 0 'Convert.ToInt32(cbFingerIndex.Text.Trim())
        Dim iFlag = 1 ' Convert.ToInt32(cbFlag.Text.Trim())

        axCZKEM1.CancelOperation()
        axCZKEM1.SSR_DelUserTmpExt(iMachineNumber, iUserID, iFingerIndex)
        If axCZKEM1.StartEnrollEx(iUserID, iFingerIndex, iFlag) = True Then
            MsgBox("Start to Enroll a new User,UserID=" + iUserID.ToString() + " FingerID=" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Start")
            iCanSaveTmp = 1
            axCZKEM1.StartIdentify() 'After enrolling templates,you should let the device into the 1:N verification condition
            'DownloadUser()
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Private Sub RepositoryItemButtonEdit2_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit2.Click
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        'If cbUserIDTmp.Text.Trim() = "" Or cbFingerIndex.Text.Trim() = "" Then
        '    MsgBox("Please input the UserID and FingerIndex first!", MsgBoxStyle.Exclamation, "Error")
        '    Return
        'End If
        Dim idwErrorCode As Integer

        Dim iUserID As String = CStr(GridView1.GetFocusedRowCellValue("Emp_Bio_Device_Users_UserID"))
        Dim iFingerIndex As Integer = CInt(txtFin.Text)  'Convert.ToInt32(cbFingerIndex.Text.Trim())
        'Dim EmpID As String = tx1.Text
        Cursor = Cursors.WaitCursor

        If MsgBox("Delete FingerPrint and Face? Click YES, or Only Delete Face? Click NO", vbYesNoCancel, "Delete Msg") = MsgBoxResult.Yes Then
            If axCZKEM1.SSR_DelUserTmpExt(iMachineNumber, iUserID, iFingerIndex) = True Then
                axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                MsgBox("DelUserTmp,UserID:" + iUserID.ToString() + " FingerIndex:" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Success")
                Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
                    Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_Bio_Device_Users_UserID = CType(iUserID, Integer?) Select a).FirstOrDefault
                    If fg IsNot Nothing Then
                        With fg
                            '.Emp_ID = EmpID
                            '.Attendence_Status_ID = ddd
                            '.Emp_Bio_Device_User_Name = sName
                            .Emp_Bio_Device_User_Finger = 0
                            .Emp_Bio_Device_User_tmpData = ""
                            '.Emp_Bio_Device_User_Privilege = iPrivilege
                            '.Emp_Bio_Device_User_Password = sPassword
                            '.Emp_Bio_Device_User_Enabled = bEnabled
                        End With
                        db.SaveChanges()
                    End If

                End Using
            Else
                axCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
            End If
            If axCZKEM1.DelUserFace(iMachineNumber, iUserID, iFingerIndex) = True Then
                axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                MsgBox("DelUserTmp,UserID:" + iUserID.ToString() + " Face:" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Success")
                Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
                    Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_Bio_Device_Users_UserID = CType(iUserID, Integer?) Select a).FirstOrDefault
                    If fg IsNot Nothing Then
                        With fg
                            '.Emp_ID = EmpID
                            '.Attendence_Status_ID = ddd
                            '.Emp_Bio_Device_User_Name = sName
                            '.Emp_Bio_Device_User_Finger = 0
                            .Emp_Bio_Device_User_FacetmpData = ""
                            .Emp_Bio_Device_User_iLength = 0
                            '.Emp_Bio_Device_User_Privilege = iPrivilege
                            '.Emp_Bio_Device_User_Password = sPassword
                            '.Emp_Bio_Device_User_Enabled = bEnabled
                        End With
                        db.SaveChanges()
                    End If
                    'LoadEmployeeFingerDetail(ghj)
                End Using
            Else
                axCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
            End If
        ElseIf MsgBox("Delete Face? Click NO", vbYesNoCancel, "Delete Msg") = MsgBoxResult.Yes Then
            If axCZKEM1.DelUserFace(iMachineNumber, iUserID, iFingerIndex) = True Then
                axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                MsgBox("DelUserTmp,UserID:" + iUserID.ToString() + " Face:" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Success")
                Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
                    Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_Bio_Device_Users_UserID = CType(iUserID, Integer?) Select a).FirstOrDefault
                    If fg IsNot Nothing Then
                        With fg
                            '.Emp_ID = EmpID
                            '.Attendence_Status_ID = ddd
                            '.Emp_Bio_Device_User_Name = sName
                            '.Emp_Bio_Device_User_Finger = 0
                            .Emp_Bio_Device_User_FacetmpData = ""
                            .Emp_Bio_Device_User_iLength = 0
                            '.Emp_Bio_Device_User_Privilege = iPrivilege
                            '.Emp_Bio_Device_User_Password = sPassword
                            '.Emp_Bio_Device_User_Enabled = bEnabled
                        End With
                        db.SaveChanges()
                    End If
                    'LoadEmployeeFingerDetail(ghj)
                End Using
            Else
                axCZKEM1.GetLastError(idwErrorCode)
                MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
            End If
        Else
            Exit Sub
        End If


        LoadEmployeeFingerDetail(ghj)



        Cursor = Cursors.Default
    End Sub

    Private Sub AxCZKEM1_OnDeleteTemplate(ByVal iEnrollNumber As Integer, ByVal iFingerIndex As Integer)
        'ListBox1.Items.Add("RTEvent OnDeleteTemplate Has been Triggered...")
        'ListBox1.Items.Add("...UserID=" & iEnrollNumber.ToString() & " FingerIndex=" & iFingerIndex.ToString())
    End Sub
    Private Sub AxCZKEM1_OnEnrollFinger(ByVal iEnrollNumber As Integer, ByVal iFingerIndex As Integer, ByVal iActionResult As Integer, ByVal iTemplateLength As Integer)
        If iActionResult = 0 Then
            'ListBox1.Items.Add("RTEvent OnEnrollFiger Has been Triggered....")
            'ListBox1.Items.Add(".....UserID: " & iEnrollNumber & " Index: " & iFingerIndex.ToString() & " tmpLen: " + iTemplateLength.ToString())
            DownloadUser()

        Else
            'ListBox1.Items.Add("RTEvent OnEnrollFiger was Triggered by Error")
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        Try
            If e.Column.FieldName = "Fing" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.LimeGreen
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception

        End Try
        Try
            If e.Column.FieldName = "Face" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit3_Click(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit3.Click
        '  axCZKEM1 = New zkemkeeper.CZKEM()
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        'If txtUserID.Text.Trim() = "" Or cbFingerIndex.Text.Trim() = "" Then
        '    MsgBox("UserID,FingerIndex must be inputted first!", MsgBoxStyle.Information, "Error")
        '    Return
        'End If
        Dim idwErrorCode As Integer

        Dim iUserID As String = CType(GridView1.GetFocusedRowCellValue("Emp_Bio_Device_Users_UserID"), String) 'Convert.ToInt32(txtUserID.Text.Trim())
        'Dim sUserID = txtUserID.Text.Trim()
        Dim iFingerIndex As Integer = 111 'Convert.ToInt32(cbFingerIndex.Text.Trim())
        Dim iFlag As Integer = 1 ' Convert.ToInt32(cbFlag.Text.Trim())


        axCZKEM1.CancelOperation()
        axCZKEM1.DelUserFace(iMachineNumber, iUserID, iFingerIndex)
        axCZKEM1.RefreshData(1)
        If axCZKEM1.StartEnrollEx(iUserID, iFingerIndex, iFlag) = True Then
            MsgBox("Start to Enroll a new User,UserID=" + iUserID.ToString() + " FingerID=" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Start")
            iCanSaveTmp = 1
            axCZKEM1.StartIdentify() 'After enrolling templates,you should let the device into the 1:N verification condition
            axCZKEM1.RefreshData(1)
            'DownloadUser()
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Operation failed,ErrorCode=" & idwErrorCode.ToString(), MsgBoxStyle.Exclamation, "Error")
        End If
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        Using db As CsmdBioAttendenceEntities1 = New CsmdBioAttendenceEntities1
            Dim dt = (From a In db.Employees Select a).ToList
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
                        Dim df = (From a In db2.Employees Where a.Emp_ID = dts.Emp_ID Select a).FirstOrDefault
                        If df IsNot Nothing Then
                            With df
                                .Emp_Address = dts.Emp_Address
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Father = dts.Emp_Father
                                '.Emp_Image = dts.Emp_Image
                                .Emp_Name = dts.Emp_Name
                                .Emp_NIC_No = dts.Emp_NIC_No
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Salary = dts.Emp_Salary
                                .Emp_Status = dts.Emp_Status
                            End With
                            db2.SaveChanges()
                        Else
                            Dim dfNew = New CsmdBioDatabase.Employee
                            With dfNew
                                .Emp_Address = dts.Emp_Address
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Father = dts.Emp_Father
                                '.Emp_Image = dts.Emp_Image
                                .Emp_Name = dts.Emp_Name
                                .Emp_NIC_No = dts.Emp_NIC_No
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Salary = dts.Emp_Salary
                                .Emp_Status = dts.Emp_Status
                            End With
                            db2.Employees.Add(dfNew)
                            db2.SaveChanges()
                        End If
                    End Using

                    Using dbX As CsmdBioAttendenceEntities1 = New CsmdBioAttendenceEntities1
                        Dim dtX = (From a In dbX.Emp_Bio_Device_Users Where a.Emp_ID = dts.Emp_ID Select a).ToList
                        If dtX.Count > 0 Then
                            'Dim kX As Integer = 0
                            'ProgressBarControl1.Properties.Maximum = dtX.Count
                            'ProgressBarControl1.Properties.Minimum = 0
                            'ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                            'ProgressBarControl1.Position = 0
                            'ProgressBarControl1.Update()
                            For Each dtsX In dtX
                                'ProgressBarControl1.Position = kX
                                'ProgressBarControl1.Update()
                                'k += 1
                                Using db2X As New CsmdBioAttendenceEntities
                                    Dim dfX = (From a In db2X.Emp_Bio_Device_Users Where a.Emp_Bio_Device_Users_UserID = dtsX.Emp_Bio_Device_Users_UserID Select a).FirstOrDefault
                                    If dfX IsNot Nothing Then
                                        With dfX
                                            .Attendence_Status_ID = dtsX.Attendence_Status_ID
                                            .Emp_Bio_Device_Users_UserID = dtsX.Emp_Bio_Device_Users_UserID
                                            .Emp_Bio_Device_User_Enabled = dtsX.Emp_Bio_Device_User_Enabled
                                            .Emp_Bio_Device_User_FacetmpData = dtsX.Emp_Bio_Device_User_FacetmpData
                                            .Emp_Bio_Device_User_Finger = dtsX.Emp_Bio_Device_User_Finger
                                            .Emp_Bio_Device_User_iLength = dtsX.Emp_Bio_Device_User_iLength
                                            .Emp_Bio_Device_User_Name = dtsX.Emp_Bio_Device_User_Name
                                            .Emp_Bio_Device_User_Password = dtsX.Emp_Bio_Device_User_Password
                                            .Emp_Bio_Device_User_Privilege = dtsX.Emp_Bio_Device_User_Privilege
                                            .Emp_Bio_Device_User_tmpData = dtsX.Emp_Bio_Device_User_tmpData
                                            .Emp_ID = dts.Emp_ID
                                        End With
                                        db2X.SaveChanges()
                                    Else
                                        Dim dfNew = New CsmdBioDatabase.Emp_Bio_Device_Users
                                        With dfNew
                                            .Attendence_Status_ID = dtsX.Attendence_Status_ID
                                            .Emp_Bio_Device_Users_UserID = dtsX.Emp_Bio_Device_Users_UserID
                                            .Emp_Bio_Device_User_Enabled = dtsX.Emp_Bio_Device_User_Enabled
                                            .Emp_Bio_Device_User_FacetmpData = dtsX.Emp_Bio_Device_User_FacetmpData
                                            .Emp_Bio_Device_User_Finger = dtsX.Emp_Bio_Device_User_Finger
                                            .Emp_Bio_Device_User_iLength = dtsX.Emp_Bio_Device_User_iLength
                                            .Emp_Bio_Device_User_Name = dtsX.Emp_Bio_Device_User_Name
                                            .Emp_Bio_Device_User_Password = dtsX.Emp_Bio_Device_User_Password
                                            .Emp_Bio_Device_User_Privilege = dtsX.Emp_Bio_Device_User_Privilege
                                            .Emp_Bio_Device_User_tmpData = dtsX.Emp_Bio_Device_User_tmpData
                                            .Emp_ID = dts.Emp_ID
                                        End With
                                        db2X.Emp_Bio_Device_Users.Add(dfNew)
                                        db2X.SaveChanges()
                                    End If
                                End Using
                            Next
                            'MsgBox("Import Done")
                            'Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
                            'Load_cmb_Emp_Report_To.ColumnsAndData(Emp_Report_To)
                            'LoadTile()
                        End If

                    End Using



                Next
                Dim gg = (From a In db.Auto_Number Where a.Auto_ID = 1 Select a).FirstOrDefault
                If gg IsNot Nothing Then
                    Using db2 As New CsmdBioAttendenceEntities
                        Dim hh = (From a In db2.Auto_Number Where a.Auto_ID = 1 Select a).FirstOrDefault
                        If hh IsNot Nothing Then
                            hh.Auto_Emp_Num = gg.Auto_Emp_Num
                            db2.SaveChanges()
                        End If
                    End Using

                End If
                MsgBox("Import Done")
                Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
                Load_cmb_Emp_Report_To.ColumnsAndData(Emp_Report_To)
                LoadTile()
            End If

        End Using
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        Using db As CsmdBioAttendenceEntities1 = New CsmdBioAttendenceEntities1
            Dim dt = (From a In db.Emp_Bio_Device_Users Select a).ToList
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
                        Dim df = (From a In db2.Emp_Bio_Device_Users Where a.Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID Select a).FirstOrDefault
                        If df IsNot Nothing Then

                        Else
                            Dim dfNew = New CsmdBioDatabase.Emp_Bio_Device_Users
                            With dfNew
                                .Attendence_Status_ID = dts.Attendence_Status_ID
                                .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
                                .Emp_Bio_Device_User_Enabled = dts.Emp_Bio_Device_User_Enabled
                                .Emp_Bio_Device_User_FacetmpData = dts.Emp_Bio_Device_User_FacetmpData
                                .Emp_Bio_Device_User_Finger = dts.Emp_Bio_Device_User_Finger
                                .Emp_Bio_Device_User_iLength = dts.Emp_Bio_Device_User_iLength
                                .Emp_Bio_Device_User_Name = dts.Emp_Bio_Device_User_Name
                                .Emp_Bio_Device_User_Password = dts.Emp_Bio_Device_User_Password
                                .Emp_Bio_Device_User_Privilege = dts.Emp_Bio_Device_User_Privilege
                                .Emp_Bio_Device_User_tmpData = dts.Emp_Bio_Device_User_tmpData
                                .Emp_ID = dts.Emp_ID
                            End With
                            db2.Emp_Bio_Device_Users.Add(dfNew)
                            db2.SaveChanges()
                        End If
                    End Using
                Next
                MsgBox("Import Done")
                Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
                Load_cmb_Emp_Report_To.ColumnsAndData(Emp_Report_To)
                LoadTile()
            End If

        End Using
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs)

    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Select a).ToList
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
                    Using db2 As New CsmdBioAttendenceEntities1
                        Dim df = (From a In db2.Employees Where a.Emp_ID = dts.Emp_ID Select a).FirstOrDefault
                        If df IsNot Nothing Then
                            With df
                                .Emp_Address = dts.Emp_Address
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Father = dts.Emp_Father
                                '.Emp_Image = dts.Emp_Image
                                .Emp_Name = dts.Emp_Name
                                .Emp_NIC_No = dts.Emp_NIC_No
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Salary = dts.Emp_Salary
                                .Emp_Status = dts.Emp_Status
                            End With
                            db2.SaveChanges()
                        Else
                            Dim dfNew = New CsmdBioDatabase.Employee
                            With dfNew
                                .Emp_Address = dts.Emp_Address
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Father = dts.Emp_Father
                                '.Emp_Image = dts.Emp_Image
                                .Emp_Name = dts.Emp_Name
                                .Emp_NIC_No = dts.Emp_NIC_No
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Salary = dts.Emp_Salary
                                .Emp_Status = dts.Emp_Status
                            End With
                            db2.Employees.Add(dfNew)
                            db2.SaveChanges()
                        End If
                    End Using

                    Using dbX As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
                        Dim dtX = (From a In dbX.Emp_Bio_Device_Users Where a.Emp_ID = dts.Emp_ID Select a).ToList
                        If dtX.Count > 0 Then
                            'Dim kX As Integer = 0
                            'ProgressBarControl1.Properties.Maximum = dtX.Count
                            'ProgressBarControl1.Properties.Minimum = 0
                            'ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                            'ProgressBarControl1.Position = 0
                            'ProgressBarControl1.Update()
                            For Each dtsX In dtX
                                'ProgressBarControl1.Position = kX
                                'ProgressBarControl1.Update()
                                'k += 1
                                Using db2X As New CsmdBioAttendenceEntities1
                                    Dim dfX = (From a In db2X.Emp_Bio_Device_Users Where a.Emp_Bio_Device_Users_UserID = dtsX.Emp_Bio_Device_Users_UserID Select a).FirstOrDefault
                                    If dfX IsNot Nothing Then
                                        With dfX
                                            .Attendence_Status_ID = dtsX.Attendence_Status_ID
                                            .Emp_Bio_Device_Users_UserID = dtsX.Emp_Bio_Device_Users_UserID
                                            .Emp_Bio_Device_User_Enabled = dtsX.Emp_Bio_Device_User_Enabled
                                            .Emp_Bio_Device_User_FacetmpData = dtsX.Emp_Bio_Device_User_FacetmpData
                                            .Emp_Bio_Device_User_Finger = dtsX.Emp_Bio_Device_User_Finger
                                            .Emp_Bio_Device_User_iLength = dtsX.Emp_Bio_Device_User_iLength
                                            .Emp_Bio_Device_User_Name = dtsX.Emp_Bio_Device_User_Name
                                            .Emp_Bio_Device_User_Password = dtsX.Emp_Bio_Device_User_Password
                                            .Emp_Bio_Device_User_Privilege = dtsX.Emp_Bio_Device_User_Privilege
                                            .Emp_Bio_Device_User_tmpData = dtsX.Emp_Bio_Device_User_tmpData
                                            .Emp_ID = dts.Emp_ID
                                        End With
                                        db2X.SaveChanges()
                                    Else
                                        Dim dfNew = New CsmdBioDatabase.Emp_Bio_Device_Users
                                        With dfNew
                                            .Attendence_Status_ID = dtsX.Attendence_Status_ID
                                            .Emp_Bio_Device_Users_UserID = dtsX.Emp_Bio_Device_Users_UserID
                                            .Emp_Bio_Device_User_Enabled = dtsX.Emp_Bio_Device_User_Enabled
                                            .Emp_Bio_Device_User_FacetmpData = dtsX.Emp_Bio_Device_User_FacetmpData
                                            .Emp_Bio_Device_User_Finger = dtsX.Emp_Bio_Device_User_Finger
                                            .Emp_Bio_Device_User_iLength = dtsX.Emp_Bio_Device_User_iLength
                                            .Emp_Bio_Device_User_Name = dtsX.Emp_Bio_Device_User_Name
                                            .Emp_Bio_Device_User_Password = dtsX.Emp_Bio_Device_User_Password
                                            .Emp_Bio_Device_User_Privilege = dtsX.Emp_Bio_Device_User_Privilege
                                            .Emp_Bio_Device_User_tmpData = dtsX.Emp_Bio_Device_User_tmpData
                                            .Emp_ID = dts.Emp_ID
                                        End With
                                        db2X.Emp_Bio_Device_Users.Add(dfNew)
                                        db2X.SaveChanges()
                                    End If
                                End Using
                            Next
                            'MsgBox("Import Done")
                            'Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
                            'Load_cmb_Emp_Report_To.ColumnsAndData(Emp_Report_To)
                            'LoadTile()
                        End If

                    End Using



                Next
                Dim gg = (From a In db.Auto_Number Where a.Auto_ID = 1 Select a).FirstOrDefault
                If gg IsNot Nothing Then
                    Using db2 As New CsmdBioAttendenceEntities1
                        Dim hh = (From a In db2.Auto_Number Where a.Auto_ID = 1 Select a).FirstOrDefault
                        If hh IsNot Nothing Then
                            hh.Auto_Emp_Num = gg.Auto_Emp_Num
                            db2.SaveChanges()
                        End If
                    End Using

                End If
                MsgBox("Export Done")
                Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
                Load_cmb_Emp_Report_To.ColumnsAndData(Emp_Report_To)
                LoadTile()
            End If

        End Using
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Dim filePath As String = Replace(System.Reflection.Assembly.GetExecutingAssembly().Location, ".exe", "") + ".exe.config"
        Dim objDoc As XDocument = XDocument.Load(filePath)
        Dim conEl = objDoc.Descendants("connectionStrings").Elements().First()
        conEl.Attribute("name").Value = "CsmdBioAttendenceEntities1"
        conEl.Attribute("connectionString").Value = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string='data source=" & sIP.EditValue.ToString & "," & sPort.EditValue.ToString & "; initial catalog=CsmdBioAttendence ;user id=sa; password=123;multipleactiveresultsets=True;application name=EntityFramework;'"
        'conEl.Attribute("connectionString").Value = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\sqlexpress; AttachDbFileName=|DataDirectory|DATA\CsmdTheLeadsSchool.mdf ;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;"
        objDoc.Save(filePath)
        lblStatem.Caption = "Current State: Connected"
        lblStatem.ItemAppearance.Normal.BackColor = Color.LimeGreen
    End Sub



    Private Sub BarButtonItem9_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        Using db As New CsmdBioDatabase.CsmdBioAttendenceEntities
            Dim dts = (From a In db.Employees Where a.Emp_ID = ghj And a.User_ID = CsmdVarible.PlazaUserID Select a).FirstOrDefault
            If dts IsNot Nothing Then
                Dim k As Integer = 1
                ProgressBarControl1.Properties.Maximum = 10
                ProgressBarControl1.Properties.Minimum = 1
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 1
                ProgressBarControl1.Update()
                Using dbO As New CsmdBioAttendenceEntitiesOnline

                    Dim dtGet = (From a In dbO.Employees Where a.Emp_ID = dts.Emp_ID And a.User_ID = dts.User_ID Select a).FirstOrDefault
                    If dtGet IsNot Nothing Then
                        With dtGet
                            .Emp_Reg = dts.Emp_Reg
                            .Emp_Name = dts.Emp_Name
                            .Emp_Pass = dts.Emp_Pass
                            .Emp_Father = dts.Emp_Father
                            .Emp_Phone = dts.Emp_Phone
                            .Emp_Phone2 = dts.Emp_Phone2
                            .Emp_Address = dts.Emp_Address
                            .Emp_Quali = dts.Emp_Quali
                            .Emp_Designation = dts.Emp_Designation
                            .Emp_Report_To = dts.Emp_Report_To
                            .Emp_Date_Hired = dts.Emp_Date_Hired
                            .Emp_Date_Terminated = dts.Emp_Date_Terminated
                            .Emp_Date_ReHired = dts.Emp_Date_ReHired
                            .Emp_Birth_Date = dts.Emp_Birth_Date
                            .Emp_Beg_Balance = dts.Emp_Beg_Balance
                            .Emp_Status = dts.Emp_Status
                            .Emp_DutyOn = dts.Emp_DutyOn
                            .Emp_Duty_Off = dts.Emp_Duty_Off
                            .Emp_Salary = dts.Emp_Salary
                            .User_ID = CInt(dts.User_ID)
                        End With
                        dbO.SaveChanges()
                    Else
                        Dim dtNew = New CsmdOnline.Employee
                        With dtNew
                            'Dim maxID As Integer
                            'Try
                            '    maxID = (From a In db.Employees Where a.User_ID = CsmdVarible.PlazaUserID Select a.Emp_ID).Max + 1
                            'Catch ex As Exception
                            '    maxID = 1
                            'End Try
                            .Emp_ID = dts.Emp_ID
                            .Emp_Reg = dts.Emp_Reg
                            .Emp_Name = dts.Emp_Name
                            .Emp_Pass = dts.Emp_Pass
                            .Emp_Father = dts.Emp_Father
                            .Emp_Phone = dts.Emp_Phone
                            .Emp_Phone2 = dts.Emp_Phone2
                            .Emp_Address = dts.Emp_Address
                            .Emp_Quali = dts.Emp_Quali
                            .Emp_Designation = dts.Emp_Designation
                            .Emp_Report_To = dts.Emp_Report_To
                            .Emp_Date_Hired = dts.Emp_Date_Hired
                            .Emp_Date_Terminated = dts.Emp_Date_Terminated
                            .Emp_Date_ReHired = dts.Emp_Date_ReHired
                            .Emp_Birth_Date = dts.Emp_Birth_Date
                            .Emp_Beg_Balance = dts.Emp_Beg_Balance
                            .Emp_Status = dts.Emp_Status
                            .Emp_DutyOn = dts.Emp_DutyOn
                            .Emp_Duty_Off = dts.Emp_Duty_Off
                            .Emp_Salary = dts.Emp_Salary
                            .User_ID = CInt(dts.User_ID)
                        End With
                        dbO.Employees.Add(dtNew)
                    End If
                    dbO.SaveChanges()
                    GenerateUpload(ghj)
                    ProgressBarControl1.Position = k
                    ProgressBarControl1.Update()
                    k += 1



                    MsgBox("Employees Upload Successfull")
                    'Dim dtO = (From a In dbO.Employees Select a).ToList
                    'If dtO.Count > 0 Then
                    '    GridControl2.DataSource = dtO
                    'End If
                End Using
            End If
        End Using

    End Sub
    Public Sub GenerateUpload(EmpID As Integer)
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            'Dim EmpID As Integer = ghj
            Dim mm As Integer = EmpID * 10
            Dim nn As Integer = mm - 9
            Dim dty = (From a In db.Employees Where a.Emp_ID = EmpID And a.User_ID = CsmdVarible.PlazaUserID Select a).FirstOrDefault
            If dty IsNot Nothing Then
                Dim dt = (From a In db.Attendence_Status Select a).ToList
                If dt.Count > 0 Then
                    Dim kl As Integer = 1
                    ProgressBarControl1.Properties.Maximum = dt.Count
                    ProgressBarControl1.Properties.Minimum = 1
                    ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                    ProgressBarControl1.Position = 1
                    ProgressBarControl1.Update()
                    Dim k As Integer = 0
                    For Each dts In dt
                        Using dbc As New CsmdBioAttendenceEntitiesOnline
                            Dim fg = (From a In dbc.Emp_Bio_Device_Users Where a.Emp_ID = EmpID And a.User_ID = dty.User_ID And a.Attendence_Status_ID = dts.Attendence_Status_ID Select a).FirstOrDefault
                            If fg IsNot Nothing Then
                                With fg
                                    .User_ID = CsmdVarible.PlazaUserID
                                    .Emp_ID = EmpID
                                    .Attendence_Status_ID = dts.Attendence_Status_ID
                                    .Emp_Bio_Device_Users_UserID = nn
                                    .Emp_Bio_Device_User_Name = dty.Emp_Name
                                    '.Emp_Bio_Device_User_Finger = 0
                                    '.Emp_Bio_Device_User_tmpData = ""
                                    '.Emp_Bio_Device_User_Privilege = 0
                                    .Emp_Bio_Device_User_Password = CType(GridView1.GetRowCellValue(k, "Emp_Bio_Device_User_Password"), String)
                                    '.Emp_Bio_Device_User_Enabled = True
                                End With
                                db.SaveChanges()
                            Else
                                Dim dtNew = New CsmdOnline.Emp_Bio_Device_Users
                                With dtNew
                                    .User_ID = dty.User_ID
                                    .Emp_ID = EmpID
                                    .Attendence_Status_ID = dts.Attendence_Status_ID
                                    .Emp_Bio_Device_Users_UserID = nn
                                    .Emp_Bio_Device_User_Name = dty.Emp_Name
                                    .Emp_Bio_Device_User_Finger = 0
                                    .Emp_Bio_Device_User_tmpData = ""
                                    .Emp_Bio_Device_User_FacetmpData = ""
                                    .Emp_Bio_Device_User_iLength = 0
                                    .Emp_Bio_Device_User_Privilege = 0
                                    .Emp_Bio_Device_User_Password = ""
                                    .Emp_Bio_Device_User_Enabled = True
                                End With
                                dbc.Emp_Bio_Device_Users.Add(dtNew)
                                dbc.SaveChanges()
                            End If
                            nn += 1
                            k += 1
                        End Using
                        ProgressBarControl1.Position = kl
                        ProgressBarControl1.Update()
                        kl += 1
                    Next

                End If
            End If

        End Using
    End Sub

    Private Sub BarButtonItem12_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem12.ItemClick
        Using db As New CsmdOnline.CsmdBioAttendenceEntitiesOnline
            Dim dt = (From a In db.Employees Where a.Emp_ID = ghj And a.User_ID = CsmdVarible.PlazaUserID Select a).ToList
            If dt.Count > 0 Then
                Dim k As Integer = 1
                ProgressBarControl1.Properties.Maximum = dt.Count
                ProgressBarControl1.Properties.Minimum = 1
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 1
                ProgressBarControl1.Update()
                Using dbO As New CsmdBioDatabase.CsmdBioAttendenceEntities
                    For Each dts In dt
                        Dim dtGet = (From a In dbO.Employees Where a.Emp_ID = dts.Emp_ID And a.User_ID = dts.User_ID Select a).FirstOrDefault
                        If dtGet IsNot Nothing Then
                            With dtGet
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Name = dts.Emp_Name
                                .Emp_Pass = dts.Emp_Pass
                                .Emp_Father = dts.Emp_Father
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Address = dts.Emp_Address
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Status = dts.Emp_Status
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Salary = dts.Emp_Salary
                                .User_ID = dts.User_ID
                            End With
                            dbO.SaveChanges()
                        Else
                            Dim dtNew = New CsmdBioDatabase.Employee
                            With dtNew
                                Dim maxID As Integer
                                Try
                                    maxID = (From a In dbO.Employees Where a.User_ID = dts.User_ID Select a.Emp_ID).Max + 1
                                Catch ex As Exception
                                    maxID = 1
                                End Try
                                .Emp_ID = maxID
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Name = dts.Emp_Name
                                .Emp_Pass = dts.Emp_Pass
                                .Emp_Father = dts.Emp_Father
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Address = dts.Emp_Address
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Status = dts.Emp_Status
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Salary = dts.Emp_Salary
                                .User_ID = dts.User_ID
                            End With
                            dbO.Employees.Add(dtNew)
                        End If
                        dbO.SaveChanges()
                        GenerateDown()
                        ProgressBarControl1.Position = k
                        ProgressBarControl1.Update()
                        k += 1

                    Next

                    MsgBox("Employees Download Successfull")
                    'Dim dtO = (From a In dbO.Employees Select a).ToList
                    'If dtO.Count > 0 Then
                    '    GridControl2.DataSource = dtO
                    'End If
                End Using
            End If
        End Using

    End Sub
    Public Sub GenerateDown()
        Using db As New CsmdOnline.CsmdBioAttendenceEntitiesOnline
            Dim EmpID As Integer = ghj
            Dim mm As Integer = EmpID * 10
            Dim nn As Integer = mm - 9
            Dim dty = (From a In db.Employees Where a.Emp_ID = EmpID And a.User_ID = CsmdVarible.PlazaUserID Select a).FirstOrDefault
            If dty IsNot Nothing Then
                Dim dt = (From a In db.Attendence_Status Select a).ToList
                If dt.Count > 0 Then
                    Dim kl As Integer = 1
                    ProgressBarControl1.Properties.Maximum = dt.Count
                    ProgressBarControl1.Properties.Minimum = 1
                    ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                    ProgressBarControl1.Position = 1
                    ProgressBarControl1.Update()
                    Dim k As Integer = 0
                    For Each dts In dt
                        Using dbc As New CsmdBioDatabase.CsmdBioAttendenceEntities
                            Dim fg = (From a In dbc.Emp_Bio_Device_Users Where a.Emp_ID = EmpID And a.Attendence_Status_ID = dts.Attendence_Status_ID Select a).FirstOrDefault
                            If fg IsNot Nothing Then
                                With fg
                                    .Emp_ID = EmpID
                                    .Attendence_Status_ID = dts.Attendence_Status_ID
                                    .Emp_Bio_Device_Users_UserID = nn
                                    .Emp_Bio_Device_User_Name = dty.Emp_Name
                                    '.Emp_Bio_Device_User_Finger = 0
                                    '.Emp_Bio_Device_User_tmpData = ""
                                    '.Emp_Bio_Device_User_Privilege = 0
                                    .Emp_Bio_Device_User_Password = CType(GridView1.GetRowCellValue(k, "Emp_Bio_Device_User_Password"), String)
                                    '.Emp_Bio_Device_User_Enabled = True
                                End With
                                db.SaveChanges()
                            Else
                                Dim dtNew = New CsmdBioDatabase.Emp_Bio_Device_Users
                                With dtNew
                                    .Emp_ID = EmpID
                                    .Attendence_Status_ID = dts.Attendence_Status_ID
                                    .Emp_Bio_Device_Users_UserID = nn
                                    .Emp_Bio_Device_User_Name = dty.Emp_Name
                                    .Emp_Bio_Device_User_Finger = 0
                                    .Emp_Bio_Device_User_tmpData = ""
                                    .Emp_Bio_Device_User_FacetmpData = ""
                                    .Emp_Bio_Device_User_iLength = 0
                                    .Emp_Bio_Device_User_Privilege = 0
                                    .Emp_Bio_Device_User_Password = ""
                                    .Emp_Bio_Device_User_Enabled = True
                                End With
                                dbc.Emp_Bio_Device_Users.Add(dtNew)
                                dbc.SaveChanges()
                            End If
                            nn += 1
                            k += 1
                        End Using
                        ProgressBarControl1.Position = kl
                        ProgressBarControl1.Update()
                        kl += 1
                    Next

                End If
            End If

        End Using
    End Sub

    Private Sub BarButtonItem13_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem13.ItemClick
        Using db As New CsmdBioAttendenceEntitiesOnline
            Dim dts = (From a In db.Employees Where a.Emp_ID = ghj And a.User_ID = CsmdVarible.PlazaUserID Select a).FirstOrDefault
            If dts IsNot Nothing Then
                Dim dtGet = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = dts.Emp_ID And a.User_ID = dts.User_ID Select a).ToList
                If dtGet.Count > 0 Then
                    For Each df In dtGet
                        db.Emp_Bio_Device_Users.Remove(df)
                    Next
                    db.SaveChanges()
                End If
                db.Employees.Remove(dts)
                db.SaveChanges()
                MsgBox("Employees Delete from Web Server Successfull")
            End If
        End Using
    End Sub

    Private Sub Emp_Name_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Name.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Father.Focus()
        End If
        If e.KeyCode = Keys.Control AndAlso e.KeyCode = Keys.U Then
            If frmMain.TabX1.ActiveDocument.ControlName = CsmdFrm.frmEmployeesAdd And CsmdFrm.frmEmployeesAdd = CsmdFrm.frmEmployeesAddX Then
                Dim frm As frmEmployeesAdds = CType(frmMain.Dcm1.View.ActiveDocument.Form, frmEmployeesAdds)
                frm.BarButtonItem2.PerformClick()
            End If
        End If
    End Sub

    Private Sub Emp_Father_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Father.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Quali.Focus()
        End If
    End Sub

    Private Sub Emp_Quali_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Quali.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Designation_ID.Focus()
        End If
    End Sub

    Private Sub Emp_Designation_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Designation_ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Birth_Date.Focus()
        End If
    End Sub

    Private Sub Emp_Birth_Date_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Birth_Date.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_NIC_No.Focus()
        End If
    End Sub

    Private Sub Emp_NIC_No_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_NIC_No.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Phone.Focus()
        End If
    End Sub

    Private Sub Emp_Phone_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Phone.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Phone2.Focus()
        End If
    End Sub

    Private Sub Emp_Phone2_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Phone2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Address_ID.Focus()
        End If
    End Sub

    Private Sub Emp_Address_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Address_ID.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Report_To.Focus()
        End If
    End Sub

    Private Sub Emp_Report_To_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Report_To.KeyDown
        If e.KeyCode = Keys.Enter Then
            Emp_Salary.Focus()
        End If
    End Sub

    Private Sub Emp_Salary_KeyDown(sender As Object, e As KeyEventArgs) Handles Emp_Salary.KeyDown
        If e.KeyCode = Keys.Enter Then
            BarButtonItem3.PerformClick()
            Emp_Name.Focus()
        End If
    End Sub

    Private Sub frmEmployeesAdds_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        'If e.KeyCode = Keys.Control Then
        '    BarButtonItem2.PerformClick()
        '    Emp_Name.Focus()
        'End If

    End Sub

    Private Sub RibbonControl1_KeyDown(sender As Object, e As KeyEventArgs) Handles RibbonControl1.KeyDown
        If e.KeyCode = Keys.U Then
            If frmMain.TabX1.ActiveDocument.ControlName = CsmdFrm.frmEmployeesAdd And CsmdFrm.frmEmployeesAdd = CsmdFrm.frmEmployeesAddX Then
                Dim frm As frmEmployeesAdds = CType(frmMain.Dcm1.View.ActiveDocument.Form, frmEmployeesAdds)
                frm.BarButtonItem2.PerformClick()
            End If
        End If
    End Sub



#End Region

End Class


