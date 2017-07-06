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

Public Class AddMember
    Public Property con_string As String
    Public Property admin_status As Boolean
    Public Property ID As String

    Private Sub AddMember_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim test_form As New Form1
        test_form.con_string = con_string
        test_form.admin_status = admin_status
        If My.Settings.IdThroughForms = "Yes" Then
            test_form.id_public = ID
        End If
        test_form.Show()
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
        cmd2.CommandText = "Select [Default Channel] from [Defaults]"
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
        cmd2.CommandText = "Select [Default Payment] from [Defaults]"
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
        cmd2.CommandText = "Select [Default Event] from [Defaults]"
        EventBox.SelectedValue = cmd2.ExecuteScalar()
        con2.Close()
    End Sub
    ''' <summary>
    ''' Initializes the EventBox combobox based off the contents of the events table.
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
    ''' Fills the channel combo box based of the information stored in the events table.
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
    Private Sub AddMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Visible = False
        CountryText.Text = "USA"
        If My.Settings.Resize = "1080 x 720" Then
            Me.Width = 1080
            Me.Height = 720
            AddMemberButton.Location = New Point(340, 585)
            Dim top_size As New Size(30, 22)
            Dim bottom_size As New Size(350, 26)
            Dim phone_size As New Size(200, 26)
            Dim font_8 As New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
            Dim font_10 As New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Dim font_12 As New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
            'Spacing between label and box is 25 spacing between box and new label is 35
            'Labels are placed 5 units before the box so they allign properly
            'Quit Button
            Quit.Location = New Point(900, 0)
            'Add Member Button
            AddMemberButton.Location = New Point(200, 600)
            'ID Label
            IDLabel.Location = New Point(0, 0)
            IDLabel.Font = font_10
            'ID Box
            IDNumber.Location = New Point(5, 25)
            'Adult Label
            Adult_Label.Location = New Point(60, 0)
            Adult_Label.Font = font_10
            'Adult Box
            Adult.Location = New Point(65, 25)
            Adult.Font = font_10
            'Children Label
            Children_Label.Location = New Point(125, 0)
            Children_Label.Font = font_10
            'Children Box
            Children.Location = New Point(130, 25)
            Children.Font = font_10
            'Family Label
            Family_Label.Location = New Point(200, 0)
            Family_Label.Font = font_10
            'Family Box
            FamilySize.Location = New Point(205, 25)
            FamilySize.Font = font_10
            'Address Label
            Address_Label.Location = New Point(595, 0)
            Address_Label.Font = font_12
            'Line 1 Label
            Line1Label.Location = New Point(595, 25)
            Line1Label.Font = font_10
            'Line 1 box
            Line1Text.Location = New Point(600, 50)
            Line1Text.Font = font_10
            Line1Text.Size = bottom_size
            'Line 2 Label
            Line2Label.Location = New Point(595, 85)
            Line2Label.Font = font_10
            'Line 2 Box
            Line2Text.Location = New Point(600, 110)
            Line2Text.Font = font_10
            Line2Text.Size = bottom_size
            'City Label
            CityLabel.Location = New Point(595, 145)
            CityLabel.Font = font_10
            'City Box
            CityText.Location = New Point(600, 170)
            CityText.Font = font_10
            CityText.Size = bottom_size
            'State Label
            StateLabel.Location = New Point(595, 205)
            StateLabel.Font = font_10
            'State Box
            StateText.Location = New Point(600, 230)
            StateText.Size = bottom_size
            StateText.Font = font_10
            'Zip Label
            ZipLabel.Location = New Point(595, 265)
            ZipLabel.Font = font_10
            'Zip Box
            ZipText.Location = New Point(600, 290)
            ZipText.Font = font_10
            ZipText.Size = bottom_size
            'Country Label
            CountryLabel.Location = New Point(595, 325)
            CountryLabel.Font = font_10
            'Country Box
            CountryText.Location = New Point(600, 350)
            CountryText.Font = font_10
            CountryText.Size = bottom_size
            'Phone Number Label
            PhoneNumber_Label.Location = New Point(595, 385)
            PhoneNumber_Label.Font = font_10
            'Phone Number Box
            PhoneNumber.Location = New Point(795, 385)
            PhoneNumber.Font = font_10
            PhoneNumber.Size = phone_size
            'Cell Phone Label
            Cell_Label.Location = New Point(595, 420)
            Cell_Label.Font = font_10
            'Cell Phone Box
            cell_phone.Location = New Point(795, 420)
            cell_phone.Font = font_10
            cell_phone.Size = phone_size
            'Work Phone Label
            Work_Label.Location = New Point(595, 455)
            Work_Label.Font = font_10
            'Work Phone Box
            WorkPhone.Location = New Point(795, 455)
            WorkPhone.Font = font_10
            WorkPhone.Size = phone_size
            'Event Label
            Event_Label.Location = New Point(595, 490)
            Event_Label.Font = font_10
            'Event Box
            EventBox.Location = New Point(600, 515)
            EventBox.Font = font_10
            'Channel Label
            Channel_Label.Location = New Point(595, 550)
            Channel_Label.Font = font_10
            'Channel Box
            ChannelBox.Location = New Point(600, 575)
            ChannelBox.Font = font_10
            'Payment Label
            Payment_Label.Location = New Point(595, 610)
            Payment_Label.Font = font_10
            'Payment Box
            PaymentMethod.Location = New Point(600, 635)
            PaymentMethod.Font = font_10
            'Note Label
            Note_Label.Location = New Point(790, 490)
            Note_Label.Font = font_10
            'Note Box
            NoteBox.Location = New Point(795, 515)
            NoteBox.Font = font_10
            NoteBox.Size = New Size(200, 50)
            'Unpaid Dues Label
            Unpaid_Dues_Label.Location = New Point(790, 560)
            Unpaid_Dues_Label.Font = font_10
            'Unpaid Dues Box
            UnpaidDuesBox.Location = New Point(795, 585)
            UnpaidDuesBox.Font = font_10
            UnpaidDuesBox.Size = phone_size
            '*******************************************************
            '*******************************************************
            '*******************************************************
            'First Name Label
            FirstName_Label.Location = New Point(0, 66)
            FirstName_Label.Font = font_10
            'First Name Box
            FirstName.Location = New Point(5, 91)
            FirstName.Size = bottom_size
            FirstName.Font = font_10
            'Last Name Label
            LastName_Label.Location = New Point(0, 126)
            LastName_Label.Font = font_10
            'Last Name Box
            LastName.Location = New Point(5, 151)
            LastName.Font = font_10
            LastName.Size = bottom_size
            'Spouse Name Label
            SpouseName_Label.Location = New Point(0, 186)
            SpouseName_Label.Font = font_10
            'Spouse Name Box
            SpouseName.Location = New Point(5, 211)
            SpouseName.Font = font_10
            SpouseName.Size = bottom_size
            'Email Address Label
            EmailAddress_Label.Location = New Point(0, 246)
            EmailAddress_Label.Font = font_10
            'Email Address Box
            EmailAddress.Location = New Point(5, 271)
            EmailAddress.Size = bottom_size
            EmailAddress.Font = font_10
            'Dependent Label
            Dependent_Label.Location = New Point(0, 306)
            Dependent_Label.Font = font_10
            'Depedent GridView
            DataGridView2.Location = New Point(5, 331)
        Else
            'Fixing default resolution tab indexes
            UnpaidDuesBox.TabIndex = 18
            EventBox.TabIndex = 19
            ChannelBox.TabIndex = 20
            PaymentMethod.TabIndex = 21
            NoteBox.TabIndex = 22
            AddMemberButton.TabIndex = 23
            Quit.TabIndex = 24
        End If
        IDNumber.Text = ID
        IDNumber.ReadOnly = True
        DataGridView1.Visible = False
        StateText.Text = "NJ"
        CountryText.Text = "USA"
        InitializeEvents()
        InitializeChannel()
        InitializePaymentMethod()
        SetDefaultChannel()
        SetDefaultEvent()
        SetDefaultPayment()
    End Sub

    Private Sub AddMemberButton_Click(sender As Object, e As EventArgs) Handles AddMemberButton.Click
        Dim message_result As DialogResult = MessageBox.Show(" Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
       MessageBoxIcon.Exclamation)
        If message_result = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
        If FirstName.Text = "" Then
            MessageBox.Show("Please make sure First Name is filled out before trying to add a member.")
            Exit Sub
        End If
        If LastName.Text = "" Then
            MessageBox.Show("Please make sure Last Name is filled out before trying to add a member.")
            Exit Sub
        End if
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Insert into [membership] ([Id], [First Name], [Last Name], " &
                    "[Phone Number], [Cellphone Number], [Email Address], [Event Signed Up At]," &
                    "[Payment Method], [Note], [Membership Status], [Channel], [Family Size], " &
                    "[Children], [Adults], [Address 1], [Address 2], [City], [Zip], [State], [Country],[Spouse Name], " & _
                     "[Work Number], [Date Signed Up], [Unpaid Dues]) VALUES (@Id, @FirstName, " &
                    "@LastName, @PhoneNumber, @CellPhoneNumber, @EmailAddress, @EventSignedUpAt, " &
                "@PaymentMethod, @Note, @MembershipStatus, @Channel, @Family, @Children, @Adult, @Line1, " &
                "@Line2, @City, @Zip, @State, @Country, @Spouse, @WorkPhone, @Date, @Dues)"
            'Spouse Name
            If SpouseName.Text = "" Then
                cmd.Parameters.AddWithValue("@Spouse", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Spouse", SpouseName.Text)
            End If
            'Country
            If CountryText.Text = "" Then
                cmd.Parameters.AddWithValue("@Country", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Country", CountryText.Text)
            End If
            'State
            If StateText.Text = "" Then
                cmd.Parameters.AddWithValue("@State", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@State", StateText.Text)
            End If
            'Zip
            If ZipText.Text = "" Then
                cmd.Parameters.AddWithValue("@Zip", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Zip", ZipText.Text)
            End If
            'Line 1
            If Line1Text.Text = "" Then
                cmd.Parameters.AddWithValue("@Line1", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Line1", Line1Text.Text)
            End If
            'Line2
            If Line2Text.Text = "" Then
                cmd.Parameters.AddWithValue("@Line2", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Line2", Line2Text.Text)
            End If
            'City
            If CityText.Text = "" Then
                cmd.Parameters.AddWithValue("@City", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@City", CityText.Text)
            End If
            'ID
            cmd.Parameters.AddWithValue("@ID", IDNumber.Text)
            'First Name
            cmd.Parameters.AddWithValue("@FirstName", FirstName.Text)
            'Last Name
            cmd.Parameters.AddWithValue("@LastName", LastName.Text)
            'Family Size
            If FamilySize.Text = "" Then
                cmd.Parameters.AddWithValue("@Family", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Family", FamilySize.Text)
            End If
            'Adult Number
            If Adult.Text = "" Then
                cmd.Parameters.AddWithValue("@Adult", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Adult", Adult.Text)
            End If
            'Children Number
            If Children.Text = "" Then
                cmd.Parameters.AddWithValue("@Children", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Children", Children.Text)
            End If
            'Channel
            If ChannelBox.Text = "" Then
                cmd.Parameters.AddWithValue("@Channel", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Channel", ChannelBox.Text)
            End If
            'Phone Number
            If PhoneNumber.Text = "" Then
                cmd.Parameters.AddWithValue("@PhoneNumber", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber.Text)
            End If
            'Cellphone Number
            If cell_phone.Text = "" Then
                cmd.Parameters.AddWithValue("@CellPhoneNumber", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@CellPhoneNumber", cell_phone.Text)
            End If
            'Email Address
            If EmailAddress.Text = "" Then
                cmd.Parameters.AddWithValue("@EmailAddress", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@EmailAddress", EmailAddress.Text)
            End If
            'Member Status
            cmd.Parameters.AddWithValue("@MembershipStatus", "Active")
            'Event Name
            If EventBox.Text = "" Then
                cmd.Parameters.AddWithValue("@EventSignedUpAt", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@EventSignedUpAt", EventBox.Text)
            End If
            'Payment Method
            If PaymentMethod.Text = "" Then
                cmd.Parameters.AddWithValue("@PaymentMethod", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@PaymentMethod", PaymentMethod.Text)
            End If
            'Note
            If NoteBox.Text = "" Then
                cmd.Parameters.AddWithValue("@Note", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Note", NoteBox.Text)
            End If
            'Work Phone
            If WorkPhone.Text = "" Then
                cmd.Parameters.AddWithValue("@WorkPhone", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@WorkPhone", WorkPhone.Text)
            End If
            'Date Signed Up
            cmd.Parameters.AddWithValue("@Date", DateTime.Now)
            'Unpaid Dues
            If UnpaidDuesBox.Text = "" Then
                cmd.Parameters.AddWithValue("@Dues", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Dues", UnpaidDuesBox.Text)
            End If
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MessageBox.Show("Please enter a unique Membership ID Number")
            Else
                MessageBox.Show("Error:" & ex.Message)
            End If
        Finally
            con.Close()
        End Try
        SendMail2_Click(sender, e)
        'IDNumber_TextChanged(sender, e)
        'AddMember(sender, e)
        Me.Close()
    End Sub

    Private Sub SendMail2_Click(sender As Object, e As EventArgs) 'Handles SendMail2.Click
        'Dim message_result As DialogResult = MessageBox.Show(" Are you sure you wish continue?", "Critical Warning", MessageBoxButtons.YesNo,
        'MessageBoxIcon.Exclamation)
        'If message_result = Windows.Forms.DialogResult.No Then
        'Exit Sub
        'End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Select * from [Membership] where [Id] = @ID"
        cmd.Parameters.AddWithValue("@ID", IDNumber.Text)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        con.Open()
        sqlquery.Fill(ds, "Email_Table")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "Email_Table"
        ' Console.WriteLine("table_created")
        'For i = 0 To ds.Tables(0).Rows.Count - 1
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
            If ds.Tables(0).Rows(0).Item(5).ToString = "" Then
                mail.To.Add("username@gmail.com")
            Else
                mail.To.Add(ds.Tables(0).Rows(0).Item(5).ToString)
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
                        "Your work phone number is " & ds.Tables(0).Rows(0).Item(23).ToString & System.Environment.NewLine &
                        "The size of your family is " & ds.Tables(0).Rows(0).Item(8).ToString & System.Environment.NewLine &
                        "The number of children in your family is " & ds.Tables(0).Rows(0).Item(9).ToString & System.Environment.NewLine &
                        "The number of adults in your family is " & ds.Tables(0).Rows(0).Item(10).ToString & System.Environment.NewLine &
                        "Your membership status is " & ds.Tables(0).Rows(0).Item(11).ToString & System.Environment.NewLine &
                        "Your address is " & System.Environment.NewLine & System.Environment.NewLine & ds.Tables(0).Rows(0).Item(17).ToString &
                        System.Environment.NewLine & ds.Tables(0).Rows(0).Item(19).ToString & ds.Tables(0).Rows(0).Item(18) & _
                        " " & ds.Tables(0).Rows(0).Item(20).ToString & " " & ds.Tables(0).Rows(0).Item(21).ToString & System.Environment.NewLine & System.Environment.NewLine &
                        "Have a nice day!" & System.Environment.NewLine & System.Environment.NewLine &
                         "From," & System.Environment.NewLine &
                    "IFMP Admin"
            '"You  " & ds.Tables(0).Rows(i).Item(4) & System.Environment.NewLine 
            'SmtpServer.EnableSsl = True
            'Console.WriteLine("Email_Created")
            SmtpServer.Send(mail)
            'Console.WriteLine("Email_Sent")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        'Next
        con.Close()
        MessageBox.Show("Email Sent")
        For counter As Int32 = 0 To DataGridView2.RowCount - 2 Step 1
            Dim cmd_new As New SqlCommand()
            Dim con_new As New SqlConnection()
            Try
                con_new.ConnectionString = con_string
                con_new.Open()
                cmd_new.Connection = con_new
                cmd_new.CommandText = "Insert into [Child] ([Id], [Child Id], [Name], " &
                    "[Age], [School Name], [Relationship]) VALUES (@Id, @ChildId, " &
                    "@Name, @Age, @SchoolName, @Relationship)"
                cmd_new.Parameters.AddWithValue("@Id", Convert.ToInt32(ID))
                cmd_new.Parameters.AddWithValue("@ChildId", Convert.ToInt32(counter))
                'Dependant Name
                If DataGridView2.Rows(counter).Cells(0).Value = "" Then
                    cmd_new.Parameters.AddWithValue("@Name", DBNull.Value)
                Else
                    cmd_new.Parameters.AddWithValue("@Name", DataGridView2.Rows(counter).Cells(0).Value)
                End If
                'Relationship
                If DataGridView2.Rows(counter).Cells(1).Value = "" Then
                    cmd_new.Parameters.AddWithValue("@Relationship", DBNull.Value)
                Else
                    cmd_new.Parameters.AddWithValue("@Relationship", DataGridView2.Rows(counter).Cells(1).Value)
                End If
                'Dependant Age
                If DataGridView2.Rows(counter).Cells(2).Value = "" Then
                    cmd_new.Parameters.AddWithValue("@Age", DBNull.Value)
                Else
                    cmd_new.Parameters.AddWithValue("@Age", DataGridView2.Rows(counter).Cells(2).Value)
                End If
                'Dependant School
                If DataGridView2.Rows(counter).Cells(3).Value = "" Then
                    cmd_new.Parameters.AddWithValue("@SchoolName", DBNull.Value)
                Else
                    cmd_new.Parameters.AddWithValue("@SchoolName", DataGridView2.Rows(counter).Cells(3).Value)
                End If
                cmd_new.ExecuteNonQuery()
            Catch ex As SqlException
                If ex.Number = 2627 Then
                    MessageBox.Show("Please enter a unique Membership ID Number")
                Else
                    MessageBox.Show("Error:" & ex.Message)
                End If
            Finally
                con_new.Close()
            End Try
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        For counter As Int32 = 0 To DataGridView2.RowCount - 1 Step 1
            Console.WriteLine(DataGridView2.Rows(counter).Cells(0).Value)
            Console.WriteLine(DataGridView2.Rows(counter).Cells(1).Value)
            Console.WriteLine(DataGridView2.Rows(counter).Cells(2).Value)
            Console.WriteLine(DataGridView2.Rows(counter).Cells(3).Value)
        Next
        Me.Close()
    End Sub

    Private Sub Quit_Click(sender As Object, e As EventArgs) Handles Quit.Click
        Me.Close()
    End Sub

End Class