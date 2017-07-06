Public Class Resize
    Public size1 As String
    Public Property form_number As String
    Public Property first_time As Boolean
    Public Property admin_status As String
    Public Property con_string As String

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        size1 = ComboBox1.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.Resize = size1
        My.Settings.Save()
        If form_number = 3 Then
            Dim form_3 As New Form3
            form_3.Visible = True
            form_3.ShowInTaskbar = True
            Me.Close()
        End If
        If form_number = 1 Then
            Dim form_1 As New Form1
            form_1.con_string = con_string
            form_1.admin_status = admin_status
            form_1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Resize_Load(sender As Object, e As EventArgs) Handles Me.Load
        If first_time = True Then
            MessageBox.Show("Since this is your first time using this application, please select a graphical display option.")
        End If
        If Not My.Settings.Resize = "" Then
            ComboBox1.SelectedItem = My.Settings.Resize
        End If
    End Sub

End Class