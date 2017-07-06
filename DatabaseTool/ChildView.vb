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

Public Class ChildView
    Public Property con_string As String
    Public Property admin_status As Boolean
    Public Property member_id As Int64
    Public Property last_name As String
    'Child
    Public child_id As Int64
    Public child_name As String
    Public child_age As String
    Public child_school As String
    Public Relationship As String
    'Adult
    Public adult_id As Int64
    Public adult_name As String
    Public adult_age As String

    Private Sub ChildView_Load(sender As Object, e As EventArgs) Handles Me.Load
        Delete_All.Visible = False
        AddAdultToolStripMenuItem.Visible = False
        MemberID.Text = member_id.ToString()
        DBUpdateHand.Visible = False
        Add_Adult.Visible = False
        Remove_Adult.Visible = False
        Remove.Visible = False
        ViewDatabase_Click(sender, e)
        View_Adult_Click(sender, e)
        If My.Settings.Resize = "1080 x 720" Then
            Me.Width = 1080
            Me.Height = 720
        End If
    End Sub

    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ADD CHILD SECTION @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ADD CHILD SECTION @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ADD CHILD SECTION @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    Private Sub addchild(sender As Object, e As EventArgs)
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "select top 1 [Child Id] From [Child] where [Id]=@Id Order By [Child Id] DESC;"
        cmd.Parameters.AddWithValue("@Id", member_id)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds2 As New DataSet()
        con.Open()
        cmd.ExecuteNonQuery()
        sqlquery.Fill(ds2, "Id_Table")
        con.Close()
        If ds2.Tables(0).Rows.Count > 0 Then
            ChildId.Text = ds2.Tables(0).Rows(0).Item(0) + 1
        Else
            ChildId.Text = 1
        End If
        'Children_Grid.DataSource = ds2
        'Children_Grid.DataMember = "Id_Table"
    End Sub

    Private Sub AddChildToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddChildToolStripMenuItem.Click
        addchild(sender, e)
        DBUpdateHand.Visible = True
        ChildId.ReadOnly = True
    End Sub

    Private Sub DBUpdateHand_Click(sender As Object, e As EventArgs) Handles DBUpdateHand.Click
        If ChildName.Text = "" Then
            MessageBox.Show("Please enter a child name before udpating")
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim cmd2 As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Insert into [Child] ([Id], [Child Id], [Name], " &
                    "[Age], [School Name], [Relationship]) VALUES (@Id, @ChildId, " &
                    "@Name, @Age, @SchoolName, @Relationship)"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@ChildId", child_id)
            cmd.Parameters.AddWithValue("@Name", child_name)
            cmd2.Connection = con
            cmd2.CommandText = "Select [Id], [Child Id], [Name], [Last Name], [Age], [School Name] from [Child] where [Id] = @ID"
            cmd2.Parameters.AddWithValue("@ID", member_id)
            Dim sqlquery As New SqlDataAdapter(cmd2)
            Dim ds As New DataSet()
            'Child Age, default 0 
            If child_age = 0 Then
                cmd.Parameters.AddWithValue("@Age", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Age", child_age)
            End If
            'Child School
            If child_school = "" Then
                cmd.Parameters.AddWithValue("@SchoolName", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@SchoolName", child_school)
            End If
            'Relationship
            If Relationship = "" Then
                cmd.Parameters.AddWithValue("@Relationship", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Relationship", Relationship)
            End If

            cmd.ExecuteNonQuery()
            sqlquery.Fill(ds, "Membership_Table")
            Children_Grid.DataSource = ds
            Children_Grid.DataMember = "Membership_Table"
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MessageBox.Show("Please enter a unique Membership ID Number")
            Else
                MessageBox.Show("Error:" & ex.Message)
            End If
        Finally
            con.Close()
        End Try
        ChildId_TextChanged(sender, e)
        addchild(sender, e)
    End Sub

    Private Sub ChildId_TextChanged(sender As Object, e As EventArgs) Handles ChildId.TextChanged
        If ChildId.TextLength = 0 Then
            ChildName.Clear()
            ChildAge.Clear()
            ChildSchool.Clear()
            RelationshipBox.Clear()
            child_name = ""
            child_age = 0
            child_school = ""
            View(sender, e)
        Else
            Try
                Int64.Parse(ChildId.Text)
                child_id = Int64.Parse(ChildId.Text)
                ChildName.Clear()
                ChildAge.Clear()
                ChildSchool.Clear()
                RelationshipBox.Clear()
                child_name = ""
                child_age = 0
                child_school = ""
                Try
                    Dim cmd As New SqlCommand()
                    Dim con As New SqlConnection()
                    con.ConnectionString = con_string
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "select * from [Child] where [Id] = @Id AND [Child Id] = @ChildId"
                    cmd.Parameters.AddWithValue("@Id", member_id)
                    cmd.Parameters.AddWithValue("@ChildId", child_id)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    reader.Read()
                    If reader.HasRows Then
                        'First Name
                        If Not reader(0) Is DBNull.Value Then
                            ChildName.Text = reader.GetString(0)
                            'child_name = reader.GetString(0)
                        End If
                        'Child Age
                        If Not reader(2) Is DBNull.Value Then
                            ChildAge.Text = reader.GetString(2)
                            'child_age = reader.GetString(2)
                        End If
                        'School Name
                        If Not reader(3) Is DBNull.Value Then
                            ChildSchool.Text = reader.GetString(3)
                            'child_school = reader.GetString(3)
                        End If
                        'Relationship
                        If Not reader(6) Is DBNull.Value Then
                            RelationshipBox.Text = reader.GetString(6)
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
                If ChildId.Text.Length > 1 Then
                    MessageBox.Show(ex.Message)
                    ChildId.Clear()
                End If
            End Try
        End If
    End Sub

    Private Sub ChildName_TextChanged(sender As Object, e As EventArgs) Handles ChildName.TextChanged
        child_name = ChildName.Text
    End Sub

    Private Sub ChildAge_TextChanged(sender As Object, e As EventArgs) Handles ChildAge.TextChanged
        Try
            Int64.Parse(ChildAge.Text)
            child_age = ChildAge.Text
        Catch ex As Exception
            If ChildAge.Text.Length > 1 Then
                MessageBox.Show(ex.Message)
                ChildAge.Clear()
            End If
        End Try
    End Sub

    Private Sub ChildSchool_TextChanged(sender As Object, e As EventArgs) Handles ChildSchool.TextChanged
        child_school = ChildSchool.Text
    End Sub

    Private Sub View(sender As Object, e As EventArgs)
        DBUpdateHand.Visible = False
        ChildId.ReadOnly = False
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Select [Id], [Child Id], [Name], [Age], [School Name], [Relationship] from [Child] where [Id] = @ID"
            cmd.Parameters.AddWithValue("@ID", member_id)
            Dim sqlquery As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            con.Open()
            sqlquery.Fill(ds, "Membership_Table")
            Children_Grid.DataSource = ds
            Children_Grid.DataMember = "Membership_Table"
        Catch ex As SqlException
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Remove.Click
        Dim message_result As DialogResult = MessageBox.Show("You cannot undo removing a child from the database. " &
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
            cmd.CommandText = "Delete from [Child] where [Id]=@Id AND [Child Id]=@ChildId;"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@ChildId", child_id)
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
        ViewDatabase_Click(sender, e)
    End Sub

    Private Sub UpdateMember_Click(sender As Object, e As EventArgs) Handles UpdateMember.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Update [Child] Set [Name] = @Name, [Age] = @Age, [School Name] = @SchoolName, [Relationship] = @Relationship Where [Id] = @Id AND [Child Id] = @ChildId;"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@ChildId", child_id)
            cmd.Parameters.AddWithValue("@Name", child_name)
            'Child Age, default 0 
            If child_age = 0 Then
                cmd.Parameters.AddWithValue("@Age", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Age", child_age)
            End If
            'Child School
            If child_school = "" Then
                cmd.Parameters.AddWithValue("@SchoolName", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@SchoolName", child_school)
            End If
            'Relationship
            If Relationship = "" Then
                cmd.Parameters.AddWithValue("@Relationship", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Relationship", Relationship)
            End If
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
        ViewDatabase_Click(sender, e)
    End Sub

    Private Sub children_grid_CellClick(ByVal sender As Object,
  ByVal e As DataGridViewCellEventArgs) _
  Handles Children_Grid.CellClick
        'ID
        If e.ColumnIndex = 1 And e.RowIndex >= 0 Then
            Dim cell As DataGridViewTextBoxCell =
        Children_Grid.Rows(e.RowIndex).
            Cells(e.ColumnIndex)
            If cell.Value.ToString IsNot "" Then
                ChildId.Text = cell.Value
                child_id = Int64.Parse(cell.Value)
            End If
        End If
    End Sub

    Private Sub RelationshipBox_TextChanged(sender As Object, e As EventArgs) Handles RelationshipBox.TextChanged
        Relationship = RelationshipBox.Text
    End Sub

    Private Sub ViewDatabase_Click(sender As Object, e As EventArgs) Handles ViewDatabase.Click
        ChildId.Text = ""
        ChildId_TextChanged(sender, e)
    End Sub

    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ADD ADULT SECTION @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ADD ADULT SECTION @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ ADD ADULT SECTION @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    Private Sub addadult(sender As Object, e As EventArgs)
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "select top 1 [Adult Id] From [Adult] where [Id]=@Id Order By [Adult Id] DESC;"
        cmd.Parameters.AddWithValue("@Id", member_id)
        Dim sqlquery As New SqlDataAdapter(cmd)
        Dim ds2 As New DataSet()
        con.Open()
        cmd.ExecuteNonQuery()
        sqlquery.Fill(ds2, "Id_Table")
        con.Close()
        If ds2.Tables(0).Rows.Count > 0 Then
            AdultId.Text = ds2.Tables(0).Rows(0).Item(0) + 1
        Else
            AdultId.Text = 1
        End If
    End Sub

    Private Sub AddAdultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddAdultToolStripMenuItem.Click
        AddAdult(sender, e)
        add_adult.Visible = True
        AdultId.ReadOnly = True
    End Sub

    Private Sub Add_Adult_Click(sender As Object, e As EventArgs) Handles Add_Adult.Click
        If AdultName.Text = "" Then
            MessageBox.Show("Please enter an Adult name before udpating")
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim cmd2 As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "Insert into [Adult] ([Id], [Adult Id], [Name], [Last Name], [Age])" &
                    "VALUES (@Id, @AdultId, " &
                    "@Name, @LastName, @Age)"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@AdultId", adult_id)
            cmd.Parameters.AddWithValue("@Name", adult_name)
            cmd.Parameters.AddWithValue("@LastName", last_name)
            'Adult Age, default 0 
            If adult_age = 0 Then
                cmd.Parameters.AddWithValue("@Age", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Age", adult_age)
            End If
            cmd2.Connection = con
            cmd2.CommandText = "Select [Id], [Adult Id], [Name], [Last Name], [Age] from [Adult] where [Id] = @ID"
            cmd2.Parameters.AddWithValue("@ID", member_id)
            Dim sqlquery As New SqlDataAdapter(cmd2)
            Dim ds As New DataSet()
            cmd.ExecuteNonQuery()
            sqlquery.Fill(ds, "Membership_Table")
            Adults_Grid.DataSource = ds
            Adults_Grid.DataMember = "Membership_Table"
        Catch ex As SqlException
            If ex.Number = 2627 Then
                MessageBox.Show("Please enter a unique Membership ID Number")
            Else
                MessageBox.Show("Error: " & ex.Message)
            End If
        Finally
            con.Close()
        End Try
        AdultId_TextChanged(sender, e)
        addadult(sender, e)
    End Sub

    Private Sub AdultId_TextChanged(sender As Object, e As EventArgs) Handles AdultId.TextChanged
        If AdultId.TextLength = 0 Then
            AdultName.Clear()
            child_name = ""
            adult_age = 0
            AdultAge.Clear()
            ViewAdult(sender, e)
        Else
            Try
                Int64.Parse(AdultId.Text)
                adult_id = Int64.Parse(AdultId.Text)
                AdultName.Clear()
                adult_name = ""
                adult_age = 0
                AdultAge.Clear()
                Try
                    Dim cmd As New SqlCommand()
                    Dim con As New SqlConnection()
                    con.ConnectionString = con_string
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = "select * from [Adult] where [Id] = @Id AND [Adult Id] = @AdultId"
                    cmd.Parameters.AddWithValue("@Id", member_id)
                    cmd.Parameters.AddWithValue("@AdultId", adult_id)
                    Dim reader As SqlDataReader = cmd.ExecuteReader()
                    reader.Read()
                    If reader.HasRows Then
                        'First Name
                        If Not reader(0) Is DBNull.Value Then
                            AdultName.Text = reader.GetString(0)
                            adult_name = reader.GetString(0)
                        End If
                        'Adult Age
                        If Not reader(2) Is DBNull.Value Then
                            AdultAge.Text = reader.GetString(2)
                            adult_age = reader.GetString(2)
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
                If AdultId.Text.Length > 1 Then
                    MessageBox.Show(ex.Message)
                    AdultId.Clear()
                End If
            End Try
        End If
    End Sub

    Private Sub AdultName_TextChanged(sender As Object, e As EventArgs) Handles AdultName.TextChanged
        adult_name = AdultName.Text
    End Sub

    Private Sub AdultAge_TextChanged(sender As Object, e As EventArgs) Handles AdultAge.TextChanged
        Try
            Int64.Parse(AdultAge.Text)
            adult_age = AdultAge.Text
        Catch ex As Exception
            If AdultAge.Text.Length > 1 Then
                MessageBox.Show(ex.Message)
                AdultAge.Clear()
            End If
        End Try
    End Sub

    Private Sub ViewAdult(sender As Object, e As EventArgs)
        Add_Adult.Visible = False
        AdultId.ReadOnly = False
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Select [Id], [Adult Id], [Name], [Last Name], [Age] from [Adult] where [Id] = @ID"
            cmd.Parameters.AddWithValue("@ID", member_id)
            Dim sqlquery As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            con.Open()
            sqlquery.Fill(ds, "Membership_Table")
            Adults_Grid.DataSource = ds
            Adults_Grid.DataMember = "Membership_Table"
        Catch ex As SqlException
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Remove_Adult_Click(sender As Object, e As EventArgs) Handles Remove_Adult.Click
        Dim message_result As DialogResult = MessageBox.Show("You cannot undo removing an adult from the database. " &
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
            cmd.CommandText = "Delete from [Adult] where [Id]=@Id AND [Adult Id]=@AdultId;"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@AdultId", adult_id)
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
        View_Adult_Click(sender, e)
    End Sub

    Private Sub Update_Adult_Click(sender As Object, e As EventArgs) Handles Update_Adult.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Update [Adult] Set [Name] = @Name, [Age]=@Age Where [Id] = @Id AND [Adult Id] = @AdultId;"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@AdultId", adult_id)
            cmd.Parameters.AddWithValue("@Name", adult_name)
            'Child Age, default 0 
            If adult_age = 0 Then
                cmd.Parameters.AddWithValue("@Age", DBNull.Value)
            Else
                cmd.Parameters.AddWithValue("@Age", adult_age)
            End If
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
        View_Adult_Click(sender, e)
    End Sub

    Private Sub adults_grid_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Adults_Grid.CellClick
        'ID
        If e.ColumnIndex = 1 And e.RowIndex >= 0 Then
            Dim cell As DataGridViewTextBoxCell =
        Adults_Grid.Rows(e.RowIndex).
            Cells(e.ColumnIndex)
            If cell.Value.ToString IsNot "" Then
                AdultId.Text = cell.Value
                adult_id = Int64.Parse(cell.Value)
            End If
        End If
    End Sub

    Private Sub View_Adult_Click(sender As Object, e As EventArgs) Handles View_Adult.Click
        AdultId.Text = ""
        AdultId_TextChanged(sender, e)
    End Sub

    Private Sub MainViewToolStripMenuItem_Click(sender As Object, e As EventArgs)
        GoToMain(sender, e)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Delete_All.Click
        Dim message_result As DialogResult = MessageBox.Show("You cannot undo removing all children from the database. " &
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
            cmd.CommandText = "Delete from [Child] where [Id]=@Id;"
            cmd.Parameters.AddWithValue("@Id", member_id)
            cmd.Parameters.AddWithValue("@ChildId", child_id)
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
        ViewDatabase_Click(sender, e)
    End Sub

    Private Sub ViewAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewAllToolStripMenuItem.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Select * from [Child]"
            Dim sqlquery As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            con.Open()
            sqlquery.Fill(ds, "Membership_Table")
            Children_Grid.DataSource = ds
            Children_Grid.DataMember = "Membership_Table"
        Catch ex As SqlException
            MessageBox.Show("Error:" & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub MainViewToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles MainViewToolStripMenuItem.Click
        GoToMain(sender, e)
    End Sub

    Private Sub ManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem.Click
        Dim help_form As New Manual
        help_form.admin_status = admin_status
        help_form.id_public = member_id
        help_form.con_string = con_string
        help_form.Show()
        Me.Close()
    End Sub

    Private Sub GoToMain(sender As Object, e As EventArgs) 'Handles GoToMain.Click
        Dim f1 As New Form1
        f1.con_string = con_string
        f1.admin_status = admin_status
        If My.Settings.IdThroughForms = "Yes" Then
            f1.id_public = member_id.ToString
        End If
        f1.Show()
        Me.Close()
    End Sub
End Class