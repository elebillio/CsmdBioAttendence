Imports System.Configuration

Public Class CsmdCon
    Public Shared ConOleDB As String = ConfigurationManager.ConnectionStrings("att2000ConnectionString").ConnectionString
    Public Shared Function ConSqlDB() As String
        Dim RAW As New CsmdFazalPlazaMainEntities
        Return RAW.Database.Connection.ConnectionString
    End Function
End Class
Public Class CsmdVarible
    Public Shared intEmpID As Integer
End Class
Public Class CsmdFrm
    Public Const frmEmployeesAdd As String = "Employees Add"
    Public Const frmEmployeesRegister As String = "Employees Register"
    Public Const frmAttendanceLive As String = "Attendance Live"
    Public Const frmEmployeesAttCalculation As String = "Attendance Calculations"
    Public Const frmEmployeesInvoices As String = "Employees Payment / Invoices"
    '

End Class
Public Class CsmdDateTime
    Public Shared Function TotalHours(sum As Integer) As String
        Dim hours As Integer = sum \ 60
        Dim minutes As Integer = sum - (hours * 60)
        Dim timeElapsed As String = CType(hours, String) & ":" & CType(minutes, String)
        Return timeElapsed
    End Function
    Public Shared Function FirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
    End Function

    Public Shared Function LastDayOfMonth(ByVal sourceDate As DateTime) As String
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Return CType(lastDay.AddMonths(1).AddDays(-1), String)
    End Function
End Class
