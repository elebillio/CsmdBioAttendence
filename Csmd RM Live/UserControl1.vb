Imports System.Data.SqlClient
Imports CsmdBioDatabase

Public Class UserControl1
    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim DataT As New DataTable
        Dim Mtr As DataRow
        DataT.Columns.Clear()
        DataT.Columns.Add("USERID", GetType(String))
        DataT.Columns.Add("Sd1", GetType(String))
        DataT.Columns.Add("Sd2", GetType(String))
        DataT.Columns.Add("Date", GetType(String))
        DataT.Columns.Add("Day", GetType(String))
        DataT.Columns.Add("SSN", GetType(String))
        DataT.Columns.Add("Sn1", GetType(String))
        'Dim uc As New UserControl1
        Dim myGraphics As Graphics = Me.CreateGraphics
        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center
        Dim ff As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Dim thisDate As Date = CDate("01-10-2022" & " " & CsmdDateTime.StartDayTime("01-10-2022"))
        Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime("01-10-2022"))
        Dim TiA As String = "07:00" ').ToString("dd-MM-yyyy HH:mm"))
        Dim TiB As String = "03:00" ').ToString("dd-MM-yyyy HH:mm"))

        Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
        Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name,dbo.Emp_Bio_Device_Users.Emp_ID, " &
"dbo.Attendence_Status.Attendence_Status_Type,dbo.Emp_Attendence_Device.Emp_Attendence_Device_Duty_On_Off, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day,dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID " &
"FROM  dbo.Emp_Attendence_Device INNER JOIN " &
"dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
"dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
"            WHERE " &
"(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & thisDate.ToString("yyyy/MM/dd") & "')  " &
"AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & 1 & ") AND (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
        Dim ds2 As New DataSet()
        da2.Fill(ds2)
        Dim chkA As Boolean = False
        Dim chkB As Boolean = False
        Dim chkC As Boolean = False
        Dim chkD As Boolean = False
        Dim chkE As Boolean = False
        Dim chkA2 As Boolean = False
        Dim chkB2 As Boolean = False
        Dim chkC2 As Boolean = False
        Dim chkD2 As Boolean = False
        Dim chkE2 As Boolean = False
        Dim ChkAdate As String = ""
        Dim ChkAtime As String = ""
        Dim PrayAdate As String = ""
        Dim PrayAtime As String = ""
        Dim PrayBdate As String = ""
        Dim PrayBtime As String = ""
        Dim ShAdate As String = ""
        Dim ShAtime As String = ""
        Dim ShBdate As String = ""
        Dim ShBtime As String = ""
        Dim LuAdate As String = ""
        Dim LuAtime As String = ""
        Dim LuBdate As String = ""
        Dim LuBtime As String = ""
        Dim PriAdate As String = ""
        Dim PriAtime As String = ""
        Dim PriBdate As String = ""
        Dim PriBtime As String = ""
        Dim ggg As DateTime
        Dim fff As DateTime
        Dim durationM As Integer
        If ds2.Tables(0).Rows.Count > 0 Then

            For Each dsx As DataRow In ds2.Tables(0).Rows
                If CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") >= thisDate.ToString("yyyy/MM/dd HH") And CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") <= ToDate.ToString("yyyy/MM/dd HH") Then
                    If dsx.Item("Attendence_Status_Type").ToString = "RT-Check In" Then
                        If chkA2 = False Then
                            chkA = True
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sd1") = dsx.Item("Emp_Attendence_Device_Duty_On_Off")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)
                            chkA2 = True

                            fff = "08:00" ' If(IsNothing(dXA), CDate("00:00"), dXA)
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                            ' MsgBox(duration)
                            durationM = duration
                            myGraphics.FillRectangle(New SolidBrush(Color.Pink), New Rectangle(0, 0, duration, 30))
                            myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(0, 0, duration, 30), stringFormat)

                        Else
                            chkA = False
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sd1") = dsx.Item("Emp_Attendence_Device_Duty_On_Off")
                            Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            DataT.Rows.Add(Mtr)

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1

                            ChkAdate = thisDate.ToString("dd/MM/yyyy").ToString '("dd/MM/yyyy HH:mm:ss")
                            ChkAtime = "20:00" '("HH:mm:ss")

                            Mtr.Item("Date") = CDate(ChkAdate & " " & ChkAtime).ToString("dd/MM/yyyy HH:mm:ss")
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = "LT-Check Out"
                            Mtr.Item("Sd1") = "20:00" & " zz"
                            Mtr.Item("Sn1") = ChkAtime & " vv"
                            DataT.Rows.Add(Mtr)

                        End If

                    Else
                        If dsx.Item("Attendence_Status_Type").ToString = "LT-Check Out" Then
                            If chkA = False Then
                                ChkAdate = thisDate.ToString("dd/MM/yyyy").ToString '("dd/MM/yyyy HH:mm:ss")
                                ChkAtime = "08:00" '("HH:mm:ss")
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                Mtr.Item("Date") = CDate(ChkAdate & " " & ChkAtime).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = "RT-Check In"
                                Mtr.Item("Sd1") = "08:00" & " ss"
                                Mtr.Item("Sn1") = ChkAtime & " xx"
                                DataT.Rows.Add(Mtr)

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sd1") = dsx.Item("Emp_Attendence_Device_Duty_On_Off")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkA2 = False
                            Else
                                chkA = False
                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sd1") = dsx.Item("Emp_Attendence_Device_Duty_On_Off")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkA2 = False
                                fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                                ggg = "20:00" ' CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                                myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                                myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration

                                fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                                Dim durationz As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                                myGraphics.FillRectangle(New SolidBrush(Color.Pink), New Rectangle(durationM, 0, durationz, 30))
                                myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, durationz, 30), stringFormat)
                                durationM += duration
                            End If
                            'Else
                            '    If chkA = True Then
                            '        chkA = False
                            '        Mtr = DataT.NewRow
                            '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                            '        Mtr.Item("SSN") = "LT-Check Out"
                            '        Mtr.Item("Sn1") = ""
                            '        DataT.Rows.Add(Mtr)
                            '    End If
                        End If
                    End If
                    'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                    If dsx.Item("Attendence_Status_Type").ToString = "RI-Prayer A" Then
                        If chkB2 = False Then
                            PrayAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            PrayAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = PrayAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = PrayAtime
                            DataT.Rows.Add(Mtr)
                            chkB2 = True
                            chkB = True
                            fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                            myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                        Else
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                            Mtr.Item("Date") = PrayAdate ' CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = "LI-Prayer B"
                            Mtr.Item("Sn1") = PrayAtime & " hh"
                            DataT.Rows.Add(Mtr)

                            PrayAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            PrayAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = PrayAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = PrayAtime
                            DataT.Rows.Add(Mtr)
                            chkB2 = True
                            chkB = True
                        End If
                    Else
                        If dsx.Item("Attendence_Status_Type").ToString = "LI-Prayer B" Then
                            If chkB2 = False Then
                                If chkB = True Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = PrayBdate
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RI-Prayer A"
                                    Mtr.Item("Sn1") = PrayBtime & " hh"
                                    DataT.Rows.Add(Mtr)
                                    chkB = False
                                Else
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RI-Prayer A"
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkB = False
                                End If

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkB2 = False
                            Else
                                PrayBdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                PrayBtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = PrayBdate
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = PrayBtime
                                DataT.Rows.Add(Mtr)
                                chkB2 = False
                                chkB = False
                                fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                                myGraphics.FillRectangle(New SolidBrush(Color.Green), New Rectangle(durationM, 0, duration, 30))
                                myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                            End If
                            'Else
                            '    If chkB = True Then
                            '        chkB = False
                            '        Mtr = DataT.NewRow
                            '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                            '        Mtr.Item("SSN") = "LI-Prayer B"
                            '        Mtr.Item("Sn1") = ""
                            '        DataT.Rows.Add(Mtr)
                            '    End If
                        End If
                    End If
                    'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                    If dsx.Item("Attendence_Status_Type").ToString = "RM-Short Leave A" Then
                        If chkC2 = False Then
                            ShAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            ShAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = ShAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = ShAtime
                            DataT.Rows.Add(Mtr)
                            chkC2 = True
                            chkC = True
                            fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                            myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                        Else
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                            Mtr.Item("Date") = ShAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = "LM-Short Leave B"
                            Mtr.Item("Sn1") = ShAtime & " hh"
                            DataT.Rows.Add(Mtr)
                            ShAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            ShAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = ShAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = ShAtime
                            DataT.Rows.Add(Mtr)
                            chkC2 = True
                            chkC = True
                        End If

                    Else
                        If dsx.Item("Attendence_Status_Type").ToString = "LM-Short Leave B" Then

                            If chkC2 = False Then
                                If chkC = True Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = ShAdate
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RM-Short Leave A"
                                    Mtr.Item("Sn1") = ShAtime & " hh"
                                    DataT.Rows.Add(Mtr)
                                    chkC = False
                                Else
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RM-Short Leave A"
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkC = False
                                End If


                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkC2 = False
                            Else
                                ShAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                ShAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkC2 = False
                                chkC = False
                                fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                                myGraphics.FillRectangle(New SolidBrush(Color.Aquamarine), New Rectangle(durationM, 0, duration, 30))
                                myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                            End If
                            'Else
                            '    If chkC = True Then
                            '        chkC = False
                            '        Mtr = DataT.NewRow
                            '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                            '        Mtr.Item("SSN") = "LM-Short Leave B"
                            '        Mtr.Item("Sn1") = ""
                            '        DataT.Rows.Add(Mtr)
                            '    End If
                        End If
                    End If
                    'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                    If dsx.Item("Attendence_Status_Type").ToString = "RR-Lunch A" Then
                        If chkD2 = False Then
                            LuAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            LuAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = LuAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = LuAtime
                            DataT.Rows.Add(Mtr)
                            chkD2 = True
                            chkD = True
                            fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                            myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                        Else
                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                            Mtr.Item("Date") = LuAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = "LR-Lunch B"
                            Mtr.Item("Sn1") = LuAtime
                            DataT.Rows.Add(Mtr)
                            LuAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            LuAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = LuAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = LuAtime & " hh"
                            DataT.Rows.Add(Mtr)
                            chkD2 = True
                            chkD = True
                        End If
                    Else
                        If dsx.Item("Attendence_Status_Type").ToString = "LR-Lunch B" Then

                            If chkD2 = False Then
                                If chkD = True Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = LuAdate
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RR-Lunch A"
                                    Mtr.Item("Sn1") = LuAtime & " hh"
                                    DataT.Rows.Add(Mtr)
                                    chkD = False
                                Else
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RR-Lunch A"
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkD = False
                                End If


                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkD2 = False
                            Else
                                LuAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                LuAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = LuAdate
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkD2 = False
                                chkD = False
                                fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                                myGraphics.FillRectangle(New SolidBrush(Color.Yellow), New Rectangle(durationM, 0, duration, 30))
                                myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                            End If
                            'Else
                            '    If chkD = True Then
                            '        chkD = False
                            '        Mtr = DataT.NewRow
                            '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                            '        Mtr.Item("SSN") = "LR-Lunch B"
                            '        Mtr.Item("Sn1") = ""
                            '        DataT.Rows.Add(Mtr)
                            '    End If
                        End If
                    End If
                    'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                    If dsx.Item("Attendence_Status_Type").ToString = "RP-Private A" Then
                        If chkE2 = False Then
                            PriAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            PriAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = PriAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = PriAtime
                            DataT.Rows.Add(Mtr)
                            chkE2 = True
                            chkE = True

                            fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                            Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2

                            myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                        Else

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) + 1
                            Mtr.Item("Date") = PriAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = "LP-Private B"
                            Mtr.Item("Sn1") = PriAtime
                            DataT.Rows.Add(Mtr)
                            PriAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                            PriAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                            Mtr = DataT.NewRow
                            Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                            Mtr.Item("Date") = PriAdate
                            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                            Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                            Mtr.Item("Sn1") = PriAtime & " hh"
                            DataT.Rows.Add(Mtr)
                            chkE2 = True
                            chkE = True
                        End If


                    Else

                        If dsx.Item("Attendence_Status_Type").ToString = "LP-Private B" Then

                            If chkE2 = False Then
                                If chkE = True Then
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = PriAdate
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RP-Private A"
                                    Mtr.Item("Sn1") = PriAtime & " hh"
                                    DataT.Rows.Add(Mtr)
                                    chkE = False
                                Else
                                    Mtr = DataT.NewRow
                                    Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID")) - 1
                                    Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                    Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                    Mtr.Item("SSN") = "RP-Private A"
                                    Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                    DataT.Rows.Add(Mtr)
                                    chkE = False
                                End If


                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("HH:mm")
                                DataT.Rows.Add(Mtr)
                                chkE2 = False
                            Else
                                PriAdate = CDate(dsx.Item("Emp_Attendence_Device_DateTime")).ToString("dd/MM/yyyy HH:mm:ss")
                                PriAtime = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")

                                Mtr = DataT.NewRow
                                Mtr.Item("USERID") = CInt(dsx.Item("Emp_Bio_Device_Users_UserID"))
                                Mtr.Item("Date") = PriAdate
                                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                                Mtr.Item("SSN") = dsx.Item("Attendence_Status_Type")
                                Mtr.Item("Sn1") = PriAtime
                                DataT.Rows.Add(Mtr)
                                chkE2 = False
                                chkE = False

                                fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                                Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 2
                                myGraphics.FillRectangle(New SolidBrush(Color.Red), New Rectangle(durationM, 0, duration, 30))
                                myGraphics.DrawString(duration, ff, Brushes.Aqua, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                            End If

                            'Else
                            '    If chkE = True Then
                            '        chkE = False
                            '        Mtr = DataT.NewRow
                            '        Mtr.Item("Date") = dsx.Item("CHECKTIME")
                            '        Mtr.Item("SSN") = "LP-Private B"
                            '        Mtr.Item("Sn1") = ""
                            '        DataT.Rows.Add(Mtr)
                            '    End If
                        End If
                    End If
                End If
            Next

            If chkA = True Then
                chkA = False
                Mtr = DataT.NewRow
                Mtr.Item("USERID") = 1
                ChkAdate = thisDate.ToString("dd/MM/yyyy").ToString '("dd/MM/yyyy HH:mm:ss")
                ChkAtime = "20:00"
                Mtr.Item("Date") = CDate(ChkAdate & " " & ChkAtime).ToString("dd/MM/yyyy HH:mm:ss")
                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                Mtr.Item("SSN") = "LT-Check Out"
                Mtr.Item("Sd1") = ChkAtime & " dd"
                Mtr.Item("Sn1") = ChkAtime & " cc"
                DataT.Rows.Add(Mtr)
            End If
            If chkB = True Then
                chkB = False
                Mtr = DataT.NewRow
                Mtr.Item("USERID") = 1
                Mtr.Item("Date") = PrayAdate
                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                Mtr.Item("SSN") = "LI-Prayer B"
                Mtr.Item("Sn1") = PrayAtime & " rr"
                DataT.Rows.Add(Mtr)
            End If
            If chkC = True Then
                chkC = False
                Mtr = DataT.NewRow
                Mtr.Item("USERID") = 1
                Mtr.Item("Date") = ShAdate
                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                Mtr.Item("SSN") = "LM-Short Leave B"
                Mtr.Item("Sn1") = ShAtime & " rr"
                DataT.Rows.Add(Mtr)
            End If
            If chkD = True Then
                chkD = False
                Mtr = DataT.NewRow
                Mtr.Item("USERID") = 1
                Mtr.Item("Date") = LuAdate
                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                Mtr.Item("SSN") = "LR-Lunch B"
                Mtr.Item("Sn1") = LuAtime & " rr"
                DataT.Rows.Add(Mtr)
            End If
            If chkE = True Then
                chkE = False
                Mtr = DataT.NewRow
                Mtr.Item("USERID") = 1
                Mtr.Item("Date") = PriAdate
                Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
                Mtr.Item("SSN") = "LP-Private B"
                Mtr.Item("Sn1") = PriAtime & " rr"
                DataT.Rows.Add(Mtr)
            End If

        Else
            Mtr = DataT.NewRow
            Mtr.Item("USERID") = 1
            Mtr.Item("Sd1") = ""
            'Mtr.Item("Sd2") = "-."
            Mtr.Item("Date") = thisDate.Date
            Mtr.Item("Day") = thisDate.ToString("yyyy/MM/dd")
            Mtr.Item("SSN") = "Absent"
            Mtr.Item("Sn1") = "OFF"
            DataT.Rows.Add(Mtr)

        End If

        'Button2.Text = durationM

        DBCon2.Close()
        'FlowLayoutPanel1.Controls.Add(uc)
        'GridControl1.DataSource = Nothing
        'GridControl1.DataSource = DataT

    End Sub
End Class
