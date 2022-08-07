
Imports System.Runtime.InteropServices
Imports DevExpress.XtraEditors
Imports System.Drawing.Imaging
Imports DevExpress.XtraBars.Navigation
Imports System.Data.SqlClient

Public Class UserControl1

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
            SimpleButton1.Enabled = True
            SimpleButton2.Enabled = False
            SimpleButton3.Enabled = False
            SimpleButton4.Enabled = False
        Else
            LoadTeachersRecords(intMultiFee)
            SearchLookUpEdit1.EditValue = intMultiFee
            SimpleButton2.PerformClick()
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
        SimpleButton1.Enabled = False
        SimpleButton2.Enabled = False
        SimpleButton3.Enabled = True
        SimpleButton4.Enabled = False
        SimpleButton5.Enabled = False
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
            If Emp_Name.EditValue = Nothing Then
                MsgBox("Please Enter a Name of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Name, "Please Enter a Name of this Employee")
                Exit Sub
            ElseIf Emp_Father.EditValue = Nothing Then
                MsgBox("Please Enter a Father's name of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Father, "Please Enter a Father's name of this Employee")
                Exit Sub
            ElseIf Emp_Birth_Date.EditValue = Nothing Then
                MsgBox("Please Enter a BirthDate of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Birth_Date, "Please Enter a BirthDate of this Employee")
                Exit Sub
            ElseIf Emp_Address_ID.EditValue = Nothing Then
                MsgBox("Please Enter a Address of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Address_ID, "Please Enter a Address of this Employee")
                Exit Sub
            ElseIf Emp_DutyOn.EditValue = Nothing Then
                MsgBox("Please Enter a Duty On time of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_DutyOn, "Please Enter a Duty On time of this Employee")
                Exit Sub
            ElseIf Emp_Duty_Off.EditValue = Nothing Then
                MsgBox("Please Enter a Duty Off time of this Employee", vbCritical, "Missing")
                DxErrorProvider1.SetError(Emp_Duty_Off, "Please Enter a Duty Off time of this Employee")
                Exit Sub
            Else

                Dim Tea = (From a In db.Employees Where a.Emp_Reg = Emp_Reg.Text Select a).FirstOrDefault
                If Not IsNothing(Tea) Then
                    With Tea
                        .Emp_Name = Emp_Name.Text
                        .Emp_Father = Emp_Father.Text
                        .Emp_Phone = Emp_Phone.Text
                        .Emp_Phone2 = Emp_Phone2.Text
                        .Emp_Address = Emp_Address_ID.EditValue
                        .Emp_Quali = Emp_Quali.Text
                        .Emp_Designation = Emp_Designation_ID.EditValue
                        .Emp_Date_Hired = Emp_Date_Join.EditValue
                        Try
                            .Emp_Date_Terminated = Emp_Date_Leave.EditValue
                            .Emp_Date_ReHired = Emp_Date_ReHired.EditValue
                        Catch ex As Exception

                        End Try
                        .Emp_Image = ImgToByteArray(Emp_Image.Image, ImageFormat.Png)
                        'Try
                        '    .Emp_Signature = ImgToByteArray(Emp_Signature.Image, ImageFormat.Png)
                        'Catch ex As Exception

                        'End Try
                        .Emp_NIC_No = Emp_NIC_No.EditValue
                        .Emp_Report_To = Emp_Report_To.EditValue
                        .Emp_Birth_Date = Emp_Birth_Date.EditValue
                        .Emp_Status = Emp_Status.Checked

                        .Emp_DutyOn = CStr(CDate(Emp_DutyOn.EditValue).ToString("HH:mm"))
                        .Emp_Duty_Off = CStr(CDate(Emp_Duty_Off.EditValue).ToString("HH:mm"))
                        Dim kkk As String = .Emp_DutyOn
                        .User_ID = PlazaUserID
                        db.SaveChanges()
                    End With
                    XtraMessageBox.Show("Update Employee Successfull")
                    LoadTile()
                    SimpleButton1.Enabled = True
                    SimpleButton2.Enabled = True
                    SimpleButton3.Enabled = False
                    SimpleButton4.Enabled = True
                    SimpleButton5.Enabled = False
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
                        .Emp_Address = Emp_Address_ID.EditValue
                        .Emp_Quali = Emp_Quali.Text
                        .Emp_Designation = Emp_Designation_ID.EditValue
                        .Emp_Date_Hired = Emp_Date_Join.EditValue
                        Try
                            .Emp_Date_Terminated = Emp_Date_Leave.EditValue
                            .Emp_Date_ReHired = Emp_Date_ReHired.EditValue
                        Catch ex As Exception

                        End Try
                        .Emp_Image = ImgToByteArray(Emp_Image.Image, ImageFormat.Png)
                        'Try
                        '    .Emp_Signature = ImgToByteArray(Emp_Signature.Image, ImageFormat.Png)
                        'Catch ex As Exception

                        'End Try
                        .Emp_NIC_No = Emp_NIC_No.EditValue
                        .Emp_Report_To = Emp_Report_To.EditValue
                        .Emp_Birth_Date = Emp_Birth_Date.EditValue
                        .Emp_Status = Emp_Status.Checked
                        .Emp_DutyOn = CStr(CDate(Emp_DutyOn.EditValue).ToString("HH:mm"))
                        .Emp_Duty_Off = CStr(CDate(Emp_Duty_Off.EditValue).ToString("HH:mm"))
                        .User_ID = PlazaUserID
                    End With
                    db.Employees.Add(TeaNew)
                    Dim AddNum = (From a In db.Auto_Number Select a).FirstOrDefault
                    If AddNum IsNot Nothing Then
                        AddNum.Auto_Emp_Num = Replace(Replace(AutoRegisterNumber(), "R-", ""), Microsoft.VisualBasic.Right(Replace(AutoRegisterNumber(), "R-", ""), 3), "")
                    End If
                    db.SaveChanges()
                    XtraMessageBox.Show("Add new Employee Successfull")
                    LoadTile()
                    SimpleButton1.Enabled = True
                    SimpleButton2.Enabled = True
                    SimpleButton3.Enabled = False
                    SimpleButton4.Enabled = True
                    SimpleButton5.Enabled = False
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
            SimpleButton1.Enabled = True
            SimpleButton2.Enabled = True
            SimpleButton3.Enabled = False
            SimpleButton4.Enabled = True
            SimpleButton5.Enabled = False

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
                    Emp_Status.Checked = .Emp_Status
                    Emp_DutyOn.EditValue = .Emp_DutyOn
                    Emp_Duty_Off.EditValue = .Emp_Duty_Off
                    Call LoadEmployeeFingerDetail(.Emp_Name)
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
            LoadTeachersRecords(SearchLookUpEdit1.EditValue)
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
                    item.Elements.Add(New TileItemElement With {.Text = dts.Emp_ID, .TextAlignment = TileItemContentAlignment.TopLeft, .TextLocation = New Point(-50, 0)})

                    item.ItemSize = TileItemSize.Wide
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

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click
        SaveAndUpdateData()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        NewStudentData()
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Load_cmb_Employee_Search_Look.ColumnsAndData(SearchLookUpEdit1)
        LoadTeachersRecords(intMultiFee)
        LoadTile()
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        SimpleButton1.Enabled = False
        SimpleButton2.Enabled = False
        SimpleButton3.Enabled = True
        SimpleButton4.Enabled = False
        SimpleButton5.Enabled = True

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


    Public Sub LoadEmployeeFingerDetail(Namex As String)
        Dim DBCon2 As New OleDb.OleDbConnection(SqlConnectionString2)
        Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.Name, USERINFO.Gender, USERINFO.DEFAULTDEPTID FROM USERINFO WHERE Name='" & Namex & "'", DBCon2)
        Dim ds2 As New DataSet()
        da2.Fill(ds2)

        If ds2.Tables(0).Rows.Count > 0 Then
            GridControl1.DataSource = ds2.Tables(0)
        Else
            GridControl1.DataSource = Nothing
        End If
    End Sub
    Private Sub LoadFormAdmin(EmpID As String)
        'Dim mm As Integer = If(TextBox1.Text = "", 0, TextBox1.Text)
        Dim DBCon4 As New SqlConnection(SqlConnectionString)
        Dim da4 As SqlDataAdapter = New SqlDataAdapter("Select * FROM Employees WHERE Emp_Name='" & EmpID & "'", DBCon4)
        Dim ds4 As New DataSet()
        da4.Fill(ds4)
        Dim MyTableCount4 As Integer = ds4.Tables.Count
        Dim k4 As Integer = 1

        If MyTableCount4 = 1 Then
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            Dim v As Integer = ds4.Tables(0).Rows(0).Item("Emp_ID")
            Dim a As Integer = v * 10
            Dim b As Integer = a - 9
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            Dim DBCon As New SqlConnection(SqlConnectionString)
            Dim da As SqlDataAdapter = New SqlDataAdapter("Select * FROM Attendence_Status", DBCon)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim MyTableCount As Integer = ds.Tables.Count
            Dim k As Integer = 1
            'DataT.Rows.Clear()
            For Each row As DataRow In ds.Tables(0).Rows
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                Dim DBCon2 As New OleDb.OleDbConnection(SqlConnectionString2)
                Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT * FROM USERINFO WHERE DEFAULTDEPTID=" & row.Item("Attendence_Status_Dep") & " and Name='" & ds4.Tables(0).Rows(0).Item("Emp_Name") & "' and Badgenumber='" & b & "'", DBCon2)
                Dim ds2 As New DataSet()
                da2.Fill(ds2)
                Dim MyTableCount2 As Integer = ds2.Tables(0).Rows.Count
                Dim k2 As Integer = 1
                If MyTableCount2 = 0 Then
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    Dim SqldataSet3 As New DataSet()
                    Dim dataadapter3 As New OleDb.OleDbDataAdapter
                    Dim cmd3 As New OleDb.OleDbCommand
                    Dim connection3 As New OleDb.OleDbConnection(SqlConnectionString2)
                    connection3.Open()
                    cmd3.Connection = connection3
                    Dim Crt_User As String = "INSERT INTO USERINFO (Badgenumber,SSN,Name,Gender,DEFAULTDEPTID) VALUES ('" & b & "','" & row.Item("Attendence_Status_Type") & "','" & ds4.Tables(0).Rows(0).Item("Emp_Name") & "','M'," & row.Item("Attendence_Status_Dep") & ")"
                    cmd3.CommandText = Crt_User
                    cmd3.ExecuteNonQuery()
                    connection3.Close()
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                Else
                End If
                DBCon2.Close()
                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                k += 1
                b += 1
            Next row

            DBCon.Close()

            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        End If
        DBCon4.Close()

        LoadEmployeeFingerDetail(Emp_Name.Text)
    End Sub

    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        LoadFormAdmin(Emp_Name.Text)
    End Sub

    Private Sub Emp_DutyOn_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_DutyOn.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    Private Sub Emp_Duty_Off_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Duty_Off.EditValueChanged
        DxErrorProvider1.ClearErrors()
    End Sub

    'Private Sub Emp_DutyOn_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_DutyOn.EditValueChanged
    '    Emp_DutyOn.EditValue = CDate(Emp_DutyOn.EditValue).ToString("HH:mm")
    'End Sub

    'Private Sub Emp_Duty_Off_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Duty_Off.EditValueChanged
    '    Emp_Duty_Off.EditValue = CDate(Emp_Duty_Off.EditValue).ToString("HH:mm")
    'End Sub
End Class

