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

Partial Public Class Sch_Accounts
    Public Property Sch_Accounts_ID As Integer
    Public Property Sch_Accounts_Invoice_Number As String
    Public Property Sch_Accounts_Description As String
    Public Property Sch_Accounts_Default_ID As Integer
    Public Property Sch_Debit_Accounts_ID As Nullable(Of Integer)
    Public Property Sch_Credit_Accounts_ID As Nullable(Of Integer)
    Public Property Sch_Accounts_Amount_Debit As Nullable(Of Decimal)
    Public Property Sch_Accounts_Amount_Credits As Nullable(Of Decimal)
    Public Property Sch_Accounts_Added_Date As Nullable(Of Date)
    Public Property Sch_Accounts_Added_User_ID As Nullable(Of Integer)
    Public Property Sch_Accounts_Update_Date As Nullable(Of Date)
    Public Property Sch_Accounts_Update_User_ID As Nullable(Of Integer)

    Public Overridable Property Chart_Of_Accounts_Detail As ICollection(Of Chart_Of_Accounts_Detail) = New HashSet(Of Chart_Of_Accounts_Detail)
    Public Overridable Property Plaza_User As Plaza_User
    Public Overridable Property Plaza_User1 As Plaza_User
    Public Overridable Property Sch_Accounts_Default As Sch_Accounts_Default

End Class
