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

Partial Public Class Customer
    Public Property Cus_ID As Integer
    Public Property Plaza_ID As Nullable(Of Integer)
    Public Property Cus_Status As Nullable(Of Boolean)
    Public Property Cus_Code As String
    Public Property Cus_Name As String
    Public Property Cus_Name_Urdu As String
    Public Property Cus_Image As Byte()
    Public Property Cus_Father As String
    Public Property Cus_Nic_No As String
    Public Property Cus_Phone1 As String
    Public Property Cus_Phone2 As String
    Public Property Cus_Address As String
    Public Property Cus_City As String
    Public Property Cus_Reliegn As String
    Public Property Cus_Added_Date As Nullable(Of Date)
    Public Property Cus_Leave_Date As Nullable(Of Date)
    Public Property Cus_Deposit As Nullable(Of Double)
    Public Property User_ID As Nullable(Of Integer)

    Public Overridable Property Customer_Bridge As ICollection(Of Customer_Bridge) = New HashSet(Of Customer_Bridge)
    Public Overridable Property Plaza As Plaza
    Public Overridable Property Plaza_User As Plaza_User
    Public Overridable Property RB_Pay_Detail As ICollection(Of RB_Pay_Detail) = New HashSet(Of RB_Pay_Detail)

End Class
