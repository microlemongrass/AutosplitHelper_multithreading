Imports System.Drawing.Imaging
Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class tableview
    Private Sub tableview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgpic.AllowUserToAddRows = False

        Me.Location = New Point(Mainwindow.Location.X + 600, Mainwindow.Location.Y + 390)


        '■表の表示方法を設定（フォント、フォントサイズ、右詰め）■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        dgpic.DefaultCellStyle.BackColor = Color.WhiteSmoke 'GhostWhite



        dgpic.DefaultCellStyle.ForeColor = Color.Black
        dgpic.DefaultCellStyle.Font = New Font("Meiryo UI", 10)
        dgpic.ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9)
        dgpic.DefaultCellStyle.Alignment =
    DataGridViewContentAlignment.MiddleRight
        dgpic.Columns(0).DefaultCellStyle.Alignment =
    DataGridViewContentAlignment.MiddleLeft
        dgpic.RowHeadersWidth = 30



        '' 列ヘッダの背景色の変更
        dgpic.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        '' 行ヘッダの背景色の変更
        'dgpic.RowHeadersDefaultCellStyle.BackColor = Color.Green


        txttable_picpass.Text = Mainwindow.txtpass_picturefolder.Text


        Try

            ' ファイルが存在しているかどうか確認する
            Dim di As New System.IO.DirectoryInfo(txttable_picpass.Text)
            Dim files As System.IO.FileInfo() =
            di.GetFiles("*.bmp", System.IO.SearchOption.TopDirectoryOnly)


            For Each f As System.IO.FileInfo In files
                ListBox1.Items.Add(f.FullName)
                listname.Items.Add(System.IO.Path.GetFileNameWithoutExtension(f.FullName))

            Next

            txtnumbers.Text = ListBox1.Items.Count

            For ii = 0 To txtnumbers.Text - 1


                ' 画像の幅と高さの取得■■■■■■■■
                Dim imagew, imageh As Integer
                Dim fs As System.IO.FileStream
                ' Specify a valid picture file path on your computer.
                fs = New System.IO.FileStream(ListBox1.Items(ii), IO.FileMode.Open, IO.FileAccess.Read)
                imagew = System.Drawing.Image.FromStream(fs).Width
                imageh = System.Drawing.Image.FromStream(fs).Height
                fs.Close()



                Dim rowfull As String = ListBox1.Items(ii)
                Dim rowname As String = listname.Items(ii)
                dgpic.Rows.Add(rowname, New Bitmap(rowfull))
                dgpic.Rows(ii).Height = imageh + 6
            Next

            listname.SelectedIndex = 0


        Catch
        End Try




    End Sub

End Class