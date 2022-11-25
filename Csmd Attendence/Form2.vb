Imports CsmdBioDatabase

Public Class Form2
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Using db As New CsmdBioAttendenceEntities
            Dim FromDat As DateTime = CDate(Dtp1.EditValue)
            Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat)
            Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))

            Dim AAz As Date = CDate(firstDay & " " & CsmdDateTime.StartDayTime(FromDat.Date))
            Dim AAx As Date = CDate(lastDay & " " & CsmdDateTime.EndDayTime(FromDat.Date))
            Dim kk As Integer = 0
            Dim k2 As Integer = 0
            ProgressBarControl2.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate))
            ProgressBarControl2.Properties.Minimum = 0
            ProgressBarControl2.Properties.Appearance.BackColor = Color.Yellow
            ProgressBarControl2.Position = 0
            ProgressBarControl2.Update()
            For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate

                ProgressBarControl2.Position = k2
                ProgressBarControl2.Update()
                k2 += 1
                'Dim dt = (From a In db.Employees Where a.Emp_Status = True Select a).ToList
                'If dt.Count > 0 Then
                '    Dim k1 As Integer = 0
                '    ProgressBarControl1.Properties.Maximum = dt.Count - 1
                '    ProgressBarControl1.Properties.Minimum = 0
                '    ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
                '    ProgressBarControl1.Position = 0
                '    ProgressBarControl1.Update()

                '    For Each df In dt
                '        ProgressBarControl1.Position = k1
                '        ProgressBarControl1.Update()
                '        k1 += 1






                Dim thisDate As DateTime = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(FromDat.Date))
                Dim ToDate As DateTime = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(FromDat.Date))

                Dim dts = (From a In db.Emp_Attendence_Device Where
                                                                             a.Emp_Bio_Device_Users.Employee.Emp_Status = True And
                                                                             a.Emp_Attendence_Device_DateTime >= thisDate And
                                                                             a.Emp_Attendence_Device_DateTime <= ToDate
                           Order By a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time Select a).ToList


                Dim k3 As Integer = 0
                ProgressBarControl3.Properties.Maximum = dts.Count - 1
                ProgressBarControl3.Properties.Minimum = 0
                ProgressBarControl3.Properties.Appearance.BackColor = Color.Yellow
                ProgressBarControl3.Position = 0
                ProgressBarControl3.Update()
                For Each row0 In dts
                    ProgressBarControl3.Position = k3
                    ProgressBarControl3.Update()
                    k3 += 1
                    Dim datet As DateTime = CDate(CStr(row0.Emp_Attendence_Device_DateTime).ToString)
                    If datet.ToString("yyyy/MM/dd HH:mm") >= thisDate.ToString("yyyy/MM/dd HH:mm") And datet.ToString("yyyy/MM/dd HH:mm") <= ToDate.ToString("yyyy/MM/dd HH:mm") Then
                        row0.Emp_Attendence_Device_Day = thisDate.Date
                    End If
                    db.SaveChanges()
                    kk += 1
                Next


                '    Next

                'End If
            Next

            BarStaticItem1.Caption = kk

            'For Each dtf In dts
            '    dtf.Emp_Attendence_Device_Day = AAz.Day
            'Next
            'db.SaveChanges()

            'Dim dts0 = (From a In db.Emp_Attendence_Device Where
            '                                                         a.Emp_Bio_Device_Users.Employee.Emp_Status = True And
            '                                                         a.Emp_Attendence_Device_DateTime >= AAz And
            '                                                         a.Emp_Attendence_Device_DateTime <= AAx
            '            Order By a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_Time Select New With {a.Emp_Bio_Device_Users.Employee.Emp_Name, a.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Head.Attendence_Status_Head_Name, a.Emp_Bio_Device_Users.Attendence_Status.Attendence_Status_Type, a.Emp_Attendence_Device_Date, a.Emp_Attendence_Device_DateTime, a.Emp_Attendence_Device_Time,
            '                                                                                   a.Emp_Attendence_Device_Status, a.Emp_Attendence_Device_Day}).ToList


            'GridControl1.DataSource = dts0



        End Using


    End Sub
End Class