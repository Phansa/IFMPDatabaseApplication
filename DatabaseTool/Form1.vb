Imports System.Text.RegularExpressions
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Net.Mail
Imports System.Reflection
Imports System.Text
Imports System.IO
Imports EAGetMail 'imports EAGetMail namespace

'Space Label 4 units before the textbox horizontally

'*********************Method for adding a new column*********************
'Add column to dbo.membership
'Add text box/label for the new field
'Add a new variable to store the new field
'Update add member form - add new textbox, add new variable and update sql command
'Update user view commands
'Update ID Text Changed Sub
'Make textbox changed sub and store text into the variable
'Edit sql command located at UpdateMember_Click 
'Update RSVPNoCheckInToolStripMenuItem_Click 
'Update LoadSheet2ToolStripMenuItem_Click
'Edit tab indexes and resize properties

Public Class Form1
    Private Function isValid(ByVal str As String) As Boolean
        Dim pattern As String = "^[a-zA-Z\s\-]+$"
        Dim reg As New Regex(pattern)
        Return reg.IsMatch(str)
    End Function
    Public Property con_string As String
    Public Property admin_status As Boolean
    Public Property id_public As String
    Private first_name As String
    Private last_name As String
    Private phone_number As String
    Private email_address As String
    Private id_number As Int64
    Private event_name As String
    Private note As String
    Private member_status As String
    Private payment_method As String
    Public check_in_status As String
    Public RSVP As String
    Public cellphone_number As String
    Public party_number As String
    Public family_size As String
    Public children_number As String
    Public adult_number As String
    Public channel As String
    Public line1 As String
    Public line2 As String
    Public city As String
    Public state As String
    Public zip As String
    Public country As String
    Public spouse_name As String
    Public check_in As Int64
    Public adult_rsvp As Int64
    Public children_rsvp As Int64
    'Changes the User View Table
    Public child_1 As String
    Public child_2 As String
    Public user_view As String = "Select [Id], [First Name], [Last Name],  [Phone Number],  [Membership Status]," &
            "[Party Size], [Email Address], [Picnic RSVP], [Check In Status], [Adult Check In], [Children Check In], [Family Size]," &
            "[Children], [Adults], [Event Signed Up At], [Payment Method], [Channel],[Spouse Name], [Cellphone Number], " &
"[Note], [Date Signed Up], [Unpaid Dues] from [Membership]"
    Public user_view2 As String = "Select [Id], [First Name], [Last Name],  [Phone Number],  [Membership Status]," &
            "[Party Size], [Email Address], [Picnic RSVP], [Check In Status], [Adult Check In], [Children Check In], [Family Size]," &
            "[Children], [Adults], [Event Signed Up At], [Payment Method], [Channel],[Spouse Name], [Cellphone Number], " &
"[Note], [Date Signed Up] from [Membership] where [Membership Status]='Active'"
    Public date_signed_up As DateTime
    Public viewall As Boolean
    Public unpaid_dues As String
    Public string1 As String = "Events"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''Only for use in debugging
        DebugToolStripMenuItem.Visible = False
        ViewNonMemberToolStripMenuItem.Visible = False
        PayMembershipDifferenceToolStripMenuItem.Visible = False
        RemoveMember.Visible = False
        EventViewToolStripMenuItem.Visible = False
        UpdateToolStripMenuItem1.Visible = True
        LoadDefaultToolStripMenuItem.Visible = False
        LoadExcellFileToolStripMenuItem.Visible = False
        MembershipDifferenceToolStripMenuItem.Visible = False
        InformationToolStripMenuItem.Visible = False
        PayMembershipDifferenceToolStripMenuItem.Visible = False
        ConfirmationToolStripMenuItem.Visible = False
        'RenewMembershipToolStripMenuItem.Visible = False
        MembershipToolStripMenuItem.Visible = False
        If My.Settings.Resize = "1080 x 720" Then
            Me.Width = 1080
            Me.Height = 720
            If admin_status = False Then
                MenuToolStripMenuItem.Visible = True
                LoadSheet2ToolStripMenuItem.Visible = False
                ViewNonMemberToolStripMenuItem.Visible = False
                'AddMemberToolStripMenuItem.Visible = False
                ResetToolStripMenuItem.Visible = False
                AdminSaveToolStripMenuItem.Visible = False
                SendMailToolStripMenuItem.Visible = False
                'RemoveMember.Visible = False
                Test.Visible = False
                Transfer.Visible = False
                'ViewDatabase.Location = New Point(75, 0)
                'Reset.Location = New Point(75, 0)
                'UpdateMember.Location = New Point(5, 0)
            Else
                'Reset.Location = New Point(144, 0)
                'LoadSheet2ToolStripMenuItem1.Visible = False
                'LoadRSVPToolStripMenuItem.Visible = False
            End If
            '* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
            '* * * * * * * * * * * * * * START GLOBAL RESIZING   * * * * * * * * * * * * * * * * * * * * *
            '* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
            Dim top_size As New Size(34, 22)
            Dim bottom_size As New Size(240, 34)
            Dim font_8 As New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
            Dim font_10 As New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Dim font_11 As New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
            Dim font_12 As New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
            'Phone Number Label
            Phone_Label.Location = New Point(246, 240)
            'Phone Number Box
            PhoneNumber.Location = New Point(250, 264)
            'Cell Phone Label
            cell_number.Location = New Point(246, 305)
            'Cell Phone Box
            cell_phone.Location = New Point(250, 329)
            'Work Number Label
            WorkPhoneLabel.Location = New Point(246, 367)
            'Work Number Box
            WorkPhone.Location = New Point(250, 391)
            'Event Label
            Event_Label.Location = New Point(238, 450)
            'Event Box
            EventBox.Location = New Point(300, 450)
            'Channel Label
            Channel_Label.Location = New Point(216, 491)
            'Channel Box
            ChannelBox.Location = New Point(300, 491)
            'Note Box
            NoteBox.Size = New Size(190, 98)
            'Adult Check In Label
            Adult_CheckLabel.Location = New Point(246, 43)
            'Adult Check In Textbox
            AdultCheck.Location = New Point(250, 71)
            'Children Check In Label
            Children_CheckLabel.Location = New Point(315, 43)
            'Children Check In Box
            ChildrenCheck.Location = New Point(319, 71)
            'Party Check In Label
            Party_Label.Location = New Point(392, 43)
            'Party Box
            PartyText.Location = New Point(396, 71)
            'Membership Label
            Status.Location = New Point(246, 116)
            'Membership Box
            MemberStatus.Location = New Point(250, 140)
            'Adults Label
            Adults_Label.Location = New Point(246, 178)
            'Adults Box
            Adult.Location = New Point(250, 202)
            'Children Label
            Children_Label.Location = New Point(315, 178)
            'Children Box
            Children.Location = New Point(319, 202)
            'Family Label
            Family_Label.Location = New Point(392, 178)
            'Family Box
            FamilySize.Location = New Point(396, 202)
            'First Name
            FirstName.Size = bottom_size
            'Last Name
            LastName.Size = bottom_size
            'Spouse Name
            SpouseName.Size = bottom_size
            'Email Address
            EmailAddress.Size = bottom_size
            'Total RSVP Label
            TotalRSVP.Location = New Point(905, 2)
            'Total RSVP Textbox
            TextBox2.Location = New Point(1005, 0)
            TextBox2.Size = top_size
            'IFMP Members Label
            Label15.Location = New Point(732, 3)
            'Total Children Textbox
            Total_Children.Location = New Point(696, 0)
            Total_Children.Size = top_size
            'Total Children Label
            TotalChildren.Location = New Point(587, 2)
            'Total Adult Label
            Label22.Location = New Point(460, 2)
            'Total Adult Textbox
            Total_Adult.Location = New Point(547, 0)
            Total_Adult.Size = top_size
            'Check In Label
            Label21.Location = New Point(300, 2)
            'Check In Textbox
            Checkin_number.Location = New Point(420, 0)
            Checkin_number.Size = top_size
            'Address Label
            AddressLabel.Location = New Point(5, 544)
            'Line 1 Label
            Line1Label.Location = New Point(5, 575)
            'Line 1 Textbox
            Line1Text.Location = New Point(91, 575)
            Line1Text.Size = bottom_size
            'Line 2 Label
            Line2Label.Location = New Point(5, 609)
            'Line 2 Textbox
            Line2Text.Location = New Point(91, 609)
            Line2Text.Size = bottom_size
            'City Label
            CityLabel.Location = New Point(5, 638)
            'City Textbox
            CityText.Location = New Point(91, 638)
            CityText.Size = bottom_size
            'State Label
            StateLabel.Location = New Point(351, 575)
            'State Textbox
            StateText.Location = New Point(425, 575)
            StateText.Size = bottom_size
            'Zip Label
            ZipLabel.Location = New Point(351, 609)
            ZipLabel.Size = bottom_size
            'Zip Textbox
            ZipText.Location = New Point(425, 609)
            ZipText.Size = bottom_size
            'Country Label
            CountryLabel.Location = New Point(351, 638)
            CountryLabel.Size = bottom_size
            'Country Textbox
            CountryText.Location = New Point(425, 638)
            CountryText.Size = bottom_size
            'Datagridview1
            DataGridView1.Location = New Point(470, 39)
            DataGridView1.Size = New Size(550, 530)
            'Unpaid Dues Label
            DuesLabel.Location = New Point(690, 575)
            'Unpaid Dues Box
            DuesBox.Location = New Point(740, 575)
            DuesBox.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
            DuesLabel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
            FamilySize.TabIndex = 22
            PhoneNumber.TabIndex = 23
            cell_phone.TabIndex = 24
            WorkPhone.TabIndex = 25
            EventBox.TabIndex = 26
            ChannelBox.TabIndex = 27
            DuesBox.TabIndex = 28
            '* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
            '* * * * * * * * * * * * * * END GLOBAL RESIZING * * * * * * * * * * * * * * * * * * * * * * 
            '* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
            Transfer.Visible = False
            Test.Visible = False
            Test2.Visible = False
            Button1.Visible = False
            ViewDatabase_Click(sender, e)
        Else
            If admin_status = False Then
                MenuToolStripMenuItem.Visible = True
                LoadExcellFileToolStripMenuItem.Visible = False
                LoadSheet2ToolStripMenuItem.Visible = False
                ViewNonMemberToolStripMenuItem.Visible = False
                'AddMemberToolStripMenuItem.Visible = False
                AdminSaveToolStripMenuItem.Visible = False
                SendMailToolStripMenuItem.Visible = False
                ResetToolStripMenuItem.Visible = False
                'Test.Visible = False
                Transfer.Visible = False
                AddEventToolStripMenuItem.Visible = False
                AddChannelToolStripMenuItem.Visible = False
                AddMethodToolStripMenuItem.Visible = False
            Else
                LoadSheet2ToolStripMenuItem1.Visible = False
                LoadRSVPToolStripMenuItem.Visible = False
            End If
            Transfer.Visible = False
            Test.Visible = False
            Test2.Visible = False
            Button1.Visible = False
            ViewDatabase_Click(sender, e)
        End If
        ' Update check In
        'Dim cmd As New SqlCommand()
        'Dim con As New SqlConnection()
        'con.ConnectionString = con_string
        'con.Open()
        'cmd.Connection = con
        'Dim ds As New DataSet()
        'check_in = 0
        'adult_rsvp = 0
        'children_rsvp = 0
        'cmd.CommandText = "select [Adult Check In], [Children Check In] from [Membership] where [Check In Status] = @CheckIn"
        'cmd.Parameters.AddWithValue("@CheckIn", "Yes")
        'Dim sqlquery As New SqlDataAdapter(cmd)
        'sqlquery.Fill(ds, "Membership_Table")
        'con.Close()
        'For i = 0 To ds.Tables(0).Rows.Count - 1
        '    'check_in += ds.Tables(0).Rows(i).Item(0)
        '    If Not ds.Tables(0).Rows(i).Item(0) Is DBNull.Value Then
        '        adult_rsvp += Convert.ToInt64(ds.Tables(0).Rows(i).Item(0))
        '    Else
        '        adult_rsvp += 0
        '    End If
        '    If Not ds.Tables(0).Rows(i).Item(1) Is DBNull.Value Then
        '        children_rsvp += Convert.ToInt64(ds.Tables(0).Rows(i).Item(1))
        '    Else
        '        children_rsvp += 0
        '    End If
        'Next
        'check_in = adult_rsvp + children_rsvp
        'Checkin_number.Text = check_in.ToString()
        'Total_Adult.Text = adult_rsvp.ToString()
        'Total_Children.Text = children_rsvp.ToString()
        'Dim cmd2 As New SqlCommand()
        'Dim con2 As New SqlConnection()
        'Dim total_rsvp As Int64
        Recalculate_Boxes(sender, e)
        Recalculate_RSVP(sender, e)
        'con2.ConnectionString = con_string
        'con2.Open()
        'cmd2.Connection = con2
        'Dim ds2 As New DataSet()
        'cmd2.CommandText = "select [Party Size] from [Membership] where [Picnic RSVP] = @RSVP"
        'cmd2.Parameters.AddWithValue("@RSVP", "Yes")
        'Dim sqlquery2 As New SqlDataAdapter(cmd)
        'sqlquery2.Fill(ds2, "Membership_Table")
        'con2.Close()
        'For i = 0 To ds2.Tables(0).Rows.Count - 1
        '    If Not ds2.Tables(0).Rows(i).Item(0) Is DBNull.Value Then
        '        total_rsvp += Convert.ToInt64(ds.Tables(0).Rows(i).Item(0))
        '    Else
        '        total_rsvp += 0
        '    End If
        'Next
        'TextBox2.Text = total_rsvp.ToString()
        'TODO: This line of code loads data into the 'DataSet2.Events' table. You can move, or remove it, as needed.
        InitializeEvents()
        InitializeChannel()
        InitializePaymentMethod()
        If My.Settings.TableStyle = "None" Then
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        End If
        If My.Settings.TableStyle = "All" Then
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
        If Not id_public = "" Then
            IDNumber.Text = id_public
        End If
        SetDefaultEvent()
        SetDefaultChannel()
        SetDefaultPayment()
    End Sub

    ''' <summary>
    ''' Fills the Event combo box based of the information stored in the events table.
    ''' </summary>
    Private Sub InitializeEvents()
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select * from Events"
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        sqlquery.Fill(ds)
        EventBox.ValueMember = "Events"
        EventBox.DisplayMember = "Events"
        EventBox.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    ''' <summary>
    ''' Fills the Channel combo box based of the information stored in the events table.
    ''' </summary>
    Private Sub InitializeChannel()
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select * from Channels"
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        sqlquery.Fill(ds)
        ChannelBox.ValueMember = "Channel"
        ChannelBox.DisplayMember = "Channel"
        ChannelBox.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    ''' <summary>
    ''' Fills the Payment Method combo box based of the information stored in the events table.
    ''' </summary>
    Private Sub InitializePaymentMethod()
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Select * from PaymentMethods"
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        sqlquery.Fill(ds)
        PaymentMethod.ValueMember = "Method"
        PaymentMethod.DisplayMember = "Method"
        PaymentMethod.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub dataGridView1_CellClick(ByVal sender As Object,
    ByVal e As DataGridViewCellEventArgs) _
    Handles DataGridView1.CellClick
        'ID
        If admin_status = True Then
            If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    IDNumber.Text = cell.Value
                    IDNumber_TextChanged(sender, e)
                End If
            End If
            'First Name
            If e.ColumnIndex = 1 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    FirstName.Text = cell.Value
                    FirstName_TextChanged(sender, e)
                End If
            End If
            'Last Name
            If e.ColumnIndex = 2 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    LastName.Text = cell.Value
                    LastName_TextChanged(sender, e)
                End If
            End If
            'RSVP Status
            If e.ColumnIndex = 6 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then

                    If cell.Value.ToString = "Yes" Then
                        RSVPBOX.SelectedValue = "No"
                        RSVP = "No"
                        UpdateMember_Click(sender, e)
                    ElseIf cell.Value.ToString = "No" Then
                        RSVPBOX.SelectedValue = "Yes"
                        RSVP = "Yes"
                        UpdateMember_Click(sender, e)
                    End If
                End If
            End If
            'Check In Status
            If e.ColumnIndex = 7 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then

                    If cell.Value = "Yes" Then
                        CheckIn.SelectedValue = "No"
                        check_in_status = "No"
                        UpdateMember_Click(sender, e)
                    ElseIf cell.Value = "No" Then
                        CheckIn.SelectedValue = "Yes"
                        check_in_status = "Yes"
                        UpdateMember_Click(sender, e)
                    End If
                End If
            End If
            'Membership Status
            If e.ColumnIndex = 11 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    If cell.Value = "Active" Then
                        MemberStatus.SelectedValue = "Inactive"
                        member_status = "Inactive"
                        UpdateMember_Click(sender, e)
                    ElseIf cell.Value = "Inactive" Then
                        MemberStatus.SelectedValue = "Active"
                        member_status = "Active"
                        UpdateMember_Click(sender, e)
                    End If
                End If
            End If
        Else
            If e.ColumnIndex = 0 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    IDNumber.Text = cell.Value
                    IDNumber_TextChanged(sender, e)
                End If
            End If
            'First Name
            If e.ColumnIndex = 1 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    FirstName.Text = cell.Value
                    FirstName_TextChanged(sender, e)
                End If
            End If
            'Last Name
            If e.ColumnIndex = 2 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    LastName.Text = cell.Value
                    LastName_TextChanged(sender, e)
                End If
            End If
            'RSVP Status
            If e.ColumnIndex = 7 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then

                    If cell.Value.ToString = "Yes" Then
                        RSVPBOX.SelectedValue = "No"
                        RSVP = "No"
                        UpdateMember_Click(sender, e)
                    ElseIf cell.Value.ToString = "No" Then
                        RSVPBOX.SelectedValue = "Yes"
                        RSVP = "Yes"
                        UpdateMember_Click(sender, e)
                    End If
                End If
            End If
            'Check In Status
            If e.ColumnIndex = 8 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then

                    If cell.Value = "Yes" Then
                        CheckIn.SelectedValue = "No"
                        check_in_status = "No"
                        UpdateMember_Click(sender, e)
                    ElseIf cell.Value = "No" Then
                        CheckIn.SelectedValue = "Yes"
                        check_in_status = "Yes"
                        UpdateMember_Click(sender, e)
                    End If
                End If
            End If
            'Membership Status
            If e.ColumnIndex = 4 And e.RowIndex >= 0 Then
                Dim cell As DataGridViewTextBoxCell =
            DataGridView1.Rows(e.RowIndex).
                Cells(e.ColumnIndex)
                If cell.Value.ToString IsNot "" Then
                    If cell.Value = "Active" Then
                        MemberStatus.SelectedValue = "Inactive"
                        member_status = "Inactive"
                        UpdateMember_Click(sender, e)
                    ElseIf cell.Value = "Inactive" Then
                        MemberStatus.SelectedValue = "Active"
                        member_status = "Active"
                        UpdateMember_Click(sender, e)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    ''' <summary>
    ''' This function sets the default channel to the value from the defaults table.
    ''' </summary>
    Private Sub SetDefaultChannel()
        Dim cmd2 As New SqlCommand()
        Dim con2 As New SqlConnection()
        con2.ConnectionString = con_string
        con2.Open()
        cmd2.Connection = con2
        cmd2.CommandText = "Select [Default Channel] from [Defaults] where [Id]=@Id"
        cmd2.Parameters.AddWithValue("@Id", 1)
        ChannelBox.SelectedValue = cmd2.ExecuteScalar()
        con2.Close()
    End Sub
    ''' <summary>
    ''' This function sets the default payment to the value from the defaults table.
    ''' </summary>
    Private Sub SetDefaultPayment()
        Dim cmd2 As New SqlCommand()
        Dim con2 As New SqlConnection()
        con2.ConnectionString = con_string
        con2.Open()
        cmd2.Connection = con2
        cmd2.CommandText = "Select [Default Payment] from [Defaults] where [Id]=@Id"
        cmd2.Parameters.AddWithValue("@Id", 1)
        PaymentMethod.SelectedValue = cmd2.ExecuteScalar()
        con2.Close()
    End Sub
    ''' <summary>
    ''' This function sets the default event to the value from the defaults table.
    ''' </summary>
    Private Sub SetDefaultEvent()
        Dim cmd2 As New SqlCommand()
        Dim con2 As New SqlConnection()
        con2.ConnectionString = con_string
        con2.Open()
        cmd2.Connection = con2
        cmd2.CommandText = "Select [Default Event] from [Defaults] where [Id]=@Id"
        cmd2.Parameters.AddWithValue("@Id", 1)
        EventBox.SelectedValue = cmd2.ExecuteScalar()
        con2.Close()
    End Sub
    Private Sub IDNumber_TextChanged(sender As Object, e As EventArgs) Handles IDNumber.TextChanged
        If IDNumber.Text.Length = 0 Then
            FirstName.Clear()
            LastName.Clear()
            PhoneNumber.Clear()
            EmailAddress.Clear()
            cell_phone.Clear()
            CheckIn.SelectedIndex = 2
            RSVPBOX.SelectedIndex = 2
            PartyText.Clear()
            Line1Text.Clear()
            Line2Text.Clear()
            CityText.Clear()
            StateText.Clear()
            ZipText.Clear()
            CountryText.Clear()
            SpouseName.Clear()
            SetDefaultEvent()
            SetDefaultChannel()
            SetDefaultPayment()
            NoteBox.Clear()
            NoteBox.Text = ""
            MemberStatus.SelectedIndex = 2
            Adult.Clear()
            Children.Clear()
            FamilySize.Clear()
            ChildrenCheck.Clear()
            AdultCheck.Clear()
            WorkPhone.Clear()
            DuesBox.Clear()
            ViewDatabase_Click(sender, e)
        Else
            Try
                Int64.Parse(IDNumber.Text)
                id_number = Int64.Parse(IDNumber.Text)
                FirstName.Clear()
                LastName.Clear()
                PhoneNumber.Clear()
                EmailAddress.Clear()
                cell_phone.Clear()
                Adult.Clear()
                Children.Clear()
                FamilySize.Clear()
                PartyText.Clear()
                Line1Text.Clear()
                Line2Text.Clear()
                CityText.Clear()
                StateText.Clear()
                ZipText.Clear()
                CountryText.Clear()
                SpouseName.Clear()
                ChildrenCheck.Clear()
                DuesBox.Clear()
                AdultCheck.Clear()
                WorkPhone.Clear()
                CheckIn.SelectedIndex = 2
                RSVPBOX.SelectedIndex = 2
                SetDefaultEvent()
                SetDefaultChannel()
                event_name = ""
                SetDefaultPayment()
                NoteBox.Clear()
                NoteBox.Text = ""
                MemberStatus.SelectedIndex = 2
                Try
                    Dim cmd As New SqlCommand()
                    Dim con As New SqlConnection()
                    con.ConnectionString = con_string
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "select * from membership where Id = @id"
                    cmd.Parameters.AddWithValue("@id", id_number)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    reader.Read()
                    If reader.HasRows Then
                        'First Name
                        If Not reader(1) Is DBNull.Value Then
                            FirstName.Text = reader.GetString(1)
                            first_name = reader.GetString(1)
                        End If
                        'Last Name
                        If Not reader(2) Is DBNull.Value Then
                            LastName.Text = reader.GetString(2)
                            last_name = reader.GetString(2)
                        End If
                        'Phone Number
                        If Not reader(3) Is DBNull.Value Then
                            PhoneNumber.Text = reader.GetString(3)
                            phone_number = reader.GetString(3)
                        End If
                        'Cell Phone
                        If Not reader(4) Is DBNull.Value Then
                            cell_phone.Text = reader.GetString(4)
                            cellphone_number = reader.GetString(4)
                        End If
                        'Email Address
                        If Not reader(5) Is DBNull.Value Then
                            EmailAddress.Text = reader.GetString(5)
                            email_address = reader.GetString(5)
                        End If
                        'RSVP
                        If Not reader(6) Is DBNull.Value Then
                            RSVPBOX.SelectedItem = reader.GetString(6)
                            RSVP = reader.GetString(6)
                        End If
                        'Check In
                        If Not reader(7) Is DBNull.Value Then
                            CheckIn.SelectedItem = reader.GetString(7)
                            check_in_status = reader.GetString(7)
                        End If
                        'Family Size
                        If Not reader(8) Is DBNull.Value Then
                            FamilySize.Text = reader.GetString(8)
                            family_size = reader.GetString(8)
                        End If
                        'Children
                        If Not reader(9) Is DBNull.Value Then
                            Children.Text = reader.GetString(9)
                            children_number = reader.GetString(9)
                        End If
                        'Adults
                        If Not reader(10) Is DBNull.Value Then
                            Adult.Text = reader.GetString(10)
                            adult_number = reader.GetString(10)
                        End If
                        'Membership Status
                        If Not reader(11) Is DBNull.Value Then
                            MemberStatus.SelectedItem = reader.GetString(11)
                            member_status = reader.GetString(11)
                        End If
                        'Event
                        If Not reader(12) Is DBNull.Value Then
                            EventBox.Text = reader.GetString(12)
                            event_name = reader.GetString(12)
                        End If
                        'Payment Method
                        If Not reader(13) Is DBNull.Value Then
                            PaymentMethod.SelectedItem = reader.GetString(13)
                            payment_method = reader.GetString(13)
                        End If
                        'Channel 
                        If Not reader(14) Is DBNull.Value Then
                            ChannelBox.SelectedItem = reader.GetString(14)
                            channel = reader.GetString(14)
                        End If
                        'Note
                        If Not reader(15) Is DBNull.Value Then
                            NoteBox.Text = reader.GetString(15)
                            note = reader.GetString(15)
                        End If
                        'Party Size
                        If Not reader(16) Is DBNull.Value Then
                            PartyText.Text = reader.GetString(16)
                            party_number = reader.GetString(16)
                        End If
                        'Line 1
                        If Not reader(17) Is DBNull.Value Then
                            Line1Text.Text = reader.GetString(17)
                            line1 = reader.GetString(17)
                        End If
                        'Line 2
                        If Not reader(18) Is DBNull.Value Then
                            Line2Text.Text = reader.GetString(18)
                            line2 = reader.GetString(18)
                        End If
                        'City
                        If Not reader(19) Is DBNull.Value Then
                            CityText.Text = reader.GetString(19)
                            city = reader.GetString(19)
                        End If
                        'State
                        If Not reader(20) Is DBNull.Value Then
                            StateText.Text = reader.GetString(20)
                            state = reader.GetString(20)
                        End If
                        'Zip
                        If Not reader(21) Is DBNull.Value Then
                            ZipText.Text = reader.GetString(21)
                            zip = reader.GetString(21)
                        End If
                        'Country
                        If Not reader(22) Is DBNull.Value Then
                            CountryText.Text = reader.GetString(22)
                            country = reader.GetString(22)
                        End If
                        'Spouse Name
                        If Not reader(23) Is DBNull.Value Then
                            SpouseName.Text = reader.GetString(23)
                            spouse_name = reader.GetString(23)
                        End If
                        'Adult Check In
                        If Not reader(24) Is DBNull.Value Then
                            AdultCheck.Text = reader.GetString(24)
                        End If
                        'Children Check In
                        If Not reader(25) Is DBNull.Value Then
                            ChildrenCheck.Text = reader.GetString(25)
                        End If
                        'Work Phone
                        If Not reader(26) Is DBNull.Value Then
                            WorkPhone.Text = reader.GetString(26)
                        End If
                        'Date Time would be 27 but it is not stored into any local variables
                        'DuesBox
                        If Not reader(28) Is DBNull.Value Then
                            DuesBox.Text = reader.GetString(28)
                        End If
                        reader.Close()
                        con.Close()
                    Else
                        con.Close()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Catch ex As Exception
                If IDNumber.Text.Length > 1 Then
                    MessageBox.Show(ex.Message)
                    IDNumber.Clear()
                End If
            End Try

        End If
    End Sub

    'Search DB To find all with matching first name
    Private Sub FirstName_TextChanged(sender As Object, e As EventArgs) Handles FirstName.TextChanged
        If FirstName.Text = "" Then
            first_name = ""
            ViewDatabase_Click(sender, e)
        End If
        If admin_status = True Then
            If isValid(FirstName.Text) Then
                first_name = FirstName.Text
                Try
                    Try
                        Dim cmd As New SqlCommand()
                        Dim con As New SqlConnection()
                        con.ConnectionString = con_string
                        con.Open()
                        cmd.Connection = con
                        cmd.CommandText = "Select * from membership where [Last Name] Like @lastname + '%' and [First Name] Like + @firstname + '%'"
                        cmd.Parameters.AddWithValue("@firstname", first_name)
                        If last_name = "" Then
                            cmd.Parameters.AddWithValue("@lastname", "")
                        Else
                            cmd.Parameters.AddWithValue("@lastname", last_name)
                        End If
                        Dim sqlquery As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        sqlquery.Fill(ds, "Membership_Table")
                        con.Close()
                        DataGridView1.DataSource = ds
                        DataGridView1.DataMember = "Membership_Table"
                        DataGridView1.AutoGenerateColumns = False
                        DataGridView1.Columns(11).DisplayIndex = 1
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch ex As Exception
                    If FirstName.Text.Length > 1 Then
                        MessageBox.Show("Please only enter alphabetical characters")
                        FirstName.Clear()
                    End If
                End Try
            ElseIf FirstName.Text.Length > 1 Then
                MessageBox.Show("Please only enter alphabetical characters")
                FirstName.Clear()
            End If
            If FirstName.Text = "" Then
                first_name = ""
            End If
            '* * * * * * * * * * * * * * * * User View * * * * * * * * * * * * * * * *
        Else
            If isValid(FirstName.Text) Then
                first_name = FirstName.Text
                Try
                    Try
                        Dim cmd As New SqlCommand()
                        Dim con As New SqlConnection()
                        con.ConnectionString = con_string
                        con.Open()
                        cmd.Connection = con
                        cmd.CommandText = user_view & "where [Last Name] Like @lastname + '%' and [First Name] Like @firstname + '%'"
                        cmd.Parameters.AddWithValue("@firstname", first_name)
                        If last_name = "" Then
                            cmd.Parameters.AddWithValue("@lastname", "")
                        Else
                            cmd.Parameters.AddWithValue("@lastname", last_name)
                        End If
                        Dim sqlquery As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        sqlquery.Fill(ds, "Membership_Table")
                        con.Close()
                        DataGridView1.DataSource = ds
                        DataGridView1.DataMember = "Membership_Table"
                        DataGridView1.AutoGenerateColumns = False
                        DataGridView1.Columns(11).DisplayIndex = 1
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch ex As Exception
                    If FirstName.Text.Length > 1 Then
                        MessageBox.Show("Please only enter alphabetical characters")
                        FirstName.Clear()
                    End If
                End Try
            ElseIf FirstName.Text.Length > 1 Then
                MessageBox.Show("Please only enter alphabetical characters")
                FirstName.Clear()

            End If
            If FirstName.Text = "" Then
                first_name = ""
            End If
        End If
    End Sub

    'Search DB To find all with matching last name
    Private Sub LastName_TextChanged(sender As Object, e As EventArgs) Handles LastName.TextChanged
        If LastName.Text = "" Then
            last_name = ""
            ViewDatabase_Click(sender, e)
        End If
        If admin_status = True Then

            If isValid(LastName.Text) Then
                last_name = LastName.Text
                Try
                    Try
                        Dim cmd As New SqlCommand()
                        Dim con As New SqlConnection()
                        con.ConnectionString = con_string
                        con.Open()
                        cmd.Connection = con
                        cmd.CommandText = "select * from membership where [Last Name] Like @lastname + '%' and [First Name] Like @firstname + '%'"
                        cmd.Parameters.AddWithValue("@lastname", last_name)
                        If first_name = "" Then
                            cmd.Parameters.AddWithValue("@firstname", "")
                        Else
                            cmd.Parameters.AddWithValue("@firstname", first_name)
                        End If
                        Dim sqlquery As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        sqlquery.Fill(ds, "Membership_Table")
                        con.Close()
                        DataGridView1.DataSource = ds
                        DataGridView1.DataMember = "Membership_Table"
                        DataGridView1.AutoGenerateColumns = False
                        DataGridView1.Columns(11).DisplayIndex = 1
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            ElseIf LastName.Text.Length >= 1 Then
                MessageBox.Show("Please only enter alphabetical characters")
                LastName.Clear()
            End If
            If LastName.Text = "" Then
                last_name = ""
            End If
            '* * * * * * * * * * * * * * * * User View * * * * * * * * * * * * * * * *
        Else
            If isValid(LastName.Text) Then
                last_name = LastName.Text
                Try
                    Try
                        Dim cmd As New SqlCommand()
                        Dim con As New SqlConnection()
                        con.ConnectionString = con_string
                        con.Open()
                        cmd.Connection = con
                        cmd.CommandText = user_view & " where [Last Name] Like @lastname + '%' and [First Name] Like @firstname + '%'"
                        cmd.Parameters.AddWithValue("@lastname", last_name)
                        If first_name = "" Then
                            cmd.Parameters.AddWithValue("@firstname", "")
                        Else
                            cmd.Parameters.AddWithValue("@firstname", first_name)
                        End If
                        Dim sqlquery As New SqlDataAdapter(cmd)
                        Dim ds As New DataSet()
                        sqlquery.Fill(ds, "Membership_Table")
                        con.Close()
                        DataGridView1.DataSource = ds
                        DataGridView1.DataMember = "Membership_Table"
                        DataGridView1.AutoGenerateColumns = False
                        DataGridView1.Columns(11).DisplayIndex = 1
                    Catch ex As Exception
                        MessageBox.Show(ex.Message)
                    End Try
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            ElseIf LastName.Text.Length >= 1 Then
                MessageBox.Show("Please only enter alphabetical characters")
                LastName.Clear()
            End If
            If LastName.Text = "" Then
                last_name = ""
            End If
        End If
    End Sub

    '* * * * * * * * * * * * * * * * * * * * * * * *  Defining variables by input * * * * * * * * * * * *  * * * * * * * * * * * * 
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

    Private Sub FamilySize_TextChanged(sender As Object, e As EventArgs) Handles FamilySize.TextChanged
        family_size = FamilySize.Text
    End Sub

    Private Sub Children_TextChanged(sender As Object, e As EventArgs) Handles Children.TextChanged
        children_number = Children.Text
    End Sub

    Private Sub RichTextBox3_TextChanged(sender As Object, e As EventArgs) Handles Adult.TextChanged
        adult_number = Adult.Text
    End Sub

    Private Sub RSVPBOX_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RSVPBOX.SelectedIndexChanged
        RSVP = RSVPBOX.Text
    End Sub

    Private Sub CheckIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CheckIn.SelectedIndexChanged
        check_in_status = CheckIn.Text
    End Sub

    Private Sub Recalculate_Boxes(sender As Object, e As EventArgs)
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Dim ds As New DataSet()
        cmd.CommandText = "select [Adult Check In], [Children Check In] from [Membership] where [Check In Status] = @CheckIn"
        cmd.Parameters.AddWithValue("@CheckIn", "Yes")
        con.ConnectionString = con_string
        cmd.Connection = con
        adult_rsvp = 0
        children_rsvp = 0
        con.Open()
        Dim sqlquery As New SqlDataAdapter(cmd)
        sqlquery.Fill(ds, "Membership_Table")
        con.Close()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If Not ds.Tables(0).Rows(i).Item(0) Is DBNull.Value Then
                adult_rsvp += ds.Tables(0).Rows(i).Item(0)
            Else
                adult_rsvp += 0
            End If
            If Not ds.Tables(0).Rows(i).Item(1) Is DBNull.Value Then
                children_rsvp += ds.Tables(0).Rows(i).Item(1)
            Else
                children_rsvp += 0
            End If
        Next
        con.Close()
        check_in = adult_rsvp + children_rsvp
        Checkin_number.Text = check_in.ToString()
        Total_Adult.Text = adult_rsvp.ToString()
        Total_Children.Text = children_rsvp.ToString()
    End Sub
    Private Sub Recalculate_RSVP(sender As Object, e As EventArgs)
        Dim cmd2 As New SqlCommand()
        Dim con2 As New SqlConnection()
        Dim total_rsvp As Int64
        con2.ConnectionString = con_string
        con2.Open()
        cmd2.Connection = con2
        Dim ds2 As New DataSet()
        cmd2.CommandText = "select [Party Size] from [Membership] where [Picnic RSVP] = @RSVP"
        cmd2.Parameters.AddWithValue("@RSVP", "Yes")
        Dim sqlquery2 As New SqlDataAdapter(cmd2)
        sqlquery2.Fill(ds2, "Membership_Table")
        con2.Close()
        For i = 0 To ds2.Tables(0).Rows.Count - 1
            If Not ds2.Tables(0).Rows(i).Item(0) Is DBNull.Value Then
                total_rsvp += Convert.ToInt64(ds2.Tables(0).Rows(i).Item(0))
            Else
                total_rsvp += 0
            End If
        Next
        TextBox2.Text = total_rsvp.ToString()
    End Sub
    Private Sub Reset_Click(sender As Object, e As EventArgs) Handles Reset.Click
        Recalculate_Boxes(sender, e)
        Recalculate_RSVP(sender, e)
        If (IDNumber.Text = "") Then
            IDNumber_TextChanged(sender, e)
        Else
            IDNumber.Text = ""
        End If
    End Sub

    Private Sub cell_phone_TextChanged(sender As Object, e As EventArgs) Handles cell_phone.TextChanged
        cellphone_number = cell_phone.Text
    End Sub

    Private Sub PhoneNumber_TextChanged(sender As Object, e As EventArgs) Handles PhoneNumber.TextChanged
        phone_number = PhoneNumber.Text
    End Sub

    Private Sub EmailAddress_TextChanged(sender As Object, e As EventArgs) Handles EmailAddress.TextChanged
        email_address = EmailAddress.Text
    End Sub

    Private Sub EventBox_TextChanged(sender As Object, e As EventArgs) Handles EventBox.TextChanged
        event_name = EventBox.Text
    End Sub

    Private Sub PaymentMethod_TextChanged(sender As Object, e As EventArgs) Handles PaymentMethod.TextChanged
        If isValid(PaymentMethod.Text) And PaymentMethod.Text.Length > 1 Then
            payment_method = PaymentMethod.Text
        ElseIf PaymentMethod.Text.Length > 1 Then
            MessageBox.Show("Please only enter alphabetical characters")
            PaymentMethod.Text = ""
        End If
    End Sub

    Private Sub DuesBox_TextChanged(sender As Object, e As EventArgs) Handles DuesBox.TextChanged
        unpaid_dues = DuesBox.Text
    End Sub

    Private Sub EventBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles EventBox.SelectedIndexChanged
        event_name = EventBox.Text
    End Sub

    Private Sub PaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PaymentMethod.SelectedIndexChanged
        payment_method = PaymentMethod.Text
    End Sub

    Private Sub NoteBox_TextChanged(sender As Object, e As EventArgs) Handles NoteBox.TextChanged
        note = NoteBox.Text
    End Sub

    Private Sub PartyText_TextChanged(sender As Object, e As EventArgs) Handles PartyText.TextChanged
        party_number = PartyText.Text
    End Sub

    Private Sub ChannelBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChannelBox.SelectedIndexChanged
        channel = ChannelBox.Text
    End Sub

    Private Sub ChannelBox_TextChanged(sender As Object, e As EventArgs) Handles ChannelBox.TextChanged
        channel = ChannelBox.Text
    End Sub

    Private Sub MemberStatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MemberStatus.SelectedIndexChanged
        member_status = MemberStatus.Text
    End Sub

    Private Sub Line1Text_TextChanged(sender As Object, e As EventArgs) Handles Line1Text.TextChanged
        line1 = Line1Text.Text
    End Sub

    Private Sub Line2Text_TextChanged(sender As Object, e As EventArgs) Handles Line2Text.TextChanged
        line2 = Line2Text.Text
    End Sub

    Private Sub CityText_TextChanged(sender As Object, e As EventArgs) Handles CityText.TextChanged
        city = CityText.Text
    End Sub

    Private Sub StateText_TextChanged(sender As Object, e As EventArgs) Handles StateText.TextChanged
        state = StateText.Text
    End Sub

    Private Sub ZipText_TextChanged(sender As Object, e As EventArgs) Handles ZipText.TextChanged
        zip = ZipText.Text
    End Sub

    Private Sub CountryText_TextChanged(sender As Object, e As EventArgs) Handles CountryText.TextChanged
        country = CountryText.Text
    End Sub

    Private Sub SpouseName_TextChanged(sender As Object, e As EventArgs) Handles SpouseName.TextChanged
        spouse_name = SpouseName.Text
    End Sub

    'Updating Member
    Private Sub UpdateMember_Click(sender As Object, e As EventArgs) Handles UpdateMember.Click
        If IDNumber.Text = "" Then
            MessageBox.Show("Please make sure Member ID Number is filled out before trying to update")
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Update [membership] SET [First Name]=@FirstName, [Last Name]=@LastName, " &
                "[Phone Number]=@PhoneNumber, [Cellphone Number] = @CellPhoneNumber, [Email Address]=@EmailAddress, " &
                "[Event Signed Up At]=@EventSignedUpAt, [Picnic RSVP] = @RSVP, [Check In Status] =@CheckInStatus, " &
                "[Payment Method]=@PaymentMethod, [Note]=@Note, [Party Size] = @PartySize, [Membership Status]=@MembershipStatus," &
" [Channel]=@Channel, [Family Size]=@Family, [Adults]=@Adult, [Children]=@Children, [Country]=@Country," &
            "[State]=@State, [Zip]=@Zip, [Address 1]=@Line1, [Address 2]=@Line2, [City]=@City, [Spouse Name]=@Spouse," &
            "[Adult Check In]=@AdultCheck, [Children Check In]=@ChildrenCheck, [Work Number]=@Work, [Unpaid Dues]=@Dues WHERE [ID] = @id;"

            cmd.Parameters.AddWithValue("@id", id_number)
            cmd.Parameters.AddWithValue("@FirstName", first_name)
            cmd.Parameters.AddWithValue("@LastName", last_name)
            'Adult Check In
            If AdultCheck.Text = "" Then
                cmd.Parameters.AddWithValue("@AdultCheck", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@AdultCheck", AdultCheck.Text)
            End If
            'Children Check In
            If ChildrenCheck.Text = "" Then
                cmd.Parameters.AddWithValue("@ChildrenCheck", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@ChildrenCheck", ChildrenCheck.Text)
            End If

            'Spouse Name
            If spouse_name = "" Then
                cmd.Parameters.AddWithValue("@Spouse", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Spouse", spouse_name)
            End If
            'Country
            If country = "" Then
                cmd.Parameters.AddWithValue("@Country", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Country", country)
            End If
            'State
            If state = "" Then
                cmd.Parameters.AddWithValue("@State", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@State", state)
            End If
            'Zip
            If zip = "" Then
                cmd.Parameters.AddWithValue("@Zip", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Zip", zip)
            End If
            'Line 1
            If line1 = "" Then
                cmd.Parameters.AddWithValue("@Line1", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Line1", line1)
            End If
            'Line2
            If line2 = "" Then
                cmd.Parameters.AddWithValue("@Line2", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Line2", line2)
            End If
            'City
            If city = "" Then
                cmd.Parameters.AddWithValue("@City", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@City", city)
            End If
            'Family Size
            If family_size = "" Then
                cmd.Parameters.AddWithValue("@Family", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Family", family_size)
            End If
            'Adult Number
            If adult_number = "" Then
                cmd.Parameters.AddWithValue("@Adult", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Adult", adult_number)
            End If
            'Children Number
            If children_number = "" Then
                cmd.Parameters.AddWithValue("@Children", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Children", children_number)
            End If
            'Channel
            If channel = "" Then
                cmd.Parameters.AddWithValue("@Channel", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Channel", channel)
            End If
            'Member Status
            If member_status = "" Then
                cmd.Parameters.AddWithValue("@MembershipStatus", "Active")
            Else
                cmd.Parameters.AddWithValue("@MembershipStatus", member_status)
            End If
            'Check In Status
            If check_in_status = "" Then
                cmd.Parameters.AddWithValue("@CheckInStatus", "No")
            Else
                cmd.Parameters.AddWithValue("@CheckInStatus", check_in_status)
            End If
            'RSVP
            If RSVP = "" Then
                cmd.Parameters.AddWithValue("@RSVP", "No")
            Else
                cmd.Parameters.AddWithValue("@RSVP", RSVP)
            End If
            'Phone number
            If phone_number = "" Then
                cmd.Parameters.AddWithValue("@PhoneNumber", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@PhoneNumber", phone_number)
            End If
            'Cellphone Number
            If cellphone_number = "" Then
                cmd.Parameters.AddWithValue("@CellPhoneNumber", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@CellPhoneNumber", cellphone_number)
            End If
            'Email Address
            If email_address = "" Then
                cmd.Parameters.AddWithValue("@EmailAddress", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@EmailAddress", email_address)
            End If
            'Event Name
            If event_name = "" Then
                cmd.Parameters.AddWithValue("@EventSignedUpAt", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@EventSignedUpAt", event_name)
            End If
            'Payment Method
            If payment_method = "" Then
                cmd.Parameters.AddWithValue("@PaymentMethod", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@PaymentMethod", payment_method)
            End If
            'Note
            If note = "" Then
                cmd.Parameters.AddWithValue("@Note", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Note", note)
            End If
            'Party Number
            If party_number = "" Then
                cmd.Parameters.AddWithValue("@PartySize", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@PartySize", party_number)
            End If
            'Work Phone
            If WorkPhone.Text = "" Then
                cmd.Parameters.AddWithValue("@Work", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Work", WorkPhone.Text)
            End If
            'Unpaid Dues
            If DuesBox.Text = "" Then
                cmd.Parameters.AddWithValue("@Dues", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Dues", DuesBox.Text)
            End If
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
        IDNumber_TextChanged(sender, e)
        Recalculate_Boxes(sender, e)
        Recalculate_RSVP(sender, e)
    End Sub

    'View Database - check for user/admin status
    Private Sub ViewDatabase_Click(sender As Object, e As EventArgs) 'Handles ViewDatabase.Click
        If admin_status = True Then
            IDNumber.ReadOnly = False
            Dim connstring As String = con_string
            Dim query As String
            If My.Settings.ViewAll = True Then
                query = "Select * from [Membership]"
            Else
                query = "Select * from [Membership] where [Membership Status]='Active'"
            End If
            Using connection As New SqlConnection(connstring)
                Dim sqlquery As New SqlDataAdapter(query, connection)
                Dim ds As New DataSet()
                connection.Open()
                sqlquery.Fill(ds, "Membership_Table")
                connection.Close()
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "Membership_Table"
                DataGridView1.AutoGenerateColumns = False
                DataGridView1.Columns(11).DisplayIndex = 1
            End Using
            'Change select for user view only if need be
        Else
            Dim connstring As String = con_string
            Dim query As String
            If My.Settings.ViewAll = True Then
                query = user_view
            Else
                query = user_view2
            End If
            Using connection As New SqlConnection(connstring)
                Dim sqlquery As New SqlDataAdapter(query, connection)
                Dim ds As New DataSet()
                connection.Open()
                sqlquery.Fill(ds, "Membership_Table")
                connection.Close()
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "Membership_Table"
                DataGridView1.AutoGenerateColumns = False
                DataGridView1.Columns(11).DisplayIndex = 1
            End Using
        End If
    End Sub

    ' * * * * * * * * * * * * * * * * * * ADMIN ONLY SECTION * * * * * * * * * * * * * * * * * * * * * * * *
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
    ' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *

    'Admin Only - Remove Member
    Private Sub RemoveMember_Click(sender As Object, e As EventArgs) 'Handles RemoveMember.Click
        If IDNumber.Text = "" Then
            MessageBox.Show("Please make sure Member ID Number Is filled out before trying To update")
            Exit Sub
        End If
        Dim message_result As DialogResult = MessageBox.Show("You cannot undo removing a member from the database. " &
        "Are you sure you wish to remove this person?", "Critical Warning", MessageBoxButtons.YesNo,
        MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Delete from membership Where [Id] = @id"
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id_number
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
        ViewDatabase_Click(sender, e)
    End Sub

    ' ************************LOAD FUNCTION SHOULD NOT BE USED AGAIN, USE BACK UP FUNCTIONALITY *******************************
    'Admin Only - Load IFMP Member 2015
    'Currently Hidden
    'Private Sub LoadSheet2ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LoadSheet2ToolStripMenuItem1.Click
    '    Dim message_result As DialogResult = MessageBox.Show("Warning: This will overwrite any existing database you have established. " &
    '    "Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
    '    MessageBoxIcon.Exclamation)
    '    If message_result = Windows.Forms.DialogResult.No Then
    '        Exit Sub
    '    End If
    '    OpenFileDialog2.InitialDirectory = "c:\data\"
    '    OpenFileDialog2.Filter = "Excel Files (*.xlsx)|*.xlsx|All files(*.*)|*.*"
    '    OpenFileDialog2.FilterIndex = 1
    '    OpenFileDialog2.RestoreDirectory = True
    '    If OpenFileDialog2.ShowDialog() = DialogResult.OK Then
    '        'Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
    '        Dim cmd As New SqlCommand()
    '        Dim con As New SqlConnection()
    '        con.ConnectionString = con_string
    '        'con.Open()
    '        'cmd.Connection = con
    '        'cmd.CommandText = "delete from membership;"
    '        'cmd.ExecuteNonQuery()
    '        'con.Close()
    '        Dim xlApp As Excel.Application
    '        Dim xlWorkBook As Excel.Workbook
    '        Dim xlWorkSheet As Excel.Worksheet
    '        Dim x As Int16 = 2
    '        xlApp = New Excel.ApplicationClass
    '        xlWorkBook = xlApp.Workbooks.Open(OpenFileDialog2.FileName, Notify:=False)
    '        xlWorkSheet = xlWorkBook.Worksheets("2015-IFMP-MEMBER")
    '        Do Until xlWorkSheet.Cells(x, 1).text.ToString = ""
    '            id_number = Convert.ToInt64(xlWorkSheet.Cells(x, 1).text)
    '            first_name = xlWorkSheet.Cells(x, 4).text
    '            last_name = xlWorkSheet.Cells(x, 5).text
    '            email_address = xlWorkSheet.Cells(x, 7).text
    '            phone_number = Convert.ToString(xlWorkSheet.Cells(x, 8).text)
    '            cellphone_number = Convert.ToString(xlWorkSheet.Cells(x, 9).text)
    '            family_size = Convert.ToString(xlWorkSheet.Cells(x, 10).text)
    '            adult_number = Convert.ToString(xlWorkSheet.Cells(x, 11).text)
    '            children_number = Convert.ToString(xlWorkSheet.Cells(x, 12).text)
    '            line1 = Convert.ToString(xlWorkSheet.Cells(x, 13).text)
    '            line2 = Convert.ToString(xlWorkSheet.Cells(x, 14).text)
    '            city = Convert.ToString(xlWorkSheet.Cells(x, 15).text)
    '            state = Convert.ToString(xlWorkSheet.Cells(x, 16).text)
    '            zip = Convert.ToString(xlWorkSheet.Cells(x, 17).text)
    '            country = Convert.ToString(xlWorkSheet.Cells(x, 18).text)
    '            payment_method = Convert.ToString(xlWorkSheet.Cells(x, 19).text)
    '            channel = Convert.ToString(xlWorkSheet.Cells(x, 20).text)
    '            DBUpdateHand_Click(sender, e)
    '            x += 1
    '        Loop
    '        xlWorkBook.Close()
    '        xlApp.Quit()
    '        releaseObject(xlApp)
    '        releaseObject(xlWorkBook)
    '        releaseObject(xlWorkSheet)
    '    End If
    'End Sub

    'Admin Only - Load From Default Template
    'Currently Hidden
    '    Private Sub LoadDefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadDefaultToolStripMenuItem.Click
    '        Dim message_result As DialogResult = MessageBox.Show("Warning: This will overwrite existing member information you have with information
    'form the template you are loading. " &
    '       "Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
    '       MessageBoxIcon.Exclamation)
    '        If message_result = Windows.Forms.DialogResult.No Then
    '            Exit Sub
    '        End If
    '        OpenFileDialog1.InitialDirectory = "c:\data\"
    '        OpenFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx|All files(*.*)|*.*"
    '        OpenFileDialog1.FilterIndex = 1
    '        OpenFileDialog1.RestoreDirectory = True
    '        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
    '            'Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
    '            'Dim cmd As New SqlCommand()
    '            'Dim con As New SqlConnection()
    '            'con.ConnectionString = con_string
    '            'con.Open()
    '            'cmd.Connection = con
    '            'cmd.CommandText = "delete from membership;"
    '            'cmd.ExecuteNonQuery()
    '            'con.Close()
    '            Dim file_name As String = OpenFileDialog1.FileName
    '            Dim xlApp As Excel.Application
    '            Dim xlWorkBook As Excel.Workbook
    '            Dim xlWorkSheet As Excel.Worksheet
    '            Dim x As Int16 = 2
    '            xlApp = New Excel.ApplicationClass
    '            xlWorkBook = xlApp.Workbooks.Open(file_name, Notify:=False)
    '            xlWorkSheet = xlWorkBook.Worksheets("sheet1")
    '            Do Until xlWorkSheet.Cells(x, 1).text.ToString = ""
    '                id_number = Convert.ToInt64(xlWorkSheet.Cells(x, 1).text)
    '                first_name = Convert.ToString(xlWorkSheet.Cells(x, 2).text)
    '                last_name = Convert.ToString(xlWorkSheet.Cells(x, 3).text)
    '                phone_number = Convert.ToString(xlWorkSheet.Cells(x, 4).text)
    '                cellphone_number = Convert.ToString(xlWorkSheet.Cells(x, 5).text)
    '                email_address = Convert.ToString(xlWorkSheet.Cells(x, 6).text)
    '                RSVP = Convert.ToString(xlWorkSheet.Cells(x, 7).text)
    '                check_in_status = Convert.ToString(xlWorkSheet.Cells(x, 8).text)
    '                family_size = Convert.ToString(xlWorkSheet.Cells(x, 9).text)
    '                children_number = Convert.ToString(xlWorkSheet.Cells(x, 10).text)
    '                adult_number = Convert.ToString(xlWorkSheet.Cells(x, 11).text)
    '                member_status = Convert.ToString(xlWorkSheet.Cells(x, 12).text)
    '                event_name = Convert.ToString(xlWorkSheet.Cells(x, 13).text)
    '                payment_method = Convert.ToString(xlWorkSheet.Cells(x, 14).text)
    '                channel = Convert.ToString(xlWorkSheet.Cells(x, 15).text)
    '                note = Convert.ToString(xlWorkSheet.Cells(x, 16).text)
    '                party_number = Convert.ToString(xlWorkSheet.Cells(x, 17).text)
    '                line1 = Convert.ToString(xlWorkSheet.Cells(x, 18).text)
    '                line2 = Convert.ToString(xlWorkSheet.Cells(x, 19).text)
    '                city = Convert.ToString(xlWorkSheet.Cells(x, 20).text)
    '                state = Convert.ToString(xlWorkSheet.Cells(x, 21).text)
    '                zip = Convert.ToString(xlWorkSheet.Cells(x, 22).text)
    '                country = Convert.ToString(xlWorkSheet.Cells(x, 23).text)
    '                spouse_name = Convert.ToString(xlWorkSheet.Cells(x, 24).text)
    '                AdultCheck.Text = Convert.ToString(xlWorkSheet.Cells(x, 25).text)
    '                ChildrenCheck.Text = Convert.ToString(xlWorkSheet.Cells(x, 26).text)
    '                WorkPhone.text = Convert.ToString(xlWorkSheet.Cells(x, 27).text)
    '                UpdateMember_Click(sender, e)
    '                ViewDatabase_Click(sender, e)
    '                x += 1
    '            Loop
    '            xlWorkBook.Close()
    '            xlApp.Quit()
    '            releaseObject(xlApp)
    '            releaseObject(xlWorkBook)
    '            releaseObject(xlWorkSheet)

    '        End If
    '    End Sub

    'Admin Only - Load RSVP Excel Documnet
    'Currently Hidden
    'Private Sub LoadRSVPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadRSVPToolStripMenuItem.Click
    '    Dim message_result As DialogResult = MessageBox.Show("Warning: This will overwrite any existing database you have established." &
    '   " Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
    '   MessageBoxIcon.Exclamation)
    '    If message_result = Windows.Forms.DialogResult.No Then
    '        Exit Sub
    '    End If
    '    OpenFileDialog1.InitialDirectory = "c:\data\"
    '    OpenFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx|(*.csv)|*.csv|All files(*.*)|*.*"
    '    OpenFileDialog1.FilterIndex = 2
    '    OpenFileDialog1.RestoreDirectory = True
    '    If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
    '        'Dim sr As New System.IO.StreamReader(OpenFileDialog1.FileName)
    '        Reset_Click(sender, e)
    '        Dim file_name As String = OpenFileDialog1.FileName
    '        Dim xlApp As Excel.Application
    '        Dim xlWorkBook As Excel.Workbook
    '        Dim xlWorkSheet As Excel.Worksheet
    '        Dim x As Int16 = 2
    '        xlApp = New Excel.ApplicationClass
    '        xlWorkBook = xlApp.Workbooks.Open(file_name)
    '        xlWorkSheet = xlWorkBook.Worksheets("Guestlist")
    '        Do Until xlWorkSheet.Cells(x, 1).text.ToString = ""
    '            email_address = (xlWorkSheet.Cells(x, 2).text)
    '            RSVP = xlWorkSheet.Cells(x, 3).text
    '            party_number = xlWorkSheet.Cells(x, 4).text
    '            If RSVP = "Not Yet Replied" Then
    '                RSVP = "No"
    '            End If
    '            Try
    '                Dim cmd As New SqlCommand()
    '                Dim con As New SqlConnection()
    '                Dim cmd2 As New SqlCommand()
    '                con.ConnectionString = con_string
    '                con.Open()
    '                cmd.Connection = con
    '                cmd2.CommandText = "Insert into [membership] ([Id], [Fist Name], [Last Name], [RSVP], [Party Size]) Values(@id, @FirstName,@LastName)"
    '                cmd2.Parameters.AddWithValue("@id", id_number)
    '                cmd2.Parameters.AddWithValue("@FirstName", first_name)
    '                cmd2.Parameters.AddWithValue("@LastName", last_name)
    '                cmd.CommandText = "update membership Set [Picnic RSVP] = @RSVP, [Party Size] = @PartyNumber Where [Email Address] = @EmailAddress;"
    '                cmd.Parameters.Add("@RSVP", SqlDbType.VarChar, 100).Value = RSVP
    '                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 100).Value = email_address
    '                cmd.Parameters.Add("@PartyNumber", SqlDbType.VarChar, 100).Value = party_number
    '                cmd.ExecuteNonQuery()
    '                con.Close()
    '                ViewDatabase_Click(sender, e)
    '            Catch ex As Exception
    '                MessageBox.Show("Error:" & ex.Message)
    '            Finally
    '                x += 1
    '            End Try
    '        Loop
    '        xlWorkBook.Close()
    '        xlApp.Quit()
    '        releaseObject(xlApp)
    '        releaseObject(xlWorkBook)
    '        releaseObject(xlWorkSheet)
    '    End If
    'End Sub

    'Admin Only - Save to default template/backup functionality
    Private Sub LoadSheet2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSheet2ToolStripMenuItem.Click
        SaveFileDialog1.InitialDirectory = "c:\data\"
        SaveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx|All files(*.*)|*.*"
        SaveFileDialog1.FilterIndex = 1
        SaveFileDialog1.RestoreDirectory = True
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            If xlApp Is Nothing Then
                MessageBox.Show("Excel is not properly installed!!")
                Return
            End If
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            Dim connstring = con_string
            Dim query As String = "Select * from [Membership]"
            Using connection As New SqlConnection(connstring)
                Dim sqlquery As New SqlDataAdapter(query, connection)
                Dim ds As New DataSet()
                connection.Open()
                sqlquery.Fill(ds, "Membership_Table")
                xlWorkSheet.Cells(1, 1).Value = "Id"
                xlWorkSheet.Cells(1, 2).Value = "First Name"
                xlWorkSheet.Cells(1, 3).Value = "Last Name"
                xlWorkSheet.Cells(1, 4).Value = "Phone Number"
                xlWorkSheet.Cells(1, 5).value = "Cell Phone Number"
                xlWorkSheet.Cells(1, 6).value = "Email Address"
                xlWorkSheet.Cells(1, 7).value = "Picnic RSVP"
                xlWorkSheet.Cells(1, 8).value = "Check In Status"
                xlWorkSheet.Cells(1, 9).value = "Family Size"
                xlWorkSheet.Cells(1, 10).value = "Children"
                xlWorkSheet.Cells(1, 11).value = "Adults"
                xlWorkSheet.Cells(1, 12).value = "Membership Status"
                xlWorkSheet.Cells(1, 13).value = "Event Signed Up At"
                xlWorkSheet.Cells(1, 14).value = "Payment Method"
                xlWorkSheet.Cells(1, 15).value = "Channel"
                xlWorkSheet.Cells(1, 16).value = "Note"
                xlWorkSheet.Cells(1, 17).value = "Party Size"
                xlWorkSheet.Cells(1, 18).value = "Line 1"
                xlWorkSheet.Cells(1, 19).value = "Line 2"
                xlWorkSheet.Cells(1, 20).value = "City"
                xlWorkSheet.Cells(1, 21).value = "State"
                xlWorkSheet.Cells(1, 22).value = "Zip"
                xlWorkSheet.Cells(1, 23).value = "Country"
                xlWorkSheet.Cells(1, 24).value = "Spouse Name"
                xlWorkSheet.Cells(1, 25).value = "Adults Checked In"
                xlWorkSheet.Cells(1, 26).value = "Children Checked In"
                xlWorkSheet.Cells(1, 27).value = "Work Phone"
                xlWorkSheet.Cells(1, 28).value = "Date Signed Up"
                xlWorkSheet.Cells(1, 29).value = "Unpaid Dues"
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "Membership_Table"
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    For j = 0 To ds.Tables(0).Columns.Count - 1
                        xlWorkSheet.Cells(i + 2, j + 1) =
                    ds.Tables(0).Rows(i).Item(j).ToString()
                    Next
                Next
                connection.Close()
            End Using
            xlWorkBook.SaveAs(SaveFileDialog1.FileName)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            MessageBox.Show("Excel file created , you can find the file " & SaveFileDialog1.FileName & " .")
        End If
    End Sub

    'Send Welcome Mail - Send Mail Through STMP/Gmail To One Member/New Member
    Private Sub SendMail2_Click(sender As Object, e As EventArgs) 'Handles SendMail2.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [Id] = @ID"
        cmd.Parameters.AddWithValue("@ID", id_number)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Email_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Email_Table"
        Dim email_result As String = ""
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.UseDefaultCredentials = False
            SmtpServer.EnableSsl = True
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network
            SmtpServer.Credentials = New _
            Net.NetworkCredential("username@gmail.com", "passcode")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New Net.Mail.MailAddress("username@gmail.com")
            'Redirect all email when the member's email is not present in the database
            If ds.Tables(0).Rows(0).Item(5).ToString = "" Then
                mail.To.Add("username@gmail.com")
                email_result = "username@gmail.com"
            Else
                mail.To.Add(ds.Tables(0).Rows(0).Item(5).ToString)
                email_result = ds.Tables(0).Rows(0).Item(5).ToString
            End If
            mail.Subject = "India Foundaton of Metropolitan Princeton Membership Information"
            mail.Body = "Dear " & ds.Tables(0).Rows(0).Item(1).ToString & " " & ds.Tables(0).Rows(0).Item(2).ToString & "," & System.Environment.NewLine & System.Environment.NewLine &
                        "Welcome to the India Foundation of Metropolitan Princeton! " & System.Environment.NewLine &
                        "Please visit our official website, www.ifmpnj.org, to learn more about our organization and view upcoming events." & System.Environment.NewLine & System.Environment.NewLine &
                        "Your Membership Id Number is: " & ds.Tables(0).Rows(0).Item(0).ToString & System.Environment.NewLine &
                        "You can present this id number at any IFMP Event to speed up the check-in process." & System.Environment.NewLine & System.Environment.NewLine &
                        "Please send a response to ifmporg@gmail.com with the subject line ""Information Update""" &
                        " with updates if any of the information below is incorrect." & System.Environment.NewLine & "Any blank fields indicate that we do not have that information from you." &
                    System.Environment.NewLine & System.Environment.NewLine & "Your phone number is " & ds.Tables(0).Rows(0).Item(3) & System.Environment.NewLine &
                        "Your cell phone number is " & ds.Tables(0).Rows(0).Item(4).ToString & System.Environment.NewLine &
                        "Your work phone number is " & ds.Tables(0).Rows(0).Item(24).ToString & System.Environment.NewLine &
                        "The size of your family is " & ds.Tables(0).Rows(0).Item(8).ToString & System.Environment.NewLine &
                        "The number of children in your family is " & ds.Tables(0).Rows(0).Item(9).ToString & System.Environment.NewLine &
                        "The number of adults in your family is " & ds.Tables(0).Rows(0).Item(10).ToString & System.Environment.NewLine &
                        "Your membership status is " & ds.Tables(0).Rows(0).Item(11).ToString & System.Environment.NewLine &
                        "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(0).Item(17).ToString &
                        System.Environment.NewLine & ds.Tables(0).Rows(0).Item(19).ToString & ds.Tables(0).Rows(0).Item(18) &
                        " " & ds.Tables(0).Rows(0).Item(20).ToString & " " & ds.Tables(0).Rows(0).Item(21).ToString & System.Environment.NewLine & System.Environment.NewLine &
                        "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                         "From," & System.Environment.NewLine &
                    "IFMP Admin"
            SmtpServer.Send(mail)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
        MessageBox.Show("Welcome email sent to " + email_result + ".")
    End Sub

    'Send Mail All - Send Mail Through STMP/Gmail To All Members
    Private Sub SendMail_Click(sender As Object, e As EventArgs) 'Handles SendMail.Click
        Dim message_result As DialogResult = MessageBox.Show(" Are you sure you wish continue? This will send an email to all IFMP Members", "Critical Warning", MessageBoxButtons.YesNo,
       MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership]"
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Try
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.Credentials = New _
                Net.NetworkCredential("username@gmail.com", "passcode")
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.From = New Net.Mail.MailAddress("username@gmail.com")
                'Redirect all email when the member's email is not present in the database
                If ds.Tables(0).Rows(i).Item(5).ToString = "" Then
                    mail.To.Add("username@gmail.com")
                Else
                    mail.To.Add(ds.Tables(0).Rows(i).Item(5).ToString)
                End If
                mail.Subject = "India Foundaton of Metropolitan Princeton Membership Information"
                mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & "," & System.Environment.NewLine & System.Environment.NewLine &
                        "Welcome to the India Foundation of Metropolitan Princeton! " & System.Environment.NewLine &
                        "Please visit our official website, www.ifmpnj.org, to learn more about our organization and " &
                        "view upcoming events." & System.Environment.NewLine & System.Environment.NewLine &
                        "Your Membership Id Number is: " & ds.Tables(0).Rows(i).Item(0).ToString & System.Environment.NewLine &
                        "You can present this id number at any IFMP Event to speed up the check-in process." & System.Environment.NewLine & System.Environment.NewLine &
                        "Please send a response to ifmporg@gmail.com with the subject line ""Information Update""" &
                        " with updates if any of the information below is incorrect." & System.Environment.NewLine & "Any blank fields indicate that we do not have that information from you." &
                    System.Environment.NewLine & System.Environment.NewLine & "Your phone number is " & ds.Tables(0).Rows(i).Item(3) & System.Environment.NewLine &
                        "Your cell phone number is " & ds.Tables(0).Rows(i).Item(4).ToString & System.Environment.NewLine &
                        "Your work phone number is " & ds.Tables(0).Rows(0).Item(24).ToString & System.Environment.NewLine &
                        "The size of your family is " & ds.Tables(0).Rows(i).Item(8).ToString & System.Environment.NewLine &
                        "The number of children in your family is " & ds.Tables(0).Rows(i).Item(9).ToString & System.Environment.NewLine &
                        "The number of adults in your family is " & ds.Tables(0).Rows(i).Item(10).ToString & System.Environment.NewLine &
                        "Your membership status is " & ds.Tables(0).Rows(i).Item(11).ToString & System.Environment.NewLine &
                        "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(i).Item(17).ToString &
                        System.Environment.NewLine & ds.Tables(0).Rows(i).Item(19).ToString & ds.Tables(0).Rows(i).Item(18) &
                        " " & ds.Tables(0).Rows(i).Item(20).ToString & "If you membership is inactive please follow this link " & ds.Tables(0).Rows(i).Item(21).ToString & System.Environment.NewLine & System.Environment.NewLine &
                        "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                         "From," & System.Environment.NewLine &
                    "IFMP Admin"
                SmtpServer.EnableSsl = True
                SmtpServer.Send(mail)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            System.Threading.Thread.Sleep(5000)
        Next
        con.Close()
        MessageBox.Show("Emails Sent")
    End Sub

    ''Test code, no longer in use.
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Test.Click
    '    ' Create a folder named "inbox" under current directory
    '    ' to save the email retrieved.
    '    Dim curpath As String = Directory.GetCurrentDirectory()
    '    Dim mailbox As String = [String].Format("{0}\inbox", curpath)
    '    ' If the folder is not existed, create it.
    '    If Not Directory.Exists(mailbox) Then
    '        Directory.CreateDirectory(mailbox)
    '    End If
    '    ' Hotmail POP3 server is "pop3.live.com"
    '    Dim oServer As New MailServer("imap.gmail.com",
    '        "username@gmail.com", "passcode", ServerProtocol.Imap4)
    '    Dim oClient As New MailClient("TryIt")
    '    ' Enable SSL connection
    '    oServer.SSLConnection = True
    '    ' Set 995 port
    '    oServer.Port = 993
    '    Try
    '        oClient.Connect(oServer)
    '        Dim infos As MailInfo() = oClient.GetMailInfos()
    '        For i As Integer = 0 To infos.Length - 1
    '            Dim info As MailInfo = infos(i)
    '            Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
    '                    info.Index, info.Size, info.UIDL)
    '            ' Receive email from POP3 server
    '            Dim oMail As Mail = oClient.GetMail(info)
    '            Console.WriteLine("From: {0}", oMail.From.ToString())
    '            Console.WriteLine("Subject: {0}" & vbCr & vbLf, oMail.Subject)
    '            ' Generate an email file name based on date time.
    '            Dim d As System.DateTime = System.DateTime.Now
    '            Dim cur As New System.Globalization.CultureInfo("en-US")
    '            Dim sdate As String = d.ToString("yyyyMMddHHmmss", cur)
    '            Dim fileName As String = [String].Format("{0}\{1}{2}{3}.mht",
    '                 mailbox, sdate, d.Millisecond.ToString("d3"), i)
    '            ' Save email to local disk
    '            oMail.SaveAs(fileName, True)
    '            i = infos.Length - 1
    '        Next
    '        ' Quit and pure emails marked as deleted from Hotmail POP3 server.
    '        oClient.Quit()
    '    Catch ep As Exception
    '        MessageBox.Show(ep.Message)
    '    End Try
    'End Sub

    ''' <summary>
    ''' This function allows the user to see all nonmebers in their table view. However, since the
    ''' non-member functionality was never really used this shouldn't be called.
    ''' </summary>
    ''' <param name="sender">Sender</param>
    ''' <param name="e">Event</param>
    Private Sub ViewNonMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewNonMemberToolStripMenuItem.Click
        Dim connstring As String = con_string
        Dim query As String = "Select * from [NonMember]"
        Using connection As New SqlConnection(connstring)
            Dim sqlquery As New SqlDataAdapter(query, connection)
            Dim ds As New DataSet()
            connection.Open()
            sqlquery.Fill(ds, "non_member_table")
            connection.Close()
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "non_member_table"
        End Using
    End Sub

    Private Sub SendUpdateEmail_Click(sender As Object, e As EventArgs) 'Handles SendUpdateEmail.Click
        Dim message_result As DialogResult = MessageBox.Show(" Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
   MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [Id] = @ID"
        cmd.Parameters.AddWithValue("@ID", id_number)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        Dim i As Int32 = 0
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New _
            Net.NetworkCredential("username@gmail.com", "passcode")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New Net.Mail.MailAddress("username@gmail.com")
            'Redirect all email when the member's email is not present in the database
            If ds.Tables(0).Rows(i).Item(5).ToString = "" Then
                mail.To.Add("username@gmail.com")
            Else
                mail.To.Add(ds.Tables(0).Rows(i).Item(5).ToString)
            End If
            mail.Subject = "India Foundaton of Metropolitan Princeton Membership Information"
            mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & "," & System.Environment.NewLine & System.Environment.NewLine &
                    "Thank you for updating your information." & System.Environment.NewLine &
                    "Please keep this email as a record of your membership number and membership information. " & System.Environment.NewLine &
                    "Please visit our official website, www.ifmpnj.org, to learn more about our organization and view upcoming events." & System.Environment.NewLine & System.Environment.NewLine &
                    "Your Membership Id Number is: " & ds.Tables(0).Rows(i).Item(0).ToString & System.Environment.NewLine &
                    "You can present this id number at any IFMP Event to speed up the check-in process." & System.Environment.NewLine & System.Environment.NewLine &
                    "Please send a response to ifmpdb@gmail.com with the subject line ""Information Update""" &
                    " with updates if any of the information below is incorrect." & System.Environment.NewLine & "Any blank fields indicate that we do not have that information from you." &
                System.Environment.NewLine & System.Environment.NewLine & "Your phone number is " & ds.Tables(0).Rows(i).Item(3) & System.Environment.NewLine &
                    "Your cell phone number is " & ds.Tables(0).Rows(i).Item(4).ToString & System.Environment.NewLine &
                    "Your work phone number is " & ds.Tables(0).Rows(0).Item(24).ToString & System.Environment.NewLine &
                    "The size of your family is " & ds.Tables(0).Rows(i).Item(8).ToString & System.Environment.NewLine &
                    "The number of children in your family is " & ds.Tables(0).Rows(i).Item(9).ToString & System.Environment.NewLine &
                    "The number of adults in your family is " & ds.Tables(0).Rows(i).Item(10).ToString & System.Environment.NewLine &
                    "Your membership status is " & ds.Tables(0).Rows(i).Item(11).ToString & System.Environment.NewLine &
                    "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(i).Item(17).ToString & System.Environment.NewLine &
                    ds.Tables(0).Rows(i).Item(19).ToString &
                    " " & ds.Tables(0).Rows(i).Item(20).ToString & " " & ds.Tables(0).Rows(i).Item(21).ToString & System.Environment.NewLine & System.Environment.NewLine &
                    "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                     "From," & System.Environment.NewLine &
                "IFMP Admin"
            SmtpServer.EnableSsl = True
            SmtpServer.Send(mail)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
        MessageBox.Show("Email Sent")
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Transfer.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "update [Membership] set [Adult Check In]=[Adults], [Children Check In]=[Children]"
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''ADD _____ FUNCTION ''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    ''' <summary> Add Member
    ''' This function will fill in the member id correctly for use in the add member
    ''' form - sets it to the current greatest id + 1
    ''' </summary>
    Private Sub addmember()
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "select top 1 [Id] From [Membership] Order By [Id] DESC;"
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds2 As New DataSet()
        con.Open()
        cmd.ExecuteNonQuery()
        sqlquery.Fill(ds2, "Id_Table")
        con.Close()
        IDNumber.Text = ds2.Tables(0).Rows(0).Item(0) + 1
    End Sub
    ''' <summary>
    ''' Calculates the correct IDNumber then passes control to the add member form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddMemberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMemberToolStripMenuItem.Click
        addmember()
        Dim add_member As New AddMember
        add_member.ID = IDNumber.Text
        add_member.admin_status = True
        add_member.con_string = con_string
        add_member.Show()
        Me.Close()
    End Sub

    ''' <summary> Go to Add Channel
    ''' Passes form control to the Add Channel form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddChannelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddChannelToolStripMenuItem.Click
        Dim f1 As New Add_Channel
        f1.con_string = con_string
        f1.admin_status = admin_status
        f1.id_public = id_number
        f1.Show()
        Me.Close()
    End Sub

    ''' <summary> Go to Add Event
    ''' Passes form control to the Add Event form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddEventToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddEventToolStripMenuItem.Click
        Dim f1 As New Add_Event
        f1.con_string = con_string
        f1.admin_status = admin_status
        f1.id_public = id_number
        f1.Show()
        Me.Close()
    End Sub

    ''' <summary> Go to Add Method
    ''' Passes form control to the Add Event form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddMethodToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMethodToolStripMenuItem.Click
        Dim f1 As New Add_Method
        f1.con_string = con_string
        f1.admin_status = admin_status
        f1.id_public = id_number
        f1.Show()
        Me.Close()
    End Sub

    Private Sub Test2_Click(sender As Object, e As EventArgs) Handles Test2.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Dim cmd2 As New SqlCommand()
        Dim sqlquery As New SqlDataAdapter(cmd2)
        Dim ds As New DataSet()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "insert into [Child] ([Id],[Name]) Values (@Id,@Name)"
        cmd.Parameters.AddWithValue("@Id", id_number)
        cmd.Parameters.AddWithValue("@Name", child_1)
        cmd2.CommandText = "select * from [Child 1]"
        cmd2.Connection = con
        con.Open()
        cmd.ExecuteNonQuery()
        cmd2.ExecuteNonQuery()
        con.Close()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Delete from [Child] Where [Id] = @id"
        cmd.Parameters.AddWithValue("@Id", id_number)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub GoToChild(sender As Object, e As EventArgs) 'Handles GoToChild.Click
        If IDNumber.Text = "" Then
            MessageBox.Show("Please enter an Id Number")
            Exit Sub
        End If
        Dim f4 As New ChildView
        f4.con_string = con_string
        f4.admin_status = admin_status
        f4.member_id = id_number
        f4.last_name = last_name
        f4.Show()
        Me.Close()
    End Sub

    Private Sub GoToEvent(sender As Object, e As EventArgs)
        Dim form As New EventView
        form.con_string = con_string
        form.admin_status = admin_status
        form.member_id = id_number
        form.Show()
        Me.Close()
    End Sub

    Private Sub RSVPNoCheckInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RSVPNoCheckInToolStripMenuItem.Click
        SaveFileDialog2.InitialDirectory = "c:\data\"
        SaveFileDialog2.Filter = "Excel Files (*.xlsx)|*.xlsx|All files(*.*)|*.*"
        SaveFileDialog2.FilterIndex = 1
        SaveFileDialog2.RestoreDirectory = True
        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            If xlApp Is Nothing Then
                MessageBox.Show("Excel is not properly installed!!")
                Return
            End If
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            Dim cmd As New SqlCommand()
            Dim con As New SqlConnection()
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Select * from [Membership] where [Picnic RSVP]=@RSVP and [Check In Status]=@CheckIn"
            cmd.Parameters.AddWithValue("@RSVP", "Yes")
            cmd.Parameters.AddWithValue("@CheckIn", "No")
            Dim sqlquery As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            con.Open()
            sqlquery.Fill(ds, "check_table")
            xlWorkSheet.Cells(1, 1).Value = "Id"
            xlWorkSheet.Cells(1, 2).Value = "First Name"
            xlWorkSheet.Cells(1, 3).Value = "Last Name"
            xlWorkSheet.Cells(1, 4).Value = "Phone Number"
            xlWorkSheet.Cells(1, 5).value = "Cell Phone Number"
            xlWorkSheet.Cells(1, 6).value = "Email Address"
            xlWorkSheet.Cells(1, 7).value = "Picnic RSVP"
            xlWorkSheet.Cells(1, 8).value = "Check In Status"
            xlWorkSheet.Cells(1, 9).value = "Family Size"
            xlWorkSheet.Cells(1, 10).value = "Children"
            xlWorkSheet.Cells(1, 11).value = "Adults"
            xlWorkSheet.Cells(1, 12).value = "Membership Status"
            xlWorkSheet.Cells(1, 13).value = "Event Signed Up At"
            xlWorkSheet.Cells(1, 14).value = "Payment Method"
            xlWorkSheet.Cells(1, 15).value = "Channel"
            xlWorkSheet.Cells(1, 16).value = "Note"
            xlWorkSheet.Cells(1, 17).value = "Party Size"
            xlWorkSheet.Cells(1, 18).value = "Line 1"
            xlWorkSheet.Cells(1, 19).value = "Line 2"
            xlWorkSheet.Cells(1, 20).value = "City"
            xlWorkSheet.Cells(1, 21).value = "State"
            xlWorkSheet.Cells(1, 22).value = "Zip"
            xlWorkSheet.Cells(1, 23).value = "Country"
            xlWorkSheet.Cells(1, 24).value = "Spouse Name"
            xlWorkSheet.Cells(1, 25).value = "Adults Checked In"
            xlWorkSheet.Cells(1, 26).value = "Children Checked In"
            xlWorkSheet.Cells(1, 27).value = "Work Phone"
            xlWorkSheet.Cells(1, 28).value = "Date Signed Up"
            xlWorkSheet.Celss(1, 29).value = "Unpaid Dues"
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "check_table"
            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    xlWorkSheet.Cells(i + 2, j + 1) =
                ds.Tables(0).Rows(i).Item(j).ToString()
                Next
            Next
            con.Close()
            xlWorkBook.SaveAs(SaveFileDialog2.FileName)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            MessageBox.Show("Excel file created , you can find the file " & SaveFileDialog2.FileName & " .")
        End If
    End Sub

    Private Sub SizeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SizeToolStripMenuItem.Click
        Dim resize1 As New Resize
        resize1.form_number = 1
        resize1.admin_status = admin_status
        resize1.con_string = con_string
        resize1.Show()
        Me.Close()
    End Sub

    Private Sub ToAllToolStripMenuItem_Click(sender As Object, e As EventArgs)
        SendMail_Click(sender, e)
    End Sub

    'Admin Only - Send Mail Through STMP/Gmail To One Member
    Private Sub InformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformationToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show(" Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
      MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [Id] = @ID"
        cmd.Parameters.AddWithValue("@ID", id_number)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        Dim i As Int32 = 0
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New _
            Net.NetworkCredential("username@gmail.com", "passcode")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()

            mail.From = New Net.Mail.MailAddress("username@gmail.com")
            'Redirect all email when the member's email is not present in the database
            If ds.Tables(0).Rows(0).Item(5).ToString = "" Then
                mail.To.Add("username@gmail.com")
            Else
                mail.To.Add(ds.Tables(0).Rows(0).Item(5).ToString)
            End If
            mail.Subject = "India Foundaton of Metropolitan Princeton Membership Information"
            mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & "," & System.Environment.NewLine & System.Environment.NewLine &
                    "Please keep this email as a record of your membership number and membership information. " & System.Environment.NewLine &
                    "Please visit our official website, www.ifmpnj.org, to learn more about our organization and view upcoming events." & System.Environment.NewLine & System.Environment.NewLine &
                    "Your Membership Id Number is: " & ds.Tables(0).Rows(i).Item(0).ToString & System.Environment.NewLine &
                    "You can present this id number at any IFMP Event to speed up the check-in process." & System.Environment.NewLine & System.Environment.NewLine &
                    "Please send a response to ifmpdb@gmail.com with the subject line ""Information Update""" &
                    " with updates if any of the information below is incorrect." & System.Environment.NewLine & "Any blank fields indicate that we do not have that information from you." &
                System.Environment.NewLine & System.Environment.NewLine & "Your phone number is " & ds.Tables(0).Rows(i).Item(3) & System.Environment.NewLine &
                    "Your cell phone number is " & ds.Tables(0).Rows(i).Item(4).ToString & System.Environment.NewLine &
                    "Your work phone number is " & ds.Tables(0).Rows(0).Item(24).ToString & System.Environment.NewLine &
                    "The size of your family is " & ds.Tables(0).Rows(i).Item(8).ToString & System.Environment.NewLine &
                    "The number of children in your family is " & ds.Tables(0).Rows(i).Item(9).ToString & System.Environment.NewLine &
                    "The number of adults in your family is " & ds.Tables(0).Rows(i).Item(10).ToString & System.Environment.NewLine &
                    "Your membership status is " & ds.Tables(0).Rows(i).Item(11).ToString & System.Environment.NewLine &
                    "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(i).Item(17).ToString & System.Environment.NewLine &
                    ds.Tables(0).Rows(i).Item(19).ToString &
                    " " & ds.Tables(0).Rows(i).Item(20).ToString & " " & ds.Tables(0).Rows(i).Item(21).ToString & System.Environment.NewLine & System.Environment.NewLine &
                    "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                     "From," & System.Environment.NewLine &
                "IFMP Admin"
            SmtpServer.EnableSsl = True
            SmtpServer.Send(mail)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
        MessageBox.Show("Email Sent")
    End Sub

    Private Sub WelcomeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles WelcomeToolStripMenuItem.Click
        SendMail2_Click(sender, e)
    End Sub

    Private Sub ChildAdultViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChildAdultViewToolStripMenuItem.Click
        GoToChild(sender, e)
    End Sub

    Private Sub EventViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EventViewToolStripMenuItem.Click
        GoToEvent(sender, e)
    End Sub

    Private Sub CheckInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckInToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Update [Membership] set [Check In Status]=@CheckIn"
        cmd.Parameters.AddWithValue("@CheckIn", "No")
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Action Complete")
        Reset_Click(sender, e)
    End Sub

    Private Sub RSVPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RSVPToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Update [Membership] set [Picnic RSVP]=@RSVP"
        cmd.Parameters.AddWithValue("@RSVP", "No")
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Action Complete")
        Reset_Click(sender, e)
    End Sub

    Private Sub LastNameSortToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LastNameSortToolStripMenuItem.Click
        SaveFileDialog2.InitialDirectory = "c:\data\"
        SaveFileDialog2.Filter = "Excel Files (*.xlsx)|*.xlsx|All files(*.*)|*.*"
        SaveFileDialog2.FilterIndex = 1
        SaveFileDialog2.RestoreDirectory = True
        If SaveFileDialog2.ShowDialog() = DialogResult.OK Then
            Dim xlApp As Excel.Application = New Microsoft.Office.Interop.Excel.Application()
            If xlApp Is Nothing Then
                MessageBox.Show("Excel is not properly installed!!")
                Return
            End If
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            Dim cmd As New SqlCommand()
            Dim con As New SqlConnection()
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Select [Id],[First Name],[Last Name], [Email Address], [Picnic RSVP], [Check In Status], [Family Size], [Children], [Adults], [City] from [Membership] where [Membership Status] = 'Active' "
            cmd.Parameters.AddWithValue("@RSVP", "Yes")
            cmd.Parameters.AddWithValue("@CheckIn", "No")
            'cmd.ExecuteNonQuery()
            Dim sqlquery As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            con.Open()
            sqlquery.Fill(ds, "check_table")
            xlWorkSheet.Cells(1, 1).Value = "Id"
            xlWorkSheet.Cells(1, 2).Value = "First Name"
            xlWorkSheet.Cells(1, 3).Value = "Last Name"
            xlWorkSheet.Cells(1, 4).value = "Email Address"
            xlWorkSheet.Cells(1, 5).value = "Picnic RSVP"
            xlWorkSheet.Cells(1, 6).value = "Check In Status"
            xlWorkSheet.Cells(1, 7).value = "Family Size"
            xlWorkSheet.Cells(1, 8).value = "Children"
            xlWorkSheet.Cells(1, 9).value = "Adults"
            xlWorkSheet.Cells(1, 10).value = "City"
            DataGridView1.DataSource = ds
            DataGridView1.DataMember = "check_table"
            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    xlWorkSheet.Cells(i + 2, j + 1) =
                ds.Tables(0).Rows(i).Item(j).ToString()
                Next
            Next
            con.Close()
            xlWorkBook.SaveAs(SaveFileDialog2.FileName)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            MessageBox.Show("Excel file created , you can find the file " & SaveFileDialog2.FileName & " .")
        End If
    End Sub

    Private Sub Picnic2015ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Picnic2015ToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Update [Membership] set [Date Signed Up]=@Date where [Event Signed Up At]=@Event "
        Dim emptyDateTime As New DateTime(2015, 8, 9, 0, 1, 0)
        cmd.Parameters.AddWithValue("@Date", emptyDateTime)
        cmd.Parameters.AddWithValue("@Event", "Picnic 2015")
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        Reset_Click(sender, e)
    End Sub

    Private Sub GoldenGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GoldenGroupToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Update [Membership] set [Date Signed Up]=@Date where [Event Signed Up At]=@Event "
        Dim emptyDateTime As New DateTime(2015, 5, 17, 0, 1, 0)
        cmd.Parameters.AddWithValue("@Date", emptyDateTime)
        cmd.Parameters.AddWithValue("@Event", "Golden Group Launch Event")
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        Reset_Click(sender, e)
    End Sub

    Private Sub Navaratri2015ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Navaratri2015ToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Update [Membership] set [Date Signed Up]=@Date where [Event Signed Up At]=@Event "
        Dim emptyDateTime As New DateTime(2015, 10, 8, 0, 1, 0)
        cmd.Parameters.AddWithValue("@Date", emptyDateTime)
        cmd.Parameters.AddWithValue("@Event", "Navratri 2015")
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        Reset_Click(sender, e)
    End Sub

    Private Sub AnnualShowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnnualShowToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Update [Membership] set [Date Signed Up]=@Date where [Event Signed Up At]=@Event "
        Dim emptyDateTime As New DateTime(2015, 12, 19, 0, 1, 0)
        cmd.Parameters.AddWithValue("@Date", emptyDateTime)
        cmd.Parameters.AddWithValue("@Event", "Annual Show 2015")
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        Reset_Click(sender, e)
    End Sub

    Private Sub OldStyleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OldStyleToolStripMenuItem.Click
        My.Settings.TableStyle = "None"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        My.Settings.TableStyle = "All"
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Private Sub RemoveMember_Click_1(sender As Object, e As EventArgs) Handles RemoveMember.Click
        RemoveMember_Click(sender, e)
    End Sub

    Private Sub OnToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OnToolStripMenuItem.Click
        My.Settings.IdThroughForms = "Yes"
    End Sub

    Private Sub OffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OffToolStripMenuItem.Click
        My.Settings.IdThroughForms = "No"
    End Sub
    'Sends email to all inactive memebrs asking them to renew their membership
    Private Sub RenewMembershipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RenewMembershipToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show("This option will send an email to multiple people. Are you sure you wish to continue?", "Critical Warning", MessageBoxButtons.YesNo,
        MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [Membership Status] = @Status"
        cmd.Parameters.AddWithValue("@Status", "Inactive")
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Try
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.Credentials = New _
                Net.NetworkCredential("username@gmail.com", "passcode")
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.IsBodyHtml = True
                mail.From = New Net.Mail.MailAddress("username@gmail.com")
                'Redirect all email when the member's email is not present in the database
                If ds.Tables(0).Rows(i).Item(5).ToString = "" Then
                    mail.To.Add("username@gmail.com")
                Else
                    mail.To.Add(ds.Tables(0).Rows(i).Item(5).ToString)
                End If
                mail.Subject = "India Foundation of Metropolitan Princeton - Renew Membership"
                mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & "," & "<br>" & "<br>" &
                    "To renew your IFMP membership, please click on the following link: " &
                    "<a href=""http://www.ifmpnj.org/id19.html"""">I want to sign up for IFMP Membership now. </a>" &
                    "Annual membership dues are $50 For a family Of four. HOLI & PICNIC events are FREE for members and members get discounted prices for ticketed events." &
                    "Have a nice day!" & "<br>" & "From," & "<br>" & "IFMP Admin"
                SmtpServer.EnableSsl = True
                SmtpServer.Send(mail)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            System.Threading.Thread.Sleep(5000)
        Next
        con.Close()
        MessageBox.Show("Email Sent")
    End Sub

    Private Sub FromExcelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FromExcelToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show("Warning: This will change the DateTime in the database and cannot be undone." &
  " Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
  MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        OpenFileDialog5.InitialDirectory = "c:\data\"
        OpenFileDialog5.Filter = "Excel Files (*.xlsx)|*.xlsx|(*.csv)|*.csv|All files(*.*)|*.*"
        OpenFileDialog5.FilterIndex = 2
        OpenFileDialog5.RestoreDirectory = True
        If OpenFileDialog5.ShowDialog() = DialogResult.OK Then
            Reset_Click(sender, e)
            Dim file_name As String = OpenFileDialog5.FileName
            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim x As Int16 = 2
            xlApp = New Excel.ApplicationClass
            xlWorkBook = xlApp.Workbooks.Open(file_name)
            xlWorkSheet = xlWorkBook.Worksheets("2015-PayPal-SignUps")
            Do Until xlWorkSheet.Cells(x, 1).text.ToString = ""
                Dim date_new As String
                Dim time_new As String
                Dim email_new As String
                date_new = (xlWorkSheet.Cells(x, 1).value)
                time_new = xlWorkSheet.Cells(x, 2).text
                email_new = xlWorkSheet.Cells(x, 10).text
                Dim final_string As String
                final_string = date_new + " " + time_new
                Dim datetime_new As DateTime
                datetime_new = DateTime.Parse(final_string)
                Try
                    Dim con As New SqlConnection()
                    Dim cmd2 As New SqlCommand()
                    con.ConnectionString = con_string
                    con.Open()
                    cmd2.Connection = con
                    cmd2.CommandText = "Update [membership] Set [Date Signed Up]=@Date Where [Email Address]=@Email;"
                    cmd2.Parameters.AddWithValue("@Email", email_new)
                    cmd2.Parameters.AddWithValue("@Date", datetime_new)
                    cmd2.ExecuteNonQuery()
                    con.Close()
                    ViewDatabase_Click(sender, e)
                Catch ex As Exception
                    MessageBox.Show("Error:" & ex.Message)
                Finally
                    x += 1
                End Try
            Loop
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        End If
    End Sub

    Private Sub ConfirmationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConfirmationToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show("Are you sure you wish to continue?", "Critical Warning", MessageBoxButtons.YesNo,
MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        OpenFileDialog4.InitialDirectory = "c:\data\"
        OpenFileDialog4.Filter = "Text Files (*.txt)|*.txt|All files(*.*)|*.*"
        OpenFileDialog4.FilterIndex = 1
        OpenFileDialog4.RestoreDirectory = True
        If OpenFileDialog4.ShowDialog() = DialogResult.OK Then
            Dim file_name As String = OpenFileDialog4.FileName
            Using sr As New StreamReader(file_name)
                Dim line As String
                line = sr.ReadToEnd()
                Dim cmd As New SqlCommand()
                Dim con As New SqlConnection()
                con.ConnectionString = con_string
                cmd.Connection = con
                cmd.CommandText = "Select * from [Membership] where [Id] > @ID"
                cmd.Parameters.AddWithValue("@ID", 250)
                Dim sqlquery As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                con.Open()
                sqlquery.Fill(ds, "Membership_Table")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "Membership_Table"
                For i = 0 To 1
                    Try
                        Dim SmtpServer As New SmtpClient()
                        Dim mail As New MailMessage()
                        SmtpServer.UseDefaultCredentials = False
                        SmtpServer.Credentials = New _
                        Net.NetworkCredential("username@gmail.com", "passcode")
                        SmtpServer.Port = 587
                        SmtpServer.Host = "smtp.gmail.com"
                        mail = New MailMessage()
                        mail.From = New Net.Mail.MailAddress("username@gmail.com")
                        mail.To.Add("username@gmail.com")
                        mail.Subject = "Acknowledge Receipt of Membership Difference Dues for 2016 -- Your membership will expire 1 week before Annual Cultural Show 2016"
                        mail.Body = line
                        SmtpServer.EnableSsl = True
                        SmtpServer.Send(mail)
                        MessageBox.Show("Email Sent")
                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                    System.Threading.Thread.Sleep(5000)
                Next
                con.Close()
            End Using
        End If
    End Sub

    Private Sub MembershipDifferenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MembershipDifferenceToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [Id] = @ID"
        cmd.Parameters.AddWithValue("@ID", id_number)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Try
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.Credentials = New _
                Net.NetworkCredential("username@gmail.com", "passcode")
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.From = New Net.Mail.MailAddress("username@gmail.com")
                'Redirect all email when the member's email is not present in the database
                If ds.Tables(0).Rows(i).Item(5).ToString = "" Then
                    mail.To.Add("username@gmail.com")
                Else
                    mail.To.Add(ds.Tables(0).Rows(i).Item(5).ToString)
                End If
                mail.Subject = "Acknowledge Receipt of Membership Difference Dues for 2016 -- Your membership will expire 1 week before Annual Cultural Show 2016"
                mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & "," & System.Environment.NewLine & System.Environment.NewLine &
                        "This is to acknowledge receipt of $10 the difference in 2016 & 2015 membership dues received before last year's Annual Cultural Show." & System.Environment.NewLine &
                        "Your membership will expire one week before the next Annual Cultural Show in 2016 as it follows the Annual Show to Annual Show period of validity (Nov-Dec) and not the calendar year (Jan-Dec). " & System.Environment.NewLine &
                        "Please keep this email as a record of your membership number and membership information" & System.Environment.NewLine & System.Environment.NewLine &
                        "Please visit our official website, www.ifmpnj.org, to learn more about our organization and view upcoming events." & System.Environment.NewLine & System.Environment.NewLine &
                        "Your Membership Id Number is: " & ds.Tables(0).Rows(i).Item(0).ToString & System.Environment.NewLine & System.Environment.NewLine &
                        "You can present this id number at any IFMP Event  " & System.Environment.NewLine & System.Environment.NewLine &
                        "Please send a response To ifmpdb@gmail.com With the subject line ""Information Update""" &
                        " with updates If any of the information below is incorrect." & System.Environment.NewLine & System.Environment.NewLine & "Any blank fields indicate that we do not have that information from you." &
                    System.Environment.NewLine & System.Environment.NewLine & "Your phone number is " & ds.Tables(0).Rows(i).Item(3) & System.Environment.NewLine &
                        "Your cell phone number is " & ds.Tables(0).Rows(i).Item(4).ToString & System.Environment.NewLine &
                        "Your work phone number is " & ds.Tables(0).Rows(0).Item(24).ToString & System.Environment.NewLine &
                        "The size Of your family is " & ds.Tables(0).Rows(i).Item(8).ToString & System.Environment.NewLine &
                        "The number of children in your family is " & ds.Tables(0).Rows(i).Item(9).ToString & System.Environment.NewLine &
                        "The number of adults in your family is " & ds.Tables(0).Rows(i).Item(10).ToString & System.Environment.NewLine &
                        "Your membership status is " & ds.Tables(0).Rows(i).Item(11).ToString & System.Environment.NewLine &
                        "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(i).Item(17).ToString & System.Environment.NewLine &
                        ds.Tables(0).Rows(i).Item(19).ToString &
                        " " & ds.Tables(0).Rows(i).Item(20).ToString & " " & ds.Tables(0).Rows(i).Item(21).ToString & System.Environment.NewLine & System.Environment.NewLine &
                        "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                         "From," & System.Environment.NewLine &
                    "IFMP Admin"
                SmtpServer.EnableSsl = True
                SmtpServer.Send(mail)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            System.Threading.Thread.Sleep(5000)
        Next
        con.Close()
        MessageBox.Show("Email Sent")
    End Sub

    Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomToolStripMenuItem.Click
        If IDNumber.Text = "" Then
            MessageBox.Show("Please enter an Id Number")
            Exit Sub
        End If
        Dim date_time_form As New Date_Time
        date_time_form.con_string = con_string
        date_time_form.id_int = id_number
        date_time_form.Show()
        Me.Close()
    End Sub

    Private Sub ViewAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAllToolStripMenuItem.Click
        My.Settings.ViewAll = True
        ViewDatabase_Click(sender, e)
    End Sub

    Private Sub ViewCurrentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCurrentToolStripMenuItem.Click
        My.Settings.ViewAll = False
        ViewDatabase_Click(sender, e)
    End Sub

    Private Sub MembershipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MembershipToolStripMenuItem.Click
        'Method that worked previously
        'Dim cmd As New SqlCommand()
        'Dim con As New SqlConnection()
        'con.ConnectionString = con_string
        'cmd.Connection = con
        'cmd.CommandText = "Update [Membership] set [Membership Status]='Inactive' where [Id] < 212"
        'con.Open()
        'cmd.ExecuteNonQuery()
        'con.Close()
        'MessageBox.Show("Action Complete")
        'Reset_Click(sender, e)
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership]"
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        For i = 1 To 211
            Dim cmd2 As New SqlCommand()
            Dim con2 As New SqlConnection()
            con2.ConnectionString = con_string
            cmd2.Connection = con
            cmd2.CommandText = "Update [Membership] Set [Membership Status]='Inactive' where [Id]=@id"
            cmd2.Parameters.AddWithValue("@id", i)
            con2.Open()
            cmd2.ExecuteNonQuery()
            con2.Close()
        Next
        con.Close()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        Dim help_form As New Manual
        help_form.admin_status = admin_status
        help_form.id_public = id_public
        help_form.con_string = con_string
        help_form.Show()
        Me.Close()
    End Sub

    'Pay membership difference email
    'Update the link with something they can pay with
    Private Sub PayMembershipDifferenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayMembershipDifferenceToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [ID] = @id"
        cmd.Parameters.AddWithValue("@id", id_number)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Try
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.Credentials = New _
                Net.NetworkCredential("username@gmail.com", "passcode")
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.IsBodyHtml = True
                mail.From = New Net.Mail.MailAddress("username@gmail.com")
                'Redirect all email when the member's email is not present in the database
                If ds.Tables(0).Rows(i).Item(5).ToString = "" Then
                    mail.To.Add("username@gmail.com")
                Else
                    mail.To.Add(ds.Tables(0).Rows(i).Item(5).ToString)
                End If
                mail.Subject = "India Foundation Of Metropolitan Princeton - Membership Dues"
                mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & ", " & " < BR > " & " < BR" &
                "You are receiving this email since you became IFMP members In Nov/Dec 2015 For your children To participate free In the Annual Cultural Show. We had changed our membership rule To extend your membership into 2016 until the Next Annual Cultural Show Or first week Of December 2016, provided you pay any increase in membership dues for 2016. As you know we have increased the annual membership fees for a family of four to $50 And you can add 2 additional members to your family membership at $5 per person if you have more than 4 members in the family. " &
                "<br>" & "Below are the additional membership dues for those who became members at the annual show based on number of members in the family." &
                "<ul><li>For a Family of 4:   $10</li><li>For a Family of 5: $15</li><li>For a Family of 6: $20</li></ul>" &
                "If you have already extended the membership by paying the difference in the membership dues for 2016 vs 2015 at our Annual Show last year, we thank you and will see you at an upcoming event. If you have not had the opportunity yet, please click the link below and do it at the earliest." &
                "<a href=""http://www.ifmpnj.org/id19.html"""">I want to pay my IFMP membership difference dues now. </a>" &
                "Thank you" & "<br>" & "IFMP Committee" & "<br>" & "609-297-7116" & "<br>" & "ifmp@ifmpnj.org"
                SmtpServer.EnableSsl = True
                SmtpServer.Send(mail)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            System.Threading.Thread.Sleep(5000)
        Next
        con.Close()
        MessageBox.Show("Email Sent")
    End Sub

    'Send Mail All - Send Mail Through STMP/Gmail To All Active Members
    Private Sub MembershipInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MembershipInfoToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show(" Are you sure you wish continue? This will send an email to all IFMP Members", "Critical Warning", MessageBoxButtons.YesNo,
   MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership]  where [Membership Status] = @Membership"
        cmd.Parameters.AddWithValue("@Membership", "Active")
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        For i = 0 To ds.Tables(0).Rows.Count - 1
            Try
                Dim SmtpServer As New SmtpClient()
                Dim mail As New MailMessage()
                SmtpServer.Credentials = New _
                Net.NetworkCredential("username@gmail.com", "passcode")
                SmtpServer.Port = 587
                SmtpServer.Host = "smtp.gmail.com"
                mail = New MailMessage()
                mail.From = New Net.Mail.MailAddress("username@gmail.com")
                'Redirect all email when the member's email is not present in the database
                If ds.Tables(0).Rows(i).Item(5).ToString = "" Then
                    mail.To.Add("username@gmail.com")
                Else
                    mail.To.Add(ds.Tables(0).Rows(i).Item(5).ToString)
                End If
                mail.Subject = "India Foundaton of Metropolitan Princeton Membership Information"
                mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & "," & System.Environment.NewLine & System.Environment.NewLine &
                        "This email is to remind you of your India Foundation of Metropolitan Princeton membership information. " & System.Environment.NewLine &
                        "Please visit our official website, www.ifmpnj.org, to learn more about our organization and " &
                        "view upcoming events." & System.Environment.NewLine & System.Environment.NewLine &
                        "Your Membership Id Number is: " & ds.Tables(0).Rows(i).Item(0).ToString & System.Environment.NewLine &
                        "You can present this id number at any IFMP Event to speed up the check-in process." & System.Environment.NewLine & System.Environment.NewLine &
                        "Please send a response to ifmporg@gmail.com with the subject line ""Information Update""" &
                        " with updates if any of the information below is incorrect." & System.Environment.NewLine & "Any blank fields indicate that we do not have that information from you." &
                    System.Environment.NewLine & System.Environment.NewLine & "Your phone number is " & ds.Tables(0).Rows(i).Item(3) & System.Environment.NewLine &
                        "Your cell phone number is " & ds.Tables(0).Rows(i).Item(4).ToString & System.Environment.NewLine &
                        "Your work phone number is " & ds.Tables(0).Rows(0).Item(24).ToString & System.Environment.NewLine &
                        "The size of your family is " & ds.Tables(0).Rows(i).Item(8).ToString & System.Environment.NewLine &
                        "The number of children in your family is " & ds.Tables(0).Rows(i).Item(9).ToString & System.Environment.NewLine &
                        "The number of adults in your family is " & ds.Tables(0).Rows(i).Item(10).ToString & System.Environment.NewLine &
                        "Your membership status is " & ds.Tables(0).Rows(i).Item(11).ToString & System.Environment.NewLine &
                        "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(i).Item(17).ToString &
                        System.Environment.NewLine & ds.Tables(0).Rows(i).Item(19).ToString & ds.Tables(0).Rows(i).Item(18) &
                        " " & ds.Tables(0).Rows(i).Item(20).ToString &
                        "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                         "From," & System.Environment.NewLine &
                    "IFMP Admin"
                SmtpServer.EnableSsl = True
                SmtpServer.Send(mail)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
            System.Threading.Thread.Sleep(5000)
        Next
        con.Close()
        MessageBox.Show("Emails Sent")
    End Sub

    ''' <summary> Membership Info to Single Member Email Menu Item.
    ''' Sends an email contaning the informaiton currently stored in the database about a specific member
    ''' based on their ID to that member based on the email address they have stored in the database. If the
    ''' email is empty it will send the email to adeetp@gmail.com and then efforts should be made to get the 
    ''' email for that member.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MembershipInfoToSingleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MembershipInfoToSingleToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show(" Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [Id] = @ID"
        cmd.Parameters.AddWithValue("@ID", id_number)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Membership_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Membership_Table"
        Dim i As Int32 = 0
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New _
            Net.NetworkCredential("username@gmail.com", "passcode")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"
            mail = New MailMessage()
            mail.From = New Net.Mail.MailAddress("username@gmail.com")
            'Redirect all email when the member's email is not present in the database
            If ds.Tables(0).Rows(i).Item(5).ToString = "" Then
                mail.To.Add("username@gmail.com")
            Else
                mail.To.Add(ds.Tables(0).Rows(i).Item(5).ToString)
            End If
            mail.Subject = "India Foundaton of Metropolitan Princeton Membership Information"
            mail.Body = "Dear " & ds.Tables(0).Rows(i).Item(1).ToString & " " & ds.Tables(0).Rows(i).Item(2).ToString & "," & System.Environment.NewLine & System.Environment.NewLine &
                    "Please keep this email as a record of your membership number and membership information. " & System.Environment.NewLine &
                    "Please visit our official website, www.ifmpnj.org, to learn more about our organization and view upcoming events." & System.Environment.NewLine & System.Environment.NewLine &
                    "Your Membership Id Number is: " & ds.Tables(0).Rows(i).Item(0).ToString & System.Environment.NewLine &
                    "You can present this id number at any IFMP Event to speed up the check-in process." & System.Environment.NewLine & System.Environment.NewLine &
                    "Please send a response to ifmpdb@gmail.com with the subject line ""Information Update""" &
                    " with updates if any of the information below is incorrect." & System.Environment.NewLine & "Any blank fields indicate that we do not have that information from you." &
                System.Environment.NewLine & System.Environment.NewLine & "Your phone number is " & ds.Tables(0).Rows(i).Item(3) & System.Environment.NewLine &
                    "Your cell phone number is " & ds.Tables(0).Rows(i).Item(4).ToString & System.Environment.NewLine &
                    "Your work phone number is " & ds.Tables(0).Rows(0).Item(24).ToString & System.Environment.NewLine &
                    "The size of your family is " & ds.Tables(0).Rows(i).Item(8).ToString & System.Environment.NewLine &
                    "The number of children in your family is " & ds.Tables(0).Rows(i).Item(9).ToString & System.Environment.NewLine &
                    "The number of adults in your family is " & ds.Tables(0).Rows(i).Item(10).ToString & System.Environment.NewLine &
                    "Your membership status is " & ds.Tables(0).Rows(i).Item(11).ToString & System.Environment.NewLine &
                    "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(i).Item(17).ToString & System.Environment.NewLine &
                    ds.Tables(0).Rows(i).Item(19).ToString &
                    " " & ds.Tables(0).Rows(i).Item(20).ToString & " " & ds.Tables(0).Rows(i).Item(21).ToString & System.Environment.NewLine & System.Environment.NewLine &
                    "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                     "From," & System.Environment.NewLine &
                "IFMP Admin"
            SmtpServer.EnableSsl = True
            SmtpServer.Send(mail)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
        MessageBox.Show("Email Sent")
    End Sub

    ''' <summary> Set Default Event Menu Item
    ''' Updates the default event field in the defaults table to the currently selected value in EventBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DefaultEventToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultEventToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show("This will set the default event on all computers using this application to the event that is currently selected. Would you like to continue?", "Warning", MessageBoxButtons.YesNo,
           MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Update [Defaults] set [Default Event] = @DefaultEvent"
        cmd.Parameters.AddWithValue("@DefaultEvent", EventBox.SelectedValue)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    ''' <summary> Set Default Channel Menu Item.
    ''' Updates the default channel field in the defaults table to the currently selected value in ChannelBox.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ChannelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChannelToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show("This will set the default channel on all computers using this application to the event that is currently selected. Would you like to continue?", "Warning", MessageBoxButtons.YesNo,
             MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Update [Defaults] set [Default Channel] = @DefaultChannel"
        cmd.Parameters.AddWithValue("@DefaultChannel", ChannelBox.SelectedValue)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    ''' <summary> Set Default Payment Menu Item.
    ''' Updates the default payment field in the defaults table to the currently selected value in PaymentMethod.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub PaymentMethodToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentMethodToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show("This will set the default payment method on all computers using this application to the event that is currently selected. Would you like to continue?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Update [Defaults] set [Default Payment] = @DefaultPayment"
        cmd.Parameters.AddWithValue("@DefaultPayment", PaymentMethod.SelectedValue)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub LoadRSVP852016ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadRSVP852016ToolStripMenuItem.Click
        Dim message_result As DialogResult = MessageBox.Show("warning: this will overwrite any existing database you have established." &
   " are you sure you wish continue?", "critical warning", MessageBoxButtons.YesNo,
   MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        OpenFileDialog1.InitialDirectory = "c:\data\"
        OpenFileDialog1.Filter = "excel files (*.xlsx)|*.xlsx|(*.csv)|*.csv|all files(*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            'dim sr as new system.io.streamreader(openfiledialog1.filename)
            Reset_Click(sender, e)
            Dim file_name As String = OpenFileDialog1.FileName
            Dim xlapp As Excel.Application
            Dim xlworkbook As Excel.Workbook
            Dim xlworksheet As Excel.Worksheet
            Dim x As Int16 = 2
            xlapp = New Excel.ApplicationClass
            xlworkbook = xlapp.Workbooks.Open(file_name)
            xlworksheet = xlworkbook.Worksheets("Form Responses 1")
            Dim adults_string As String
            Dim child_string As String
            Do Until xlworksheet.Cells(x, 1).text.ToString = ""
                email_address = xlworksheet.Cells(x, 3).text
                adults_string = xlworksheet.Cells(x, 5).text
                child_string = xlworksheet.Cells(x, 6).text
                Dim temp As Integer
                temp = Convert.ToInt32(adults_string) + Convert.ToInt32(child_string)
                Dim party_string As String = Convert.ToString(temp)
                Try
                    Dim cmd As New SqlCommand()
                    Dim con As New SqlConnection()
                    con.ConnectionString = con_string
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "update membership set [picnic rsvp] = @rsvp, [Adult Check in] = @AdultCheck, [Children Check In] = @ChildCheck, [party size] = @partynumber where [email address] = @emailaddress;"
                    cmd.Parameters.Add("@rsvp", SqlDbType.VarChar, 100).Value = "Yes"
                    cmd.Parameters.Add("@emailaddress", SqlDbType.VarChar, 100).Value = email_address
                    cmd.Parameters.Add("@partynumber", SqlDbType.VarChar, 100).Value = party_string
                    cmd.Parameters.Add("@AdultCheck", SqlDbType.VarChar, 100).Value = adults_string
                    cmd.Parameters.Add("@ChildCheck", SqlDbType.VarChar, 100).Value = child_string
                    cmd.ExecuteNonQuery()
                    con.Close()
                    ViewDatabase_Click(sender, e)
                Catch ex As Exception
                    MessageBox.Show("error:" & ex.Message)
                Finally
                    x += 1
                End Try
            Loop
            xlworkbook.Close()
            xlapp.Quit()
            releaseObject(xlapp)
            releaseObject(xlworkbook)
            releaseObject(xlworksheet)
        End If
    End Sub
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''''''''''''''''DEBUG SECTION''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''' <summary>
    ''' Initalzies my default event table.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AddDefaultEventsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddDefaultEventsToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Insert into [Defaults] ([Id]) VALUES (@Id)"
            cmd.Parameters.AddWithValue("@Id", 1)
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class
