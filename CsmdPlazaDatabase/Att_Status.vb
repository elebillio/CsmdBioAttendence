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

Partial Public Class Att_Status
    Public Property Att_Status_ID As Integer
    Public Property Att_Status_Type As String
    Public Property Att_Status_Color As String
    Public Property Att_Status_time As String

    Public Overridable Property Emp_Attendence As ICollection(Of Emp_Attendence) = New HashSet(Of Emp_Attendence)
    Public Overridable Property Emp_Fingers As ICollection(Of Emp_Fingers) = New HashSet(Of Emp_Fingers)

End Class
