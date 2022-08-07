Public Class frmAttPayments


    Private Sub frmAttPayments_Load(sender As Object, e As EventArgs) Handles Me.Load
        FromDate.EditValue = Today
        LoadPay()
    End Sub

    Private Sub RepositoryItemDateEdit1_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemDateEdit1.ButtonClick
        Select Case e.Button.Index
            Case 1
                FromDate.EditValue = DateTime.Parse(FromDate.EditValue).AddMonths(-1)
            Case 2
                FromDate.EditValue = DateTime.Parse(FromDate.EditValue).AddMonths(1)
        End Select
    End Sub
    Private Sub LoadPay()
        Using db As New CsmdBioAttendenceEntities
            Dim Emp_Att_Payment_From_DateX As DateTime = CDate(FromDate.EditValue)
            Dim dt = (From a In db.Employees
                      Group Join b In db.Emp_Att_Payment.Where(Function(o) o.Emp_Att_Payment_From_Date.Value.Month = Emp_Att_Payment_From_DateX.Month And o.Emp_Att_Payment_From_Date.Value.Year = Emp_Att_Payment_From_DateX.Year)
                      On a.Emp_ID Equals b.Emp_ID
                      Into z = Group From b In z.DefaultIfEmpty Order By a.Emp_Name Ascending
                      Select New With {
                          .ID = a.Emp_ID,
                          .Name = a.Emp_Name,
                          .Father = a.Emp_Father,
                          .Issue_Date = b.Emp_Att_Payment_Issue_Date,
                          .From_Date = b.Emp_Att_Payment_From_Date,
                          .To_Date = b.Emp_Att_Payment_To_Date,
                          .SalrayFix = b.Emp_Att_Payment_Fix,
                          .Amount = b.Emp_Att_Payment_Amount,
                          .OldBalance = b.Emp_Att_Payment_Beg,
                          .Bonus = b.Emp_Att_Payment_Bonus,
                          .Advances = b.Emp_Att_Payment_Advance,
                          .Fine = b.Emp_Att_Payment_Fine,
                          .Total = b.Emp_Att_Payment_Total,
                          .Paid = b.Emp_Att_Payment_Paid,
                          .Balance = b.Emp_Att_Payment_Balance}).ToList
             
            If dt.Count > 0 Then
                GridControl1.DataSource = dt
            Else
                GridControl1.DataSource = Nothing
            End If
        End Using
    End Sub

    Private Sub SetPay()
        Using db As New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Emp_Att_Payment Select a).ToList
            If dt.Count > 0 Then
                For Each dts In dt
                    With dts
                        Dim sain As Double = .Emp_Att_Payment_Amount
                        Dim bon As Double = .Emp_Att_Payment_Bonus
                        Dim tott As Double = sain + bon

                        Dim adv As Double = .Emp_Att_Payment_Advance
                        Dim finn As Double = .Emp_Att_Payment_Fine
                        Dim kokk As Double = adv + finn

                        .Emp_Att_Payment_Total = tott - kokk

                        .Emp_Att_Payment_Balance = .Emp_Att_Payment_Total - .Emp_Att_Payment_Paid
                    End With
                    db.SaveChanges()
                Next
                MsgBox("Done")
            End If
        End Using
    End Sub


    Private Sub SetPayBal()
        Using db As New CsmdBioAttendenceEntities
            Dim Emp_Att_Payment_From_DateX As DateTime = FromDate.EditValue
            Dim Emp_Att_Payment_From_DateXn As DateTime = DateTime.Parse(FromDate.EditValue).AddMonths(-1)

            'Dim dt = (From a In db.Employees
            '          Group Join b In db.Emp_Att_Payment.Where(Function(o) o.Emp_Att_Payment_From_Date.Value.Month = Emp_Att_Payment_From_DateXn.Month And o.Emp_Att_Payment_From_Date.Value.Year = Emp_Att_Payment_From_DateXn.Year)
            '          On a.Emp_ID Equals b.Emp_ID
            '          Into z = Group
            '          From b In z.DefaultIfEmpty
            '          Order By a.Emp_Name Ascending
            '          Select a).ToList

            Dim dtt = (From a In db.Employees Select a).ToList
            If dtt.Count > 0 Then

                For Each dtts In dtt
                    Dim dtm = (From a In db.Emp_Att_Payment Where a.Emp_ID = dtts.Emp_ID And a.Emp_Att_Payment_From_Date.Value.Month = Emp_Att_Payment_From_DateXn.Month And a.Emp_Att_Payment_From_Date.Value.Year = Emp_Att_Payment_From_DateXn.Year Select a).FirstOrDefault
                    If dtm IsNot Nothing Then

                        With dtm
                            '.Emp_Att_Payment_Beg = dtm.Emp_Att_Payment_Balance
                            Dim ball As Double = .Emp_Att_Payment_Beg
                            Dim sain As Double = .Emp_Att_Payment_Amount
                            Dim bon As Double = .Emp_Att_Payment_Bonus
                            Dim tott As Double = ball + sain + bon

                            Dim adv As Double = .Emp_Att_Payment_Advance
                            Dim finn As Double = .Emp_Att_Payment_Fine
                            Dim kokk As Double = adv + finn

                            .Emp_Att_Payment_Total = tott - kokk

                            .Emp_Att_Payment_Balance = .Emp_Att_Payment_Total - .Emp_Att_Payment_Paid
                        End With
                        db.SaveChanges()


                        Dim dtmn = (From a In db.Emp_Att_Payment Where a.Emp_ID = dtts.Emp_ID And a.Emp_Att_Payment_From_Date.Value.Month = Emp_Att_Payment_From_DateX.Month And a.Emp_Att_Payment_From_Date.Value.Year = Emp_Att_Payment_From_DateX.Year Select a).FirstOrDefault
                        If dtmn IsNot Nothing Then

                            With dtmn
                                .Emp_Att_Payment_Beg = dtm.Emp_Att_Payment_Balance
                                Dim ball As Double = .Emp_Att_Payment_Beg

                                Dim sain As Double = .Emp_Att_Payment_Amount
                                Dim bon As Double = .Emp_Att_Payment_Bonus
                                Dim tott As Double = ball + sain + bon

                                Dim adv As Double = .Emp_Att_Payment_Advance
                                Dim finn As Double = .Emp_Att_Payment_Fine
                                Dim kokk As Double = adv + finn

                                .Emp_Att_Payment_Total = tott - kokk

                                .Emp_Att_Payment_Balance = .Emp_Att_Payment_Total - .Emp_Att_Payment_Paid
                            End With
                            db.SaveChanges()




                            MsgBox("Done")

                        End If




                    End If
                Next


            End If

            'Dim dt = (From a In db.Emp_Att_Payment Select a).ToList
            'If dt.Count > 0 Then
            '    For Each dts In dt
            '        With dts
            '            Dim sain As Double = .Emp_Att_Payment_Amount
            '            Dim bon As Double = .Emp_Att_Payment_Bonus
            '            Dim tott As Double = sain + bon

            '            Dim adv As Double = .Emp_Att_Payment_Advance
            '            Dim finn As Double = .Emp_Att_Payment_Fine
            '            Dim kokk As Double = adv + finn

            '            .Emp_Att_Payment_Total = tott - kokk

            '            .Emp_Att_Payment_Balance = .Emp_Att_Payment_Total - .Emp_Att_Payment_Paid
            '        End With
            '        db.SaveChanges()
            '    Next
            '    MsgBox("Done")
            'End If
        End Using
    End Sub

    Private Sub RepositoryItemDateEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemDateEdit1.EditValueChanged
        LoadPay()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        SetPay()
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        SetPayBal()
    End Sub
End Class