Imports System.Windows.Threading


Public Class Videoplayer


    'ウィンドウキャプチャ用ウィンドウのサイズを一時保存

    Friend playtime As Double
    Friend videovolume As Integer

    Private temp_pausetime As Double
    Private play_pause As String = "play"



    Private Sub Videoplayer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Axwmp1.uiMode = "None"
            Axwmp1.settings.autoStart = False
            Axwmp1.settings.mute = True
            'Axwmp1.settings.volume = 40


            '■ビデオパスを入れる
            Axwmp1.URL = Mainwindow.txtvideo_pass.Text

            '■ウィンドウサイズの設定
            Axwmp1.Size = New Size(Mainwindow.numvideo_sizex.Value, Mainwindow.numvideo_sizey.Value)
            Me.Size = New Size(Mainwindow.numvideo_sizex.Value, Mainwindow.numvideo_sizey.Value + lbltitlebar.Height)


            '■1度再生してバッファをなくす
            Axwmp1.Ctlcontrols.play()
            Axwmp1.Ctlcontrols.stop()

        Catch ex As Exception
            MsgBox("動画ファイルのパスを選択していない可能性があります。" & vbCrLf & ex.Message) '★
        End Try


    End Sub


    Friend Sub videoplay()

        Axwmp1.Ctlcontrols.currentPosition = playtime
        Axwmp1.Ctlcontrols.play()
        Axwmp1.settings.mute = True
        'Axwmp1.settings.volume = videovolume


    End Sub


    Friend Sub videostop()

        Axwmp1.Ctlcontrols.stop()


    End Sub


    Friend Sub videopause()

        If play_pause = "play" Then
            play_pause = "pause"
            Axwmp1.Ctlcontrols.pause()
            temp_pausetime = Axwmp1.Ctlcontrols.currentPosition

        ElseIf play_pause = "pause" Then
            play_pause = "play"
            Axwmp1.Ctlcontrols.currentPosition = temp_pausetime
            Axwmp1.Ctlcontrols.play()

        End If


    End Sub



    Private Sub 閉じるToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 閉じるToolStripMenuItem.Click


        Axwmp1.Dispose()
        Videoplayer_wincap.dtimer.Stop()
        Videoplayer_wincap.Close()
        Me.Close()
    End Sub









    '■ラベルのドラッグでウィンドウを動かす■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private mousePoint As Point
    'Form1のMouseDownイベントハンドラ
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbltitlebar.MouseDown

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    'Form1のMouseMoveイベントハンドラ
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbltitlebar.MouseMove

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y

        End If

    End Sub

    Private Sub Videoplayer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Mainwindow.pnl_video.Enabled = True

    End Sub


End Class