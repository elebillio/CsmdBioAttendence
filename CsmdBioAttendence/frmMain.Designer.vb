<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.SkinBarSubItem1 = New DevExpress.XtraBars.SkinBarSubItem()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.FormAssistant1 = New DevExpress.XtraBars.FormAssistant()
        Me.BackstageViewControl1 = New DevExpress.XtraBars.Ribbon.BackstageViewControl()
        Me.BackstageViewClientControl1 = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.BackstageViewClientControl2 = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.BackstageViewClientControl3 = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.BackstageViewClientControl4 = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.BackstageViewClientControl5 = New DevExpress.XtraBars.Ribbon.BackstageViewClientControl()
        Me.BackstageViewButtonItem1 = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.BackstageViewTabItem1 = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.BackstageViewTabItem2 = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.BackstageViewItemSeparator1 = New DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator()
        Me.BackstageViewButtonItem2 = New DevExpress.XtraBars.Ribbon.BackstageViewButtonItem()
        Me.BackstageViewTabItem3 = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.BackstageViewTabItem4 = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.BackstageViewTabItem5 = New DevExpress.XtraBars.Ribbon.BackstageViewTabItem()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BackstageViewControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BackstageViewControl1.SuspendLayout()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 739)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Nothing
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(1231, 20)
        '
        'BarManager1
        '
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.SkinBarSubItem1})
        Me.BarManager1.MaxItemId = 4
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom
        Me.Bar1.FloatLocation = New System.Drawing.Point(-1734, 373)
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.SkinBarSubItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1, True)})
        Me.Bar1.Text = "Tools"
        '
        'SkinBarSubItem1
        '
        Me.SkinBarSubItem1.Caption = "Themes"
        Me.SkinBarSubItem1.Id = 3
        Me.SkinBarSubItem1.Name = "SkinBarSubItem1"
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Color"
        Me.BarButtonItem1.Id = 2
        Me.BarButtonItem1.Name = "BarButtonItem1"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Size = New System.Drawing.Size(1231, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 640)
        Me.barDockControlBottom.Size = New System.Drawing.Size(1231, 29)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 640)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1231, 0)
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 640)
        '
        'BackstageViewControl1
        '
        Me.BackstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow
        Me.BackstageViewControl1.Controls.Add(Me.BackstageViewClientControl1)
        Me.BackstageViewControl1.Controls.Add(Me.BackstageViewClientControl2)
        Me.BackstageViewControl1.Controls.Add(Me.BackstageViewClientControl3)
        Me.BackstageViewControl1.Controls.Add(Me.BackstageViewClientControl4)
        Me.BackstageViewControl1.Controls.Add(Me.BackstageViewClientControl5)
        Me.BackstageViewControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewButtonItem1)
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewTabItem1)
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewTabItem2)
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewItemSeparator1)
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewButtonItem2)
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewTabItem3)
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewTabItem4)
        Me.BackstageViewControl1.Items.Add(Me.BackstageViewTabItem5)
        Me.BackstageViewControl1.Location = New System.Drawing.Point(0, 0)
        Me.BackstageViewControl1.Name = "BackstageViewControl1"
        Me.BackstageViewControl1.PaintStyle = DevExpress.XtraBars.Ribbon.BackstageViewPaintStyle.Skinned
        Me.BackstageViewControl1.SelectedTab = Me.BackstageViewTabItem1
        Me.BackstageViewControl1.SelectedTabIndex = 1
        Me.BackstageViewControl1.Size = New System.Drawing.Size(1231, 640)
        Me.BackstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013
        Me.BackstageViewControl1.TabIndex = 6
        Me.BackstageViewControl1.Text = "BackstageViewControl1"
        '
        'BackstageViewClientControl1
        '
        Me.BackstageViewClientControl1.Location = New System.Drawing.Point(187, 63)
        Me.BackstageViewClientControl1.Name = "BackstageViewClientControl1"
        Me.BackstageViewClientControl1.Size = New System.Drawing.Size(1043, 576)
        Me.BackstageViewClientControl1.TabIndex = 1
        '
        'BackstageViewClientControl2
        '
        Me.BackstageViewClientControl2.Location = New System.Drawing.Point(187, 63)
        Me.BackstageViewClientControl2.Name = "BackstageViewClientControl2"
        Me.BackstageViewClientControl2.Size = New System.Drawing.Size(1043, 576)
        Me.BackstageViewClientControl2.TabIndex = 2
        '
        'BackstageViewClientControl3
        '
        Me.BackstageViewClientControl3.Location = New System.Drawing.Point(187, 63)
        Me.BackstageViewClientControl3.Name = "BackstageViewClientControl3"
        Me.BackstageViewClientControl3.Size = New System.Drawing.Size(1043, 576)
        Me.BackstageViewClientControl3.TabIndex = 3
        '
        'BackstageViewClientControl4
        '
        Me.BackstageViewClientControl4.Location = New System.Drawing.Point(187, 63)
        Me.BackstageViewClientControl4.Name = "BackstageViewClientControl4"
        Me.BackstageViewClientControl4.Size = New System.Drawing.Size(1043, 576)
        Me.BackstageViewClientControl4.TabIndex = 4
        '
        'BackstageViewClientControl5
        '
        Me.BackstageViewClientControl5.Location = New System.Drawing.Point(187, 63)
        Me.BackstageViewClientControl5.Name = "BackstageViewClientControl5"
        Me.BackstageViewClientControl5.Size = New System.Drawing.Size(1043, 576)
        Me.BackstageViewClientControl5.TabIndex = 5
        '
        'BackstageViewButtonItem1
        '
        Me.BackstageViewButtonItem1.Appearance.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BackstageViewButtonItem1.Appearance.Options.UseFont = True
        Me.BackstageViewButtonItem1.Caption = "Employees"
        Me.BackstageViewButtonItem1.Glyph = CType(resources.GetObject("BackstageViewButtonItem1.Glyph"), System.Drawing.Image)
        Me.BackstageViewButtonItem1.Name = "BackstageViewButtonItem1"
        '
        'BackstageViewTabItem1
        '
        Me.BackstageViewTabItem1.Caption = "Employee Form"
        Me.BackstageViewTabItem1.ContentControl = Me.BackstageViewClientControl1
        Me.BackstageViewTabItem1.Glyph = CType(resources.GetObject("BackstageViewTabItem1.Glyph"), System.Drawing.Image)
        Me.BackstageViewTabItem1.Name = "BackstageViewTabItem1"
        Me.BackstageViewTabItem1.Selected = True
        '
        'BackstageViewTabItem2
        '
        Me.BackstageViewTabItem2.Caption = "Employees Register"
        Me.BackstageViewTabItem2.ContentControl = Me.BackstageViewClientControl2
        Me.BackstageViewTabItem2.Glyph = CType(resources.GetObject("BackstageViewTabItem2.Glyph"), System.Drawing.Image)
        Me.BackstageViewTabItem2.Name = "BackstageViewTabItem2"
        Me.BackstageViewTabItem2.Selected = False
        '
        'BackstageViewItemSeparator1
        '
        Me.BackstageViewItemSeparator1.Name = "BackstageViewItemSeparator1"
        '
        'BackstageViewButtonItem2
        '
        Me.BackstageViewButtonItem2.Appearance.Font = New System.Drawing.Font("Lucida Handwriting", 12.0!, System.Drawing.FontStyle.Bold)
        Me.BackstageViewButtonItem2.Appearance.Options.UseFont = True
        Me.BackstageViewButtonItem2.Caption = "Attendence"
        Me.BackstageViewButtonItem2.Glyph = CType(resources.GetObject("BackstageViewButtonItem2.Glyph"), System.Drawing.Image)
        Me.BackstageViewButtonItem2.Name = "BackstageViewButtonItem2"
        '
        'BackstageViewTabItem3
        '
        Me.BackstageViewTabItem3.Caption = "Attendence Register"
        Me.BackstageViewTabItem3.ContentControl = Me.BackstageViewClientControl3
        Me.BackstageViewTabItem3.Glyph = CType(resources.GetObject("BackstageViewTabItem3.Glyph"), System.Drawing.Image)
        Me.BackstageViewTabItem3.Name = "BackstageViewTabItem3"
        Me.BackstageViewTabItem3.Selected = False
        '
        'BackstageViewTabItem4
        '
        Me.BackstageViewTabItem4.Caption = "Payment Register"
        Me.BackstageViewTabItem4.ContentControl = Me.BackstageViewClientControl4
        Me.BackstageViewTabItem4.Glyph = CType(resources.GetObject("BackstageViewTabItem4.Glyph"), System.Drawing.Image)
        Me.BackstageViewTabItem4.Name = "BackstageViewTabItem4"
        Me.BackstageViewTabItem4.Selected = False
        '
        'BackstageViewTabItem5
        '
        Me.BackstageViewTabItem5.Caption = "Attendence LIVE"
        Me.BackstageViewTabItem5.ContentControl = Me.BackstageViewClientControl5
        Me.BackstageViewTabItem5.Glyph = CType(resources.GetObject("BackstageViewTabItem5.Glyph"), System.Drawing.Image)
        Me.BackstageViewTabItem5.Name = "BackstageViewTabItem5"
        Me.BackstageViewTabItem5.Selected = False
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = CType(resources.GetObject("PictureEdit1.EditValue"), Object)
        Me.PictureEdit1.Location = New System.Drawing.Point(0, -2)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(146, 62)
        Me.PictureEdit1.TabIndex = 7
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Century", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Black
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical
        Me.LabelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.LabelControl1.Location = New System.Drawing.Point(209, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(1014, 33)
        Me.LabelControl1.TabIndex = 8
        Me.LabelControl1.Text = "ATTENDENCE OF PARIS MART DINGA"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1231, 669)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.PictureEdit1)
        Me.Controls.Add(Me.BackstageViewControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BackstageViewControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BackstageViewControl1.ResumeLayout(False)
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents FormAssistant1 As DevExpress.XtraBars.FormAssistant
    Friend WithEvents BackstageViewControl1 As DevExpress.XtraBars.Ribbon.BackstageViewControl
    Friend WithEvents BackstageViewClientControl1 As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Friend WithEvents BackstageViewClientControl2 As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Friend WithEvents BackstageViewClientControl3 As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Friend WithEvents BackstageViewClientControl4 As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Friend WithEvents BackstageViewButtonItem1 As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Friend WithEvents BackstageViewTabItem1 As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Friend WithEvents BackstageViewTabItem2 As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Friend WithEvents BackstageViewItemSeparator1 As DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator
    Friend WithEvents BackstageViewButtonItem2 As DevExpress.XtraBars.Ribbon.BackstageViewButtonItem
    Friend WithEvents BackstageViewTabItem3 As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Friend WithEvents BackstageViewTabItem4 As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BackstageViewClientControl5 As DevExpress.XtraBars.Ribbon.BackstageViewClientControl
    Friend WithEvents BackstageViewTabItem5 As DevExpress.XtraBars.Ribbon.BackstageViewTabItem
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents SkinBarSubItem1 As DevExpress.XtraBars.SkinBarSubItem
End Class
