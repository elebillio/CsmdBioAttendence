Imports System.Drawing.Drawing2D
Imports CsmdBioDatabase
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.BandedGrid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI

Public Class frmPayments

    Dim TempGridCheckMarksSelection As New GridCheckMarksSelectionxx
    Private Sub frmPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(AdvBandedGridView1)
        TempGridCheckMarksSelection.View.OptionsSelection.InvertSelection = True
        ' Dim tempVar As New LinesDrawHelper(AdvBandedGridView1)
        '  tempVar(AdvBandedGridView1)
        AdvBandedGridView1.IndicatorWidth = 35
    End Sub
    Private Sub LoadEmp()
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Try
                Dim dt = (From c In db.Emp_Att_Payment Where c.Employee.Emp_Status = True
                          Order By c.Emp_Att_Payment_Issue_Date Ascending
                          Select New With {.ID = c.Employee.Emp_ID, c.Employee.Emp_Name, c.Employee.Emp_Status, c.Emp_Att_Payment_ID, .Emp_Att_Payment_Issue_Date = c.Emp_Att_Payment_Issue_Date.Value.Month & "-" & c.Emp_Att_Payment_Issue_Date.Value.Year,
                              c.Emp_Att_Payment_Total_MonthDays, .dr1 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_Fix,
                            c.Emp_Att_Payment_Absent_D, .dr2 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_Absent_Amount,
                              c.Emp_Att_Payment_Total_OffDays, .dr3 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_Total_OffDays_Amount,
                              c.Emp_Att_Payment_InOutDays, .dr4 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_InOutDays_Amount,
                              c.Emp_Att_Payment_ExtraDays, .dr5 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_ExtraDays_Amount,
                              c.Emp_Att_Payment_Salaray_Total,
                              c.Emp_Att_Payment_Late_D, c.Emp_Att_Payment_Late_H, c.Emp_Att_Payment_Late, c.Emp_Att_Payment_Late_Amount,
                              c.Emp_Att_Payment_Early_D, c.Emp_Att_Payment_Early_H, .min1 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Early_Amount,
                              c.Emp_Att_Payment_OverTime_D, c.Emp_Att_Payment_OverTime_H, .min2 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_OverTime_Amount,
                              c.Emp_Att_Payment_Prayer_Late_D, c.Emp_Att_Payment_Prayer_Late_H, .min3 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Prayer_Late_Amount,
                              c.Emp_Att_Payment_Short_D, c.Emp_Att_Payment_Short_H, .min4 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Short_Amount,
                              c.Emp_Att_Payment_Lunch_Late_D, c.Emp_Att_Payment_Lunch_Late_H, .min5 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Lunch_Late_Amount,
                              c.Emp_Att_Payment_Lunch_OverTime_D, c.Emp_Att_Payment_Lunch_OverTime_H, .min6 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Lunch_OverTime_Amount,
                              c.Emp_Att_Payment_Private_Late_D, c.Emp_Att_Payment_Private_Late_H, .min7 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Private_Late_Amount,
                              c.Emp_Att_Payment_Amount,
                              c.Emp_Att_Payment_Beg,
                              c.Emp_Att_Payment_Advance, c.Emp_Att_Payment_Fine, c.Emp_Att_Payment_Bonus,
                              c.Emp_Att_Payment_Total, c.Emp_Att_Payment_Paid, c.Emp_Att_Payment_Balance,
                              c.Emp_Att_Payment_Prayer_Late_D_T,
                              c.Emp_Att_Payment_Short_D_T,
                              c.Emp_Att_Payment_Lunch_Late_D_T,
                              c.Emp_Att_Payment_Private_Late_D_T}).ToList
                If dt.Count > 0 Then
                    GridControl1.DataSource = dt
                    '  GridControl1.DataSource = Nothing
                    ' VGridControl1.DataSource = Nothing
                    '  ShowSelectionAtt00000000()
                Else
                    GridControl1.DataSource = Nothing
                End If
            Catch ex As Exception
                GridControl1.DataSource = Nothing
            End Try
        End Using
    End Sub
    Private Sub LoadEmp(Datx As Date)
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Try
                Dim dt = (From c In db.Emp_Att_Payment.Where(Function(o) o.Emp_Att_Payment_Issue_Date.Value.Month = Datx.Month And o.Emp_Att_Payment_Issue_Date.Value.Year = Datx.Year)
                          Order By c.Emp_Att_Payment_Issue_Date Ascending
                          Select New With {.ID = c.Employee.Emp_ID, c.Employee.Emp_Name, c.Employee.Emp_Status, c.Emp_Att_Payment_ID, .Emp_Att_Payment_Issue_Date = c.Emp_Att_Payment_Issue_Date.Value.Month & "-" & c.Emp_Att_Payment_Issue_Date.Value.Year,
                              c.Emp_Att_Payment_Total_MonthDays, .dr1 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_Fix,
                            c.Emp_Att_Payment_Absent_D, .dr2 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_Absent_Amount,
                              c.Emp_Att_Payment_Total_OffDays, .dr3 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_Total_OffDays_Amount,
                              c.Emp_Att_Payment_InOutDays, .dr4 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_InOutDays_Amount,
                              c.Emp_Att_Payment_ExtraDays, .dr5 = c.Emp_Att_Payment_Total_DayRate, c.Emp_Att_Payment_ExtraDays_Amount,
                              c.Emp_Att_Payment_Salaray_Total,
                              c.Emp_Att_Payment_Late_D, c.Emp_Att_Payment_Late_H, c.Emp_Att_Payment_Late, c.Emp_Att_Payment_Late_Amount,
                              c.Emp_Att_Payment_Early_D, c.Emp_Att_Payment_Early_H, .min1 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Early_Amount,
                              c.Emp_Att_Payment_OverTime_D, c.Emp_Att_Payment_OverTime_H, .min2 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_OverTime_Amount,
                              c.Emp_Att_Payment_Prayer_Late_D, c.Emp_Att_Payment_Prayer_Late_H, .min3 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Prayer_Late_Amount,
                              c.Emp_Att_Payment_Short_D, c.Emp_Att_Payment_Short_H, .min4 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Short_Amount,
                              c.Emp_Att_Payment_Lunch_Late_D, c.Emp_Att_Payment_Lunch_Late_H, .min5 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Lunch_Late_Amount,
                              c.Emp_Att_Payment_Lunch_OverTime_D, c.Emp_Att_Payment_Lunch_OverTime_H, .min6 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Lunch_OverTime_Amount,
                              c.Emp_Att_Payment_Private_Late_D, c.Emp_Att_Payment_Private_Late_H, .min7 = c.Emp_Att_Payment_Total_MinRate, c.Emp_Att_Payment_Private_Late_Amount,
                              c.Emp_Att_Payment_Amount,
                              c.Emp_Att_Payment_Beg,
                              c.Emp_Att_Payment_Advance, c.Emp_Att_Payment_Fine, c.Emp_Att_Payment_Bonus,
                              c.Emp_Att_Payment_Total, c.Emp_Att_Payment_Paid, c.Emp_Att_Payment_Balance,
                              c.Emp_Att_Payment_Prayer_Late_D_T,
                              c.Emp_Att_Payment_Short_D_T,
                              c.Emp_Att_Payment_Lunch_Late_D_T,
                              c.Emp_Att_Payment_Private_Late_D_T}).ToList
                If dt.Count > 0 Then
                    GridControl1.DataSource = dt
                    '  GridControl1.DataSource = Nothing
                    ' VGridControl1.DataSource = Nothing
                    '  ShowSelectionAtt00000000()
                Else
                    GridControl1.DataSource = Nothing
                End If
            Catch ex As Exception
                GridControl1.DataSource = Nothing
            End Try
        End Using
    End Sub
    Private Sub RepositoryItemDateEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemDateEdit1.ButtonClick
        Select Case e.Button.Index
            Case 1
                Issue_Date.EditValue = DateTime.Parse(CType(Issue_Date.EditValue, String)).AddMonths(-1)
                ' FF1.EditValue = FirstDayOfMonth(DateTime.Parse(CType(FF1.EditValue, String)).AddMonths(-1))
               ' FF2.EditValue = LastDayOfMonth(DateTime.Parse(CType(FF2.EditValue, String)).AddMonths(-1))
            Case 2
                Issue_Date.EditValue = DateTime.Parse(CType(Issue_Date.EditValue, String)).AddMonths(1)
                '  FF1.EditValue = FirstDayOfMonth(DateTime.Parse(CType(FF1.EditValue, String)).AddMonths(1))
                ' FF2.EditValue = LastDayOfMonth(DateTime.Parse(CType(FF2.EditValue, String)).AddMonths(1))
        End Select
        LoadEmp(CDate(Issue_Date.EditValue))
    End Sub

    Private Sub GridControl1_Click(sender As Object, e As EventArgs) Handles GridControl1.Click

    End Sub
    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        LoadEmp()
        AdvBandedGridView1.Columns("Emp_Att_Payment_Issue_Date").UnGroup()
        AdvBandedGridView1.Columns("Emp_Name").UnGroup()
        AdvBandedGridView1.Columns("Emp_Name").Group()
        AdvBandedGridView1.Columns("Emp_Att_Payment_Issue_Date").Group()
        AdvBandedGridView1.ExpandGroupLevel(0)
    End Sub
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        LoadEmp()

        AdvBandedGridView1.Columns("Emp_Name").UnGroup()
        AdvBandedGridView1.Columns("Emp_Att_Payment_Issue_Date").UnGroup()
        AdvBandedGridView1.Columns("Emp_Att_Payment_Issue_Date").Group()
        AdvBandedGridView1.Columns("Emp_Name").Group()
        AdvBandedGridView1.ExpandGroupLevel(0)

    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        LoadEmp(CDate(Issue_Date.EditValue))
        AdvBandedGridView1.Columns("Emp_Name").UnGroup()
        AdvBandedGridView1.Columns("Emp_Att_Payment_Issue_Date").UnGroup()
    End Sub

    Private Sub BarButtonItem4_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem4.ItemClick
        AdvBandedGridView1.ExpandGroupLevel(1)
    End Sub

    Private Sub BarButtonItem5_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem5.ItemClick
        AdvBandedGridView1.CollapseGroupLevel(1)
    End Sub

    Private Sub BarButtonItem6_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem6.ItemClick
        AdvBandedGridView1.ExpandAllGroups()
    End Sub

    Private Sub BarButtonItem7_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem7.ItemClick
        AdvBandedGridView1.CollapseAllGroups()
    End Sub

    Private Sub AdvBandedGridView1_CustomDrawBandHeader(sender As Object, e As BandHeaderCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawBandHeader

        If e.Band Is Nothing Then
            Return
        End If
        If e.Band.AppearanceHeader.BackColor <> Color.Empty Then
            e.Info.AllowColoring = True
        End If
    End Sub

    Private Sub AdvBandedGridView1_CustomDrawColumnHeader(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawColumnHeader
        If e.Column Is Nothing Then
            Return
        End If
        If e.Column.AppearanceHeader.BackColor <> Color.Empty Then
            e.Info.AllowColoring = True
        End If
    End Sub

    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles AdvBandedGridView1.DoubleClick
        'If AdvBandedGridView1.FocusedColumn.FieldName = "Emp_Att_Payment_ExtraDays" Then
        '    AdvBandedGridView1.Columns("Emp_Att_Payment_ExtraDays").OptionsColumn.AllowEdit = True
        'Else
        '    AdvBandedGridView1.Columns("Emp_Att_Payment_ExtraDays").OptionsColumn.AllowEdit = False
        'End If
    End Sub

    Private Sub AdvBandedGridView1_RowClick(sender As Object, e As RowClickEventArgs) Handles AdvBandedGridView1.RowClick
        ' AdvBandedGridView1.Columns("Emp_Att_Payment_ExtraDays").OptionsColumn.AllowEdit = False
    End Sub

    Private Sub AdvBandedGridView1_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles AdvBandedGridView1.RowCellClick
        If AdvBandedGridView1.FocusedColumn.FieldName = "Emp_Att_Payment_ExtraDays" Then
            AdvBandedGridView1.Columns("Emp_Att_Payment_ExtraDays").OptionsColumn.AllowEdit = True
        Else
            AdvBandedGridView1.Columns("Emp_Att_Payment_ExtraDays").OptionsColumn.AllowEdit = False
        End If
        If AdvBandedGridView1.FocusedColumn.FieldName = "Emp_Att_Payment_Late" Then
            AdvBandedGridView1.Columns("Emp_Att_Payment_Late").OptionsColumn.AllowEdit = True
        Else
            AdvBandedGridView1.Columns("Emp_Att_Payment_Late").OptionsColumn.AllowEdit = False
        End If
        If AdvBandedGridView1.FocusedColumn.FieldName = "Emp_Att_Payment_Advance" Then
            AdvBandedGridView1.Columns("Emp_Att_Payment_Advance").OptionsColumn.AllowEdit = True
        Else
            AdvBandedGridView1.Columns("Emp_Att_Payment_Advance").OptionsColumn.AllowEdit = False
        End If
        If AdvBandedGridView1.FocusedColumn.FieldName = "Emp_Att_Payment_Fine" Then
            AdvBandedGridView1.Columns("Emp_Att_Payment_Fine").OptionsColumn.AllowEdit = True
        Else
            AdvBandedGridView1.Columns("Emp_Att_Payment_Fine").OptionsColumn.AllowEdit = False
        End If
        If AdvBandedGridView1.FocusedColumn.FieldName = "Emp_Att_Payment_Bonus" Then
            AdvBandedGridView1.Columns("Emp_Att_Payment_Bonus").OptionsColumn.AllowEdit = True
        Else
            AdvBandedGridView1.Columns("Emp_Att_Payment_Bonus").OptionsColumn.AllowEdit = False
        End If
        If AdvBandedGridView1.FocusedColumn.FieldName = "Emp_Att_Payment_Paid" Then
            AdvBandedGridView1.Columns("Emp_Att_Payment_Paid").OptionsColumn.AllowEdit = True
        Else
            AdvBandedGridView1.Columns("Emp_Att_Payment_Paid").OptionsColumn.AllowEdit = False
        End If
    End Sub

    Private Sub AdvBandedGridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles AdvBandedGridView1.CellValueChanged

        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim ID As Integer = CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_ID"))
            Dim Salar As Decimal = CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Fix"))

            If e.Column.FieldName = "Emp_Att_Payment_ExtraDays" Then
                Dim InOutAmt As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_InOutDays_Amount"))
                Dim ExtraDay As Integer = CInt(If(e.Value.ToString = "", 0, e.Value))

                Dim DayRate As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("dr5"))

                Dim sds As Decimal = ExtraDay * DayRate
                Dim TotAmount As Decimal = sds + InOutAmt

                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_ExtraDays_Amount", sds)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Salaray_Total", TotAmount)

                Dim R7 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Late_Amount")))
                Dim R8 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Early_Amount")))
                Dim R9 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_OverTime_Amount")))
                Dim R10 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Prayer_Late_Amount")))
                Dim R11 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Short_Amount")))
                Dim R12 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Lunch_Late_Amount")))
                Dim R13 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Lunch_OverTime_Amount")))
                Dim R14 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Private_Late_Amount")))

                Dim over As Decimal = R9 + R13
                Dim mins As Decimal = (R7 + R8) + (R10 + R11) + (R12 + R14)

                Dim salTot As Decimal = (TotAmount + over) - mins



                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Amount", salTot)
                Dim P1 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Beg"))
                Dim P3 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Advance"))
                Dim P4 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Fine"))
                Dim P2 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Bonus"))

                Dim P5 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Paid"))

                Dim pTOT As Decimal = salTot + (P1 + P2) - (P3 + P4)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Total", pTOT)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Balance", pTOT - P5)

                Dim dts = (From a In db.Emp_Att_Payment Where a.Emp_Att_Payment_ID = ID Select a).FirstOrDefault
                If dts IsNot Nothing Then
                    'dts.Emp_Att_Payment_Add_Days = ExtraDay
                    'dts.Emp_Att_Payment_Absent_D = totDa
                    'dts.Emp_Att_Payment_Absent_Amount = -TotAmount
                    dts.Emp_Att_Payment_ExtraDays = ExtraDay
                    dts.Emp_Att_Payment_ExtraDays_Amount = sds
                    dts.Emp_Att_Payment_Salaray_Total = TotAmount
                    dts.Emp_Att_Payment_Amount = salTot
                    dts.Emp_Att_Payment_Total = pTOT
                    dts.Emp_Att_Payment_Balance = pTOT - P5
                    db.SaveChanges()
                End If
            End If
            If e.Column.FieldName = "Emp_Att_Payment_Late" Then
                Dim LateDay As String = CStr(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Late_H"))


                Dim kl As Integer = CInt(LateDay.Split(CType(":", Char()))(0)) * 60 + CInt(LateDay.Split(CType(":", Char()))(1))

                Dim MinRate As Decimal = CDec(If(e.Value.ToString = "", 0, e.Value))

                Dim LateAmount As Decimal = kl * MinRate


                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Late_Amount", -LateAmount)

                'Dim R6 As Decimal = Math.Abs(CInt(VGridControl1.GetCellValue(row6.PropertiesCollection.Item("Emp_Att_Payment_Absent_Amount"), e.RecordIndex)))
                Dim R7 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Late_Amount")))
                Dim R8 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Early_Amount")))
                Dim R9 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_OverTime_Amount")))
                Dim R10 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Prayer_Late_Amount")))
                Dim R11 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Short_Amount")))
                Dim R12 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Lunch_Late_Amount")))
                Dim R13 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Lunch_OverTime_Amount")))
                Dim R14 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Private_Late_Amount")))

                Dim over As Decimal = R9 + R13
                Dim mins As Decimal = (R7 + R8) + (R10 + R11) + (R12 + R14) '+ R6

                Dim salTot As Decimal = (Salar + over) - mins


                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Amount", salTot)
                Dim P1 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Beg"))
                Dim P3 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Advance"))
                Dim P4 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Fine"))
                Dim P2 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Bonus"))

                Dim P5 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Paid"))

                Dim pTOT As Decimal = salTot + (P1 + P2) - (P3 + P4)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Total", pTOT)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Balance", pTOT - P5)

                Dim dts = (From a In db.Emp_Att_Payment Where a.Emp_Att_Payment_ID = ID Select a).FirstOrDefault
                If dts IsNot Nothing Then
                    dts.Emp_Att_Payment_Late = MinRate
                    dts.Emp_Att_Payment_Late_Amount = -LateAmount
                    dts.Emp_Att_Payment_Amount = salTot
                    dts.Emp_Att_Payment_Total = pTOT
                    dts.Emp_Att_Payment_Balance = pTOT - P5
                    db.SaveChanges()
                End If
                'LoadEmp(CDate(Issue_Date.EditValue))
            End If
            If e.Column.FieldName = "Emp_Att_Payment_Advance" Then
                Dim Advanced As Decimal = CDec(If(e.Value.ToString = "", 0, e.Value))
                Dim P0 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Amount"))
                Dim P1 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Beg"))
                'Dim P3 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Advance"))
                Dim P4 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Fine"))
                Dim P2 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Bonus"))

                Dim P5 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Paid"))

                Dim pTOT As Decimal = P0 + (P1 + P2) - (Advanced + P4)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Total", pTOT)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Balance", pTOT - P5)
                Dim dts = (From a In db.Emp_Att_Payment Where a.Emp_Att_Payment_ID = ID Select a).FirstOrDefault
                If dts IsNot Nothing Then
                    dts.Emp_Att_Payment_Advance = Advanced
                    dts.Emp_Att_Payment_Total = pTOT
                    dts.Emp_Att_Payment_Balance = pTOT - P5
                    db.SaveChanges()
                End If
                'LoadEmp(CDate(Issue_Date.EditValue))
            End If
            If e.Column.FieldName = "Emp_Att_Payment_Fine" Then
                Dim Fined As Decimal = CDec(If(e.Value.ToString = "", 0, e.Value))
                'VGridControl1.SetCellValue(row4.PropertiesCollection.Item("Emp_Att_Payment_Amount"), e.RecordIndex, salTot)

                Dim P0 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Amount"))
                Dim P1 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Beg"))
                Dim P3 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Advance"))
                'Dim P4 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Fine"))
                Dim P2 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Bonus"))

                Dim P5 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Paid"))

                Dim pTOT As Decimal = P0 + (P1 + P2) - (P3 + Fined)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Total", pTOT)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Balance", pTOT - P5)

                Dim dts = (From a In db.Emp_Att_Payment Where a.Emp_Att_Payment_ID = ID Select a).FirstOrDefault
                If dts IsNot Nothing Then
                    dts.Emp_Att_Payment_Fine = Fined
                    dts.Emp_Att_Payment_Total = pTOT
                    dts.Emp_Att_Payment_Balance = pTOT - P5
                    db.SaveChanges()
                End If
                'LoadEmp(CDate(Issue_Date.EditValue))
            End If
            If e.Column.FieldName = "Emp_Att_Payment_Bonus" Then
                Dim Bonused As Decimal = CDec(If(e.Value.ToString = "", 0, e.Value))
                'VGridControl1.SetCellValue(row4.PropertiesCollection.Item("Emp_Att_Payment_Amount"), e.RecordIndex, salTot)

                Dim P0 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Amount"))
                Dim P1 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Beg"))
                Dim P3 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Advance"))
                Dim P4 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Fine"))
                'Dim P2 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Bonus"))

                Dim P5 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Paid"))

                Dim pTOT As Decimal = P0 + (P1 + Bonused) - (P3 + P4)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Total", pTOT)
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Balance", pTOT - P5)

                Dim dts = (From a In db.Emp_Att_Payment Where a.Emp_Att_Payment_ID = ID Select a).FirstOrDefault
                If dts IsNot Nothing Then
                    dts.Emp_Att_Payment_Bonus = Bonused
                    dts.Emp_Att_Payment_Total = pTOT
                    dts.Emp_Att_Payment_Balance = pTOT - P5
                    db.SaveChanges()
                End If
                'LoadEmp(CDate(Issue_Date.EditValue))
            End If
            If e.Column.FieldName = "Emp_Att_Payment_Paid" Then
                'Dim cASHx As Decimal = CDec(VGridControl1.GetCellValue(row20.PropertiesCollection.Item("ccA2"), e.RecordIndex))

                Dim Paided As Decimal = CDec(If(e.Value.ToString = "", 0, e.Value))

                'If cASHx >= Paided Then
                Dim P2 As Decimal = CDec(AdvBandedGridView1.GetFocusedRowCellValue("Emp_Att_Payment_Total"))
                AdvBandedGridView1.SetFocusedRowCellValue("Emp_Att_Payment_Balance", P2 - Paided)
                Dim dts = (From a In db.Emp_Att_Payment Where a.Emp_Att_Payment_ID = ID Select a).FirstOrDefault
                If dts IsNot Nothing Then
                    dts.Emp_Att_Payment_Paid = Paided
                    dts.Emp_Att_Payment_Balance = P2 - Paided
                    db.SaveChanges()
                End If
                LoadEmp(CDate(Issue_Date.EditValue))
                'Else
                '    MsgBox("Please add CASH in Cash Register")
                'End If
            End If
        End Using

    End Sub

    Private Sub AdvBandedGridView1_MouseUp(sender As Object, e As MouseEventArgs) Handles AdvBandedGridView1.MouseUp
        ShowSelection()
    End Sub
    Private Sub ShowSelection()
        Dim intL As Integer = 0
        Dim RowCount As Integer = TempGridCheckMarksSelection.SelectedCount - 1
        ReDim intList(RowCount)
        ReDim intList2(RowCount)
        ReDim intListSelected(RowCount)
        For ff As Integer = 0 To AdvBandedGridView1.RowCount - 1
            If TempGridCheckMarksSelection.IsRowSelected(ff) Then
                Dim obj1 As Object = TryCast(AdvBandedGridView1.GetRowCellValue(ff, "Emp_Att_Payment_ID"), Object)
                Dim obj2 As Object = TryCast(AdvBandedGridView1.GetRowCellValue(ff, "ID"), Object)
                If obj1 Is Nothing Then
                    Return
                End If
                intList(intL) = obj1
                intList2(intL) = obj2
                intListSelected(intL) = ff
                intL += 1
            End If
        Next
    End Sub

    Private Sub BarButtonItem8_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem8.ItemClick
        Dim report As XtraReport = New XtraReport1 '.FromFile(".\Reports\" & OpenReport & ".repx", True)
        report.RequestParameters = False
        Dim pt As New ReportPrintTool(report)
        pt.AutoShowParametersPanel = False
        report.Parameters.Item(0).Value = intList
        pt.ShowRibbonPreview()
    End Sub

    Private Sub BarButtonItem9_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem9.ItemClick
        If intList2.Count > 0 Then
            For k As Integer = 0 To intList2.Count - 1
                Dim kk As Integer = intList2(k)
                Dim webAddress As String = Load_Payment_Month_Single_For_WhatsAppChk(kk, Issue_Date.EditValue)
                Dim web As New WebBrowser
                web.Navigate(webAddress)
                Threading.Thread.Sleep(1000)
                SendKeys.Send("{ENTER}")
                'Process.Start(webAddress)
                'Timer1.Start()
            Next
        End If
    End Sub

    Private Sub BarButtonItem10_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem10.ItemClick
        If intList2.Count > 0 Then
            For k As Integer = 0 To intList2.Count - 1
                Dim kk As Integer = intList2(k)
                Dim webAddress As String = Load_Payment_Month_Single_For_WhatsApp(kk, Issue_Date.EditValue)
                Dim web As New WebBrowser
                web.Navigate(webAddress)
                Threading.Thread.Sleep(1000)
                SendKeys.Send("{ENTER}")
                'Process.Start(webAddress)
                'Timer1.Start()
            Next
        End If
    End Sub
    Public Function Load_Payment_Month_Single_For_WhatsAppChk(EmpID As Integer, Datx As Date) As String


        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            'db.Emp_Att_Payment.Load
            'BindingSource1.DataSource = db.Emp_Att_Payment.Local.ToBindingList()
            Dim md As Integer = CDate(CsmdDateTime.LastDayOfMonth(CDate(Issue_Date.EditValue))).Day

            Dim dt = (From a In db.Emp_Att_Payment Where a.Emp_ID = EmpID And a.Emp_Att_Payment_Issue_Date.Value.Month = Datx.Month And a.Emp_Att_Payment_Issue_Date.Value.Year = Datx.Year
                      Select a).FirstOrDefault
            Dim strDetail As String = "whatsapp://send?"
            If dt IsNot Nothing Then
                'Dim row As GridViewRow = Me.GridView1.Rows(selectedIndex)
                'Dim id As String = row.Cells(0).Text
                'Dim name As String = row.Cells(1).Text
                'Dim country As String = row.Cells(2).Text
                'Dim script As String = "window.onload = function() { ShareOnWhatsApp('" & id & "','" & name & "','" & country & "'); };"
                'ClientScript.RegisterStartupScript(Me.[GetType](), "script", script, True)
                strDetail = strDetail & "phone="
                strDetail = strDetail & "92" + Microsoft.VisualBasic.Right(dt.Employee.Emp_Phone, 10)
                strDetail = strDetail + "&text=" & dt.Employee.Emp_Name & " >> " & "WhatsApp PayRoll Invoice by Csmd Softwares 0318-7785452 / 0310-7397851"
                strDetail = strDetail + "*-----------------------*%0a%0a"


            End If

            Return strDetail
        End Using
    End Function
    Public Function Load_Payment_Month_Single_For_WhatsApp(EmpID As Integer, Datx As Date) As String


        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities




            'db.Emp_Att_Payment.Load
            'BindingSource1.DataSource = db.Emp_Att_Payment.Local.ToBindingList()
            Dim md As Integer = CDate(CsmdDateTime.LastDayOfMonth(CDate(Issue_Date.EditValue))).Day

            Dim dt = (From a In db.Emp_Att_Payment.AsEnumerable Where a.Emp_ID = EmpID And a.Emp_Att_Payment_Issue_Date.Value.Month = Datx.Month And a.Emp_Att_Payment_Issue_Date.Value.Year = Datx.Year
                      Select New With {a.Emp_Att_Payment_ID, a, a.Employee.Emp_Name, a.Employee.Emp_Phone, a.Emp_Att_Payment_Fix,
                          a.Emp_Att_Payment_Issue_Date, a.Emp_Att_Payment_From_Date, a.Emp_Att_Payment_To_Date,
                          a.Emp_Att_Payment_DutyOn, a.Emp_Att_Payment_DutyOff,
                          a.Emp_Att_Payment_Total_Hours, a.Emp_Att_Payment_Total_MinRate, a.Emp_Att_Payment_Total_Days, a.Emp_Att_Payment_Total_DayRate,
                          a.Emp_Att_Payment_Add_Days, a.Emp_Att_Payment_InOutDays, a.Emp_Att_Payment_Absent_D, a.Emp_Att_Payment_Absent_Amount,
                          a.Emp_Att_Payment_Late, a.Emp_Att_Payment_Late_H, a.Emp_Att_Payment_Late_D, a.Emp_Att_Payment_Late_Amount,
                          a.Emp_Att_Payment_Early_H, a.Emp_Att_Payment_Early_D, a.Emp_Att_Payment_Early_Amount,
                          a.Emp_Att_Payment_OverTime_H, a.Emp_Att_Payment_OverTime_D, a.Emp_Att_Payment_OverTime_Amount,
                          a.Emp_Att_Payment_Prayer_Late_H, a.Emp_Att_Payment_Prayer_Late_D, a.Emp_Att_Payment_Prayer_Late_Amount,
                          a.Emp_Att_Payment_Short_H, a.Emp_Att_Payment_Short_D, a.Emp_Att_Payment_Short_Amount,
                          a.Emp_Att_Payment_Lunch_Late_H, a.Emp_Att_Payment_Lunch_Late_D, a.Emp_Att_Payment_Lunch_Late_Amount,
                          a.Emp_Att_Payment_Lunch_OverTime_H, a.Emp_Att_Payment_Lunch_OverTime_D, a.Emp_Att_Payment_Lunch_OverTime_Amount,
                          a.Emp_Att_Payment_Private_Late_H, a.Emp_Att_Payment_Private_Late_D, a.Emp_Att_Payment_Private_Late_Amount,
                          a.Emp_Att_Payment_Amount, a.Emp_Att_Payment_Beg, a.Emp_Att_Payment_Advance,
                          a.Emp_Att_Payment_Fine, a.Emp_Att_Payment_Bonus, a.Emp_Att_Payment_Total,
                          a.Emp_Att_Payment_Paid, a.Emp_Att_Payment_Balance,
                                       .Ca1 = "Description", .Ca2 = "Days", .Ca3 = "Rate", .Ca4 = "Amount",
                                       .Cb1 = "Salary Days", .Cb2 = a.Emp_Att_Payment_Total_Salaray_Days, .Cb3 = a.Emp_Att_Payment_Total_DayRate, .Cb4 = a.Emp_Att_Payment_Fix,
                                       .Cc1 = "Absentees", .Cc2 = a.Emp_Att_Payment_Absent_D, .Cc3 = a.Emp_Att_Payment_Total_DayRate, .Cc4 = a.Emp_Att_Payment_Absent_Amount,
                                       .Cd1 = "OffDays", .Cd2 = a.Emp_Att_Payment_Total_OffDays, .Cd3 = a.Emp_Att_Payment_Total_DayRate, .Cd4 = a.Emp_Att_Payment_Total_OffDays_Amount,
                                       .Cf1 = "Inout Days", .Cf2 = a.Emp_Att_Payment_InOutDays, .Cf3 = a.Emp_Att_Payment_Total_DayRate, .Cf4 = a.Emp_Att_Payment_InOutDays_Amount,
                                       .Cg1 = "Extra Days", .Cg2 = a.Emp_Att_Payment_ExtraDays, .Cg3 = a.Emp_Att_Payment_Total_DayRate, .Cg4 = a.Emp_Att_Payment_ExtraDays_Amount,
                                       .Ch1 = "Salary Total:", .Ch2 = a.Emp_Att_Payment_Salaray_Total,
                          .m0 = "Description", .m00 = "OffDay", .m1 = "Days", .m2 = "Hours", .m3 = "Rate", .m4 = "Amount",
                          .m5 = "Working Days", .m55 = a.Emp_Att_Payment_Total_MonthDays, .m6 = "Absentees", .m66 = a.Emp_Att_Payment_Total_OffDays,
                                       .Az1 = "Description", .Az2 = "Sts", .Az3 = "Days", .Az4 = "Hours", .Az5 = "Rate", .Az6 = "Amount",
                          .m7 = "Late Arrival", .m8 = "Early Dep", .m9 = "Duty Overtime", .m10 = "Prayer Late",
                          .m11 = "Short Leave", .m12 = "Lunch Late", .m13 = "Lunch Overtime", .m14 = "Private Late",
                          .s1 = "Summary of Month:", .s2 = "Old Due:", .s3 = "Advances:", .s4 = "Fine:", .s5 = "Bonus:", .s6 = "Total Amount:", .s7 = "Paid:", .s8 = "Balance:",
                          .n1 = "DutyOn", .n2 = "DutyOff", .n4 = "MinRate", .n5 = "Hours", .d1 = "Issue Date", .d2 = "Duty From", .d3 = "Duty To",
                          .e1 = "Name of Employees",
                              a.Emp_Att_Payment_Prayer_Late_D_T,
                              a.Emp_Att_Payment_Short_D_T,
                              a.Emp_Att_Payment_Lunch_Late_D_T,
                              a.Emp_Att_Payment_Private_Late_D_T}).FirstOrDefault
            Dim strDetail As String = "whatsapp://send?"
            If dt IsNot Nothing Then
                'Dim row As GridViewRow = Me.GridView1.Rows(selectedIndex)
                'Dim id As String = row.Cells(0).Text
                'Dim name As String = row.Cells(1).Text
                'Dim country As String = row.Cells(2).Text
                'Dim script As String = "window.onload = function() { ShareOnWhatsApp('" & id & "','" & name & "','" & country & "'); };"
                'ClientScript.RegisterStartupScript(Me.[GetType](), "script", script, True)
                strDetail = strDetail & "phone="
                strDetail = strDetail & "92" + Microsoft.VisualBasic.Right(dt.Emp_Phone, 10)
                strDetail = strDetail & "&text="
                strDetail = strDetail & "*" & dt.Emp_Name & "*%0a"
                'strDetail = strDetail & "*Faazal Furniture*%0a"
                strDetail = strDetail & "*FAAZAL PHARMACY AND MART*%0a"

                'strDetail = strDetail & "%09%09Satisfaction Guaranteed%0a"
                'strDetail = strDetail & "*Dhulyan Road Dinga*%0a"
                strDetail = strDetail & "*DHULYAN CHOWK DINGA*%0a"
                'strDetail = strDetail & "*Phone:*	%090537-401910 %0a"
                strDetail = strDetail & "*Cell :*		%09%090332-7117786%0a%0a"
                'strDetail = strDetail & "*...............................................*%0a%0a"

                strDetail = strDetail & "*Name :*		%09%09" & dt.Emp_Name & " s/o " & dt.a.Employee.Emp_Father & "%0a%0a"

                'strDetail = strDetail & "%09%09*```Dates```*%0a"
                strDetail = strDetail & "*-----*%0a"
                'strDetail = strDetail & "*Invoice*	%09" & dt. & "%0a"
                strDetail = strDetail & "*Issue Date:*	%09" & dt.Emp_Att_Payment_Issue_Date & "%0a"
                strDetail = strDetail & "*From :*	%09" & dt.Emp_Att_Payment_From_Date & "%09*To*%09" & dt.Emp_Att_Payment_To_Date & "%0a%0a"
                'strDetail = strDetail & ""
                'strDetail = strDetail & "*-----------------------*%0a%0a"

                strDetail = strDetail & "%09*Duty Times*%0a"
                'strDetail = strDetail & "*-----*%0a"
                strDetail = strDetail & "```DutyOn    : %09" & dt.Emp_Att_Payment_DutyOn & "```%0a"
                strDetail = strDetail & "```DutyOff   : %09" & dt.Emp_Att_Payment_DutyOff & "```%0a"
                strDetail = strDetail & "```DutyHours : %09" & dt.Emp_Att_Payment_Total_Hours & "```%0a%0a"
                'strDetail = strDetail & "*DutyOff:*	%09" & dt.Emp_Att_Payment_DutyOn & "%0a"
                'strDetail = strDetail & "*Duty Hours:*		%09%09" & dt.Emp_Att_Payment_Total_Hours & "%0a%0a"

                'strDetail = strDetail & "*=======================*%0a"
                strDetail = strDetail & "%09*Salary Details*%0a"
                'strDetail = strDetail & "*-----*%0a"
                'strDetail = strDetail & "```DayRate     : %09" & CDbl(dt.Emp_Att_Payment_Total_DayRate).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Salary Days : %09" & CDbl(dt.a.Emp_Att_Payment_Total_Salaray_Days).ToString("00") & "|%09" & CDbl(dt.Emp_Att_Payment_Fix).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Absentees   : %09" & CDbl(dt.Emp_Att_Payment_Absent_D).ToString("00") & "|%09" & CDbl(dt.a.Emp_Att_Payment_Absent_Amount).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Off Days    : %09" & CDbl(dt.a.Emp_Att_Payment_Total_OffDays).ToString("00") & "|%09" & CDbl(dt.a.Emp_Att_Payment_Total_OffDays_Amount).ToString("00000") & "```%0a"
                strDetail = strDetail & "```InOut Days  : %09" & CDbl(dt.Emp_Att_Payment_InOutDays).ToString("00") & "|%09" & CDbl(dt.a.Emp_Att_Payment_InOutDays_Amount).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Extra Days  : %09" & CDbl(dt.a.Emp_Att_Payment_ExtraDays).ToString("00") & "|%09" & CDbl(dt.a.Emp_Att_Payment_ExtraDays_Amount).ToString("00000") & "```%0a"
                'strDetail = strDetail & "```====%09====%09====%09====%09====```%0a"
                strDetail = strDetail & "*-----*%0a"
                strDetail = strDetail & "```Salary Total:	%09%09" & CDbl(dt.a.Emp_Att_Payment_Salaray_Total).ToString("00000") & "```%0a%0a"
                'strDetail = strDetail & "```====%09====%09====%09====%09====```%0a%0a"
                'strDetail = strDetail & "*-----------------------*%0a%0a"

                ''''strDetail = strDetail & "*=======================*%0a"
                strDetail = strDetail & "%09*Attendence Details*%0a"
                'strDetail = strDetail & "*-----*%0a"
                Dim MInR As String = CDbl(dt.Emp_Att_Payment_Total_MinRate).ToString("00.00")
                strDetail = strDetail & "*MinRate       :* %09" & MInR & "%0a"
                strDetail = strDetail & "```Description : %09TD|%09LD|%09Hours|%09Amount```%0a"
                strDetail = strDetail & "```Late Arrival: %0900|%09" & CDbl(dt.Emp_Att_Payment_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Late_H).Split(":")(1)).ToString("00") & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Late_Amount).ToString("00000"), "-", "") & "```%0a"
                strDetail = strDetail & "```Early Dept  : %0900|%09" & CDbl(dt.Emp_Att_Payment_Early_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Early_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Early_H).Split(":")(1)).ToString("00") & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Early_Amount).ToString("00000"), "-", "") & "```%0a"
                strDetail = strDetail & "```Over Time   : %0900|%09" & CDbl(dt.Emp_Att_Payment_OverTime_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_OverTime_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_OverTime_H).Split(":")(1)).ToString("00") & "|%2B%09" & CDbl(dt.Emp_Att_Payment_OverTime_Amount).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Prayer Late : %09" & CDbl(dt.Emp_Att_Payment_Prayer_Late_D_T).ToString("00") & "|%09" & CDbl(dt.Emp_Att_Payment_Prayer_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Prayer_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Prayer_Late_H).Split(":")(1)).ToString("00") & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Prayer_Late_Amount).ToString("00000"), "-", "") & "```%0a"
                strDetail = strDetail & "```Short Leave : %09" & CDbl(dt.Emp_Att_Payment_Short_D_T).ToString("00") & "|%09" & CDbl(dt.Emp_Att_Payment_Short_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Short_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Short_H).Split(":")(1)).ToString("00") & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Short_Amount).ToString("00000"), "-", "") & "```%0a"
                strDetail = strDetail & "```Lunch Late  : %09" & CDbl(dt.Emp_Att_Payment_Lunch_Late_D_T).ToString("00") & "|%09" & CDbl(dt.Emp_Att_Payment_Lunch_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_Late_H).Split(":")(1)).ToString("00") & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Lunch_Late_Amount).ToString("00000"), "-", "") & "```%0a"
                strDetail = strDetail & "```Lunch OvrTim: %0900|%09" & CDbl(dt.Emp_Att_Payment_Lunch_OverTime_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_OverTime_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_OverTime_H).Split(":")(1)).ToString("00") & "|%2B%09" & CDbl(dt.Emp_Att_Payment_Lunch_OverTime_Amount).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Private Late: %09" & CDbl(dt.Emp_Att_Payment_Private_Late_D_T).ToString("00") & "|%09" & CDbl(dt.Emp_Att_Payment_Private_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Private_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Private_Late_H).Split(":")(1)).ToString("00") & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Private_Late_Amount).ToString("00000"), "-", "") & "```%0a"
                'strDetail = strDetail & "```..: %09Dy|%09Hours|%09MinRt|%09Amount```%0a"
                'strDetail = strDetail & "```LA:	%09" & CDbl(dt.Emp_Att_Payment_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Late_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Late_Amount).ToString("00000.00"), "-", "") & "```%0a"
                'strDetail = strDetail & "```ED:	%09" & CDbl(dt.Emp_Att_Payment_Early_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Early_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Early_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Early_Amount).ToString("00000.00"), "-", "") & "```%0a"
                'strDetail = strDetail & "```OT:	%09" & CDbl(dt.Emp_Att_Payment_OverTime_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_OverTime_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_OverTime_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|%2B%09" & CDbl(dt.Emp_Att_Payment_OverTime_Amount).ToString("00000.00") & "```%0a"
                'strDetail = strDetail & "```PL:	%09" & CDbl(dt.Emp_Att_Payment_Prayer_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Prayer_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Prayer_Late_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Prayer_Late_Amount).ToString("00000.00"), "-", "") & "```%0a"
                'strDetail = strDetail & "```SL:	%09" & CDbl(dt.Emp_Att_Payment_Short_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Short_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Short_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Short_Amount).ToString("00000.00"), "-", "") & "```%0a"
                'strDetail = strDetail & "```LL:	%09" & CDbl(dt.Emp_Att_Payment_Lunch_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_Late_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Lunch_Late_Amount).ToString("00000.00"), "-", "") & "```%0a"
                'strDetail = strDetail & "```LO:	%09" & CDbl(dt.Emp_Att_Payment_Lunch_OverTime_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_OverTime_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Lunch_OverTime_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|%2B%09" & CDbl(dt.Emp_Att_Payment_Lunch_OverTime_Amount).ToString("00000.00") & "```%0a"
                'strDetail = strDetail & "```PR:	%09" & CDbl(dt.Emp_Att_Payment_Private_Late_D).ToString("00") & "|%09" & CDbl(CStr(dt.Emp_Att_Payment_Private_Late_H).Split(":")(0)).ToString("00") & ":" & CDbl(CStr(dt.Emp_Att_Payment_Private_Late_H).Split(":")(1)).ToString("00") & "|%09" & MInR & "|-%09" & Replace(CDbl(dt.Emp_Att_Payment_Private_Late_Amount).ToString("00000.00"), "-", "") & "```%0a"
                'strDetail = strDetail & "```==:%09==|%09=====|%09=====|%09========```%0a"
                strDetail = strDetail & "*-----*%0a"
                strDetail = strDetail & "```Summary of Month: %09" & CDbl(dt.Emp_Att_Payment_Amount).ToString("00000") & "```%0a%0a"
                'strDetail = strDetail & "*-----------------------*%0a"
                'strDetail = strDetail & "```====%09====%09====%09====%09====%09====```%0a%0a"
                ''''strDetail = strDetail & "*-----------------------*%0a%0a"
                strDetail = strDetail & "%09*Payment Details*%0a"
                'strDetail = strDetail & "*-----*%0a"
                strDetail = strDetail & "```Old Due : %09%09" & CDbl(dt.Emp_Att_Payment_Beg).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Advances: %09%09" & CDbl(dt.Emp_Att_Payment_Advance).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Fine    : %09%09" & CDbl(dt.Emp_Att_Payment_Fine).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Bonus   : %09%09" & CDbl(dt.Emp_Att_Payment_Bonus).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Total   : %09%09" & CDbl(dt.Emp_Att_Payment_Total).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Paid    : %09%09" & CDbl(dt.Emp_Att_Payment_Paid).ToString("00000") & "```%0a"
                strDetail = strDetail & "```Balance : %09%09" & CDbl(dt.Emp_Att_Payment_Balance).ToString("00000") & "```%0a"

                'strDetail = strDetail & "*Old Due:*	%09" & dt.Emp_Att_Payment_Beg & "%0a"
                'strDetail = strDetail & "*Advances:*	%09" & dt.Emp_Att_Payment_Advance & "%0a"
                'strDetail = strDetail & "*Fine:*	%09" & dt.Emp_Att_Payment_Fine & "%0a"
                'strDetail = strDetail & "*Bonus:*	%09" & dt.Emp_Att_Payment_Bonus & "%0a"
                'strDetail = strDetail & "*Total:*	%09" & dt.Emp_Att_Payment_Total & "%0a"
                'strDetail = strDetail & "*Paid:*	%09" & dt.Emp_Att_Payment_Paid & "%0a"
                'strDetail = strDetail & "*Balance:*	%09" & dt.Emp_Att_Payment_Balance & "%0a"

                ''''Dim MInR As String = CsmdWaFont(CDbl(dt.Emp_Att_Payment_Total_MinRate).ToString("00.00"))
                '''''strDetail = strDetail & "```LA:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_Late_D).ToString("00")) & "|%09" & CsmdWaFont(dt.Emp_Att_Payment_Late_H) & "|%09" & MInR & "%09|" & dt.Emp_Att_Payment_Late_Amount & "```%0a"
                ''''strDetail = strDetail & "```ED:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_Early_D).ToString("00")) & "|%09" & CsmdWaFont(dt.Emp_Att_Payment_Early_H) & "|%09" & MInR & "|%09" & dt.Emp_Att_Payment_Early_Amount & "```%0a"
                ''''strDetail = strDetail & "```OT:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_OverTime_D).ToString("00")) & "|%09" & CsmdWaFont(dt.Emp_Att_Payment_OverTime_H) & "|%09" & MInR & "|%09" & dt.Emp_Att_Payment_OverTime_Amount & "```%0a"
                ''''strDetail = strDetail & "```PL:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_Prayer_Late_D).ToString("00")) & "%09" & CsmdWaFont(dt.Emp_Att_Payment_Prayer_Late_H) & "%09" & MInR & "%09" & dt.Emp_Att_Payment_Prayer_Late_Amount & "```%0a"
                '''''strDetail = strDetail & "```SL:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_Short_D).ToString("00")) & "%09" & CsmdWaFont(dt.Emp_Att_Payment_Short_H) & "%09" & MInR & "%09" & dt.Emp_Att_Payment_Short_Amount & "```%0a"
                ''''strDetail = strDetail & "```LL:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_Lunch_Late_D).ToString("00")) & "%09" & CsmdWaFont(dt.Emp_Att_Payment_Lunch_Late_H) & "%09" & MInR & "%09" & dt.Emp_Att_Payment_Lunch_Late_Amount & "```%0a"
                ''''strDetail = strDetail & "```LO:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_Lunch_OverTime_D).ToString("00")) & "%09" & CsmdWaFont(dt.Emp_Att_Payment_Lunch_OverTime_H) & "%09" & MInR & "%09" & dt.Emp_Att_Payment_Lunch_OverTime_Amount & "```%0a"
                '''''strDetail = strDetail & "```PR:	%09" & CsmdWaFont(CDbl(dt.Emp_Att_Payment_Private_Late_D).ToString("00")) & "%09" & CsmdWaFont(dt.Emp_Att_Payment_Private_Late_H) & "%09" & MInR & "%09" & dt.Emp_Att_Payment_Private_Late_Amount & "```%0a"
                ''''strDetail = strDetail & "```====%09====%09====%09====%09====%09====```%0a"
                ''''strDetail = strDetail & "```Summary of Month:	%09%09%09" & dt.Emp_Att_Payment_Total & "```%0a"
                ''''strDetail = strDetail & "```====%09====%09====%09====%09====%09====```%0a%0a"
                '''''''strDetail = strDetail & "*-----------------------*%0a%0a"




                ''Dim eBill As Double = dts.RB_Pay_Detail_Bill_Amt
                ''Dim gBill As Double = dts.RB_Pay_Detail_Gas_TBill
                ''Dim rRent As Double = dts.RB_Pay_Detail_Rent

                ''Dim payab As Double = dts.RB_Pay_Detail_Payable

                ''Dim curPay As Double = (eBill + gBill) + rRent

                ''Dim oldDue As Double = payab - curPay



                ''Dim GranTotal As Double = payab



                ''strDetail = strDetail & "*=======================*%0a"
                ''strDetail = strDetail & "*Arrears Dues*	%09" & oldDue & "%0a"
                ''strDetail = strDetail & "*Current Pay:*	%09" & curPay & "%0a"
                ''strDetail = strDetail & "*Payable Within Due Date:* " & GranTotal & "%0a"
                ''strDetail = strDetail & "*=======================*%0a%0a"

                ''Dim LateF As Double = (GranTotal / 100) * 15

                ''Dim afterDue As Double = payab + LateF

                ''strDetail = strDetail & "*L.F Fine 15%*	%09" & LateF & "%0a"
                ''strDetail = strDetail & "*Payable After Due Date:* " & afterDue & "%0a"
                'strDetail = strDetail & "*.....*%0a%0a"

                strDetail = strDetail & "*Thank You*"
                'strDetail = strDetail & "*Note:* This invoice Testing by CSMD Softwares Company"

            End If
            ' MsgBox(strDetail.Length)
            Return strDetail
        End Using
    End Function

    Private Sub GridControl1_Paint(sender As Object, e As PaintEventArgs) Handles GridControl1.Paint
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim advBandedGridView As AdvBandedGridView = TryCast(grid.MainView, AdvBandedGridView)
        Try
            If advBandedGridView Is Nothing Then
                Return
            End If
            Dim viewInfo As AdvBandedGridViewInfo = TryCast(advBandedGridView.GetViewInfo(), AdvBandedGridViewInfo)
            For Each band As GridBand In advBandedGridView.Bands
                If band Is advBandedGridView.Bands.LastVisibleBand Then
                    Continue For
                End If
                Dim bandInfo As DevExpress.XtraGrid.Drawing.GridBandInfoArgs = viewInfo.BandsInfo(band)
                If bandInfo Is Nothing Then
                    Exit Sub
                End If
                Dim redPen As New Pen(Color.Red, 5)
                Dim greenPen As New Pen(Color.Green, 5)
                greenPen.Alignment = PenAlignment.Center
                Dim startPoint As New Point(bandInfo.Bounds.Right - 1, bandInfo.Bounds.Y)
                'Dim endPoint As New Point(bandInfo.Bounds.Right - 1, bandInfo.Bounds.Y + viewInfo.ColumnRowHeight + viewInfo.BandRowHeight)
                Dim endPoint As New Point(bandInfo.Bounds.Right - 1, bandInfo.Bounds.Y + viewInfo.ViewRects.BandPanel.Height + viewInfo.ViewRects.ColumnPanel.Height) ' + viewInfo.ColumnRowHeight + viewInfo.BandRowHeight
                'e.Graphics.DrawLine(Pens.DarkGray, startPoint, endPoint)
                e.Graphics.DrawLine(redPen, startPoint, endPoint)
                For Each rowInfo As Views.Grid.ViewInfo.GridRowInfo In viewInfo.RowsInfo
                    If rowInfo.IsGroupRow Then 'skip group rows  
                        Continue For
                    End If
                    Dim startPoint1 As New Point(bandInfo.Bounds.Right - 1, rowInfo.Bounds.Top)
                    Dim endPoint1 As New Point(bandInfo.Bounds.Right - 1, rowInfo.Bounds.Bottom)
                    'e.Graphics.DrawLine(Pens.DarkGray, startPoint1, endPoint1)
                    e.Graphics.DrawLine(greenPen, startPoint1, endPoint1)
                Next rowInfo
            Next band
        Catch ex As Exception
            MsgBox("Error!")
        End Try
    End Sub

    Private Sub BarButtonItem11_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem11.ItemClick
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            If intList2.Count > 0 Then
                For kk As Integer = 0 To intList2.Count - 1

                    Dim k As Integer = intListSelected(kk)


                    Dim ext As Double = If(txtExtraDays.EditValue IsNot Nothing, txtExtraDays.EditValue, 0)
                    Dim idx As Integer = intList2(k)
                    Dim Datx As DateTime = Issue_Date.EditValue
                    Dim dt = (From a In db.Emp_Att_Payment Where a.Emp_ID = idx And a.Emp_Att_Payment_Issue_Date.Value.Month = Datx.Month And a.Emp_Att_Payment_Issue_Date.Value.Year = Datx.Year
                              Select a).FirstOrDefault
                    If dt IsNot Nothing Then
                        dt.Emp_Att_Payment_ExtraDays = ext
                        Dim ID As Integer = CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_ID"))
                        Dim Salar As Decimal = CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Fix"))


                        Dim InOutAmt As Decimal = CDec(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_InOutDays_Amount"))
                        Dim ExtraDay As Integer = If(txtExtraDays.EditValue IsNot Nothing, txtExtraDays.EditValue, 0)

                        Dim DayRate As Decimal = CDec(AdvBandedGridView1.GetRowCellValue(k, "dr5"))

                        Dim sds As Decimal = ExtraDay * DayRate
                        Dim TotAmount As Decimal = sds + InOutAmt

                        AdvBandedGridView1.SetRowCellValue(k, "Emp_Att_Payment_ExtraDays_Amount", sds)
                        AdvBandedGridView1.SetRowCellValue(k, "Emp_Att_Payment_Salaray_Total", TotAmount)

                        Dim R7 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Late_Amount")))
                        Dim R8 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Early_Amount")))
                        Dim R9 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_OverTime_Amount")))
                        Dim R10 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Prayer_Late_Amount")))
                        Dim R11 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Short_Amount")))
                        Dim R12 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Lunch_Late_Amount")))
                        Dim R13 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Lunch_OverTime_Amount")))
                        Dim R14 As Decimal = Math.Abs(CInt(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Private_Late_Amount")))

                        Dim over As Decimal = R9 + R13
                        Dim mins As Decimal = (R7 + R8) + (R10 + R11) + (R12 + R14)

                        Dim salTot As Decimal = (TotAmount + over) - mins



                        AdvBandedGridView1.SetRowCellValue(k, "Emp_Att_Payment_Amount", salTot)
                        Dim P1 As Decimal = CDec(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Beg"))
                        Dim P3 As Decimal = CDec(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Advance"))
                        Dim P4 As Decimal = CDec(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Fine"))
                        Dim P2 As Decimal = CDec(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Bonus"))

                        Dim P5 As Decimal = CDec(AdvBandedGridView1.GetRowCellValue(k, "Emp_Att_Payment_Paid"))

                        Dim pTOT As Decimal = salTot + (P1 + P2) - (P3 + P4)
                        AdvBandedGridView1.SetRowCellValue(k, "Emp_Att_Payment_Total", pTOT)
                        AdvBandedGridView1.SetRowCellValue(k, "Emp_Att_Payment_Balance", pTOT - P5)

                        Dim dts = (From a In db.Emp_Att_Payment Where a.Emp_Att_Payment_ID = ID Select a).FirstOrDefault
                        If dts IsNot Nothing Then
                            'dts.Emp_Att_Payment_Add_Days = ExtraDay
                            'dts.Emp_Att_Payment_Absent_D = totDa
                            'dts.Emp_Att_Payment_Absent_Amount = -TotAmount
                            dts.Emp_Att_Payment_ExtraDays = ExtraDay
                            dts.Emp_Att_Payment_ExtraDays_Amount = sds
                            dts.Emp_Att_Payment_Salaray_Total = TotAmount
                            dts.Emp_Att_Payment_Amount = salTot
                            dts.Emp_Att_Payment_Total = pTOT
                            dts.Emp_Att_Payment_Balance = pTOT - P5
                            '  db.SaveChanges()

                        End If

                        db.SaveChanges()
                    End If

                Next
                MsgBox("Add ExtraDays Successfull")
                LoadEmp(CDate(Issue_Date.EditValue))
                AdvBandedGridView1.Columns("Emp_Name").UnGroup()
                AdvBandedGridView1.Columns("Emp_Att_Payment_Issue_Date").UnGroup()
            Else
                MsgBox("Please Select Employees")
            End If
        End Using
    End Sub
    Private Sub AdvBandedGridView1_CustomDrawRowIndicator(sender As Object, e As RowIndicatorCustomDrawEventArgs) Handles AdvBandedGridView1.CustomDrawRowIndicator
        If e.RowHandle >= 0 Then
            e.Info.DisplayText = (e.RowHandle + 1).ToString()
        End If
    End Sub
End Class