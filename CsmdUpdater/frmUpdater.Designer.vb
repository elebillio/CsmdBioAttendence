<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUpdater
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdater))
        Me.SimpleButton3 = New DevExpress.XtraEditors.SimpleButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lbl1 = New DevExpress.XtraEditors.LabelControl()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.aa = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ff = New DevExpress.XtraEditors.LabelControl()
        Me.cc = New DevExpress.XtraEditors.LabelControl()
        Me.bb = New DevExpress.XtraEditors.LabelControl()
        Me.dd = New DevExpress.XtraEditors.LabelControl()
        Me.ee = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.gg = New DevExpress.XtraEditors.LabelControl()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SimpleButton3
        '
        Me.SimpleButton3.Appearance.Font = New System.Drawing.Font("Tahoma", 14.0!)
        Me.SimpleButton3.Appearance.Options.UseFont = True
        Me.SimpleButton3.Image = CType(resources.GetObject("SimpleButton3.Image"), System.Drawing.Image)
        Me.SimpleButton3.Location = New System.Drawing.Point(473, 377)
        Me.SimpleButton3.Name = "SimpleButton3"
        Me.SimpleButton3.Size = New System.Drawing.Size(203, 38)
        Me.SimpleButton3.StyleController = Me.LayoutControl1
        Me.SimpleButton3.TabIndex = 2
        Me.SimpleButton3.Text = "Download Updates"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 377)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(457, 38)
        Me.ProgressBar1.TabIndex = 4
        '
        'lbl1
        '
        Me.lbl1.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lbl1.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Underline)
        Me.lbl1.Location = New System.Drawing.Point(12, 12)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(664, 33)
        Me.lbl1.StyleController = Me.LayoutControl1
        Me.lbl1.TabIndex = 5
        Me.lbl1.Text = "Feature Updates"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'aa
        '
        Me.aa.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.aa.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.aa.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.aa.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.aa.Location = New System.Drawing.Point(12, 49)
        Me.aa.Name = "aa"
        Me.aa.Size = New System.Drawing.Size(664, 22)
        Me.aa.StyleController = Me.LayoutControl1
        Me.aa.TabIndex = 8
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.ProgressBar1)
        Me.LayoutControl1.Controls.Add(Me.SimpleButton3)
        Me.LayoutControl1.Controls.Add(Me.gg)
        Me.LayoutControl1.Controls.Add(Me.ff)
        Me.LayoutControl1.Controls.Add(Me.ee)
        Me.LayoutControl1.Controls.Add(Me.dd)
        Me.LayoutControl1.Controls.Add(Me.aa)
        Me.LayoutControl1.Controls.Add(Me.cc)
        Me.LayoutControl1.Controls.Add(Me.bb)
        Me.LayoutControl1.Controls.Add(Me.lbl1)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(678, 301, 250, 350)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(688, 427)
        Me.LayoutControl1.TabIndex = 9
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.LayoutControlItem9})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(688, 427)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.lbl1
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(0, 37)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(118, 37)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(668, 37)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.aa
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 37)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(44, 26)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(668, 26)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'ff
        '
        Me.ff.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ff.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ff.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ff.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.ff.Location = New System.Drawing.Point(12, 330)
        Me.ff.Name = "ff"
        Me.ff.Size = New System.Drawing.Size(664, 21)
        Me.ff.StyleController = Me.LayoutControl1
        Me.ff.TabIndex = 10
        '
        'cc
        '
        Me.cc.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cc.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.cc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.cc.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.cc.Location = New System.Drawing.Point(12, 101)
        Me.cc.Name = "cc"
        Me.cc.Size = New System.Drawing.Size(664, 22)
        Me.cc.StyleController = Me.LayoutControl1
        Me.cc.TabIndex = 11
        '
        'bb
        '
        Me.bb.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.bb.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.bb.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.bb.Location = New System.Drawing.Point(12, 75)
        Me.bb.Name = "bb"
        Me.bb.Size = New System.Drawing.Size(664, 22)
        Me.bb.StyleController = Me.LayoutControl1
        Me.bb.TabIndex = 12
        '
        'dd
        '
        Me.dd.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dd.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.dd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.dd.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.dd.Location = New System.Drawing.Point(12, 127)
        Me.dd.Name = "dd"
        Me.dd.Size = New System.Drawing.Size(664, 21)
        Me.dd.StyleController = Me.LayoutControl1
        Me.dd.TabIndex = 13
        '
        'ee
        '
        Me.ee.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ee.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.ee.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.ee.Location = New System.Drawing.Point(12, 152)
        Me.ee.Name = "ee"
        Me.ee.Size = New System.Drawing.Size(664, 174)
        Me.ee.StyleController = Me.LayoutControl1
        Me.ee.TabIndex = 14
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.bb
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 63)
        Me.LayoutControlItem3.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(44, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(668, 26)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.cc
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 89)
        Me.LayoutControlItem4.MaxSize = New System.Drawing.Size(0, 26)
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(44, 26)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(668, 26)
        Me.LayoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.dd
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 115)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(44, 25)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(668, 25)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.ee
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 140)
        Me.LayoutControlItem6.MinSize = New System.Drawing.Size(44, 20)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(668, 178)
        Me.LayoutControlItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.ff
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 318)
        Me.LayoutControlItem7.MaxSize = New System.Drawing.Size(0, 25)
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(44, 25)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(668, 25)
        Me.LayoutControlItem7.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'gg
        '
        Me.gg.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.gg.Appearance.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.gg.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.gg.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
        Me.gg.Location = New System.Drawing.Point(12, 355)
        Me.gg.Name = "gg"
        Me.gg.Size = New System.Drawing.Size(664, 18)
        Me.gg.StyleController = Me.LayoutControl1
        Me.gg.TabIndex = 11
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.gg
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 343)
        Me.LayoutControlItem8.MaxSize = New System.Drawing.Size(0, 22)
        Me.LayoutControlItem8.MinSize = New System.Drawing.Size(44, 22)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(668, 22)
        Me.LayoutControlItem8.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.SimpleButton3
        Me.LayoutControlItem10.Location = New System.Drawing.Point(461, 365)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(207, 42)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.ProgressBar1
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 365)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(461, 42)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'frmUpdater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 427)
        Me.Controls.Add(Me.LayoutControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdater"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Csmd Attendance Updater"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SimpleButton3 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents lbl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Timer1 As Timer
    Friend WithEvents aa As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents ff As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ee As DevExpress.XtraEditors.LabelControl
    Friend WithEvents dd As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cc As DevExpress.XtraEditors.LabelControl
    Friend WithEvents bb As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents gg As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
End Class
