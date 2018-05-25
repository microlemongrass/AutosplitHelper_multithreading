Public Class Textwindow
    Private Sub Textwindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Mainwindow.Location.X + Mainwindow.Width, Mainwindow.Location.Y)
        Me.Size = New Size(Mainwindow.numtextwindow_sizex.Value, Mainwindow.numtextwindow_sizey.Value)
        Me.Text = Mainwindow.cmbprofile.SelectedItem
    End Sub

    Private Sub Textwindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Mainwindow.numtextwindow_sizex.Value = Me.Width
        Mainwindow.numtextwindow_sizey.Value = Me.Height

    End Sub
End Class