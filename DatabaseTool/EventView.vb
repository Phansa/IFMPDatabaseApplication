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

Public Class EventView
    Public Property con_string As String
    Public Property admin_status As Boolean
    Public Property member_id As Int64
    Public event_name As String
    Public check_in As String
    Public RSVP_Status As String
    Public adult_rsvp As String
    Public children_rsvp As String
    Public rsvp_added As String
    Public total_rsvp As Int64
    Public payment_method As String
    Public channel As String
    Public tickets As String
    Public adult_check As String
    Public children_check As String
    Public check_in_int As Int64
    Public adult_rsvp_int As Int64
    Public children_rsvp_int As Int64

    Private Sub add_CheckIn(sender As Object, e As EventArgs)
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        Dim ds As New DataSet()
        check_in_int = 0
        adult_rsvp_int = 0
        children_rsvp_int = 0
        cmd.CommandText = "select [Adults Check In], [Children Check In] from [Event] where [Check In Status] = @CheckIn"
        cmd.Parameters.AddWithValue("@CheckIn", "Yes")
        Dim sqlquery As New SqlDataAdapter(cmd)
        sqlquery.Fill(ds, "Temp_Table")
        con.Close()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            adult_rsvp_int += ds.Tables(0).Rows(i).Item(0)
            children_rsvp_int += ds.Tables(0).Rows(i).Item(1)
        Next
        check_in_int = adult_rsvp_int + children_rsvp_int
        Checkin_number.Text = check_in_int.ToString()
        Total_Adult.Text = adult_rsvp_int.ToString()
        Total_Children.Text = children_rsvp_int.ToString()
    End Sub

    Private Sub add_RSVP(sender As Object, e As EventArgs)
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        Dim ds As New DataSet()
        check_in_int = 0
        adult_rsvp_int = 0
        children_rsvp_int = 0
        cmd.CommandText = "select [RSVP Size] from [Event] where [RSVP Status] = @RSVP"
        cmd.Parameters.AddWithValue("@RSVP", "Yes")
        Dim sqlquery As New SqlDataAdapter(cmd)
        sqlquery.Fill(ds, "Temp_Table")
        con.Close()
        For i = 0 To ds.Tables(0).Rows.Count - 1
            total_rsvp += ds.Tables(0).Rows(i).Item(0)
        Next
        Total_RSVPBox.Text = total_rsvp.ToString()
    End Sub

    Private Sub MainViewToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles MainViewToolStripMenuItem.Click
        Dim f1 As New Form1
        f1.con_string = con_string
        f1.admin_status = admin_status
        f1.Show()
        Me.Close()
    End Sub

    Private Sub EventView_Load(sender As Object, e As EventArgs) Handles Me.Load
        View(sender, e)
        add_RSVP(sender, e)
        add_CheckIn(sender, e)
        DBUpdateHand.Visible = False
        If My.Settings.Resize = "1080 x 720" Then
            Me.Width = 1080
            Me.Height = 720
            Event_Label.Location = New Point(649, 0)
            Member_Id_Label.Location = New Point(7, 405)
            MemberId_Text.Location = New Point(7, 434)
        End If
        MemberId_Text.Text = member_id.ToString()
    End Sub

    Private Sub View(sender As Object, e As EventArgs)
        DBUpdateHand.Visible = False
        MemberId_Text.ReadOnly = False
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Select * from [Event]"
            Dim sqlquery As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            con.Open()
            sqlquery.Fill(ds, "Event_Table")
            Event_Grid.DataSource = ds
            Event_Grid.DataMember = "Event_Table"
        Catch ex As SqlException
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub ViewDatabase_Click(sender As Object, e As EventArgs) Handles ViewDatabase.Click
        View(sender, e)
    End Sub

    Private Sub ChildViewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChildViewToolStripMenuItem.Click
        If member_id = 0 Then
            MessageBox.Show("Please enter a Member ID before attempting to view the Child View table")
            Exit Sub
        End If
        Dim f1 As New ChildView
        f1.con_string = con_string
        f1.admin_status = admin_status
        f1.member_id = member_id
        f1.Show()
        Me.Close()
    End Sub

    Private Sub AddEventToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddEventToolStripMenuItem.Click
        DBUpdateHand.Visible = True
        MemberId_Text.ReadOnly = True
    End Sub

    Private Sub EventName_Text_TextChanged(sender As Object, e As EventArgs) Handles EventName_Text.TextChanged
        event_name = EventName_Text.Text
        payment_method = ""
        channel = ""
        Adult_RSVPBox.Clear()
        Children_RSVPBox.Clear()
        Adult_CheckBox.Clear()
        Children_CheckBox.Clear()
        FirstName.Clear()
        LastName.Clear()
        TicketsBox.Clear()
        RSVPBOX.SelectedIndex = 2
        Check_In_Box.SelectedIndex = 2
        PaymentMethod.SelectedIndex = 6
        ChannelBox.SelectedIndex = 6
        Try
            Dim cmd As New SqlCommand()
            Dim con As New SqlConnection()
            con.ConnectionString = con_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Select * from [Event] where [Id] = @Id and [Event Name] = @EventName"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@EventName", event_name)
            Dim reader As SqlDataReader = cmd.ExecuteReader()
            reader.Read()
            If reader.HasRows Then
                'First Name
                If Not reader(2) Is DBNull.Value Then
                    FirstName.Text = reader.GetString(2)
                End If
                'Last Name
                If Not reader(3) Is DBNull.Value Then
                    LastName.Text = reader.GetString(3)
                End If
                'RSVP Status
                RSVPBOX.SelectedItem = reader.GetString(4)
                RSVP_Status = reader.GetString(4)
                'Check In Status
                Check_In_Box.SelectedItem = reader.GetString(5)
                check_in = reader.GetString(5)
                'Payment Method
                If Not reader(6) Is DBNull.Value Then
                    PaymentMethod.SelectedItem = reader.GetString(6)
                    payment_method = reader.GetString(6)
                End If
                'Channel
                If Not reader(7) Is DBNull.Value Then
                    ChannelBox.SelectedItem = reader.GetString(7)
                    channel = reader.GetString(7)
                End If
                'Tickets
                TicketsBox.Text = reader.GetString(8)
                tickets = reader.GetString(8)
                'Adult RSVP
                Adult_RSVPBox.Text = reader.GetString(9)
                adult_rsvp = reader.GetString(9)
                'Children RSVP
                Children_RSVPBox.Text = reader.GetString(10)
                children_rsvp = reader.GetString(10)
                'RSVP Total
                rsvp_added = reader.GetString(11)
                'Adult Check In
                Adult_CheckBox.Text = reader.GetString(12)
                adult_check = reader.GetString(12)
                'Children Check In
                Children_CheckBox.Text = reader.GetString(13)
                children_check = reader.GetString(13)
                reader.Close()
                con.Close()
            Else
                con.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        If EventName_Text.TextLength = 0 Then
            payment_method = ""
            channel = ""
            Adult_RSVPBox.Clear()
            Children_RSVPBox.Clear()
            Adult_CheckBox.Clear()
            Children_CheckBox.Clear()
            FirstName.Clear()
            LastName.Clear()
            TicketsBox.Clear()
            RSVPBOX.SelectedIndex = 2
            Check_In_Box.SelectedIndex = 2
            PaymentMethod.SelectedIndex = 6
            ChannelBox.SelectedIndex = 6
            View(sender, e)
        End If
    End Sub

    Private Sub Adult_TextChanged(sender As Object, e As EventArgs) Handles Adult_RSVPBox.TextChanged
        adult_rsvp = Adult_RSVPBox.Text
    End Sub

    Private Sub Children_TextChanged(sender As Object, e As EventArgs) Handles Children_RSVPBox.TextChanged
        children_rsvp = Children_RSVPBox.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As New SqlCommand()
        Dim cmd2 As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd2.Connection = con
        cmd2.CommandText = "Select * from [Membership] where [Id] = @Id"
        cmd2.Parameters.AddWithValue("@Id", member_id)
        Dim reader As SqlDataReader = cmd2.ExecuteReader()
        reader.Read()
        cmd.CommandText = "Update [Event] Set [First Name] = @FirstName, [Last Name]=@LastName, [RSVP Status]=@RSVP, " & _
            "[Check In Status]=@CheckIn, [Payment Method]=@Payment, [Channel]=@Channel, [Adults RSVP]=@Adult, [Children RSVP]=@Children, " & _
        "[RSVP Size]=@RSVP2, [Adults Check In]=@Adult2, [Children Check In]=@Children2 where [Id] = @Id and [Event Name] = @EventName"
        cmd.Parameters.AddWithValue("@FirstName", reader.GetString(1))
        cmd.Parameters.AddWithValue("@LastName", reader.GetString(2))
        cmd.Parameters.AddWithValue("@RSVP", reader.GetString(6))
        cmd.Parameters.AddWithValue("@CheckIn", reader.GetString(7))
        cmd.Parameters.AddWithValue("@Payment", reader.GetString(13))
        cmd.Parameters.AddWithValue("@Channel", reader.GetString(14))
        cmd.Parameters.AddWithValue("@Adult", reader.GetString(10))
        cmd.Parameters.AddWithValue("@Children", reader.GetString(9))
        cmd.Parameters.AddWithValue("@RSVP2", reader.GetString(8))
        cmd.Parameters.AddWithValue("@Adult2", reader.GetString(24))
        cmd.Parameters.AddWithValue("@Children2", reader.GetString(25))
        cmd.Parameters.AddWithValue("@Id", member_id)
        cmd.Parameters.AddWithValue("@EventName", event_name)
        reader.Close()
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Private Sub Event_Grid_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Event_Grid.CellClick
        'Event Name
        If e.ColumnIndex = 1 And e.RowIndex >= 0 Then
            Dim cell As DataGridViewTextBoxCell = Event_Grid.Rows(e.RowIndex).
            Cells(e.ColumnIndex)
            If cell.Value.ToString IsNot "" Then
                EventName_Text.Text = cell.Value
                event_name = cell.Value
            End If
        End If
    End Sub

    Private Sub DBUpdateHand_Click(sender As Object, e As EventArgs) Handles DBUpdateHand.Click

    End Sub
End Class