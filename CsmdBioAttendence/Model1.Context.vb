﻿'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class CsmdBioAttendenceEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=CsmdBioAttendenceEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Property Attendence_Status() As DbSet(Of Attendence_Status)
    Public Property Emp_Att_Payment() As DbSet(Of Emp_Att_Payment)
    Public Property Emp_Att_Set() As DbSet(Of Emp_Att_Set)
    Public Property Emp_Attendence_Device() As DbSet(Of Emp_Attendence_Device)
    Public Property Plaza_User() As DbSet(Of Plaza_User)
    Public Property sysdiagrams() As DbSet(Of sysdiagram)
    Public Property User_Type() As DbSet(Of User_Type)
    Public Property Auto_Number() As DbSet(Of Auto_Number)
    Public Property Employees() As DbSet(Of Employee)

End Class
