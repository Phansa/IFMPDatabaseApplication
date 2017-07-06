<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EventView
    Inherits System.Windows.Forms.Form

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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddEventToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GoToToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MainViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChildViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Event_Label = New System.Windows.Forms.Label()
        Me.Event_Grid = New System.Windows.Forms.DataGridView()
        Me.ViewDatabase = New System.Windows.Forms.Button()
        Me.DBUpdateHand = New System.Windows.Forms.Button()
        Me.Member_Id_Label = New System.Windows.Forms.Label()
        Me.MemberId_Text = New System.Windows.Forms.RichTextBox()
        Me.Event_Id_Label = New System.Windows.Forms.Label()
        Me.EventName_Text = New System.Windows.Forms.RichTextBox()
        Me.Check_In_Box = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RSVPBOX = New System.Windows.Forms.ComboBox()
        Me.Adult_RSVPBox = New System.Windows.Forms.RichTextBox()
        Me.Children_RSVPBox = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Total_Children = New System.Windows.Forms.TextBox()
        Me.Total_Adult = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TotalChildren = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TotalRSVP = New System.Windows.Forms.Label()
        Me.Checkin_number = New System.Windows.Forms.TextBox()
        Me.Total_RSVPBox = New System.Windows.Forms.TextBox()
        Me.FirstName = New System.Windows.Forms.RichTextBox()
        Me.LastName = New System.Windows.Forms.RichTextBox()
        Me.FirstName_Label = New System.Windows.Forms.Label()
        Me.LastName_Label = New System.Windows.Forms.Label()
        Me.PaymentMethod = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ChannelBox = New System.Windows.Forms.ComboBox()
        Me.Tickets_Label = New System.Windows.Forms.Label()
        Me.TicketsBox = New System.Windows.Forms.RichTextBox()
        Me.Adult_Check_Label = New System.Windows.Forms.Label()
        Me.Children_Check_Label = New System.Windows.Forms.Label()
        Me.Adult_CheckBox = New System.Windows.Forms.RichTextBox()
        Me.Children_CheckBox = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Event_Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1530, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEventToolStripMenuItem, Me.GoToToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(58, 24)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'AddEventToolStripMenuItem
        '
        Me.AddEventToolStripMenuItem.Name = "AddEventToolStripMenuItem"
        Me.AddEventToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.AddEventToolStripMenuItem.Text = "Add Event"
        '
        'GoToToolStripMenuItem
        '
        Me.GoToToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MainViewToolStripMenuItem, Me.ChildViewToolStripMenuItem})
        Me.GoToToolStripMenuItem.Name = "GoToToolStripMenuItem"
        Me.GoToToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.GoToToolStripMenuItem.Text = "Go To"
        '
        'MainViewToolStripMenuItem
        '
        Me.MainViewToolStripMenuItem.Name = "MainViewToolStripMenuItem"
        Me.MainViewToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.MainViewToolStripMenuItem.Text = "Main View"
        '
        'ChildViewToolStripMenuItem
        '
        Me.ChildViewToolStripMenuItem.Name = "ChildViewToolStripMenuItem"
        Me.ChildViewToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.ChildViewToolStripMenuItem.Text = "Child View"
        '
        'Event_Label
        '
        Me.Event_Label.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Event_Label.AutoSize = True
        Me.Event_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Event_Label.Location = New System.Drawing.Point(563, 0)
        Me.Event_Label.Name = "Event_Label"
        Me.Event_Label.Size = New System.Drawing.Size(102, 32)
        Me.Event_Label.TabIndex = 1
        Me.Event_Label.Text = "Events"
        '
        'Event_Grid
        '
        Me.Event_Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Event_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Event_Grid.Location = New System.Drawing.Point(12, 35)
        Me.Event_Grid.Name = "Event_Grid"
        Me.Event_Grid.RowTemplate.Height = 24
        Me.Event_Grid.Size = New System.Drawing.Size(1505, 415)
        Me.Event_Grid.TabIndex = 2
        '
        'ViewDatabase
        '
        Me.ViewDatabase.AutoSize = True
        Me.ViewDatabase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ViewDatabase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ViewDatabase.Location = New System.Drawing.Point(155, 0)
        Me.ViewDatabase.Margin = New System.Windows.Forms.Padding(4)
        Me.ViewDatabase.Name = "ViewDatabase"
        Me.ViewDatabase.Size = New System.Drawing.Size(98, 28)
        Me.ViewDatabase.TabIndex = 122
        Me.ViewDatabase.TabStop = False
        Me.ViewDatabase.Text = "View Events"
        Me.ViewDatabase.UseVisualStyleBackColor = True
        '
        'DBUpdateHand
        '
        Me.DBUpdateHand.AutoSize = True
        Me.DBUpdateHand.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DBUpdateHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.DBUpdateHand.Location = New System.Drawing.Point(63, 0)
        Me.DBUpdateHand.Margin = New System.Windows.Forms.Padding(4)
        Me.DBUpdateHand.Name = "DBUpdateHand"
        Me.DBUpdateHand.Size = New System.Drawing.Size(84, 28)
        Me.DBUpdateHand.TabIndex = 123
        Me.DBUpdateHand.Text = "Add Event"
        Me.DBUpdateHand.UseVisualStyleBackColor = True
        '
        'Member_Id_Label
        '
        Me.Member_Id_Label.AutoSize = True
        Me.Member_Id_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Member_Id_Label.Location = New System.Drawing.Point(7, 469)
        Me.Member_Id_Label.Name = "Member_Id_Label"
        Me.Member_Id_Label.Size = New System.Drawing.Size(105, 25)
        Me.Member_Id_Label.TabIndex = 124
        Me.Member_Id_Label.Text = "Member Id"
        '
        'MemberId_Text
        '
        Me.MemberId_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.MemberId_Text.Location = New System.Drawing.Point(12, 498)
        Me.MemberId_Text.Margin = New System.Windows.Forms.Padding(4)
        Me.MemberId_Text.Multiline = False
        Me.MemberId_Text.Name = "MemberId_Text"
        Me.MemberId_Text.ReadOnly = True
        Me.MemberId_Text.Size = New System.Drawing.Size(214, 34)
        Me.MemberId_Text.TabIndex = 126
        Me.MemberId_Text.TabStop = False
        Me.MemberId_Text.Text = ""
        '
        'Event_Id_Label
        '
        Me.Event_Id_Label.AutoSize = True
        Me.Event_Id_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Event_Id_Label.Location = New System.Drawing.Point(7, 550)
        Me.Event_Id_Label.Name = "Event_Id_Label"
        Me.Event_Id_Label.Size = New System.Drawing.Size(119, 25)
        Me.Event_Id_Label.TabIndex = 127
        Me.Event_Id_Label.Text = "Event Name"
        '
        'EventName_Text
        '
        Me.EventName_Text.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EventName_Text.BackColor = System.Drawing.SystemColors.Window
        Me.EventName_Text.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.EventName_Text.Location = New System.Drawing.Point(12, 579)
        Me.EventName_Text.Margin = New System.Windows.Forms.Padding(4)
        Me.EventName_Text.Multiline = False
        Me.EventName_Text.Name = "EventName_Text"
        Me.EventName_Text.Size = New System.Drawing.Size(214, 34)
        Me.EventName_Text.TabIndex = 128
        Me.EventName_Text.Text = ""
        '
        'Check_In_Box
        '
        Me.Check_In_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Check_In_Box.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Check_In_Box.FormattingEnabled = True
        Me.Check_In_Box.Items.AddRange(New Object() {"Yes", "No", ""})
        Me.Check_In_Box.Location = New System.Drawing.Point(247, 502)
        Me.Check_In_Box.Name = "Check_In_Box"
        Me.Check_In_Box.Size = New System.Drawing.Size(77, 28)
        Me.Check_In_Box.TabIndex = 130
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(242, 474)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 25)
        Me.Label6.TabIndex = 131
        Me.Label6.Text = "Check In"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(658, 475)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 25)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "RSVP"
        '
        'RSVPBOX
        '
        Me.RSVPBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.RSVPBOX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.RSVPBOX.FormattingEnabled = True
        Me.RSVPBOX.Items.AddRange(New Object() {"Yes", "No", ""})
        Me.RSVPBOX.Location = New System.Drawing.Point(663, 503)
        Me.RSVPBOX.Name = "RSVPBOX"
        Me.RSVPBOX.Size = New System.Drawing.Size(77, 28)
        Me.RSVPBOX.TabIndex = 132
        '
        'Adult_RSVPBox
        '
        Me.Adult_RSVPBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Adult_RSVPBox.Location = New System.Drawing.Point(747, 498)
        Me.Adult_RSVPBox.Margin = New System.Windows.Forms.Padding(4)
        Me.Adult_RSVPBox.Multiline = False
        Me.Adult_RSVPBox.Name = "Adult_RSVPBox"
        Me.Adult_RSVPBox.Size = New System.Drawing.Size(47, 34)
        Me.Adult_RSVPBox.TabIndex = 134
        Me.Adult_RSVPBox.Text = ""
        '
        'Children_RSVPBox
        '
        Me.Children_RSVPBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Children_RSVPBox.Location = New System.Drawing.Point(852, 496)
        Me.Children_RSVPBox.Margin = New System.Windows.Forms.Padding(4)
        Me.Children_RSVPBox.Multiline = False
        Me.Children_RSVPBox.Name = "Children_RSVPBox"
        Me.Children_RSVPBox.Size = New System.Drawing.Size(47, 34)
        Me.Children_RSVPBox.TabIndex = 135
        Me.Children_RSVPBox.Text = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(743, 474)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 20)
        Me.Label7.TabIndex = 137
        Me.Label7.Text = "Adult RSVP"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(848, 474)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(121, 20)
        Me.Label9.TabIndex = 136
        Me.Label9.Text = "Children RSVP"
        '
        'Total_Children
        '
        Me.Total_Children.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Total_Children.Location = New System.Drawing.Point(446, 627)
        Me.Total_Children.Name = "Total_Children"
        Me.Total_Children.Size = New System.Drawing.Size(36, 26)
        Me.Total_Children.TabIndex = 145
        Me.Total_Children.TabStop = False
        '
        'Total_Adult
        '
        Me.Total_Adult.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Total_Adult.Location = New System.Drawing.Point(285, 628)
        Me.Total_Adult.Name = "Total_Adult"
        Me.Total_Adult.Size = New System.Drawing.Size(36, 26)
        Me.Total_Adult.TabIndex = 144
        Me.Total_Adult.TabStop = False
        '
        'Label22
        '
        Me.Label22.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label22.Location = New System.Drawing.Point(190, 631)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(89, 20)
        Me.Label22.TabIndex = 143
        Me.Label22.Text = "Total Adult"
        '
        'TotalChildren
        '
        Me.TotalChildren.AutoSize = True
        Me.TotalChildren.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TotalChildren.Location = New System.Drawing.Point(327, 630)
        Me.TotalChildren.Name = "TotalChildren"
        Me.TotalChildren.Size = New System.Drawing.Size(113, 20)
        Me.TotalChildren.TabIndex = 142
        Me.TotalChildren.Text = "Total Children"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label21.Location = New System.Drawing.Point(8, 631)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(134, 20)
        Me.Label21.TabIndex = 141
        Me.Label21.Text = "Total Checked In"
        '
        'TotalRSVP
        '
        Me.TotalRSVP.AutoSize = True
        Me.TotalRSVP.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.TotalRSVP.Location = New System.Drawing.Point(497, 630)
        Me.TotalRSVP.Name = "TotalRSVP"
        Me.TotalRSVP.Size = New System.Drawing.Size(96, 20)
        Me.TotalRSVP.TabIndex = 140
        Me.TotalRSVP.Text = "Total RSVP"
        '
        'Checkin_number
        '
        Me.Checkin_number.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Checkin_number.Location = New System.Drawing.Point(148, 627)
        Me.Checkin_number.Name = "Checkin_number"
        Me.Checkin_number.Size = New System.Drawing.Size(36, 26)
        Me.Checkin_number.TabIndex = 139
        Me.Checkin_number.TabStop = False
        '
        'Total_RSVPBox
        '
        Me.Total_RSVPBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Total_RSVPBox.Location = New System.Drawing.Point(599, 627)
        Me.Total_RSVPBox.Name = "Total_RSVPBox"
        Me.Total_RSVPBox.Size = New System.Drawing.Size(36, 26)
        Me.Total_RSVPBox.TabIndex = 146
        Me.Total_RSVPBox.TabStop = False
        '
        'FirstName
        '
        Me.FirstName.BackColor = System.Drawing.SystemColors.Window
        Me.FirstName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.FirstName.Location = New System.Drawing.Point(247, 579)
        Me.FirstName.Margin = New System.Windows.Forms.Padding(4)
        Me.FirstName.Multiline = False
        Me.FirstName.Name = "FirstName"
        Me.FirstName.ReadOnly = True
        Me.FirstName.Size = New System.Drawing.Size(214, 34)
        Me.FirstName.TabIndex = 147
        Me.FirstName.Text = ""
        '
        'LastName
        '
        Me.LastName.BackColor = System.Drawing.SystemColors.Window
        Me.LastName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.LastName.Location = New System.Drawing.Point(501, 579)
        Me.LastName.Margin = New System.Windows.Forms.Padding(4)
        Me.LastName.Multiline = False
        Me.LastName.Name = "LastName"
        Me.LastName.ReadOnly = True
        Me.LastName.Size = New System.Drawing.Size(214, 34)
        Me.LastName.TabIndex = 148
        Me.LastName.Text = ""
        '
        'FirstName_Label
        '
        Me.FirstName_Label.AutoSize = True
        Me.FirstName_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstName_Label.Location = New System.Drawing.Point(242, 550)
        Me.FirstName_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.FirstName_Label.Name = "FirstName_Label"
        Me.FirstName_Label.Size = New System.Drawing.Size(106, 25)
        Me.FirstName_Label.TabIndex = 149
        Me.FirstName_Label.Text = "First Name"
        '
        'LastName_Label
        '
        Me.LastName_Label.AutoSize = True
        Me.LastName_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastName_Label.Location = New System.Drawing.Point(496, 550)
        Me.LastName_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LastName_Label.Name = "LastName_Label"
        Me.LastName_Label.Size = New System.Drawing.Size(106, 25)
        Me.LastName_Label.TabIndex = 150
        Me.LastName_Label.Text = "Last Name"
        '
        'PaymentMethod
        '
        Me.PaymentMethod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PaymentMethod.DropDownHeight = 100
        Me.PaymentMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.PaymentMethod.FormattingEnabled = True
        Me.PaymentMethod.IntegralHeight = False
        Me.PaymentMethod.Items.AddRange(New Object() {"Check", "Cash", "Paypal", "Credit Card", "Honorary", "Sulekha", " "})
        Me.PaymentMethod.Location = New System.Drawing.Point(12, 695)
        Me.PaymentMethod.Margin = New System.Windows.Forms.Padding(4)
        Me.PaymentMethod.Name = "PaymentMethod"
        Me.PaymentMethod.Size = New System.Drawing.Size(214, 33)
        Me.PaymentMethod.TabIndex = 151
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label16.Location = New System.Drawing.Point(7, 666)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(160, 25)
        Me.Label16.TabIndex = 152
        Me.Label16.Text = "Payment Method"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Label17.Location = New System.Drawing.Point(262, 666)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 25)
        Me.Label17.TabIndex = 153
        Me.Label17.Text = "Channel"
        '
        'ChannelBox
        '
        Me.ChannelBox.DropDownHeight = 100
        Me.ChannelBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ChannelBox.FormattingEnabled = True
        Me.ChannelBox.IntegralHeight = False
        Me.ChannelBox.Items.AddRange(New Object() {"Sulekha", "Onsite", "In-person", "Paypal", "Mail", "Not Paid", ""})
        Me.ChannelBox.Location = New System.Drawing.Point(267, 695)
        Me.ChannelBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ChannelBox.Name = "ChannelBox"
        Me.ChannelBox.Size = New System.Drawing.Size(158, 33)
        Me.ChannelBox.TabIndex = 154
        '
        'Tickets_Label
        '
        Me.Tickets_Label.AutoSize = True
        Me.Tickets_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Tickets_Label.Location = New System.Drawing.Point(718, 550)
        Me.Tickets_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Tickets_Label.Name = "Tickets_Label"
        Me.Tickets_Label.Size = New System.Drawing.Size(75, 25)
        Me.Tickets_Label.TabIndex = 155
        Me.Tickets_Label.Text = "Tickets"
        '
        'TicketsBox
        '
        Me.TicketsBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TicketsBox.Location = New System.Drawing.Point(723, 579)
        Me.TicketsBox.Margin = New System.Windows.Forms.Padding(4)
        Me.TicketsBox.Multiline = False
        Me.TicketsBox.Name = "TicketsBox"
        Me.TicketsBox.Size = New System.Drawing.Size(47, 34)
        Me.TicketsBox.TabIndex = 156
        Me.TicketsBox.Text = ""
        '
        'Adult_Check_Label
        '
        Me.Adult_Check_Label.AutoSize = True
        Me.Adult_Check_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Adult_Check_Label.Location = New System.Drawing.Point(343, 478)
        Me.Adult_Check_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Adult_Check_Label.Name = "Adult_Check_Label"
        Me.Adult_Check_Label.Size = New System.Drawing.Size(117, 20)
        Me.Adult_Check_Label.TabIndex = 157
        Me.Adult_Check_Label.Text = "Adult Check In"
        '
        'Children_Check_Label
        '
        Me.Children_Check_Label.AutoSize = True
        Me.Children_Check_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Children_Check_Label.Location = New System.Drawing.Point(465, 479)
        Me.Children_Check_Label.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Children_Check_Label.Name = "Children_Check_Label"
        Me.Children_Check_Label.Size = New System.Drawing.Size(141, 20)
        Me.Children_Check_Label.TabIndex = 158
        Me.Children_Check_Label.Text = "Children Check In"
        '
        'Adult_CheckBox
        '
        Me.Adult_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Adult_CheckBox.Location = New System.Drawing.Point(347, 503)
        Me.Adult_CheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.Adult_CheckBox.Multiline = False
        Me.Adult_CheckBox.Name = "Adult_CheckBox"
        Me.Adult_CheckBox.Size = New System.Drawing.Size(47, 34)
        Me.Adult_CheckBox.TabIndex = 159
        Me.Adult_CheckBox.Text = ""
        '
        'Children_CheckBox
        '
        Me.Children_CheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.Children_CheckBox.Location = New System.Drawing.Point(469, 502)
        Me.Children_CheckBox.Margin = New System.Windows.Forms.Padding(4)
        Me.Children_CheckBox.Multiline = False
        Me.Children_CheckBox.Name = "Children_CheckBox"
        Me.Children_CheckBox.Size = New System.Drawing.Size(47, 34)
        Me.Children_CheckBox.TabIndex = 160
        Me.Children_CheckBox.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(717, 656)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 24)
        Me.Button1.TabIndex = 161
        Me.Button1.Text = "Test"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'EventView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1530, 778)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Children_CheckBox)
        Me.Controls.Add(Me.Adult_CheckBox)
        Me.Controls.Add(Me.Children_Check_Label)
        Me.Controls.Add(Me.Adult_Check_Label)
        Me.Controls.Add(Me.TicketsBox)
        Me.Controls.Add(Me.Tickets_Label)
        Me.Controls.Add(Me.ChannelBox)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PaymentMethod)
        Me.Controls.Add(Me.LastName_Label)
        Me.Controls.Add(Me.FirstName_Label)
        Me.Controls.Add(Me.LastName)
        Me.Controls.Add(Me.FirstName)
        Me.Controls.Add(Me.Total_RSVPBox)
        Me.Controls.Add(Me.Total_Children)
        Me.Controls.Add(Me.Total_Adult)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TotalChildren)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TotalRSVP)
        Me.Controls.Add(Me.Checkin_number)
        Me.Controls.Add(Me.Adult_RSVPBox)
        Me.Controls.Add(Me.Children_RSVPBox)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.RSVPBOX)
        Me.Controls.Add(Me.Check_In_Box)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.EventName_Text)
        Me.Controls.Add(Me.Event_Id_Label)
        Me.Controls.Add(Me.MemberId_Text)
        Me.Controls.Add(Me.Member_Id_Label)
        Me.Controls.Add(Me.DBUpdateHand)
        Me.Controls.Add(Me.ViewDatabase)
        Me.Controls.Add(Me.Event_Grid)
        Me.Controls.Add(Me.Event_Label)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "EventView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EventView"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Event_Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddEventToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GoToToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MainViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChildViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Event_Label As Label
    Friend WithEvents Event_Grid As DataGridView
    Friend WithEvents ViewDatabase As Button
    Friend WithEvents DBUpdateHand As Button
    Friend WithEvents Member_Id_Label As Label
    Friend WithEvents Event_Id_Label As Label
    Friend WithEvents EventName_Text As RichTextBox
    Friend WithEvents Check_In_Box As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents RSVPBOX As ComboBox
    Friend WithEvents Adult_RSVPBox As RichTextBox
    Friend WithEvents Children_RSVPBox As RichTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Total_Children As TextBox
    Friend WithEvents Total_Adult As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents TotalChildren As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents TotalRSVP As Label
    Friend WithEvents Checkin_number As TextBox
    Friend WithEvents Total_RSVPBox As TextBox
    Friend WithEvents MemberId_Text As RichTextBox
    Friend WithEvents FirstName As RichTextBox
    Friend WithEvents LastName As RichTextBox
    Friend WithEvents FirstName_Label As Label
    Friend WithEvents LastName_Label As Label
    Friend WithEvents PaymentMethod As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents ChannelBox As ComboBox
    Friend WithEvents Tickets_Label As Label
    Friend WithEvents TicketsBox As RichTextBox
    Friend WithEvents Adult_Check_Label As Label
    Friend WithEvents Children_Check_Label As Label
    Friend WithEvents Adult_CheckBox As RichTextBox
    Friend WithEvents Children_CheckBox As RichTextBox
    Friend WithEvents Button1 As Button
End Class
