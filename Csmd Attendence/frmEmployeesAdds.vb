﻿

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

Public Class frmEmployeesAdds

    Dim db As New CsmdBioAttendenceEntities
    Dim Load_cmb_Employee_Search_Look As New cmb_Employee_Search_Look
    Dim Load_cmb_Emp_Report_To As New cmb_Emp_Report_To
    Dim ghj As Integer
    <DllImport("kernel32")>
    Public Shared Function Beep(ByVal dwFreg As Integer, ByVal dwDuration As Integer) As Integer
    End Function

#Region "EMPLOYEES MODIFIED VIEWER UserControl1_LOAD"
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles Me.Load
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
        Using Db As New CsmdBioAttendenceEntities
            Dim hh = (From a In Db.Employees Where a.Emp_Reg = Emp_Reg.Text Select a).FirstOrDefault
            If hh IsNot Nothing Then
                LoadTeachersRecords(hh.Emp_ID)
            End If
        End Using
    End Sub
#End Region
#Region "EMPLOYEES RECORDS SAVE AND UPDATE FUNCTION"
    Public Sub SaveAndUpdateData()
        Using db As New CsmdBioAttendenceEntities
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
                        .Emp_Image = ImgToByteArray(Emp_Image.Image, ImageFormat.Png)
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
                        .User_ID = PlazaUserID
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
                    Dim TeaNew = New Employee
                    With TeaNew
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
                        .Emp_Image = ImgToByteArray(Emp_Image.Image, ImageFormat.Png)
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
                        .User_ID = PlazaUserID
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
        Using db As New CsmdBioAttendenceEntities
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
                        Emp_Image.Image = DbToImg(.Emp_Image)
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
                        TileEle.Image = DbToImg(dts.Emp_Image)
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
        Using db As New CsmdBioAttendenceEntities
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
        Using db As New CsmdBioAttendenceEntities
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
        Using db As New CsmdBioAttendenceEntities
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
                            Dim dtNew = New Emp_Bio_Device_Users
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

        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            'For idwFingerIndex = 0 To 9
            Using db As New CsmdBioAttendenceEntities
                If axCZKEM1.GetUserTmpExStr(iMachineNumber, idwEnrollNumber, 0, iFlag, sTmpData, iTmpLength) Then 'get the corresponding templates string and length from the memory



                    Dim ddd As Integer = If(CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)) = 0, 10, CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)))
                    Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = EmpID And a.Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?) Select a).FirstOrDefault
                    If fg IsNot Nothing Then
                        With fg
                            .Emp_ID = EmpID
                            .Attendence_Status_ID = ddd
                            .Emp_Bio_Device_User_Name = sName
                            .Emp_Bio_Device_User_Finger = 0
                            .Emp_Bio_Device_User_tmpData = sTmpData
                            .Emp_Bio_Device_User_Privilege = iPrivilege
                            .Emp_Bio_Device_User_Password = sPassword
                            .Emp_Bio_Device_User_Enabled = bEnabled
                        End With
                        db.SaveChanges()
                        'Else
                        '    Dim dtNew = New Emp_Bio_Device_Users
                        '    With dtNew
                        '        .Emp_ID = EmpID
                        '        .Attendence_Status_ID = ddd
                        '        .Emp_Bio_Device_Users_UserID = CInt(idwEnrollNumber)
                        '        .Emp_Bio_Device_User_Name = sName
                        '        .Emp_Bio_Device_User_Finger = idwFingerIndex
                        '        .Emp_Bio_Device_User_tmpData = sTmpData
                        '        .Emp_Bio_Device_User_Privilege = iPrivilege
                        '        .Emp_Bio_Device_User_Password = sPassword
                        '        .Emp_Bio_Device_User_Enabled = bEnabled
                        '    End With
                        '    db.Emp_Bio_Device_Users.Add(dtNew)
                        '    db.SaveChanges()
                    End If


                End If

            End Using
            'Next
        End While
        axCZKEM1.EnableDevice(iMachineNumber, False)
        Cursor = Cursors.WaitCursor
        'axCZKEM1.BatchUpdate(iMachineNumber) 'download all the information in the memory
        'axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed

        '    axCZKEM1.EnableDevice(iMachineNumber, True)

        axCZKEM1.BeginBatchUpdate(iMachineNumber, 1) 'create memory space for batching data
        axCZKEM1.ReadAllUserID(iMachineNumber) 'read all the user information to the memory
        axCZKEM1.ReadAllTemplate(iMachineNumber)
        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, idwEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            'For idwFingerIndex = 0 To 9
            Using db As New CsmdBioAttendenceEntities

                If axCZKEM1.GetUserFaceStr(iMachineNumber, idwEnrollNumber, iFaceIndex, sFaceTmpData, iLength) Then 'get the corresponding templates string and length from the memory



                    Dim ddd As Integer = If(CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)) = 0, 10, CInt(Microsoft.VisualBasic.Right(idwEnrollNumber.ToString, 1)))
                    Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = EmpID And a.Emp_Bio_Device_Users_UserID = CType(idwEnrollNumber, Integer?) Select a).FirstOrDefault
                    If fg IsNot Nothing Then
                        With fg
                            .Emp_ID = EmpID
                            .Attendence_Status_ID = ddd
                            .Emp_Bio_Device_User_Name = sName
                            ' .Emp_Bio_Device_User_Finger = 0
                            .Emp_Bio_Device_User_FacetmpData = sFaceTmpData
                            '.Emp_Bio_Device_User_Privilege = iPrivilege
                            .Emp_Bio_Device_User_iLength = iLength
                            '.Emp_Bio_Device_User_Password = sPassword
                            .Emp_Bio_Device_User_Enabled = bEnabled
                        End With
                        db.SaveChanges()
                        'Else
                        '    Dim dtNew = New Emp_Bio_Device_Users
                        '    With dtNew
                        '        .Emp_ID = EmpID
                        '        .Attendence_Status_ID = ddd
                        '        .Emp_Bio_Device_Users_UserID = CInt(idwEnrollNumber)
                        '        .Emp_Bio_Device_User_Name = sName
                        '        .Emp_Bio_Device_User_Finger = idwFingerIndex
                        '        .Emp_Bio_Device_User_tmpData = sTmpData
                        '        .Emp_Bio_Device_User_Privilege = iPrivilege
                        '        .Emp_Bio_Device_User_Password = sPassword
                        '        .Emp_Bio_Device_User_Enabled = bEnabled
                        '    End With
                        '    db.Emp_Bio_Device_Users.Add(dtNew)
                        '    db.SaveChanges()
                    End If


                End If
            End Using
            'Next
        End While
        'lvDownload.EndUpdate()
        axCZKEM1.BatchUpdate(iMachineNumber) 'download all the information in the memory
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        axCZKEM1.EnableDevice(iMachineNumber, True)
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
        Dim iFingerIndex As Integer = 0 'Convert.ToInt32(cbFingerIndex.Text.Trim())
        'Dim EmpID As String = tx1.Text
        Cursor = Cursors.WaitCursor

        If MsgBox("Delete FingerPrint and Face? Click YES, or Only Delete Face? Click NO", vbYesNoCancel, "Delete Msg") = MsgBoxResult.Yes Then
            If axCZKEM1.SSR_DelUserTmpExt(iMachineNumber, iUserID, iFingerIndex) = True Then
                axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                MsgBox("DelUserTmp,UserID:" + iUserID.ToString() + " FingerIndex:" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Success")
                Using db As New CsmdBioAttendenceEntities
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
                Using db As New CsmdBioAttendenceEntities
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
        ElseIf MsgBox("Delete Face? Click NO", vbYesNoCancel, "Delete Msg") = MsgBoxResult.yes Then
            If axCZKEM1.DelUserFace(iMachineNumber, iUserID, iFingerIndex) = True Then
                axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
                MsgBox("DelUserTmp,UserID:" + iUserID.ToString() + " Face:" + iFingerIndex.ToString(), MsgBoxStyle.Information, "Success")
                Using db As New CsmdBioAttendenceEntities
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
#End Region

End Class

