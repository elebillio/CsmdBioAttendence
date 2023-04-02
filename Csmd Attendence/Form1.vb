Option Explicit On
Option Strict On
Imports CsmdBioDatabase

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using db As New CsmdBioAttendenceEntities
            Dim idX As Integer = CInt(mK.Text)
            Dim dt = (From a In db.Employees Where a.User_ID = 2 And a.Emp_ID = idX Select a).FirstOrDefault
            If dt IsNot Nothing Then
                Dim df = (From a In dt.Emp_Bio_Device_Users Select a).ToList
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


                Dim dh = (From a In dt.Emp_Att_Payment Select a).ToList
                If dh.Count > 0 Then
                    For Each dhs In dh
                        db.Emp_Att_Payment.Remove(dhs)
                    Next
                End If




                db.Employees.Remove(dt)
                db.SaveChanges()
                MsgBox("Delete Record Successfull")
            Else
                MsgBox("No Records")
            End If
        End Using
    End Sub
End Class