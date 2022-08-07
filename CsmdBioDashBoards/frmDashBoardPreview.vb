Imports System.Windows.Forms
Imports DevExpress.XtraNavBar

Public Class frmDashBoardPreview
    Inherits frmDashBoard

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Folder()
    End Sub



#Region "Get Reports"
    Dim gp() As NavBarGroup
    Dim itg() As NavBarItem
    Dim mm As Integer
    Dim i As Integer


    Public Sub Folder()
        Dim objFSO As Object
        Dim objFolder As Object
        Dim objFile As Object
        NavBarControl1.Groups.Clear()
        NavBarControl1.Items.Clear()
        objFSO = CreateObject("Scripting.FileSystemObject")
        objFolder = objFSO.GetFolder(".\")
        For Each objFile In objFolder.subfolders
            If objFile.name.ToString = "DashBoard" Then
                ReDim gp(i)
                gp(i) = NavBarControl1.Groups.Add
                gp(i).Caption = objFile.name
                gp(i).Expanded = True
                LoadReportFromFile(".\" & objFile.Name & "")
                i = i + 1
            End If
        Next objFile
    End Sub
    Public Sub LoadReportFromFile(Path As String)
        Dim di As New IO.DirectoryInfo(My.Application.Info.DirectoryPath + Path)
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo
        For Each dra In diar1
            If dra.Extension = ".xml" Then
                ReDim itg(mm)
                itg(mm) = NavBarControl1.Items.Add
                itg(mm).Caption = System.IO.Path.GetFileNameWithoutExtension(dra.Name)
                gp(i).ItemLinks.Add(itg(mm))
                mm = mm + 1
            End If
        Next
    End Sub
#End Region


    Private Sub NavBarControl1_Click(sender As Object, e As EventArgs) Handles NavBarControl1.Click

    End Sub

    Private Sub NavBarControl1_LinkClicked(sender As Object, e As NavBarLinkEventArgs) Handles NavBarControl1.LinkClicked
        DashboardViewer1.DashboardSource = Application.StartupPath & "\DashBoard\" & e.Link.Item.Caption & ".xml"
        DashboardViewer1.Dashboard.Title.Text = e.Link.Item.Caption
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        ShowDialog()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Folder()
    End Sub
End Class