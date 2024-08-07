﻿Imports DevExpress.XtraEditors.Repository

Public Class Class1
    Public Shared EmpID As Integer = 0
    Public Shared EmpName As String = ""
    Public Shared EmpDate As Date

    Public Shared MasterLive As String = ""
    Public Shared Sub DrawVertical(Col As String, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs)
        If Not e.Column Is Nothing Then
            Try
                If e.Column.FieldName = Col Then
                    Dim r As Rectangle = e.Info.CaptionRect
                    e.Info.Caption = ""
                    e.Painter.DrawObject(e.Info)
                    Dim state As System.Drawing.Drawing2D.GraphicsState = e.Graphics.Save()
                    Dim format As StringFormat = e.Appearance.GetTextOptions().GetStringFormat()
                    format.Trimming = StringTrimming.EllipsisCharacter
                    format.FormatFlags = format.FormatFlags Or StringFormatFlags.NoWrap
                    format.FormatFlags = format.FormatFlags Or StringFormatFlags.DirectionVertical Or StringFormatFlags.DirectionRightToLeft
                    'r = Transform(e.Graphics, 90, r)
                    e.Graphics.DrawString(e.Column.Caption, e.Appearance.Font, e.Appearance.GetForeBrush(e.Cache), r, format)
                    e.Graphics.Restore(state)
                    e.Handled = True
                End If
            Catch ex As Exception

                e.Handled = False

            End Try

        Else
            e.Handled = False
        End If
    End Sub

End Class
Public Class cmb_Attendance_Duty_Status
    Public Sub ColumnsAndData(GridLookUpEdit As RepositoryItemLookUpEdit)
        Using db As New CsmdBioDatabase.CsmdBioAttendenceEntities
            Dim dt = (From a In db.Attendance_Duty_Status Order By a.Attendance_Duty_Status_ID Ascending Select New With {.ID = a.Attendance_Duty_Status_ID, .StatusType = a.Attendance_Duty_Status_Type}).ToList()
            If dt.Count() > 0 Then
                GridLookUpEdit.DataSource = dt
                GridLookUpEdit.DisplayMember = "StatusType"
                GridLookUpEdit.ValueMember = "ID"
                GridLookUpEdit.PopulateColumns()
                GridLookUpEdit.Columns("ID").Visible = False
            End If
        End Using
    End Sub
End Class
