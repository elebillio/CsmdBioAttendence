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

Partial Public Class Emp_Pay_Detail
    Public Property Emp_Pay_Detail_ID As Integer
    Public Property Emp_Pay_ID As Nullable(Of Integer)
    Public Property Emp_Pay_Method_Default_ID As Nullable(Of Integer)
    Public Property Emp_Pay_Detail_Std As Nullable(Of Boolean)
    Public Property Emp_Pay_Detail_GL_Account_ID As Nullable(Of Integer)
    Public Property Emp_Pay_Detail_Pay_Rate As String

    Public Overridable Property Chart_Of_Accounts As Chart_Of_Accounts
    Public Overridable Property Emp_Pay As Emp_Pay
    Public Overridable Property Emp_Pay_Method_Default As Emp_Pay_Method_Default

End Class