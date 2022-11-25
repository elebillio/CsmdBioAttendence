Imports CsmdBioDatabase

Public Class frmFaceTest
    Public axCZKEM1 As New zkemkeeper.CZKEM
    Private bIsConnected As Boolean = False 'the boolean value identifies whether the device is connected
    Private iMachineNumber As Integer
    'Dim lvUserInfo As ListView
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sta_GetAllUserFaceInfo()
    End Sub
    Public Sub sta_GetAllUserFaceInfo()


        'If (GetConnectState() == False) Then
        '            {
        '    lblOutputInfo.Items.Add("*Please connect first!");
        '    Return -1024;
        '}
        If bIsConnected = False Then
            MsgBox("Please connect the device first", MsgBoxStyle.Exclamation, "Error")
            Return
        End If

        Dim sEnrollNumber As String = ""
        Dim sName As String = ""
        Dim sPassword As String = ""
        Dim iPrivilege As Integer = 0
        Dim bEnabled As Boolean = False
        Dim iFaceIndex As Integer = 50 ';//the only possible parameter value
        Dim sTmpData As String = ""
        Dim iLength As Integer = 0
        Dim num As Integer = 0
        Dim Index As Integer = 0
        Dim iFlag As Integer = 0
        'lvUserInfo.Items.Clear()

        axCZKEM1.EnableDevice(iMachineNumber, False)
        axCZKEM1.ReadAllUserID(iMachineNumber) '//read all the user information To the memory
        ''While (axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, out sEnrollNumber, out sName, out sPassword, out iPrivilege, out bEnabled)) //get all the users' information from the memory
        ''    {
        ''        If (axCZKEM1.GetUserFaceStr(iMachineNumber, sEnrollNumber, iFaceIndex, ref sTmpData, ref iLength)) //get the face templates from the memory
        ''        {
        ''            lvUserInfo.Items.Add(sEnrollNumber);

        ''            If (bEnabled == True) Then
        ''                                    {
        ''                lvUserInfo.Items[Index].SubItems.Add("true");
        ''            }
        ''            Else
        ''            {
        ''                lvUserInfo.Items[Index].SubItems.Add("false");
        ''            }

        ''            lvUserInfo.Items[Index].SubItems.Add(sName);
        ''            lvUserInfo.Items[Index].SubItems.Add(sPassword);
        ''            lvUserInfo.Items[Index].SubItems.Add(iPrivilege.ToString());
        ''            lvUserInfo.Items[Index].SubItems.Add(iLength.ToString());
        ''            lvUserInfo.Items[Index].SubItems.Add(sTmpData);

        ''            Index++;
        ''            num++;
        ''        }
        ''        prgSta.Value = num % 100;

        ''    prgSta.Value = 100;
        ''    lblOutputInfo.Items.Add("Download user  face count : " + num.ToString());
        ''    axCZKEM1.EnableDevice(iMachineNumber, True);


        While axCZKEM1.SSR_GetAllUserInfo(iMachineNumber, sEnrollNumber, sName, sPassword, iPrivilege, bEnabled) = True  'get all the users' information from the memory
            'For idwFingerIndex = 0 To 9
            If axCZKEM1.GetUserFaceStr(iMachineNumber, sEnrollNumber, iFaceIndex, sTmpData, iLength) Then 'get the corresponding templates string and length from the memory

                        Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities

                    Dim ddd As Integer = If(CInt(Microsoft.VisualBasic.Right(sEnrollNumber.ToString, 1)) = 0, 10, CInt(Microsoft.VisualBasic.Right(sEnrollNumber.ToString, 1)))
                    Dim fg = (From a In db.Emp_Bio_Device_Users Where a.Emp_ID = 1 And a.Emp_Bio_Device_Users_UserID = CType(sEnrollNumber, Integer?) Select a).FirstOrDefault
                    If fg IsNot Nothing Then
                        With fg
                            .Emp_ID = 1
                            .Attendence_Status_ID = ddd
                            .Emp_Bio_Device_User_Name = sName
                            '.Emp_Bio_Device_User_Face = iFaceIndex
                            .Emp_Bio_Device_User_FacetmpData = sTmpData
                            .Emp_Bio_Device_User_iLength = iLength
                            .Emp_Bio_Device_User_Privilege = iPrivilege
                            .Emp_Bio_Device_User_Password = sPassword
                            .Emp_Bio_Device_User_Enabled = bEnabled
                        End With
                        db.SaveChanges()
                        'Else
                        '    Dim dtNew = New Emp_Bio_Device_Users
                        '    With dtNew
                        '        .Emp_ID = EmpID
                        '        .Attendence_Status_ID = ddd
                        '        .Emp_Bio_Device_Users_UserID = CInt(idwEnrollNumber)
                        '        .Emp_Bio_Device_User_Name = sName
                        '        .Emp_Bio_Device_User_Finger = idwFingerIndex
                        '        .Emp_Bio_Device_User_tmpData = sTmpData
                        '        .Emp_Bio_Device_User_Privilege = iPrivilege
                        '        .Emp_Bio_Device_User_Password = sPassword
                        '        .Emp_Bio_Device_User_Enabled = bEnabled
                        '    End With
                        '    db.Emp_Bio_Device_Users.Add(dtNew)
                        '    db.SaveChanges()
                    End If
                End Using

            End If
            'Next
        End While
        'lvDownload.EndUpdate()
        axCZKEM1.BatchUpdate(iMachineNumber) 'download all the information in the memory
        axCZKEM1.RefreshData(iMachineNumber) 'the data in the device should be refreshed
        axCZKEM1.EnableDevice(iMachineNumber, True)
        Cursor = Cursors.Default
        LoadFromDb(1)

        '    Return 1;
    End Sub
    Public Sub LoadFromDb(EmpID As Integer)
                Using db As CsmdBioAttendenceEntities = New CsmdBioAttendenceEntities
            Dim dt = (From a In db.Attendence_Status Group Join b In db.Emp_Bio_Device_Users.Where(Function(o) CBool(o.Emp_ID = EmpID)) On a.Attendence_Status_ID Equals b.Attendence_Status_ID Into z = Group From b In z.DefaultIfEmpty()
                      Select New With {a.Attendence_Status_Type, a.Attendence_Status_Finger,
                           b.Emp_Bio_Device_Users_UserID,
                           b.Emp_Bio_Device_User_Name,
                           b.Emp_Bio_Device_User_Finger,
                          .FingerData = b.Emp_Bio_Device_User_tmpData,
                          .FaceData = b.Emp_Bio_Device_User_FacetmpData,
                          b.Emp_Bio_Device_User_Privilege, b.Emp_Bio_Device_User_iLength,
                           b.Emp_Bio_Device_User_Enabled, b.Emp_Bio_Device_User_Password,
                          .Fing = If(b.Emp_Bio_Device_User_tmpData Is Nothing Or b.Emp_Bio_Device_User_tmpData = "", "No", "Yes")}).ToList
            If dt.Count > 0 Then
                GridControl1.DataSource = dt
            Else
                GridControl1.DataSource = Nothing
            End If
        End Using
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        If txtIP.Text.ToString = "" Or txtPort.Text.ToString = "" Then
            MsgBox("IP and Port cannot be null", MsgBoxStyle.Exclamation, "Error")
            Return
        End If
        Dim idwErrorCode As Integer
        Cursor = Cursors.WaitCursor
        If btnConnect.Text = "Disconnect" Then
            axCZKEM1.Disconnect()
            'RemoveHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
            'RemoveHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
            'RemoveHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
            'RemoveHandler axCZKEM1.OnAttTransaction, AddressOf AxCZKEM1_OnAttTransaction
            'RemoveHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
            'RemoveHandler axCZKEM1.OnKeyPress, AddressOf AxCZKEM1_OnKeyPress
            '  RemoveHandler axCZKEM1.OnEnrollFinger, AddressOf AxCZKEM1_OnEnrollFinger
            '  RemoveHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
            'RemoveHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
            'RemoveHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
            'RemoveHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
            'RemoveHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
            'RemoveHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
            'RemoveHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum
            bIsConnected = False
            btnConnect.Text = "Connect"
            lblState.Text = "Current State:Disconnected"
            '     Button2.ItemAppearance.Normal.BackColor = Color.Red
            '    Button2.ItemAppearance.Normal.BackColor = Color.Red
            '    SimpleButton5.Enabled = False
            '   SimpleButton1.Enabled = False
            '   GridView1.OptionsBehavior.Editable = False
            Cursor = Cursors.Default
            Return
        End If

        bIsConnected = axCZKEM1.Connect_Net(txtIP.Text.ToString, Convert.ToInt32(txtPort.Text.ToString))
        bIsConnected = True
        If bIsConnected = True Then
            btnConnect.Text = "Disconnect"
            btnConnect.Refresh()
            lblState.Text = "Current State:Connected"
            btnConnect.BackColor = Color.LimeGreen
            lblState.BackColor = Color.LimeGreen
            '   SimpleButton5.Enabled = True
            '   SimpleButton1.Enabled = True
            '   GridView1.OptionsBehavior.Editable = True
            iMachineNumber = 1 'In fact,when you are using the tcp/ip communication,this parameter will be ignored,that is any integer will all right.Here we use 1.
            'axCZKEM1.RegEvent(iMachineNumber, 65535) 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            If axCZKEM1.RegEvent(iMachineNumber, 65535) = True Then 'Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)

                'AddHandler axCZKEM1.OnFinger, AddressOf AxCZKEM1_OnFinger
                'AddHandler axCZKEM1.OnFingerFeature, AddressOf AxCZKEM1_OnFingerFeature
                'AddHandler axCZKEM1.OnVerify, AddressOf AxCZKEM1_OnVerify
                'AddHandler axCZKEM1.OnAttTransaction, AddressOf AxCZKEM1_OnAttTransaction
                'AddHandler axCZKEM1.OnAttTransactionEx, AddressOf AxCZKEM1_OnAttTransactionEx
                'AddHandler axCZKEM1.OnKeyPress, AddressOf AxCZKEM1_OnKeyPress
                '     AddHandler axCZKEM1.OnEnrollFinger, AddressOf AxCZKEM1_OnEnrollFinger
                '     AddHandler axCZKEM1.OnDeleteTemplate, AddressOf AxCZKEM1_OnDeleteTemplate
                'AddHandler axCZKEM1.OnNewUser, AddressOf AxCZKEM1_OnNewUser
                'AddHandler axCZKEM1.OnAlarm, AddressOf AxCZKEM1_OnAlarm
                'AddHandler axCZKEM1.OnDoor, AddressOf AxCZKEM1_OnDoor
                'AddHandler axCZKEM1.OnWriteCard, AddressOf AxCZKEM1_OnWriteCard
                'AddHandler axCZKEM1.OnEmptyCard, AddressOf AxCZKEM1_OnEmptyCard
                'AddHandler axCZKEM1.OnHIDNum, AddressOf AxCZKEM1_OnHIDNum

            End If
        Else
            axCZKEM1.GetLastError(idwErrorCode)
            MsgBox("Unable to connect the device,ErrorCode=" & idwErrorCode, MsgBoxStyle.Exclamation, "Error")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowClickEventArgs) Handles GridView1.RowClick
        PictureEdit1.Image = DbToImg(CType(GridView1.GetFocusedRowCellValue("Emp_Image"), Byte()))
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        LoadFromDb(1)
    End Sub
End Class