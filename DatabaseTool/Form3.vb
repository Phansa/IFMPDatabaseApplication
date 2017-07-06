Public Class Form3
    Public admin_status As Boolean
    Public password As String
    Public savepassword As Boolean

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        password = TextBox1.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f2 As New Form2
        f2.admin_status = False
        f2.Show()
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox1.UseSystemPasswordChar = False
        Else
            TextBox1.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub textbox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button2_Click(sender, e)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If password = "Password" Then
            If savepassword = True Then
                My.Settings.Admin_Password = password
                My.Settings.Save()
            End If
            Dim f2 As New Form2
            f2.admin_status = True
            f2.Show()
            Me.Close()
        Else
            MessageBox.Show("Please enter the correct password")
            TextBox1.Clear()
            My.Settings.Admin_Password = ""
            My.Settings.Save()
        End If
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles Me.Load
        If My.Settings.Resize = "" Then
            Me.Visible = False
            Me.ShowInTaskbar = False
            Dim resize As New Resize
            resize.form_number = 3
            resize.first_time = True
            resize.Show()
        End If
        If Not My.Settings.Admin_Password = "" Then
            Save_Password.Checked = True
            TextBox1.Text = My.Settings.Admin_Password
            TextBox1_TextChanged(sender, e)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        My.Settings.Resize = ""
        My.Settings.Save()
        Form3_Load(sender, e)
    End Sub

    Private Sub Save_Password_CheckedChanged(sender As Object, e As EventArgs) Handles Save_Password.CheckedChanged
        If Save_Password.Checked Then
            savepassword = True
        Else
            savepassword = False
        End If
    End Sub
End Class