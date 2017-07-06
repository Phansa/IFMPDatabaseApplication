Imports System.Text.RegularExpressions
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

Public Class Form2
    Public Property admin_status As String
    Public form2_string As String
    Public save_password As Boolean

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        If Not My.Settings.DB_Password = "" Then
            RememberPassword.Checked = True
            TextBox1.Text = My.Settings.DB_Password
            TextBox1_TextChanged(sender, e)
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        form2_string = TextBox1.Text
    End Sub

    'Test a connection with a similar query and only allows the user on the main page if it succeeds.
    Private Sub LogOn_Click(sender As Object, e As EventArgs) Handles LogOn.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        Try
            con.ConnectionString = "DBInfo" & form2_string & "DBInfo cont."
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "select * from membership where Id = @id"
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 1
            cmd.ExecuteNonQuery()
            con.Close()
            If save_password = True Then
                My.Settings.DB_Password = form2_string
            End If
            Dim f1 As New Form1
            f1.con_string = "DBInfo" & form2_string & "DBInfo cont."
            f1.admin_status = admin_status
            f1.Show()
            Me.Close()
        Catch ex As TimeoutException
            MessageBox.Show("Your connection has timed out. Please check your internet settings.")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.UseSystemPasswordChar = False
        Else
            TextBox1.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub LogOn_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            LogOn_Click(sender, e)
        End If
    End Sub

    Private Sub RememberPassword_CheckedChanged(sender As Object, e As EventArgs) Handles RememberPassword.CheckedChanged
        If RememberPassword.Checked Then
            save_password = True
        Else
            save_password = False
        End If
    End Sub
End Class