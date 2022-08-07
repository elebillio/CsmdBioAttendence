Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors

Public Class GrisLookupEditLoad

End Class

'Public Class cmb_Emp_Gender_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.Genders Select New With {.ID = a.Gender_ID, .Gender = a.Gender_Type}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "Gender"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Emp_Gender_IDR
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.Properties.DataSource = Nothing
'            Dim dt = (From a In db.Genders Select New With {.ID = a.Gender_ID, .Gender = a.Gender_Type}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Gender"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'                GridLookUpEdit.Properties.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Emp_Nic_Type_ID
'    Public Count_ClassRoomRepos As Integer = 0
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Nic_Type Select New With {.ID = a.Nic_Type_ID, .NicType = a.Nic_Type1}).ToList()
'            If dt.Count() > 0 Then
'                'Count_ClassRoomRepos = dt.Count
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "NicType"
'                GridLookUpEdit.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Emp_Nic_Type_IDR
'    Public Count_ClassRoomRepos As Integer = 0
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Nic_Type Select New With {.ID = a.Nic_Type_ID, .NicType = a.Nic_Type1}).ToList()
'            If dt.Count() > 0 Then
'                'Count_ClassRoomRepos = dt.Count
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "NicType"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Emp_Labour_Type_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.Labour_Type Select New With {.ID = a.Labour_Type_ID, .LabourType = a.Labour_Type1}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "LabourType"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Emp_Labour_Type_IDR
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.Properties.DataSource = Nothing
'            Dim dt = (From a In db.Labour_Type Select New With {.ID = a.Labour_Type_ID, .LabourType = a.Labour_Type1}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "LabourType"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'                GridLookUpEdit.Properties.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Emp_PayRoll_Type_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.PayRoll_Type Select New With {.ID = a.PayRoll_Type_ID, .PayRollType = a.PayRoll_Type1}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "PayRollType"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Emp_PayRoll_Type_IDR
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.Properties.DataSource = Nothing
'            Dim dt = (From a In db.PayRoll_Type Select New With {.ID = a.PayRoll_Type_ID, .PayRollType = a.PayRoll_Type1}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "PayRollType"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'                GridLookUpEdit.Properties.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class

Public Class Attendence_Master_RepositoryItemLookUpEdit
    'Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
    '    Using db As New CsmdBioAttendenceEntities
    '        GridLookUpEdit.DataSource = Nothing
    '        Try
    '            Dim dt = (From a In db.Attendence_Master
    '                      Let shift = "Shift: " + a.Attendence_Master_Shift
    '                      Let aa = "DutyOn: " + a.Attendence_Master_Duty_On
    '                      Let bb = "DutyOff: " + a.Attendence_Master_Duty_Off
    '                      Let cc = "DutyFriOff: " + a.Attendence_Master_Friday_Off
    '                      Select New With {.ID = a.Attendence_Master_ID,
    '                          .Shift = shift}).ToList
    '            If dt.Count() > 0 Then
    '                GridLookUpEdit.DataSource = dt
    '                GridLookUpEdit.DisplayMember = "Shift"
    '                GridLookUpEdit.ValueMember = "ID"
    '                GridLookUpEdit.NullText = "Select Duty Timetable"
    '                GridLookUpEdit.PopulateColumns()
    '                GridLookUpEdit.Columns("ID").Visible = False
    '            End If
    '        Catch ex As NotSupportedException ' 
    '            MsgBox(ex.Message)
    '        End Try
    '        '& " - " & "Duty Fri Off" & ": " & a.Attendence_Master_Friday_Off & " - " & "CheckIn" & ": " & a.Attendence_Master_Check_In & " - " & "Prayer" & ": " & a.Attendence_Master_Prayer & " - " & "ShortLeave" & ": " & a.Attendence_Master_ShortLeave & " - " & "Lunch" & ": " & a.Attendence_Master_Lunch & " - " & "Private" & ": " & a.Attendence_Master_Private

    '    End Using
    'End Sub
End Class

Public Class Employees_RepositoryItemLookUpEdit
    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
        Using db As New CsmdBioAttendenceEntities
            GridLookUpEdit.DataSource = Nothing
            Dim dt = (From a In db.Employees Select New With {.ID = a.Emp_ID, .Name = a.Emp_Name}).ToList
            If dt.Count() > 0 Then
                GridLookUpEdit.DataSource = dt
                GridLookUpEdit.DisplayMember = "Name"
                GridLookUpEdit.ValueMember = "ID"
                GridLookUpEdit.NullText = "Nill"
                GridLookUpEdit.PopulateColumns()
                GridLookUpEdit.Columns("ID").Visible = False
            End If
        End Using
    End Sub
End Class

Public Class Attendence_Status_RepositoryItemLookUpEdit
    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
        Using db As New CsmdBioAttendenceEntities
            GridLookUpEdit.DataSource = Nothing
            Dim dt = (From a In db.Attendence_Status Select New With {.ID = a.Attendence_Status_ID, .Status = a.Attendence_Status_Type}).ToList
            If dt.Count() > 0 Then
                GridLookUpEdit.DataSource = dt
                GridLookUpEdit.DisplayMember = "Status"
                GridLookUpEdit.ValueMember = "ID"
                GridLookUpEdit.NullText = "Total= "
                GridLookUpEdit.PopulateColumns()
                GridLookUpEdit.Columns("ID").Visible = False
            End If
        End Using
    End Sub
End Class
Public Class Attendence_Status_LookUpEdit
    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
        Using db As New CsmdBioAttendenceEntities
            GridLookUpEdit.Properties.DataSource = Nothing
            Dim dt = (From a In db.Attendence_Status Select New With {.ID = a.Attendence_Status_ID, .Status = a.Attendence_Status_Type}).ToList
            If dt.Count() > 0 Then
                GridLookUpEdit.Properties.DataSource = dt
                GridLookUpEdit.Properties.DisplayMember = "Status"
                GridLookUpEdit.Properties.ValueMember = "ID"
                GridLookUpEdit.Properties.NullText = "Nill"
                GridLookUpEdit.Properties.PopulateColumns()
                GridLookUpEdit.Properties.Columns("ID").Visible = False
            End If
        End Using
    End Sub
End Class
'Public Class cmb_Shop_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit, intPlaza As Integer)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.Shops Where a.Floor.Plaza_ID = intPlaza Select New With {.ID = a.Shop_ID, .ShopCode = a.Shop_Code}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "ShopCode"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Customers
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.Customers Select New With {.ID = a.Cus_ID, .Name = a.Cus_Name, .Father = a.Cus_Father}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "Name"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class


'Public Class cmb_Floor
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit, intPlaza As Integer)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.Floors Where a.Plaza_ID = intPlaza Select New With {.ID = a.Floor_ID, .NO = a.Floor_Name}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "NO"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Plaza
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit, intPlaza As Integer)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.Plazas Where a.Plaza_ID = intPlaza Select New With {.ID = a.Plaza_ID, .PlazaName = a.Plaza_Name}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "PlazaName"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Plaza_LookUpEdit
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.Properties.DataSource = Nothing
'            Dim dt = (From a In db.Plazas Select New With {.ID = a.Plaza_ID, .PlazaName = a.Plaza_Name}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "PlazaName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'                GridLookUpEdit.Properties.NullText = "Select"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Shop_Type
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.DataSource = Nothing
'            Dim dt = (From a In db.Shop_Type Select New With {.ID = a.Shop_Type_ID, .Type = a.Shop_Type1}).ToList
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "Type"
'                GridLookUpEdit.ValueMember = "ID"
'                GridLookUpEdit.NullText = "Nill"
'            End If
'        End Using
'    End Sub
'End Class


'Public Class cmb_Rent_Cash_Account
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Chart_Of_Accounts Where a.Chart_Of_Accounts_Type.Accounts_ID = 1 Select New With {.ID = a.Chart_Of_Accounts_ID, .AccountName = a.Chart_Of_Accounts_Description, .Balance = a.Chart_Of_Accounts_Beginning_Balances}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "AccountName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Pay_Roll_Cash_Account
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Chart_Of_Accounts Where a.Chart_Of_Accounts_Type_ID = 1 Select New With {.ID = a.Chart_Of_Accounts_ID, .AccountName = a.Chart_Of_Accounts_Description, .Balance = a.Chart_Of_Accounts_Beginning_Balances}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "AccountName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Emp_Designation
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Designations Select New With {.ID = a.Designation_ID, .Designation = a.Designation_Type}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Designation"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmbGender
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Genders Select New With {.ID = a.Gender_ID, .Gender = a.Gender_Type}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Gender"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Emp_Title_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Emp_Title Select New With {.ID = a.Emp_Title_ID, .Title = a.Emp_Title1}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Title"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmbAddress_Detail
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Addresses Select New With {.ID = a.Stu_Address_ID, .Address = a.Stu_Address_Name & ", " & a.Stu_Address_Detail}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Address"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmbStuNicType
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Nic_Type Select New With {.ID = a.Nic_Type_ID, .NicType = a.Nic_Type1}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "NicType"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

Public Class cmb_Employee_Search_Look
    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Select a.Emp_ID, a.Emp_Reg, a.Emp_Name, a.Emp_Father, a.Emp_Address, Emp_Namess = a.Plaza_User.User_Name, a.Emp_Status).ToList
            If dt.Count > 0 Then
                GridLookUpEdit.Properties.DataSource = dt
                GridLookUpEdit.Properties.DisplayMember = "Emp_Name"
                GridLookUpEdit.Properties.ValueMember = "Emp_ID"
                GridLookUpEdit.Properties.NullText = "Drop Down Search more Student"
            End If
        End Using
    End Sub
End Class

Public Class cmb_Emp_Report_To
    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Where a.Emp_Status = True Select New With {.ID = a.Emp_ID, .Name = a.Emp_Name, .Designation = a.Emp_Designation}).ToList()
            If dt.Count() > 0 Then
                GridLookUpEdit.Properties.DataSource = dt
                GridLookUpEdit.Properties.DisplayMember = "Name"
                GridLookUpEdit.Properties.ValueMember = "ID"
            End If
        End Using
    End Sub
End Class

'Public Class cmb_Emp_Pay_Frequency
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Emp_Pay_Frequency Select New With {.ID = a.Emp_Pay_Frequency_ID, .Frequency = a.Emp_Pay_Frequency_Type}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Frequency"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Emp_Pay_Method
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Emp_Pay_Method Select New With {.ID = a.Emp_Pay_Method_ID, .PayMethod = a.Emp_Pay_Method_Type}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "PayMethod"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Emp_Pay_Method_Default
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit, IDs As Integer)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Emp_Pay_Method_Default Where a.Emp_Pay_Method_ID = IDs Select New With {.ID = a.Emp_Pay_Method_Default_ID, .FieldName = a.Emp_Pay_Salary_Default_FieldName}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "FieldName"
'                GridLookUpEdit.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Chart_Of_Accounts_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Chart_Of_Accounts Select New With {.ID = a.Chart_Of_Accounts_ID, .Account = a.Chart_Of_Accounts_Description, .TypeOfAccount = a.Chart_Of_Accounts_Type.Chart_Of_Accounts_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "Account"
'                GridLookUpEdit.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class Chart_Of_Accounts_ID_RepositoryItemSearchLookUpEdit
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemSearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Chart_Of_Accounts Select New With {.ID = a.Chart_Of_Accounts_ID, .Account = a.Chart_Of_Accounts_Description, .TypeOfAccount = a.Chart_Of_Accounts_Type.Chart_Of_Accounts_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "Account"
'                GridLookUpEdit.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Chart_Of_Accounts
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            'GridLookUpEdit.Properties.View.Columns.Clear()
'            Dim dt = (From a In db.Chart_Of_Accounts Select New With {.ID = a.Chart_Of_Accounts_ID, .AccountName = a.Chart_Of_Accounts_Description}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "AccountName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'                'GridLookUpEdit.Properties.View.Columns("ID").Visible = False
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Sch_Accounts_Default_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            GridLookUpEdit.Properties.View.Columns.Clear()
'            Dim dt = (From a In db.Sch_Accounts_Default Select New With {.ID = a.Sch_Accounts_Default_ID, .DebitAccountName = a.Chart_Of_Accounts.Chart_Of_Accounts_Description, .CreditAccountName = a.Chart_Of_Accounts1.Chart_Of_Accounts_Description}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "DebitAccountName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'                'GridLookUpEdit.Properties.View.Columns("ID").Visible = False
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Sch_Credit_Accounts_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Chart_Of_Accounts Select New With {.ID = a.Chart_Of_Accounts_ID, .AccountName = a.Chart_Of_Accounts_Description}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "AccountName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Unit_Type_ID
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Unit_Type Select New With {.ID = a.Unit_Type_ID, .UnitType = a.Unit_Type1}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "UnitType"
'                GridLookUpEdit.ValueMember = "ID"

'                'GridLookUpEdit.Columns("ID").Visible = False
'            End If
'        End Using
'    End Sub
'End Class



'Public Class cmb_Patient_Search
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Patients Select New With {.ID = a.Patient_ID, .Name = a.Patient_Name, .Father = a.Patient_Father, .GuardianName = a.Patient_Guardian_Name, .GuardianFather = a.Patient_Guardian_Father}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Name"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Patient_Lookup
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Patients Select New With {.ID = a.Patient_ID, .Name = a.Patient_Name, .Father = a.Patient_Father, .GuardianName = a.Patient_Guardian_Name, .GuardianFather = a.Patient_Guardian_Father}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Name"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Drivers_Search
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Drivers Select New With {.ID = a.Driver_ID, .Name = a.Driver_Name, .Father = a.Driver_Father}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Name"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Drivers_Payroll_Search
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Driver_Payroll Select New With {.ID = a.Driver_Payroll_ID, .Name = a.Driver.Driver_Name, .Father = a.Driver.Driver_Father}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Name"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Drivers_Lookup
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Drivers Select New With {.ID = a.Driver_ID, .Name = a.Driver_Name, .Father = a.Driver_Father}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Name"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Driver_Pay_Type_Lookup
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Driver_Pay_Type Select New With {.ID = a.Driver_Pay_Type_ID, .TypeofPay = a.Driver_Pay_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "TypeofPay"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Emb_Calls_Search
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Emb_Calls Select New With {.ID = a.Emb_Calls_ID, .Emergency = a.Emergency.Emergency_Name, .PlateNo = a.Vehicle.Vehicle_Plate_No, .DriverName = a.Driver.Driver_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Emergency"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Vehicle_Detail_Search
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Veh_Fuel_Detail Select New With {.ID = a.Veh_Fuel_Detail_ID, .Invoice = a.Veh_Fuel_Detail_Invoice, .PlateNo = a.Vehicle.Vehicle_Plate_No, .AddedDate = a.Veh_Fuel_Detail_Date}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Invoice"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Veh_Maintinance_Search
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Veh_Maintinance Select New With {.ID = a.Veh_Maintinance_ID, .Invoice = a.Veh_Maintinance_Invoice, .Workshop = a.Veh_Maintinance_Workshop, .AddedDate = a.Veh_Maintinance_Date}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Invoice"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Vehicle_Search
'    Public Sub ColumnsAndData(GridLookUpEdit As SearchLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Vehicles Select New With {.ID = a.Vehicle_ID, .PlateNo = a.Vehicle_Plate_No, .TypeofVeh = a.Veh_Type.Veh_Type_Name, .Company = a.Vehicle_Company, .Model = a.Vehicle_Model, .TypeofFuel = a.Veh_Fuel_Type.Veh_Fuel_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "PlateNo"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Vehicle_Lookup
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Vehicles Select New With {.ID = a.Vehicle_ID, .PlateNo = a.Vehicle_Plate_No, .TypeofVeh = a.Veh_Type.Veh_Type_Name, .Company = a.Vehicle_Company, .Model = a.Vehicle_Model, .TypeofFuel = a.Veh_Fuel_Type.Veh_Fuel_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "PlateNo"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Vehicle_Repos
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Vehicles Select New With {.ID = a.Vehicle_ID, .PlateNo = a.Vehicle_Plate_No, .TypeofVeh = a.Veh_Type.Veh_Type_Name, .Company = a.Vehicle_Company, .Model = a.Vehicle_Model, .TypeofFuel = a.Veh_Fuel_Type.Veh_Fuel_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "PlateNo"
'                GridLookUpEdit.ValueMember = "ID"

'                'GridLookUpEdit.Columns("ID").Visible = False
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Driver_Repos
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Drivers Select New With {.ID = a.Driver_ID, .Name = a.Driver_Name, .Father = a.Driver_Father}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "Name"
'                GridLookUpEdit.ValueMember = "ID"

'                'GridLookUpEdit.Columns("ID").Visible = False
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Veh_Expensee_Type_Lookup
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Veh_Expensee_Type Select New With {.ID = a.Veh_Expensee_Type_ID, .TypeOfExpensee = a.Veh_Expensee_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "TypeOfExpensee"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Veh_Type
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Veh_Type Select New With {.ID = a.Veh_Type_ID, .AccountName = a.Veh_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "AccountName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Veh_Fuel_Type
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Veh_Fuel_Type Select New With {.ID = a.Veh_Fuel_Type_ID, .TypeOfFuel = a.Veh_Fuel_Type_Name, .Mesc = a.Veh_Fuel_Type_Mesc}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "TypeOfFuel"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class


'Public Class cmb_Fuel_Pump
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Fuel_Pump Select New With {.ID = a.Fuel_Pump_ID, .Name = a.Fuel_Pump_Name, .Phone = a.Fuel_Pump_Phone, .Address = a.Fuel_Pump_Address}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Name"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Emergency_Lookup
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Emergencies Select New With {.ID = a.Emergency_ID, .Emergency = a.Emergency_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "Emergency"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class
'Public Class cmb_Hospital_Lookup
'    Public Sub ColumnsAndData(GridLookUpEdit As LookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Hospitals Select New With {.ID = a.Hospital_ID, .HpName = a.Hospital_Name, .Address = a.Hospital_Address, .HpType = a.Hospital_Type_ID}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.Properties.DataSource = dt
'                GridLookUpEdit.Properties.DisplayMember = "HpName"
'                GridLookUpEdit.Properties.ValueMember = "ID"
'            End If
'        End Using
'    End Sub
'End Class

'Public Class cmb_Hospital_Type_Repos
'    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
'        Using db As New CsmdBioAttendenceEntities
'            Dim dt = (From a In db.Hospital_Type Select New With {.ID = a.Hospital_Type_ID, .HpType = a.Hospital_Type_Name}).ToList()
'            If dt.Count() > 0 Then
'                GridLookUpEdit.DataSource = dt
'                GridLookUpEdit.DisplayMember = "HpType"
'                GridLookUpEdit.ValueMember = "ID"

'                'GridLookUpEdit.Columns("ID").Visible = False
'            End If
'        End Using
'    End Sub
'End Class

















