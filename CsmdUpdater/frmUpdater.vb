Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
'Imports System.Text

Public Class frmUpdater
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs)
        '   Try
        'Process.Start("")
        Kill(Application.StartupPath & "\Csmd Attendence.exe")
        Kill(Application.StartupPath & "\Csmd RM Live.exe")
        Kill(Application.StartupPath & "\CsmdBioDashBoard.dll")
        Kill(Application.StartupPath & "\CsmdBioDatabase.dll")
        Kill(Application.StartupPath & "\CsmdBioReports.dll")
        'Catch ex As Exception

        'End Try

    End Sub

    Private Sub SimpleButton2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub SimpleButton3_Click(sender As Object, e As EventArgs) Handles SimpleButton3.Click

        'Dim password As String = "..."
        'Dim username As String = "..."

        'Using client As New WebClient()

        '    client.Credentials = New NetworkCredential(username, password)
        '    client.DownloadFile(remoteUri, fileName)
        'End Using
        'ServicePointManager.SecurityProtocol = 3072
        ' ServicePointManager.DefaultConnectionLimit = 9999

        '   Dim remoteUri As String = "http://www.contoso.com/library/homepage/images/"
        '  Dim fileName As String = "ms-banner.gif"

        'Console.WriteLine("Downloading File ""{0}"" from ""{1}"" ......." + ControlChars.Cr + ControlChars.Cr, fileName, myStringWebResource)
        ' The DownloadFile() method downloads the Web resource and saves it into the current file-system folder.
        'myWebClient.DownloadFile(myStringWebResource, fileName)
        'Console.WriteLine("Successfully Downloaded file ""{0}"" from ""{1}""", fileName, myStringWebResource)
        'Console.WriteLine((ControlChars.Cr + "Downloaded file saved in the following file system folder:" + ControlChars.Cr + ControlChars.Tab + Application.StartupPath))
        'Dim remoteUri As String = "https://csmdsoft.weebly.com/uploads/1/4/2/7/142709025/"
        'Dim fileName As String = "csmd_attendence.exe"
        'Dim myStringWebResource As String = Nothing
        '' Create a new WebClient instance.
        'Dim myWebClient As New WebClient()
        '' Concatenate the domain with the Web resource filename. Because DownloadFile 
        ''requires a fully qualified resource name, concatenate the domain with the Web resource file name.
        'myStringWebResource = remoteUri + fileName
        'Me.Cursor = Cursors.WaitCursor
        'Application.DoEvents()

        'Try
        '    ServicePointManager.Expect100Continue = True
        '    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        '    ' Make a WebClient.
        '    Dim web_client As WebClient = New WebClient

        '    web_client.UseDefaultCredentials = True
        '    web_client.Encoding = Encoding.UTF8
        '    ' Download the file.
        '    web_client.DownloadFile(myStringWebResource, Application.StartupPath & "\" & fileName)

        '    MessageBox.Show("Done")
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Download Error",
        '        MessageBoxButtons.OK,
        '            MessageBoxIcon.Exclamation)
        'End Try

        'Me.Cursor = Cursors.Default
        'If IsConnectedToInternet() = True Then

        Try
            Kill(Application.StartupPath & "\Csmd Attendence.exe")
            Kill(Application.StartupPath & "\Csmd RM Live.exe")
            Kill(Application.StartupPath & "\CsmdBioDashBoard.dll")
            Kill(Application.StartupPath & "\CsmdBioDatabase.dll")
            Kill(Application.StartupPath & "\CsmdBioReports.dll")
        Catch ex As Exception

        End Try
        lbl1.Text = "a"
        DownloadStart("Csmd%20Attendence.exe", False)
        lbl1.Text = "b"
        DownloadStart("Csmd%20RM%20Live.exe", False)
        lbl1.Text = "c"
        DownloadStart("CsmdBioDashBoard.dll", False)
        lbl1.Text = "d"
        DownloadStart("CsmdBioDatabase.dll", False)
        lbl1.Text = "Start Downloading..."
        DownloadStart("CsmdBioReports.dll", False)
        'Else
        '    MsgBox("net error")
        'End If

    End Sub
    Public Function IsConnectedToInternet() As Boolean
        Dim host As String = "http://www.google.com"
        Dim result As Boolean = False
        Dim p As Ping = New Ping()


        Try
            Dim reply As PingReply = p.Send(host, 3000)
            If reply.Status = IPStatus.Success Then
                Return True
            End If
        Catch ex As Exception

        End Try
        Return result
    End Function
    Public downloader As WebClient

    Public Sub DownloadStart(fileName As String, FileAction As Boolean)
        Dim remoteUri As String = "https://raw.githubusercontent.com/elebillio/parismart/master/"
        ProgressBar1.Visible = True
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        downloader = New WebClient

        AddHandler downloader.DownloadFileCompleted, AddressOf DownloadComplete
            AddHandler downloader.DownloadProgressChanged, AddressOf DownloadProgress
            downloader.DownloadFileAsync(New Uri(remoteUri + fileName), Application.StartupPath & "\" & Replace(fileName, "%20", " "))




    End Sub

    Private Sub DownloadProgress(sender As Object, e As DownloadProgressChangedEventArgs) 'Handles downloader.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        ProgressBar1.CreateGraphics().DrawString(e.ProgressPercentage, New Font("Arial",
       9, FontStyle.Bold),
       Brushes.Red, New PointF(ProgressBar1.Width / 2 - 10, ProgressBar1.Height / 2 - 7))
    End Sub
    Dim k As Integer = 0
    Public Sub DownloadComplete(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) ' Handles downloader.DownloadDataCompleted
        If e.Error Is Nothing = False Then
            '      Label6.Text = e.Error.InnerException.ToString
            Return
        End If

        Threading.Thread.Sleep(3000)
        MsgBox("Download Complete!")
        Close()
        k += 1
        If k = 5 Then
            Process.Start(Application.StartupPath & "\Csmd Attendence.exe")
        End If

    End Sub
    Private Sub UploadProgress(sender As Object, e As UploadProgressChangedEventArgs) 'Handles downloader.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
    End Sub
    Dim h As Integer = 0
    Public Sub UploadComplete(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) ' Handles downloader.DownloadDataCompleted
        If e.Error Is Nothing = False Then
            '      Label6.Text = e.Error.InnerException.ToString
            Return
        End If

        Threading.Thread.Sleep(3000)
        MsgBox("Download Complete!")
        Close()
        h += 1
        If h = 5 Then
            Process.Start(Application.StartupPath & "\Csmd Attendence.exe")
        End If

    End Sub

    Private Sub SimpleButton1_Click_1(sender As Object, e As EventArgs)
        'lbl1.Text = "a"
        'DownloadStart("Csmd%20Attendence.exe", True)
        'lbl1.Text = "b"
        'DownloadStart("Csmd%20RM%20Live.exe", True)
        'lbl1.Text = "c"
        'DownloadStart("CsmdBioDashBoard.dll", True)
        'lbl1.Text = "d"
        'DownloadStart("CsmdBioDatabase.dll", True)
        'lbl1.Text = "Start Downloading..."
        'DownloadStart("CsmdBioReports.dll", True)
        'Dim remoteUri As String = "https://raw.githubusercontent.com/elebillio/parismart/master/"
        'Dim fileName As String = "Csmd%20Attendence.exe"
        'Dim request As WebRequest = WebRequest.Create(remoteUri + fileName)
        'request.Credentials = New NetworkCredential("elebillio", "26FAI26sal")
        'request.Method = WebRequestMethods.Ftp.UploadFile

        'Using fileStream As Stream = File.OpenRead(Application.StartupPath & "\" & Replace(fileName, "%20", " ")),
        '      ftpStream As Stream = request.GetRequestStream()
        '    Dim buffer As Byte() = New Byte(10240 - 1) {}
        '    Dim read As Integer
        '    Do
        '        read = fileStream.Read(buffer, 0, buffer.Length)
        '        If read > 0 Then
        '            ftpStream.Write(buffer, 0, read)
        '            Console.WriteLine("Uploaded {0} bytes", fileStream.Position)
        '        End If
        '    Loop While read > 0
        'End Using
    End Sub

    Private Sub SimpleButton1_Click_2(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'If LabelControl1.Text = "" Then
        Dim remoteUri As String = "https://raw.githubusercontent.com/elebillio/parismart/master/header.txt"
        ProgressBar1.Visible = True
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            downloader = New WebClient

        '  AddHandler downloader.DownloadStringCompleted, AddressOf DownloadComplete
        'AddHandler downloader.DownloadProgressChanged, AddressOf DownloadProgress
        aa.Text = downloader.DownloadString(remoteUri)
        'Timer1.Enabled = False
        'End If
        'Dim parts As String() = aa.Text.Split(New Char() {","c})
        'aa.Text = Replace(parts(0), ",", "")
        'bb.Text = Replace(parts(1), ",", "")
        'cc.Text = Replace(parts(2), ",", "")
        'dd.Text = Replace(parts(3), ",", "")
        'ee.Text = Replace(parts(4), ",", "")
        'ff.Text = Replace(parts(5), ",", "")
        'gg.Text = Replace(parts(6), ",", "")

        'For Each line As String In File.ReadLines(aa.Text)
        '    ' Display the line.
        '    ee.Text = line
        'Next
        Dim aLine, aParagraph As String
        Dim strReader As New StringReader(aa.Text)
        Dim j As Integer = 0
        While True
            aLine = strReader.ReadLine()
            If aLine Is Nothing Then
                aParagraph = aParagraph & vbCrLf
                Exit While
            Else
                aParagraph = aParagraph & aLine & " "
            End If
            Select Case j
                Case 0
                    aa.Text = aLine
                Case 1
                    bb.Text = aLine
                Case 2
                    cc.Text = aLine
                Case 3
                    dd.Text = aLine
                'Case 4
                '    ee.Text = aLine
                Case 5
                    ff.Text = aLine
                Case 6
                    gg.Text = aLine
            End Select
            j += 1
        End While
        Dim remoteUri2 As String = "https://raw.githubusercontent.com/elebillio/parismart/master/notes.txt"
        'ProgressBar1.Visible = True
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
        downloader = New WebClient

        '  AddHandler downloader.DownloadStringCompleted, AddressOf DownloadComplete
        'AddHandler downloader.DownloadProgressChanged, AddressOf DownloadProgress
        ee.Text = downloader.DownloadString(remoteUri2)
        'ee.Text = aParagraph
    End Sub
End Class
