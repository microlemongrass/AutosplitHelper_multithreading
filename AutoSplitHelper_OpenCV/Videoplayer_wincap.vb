Imports System.Windows.Threading

Public Class Videoplayer_wincap
    '現在のコードを実行しているAssemblyを取得
    Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
    Friend bmp As New Bitmap(myAssembly.GetManifestResourceStream("AutoSplitHelper_OpenCV.viewsize_640x360.bmp")) '("viewsize_640x360.bmp")★

    'Friend bmp As New Bitmap(".\viewsize.bmp")
    Friend WithEvents dtimer As New DispatcherTimer()


    Private interval As Integer = Mainwindow.numwin_interval.Value

    'Graphicsの作成
    Private g_win As Graphics = Graphics.FromImage(bmp)

    'スレッドの本体
    Private Sub ThreadA()

        Do
            Try

                'PC画面の一部をコピー
                'g_win.CopyFromScreen(New Point(ltx, lty), New Point(0, 0), New Size(Mainwindow.numvideo_sizex.Value, Mainwindow.numvideo_sizey.Value))
                g_win.CopyFromScreen(New Point(ltx, lty), New Point(0, 0), New Size(sizex, sizey))

                '解放
                'g_win.Dispose()
                '表示
                'picVideo.Image = bmp
                Threading.Thread.Sleep(interval)

            Catch ex As Exception
                Console.WriteLine(ex.Message)

            End Try

        Loop

    End Sub




    '別スレッドタイマー
    'Private thr_timer As System.Threading.Timer '★
    Private Thread1 As New System.Threading.Thread(New System.Threading.ThreadStart(AddressOf ThreadA))


    Private Sub Videoplayer_wincap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '■ウィンドウサイズ、位置の設定
        Me.Location = New Point(Mainwindow.numwin_locx.Value, Mainwindow.numwin_locy.Value)
        Me.Size = New Size(Mainwindow.numvideo_sizex.Value, Mainwindow.numvideo_sizey.Value) 'New Size(Setting.numvideosizex.Value, Setting.numvideosizey.Value)
        picVideo.Size = New Size(Mainwindow.numvideo_sizex.Value, Mainwindow.numvideo_sizey.Value) 'New Size(Setting.numvideosizex.Value, Setting.numvideosizey.Value)


        '■ウィンドウキャプチャを別スレッドで開始する。
        Thread1.IsBackground = True
        Thread1.Start()

        dtimer.Interval = New TimeSpan(0, 0, 0, 0, interval)
        dtimer.Start()



    End Sub

    Friend ltx, lty As Integer
    Friend sizex, sizey As Integer


    Private Sub dtimer_Tick(sender As Object, e As EventArgs) Handles dtimer.Tick




        'If Not Videoplayer.Axwmp1.status = "停止" Then

        '    ltx = Videoplayer.Location.X
        '    lty = Videoplayer.Location.Y + Videoplayer.lbltitlebar.Height

        '    'PC画面の一部をコピー

        '    g_win.CopyFromScreen(New Point(ltx, lty), New Point(0, 0), New Size(Mainwindow.numvideo_sizex.Value, Mainwindow.numvideo_sizey.Value))
        '    '解放
        '    'g.Dispose()
        '    '表示

        picVideo.Image = bmp
        ltx = Videoplayer.Location.X
        lty = Videoplayer.Location.Y + Videoplayer.lbltitlebar.Height


        'End If



    End Sub



    Private Sub Videoplayer_wincap_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        dtimer.Stop()
        Thread1.Abort()


    End Sub


    '■■ラベルのドラッグでウィンドウを動かす

    Private mousePoint As Point
    'Form1のMouseDownイベントハンドラ
    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picVideo.MouseDown

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    'Form1のMouseMoveイベントハンドラ
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles picVideo.MouseMove

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y

        End If

    End Sub



End Class