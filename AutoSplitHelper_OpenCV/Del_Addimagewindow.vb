Imports System.IO

Public Class Del_Addimagewindow
    Private Sub Del_Addimagewindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtpass_picturefolder.Text = Mainwindow.txtpass_picturefolder.Text
        txtpass_csv.Text = Mainwindow.txtpass_csv.Text
        txtpass_rtf.Text = Mainwindow.txtpass_rtf.Text



        Dim di As New System.IO.DirectoryInfo(txtpass_picturefolder.Text)
        Dim files As System.IO.FileInfo() = di.GetFiles("*.bmp", System.IO.SearchOption.TopDirectoryOnly)
        Dim FileCount_bmponly As Integer

        For Each f As System.IO.FileInfo In files
            FileCount_bmponly += 1
        Next



        If System.IO.File.Exists(txtpass_picturefolder.Text & "\reset.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading1.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading2.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading3.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading4.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading5.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading6.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading7.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading8.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading9.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_picturefolder.Text & "\loading10.bmp") Then
            FileCount_bmponly -= 1
        End If

        '→FileCount_bmponlyは、全てのbmpファイルからreset/loadingxx.bmpを取り除いた数になる。
        For i = 0 To FileCount_bmponly - 1
            listnumber.Items.Add(i + 1)
            listcomment.Items.Add(Mainwindow.DGtable(0, i).Value)
        Next

    End Sub

    Private Sub listnumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listnumber.SelectedIndexChanged



        ''■画像の読み込み（表示用）※ADD/DELETE時画像の参照先が狂うので一旦無し
        'Dim aa As String = txtpass_picturefolder.Text & "/" & listnumber.SelectedItem & ".bmp"
        'Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
        '    PictureBox1.Image = Image.FromStream(fs)
        'End Using



    End Sub

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        Try

            Dim addpoint As Integer = listnumber.SelectedIndex + 1
            listnumber.Items.Insert(addpoint, "ADD")
            listcomment.Items.Insert(addpoint, "ADD")


        Catch ex As Exception

        End Try


    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try

            Dim deletepoint As Integer = listnumber.SelectedIndex
            listnumber.Items.RemoveAt(deletepoint)
            listcomment.Items.RemoveAt(deletepoint)

        Catch ex As Exception

        End Try


    End Sub


End Class