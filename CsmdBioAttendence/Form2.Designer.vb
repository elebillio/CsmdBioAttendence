<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.NavigationPane1 = New DevExpress.XtraBars.Navigation.NavigationPane()
        Me.NavigationPage1 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.NavigationPage2 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.NavigationPage3 = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.NavigationPane1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NavigationPane1
        '
        Me.NavigationPane1.AllowHtmlDraw = True
        Me.NavigationPane1.Controls.Add(Me.NavigationPage1)
        Me.NavigationPane1.Controls.Add(Me.NavigationPage2)
        Me.NavigationPane1.Controls.Add(Me.NavigationPage3)
        Me.NavigationPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigationPane1.Location = New System.Drawing.Point(0, 0)
        Me.NavigationPane1.Name = "NavigationPane1"
        Me.NavigationPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPage() {Me.NavigationPage1, Me.NavigationPage2, Me.NavigationPage3})
        Me.NavigationPane1.RegularSize = New System.Drawing.Size(801, 423)
        Me.NavigationPane1.SelectedPage = Me.NavigationPage2
        Me.NavigationPane1.SelectedPageIndex = 0
        Me.NavigationPane1.Size = New System.Drawing.Size(753, 484)
        Me.NavigationPane1.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Expanded
        Me.NavigationPane1.TabIndex = 0
        Me.NavigationPane1.Text = "NavigationPane1"
        '
        'NavigationPage1
        '
        Me.NavigationPage1.Caption = "NavigationPage1"
        Me.NavigationPage1.CustomHeaderButtons.AddRange(New DevExpress.XtraBars.Docking2010.IButton() {New DevExpress.XtraBars.Docking.CustomHeaderButton("Button", CType(resources.GetObject("NavigationPage1.CustomHeaderButtons"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1), New DevExpress.XtraBars.Docking.CustomHeaderButton("Button", CType(resources.GetObject("NavigationPage1.CustomHeaderButtons1"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1), New DevExpress.XtraBars.Docking.CustomHeaderButton("Button", CType(resources.GetObject("NavigationPage1.CustomHeaderButtons2"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1), New DevExpress.XtraBars.Docking.CustomHeaderButton("Button", CType(resources.GetObject("NavigationPage1.CustomHeaderButtons3"), System.Drawing.Image), -1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, -1)})
        Me.NavigationPage1.Image = CType(resources.GetObject("NavigationPage1.Image"), System.Drawing.Image)
        Me.NavigationPage1.Name = "NavigationPage1"
        Me.NavigationPage1.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.NavigationPage1.Size = New System.Drawing.Size(610, 410)
        '
        'NavigationPage2
        '
        Me.NavigationPage2.Caption = "NavigationPage2"
        Me.NavigationPage2.Image = CType(resources.GetObject("NavigationPage2.Image"), System.Drawing.Image)
        Me.NavigationPage2.Name = "NavigationPage2"
        Me.NavigationPage2.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.NavigationPage2.Size = New System.Drawing.Size(610, 410)
        '
        'NavigationPage3
        '
        Me.NavigationPage3.Caption = "NavigationPage3"
        Me.NavigationPage3.Image = CType(resources.GetObject("NavigationPage3.Image"), System.Drawing.Image)
        Me.NavigationPage3.Name = "NavigationPage3"
        Me.NavigationPage3.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText
        Me.NavigationPage3.Size = New System.Drawing.Size(610, 410)
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(753, 484)
        Me.Controls.Add(Me.NavigationPane1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.NavigationPane1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents NavigationPane1 As DevExpress.XtraBars.Navigation.NavigationPane
    Friend WithEvents NavigationPage1 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NavigationPage2 As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents NavigationPage3 As DevExpress.XtraBars.Navigation.NavigationPage
End Class
