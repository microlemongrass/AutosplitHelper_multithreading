'Imports System.Globalization
'Imports System.Text.RegularExpressions

'Public Class code_strage

'    Private Sub create_delete_create_temp3()

'        '起動時にtempを削除し、起動処理終了後にtempを作る。

'        '■テンプレート画像のテンポラリーファイル。監視などが安定しない時に使用している。
'        If System.IO.Directory.Exists("./temp/temp3") Then
'            System.IO.Directory.Delete("./temp/temp3", True) ' フォルダ (ディレクトリ) を削除する


'        End If

'        ' フォルダ (ディレクトリ) を作成する
'        System.IO.Directory.CreateDirectory("./temp/temp3")



'    End Sub

'    Private Sub Start_create_tempfolder()

'        '■画像フォルダの一時ファイルを作成するかどうか
'        If chkcreate_temppicture.Checked = True Then
'            ' 必要な変数を宣言する
'            Dim dtNow As DateTime = DateTime.Now
'            ' 時刻の部分だけを取得する
'            Dim tsNow As TimeSpan = dtNow.TimeOfDay

'            Dim r1 As String = tsNow.ToString().Replace(":", "-")
'            ' フォルダ (ディレクトリ) を作成する
'            System.IO.Directory.CreateDirectory("./temp/temp3/" & r1)

'            'ディレクトリ"picture/xxx"を"temp/temp3/xxx"にコピーする
'            My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, "./temp/temp3/" & r1,
'            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

'            txttemp_picturepass.Text = txtpass_picturefolder.Text
'            txtpass_picturefolder.Text = "./temp/temp3/" & r1

'        End If

'    End Sub

'    Private Sub タイマーの現在の状態を取得()

'        lbltitlebar.Text = "T:" & cvtimer.IsEnabled & ",R:" & cvreset_timer.IsEnabled & ",RO:" & cvresetonly_timer.IsEnabled

'        '■最初の画像の読み込み（表示用）
'        Dim img As System.Drawing.Image = System.Drawing.Image.FromFile(aa)
'        piccv_picture.Image = img

'    End Sub



'    Private Sub Videoseek_全て()
'        '■Videoplayerのシーク
'        If chkshowvideo.Checked = True Then

'            If chkvideo_autoseek.Checked = True Then
'                If chkcv_loop.Checked = True Then

'                    Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 0)).Value

'                    'Videoseekの値が"-1"ならば、シークなど何の操作もしない
'                    If Videoplayer.playtime = -1 Then

'                    Else

'                        Videoplayer.videoplay()


'                    End If


'                ElseIf chkcv_loop.Checked = False Then

'                    Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 1)).Value

'                    'Videoseekの値が"-1"ならば、シークなど何の操作もしない
'                    If Videoplayer.playtime = -1 Then

'                    Else
'                        Videoplayer.videoplay()

'                    End If

'                End If



'            Else '最初の反応時にのみplayする

'                If chkcv_loop.Checked = True Then
'                    If numnowloop.Value = 0 Then
'                        Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text)).Value
'                        Videoplayer.videoplay()

'                    End If
'                ElseIf chkcv_loop.Checked = False Then

'                    If lblcv_lap.Text = 2 Then
'                        Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 1)).Value
'                        Videoplayer.videoplay()

'                    End If


'                End If

'            End If

'        End If

'    End Sub


'    Private Sub timchecktimer_Tick(sender As Object, e As EventArgs) Handles timchecktimer.Tick
'        lbltitlebar.Text =
'            "▷:" & cvtimer.IsEnabled &
'            " ⏸:" & timopencvsleep.Enabled &
'            " LR:" & cvtimer_loadremover1.IsEnabled
'    End Sub




'End Class
