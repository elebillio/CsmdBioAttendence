Imports System.Data.SqlClient
Imports CsmdBioDatabase
Imports DevExpress.XtraEditors.Controls

Public Class DataUploader
    Private Sub DataUploader_Load(sender As Object, e As EventArgs) Handles Me.Load
        aa(CsmdConOnline.ddd, CsmdConOnline.kkk)
    End Sub
    Public Sub aa(DateX As Date, EmpID As Integer)
        Using DBCon1 As New SqlConnection(CsmdCon.ConSqlDB)
            Dim dat As Date = CDate(DateX)
            Dim idd As Integer = CInt(EmpID)
            Dim da1 As SqlDataAdapter = New SqlDataAdapter("SELECT * " &
                                                           "FROM dbo.Emp_Attendence_Device inner join Employees on dbo.Emp_Attendence_Device.Emp_ID=Employees.Emp_ID " &
"WHERE (dbo.Emp_Attendence_Device.Emp_ID=" & idd & ") and (datepart(month, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date) = " & dat.Date.ToString("MM") & ") " &
" AND (datepart(year, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date) = " & dat.Date.ToString("yyyy") & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') and Employees.Emp_Status='true'", DBCon1)



            Dim ds1 As New DataSet()
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                    'Dim k As Integer = 1
                    'ProgressBarControl1.Properties.Maximum = ds1.Tables(0).Rows.Count
                    'ProgressBarControl1.Properties.Minimum = 1
                    'ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                    'ProgressBarControl1.Position = 1
                    'ProgressBarControl1.Update()
                    ProgressBar1.Maximum = ds1.Tables(0).Rows.Count
                    ProgressBar1.Value = 0
                    ProgressBar1.Step = 1
                    Dim Crt_User As String = ""
                    Dim connection As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                    For Each dts As DataRow In ds1.Tables(0).Rows
                        'ProgressBarControl1.Position = k
                        'ProgressBarControl1.Update()
                        'ProgressBar1.Value = ProgressBar1.Value + 1
                        ProgressBar1.PerformStep()
                        'k += 1
                        Dim devID As Integer = CInt(dts.Item("Emp_Attendence_Device_ID"))


                        Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT * " &
                                                                           "FROM dbo.Emp_Attendence_Device " &
                "WHERE (dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID = " & devID & ")", DBCon2)


                        Dim ds2 As New DataSet()
                        da2.Fill(ds2)
                        If ds2.Tables(0).Rows.Count > 0 Then


                        Else
                            'Try
                            Crt_User = " INSERT INTO Emp_Attendence_Device " &
                                                               " (Emp_Attendence_Device_ID, " &
                                                               " Emp_Bio_Device_Users_UserID, " &
                                                               " Attendance_Duty_Status_ID, " &
                                                               " Emp_ID, " &
                                                               " Emp_Attendence_Device_Duty_On_Off, " &
                                                               " Emp_Attendence_Device_Cal1, " &
                                                               " Emp_Attendence_Device_Cal2, " &
                                                               " Emp_Attendence_Device_Cal3, " &
                                                               " Emp_Attendence_Device_Cal4, " &
                                                               " Emp_Attendence_Device_Cal5, " &
                                                               " Emp_Attendence_Device_Cal6, " &
                                                               " Emp_Attendence_Device_Cal7, " &
                                                               " Emp_Attendence_Device_DateTime, " &
                                                               " Emp_Attendence_Device_Date, " &
                                                               " Emp_Attendence_Device_Day, " &
                                                               " Emp_Attendence_Device_Time, " &
                                                               " Emp_Attendence_Device_Status) " &
                                                               "  VALUES  " &
                                                               " (" & CInt(dts.Item("Emp_Attendence_Device_ID")) &
                                                                   "," & If(Not IsDBNull(dts.Item("Emp_Bio_Device_Users_UserID")), dts.Item("Emp_Bio_Device_Users_UserID"), "NULL") & ", " &
                                                            "" & If(Not IsDBNull(dts.Item("Attendance_Duty_Status_ID")), dts.Item("Attendance_Duty_Status_ID"), "NULL") &
                                                                "," & If(Not IsDBNull(dts.Item("Emp_ID")), dts.Item("Emp_ID"), "NULL") & ", " &
                                                             " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Duty_On_Off")), CStr(dts.Item("Emp_Attendence_Device_Duty_On_Off")), "") & "', " &
                                                               " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal1")), CStr(dts.Item("Emp_Attendence_Device_Cal1")), "") & "', " &
                                                              " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal2")), CStr(dts.Item("Emp_Attendence_Device_Cal2")), "") & "', " &
                                                              " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal3")), CStr(dts.Item("Emp_Attendence_Device_Cal3")), "") & "', " &
                                                              " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal4")), CStr(dts.Item("Emp_Attendence_Device_Cal4")), "") & "', " &
                                                              " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal5")), CStr(dts.Item("Emp_Attendence_Device_Cal5")), "") & "', " &
                                                              " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal6")), CStr(dts.Item("Emp_Attendence_Device_Cal6")), "") & "', " &
                                                              " '" & If(Not IsDBNull(dts.Item("Emp_Attendence_Device_Cal7")), CStr(dts.Item("Emp_Attendence_Device_Cal7")), "") & "', " &
                                                              " '" & CDate(dts.Item("Emp_Attendence_Device_DateTime")).ToString("yyyy/MM/dd HH:mm:ss") & "', " &
                                                               " '" & CDate(dts.Item("Emp_Attendence_Device_Date")).ToString("yyyy/MM/dd") & "', " &
                                                               " '" & CDate(dts.Item("Emp_Attendence_Device_Day")).ToString("yyyy/MM/dd") & "', " &
                                                               " '" & CDate(dts.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "', " &
                                                               " '" & CBool(dts.Item("Emp_Attendence_Device_Status")) & "')"
                            Dim SqldataSet As New DataSet()
                            Dim dataadapter As New SqlDataAdapter
                            Dim cmd As New SqlCommand

                            connection.Open()
                            cmd.Connection = connection
                            'cmd.CommandText = Crt_Login
                            'cmd.ExecuteScalar()
                            cmd.CommandText = Crt_User
                            cmd.ExecuteNonQuery()
                            connection.Close()
                            'Catch ex As Exception
                            '    'MsgBox("Aa")
                            'End Try

                        End If
                        Application.DoEvents()
                    Next
                    DBCon2.Close()
                End Using
            End If
            DBCon1.Close()
        End Using

    End Sub
    Public Sub ProgressBarControl1_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs) Handles ProgressBarControl1.CustomDisplayText
        Dim val As String = e.Value.ToString()
        e.DisplayText = "The progress is: " & val & " of " & ProgressBarControl1.Properties.Maximum
    End Sub
End Class
