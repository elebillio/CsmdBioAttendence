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

Partial Public Class Emp_Fingers
    Public Property Emp_Fingers_ID As Integer
    Public Property Emp_ID As Nullable(Of Integer)
    Public Property Att_Status_ID As Nullable(Of Integer)
    Public Property Fingers_ID As Nullable(Of Integer)
    Public Property Emp_Fingers_Code As String
    Public Property Emp_Fingers_Image As Byte()

    Public Overridable Property Att_Status As Att_Status
    Public Overridable Property Emp_Attendence As ICollection(Of Emp_Attendence) = New HashSet(Of Emp_Attendence)
    Public Overridable Property Employee As Employee
    Public Overridable Property Finger As Finger

End Class
