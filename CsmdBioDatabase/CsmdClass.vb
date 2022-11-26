Imports System.Configuration
Imports System.Net

Public Class CsmdCon
    Public Shared myConnectionString As String = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string='data source=.\sqlexpress;initial catalog=CsmdBioAttendence;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;'"
    '"metadata=.\Model1.csdl|.\Model1.ssdl|.\Model1.msl;provider=System.Data.SqlClient;provider connection string="";data source=.\sqlexpress;initial catalog=CsmdBioAttendence;integrated security=True;multipleactiveresultsets=True;App=EntityFramework"""
    '"metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\sqlexpress;initial catalog=CsmdBioAttendence;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot'"
    'Public Shared ConOleDB As String = ConfigurationManager.ConnectionStrings("att2000ConnectionString").ConnectionString
    Public Shared Function ConSqlDB() As String
        Dim RAW As New CsmdBioAttendenceEntities
        Return RAW.Database.Connection.ConnectionString
    End Function
    'Public Shared Function ConSqlDBonline() As String
    '    Dim RAW As New CsmdBioAttendenceEntitiesonline
    '    Return RAW.Database.Connection.ConnectionString
    'End Function
    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
End Class
Public Class CsmdVarible
    Public Shared intEmpID As Integer
    '  Public Shared updatePath As String
End Class
Public Class CsmdFrm
    Public Shared frmPaymentsShowX As String
    Public Const frmPaymentsShow As String = "Payments Register"
    Public Shared frmDeviceRegistersX As String
    Public Const frmDeviceRegisters As String = "Device Register"
    Public Const frmDashBoardPreview As String = "DashBoard" '5
    Public Const frmDashBoard As String = "DashBoard Designer" '6

    Public Shared frmDashBoardPreviewX As String
    Public Shared frmDashBoardX As String

    Public Const frmPrintPreview As String = "Reports"
    Public Const frmPrintDesigner As String = "Reports Designer" '8

    Public Shared frmPrintPreviewX As String
    Public Shared frmPrintDesignerX As String

    Public Const frmEmployeesAdd As String = "Employees Add" '0
    Public Const frmEmployeesRegister As String = "Employees Register" '1
    Public Const frmAttendanceLive As String = "ATT Live and Editor" '2
    Public Const frmEmployeesAttCalculation As String = "Calculations and Payments" '3
    'Public Const frmEmployeesInvoices As String = "Employees Payment / Invoices"

    Public Shared frmEmployeesAddX As String
    Public Shared frmEmployeesRegisterX As String
    Public Shared frmAttendanceLiveX As String
    Public Shared frmEmployeesAttCalculationX As String
    'Public Shared frmEmployeesInvoicesX As String

    Public Const Ax1 As String = "CSMD Softwares"
    Public Const Ax2 As String = "ZKTeco Device K-40"
    Public Const Ax3 As String = "IP:192.168.1.201"
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

    Public Shared Function LastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
        Return CType(lastDay.AddMonths(1).AddDays(-1), String)
    End Function
    Public Shared Function StartDayTime(Datx As Date) As String
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Emp_Att_Set Where a.Emp_Att_Set_Date.Value.Month = Datx.Month And a.Emp_Att_Set_Date.Value.Year = Datx.Year Select a.Emp_Att_Set_Open_Time).FirstOrDefault
            If dt IsNot Nothing Then
                Return dt.ToString
            Else
                Return "06:00"
            End If
        End Using
    End Function
    Public Shared Function EndDayTime(Datx As Date) As String
        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Emp_Att_Set Where a.Emp_Att_Set_Date.Value.Month = Datx.Month And a.Emp_Att_Set_Date.Value.Year = Datx.Year Select a.Emp_Att_Set_Close_Time).FirstOrDefault
            If dt IsNot Nothing Then
                Return dt.ToString
            Else
                Return "05:59"
            End If
        End Using
    End Function
End Class
