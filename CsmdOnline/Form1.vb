'Option Explicit On
'Option Strict On

Imports System.Data.SqlClient
Imports CsmdBioDatabase
Imports DevExpress.XtraEditors.Controls

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CsmdVarible.PlazaUserID = 2
    End Sub
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.User_Type Select a).ToList
            If dt.Count > 0 Then
                GridControl1.DataSource = dt
            End If
        End Using
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.User_Type Select a).ToList
            If dt.Count > 0 Then
                Using dbO As New CsmdBioAttendenceEntitiesOnline
                    For Each dts In dt
                        Dim dtO = (From a In dbO.User_Type Where a.User_Type_ID = dts.User_Type_ID Select a).FirstOrDefault
                        If dtO IsNot Nothing Then
                            dtO.User_Type1 = dts.User_Type1
                        Else
                            Dim dtNew = New User_Type
                            dtNew.User_Type1 = dts.User_Type1
                            dbO.User_Type.Add(dtNew)
                        End If
                    Next
                    dbO.SaveChanges()
                    SimpleButton2.PerformClick()
                End Using
            End If
        End Using
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        Using db As New CsmdBioDatabase.CsmdBioAttendenceEntities
            Dim dt = (From a In db.Plaza_User Select a).ToList
            If dt.Count > 0 Then
                Using dbO As New CsmdBioAttendenceEntitiesOnline
                    For Each dts In dt
                        Dim dtGet = (From a In dbO.Plaza_User Where a.User_ID = dts.User_ID Select a).FirstOrDefault
                        If dtGet IsNot Nothing Then
                            With dtGet
                                '.User_Name = dts.User_Name
                                '.User_Name = dts.User_Pass
                                '.User_Name = dts.User_Status
                                .User_Type_ID = dts.User_Type_ID
                            End With
                        Else
                            Dim dtNew = New Plaza_User
                            With dtNew
                                .User_Name = dts.User_Name
                                .User_Pass = dts.User_Pass
                                .User_Status = dts.User_Status
                                .User_Type_ID = dts.User_Type_ID
                            End With
                            dbO.Plaza_User.Add(dtNew)
                        End If
                    Next
                    dbO.SaveChanges()
                    Dim dtO = (From a In dbO.Plaza_User Select a).ToList
                    If dtO.Count > 0 Then
                        GridControl2.DataSource = dtO
                    End If
                End Using
            End If
        End Using
    End Sub

    Private Sub SimpleButton4_Click(sender As Object, e As EventArgs) Handles SimpleButton4.Click
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Where a.User_ID = CsmdVarible.PlazaUserID Select a).ToList
            If dt.Count > 0 Then
                Using dbO As New CsmdBioAttendenceEntitiesOnline
                    For Each dts In dt
                        Dim dtGet = (From a In dbO.Employees Where a.User_ID = CsmdVarible.PlazaUserID And a.Emp_ID = dts.Emp_ID Select a).FirstOrDefault
                        If dtGet IsNot Nothing Then
                            With dtGet
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Name = dts.Emp_Name
                                .Emp_Pass = dts.Emp_Pass
                                .Emp_Father = dts.Emp_Father
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Address = dts.Emp_Address
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Status = dts.Emp_Status
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Salary = dts.Emp_Salary
                                .User_ID = dts.User_ID
                            End With
                        Else
                            Dim dtNew = New CsmdOnline.Employee
                            With dtNew
                                'Dim maxID As Integer
                                'Try
                                '    maxID = (From a In dbO.Employees Where a.User_ID = dts.User_ID Select a.Emp_ID).Max + 1
                                'Catch ex As Exception
                                '    maxID = 1
                                'End Try
                                .Emp_ID = dts.Emp_ID
                                .Emp_Reg = dts.Emp_Reg
                                .Emp_Name = dts.Emp_Name
                                .Emp_Pass = dts.Emp_Pass
                                .Emp_Father = dts.Emp_Father
                                .Emp_Phone = dts.Emp_Phone
                                .Emp_Phone2 = dts.Emp_Phone2
                                .Emp_Address = dts.Emp_Address
                                .Emp_Quali = dts.Emp_Quali
                                .Emp_Designation = dts.Emp_Designation
                                .Emp_Report_To = dts.Emp_Report_To
                                .Emp_Date_Hired = dts.Emp_Date_Hired
                                .Emp_Date_Terminated = dts.Emp_Date_Terminated
                                .Emp_Date_ReHired = dts.Emp_Date_ReHired
                                .Emp_Birth_Date = dts.Emp_Birth_Date
                                .Emp_Beg_Balance = dts.Emp_Beg_Balance
                                .Emp_Status = dts.Emp_Status
                                .Emp_DutyOn = dts.Emp_DutyOn
                                .Emp_Duty_Off = dts.Emp_Duty_Off
                                .Emp_Salary = dts.Emp_Salary
                                .User_ID = dts.User_ID
                            End With
                            dbO.Employees.Add(dtNew)
                        End If
                        dbO.SaveChanges()
                    Next

                    Dim dtO = (From a In dbO.Employees Select a).ToList
                    If dtO.Count > 0 Then
                        GridControl2.DataSource = dtO
                    End If
                End Using
            End If
        End Using
    End Sub
    Private Sub SimpleButton6_Click(sender As Object, e As EventArgs) Handles SimpleButton6.Click
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Attendence_Status Select a).ToList
            If dt.Count > 0 Then
                Using dbO As New CsmdBioAttendenceEntitiesOnline
                    For Each dts In dt
                        Dim dtGet = (From a In dbO.Attendence_Status Where a.Attendence_Status_ID = dts.Attendence_Status_ID Select a).FirstOrDefault
                        If dtGet IsNot Nothing Then
                            With dtGet
                                .Attendence_Status_Type = dts.Attendence_Status_Type
                                .Attendence_Status_Dep = dts.Attendence_Status_Dep
                                .Attendence_Status_Finger = dts.Attendence_Status_Finger
                            End With
                        Else
                            Dim dtNew = New Attendence_Status
                            With dtNew
                                .Attendence_Status_Type = dts.Attendence_Status_Type
                                .Attendence_Status_Dep = dts.Attendence_Status_Dep
                                .Attendence_Status_Finger = dts.Attendence_Status_Finger
                            End With
                            dbO.Attendence_Status.Add(dtNew)
                        End If
                    Next
                    dbO.SaveChanges()
                    Dim dtO = (From a In dbO.Attendence_Status Select a).ToList
                    If dtO.Count > 0 Then
                        GridControl2.DataSource = dtO
                    End If
                End Using
            End If
        End Using
    End Sub
    Private Sub SimpleButton5_Click(sender As Object, e As EventArgs) Handles SimpleButton5.Click
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Emp_Bio_Device_Users Where a.Employee.Emp_Status = True And a.User_ID = CsmdVarible.PlazaUserID Select a).ToList
            If dt.Count > 0 Then
                Using dbO As New CsmdBioAttendenceEntitiesOnline
                    Dim kk As Integer = 0
                    For Each dts In dt
                        Dim dtGet = (From a In dbO.Emp_Bio_Device_Users Where a.Emp_ID = dts.Emp_ID And a.Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID And a.User_ID = CsmdVarible.PlazaUserID Select a).FirstOrDefault
                        If dtGet IsNot Nothing Then
                            With dtGet
                                .User_ID = dts.User_ID
                                .Emp_ID = dts.Emp_ID
                                .Attendence_Status_ID = dts.Attendence_Status_ID
                                .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
                                .Emp_Bio_Device_User_Name = dts.Emp_Bio_Device_User_Name
                                .Emp_Bio_Device_User_Finger = dts.Emp_Bio_Device_User_Finger
                                .Emp_Bio_Device_User_tmpData = dts.Emp_Bio_Device_User_tmpData
                                .Emp_Bio_Device_User_Privilege = dts.Emp_Bio_Device_User_Privilege
                                .Emp_Bio_Device_User_Password = dts.Emp_Bio_Device_User_Password
                                .Emp_Bio_Device_User_FacetmpData = dts.Emp_Bio_Device_User_FacetmpData
                                .Emp_Bio_Device_User_iLength = dts.Emp_Bio_Device_User_iLength
                                .Emp_Bio_Device_User_Enabled = dts.Emp_Bio_Device_User_Enabled
                            End With
                        Else
                            Dim dtNew = New CsmdOnline.Emp_Bio_Device_Users
                            With dtNew
                                .User_ID = dts.User_ID
                                .Emp_ID = dts.Emp_ID
                                .Attendence_Status_ID = dts.Attendence_Status_ID
                                .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
                                .Emp_Bio_Device_User_Name = dts.Emp_Bio_Device_User_Name
                                .Emp_Bio_Device_User_Finger = dts.Emp_Bio_Device_User_Finger
                                .Emp_Bio_Device_User_tmpData = dts.Emp_Bio_Device_User_tmpData
                                .Emp_Bio_Device_User_Privilege = dts.Emp_Bio_Device_User_Privilege
                                .Emp_Bio_Device_User_Password = dts.Emp_Bio_Device_User_Password
                                .Emp_Bio_Device_User_FacetmpData = dts.Emp_Bio_Device_User_FacetmpData
                                .Emp_Bio_Device_User_iLength = dts.Emp_Bio_Device_User_iLength
                                .Emp_Bio_Device_User_Enabled = dts.Emp_Bio_Device_User_Enabled
                            End With
                            dbO.Emp_Bio_Device_Users.Add(dtNew)
                        End If
                        dbO.SaveChanges()
                        Me.Text = kk
                        kk += 1

                    Next

                    Dim dtO = (From a In dbO.Emp_Bio_Device_Users Select a).ToList
                    If dtO.Count > 0 Then
                        GridControl2.DataSource = dtO
                    End If
                End Using
            End If
        End Using
    End Sub

    Private Sub SimpleButton7_Click(sender As Object, e As EventArgs) Handles SimpleButton7.Click
        Using DBCon1 As New SqlConnection(CsmdCon.ConSqlDB)
            Dim dat As Date = CDate(Dtp1.EditValue)
            Dim idd As Integer = CInt(TextBox1.Text)
            Dim da1 As SqlDataAdapter = New SqlDataAdapter("SELECT * " &
                                                           "FROM dbo.Emp_Attendence_Device inner join Employees on dbo.Emp_Attendence_Device.Emp_ID=Employees.Emp_ID " &
"WHERE (dbo.Emp_Attendence_Device.Emp_ID=" & idd & ") and (datepart(month, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date) = " & CDate(Dtp1.EditValue.ToString).Date.ToString("MM") & ") " &
" AND (datepart(year, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date) = " & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy") & ") and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') and Employees.Emp_Status='true'", DBCon1)



            Dim ds1 As New DataSet()
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                    Dim k As Integer = 1
                    ProgressBarControl1.Properties.Maximum = ds1.Tables(0).Rows.Count
                    ProgressBarControl1.Properties.Minimum = 1
                    ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                    ProgressBarControl1.Position = 1
                    ProgressBarControl1.Update()
                    Dim Crt_User As String = ""
                    Dim connection As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                    For Each dts As DataRow In ds1.Tables(0).Rows
                        ProgressBarControl1.Position = k
                        ProgressBarControl1.Update()
                        k += 1
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


                    Dim da3 As SqlDataAdapter = New SqlDataAdapter("SELECT  dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Attendence_Device.Emp_ID,  " &
"dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time " &
                                                           "FROM dbo.Emp_Attendence_Device " &
"WHERE (dbo.Emp_Attendence_Device.Emp_ID=" & idd & ")", DBCon2)



                    Dim ds3 As New DataSet()
                    da3.Fill(ds3)
                    If ds3.Tables(0).Rows.Count > 0 Then
                        GridControl2.DataSource = ds3.Tables(0)
                    End If
                    DBCon2.Close()
                End Using
            End If
            DBCon1.Close()
        End Using
        'Using db As New CsmdBioAttendenceEntities
        '    Dim dat As Date = CDate(Dtp1.EditValue)
        '    Dim dt = (From a In db.Emp_Attendence_Device
        '              Where a.Emp_ID = 15 And a.Emp_Attendence_Device_Status = True And
        '                  a.Emp_Attendence_Device_Day.Value.Month >= dat.Month And
        '                                                     a.Emp_Attendence_Device_Day.Value.Month <= dat.Month And
        '                                                     a.Emp_Attendence_Device_Day.Value.Year >= dat.Year And
        '                                                     a.Emp_Attendence_Device_Day.Value.Year <= dat.Year Order By a.Emp_Attendence_Device_DateTime Select a).ToList
        '    If dt.Count > 0 Then
        '        Using dbO As New CsmdBioAttendenceEntitiesOnline
        '            Dim k As Integer = 1
        '            ProgressBarControl1.Properties.Maximum = dt.Count
        '            ProgressBarControl1.Properties.Minimum = 1
        '            ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
        '            ProgressBarControl1.Position = 1
        '            ProgressBarControl1.Update()
        '            For Each dts In dt
        '                ProgressBarControl1.Position = k
        '                ProgressBarControl1.Update()
        '                k += 1
        '                Dim dtGet = (From a In dbO.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = dts.Emp_Attendence_Device_ID Select a).FirstOrDefault
        '                If dtGet IsNot Nothing Then
        '                    With dtGet
        '                        .Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
        '                        .Emp_ID = dts.Emp_ID
        '                        .Attendance_Duty_Status_ID = dts.Attendance_Duty_Status_ID
        '                        .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
        '                        .Emp_Attendence_Device_Duty_On_Off = dts.Emp_Attendence_Device_Duty_On_Off
        '                        .Emp_Attendence_Device_Day = dts.Emp_Attendence_Device_Day
        '                        .Emp_Attendence_Device_Date = dts.Emp_Attendence_Device_Date
        '                        .Emp_Attendence_Device_Time = dts.Emp_Attendence_Device_Time
        '                        .Emp_Attendence_Device_Cal1 = dts.Emp_Attendence_Device_Cal1
        '                        .Emp_Attendence_Device_Cal2 = dts.Emp_Attendence_Device_Cal2
        '                        .Emp_Attendence_Device_Cal3 = dts.Emp_Attendence_Device_Cal3
        '                        .Emp_Attendence_Device_Cal4 = dts.Emp_Attendence_Device_Cal4
        '                        .Emp_Attendence_Device_Cal5 = dts.Emp_Attendence_Device_Cal5
        '                        .Emp_Attendence_Device_Cal6 = dts.Emp_Attendence_Device_Cal6
        '                        .Emp_Attendence_Device_Cal7 = dts.Emp_Attendence_Device_Cal7
        '                        .Emp_Attendence_Device_Status = dts.Emp_Attendence_Device_Status
        '                        .User_ID = dts.User_ID
        '                    End With

        '                Else
        '                    Dim dtNew = New Emp_Attendence_Device
        '                    With dtNew
        '                        .Emp_Attendence_Device_ID = dts.Emp_Attendence_Device_ID
        '                        .Emp_Attendence_Device_DateTime = dts.Emp_Attendence_Device_DateTime
        '                        .Emp_ID = dts.Emp_ID
        '                        .Attendance_Duty_Status_ID = dts.Attendance_Duty_Status_ID
        '                        .Emp_Bio_Device_Users_UserID = dts.Emp_Bio_Device_Users_UserID
        '                        .Emp_Attendence_Device_Duty_On_Off = dts.Emp_Attendence_Device_Duty_On_Off
        '                        .Emp_Attendence_Device_Day = dts.Emp_Attendence_Device_Day
        '                        .Emp_Attendence_Device_Date = dts.Emp_Attendence_Device_Date
        '                        .Emp_Attendence_Device_Time = dts.Emp_Attendence_Device_Time
        '                        .Emp_Attendence_Device_Cal1 = dts.Emp_Attendence_Device_Cal1
        '                        .Emp_Attendence_Device_Cal2 = dts.Emp_Attendence_Device_Cal2
        '                        .Emp_Attendence_Device_Cal3 = dts.Emp_Attendence_Device_Cal3
        '                        .Emp_Attendence_Device_Cal4 = dts.Emp_Attendence_Device_Cal4
        '                        .Emp_Attendence_Device_Cal5 = dts.Emp_Attendence_Device_Cal5
        '                        .Emp_Attendence_Device_Cal6 = dts.Emp_Attendence_Device_Cal6
        '                        .Emp_Attendence_Device_Cal7 = dts.Emp_Attendence_Device_Cal7
        '                        .Emp_Attendence_Device_Status = dts.Emp_Attendence_Device_Status
        '                        .User_ID = dts.User_ID
        '                    End With
        '                    dbO.Emp_Attendence_Device.Add(dtNew)
        '                End If
        '                dbO.SaveChanges()
        '            Next
        '            Dim dtO = (From a In dbO.Emp_Attendence_Device
        '                       Where a.Emp_Attendence_Device_Status = True And a.Emp_ID = 15 And
        '                           a.Emp_Attendence_Device_Day.Value.Month >= dat.Month And
        '                           a.Emp_Attendence_Device_Day.Value.Month <= dat.Month And
        '                           a.Emp_Attendence_Device_Day.Value.Year >= dat.Year And
        '                           a.Emp_Attendence_Device_Day.Value.Year <= dat.Year
        '                       Order By a.Emp_Attendence_Device_DateTime Select a).ToList
        '            If dtO.Count > 0 Then
        '                GridControl2.DataSource = dtO
        '            End If
        '        End Using
        '    End If
        'End Using

    End Sub
    Private Sub ProgressBarControl1_CustomDisplayText(sender As Object, e As CustomDisplayTextEventArgs) Handles ProgressBarControl1.CustomDisplayText
        Dim val As String = e.Value.ToString()
        e.DisplayText = "The progress is: " & val & " of " & ProgressBarControl1.Properties.Maximum
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Using dbO As New CsmdBioAttendenceEntitiesOnline
            Dim dat As Date = CDate(Dtp1.EditValue)
            Dim dtO = (From a In dbO.Emp_Attendence_Device
                       Where a.Emp_Attendence_Device_Status = True And
                           a.Emp_Attendence_Device_Day.Value.Month >= dat.Month And
                           a.Emp_Attendence_Device_Day.Value.Month <= dat.Month And
                           a.Emp_Attendence_Device_Day.Value.Year >= dat.Year And
                           a.Emp_Attendence_Device_Day.Value.Year <= dat.Year
                       Order By a.Emp_Attendence_Device_DateTime Select a).ToList
            If dtO.Count > 0 Then
                GridControl2.DataSource = dtO
            End If
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)
            Dim da3 As SqlDataAdapter = New SqlDataAdapter("SELECT  dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Attendence_Device.Emp_ID,  " &
"dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time " &
                                                          "FROM dbo.Emp_Attendence_Device " &
"WHERE (dbo.Emp_Attendence_Device.Emp_ID=" & 9 & ")", DBCon2)



            Dim ds3 As New DataSet()
            da3.Fill(ds3)
            If ds3.Tables(0).Rows.Count > 0 Then
                GridControl2.DataSource = ds3.Tables(0)
            End If
            DBCon2.Close()
        End Using
    End Sub
    Dim frm As Form2
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        frm = New Form2
        frm.Show()
        CsmdConOnline.kkk = CInt(TextBox1.Text)
        CsmdConOnline.ddd = CDate(Dtp1.EditValue)
        frm.FlowLayoutPanel1.Controls.Add(New DataUploader)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Dim du As New DataUploader

    End Sub

    Private Sub SimpleButton11_Click(sender As Object, e As EventArgs) Handles SimpleButton11.Click
        Using DBCon1 As New SqlConnection(CsmdCon.ConSqlDB)
            Dim dat As Date = CDate(Dtp1.EditValue)
            Dim idd As Integer = CInt(TextBox1.Text)
            Dim sqlStr As String = "SELECT * " &
                                                           "FROM dbo.Emp_Attendence_Device inner join Employees on dbo.Emp_Attendence_Device.Emp_ID=Employees.Emp_ID " &
"WHERE (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy-MM-dd") & "') and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') and Employees.Emp_Status='true'"
            Dim da1 As SqlDataAdapter = New SqlDataAdapter(sqlStr, DBCon1)



            Dim ds1 As New DataSet()
            da1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                    Dim k As Integer = 1
                    ProgressBarControl1.Properties.Maximum = ds1.Tables(0).Rows.Count
                    ProgressBarControl1.Properties.Minimum = 1
                    ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                    ProgressBarControl1.Position = 1
                    ProgressBarControl1.Update()
                    Dim Crt_User As String = ""
                    Dim connection As New SqlConnection(CsmdConOnline.ConSqlDBonline)
                    For Each dts As DataRow In ds1.Tables(0).Rows
                        ProgressBarControl1.Position = k
                        ProgressBarControl1.Update()
                        k += 1
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Using DBCon2 As New SqlConnection(CsmdConOnline.ConSqlDBonline)
            Dim da3 As SqlDataAdapter = New SqlDataAdapter("SELECT  dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Attendence_Device.Emp_ID,  " &
"dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time " &
                                                          "FROM dbo.Emp_Attendence_Device " &
"WHERE (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & CDate(Dtp1.EditValue.ToString).Date.ToString("yyyy-MM-dd") & "') and (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true')", DBCon2)



            Dim ds3 As New DataSet()
            da3.Fill(ds3)
            If ds3.Tables(0).Rows.Count > 0 Then
                GridControl2.DataSource = ds3.Tables(0)
            End If
            DBCon2.Close()
        End Using
    End Sub

    Private Sub SimpleButton12_Click(sender As Object, e As EventArgs) Handles SimpleButton12.Click
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Emp_Attendence_Device Select a).ToList
            If dt.Count > 0 Then
                Dim k As Integer = 1
                ProgressBarControl1.Properties.Maximum = dt.Count
                ProgressBarControl1.Properties.Minimum = 1
                ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl1.Position = 1
                ProgressBarControl1.Update()
                Dim ff As Integer = 1
                For Each dts In dt
                    dts.User_ID = 2
                    Me.Text = ff
                    ProgressBarControl1.Position = ff
                    ProgressBarControl1.Update()
                    ff += 1
                    db.SaveChanges()
                Next

            End If
        End Using
    End Sub
End Class
