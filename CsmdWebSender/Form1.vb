
Imports MySql.Data.MySqlClient

Public Class Form1
    Public dbconn As New MySqlConnection
    Public sql As String
    Public dbcomm As New MySqlCommand
    Public dbread As MySqlDataReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn = New MySqlConnection("server=localhost;" _
            & "uid=id19393375_csmdelebillio;" _
            & "pwd=26FAI26sal?1;" _
            & "database=id19393375_csmdbioattendance")
        Try
            dbconn.Open()


            sql = "INSERT INTO Employees(Emp_Name,Emp_Father,Emp_Phone) VALUES('aa','bb','cc')"
            Try
                dbcomm = New MySqlCommand(sql, dbconn)
                dbread = dbcomm.ExecuteReader()
                dbread.Close()
                MsgBox("Data inserted.")
            Catch ex As Exception
                MsgBox("Failed to insert data: " & ex.Message.ToString())
            End Try
            dbread.Close()
        Catch ex As Exception
            MsgBox("Connection Error: " & ex.Message.ToString)
        End Try

    End Sub
End Class
