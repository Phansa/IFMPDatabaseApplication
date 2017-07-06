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

Public Class Date_Time
    Public Property con_string As String
    Public Property id_int As Long

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd As New SqlCommand()
        Dim con As New SqlConnection()
        con.ConnectionString = con_string
        cmd.Connection = con
        cmd.CommandText = "Update [Membership] set [Date Signed Up]=@Date where [Id]=@ID "
        cmd.Parameters.AddWithValue("@Date", DateTimePicker1.Value)
        cmd.Parameters.AddWithValue("@ID", id_int)
        con.Open()
        cmd.ExecuteNonQuery()
        con.Close()
        Dim f1 As New Form1
        f1.con_string = con_string
        f1.id_public = id_int.ToString()
        f1.Show()
        Me.Close()
    End Sub

    Private Sub Date_Time_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class