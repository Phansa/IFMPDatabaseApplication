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

Public Class Add_Method
    Public Property con_string As String
    Public Property admin_status As Boolean
    Public Property id_public As String

    Private Sub MainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Event_TextBox.Text = "" Then
            MessageBox.Show("Please make sure method name is filled out before trying to update")
            Exit Sub
        End If
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "Insert into [PaymentMethods]([Method]) VALUES (@Method)"
        cmd.Parameters.AddWithValue("@Method", Event_TextBox.Text)
        cmd.ExecuteNonQuery()
        con.Close()
        view_events(sender, e)
    End Sub

    Private Sub view_events(sender As Object, e As EventArgs)
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = con_string
            cmd.Connection = con
            cmd.CommandText = "Select * from [PaymentMethods]"
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

    Private Sub AddEvent_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim test_form As New Form1
        test_form.con_string = con_string
        test_form.admin_status = admin_status
        If My.Settings.IdThroughForms = "Yes" Then
            test_form.id_public = id_public
        End If
        test_form.Show()
    End Sub

    Private Sub Add_Event_Load(sender As Object, e As EventArgs) Handles Me.Load
        view_events(sender, e)
    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
        Me.Close()
    End Sub
End Class