Public Class Sortimage_input_info

    Private Sub btnzipok_Click(sender As Object, e As EventArgs) Handles btnzipok.Click

        If Sortimagewindow.listselect_pass_picture.Items.Count <> 0 Then

            If System.IO.Directory.Exists("./output/" & Sortimagewindow.txtoutputname.Text) Then
                MessageBox.Show(My.Resources.Message.msg2) '"フォルダが既に存在しています。"
            Else
                System.IO.Directory.CreateDirectory("./output/" & Sortimagewindow.txtoutputname.Text) '大元
                System.IO.Directory.CreateDirectory("./output/" & Sortimagewindow.txtoutputname.Text & "/picture") '画像フォルダ
                System.IO.Directory.CreateDirectory("./output/" & Sortimagewindow.txtoutputname.Text & "/text") 'テキストフォルダ

                'info.txt作成
                Dim sw As New System.IO.StreamWriter("./output/" & Sortimagewindow.txtoutputname.Text & "/info.txt", False, System.Text.Encoding.GetEncoding("shift_jis"))

                sw.Write(txtinfo.Text)

                sw.Close()

                Sortimagewindow.btnzipok.PerformClick()

                Me.Close()

            End If
        End If
    End Sub


End Class