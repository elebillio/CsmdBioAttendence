'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class RB_Pay
    Public Property RB_Pay_ID As Integer
    Public Property Cus_Detail_ID As Nullable(Of Integer)
    Public Property RB_Pay_IDx As Nullable(Of Integer)
    Public Property RB_Pay_IssueDate As Nullable(Of Date)
    Public Property RB_Pay_Start_Reading As Nullable(Of Double)
    Public Property RB_Pay_End_Reading As Nullable(Of Double)
    Public Property RB_Pay_Used_Unit As Nullable(Of Decimal)
    Public Property RB_Pay_Unit_Price As Nullable(Of Decimal)
    Public Property RB_Pay_Bill_Amt As Nullable(Of Decimal)
    Public Property RB_Pay_Tax_Percent As Nullable(Of Decimal)
    Public Property RB_Pay_Tax_Unit As Nullable(Of Decimal)
    Public Property RB_Pay_Tax_Amt As Nullable(Of Decimal)
    Public Property RB_Pay_TBill As Nullable(Of Decimal)
    Public Property RB_Pay_Gas_Start_Reading As Nullable(Of Double)
    Public Property RB_Pay_Gas_End_Reading As Nullable(Of Double)
    Public Property RB_Pay_Gas_Used_Unit As Nullable(Of Decimal)
    Public Property RB_Pay_Gas_Unit_Price As Nullable(Of Decimal)
    Public Property RB_Pay_Gas_TBill As Nullable(Of Decimal)
    Public Property RB_Pay_Rent As Nullable(Of Decimal)
    Public Property RB_Pay_Rent_Update As String
    Public Property User_ID As Nullable(Of Integer)

    Public Overridable Property Customer_Bridge As Customer_Bridge
    Public Overridable Property Plaza_User As Plaza_User

End Class
