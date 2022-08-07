Option Explicit On
Option Strict On

Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting

Public Class frmAttCalculations
    Public dSumDutyX As Integer = 0
    Public dSum1X As Integer = 0
    Public dSum1aX As Integer = 0
    Public dSum1bX As Integer = 0
    Public dSum1cX As Integer = 0
    Public dSum2X As Integer = 0
    Public dSum2aX As Integer = 0
    Public dSum3X As Integer = 0
    Public dSum3aX As Integer = 0
    Public dSum4X As Integer = 0
    Public dSum4aX As Integer = 0
    Public dSum5X As Integer = 0
    Public dSum5aX As Integer = 0
    Public dSum6X As Integer = 0
    Public dSum6aX As Integer = 0
    Dim duration As Integer = 0
    Dim duration2 As Integer = 0
    Dim Tim As Integer = 0
    Dim Tdm As Integer = 0
    Dim Abse As Integer = 0

    Dim DutyOn1X As DateTime
    Dim DutyOn2X As DateTime
    Dim DutyOffX As DateTime
    Dim DutyFriX As DateTime

    Private Sub frmAttCalculations_Load(sender As Object, e As EventArgs) Handles Me.Load
        Using db As New CsmdBioAttendenceEntities
            F5.Text = "0"

            Emp_Att_Payment_Issue_Date.EditValue = intAttDate



            Dim datX As Date = CDate(intAttDate)
            Dim dtj = (From a In db.Emp_Att_Set Where a.Emp_Att_Set_Date.Value.Month = datX.Month And a.Emp_Att_Set_Date.Value.Year = datX.Year Select a).FirstOrDefault
            If dtj IsNot Nothing Then
                With dtj


                    DutyOn1.Text = .Emp_Att_Set_DutyOn
                    DutyOn2.Text = .Emp_Att_Set_DutyOn
                    DutyOff.Text = .Emp_Att_Set_DutyOff
                    DutyFri.Text = .Emp_Att_Set_FridayOff
                    DutyOn1X = CDate(CDate(.Emp_Att_Set_DutyOn).ToString("HH:mm"))
                    DutyOn2X = CDate(CDate(.Emp_Att_Set_DutyOn).ToString("HH:mm"))
                    DutyOffX = CDate(CDate(.Emp_Att_Set_DutyOff).ToString("HH:mm"))
                    DutyFriX = CDate(CDate(.Emp_Att_Set_FridayOff).ToString("HH:mm"))
                End With

            Else

            End If
            'dXA = CStr(CDate(bb.ToString("HH:mm").ToString))
            '                                End If
            'If finNa = 10 Then
            '    dXB = CStr(CDate(bb.ToString("HH:mm").ToString))
            '    Dim fff As DateTime = CDate(If(dXA = "", "00:00", dXA))
            '    Dim ggg As DateTime = CDate(If(dXB = "", "00:00", dXB))
            duration = CInt(DateDiff(DateInterval.Minute, DutyOn1X, DutyOffX))
            duration2 = CInt(DateDiff(DateInterval.Minute, DutyOn2X, DutyFriX))
            '    CalStatus += duration
            Dim frmD As DateTime = CDate(intAttDate)
            Dim dtMin = (From a In db.Emp_Attendence_Device
                          Where a.Emp_Attendence_Device_Date.Value.Month = frmD.Month And a.Emp_Attendence_Device_Date.Value.Year = frmD.Year Select a.Emp_Attendence_Device_Date).Min
            If dtMin IsNot Nothing Then
                Emp_Att_Payment_From_Date.EditValue = FirstDayOfMonth(CDate(dtMin))
            End If

            Dim dtMax = (From a In db.Emp_Attendence_Device
                          Where a.Emp_Attendence_Device_Date.Value.Month = frmD.Month And a.Emp_Attendence_Device_Date.Value.Year = frmD.Year Select a.Emp_Attendence_Device_Date).Max
            If dtMax IsNot Nothing Then
                Emp_Att_Payment_To_Date.EditValue = dtMax
            End If


            'If dt.Count > 0 Then
            'var MinDate = (from d in dataRows select d.Date).Min();
            'Dtp1.EditValue = "11/6/2019"
            'Dtp2.EditValue = "11/30/2019"

            Dim fff As DateTime = CType(Emp_Att_Payment_From_Date.EditValue, Date) ' CDate(If(CStr(Dtp1.EditValue) = "", "00:00", CStr(Dtp1.EditValue)))
            Dim ggg As DateTime = CType(Emp_Att_Payment_To_Date.EditValue, Date) 'CDate(If(CStr(Dtp2.EditValue) = "", "00:00", CStr(Dtp2.EditValue)))
            ''Dim duration As Integer = DateDiff(DateInterval.Hour, fff, ggg)
            'Dim day As Integer = DateDiff(DateInterval.Day, fff, ggg)
            ''Dim HH1 As Integer = CInt(DateDiff("h", CType(Dtp1.EditValue, Date), CType(Dtp1.EditValue, Date)))
            ''Dim DD1 As Integer = CInt(DateDiff("d", CType(Dtp1.EditValue, Date), CType(Dtp1.EditValue, Date)))
            'H1.Text = CStr(TotalHours(duration * day))
            'D1.Text = CStr(day)
            'H1.Text = CStr(TotalHours(duration * day))
            'D1.Text = CStr(day)
            Dim x1 As Double = 0
            Dim x2 As Double = 0
            Dim w1 As Double = 0
            Dim w2 As Double = 0
            Dim w3 As Double = 0
            Dim w4 As Double = 0
            Dim w5 As Double = 0
            Dim w6 As Double = 0
            Dim w7 As Double = 0
            Dim w8 As Double = 0
            Dim w9 As Double = 0
            Dim w10 As Double = 0
            Dim w11 As Double = 0
            Dim w12 As Double = 0
            Dim w13 As Double = 0
            Dim w14 As Double = 0
            Dim w15 As Double = 0
            Dim w16 As Double = 0

            For loopDate As Double = fff.ToOADate To ggg.ToOADate
                Dim nn As Integer = 0
                dSum4X = 0
                Dim thisDate As Date = DateTime.FromOADate(loopDate)
                If thisDate.DayOfWeek = DayOfWeek.Friday Then
                    w2 += 1
                Else
                    w1 += 1
                End If
                Dim dt = (From a In db.Emp_Attendence_Device
                           Where a.Emp_ID = intEmpID And a.Emp_Attendence_Device_Date = thisDate
                            Select a).ToList
                If dt.Count > 0 Then
                    Dim hhhg As Boolean = False
                    For Each dts In dt
                        With dts

                            Dim datet As DateTime = CDate(CStr(.Emp_Attendence_Device_Date).ToString)
                            If thisDate.Date = datet.Date Then


                                Dim val1 As String = .Emp_Attendence_Device_Cal1
                                Dim val2 As String = .Emp_Attendence_Device_Cal2
                                Dim val3 As String = .Emp_Attendence_Device_Cal3
                                Dim val4 As String = .Emp_Attendence_Device_Cal4
                                Dim val5 As String = .Emp_Attendence_Device_Cal5

                                'If Not val4 = "" And IsNumeric(val4) Then
                                '    dSumDutyX += val4
                                '    w4 += 1
                                'End If

                                If Not val3 = "" And IsNumeric(val3) Then
                                    dSum1X += CInt(val3)
                                    w4 += 1
                                End If
                                If Not val2 = "" And IsNumeric(val2) Then
                                    '
                                    If .Attendence_Status_ID = 1 Then
                                        dSum1aX += CInt(val2)
                                        w5 += 1
                                    End If
                                    If .Attendence_Status_ID = 2 Then
                                        If CInt(val2) > 0 Then
                                            dSum1bX += CInt(val2)
                                            w6 += 1
                                        Else
                                            dSum1cX -= CInt(val2)
                                            w7 += 1
                                        End If

                                    End If

                                End If
                                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                                If .Attendence_Status_ID = 4 Then
                                    If Not val1 = "" And IsNumeric(val1) Then
                                        dSum2X += CInt(val1)
                                    End If
                                    If Not val2 = "" And IsNumeric(val2) Then
                                        dSum2aX += CInt(val2)
                                        w9 += 1
                                    End If
                                End If
                                If .Attendence_Status_ID = 6 Then
                                    If Not val1 = "" And IsNumeric(val1) Then
                                        dSum3X += CInt(val1)
                                    End If
                                    If Not val2 = "" And IsNumeric(val2) Then
                                        dSum3aX += CInt(val2)
                                        w10 += 1
                                    End If
                                End If

                                If .Attendence_Status_ID = 8 Then
                                    If hhhg = False Then
                                        Dim dtm = (From a In db.Emp_Attendence_Device
                                                   Where a.Emp_ID = intEmpID And a.Emp_Attendence_Device_Date = thisDate And a.Attendence_Status_ID = 8
                                                   Select a.Emp_Attendence_Device_ID).Max
                                        If Not IsNothing(dtm) Then
                                            Dim dtn = (From a In db.Emp_Attendence_Device Where a.Emp_Attendence_Device_ID = dtm
                                                       Select a).FirstOrDefault
                                            If dtn IsNot Nothing Then
                                                Dim kop As String = dtn.Emp_Attendence_Device_Cal2
                                                'MsgBox(dtn.Emp_Attendence_Device_Date & " --- " & dtn.Emp_Attendence_Device_Cal2)
                                                If Not kop = "" And IsNumeric(kop) Then
                                                    If CDbl(kop) > 0 Then
                                                        w11 += 1
                                                        dSum4aX += CInt(kop)
                                                        'MsgBox(dSum4aX & "=" & dtn.Emp_Attendence_Device_Time & " --- " & dtn.Emp_Attendence_Device_Date)
                                                    End If
                                                    If CDbl(kop) < 0 Then
                                                        dSum6aX += CInt(kop)
                                                        w16 += 1
                                                        'MsgBox(dSum6aX & "=" & dtn.Emp_Attendence_Device_Time & " --- " & dtn.Emp_Attendence_Device_Date)
                                                    End If
                                                End If
                                            End If
                                        End If
                                        If Not val1 = "" And IsNumeric(val1) Then
                                            dSum4X += CInt(val1)
                                        End If
                                        'If Not val2 = "" And IsNumeric(val2) Then

                                        '    'If CDbl(val2) > 0 Then
                                        '    dSum4aX += CInt(val2)
                                        '    w11 += 1
                                        '    'End If
                                        '    'If CDbl(val2) < 0 Then
                                        '    '    'dSum6aX += 30 - CInt(val2)
                                        '    '    dSum6aX += CInt(val2)
                                        '    '    w16 += 1
                                        '    'End If
                                        'End If

                                        hhhg = True
                                    End If

                                End If

                                If .Attendence_Status_ID = 10 Then
                                    If Not val1 = "" And IsNumeric(val1) Then
                                        dSum5X += CInt(val1)
                                    End If
                                    If Not val2 = "" And IsNumeric(val2) Then
                                        dSum5aX += CInt(val2)
                                        w12 += 1
                                    End If
                                End If
                            Else


                            End If
                        End With
                        Emp_Name.Text = dts.Employee.Emp_Name
                    Next
                Else
                    If thisDate.DayOfWeek = DayOfWeek.Friday Then
                        x2 += 1
                    Else
                        x1 += 1
                    End If
                End If
                'nn = dSum4X - intSp4
                'If nn > 0 Then
                '    w11 += 1
                '    dSum4aX += nn
                'End If
                'If nn < 0 Then
                '    dSum6aX += nn
                '    w16 += 1
                'End If
            Next

            'A3.Text = CStr(10000)

            H1.Text = TotalHours(CInt(w1 * duration))
            H2.Text = TotalHours(CInt(w2 * duration2))
            D1.Text = CStr(w1)
            D2.Text = CStr(w2)
            Tim = CInt((w1 * duration) + (w2 * duration2))
            H3.Text = TotalHours(Tim)
            Tdm = CInt(w1 + w2)
            D3.Text = CStr(Tdm)



            Dim gg As Integer = CInt((x1 * duration) + (x2 * duration2))
            'Dim gg As Integer = CInt((x1 * duration) + (x2 * duration2))

            H15.Text = TotalHours(gg)
            Abse = CInt(x1 + x2)
            'D15.Text = CStr(Abse)

            'If Emp_Att_Payment_Add_Days.Text = "0" Or Emp_Att_Payment_Add_Days.Text = "" Then
            '    D15.Text = CStr(Abse) ' CStr(IfNull(D15) - IfNull(D16))
            'Else
            '    D15.Text = CStr(IfNull(D15) - IfNull(Emp_Att_Payment_Add_Days))
            'End If
            'H16.Text = TotalHours(CInt(x2 * duration2))
            'D16.Text = CStr(x2)

            H4.Text = TotalHours(dSum1X)
            D4.Text = CStr(w4)


            H5.Text = TotalHours(dSum1aX)
            D5.Text = CStr(w5)
            H6.Text = TotalHours(dSum1bX)
            D6.Text = CStr(w6)
            H7.Text = TotalHours(dSum1cX)
            D7.Text = CStr(w7)

            H9.Text = TotalHours(dSum2aX)
            D9.Text = CStr(w9)
            H10.Text = TotalHours(dSum3aX)
            D10.Text = CStr(w10)

            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx





            'If nn > 0 Then
            H11.Text = TotalHours(dSum4aX)
            'w11 += 1
            D11.Text = CStr(w11)

            'End If

            'If nn < 0 Then

            H17.Text = TotalHours(Math.Abs(dSum6aX))
            'w16 += 1
            D17.Text = CStr(w16)
            'End If



            H12.Text = TotalHours(dSum5aX)
            D12.Text = CStr(w12)
            'H4.Text = TotalHours(dSum1X)
            'H5.Text = TotalHours(dSum1aX)
            'H7.Text = TotalHours(dSum1bX)
            'H8.Text = TotalHours(dSum1aX - dSum1bX)
            ' '' ''dSum2.Text = TotalHours(dSum2X)
            '' '' ''H9.Text = TotalHours(dSum2aX)
            ' '' ''dSum3.Text = TotalHours(dSum3X)
            '' '' ''H10.Text = TotalHours(dSum3aX)
            ' '' ''dSum4.Text = TotalHours(dSum4X)
            '' '' ''H11.Text = TotalHours(dSum4aX)
            ' '' ''dSum5.Text = TotalHours(dSum5X)
            '' '' ''H12.Text = TotalHours(dSum5aX)

            'tSum1.Text = TotalHours(dSum2X + dSum3X + dSum4X + dSum5X)
            'H13.Text = TotalHours(dSum2aX + dSum3aX + dSum4aX + dSum5aX)

            'H14.Text = TotalHours((dSum1aX - dSum1bX) + (dSum2aX + dSum3aX + dSum4aX + dSum5aX))
            'End If
            Load_Att_Payment()
        End Using
    End Sub
    Public Function TotalHours(sum As Integer) As String
        Dim hours As Integer = sum \ 60
        Dim minutes As Integer = sum - (hours * 60)
        Dim timeElapsed As String = CType(hours, String) & ":" & CType(minutes, String)
        Return timeElapsed
    End Function

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim controlContainer As New PrintableComponentContainer()
        controlContainer.PrintableComponent = LayoutControl1
        '.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        'Dim myReport As New MyCustomXtraReportWithHeader()
        'Dim detailBand As DetailBand = myReport.Bands(BandKind.Detail)
        'detailBand.Controls.Add(controlContainer)


        'LayoutControl1.ShowPrintPreview()

        'Dim link As New PrintableComponentLink()
        'link.Component = CType(controlContainer.PrintableComponent, IPrintable)
        'link.Margins = New System.Drawing.Printing.Margins(50, 50, 50, 50)
        'link.CreateDocument()

        'link.ShowPreview()
        Dim pSystem As New DevExpress.XtraPrinting.PrintingSystem
        Dim pLink As New DevExpress.XtraPrinting.PrintableComponentLink()

        pSystem.Links.Add(pLink)
        pLink.Component = LayoutControl1
        Dim margins As New System.Drawing.Printing.Margins(10, 10, 10, 10)
        pLink.Margins = margins
        pLink.Landscape = False
        pLink.PaperKind = System.Drawing.Printing.PaperKind.Custom
        pLink.CustomPaperSize = New Size(CInt(70 * 4), CInt(210 * 4))
        'pLink.PaperKind = Printing.PaperSize(90, 110) ' .PaperKind.PrcEnvelopeNumber5
        'pLink.PaperKind = Printing.PaperKind.Prc32KBig
        pSystem.Document.AutoFitToPagesWidth = 0

        'Set Header/Footer if desired  

        'Header  
        'Dim myHead As New DevExpress.XtraPrinting.PageHeaderArea

        ''Footer  
        'Dim myFoot As New DevExpress.XtraPrinting.PageFooterArea
        'Dim left As String = String.Empty
        'Dim cent As String = "DISCLAIMER: This is a work in progress. This application was complied " &
        '  "by the Marion county Property Appraiser's Office soley for the governmental purpose of property " &
        '  "assessment. These are NOT surveys. Our goal is to provide the most accurate data available, however, " &
        '  "no warranties, expressed or implied are provided with this data, its use, or interpretation. All information " &
        '  "subject to change without notice. Use at your own risk."
        'Dim right As String = String.Empty
        'myFoot.Content.AddRange(New String() {left, cent, right})
        'Dim myHeadFoot As New DevExpress.XtraPrinting.PageHeaderFooter(myHead, myFoot)
        'pLink.PageHeaderFooter = myHeadFoot


        'Dim width As Integer = MapControl1.Width
        'Dim height As Integer = MapControl1.Height
        'Dim myScale As Single = 1
        'Dim docWidth As Integer = pSystem.Document.PrintingSystem.PageBounds.Width - 100
        'Dim docHeight As Integer = pSystem.Document.PrintingSystem.PageBounds.Height - 100
        'Dim wScale As Single = CType(docWidth / width, Single)
        'Dim hScale As Single = CType(docHeight / height, Single)


        'If wScale < hScale Then
        '    myScale = wScale
        'Else
        '    myScale = hScale
        'End If
        'pSystem.Document.ScaleFactor = myScale
        pLink.CreateDocument()
        pLink.ShowPreviewDialog()
    End Sub

    Public Sub CallSummary()
        Dim S3 As Double = IfNull(Emp_Att_Payment_Fix)
        Dim S4 As Double = IfNull(F4)
        Dim S5 As Double = IfNull(F5)
        Dim S6 As Double = IfNull(F6)
        Dim S7 As Double = IfNull(F7)

        Dim S9 As Double = IfNull(F9)
        Dim S10 As Double = IfNull(F10)
        Dim S11 As Double = IfNull(F11)
        Dim S12 As Double = IfNull(F12)


        Dim H3 As Double = IfNull(D3)
        Dim H4 As Double = IfNull(D4)
        Dim H55 As Double = IfNull(D5)
        Dim HH6 As Double = IfNull(D6)
        Dim HH7 As Double = IfNull(D7)

        Dim HH9 As Double = IfNull(D9)
        Dim HH10 As Double = IfNull(D10)
        Dim HH11 As Double = IfNull(D11)
        Dim HH12 As Double = IfNull(D12)
        Dim H15 As Double = IfNull(D15)
        Dim H16 As Double = IfNull(Emp_Att_Payment_Add_Days)

        'MsgBox(duration)
        Dim THm As Double = CDbl(IfNull(Emp_Att_Payment_Fix) / CDbl(Tdm))
        Dim THo As Double = CDbl(IfNull(Emp_Att_Payment_Fix) / CDbl(Tim))


        F1.Text = CStr(THm)
        F2.Text = CStr(THm)

        A1.Text = CStr(IfNull(F1) * IfNull(D1))
        A2.Text = CStr(IfNull(F2) * IfNull(D2))

        F15.Text = CStr(IfNull(F1))
        F16.Text = CStr(IfNull(F1))


        Dim S15 As Double = IfNull(F15)
        Dim S16 As Double = IfNull(F16)

        'D15.Text = CStr(IfNull(D15) - IfNull(D16))
        A16.Text = CStr((H16 * S16))
        If Emp_Att_Payment_Add_Days.Text = "0" Or Emp_Att_Payment_Add_Days.Text = "" Then
            D15.Text = CStr(Abse) ' CStr(IfNull(D15) - IfNull(D16))
        Else
            D15.Text = CStr(Abse - IfNull(Emp_Att_Payment_Add_Days))
        End If
        A15.Text = CStr(-(CDbl(IfNull(D15)) * S15))
        A4.Text = CStr(-(H4 * S4))


        'Dim SH5 As Integer = Minute(CDate(IfNulll(H5)))
        'F5.Text = "0" ' CStr(THo)
        A5.Text = CStr(-(dSum1aX * CDbl(IfNull(F5))))

        'Dim SH6 As Integer = Minute(CDate(IfNulll(H6)))
        F6.Text = CStr(THo)
        A6.Text = CStr(-(dSum1bX * THo))

        'Dim SH7 As Integer = Minute(CDate(IfNulll(H7)))
        F7.Text = CStr(THo)
        A7.Text = CStr((dSum1cX * THo))

        Dim ds1 As Double = (CDbl(A4.Text) + CDbl(A5.Text) + CDbl(A6.Text))
        'Dim datet As DateTime = CDate(CDate(IfNulll(H9)).ToString("HH:mm"))
        'Dim SH9 As Integer =datet.Minute ' Minute(CDate(CDate(IfNulll(H9)).ToString("HH:mm")))
        F9.Text = CStr(THo)
        A9.Text = CStr(-(dSum2aX * THo))
        'Dim SH10 As Integer = Minute(CDate(IfNulll(H10)))
        F10.Text = CStr(THo)
        A10.Text = CStr(-(dSum3aX * THo))
        'Dim SH11 As Integer = Minute(CDate(IfNulll(H11)))
        F11.Text = CStr(THo)
        A11.Text = CStr(-(dSum4aX * THo))
        F17.Text = CStr(THo)
        A17.Text = CStr((Math.Abs(dSum6aX) * THo))
        'Dim SH12 As Integer = Minute(CDate(CDate(IfNulll(H12)).ToString("HH:mm")))
        F12.Text = CStr(THo)
        A12.Text = CStr(-(dSum5aX * THo))


        'Dim aaa As Double = (CDbl(A15.Text) + CDbl(A16.Text)) + (CDbl(A9.Text) + CDbl(A10.Text)) + (CDbl(A11.Text) + CDbl(A12.Text))
        Dim aaa As Double = (CDbl(A15.Text) + CDbl(A9.Text) + CDbl(A10.Text)) + (CDbl(A11.Text) + CDbl(A12.Text))
        Dim bbb As Double = CDbl(A7.Text) + CDbl(A17.Text)

        'Dim ds2 As Double = bbb

        Dim DS12 As Double = -ds1 - aaa
        Dim hjhj As Double = bbb - DS12
        A13.Text = CStr(S3 + hjhj)
        '      A13.Text = CStr(S3 + CDbl(IfNull(A15)) + (CDbl(A4.Text) + CDbl(A5.Text)) - (CDbl(A6.Text) + CDbl(A7.Text)) + (CDbl(A9.Text) + CDbl(A10.Text)) + (CDbl(A11.Text) + CDbl(A12.Text)))

        Dim B1 As Double = IfNull(Emp_Att_Payment_Beg)
        Dim B6 As Double = IfNull(Emp_Att_Payment_Bonus)
        Dim B16 As Double = B1 + B6
        Dim Btot As Double = IfNull(A13) + B16

        Dim B2 As Double = IfNull(Emp_Att_Payment_Advance)
        Dim B5 As Double = IfNull(Emp_Att_Payment_Fine)
        Dim B25 As Double = B2 + B5
        'Tot1.Text = CStr(B3)
        'Emp_Att_Payment_Amount.Text = CStr(IfNull(A13))
        Dim BBtot As Double = Btot - B25

        'Dim B7 As Double = B3 + B6 - B5 '- IfNull(A13)
        Emp_Att_Payment_Total.Text = CStr(BBtot)
        Dim B8 As Double = IfNull(Emp_Att_Payment_Paid)
        Emp_Att_Payment_Balance.Text = CStr(BBtot - B8)






    End Sub

    Private Sub Pay_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Att_Payment_Beg.EditValueChanged, Emp_Att_Payment_Advance.EditValueChanged, Emp_Att_Payment_Fine.EditValueChanged, Emp_Att_Payment_Bonus.EditValueChanged, Emp_Att_Payment_Paid.EditValueChanged
        CallSummary()
    End Sub
    Private Sub F15_EditValueChanged(sender As Object, e As KeyEventArgs) Handles Emp_Att_Payment_Paid.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveUpdate_Att_Payment()
        End If
    End Sub

    Private Sub A3ToF15_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Att_Payment_Fix.EditValueChanged, F15.EditValueChanged
        CallSummary()
    End Sub
    Private Sub F4ToF7_EditValueChanged(sender As Object, e As EventArgs) Handles F4.EditValueChanged, F5.EditValueChanged, F6.EditValueChanged, F7.EditValueChanged
        CallSummary()
    End Sub
    Private Sub F9ToF12_EditValueChanged(sender As Object, e As EventArgs) Handles F9.EditValueChanged, F10.EditValueChanged, F11.EditValueChanged, F12.EditValueChanged
        CallSummary()
    End Sub

    Private Sub D16_EditValueChanged(sender As Object, e As EventArgs) Handles Emp_Att_Payment_Add_Days.EditValueChanged
        'If CDbl(D16.Text) = 0 Or D16.Text = "" Then
        '    D15.Text = CStr(Abse) ' CStr(IfNull(D15) - IfNull(D16))
        'Else
        '    D15.Text = CStr(IfNull(D15) - IfNull(D16))
        'End If


        CallSummary()
    End Sub

    Private Sub Load_Att_Payment()
        Using db As New CsmdBioAttendenceEntities
            Dim Emp_Att_Payment_From_DateX As DateTime = CDate(Emp_Att_Payment_From_Date.EditValue)
            Dim Emp_Att_Payment_From_DateXbeg As DateTime = DateTime.Parse(CStr(Emp_Att_Payment_From_Date.EditValue)).AddMonths(-1)

            Dim dtBeg = (From a In db.Emp_Att_Payment Where a.Emp_ID = intEmpID And a.Emp_Att_Payment_From_Date.Value.Month = Emp_Att_Payment_From_DateXbeg.Month And a.Emp_Att_Payment_From_Date.Value.Year = Emp_Att_Payment_From_DateXbeg.Year Select a).FirstOrDefault
            If dtBeg IsNot Nothing Then
                Emp_Att_Payment_Beg.Text = CStr(dtBeg.Emp_Att_Payment_Balance)
            Else
                Emp_Att_Payment_Beg.Text = CStr(0)
            End If

            Dim dt = (From a In db.Emp_Att_Payment Where a.Emp_ID = intEmpID And a.Emp_Att_Payment_From_Date.Value.Month = Emp_Att_Payment_From_DateX.Month And a.Emp_Att_Payment_From_Date.Value.Year = Emp_Att_Payment_From_DateX.Year Select a).FirstOrDefault
            If dt IsNot Nothing Then
                With dt
                    F5.Text = CStr(If(.Emp_Att_Payment_Late IsNot Nothing, .Emp_Att_Payment_Late, 0))
                    Emp_Att_Payment_Issue_Date.EditValue = .Emp_Att_Payment_Issue_Date
                    '.Emp_Att_Payment_From_Date
                    '.Emp_Att_Payment_To_Date
                    Emp_Att_Payment_Add_Days.Text = CStr(.Emp_Att_Payment_Add_Days)
                    Emp_Att_Payment_Fix.Text = CStr(.Emp_Att_Payment_Fix)
                    Emp_Att_Payment_Advance.Text = CStr(.Emp_Att_Payment_Advance)
                    'Emp_Att_Payment_Amount.Text = CStr(.Emp_Att_Payment_Amount)
                    Emp_Att_Payment_Fine.Text = CStr(.Emp_Att_Payment_Fine)
                    Emp_Att_Payment_Bonus.Text = CStr(.Emp_Att_Payment_Bonus)
                    Emp_Att_Payment_Total.Text = CStr(.Emp_Att_Payment_Total)
                    Emp_Att_Payment_Paid.Text = CStr(.Emp_Att_Payment_Paid)
                    Emp_Att_Payment_Balance.Text = CStr(.Emp_Att_Payment_Balance)
                End With

            Else

            End If
        End Using
    End Sub

    Private Sub SaveUpdate_Att_Payment()
        Using db As New CsmdBioAttendenceEntities
            Dim Emp_Att_Payment_Issue_DateX As DateTime = CDate(Emp_Att_Payment_Issue_Date.EditValue)
            Dim Emp_Att_Payment_From_DateX As DateTime = CDate(Emp_Att_Payment_From_Date.EditValue)
            Dim Emp_Att_Payment_To_DateX As DateTime = CDate(Emp_Att_Payment_To_Date.EditValue)
            Dim dt = (From a In db.Emp_Att_Payment Where a.Emp_ID = intEmpID And a.Emp_Att_Payment_From_Date.Value.Month = Emp_Att_Payment_From_DateX.Month And a.Emp_Att_Payment_From_Date.Value.Year = Emp_Att_Payment_From_DateX.Year Select a).FirstOrDefault
            If dt IsNot Nothing Then
                With dt
                    .Emp_Att_Payment_Issue_Date = Emp_Att_Payment_Issue_DateX
                    .Emp_Att_Payment_From_Date = Emp_Att_Payment_From_DateX
                    .Emp_Att_Payment_To_Date = Emp_Att_Payment_To_DateX
                    .Emp_Att_Payment_Add_Days = IfNull(Emp_Att_Payment_Add_Days)
                    .Emp_Att_Payment_Late = CType(IfNull(F5), Decimal?)
                    .Emp_Att_Payment_Fix = CType(IfNull(Emp_Att_Payment_Fix), Decimal?)
                    .Emp_Att_Payment_Beg = CType(IfNull(Emp_Att_Payment_Beg), Decimal?)
                    .Emp_Att_Payment_Advance = CType(IfNull(Emp_Att_Payment_Advance), Decimal?)
                    '.Emp_Att_Payment_Amount = CType(IfNull(Emp_Att_Payment_Amount), Decimal?)
                    .Emp_Att_Payment_Fine = CType(IfNull(Emp_Att_Payment_Fine), Decimal?)
                    .Emp_Att_Payment_Bonus = CType(IfNull(Emp_Att_Payment_Bonus), Decimal?)
                    .Emp_Att_Payment_Total = CType(IfNull(Emp_Att_Payment_Total), Decimal?)
                    .Emp_Att_Payment_Paid = CType(IfNull(Emp_Att_Payment_Paid), Decimal?)
                    .Emp_Att_Payment_Balance = CType(IfNull(Emp_Att_Payment_Balance), Decimal?)
                End With
                db.SaveChanges()
                MsgBox("Update Record is Successfull")
            Else
                Dim dtNew = New Emp_Att_Payment With {.Emp_ID = intEmpID,
                    .Emp_Att_Payment_Issue_Date = Emp_Att_Payment_Issue_DateX,
                    .Emp_Att_Payment_From_Date = Emp_Att_Payment_From_DateX,
                    .Emp_Att_Payment_To_Date = Emp_Att_Payment_To_DateX,
                    .Emp_Att_Payment_Add_Days = IfNull(Emp_Att_Payment_Add_Days),
                    .Emp_Att_Payment_Late = CType(IfNull(F5), Decimal?),
                    .Emp_Att_Payment_Fix = CType(IfNull(Emp_Att_Payment_Fix), Decimal?),
                    .Emp_Att_Payment_Beg = CType(IfNull(Emp_Att_Payment_Beg), Decimal?),
                    .Emp_Att_Payment_Advance = CType(IfNull(Emp_Att_Payment_Advance), Decimal?),
                    .Emp_Att_Payment_Fine = CType(IfNull(Emp_Att_Payment_Fine), Decimal?),
                    .Emp_Att_Payment_Bonus = CType(IfNull(Emp_Att_Payment_Bonus), Decimal?),
                    .Emp_Att_Payment_Total = CType(IfNull(Emp_Att_Payment_Total), Decimal?),
                    .Emp_Att_Payment_Paid = CType(IfNull(Emp_Att_Payment_Paid), Decimal?),
                    .Emp_Att_Payment_Balance = CType(IfNull(Emp_Att_Payment_Balance), Decimal?)
}
                '.Emp_Att_Payment_Amount = CType(IfNull(Emp_Att_Payment_Amount), Decimal?),
                db.Emp_Att_Payment.Add(dtNew)
                db.SaveChanges()
                MsgBox("Add Record is Successfull")
            End If
        End Using
    End Sub
 
End Class