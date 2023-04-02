Option Explicit On
Option Strict On
Imports CsmdBioDatabase

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using db As New CsmdBioAttendenceEntities
            Dim idX As Integer = CInt(mK.Text)
            Dim dt = (From a In db.Employees Where a.User_ID = 2 Select a).ToList
            If dt.Count > 0 Then
                p1.Minimum = 0
                p1.Maximum = dt.Count - 1
                p1.Value = 0
                For Each dta In dt
                    Dim df = (From a In dta.Emp_Bio_Device_Users Select a).ToList
                    If df.Count > 0 Then
                        For Each dfs In df
                            Dim dg = (From a In dfs.Emp_Attendence_Device Select a).ToList
                            If dg.Count > 0 Then
                                For Each dgs In dg
                                    db.Emp_Attendence_Device.Remove(dgs)
                                Next
                            End If
                            db.Emp_Bio_Device_Users.Remove(dfs)
                        Next
                    End If


                    Dim dh = (From a In dta.Emp_Att_Payment Select a).ToList
                    If dh.Count > 0 Then
                        For Each dhs In dh
                            db.Emp_Att_Payment.Remove(dhs)
                        Next
                    End If
                    Me.Text = dta.Emp_ID & " " & dta.Emp_Name
                    db.Employees.Remove(dta)
                    p1.Value = p1.Value + 1
                    Application.DoEvents()
                Next



                db.SaveChanges()
                MsgBox("Delete Record Successfull")
            Else
                MsgBox("No Records")
            End If
        End Using
    End Sub
End Class