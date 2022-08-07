Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports CsmdAttendenceViewer
Public Class UserControl5
    Dim DataT As New DataTable
    Dim Mtr As DataRow
    Public Const SqlConnectionString2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\ZKTeco\att2000.mdb"
    Public Sub LoadManualDevice()

        Dim DBCon2 As New OleDb.OleDbConnection(SqlConnectionString2)
        Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.Name, CHECKINOUT.CHECKTIME FROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID;", DBCon2)
        Dim ds2 As New DataSet()
        da2.Fill(ds2)

        If ds2.Tables(0).Rows.Count > 0 Then

            GridControl2.DataSource = ds2.Tables(0)
            GridView2.Columns("CHECKTIME").DisplayFormat.FormatString = "G"
            GridView2.Columns("CHECKTIME").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            GridView2.Columns("CHECKTIME").SortOrder = DevExpress.Data.ColumnSortOrder.Descending

        End If
    End Sub


    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        '  LoadAttendenceFromDevice(Dtp1.EditValue)
        LoadManualDevice()
    End Sub
    'Private Sub LoadAttendenceFromDevice(DtpX As DateTime)
    '    Dim DBCon As New OleDb.OleDbConnection(SqlConnectionString2) '  WHERE USERINFO.Name='" & NAMEX & "'
    '    'Dim DtpX As DateTime = Dtp1.EditValue
    '    Dim da As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT CHECKINOUT.USERID,CHECKINOUT.CHECKTIME, USERINFO.SSN,  USERINFO.Name FROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID ORDER BY CHECKINOUT.CHECKTIME", DBCon)
    '    Dim ds As New DataSet()
    '    da.Fill(ds)
    '    Dim MyTableCount As Integer = ds.Tables(0).Rows.Count
    '    Dim k As Integer = 1
    '    Dim bolx As Boolean = False
    '    Dim boly As Boolean = False
    '    Dim bolz As Boolean = False
    '    DataT.Rows.Clear()
    '    For Each row5 As DataRow In ds.Tables(0).Rows
    '        Dim datet2 As DateTime = CDate(row5.Item(1)).ToString
    '        Dim empn As String = CStr(row5.Item(3)).ToString
    '        'If datet2.Date = Today.Date Then


    '        'If CStr(row5.Item(2)) = "RT-Check In" Or CStr(row5.Item(2)) = "RI-Prayer A" Or CStr(row5.Item(2)) = "RM-Short Leave A" Or CStr(row5.Item(2)) = "RR-Lunch A" Or CStr(row5.Item(2)) = "RP-Private A" And datet2.Date = Today.Date Then
    '        If CStr(row5.Item(2)) = "RT-Check In" And datet2.Date = DtpX.Date Then

    '            Mtr = DataT.NewRow
    '            Mtr.Item("USERID") = k
    '            Mtr.Item("Name") = empn
    '            Mtr.Item("A_Date") = datet2.Date
    '            'If CStr(row5.Item(2)) = "RT-Check In" Or CStr(row5.Item(2)) = "LT-Check Out" And datet2.Date = Today.Date Then

    '            'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    '            For Each row As DataRow In ds.Tables(0).Rows
    '                Dim datet3 As DateTime = CDate(row.Item(1)).ToString
    '                'If CStr(row.Item(2)) = "RT-Check In" Or CStr(row.Item(2)) = "RI-Prayer A" Or CStr(row.Item(2)) = "RM-Short Leave A" Or CStr(row.Item(2)) = "RR-Lunch A" Or CStr(row.Item(2)) = "RP-Private A" Then
    '                If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "RT-Check In" And datet3.Date = DtpX.Date Then
    '                    'If CStr(row5.Item(2)) = "RT-Check In" Or CStr(row5.Item(2)) = "RI-Prayer A" Or CStr(row5.Item(2)) = "RM-Short Leave A" Or CStr(row5.Item(2)) = "RR-Lunch A" Or CStr(row5.Item(2)) = "RP-Private A" And datet2.Date = Today.Date Then

    '                    Dim datet As DateTime = CDate(row.Item(1)).ToString


    '                    Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                    Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                    Dim timg As String = bb.ToString("HH:mm").ToString
    '                    'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                    'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                    Mtr.Item("A_SSN") = CStr(row.Item(2)).ToString
    '                    Mtr.Item("A_Time") = timg

    '                End If
    '                If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "LT-Check Out" And datet3.Date = DtpX.Date Then
    '                    'If CStr(row5.Item(2)) = "LT-Check Out" Or CStr(row5.Item(2)) = "LI-Prayer B" Or CStr(row5.Item(2)) = "LM-Short Leave B" Or CStr(row5.Item(2)) = "LR-Lunch B" Or CStr(row5.Item(2)) = "LP-Private B" And datet2.Date = Today.Date Then

    '                    'If CStr(row.Item(2)) = "LT-Check Out" Or CStr(row.Item(2)) = "LI-Prayer B" Or CStr(row.Item(2)) = "LM-Short Leave B" Or CStr(row.Item(2)) = "LR-Lunch B" Or CStr(row.Item(2)) = "LP-Private B" Then
    '                    Dim datet As DateTime = CDate(row.Item(1)).ToString

    '                    'Mtr = DataT.NewRow
    '                    'Mtr.Item("USERID") = CStr(row.Item(0)).ToString
    '                    'Mtr.Item("Name") = CStr(row.Item(3)).ToString
    '                    'Mtr.Item("A_Date") = datet.Date

    '                    Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                    Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                    Dim timg As String = bb.ToString("HH:mm").ToString
    '                    'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                    'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                    Mtr.Item("B_SSN") = CStr(row.Item(2)).ToString
    '                    Mtr.Item("B_Time") = timg
    '                    k += 1
    '                    DataT.Rows.Add(Mtr)

    '                    Exit For
    '                End If
    '            Next
    '        End If
    '        Dim bol As Boolean = False
    '        Dim bolv As Boolean = False
    '        'CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
    '        If CStr(row5.Item(2)) = "RP-Private A" And datet2.Date = DtpX.Date Then
    '            If bolx = False Then
    '                Mtr = DataT.NewRow
    '                Mtr.Item("USERID") = k
    '                Mtr.Item("Name") = empn
    '                Mtr.Item("A_Date") = datet2.Date
    '                For Each row As DataRow In ds.Tables(0).Rows
    '                    Dim datet3 As DateTime = CDate(row.Item(1)).ToString
    '                    'If CStr(row.Item(2)) = "RT-Check In" Or CStr(row.Item(2)) = "RI-Prayer A" Or CStr(row.Item(2)) = "RM-Short Leave A" Or CStr(row.Item(2)) = "RR-Lunch A" Or CStr(row.Item(2)) = "RP-Private A" Then

    '                    If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "RP-Private A" And datet3.Date = DtpX.Date Then
    '                        If bol = True Then
    '                            Mtr = DataT.NewRow
    '                            Mtr.Item("USERID") = k
    '                            Mtr.Item("Name") = empn
    '                            Mtr.Item("A_Date") = datet2.Date
    '                            bol = False

    '                        End If
    '                        'If CStr(row5.Item(2)) = "RT-Check In" Or CStr(row5.Item(2)) = "RI-Prayer A" Or CStr(row5.Item(2)) = "RM-Short Leave A" Or CStr(row5.Item(2)) = "RR-Lunch A" Or CStr(row5.Item(2)) = "RP-Private A" And datet2.Date = Today.Date Then

    '                        Dim datet As DateTime = CDate(row.Item(1)).ToString


    '                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                        Dim timg As String = bb.ToString("HH:mm").ToString
    '                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                        Mtr.Item("A_SSN") = CStr(row.Item(2)).ToString
    '                        Mtr.Item("A_Time") = timg
    '                        bolv = True
    '                    End If
    '                    If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "LP-Private B" And datet3.Date = DtpX.Date Then
    '                        If bolv = False Then
    '                            Mtr = DataT.NewRow
    '                            Mtr.Item("USERID") = k
    '                            Mtr.Item("Name") = empn
    '                            Mtr.Item("A_Date") = datet2.Date
    '                        End If

    '                        'If CStr(row5.Item(2)) = "LT-Check Out" Or CStr(row5.Item(2)) = "LI-Prayer B" Or CStr(row5.Item(2)) = "LM-Short Leave B" Or CStr(row5.Item(2)) = "LR-Lunch B" Or CStr(row5.Item(2)) = "LP-Private B" And datet2.Date = Today.Date Then

    '                        'If CStr(row.Item(2)) = "LT-Check Out" Or CStr(row.Item(2)) = "LI-Prayer B" Or CStr(row.Item(2)) = "LM-Short Leave B" Or CStr(row.Item(2)) = "LR-Lunch B" Or CStr(row.Item(2)) = "LP-Private B" Then
    '                        Dim datet As DateTime = CDate(row.Item(1)).ToString

    '                        'Mtr = DataT.NewRow
    '                        'Mtr.Item("USERID") = CStr(row.Item(0)).ToString
    '                        'Mtr.Item("Name") = CStr(row.Item(3)).ToString
    '                        'Mtr.Item("A_Date") = datet.Date

    '                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                        Dim timg As String = bb.ToString("HH:mm").ToString
    '                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                        Mtr.Item("B_SSN") = CStr(row.Item(2)).ToString
    '                        Mtr.Item("B_Time") = timg
    '                        k += 1
    '                        DataT.Rows.Add(Mtr)
    '                        bol = True
    '                        bolv = False
    '                        'Exit For
    '                    End If
    '                Next
    '                If bolv = True Then
    '                    k += 1
    '                    DataT.Rows.Add(Mtr)
    '                    bolv = False
    '                End If

    '                bolx = True
    '            End If
    '        End If
    '        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    '        Dim bolm As Boolean = False
    '        Dim boln As Boolean = False
    '        'CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
    '        If CStr(row5.Item(2)) = "RR-Lunch A" Or CStr(row5.Item(2)) = "LR-Lunch B" And datet2.Date = DtpX.Date Then
    '            If boly = False Then
    '                Mtr = DataT.NewRow
    '                Mtr.Item("USERID") = k
    '                Mtr.Item("Name") = empn
    '                Mtr.Item("A_Date") = datet2.Date
    '                For Each row As DataRow In ds.Tables(0).Rows
    '                    Dim datet3 As DateTime = CDate(row.Item(1)).ToString("dd-MMM-yyyy")
    '                    'If CStr(row.Item(2)) = "RT-Check In" Or CStr(row.Item(2)) = "RI-Prayer A" Or CStr(row.Item(2)) = "RM-Short Leave A" Or CStr(row.Item(2)) = "RR-Lunch A" Or CStr(row.Item(2)) = "RP-Private A" Then

    '                    If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "RR-Lunch A" And datet3.Date = DtpX.Date Then
    '                        If bolm = True Then
    '                            Mtr = DataT.NewRow
    '                            Mtr.Item("USERID") = k
    '                            Mtr.Item("Name") = empn
    '                            Mtr.Item("A_Date") = datet2.Date
    '                            bolm = False
    '                        End If
    '                        'If CStr(row5.Item(2)) = "RT-Check In" Or CStr(row5.Item(2)) = "RI-Prayer A" Or CStr(row5.Item(2)) = "RM-Short Leave A" Or CStr(row5.Item(2)) = "RR-Lunch A" Or CStr(row5.Item(2)) = "RP-Private A" And datet2.Date = Today.Date Then

    '                        Dim datet As DateTime = CDate(row.Item(1)).ToString


    '                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                        Dim timg As String = bb.ToString("HH:mm").ToString
    '                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                        Mtr.Item("A_SSN") = CStr(row.Item(2)).ToString
    '                        Mtr.Item("A_Time") = timg
    '                        boln = True
    '                    End If
    '                    If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "LR-Lunch B" And datet3.Date = DtpX.Date Then
    '                        If boln = False Then
    '                            Mtr = DataT.NewRow
    '                            Mtr.Item("USERID") = k
    '                            Mtr.Item("Name") = empn
    '                            Mtr.Item("A_Date") = datet2.Date
    '                        End If
    '                        'If CStr(row5.Item(2)) = "LT-Check Out" Or CStr(row5.Item(2)) = "LI-Prayer B" Or CStr(row5.Item(2)) = "LM-Short Leave B" Or CStr(row5.Item(2)) = "LR-Lunch B" Or CStr(row5.Item(2)) = "LP-Private B" And datet2.Date = Today.Date Then

    '                        'If CStr(row.Item(2)) = "LT-Check Out" Or CStr(row.Item(2)) = "LI-Prayer B" Or CStr(row.Item(2)) = "LM-Short Leave B" Or CStr(row.Item(2)) = "LR-Lunch B" Or CStr(row.Item(2)) = "LP-Private B" Then
    '                        Dim datet As DateTime = CDate(row.Item(1)).ToString

    '                        'Mtr = DataT.NewRow
    '                        'Mtr.Item("USERID") = CStr(row.Item(0)).ToString
    '                        'Mtr.Item("Name") = CStr(row.Item(3)).ToString
    '                        'Mtr.Item("A_Date") = datet.Date

    '                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                        Dim timg As String = bb.ToString("HH:mm").ToString
    '                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                        Mtr.Item("B_SSN") = CStr(row.Item(2)).ToString
    '                        Mtr.Item("B_Time") = timg
    '                        k += 1
    '                        DataT.Rows.Add(Mtr)
    '                        bolm = True
    '                        boln = False
    '                        'Exit For
    '                    End If
    '                Next
    '                If boln = True Then
    '                    k += 1
    '                    DataT.Rows.Add(Mtr)
    '                    boln = False
    '                End If
    '                boly = True
    '            End If
    '        End If

    '        'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    '        Dim bolmm As Boolean = False
    '        Dim bolnn As Boolean = False
    '        'CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC
    '        If CStr(row5.Item(2)) = "RI-Prayer A" Or CStr(row5.Item(2)) = "LI-Prayer B" And datet2.Date = DtpX.Date Then
    '            If bolz = False Then
    '                Mtr = DataT.NewRow
    '                Mtr.Item("USERID") = k
    '                Mtr.Item("Name") = empn
    '                Mtr.Item("A_Date") = datet2.Date
    '                For Each row As DataRow In ds.Tables(0).Rows
    '                    Dim datet3 As DateTime = CDate(row.Item(1)).ToString
    '                    'If CStr(row.Item(2)) = "RT-Check In" Or CStr(row.Item(2)) = "RI-Prayer A" Or CStr(row.Item(2)) = "RM-Short Leave A" Or CStr(row.Item(2)) = "RR-Lunch A" Or CStr(row.Item(2)) = "RP-Private A" Then

    '                    If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "RI-Prayer A" And datet3.Date = DtpX.Date Then
    '                        If bolmm = True Then
    '                            Mtr = DataT.NewRow
    '                            Mtr.Item("USERID") = k
    '                            Mtr.Item("Name") = empn
    '                            Mtr.Item("A_Date") = datet2.Date
    '                            bolmm = False
    '                        End If
    '                        'If CStr(row5.Item(2)) = "RT-Check In" Or CStr(row5.Item(2)) = "RI-Prayer A" Or CStr(row5.Item(2)) = "RM-Short Leave A" Or CStr(row5.Item(2)) = "RR-Lunch A" Or CStr(row5.Item(2)) = "RP-Private A" And datet2.Date = Today.Date Then

    '                        Dim datet As DateTime = CDate(row.Item(1)).ToString


    '                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                        Dim timg As String = bb.ToString("HH:mm").ToString
    '                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                        Mtr.Item("A_SSN") = CStr(row.Item(2)).ToString
    '                        Mtr.Item("A_Time") = timg
    '                        bolnn = True
    '                    End If
    '                    If CStr(row.Item(3)) = empn And CStr(row.Item(2)) = "LI-Prayer B" And datet3.Date = DtpX.Date Then
    '                        If bolnn = False Then
    '                            Mtr = DataT.NewRow
    '                            Mtr.Item("USERID") = k
    '                            Mtr.Item("Name") = empn
    '                            Mtr.Item("A_Date") = datet2.Date
    '                        End If
    '                        'If CStr(row5.Item(2)) = "LT-Check Out" Or CStr(row5.Item(2)) = "LI-Prayer B" Or CStr(row5.Item(2)) = "LM-Short Leave B" Or CStr(row5.Item(2)) = "LR-Lunch B" Or CStr(row5.Item(2)) = "LP-Private B" And datet2.Date = Today.Date Then

    '                        'If CStr(row.Item(2)) = "LT-Check Out" Or CStr(row.Item(2)) = "LI-Prayer B" Or CStr(row.Item(2)) = "LM-Short Leave B" Or CStr(row.Item(2)) = "LR-Lunch B" Or CStr(row.Item(2)) = "LP-Private B" Then
    '                        Dim datet As DateTime = CDate(row.Item(1)).ToString

    '                        'Mtr = DataT.NewRow
    '                        'Mtr.Item("USERID") = CStr(row.Item(0)).ToString
    '                        'Mtr.Item("Name") = CStr(row.Item(3)).ToString
    '                        'Mtr.Item("A_Date") = datet.Date

    '                        Dim aa As DateTime = datet.Date '("dd-MMM-yyyy").tostring
    '                        Dim bb As DateTime = CDate(datet.TimeOfDay.ToString)
    '                        Dim timg As String = bb.ToString("HH:mm").ToString
    '                        'If CStr(row.Item(2)) = "RT-Check In" And datet.Date = Today.Date Then
    '                        'ckA = CStr(CDate(bb.ToString("HH:mm").ToString))
    '                        Mtr.Item("B_SSN") = CStr(row.Item(2)).ToString
    '                        Mtr.Item("B_Time") = timg
    '                        k += 1
    '                        DataT.Rows.Add(Mtr)
    '                        bolmm = True
    '                        bolnn = False
    '                        'Exit For
    '                    End If
    '                Next
    '                If bolnn = True Then
    '                    k += 1
    '                    DataT.Rows.Add(Mtr)
    '                    bolnn = False
    '                End If
    '                bolz = True
    '            End If
    '        End If

    '        'End If
    '    Next
    '    'If MyTableCount > 0 Then
    '    GridControl1.DataSource = Nothing
    '    GridControl1.DataSource = DataT 'ds.Tables(0)
    '    'Else
    '    '    GridControl1.DataSource = Nothing
    '    'End If
    'End Sub
    Private Sub UserControl5_Load(sender As Object, e As EventArgs) Handles Me.Load




        DataT.Columns.Add("USERID", GetType(Integer))
        DataT.Columns.Add("A_Date", GetType(Date))
        DataT.Columns.Add("Name", GetType(String))

        DataT.Columns.Add("A_SSN", GetType(String))
        DataT.Columns.Add("A_Time", GetType(String))
        DataT.Columns.Add("B_SSN", GetType(String))
        DataT.Columns.Add("B_Time", GetType(String))

        Dtp1.EditValue = Today.Date

    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle

        'If e.Column.FieldName = "A_SSN" Then
        '    If e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Red
        '        'Else
        '        '    e.Appearance.BackColor = Color.Green
        '        If e.Column.FieldName = "B_SSN" Then
        '            If Not e.CellValue.ToString = "" Then
        '                e.Appearance.BackColor = Color.Red
        '            End If
        '        End If
        '    End If
        'End If
        'If e.Column.FieldName = "B_SSN" Then
        '    If e.CellValue.ToString = "" Then
        '        e.Appearance.BackColor = Color.Yellow
        '        'Else
        '        '    e.Appearance.BackColor = Color.Green
        '    End If
        'End If
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub BarEditItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Dtp1.ItemClick

    End Sub

    Private Sub RepositoryItemDateEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemDateEdit1.ButtonClick
        Select Case e.Button.Index
            Case 1
                Dim d1 As DateTime = CDate(Dtp1.EditValue)

                Dtp1.EditValue = DateTime.Parse(d1).AddDays(-1)

            Case 2
                Dim d1 As DateTime = CDate(Dtp1.EditValue)

                Dtp1.EditValue = DateTime.Parse(d1).AddDays(1)
        End Select
        Timer1.Enabled = False
        BarEditItem1.EditValue = False
        BarTime.Caption = "Stop"
        'LoadAttendenceFromDevice(Dtp1.EditValue)
    End Sub

    Private Sub Dtp1_EditValueChanged(sender As Object, e As EventArgs) Handles Dtp1.EditValueChanged
        'LoadAttendenceFromDevice(Dtp1.EditValue)
    End Sub

    Private Sub BarEditItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarEditItem1.ItemClick

    End Sub

    Private Sub RepositoryItemToggleSwitch1_Toggled(sender As Object, e As EventArgs) Handles RepositoryItemToggleSwitch1.Toggled
        Dim ToggleSwitch As ToggleSwitch = TryCast(sender, ToggleSwitch)
        If ToggleSwitch.IsOn Then
            Timer1.Enabled = True

        Else
            Timer1.Enabled = False
            BarTime.Caption = "Stop"
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BarTime.Caption = Now
        '   LoadAttendenceFromDevice(Dtp1.EditValue)
        LoadManualDevice()
    End Sub





    'Private Sub timey_Tick(sender As Object, e As EventArgs)
    '    frmkk.Text = "Csmd Employees Attendence Software with Device Live Preview > " & Now
    '    '   LoadAttendenceFromDevice(Dtp1.EditValue)
    '    'LoadManualDevice()
    'End Sub

    'Dim frmkk As Form = New Form
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick

        'Dim frm As Form = New CsmdAttendenceViewer.Form1

        'frm.Show()
        ''Try

        'Dim timey As New Timer
        '    Dim uc As UserControl = New UserControl5
        '    uc.Dock = DockStyle.Fill
        '    frmkk.StartPosition = FormStartPosition.CenterScreen
        '    frmkk.WindowState = FormWindowState.Maximized
        '    frmkk.Controls.Add(uc)
        '    'frmkk.Text =
        '    AddHandler timey.Tick, AddressOf timey_Tick
        '    timey.Interval = 1000
        '    timey.Enabled = True
        Form1.Show()
        'Catch ex As Exception
        '    frmkk.Show()
        'End Try
    End Sub


End Class
