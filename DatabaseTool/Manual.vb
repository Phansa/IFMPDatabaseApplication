Public Class Manual
    Public Property con_string As String
    Public Property admin_status As Boolean
    Public Property id_public As String
    Dim current_page As Int32
    Dim page_limit As Int32
    Dim topic As String

    Private Sub Manual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Settings.Resize = "1080 x 720" Then
            Dim font_10 As New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
            Me.Width = 1080
            Me.Height = 720
        End If
        ToolStripMenuItem1_Click(sender, e)
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        Dim form1 As New Form1
        form1.con_string = con_string
        form1.admin_status = admin_status
        form1.id_public = id_public
        form1.Show()
        Me.Close()
    End Sub

    Private Sub Manual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Right) Then
            If current_page + 1 <= page_limit Then
                current_page += 1
                Page_Number.Text = current_page.ToString()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Left) Then
            If current_page - 1 > 0 Then
                current_page -= 1
                Page_Number.Text = current_page.ToString()
            End If
        End If
    End Sub

    Private Sub Page_Number_TextChanged(sender As Object, e As EventArgs) Handles Page_Number.TextChanged
        If Page_Number.Text <> "" Then
            current_page = Convert.ToInt32(Page_Number.Text)
            If topic = "Welcome" Then
                If current_page = 1 Then
                    Manual_Text.Text = "Welcome to the IFMP Database Tool manual. Here you will " &
                        "find information about all of the features this application has to offer. To " &
                        "navigate this manual, select a topic from the topics menu and then press either " &
                        "the left or right arrow buttons to change which page you are looking at. Alternatively " &
                        "you can edit the page number text box. When you are done using the manual, press the quit " &
                        "button to exit or else you will exit the program entirely." & System.Environment.NewLine & "Please note that in order for this " &
                        "application to work your IP address must be added to the list of approved ip addresses on aplus" &
                        ".net/the server this database is located on. If you are having trouble logging in, please verify " &
                        "that your IP address is on this list." & System.Environment.NewLine & "Please contact adeetp@gmail.com with " &
                        "any questions, comments or concerns." & System.Environment.NewLine & "Continue to the next page for " &
                        "an overview of the topics covered in this manual."
                End If
                If current_page = 2 Then
                    Manual_Text.Text = "A brief overivew of each topic:" &
                        System.Environment.NewLine & "Welcome - Describes an overview of this application" &
                        System.Environment.NewLine & "Interface - Describes the basic functions of this application" &
                        System.Environment.NewLine & "Email - Describes each function under the email menu" &
                        System.Environment.NewLine & "Settings - Describes the customizable settings featured in this application" &
                        System.Environment.NewLine & "Dependant Table - Describes the features of the dependant table" &
                        System.Environment.NewLine & "Changelog - Describes the recent changes made to this application starting " &
                        System.Environment.NewLine & "from the most recent first."
                End If
            ElseIf topic = "Interface" Then
                If current_page = 1 Then
                    'ImagesBox.Image = My.Resources.Main_Interface
                    Manual_Text.Text = "Here you will find a detailed explanation of all aspects of the user interface."
                End If
            ElseIf topic = "Email" Then
                If current_page = 1 Then
                    Manual_Text.Text = "Hello"
                End If
                If current_page = 2 Then
                    Manual_Text.Text = "Goodbye"
                End If
            ElseIf topic = "Settings" Then
                If current_page = 1 Then
                    Manual_Text.Text = "A brief overview of each topic: "
                End If
                If current_page = 2 Then
                    Manual_Text.Text = "The set Default Event/Payment/Channel options will change the default event that is " &
                        "selected when the program starts/when you are trying to add a new member. Simply select the event/" &
                        "channel/payment method you want to set as the new default, the press the menu option for the corresponding " &
                        "item you are trying to change and you are all set!"
                End If
            ElseIf topic = "Dependant Table" Then
            ElseIf topic = "Changelog" Then
                If current_page = 8 Then
                    Manual_Text.Text = "V 5.3.4" & System.Environment.NewLine & "8/12/16" & System.Environment.NewLine &
                        "-Removed Verify Member, Pay Membership Difference, 2016 Confirmation and Membership Difference Acknowledgement email options."
                End If
                If current_page = 7 Then
                    Manual_Text.Text = "V 5.3.3" & System.Environment.NewLine & "8/5/16" & System.Environment.NewLine &
                        "-Added new load excel option, not accessible in program anymore." & System.Environment.NewLine &
                        "-Fixed view members bug."
                End If
                If current_page = 6 Then
                    Manual_Text.Text = "V 5.3.2" & System.Environment.NewLine & "7/24/16" & System.Environment.NewLine &
                        "-Added Add Event form so that in the future it's easier to add new events." & System.Environment.NewLine &
                        "-Event Field loads from a new table in the database." & System.Environment.NewLine &
                        "-Can set default event properly, will change the default event on the local machine only." & System.Environment.NewLine &
                        "-Default channel/payment got same changes, access this option through menu -> settings."
                End If
                If current_page = 5 Then
                    Manual_Text.Text = "V 5.3.1" & System.Environment.NewLine & "7/19/16" & System.Environment.NewLine & "-Updated Renew Membership Email (sends to all)" &
                        "-Added pay membership difference email option (sends to one person only)" &
                        "-Check In Boxes will update everytime view is pressed with correct values" &
                        "-Fixed total RSVP box"
                End If
                If current_page = 4 Then
                    Manual_Text.Text = "V 5.3" & System.Environment.NewLine & "4/2/16" & System.Environment.NewLine & "-Update send mail options" & System.Environment.NewLine &
                    "Renew Membership - Sends mail to all inactive members" & System.Environment.NewLine & "Membership Info to All - Sends information email to all members" &
                    System.Environment.NewLine & "Membership Info to Single - Sends information email to one person" & System.Environment.NewLine &
                    "2016 Confirmation - Sends confirmation email to a single person" & System.Environment.NewLine &
                    "-Added Unpaid Dues Column" & System.Environment.NewLine & "-Defaults for add member are now" & System.Environment.NewLine &
                    "State - NJ" & System.Environment.NewLine & "Payment - Paypal" & System.Environment.NewLine & "Channel - Paypal" &
                    System.Environment.NewLine & "Country - USA" & System.Environment.NewLine & "-Fixed Tab Indexing on Add Member Form" & System.Environment.NewLine &
                    "Switched membership column to the 2nd column" & System.Environment.NewLine & "Can change default Event/Payment Method/Channel when adding members"
                ElseIf current_page = 3 Then
                    Manual_Text.Text = "V 5.2" & System.Environment.NewLine & "3/27/16" & System.Environment.NewLine & "Added ability to change Date Signed Up At field" &
                    System.Environment.NewLine & "-Default view is set to current members only. Can change this to view all members as well."
                ElseIf current_page = 2 Then
                    Manual_Text.Text = "V 5.1" & System.Environment.NewLine & "2/15/16" & System.Environment.NewLine & "-Added new update membership email option for membership renewel"
                ElseIf current_page = 1 Then
                    Manual_Text.Text = "V 5.0" & System.Environment.NewLine & "1/1/16" & System.Environment.NewLine & "-New add member Interface added" & System.Environment.NewLine &
"-New Work Phone Field added into database" & System.Environment.NewLine &
"-Load Function removed from admin panel" & System.Environment.NewLine &
"-Adult Table discontinued" & System.Environment.NewLine &
"-Child table encompasses all dependents now (adults And children)" & System.Environment.NewLine &
"-Remove Child  & Remove Adult buttons removed from admin mode" & System.Environment.NewLine &
"-Fixed Anchoring Properties And first two login screen (When going full screen" &
"icons dont Not move)" & System.Environment.NewLine &
"-Changed Default Table view To show whole contents Of cell (can be changed" &
"by going To settings > table > Old Style)" & System.Environment.NewLine &
"-Fixed view button throwing an exception To the console (back End)" & System.Environment.NewLine &
"-Event view no longer accesible(work In progress)" & System.Environment.NewLine &
"-Going from child view To main view maintains ID used (can change this In settings > form behavior > pass id through forms pick yes or no) - " & _
"When toggled off resets to default view when a new form is opened such as after " & _
"adding a member. Othwerise when toggled on it will use the new memebr's id " & _
"and fill out their information automatically in the grid/textboxes. " & System.Environment.NewLine &
"-View Non Member option removed" & System.Environment.NewLine &
"-User permission level can add members" & System.Environment.NewLine &
"-Reset() RSVP/Check In removed from User Level" & System.Environment.NewLine &
"-Fixed bug causing display settings not to change" & System.Environment.NewLine &
"-Changed main user Interface" & System.Environment.NewLine &
"-IFMP membership tool text box made Read Only"
                End If
            End If
        End If
    End Sub

    Private Sub EmailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmailToolStripMenuItem.Click
        topic = "Email"
        Page_Number.Text = 1
        page_limit = 2
        Page_Number_TextChanged(sender, e)
    End Sub

    Private Sub Manual_Text_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Manual_Text.KeyPress
        If e.KeyChar = ChrW(Keys.Right) Then
            If current_page + 1 <= page_limit Then
                current_page += 1
                Page_Number.Text = current_page.ToString()
            End If
        End If
        If e.KeyChar = ChrW(Keys.Left) Then
            If current_page - 1 >= 0 Then
                current_page -= 1
                Page_Number.Text = current_page.ToString()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If current_page - 1 > 0 Then
            current_page -= 1
            Page_Number.Text = current_page.ToString()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If current_page + 1 <= page_limit Then
            current_page += 1
            Page_Number.Text = current_page.ToString()
        End If
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        page_limit = 2
        topic = "Welcome"
        Page_Number.Text = 1
        Page_Number_TextChanged(sender, e)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        page_limit = 5
        topic = "Interface"
        Page_Number.Text = 1
        Page_Number_TextChanged(sender, e)
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        page_limit = 4
        topic = "Settings"
        Page_Number.Text = 1
        Page_Number_TextChanged(sender, e)
    End Sub

    Private Sub DependToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DependToolStripMenuItem.Click
        page_limit = 4
        topic = "Dependant Table"
        Page_Number.Text = 1
        Page_Number_TextChanged(sender, e)
    End Sub

    Private Sub ChangelogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangelogToolStripMenuItem.Click
        page_limit = 8
        topic = "Changelog"
        Page_Number.Text = 1
        Page_Number_TextChanged(sender, e)
    End Sub

End Class