Imports System.Data.OleDb

Public Class Form1
    '''''''''''''''''''''''''''PANEL ANIMATIONS'''''''''''''''''''''''''''''''''''
    'These timers are programmed to that a panel falls down depending on whether the students chooses to register or log in.
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
    ''''''''''''''''''''''''''''''''''''''Registering user into the database '''''''''''''''''''''''''''''''''''''
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox5.Text = "" Then 'Check if the textboxes are empty
            MsgBox("Please enter the correct information") 'Notifies  user that they haven't entered their information 
        ElseIf Textbox2.text <> Textbox5.text Then'Checking if passwords do not match
            MsgBox("Your passwords do not match!")'Notifies users passwords do not match
        Else
            Try
                'Finds the database source
                Dim conn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\" + TextBox6.Text + "\Documents\Database1.accdb;")
                Dim insert As String = "Insert into Table1 values('" & TextBox1.Text & "','" & TextBox2.Text & "');" 'Query to insert user data in database 
                Dim cmd As New OleDbCommand(insert, conn) 
                conn.Open()'Opening the connection with database
                cmd.ExecuteNonQuery()'Executing the query
                MsgBox("Registration successfully completed")'If the user values are successfully inputted then the user will be notified
            Catch ex As Exception 'Checks for any other outcome than the one expected
                MsgBox("Something went wrong")'However in any case where the users data is not inserted into the database then it will tell the user
            End Try
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim uname As String = TextBox4.Text
        Dim pword As String = TextBox3.Text
        Dim username As String = ""
        Dim pass As String = "Select password From Table1 where name= '" & uname & "" 'Selects the password which matches the username given
        If TextBox4.Text = "" Or TextBox3.Text = "" Then 'Checks if textboxes are empty and notifies user
            MsgBox("Please fill in the textbboxes")
        Else
            uname = TextBox4.Text
            pword = TextBox3.Text
            Dim querry As String = "Select password From Table1 where name= '" & uname & "'"'Selects the password which matches the username given
            'Finds the source of the database 
            Dim dbsource As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\" + TextBox6.Text + "\Documents\Database1.accdb"
            Dim conn = New OleDbConnection(dbsource)'Them conn variable allows the connection between VB and MS Acess to exist when executed
            Dim cmd As New OleDbCommand(querry, conn)'A query that opens the connection between VB and the database which passes the query.
            conn.Open()'Opens the connection between VB and the Database source
            Try
                pass = cmd.ExecuteScalar().ToString'Fetches the password for the given username
            Catch ex As Exception'Checks for any outcomes other than the outcome intended
                MsgBox("Username does not exit")'If there is no password with that username then the user will know
            End Try
        End If
        If (pword = pass) Then 'Checks if the password fetched is the same that has been entered into the form
            MsgBox("Login successful") 'If the passwords match then the user will be notified
            If System.IO.File.Exists("C:\Users\" + TextBox6.Text + "\Desktop\" + TextBox4.Text + ".png") Then 'Checking if a timetable exists
                'Result retrieves the input from the user to the messagebox asking the user whether they want to create a new timetable or not
                Dim result = MsgBox("Yes to create new timetable  " + vbCrLf + "No to view current timetable.", vbYesNo)
                If result = MsgBoxResult.Yes Then'Checks if the user selected yes to create a new timetable
                    Form2.Show()'Directs the user to the next form
                    Me.Hide()'Hides the current form
                ElseIf result = MsgBoxResult.No Then 'However if the user does not want to create timetable
                    Process.Start("C:\Users\" + TextBox6.Text + "\Desktop\" + TextBox4.Text + ".png")'Their current timetable will be displayed
                    Me.Close()'Hides the current form
                End If
            Else If (pword = pass) Then 'If the user currently does not have a timetable then they will be directed to the next form
                Form2.Show()
                Me.Hide()
            End If
            End If
        Else 'Any other outcome will result in the user being notified that their login failed.  
            MsgBox("Login Failed")
            TextBox4.Clear()
            TextBox3.Clear()
        End If
    End Sub
    ''''''''''''''''Hiding password from the user to ensure security'''''''''''''''''''''''''''
    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        TextBox3.PasswordChar = "*"c'Replaces each letter in the textbox with an asterisk
    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        TextBox2.PasswordChar = "*"c
    End Sub
    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        TextBox5.PasswordChar = "*"c
    End Sub
End Class
