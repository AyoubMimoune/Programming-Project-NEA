Public Class Form2
    Public y As Integer
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''''''''''''''''''''''''
        Button1.Visible = False
        Button2.Visible = False
        Button3.Visible = False   'Buttons that remove data from listbox
        Button5.Visible = False
        Button6.Visible = False
        '''''''''''''''''''''''
    End Sub
    
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '''''''''''''''ADDING THE CHOSEN TIMETABLE TO LISTBOX'''''''''''''''''''''''''''
        If ListBox1.Items.Count > 5 Then 'Checks if listbox contains more than 5 items 
            MsgBox("You cannot input any more")'If it contains more than 5 then the user will be told they cannot input anymore
        End If
        If ListBox1.Items.Contains(RadioButton1.Text) Then 'Checks if listbox already holds a timetable
            MsgBox("You have already picked your timetable") 'Notifies user that they already selected a timetable
        ElseIf Listbox1.Items.Contains(Radiobutton2.Text) Then
            MsgBox("You have already picked your timetable")
            
        ElseIf RadioButton1.Checked = True Then 'However if no timetable is in the listbox then the timetable will be added.
                ListBox1.Items.Add(RadioButton1.Text)
            Else
                ListBox1.Items.Add(RadioButton2.Text)
        End If
        
        ''''''''''''''''''''''''''''''''''''''' ADDING CHECKBOX TEXT TO LISTBOX
        For Each Control In Me.Controls 'Finds each control that exists within the form
            If TypeOf Control Is CheckBox Then 'Checks if the controls found are checkboxes
                If CType(Control, CheckBox).Checked Then 'Checks to see which textboxes are checked
                    If ListBox1.Items.Contains(Control.text) Then 'Checks if the checkbox already exists in the listbox
                    'If the listbox contains the checkbox already then nothing will happen
                    Else 'However if the listbox does not contain the checkbox then it will add the text of the checkbox to listbox
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
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Removing items from the listbox
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
    If ListBox1.Items.Contains("") Then 'Checks if the row in the listbox is empty
        MsgBox("There is nothing here") 'Notifies the user if that row is empty
        Else
            ListBox1.Items.RemoveAt(0)'If something exists witin that row then it will be removed
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If ListBox1.Items.Contains("") Then
            MsgBox("There is nothing here")
        Else
            ListBox1.Items.RemoveAt(4)
        End If
        Button6.Visible = False
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
    'Directs user to the next form and hides the current form 
        Me.Hide()
        Form3.Show()
    End Sub

End Class
