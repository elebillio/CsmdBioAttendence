'Imports System.Data.Entity.SqlServer
Public Class frmAttReporstEdit
    Dim EmpID As Integer
    Dim Load_Attendence_Status_LookUpEdit As New Attendence_Status_LookUpEdit

    Private Sub frmAttReporstEdit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmAttReports.LoadAtt(intEmpID, frmAttReports.FromDate.EditValue)
    End Sub
    Private Sub frmAttReporstEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        Load_Attendence_Status_LookUpEdit.ColumnsAndData(LookUpEdit1)
        Load_Attendence_Status_LookUpEdit.ColumnsAndData(LookUpEdit2)
        'TextEdit1.Properties.ReadOnly = False
        'TextEdit2.Properties.ReadOnly = False
        TextEdit1.Time = Nothing
        TextEdit2.Time = Nothing
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = intPngID Select a).FirstOrDefault
            If dt IsNot Nothing Then
                EmpID = dt.Emp_ID
                Emp_Name.Text = dt.Employee.Emp_Name
                DateEdit1.EditValue = dt.Emp_Attendence_Device_Date
                Select Case dt.Attendence_Status_ID
                    Case 1
                        LookUpEdit1.EditValue = 1
                        LookUpEdit2.EditValue = 2
                        TextEdit1.Time = dt.Emp_Attendence_Device_Time
                        'MsgBox(dt.Emp_Attendence_Device_Time)
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 2 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit2.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit2.Time = Nothing
                        End If
                    Case 2
                        LookUpEdit1.EditValue = 1
                        LookUpEdit2.EditValue = 2
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 1 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit1.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit1.Time = Nothing
                        End If
                        TextEdit2.Time = dt.Emp_Attendence_Device_Time
                    Case 3
                        LookUpEdit1.EditValue = 3
                        LookUpEdit2.EditValue = 4
                        TextEdit1.Time = dt.Emp_Attendence_Device_Time
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 4 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit2.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit2.Time = Nothing
                        End If
                    Case 4
                        LookUpEdit1.EditValue = 3
                        LookUpEdit2.EditValue = 4
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 3 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit1.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit1.Time = Nothing
                        End If
                        TextEdit2.Time = dt.Emp_Attendence_Device_Time
                    Case 5
                        LookUpEdit1.EditValue = 5
                        LookUpEdit2.EditValue = 6
                        TextEdit1.Time = dt.Emp_Attendence_Device_Time
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 6 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit2.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit2.Time = Nothing
                        End If
                    Case 6
                        LookUpEdit1.EditValue = 5
                        LookUpEdit2.EditValue = 6
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 5 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit1.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit1.Time = Nothing
                        End If
                        TextEdit2.Time = dt.Emp_Attendence_Device_Time
                    Case 7
                        LookUpEdit1.EditValue = 7
                        LookUpEdit2.EditValue = 8
                        TextEdit1.Time = dt.Emp_Attendence_Device_Time
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 8 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit2.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit2.Time = Nothing
                        End If
                    Case 8
                        LookUpEdit1.EditValue = 7
                        LookUpEdit2.EditValue = 8
                        Dim dtx = (From a In db.Emp_Attendence_Device Where a.Emp_ID = dt.Emp_ID And a.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And a.Attendence_Status_ID = 7 Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit1.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit1.Time = Nothing
                        End If
                        TextEdit2.Time = dt.Emp_Attendence_Device_Time
                    Case 9
                        LookUpEdit1.EditValue = 9
                        LookUpEdit2.EditValue = 10
                        TextEdit1.Time = dt.Emp_Attendence_Device_Time
                        'Dim dddd As String = Format(CDate(dt.Emp_Attendence_Device_Time), "HH:mm")
                        'Dim ddx As TimeSpan = TimeSpan.Parse(dddd)
                        ''MsgBox(ddx.ToString)
                        Dim dtx = (From a In db.Emp_Attendence_Device.Where(Function(o) o.Emp_Attendence_Device_Time >= dt.Emp_Attendence_Device_Time And o.Emp_ID = dt.Emp_ID And o.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And o.Attendence_Status_ID = 10) Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit2.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit2.Time = Nothing
                        End If
                    Case 10
                        LookUpEdit1.EditValue = 9
                        LookUpEdit2.EditValue = 10
                        Dim dtx = (From a In db.Emp_Attendence_Device.Where(Function(o) o.Emp_Attendence_Device_Time <= dt.Emp_Attendence_Device_Time And o.Emp_ID = dt.Emp_ID And o.Emp_Attendence_Device_Date = dt.Emp_Attendence_Device_Date And o.Attendence_Status_ID = 9) Select a).FirstOrDefault
                        If dtx IsNot Nothing Then
                            TextEdit1.Time = dtx.Emp_Attendence_Device_Time
                        Else
                            TextEdit1.Time = Nothing
                        End If
                        TextEdit2.Time = dt.Emp_Attendence_Device_Time
                End Select

            End If
        End Using
    End Sub


    Private Sub TextEdit1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEdit1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Using db As New CsmdBioAttendenceEntities
                TextEdit3.Focus()
                Dim ids As Integer = LookUpEdit1.EditValue
                Dim dtx As Date = DateEdit1.EditValue
                Dim tim As String = TextEdit1.Text
                Dim dt = (From a In db.Emp_Attendence_Device.Where(Function(o) o.Emp_Attendence_Device_Time = tim And o.Emp_ID = EmpID And o.Emp_Attendence_Device_Date = dtx And o.Attendence_Status_ID = ids) Select a).FirstOrDefault
                If dt IsNot Nothing Then
                    dt.Emp_Attendence_Device_Time = tim.ToString
                Else
                    Dim dtNew = New Emp_Attendence_Device
                    With dtNew
                        .Emp_ID = EmpID
                        .Attendence_Status_ID = ids
                        .Emp_Attendence_Device_Date = dtx.ToString("dd-MMM-yyyy").ToString
                        .Emp_Attendence_Device_Time = tim.ToString
                        'Select Case ids
                        '    Case 1, 2
                        '        .Emp_Attendence_Device_Cal2 = TextEdit3.Text
                        '    Case 3, 4, 5, 6, 7, 8, 9, 10
                        '        .Emp_Attendence_Device_Cal1 = TextEdit3.Text
                        'End Select
                    End With
                    db.Emp_Attendence_Device.Add(dtNew)
                End If
                db.SaveChanges()
                Me.Close()
            End Using
        End If

    End Sub


    Private Sub TextEdit2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextEdit2.KeyDown
        If e.KeyCode = Keys.Enter Then
            Using db As New CsmdBioAttendenceEntities
                TextEdit3.Focus()
                Dim ids As Integer = LookUpEdit2.EditValue
                Dim dtx As Date = DateEdit1.EditValue
                Dim tim As String = TextEdit2.Text
                Dim dt = (From a In db.Emp_Attendence_Device.Where(Function(o) o.Emp_Attendence_Device_Time = tim And o.Emp_ID = EmpID And o.Emp_Attendence_Device_Date = dtx And o.Attendence_Status_ID = ids) Select a).FirstOrDefault
                If dt IsNot Nothing Then
                    With dt
                        .Emp_Attendence_Device_Time = tim.ToString
                        Select Case ids
                            Case 1, 2
                                .Emp_Attendence_Device_Cal2 = TextEdit3.Text
                            Case 3, 4, 5, 6, 7, 8, 9, 10
                                .Emp_Attendence_Device_Cal1 = TextEdit3.Text
                        End Select
                    End With
                Else
                    Dim dtNew = New Emp_Attendence_Device
                    With dtNew
                        .Emp_ID = EmpID
                        .Attendence_Status_ID = ids
                        .Emp_Attendence_Device_Date = dtx.ToString("dd-MMM-yyyy").ToString
                        .Emp_Attendence_Device_Time = tim.ToString
                        Select Case ids
                            Case 1, 2
                                .Emp_Attendence_Device_Cal2 = TextEdit3.Text
                            Case 3, 4, 5, 6, 7, 8, 9, 10
                                .Emp_Attendence_Device_Cal1 = TextEdit3.Text
                        End Select
                    End With
                    db.Emp_Attendence_Device.Add(dtNew)
                End If
                db.SaveChanges()
                Me.Close()
            End Using
        End If

    End Sub
    Private Sub TextEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit1.EditValueChanged
        Dim aa As DateTime = CDate(If(TextEdit1.Text = "", "00:00", TextEdit1.Text))  '.TimeOfDay.ToString
        Dim bb As DateTime = CDate(If(TextEdit2.Text = "", "00:00", TextEdit2.Text))
        Dim duration As Integer = DateDiff(DateInterval.Minute, aa, bb)
        TextEdit3.Text = duration
    End Sub
    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles TextEdit2.EditValueChanged
        Dim aa As DateTime = CDate(If(TextEdit1.Text = "", "00:00", TextEdit1.Text))  '.TimeOfDay.ToString
        Dim bb As DateTime = CDate(If(TextEdit2.Text = "", "00:00", TextEdit2.Text))
        Dim duration As Integer = DateDiff(DateInterval.Minute, aa, bb)
        TextEdit3.Text = duration
    End Sub
    Private Sub TextEdit1_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles TextEdit1.EditValueChanging

    End Sub
    Private Sub TextEdit2_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles TextEdit2.EditValueChanging

    End Sub
End Class