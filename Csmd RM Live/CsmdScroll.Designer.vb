<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CsmdScroll
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.M = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'M
        '
        Me.M.AutoSize = True
        Me.M.BackColor = System.Drawing.Color.Blue
        Me.M.Location = New System.Drawing.Point(0, 0)
        Me.M.Name = "M"
        Me.M.Size = New System.Drawing.Size(39, 13)
        Me.M.TabIndex = 0
        Me.M.Text = "Label1"
        Me.M.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'CsmdScroll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Controls.Add(Me.M)
        Me.Name = "CsmdScroll"
        Me.Size = New System.Drawing.Size(527, 77)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents M As Label
    Friend WithEvents Timer1 As Timer
End Class
