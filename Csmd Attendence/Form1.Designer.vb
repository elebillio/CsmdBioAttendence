﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.mK = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.p1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'mK
        '
        Me.mK.Location = New System.Drawing.Point(356, 39)
        Me.mK.Name = "mK"
        Me.mK.Size = New System.Drawing.Size(255, 20)
        Me.mK.TabIndex = 0
        Me.mK.Text = "1"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(383, 116)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(125, 28)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'p1
        '
        Me.p1.Location = New System.Drawing.Point(84, 74)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(442, 23)
        Me.p1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 382)
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.mK)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mK As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents p1 As ProgressBar
End Class
