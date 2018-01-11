Public Class Form2
    Public y As Integer
    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Button5.Visible = False
        Button6.Visible = False

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''ADDING THE CHOSEN TIMETABLE TO LISTBOX
        If ListBox1.Items.Count > 5 Then
            MsgBox("You cannot input any more")
        End If
        If ListBox1.Items.Contains(RadioButton1.Text) Then
            MsgBox("You have already picked your timetable")
        Else
            If RadioButton1.Checked = True Then
                ListBox1.Items.Add(RadioButton1.Text)
            Else
                ListBox1.Items.Add(RadioButton2.Text)
            End If
        End If
        ''''''''''''''''''''''''''''''''''''''' ADDING CHECKBOX TEXT TO LISTBOX
        For Each Control In Me.Controls
            If TypeOf Control Is CheckBox Then
                If CType(Control, CheckBox).Checked Then
                    If ListBox1.Items.Contains(Control.text) Then
                    Else
                        ListBox1.Items.Add(Control.Text)
                        y += 1
                    End If
                End If
            End If



        Next



        '''''''''''''''''''''''''''''''''''''''''''' ADDING THE SELECTED AMOUNT OF HOURS TO LISTBOX
        If ListBox1.Items.Contains(TextBox1.Text) Then
            MsgBox("You have already seelected the amount of hours per subject")
        Else
            ListBox1.Items.Add(TextBox1.Text)
        End If

        Button1.Visible = True
        Button2.Visible = True
        Button3.Visible = True
        Button5.Visible = True
        Button6.Visible = True




    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.Items.Contains("") Then
            MsgBox("There is nothing here")
        Else
            ListBox1.Items.RemoveAt(0)
        End If
        Button1.Visible = False
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.Items.Contains("") Then
            MsgBox("There is nothing here")
        Else
            ListBox1.Items.RemoveAt(1)
        End If
        Button2.Visible = False
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If ListBox1.Items.Contains("") Then
            MsgBox("There is nothing here")
        Else
            ListBox1.Items.RemoveAt(2)
        End If
        Button3.Visible = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ListBox1.Items.Contains("") Then
            MsgBox("There is nothing here")
        Else
            ListBox1.Items.RemoveAt(3)
        End If
        Button5.Visible = False
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ListBox1.Items.Contains("") Then
            MsgBox("There is nothing here")
        Else
            ListBox1.Items.RemoveAt(4)
        End If
        Button6.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub
End Class