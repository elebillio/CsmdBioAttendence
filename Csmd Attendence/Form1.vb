Imports CsmdBioDatabase

Public Class Form1
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles a1.KeyDown
        If e.KeyCode = Keys.Enter Then
            'b1.Text = CsmdWaFont(a1.Text)
        End If
    End Sub


    Public Sub GetAtt()
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Select a).ToList
            If dt.Count > 0 Then
                For Each dts In dt
                    With dts
                        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        .Emp_Name = "QASIM FAREED"
                        .Emp_Father = "GHULAM FAREED"
                        .Emp_Address = "SUMAILA"
                        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        .Emp_Name = "KINZA SHOKAT"
                        .Emp_Father = "SHOKAT ALI"
                        .Emp_Address = "BAJARANWALA"
                        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        .Emp_Name = "AROOJ SHOKAT"
                        .Emp_Name = "SHOKAT ALI"
                        .Emp_Address = "BAJARANWALA"
                        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
                        .Emp_Name = "IQRA SHEHZADI"
                        .Emp_Father = "JAVEED IQBAL"
                        .Emp_Address = "DING"
                    End With
                Next
            End If
        End Using
    End Sub

End Class