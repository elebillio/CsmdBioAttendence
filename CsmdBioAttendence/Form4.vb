Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class Form4


    'Data Source=.\sqlexpress;Initial Catalog=CsmdTheLeadsSchool;
    'Const SqlConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Program Files (x86)\ZKTeco\att2000.mdb"
    Dim DataT As New DataTable
    Dim Mtr As DataRow
    Dim DataT2 As New DataTable
    Dim Mtr2 As DataRow

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        LoadFormAdmin()
    End Sub
    ' Select   [Attendence_Status_ID]  ,[Attendence_Status_Type] ,[Attendence_Status_Dep] FROM [dbo].[Attendence_Status]
    Private Sub LoadFormAdmin()

        Dim mm As Integer = If(TextBox1.Text = "", 0, TextBox1.Text)


        Dim DBCon4 As New SqlConnection(SqlConnectionString)
        'Dim da As SqlDataAdapter = New OleDb.OleDbDataAdapter("SELECT USERID,Badgenumber,SSN,Name,Gender,VERIFICATIONMETHOD,DEFAULTDEPTID,ATT,INLATE,OUTEARLY,OVERTIME,SEP,HOLIDAY,LUNCHDURATION,privilege,InheritDeptSch,InheritDeptSchClass,AutoSchPlan,MinAutoSchInterval,RegisterOT,InheritDeptRule,EMPRIVILEGE,FaceGroup,AccGroup,UseAccGroupTZ,VerifyCode,Expires,ValidCount,TimeZone1,TimeZone2,TimeZone3, FROM CHECKINOUT", DBCon)
        'Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.Name, USERINFO.Gender, USERINFO.DEFAULTDEPTID FROM USERINFO; ", DBCon)
        Dim da4 As SqlDataAdapter = New SqlDataAdapter("Select * FROM Employees WHERE Emp_ID=" & mm, DBCon4)
        Dim ds4 As New DataSet()
        da4.Fill(ds4)
        Dim MyTableCount4 As Integer = ds4.Tables.Count
        Dim k4 As Integer = 1

        If MyTableCount4 = 1 Then
            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            Dim v As Integer = ds4.Tables(0).Rows(0).Item("Emp_ID")

            Dim a As Integer = v * 10

            Dim b As Integer = a - 9

            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            Dim DBCon As New SqlConnection(SqlConnectionString)
            'Dim da As SqlDataAdapter = New OleDb.OleDbDataAdapter("SELECT USERID,Badgenumber,SSN,Name,Gender,VERIFICATIONMETHOD,DEFAULTDEPTID,ATT,INLATE,OUTEARLY,OVERTIME,SEP,HOLIDAY,LUNCHDURATION,privilege,InheritDeptSch,InheritDeptSchClass,AutoSchPlan,MinAutoSchInterval,RegisterOT,InheritDeptRule,EMPRIVILEGE,FaceGroup,AccGroup,UseAccGroupTZ,VerifyCode,Expires,ValidCount,TimeZone1,TimeZone2,TimeZone3, FROM CHECKINOUT", DBCon)
            'Dim da As SqlDataAdapter = New SqlDataAdapter("SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.Name, USERINFO.Gender, USERINFO.DEFAULTDEPTID FROM USERINFO; ", DBCon)
            Dim da As SqlDataAdapter = New SqlDataAdapter("Select * FROM Attendence_Status", DBCon)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim MyTableCount As Integer = ds.Tables.Count
            Dim k As Integer = 1
            'DataT.Rows.Clear()
            For Each row As DataRow In ds.Tables(0).Rows


                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

                Dim DBCon2 As New OleDb.OleDbConnection(SqlConnectionString2)
                Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT * FROM USERINFO WHERE DEFAULTDEPTID=" & row.Item("Attendence_Status_Dep") & " and Name='" & ds4.Tables(0).Rows(0).Item("Emp_Name") & "' and Badgenumber='" & b & "'", DBCon2)
                Dim ds2 As New DataSet()
                da2.Fill(ds2)
                Dim MyTableCount2 As Integer = ds2.Tables(0).Rows.Count
                Dim k2 As Integer = 1

                'MsgBox(CStr(MyTableCount2))


                If MyTableCount2 = 0 Then
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                    Dim SqldataSet3 As New DataSet()
                    Dim dataadapter3 As New OleDb.OleDbDataAdapter
                    Dim cmd3 As New OleDb.OleDbCommand
                    Dim connection3 As New OleDb.OleDbConnection(SqlConnectionString2)
                    connection3.Open()
                    cmd3.Connection = connection3
                    'cmd.CommandText = Crt_Login
                    'cmd.ExecuteScalar()


                    Dim Crt_User As String = "INSERT INTO USERINFO (Badgenumber,SSN,Name,Gender,DEFAULTDEPTID) VALUES ('" & b & "','" & row.Item("Attendence_Status_Type") & "','" & ds4.Tables(0).Rows(0).Item("Emp_Name") & "','M'," & row.Item("Attendence_Status_Dep") & ")"
                    cmd3.CommandText = Crt_User
                    cmd3.ExecuteNonQuery()


                    '3 * 10 30=

                    connection3.Close()
                    'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                Else


                End If



                'DataT.Rows.Clear()
                'For Each row As DataRow In ds.Tables(0).Rows
                '    'ListBox1.Items.Add(row.Item("TABLE_NAME"))

                '    Mtr = DataT.NewRow

                '    Mtr.Item("SC_ID") = k
                '    Mtr.Item("SC_TableCaption") = Replace(row.Item("TABLE_NAME"), "_", " ")
                '    Mtr.Item("SC_TableName") = row.Item("TABLE_NAME")
                '    'Mtr.Item("SC_Select") = False
                '    'Mtr.Item("SC_Insert") = False
                '    'Mtr.Item("SC_Update") = False
                '    'Mtr.Item("SC_Delete") = False

                '    DataT.Rows.Add(Mtr)
                '    k += 1
                'Next row
                'GridView1.Columns("ADD").Visible = True
                'GridControl1.DataSource = Nothing
                'GridControl1.DataSource = ds2.Tables(0)

                DBCon2.Close()

                'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx





                '    'ListBox1.Items.Add(row.Item("TABLE_NAME"))

                '    Mtr = DataT.NewRow

                '    Mtr.Item("SC_ID") = k
                '    Mtr.Item("SC_TableCaption") = Replace(row.Item("TABLE_NAME"), "_", " ")
                '    Mtr.Item("SC_TableName") = row.Item("TABLE_NAME")
                '    'Mtr.Item("SC_Select") = False
                '    'Mtr.Item("SC_Insert") = False
                '    'Mtr.Item("SC_Update") = False
                '    'Mtr.Item("SC_Delete") = False

                '    DataT.Rows.Add(Mtr)
                k += 1
                b += 1
            Next row
            'GridView1.Columns("ADD").Visible = True
            GridControl1.DataSource = Nothing
            GridControl1.DataSource = ds.Tables(0)

            DBCon.Close()

            'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
        End If
        DBCon4.Close()

        SimpleButton3.PerformClick()
    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs) Handles SimpleButton2.Click
        'Try
        'Dim Crt_Login As String = "create login " & UserID.EditValue & " with password='" & UserPass.EditValue & "'"

        Dim SqldataSet As New DataSet()
        Dim dataadapter As New OleDb.OleDbDataAdapter
        Dim cmd As New OleDb.OleDbCommand
        Dim connection As New OleDb.OleDbConnection(SqlConnectionString)
        connection.Open()
        cmd.Connection = connection
        'cmd.CommandText = Crt_Login
        'cmd.ExecuteScalar()

        For I As Integer = 5 To 10
            Dim Crt_User As String = "INSERT INTO USERINFO (Badgenumber,SSN,Name,Gender,DEFAULTDEPTID) VALUES (" & I & ",'mk','Afzaal','M'," & I + 1 & ")"
            cmd.CommandText = Crt_User
            cmd.ExecuteNonQuery()
        Next



        connection.Close()
        'Catch ex As OleDbException
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        Dim DBCon2 As New OleDb.OleDbConnection(SqlConnectionString2)
        Dim da2 As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter("SELECT USERINFO.USERID, USERINFO.Badgenumber, USERINFO.SSN, USERINFO.Name, CHECKINOUT.CHECKTIME BFROM CHECKINOUT INNER JOIN USERINFO ON CHECKINOUT.USERID = USERINFO.USERID;", DBCon2)
        Dim ds2 As New DataSet()
        da2.Fill(ds2)

        GridControl2.DataSource = ds2.Tables(0)
    End Sub
End Class