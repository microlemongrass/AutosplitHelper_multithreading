Imports System.Windows.Forms
Imports Microsoft.Win32

Public Class dialog_sharetemplate


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK

        If System.IO.Directory.Exists("./output/" & txtshare_profilename.Text) Then
            MessageBox.Show(My.Resources.Message.msg51, Mainwindow.messagebox_name) '"フォルダが既に存在しています。"

        Else
            System.IO.Directory.CreateDirectory("./output/" & txtshare_profilename.Text) '大元
            System.IO.Directory.CreateDirectory("./output/" & txtshare_profilename.Text & "/picture") '画像フォルダ
            System.IO.Directory.CreateDirectory("./output/" & txtshare_profilename.Text & "/text") 'テキストフォルダ

            'info.txt作成
            Dim sw As New System.IO.StreamWriter("./output/" & txtshare_profilename.Text & "/info.txt", False, System.Text.Encoding.GetEncoding("shift_jis"))

            sw.Write(txtshare_info.Text)

            sw.Close()

            My.Computer.FileSystem.CopyDirectory(Mainwindow.txtpass_picturefolder.Text, "./output/" & txtshare_profilename.Text & "/picture",
                FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            My.Computer.FileSystem.CopyDirectory(Mainwindow.txtpass_rtf.Text, "./output/" & txtshare_profilename.Text & "/text",
                FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            My.Computer.FileSystem.CopyFile(Mainwindow.txtpass_csv.Text, "./output/" & txtshare_profilename.Text & "/table.csv",
                FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing) '★


            '■zipファイルの作成
            System.IO.Compression.ZipFile.CreateFromDirectory("./output/" & txtshare_profilename.Text & "/",
                                                                  "./output/" & txtshare_profilename.Text & ".zip")


            '■相対パスから絶対パスを取得する
            Dim stFilePath As String = System.IO.Path.GetFullPath("./output/" & txtshare_profilename.Text & ".zip")

            '■クリップボードにパスをコピー
            Clipboard.SetText("""" & stFilePath & """")

            MessageBox.Show("Copied.")

            System.Diagnostics.Process.Start("https://ux.getuploader.com/share_template/")

            Me.Close()
        End If


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dialog_sharetemplate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(Mainwindow.Location.X + 100, Mainwindow.Location.Y + 50)
        'Me.Size = New Size(437, 640)
        txtshare_profilename.Text = Mainwindow.cmbprofile.SelectedItem


    End Sub


End Class
