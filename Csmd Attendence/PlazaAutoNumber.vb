'Imports CsmdPlazaDatabase
Imports CsmdBioDatabase

Module PlazaAutoNumber
    'Public Function AutoCustomerNumber() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Where a.Auto_ID = 1 Select a.Auto_Cus_No).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewNumber As New Auto_Number

    '            'Dim kk As String = "Rent-Inv-00001" & "-" & Now.ToString("yy")
    '            'NewNumber.Auto_Invoice = Replace(Replace(kk, "Inv-", ""), Microsoft.VisualBasic.Right(Replace(kk, "Rent-Inv-", ""), 3), "")
    '            'db.Auto_Number.Add(NewNumber)
    '            'db.SaveChanges()
    '            'GetNumber = NewNumber.Auto_Invoice
    '        Else
    '            AutoNumber += 1
    '            Dim num As String = "C-" & AutoNumber.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function
    'Public Function AutoInvoiceNumber() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Where a.Auto_ID = 1 Select a.Auto_Invoice).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewNumber As New Auto_Number

    '            'Dim kk As String = "Rent-Inv-00001" & "-" & Now.ToString("yy")
    '            'NewNumber.Auto_Invoice = Replace(Replace(kk, "Inv-", ""), Microsoft.VisualBasic.Right(Replace(kk, "Rent-Inv-", ""), 3), "")
    '            'db.Auto_Number.Add(NewNumber)
    '            'db.SaveChanges()
    '            'GetNumber = NewNumber.Auto_Invoice
    '        Else
    '            AutoNumber += 1
    '            Dim num As String = "Inv-" & AutoNumber.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function
    'Public Function AutoReceiptNumber() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Where a.Auto_ID = 1 Select a.Auto_Receipt).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewNumber As New Auto_Number

    '            'Dim kk As String = "Rent-Cpr-00001" & "-" & Now.ToString("yy")
    '            'NewNumber.Auto_Receipt = Replace(Replace(kk, "Rent-Cpr-", ""), Microsoft.VisualBasic.Right(Replace(kk, "Rent-Cpr-", ""), 3), "")
    '            'db.Auto_Number.Add(NewNumber)
    '            'db.SaveChanges()
    '            'GetNumber = NewNumber.Auto_Receipt
    '        Else
    '            AutoNumber += 1
    '            Dim num As String = "R-" & AutoNumber.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function
    'Public Function AutoBillInvoiceNumber() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Where a.Auto_ID = 1 Select a.Auto_Bill_Invoice).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewNumber As New Auto_Number

    '            'Dim kk As String = "Bill-Inv-00001" & "-" & Now.ToString("yy")
    '            'NewNumber.Auto_Bill_Invoice = Replace(Replace(kk, "Bill-Inv-", ""), Microsoft.VisualBasic.Right(Replace(kk, "Bill-Inv-", ""), 3), "")
    '            'db.Auto_Number.Add(NewNumber)
    '            'db.SaveChanges()
    '            'GetNumber = NewNumber.Auto_Bill_Invoice
    '        Else
    '            AutoNumber += 1
    '            Dim num As String = "Bill-Inv-" & AutoNumber.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function
    'Public Function AutoBillReceiptNumber() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Where a.Auto_ID = 1 Select a.Auto_Bill_Receipt).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewNumber As New Auto_Number
    '            'Dim kk As String = "Bill-Cpr-00001" & "-" & Now.ToString("yy")
    '            'NewNumber.Auto_Bill_Receipt = Replace(Replace(kk, "Bill-Cpr-", ""), Microsoft.VisualBasic.Right(Replace(kk, "Bill-Cpr-", ""), 3), "")
    '            'db.Auto_Number.Add(NewNumber)
    '            'db.SaveChanges()
    '            'GetNumber = NewNumber.Auto_Bill_Receipt
    '        Else
    '            AutoNumber += 1
    '            Dim num As String = "Bill-Cpr-" & AutoNumber.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function

    Public Function AutoRegisterNumber() As String
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim GetNumber As String = ""

            Dim AutoNumber = (From a In db.Auto_Number Select a).FirstOrDefault
            If AutoNumber Is Nothing Then
                'Dim NewInvoice As New Auto_Number
                'NewInvoice.Number_Teacher = "R-0001" & Now.ToString("yy")
                'db.Auto_Number.Add(NewInvoice)
                'db.SaveChanges()
                'GetNumber = NewInvoice.Number_Teacher
            Else
                AutoNumber.Auto_Emp_Num += 1
                Dim num As String = "R-" & AutoNumber.Auto_Emp_Num.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
                GetNumber = num
            End If
            Return GetNumber
        End Using
    End Function

    'Public Function Auto_Payroll_Receipt() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""

    '        Dim AutoNumber = (From a In db.Auto_Number Select a).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewInvoice As New Auto_Number
    '            'NewInvoice.Payroll_Receipt = "E.Cpr.0001" & Now.ToString("yy")
    '            'db.Auto_Number.Add(NewInvoice)
    '            'db.SaveChanges()
    '            'GetNumber = NewInvoice.Payroll_Receipt
    '        Else
    '            AutoNumber.Payroll_Receipt += 1
    '            Dim num As String = "EC-" & AutoNumber.Payroll_Receipt.ToString().PadLeft(6, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function

    'Public Function Auto_Sch_Accounts_Invoice_Number() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Select a).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewInvoice As New Auto_Number
    '            'NewInvoice.Stu_Receipt = "R-00001" & Now.ToString("yy")
    '            'db.Auto_Number.Add(NewInvoice)
    '            'db.SaveChanges()
    '            'GetNumber = NewInvoice.Stu_Receipt
    '        Else
    '            AutoNumber.Sch_Shop_Invoice_Number += 1
    '            Dim num As String = "EXP-" & AutoNumber.Sch_Shop_Invoice_Number.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function

    'Public Function Auto_Floor_Detail_Sr() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Select a).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewInvoice As New Auto_Number
    '            'NewInvoice.Stu_Receipt = "R-00001" & Now.ToString("yy")
    '            'db.Auto_Number.Add(NewInvoice)
    '            'db.SaveChanges()
    '            'GetNumber = NewInvoice.Stu_Receipt
    '        Else
    '            AutoNumber.Auto_Floor_Detail_Sr += 1
    '            Dim num As String = "PM-" & AutoNumber.Auto_Floor_Detail_Sr.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function

    'Public Function Auto_Veh_Fuel_Detail_Invoice() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Select a).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewInvoice As New Auto_Number
    '            'NewInvoice.Stu_Receipt = "R-00001" & Now.ToString("yy")
    '            'db.Auto_Number.Add(NewInvoice)
    '            'db.SaveChanges()
    '            'GetNumber = NewInvoice.Stu_Receipt
    '        Else
    '            AutoNumber.Auto_Veh_Fuel_Detail_Invoice += 1
    '            Dim num As String = "FU-" & AutoNumber.Auto_Veh_Fuel_Detail_Invoice.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function

    'Public Function Auto_Veh_Maintinance_Invoice() As String
    '    Using db = New CsmdBioAttendenceEntities
    '        Dim GetNumber As String = ""
    '        Dim AutoNumber = (From a In db.Auto_Number Select a).FirstOrDefault
    '        If AutoNumber Is Nothing Then
    '            'Dim NewInvoice As New Auto_Number
    '            'NewInvoice.Stu_Receipt = "R-00001" & Now.ToString("yy")
    '            'db.Auto_Number.Add(NewInvoice)
    '            'db.SaveChanges()
    '            'GetNumber = NewInvoice.Stu_Receipt
    '        Else
    '            AutoNumber.Auto_Veh_Maintinance_Invoice += 1
    '            Dim num As String = "MAN-" & AutoNumber.Auto_Veh_Maintinance_Invoice.ToString().PadLeft(5, "0") & "-" & Now.ToString("yy")
    '            GetNumber = num
    '        End If
    '        Return GetNumber
    '    End Using
    'End Function
End Module
