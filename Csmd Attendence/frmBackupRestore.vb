Imports System.Data.SqlClient
Imports System.Configuration
 
Public Class frmBackupRestore

    Dim con As SqlConnection
    Dim con2 As SqlConnection
    Dim cmd As SqlCommand
    Dim cmd2 As SqlCommand
    Dim dread As SqlDataReader

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'server(".")
        server(".\sqlexpress")
    End Sub

    Sub server(ByVal str As String)
        con = New SqlConnection("Data Source=" & str & ";Database=Master;integrated security=SSPI;")
        con.Open()
        cmd = New SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con)
        dread = cmd.ExecuteReader
        cmbserver.Items.Clear()
        While dread.Read
            cmbserver.Items.Add(dread(2))
        End While
        dread.Close()
    End Sub

    Sub connection()
        con = New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";Database=Master;integrated security=SSPI;")
        con.Open()
        cmbdatabase.Items.Clear()
        cmd = New SqlCommand("select * from sysdatabases", con)
        dread = cmd.ExecuteReader
        While dread.Read
            cmbdatabase.Items.Add(dread(0))
        End While
        dread.Close()
    End Sub

    Private Sub cmbserver_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbserver.SelectedIndexChanged
        connection()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        'Try
        Dim sd As New SaveFileDialog()
        'sd.Filter = "SQL Server database backup files"
        sd.Title = "Create Database Backup"
        sd.FileName = "CsmdBioAttendence_Backup_" & Now.ToString("d-M-yyyy_hh-mm tt" & ".bak")

        'CsmdTheLeadsSchool_Backup_" & sd.FileName & Now.ToString("d-mm-yyyy") & "
        If sd.ShowDialog() = DialogResult.OK Then
            'MsgBox(sd.FileName)
            Using conn As New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";Initial Catalog=CsmdBioAttendence;integrated security=True;")
                Dim sqlStmt As String = String.Format("backup database [" & cmbdatabase.Text.Trim & "] to disk='{0}'", sd.FileName)
                'Dim sqlStmt As String = String.Format("backup database [" & cmbdatabase.Text.Trim & "] to disk='{0}'", System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak")
                Using bu2 As New SqlCommand(sqlStmt, conn)
                    conn.Open()
                    bu2.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Backup Created Sucessfully")
                End Using
            End Using
        End If
        'Catch generatedExceptionName As Exception
        '    MessageBox.Show(generatedExceptionName.Message)
        'End Try
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'Try
        Dim sd As New OpenFileDialog()
        'sd.Filter = "SQL Server database backup files|*.bak"
        sd.Title = "Create Database Backup"
        If sd.ShowDialog() = DialogResult.OK Then
            'Using conn As New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";AttachDbFilename=|DataDirectory|DATA\CsmdTheLeadsSchool.mdf;integrated security=True;")
            Using conn As New SqlConnection("Data Source=" & Trim(cmbserver.Text) & ";Initial Catalog=master; integrated security=True;")
                'Dim sqlStmt As String = String.Format("backup database [" + System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool.mdf] to disk='{0}'", sd.FileName)
                'System.Windows.Forms.Application.StartupPath + "\DATA\CsmdTheLeadsSchool_Backup.bak
                'query("DROP DATABASE " & ComboBoxdb.Text)
                Dim ff = "alter database [" & cmbdatabase.Text.Trim & "]  set offline with rollback immediate"
                Dim sqlStmt As String = String.Format("RESTORE database [" & cmbdatabase.Text.Trim & "] from disk='" + sd.FileName + "'WITH REPLACE, RECOVERY")
                Dim ggg = "alter database [" & cmbdatabase.Text.Trim & "] set online"
                Using bu1 As New SqlCommand(ff, conn)
                    conn.Open()
                    bu1.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Offline Created Sucessfully")
                End Using
                Using bu2 As New SqlCommand(sqlStmt, conn)
                    conn.Open()
                    bu2.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Restore Created Sucessfully")
                End Using
                Using bu3 As New SqlCommand(ggg, conn)
                    conn.Open()
                    bu3.ExecuteNonQuery()
                    conn.Close()
                    MessageBox.Show("Online Created Sucessfully")
                End Using
            End Using
        End If
        'Catch generatedExceptionName As Exception
        '    MessageBox.Show(generatedExceptionName.Message)
        'End Try
    End Sub
End Class