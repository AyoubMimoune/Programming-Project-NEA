Imports System.Data.OleDb

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = True

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Timer2.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Panel1.Visible = True
        While Panel1.Height < 731
            Panel1.Height += 1
        End While
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Panel2.Visible = True
        While Panel2.Height < 721
            Panel2.Height += 1
        End While
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = False
        Panel2.Visible = False
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        While Panel2.Height >= 1
            Panel2.Height -= 1
        End While
        Panel2.Visible = False
        Timer2.Enabled = False
        Timer4.Enabled = False

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        While Panel1.Height >= 1
            Panel1.Height -= 1
        End While
        Panel1.Visible = False
        Timer1.Enabled = False
        Timer3.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Timer3.Enabled = True
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Timer4.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox5.Text = "" Then
            MsgBox("Please enter the correct information")
        ElseIf Textbox2.text <> Textbox5.text Then
            MsgBox("Your passwords do not match!")
        Else
            Try
                Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\" + TextBox6.Text + "\Documents\Database1.accdb;")
                Dim insert As String = "Insert into Table1 values('" & TextBox1.Text & "','" & TextBox2.Text & "');"
                Dim cmd As New OleDbCommand(insert, conn)
                conn.Open()
                cmd.ExecuteNonQuery()
                MsgBox("Registration successfully completed")
            Catch ex As Exception
                MsgBox("Something went wrong")
            End Try
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim uname As String = TextBox4.Text
        Dim pword As String = TextBox3.Text
        Dim username As String = ""
        Dim pass As String = "Select password From Table1 where name= '" & uname & ""
        If TextBox4.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Please fill in the textbboxes")
        Else
            uname = TextBox4.Text
            pword = TextBox3.Text
            Dim querry As String = "Select password From Table1 where name= '" & uname & "'"
            Dim dbsource As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\" + TextBox6.Text + "\Documents\Database1.accdb"
            Dim conn = New OleDbConnection(dbsource)
            Dim cmd As New OleDbCommand(querry, conn)
            conn.Open()
            Try
                pass = cmd.ExecuteScalar().ToString
            Catch ex As Exception
                MsgBox("Username does not exit")
            End Try
        End If
        If (pword = pass) Then
            MsgBox("Login successful")
            If System.IO.File.Exists("C:\Users\" + TextBox6.Text + "\Desktop\" + TextBox4.Text + ".png") Then
                Dim result = MsgBox("Yes to create new timetable  " + vbCrLf + "No to view current timetable.", vbYesNo)
                If result = MsgBoxResult.Yes Then
                    Form2.Show()
                    Me.Hide()
                ElseIf result = MsgBoxResult.No Then
                    Process.Start("C:\Users\" + TextBox6.Text + "\Desktop\" + TextBox4.Text + ".png")
                    Me.Close()
                End If
            End If
            If (pword = pass) Then
                Form2.Show()
                Me.Hide()

            End If
        Else
            MsgBox("Login Failed")
            TextBox4.Clear()
            TextBox3.Clear()
        End If
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TextBox3.PasswordChar = "*"c
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.PasswordChar = "*"c
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox5.PasswordChar = "*"c
    End Sub
End Class
