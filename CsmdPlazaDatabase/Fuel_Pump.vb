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

Partial Public Class Fuel_Pump
    Public Property Fuel_Pump_ID As Integer
    Public Property Fuel_Pump_Name As String
    Public Property Fuel_Pump_Address As String
    Public Property Fuel_Pump_Phone As String

    Public Overridable Property Veh_Fuel_Detail As ICollection(Of Veh_Fuel_Detail) = New HashSet(Of Veh_Fuel_Detail)

End Class
