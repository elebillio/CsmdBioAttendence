Public Class CsmdConOnline
    Public Shared myConnectionString As String = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string='data source=.\sqlexpress;initial catalog=CsmdBioAttendence;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;'"
    '"metadata=.\Model1.csdl|.\Model1.ssdl|.\Model1.msl;provider=System.Data.SqlClient;provider connection string="";data source=.\sqlexpress;initial catalog=CsmdBioAttendence;integrated security=True;multipleactiveresultsets=True;App=EntityFramework"""
    '"metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\sqlexpress;initial catalog=CsmdBioAttendence;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot'"
    'Public Shared ConOleDB As String = ConfigurationManager.ConnectionStrings("att2000ConnectionString").ConnectionString

    Public Shared Function ConSqlDBonline() As String
        Dim RAW As New CsmdBioAttendenceEntitiesOnline
        Return RAW.Database.Connection.ConnectionString
    End Function
    Public Shared kkk As Integer
    Public Shared ddd As Date
End Class