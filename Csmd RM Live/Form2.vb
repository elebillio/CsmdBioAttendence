Imports CsmdBioDatabase

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LoadData()
    End Sub
    Public Sub LoadData()
        'Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
        '    Dim datem As Date = DateEdit1.EditValue
        '    Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Bio_Device_Users.Emp_ID = 3 And a.Emp_Attendence_Device_Day.Value.Month >= datem.Month And a.Emp_Attendence_Device_Day.Value.Month <= datem.Month And a.Emp_Attendence_Device_Day.Value.Year >= datem.Year And a.Emp_Attendence_Device_Day.Value.Year <= datem.Year
        '              Select a.Emp_Attendence_Device_ID, a.Emp_ID, a.Attendance_Duty_Status_ID, a.Emp_Bio_Device_Users_UserID,
        '                  a.Emp_Attendence_Device_Day, a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_DateTime).ToList
        '    If dt.Count > 0 Then
        '        GridControl1.DataSource = dt
        '    End If
        'End Using
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim datem As Date = DateEdit1.EditValue
            Dim dt = (From a In db.Emp_Attendence_Device Order By a.Emp_Attendence_Device_ID Ascending
                      Select a.Emp_Attendence_Device_ID, a.Emp_ID, a.Attendance_Duty_Status_ID, a.Emp_Bio_Device_Users_UserID,
                          a.Emp_Attendence_Device_Day, a.Emp_Attendence_Device_Date,
                          a.Emp_Attendence_Device_DateTime, a.Emp_Attendence_Device_Status, a.User_ID).ToList
            If dt.Count > 0 Then
                GridControl1.DataSource = dt
            End If
        End Using
        'Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
        '    Dim datem As Date = DateEdit1.EditValue
        '    Dim dt = (From a In db.Emp_Attendence_Device
        '              Select a.Emp_Attendence_Device_ID).Max
        '    'If dt.Count > 0 Then
        '    GridControl1.DataSource = dt
        '    'End If
        'End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            'Dim datem As Date = DateEdit1.EditValue
            'Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = 22744
            '          Select a.Emp_Attendence_Device_ID, a.Emp_ID, a.Attendance_Duty_Status_ID, a.Emp_Bio_Device_Users_UserID,
            '              a.Emp_Attendence_Device_Day, a.Emp_Attendence_Device_Date,
            '              a.Emp_Attendence_Device_DateTime, a.Emp_Attendence_Device_Status).ToList
            'If dt.Count > 0 Then
            '    GridControl1.DataSource = dt
            'End If
            Dim datem As Date = DateEdit1.EditValue
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = 23148 Or a.Emp_Attendence_Device_ID = 23149
                      Select a).FirstOrDefault
            If dt IsNot Nothing Then
                dt.Emp_Attendence_Device_Status = True
                'db.Emp_Attendence_Device.Remove(dt)
                db.SaveChanges()
            End If
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadData()
    End Sub
    Dim iii As Integer
    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        iii = GridView1.GetFocusedRowCellValue("Emp_Attendence_Device_ID")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim datem As Date = DateEdit1.EditValue
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = iii
                      Select a).FirstOrDefault
            If dt IsNot Nothing Then
                db.Emp_Attendence_Device.Remove(dt)
                db.SaveChanges()
            End If
            LoadData()
        End Using
    End Sub
End Class