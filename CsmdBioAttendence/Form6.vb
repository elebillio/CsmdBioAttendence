Public Class Form6
    Dim DataT As New DataTable
    Dim Mtr As DataRow
    Dim DataT2 As New DataTable
    Dim Mtr2 As DataRow
    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        hh("EHSAN ULLAH")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'hh()
    End Sub
    Public Sub hh(NAMEX As String)
        Dim DBCon As New OleDb.OleDbConnection(SqlConnectionString2)
        Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT CHECKINOUT.USERID,CHECKINOUT.CHECKTIME ,  USERINFO.SSN,  USERINFO.Name FROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID  WHERE USERINFO.Name='" & NAMEX & "'", DBCon)
        Dim ds As New DataSet()
        da.Fill(ds)
        Dim MyTableCount As Integer = ds.Tables.Count
        Dim k As Integer = 1
        DataT.Rows.Clear()

        'Dim db As New CsmdBioAttendenceEntities
        'Dim dt = (From a In db.Attendence_Status Select a.Attendence_Status_ID, a.Attendence_Status_Type).ToList
        'If dt.Count > 0 Then
        Dim DBCon2 As New OleDb.OleDbConnection(SqlConnectionString2)
        Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.Name FROM USERINFO WHERE USERINFO.Name='" & NAMEX & "'", DBCon)
        Dim ds2 As New DataSet()
        da2.Fill(ds2)

        'For U As Integer = 1 To 10



        For Each row5 As DataRow In ds2.Tables(0).Rows
            If CStr(row5.Item(1)) = 1 Or CStr(row5.Item(1)) = 3 Or CStr(row5.Item(1)) = 5 Or CStr(row5.Item(1)) = 7 Or CStr(row5.Item(1)) = 9 Then
                Mtr = DataT.NewRow
                Mtr.Item("Name") = NAMEX
                Mtr.Item("A_Date") = CDate(Now.ToString)




                'If CStr(row5.Item(2)) = "RT-Check In" Then

                For Each row3 As DataRow In ds.Tables(0).Rows
                    Dim datet As DateTime = CStr(row3.Item(1)).ToString
                    If CStr(row3.Item(2)) = "RT-Check In" And datet.Date = Today.Date And CStr(row5.Item(0)) = CStr(row3.Item(0)) Then
                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                        Dim timg As String = bb.ToString("HH:mm").ToString
                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                        Mtr.Item("A_SSN") = CStr(row3.Item(2)).ToString
                        Mtr.Item("A_Time") = timg
                    End If
                    If CStr(row3.Item(2)) = "RP-Private A" And datet.Date = Today.Date And CStr(row5.Item(0)) = CStr(row3.Item(0)) Then
                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                        Dim timg As String = bb.ToString("HH:mm").ToString
                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                        Mtr.Item("A_SSN") = CStr(row3.Item(2)).ToString
                        Mtr.Item("A_Time") = timg
                    End If
                Next

                'End If
                'If CStr(row5.Item(2)) = "LT-Check Out" Then



            Else
                For Each row3 As DataRow In ds.Tables(0).Rows
                    Dim datet As DateTime = CStr(row3.Item(1)).ToString
                    Dim ooo As Integer = CInt(row5.Item(0)) + 1
                    Dim ppp As Integer = CInt(row3.Item(0)) + 1
                    If CStr(row3.Item(2)) = "LT-Check Out" And datet.Date = Today.Date And ooo = CInt(row3.Item(0)) + 1 Then
                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                        Dim timg As String = bb.ToString("HH:mm").ToString
                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                        Mtr.Item("B_SSN") = CStr(row3.Item(2)).ToString
                        Mtr.Item("B_Time") = timg
                    End If
                    If CStr(row3.Item(2)) = "LP-Private B" And datet.Date = Today.Date And ooo = CInt(row3.Item(0)) + 1 Then
                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                        Dim timg As String = bb.ToString("HH:mm").ToString
                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                        Mtr.Item("B_SSN") = CStr(row3.Item(2)).ToString
                        Mtr.Item("B_Time") = timg
                    End If
                Next
                'End If
                ''''''''If CStr(row5.Item(2)) = "RR-Lunch A" Then

                ''''''''    For Each row3 As DataRow In ds.Tables(0).Rows
                ''''''''        Dim datet As DateTime = CStr(row3.Item(1)).ToString
                ''''''''        If row5.Item(0) = row3.Item(0) And datet.Date = Today.Date Then
                ''''''''            Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                ''''''''            Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                ''''''''            Dim timg As String = bb.ToString("HH:mm").ToString
                ''''''''            'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                ''''''''            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                ''''''''            Mtr.Item("A_SSN") = CStr(row3.Item(2)).ToString
                ''''''''            Mtr.Item("A_Time") = timg
                ''''''''        End If
                ''''''''    Next

                ''''''''End If
                ''''''''If CStr(row5.Item(2)) = "LR-Lunch B" Then

                ''''''''    For Each row3 As DataRow In ds.Tables(0).Rows
                ''''''''        Dim datet As DateTime = CStr(row3.Item(1)).ToString
                ''''''''        If row5.Item(0) = row3.Item(0) And datet.Date = Today.Date Then
                ''''''''            Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                ''''''''            Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                ''''''''            Dim timg As String = bb.ToString("HH:mm").ToString
                ''''''''            'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                ''''''''            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                ''''''''            Mtr.Item("B_SSN") = CStr(row3.Item(2)).ToString
                ''''''''            Mtr.Item("B_Time") = timg
                ''''''''        End If
                ''''''''    Next

                ''''''''End If
                ''''''''If CStr(row5.Item(2)) = "RP-Private A" Then

                ''''''''    For Each row3 As DataRow In ds.Tables(0).Rows
                ''''''''        Dim datet As DateTime = CStr(row3.Item(1)).ToString
                ''''''''        If row5.Item(0) = row3.Item(0) And datet.Date = Today.Date Then
                ''''''''            Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                ''''''''            Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                ''''''''            Dim timg As String = bb.ToString("HH:mm").ToString
                ''''''''            'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                ''''''''            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                ''''''''            Mtr.Item("A_SSN") = CStr(row3.Item(2)).ToString
                ''''''''            Mtr.Item("A_Time") = timg
                ''''''''        End If
                ''''''''    Next

                ''''''''End If
                ''''''''If CStr(row5.Item(2)) = "LP-Private B" Then

                ''''''''    For Each row3 As DataRow In ds.Tables(0).Rows
                ''''''''        Dim datet As DateTime = CStr(row3.Item(1)).ToString
                ''''''''        If row5.Item(0) = row3.Item(0) And datet.Date = Today.Date Then
                ''''''''            Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                ''''''''            Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                ''''''''            Dim timg As String = bb.ToString("HH:mm").ToString
                ''''''''            'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                ''''''''            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                ''''''''            Mtr.Item("B_SSN") = CStr(row3.Item(2)).ToString
                ''''''''            Mtr.Item("B_Time") = timg
                ''''''''        End If
                ''''''''    Next

                ''''''''End If
                'For Each row3 As DataRow In ds.Tables(0).Rows

                '    Mtr = DataT.NewRow
                '    Mtr.Item("Name") = NAMEX
                '    Mtr.Item("A_Date") = CDate(Now.ToString)


                '    Dim datet As DateTime = CStr(row3.Item(1)).ToString
                '    If row5.Item(0) = row3.Item(0) Then
                '        If CStr(row3.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                '            'For Each row As DataRow In ds.Tables(0).Rows
                '            'ListBox1.Items.Add(row.Item("TABLE_NAME"))


                '            Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                '            Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                '            Dim timg As String = bb.ToString("HH:mm").ToString
                '            'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
                '            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                '            Mtr.Item("A_SSN") = CStr(row3.Item(2)).ToString
                '            Mtr.Item("A_Time") = timg
                '            'End If
                '            'Next
                '        End If
                '        If CStr(row3.Item(2)) = "LT-Check Out" And datet.Date = Today.Date Then
                '            For Each row As DataRow In ds.Tables(0).Rows
                '                'ListBox1.Items.Add(row.Item("TABLE_NAME"))
                '                'Dim datet As DateTime = CStr(row3.Item(1)).ToString

                '                Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
                '                Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
                '                Dim timg As String = bb.ToString("HH:mm").ToString
                '                If CStr(row.Item(2)) = "LT-Check Out" And datet.Date = Today.Date Then
                '                    'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
                '                    Mtr.Item("B_SSN") = CStr(row3.Item(2)).ToString
                '                    Mtr.Item("B_Time") = timg
                '                End If
                '            Next
                '        End If

                '    End If


                'Next
                k += 1
                DataT.Rows.Add(Mtr)
            End If
        Next

        'Next
        'For Each row3 As DataRow In ds.Tables(0).Rows
        '    Dim datet2 As DateTime = CStr(row3.Item(1)).ToString
        '    If datet2.Date = Today.Date Then


        '        'Mtr = DataT.NewRow
        '        'Mtr.Item("USERID") = k
        '        'Mtr.Item("A_Date") = CStr(row3.Item(1)).ToString 'CType(Now.ToString("dd-MMM-yyyy").ToString, Date?)
        '        'Mtr.Item("Name") = NAMEX

        '        'For Each rr In dt


        '        For Each row2 As DataRow In ds.Tables(0).Rows
        '            Dim datet4 As DateTime = CStr(row2.Item(1)).ToString
        '            ''If CStr(row2.Item(2)) = "RT-Check In" And datet4.Date = Today.Date Then
        '            ''    For Each row As DataRow In ds.Tables(0).Rows
        '            ''        'ListBox1.Items.Add(row.Item("TABLE_NAME"))
        '            ''        Dim datet As DateTime = CStr(row2.Item(1)).ToString

        '            ''        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
        '            ''        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
        '            ''        Dim timg As String = bb.ToString("HH:mm").ToString
        '            ''        If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
        '            ''            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
        '            ''            Mtr.Item("A_SSN") = CStr(row2.Item(2)).ToString
        '            ''            Mtr.Item("A_Time") = timg
        '            ''        End If
        '            ''    Next
        '            ''End If
        '            ''If CStr(row2.Item(2)) = "LT-Check Out" And datet4.Date = Today.Date Then
        '            ''    For Each row As DataRow In ds.Tables(0).Rows
        '            ''        'ListBox1.Items.Add(row.Item("TABLE_NAME"))
        '            ''        Dim datet As DateTime = CStr(row2.Item(1)).ToString

        '            ''        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
        '            ''        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
        '            ''        Dim timg As String = bb.ToString("HH:mm").ToString
        '            ''        If CStr(row.Item(2)) = "LT-Check Out" And datet.Date = Today.Date Then
        '            ''            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
        '            ''            Mtr.Item("B_SSN") = CStr(row2.Item(2)).ToString
        '            ''            Mtr.Item("B_Time") = timg
        '            ''        End If
        '            ''    Next
        '            ''End If
        '            'If CStr(row2.Item(2)) = "RP-Private A" And datet4.Date = Today.Date Then
        '            '    For Each row As DataRow In ds.Tables(0).Rows
        '            '        'ListBox1.Items.Add(row.Item("TABLE_NAME"))
        '            '        Dim datet As DateTime = CStr(row2.Item(1)).ToString

        '            '        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
        '            '        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
        '            '        Dim timg As String = bb.ToString("HH:mm").ToString
        '            '        If CStr(row2.Item(2)) = CStr(row.Item(2)) And datet.Date = Today.Date Then
        '            '            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
        '            '            Mtr.Item("A_SSN") = CStr(row2.Item(2)).ToString
        '            '            Mtr.Item("A_Time") = timg
        '            '        End If
        '            '    Next
        '            'End If
        '            'If CStr(row2.Item(2)) = "LP-Private B" And datet4.Date = Today.Date Then
        '            '    For Each row As DataRow In ds.Tables(0).Rows
        '            '        'ListBox1.Items.Add(row.Item("TABLE_NAME"))
        '            '        Dim datet As DateTime = CStr(row2.Item(1)).ToString

        '            '        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
        '            '        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
        '            '        Dim timg As String = bb.ToString("HH:mm").ToString
        '            '        If CStr(row2.Item(2)) = CStr(row.Item(2)) And datet.Date = Today.Date Then
        '            '            'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
        '            '            Mtr.Item("B_SSN") = CStr(row2.Item(2)).ToString
        '            '            Mtr.Item("B_Time") = timg
        '            '        End If
        '            '    Next
        '            'End If
        '        Next
        '        k += 1
        '        'Next
        '        DataT.Rows.Add(Mtr)
        '    End If
        'Next
        ''''For Each row As DataRow In ds.Tables(0).Rows
        ''''    'ListBox1.Items.Add(row.Item("TABLE_NAME"))
        ''''    Dim datet As DateTime = CStr(row.Item(1)).ToString

        ''''    Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
        ''''    Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
        ''''    Dim timg As String = bb.ToString("HH:mm").ToString
        ''''    Mtr.Item("A_Date") = CType(aa.ToString("dd-MMM-yyyy").ToString, Date?)





        ''''    If CStr(row.Item(2)) = "RT-Check In" Then
        ''''        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
        ''''        Mtr.Item("A_SSN") = CStr(row.Item(2)).ToString
        ''''        Mtr.Item("A_Time") = timg
        ''''    End If
        ''''    If CStr(row.Item(2)) = "LT-Check Out" Then
        ''''        'ckB = CStr(CDate(bb.ToString("HH:mm").ToString))
        ''''        'Dim fff As DateTime = CDate(If(ckA = "", "00:00", ckA))
        ''''        'Dim ggg As DateTime = CDate(If(ckB = "", "00:00", ckB))
        ''''        'Dim duration As Integer = CInt(DateDiff(DateInterval.Minute, fff, ggg))
        ''''        'ToCi = duration
        ''''        '.Emp_Attendence_Device_Cal2 = CStr(ToCi)
        ''''        Mtr.Item("B_SSN") = CStr(row.Item(2)).ToString
        ''''        Mtr.Item("B_Time") = timg
        ''''    End If





        ''''    'Mtr.Item("SC_Select") = False
        ''''    'Mtr.Item("SC_Insert") = False
        ''''    'Mtr.Item("SC_Update") = False
        ''''    'Mtr.Item("SC_Delete") = False



        ''''Next row


        'End If


        'GridView1.Columns("ADD").Visible = True
        GridControl1.DataSource = Nothing
        GridControl1.DataSource = DataT ' ds.Tables(0)
        'GridView1.Columns("CHECKTIME").DisplayFormat.FormatString = "G"
        'GridView1.Columns("CHECKTIME").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        'GridView1.Columns("mm").DisplayFormat.FormatString = "d"
        'GridView1.Columns("mm").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        'GridView1.Columns("nn").DisplayFormat.FormatString = "t"
        'GridView1.Columns("nn").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        DBCon.Close()
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataT.Columns.Add("USERID", GetType(Integer))
        DataT.Columns.Add("A_Date", GetType(Date))
        DataT.Columns.Add("Name", GetType(String))

        DataT.Columns.Add("A_SSN", GetType(String))
        DataT.Columns.Add("A_Time", GetType(String))
        DataT.Columns.Add("B_SSN", GetType(String))
        DataT.Columns.Add("B_Time", GetType(String))
    End Sub
End Class