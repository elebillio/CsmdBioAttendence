Imports CsmdBioDatabase

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        'LoadData()
    End Sub
    'Public Sub LoadData()
    '    Using db As New CsmdBioAttendenceEntities
    '        Dim dt = (From a In db.Attendance_Target
    '                  Group Join b In db.Attendence_Status On a.Attendance_Target_ID Equals b.Attendance_Target_ID Into z = Group
    '                  From b In z
    '                  Group Join c In db.Emp_Bio_Device_Users.Where(Function(o) o.Emp_ID = 1) On b.Attendence_Status_ID Equals c.Attendence_Status_ID Into x = Group
    '                  From c In x
    '                  Group Join d In db.Emp_Attendence_Device On c.Emp_Bio_Device_Users_UserID Equals d.Emp_Bio_Device_Users_UserID Into y = Group
    '                  From d In y.DefaultIfEmpty()
    '                  Select a.Attendance_Target_ID, a.Attendance_Target_Type, a.Attendance_Target_Status,
    '                      b.Attendence_Status_Finger, c.Emp_Bio_Device_User_Name,
    '                       d.Emp_Attendence_Device_Date, d.Emp_Attendence_Device_Time).ToList
    '        If dt.Count > 0 Then
    '            GridControl1.DataSource = dt
    '        End If
    '    End Using
    'End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmAttendanceLives.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'LoadData()
    End Sub
End Class