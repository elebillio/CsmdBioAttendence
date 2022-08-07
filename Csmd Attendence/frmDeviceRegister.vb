Imports System.Drawing.Drawing2D
Imports CsmdBioDatabase
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DevExpress.XtraGrid.Views.BandedGrid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmDeviceRegister
    Dim dataT As New DataTable
    Dim Pic As RepositoryItemPictureEdit = New RepositoryItemPictureEdit
    Dim TempGridCheckMarksSelection As New GridCheckMarksSelectionxx
    Private Sub frmDeviceRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(AdvBandedGridView1)
        TempGridCheckMarksSelection.View.OptionsSelection.InvertSelection = True
        LoadGridCol()
    End Sub
    Private Sub LoadGridCol()
        Using db As New CsmdBioAttendenceEntities


            dataT.Rows.Clear()
            dataT.Columns.Clear()
            dataT.Clear()
            'DataT.Clear()

            AdvBandedGridView1.BeginUpdate()
            AdvBandedGridView1.Columns.Clear()
            AdvBandedGridView1.Bands.Clear()
            GridControl1.DataSource = Nothing
            'band = AdvBandedGridView1.Bands.AddBand("Students Information")
            'band.AppearanceHeader.Font = New Font("", 14, FontStyle.Bold)
            'band.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center



            Dim childX4 As GridBand = AdvBandedGridView1.Bands.AddBand("Selection")
            childX4.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            childX4.AutoFillDown = True
            Dim column1 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("ID")
            column1.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            column1.Visible = False
            column1.OwnerBand = childX4
            column1.AutoFillDown = True
            column1.OptionsColumn.AllowEdit = False
            AdvBandedGridView1.SetColumnPosition(column1, 0, 0)
            childX4.Columns.Add(column1)
            dataT.Columns.Add("ID", GetType(Integer))

            'column1.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            Dim colun1 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("RegNo")
            colun1.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            colun1.Visible = True
            colun1.OwnerBand = childX4
            colun1.AutoFillDown = True
            colun1.OptionsColumn.AllowEdit = False
            colun1.Width = 65
            column1.OptionsColumn.FixedWidth = True
            AdvBandedGridView1.SetColumnPosition(colun1, 1, 0)
            childX4.Columns.Add(colun1)
            dataT.Columns.Add("RegNo", GetType(String))


            Dim Mband As GridBand = AdvBandedGridView1.Bands.AddBand("Fingersss")
            Mband.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            Dim childX1 As GridBand = Mband.Children.AddBand("#")
            childX1.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)

            Dim column2 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Emp_Image")
            column2.Caption = "Image"
            column2.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            column2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            column2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
            column2.Visible = True
            column2.OwnerBand = childX1
            column2.AutoFillDown = True
            column2.Width = 42
            column2.AppearanceCell.BackColor = Color.ForestGreen
            column2.AppearanceCell.BackColor2 = Color.DarkSeaGreen
            Pic.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
            column2.ColumnEdit = Pic
            'AdvBandedGridView1.SetColumnPosition(column2, 0, 0)
            childX1.Columns.Add(column2)
            dataT.Columns.Add("Emp_Image", GetType(Image))

            Dim childX As GridBand = Mband.Children.AddBand("Employees")
            childX.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            Dim column3 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Emp_Name")
            column3.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            column3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            column3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            column3.Visible = True
            column3.AutoFillDown = True
            column3.Caption = "Name"
            column3.OptionsColumn.AllowEdit = False
            column3.Width = 170
            'column3.SortOrder = ColumnSortOrder.Ascending
            childX.Columns.Add(column3)
            dataT.Columns.Add("Emp_Name", GetType(String))
            AdvBandedGridView1.SetColumnPosition(column3, 0, 0)

            Dim column4 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Emp_Father")
            column4.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            column4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            column4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            column4.Visible = True
            column4.AutoFillDown = True
            column4.Caption = "Father"
            column4.OptionsColumn.AllowEdit = False
            column4.Width = 170
            childX.Columns.Add(column4)
            dataT.Columns.Add("Emp_Father", GetType(String))
            AdvBandedGridView1.SetColumnPosition(column4, 1, 0)

            'Dim column5 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Section")
            'column5.Visible = True
            'column5.AutoFillDown = True
            'column5.Caption = "Section"
            'childX.Columns.Add(column5)
            'AdvBandedGridView1.SetColumnPosition(column5, 1, 1)
            'DataT.Columns.Add("Section", GetType(String))

            'Dim Eitzaz As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Emp_Address")
            'Eitzaz.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
            'Eitzaz.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
            'Eitzaz.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            'Eitzaz.Visible = True
            'Eitzaz.AutoFillDown = True
            'Eitzaz.Caption = "Residence"
            'Eitzaz.OptionsColumn.AllowEdit = False
            'Eitzaz.Width = 170
            'childX.Columns.Add(Eitzaz)
            'AdvBandedGridView1.SetColumnPosition(Eitzaz, 2, 0)
            'dataT.Columns.Add("Emp_Address", GetType(String))

            'band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            'band.View.OptionsBehavior.Editable = False




            'Dim band2 As GridBand = Mband.Children.AddBand("Result of Subjects")
            'band2.AppearanceHeader.Font = New Font("", 14, FontStyle.Bold)
            'band2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            ' Dim ExamTy As Integer = LookExamTerms.EditValue
            Dim dt = (From a In db.Attendence_Status Select a).ToList
            Dim TotX As New Integer

            If dt.Count > 0 Then

                Dim k As Integer = 0
                For Each dts In dt

                    Dim childX24 As GridBand = AdvBandedGridView1.Bands.AddBand(dts.Attendence_Status_Type)
                    childX24.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    childX24.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
                    Dim childX2 As GridBand = childX24.Children.AddBand(dts.Attendence_Status_Finger)
                    childX2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    childX2.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)

                    'Dim colum4 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Attendence_Status_Type" & dts.Attendence_Status_Dep)
                    'colum4.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
                    'colum4.Visible = True
                    'colum4.AutoFillDown = True
                    'colum4.Caption = "T"
                    'colum4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    'colum4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    'colum4.AppearanceCell.BackColor = Color.LightBlue
                    'colum4.AppearanceCell.Font = New Font("", 12, FontStyle.Regular)
                    'childX2.Columns.Add(colum4)
                    'dataT.Columns.Add("Attendence_Status_Type" & dts.Attendence_Status_Dep, GetType(String))

                    'Dim colum444 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Attendence_Status_Finger" & dts.Attendence_Status_Dep)
                    'colum444.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
                    'colum444.Visible = True
                    'colum444.AutoFillDown = True
                    'colum444.Caption = "F"
                    'colum444.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    'colum444.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    'colum444.AppearanceCell.BackColor = Color.LightBlue
                    'colum444.AppearanceCell.Font = New Font("", 12, FontStyle.Regular)
                    'childX2.Columns.Add(colum444)
                    'AdvBandedGridView1.SetColumnPosition(colum444, 0, 0)
                    'dataT.Columns.Add("Attendence_Status_Finger" & dts.Attendence_Status_Dep, GetType(String))

                    Dim colum44 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Fing" & dts.Attendence_Status_Dep)
                    colum44.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
                    colum44.Visible = True
                    colum44.AutoFillDown = True
                    colum44.Caption = "F"
                    colum44.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    colum44.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    'colum44.AppearanceCell.BackColor = Color.LightBlue
                    colum44.AppearanceCell.Font = New Font("", 12, FontStyle.Regular)
                    childX2.Columns.Add(colum44)
                    AdvBandedGridView1.SetColumnPosition(colum44, 0, 0)
                    dataT.Columns.Add("Fing" & dts.Attendence_Status_Dep, GetType(String))

                    Dim colum4444 As BandedGridColumn = AdvBandedGridView1.Columns.AddField("Emp_Bio_Device_User_Password" & dts.Attendence_Status_Dep)
                    colum4444.AppearanceHeader.Font = New Font("", 10, FontStyle.Bold)
                    colum4444.Visible = True
                    colum4444.AutoFillDown = True
                    colum4444.Caption = "P"
                    colum4444.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    colum4444.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    ' colum4444.AppearanceCell.BackColor = Color.LightBlue
                    colum4444.AppearanceCell.Font = New Font("", 12, FontStyle.Regular)
                    childX2.Columns.Add(colum4444)
                    AdvBandedGridView1.SetColumnPosition(colum4444, 0, 1)
                    dataT.Columns.Add("Emp_Bio_Device_User_Password" & dts.Attendence_Status_Dep, GetType(String))


                Next
            End If
            AdvBandedGridView1.BandPanelRowHeight = 40
            AdvBandedGridView1.OptionsBehavior.Editable = False
            AdvBandedGridView1.RowSeparatorHeight = 10
            AdvBandedGridView1.OptionsView.ColumnAutoWidth = True
            AdvBandedGridView1.EndUpdate()


            LoadData(True)
            TempGridCheckMarksSelection = New GridCheckMarksSelectionxx(AdvBandedGridView1)

        End Using
    End Sub
    Private Sub LoadData()
        Using db As New CsmdBioAttendenceEntities
            Dim dtRow As DataRow
            dataT.Rows.Clear()
            Dim dt = (From a In db.Employees Select a.Emp_ID, a.Emp_Reg, a.Emp_Name, a.Emp_Father, a.Emp_Image, a.Emp_Address).ToList
            If dt.Count > 0 Then
                For Each dts In dt
                    dtRow = dataT.NewRow
                    dtRow.Item("ID") = dts.Emp_ID
                    dtRow.Item("RegNo") = dts.Emp_Reg
                    Try
                        dtRow.Item("Emp_Image") = DbToImg(dts.Emp_Image)
                    Catch ex As Exception

                    End Try
                    dtRow.Item("Emp_Name") = dts.Emp_Name
                    dtRow.Item("Emp_Father") = dts.Emp_Father
                    'dtRow.Item("Emp_Address") = dts.Emp_Address

                    Dim dv = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = dts.Emp_ID
                              Select New With {a.Emp_Bio_Device_Users_UserID,
                                  a.Attendence_Status.Attendence_Status_Finger,
                                  a.Attendence_Status.Attendence_Status_Type,
                                  a.Attendence_Status.Attendence_Status_Dep,
                                  a.Emp_Bio_Device_User_Name,
                                  a.Emp_Bio_Device_User_Password,
                                  a.Emp_Bio_Device_User_Privilege,
                                  .Fing = If(a.Emp_Bio_Device_User_tmpData Is Nothing Or a.Emp_Bio_Device_User_tmpData = "", "No", "Yes"), a.Emp_Bio_Device_User_tmpData}).ToList
                    If dv.Count > 0 Then
                        For Each dvs In dv
                            'dtRow.Item("Attendence_Status_Finger" & dvs.Attendence_Status_Dep) = dvs.Attendence_Status_Finger
                            '  dtRow.Item("Attendence_Status_Type" & dvs.Attendence_Status_Dep) = dvs.Attendence_Status_Type
                            dtRow.Item("Fing" & dvs.Attendence_Status_Dep) = dvs.Fing
                            dtRow.Item("Emp_Bio_Device_User_Password" & dvs.Attendence_Status_Dep) = dvs.Emp_Bio_Device_User_Password
                        Next
                    End If
                    dataT.Rows.Add(dtRow)
                Next

            End If
            GridControl1.DataSource = dataT
        End Using
    End Sub
    Private Sub LoadData(Status As Boolean)
        Using db As New CsmdBioAttendenceEntities
            Dim dtRow As DataRow
            dataT.Rows.Clear()
            Dim dt = (From a In db.Employees Where a.Emp_Status = Status Select a.Emp_ID, a.Emp_Reg, a.Emp_Name, a.Emp_Father, a.Emp_Image, a.Emp_Address).ToList
            If dt.Count > 0 Then
                For Each dts In dt
                    dtRow = dataT.NewRow
                    dtRow.Item("ID") = dts.Emp_ID
                    dtRow.Item("RegNo") = dts.Emp_Reg
                    Try
                        dtRow.Item("Emp_Image") = DbToImg(dts.Emp_Image)
                    Catch ex As Exception

                    End Try
                    dtRow.Item("Emp_Name") = dts.Emp_Name
                    dtRow.Item("Emp_Father") = dts.Emp_Father
                    'dtRow.Item("Emp_Address") = dts.Emp_Address

                    Dim dv = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = dts.Emp_ID
                              Select New With {a.Emp_Bio_Device_Users_UserID,
                                  a.Attendence_Status.Attendence_Status_Finger,
                                  a.Attendence_Status.Attendence_Status_Type,
                                  a.Attendence_Status.Attendence_Status_Dep,
                                  a.Emp_Bio_Device_User_Name,
                                  a.Emp_Bio_Device_User_Password,
                                  a.Emp_Bio_Device_User_Privilege,
                                  .Fing = If(a.Emp_Bio_Device_User_tmpData Is Nothing Or a.Emp_Bio_Device_User_tmpData = "", "No", "Yes"), a.Emp_Bio_Device_User_tmpData}).ToList
                    If dv.Count > 0 Then
                        For Each dvs In dv
                            'dtRow.Item("Attendence_Status_Finger" & dvs.Attendence_Status_Dep) = dvs.Attendence_Status_Finger
                            '  dtRow.Item("Attendence_Status_Type" & dvs.Attendence_Status_Dep) = dvs.Attendence_Status_Type
                            dtRow.Item("Fing" & dvs.Attendence_Status_Dep) = dvs.Fing
                            dtRow.Item("Emp_Bio_Device_User_Password" & dvs.Attendence_Status_Dep) = dvs.Emp_Bio_Device_User_Password
                        Next
                    End If
                    dataT.Rows.Add(dtRow)
                Next

            End If
            GridControl1.DataSource = dataT
        End Using
    End Sub
    Private Sub GridControl1_Paint(sender As Object, e As PaintEventArgs) Handles GridControl1.Paint
        Dim grid As GridControl = TryCast(sender, GridControl)
        Dim advBandedGridView As AdvBandedGridView = TryCast(grid.MainView, AdvBandedGridView)
        Try
            If advBandedGridView Is Nothing Then
                Return
            End If
            Dim viewInfo As AdvBandedGridViewInfo = TryCast(advBandedGridView.GetViewInfo(), AdvBandedGridViewInfo)
            For Each band As GridBand In advBandedGridView.Bands
                If band Is advBandedGridView.Bands.LastVisibleBand Then
                    Continue For
                End If
                Dim bandInfo As DevExpress.XtraGrid.Drawing.GridBandInfoArgs = viewInfo.BandsInfo(band)
                If bandInfo Is Nothing Then
                    Exit Sub
                End If
                Dim redPen As New Pen(Color.Red, 5)
                Dim greenPen As New Pen(Color.Blue, 5)
                greenPen.Alignment = PenAlignment.Center
                Dim startPoint As New Point(bandInfo.Bounds.Right - 1, bandInfo.Bounds.Y)
                'Dim endPoint As New Point(bandInfo.Bounds.Right - 1, bandInfo.Bounds.Y + viewInfo.ColumnRowHeight + viewInfo.BandRowHeight)
                Dim endPoint As New Point(bandInfo.Bounds.Right - 1, bandInfo.Bounds.Y + viewInfo.ViewRects.BandPanel.Height + viewInfo.ViewRects.ColumnPanel.Height) ' + viewInfo.ColumnRowHeight + viewInfo.BandRowHeight
                'e.Graphics.DrawLine(Pens.DarkGray, startPoint, endPoint)
                e.Graphics.DrawLine(redPen, startPoint, endPoint)
                For Each rowInfo As Views.Grid.ViewInfo.GridRowInfo In viewInfo.RowsInfo
                    If rowInfo.IsGroupRow Then 'skip group rows  
                        Continue For
                    End If
                    Dim startPoint1 As New Point(bandInfo.Bounds.Right - 1, rowInfo.Bounds.Top)
                    Dim endPoint1 As New Point(bandInfo.Bounds.Right - 1, rowInfo.Bounds.Bottom)
                    'e.Graphics.DrawLine(Pens.DarkGray, startPoint1, endPoint1)
                    e.Graphics.DrawLine(greenPen, startPoint1, endPoint1)
                Next rowInfo
            Next band
        Catch ex As Exception
            MsgBox("Error!")
        End Try
    End Sub

    Private Sub AdvBandedGridView1_RowCellStyle(sender As Object, e As RowCellStyleEventArgs) Handles AdvBandedGridView1.RowCellStyle
        Using db As New CsmdBioAttendenceEntities
            'Dim dvf = (From a In db.Attendence_Status
            '           Select a).ToList
            'If dvf.Count > 0 Then
            '    For Each dvs In dvf
            If e.Column.FieldName = "Fing2" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing3" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing4" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing5" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing6" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing7" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing8" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing9" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing10" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If
            If e.Column.FieldName = "Fing11" Then
                If e.CellValue.ToString = "Yes" Then
                    e.Appearance.BackColor = Color.Lime
                Else
                    e.Appearance.BackColor = Color.Red
                End If
            End If

            If e.Column.FieldName = "Emp_Bio_Device_User_Password2" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password3" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password4" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password5" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password6" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password7" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password8" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password9" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password10" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            If e.Column.FieldName = "Emp_Bio_Device_User_Password11" Then
                If Not IsDBNull(e.CellValue) AndAlso Not e.CellValue.ToString = "" Then
                    e.Appearance.BackColor = Color.Green
                Else
                    e.Appearance.BackColor = Color.DarkGray
                End If
            End If
            '    Next
            'End If
        End Using
    End Sub

    Private Sub AdvBandedGridView1_DoubleClick(sender As Object, e As EventArgs) Handles AdvBandedGridView1.DoubleClick
        intMultiFee = AdvBandedGridView1.GetFocusedRowCellValue("ID")
        frmLoadAction = frmEditAction
        Dim frm As New frmEmployeesAdds
        frm.ShowDialog()

    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        LoadData(True)
        BarButtonItem1.Down = True
        BarButtonItem2.Down = False
        BarButtonItem3.Down = False
    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        LoadData(False)
        BarButtonItem1.Down = False
        BarButtonItem2.Down = True
        BarButtonItem3.Down = False
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        LoadData()
        BarButtonItem1.Down = False
        BarButtonItem2.Down = False
        BarButtonItem3.Down = True
    End Sub
End Class