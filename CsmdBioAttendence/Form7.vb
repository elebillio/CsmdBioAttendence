Imports DevExpress.XtraEditors

Public Class Form7
    'Dim Load_Attendence_Master_RepositoryItemLookUpEdit As New Attendence_Master_RepositoryItemLookUpEdit
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RepositoryItemTimeEdit1.DisplayFormat.FormatString = "t"
        RepositoryItemTimeEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        RepositoryItemTimeEdit2.DisplayFormat.FormatString = "t"
        RepositoryItemTimeEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

        'Load_Attendence_Master_RepositoryItemLookUpEdit.ColumnsAndData(RepositoryItemLookUpEdit1)

        LoadDB()

    End Sub

    Private Sub RepositoryItemLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemLookUpEdit1.EditValueChanged
        'Dim gg As LookUpEdit = TryCast(sender, LookUpEdit)

        'Dim inn As Integer = gg.EditValue
        'Using db As New CsmdBioAttendenceEntities
        '    Dim EmpID As Integer = GridView1.GetFocusedRowCellValue("ID")
        '    Dim dt = (From a In db.Employees Where a.Emp_ID = EmpID And a.Emp_Status = True Select a).FirstOrDefault
        '    If dt IsNot Nothing Then
        '        dt.Attendence_Master_ID = inn
        '    Else

        '    End If
        '    db.SaveChanges()
        '    LoadDB()
        'End Using


        '.ShiftID = a.Attendence_Master_ID,
        '                  .Shift = a.Attendence_Master.Attendence_Master_Shift,
        '                  .DutyOn = a.Attendence_Master.Attendence_Master_Duty_On,
        '                  .DutyOff = a.Attendence_Master.Attendence_Master_Duty_Off,
        '                  .FridayOff = a.Attendence_Master.Attendence_Master_Friday_Off,
        '                  .CheckIn = a.Attendence_Master.Attendence_Master_Check_In,
        '                  .Prayer = a.Attendence_Master.Attendence_Master_Prayer,
        '                  .ShortLeave = a.Attendence_Master.Attendence_Master_ShortLeave,
        '                  .Lunch = a.Attendence_Master.Attendence_Master_Lunch,
        '                  .Private = a.Attendence_Master.Attendence_Master_Private

    End Sub
    Public Sub LoadDB()
        Using db As New CsmdBioAttendenceEntities
            'Dim dt = (From a In db.Employees
            '          Select New With {.ID = a.Emp_ID, .Reg = a.Emp_Reg, .Name = a.Emp_Name, .Designation = a.Emp_Designation,
            '              a.Emp_DutyOn, a.Emp_Duty_Off}).ToList
            'If dt.Count > 0 Then
            '    GridControl1.DataSource = dt
            '    RepositoryItemDateEdit1.DisplayFormat.FormatString = "t"
            '    RepositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime

            '    GridView1.Columns("Emp_DutyOn").ColumnEdit = RepositoryItemDateEdit1
            '    GridView1.Columns("Emp_Duty_Off").ColumnEdit = RepositoryItemTimeEdit2

            '    GridView1.Columns("Emp_DutyOn").DisplayFormat.FormatString = "t"
            '    GridView1.Columns("Emp_DutyOn").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            '    'GridView1.Columns("ShiftID").Group()
            '    GridView1.ExpandAllGroups()


            'Else
            '    GridControl1.DataSource = Nothing
            'End If
        End Using
    End Sub

    Private Sub RepositoryItemTimeEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemTimeEdit1.EditValueChanged
        'Dim gg As TimeEdit = TryCast(sender, TimeEdit)

        'Dim inn As String = gg.EditValue
        'Using db As New CsmdBioAttendenceEntities
        '    Dim EmpID As Integer = GridView1.GetFocusedRowCellValue("ID")
        '    Dim dt = (From a In db.Employees Where a.Emp_ID = EmpID And a.Emp_Status = True Select a).FirstOrDefault
        '    If dt IsNot Nothing Then
        '        dt.Emp_DutyOn = inn
        '    Else

        '    End If
        '    db.SaveChanges()
        '    'LoadDB()
        'End Using
    End Sub
End Class