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

Partial Public Class Emp_Pay
    Public Property Emp_Pay_ID As Integer
    Public Property Emp_ID As Nullable(Of Integer)
    Public Property Emp_Pay_Method_ID As Nullable(Of Integer)
    Public Property Emp_Pay_Frequency_ID As Nullable(Of Integer)
    Public Property Student_Source_Travel_ID As Nullable(Of Integer)
    Public Property Drv_ID As Nullable(Of Integer)

    Public Overridable Property Emp_Pay_Detail As ICollection(Of Emp_Pay_Detail) = New HashSet(Of Emp_Pay_Detail)
    Public Overridable Property Emp_Pay_Frequency As Emp_Pay_Frequency
    Public Overridable Property Emp_Pay_Method As Emp_Pay_Method
    Public Overridable Property Employee As Employee

End Class
