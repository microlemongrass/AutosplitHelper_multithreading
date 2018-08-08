Public Class Del_Addimagewindow
    Private Sub Del_Addimagewindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtpass_picturefolder.Text = Mainwindow.txtpass_picturefolder.Text
        txtpass_csv.Text = Mainwindow.txtpass_csv.Text
        txtpass_rtf.Text = Mainwindow.txtpass_rtf.Text

    End Sub
End Class