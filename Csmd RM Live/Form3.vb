Imports System.Data.SqlClient
Imports CsmdBioDatabase
Imports DevExpress.XtraEditors

Public Class Form3
    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim myGraphics As Graphics = Me.CreateGraphics
        Dim stringFormat As New StringFormat()
        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center
        Dim ff As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        myGraphics.FillRectangle(New SolidBrush(Color.Blue), New Rectangle(10, 0, 1440, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(10, 0, 720, 30), stringFormat)

        myGraphics.FillRectangle(New SolidBrush(Color.Blue), New Rectangle(10, 40, 1080, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(10, 40, 720, 30), stringFormat)

        myGraphics.FillRectangle(New SolidBrush(Color.Blue), New Rectangle(10, 80, 720, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(10, 80, 720, 30), stringFormat)

        myGraphics.FillRectangle(New SolidBrush(Color.Blue), New Rectangle(10, 0, 15, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(10, 0, 15, 30), stringFormat)
        myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(25, 0, 40, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(25, 0, 40, 30), stringFormat)
        myGraphics.FillRectangle(New SolidBrush(Color.Pink), New Rectangle(65, 0, 7, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(65, 0, 7, 30), stringFormat)
        myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(72, 0, 25, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(72, 0, 25, 30), stringFormat)
        myGraphics.FillRectangle(New SolidBrush(Color.Pink), New Rectangle(97, 0, 20, 30))
        myGraphics.DrawString("Private", ff, Brushes.Black, New Rectangle(97, 0, 20, 30), stringFormat)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

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
        'Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        'Dim stringFormat As New StringFormat()
        'stringFormat.Alignment = StringAlignment.Center
        'stringFormat.LineAlignment = StringAlignment.Center
        'Dim ff As New Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point)

        WebBrowser1.Document.Write("")


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
        Dim durationM As Integer = 0
        Dim strHtml As String = ""
        strHtml = strHtml & "<center><div>"
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
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                            ' MsgBox(duration)
                            durationM = duration
                            'myGraphics.FillRectangle(New SolidBrush(Color.Pink), New Rectangle(0, 0, duration, 30))
                            'myGraphics.DrawString(duration * 2 / 3, ff, Brushes.Black, New Rectangle(0, 0, duration, 30), stringFormat)
                            strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"
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
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                'myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                                'myGraphics.DrawString(duration * 2 / 3, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

                                fff = ggg ' If(IsNothing(dXA), CDate("00:00"), dXA)
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") ' If(IsNothing(dXB), CDate("00:00"), dXB)
                                Dim durationz As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                'myGraphics.FillRectangle(New SolidBrush(Color.Pink), New Rectangle(durationM, 0, durationz, 30))
                                'myGraphics.DrawString(durationz * 2 / 3, ff, Brushes.Black, New Rectangle(durationM, 0, durationz, 30), stringFormat)
                                durationM += durationz
                                strHtml = strHtml & "<span style='width: " & durationz & "px;height: 30px;  border: 2px solid #000;background: green;'>" & durationz * 2 / 3 & "</span>"

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
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                            'myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                            strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                'myGraphics.FillRectangle(New SolidBrush(Color.Green), New Rectangle(durationM, 0, duration, 30))
                                'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                            'myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                            strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                'myGraphics.FillRectangle(New SolidBrush(Color.Maroon), New Rectangle(durationM, 0, duration, 30))
                                'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                            'myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                            strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                'myGraphics.FillRectangle(New SolidBrush(Color.Yellow), New Rectangle(durationM, 0, duration, 30))
                                'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2

                            'myGraphics.FillRectangle(New SolidBrush(Color.White), New Rectangle(durationM, 0, duration, 30))
                            'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                            durationM += duration
                            strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                'myGraphics.FillRectangle(New SolidBrush(Color.Red), New Rectangle(durationM, 0, duration, 30))
                                'myGraphics.DrawString(duration, ff, Brushes.Black, New Rectangle(durationM, 0, duration, 30), stringFormat)
                                durationM += duration
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;  border: 2px solid #000;background: green;'>" & duration * 2 / 3 & "</span>"

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
        strHtml = strHtml & "</div></center>"
        WebBrowser1.Document.Write(strHtml)
        'Button2.Text = durationM
        'PictureBox1.Refresh()
        'PictureBox1.Invalidate()
        DBCon2.Close()
        'FlowLayoutPanel1.Controls.Add(uc)
        'GridControl1.DataSource = Nothing
        'GridControl1.DataSource = DataT
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        WebBrowser1.Navigate("about:blank")
        Dim strHtml As String = ""
        strHtml = strHtml & "<div>"
        strHtml = strHtml & "<span style='width: 5px;height: 30px;  border: 2px solid #000;background: #0AC6EC;'>5</span>"
        strHtml = strHtml & "</div>"
        WebBrowser1.Document.Write(strHtml)

        '      <div Class="rectangle_style">

        '</div>
        '<style type = "text/css" >
        '.rectangle_style {

        'position: relative;
        'top: 100px;
        'left: 600px;
        'width: 100px;height: 50px; display: table; border: 2px solid #000;background: #0AC6EC;

        '}
        '</style>
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("about:blank")
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Employees Where a.Emp_Status = True Select a.Emp_ID, a.Emp_Name).ToList
            If dt.Count > 0 Then
                RepositoryItemSearchLookUpEdit1.DataSource = dt
                RepositoryItemSearchLookUpEdit1.DisplayMember = "Emp_Name"
                RepositoryItemSearchLookUpEdit1.ValueMember = "Emp_ID"
                RepositoryItemSearchLookUpEdit1.PopulateViewColumns()
                RepositoryItemSearchLookUpEdit1.View.Columns("Emp_ID").Visible = False
                'GridControl1.DataSource = dt
                'GridView1.Columns("Emp_ID").Visible = False
                BarEditItem1.EditValue = Class1.EmpID
                Dtp.EditValue = Class1.EmpDate
                LoadAtt(Class1.EmpID, Class1.EmpDate)
            End If
        End Using
    End Sub

    Private Sub LoadAtt(empid As Integer, datx As Date)

        Dim FromDat As DateTime = datx.Date
        Dim firstDay As Date = CsmdDateTime.FirstDayOfMonth(FromDat)
        Dim lastDay As Date = DateTime.Parse(CStr(firstDay)).AddDays(Date.DaysInMonth(FromDat.Year, FromDat.Month))
        WebBrowser1.Document.OpenNew(True)
        Dim strHead As String = ""
        strHead = strHead & "<div style=' border: 1px solid #000;'>"
        strHead = strHead & "<span style='width: 60px;height: 30px;text-align=center; background: white;'></span>"
        strHead = strHead & "<span style='width: " & 720 * 3 / 2 & "px;height: 30px;text-align=center; background: white;'><b>Attendance Report in Timeline View</b></span>"
        strHead = strHead & "</div>"
        WebBrowser1.Document.Write(strHead)
        strHead = ""
        strHead = strHead & "<div style=' border: 1px solid #000;'>"
        strHead = strHead & "<span style='width: 60px;height: 30px;text-align=center; background: white;'></span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=right; background: white;'><b>Name: .</b></span>"
        strHead = strHead & "<span style='width: " & 174 * 3 / 2 & "px;height: 30px;text-align=left; background: white;'>" & Class1.EmpName & "</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=right; background: white;'>Date: .</span>"
        strHead = strHead & "<span style='width: " & 174 * 3 / 2 & "px;height: 30px;text-align=left; background: white;'>" & firstDay & " to " & lastDay.AddDays(-1).Date & "</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: cyan;'>CheckInOut</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: Lime;'>Prayer</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: LightBlue;'>ShortLeave</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: Orange;'>Lunch</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: Pink;'>Private</span>"
        strHead = strHead & "</div><hr>"
        WebBrowser1.Document.Write(strHead)
        strHead = ""
        strHead = strHead & "<div style=' border: 1px solid #000;'>"
        strHead = strHead & "<span style='width: 60px;height: 30px;text-align=center; background: gray;'>Day</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: lightgray;'>08:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: gray;'>09:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: lightgray;'>10:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: gray;'>11:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: lightgray;'>12:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: gray;'>13:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: lightgray;'>14:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: gray;'>15:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: lightgray;'>16:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: gray;'>17:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: lightgray;'>18:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: gray;'>19:00</span>"
        strHead = strHead & "<span style='width: " & 58 * 3 / 2 & "px;height: 30px;text-align=center; background: lightgray;'>20:00</span>"
        strHead = strHead & "</div>"
        WebBrowser1.Document.Write(strHead)


        Dim k As Integer = 1
        ProgressBarControl1.Properties.Maximum = CInt((lastDay.ToOADate - firstDay.ToOADate))
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Properties.Appearance.BackColor = Color.Yellow
        ProgressBarControl1.Position = 0
        ProgressBarControl1.Update()

        For loopDate As Double = firstDay.ToOADate To lastDay.ToOADate - 1
            ProgressBarControl1.Position = k
            ProgressBarControl1.Update()
            k += 1

            Dim thisDate As Date = CDate(DateTime.FromOADate(loopDate) & " " & CsmdDateTime.StartDayTime(datx.Date))
            Dim ToDate As Date = CDate(thisDate.AddDays(1).Date & " " & CsmdDateTime.EndDayTime(datx.Date))
            Dim TiA As String = "07:00"
            Dim TiB As String = "03:00"

            Dim DBCon2 As New SqlConnection(CsmdCon.ConSqlDB)
            Dim da2 As SqlDataAdapter = New SqlDataAdapter("SELECT dbo.Emp_Attendence_Device.Emp_Attendence_Device_ID, dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID, dbo.Emp_Bio_Device_Users.Emp_Bio_Device_User_Name,dbo.Emp_Bio_Device_Users.Emp_ID, " &
    "dbo.Attendence_Status.Attendence_Status_Type,dbo.Emp_Attendence_Device.Emp_Attendence_Device_Duty_On_Off, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day,dbo.Emp_Attendence_Device.Emp_Attendence_Device_Date, dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime, dbo.Emp_Attendence_Device.Emp_Attendence_Device_Time, dbo.Emp_Bio_Device_Users.Emp_ID " &
    "FROM  dbo.Emp_Attendence_Device INNER JOIN " &
    "dbo.Emp_Bio_Device_Users ON dbo.Emp_Attendence_Device.Emp_Bio_Device_Users_UserID = dbo.Emp_Bio_Device_Users.Emp_Bio_Device_Users_UserID INNER JOIN " &
    "dbo.Attendence_Status ON dbo.Emp_Bio_Device_Users.Attendence_Status_ID = dbo.Attendence_Status.Attendence_Status_ID " &
    "            WHERE " &
    "(dbo.Emp_Attendence_Device.Emp_Attendence_Device_Day = '" & thisDate.ToString("yyyy/MM/dd") & "')  " &
    "AND (dbo.Emp_Bio_Device_Users.Emp_ID = " & empid & ") AND (dbo.Emp_Attendence_Device.Emp_Attendence_Device_Status = 'true') ORDER BY dbo.Emp_Attendence_Device.Emp_Attendence_Device_DateTime", DBCon2)
            Dim ds2 As New DataSet()
            da2.Fill(ds2)
            Dim ggg As DateTime
            Dim fff As DateTime
            Dim durationM As Integer = 0
            Dim strHtml As String = ""


            strHtml = strHtml & "<div style=' border: 1px solid #000;'>"
            strHtml = strHtml & "<span style='width: 60px;height: 30px;text-align=left; background: gray;'>" & thisDate.ToString("dd") & "-" & thisDate.ToString("ddd") & "</span>"
            If ds2.Tables(0).Rows.Count > 0 Then

                For Each dsx As DataRow In ds2.Tables(0).Rows
                    If CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") >= thisDate.ToString("yyyy/MM/dd HH") And CDate(dsx.Item("Emp_Attendence_Device_Datetime")).ToString("yyyy/MM/dd HH") <= ToDate.ToString("yyyy/MM/dd HH") Then
                        If dsx.Item("Attendence_Status_Type").ToString = "RT-Check In" Then
                            fff = "08:00"
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                            durationM = duration
                            strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center;background: Cyan;'>" & duration * 2 / 3 & "</span>"
                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LT-Check Out" Then
                                fff = ggg
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                durationM += duration
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center;background: white; font-size:12px;'>" & duration * 2 / 3 & "</br>" & CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "</span>"

                                fff = ggg
                                ggg = "20:00"
                                Dim durationz As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                durationM += durationz
                                strHtml = strHtml & "<span style='width: " & durationz & "px;height: 30px;text-align=center; background: Cyan;'>" & durationz * 2 / 3 & "</span>"
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RI-Prayer A" Then
                            fff = ggg
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                durationM += duration
                            If duration > 0 Then
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center; background: white; font-size:12px;'>" & duration * 2 / 3 & "</br>" & CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "</span>"
                            End If
                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LI-Prayer B" Then
                                fff = ggg
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                    durationM += duration
                                If duration > 0 Then
                                    strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center; background: Lime;'>" & duration * 2 / 3 & "</span>"
                                End If
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RM-Short Leave A" Then
                            fff = ggg
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                            durationM += duration
                            If duration > 0 Then
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px; text-align=center; background: white; font-size:12px;'>" & duration * 2 / 3 & "</br>" & CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "</span>"
                            End If
                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LM-Short Leave B" Then
                                fff = ggg
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                    durationM += duration
                                If duration > 0 Then
                                    strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center; background: LightBlue;'>" & duration * 2 / 3 & "</span>"
                                End If
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RR-Lunch A" Then
                            fff = ggg
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                durationM += duration
                            If duration > 0 Then
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center; background: white; font-size:12px;'>" & duration * 2 / 3 & "</br>" & CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "</span>"
                            End If
                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LR-Lunch B" Then
                                fff = ggg
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                    durationM += duration
                                If duration > 0 Then
                                    strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center; background: Orange;'>" & duration * 2 / 3 & "</span>"
                                End If
                            End If
                        End If
                        'nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn
                        If dsx.Item("Attendence_Status_Type").ToString = "RP-Private A" Then
                            fff = ggg
                            ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                            Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                            durationM += duration
                            If duration > 0 Then
                                strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center; background: white; font-size:12px;'>" & duration * 2 / 3 & "</br>" & CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm") & "</span>"
                            End If
                        Else
                            If dsx.Item("Attendence_Status_Type").ToString = "LP-Private B" Then
                                fff = ggg
                                ggg = CDate(dsx.Item("Emp_Attendence_Device_Time")).ToString("HH:mm")
                                Dim duration As Double = CInt(DateDiff(DateInterval.Minute, fff, ggg)) * 3 / 2
                                    durationM += duration
                                If duration > 0 Then
                                    strHtml = strHtml & "<span style='width: " & duration & "px;height: 30px;text-align=center; background: Pink;'>" & duration * 2 / 3 & "</span>"
                                End If
                            End If
                        End If
                    End If
                Next

            Else
                strHtml = strHtml & "<span style='width: 1080px;height: 30px;text-align=center; background: blue;'>Absent</span>"

            End If
            strHtml = strHtml & "</div>"
            WebBrowser1.Document.Write(strHtml)
            DBCon2.Close()
        Next
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs)

    End Sub

    Private Sub RepositoryItemSearchLookUpEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemSearchLookUpEdit1.EditValueChanged
        Dim lookup As SearchLookUpEdit = TryCast(sender, SearchLookUpEdit)
        Dim empid As Integer = lookup.EditValue
        LoadAtt(empid, Dtp.EditValue)
    End Sub

    Private Sub BarEditItem1_EditValueChanged(sender As Object, e As EventArgs) Handles BarEditItem1.EditValueChanged

    End Sub
End Class