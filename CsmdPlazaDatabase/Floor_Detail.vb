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

Partial Public Class Floor_Detail
    Public Property Floor_Detail_ID As Integer
    Public Property Floor_ID As Nullable(Of Integer)
    Public Property Floor_Detail_Sr As String
    Public Property Floor_Detail_IssueDate As Nullable(Of Date)
    Public Property Floor_Detail_LastDate As Nullable(Of Date)
    Public Property Floor_Detail_Used_Unit As Nullable(Of Decimal)
    Public Property Floor_Detail_Unit_Price As Nullable(Of Decimal)
    Public Property Floor_Detail_TBill As Nullable(Of Decimal)
    Public Property Floor_Detail_Fine As Nullable(Of Decimal)
    Public Property Floor_Detail_Payable As Nullable(Of Decimal)
    Public Property User_ID As Nullable(Of Integer)

    Public Overridable Property Floor As Floor
    Public Overridable Property Plaza_User As Plaza_User

End Class
