'直近の変更は★、気をつけたほうが良さそうなのは♥

Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports OpenCvSharp
Imports System.Windows.Threading
Imports System.IO
Imports DirectShowLib
Imports System.Net



Public Class Mainwindow

    '■API■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    'キー入力を受け取る
    Private Declare Function GetKeyPress Lib "user32" Alias "GetAsyncKeyState" (ByVal key As Integer) As Integer

    'ウィンドウタイトルからハンドル値を取得するためのAPI
    Declare Function EnumWindows Lib "User32.dll" (ByVal Proc As EnumWinProc, ByVal lParam As Integer) As Boolean

    Delegate Function EnumWinProc(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean

    Declare Function EnumChildWindows Lib "User32.dll" _
        (ByVal hWndParent As Integer, ByVal Proc As EnumChildProc, ByVal lParam As Integer) As Boolean

    Delegate Function EnumChildProc(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean


    Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" _
        (ByVal hWnd As Integer, ByVal MSG As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Declare Function SendMessageStr Lib "user32.dll" Alias "SendMessageA" _
        (ByVal hWnd As Integer, ByVal MSG As Integer, ByVal wParam As Integer, ByVal lParam As StringBuilder) As Integer


    Declare Function FindWindow Lib "user32" Alias "FindWindowA" _
        (ByVal lpClassName As String, ByVal lpWindowName As String) As Integer

    Declare Function FindWindowEx Lib "user32.dll" Alias "FindWindowExA" _
        (ByVal hwndParent As Integer, ByVal hwndChildAfter As Integer, ByVal lpszClass As String, ByVal lpszWindow As String) As Integer


    '正確な時間を計るためのAPI
    Declare Function timeGetTime Lib "winmm.dll" Alias "timeGetTime" () As Long

    '変数msecを倍精度浮動小数点型で宣言(小数点も入れることが出来る）
    Dim msec As Double
    Dim msec_load As Double
    Dim msec_pause As Double



    'ウィンドウタイトル取得用のAPI
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetWindowText(hWnd As IntPtr, lpString As StringBuilder, nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetWindowTextLength(hWnd As IntPtr) As Integer
    End Function


    'ウィンドウ位置を指定するためのAPI
    Private Declare Function MoveWindow Lib "user32" Alias "MoveWindow" _
    (ByVal hwnd As IntPtr, ByVal x As Integer, ByVal y As Integer,
    ByVal nWidth As Integer, ByVal nHeight As Integer,
    ByVal bRepaint As Integer) As Integer


    'GetWindowRect（Window の位置等を取得）の宣言
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowThreadProcessId(hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetWindowText(hWnd As IntPtr, lpString As String) As Integer
    End Function

    'RECT 構造体
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Public Const WM_SETTEXT = &HC
    Public Const WM_GETTEXT = &HD
    Public Const WM_GETTEXTLENGTH = &HE
    Private Const WM_IME_CHAR As Short = &H286S


    '■アプリケーション起動時の処理■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private pipeServer As System.IO.Pipes.NamedPipeClientStream = New System.IO.Pipes.NamedPipeClientStream("LiveSplit") 'Livesplitの名前付きパイプを利用する。
    Private livesplit_state As String = "" 'LiveSplitが起動されているかどうかを表示
    Private ASH_state As Integer = 0 '0:起動時、1:起動時以外★

    Friend messagebox_name As String = "Autosplit Helper" 'メッセージボックスのタイトル用

    Private Dpi_rate As Double

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '★■PCのDPIを取得し、全てのサイズ変更処理に対して補正する。
        Using gfx As Graphics = Me.CreateGraphics()
            Dim userDPI = CInt(gfx.DpiX)
            Dpi_rate = Math.Round(userDPI / 96, 2, MidpointRounding.AwayFromZero)
            Console.WriteLine("userDPI: " & userDPI & " 、PCの表示倍率: " & Dpi_rate & "倍")
            lbldpi.Text = "Your PC's DPI: " & userDPI & " (" & 100 * Dpi_rate & " %)"
        End Using

        '■DirectShowを利用した映像キャプチャデバイス一覧の取得
        cmbcv_device.Items.Clear()

        Dim Devices() As DsDevice

        Devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice)

        If Devices.Count <= 0 Then
            Console.WriteLine("ビデオデバイスが存在しません。")
            MessageBox.Show(My.Resources.Message.msg41, messagebox_name) 'ビデオデバイスが存在しません。SCFFDSF等仮想カメラデバイスをインストールして下さい。


        Else

            For i = 0 To Devices.Count - 1
                Console.WriteLine(Devices(i).Name)
                cmbcv_device.Items.Add(Devices(i).Name)

            Next


        End If



        '■キー押下時間を設定。
        keydown_length = numpresstime.Value

        '■アプリ終了時のソフトの位置を記憶、復元
        Me.Location = New Drawing.Point(numsavex.Value, numsavey.Value)

        '■Sortimageのフォルダ削除。画像ファイルロック防止の為起動時に＋Sort作成毎に別名フォルダ作成★
        Try

            If System.IO.Directory.Exists("./temp/temp_sort") Then
                System.IO.Directory.Delete("./temp/temp_sort", True)

            End If

        Catch ex As Exception
            Console.Write("temp/temp_sortファイル削除できず")
            rtxtlog.AppendText(Now & " " & "temp/temp_sortファイルを削除できませんでした。" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try



        '■「現在の設定」のサイズ
        grpgeneral.Location = New Drawing.Point(7 * Dpi_rate, 250 * Dpi_rate)
        grpgeneral.Size = New Drawing.Size(785 * Dpi_rate, 295 * Dpi_rate)

        '■設定を閉じるボタンの位置
        btnclose_general.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate + pnl_parameter.Height + (2 * Dpi_rate))

        '■Menustripのカラー変更
        MenuStrip1.ForeColor = SystemColors.Control

        '■ウィンドウサイズの調整 
        Me.Size = New Drawing.Point(800 * Dpi_rate, 600 * Dpi_rate)
        DGtable.Size = New Drawing.Point(785 * Dpi_rate, 146 * Dpi_rate)

        '■設定パネルを画面外に
        pnl_parameter.Location = New Drawing.Point(10000, 0)
        pnl_cvparameter.Location = New Drawing.Point(10000, 0)
        pnl_focus.Location = New Drawing.Point(10000, 0)
        pnl_hotkey.Location = New Drawing.Point(10000, 0)
        pnl_loadremover.Location = New Drawing.Point(10000, 0)
        pnl_graph.Location = New Drawing.Point(10000, 0)
        pnl_video.Location = New Drawing.Point(10000, 0)
        pnl_other.Location = New Drawing.Point(10000, 0)

        '■バインドされているコントロールがあると、タブを開かないとエラーが出るので一旦開く
        TabControl1.SelectedTab = TabPage1

        '■表の表示方法を設定（フォント、フォントサイズ、右詰め）■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        Adjust_table()

        '■起動中のアプリケーションのタイトルを取得■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        list2_alltitle.Items.Clear()

        '全てのプロセスを列挙する
        Dim p As System.Diagnostics.Process

        For Each p In System.Diagnostics.Process.GetProcesses()
            'メインウィンドウのタイトルがある時だけ列挙する
            If p.MainWindowTitle.Length <> 0 Then
                ' Console.WriteLine("プロセス名:" & p.ProcessName)
                'Console.WriteLine("タイトル名:" & p.MainWindowTitle)

                Dim results As String = p.MainWindowTitle

                list2_alltitle.Items.Add(results)


            End If

        Next

        chklockwindow.Checked = False


        '■アプリへフォーカスを当てる所の設定■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        If chkactiveapp.Checked = False Then

            chkactivesomeapp.Checked = False
            chkactivesomeapp.Enabled = False

            btndeleteitem_someapp.Enabled = False
            btngetsomeactive.Enabled = False
            cmbsomeapp.Enabled = False

            btnaddapp1.Enabled = False
            btndelete_timer.Enabled = False
            btngettimer.Enabled = False
            cmbtimer.Enabled = False


        ElseIf chkactiveapp.Checked = True Then

            chkactivesomeapp.Enabled = True

            btnaddapp1.Enabled = True
            btndelete_timer.Enabled = True
            btngettimer.Enabled = True
            cmbtimer.Enabled = True


        End If


        '■コンボボックス読み込み1

        'ComboBox1.BeginUpdate() より前に実行する事でかなり効果がある
        '必要な項目数だけしか表示しない。
        cmbtimer.IntegralHeight = False        'Windows Vista 以降で有効 

        '読み込み中の描画をしない(高速処理)　
        cmbtimer.BeginUpdate()

        Dim st As New System.IO.StreamReader("./savedata/01_active1.txt", System.Text.Encoding.Default)

        'ファイルの最後までループ
        Do Until st.Peek = -1
            '１行づつ読込む
            cmbtimer.Items.Add(st.ReadLine)
        Loop

        st.Close()              'ファイルを閉じる
        cmbtimer.EndUpdate()   'コントロールの描画を再開


        Debug.Print(cmbtimer.Items.Count.ToString)


        '■コンボボックス読み込み2

        cmbsomeapp.IntegralHeight = False

        cmbsomeapp.BeginUpdate()

        Dim st2 As New System.IO.StreamReader("./savedata/02_active2.txt", System.Text.Encoding.Default)

        'ファイルの最後までループ
        Do Until st2.Peek = -1
            '１行づつ読込む
            cmbsomeapp.Items.Add(st2.ReadLine)
        Loop

        st2.Close()              'ファイルを閉じる
        cmbsomeapp.EndUpdate()   'コントロールの描画を再開



        '■コンボボックス読み込み3

        cmbprofile.IntegralHeight = False

        cmbprofile.BeginUpdate()

        Dim st5 As New System.IO.StreamReader("./savedata/03_profilelist.txt", System.Text.Encoding.Default)

        'ファイルの最後までループ
        Do Until st5.Peek = -1
            '１行づつ読込む
            cmbprofile.Items.Add(st5.ReadLine)
        Loop

        st5.Close()              'ファイルを閉じる
        cmbprofile.EndUpdate()   'コントロールの描画を再開

        '■コンボボックス読み込み4

        cmbcv_resolution_input.IntegralHeight = False

        cmbcv_resolution_input.BeginUpdate()

        Dim st6 As New System.IO.StreamReader("./savedata/04_resolution_input.txt", System.Text.Encoding.Default)

        'ファイルの最後までループ
        Do Until st6.Peek = -1
            '１行づつ読込む
            cmbcv_resolution_input.Items.Add(st6.ReadLine)
        Loop

        st6.Close()              'ファイルを閉じる
        cmbcv_resolution_input.EndUpdate()   'コントロールの描画を再開


        '■コンボボックス読み込み5

        cmbcv_resolution_view.IntegralHeight = False

        cmbcv_resolution_view.BeginUpdate()

        Dim st7 As New System.IO.StreamReader("./savedata/05_resolution_view.txt", System.Text.Encoding.Default)

        'ファイルの最後までループ
        Do Until st7.Peek = -1
            '１行づつ読込む
            cmbcv_resolution_view.Items.Add(st7.ReadLine)
        Loop

        st7.Close()              'ファイルを閉じる
        cmbcv_resolution_view.EndUpdate()   'コントロールの描画を再開












        '表の読み込み（設定タブ(DGtable)と位置タブ(position)両方））■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

        Dim ii As Integer
        For ii = 0 To 0

            Try

                Dim myfilename_table1 As String = "./profile/default/table.csv"

                Dim parser As TextFieldParser = New TextFieldParser(myfilename_table1, Encoding.UTF8) '.GetEncoding("Shift_JIS"))
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",") ' 区切り文字はコンマ

                ' データをすべてクリア
                DGtable.Rows.Clear()

                While (Not parser.EndOfData)
                    Dim row As String() = parser.ReadFields() ' 1行読み込み
                    ' 読み込んだデータ(1行をDataGridViewに表示する)
                    DGtable.Rows.Add(row)

                End While

                For Each c As DataGridViewColumn In DGtable.Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c

                For Each c As DataGridViewColumn In DGtable.Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c

                parser.Close()


            Catch ex As Exception
                MessageBox.Show(My.Resources.Message.msg1, messagebox_name)
                '"表の読み込みに失敗しました。savefileフォルダに[table1.csv(カンマ区切り)]を作成してください。"
                rtxtlog.AppendText(Now & " " & My.Resources.Message.msg1 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)
            End Try


        Next


        '■表の読み込み（位置タブ(position)）
        For ii = 0 To 0

            Try

                Dim myfilename_position As String = "./savedata/position.csv"

                Dim parser As TextFieldParser = New TextFieldParser(myfilename_position, Encoding.UTF8) '.GetEncoding("Shift_JIS"))
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",") ' 区切り文字はコンマ

                ' データをすべてクリア
                dgv2_template.Rows.Clear()

                While (Not parser.EndOfData)
                    Dim row As String() = parser.ReadFields() ' 1行読み込み
                    ' 読み込んだデータ(1行をDataGridViewに表示する)
                    dgv2_template.Rows.Add(row)

                End While

                For Each c As DataGridViewColumn In dgv2_template.Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c

                For Each c As DataGridViewColumn In dgv2_template.Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c

                parser.Close()


                ' MessageBox.Show(myfilename_table2 & "ファイル2の読み込みに成功しました。", "AutoSplit Helper by Image")
            Catch ex As Exception
                MessageBox.Show(My.Resources.Message.msg2, messagebox_name)
                '"表の読み込みに失敗しました。savefileフォルダに[table2.csv(カンマ区切り)]を作成してください。"
                rtxtlog.AppendText(Now & " " & My.Resources.Message.msg2 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)
            End Try

        Next




        '■sendkey,sendkey_reset,llayout,pass,active1,active2（コンボボックス）の読み込み
        Try

            cmbcv_device.SelectedIndex = numcv_device.Value
            cmbprofile.SelectedIndex = numprofile.Value

        Catch ex As Exception
            MessageBox.Show(My.Resources.Message.msg3, messagebox_name) '"読み込みに失敗しました。設定が初期化されます。"
            rtxtlog.AppendText(Now & " " & My.Resources.Message.msg3 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

            cmbtimer.SelectedIndex = 0
            cmbsomeapp.SelectedIndex = 0

            txtpass_picturefolder.Text = "./profile/default/picture"
            txtpass_rtf.Text = "./profile/default/text"
            txtpass_csv.Text = "./profile/default/table.csv"

            cmbcv_device.SelectedIndex = 0

            cmbcv_resolution_input.SelectedIndex = 0
            cmbcv_resolution_view.SelectedIndex = 0
            cmbprofile.SelectedIndex = 0

            numcv_device.Value = 0

            numprofile.Value = 0

        End Try

        btncv_downsize.Text = My.Resources.Message.msg35

        btnresetup.Enabled = False

        webcam_sleep.Interval = New TimeSpan(0, 0, 0, 0, 600)



        '■進む、戻るボタンを無効に
        btncv_back.Enabled = False
        btncv_forward.Enabled = False
        btncv_first.Enabled = False




        '■リセットの部分の背景変更
        DGtable.Rows(0).DefaultCellStyle.BackColor = Color.FromArgb(58, 16, 16) 'Color.MistyRose


        '■起動時はスタートできないように。
        btnstartopencv.Enabled = False
        btnconnect_camera.Text = My.Resources.Message.msgc01

        rtxtlog.AppendText(Now & " " & "Launched." & vbCrLf)
        ASH_state = 1




    End Sub


    '■表の表示方法を設定（フォント、フォントサイズ、右詰め）
    Private Sub Adjust_table()

        With DGtable

            .AllowUserToResizeRows = False

            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            ' 列ヘッダの背景色の変更
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)
            ' 行ヘッダの背景色の変更
            .RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)

            ' 列ヘッダの文字色の変更
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            ' 行ヘッダの文字色の変更
            .RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke

            .DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)

            .Columns(no.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)

            .Columns(send.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)
            .Columns(key.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)

            .Columns(rate.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)

            .Columns(sleep.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)

            .Columns(timing.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)
            .Columns(darksleep.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)
            .Columns(darkthr.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)

            .Columns(graph_count.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)
            .Columns(graph_rate.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)
            .Columns(graph_view.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)

            .Columns(posx.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)
            .Columns(posy.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)
            .Columns(sizex.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)
            .Columns(sizey.Index).DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)

            .Columns(ltx.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)
            .Columns(lty.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)
            .Columns(rbx.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)
            .Columns(rby.Index).DefaultCellStyle.BackColor = Color.FromArgb(56, 58, 60)


            .DefaultCellStyle.ForeColor = Color.WhiteSmoke
            .DefaultCellStyle.Font = New Font("Meiryo UI", 11)
            .ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .RowHeadersWidth = 30


        End With


        With dgv2_template

            .AllowUserToResizeRows = False

            .EnableHeadersVisualStyles = False
            .ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
            .RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

            ' 列ヘッダの背景色の変更
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)
            ' 行ヘッダの背景色の変更
            .RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)

            ' 列ヘッダの文字色の変更
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
            ' 行ヘッダの文字色の変更
            .RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke

            .DefaultCellStyle.BackColor = Color.LightGray
            .DefaultCellStyle.ForeColor = Color.Black
            .DefaultCellStyle.Font = New Font("Meiryo UI", 10)
            .ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 11)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft


        End With


    End Sub


    Private Sub Mainwindow_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        '■Livesplitの名前付きパイプの接続状況表示。存在したら接続

        'タイマーのプロセスを探す
        Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

        If 0 < ps_timer1.Length Then

            If pipeServer.IsConnected = False Then
                pipeServer.Connect()
                livesplit_state = "[LiveSplit NamedPipe ON]"

            End If


        Else
            livesplit_state = "[LiveSplit NamedPipe OFF]"

        End If

        lbllivesplit_state.Text = livesplit_state

        '表示がバグるので、対症。
        Threading.Thread.Sleep(50)
        TabControl1.SelectedIndex = 0

        checkupdate()

        Me.Refresh()


    End Sub




    '■メイン設定■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private Sub lblset_monitoring_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_monitoring.MouseClick

        listsetcontents.SelectedIndex = 1
        listsetcontents.SelectedIndex = 0

        grpgeneral.Visible = False


    End Sub

    Private Sub lblset_device_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_device.MouseClick

        listsetcontents.SelectedIndex = 0
        listsetcontents.SelectedIndex = 1

        grpgeneral.Visible = False



    End Sub

    Private Sub lblset_focus_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_focus.MouseClick

        listsetcontents.SelectedIndex = 0
        listsetcontents.SelectedIndex = 2

        grpgeneral.Visible = False


    End Sub

    Private Sub lblset_hotkey_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_hotkey.MouseClick

        listsetcontents.SelectedIndex = 0
        listsetcontents.SelectedIndex = 3

        grpgeneral.Visible = False


    End Sub

    Private Sub lblset_road_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_road.MouseClick

        listsetcontents.SelectedIndex = 0
        listsetcontents.SelectedIndex = 4

        grpgeneral.Visible = False


    End Sub

    Private Sub lblset_graph_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_graph.MouseClick

        listsetcontents.SelectedIndex = 0
        listsetcontents.SelectedIndex = 5

        grpgeneral.Visible = False


    End Sub

    Private Sub lblset_video_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_video.MouseClick

        listsetcontents.SelectedIndex = 0
        listsetcontents.SelectedIndex = 6

        grpgeneral.Visible = False


    End Sub

    Private Sub lblset_text_MouseClick(sender As Object, e As MouseEventArgs) Handles lblset_text.MouseClick

        listsetcontents.SelectedIndex = 0
        listsetcontents.SelectedIndex = 7

        grpgeneral.Visible = False


    End Sub



    '■リストボックスのアイテム選択時の処理
    Private Sub listsetcontents_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listsetcontents.SelectedIndexChanged

        pnl_parameter.Location = New Drawing.Point(10000, 0)
        pnl_cvparameter.Location = New Drawing.Point(10000, 0)
        pnl_focus.Location = New Drawing.Point(10000, 0)
        pnl_hotkey.Location = New Drawing.Point(10000, 0)
        pnl_loadremover.Location = New Drawing.Point(10000, 0)
        pnl_graph.Location = New Drawing.Point(10000, 0)
        pnl_video.Location = New Drawing.Point(10000, 0)
        pnl_other.Location = New Drawing.Point(10000, 0)


        Select Case listsetcontents.SelectedIndex

            Case 0 'Parameter
                pnl_parameter.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)

            Case 1 'OpenCV Parameter
                pnl_cvparameter.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)

            Case 2 'Focus
                pnl_focus.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)

            Case 3 'Hot key
                pnl_hotkey.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)

            Case 4 'Load remover
                pnl_loadremover.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)

            Case 5 'Graph
                pnl_graph.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)

            Case 6 'Video
                pnl_video.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)

            Case 7 'Other
                pnl_other.Location = New Drawing.Point(120 * Dpi_rate, 265 * Dpi_rate)


        End Select



    End Sub


    Private Sub btnclose_general_Click(sender As Object, e As EventArgs) Handles btnclose_general.Click

        grpgeneral.Visible = True


    End Sub

    Private Sub DGtable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGtable.CellClick

        txtrowscount.BackColor = Color.WhiteSmoke

        Dim dgv As DataGridView = CType(sender, DataGridView)

        If (dgv Is Nothing) Then
            Exit Sub 'Return

        End If

        If dgv.CurrentRow.Selected Then
            For Each r11 As DataGridViewRow In DGtable.SelectedRows

                txtrowscount.Text = r11.Index

            Next r11

            txtrowscount.BackColor = Color.Pink


        End If


    End Sub


    '■インポート設定を開く
    Private Sub profile_import()

        Import_picture.Show()
        Import_picture.Location = New Drawing.Point(Me.Location.X + 150, Me.Location.Y + 115)


    End Sub


    Friend Sub import_ok()

        '■仮想カメラの切断
        If btnconnect_camera.Text = My.Resources.Message.msgc01 Then

        ElseIf btnconnect_camera.Text = My.Resources.Message.msgc02 Then

            btnconnect_camera.Text = My.Resources.Message.msgc01

            capturecv.Release()

            btnstartopencv.Enabled = False

            btnconnect_camera.BackColor = SystemColors.Control


        End If

        Dim import_pic As String = Import_picture.txtpass_picturefolder.Text
        Dim import_rtf As String = Import_picture.txtpass_rtf.Text
        Dim import_csv As String = Import_picture.txtpass_csv.Text

        Dim import_name As String = Import_picture.txtname.Text

        txtpass_picturefolder.Text = "./profile/" & import_name & "/picture"
        txtpass_rtf.Text = "./profile/" & import_name & "/text"
        txtpass_csv.Text = "./profile/" & import_name & "/table.csv"


        '■フォルダ (ディレクトリ) を作成する
        System.IO.Directory.CreateDirectory("./profile/" & import_name & "/picture/")
        System.IO.Directory.CreateDirectory("./profile/" & import_name & "/text/")

        My.Computer.FileSystem.CopyDirectory(import_pic, "./profile/" & import_name & "/picture",
        FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        My.Computer.FileSystem.CopyDirectory(import_rtf, "./profile/" & import_name & "/text",
        FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        My.Computer.FileSystem.CopyFile(import_csv, "./profile/" & import_name & "/table.csv",
        FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)


        '■csvファイルの内容を表に表示

        Dim parser As TextFieldParser = New TextFieldParser(txtpass_csv.Text, Encoding.UTF8) '.GetEncoding("Shift_JIS"))

        parser.TextFieldType = FieldType.Delimited
        parser.SetDelimiters(",") ' 区切り文字はコンマ


        ' データをすべてクリア
        DGtable.Rows.Clear()

        While (Not parser.EndOfData)
            Dim row As String() = parser.ReadFields() ' 1行読み込み
            ' 読み込んだデータ(1行をDataGridViewに表示する)
            DGtable.Rows.Add(row)

        End While

        For Each c As DataGridViewColumn In DGtable.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        For Each c As DataGridViewColumn In DGtable.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c


        parser.Close()


        '■プロファイルを作成
        cmbprofile.Text = import_name

        '■New profile/Add profileに類似記述
        Dim sameitem As Integer = cmbprofile.Items.IndexOf(cmbprofile.Text)

        If sameitem = -1 Then
            cmbprofile.Items.Add(cmbprofile.Text)


        End If

        cmbprofile.SelectedItem = cmbprofile.Text

        Createarrayprofile()

        txtprofile.Clear()

        For ii = 0 To arrayprofile_save.Count - 1
            txtprofile.AppendText(arrayprofile_save(ii) & vbCrLf)

        Next

        'Dim sw As New System.IO.StreamWriter("./savedata/profile/" & cmbprofile.SelectedItem & ".txt", False, System.Text.Encoding.GetEncoding("shift_jis"))
        Dim sw As New System.IO.StreamWriter("./profile/" & cmbprofile.SelectedItem & "/data.txt", False,
                                             System.Text.Encoding.UTF8) '.GetEncoding("Shift_JIS"))

        sw.Write(txtprofile.Text)

        sw.Close()


        numprofile.Value = cmbprofile.SelectedIndex '選択保存用

        '■リセットの部分の背景変更
        DGtable.Rows(0).DefaultCellStyle.BackColor = Color.FromArgb(58, 16, 16) 'Color.MistyRose

        lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " AutoSplit Helper by Image " & lblversion.Text




    End Sub




    '■■Parameter/Monitoring■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    '■閾値、一致率、待機時間、暗転閾値の一括挿入
    Private Sub btninsertitti_Click(sender As Object, e As EventArgs) Handles btninsertitti.Click

        Dim rowcount As Integer = DGtable.Rows.Count

        For aa = 1 To rowcount - 2
            DGtable(rate.Index, aa).Value = numpercent.Text

        Next


    End Sub

    Private Sub btninsertsleep_Click(sender As Object, e As EventArgs) Handles btninsertsleep.Click

        Dim rowcount As Integer = DGtable.Rows.Count

        For aa = 1 To rowcount - 2
            DGtable(sleep.Index, aa).Value = numstop.Text

        Next


    End Sub

    Private Sub btninsertanten_Click(sender As Object, e As EventArgs) Handles btninsertanten.Click

        Dim rowcount As Integer = DGtable.Rows.Count

        For aa = 1 To rowcount - 2
            DGtable(darkthr.Index, aa).Value = numanten.Text

        Next


    End Sub


    '■Parameterセッティングの反映
    Private Sub chkcv_monitor_CheckedChanged(sender As Object, e As EventArgs) Handles chkcv_monitor.CheckedChanged

        If chkcv_monitor.Checked = True Then
            lblcur_split.BackColor = Color.Maroon

        Else
            lblcur_split.BackColor = Color.FromArgb(80, 90, 95)


        End If


    End Sub

    Private Sub chkcv_loop_CheckedChanged(sender As Object, e As EventArgs) Handles chkcv_loop.CheckedChanged

        If chkcv_loop.Checked = True Then
            lblcur_loop.BackColor = Color.Maroon
            lblcur_loopcount.BackColor = Color.Maroon

        Else
            lblcur_loop.BackColor = Color.FromArgb(80, 90, 95)
            lblcur_loopcount.BackColor = Color.FromArgb(80, 90, 95)


        End If


    End Sub

    Private Sub numloopcount_ValueChanged(sender As Object, e As EventArgs) Handles numloopcount.ValueChanged

        lblcur_loopcount.Text = "[" & numloopcount.Value & "]"


    End Sub

    Private Sub chkcv_resetonoff_CheckedChanged(sender As Object, e As EventArgs) Handles chkcv_resetonoff.CheckedChanged

        If chkcv_resetonoff.Checked = True Then
            lblcur_reset.BackColor = Color.Maroon

        Else
            lblcur_reset.BackColor = Color.FromArgb(80, 90, 95)


        End If


    End Sub

    Private Sub chkcv_loadremover_CheckedChanged(sender As Object, e As EventArgs) Handles chkcv_loadremover.CheckedChanged

        If chkcv_loadremover.Checked = True Then
            lblcur_load.BackColor = Color.Maroon

        Else
            lblcur_load.BackColor = Color.FromArgb(80, 90, 95)


        End If


    End Sub

    Private Sub numcv_interval_ValueChanged(sender As Object, e As EventArgs) Handles numcv_interval.ValueChanged

        lblcur_interval.Text = numcv_interval.Value & "ms"


    End Sub


    '■■Video Device/OpenCVの設定■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private Sub capture_setup() '★
        'InitializeComponent()

        Dim cameranum As Integer = numcv_device.Value

        capturecv = VideoCapture.FromCamera(cameranum)

        capturecv.FrameWidth = numcrop_resolution_x.Value
        capturecv.FrameHeight = numcrop_resolution_y.Value
        capturecv.Fps = numcv_framerate.Value


    End Sub

    Private Sub numcv_framerate_ValueChanged(sender As Object, e As EventArgs) Handles numcv_framerate.ValueChanged

        btnstartopencv.Enabled = False

        '■Current Settingへの反映
        lblcur_device_res_fps.Text = cmbcv_resolution_view.SelectedItem & " - " & numcv_framerate.Value & "fps"


    End Sub

    Private Sub cmbcv_resolution_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcv_resolution_view.SelectedIndexChanged

        '■コンボボックスの値を下に代入■■■■■■
        ' 必要な変数を宣言する
        Dim stCsvData As String = cmbcv_resolution_view.SelectedItem

        ' カンマ区切りで分割して配列に格納する
        Dim stArrayData As String() = stCsvData.Split("x"c)

        numcv_sizex.Text = stArrayData(0)
        numcv_sizey.Text = stArrayData(1)

        btnstartopencv.Enabled = False

        '■Current Settingへの反映
        lblcur_device_res_fps.Text = cmbcv_resolution_view.SelectedItem & " - " & numcv_framerate.Value & "fps"


    End Sub

    Private Sub cmbcv_device_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcv_device.SelectedIndexChanged

        numcv_device.Value = cmbcv_device.SelectedIndex

        btnstartopencv.Enabled = False

        '■Current Settingへの反映
        lblcur_device_name.Text = cmbcv_device.SelectedItem


    End Sub

    Private Sub numcv_device_ValueChanged(sender As Object, e As EventArgs) Handles numcv_device.ValueChanged

        btnstartopencv.Enabled = False


    End Sub


    Private Sub btncur_webcamera_Click(sender As Object, e As EventArgs) Handles btncur_webcamera.Click

        Connect_camera_cur()


    End Sub

    '■OpenCV設定を適用するために再起動する。
    Private Sub btnresetup_Click(sender As Object, e As EventArgs) Handles btnresetup.Click

        btncur_webcamera.Enabled = False
        btnconnect_camera.Enabled = False
        btnresetup.Enabled = False

        capturecv.Release()
        System.Threading.Thread.Sleep(100)
        capture_setup()
        btnstartopencv.Enabled = True


        webcam_sleep.Start()



    End Sub



    '■■フォーカスの設定■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    '■キー送信前後のアプリ選択（追加/削除）
    Private Sub btnaddapp1_Click(sender As Object, e As EventArgs) Handles btnaddapp1.Click

        Dim win_getprocess As New getprocesswindow1
        win_getprocess.Show()


    End Sub

    Private Sub btnaddapp2_Click(sender As Object, e As EventArgs) Handles btnaddapp2.Click

        Dim win_getprocess As New getprocesswindow2
        win_getprocess.Show()


    End Sub

    Private Sub btndeleteitem_someapp_Click(sender As Object, e As EventArgs) Handles btndeleteitem_someapp.Click

        cmbsomeapp.Items.Remove(cmbsomeapp.SelectedItem)


    End Sub

    Private Sub btndelete_timer_Click(sender As Object, e As EventArgs) Handles btndelete_timer.Click

        cmbtimer.Items.Remove(cmbtimer.SelectedItem)


    End Sub

    '■確認ボタン前
    Private Sub btngettimer_Click(sender As Object, e As EventArgs) Handles btngettimer.Click

        If chknamedpipe.Checked = True Then

            'タイマーのプロセスを探す
            Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

            If 0 < ps_timer1.Length Then

                Try

                    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                    sw.AutoFlush = True
                    sw.WriteLine("startorsplit" & vbCrLf)


                Catch ex As Exception

                End Try


            End If


        ElseIf chknamedpipe.Checked = False Then


            'キー出力前のウィンドウアクティブ確認ボタン。まずプロセスを探す。
            Dim app As String = cmbtimer.SelectedItem
            Dim ps As Process() = Process.GetProcessesByName(app)

            If 0 < ps.Length Then
                '見つかった時は、アクティブにする
                Microsoft.VisualBasic.Interaction.AppActivate(ps(0).Id)

                'タイマーが入力を受け付けるまでちょっと時間空ける
                System.Threading.Thread.Sleep(numsendsleep.Value)

                keysending()


            Else MessageBox.Show(My.Resources.Message.msg4, messagebox_name) '"ウィンドウの存在を確認できませんでした。"


            End If


        End If


    End Sub
    '■確認ボタン後
    Private Sub btngetsomeactive_Click(sender As Object, e As EventArgs) Handles btngetsomeactive.Click

        'キー出力後のウィンドウアクティブ確認ボタン。まずプロセスを探す。
        Dim app As String = cmbsomeapp.SelectedItem
        Dim ps As System.Diagnostics.Process() =
            System.Diagnostics.Process.GetProcessesByName(app)

        If 0 < ps.Length Then
            '見つかった時は、アクティブにする
            Microsoft.VisualBasic.Interaction.AppActivate(ps(0).Id)

            'タイマーが入力を受け付けるまでちょっと時間空ける
            System.Threading.Thread.Sleep(numsendsleep.Value)


        Else MessageBox.Show(My.Resources.Message.msg4, messagebox_name) '"ウィンドウの存在を確認できませんでした。"


        End If


    End Sub

    '■キー出力前にアクティブにするボタンの挙動設定
    Private Sub chkactiveapp_CheckedChanged(sender As Object, e As EventArgs) Handles chkactiveapp.CheckedChanged

        If chkactiveapp.Checked = False Then

            chkactivesomeapp.Checked = False
            chkactivesomeapp.Enabled = False


            btndeleteitem_someapp.Enabled = False
            btngetsomeactive.Enabled = False
            cmbsomeapp.Enabled = False

            btnaddapp1.Enabled = False
            btndelete_timer.Enabled = False
            btngettimer.Enabled = False
            cmbtimer.Enabled = False

            '■Current Settingへの反映
            lblcur_focus_before.Text = "None"


        ElseIf chkactiveapp.Checked = True Then

            chkactivesomeapp.Enabled = True

            btnaddapp1.Enabled = True
            btndelete_timer.Enabled = True
            btngettimer.Enabled = True
            cmbtimer.Enabled = True

            '■Current Settingへの反映
            lblcur_focus_before.Text = cmbtimer.SelectedItem


        End If


    End Sub

    '■キー出力後にアクティブにするボタンの挙動設定
    Private Sub chkactivesomeapp_CheckedChanged(sender As Object, e As EventArgs) Handles chkactivesomeapp.CheckedChanged

        If chkactivesomeapp.Checked = True Then
            btnaddapp2.Enabled = True
            cmbsomeapp.Enabled = True
            btndeleteitem_someapp.Enabled = True
            btngetsomeactive.Enabled = True

            '■Current Settingへの反映
            lblcur_focus_after.Text = "None"


        ElseIf chkactivesomeapp.Checked = False Then
            btnaddapp2.Enabled = False
            cmbsomeapp.Enabled = False
            btndeleteitem_someapp.Enabled = False
            btngetsomeactive.Enabled = False

            '■Current Settingへの反映
            lblcur_focus_after.Text = cmbsomeapp.SelectedItem


        End If


    End Sub

    Private Sub cmbsomeapp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsomeapp.SelectedIndexChanged

        lblcur_focus_after.Text = cmbsomeapp.SelectedItem


    End Sub




    '■■ショートカットキーの設定■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub txtsplit_key_MouseDown(sender As Object, e As EventArgs) Handles txtsplit_key.MouseDown
        txtsplit_key.Text = "Set Hotkey..."
    End Sub

    Private Sub txtsplit_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtsplit_key.KeyDown
        txtsplit_key.Text = e.KeyCode.ToString
        lblkeysforsend.Text = e.KeyCode
        Label7.Focus()

    End Sub

    Private Sub txtreset_key_MouseDown(sender As Object, e As EventArgs) Handles txtreset_key.MouseDown
        txtreset_key.Text = "Set Hotkey..."

    End Sub

    Private Sub txtreset_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtreset_key.KeyDown
        txtreset_key.Text = e.KeyCode.ToString
        lblkeysforsend_reset.Text = e.KeyCode
        Label7.Focus()

    End Sub

    Private Sub txtundo_key_MouseDown(sender As Object, e As EventArgs) Handles txtundo_key.MouseDown
        txtundo_key.Text = "Set Hotkey..."

    End Sub

    Private Sub txtundo_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtundo_key.KeyDown
        txtundo_key.Text = e.KeyCode.ToString
        lblkeysforundo.Text = e.KeyCode
        Label7.Focus()

    End Sub

    Private Sub txtskip_key_MouseDown(sender As Object, e As EventArgs) Handles txtskip_key.MouseDown
        txtskip_key.Text = "Set Hotkey..."

    End Sub

    Private Sub txtskip_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtskip_key.KeyDown
        txtskip_key.Text = e.KeyCode.ToString
        lblkeysforskip.Text = e.KeyCode
        Label7.Focus()

    End Sub

    Private Sub txtpause_key_MouseDown(sender As Object, e As EventArgs) Handles txtpause_key.MouseDown
        txtpause_key.Text = "Set Hotkey..."

    End Sub

    Private Sub txtpause_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtpause_key.KeyDown
        txtpause_key.Text = e.KeyCode.ToString
        lblkeysforpause.Text = e.KeyCode
        Label7.Focus()

    End Sub

    Private Sub txtresume_key_MouseDown(sender As Object, e As EventArgs) Handles txtresume_key.MouseDown
        txtresume_key.Text = "Set Hotkey..."

    End Sub

    Private Sub txtresume_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtresume_key.KeyDown
        txtresume_key.Text = e.KeyCode.ToString
        lblkeysforresume.Text = e.KeyCode
        Label7.Focus()

    End Sub


    '■ASH用のホットキー
    Private Sub txtreset_ash_key_MouseDown(sender As Object, e As EventArgs) Handles txtreset_ash_key.MouseDown
        txtreset_ash_key.Text = "Set Hotkey..."
    End Sub

    Private Sub txtreset_ash_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtreset_ash_key.KeyDown
        txtreset_ash_key.Text = e.KeyCode.ToString
        numreset_ash.Value = e.KeyCode

        Label7.Focus()

    End Sub

    Private Sub txtundo_ash_key_MouseDown(sender As Object, e As EventArgs) Handles txtundo_ash_key.MouseDown
        txtundo_ash_key.Text = "Set Hotkey..."
    End Sub

    Private Sub txtundo_ash_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtundo_ash_key.KeyDown
        txtundo_ash_key.Text = e.KeyCode.ToString
        numundo_ash.Value = e.KeyCode
        Label7.Focus()

    End Sub

    Private Sub txtskip_ash_key_MouseDown(sender As Object, e As EventArgs) Handles txtskip_ash_key.MouseDown
        txtskip_ash_key.Text = "Set Hotkey..."
    End Sub

    Private Sub txtskip_ash_key_KeyDown(sender As Object, e As KeyEventArgs) Handles txtskip_ash_key.KeyDown
        txtskip_ash_key.Text = e.KeyCode.ToString
        numskip_ash.Value = e.KeyCode
        Label7.Focus()

    End Sub


    Private keydown_length As Integer = 500 ' キーを押す時間の変数
    '■Shift,Ctrl,Altキーを押す_split
    Private Sub keydownAction()
        If chkshift.Checked = True Then
            Call KeyEvent(Shift, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl.Checked = True Then
            Call KeyEvent(Ctrl, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt.Checked = True Then
            Call KeyEvent(Alt, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

    End Sub

    '■Shift,Ctrl,Altキーを離す_split
    Private Sub keyupAction()
        If chkshift.Checked = True Then
            Call KeyEvent(Shift, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl.Checked = True Then
            Call KeyEvent(Ctrl, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt.Checked = True Then
            Call KeyEvent(Alt, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If
    End Sub

    '■Shift,Ctrl,Altキーを押す_Reset
    Private Sub keydownAction_reset()
        If chkshift_reset.Checked = True Then
            Call KeyEvent(Shift, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_reset.Checked = True Then
            Call KeyEvent(Ctrl, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_reset.Checked = True Then
            Call KeyEvent(Alt, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

    End Sub

    '■Shift,Ctrl,Altキーを離す_Reset
    Private Sub keyupAction_reset()
        If chkshift_reset.Checked = True Then
            Call KeyEvent(Shift, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_reset.Checked = True Then
            Call KeyEvent(Ctrl, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_reset.Checked = True Then
            Call KeyEvent(Alt, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If
    End Sub

    '■Shift,Ctrl,Altキーを押す_undo
    Private Sub keydownAction_undo()
        If chkshift_undo.Checked = True Then
            Call KeyEvent(Shift, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_undo.Checked = True Then
            Call KeyEvent(Ctrl, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_undo.Checked = True Then
            Call KeyEvent(Alt, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

    End Sub

    '■Shift,Ctrl,Altキーを離す_undo
    Private Sub keyupAction_undo()
        If chkshift_undo.Checked = True Then
            Call KeyEvent(Shift, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_undo.Checked = True Then
            Call KeyEvent(Ctrl, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_undo.Checked = True Then
            Call KeyEvent(Alt, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If
    End Sub

    '■Shift,Ctrl,Altキーを押す_skip
    Private Sub keydownAction_skip()
        If chkshift_skip.Checked = True Then
            Call KeyEvent(Shift, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_skip.Checked = True Then
            Call KeyEvent(Ctrl, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_skip.Checked = True Then
            Call KeyEvent(Alt, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

    End Sub

    '■Shift,Ctrl,Altキーを離す_skip
    Private Sub keyupAction_skip()
        If chkshift_skip.Checked = True Then
            Call KeyEvent(Shift, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_skip.Checked = True Then
            Call KeyEvent(Ctrl, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_skip.Checked = True Then
            Call KeyEvent(Alt, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If
    End Sub

    '■Shift,Ctrl,Altキーを押す_pause
    Private Sub keydownAction_pause()
        If chkshift_pause.Checked = True Then
            Call KeyEvent(Shift, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_pause.Checked = True Then
            Call KeyEvent(Ctrl, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_pause.Checked = True Then
            Call KeyEvent(Alt, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

    End Sub

    '■Shift,Ctrl,Altキーを離す_pause
    Private Sub keyupAction_pause()
        If chkshift_pause.Checked = True Then
            Call KeyEvent(Shift, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_pause.Checked = True Then
            Call KeyEvent(Ctrl, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_pause.Checked = True Then
            Call KeyEvent(Alt, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If
    End Sub

    '■Shift,Ctrl,Altキーを押す_resume
    Private Sub keydownAction_resume()
        If chkshift_resume.Checked = True Then
            Call KeyEvent(Shift, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_resume.Checked = True Then
            Call KeyEvent(Ctrl, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_resume.Checked = True Then
            Call KeyEvent(Alt, KEY_DOWN) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

    End Sub

    '■Shift,Ctrl,Altキーを離す_resume
    Private Sub keyupAction_resume()
        If chkshift_resume.Checked = True Then
            Call KeyEvent(Shift, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkctrl_resume.Checked = True Then
            Call KeyEvent(Ctrl, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If

        If chkalt_resume.Checked = True Then
            Call KeyEvent(Alt, KEY_UP) '「ｖ」キー押下（貼り付け）
            System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
        End If
    End Sub


    '■キー送信全体 （スプリット）
    Private Sub allkeysend()
        Console.WriteLine("ALLKEYSEND")
        If chknamedpipe.Checked = True Then

            'タイマーのプロセスを探す
            Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

            If 0 < ps_timer1.Length Then

                Try


                    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                    sw.AutoFlush = True

                    If chkcv_loop.Checked = True Then '常にスプリット
                        sw.WriteLine("startorsplit" & vbCrLf)


                    ElseIf chkcv_loop.Checked = False Then

                        If DGtable(key.Index, CInt(lblcv_lap.Text - 1)).Value = 0 Then
                            sw.WriteLine("startorsplit" & vbCrLf)

                        ElseIf DGtable(key.Index, CInt(lblcv_lap.Text - 1)).Value = 1 Then
                            sw.WriteLine("pause" & vbCrLf)

                        ElseIf DGtable(key.Index, CInt(lblcv_lap.Text - 1)).Value = 2 Then
                            sw.WriteLine("resume" & vbCrLf)

                        End If

                    End If

                Catch ex As Exception
                    rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                End Try

            End If


        ElseIf chknamedpipe.Checked = False Then

            'Start③  sendkey時タイマーをアクティブにする、にチェックを入れていない時■■■■■■■■■■■■
            If chkactiveapp.Checked = False Then

                keysending()

                'sendkey時タイマーをアクティブにする、にチェックを入れている時■■■■■■■■■■■■■■■■
            ElseIf chkactiveapp.Checked = True Then

                '別のタイマーに送信する場合
                If chkmulti.Checked = True Then

                    'タイマーのプロセスを探す
                    'Dim ps_timer1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(txtrenameapp.Text)
                    Dim hProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(CInt(lblpid_1st.Text))

                    If Not hProcess Is Nothing Then
                        Console.WriteLine("multi_split")
                        '見つかった時は、アクティブにする
                        Microsoft.VisualBasic.Interaction.AppActivate(hProcess.Id)
                    End If

                    'タイマーが入力を受け付けるまでちょっと時間空ける
                    System.Threading.Thread.Sleep(numsendsleep.Value)

                    keysending()

                Else

                    'タイマーのプロセスを探す
                    Dim ps_timer1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(cmbtimer.SelectedItem)

                    If 0 < ps_timer1.Length Then
                        '見つかった時は、アクティブにする
                        Microsoft.VisualBasic.Interaction.AppActivate(ps_timer1(0).Id)
                    End If

                    'タイマーが入力を受け付けるまでちょっと時間空ける
                    System.Threading.Thread.Sleep(numsendsleep.Value)

                    keysending()

                End If

            End If



            'Start③' アクティブを元に戻すにチェックが入っている時■■■■■■■■■■■■■■■■■■■■■
            If chkactivesomeapp.Checked = True Then

                'メモ帳のプロセスを探す
                Dim app_someapp1 As String = cmbsomeapp.SelectedItem
                Dim ps_someapp1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(app_someapp1)

                If 0 < ps_someapp1.Length Then
                    '見つかった時は、アクティブにする

                    Microsoft.VisualBasic.Interaction.AppActivate(ps_someapp1(0).Id)

                End If


            End If 'End③'■■

        End If 'End■■

    End Sub

    '■キー送信全て（ロード）
    Private Sub allkeysend_load()


        If chknamedpipe.Checked = True Then

            'タイマーのプロセスを探す
            Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

            If 0 < ps_timer1.Length Then

                Try


                    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                    sw.AutoFlush = True


                    If lblloading.Text = "play" Then

                        sw.WriteLine("pause" & vbCrLf)


                    ElseIf lblloading.Text = "loading" Then
                        'ここが使われることはない


                    ElseIf lblloading.Text = "sleep" Then

                        sw.WriteLine("resume" & vbCrLf)



                    End If




                Catch ex As Exception
                    rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                End Try

            End If


        ElseIf chknamedpipe.Checked = False Then

            'Start③  sendkey時タイマーをアクティブにする、にチェックを入れていない時■■■■■■■■■■■■
            If chkactiveapp.Checked = False Then

                keysending_load()

                'sendkey時タイマーをアクティブにする、にチェックを入れている時■■■■■■■■■■■■■■■■
            ElseIf chkactiveapp.Checked = True Then

                'loadで別のタイマーに送信する場合
                If chkmulti.Checked = True Then

                    'タイマーのプロセスを探す
                    'Dim ps_timer1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(txtrenameapp.Text)
                    Dim hProcess As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessById(CInt(txtpid_2nd.Text))

                    If Not hProcess Is Nothing Then
                        Console.WriteLine("multi_load")
                        '見つかった時は、アクティブにする
                        Microsoft.VisualBasic.Interaction.AppActivate(hProcess.Id)
                    End If

                    'タイマーが入力を受け付けるまでちょっと時間空ける
                    System.Threading.Thread.Sleep(numsendsleep.Value)

                    keysending_load()

                Else

                    'タイマーのプロセスを探す
                    Dim ps_timer1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(cmbtimer.SelectedItem)

                    If 0 < ps_timer1.Length Then
                        '見つかった時は、アクティブにする
                        Microsoft.VisualBasic.Interaction.AppActivate(ps_timer1(0).Id)
                    End If

                    'タイマーが入力を受け付けるまでちょっと時間空ける
                    System.Threading.Thread.Sleep(numsendsleep.Value)

                    keysending_load()


                End If



                'Start③' アクティブを元に戻すにチェックが入っている時■■■■■■■■■■■■■■■■■■■■■
                If chkactivesomeapp.Checked = True Then

                    'メモ帳のプロセスを探す
                    Dim app_someapp1 As String = cmbsomeapp.SelectedItem
                    Dim ps_someapp1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(app_someapp1)

                    If 0 < ps_someapp1.Length Then
                        '見つかった時は、アクティブにする

                        Microsoft.VisualBasic.Interaction.AppActivate(ps_someapp1(0).Id)

                    End If


                End If 'End③'■■

            End If 'End■■

        End If

    End Sub

    '■キー送信全て（リセット）
    Private Sub allkeysend_reset()


        If chknamedpipe.Checked = True Then

            'タイマーのプロセスを探す
            Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

            If 0 < ps_timer1.Length Then

                Try



                    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                    sw.AutoFlush = True
                    sw.WriteLine("reset" & vbCrLf)


                Catch ex As Exception
                    MessageBox.Show(ex.ToString, messagebox_name)
                    rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                End Try


            End If


        ElseIf chknamedpipe.Checked = False Then


            'Start③  sendkey時タイマーをアクティブにする、にチェックを入れていない時■■■■■■■■■■■■
            If chkactiveapp.Checked = False Then

                keysending_reset()

                'sendkey時タイマーをアクティブにする、にチェックを入れている時■■■■■■■■■■■■■■■■
            ElseIf chkactiveapp.Checked = True Then

                'タイマーのプロセスを探す
                Dim ps_timer1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(cmbtimer.SelectedItem)

                If 0 < ps_timer1.Length Then
                    '見つかった時は、アクティブにする
                    Microsoft.VisualBasic.Interaction.AppActivate(ps_timer1(0).Id)
                End If

                'タイマーが入力を受け付けるまでちょっと時間空ける
                System.Threading.Thread.Sleep(numsendsleep.Value)

                keysending_reset()


                'Start③' アクティブを元に戻すにチェックが入っている時■■■■■■■■■■■■■■■■■■■■■
                If chkactivesomeapp.Checked = True Then

                    'メモ帳のプロセスを探す
                    Dim app_someapp1 As String = cmbsomeapp.SelectedItem
                    Dim ps_someapp1 As System.Diagnostics.Process() = System.Diagnostics.Process.GetProcessesByName(app_someapp1)

                    If 0 < ps_someapp1.Length Then

                        Microsoft.VisualBasic.Interaction.AppActivate(ps_someapp1(0).Id)

                    End If


                End If 'End③'■■

            End If 'End■■

        End If

    End Sub

    '■キー送信（スプリット）
    Private Sub keysending()

        Dim key_split As Short = lblkeysforsend.Text
        Dim key_pause As Short = lblkeysforpause.Text
        Dim key_resume As Short = lblkeysforresume.Text

        If chkcv_loop.Checked = True Then '常にスプリット


            keydownAction() 'Shift,Ctrl,Altキーを押す
            Call KeyEvent(key_split, KEY_DOWN) 'キーを押下
            System.Threading.Thread.Sleep(keydown_length) '指定ミリ秒待つ
            keyupAction()    'Shift,Ctrl,Altキーを離す
            Call KeyEvent(key_split, KEY_UP) 'コントロールキーを離す


        ElseIf chkcv_loop.Checked = False Then


            If DGtable(key.Index, CInt(lblcv_lap.Text - 1)).Value = 0 Then

                keydownAction() 'Shift,Ctrl,Altキーを押す
                Call KeyEvent(key_split, KEY_DOWN) 'キーを押下
                System.Threading.Thread.Sleep(keydown_length) '指定ミリ秒待つ
                keyupAction()    'Shift,Ctrl,Altキーを離す
                Call KeyEvent(key_split, KEY_UP) 'コントロールキーを離す

            ElseIf DGtable(key.Index, CInt(lblcv_lap.Text - 1)).Value = 1 Then

                keydownAction_pause() 'Shift,Ctrl,Altキーを押す
                Call KeyEvent(key_pause, KEY_DOWN) 'キーを押下
                System.Threading.Thread.Sleep(keydown_length) '指定ミリ秒待つ
                keyupAction_pause()    'Shift,Ctrl,Altキーを離す
                Call KeyEvent(key_pause, KEY_UP) 'コントロールキーを離す

            ElseIf DGtable(key.Index, CInt(lblcv_lap.Text - 1)).Value = 2 Then

                keydownAction_resume() 'Shift,Ctrl,Altキーを押す
                Call KeyEvent(key_resume, KEY_DOWN) 'キーを押下
                System.Threading.Thread.Sleep(keydown_length) '指定ミリ秒待つ
                keyupAction_resume()    'Shift,Ctrl,Altキーを離す
                Call KeyEvent(key_resume, KEY_UP) 'コントロールキーを離す


            End If

        End If

    End Sub

    '■キー送信(ロード)
    Private Sub keysending_load()

        Dim key_pause As Short = lblkeysforpause.Text
        Dim key_resume As Short = lblkeysforresume.Text

        If lblloading.Text = "play" Then

            keydownAction_pause() 'Shift,Ctrl,Altキーを押す
            Call KeyEvent(key_pause, KEY_DOWN) 'キーを押下
            System.Threading.Thread.Sleep(keydown_length) '指定ミリ秒待つ
            keyupAction_pause()    'Shift,Ctrl,Altキーを離す
            Call KeyEvent(key_pause, KEY_UP) 'コントロールキーを離す



        ElseIf lblloading.Text = "loading" Then
            'ここでは何もしない

        ElseIf lblloading.Text = "sleep" Then

            keydownAction_resume() 'Shift,Ctrl,Altキーを押す
            Call KeyEvent(key_resume, KEY_DOWN) 'キーを押下
            System.Threading.Thread.Sleep(keydown_length) '指定ミリ秒待つ
            keyupAction_resume()    'Shift,Ctrl,Altキーを離す
            Call KeyEvent(key_resume, KEY_UP) 'コントロールキーを離す


        End If




    End Sub

    '■キー送信（リセット）
    Private Sub keysending_reset()

        Dim key_reset As Short = lblkeysforsend_reset.Text

        keydownAction_reset() 'Shift,Ctrl,Altキーを押す
        Call KeyEvent(key_reset, KEY_DOWN) 'コントロールキーを押下
        System.Threading.Thread.Sleep(keydown_length) '指定ミリ秒待つ
        keyupAction_reset()    'Shift,Ctrl,Altキーを離す
        Call KeyEvent(key_reset, KEY_UP) 'コントロールキーを離す

    End Sub


    Private Sub chkundoskip_CheckedChanged(sender As Object, e As EventArgs) Handles chkundoskip.CheckedChanged

        If chkundoskip.Checked = True Then
            lblcur_rendou.Text = "ON"
        Else
            lblcur_rendou.Text = "OFF"
        End If

    End Sub


    Private Sub numputtime_ValueChanged_1(sender As Object, e As EventArgs) Handles numpresstime.ValueChanged
        keydown_length = numpresstime.Value
    End Sub






    '■■Load Removerの設定反映■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private Sub chkload1_CheckedChanged(sender As Object, e As EventArgs) Handles chkload1.CheckedChanged

        If chkload1.Checked = True Then
            lblcur_load1.BackColor = Color.Maroon
        Else
            lblcur_load1.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload2_CheckedChanged(sender As Object, e As EventArgs) Handles chkload2.CheckedChanged

        If chkload2.Checked = True Then
            lblcur_load2.BackColor = Color.Maroon
        Else
            lblcur_load2.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload3_CheckedChanged(sender As Object, e As EventArgs) Handles chkload3.CheckedChanged

        If chkload3.Checked = True Then
            lblcur_load3.BackColor = Color.Maroon
        Else
            lblcur_load3.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload4_CheckedChanged(sender As Object, e As EventArgs) Handles chkload4.CheckedChanged

        If chkload4.Checked = True Then
            lblcur_load4.BackColor = Color.Maroon
        Else
            lblcur_load4.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload5_CheckedChanged(sender As Object, e As EventArgs) Handles chkload5.CheckedChanged

        If chkload5.Checked = True Then
            lblcur_load5.BackColor = Color.Maroon
        Else
            lblcur_load5.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload6_CheckedChanged(sender As Object, e As EventArgs) Handles chkload6.CheckedChanged

        If chkload6.Checked = True Then
            lblcur_load6.BackColor = Color.Maroon
        Else
            lblcur_load6.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload7_CheckedChanged(sender As Object, e As EventArgs) Handles chkload7.CheckedChanged

        If chkload7.Checked = True Then
            lblcur_load7.BackColor = Color.Maroon
        Else
            lblcur_load7.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload8_CheckedChanged(sender As Object, e As EventArgs) Handles chkload8.CheckedChanged

        If chkload8.Checked = True Then
            lblcur_load8.BackColor = Color.Maroon
        Else
            lblcur_load8.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload9_CheckedChanged(sender As Object, e As EventArgs) Handles chkload9.CheckedChanged

        If chkload9.Checked = True Then
            lblcur_load9.BackColor = Color.Maroon
        Else
            lblcur_load9.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub

    Private Sub chkload10_CheckedChanged(sender As Object, e As EventArgs) Handles chkload10.CheckedChanged

        If chkload10.Checked = True Then
            lblcur_load10.BackColor = Color.Maroon
        Else
            lblcur_load10.BackColor = Color.FromArgb(80, 90, 95)
        End If

    End Sub


    '■■Graphの設定■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private Sub graph_split()

        Console.WriteLine("Split")

        lbllapcount.Text = CInt(lbllapcount.Text) + 1

        If lbllapcount.Text = 1 + (numgraph_first.Value - 1) Then

            lblattemptcount.Text += 1


        End If

        view_chart.lblcount.Text = lblattemptcount.Text

        DGtable(graph_count.Index, CInt(lbllapcount.Text) - 1).Value = DGtable(graph_count.Index, CInt(lbllapcount.Text) - 1).Value + 1 'カウント+1

        table_reload()


    End Sub

    Private Sub table_reload()

        Dim XDataCount = DGtable.Rows.Count - 2

        DGtable(graph_rate.Index, CInt(lbllapcount.Text) - 1).Value = Math.Round(((CInt(DGtable(graph_count.Index, CInt(lbllapcount.Text) - 1).Value) / CInt(lblattemptcount.Text)) * 100), 2)

        If lbllapcount.Text >= 2 + (numgraph_first.Value - 1) Then

            If DGtable(graph_view.Index, CInt(lbllapcount.Text) - 1).Value = 1 Then
                txtsetsplitname.Text = CInt(lbllapcount.Text) - 2 + (numgraph_first.Value - 1) - 2 & " " & DGtable(0, CInt(lbllapcount.Text) - 1).Value & "[" & DGtable(graph_count.Index, CInt(lbllapcount.Text) - 1).Value & "]"

                '■LiveSplitのSegment nameを書き換えるか否か
                If chkrename_livesplit.Checked = True Then

                    'タイマーのプロセスを探す
                    Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

                    If 0 < ps_timer1.Length Then

                        Try

                            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                            Dim sr As New IO.StreamReader(pipeServer)

                            sw.AutoFlush = True
                            sw.WriteLine("setsplitname " & txtsetsplitname.Text & vbCrLf)

                        Catch ex As Exception
                            MessageBox.Show("error", messagebox_name)
                            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                        End Try


                    End If

                End If

            End If

        End If


        If view_chart.Visible = False Then
            Console.WriteLine("グラフが表示されていません")

        Else
            view_chart.btnresponse.PerformClick()


        End If


    End Sub

    Private Sub graph_reset()

        Console.WriteLine("Reset")

        lbllapcount.Text = 0 + (numgraph_first.Value - 1)

        lblresetcount.Text += 1

        view_chart.lblcount.Text = lblattemptcount.Text

        table_reload_reset()


    End Sub

    Private Sub table_reload_reset()

        Dim XDataCount = DGtable.Rows.Count - 2

        For j As Integer = 0 To (XDataCount)

            DGtable(graph_rate.Index, j).Value = Math.Round(((CInt(DGtable(graph_count.Index, j).Value) / CInt(lblresetcount.Text)) * 100), 2)

        Next

        If view_chart.Visible = False Then
            Console.WriteLine("グラフが表示されていません")

        Else
            view_chart.btnresponse.PerformClick()


        End If

    End Sub

    Private Sub numgraph_first_ValueChanged(sender As Object, e As EventArgs) Handles numgraph_first.ValueChanged

        lblcur_firstsplit.Text = numgraph_first.Value


    End Sub

    Private Sub chkrename_livesplit_CheckedChanged(sender As Object, e As EventArgs) Handles chkrename_livesplit.CheckedChanged

        If chkrename_livesplit.Checked = True Then
            lblcur_namedpipe.Text = "YES"
        Else
            lblcur_namedpipe.Text = "NO"
        End If


    End Sub



    Private Sub btncur_clear_count_Click(sender As Object, e As EventArgs) Handles btncur_clear_count.Click

        Reset_count()


    End Sub

    Private Sub btncur_clear_table_Click(sender As Object, e As EventArgs) Handles btncur_clear_table.Click

        Reset_table()


    End Sub

    Private Sub btncur_clear_live_Click(sender As Object, e As EventArgs) Handles btncur_clear_live.Click

        Reset_livesplit()


    End Sub


    '■Videoplayerの設定反映
    Private Sub chkshowvideo_CheckedChanged(sender As Object, e As EventArgs) Handles chkshowvideo.CheckedChanged

        If chkshowvideo.Checked = True Then
            lblcur_showvideo.BackColor = Color.Maroon
            lblcur_showvideo.Text = "Y"
        Else
            lblcur_showvideo.BackColor = Color.FromArgb(80, 90, 95)
            lblcur_showvideo.Text = "N"
        End If


    End Sub

    Private Sub chkvideo_manualstart_CheckedChanged(sender As Object, e As EventArgs) Handles chkvideo_manualstart.CheckedChanged

        If chkvideo_manualstart.Checked = True Then
            txtvideo_startat.Enabled = True

        ElseIf chkvideo_manualstart.Checked = False Then
            txtvideo_startat.Enabled = False

        End If


    End Sub

    '♥
    Private Sub btnselectvideo_Click(sender As Object, e As EventArgs) Handles btnselectvideo.Click

        Dim ii As Integer

        For ii = 0 To 0

            Dim ofd As New OpenFileDialog()

            ofd.FileName = ""
            'ofd.Filter = "CSV(カンマ区切り) (*.csv)|*.csv"
            ofd.Title = "動画ファイルを選択してください"
            ofd.RestoreDirectory = True


            If ofd.ShowDialog = DialogResult.OK Then
                'Console.WriteLine(ofd.FileName)
                txtvideo_pass.Text = ofd.FileName.Replace("""", "")

            ElseIf DialogResult.Cancel Then
                MessageBox.Show(My.Resources.Message.msg42, messagebox_name) 'キャンセルされました。

                Continue For '保存処理をふっとばす。

            End If

            Console.WriteLine(ofd.FileName & "の読み込みに成功しました。")

        Next


    End Sub

    '♥
    Private Sub btncur_showvideo_Click(sender As Object, e As EventArgs) Handles btncur_showvideo.Click

        pnl_video.Enabled = False

        Videoplayer.Show()
        Videoplayer.lbltitlebar.Text = cmbprofile.SelectedItem

        If chkvideo_showwinvideo.Checked = True Then
            Videoplayer_wincap.Show()


        End If


    End Sub


    '■メイン設定画面に戻る
    Private Sub btntosetting01_Click(sender As Object, e As EventArgs) Handles btntosetting01.Click

        TabControl1.SelectedIndex = 0


    End Sub

    Private Sub btntosetting02_Click(sender As Object, e As EventArgs) Handles btntosetting02.Click

        TabControl1.SelectedIndex = 0


    End Sub

    Private Sub btntosetting04_Click(sender As Object, e As EventArgs) Handles btntosetting04.Click

        TabControl1.SelectedIndex = 0


    End Sub

    Private Sub btntosetting05_Click(sender As Object, e As EventArgs) Handles btntosetting05.Click
        Cropping_preview.Close()
        TabControl1.SelectedIndex = 0
    End Sub





    '■プレビューウィンドウ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
#Region " 'リプレイ用のMatを準備"

    Private frame0 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame1 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame2 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame3 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame4 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame5 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame6 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame7 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame8 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame9 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame10 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame11 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame12 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame13 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame14 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame15 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame16 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame17 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame18 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame19 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame20 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame21 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame22 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame23 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame24 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame25 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame26 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame27 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame28 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame29 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame30 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame31 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame32 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame33 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame34 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame35 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame36 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame37 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame38 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame39 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame40 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame41 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame42 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame43 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame44 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame45 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame46 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame47 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame48 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame49 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame50 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame51 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame52 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame53 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame54 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame55 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame56 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame57 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame58 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame59 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame60 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame61 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame62 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame63 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame64 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame65 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame66 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame67 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame68 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame69 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame70 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame71 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame72 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame73 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame74 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame75 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame76 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame77 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame78 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame79 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame80 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame81 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame82 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame83 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame84 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame85 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame86 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame87 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame88 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame89 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame90 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame91 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame92 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame93 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame94 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame95 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame96 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame97 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame98 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame99 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame100 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame101 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame102 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame103 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame104 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame105 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame106 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame107 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame108 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame109 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame110 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame111 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame112 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame113 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame114 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame115 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame116 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame117 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame118 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame119 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame120 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame121 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame122 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame123 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame124 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame125 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame126 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame127 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame128 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame129 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame130 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame131 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame132 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame133 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame134 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame135 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame136 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame137 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame138 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame139 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame140 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame141 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame142 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame143 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame144 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame145 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame146 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame147 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame148 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame149 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame150 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame151 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame152 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame153 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame154 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame155 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame156 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame157 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame158 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame159 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame160 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame161 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame162 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame163 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame164 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame165 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame166 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame167 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame168 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame169 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame170 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame171 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame172 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame173 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame174 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame175 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame176 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame177 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame178 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame179 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame180 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame181 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame182 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame183 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame184 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame185 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame186 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame187 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame188 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame189 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame190 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame191 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame192 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame193 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame194 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame195 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame196 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame197 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame198 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame199 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame200 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame201 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame202 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame203 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame204 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame205 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame206 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame207 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame208 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame209 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame210 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame211 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame212 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame213 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame214 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame215 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame216 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame217 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame218 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame219 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame220 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame221 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame222 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame223 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame224 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame225 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame226 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame227 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame228 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame229 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame230 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame231 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame232 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame233 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame234 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame235 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame236 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame237 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame238 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame239 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame240 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame241 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame242 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame243 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame244 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame245 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame246 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame247 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame248 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame249 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame250 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame251 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame252 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame253 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame254 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame255 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame256 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame257 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame258 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame259 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame260 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame261 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame262 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame263 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame264 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame265 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame266 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame267 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame268 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame269 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame270 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame271 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame272 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame273 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame274 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame275 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame276 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame277 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame278 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame279 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame280 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame281 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame282 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame283 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame284 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame285 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame286 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame287 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame288 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame289 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame290 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame291 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame292 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame293 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame294 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame295 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame296 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame297 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame298 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame299 As Mat = New Mat(640, 360, MatType.CV_8UC3)
    Private frame300 As Mat = New Mat(640, 360, MatType.CV_8UC3)

#End Region


    Private WithEvents webcam_sleep As New DispatcherTimer()
    Private webcam_sleepcount As Integer = 0

    '♥
    Private Sub webcam_sleep_Tick(sender As Object, e As EventArgs) Handles webcam_sleep.Tick

        webcam_sleepcount += 1

        If webcam_sleepcount = 2 Then

            btncur_webcamera.Enabled = True
            btnconnect_camera.Enabled = True

            If btncur_webcamera.Text = My.Resources.Message.msgc02 Then '接続中
                btnresetup.Enabled = True

            Else '切断中
                btnresetup.Enabled = False

            End If

            webcam_sleepcount = 0
            webcam_sleep.Stop()


        End If

    End Sub



    Private Sub cv_prepare()
        '適切な解像度を入力しているか確認
        If (numcv_sizex.Value Mod 16 = 0 And numcv_sizey.Value Mod 9 = 0) Or (numcv_sizex.Value Mod 4 = 0 And numcv_sizey.Value Mod 3 = 0) Then
            Console.WriteLine(numcv_sizex.Value & ", " & numcv_sizey.Value)

            PictureBoxIpl1.Size = New Drawing.Size(numcv_sizex.Value, numcv_sizey.Value)
            pictempipl.Size = New Drawing.Size(numcv_sizex.Value, numcv_sizey.Value)
            piccap.Size = New Drawing.Size(numcv_sizex.Value, numcv_sizey.Value)
            piccap.Location = New Drawing.Point(-10000, 0)

            piczoom.Location = New Drawing.Point(0, numcv_sizey.Value)
            picview_capture.Location = New Drawing.Point((piczoom.Width + 5) * Dpi_rate, (numcv_sizey.Value + 30) * Dpi_rate) '(numcv_sizex.Value / 2) - 100

            pnlview_window.Location = New Drawing.Point(0, lbltitlebar.Height - (4 * Dpi_rate))
            pnlview_window.Size = New Drawing.Size(numcv_sizex.Value * Dpi_rate, (numcv_sizey.Value + piczoom.Height) * Dpi_rate)

            pnlview_control.Location = New Drawing.Point(pnlview_window.Width, lbltitlebar.Height - (4 * Dpi_rate))

            If pnlview_window.Height < 340 * Dpi_rate Then
                pnlview_control.Size = New Drawing.Size(220 * Dpi_rate, 340 * Dpi_rate)
            Else '解像度大
                pnlview_control.Size = New Drawing.Size(220 * Dpi_rate, (pnlview_window.Location.Y + pnlview_window.Height) * Dpi_rate)
            End If


            Me.Size = New Drawing.Size((pnlview_window.Width + pnlview_control.Width),
                                           (pnlview_control.Height + DGtable.Height + 60) * Dpi_rate)

            btnclosewindow.Location = New Drawing.Point(10000, 0)
            btnsaisyouka.Location = New Drawing.Point(10000, 0)

            btnview_close.Location = New Drawing.Point(Me.Width - btnview_close.Width, 0)

            DGtable.Location = New Drawing.Point(8 * Dpi_rate, (pnlview_control.Location.Y + pnlview_control.Height + 9) * Dpi_rate)
            DGtable.Size = New Drawing.Size(525 * Dpi_rate, 146 * Dpi_rate)

            txtrowscount.Location = New Drawing.Point(8 * Dpi_rate, DGtable.Location.Y * Dpi_rate)

            Label32.Location = New Drawing.Point((piczoom.Width + 10) * Dpi_rate, (numcv_sizey.Value + 30 - 17) * Dpi_rate) '(numcv_sizex.Value / 2) - 100

            pnl_parameter.Location = New Drawing.Point(10000, 0)
            pnl_cvparameter.Location = New Drawing.Point(10000, 0)
            pnl_focus.Location = New Drawing.Point(10000, 0)
            pnl_hotkey.Location = New Drawing.Point(10000, 0)
            pnl_loadremover.Location = New Drawing.Point(10000, 0)
            pnl_graph.Location = New Drawing.Point(10000, 0)
            pnl_video.Location = New Drawing.Point(10000, 0)
            pnl_other.Location = New Drawing.Point(10000, 0)

            MenuStrip1.Visible = False
            btnclose_general.Visible = False
            listsetcontents.Visible = False
            grpgeneral.Visible = False


            Load_preview()


        Else

            MessageBox.Show(My.Resources.Message.msg52, messagebox_name)


        End If


    End Sub

    Private Sub Load_preview()

        lbltitlebar.Text = My.Resources.Message.msgb2 '"Preview"

        capturecv.Read(frame)

        If chkcv_crop.Checked = True Then

            '■先にクロップをする。
            dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                  CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

            Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

            dst_cropRect.CopyTo(dst_cropped)

            '■リサイズ
            dst_resize = New Mat()
            Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

            PictureBoxIpl1.ImageIpl = dst_resize

            dst_cropRect.Dispose()
            dst_cropped.Dispose()
            ' dst_resize.Dispose()


        ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

            If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                PictureBoxIpl1.ImageIpl = frame


            Else

                dst_resize = New Mat()
                Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                PictureBoxIpl1.ImageIpl = dst_resize

                'dst_resize.Dispose()


            End If

        End If







        cvpreview.Interval = New TimeSpan(0, 0, 0, 0, 30)
        cvpreview_zoom.Interval = New TimeSpan(0, 0, 0, 0, 30)
        cvpreview_replay.Interval = New TimeSpan(0, 0, 0, 0, 30)

        cvpreview.Start()
        Capture_TF = 0

        cvpreview_zoom.Start()
        cvpreview_replay.Start()


        txtclickcount.Text = 0


    End Sub

    Private Sub cvPreview_Tick(sender As Object, e As EventArgs) Handles cvpreview.Tick

        If btncap.Focused Then
            btncap.Text = "Capture" & vbCrLf & "[Press Space]"
        Else
            btncap.Text = "Capture"
        End If


        Try

            capturecv.Read(frame)

            If Capture_TF = 0 Then

                If chkcv_crop.Checked = True Then

                    '■先にクロップをする。
                    dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                        CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

                    Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

                    dst_cropRect.CopyTo(dst_cropped)

                    '■リサイズ
                    dst_resize = New Mat()
                    Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                    PictureBoxIpl1.ImageIpl = dst_resize

                    cvpreview_replayfunc()

                    dst_cropRect.Dispose()
                    dst_cropped.Dispose()
                    'dst_resize.Dispose()


                ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

                    If numcv_sizex.Value = numcrop_resolution_x.Value And
                       numcv_sizey.Value = numcrop_resolution_y.Value Then

                        PictureBoxIpl1.ImageIpl = frame

                        cvpreview_replayfunc()

                    Else

                        dst_resize = New Mat()
                        Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                        PictureBoxIpl1.ImageIpl = dst_resize

                        cvpreview_replayfunc()

                        'dst_resize.Dispose()


                    End If

                End If

            End If

            '   cvpreview_replayfunc()


            '■選択行番号の再取得。■■■■■■■■■■■■■■■■■■
            For Each r11 As DataGridViewRow In DGtable.SelectedRows
                txtrowscount.Text = r11.Index
            Next r11

            Dim psnumber As Integer = txtrowscount.Text
            txtno_comment.Text = psnumber & "," & CStr(DGtable(0, psnumber).Value)

        Catch ex As Exception
            'cvpreview.Stop()
            Capture_TF = 1

            MessageBox.Show(My.Resources.Message.msg43, messagebox_name) '接続エラー。本体を再起動して下さい。
            rtxtlog.AppendText(Now & " " & My.Resources.Message.msg43 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try


    End Sub

    Private Capture_TF As Integer = 0
    '■OpenCVキャプチャ→限定探索、ローディングあり。C&Dでキャプチャ＆保存
    '■RGBキャプチャ（一部）→限定探索、ローディングなし。C&Dでキャプチャ＆保存。
    '　↑保存データは同じ
    '■RGBキャプチャー（全画面）→限定探索、ローディングなし。1クリックで保存。RGB値を別に取得。
    'pic_capに画像の一部or全部。PX,PY,SX,SYの挿入間違えずに。画像を止めてクリックでRGB取得でも良いかも。
    Private Sub btncap_Click(sender As Object, e As EventArgs) Handles btncap.Click
        Try


            lbltitlebar.Text = My.Resources.Message.msgb1 '"Preview キャプチャ中"

            piccap.Location = New Drawing.Point(0, 0)

            If btntemp.BackColor = Color.Maroon Then

                piccap.Image = pictempipl.Image

            Else

                piccap.Image = PictureBoxIpl1.Image

            End If


            If rdocapture_rgbfull.Checked = True Then
                txtclickcount.Text = 10
                lbltitlebar.Text = "Click to get RGB value."

            End If

            pictempipl.Visible = False
            Capture_TF = 1

            Me.Cursor = Cursors.Cross


        Catch ex As Exception
            MessageBox.Show("キャプチャエラー" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, messagebox_name) '"無効な範囲です。")
            rtxtlog.AppendText(Now & " " & "Capture Error" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)
            Clipboard.SetText(ex.Message & vbCrLf & ex.StackTrace)
        End Try


    End Sub

    Private Sub piccap_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles piccap.MouseDown

        If e.Button = MouseButtons.Left Then
            '開始点の取得

            txt11.Text = CInt(Cursor.Position.X.ToString()) - Me.Location.X
            txt12.Text = CInt(Cursor.Position.Y.ToString()) - Me.Location.Y - lbltitlebar.Height


            If txtclickcount.Text = 0 Then
                skeleton.Show(Me)
            ElseIf txtclickcount.Text = 1 Then
                skeleton.Show(Me)
                skeleton.BackColor = Color.Tomato

            ElseIf txtclickcount.Text = 10 Then

            End If

        End If


    End Sub


    Private Sub piccap_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles piccap.MouseUp
        'ローディング時は限定探索無効
        'piccap：全範囲の画像、picview_capture：指定範囲の画像

        If e.Button = MouseButtons.Left Then

            lbltitlebar.Text = My.Resources.Message.msgb2 '"Preview"

            txt21.Text = CInt(System.Windows.Forms.Cursor.Position.X.ToString()) - Me.Location.X
            txt22.Text = CInt(System.Windows.Forms.Cursor.Position.Y.ToString()) - Me.Location.Y - lbltitlebar.Height

            Try 'RGB全画面取得の時以外では範囲選択内の画像を取得する。

                If txtclickcount.Text = 0 Then

                    '描画先とするImageオブジェクトを作成する
                    Dim canvas As New Bitmap(CInt(txt21.Text - txt11.Text), CInt(txt22.Text - txt12.Text))
                    'ImageオブジェクトのGraphicsオブジェクトを作成する
                    Dim g As Graphics = Graphics.FromImage(canvas)

                    '画像ファイルのImageオブジェクトを作成する
                    Dim img As New Bitmap(piccap.Image)

                    '切り取る部分の範囲を決定する。ここでは、位置(10,10)、大きさ100x100
                    Dim srcRect As New Rectangle(txt11.Text, txt12.Text, canvas.Width, canvas.Height)
                    '描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
                    Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
                    '画像の一部を描画する
                    g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel)

                    'Graphicsオブジェクトのリソースを解放する
                    g.Dispose()

                    'PictureBox1に表示する
                    picview_capture.Image = canvas

                End If

                '■クリックカウント0,1とLoad用の画像かどうか
                If txtclickcount.Text = 0 Then

                    Cursor.Clip = Rectangle.Empty
                    Me.Cursor = Cursors.Default
                    My.Forms.skeleton.Close()

                    '■RGB値取得
                    GetRGB()

                    If chkloading.Checked = False Then 'limit,overwriteはオフにしておく
                        Console.WriteLine("OpenCV通常。")

                        '■画像の保存＋表へ挿入
                        savepicture(picview_capture)


                    ElseIf chkloading.Checked = True Then
                        Console.WriteLine("OpenCV_Loading")

                        Dim savedir As String = txtpass_picturefolder.Text
                        Dim picname_load As String = savedir & "\loading" & numloadno.Value & ".bmp"

                        '■ローディング画像の保存。表は関わらない。
                        picview_capture.Image.Save(picname_load, ImageFormat.Bmp)


                    End If



                    If chklimit.Checked = False And rdocapture_opencv.Checked = True Then
                        Console.WriteLine("OpenCV通常_画像保存後。")
                        '■OpenCV＋通常。loading=Falseで画像、表保存済みなので後処理のみ。

                        lbltitlebar.Text = My.Resources.Message.msgb2 '"Preview"

                        piccap.Location = New Drawing.Point(-10000, 0)

                        Capture_TF = 0

                        Cursor.Clip = Rectangle.Empty
                        Me.Cursor = Cursors.Default
                        My.Forms.skeleton.Close()

                        PictureBoxIpl1.ImageIpl = Nothing
                        PictureBoxIpl1.Image = Nothing
                        piccap.Image = Nothing '2017-05-07　OpenCVSharp3に変更したら、これ書かないとだめになった

                        If btntemp.BackColor = Color.Maroon Then
                            pictempipl.Visible = True


                        End If



                    ElseIf chklimit.Checked = True Or rdocapture_rgb.Checked = True Then '★
                        Console.WriteLine("OpenCV_LimitもしくはRGB_一部")
                        '画像を保持してもう1度操作（count = 1にする）
                        'Limit→範囲選択の前処理、RGB→RGB値取得の前処理

                        If rdocapture_opencv.Checked = True Then
                            lbltitlebar.Text = My.Resources.Message.msgb3 '"Preview キャプチャ中（監視範囲指定）"


                        ElseIf rdocapture_rgb.Checked = True Then
                            lbltitlebar.Text = "Click to get RGB value." 'My.Resources.Message.msgb3 '"Preview キャプチャ中（監視範囲指定）"

                        End If

                        txtclickcount.Text = 1
                        Me.Cursor = Cursors.Cross
                        Cursor.Clip = Rectangle.Empty
                        My.Forms.skeleton.Close()


                    End If



                ElseIf txtclickcount.Text = 1 Then
                    'OpenCV_Limit→指定範囲の値を表に挿入。
                    'RGB_通常→RGB値を表に挿入。

                    Cursor.Clip = Rectangle.Empty
                    Me.Cursor = Cursors.Default
                    My.Forms.skeleton.Close()

                    If rdocapture_opencv.Checked = True Then
                        inserttable_limit()

                    ElseIf rdocapture_rgb.Checked = True Then

                        inserttable_rgb()

                    End If

                    '共通の後処理。
                    lbltitlebar.Text = My.Resources.Message.msgb2 '"Preview"
                    txtclickcount.Text = 0

                    PictureBoxIpl1.ImageIpl = Nothing
                    PictureBoxIpl1.Image = Nothing
                    piccap.Image = Nothing '2017-05-07　OpenCVSharp3に変更したら、これ書かないとだめになった


                    If btntemp.BackColor = Color.Maroon Then
                        pictempipl.Visible = True


                    End If



                ElseIf txtclickcount.Text = 10 Then 'RGB値取得(通常のキャプチャと同じ挙動で。)
                    'Savepictureで全範囲画像、表への挿入＋RGB値の表への挿入

                    lbltitlebar.Text = My.Resources.Message.msgb2 '"Preview"

                    piccap.Location = New Drawing.Point(-10000, 0)

                    Capture_TF = 0

                    Cursor.Clip = Rectangle.Empty
                    Me.Cursor = Cursors.Default
                    My.Forms.skeleton.Close()

                    '■RGB値取得
                    GetRGB()

                    savepicture(piccap)

                    '共通の後処理。
                    lbltitlebar.Text = My.Resources.Message.msgb2 '"Preview"
                    txtclickcount.Text = 0

                    PictureBoxIpl1.ImageIpl = Nothing
                    PictureBoxIpl1.Image = Nothing
                    piccap.Image = Nothing '2017-05-07　OpenCVSharp3に変更したら、これ書かないとだめになった

                    If btntemp.BackColor = Color.Maroon Then
                        pictempipl.Visible = True


                    End If

                End If


            Catch ex As Exception

                txtclickcount.Text = 0
                Cursor.Clip = Rectangle.Empty
                Me.Cursor = Cursors.Default
                My.Forms.skeleton.Close()
                piccap.Location = New Drawing.Point(-10000, 0)

                'cvpreview.Start()
                Capture_TF = 0

                MessageBox.Show(My.Resources.Message.msgb4, messagebox_name) '"無効な範囲です。")
                rtxtlog.AppendText(Now & " " & My.Resources.Message.msgb4 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

            End Try

        End If

        Console.WriteLine("clockcount: " & txtclickcount.Text)



    End Sub

    Private _scrCap As Bitmap
    Private Rvalue, Gvalue, Bvalue As Integer

    Sub GetRGB()

        _scrCap = New Bitmap(1, 1)

        Dim g As Graphics = Graphics.FromImage(_scrCap)
        'カーソル先端1ピクセルのスクリーンをコピー
        g.CopyFromScreen(Cursor.Position.X, Cursor.Position.Y, 0, 0, _scrCap.Size)

        g.Dispose()

        Dim col As Color = _scrCap.GetPixel(0, 0)
        'コピーした画像から色を取得
        Rvalue = col.R
        Gvalue = col.G
        Bvalue = col.B


        Console.WriteLine("R:" & col.R & "G:" & col.G & "B:" & col.B)

    End Sub

    '■画像ファイルの保存とテキストファイルの生成★
    Sub savepicture(captureimage As PictureBox)

        Try

            Dim savedir As String = txtpass_picturefolder.Text
            Dim psnumber As Integer = txtrowscount.Text

            '■フォルダパス＋ファイル名を確定
            Dim picname As String = savedir & "\" & psnumber & ".bmp"
            Dim picname_reset As String = savedir & "\reset.bmp"

            '■上書き確認の有無
            With captureimage
                Console.WriteLine("sdfsfsdfsfdfsfsdfsdfsdf")
                If Not (.Image Is Nothing) Then

                    '上書き確認しない
                    If chkoverwrite.Checked = False Then
                        Console.WriteLine("inserttable")
                        inserttable()

                        If psnumber = 0 Then
                            'テンプレート保存（Reset）
                            .Image.Save(picname_reset, ImageFormat.Bmp)


                        Else
                            'テンプレート保存
                            .Image.Save(picname, ImageFormat.Bmp)

                            'テキストファイルを生成。
                            If Not System.IO.File.Exists(txtpass_rtf.Text & "/" & psnumber & ".rtf") Then

                                My.Computer.FileSystem.CopyFile("./savedata/blank.rtf", txtpass_rtf.Text & "/" & psnumber & ".rtf", False)


                            End If


                        End If

                        '次の行を選択する
                        DGtable.Rows(psnumber).Selected = False
                        DGtable.Rows(psnumber + 1).Selected = True

                        txtno_comment.Text = psnumber + 1 & "," & CStr(DGtable(no.Index, psnumber + 1).Value)






                        '上書き確認する
                    ElseIf chkoverwrite.Checked = True Then

                        '■ファイルが存在しているかどうか確認する

                        '■reset.bmpを保存しようとしている。
                        If psnumber = 0 Then

                            If System.IO.File.Exists(picname_reset) Then

                                'メッセージボックスを表示する 
                                Dim result As DialogResult = MessageBox.Show(
                                    My.Resources.Message.msgb5,
                                    My.Resources.Message.msgb6,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button2) '"ファイルを上書きしますか？"


                                '■「はい」が選択された時は保存、「いいえ」が選択された時はなにもしない。

                                '「はい」が選択された。
                                If result = DialogResult.Yes Then
                                    Console.WriteLine("「はい」が選択されました")

                                    inserttable()

                                    If psnumber = 0 Then

                                        'テンプレートを保存
                                        .Image.Save(picname_reset, ImageFormat.Bmp)

                                    Else
                                        'テンプレートを保存
                                        .Image.Save(picname, ImageFormat.Bmp)

                                        'テキストファイルを生成。
                                        If Not System.IO.File.Exists(txtpass_rtf.Text & "/" & psnumber & ".rtf") Then

                                            My.Computer.FileSystem.CopyFile("./savedata/blank.rtf", txtpass_rtf.Text & "/" & psnumber & ".rtf", False)


                                        End If

                                    End If




                                    txtno_comment.Text = psnumber + 1 & "," & CStr(DGtable(no.Index, psnumber + 1).Value)

                                    '次の行を選択する
                                    DGtable.Rows(psnumber).Selected = False
                                    DGtable.Rows(psnumber + 1).Selected = True


                                    '「いいえ」が選択された
                                ElseIf result = DialogResult.No Then

                                    Console.WriteLine("「いいえ」が選択されました")
                                    Exit Sub


                                End If


                                'reset.bmpが存在しない→上書き確認不要。
                            Else

                                inserttable()

                                If psnumber = 0 Then
                                    'テンプレート保存
                                    .Image.Save(picname_reset, ImageFormat.Bmp)


                                Else
                                    'テンプレート保存
                                    .Image.Save(picname, ImageFormat.Bmp)

                                    'テキストファイルを生成。
                                    If Not System.IO.File.Exists(txtpass_rtf.Text & "/" & psnumber & ".rtf") Then

                                        My.Computer.FileSystem.CopyFile("./savedata/blank.rtf", txtpass_rtf.Text & "/" & psnumber & ".rtf", False)


                                    End If

                                End If

                                txtno_comment.Text = psnumber + 1 & "," & CStr(DGtable(no.Index, psnumber + 1).Value)


                                '次の行を選択する
                                DGtable.Rows(psnumber).Selected = False
                                DGtable.Rows(psnumber + 1).Selected = True


                            End If


                            '■1,2,....bmpを保存しようとしている。
                        Else

                            If System.IO.File.Exists(picname) Then

                                'メッセージボックスを表示する 
                                Dim result As DialogResult = MessageBox.Show(
                                    My.Resources.Message.msgb5,
                                    My.Resources.Message.msgb6,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button2)

                                '■「はい」が選択された時は保存、「いいえ」が選択された時はなにもしない。

                                '「はい」が選択された
                                If result = DialogResult.Yes Then

                                    Console.WriteLine("「はい」が選択されました")

                                    inserttable()

                                    If psnumber = 0 Then

                                        'テンプレート保存
                                        .Image.Save(picname_reset, ImageFormat.Bmp)


                                    Else

                                        'テンプレート保存
                                        .Image.Save(picname, ImageFormat.Bmp)

                                        'テキストファイルを生成。
                                        If Not System.IO.File.Exists(txtpass_rtf.Text & "/" & psnumber & ".rtf") Then

                                            My.Computer.FileSystem.CopyFile("./savedata/blank.rtf", txtpass_rtf.Text & "/" & psnumber & ".rtf", False)


                                        End If

                                    End If

                                    txtno_comment.Text = psnumber + 1 & "," & CStr(DGtable(no.Index, psnumber + 1).Value)


                                    '次の行を選択する
                                    DGtable.Rows(psnumber).Selected = False
                                    DGtable.Rows(psnumber + 1).Selected = True



                                    '「いいえ」が選択された 
                                ElseIf result = DialogResult.No Then

                                    Console.WriteLine("「いいえ」が選択されました")
                                    Exit Sub

                                End If


                                'n.bmpが存在しない→上書き確認必要なし。
                            Else

                                inserttable()

                                If psnumber = 0 Then

                                    'テンプレート保存
                                    .Image.Save(picname_reset, ImageFormat.Bmp)


                                Else

                                    'テンプレート保存
                                    .Image.Save(picname, ImageFormat.Bmp)

                                    'テキストファイルを生成。
                                    If Not System.IO.File.Exists(txtpass_rtf.Text & "/" & psnumber & ".rtf") Then

                                        My.Computer.FileSystem.CopyFile("./savedata/blank.rtf", txtpass_rtf.Text & "/" & psnumber & ".rtf", False)


                                    End If


                                End If

                                txtno_comment.Text = psnumber + 1 & "," & CStr(DGtable(no.Index, psnumber + 1).Value)


                                '次の行を選択する
                                DGtable.Rows(psnumber).Selected = False
                                DGtable.Rows(psnumber + 1).Selected = True

                            End If

                        End If

                    End If '上書きONOFF

                End If

            End With

        Catch ex As Exception

            MessageBox.Show(My.Resources.Message.msgb7, messagebox_name) '"行選択状態でキャプチャして下さい。"
            rtxtlog.AppendText(Now & " " & My.Resources.Message.msgb7 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

            Exit Sub


        End Try


    End Sub

    Sub inserttable()

        '■行選択がされている状態時のみ各パラメータを送信。
        Dim selectedRowCount As Integer = DGtable.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then

            Dim sb As New System.Text.StringBuilder()

            sb.Append("Row: ")
            sb.Append(DGtable.SelectedRows(0).Index.ToString())
            sb.Append(Environment.NewLine)

            Dim aaa As Integer = DGtable.SelectedRows(0).Index.ToString()


            '最終行を選択している状態の場合、1行追加する。
            If DGtable.RowCount - 1 <= aaa Then
                DGtable.Rows.Add(1)

            End If

            '■表へ各パラメータを代入。
            If rdocapture_opencv.Checked = True Then
                DGtable(send.Index, aaa).Value = 1
            Else
                DGtable(send.Index, aaa).Value = 3
            End If


            DGtable(key.Index, aaa).Value = 0
            DGtable(rate.Index, aaa).Value = numpercent.Text
            DGtable(sleep.Index, aaa).Value = numstop.Text
            DGtable(timing.Index, aaa).Value = 0

            If rdocapture_opencv.Checked = True Then
                DGtable(posx.Index, aaa).Value = (numcv_sizex.Text / 2) - 20 'lblform2_posx.Text
                DGtable(posy.Index, aaa).Value = (numcv_sizey.Text / 2) - 20 'lblform2_posy.Text
                DGtable(sizex.Index, aaa).Value = 40
                DGtable(sizey.Index, aaa).Value = 40

            ElseIf rdocapture_rgb.Checked = True Then
                DGtable(posx.Index, aaa).Value = txt11.Text
                DGtable(posy.Index, aaa).Value = txt12.Text
                DGtable(sizex.Index, aaa).Value = CInt(txt21.Text - txt11.Text)
                DGtable(sizey.Index, aaa).Value = CInt(txt22.Text - txt12.Text)

            ElseIf rdocapture_rgbfull.Checked = True Then
                DGtable(posx.Index, aaa).Value = 0
                DGtable(posy.Index, aaa).Value = 0
                DGtable(sizex.Index, aaa).Value = numcv_sizex.Value
                DGtable(sizey.Index, aaa).Value = numcv_sizey.Value

            End If


            DGtable(darksleep.Index, aaa).Value = 0
            DGtable(darkthr.Index, aaa).Value = numanten.Text
            DGtable(ltx.Index, aaa).Value = 0
            DGtable(lty.Index, aaa).Value = 0
            DGtable(rbx.Index, aaa).Value = 1000
            DGtable(rby.Index, aaa).Value = 1000

            DGtable(graph_count.Index, aaa).Value = 0
            DGtable(graph_rate.Index, aaa).Value = 0
            DGtable(graph_view.Index, aaa).Value = 0

            DGtable(color_r.Index, aaa).Value = Rvalue
            DGtable(color_g.Index, aaa).Value = Gvalue
            DGtable(color_b.Index, aaa).Value = Bvalue

            DGtable(seektime.Index, aaa).Value = -1


            '表をスクロールさせる
            DGtable.FirstDisplayedScrollingRowIndex = txtrowscount.Text

            '最終行を選択している状態の場合、1行追加する。
            If DGtable.RowCount - 1 <= aaa Then
                DGtable.Rows.Add(1)

            End If

        End If


    End Sub

    Sub inserttable_limit()

        txtclickcount.Text = 0

        '■行選択がされている状態時のみ各パラメータを送信。
        Dim selectedRowCount As Integer = DGtable.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then

            Dim sb As New System.Text.StringBuilder()

            sb.Append("Row: ")
            sb.Append(DGtable.SelectedRows(0).Index.ToString())
            sb.Append(Environment.NewLine)

            Dim aaa As Integer = DGtable.SelectedRows(0).Index.ToString()


            '■表へ各パラメータを代入。
            DGtable(ltx.Index, aaa - 1).Value = txt11.Text
            DGtable(lty.Index, aaa - 1).Value = txt12.Text
            DGtable(rbx.Index, aaa - 1).Value = txt21.Text
            DGtable(rby.Index, aaa - 1).Value = txt22.Text



            piccap.Location = New Drawing.Point(-10000, 0)

            Capture_TF = 0

        End If


    End Sub

    Sub inserttable_rgb() 'まだ触れてない★

        txtclickcount.Text = 0

        '■RGB値取得
        GetRGB()

        '■行選択がされている状態時のみ各パラメータを送信。
        Dim selectedRowCount As Integer = DGtable.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then

            Dim sb As New System.Text.StringBuilder()

            sb.Append("Row: ")
            sb.Append(DGtable.SelectedRows(0).Index.ToString())
            sb.Append(Environment.NewLine)

            Dim aaa As Integer = DGtable.SelectedRows(0).Index.ToString()


            '■表へ各パラメータを代入。
            DGtable(color_r.Index, aaa - 1).Value = Rvalue
            DGtable(color_g.Index, aaa - 1).Value = Gvalue
            DGtable(color_b.Index, aaa - 1).Value = Bvalue



            piccap.Location = New Drawing.Point(-10000, 0)

            Capture_TF = 0

        End If


    End Sub

    '現在のコードを実行しているAssemblyを取得
    Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()
    Private bmp_size As New Bitmap(myAssembly.GetManifestResourceStream("AutoSplitHelper_OpenCV.size.bmp")) '(".\savedata\size.bmp")

    Private Sub Preview_zoom_Tick(sender As Object, e As EventArgs) Handles cvpreview_zoom.Tick

        'ImageオブジェクトのGraphicsオブジェクトを作成する（過去のコードに一般的なやつを残してる）
        Dim g As Graphics = Graphics.FromImage(bmp_size)

        Dim ltx As Integer = CInt(Cursor.Position.X.ToString()) - 50
        Dim lty As Integer = CInt(Cursor.Position.Y.ToString()) - 30

        g.CopyFromScreen(New Drawing.Point(ltx, lty), New Drawing.Point(0, 0), New Drawing.Size(100, 60))
        '解放
        g.DrawLine(Pens.Red, 50, 0, 50, 60)
        g.DrawLine(Pens.Red, 0, 30, 100, 30)

        g.Dispose()

        'PictureBox1に表示する
        piczoom.Image = bmp_size


    End Sub


    Private Sub chkloading_CheckedChanged(sender As Object, e As EventArgs) Handles chkloading.CheckedChanged

        If chkloading.Checked = True Then

            chklimit.Checked = False
            chkoverwrite.Checked = False
            chklimit.Enabled = False
            chkoverwrite.Enabled = False


        ElseIf chkloading.Checked = False Then

            chklimit.Enabled = True
            chkoverwrite.Enabled = True


        End If


    End Sub

    Private Sub btnforward_Click(sender As Object, e As EventArgs) Handles btnforward.Click

        DGtable.ClearSelection()

        Dim psnumber As Integer = txtrowscount.Text

        If psnumber >= DGtable.Rows.Count - 1 - 1 Then
            MessageBox.Show("Nothing", messagebox_name)

        Else
            txtrowscount.Text += 1
            DGtable.Rows(txtrowscount.Text).Selected = True


        End If


    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click

        DGtable.ClearSelection()

        Dim psnumber As Integer = txtrowscount.Text

        If psnumber <= 0 Then
            MessageBox.Show("Nothing", messagebox_name)

        Else
            txtrowscount.Text -= 1
            DGtable.Rows(txtrowscount.Text).Selected = True

        End If


    End Sub


    Private replayTF As Integer = 0

    Private Sub btntemp_Click(sender As Object, e As EventArgs) Handles btntemp.Click

        If btntemp.BackColor = Color.FromArgb(50, 52, 54) Then '一時保存映像を見る

            btntemp.BackColor = Color.Maroon

            pictempipl.ImageIpl = frame

            'cvpreview_replay.Stop()
            replayTF = 1
            pictempipl.Visible = True

            txtsavetempnumber.Text = tempnumber
            trktemp.Value = 300


        ElseIf btntemp.BackColor = Color.Maroon Then '一時保存映像を消す

            btntemp.BackColor = Color.FromArgb(50, 52, 54)

            'cvpreview_replay.Start()
            replayTF = 0
            pictempipl.Visible = False
            trktemp.Value = 300


        End If


    End Sub

    Private Sub trktemp_Scroll(sender As Object, e As EventArgs) Handles trktemp.Scroll

        Dim viewnumber As Integer

        viewnumber = trktemp.Value - (301 - txtsavetempnumber.Text)

        Console.WriteLine("補正前：" & viewnumber)

        If viewnumber < 0 Then
            viewnumber += 301
        End If

        Console.WriteLine("補正後：" & viewnumber)

        numtemp.Value = viewnumber


    End Sub

    Private Sub numtemp_ValueChanged(sender As Object, e As EventArgs) Handles numtemp.ValueChanged

        Select Case numtemp.Value

            Case 0
                pictempipl.ImageIpl = frame0
            Case 1
                pictempipl.ImageIpl = frame1
            Case 2
                pictempipl.ImageIpl = frame2
            Case 3
                pictempipl.ImageIpl = frame3
            Case 4
                pictempipl.ImageIpl = frame4
            Case 5
                pictempipl.ImageIpl = frame5
            Case 6
                pictempipl.ImageIpl = frame6
            Case 7
                pictempipl.ImageIpl = frame7
            Case 8
                pictempipl.ImageIpl = frame8
            Case 9
                pictempipl.ImageIpl = frame9
            Case 10
                pictempipl.ImageIpl = frame10
            Case 11
                pictempipl.ImageIpl = frame11
            Case 12
                pictempipl.ImageIpl = frame12
            Case 13
                pictempipl.ImageIpl = frame13
            Case 14
                pictempipl.ImageIpl = frame14
            Case 15
                pictempipl.ImageIpl = frame15
            Case 16
                pictempipl.ImageIpl = frame16
            Case 17
                pictempipl.ImageIpl = frame17
            Case 18
                pictempipl.ImageIpl = frame18
            Case 19
                pictempipl.ImageIpl = frame19
            Case 20
                pictempipl.ImageIpl = frame20
            Case 21
                pictempipl.ImageIpl = frame21
            Case 22
                pictempipl.ImageIpl = frame22
            Case 23
                pictempipl.ImageIpl = frame23
            Case 24
                pictempipl.ImageIpl = frame24
            Case 25
                pictempipl.ImageIpl = frame25
            Case 26
                pictempipl.ImageIpl = frame26
            Case 27
                pictempipl.ImageIpl = frame27
            Case 28
                pictempipl.ImageIpl = frame28
            Case 29
                pictempipl.ImageIpl = frame29
            Case 30
                pictempipl.ImageIpl = frame30
            Case 31
                pictempipl.ImageIpl = frame31
            Case 32
                pictempipl.ImageIpl = frame32
            Case 33
                pictempipl.ImageIpl = frame33
            Case 34
                pictempipl.ImageIpl = frame34
            Case 35
                pictempipl.ImageIpl = frame35
            Case 36
                pictempipl.ImageIpl = frame36
            Case 37
                pictempipl.ImageIpl = frame37
            Case 38
                pictempipl.ImageIpl = frame38
            Case 39
                pictempipl.ImageIpl = frame39
            Case 40
                pictempipl.ImageIpl = frame40
            Case 41
                pictempipl.ImageIpl = frame41
            Case 42
                pictempipl.ImageIpl = frame42
            Case 43
                pictempipl.ImageIpl = frame43
            Case 44
                pictempipl.ImageIpl = frame44
            Case 45
                pictempipl.ImageIpl = frame45
            Case 46
                pictempipl.ImageIpl = frame46
            Case 47
                pictempipl.ImageIpl = frame47
            Case 48
                pictempipl.ImageIpl = frame48
            Case 49
                pictempipl.ImageIpl = frame49
            Case 50
                pictempipl.ImageIpl = frame50
            Case 51
                pictempipl.ImageIpl = frame51
            Case 52
                pictempipl.ImageIpl = frame52
            Case 53
                pictempipl.ImageIpl = frame53
            Case 54
                pictempipl.ImageIpl = frame54
            Case 55
                pictempipl.ImageIpl = frame55
            Case 56
                pictempipl.ImageIpl = frame56
            Case 57
                pictempipl.ImageIpl = frame57
            Case 58
                pictempipl.ImageIpl = frame58
            Case 59
                pictempipl.ImageIpl = frame59
            Case 60
                pictempipl.ImageIpl = frame60
            Case 61
                pictempipl.ImageIpl = frame61
            Case 62
                pictempipl.ImageIpl = frame62
            Case 63
                pictempipl.ImageIpl = frame63
            Case 64
                pictempipl.ImageIpl = frame64
            Case 65
                pictempipl.ImageIpl = frame65
            Case 66
                pictempipl.ImageIpl = frame66
            Case 67
                pictempipl.ImageIpl = frame67
            Case 68
                pictempipl.ImageIpl = frame68
            Case 69
                pictempipl.ImageIpl = frame69
            Case 70
                pictempipl.ImageIpl = frame70
            Case 71
                pictempipl.ImageIpl = frame71
            Case 72
                pictempipl.ImageIpl = frame72
            Case 73
                pictempipl.ImageIpl = frame73
            Case 74
                pictempipl.ImageIpl = frame74
            Case 75
                pictempipl.ImageIpl = frame75
            Case 76
                pictempipl.ImageIpl = frame76
            Case 77
                pictempipl.ImageIpl = frame77
            Case 78
                pictempipl.ImageIpl = frame78
            Case 79
                pictempipl.ImageIpl = frame79
            Case 80
                pictempipl.ImageIpl = frame80
            Case 81
                pictempipl.ImageIpl = frame81
            Case 82
                pictempipl.ImageIpl = frame82
            Case 83
                pictempipl.ImageIpl = frame83
            Case 84
                pictempipl.ImageIpl = frame84
            Case 85
                pictempipl.ImageIpl = frame85
            Case 86
                pictempipl.ImageIpl = frame86
            Case 87
                pictempipl.ImageIpl = frame87
            Case 88
                pictempipl.ImageIpl = frame88
            Case 89
                pictempipl.ImageIpl = frame89
            Case 90
                pictempipl.ImageIpl = frame90
            Case 91
                pictempipl.ImageIpl = frame91
            Case 92
                pictempipl.ImageIpl = frame92
            Case 93
                pictempipl.ImageIpl = frame93
            Case 94
                pictempipl.ImageIpl = frame94
            Case 95
                pictempipl.ImageIpl = frame95
            Case 96
                pictempipl.ImageIpl = frame96
            Case 97
                pictempipl.ImageIpl = frame97
            Case 98
                pictempipl.ImageIpl = frame98
            Case 99
                pictempipl.ImageIpl = frame99
            Case 100
                pictempipl.ImageIpl = frame100
            Case 101
                pictempipl.ImageIpl = frame101
            Case 102
                pictempipl.ImageIpl = frame102
            Case 103
                pictempipl.ImageIpl = frame103
            Case 104
                pictempipl.ImageIpl = frame104
            Case 105
                pictempipl.ImageIpl = frame105
            Case 106
                pictempipl.ImageIpl = frame106
            Case 107
                pictempipl.ImageIpl = frame107
            Case 108
                pictempipl.ImageIpl = frame108
            Case 109
                pictempipl.ImageIpl = frame109
            Case 110
                pictempipl.ImageIpl = frame110
            Case 111
                pictempipl.ImageIpl = frame111
            Case 112
                pictempipl.ImageIpl = frame112
            Case 113
                pictempipl.ImageIpl = frame113
            Case 114
                pictempipl.ImageIpl = frame114
            Case 115
                pictempipl.ImageIpl = frame115
            Case 116
                pictempipl.ImageIpl = frame116
            Case 117
                pictempipl.ImageIpl = frame117
            Case 118
                pictempipl.ImageIpl = frame118
            Case 119
                pictempipl.ImageIpl = frame119
            Case 120
                pictempipl.ImageIpl = frame120
            Case 121
                pictempipl.ImageIpl = frame121
            Case 122
                pictempipl.ImageIpl = frame122
            Case 123
                pictempipl.ImageIpl = frame123
            Case 124
                pictempipl.ImageIpl = frame124
            Case 125
                pictempipl.ImageIpl = frame125
            Case 126
                pictempipl.ImageIpl = frame126
            Case 127
                pictempipl.ImageIpl = frame127
            Case 128
                pictempipl.ImageIpl = frame128
            Case 129
                pictempipl.ImageIpl = frame129
            Case 130
                pictempipl.ImageIpl = frame130
            Case 131
                pictempipl.ImageIpl = frame131
            Case 132
                pictempipl.ImageIpl = frame132
            Case 133
                pictempipl.ImageIpl = frame133
            Case 134
                pictempipl.ImageIpl = frame134
            Case 135
                pictempipl.ImageIpl = frame135
            Case 136
                pictempipl.ImageIpl = frame136
            Case 137
                pictempipl.ImageIpl = frame137
            Case 138
                pictempipl.ImageIpl = frame138
            Case 139
                pictempipl.ImageIpl = frame139
            Case 140
                pictempipl.ImageIpl = frame140
            Case 141
                pictempipl.ImageIpl = frame141
            Case 142
                pictempipl.ImageIpl = frame142
            Case 143
                pictempipl.ImageIpl = frame143
            Case 144
                pictempipl.ImageIpl = frame144
            Case 145
                pictempipl.ImageIpl = frame145
            Case 146
                pictempipl.ImageIpl = frame146
            Case 147
                pictempipl.ImageIpl = frame147
            Case 148
                pictempipl.ImageIpl = frame148
            Case 149
                pictempipl.ImageIpl = frame149
            Case 150
                pictempipl.ImageIpl = frame150
            Case 151
                pictempipl.ImageIpl = frame151
            Case 152
                pictempipl.ImageIpl = frame152
            Case 153
                pictempipl.ImageIpl = frame153
            Case 154
                pictempipl.ImageIpl = frame154
            Case 155
                pictempipl.ImageIpl = frame155
            Case 156
                pictempipl.ImageIpl = frame156
            Case 157
                pictempipl.ImageIpl = frame157
            Case 158
                pictempipl.ImageIpl = frame158
            Case 159
                pictempipl.ImageIpl = frame159
            Case 160
                pictempipl.ImageIpl = frame160
            Case 161
                pictempipl.ImageIpl = frame161
            Case 162
                pictempipl.ImageIpl = frame162
            Case 163
                pictempipl.ImageIpl = frame163
            Case 164
                pictempipl.ImageIpl = frame164
            Case 165
                pictempipl.ImageIpl = frame165
            Case 166
                pictempipl.ImageIpl = frame166
            Case 167
                pictempipl.ImageIpl = frame167
            Case 168
                pictempipl.ImageIpl = frame168
            Case 169
                pictempipl.ImageIpl = frame169
            Case 170
                pictempipl.ImageIpl = frame170
            Case 171
                pictempipl.ImageIpl = frame171
            Case 172
                pictempipl.ImageIpl = frame172
            Case 173
                pictempipl.ImageIpl = frame173
            Case 174
                pictempipl.ImageIpl = frame174
            Case 175
                pictempipl.ImageIpl = frame175
            Case 176
                pictempipl.ImageIpl = frame176
            Case 177
                pictempipl.ImageIpl = frame177
            Case 178
                pictempipl.ImageIpl = frame178
            Case 179
                pictempipl.ImageIpl = frame179
            Case 180
                pictempipl.ImageIpl = frame180
            Case 181
                pictempipl.ImageIpl = frame181
            Case 182
                pictempipl.ImageIpl = frame182
            Case 183
                pictempipl.ImageIpl = frame183
            Case 184
                pictempipl.ImageIpl = frame184
            Case 185
                pictempipl.ImageIpl = frame185
            Case 186
                pictempipl.ImageIpl = frame186
            Case 187
                pictempipl.ImageIpl = frame187
            Case 188
                pictempipl.ImageIpl = frame188
            Case 189
                pictempipl.ImageIpl = frame189
            Case 190
                pictempipl.ImageIpl = frame190
            Case 191
                pictempipl.ImageIpl = frame191
            Case 192
                pictempipl.ImageIpl = frame192
            Case 193
                pictempipl.ImageIpl = frame193
            Case 194
                pictempipl.ImageIpl = frame194
            Case 195
                pictempipl.ImageIpl = frame195
            Case 196
                pictempipl.ImageIpl = frame196
            Case 197
                pictempipl.ImageIpl = frame197
            Case 198
                pictempipl.ImageIpl = frame198
            Case 199
                pictempipl.ImageIpl = frame199
            Case 200
                pictempipl.ImageIpl = frame200
            Case 201
                pictempipl.ImageIpl = frame201
            Case 202
                pictempipl.ImageIpl = frame202
            Case 203
                pictempipl.ImageIpl = frame203
            Case 204
                pictempipl.ImageIpl = frame204
            Case 205
                pictempipl.ImageIpl = frame205
            Case 206
                pictempipl.ImageIpl = frame206
            Case 207
                pictempipl.ImageIpl = frame207
            Case 208
                pictempipl.ImageIpl = frame208
            Case 209
                pictempipl.ImageIpl = frame209
            Case 210
                pictempipl.ImageIpl = frame210
            Case 211
                pictempipl.ImageIpl = frame211
            Case 212
                pictempipl.ImageIpl = frame212
            Case 213
                pictempipl.ImageIpl = frame213
            Case 214
                pictempipl.ImageIpl = frame214
            Case 215
                pictempipl.ImageIpl = frame215
            Case 216
                pictempipl.ImageIpl = frame216
            Case 217
                pictempipl.ImageIpl = frame217
            Case 218
                pictempipl.ImageIpl = frame218
            Case 219
                pictempipl.ImageIpl = frame219
            Case 220
                pictempipl.ImageIpl = frame220
            Case 221
                pictempipl.ImageIpl = frame221
            Case 222
                pictempipl.ImageIpl = frame222
            Case 223
                pictempipl.ImageIpl = frame223
            Case 224
                pictempipl.ImageIpl = frame224
            Case 225
                pictempipl.ImageIpl = frame225
            Case 226
                pictempipl.ImageIpl = frame226
            Case 227
                pictempipl.ImageIpl = frame227
            Case 228
                pictempipl.ImageIpl = frame228
            Case 229
                pictempipl.ImageIpl = frame229
            Case 230
                pictempipl.ImageIpl = frame230
            Case 231
                pictempipl.ImageIpl = frame231
            Case 232
                pictempipl.ImageIpl = frame232
            Case 233
                pictempipl.ImageIpl = frame233
            Case 234
                pictempipl.ImageIpl = frame234
            Case 235
                pictempipl.ImageIpl = frame235
            Case 236
                pictempipl.ImageIpl = frame236
            Case 237
                pictempipl.ImageIpl = frame237
            Case 238
                pictempipl.ImageIpl = frame238
            Case 239
                pictempipl.ImageIpl = frame239
            Case 240
                pictempipl.ImageIpl = frame240
            Case 241
                pictempipl.ImageIpl = frame241
            Case 242
                pictempipl.ImageIpl = frame242
            Case 243
                pictempipl.ImageIpl = frame243
            Case 244
                pictempipl.ImageIpl = frame244
            Case 245
                pictempipl.ImageIpl = frame245
            Case 246
                pictempipl.ImageIpl = frame246
            Case 247
                pictempipl.ImageIpl = frame247
            Case 248
                pictempipl.ImageIpl = frame248
            Case 249
                pictempipl.ImageIpl = frame249
            Case 250
                pictempipl.ImageIpl = frame250
            Case 251
                pictempipl.ImageIpl = frame251
            Case 252
                pictempipl.ImageIpl = frame252
            Case 253
                pictempipl.ImageIpl = frame253
            Case 254
                pictempipl.ImageIpl = frame254
            Case 255
                pictempipl.ImageIpl = frame255
            Case 256
                pictempipl.ImageIpl = frame256
            Case 257
                pictempipl.ImageIpl = frame257
            Case 258
                pictempipl.ImageIpl = frame258
            Case 259
                pictempipl.ImageIpl = frame259
            Case 260
                pictempipl.ImageIpl = frame260
            Case 261
                pictempipl.ImageIpl = frame261
            Case 262
                pictempipl.ImageIpl = frame262
            Case 263
                pictempipl.ImageIpl = frame263
            Case 264
                pictempipl.ImageIpl = frame264
            Case 265
                pictempipl.ImageIpl = frame265
            Case 266
                pictempipl.ImageIpl = frame266
            Case 267
                pictempipl.ImageIpl = frame267
            Case 268
                pictempipl.ImageIpl = frame268
            Case 269
                pictempipl.ImageIpl = frame269
            Case 270
                pictempipl.ImageIpl = frame270
            Case 271
                pictempipl.ImageIpl = frame271
            Case 272
                pictempipl.ImageIpl = frame272
            Case 273
                pictempipl.ImageIpl = frame273
            Case 274
                pictempipl.ImageIpl = frame274
            Case 275
                pictempipl.ImageIpl = frame275
            Case 276
                pictempipl.ImageIpl = frame276
            Case 277
                pictempipl.ImageIpl = frame277
            Case 278
                pictempipl.ImageIpl = frame278
            Case 279
                pictempipl.ImageIpl = frame279
            Case 280
                pictempipl.ImageIpl = frame280
            Case 281
                pictempipl.ImageIpl = frame281
            Case 282
                pictempipl.ImageIpl = frame282
            Case 283
                pictempipl.ImageIpl = frame283
            Case 284
                pictempipl.ImageIpl = frame284
            Case 285
                pictempipl.ImageIpl = frame285
            Case 286
                pictempipl.ImageIpl = frame286
            Case 287
                pictempipl.ImageIpl = frame287
            Case 288
                pictempipl.ImageIpl = frame288
            Case 289
                pictempipl.ImageIpl = frame289
            Case 290
                pictempipl.ImageIpl = frame290
            Case 291
                pictempipl.ImageIpl = frame291
            Case 292
                pictempipl.ImageIpl = frame292
            Case 293
                pictempipl.ImageIpl = frame293
            Case 294
                pictempipl.ImageIpl = frame294
            Case 295
                pictempipl.ImageIpl = frame295
            Case 296
                pictempipl.ImageIpl = frame296
            Case 297
                pictempipl.ImageIpl = frame297
            Case 298
                pictempipl.ImageIpl = frame298
            Case 299
                pictempipl.ImageIpl = frame299
            Case 300
                pictempipl.ImageIpl = frame300

        End Select


    End Sub

    'Private Sub Preview_replay_Tick(sender As Object, e As EventArgs) Handles cvpreview_replay.Tick
    Private Sub cvpreview_replayfunc()

        If replayTF = 1 Then
            Exit Sub
        End If

        Select Case tempnumber

            Case 0
                PictureBoxIpl1.ImageIpl.CopyTo(frame0)
            Case 1
                PictureBoxIpl1.ImageIpl.CopyTo(frame1)
            Case 2
                PictureBoxIpl1.ImageIpl.CopyTo(frame2)
            Case 3
                PictureBoxIpl1.ImageIpl.CopyTo(frame3)
            Case 4
                PictureBoxIpl1.ImageIpl.CopyTo(frame4)
            Case 5
                PictureBoxIpl1.ImageIpl.CopyTo(frame5)
            Case 6
                PictureBoxIpl1.ImageIpl.CopyTo(frame6)
            Case 7
                PictureBoxIpl1.ImageIpl.CopyTo(frame7)
            Case 8
                PictureBoxIpl1.ImageIpl.CopyTo(frame8)
            Case 9
                PictureBoxIpl1.ImageIpl.CopyTo(frame9)
            Case 10
                PictureBoxIpl1.ImageIpl.CopyTo(frame10)
            Case 11
                PictureBoxIpl1.ImageIpl.CopyTo(frame11)
            Case 12
                PictureBoxIpl1.ImageIpl.CopyTo(frame12)
            Case 13
                PictureBoxIpl1.ImageIpl.CopyTo(frame13)
            Case 14
                PictureBoxIpl1.ImageIpl.CopyTo(frame14)
            Case 15
                PictureBoxIpl1.ImageIpl.CopyTo(frame15)
            Case 16
                PictureBoxIpl1.ImageIpl.CopyTo(frame16)
            Case 17
                PictureBoxIpl1.ImageIpl.CopyTo(frame17)
            Case 18
                PictureBoxIpl1.ImageIpl.CopyTo(frame18)
            Case 19
                PictureBoxIpl1.ImageIpl.CopyTo(frame19)
            Case 20
                PictureBoxIpl1.ImageIpl.CopyTo(frame20)
            Case 21
                PictureBoxIpl1.ImageIpl.CopyTo(frame21)
            Case 22
                PictureBoxIpl1.ImageIpl.CopyTo(frame22)
            Case 23
                PictureBoxIpl1.ImageIpl.CopyTo(frame23)
            Case 24
                PictureBoxIpl1.ImageIpl.CopyTo(frame24)
            Case 25
                PictureBoxIpl1.ImageIpl.CopyTo(frame25)
            Case 26
                PictureBoxIpl1.ImageIpl.CopyTo(frame26)
            Case 27
                PictureBoxIpl1.ImageIpl.CopyTo(frame27)
            Case 28
                PictureBoxIpl1.ImageIpl.CopyTo(frame28)
            Case 29
                PictureBoxIpl1.ImageIpl.CopyTo(frame29)
            Case 30
                PictureBoxIpl1.ImageIpl.CopyTo(frame30)
            Case 31
                PictureBoxIpl1.ImageIpl.CopyTo(frame31)
            Case 32
                PictureBoxIpl1.ImageIpl.CopyTo(frame32)
            Case 33
                PictureBoxIpl1.ImageIpl.CopyTo(frame33)
            Case 34
                PictureBoxIpl1.ImageIpl.CopyTo(frame34)
            Case 35
                PictureBoxIpl1.ImageIpl.CopyTo(frame35)
            Case 36
                PictureBoxIpl1.ImageIpl.CopyTo(frame36)
            Case 37
                PictureBoxIpl1.ImageIpl.CopyTo(frame37)
            Case 38
                PictureBoxIpl1.ImageIpl.CopyTo(frame38)
            Case 39
                PictureBoxIpl1.ImageIpl.CopyTo(frame39)
            Case 40
                PictureBoxIpl1.ImageIpl.CopyTo(frame40)
            Case 41
                PictureBoxIpl1.ImageIpl.CopyTo(frame41)
            Case 42
                PictureBoxIpl1.ImageIpl.CopyTo(frame42)
            Case 43
                PictureBoxIpl1.ImageIpl.CopyTo(frame43)
            Case 44
                PictureBoxIpl1.ImageIpl.CopyTo(frame44)
            Case 45
                PictureBoxIpl1.ImageIpl.CopyTo(frame45)
            Case 46
                PictureBoxIpl1.ImageIpl.CopyTo(frame46)
            Case 47
                PictureBoxIpl1.ImageIpl.CopyTo(frame47)
            Case 48
                PictureBoxIpl1.ImageIpl.CopyTo(frame48)
            Case 49
                PictureBoxIpl1.ImageIpl.CopyTo(frame49)
            Case 50
                PictureBoxIpl1.ImageIpl.CopyTo(frame50)
            Case 51
                PictureBoxIpl1.ImageIpl.CopyTo(frame51)
            Case 52
                PictureBoxIpl1.ImageIpl.CopyTo(frame52)
            Case 53
                PictureBoxIpl1.ImageIpl.CopyTo(frame53)
            Case 54
                PictureBoxIpl1.ImageIpl.CopyTo(frame54)
            Case 55
                PictureBoxIpl1.ImageIpl.CopyTo(frame55)
            Case 56
                PictureBoxIpl1.ImageIpl.CopyTo(frame56)
            Case 57
                PictureBoxIpl1.ImageIpl.CopyTo(frame57)
            Case 58
                PictureBoxIpl1.ImageIpl.CopyTo(frame58)
            Case 59
                PictureBoxIpl1.ImageIpl.CopyTo(frame59)
            Case 60
                PictureBoxIpl1.ImageIpl.CopyTo(frame60)
            Case 61
                PictureBoxIpl1.ImageIpl.CopyTo(frame61)
            Case 62
                PictureBoxIpl1.ImageIpl.CopyTo(frame62)
            Case 63
                PictureBoxIpl1.ImageIpl.CopyTo(frame63)
            Case 64
                PictureBoxIpl1.ImageIpl.CopyTo(frame64)
            Case 65
                PictureBoxIpl1.ImageIpl.CopyTo(frame65)
            Case 66
                PictureBoxIpl1.ImageIpl.CopyTo(frame66)
            Case 67
                PictureBoxIpl1.ImageIpl.CopyTo(frame67)
            Case 68
                PictureBoxIpl1.ImageIpl.CopyTo(frame68)
            Case 69
                PictureBoxIpl1.ImageIpl.CopyTo(frame69)
            Case 70
                PictureBoxIpl1.ImageIpl.CopyTo(frame70)
            Case 71
                PictureBoxIpl1.ImageIpl.CopyTo(frame71)
            Case 72
                PictureBoxIpl1.ImageIpl.CopyTo(frame72)
            Case 73
                PictureBoxIpl1.ImageIpl.CopyTo(frame73)
            Case 74
                PictureBoxIpl1.ImageIpl.CopyTo(frame74)
            Case 75
                PictureBoxIpl1.ImageIpl.CopyTo(frame75)
            Case 76
                PictureBoxIpl1.ImageIpl.CopyTo(frame76)
            Case 77
                PictureBoxIpl1.ImageIpl.CopyTo(frame77)
            Case 78
                PictureBoxIpl1.ImageIpl.CopyTo(frame78)
            Case 79
                PictureBoxIpl1.ImageIpl.CopyTo(frame79)
            Case 80
                PictureBoxIpl1.ImageIpl.CopyTo(frame80)
            Case 81
                PictureBoxIpl1.ImageIpl.CopyTo(frame81)
            Case 82
                PictureBoxIpl1.ImageIpl.CopyTo(frame82)
            Case 83
                PictureBoxIpl1.ImageIpl.CopyTo(frame83)
            Case 84
                PictureBoxIpl1.ImageIpl.CopyTo(frame84)
            Case 85
                PictureBoxIpl1.ImageIpl.CopyTo(frame85)
            Case 86
                PictureBoxIpl1.ImageIpl.CopyTo(frame86)
            Case 87
                PictureBoxIpl1.ImageIpl.CopyTo(frame87)
            Case 88
                PictureBoxIpl1.ImageIpl.CopyTo(frame88)
            Case 89
                PictureBoxIpl1.ImageIpl.CopyTo(frame89)
            Case 90
                PictureBoxIpl1.ImageIpl.CopyTo(frame90)
            Case 91
                PictureBoxIpl1.ImageIpl.CopyTo(frame91)
            Case 92
                PictureBoxIpl1.ImageIpl.CopyTo(frame92)
            Case 93
                PictureBoxIpl1.ImageIpl.CopyTo(frame93)
            Case 94
                PictureBoxIpl1.ImageIpl.CopyTo(frame94)
            Case 95
                PictureBoxIpl1.ImageIpl.CopyTo(frame95)
            Case 96
                PictureBoxIpl1.ImageIpl.CopyTo(frame96)
            Case 97
                PictureBoxIpl1.ImageIpl.CopyTo(frame97)
            Case 98
                PictureBoxIpl1.ImageIpl.CopyTo(frame98)
            Case 99
                PictureBoxIpl1.ImageIpl.CopyTo(frame99)
            Case 100
                PictureBoxIpl1.ImageIpl.CopyTo(frame100)
            Case 101
                PictureBoxIpl1.ImageIpl.CopyTo(frame101)
            Case 102
                PictureBoxIpl1.ImageIpl.CopyTo(frame102)
            Case 103
                PictureBoxIpl1.ImageIpl.CopyTo(frame103)
            Case 104
                PictureBoxIpl1.ImageIpl.CopyTo(frame104)
            Case 105
                PictureBoxIpl1.ImageIpl.CopyTo(frame105)
            Case 106
                PictureBoxIpl1.ImageIpl.CopyTo(frame106)
            Case 107
                PictureBoxIpl1.ImageIpl.CopyTo(frame107)
            Case 108
                PictureBoxIpl1.ImageIpl.CopyTo(frame108)
            Case 109
                PictureBoxIpl1.ImageIpl.CopyTo(frame109)
            Case 110
                PictureBoxIpl1.ImageIpl.CopyTo(frame110)
            Case 111
                PictureBoxIpl1.ImageIpl.CopyTo(frame111)
            Case 112
                PictureBoxIpl1.ImageIpl.CopyTo(frame112)
            Case 113
                PictureBoxIpl1.ImageIpl.CopyTo(frame113)
            Case 114
                PictureBoxIpl1.ImageIpl.CopyTo(frame114)
            Case 115
                PictureBoxIpl1.ImageIpl.CopyTo(frame115)
            Case 116
                PictureBoxIpl1.ImageIpl.CopyTo(frame116)
            Case 117
                PictureBoxIpl1.ImageIpl.CopyTo(frame117)
            Case 118
                PictureBoxIpl1.ImageIpl.CopyTo(frame118)
            Case 119
                PictureBoxIpl1.ImageIpl.CopyTo(frame119)
            Case 120
                PictureBoxIpl1.ImageIpl.CopyTo(frame120)
            Case 121
                PictureBoxIpl1.ImageIpl.CopyTo(frame121)
            Case 122
                PictureBoxIpl1.ImageIpl.CopyTo(frame122)
            Case 123
                PictureBoxIpl1.ImageIpl.CopyTo(frame123)
            Case 124
                PictureBoxIpl1.ImageIpl.CopyTo(frame124)
            Case 125
                PictureBoxIpl1.ImageIpl.CopyTo(frame125)
            Case 126
                PictureBoxIpl1.ImageIpl.CopyTo(frame126)
            Case 127
                PictureBoxIpl1.ImageIpl.CopyTo(frame127)
            Case 128
                PictureBoxIpl1.ImageIpl.CopyTo(frame128)
            Case 129
                PictureBoxIpl1.ImageIpl.CopyTo(frame129)
            Case 130
                PictureBoxIpl1.ImageIpl.CopyTo(frame130)
            Case 131
                PictureBoxIpl1.ImageIpl.CopyTo(frame131)
            Case 132
                PictureBoxIpl1.ImageIpl.CopyTo(frame132)
            Case 133
                PictureBoxIpl1.ImageIpl.CopyTo(frame133)
            Case 134
                PictureBoxIpl1.ImageIpl.CopyTo(frame134)
            Case 135
                PictureBoxIpl1.ImageIpl.CopyTo(frame135)
            Case 136
                PictureBoxIpl1.ImageIpl.CopyTo(frame136)
            Case 137
                PictureBoxIpl1.ImageIpl.CopyTo(frame137)
            Case 138
                PictureBoxIpl1.ImageIpl.CopyTo(frame138)
            Case 139
                PictureBoxIpl1.ImageIpl.CopyTo(frame139)
            Case 140
                PictureBoxIpl1.ImageIpl.CopyTo(frame140)
            Case 141
                PictureBoxIpl1.ImageIpl.CopyTo(frame141)
            Case 142
                PictureBoxIpl1.ImageIpl.CopyTo(frame142)
            Case 143
                PictureBoxIpl1.ImageIpl.CopyTo(frame143)
            Case 144
                PictureBoxIpl1.ImageIpl.CopyTo(frame144)
            Case 145
                PictureBoxIpl1.ImageIpl.CopyTo(frame145)
            Case 146
                PictureBoxIpl1.ImageIpl.CopyTo(frame146)
            Case 147
                PictureBoxIpl1.ImageIpl.CopyTo(frame147)
            Case 148
                PictureBoxIpl1.ImageIpl.CopyTo(frame148)
            Case 149
                PictureBoxIpl1.ImageIpl.CopyTo(frame149)
            Case 150
                PictureBoxIpl1.ImageIpl.CopyTo(frame150)
            Case 151
                PictureBoxIpl1.ImageIpl.CopyTo(frame151)
            Case 152
                PictureBoxIpl1.ImageIpl.CopyTo(frame152)
            Case 153
                PictureBoxIpl1.ImageIpl.CopyTo(frame153)
            Case 154
                PictureBoxIpl1.ImageIpl.CopyTo(frame154)
            Case 155
                PictureBoxIpl1.ImageIpl.CopyTo(frame155)
            Case 156
                PictureBoxIpl1.ImageIpl.CopyTo(frame156)
            Case 157
                PictureBoxIpl1.ImageIpl.CopyTo(frame157)
            Case 158
                PictureBoxIpl1.ImageIpl.CopyTo(frame158)
            Case 159
                PictureBoxIpl1.ImageIpl.CopyTo(frame159)
            Case 160
                PictureBoxIpl1.ImageIpl.CopyTo(frame160)
            Case 161
                PictureBoxIpl1.ImageIpl.CopyTo(frame161)
            Case 162
                PictureBoxIpl1.ImageIpl.CopyTo(frame162)
            Case 163
                PictureBoxIpl1.ImageIpl.CopyTo(frame163)
            Case 164
                PictureBoxIpl1.ImageIpl.CopyTo(frame164)
            Case 165
                PictureBoxIpl1.ImageIpl.CopyTo(frame165)
            Case 166
                PictureBoxIpl1.ImageIpl.CopyTo(frame166)
            Case 167
                PictureBoxIpl1.ImageIpl.CopyTo(frame167)
            Case 168
                PictureBoxIpl1.ImageIpl.CopyTo(frame168)
            Case 169
                PictureBoxIpl1.ImageIpl.CopyTo(frame169)
            Case 170
                PictureBoxIpl1.ImageIpl.CopyTo(frame170)
            Case 171
                PictureBoxIpl1.ImageIpl.CopyTo(frame171)
            Case 172
                PictureBoxIpl1.ImageIpl.CopyTo(frame172)
            Case 173
                PictureBoxIpl1.ImageIpl.CopyTo(frame173)
            Case 174
                PictureBoxIpl1.ImageIpl.CopyTo(frame174)
            Case 175
                PictureBoxIpl1.ImageIpl.CopyTo(frame175)
            Case 176
                PictureBoxIpl1.ImageIpl.CopyTo(frame176)
            Case 177
                PictureBoxIpl1.ImageIpl.CopyTo(frame177)
            Case 178
                PictureBoxIpl1.ImageIpl.CopyTo(frame178)
            Case 179
                PictureBoxIpl1.ImageIpl.CopyTo(frame179)
            Case 180
                PictureBoxIpl1.ImageIpl.CopyTo(frame180)
            Case 181
                PictureBoxIpl1.ImageIpl.CopyTo(frame181)
            Case 182
                PictureBoxIpl1.ImageIpl.CopyTo(frame182)
            Case 183
                PictureBoxIpl1.ImageIpl.CopyTo(frame183)
            Case 184
                PictureBoxIpl1.ImageIpl.CopyTo(frame184)
            Case 185
                PictureBoxIpl1.ImageIpl.CopyTo(frame185)
            Case 186
                PictureBoxIpl1.ImageIpl.CopyTo(frame186)
            Case 187
                PictureBoxIpl1.ImageIpl.CopyTo(frame187)
            Case 188
                PictureBoxIpl1.ImageIpl.CopyTo(frame188)
            Case 189
                PictureBoxIpl1.ImageIpl.CopyTo(frame189)
            Case 190
                PictureBoxIpl1.ImageIpl.CopyTo(frame190)
            Case 191
                PictureBoxIpl1.ImageIpl.CopyTo(frame191)
            Case 192
                PictureBoxIpl1.ImageIpl.CopyTo(frame192)
            Case 193
                PictureBoxIpl1.ImageIpl.CopyTo(frame193)
            Case 194
                PictureBoxIpl1.ImageIpl.CopyTo(frame194)
            Case 195
                PictureBoxIpl1.ImageIpl.CopyTo(frame195)
            Case 196
                PictureBoxIpl1.ImageIpl.CopyTo(frame196)
            Case 197
                PictureBoxIpl1.ImageIpl.CopyTo(frame197)
            Case 198
                PictureBoxIpl1.ImageIpl.CopyTo(frame198)
            Case 199
                PictureBoxIpl1.ImageIpl.CopyTo(frame199)
            Case 200
                PictureBoxIpl1.ImageIpl.CopyTo(frame200)
            Case 201
                PictureBoxIpl1.ImageIpl.CopyTo(frame201)
            Case 202
                PictureBoxIpl1.ImageIpl.CopyTo(frame202)
            Case 203
                PictureBoxIpl1.ImageIpl.CopyTo(frame203)
            Case 204
                PictureBoxIpl1.ImageIpl.CopyTo(frame204)
            Case 205
                PictureBoxIpl1.ImageIpl.CopyTo(frame205)
            Case 206
                PictureBoxIpl1.ImageIpl.CopyTo(frame206)
            Case 207
                PictureBoxIpl1.ImageIpl.CopyTo(frame207)
            Case 208
                PictureBoxIpl1.ImageIpl.CopyTo(frame208)
            Case 209
                PictureBoxIpl1.ImageIpl.CopyTo(frame209)
            Case 210
                PictureBoxIpl1.ImageIpl.CopyTo(frame210)
            Case 211
                PictureBoxIpl1.ImageIpl.CopyTo(frame211)
            Case 212
                PictureBoxIpl1.ImageIpl.CopyTo(frame212)
            Case 213
                PictureBoxIpl1.ImageIpl.CopyTo(frame213)
            Case 214
                PictureBoxIpl1.ImageIpl.CopyTo(frame214)
            Case 215
                PictureBoxIpl1.ImageIpl.CopyTo(frame215)
            Case 216
                PictureBoxIpl1.ImageIpl.CopyTo(frame216)
            Case 217
                PictureBoxIpl1.ImageIpl.CopyTo(frame217)
            Case 218
                PictureBoxIpl1.ImageIpl.CopyTo(frame218)
            Case 219
                PictureBoxIpl1.ImageIpl.CopyTo(frame219)
            Case 220
                PictureBoxIpl1.ImageIpl.CopyTo(frame220)
            Case 221
                PictureBoxIpl1.ImageIpl.CopyTo(frame221)
            Case 222
                PictureBoxIpl1.ImageIpl.CopyTo(frame222)
            Case 223
                PictureBoxIpl1.ImageIpl.CopyTo(frame223)
            Case 224
                PictureBoxIpl1.ImageIpl.CopyTo(frame224)
            Case 225
                PictureBoxIpl1.ImageIpl.CopyTo(frame225)
            Case 226
                PictureBoxIpl1.ImageIpl.CopyTo(frame226)
            Case 227
                PictureBoxIpl1.ImageIpl.CopyTo(frame227)
            Case 228
                PictureBoxIpl1.ImageIpl.CopyTo(frame228)
            Case 229
                PictureBoxIpl1.ImageIpl.CopyTo(frame229)
            Case 230
                PictureBoxIpl1.ImageIpl.CopyTo(frame230)
            Case 231
                PictureBoxIpl1.ImageIpl.CopyTo(frame231)
            Case 232
                PictureBoxIpl1.ImageIpl.CopyTo(frame232)
            Case 233
                PictureBoxIpl1.ImageIpl.CopyTo(frame233)
            Case 234
                PictureBoxIpl1.ImageIpl.CopyTo(frame234)
            Case 235
                PictureBoxIpl1.ImageIpl.CopyTo(frame235)
            Case 236
                PictureBoxIpl1.ImageIpl.CopyTo(frame236)
            Case 237
                PictureBoxIpl1.ImageIpl.CopyTo(frame237)
            Case 238
                PictureBoxIpl1.ImageIpl.CopyTo(frame238)
            Case 239
                PictureBoxIpl1.ImageIpl.CopyTo(frame239)
            Case 240
                PictureBoxIpl1.ImageIpl.CopyTo(frame240)
            Case 241
                PictureBoxIpl1.ImageIpl.CopyTo(frame241)
            Case 242
                PictureBoxIpl1.ImageIpl.CopyTo(frame242)
            Case 243
                PictureBoxIpl1.ImageIpl.CopyTo(frame243)
            Case 244
                PictureBoxIpl1.ImageIpl.CopyTo(frame244)
            Case 245
                PictureBoxIpl1.ImageIpl.CopyTo(frame245)
            Case 246
                PictureBoxIpl1.ImageIpl.CopyTo(frame246)
            Case 247
                PictureBoxIpl1.ImageIpl.CopyTo(frame247)
            Case 248
                PictureBoxIpl1.ImageIpl.CopyTo(frame248)
            Case 249
                PictureBoxIpl1.ImageIpl.CopyTo(frame249)
            Case 250
                PictureBoxIpl1.ImageIpl.CopyTo(frame250)
            Case 251
                PictureBoxIpl1.ImageIpl.CopyTo(frame251)
            Case 252
                PictureBoxIpl1.ImageIpl.CopyTo(frame252)
            Case 253
                PictureBoxIpl1.ImageIpl.CopyTo(frame253)
            Case 254
                PictureBoxIpl1.ImageIpl.CopyTo(frame254)
            Case 255
                PictureBoxIpl1.ImageIpl.CopyTo(frame255)
            Case 256
                PictureBoxIpl1.ImageIpl.CopyTo(frame256)
            Case 257
                PictureBoxIpl1.ImageIpl.CopyTo(frame257)
            Case 258
                PictureBoxIpl1.ImageIpl.CopyTo(frame258)
            Case 259
                PictureBoxIpl1.ImageIpl.CopyTo(frame259)
            Case 260
                PictureBoxIpl1.ImageIpl.CopyTo(frame260)
            Case 261
                PictureBoxIpl1.ImageIpl.CopyTo(frame261)
            Case 262
                PictureBoxIpl1.ImageIpl.CopyTo(frame262)
            Case 263
                PictureBoxIpl1.ImageIpl.CopyTo(frame263)
            Case 264
                PictureBoxIpl1.ImageIpl.CopyTo(frame264)
            Case 265
                PictureBoxIpl1.ImageIpl.CopyTo(frame265)
            Case 266
                PictureBoxIpl1.ImageIpl.CopyTo(frame266)
            Case 267
                PictureBoxIpl1.ImageIpl.CopyTo(frame267)
            Case 268
                PictureBoxIpl1.ImageIpl.CopyTo(frame268)
            Case 269
                PictureBoxIpl1.ImageIpl.CopyTo(frame269)
            Case 270
                PictureBoxIpl1.ImageIpl.CopyTo(frame270)
            Case 271
                PictureBoxIpl1.ImageIpl.CopyTo(frame271)
            Case 272
                PictureBoxIpl1.ImageIpl.CopyTo(frame272)
            Case 273
                PictureBoxIpl1.ImageIpl.CopyTo(frame273)
            Case 274
                PictureBoxIpl1.ImageIpl.CopyTo(frame274)
            Case 275
                PictureBoxIpl1.ImageIpl.CopyTo(frame275)
            Case 276
                PictureBoxIpl1.ImageIpl.CopyTo(frame276)
            Case 277
                PictureBoxIpl1.ImageIpl.CopyTo(frame277)
            Case 278
                PictureBoxIpl1.ImageIpl.CopyTo(frame278)
            Case 279
                PictureBoxIpl1.ImageIpl.CopyTo(frame279)
            Case 280
                PictureBoxIpl1.ImageIpl.CopyTo(frame280)
            Case 281
                PictureBoxIpl1.ImageIpl.CopyTo(frame281)
            Case 282
                PictureBoxIpl1.ImageIpl.CopyTo(frame282)
            Case 283
                PictureBoxIpl1.ImageIpl.CopyTo(frame283)
            Case 284
                PictureBoxIpl1.ImageIpl.CopyTo(frame284)
            Case 285
                PictureBoxIpl1.ImageIpl.CopyTo(frame285)
            Case 286
                PictureBoxIpl1.ImageIpl.CopyTo(frame286)
            Case 287
                PictureBoxIpl1.ImageIpl.CopyTo(frame287)
            Case 288
                PictureBoxIpl1.ImageIpl.CopyTo(frame288)
            Case 289
                PictureBoxIpl1.ImageIpl.CopyTo(frame289)
            Case 290
                PictureBoxIpl1.ImageIpl.CopyTo(frame290)
            Case 291
                PictureBoxIpl1.ImageIpl.CopyTo(frame291)
            Case 292
                PictureBoxIpl1.ImageIpl.CopyTo(frame292)
            Case 293
                PictureBoxIpl1.ImageIpl.CopyTo(frame293)
            Case 294
                PictureBoxIpl1.ImageIpl.CopyTo(frame294)
            Case 295
                PictureBoxIpl1.ImageIpl.CopyTo(frame295)
            Case 296
                PictureBoxIpl1.ImageIpl.CopyTo(frame296)
            Case 297
                PictureBoxIpl1.ImageIpl.CopyTo(frame297)
            Case 298
                PictureBoxIpl1.ImageIpl.CopyTo(frame298)
            Case 299
                PictureBoxIpl1.ImageIpl.CopyTo(frame299)
            Case 300
                PictureBoxIpl1.ImageIpl.CopyTo(frame300)

        End Select


        If tempnumber < 300 Then
            tempnumber += 1

        ElseIf tempnumber >= 300 Then
            tempnumber = 0


        End If


    End Sub


    Private Sub btnview_close_Click(sender As Object, e As EventArgs) Handles btnview_close.Click

        Me.Size = New Drawing.Size(800 * Dpi_rate， 600 * Dpi_rate)

        btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
        btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)
        btnview_close.Location = New Drawing.Point(1500 * Dpi_rate, 0)

        pnlview_window.Location = New Drawing.Point(1500 * Dpi_rate, lbltitlebar.Height * Dpi_rate) 'lbltitlebar.Height

        pnlview_control.Location = New Drawing.Point(1500 * Dpi_rate, lbltitlebar.Height * Dpi_rate)

        MenuStrip1.Visible = True

        DGtable.Location = New Drawing.Point(7 * Dpi_rate, 71 * Dpi_rate)
        DGtable.Size = New Drawing.Size(785 * Dpi_rate, 146 * Dpi_rate)
        txtrowscount.Location = New Drawing.Point(7 * Dpi_rate, 70 * Dpi_rate)


        grpgeneral.Visible = True

        btnclose_general.Visible = True
        listsetcontents.Visible = True
        btndescription_table.Visible = True

        'Trueにしてよいのか？
        btnstartopencv.Enabled = True

        If btntemp.BackColor = Color.Maroon Then
            btntemp.PerformClick()

        End If

        'cvpreview.Stop()
        Capture_TF = 1

        cvpreview_replay.Stop()
        cvpreview_zoom.Stop()

        lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " AutoSplit Helper by Image " & lblversion.Text


    End Sub




    '■キャリブレーションウィンドウ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
#Region "キャリブレーション"
    '■キャリブレーションウィンドウを表示
    Private Sub ShowCalibration()

        TabControl1.SelectedIndex = 3
        Calibration_intialize()


    End Sub

    Private Sub Calibration_intialize()

        lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " Calibration"

        piccamera.Location = New Drawing.Point(27 * Dpi_rate, 110 * Dpi_rate)
        piccamera.Size = New Drawing.Size(numcv_sizex.Value, numcv_sizey.Value)

        gbcalib_m1.Location = New Drawing.Point(piccamera.Location.X * Dpi_rate, (piccamera.Location.Y + (numcv_sizey.Value * Dpi_rate) + 5))
        gbsetting.Location = New Drawing.Point((piccamera.Location.X + numcv_sizex.Value + 30) * Dpi_rate, (piccamera.Location.Y - btncalib_cap.Height - 11))

        btncalib_cap.Location = New Drawing.Point(piccamera.Location.X, (piccamera.Location.Y - btncalib_cap.Height - 3))
        btncalib_resize.Location = New Drawing.Point(piccamera.Location.X * Dpi_rate, gbcalib_m1.Location.Y + gbcalib_m1.Height + 5)


        Me.Size = New Drawing.Point(gbsetting.Location.X + gbsetting.Width + (50 * Dpi_rate),
                                    (gbcalib_m1.Location.Y + gbcalib_m1.Height + (90 * Dpi_rate)))




        timcamera.Enabled = True

        piccalib_comp.AllowDrop = True

        btncalib_resize.Enabled = False
        btnpreview.Enabled = False
        txtpass_picturefolder.Text = "./profile/" & cmbprofile.SelectedItem & "/picture" 'Mainwindow.txtpass_picturefolder.Text


        '■ファイルが存在しているかどうか確認する
        Dim di As New System.IO.DirectoryInfo(txtpass_picturefolder.Text) '(fbd.SelectedPath)
        Dim files As System.IO.FileInfo() =
            di.GetFiles("*.bmp", System.IO.SearchOption.TopDirectoryOnly)

        '■ListBox1に結果を表示する
        listcalib_1.Items.Clear()
        listcalib_2.Items.Clear()

        For Each f As System.IO.FileInfo In files
            listcalib_1.Items.Add(f.FullName)
            listcalib_2.Items.Add(System.IO.Path.GetFileNameWithoutExtension(f.FullName))

        Next

        txtcalib_numbers.Text = listcalib_1.Items.Count
        btnpreview.Enabled = True

        If listcalib_1.Items.Count = 0 Then
            MessageBox.Show(txtpass_picturefolder.Text & My.Resources.Message.msga1, messagebox_name) '"内に画像が存在しません。"

            Me.Close()
            Exit Sub


        End If

        listcalib_1.SelectedIndex = 0

        btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
        btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)

        txtcalib_save_scale.Text = 100
        txtcalib_save_scalewidth.Text = 100
        txtcalib_save_scaleheight.Text = 100
        txtcalib_save_bright.Text = 0
        txtcalib_save_r.Text = 0
        txtcalib_save_g.Text = 0
        txtcalib_save_b.Text = 0


    End Sub

    Private Sub timcamera_Tick(sender As Object, e As EventArgs) Handles timcamera.Tick

        capturecv.Read(frame)

        If chkcv_crop.Checked = True Then

            '■先にクロップをする。
            dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

            Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

            dst_cropRect.CopyTo(dst_cropped)

            '■リサイズ
            dst_resize = New Mat()
            Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

            piccamera.ImageIpl = dst_resize

            dst_cropRect.Dispose()
            dst_cropped.Dispose()
            'dst_resize.Dispose()


        ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

            If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                piccamera.ImageIpl = frame


            Else

                dst_resize = New Mat()
                Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                piccamera.ImageIpl = dst_resize

                'dst_resize.Dispose()


            End If

        End If





    End Sub


    'アスペクト比。    
    Private Sub rdocalib_aspect_none_CheckedChanged(sender As Object, e As EventArgs) Handles rdocalib_aspect_none.CheckedChanged

        numcalib_hand_scalewidth.Value = 100
        numcalib_hand_scaleheight.Value = 100

    End Sub

    Private Sub rdocalib_aspect_to169_CheckedChanged(sender As Object, e As EventArgs) Handles rdocalib_aspect_to169.CheckedChanged

        numcalib_hand_scalewidth.Value = 100 * (16 / 12)
        numcalib_hand_scaleheight.Value = 100

    End Sub

    Private Sub rdocalib_aspect_to43_CheckedChanged(sender As Object, e As EventArgs) Handles rdocalib_aspect_to43.CheckedChanged

        numcalib_hand_scalewidth.Value = 100 * (12 / 16)
        numcalib_hand_scaleheight.Value = 100

    End Sub


    Private Sub btncalib_cap_Click(sender As Object, e As EventArgs) Handles btncalib_cap.Click

        piccalib_temp.Visible = True
        piccalib_temp.Size = New Drawing.Size(numcv_sizex.Value, numcv_sizey.Value)

        capturecv.Read(frame)

        If chkcv_crop.Checked = True Then

            '■先にクロップをする。
            dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

            Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

            dst_cropRect.CopyTo(dst_cropped)

            '■リサイズ
            dst_resize = New Mat()
            Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

            piccalib_temp.ImageIpl = dst_resize

            dst_cropRect.Dispose()
            dst_cropped.Dispose()
            'dst_resize.Dispose()


        ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

            If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                piccalib_temp.ImageIpl = frame


            Else

                dst_resize = New Mat()
                Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                piccalib_temp.ImageIpl = dst_resize

                'dst_resize.Dispose()


            End If

        End If



        Application.DoEvents()

        capturecv.Read(frame)

        If chkcv_crop.Checked = True Then

            '■先にクロップをする。
            dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

            Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

            dst_cropRect.CopyTo(dst_cropped)

            '■リサイズ
            dst_resize = New Mat()
            Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

            piccalib_temp.ImageIpl = dst_resize

            dst_cropRect.Dispose()
            dst_cropped.Dispose()
            'dst_resize.Dispose()


        ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

            If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                piccalib_temp.ImageIpl = frame


            Else

                dst_resize = New Mat()
                Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                piccalib_temp.ImageIpl = dst_resize

                'dst_resize.Dispose()


            End If

        End If


        chkcalib_1.Checked = True

        txtcalib_max.Text = 0

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then
            gbsetting.Enabled = True
            timcalib.Enabled = True
            timcamera.Enabled = False

            btncalib_resize.Enabled = True


        End If


    End Sub



    '■txtsaveの内容を基に初期の画像を調整し、best.bmpとして保存。
    Sub best()

        Dim pass As String = txtcalib_compfilename.Text
        Dim image = New Bitmap(pass)

        ' 画像の幅と高さの取得その２
        Dim imagew, imageh As Integer
        Dim fs As System.IO.FileStream

        ' Specify a valid picture file path on your computer.
        fs = New System.IO.FileStream(pass, IO.FileMode.Open, IO.FileAccess.Read)
        imagew = System.Drawing.Image.FromStream(fs).Width
        imageh = System.Drawing.Image.FromStream(fs).Height

        fs.Close()


        Dim wid As Integer = CInt(imagew * (0.01 * txtcalib_save_scalewidth.Text) * ((txtcalib_save_scale.Text) / 100)) 'numwidth.Value
        Dim hei As Integer = CInt(imageh * (0.01 * txtcalib_save_scaleheight.Text) * ((txtcalib_save_scale.Text) / 100)) 'numheight.Value

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(wid, hei)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)


        '補間方法を指定して画像を縮小して描画する
        '補間方法として高品質双三次補間を指定する
        g.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        '画像を縮小して描画する
        g.DrawImage(image, 0, 0, wid, hei)

        'BitmapとGraphicsオブジェクトを破棄
        image.Dispose()
        g.Dispose()


        'カラーバランスの調整
        AdjustColorImage(canvas, txtcalib_save_r.Text, txtcalib_save_g.Text, txtcalib_save_b.Text)
        ''PictureBox1に表示
        'If Not picresult.Image Is Nothing Then
        '    picresult.Image.Dispose()
        'End If
        'picresize.Image = img

        'Application.DoEvents()

        piccalib_bestresult.Image = canvas

        piccalib_bestresult.Image.Save("./temp/temp2/best.bmp", ImageFormat.Bmp)


    End Sub


    Private Sub btncalscale_Click(sender As Object, e As EventArgs) Handles btncalib_adjscale.Click

        Try

            gbrgb.Enabled = True

            txtcalib_scaleorcolor.Text = 0

            txtcalib_count.Text = 0

            Dim scalev_min As Integer = -20
            Dim scalev_max As Integer = 20


            pgbcalib_1.Minimum = 0
            pgbcalib_1.Maximum = scalev_max - scalev_min
            pgbcalib_1.Value = 0


            numcalib_scale.Value -= 0.1 * scalev_max

            For scalev = scalev_min To scalev_max - 1

                Dim pass As String = txtcalib_compfilename.Text
                Dim image = New Bitmap(pass)

                ' 画像の幅と高さの取得その２
                Dim imagew, imageh As Integer
                Dim fs As System.IO.FileStream
                ' Specify a valid picture file path on your computer.
                fs = New System.IO.FileStream(pass, IO.FileMode.Open, IO.FileAccess.Read)
                imagew = System.Drawing.Image.FromStream(fs).Width
                imageh = System.Drawing.Image.FromStream(fs).Height

                fs.Close()

                Dim wid As Integer = CInt(imagew * (0.01 * numcalib_scalewidth.Value) * (CInt(numcalib_scale.Value) / 100)) 'numwidth.Value
                Dim hei As Integer = CInt(imageh * (0.01 * numcalib_scaleheight.Value) * (CInt(numcalib_scale.Value) / 100)) 'numheight.Value

                '描画先とするImageオブジェクトを作成する
                Dim canvas As New Bitmap(wid, hei)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Dim g As Graphics = Graphics.FromImage(canvas)


                '補間方法を指定して画像を縮小して描画する
                '補間方法として高品質双三次補間を指定する
                g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                '画像を縮小して描画する
                g.DrawImage(image, 0, 0, wid, hei)



                'BitmapとGraphicsオブジェクトを破棄
                image.Dispose()
                g.Dispose()


                'PictureBox1に表示する
                piccalib_handresult.Image = canvas
                piccalib_handresult.Image.Save("./temp/temp1/" & txtcalib_count.Text & ".bmp", ImageFormat.Bmp)

                numcalib_scale.Value += 0.1

                'Application.DoEvents()

                calib()


                txtcalib_count.Text += 1
                pgbcalib_1.Value = CInt(txtcalib_count.Text)
                Application.DoEvents()

            Next

            txtsave_to_num()
            '現時点で最も良いパラメーターの画像を作成する。
            best()


        Catch ex As Exception
            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try


    End Sub

    Private Sub btncalaspect_Click(sender As Object, e As EventArgs) Handles btncalib_adjaspect.Click

        gbrgb.Enabled = True

        txtcalib_scaleorcolor.Text = 0

        txtcalib_count.Text = 0

        Dim aspect_min As Integer = -10
        Dim aspect_max As Integer = 9

        Dim save_aspectheight As Decimal = numcalib_scaleheight.Value

        pgbcalib_1.Minimum = 0
        pgbcalib_1.Maximum = (aspect_max - aspect_min) ^ 2
        pgbcalib_1.Value = 0

        numcalib_scalewidth.Value -= 0.1 * aspect_max
        numcalib_scaleheight.Value -= 0.1 * aspect_max

        For aspectw = aspect_min To aspect_max - 1

            For aspecth = aspect_min To aspect_max - 1
                Dim pass As String = txtcalib_compfilename.Text
                Dim image = New Bitmap(pass)

                ' 画像の幅と高さの取得その２
                Dim imagew, imageh As Integer
                Dim fs As System.IO.FileStream
                ' Specify a valid picture file path on your computer.
                fs = New System.IO.FileStream(pass, IO.FileMode.Open, IO.FileAccess.Read)
                imagew = System.Drawing.Image.FromStream(fs).Width
                imageh = System.Drawing.Image.FromStream(fs).Height

                fs.Close()

                Dim wid As Integer = CInt(imagew * ((0.01 * numcalib_scalewidth.Value) + (0.01 * aspectw)) * (CInt(numcalib_scale.Value) / 100)) 'numwidth.Value
                Dim hei As Integer = CInt(imageh * ((0.01 * numcalib_scaleheight.Value) + (0.01 * aspecth)) * (CInt(numcalib_scale.Value) / 100)) 'numheight.Value

                '描画先とするImageオブジェクトを作成する
                Dim canvas As New Bitmap(wid, hei)
                'ImageオブジェクトのGraphicsオブジェクトを作成する
                Dim g As Graphics = Graphics.FromImage(canvas)


                '補間方法を指定して画像を縮小して描画する
                '補間方法として高品質双三次補間を指定する
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
                '画像を縮小して描画する
                g.DrawImage(image, 0, 0, wid, hei)

                'BitmapとGraphicsオブジェクトを破棄
                image.Dispose()
                g.Dispose()


                'PictureBox1に表示する
                piccalib_handresult.Image = canvas
                piccalib_handresult.Image.Save("./temp/temp1/" & txtcalib_count.Text & ".bmp", ImageFormat.Bmp)

                numcalib_scaleheight.Value += 0.1

                calib()

                txtcalib_count.Text += 1
                pgbcalib_1.Value = CInt(txtcalib_count.Text)

                Application.DoEvents()


            Next

            numcalib_scaleheight.Value = save_aspectheight
            numcalib_scalewidth.Value += 0.1

        Next

        txtsave_to_num()
        '現時点で最も良いパラメーターの画像を作成する。
        best()


    End Sub


    Private Sub btncalbright_Click(sender As Object, e As EventArgs) Handles btncalib_adjbright.Click

        txtcalib_scaleorcolor.Text = 1

        txtcalib_count.Text = 0

        Dim bright_min As Integer = -40
        Dim bright_max As Integer = 40

        If numcalib_hand_bright.Value + bright_min <= -256 Then

            MessageBox.Show(My.Resources.Message.msga2, messagebox_name) '"範囲外の値を指定しようとしました。値を-215以上にして下さい。"
            Exit Sub


        End If

        pgbcalib_1.Minimum = 0
        pgbcalib_1.Maximum = bright_max - bright_min
        pgbcalib_1.Value = 0

        numcalib_bright.Value -= bright_max

        For bright = bright_min To bright_max - 1

            Dim brightness As Integer = numcalib_bright.Value + bright

            '色補正をする画像
            Dim img As New Bitmap("./temp/temp2/best.bmp")
            '赤を128増加させる
            AdjustColorImage(img, brightness, brightness, brightness)
            'PictureBox1に表示
            If Not piccalib_bestresult.Image Is Nothing Then
                piccalib_bestresult.Image.Dispose()


            End If

            piccalib_handresult.Image = img
            piccalib_handresult.Image.Save("./temp/temp1/" & txtcalib_count.Text & ".bmp", ImageFormat.Bmp)

            Application.DoEvents()

            calib()

            numcalib_bright.Value += 1

            txtcalib_count.Text += 1
            pgbcalib_1.Value = CInt(txtcalib_count.Text)
            Application.DoEvents()

            img.Dispose()

        Next

        txtsave_to_num()

        '現時点で最も良いパラメーターの画像を作成する。
        best()


    End Sub

    Private Sub btncalrgb_Click(sender As Object, e As EventArgs) Handles btncalib_adjrgb.Click

        txtcalib_scaleorcolor.Text = 1

        txtcalib_count.Text = 0

        Dim rgb_min As Integer = -5
        Dim rgb_max As Integer = 4


        If numcalib_hand_r.Value + rgb_min <= -256 Or numcalib_hand_g.Value + rgb_min <= -256 Or numcalib_hand_b.Value + rgb_min <= -256 Then
            MessageBox.Show(My.Resources.Message.msga3, messagebox_name) '"範囲外の値を指定しようとしました。値を-250以上にして下さい。"
            Exit Sub
        End If

        Dim save_g As Integer = numcalib_g.Value
        Dim save_b As Integer = numcalib_b.Value

        pgbcalib_1.Minimum = 0
        pgbcalib_1.Maximum = (rgb_max - rgb_min) ^ 3
        pgbcalib_1.Value = 0

        numcalib_r.Value -= rgb_max
        numcalib_g.Value -= rgb_max
        numcalib_b.Value -= rgb_max



        For rr = rgb_min To rgb_max - 1
            For gg = rgb_min To rgb_max - 1
                For bb = rgb_min To rgb_max - 1

                    Dim valR As Integer = numcalib_r.Value + rr
                    Dim valG As Integer = numcalib_g.Value + gg
                    Dim valB As Integer = numcalib_b.Value + bb
                    '色補正をする画像
                    Dim img As New Bitmap("./temp/temp2/best.bmp")
                    '赤を128増加させる
                    AdjustColorImage(img, valR, valG, valB)
                    'PictureBox1に表示
                    If Not piccalib_bestresult.Image Is Nothing Then
                        piccalib_bestresult.Image.Dispose()


                    End If

                    piccalib_handresult.Image = img
                    piccalib_handresult.Image.Save("./temp/temp1/" & txtcalib_count.Text & ".bmp", ImageFormat.Bmp)
                    Application.DoEvents()

                    calib()

                    Application.DoEvents()

                    numcalib_b.Value += 1

                    txtcalib_count.Text += 1
                    pgbcalib_1.Value = CInt(txtcalib_count.Text)

                    img.Dispose()


                Next

                numcalib_b.Value = save_b
                numcalib_g.Value += 1


            Next

            numcalib_g.Value = save_g
            numcalib_r.Value += 1


        Next


        txtsave_to_num()
        '現時点で最も良いパラメーターの画像を作成する。
        best()


    End Sub

    ''' <summary>
    ''' 指定した画像の色を補正する
    ''' </summary>
    ''' <param name="img">補正する画像</param>
    ''' <param name="rValue">赤の増加値（-255～255）</param>
    ''' <param name="gValue">緑の増加値（-255～255）</param>
    ''' <param name="bValue">青の増加値（-255～255）</param>
    Public Shared Sub AdjustColorImage(ByVal img As Bitmap, ByVal rValue As Integer, ByVal gValue As Integer, ByVal bValue As Integer)
        '1ピクセルあたりのバイト数を取得する
        Dim pixelFormat As PixelFormat = img.PixelFormat
        Dim pixelSize As Integer = Image.GetPixelFormatSize(pixelFormat) / 8

        If pixelSize < 3 OrElse 4 < pixelSize Then
            Throw New ArgumentException(
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。",
                "img")
        End If

        'または次のように元の画像とは異なるPixelFormatでLockBitsすることも可能
        'この場合、UnlockBitsで元のPixelFormatに戻る
        'ただし、元のPixelFormatとLockBits時のPixelFormatが異なる場合は、
        '変更した色とは異なる色になる可能性がある
        'pixelFormat = PixelFormat.Format32bppArgb
        'pixelSize = 4

        'Bitmapをロックする
        Dim bmpDate As BitmapData =
            img.LockBits(New Rectangle(0, 0, img.Width, img.Height),
                         ImageLockMode.ReadWrite, img.PixelFormat)

        If bmpDate.Stride < 0 Then
            img.UnlockBits(bmpDate)
            Throw New ArgumentException(
                "ボトムアップ形式のイメージには対応していません。",
                "img")
        End If

        'ピクセルデータをバイト型配列で取得する
        Dim ptr As IntPtr = bmpDate.Scan0
        Dim pixels As Byte() = New Byte(bmpDate.Stride * img.Height - 1) {}
        System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length)

        'すべてのピクセルの色を補正する
        For y As Integer = 0 To bmpDate.Height - 1
            For x As Integer = 0 To bmpDate.Width - 1
                'ピクセルデータでのピクセル(x,y)の開始位置を計算する
                Dim pos As Integer = y * bmpDate.Stride + x * pixelSize
                '新しい色を計算する
                Dim newR As Integer =
                    Math.Max(0, Math.Min(255, pixels(pos + 2) + rValue))
                Dim newG As Integer =
                    Math.Max(0, Math.Min(255, pixels(pos + 1) + gValue))
                Dim newB As Integer =
                    Math.Max(0, Math.Min(255, pixels(pos) + bValue))
                '色を変更する
                pixels(pos + 2) = CByte(newR)
                pixels(pos + 1) = CByte(newG)
                pixels(pos) = CByte(newB)

            Next

        Next

        'ピクセルデータを元に戻す
        System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length)

        'ロックを解除する
        img.UnlockBits(bmpDate)


    End Sub

    Private Sub timcalib_Tick(sender As Object, e As EventArgs) Handles timcalib.Tick

        Dim minloc As Point, maxloc As Point
        Dim minval As Double = 0, maxval As Double = 0

        'Try '画像サイズが映像キャプチャデバイスのサイズ以上だとエラー落ちする

        Dim aa As String = txtcalib_compfilename.Text

        Using tpl1 As Mat = Cv2.ImRead(aa, ImreadModes.Color)

            Dim img1 As Mat = piccalib_temp.ImageIpl
            Using res1 As New Mat(img1.Width - tpl1.Width + 1, img1.Height - tpl1.Height + 1, MatType.CV_32FC1)

                Cv2.MatchTemplate(img1, tpl1, res1, TemplateMatchModes.CCoeffNormed)
                Cv2.MinMaxLoc(res1, minval, maxval, minloc, maxloc, Nothing)

                'テンプレートマッチングの結果を表示
                txtcalib_nowvalue.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) '100 * maxval

                If CDbl(txtcalib_max.Text) < 100 * maxval Then
                    txtcalib_max.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) '100 * maxval
                    txtcalib_bestvalue.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) & "%"


                    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
                End If

            End Using

        End Using


    End Sub

    Sub calib()

        Dim minloc As Point, maxloc As Point
        Dim minval As Double = 0, maxval As Double = 0

        'Try '画像サイズが映像キャプチャデバイスのサイズ以上だとエラー落ちする

        Dim aa As String = "./temp/temp1/" & txtcalib_count.Text & ".bmp"

        Using tpl2 As Mat = Cv2.ImRead(aa, ImreadModes.Color)

            Dim img2 As Mat = piccalib_temp.ImageIpl

            Using res2 As New Mat(img2.Width - tpl2.Width + 1, img2.Height - tpl2.Height + 1, MatType.CV_32FC1)

                Cv2.MatchTemplate(img2, tpl2, res2, TemplateMatchModes.CCoeffNormed)
                Cv2.MinMaxLoc(res2, minval, maxval, minloc, maxloc, Nothing)


                'テンプレートマッチングの結果を表示
                txtcalib_nowvalue.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) '100 * maxval

                If CDbl(txtcalib_max.Text) < 100 * maxval Then
                    txtcalib_max.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) '100 * maxval
                    txtcalib_bestvalue.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) & "%"

                    txtcalib_save_scale.Text = numcalib_scale.Value
                    txtcalib_save_scalewidth.Text = numcalib_scalewidth.Value
                    txtcalib_save_scaleheight.Text = numcalib_scaleheight.Value
                    txtcalib_save_bright.Text = numcalib_bright.Value
                    txtcalib_save_r.Text = numcalib_r.Value
                    txtcalib_save_g.Text = numcalib_g.Value
                    txtcalib_save_b.Text = numcalib_b.Value

                    If txtcalib_scaleorcolor.Text = 0 Then

                        System.IO.File.Copy("./temp/temp1/" & txtcalib_count.Text & ".bmp", "./temp/temp2/bestscale.bmp", True)

                    ElseIf txtcalib_scaleorcolor.Text = 1 Then
                        System.IO.File.Copy("./temp/temp1/" & txtcalib_count.Text & ".bmp", "./temp/temp2/bestcolor.bmp", True)


                    End If

                End If

            End Using

        End Using


    End Sub

    Sub calib_hand()
        '■手動でパラメーターをいじったときの処理。各処理でhandscale.bmp or handrgb.bmpが生成されるので、場合分けしつつマッチング。
        '■最高一致率を更新した時は、自動調整と同じ名前でコピー。

        Dim minloc As Point, maxloc As Point
        Dim minval As Double = 0, maxval As Double = 0

        'Try '画像サイズが映像キャプチャデバイスのサイズ以上だとエラー落ちする

        Dim aa As String

        If txtcalib_scaleorcolor.Text = 0 Then
            aa = "./temp/temp2/handscale.bmp"

        ElseIf txtcalib_scaleorcolor.Text = 1 Then
            aa = "./temp/temp2/handrgb.bmp"

        End If


        Using tpl2 As Mat = Cv2.ImRead(aa, ImreadModes.Color)

            Dim img2 As Mat = piccalib_temp.ImageIpl
            Using res2 As New Mat(img2.Width - tpl2.Width + 1, img2.Height - tpl2.Height + 1, MatType.CV_32FC1)

                Cv2.MatchTemplate(img2, tpl2, res2, TemplateMatchModes.CCoeffNormed)
                Cv2.MinMaxLoc(res2, minval, maxval, minloc, maxloc, Nothing)


                'テンプレートマッチングの結果を表示
                txtcalib_nowvalue.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) '100 * maxval

                If CDbl(txtcalib_max.Text) < 100 * maxval Then

                    txtcalib_max.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) '100 * maxval
                    txtcalib_bestvalue.Text = Math.Round(100 * maxval, 2, MidpointRounding.AwayFromZero) & "%"


                    If txtcalib_scaleorcolor.Text = 0 Then
                        txtcalib_save_scale.Text = numcalib_hand_scale.Value
                        txtcalib_save_scalewidth.Text = numcalib_hand_scalewidth.Value
                        txtcalib_save_scaleheight.Text = numcalib_hand_scaleheight.Value


                    ElseIf txtcalib_scaleorcolor.Text = 1 Then
                        txtcalib_save_bright.Text = numcalib_hand_bright.Value
                        txtcalib_save_r.Text = numcalib_r.Value
                        txtcalib_save_g.Text = numcalib_g.Value
                        txtcalib_save_b.Text = numcalib_b.Value


                    End If


                    If txtcalib_scaleorcolor.Text = 0 Then

                        System.IO.File.Copy("./temp/temp2/handscale.bmp", "./temp/temp2/bestscale.bmp", True)


                    ElseIf txtcalib_scaleorcolor.Text = 1 Then
                        System.IO.File.Copy("./temp/temp2/handrgb.bmp", "./temp/temp2/bestcolor.bmp", True)


                    End If

                End If

            End Using

        End Using


    End Sub



    '画像の出力。
    Private Sub btncalib_resize_Click(sender As Object, e As EventArgs) Handles btncalib_resize.Click

        ' フォルダ (ディレクトリ) を作成する
        System.IO.Directory.CreateDirectory(txtpass_picturefolder.Text & "\resize")

        'Bitmapオブジェクトの作成
        For ii = 0 To txtcalib_numbers.Text - 1
            '選択されている項目のテキストを表示する

            listcalib_1.SelectedIndex = ii

            Dim pass As String = listcalib_1.Text
            Dim image = New Bitmap(pass)


            ' 画像の幅と高さの取得その２
            Dim imagew, imageh As Integer
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(pass, IO.FileMode.Open, IO.FileAccess.Read)
            imagew = System.Drawing.Image.FromStream(fs).Width
            imageh = System.Drawing.Image.FromStream(fs).Height
            fs.Close()

            Dim wid As Integer = CInt(imagew * (0.01 * txtcalib_save_scalewidth.Text) * (txtcalib_save_scale.Text / 100)) 'numwidth.Value
            Dim hei As Integer = CInt(imageh * (0.01 * numcalib_scaleheight.Value) * (txtcalib_save_scale.Text / 100)) 'numheight.Value

            '描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(wid, hei)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)


            '補間方法を指定して画像を縮小して描画する
            '補間方法として高品質双三次補間を指定する
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            '画像を縮小して描画する
            g.DrawImage(image, 0, 0, wid, hei)

            'BitmapとGraphicsオブジェクトを破棄
            image.Dispose()
            g.Dispose()


            'カラーバランスの調整
            AdjustColorImage(canvas, txtcalib_save_r.Text, txtcalib_save_g.Text, txtcalib_save_b.Text)

            Application.DoEvents()

            canvas.Save(txtpass_picturefolder.Text & "\resize\" & listcalib_2.Items(ii) & ".bmp", ImageFormat.Bmp)


        Next

        txtpass_picturefolder.Text = txtpass_picturefolder.Text & "\resize\"
        MessageBox.Show("ok.", messagebox_name)

        'PictureBox1.Image.Save(stCurrentDir & "\screenshot\" & psnumber & ".bmp", ImageFormat.Bmp)


    End Sub


    '■エクスプローラーから画像ファイルをドラッグしてPictureBox1上に表示する

    Private Sub piccomp_DragDrop(sender As Object, e As DragEventArgs) Handles piccalib_comp.DragDrop

        'ドラッグしてきた、ファイル名を取得
        Dim fileNames() As String = DirectCast(e.Data.GetData(DataFormats.FileDrop, False), String())
        txtcalib_compfilename.Text = fileNames(0)
        '取得したファイルのパスを元にピクチャーボックスに画像を表示
        With piccalib_comp
            .SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
            '既に画像が表示されていたら入れ替えて表示し、でなければ新規に表示する
            'Call sChangeImage(piccomp, System.Drawing.Image.FromFile(fileNames(0)))
            .Image = System.Drawing.Image.FromFile(fileNames(0))

            ' 画像の幅と高さの取得その２
            Dim imagew, imageh As Integer
            Dim fs2 As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs2 = New System.IO.FileStream(fileNames(0), IO.FileMode.Open, IO.FileAccess.Read)
            imagew = System.Drawing.Image.FromStream(fs2).Width
            imageh = System.Drawing.Image.FromStream(fs2).Height

            fs2.Close()

        End With

        chkcalib_2.Checked = True
        txtcalib_max.Text = 0

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then
            gbsetting.Enabled = True
            timcalib.Enabled = True
            timcamera.Enabled = False

            btncalib_resize.Enabled = True


        End If


    End Sub

    Private Sub Piccomp_DragEnter(sender As Object, e As DragEventArgs) Handles piccalib_comp.DragEnter
        '格納されているデータが、指定した形式に関連付けられているかどうかを確認
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'ターゲットにコピー
            e.Effect = DragDropEffects.Copy


        Else
            'ターゲットはデータを受け付けない
            e.Effect = DragDropEffects.None


        End If


    End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listcalib_1.SelectedIndexChanged

        Dim pass As String = listcalib_1.SelectedItem
        Dim image = New Bitmap(pass)
        piccalib_resize.Image = image


    End Sub



    Private Sub numhand_scale_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_hand_scale.ValueChanged

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then
            gbrgb.Enabled = True

            txtcalib_scaleorcolor.Text = 0

            timcalib.Enabled = False

            Dim pass As String = txtcalib_compfilename.Text
            Dim image = New Bitmap(pass)

            ' 画像の幅と高さの取得その２
            Dim imagew, imageh As Integer
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(pass, IO.FileMode.Open, IO.FileAccess.Read)
            imagew = System.Drawing.Image.FromStream(fs).Width
            imageh = System.Drawing.Image.FromStream(fs).Height

            fs.Close()

            Dim wid As Integer = CInt(imagew * (0.01 * numcalib_scalewidth.Value) * (CInt(numcalib_hand_scale.Value) / 100)) 'numwidth.Value
            Dim hei As Integer = CInt(imageh * (0.01 * numcalib_scaleheight.Value) * (CInt(numcalib_hand_scale.Value) / 100)) 'numheight.Value

            '描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(wid, hei)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)

            '補間方法を指定して画像を縮小して描画する
            '補間方法として高品質双三次補間を指定する
            g.InterpolationMode =
                    System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            '画像を縮小して描画する
            g.DrawImage(image, 0, 0, wid, hei)

            'BitmapとGraphicsオブジェクトを破棄
            image.Dispose()
            g.Dispose()


            'PictureBox1に表示する
            piccalib_handresult.Image = canvas
            piccalib_handresult.Image.Save("./temp/temp2/handscale.bmp", ImageFormat.Bmp)

            'Application.DoEvents()

            calib_hand()

            txtsave_to_num()

            '現時点で最も良いパラメーターの画像を作成する。
            best()


        End If


    End Sub


    Private Sub numhand_scalewidth_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_hand_scalewidth.ValueChanged

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then

            gbrgb.Enabled = True

            txtcalib_scaleorcolor.Text = 0

            Dim pass As String = txtcalib_compfilename.Text
            Dim image = New Bitmap(pass)

            ' 画像の幅と高さの取得その２
            Dim imagew, imageh As Integer
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(pass, IO.FileMode.Open, IO.FileAccess.Read)
            imagew = System.Drawing.Image.FromStream(fs).Width
            imageh = System.Drawing.Image.FromStream(fs).Height

            fs.Close()

            Dim wid As Integer = CInt(imagew * ((0.01 * numcalib_hand_scalewidth.Value)) * (CInt(numcalib_hand_scale.Value) / 100)) 'numwidth.Value
            Dim hei As Integer = CInt(imageh * ((0.01 * numcalib_hand_scaleheight.Value)) * (CInt(numcalib_hand_scale.Value) / 100)) 'numheight.Value

            '描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(wid, hei)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)


            '補間方法を指定して画像を縮小して描画する
            '補間方法として高品質双三次補間を指定する
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            '画像を縮小して描画する
            g.DrawImage(image, 0, 0, wid, hei)

            'BitmapとGraphicsオブジェクトを破棄
            image.Dispose()
            g.Dispose()


            'PictureBox1に表示する
            piccalib_handresult.Image = canvas
            piccalib_handresult.Image.Save("./temp/temp2/handscale.bmp", ImageFormat.Bmp)

            calib_hand()

            txtsave_to_num()

            '現時点で最も良いパラメーターの画像を作成する。
            best()

            'Application.DoEvents()


        End If


    End Sub

    Private Sub numhand_scaleheight_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_hand_scaleheight.ValueChanged

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then
            gbrgb.Enabled = True

            txtcalib_scaleorcolor.Text = 0

            Dim pass As String = txtcalib_compfilename.Text
            Dim image = New Bitmap(pass)

            ' 画像の幅と高さの取得その２
            Dim imagew, imageh As Integer
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(pass, IO.FileMode.Open, IO.FileAccess.Read)
            imagew = System.Drawing.Image.FromStream(fs).Width
            imageh = System.Drawing.Image.FromStream(fs).Height

            fs.Close()

            Dim wid As Integer = CInt(imagew * ((0.01 * numcalib_hand_scalewidth.Value)) * (CInt(numcalib_scale.Value) / 100)) 'numwidth.Value
            Dim hei As Integer = CInt(imageh * ((0.01 * numcalib_hand_scaleheight.Value)) * (CInt(numcalib_scale.Value) / 100)) 'numheight.Value

            '描画先とするImageオブジェクトを作成する
            Dim canvas As New Bitmap(wid, hei)
            'ImageオブジェクトのGraphicsオブジェクトを作成する
            Dim g As Graphics = Graphics.FromImage(canvas)


            '補間方法を指定して画像を縮小して描画する
            '補間方法として高品質双三次補間を指定する
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            '画像を縮小して描画する
            g.DrawImage(image, 0, 0, wid, hei)

            'BitmapとGraphicsオブジェクトを破棄
            image.Dispose()
            g.Dispose()


            'PictureBox1に表示する
            piccalib_handresult.Image = canvas
            piccalib_handresult.Image.Save("./temp/temp2/handscale.bmp", ImageFormat.Bmp)


            calib_hand()

            'Application.DoEvents()


        End If


    End Sub

    Private Sub numhand_bright_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_hand_bright.ValueChanged

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then

            txtcalib_scaleorcolor.Text = 1

            numcalib_hand_r.Value = numcalib_hand_bright.Value
            numcalib_hand_g.Value = numcalib_hand_bright.Value
            numcalib_hand_b.Value = numcalib_hand_bright.Value

            Dim brightness As Integer = numcalib_hand_bright.Value

            '色補正をする画像
            Dim img As New Bitmap("./temp/temp2/handscale.bmp")
            '赤を128増加させる
            AdjustColorImage(img, brightness, brightness, brightness)
            'PictureBox1に表示
            If Not piccalib_bestresult.Image Is Nothing Then
                piccalib_bestresult.Image.Dispose()


            End If

            piccalib_handresult.Image = img
            piccalib_handresult.Image.Save("./temp/temp2/handrgb.bmp", ImageFormat.Bmp)

            calib_hand()

            txtsave_to_num()

            '現時点で最も良いパラメーターの画像を作成する。
            best()


        End If


    End Sub


    Private Sub numhand_r_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_hand_r.ValueChanged

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then
            txtcalib_scaleorcolor.Text = 1

            Dim rr As Integer = numcalib_hand_r.Value
            Dim gg As Integer = numcalib_hand_g.Value
            Dim bb As Integer = numcalib_hand_b.Value

            '色補正をする画像
            Dim img As New Bitmap("./temp/temp2/handscale.bmp")
            '赤を128増加させる
            AdjustColorImage(img, rr, gg, bb)
            'PictureBox1に表示
            If Not piccalib_bestresult.Image Is Nothing Then
                piccalib_bestresult.Image.Dispose()


            End If

            piccalib_handresult.Image = img
            piccalib_handresult.Image.Save("./temp/temp2/handrgb.bmp", ImageFormat.Bmp)

            calib_hand()

            txtsave_to_num()

            '現時点で最も良いパラメーターの画像を作成する。
            best()


        End If


    End Sub

    Private Sub numhand_g_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_hand_g.ValueChanged

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then

            txtcalib_scaleorcolor.Text = 1

            Dim rr As Integer = numcalib_hand_r.Value
            Dim gg As Integer = numcalib_hand_g.Value
            Dim bb As Integer = numcalib_hand_b.Value

            '色補正をする画像
            Dim img As New Bitmap("./temp/temp2/handscale.bmp")
            '赤を128増加させる
            AdjustColorImage(img, rr, gg, bb)
            'PictureBox1に表示
            If Not piccalib_bestresult.Image Is Nothing Then
                piccalib_bestresult.Image.Dispose()


            End If

            piccalib_handresult.Image = img
            piccalib_handresult.Image.Save("./temp/temp2/handrgb.bmp", ImageFormat.Bmp)

            calib_hand()

            txtsave_to_num()

            '現時点で最も良いパラメーターの画像を作成する。
            best()


        End If


    End Sub

    Private Sub numhand_b_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_hand_b.ValueChanged

        If chkcalib_1.Checked = True And chkcalib_2.Checked = True Then

            txtcalib_scaleorcolor.Text = 1

            Dim rr As Integer = numcalib_hand_r.Value
            Dim gg As Integer = numcalib_hand_g.Value
            Dim bb As Integer = numcalib_hand_b.Value

            '色補正をする画像
            Dim img As New Bitmap("./temp/temp2/handscale.bmp")
            '赤を128増加させる
            AdjustColorImage(img, rr, gg, bb)
            'PictureBox1に表示
            If Not piccalib_bestresult.Image Is Nothing Then
                piccalib_bestresult.Image.Dispose()
            End If
            piccalib_handresult.Image = img
            piccalib_handresult.Image.Save("./temp/temp2/handrgb.bmp", ImageFormat.Bmp)

            calib_hand()

            txtsave_to_num()

            '現時点で最も良いパラメーターの画像を作成する。
            best()


        End If


    End Sub



    Sub txtsave_to_num()
        '自動調整用の値を常に更新する。
        numcalib_scale.Value = txtcalib_save_scale.Text
        numcalib_scalewidth.Value = txtcalib_save_scalewidth.Text
        numcalib_scaleheight.Value = txtcalib_save_scaleheight.Text
        numcalib_bright.Value = txtcalib_save_bright.Text
        numcalib_r.Value = txtcalib_save_r.Text
        numcalib_g.Value = txtcalib_save_g.Text
        numcalib_b.Value = txtcalib_save_b.Text


    End Sub

    Private Sub numbright_ValueChanged(sender As Object, e As EventArgs) Handles numcalib_bright.ValueChanged

        numcalib_r.Value = numcalib_bright.Value
        numcalib_g.Value = numcalib_bright.Value
        numcalib_b.Value = numcalib_bright.Value


    End Sub

    Private Sub btncalib_insert_Click(sender As Object, e As EventArgs) Handles btncalib_insert.Click

        txtcalib_save_scale.Text = numcalib_hand_scale.Value
        txtcalib_save_scalewidth.Text = numcalib_hand_scalewidth.Value
        txtcalib_save_scaleheight.Text = numcalib_hand_scaleheight.Value
        txtcalib_save_bright.Text = numcalib_hand_bright.Value
        txtcalib_save_r.Text = numcalib_hand_r.Value
        txtcalib_save_g.Text = numcalib_hand_g.Value
        txtcalib_save_b.Text = numcalib_hand_b.Value


    End Sub

    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btncalib_reset.Click

        txtcalib_save_scale.Text = 100
        txtcalib_save_scalewidth.Text = 100
        txtcalib_save_scaleheight.Text = 100
        txtcalib_save_bright.Text = 0
        txtcalib_save_r.Text = 0
        txtcalib_save_g.Text = 0
        txtcalib_save_b.Text = 0

        txtcalib_max.Text = 0
        txtcalib_bestvalue.Text = 0

        txtsave_to_num()


    End Sub


#End Region

    '■クロップウィンドウ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private crop_aspect_x As Integer = 16
    Private crop_aspect_y As Integer = 9

    Private Sub Crop_setup()

        lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " Cropping"

        btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
        btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)

        Cropping_preview.Show()
        Cropping_preview.Size = New Drawing.Size(numcrop_resolution_x.Value + (50 * Dpi_rate), numcrop_resolution_y.Value + (50 * Dpi_rate))
        Cropping_preview.picipl_crop.Size = New Drawing.Size(numcrop_resolution_x.Value, numcrop_resolution_y.Value)

        '■inputの解像度を表示
        capturecv.Read(frame)

        Cropping_preview.picipl_crop.ImageIpl = frame







    End Sub



    Private dst_crop As Mat = New Mat(640, 360, MatType.CV_32FC1) ' = Cv2.ImRead("./data/img.png", ImreadModes.AnyColor)
    Private dst_crop_temp As Mat = New Mat(640, 360, MatType.CV_32FC1) ' = Cv2.ImRead("./data/img.png", ImreadModes.AnyColor)


    Private Sub btncrop_frame_Click(sender As Object, e As EventArgs) Handles btncrop_frame.Click

        Try

            If numcrop_resolution_x.Value < numcrop_position_x.Value + CInt(txtcrop_size_x.Text) Or
            numcrop_resolution_y.Value < numcrop_position_y.Value + CInt(txtcrop_size_y.Text) Then
                lblcrop_status.Text = "Crop status : 許されない"

                Exit Sub


            End If

            Cropping_preview.Size = New Drawing.Size(
                numcrop_rate.Value * crop_aspect_x * 2 + (50 * Dpi_rate),
                numcrop_rate.Value * crop_aspect_y * 2 + (50 * Dpi_rate))

            Cropping_preview.picipl_crop.Size = New Drawing.Size(
            numcrop_rate.Value * crop_aspect_x * 2,
            numcrop_rate.Value * crop_aspect_y * 2)

            '■inputの解像度を表示
            capturecv.Read(frame)

            dst_crop_temp = New Mat(frame, New OpenCvSharp.Rect(
                                    numcrop_position_x.Value, numcrop_position_y.Value,
                                    numcrop_rate.Value * crop_aspect_x * 2, numcrop_rate.Value * crop_aspect_y * 2))

            Dim cropped_p As Mat = New Mat(numcrop_rate.Value * crop_aspect_x, numcrop_rate.Value * crop_aspect_y, MatType.CV_32FC1)


            dst_crop_temp.CopyTo(cropped_p)
            Cropping_preview.picipl_crop.ImageIpl = cropped_p

        Catch ex As Exception

            rtxtlog.AppendText(Now & " Error" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try

    End Sub


    Private Sub numcrop_rate_ValueChanged(sender As Object, e As EventArgs) Handles numcrop_rate.ValueChanged

        If Cropping_preview.Visible = False Then
            Exit Sub

        End If


        txtcrop_size_x.Text = numcrop_rate.Value * crop_aspect_x * 2
        txtcrop_size_y.Text = numcrop_rate.Value * crop_aspect_y * 2

        If numcrop_resolution_x.Value > numcrop_position_x.Value + CInt(txtcrop_size_x.Text) And
           numcrop_resolution_y.Value > numcrop_position_y.Value + CInt(txtcrop_size_y.Text) Then

            lblcrop_status.Text = "Crop status : 許された"
            Crop_apply()
        Else
            lblcrop_status.Text = "Crop status : 許されない"

        End If




    End Sub

    Private Sub numcrop_position_x_ValueChanged(sender As Object, e As EventArgs) Handles numcrop_position_x.ValueChanged

        If Cropping_preview.Visible = False Then
            Exit Sub
        End If

        If numcrop_resolution_x.Value < numcrop_position_x.Value + CInt(txtcrop_size_x.Text) Or
          numcrop_resolution_y.Value < numcrop_position_y.Value + CInt(txtcrop_size_y.Text) Then
            lblcrop_status.Text = "Crop status : 許されない"
            Exit Sub

        End If

        Crop_apply()


    End Sub

    Private Sub numcrop_position_y_ValueChanged(sender As Object, e As EventArgs) Handles numcrop_position_y.ValueChanged

        If Cropping_preview.Visible = False Then
            Exit Sub
        End If

        If numcrop_resolution_x.Value < numcrop_position_x.Value + CInt(txtcrop_size_x.Text) Or
          numcrop_resolution_y.Value < numcrop_position_y.Value + CInt(txtcrop_size_y.Text) Then
            lblcrop_status.Text = "Crop status : 許されない"
            Exit Sub

        End If

        Crop_apply()


    End Sub

    Private Sub Crop_apply()
        Try


            Cropping_preview.Size = New Drawing.Size(
            numcrop_rate.Value * crop_aspect_x * 2 + (50 * Dpi_rate),
            numcrop_rate.Value * crop_aspect_y * 2 + (50 * Dpi_rate))

            Cropping_preview.picipl_crop.Size = New Drawing.Size(
                numcrop_rate.Value * crop_aspect_x * 2,
                numcrop_rate.Value * crop_aspect_y * 2)

            ''■inputの解像度を表示

            dst_crop_temp = New Mat(frame, New OpenCvSharp.Rect(
                                    numcrop_position_x.Value, numcrop_position_y.Value,
                                    numcrop_rate.Value * crop_aspect_x * 2, numcrop_rate.Value * crop_aspect_y * 2))

            Dim cropped_p As Mat = New Mat(numcrop_rate.Value * crop_aspect_x, numcrop_rate.Value * crop_aspect_y, MatType.CV_32FC1)


            dst_crop_temp.CopyTo(cropped_p)
            Cropping_preview.picipl_crop.ImageIpl = cropped_p
            lblcrop_status.Text = "Crop status : 許された"

        Catch ex As Exception
            rtxtlog.AppendText(Now & " Error" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try

    End Sub

    Private Sub btncrop_ok_Click(sender As Object, e As EventArgs) Handles btncrop_ok.Click
        txtcv_crop_posx.Text = numcrop_position_x.Value
        txtcv_crop_posy.Text = numcrop_position_y.Value
        txtcv_crop_sizex.Text = txtcrop_size_x.Text
        txtcv_crop_sizey.Text = txtcrop_size_y.Text
        MessageBox.Show("Apply.")

    End Sub

    Private Sub rdocrop_169_CheckedChanged(sender As Object, e As EventArgs) Handles rdocrop_169.CheckedChanged

        If rdocrop_169.Checked = True Then
            crop_aspect_x = 16
            crop_aspect_y = 9
        ElseIf rdocrop_43.Checked = True Then
            crop_aspect_x = 4
            crop_aspect_y = 3
        End If


    End Sub

    Private Sub rdocrop_43_CheckedChanged(sender As Object, e As EventArgs) Handles rdocrop_43.CheckedChanged

        If rdocrop_169.Checked = True Then
            crop_aspect_x = 16
            crop_aspect_y = 9
        ElseIf rdocrop_43.Checked = True Then
            crop_aspect_x = 4
            crop_aspect_y = 3
        End If


    End Sub


    '■OpenCVモニタリング■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■


    Private WithEvents cvtimer As New DispatcherTimer()
    Private WithEvents cvtimer_change As New DispatcherTimer()
    Private WithEvents cvtimer_changergb As New DispatcherTimer()
    Private WithEvents cvsleep_split As New DispatcherTimer()
    Private WithEvents cvpreview As New DispatcherTimer()
    Private WithEvents cvpreview_zoom As New DispatcherTimer()
    Private WithEvents cvpreview_replay As New DispatcherTimer()

    Private WithEvents cvtimer_load1 As New DispatcherTimer()
    Private WithEvents cvtimer_load2 As New DispatcherTimer()
    Private WithEvents cvtimer_load3 As New DispatcherTimer()
    Private WithEvents cvtimer_load4 As New DispatcherTimer()
    Private WithEvents cvtimer_load5 As New DispatcherTimer()
    Private WithEvents cvtimer_load6 As New DispatcherTimer()
    Private WithEvents cvtimer_load7 As New DispatcherTimer()
    Private WithEvents cvtimer_load8 As New DispatcherTimer()
    Private WithEvents cvtimer_load9 As New DispatcherTimer()
    Private WithEvents cvtimer_load10 As New DispatcherTimer()

    Private WithEvents cvtimer_loadremover1 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover2 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover3 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover4 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover5 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover6 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover7 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover8 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover9 As New DispatcherTimer()
    Private WithEvents cvtimer_loadremover10 As New DispatcherTimer()

    Private WithEvents cvtimer_loaddelay1 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay2 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay3 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay4 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay5 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay6 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay7 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay8 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay9 As New DispatcherTimer()
    Private WithEvents cvtimer_loaddelay10 As New DispatcherTimer()

    Private WithEvents cvtimer_manualstart As New DispatcherTimer()

    Private WithEvents cvtimer_ash_hotkey As New DispatcherTimer()

    Private tempnumber As Integer = 0

    Private capturecv As VideoCapture

    Private frame As Mat = New Mat(640, 360, MatType.CV_32FC1) 'New Mat(numcv_sizex.Value, numcv_sizey.Value, MatType.CV_8UC3)


    Private minloc_split As Point
    Private maxloc_split As Point
    Private minval_split As Double = 0
    Private maxval_split As Double = 0

    Private minloc_reset As Point
    Private maxloc_reset As Point
    Private minval_reset As Double = 0
    Private maxval_reset As Double = 0

    Private minloc_load1, minloc_load2, minloc_load3, minloc_load4, minloc_load5, minloc_load6, minloc_load7, minloc_load8, minloc_load9, minloc_load10 As Point
    Private maxloc_load1, maxloc_load2, maxloc_load3, maxloc_load4, maxloc_load5, maxloc_load6, maxloc_load7, maxloc_load8, maxloc_load9, maxloc_load10 As Point

    Private minval_load1 As Double = 0
    Private minval_load2 As Double = 0
    Private minval_load3 As Double = 0
    Private minval_load4 As Double = 0
    Private minval_load5 As Double = 0
    Private minval_load6 As Double = 0
    Private minval_load7 As Double = 0
    Private minval_load8 As Double = 0
    Private minval_load9 As Double = 0
    Private minval_load10 As Double = 0

    Private maxval_load1 As Double = 0
    Private maxval_load2 As Double = 0
    Private maxval_load3 As Double = 0
    Private maxval_load4 As Double = 0
    Private maxval_load5 As Double = 0
    Private maxval_load6 As Double = 0
    Private maxval_load7 As Double = 0
    Private maxval_load8 As Double = 0
    Private maxval_load9 As Double = 0
    Private maxval_load10 As Double = 0

    Private tplex As Mat
    Private tplex_r As Mat
    Private tplex_load1 As Mat
    Private tplex_load2 As Mat
    Private tplex_load3 As Mat
    Private tplex_load4 As Mat
    Private tplex_load5 As Mat
    Private tplex_load6 As Mat
    Private tplex_load7 As Mat
    Private tplex_load8 As Mat
    Private tplex_load9 As Mat
    Private tplex_load10 As Mat
    Private imgex As Mat = New Mat(640, 360, MatType.CV_32FC1)

    Private dst_resize As Mat = New Mat(640, 360, MatType.CV_32FC1) ' = Cv2.ImRead("./data/img.png", ImreadModes.AnyColor)
    Private dst_cropRect As Mat = New Mat(640, 360, MatType.CV_32FC1) ' = Cv2.ImRead("./data/img.png", ImreadModes.AnyColor)
    Private dst_cropped As Mat = New Mat(640, 360, MatType.CV_32FC1) ' = Cv2.ImRead("./data/img.png", ImreadModes.AnyColor)


    Private cv_method As Integer = 0



    '■監視の処理■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub btnstartopencv_Click(sender As Object, e As EventArgs) Handles btnstartopencv.Click

        Try

#Region "監視前のチェック"



            '■画像フォルダ選択がなされているかどうか
            If txtpass_picturefolder.Text = "" Or txtpass_picturefolder.Text = "フォルダを選択して下さい…" Then '画像フォルダは選択ができた時点で中身は大丈夫…なはず
                MessageBox.Show(My.Resources.Message.msg5, messagebox_name,
                        MessageBoxButtons.OK) '"画像フォルダ選択がされていません。"

                Exit Sub

            End If

            '■画像（1.bmp、Reset.bmp）が存在するかどうか。いずれの場合も1.bmpの存在確認は必要。

            If chkcv_resetonoff.Checked = False Then '→1.bmpがあれば良い。

                If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\1.bmp") Then

                    MessageBox.Show(My.Resources.Message.msg22, messagebox_name) '"1.bmpが存在しません。"

                    Exit Sub

                End If


            ElseIf chkcv_resetonoff.Checked = True Then '→1.bmp、reset.bmpがあれば良い。

                If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\1.bmp") Or
                   Not System.IO.File.Exists(txtpass_picturefolder.Text & "\reset.bmp") Then

                    MessageBox.Show(My.Resources.Message.msg23, messagebox_name) '"1.bmpもしくはreset.bmpが存在しません。"

                    Exit Sub

                End If

            End If


            '■Load remover用の画像があるかどうかチェック
            If chkcv_loadremover.Checked = True Then

                If chkload1.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading1.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload2.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading2.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload3.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading3.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload4.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading4.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload5.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading5.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload6.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading6.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload7.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading7.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload8.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading8.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload9.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading9.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If

                ElseIf chkload10.Checked = True Then

                    If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\loading10.bmp") Then

                        MessageBox.Show(My.Resources.Message.msg40, messagebox_name) '"loading.bmpが存在しません。"

                        Exit Sub

                    End If



                End If


            End If



            '■ビデオプレイヤーを表示する設定＋表示されていない場合、表示する。
            If chkshowvideo.Checked = True And Videoplayer.Visible = False Then
                Console.WriteLine("ビデオプレイヤーが表示されていない")
                Videoplayer.Show()

            End If

            '■テキストビューワーを表示する設定＋表示されていない場合、表示する。
            If chkshow_text.Checked = True And Textwindow.Visible = False Then
                Console.WriteLine("テキストビューワーが表示されていない")
                Textwindow.Show()

            End If







            '■ウィンドウサイズの調整
            Me.Size = New Drawing.Point(800 * Dpi_rate, 600 * Dpi_rate)
            DGtable.Size = New Drawing.Point(785 * Dpi_rate, 146 * Dpi_rate)





            '■seektimeに整数が入っているか★★書く場所がおかしい
            Dim TableRowsCount As Integer = DGtable.Rows.Count - 1

            For i = 0 To TableRowsCount - 1

                If Validation.IsNumeric(CStr(DGtable(seektime.Index, i).Value)) Then
                    '数字が入っているので問題ない

                Else
                    '数字以外が入っている
                    MessageBox.Show(My.Resources.Message.msg45, messagebox_name) 'Time列に数字以外の文字が入っています。

                    Exit Sub


                End If


            Next



            Dim TableCount As Integer = DGtable.Rows.Count - 1


            '■Rtfファイル数と表データの数に齟齬がないか
            Dim FileCount_rtfonly As Integer

            If chkshow_text.Checked = True Then
                Dim di_text As New System.IO.DirectoryInfo(txtpass_rtf.Text)
                Dim files_text As System.IO.FileInfo() = di_text.GetFiles("*.rtf", System.IO.SearchOption.TopDirectoryOnly)

                For Each f As System.IO.FileInfo In files_text
                    FileCount_rtfonly += 1
                Next

                If Not FileCount_rtfonly = TableCount - 1 Then
                    MessageBox.Show(My.Resources.Message.msgd01, messagebox_name) '"Rtfファイルが存在しないか、数がテンプレート数と一致していません。"

                    Exit Sub
                End If


            End If



            '■画像ファイル数と表データの数に齟齬がないか。
            '　全てのbmpファイル数をカウントし、loading、resetを除外している。
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


            'ファイル数: FileCount
            '除リセット、ロード: FileCount_numberonly
            '行数: TableCount

            If chkcv_loop.Checked = True Then 'ファイル数を考慮する必要なし。

            ElseIf chkcv_loop.Checked = False Then

                If chkcv_resetonoff.Checked = False Then

                    If Not FileCount_bmponly = TableCount - 1 Then
                        MessageBox.Show(My.Resources.Message.msg6 & vbCrLf &
                                       "Table line number(s): " & TableCount - 1 & " (exclude Reset line)" & vbCrLf &
                                       "Bmpfile number(s): " & FileCount_bmponly & vbCrLf &
                                       "Textfile number(s): " & FileCount_rtfonly,
                                        "AutoSplit Helper by Image", MessageBoxButtons.OK) '"画像ファイル数と表のデータ数が一致しません。"

                        Exit Sub

                    End If

                ElseIf chkcv_resetonoff.Checked = True Then

                    FileCount_bmponly += 1 'resetの分を補填

                    If Not FileCount_bmponly = TableCount Then
                        MessageBox.Show(My.Resources.Message.msg6 & vbCrLf &
                                       "Table line number(s): " & TableCount & " (include Reset line)" & vbCrLf &
                                       "Bmpfile number(s): " & FileCount_bmponly & vbCrLf &
                                       "Textfile number(s): " & FileCount_rtfonly,
                                        "AutoSplit Helper by Image", MessageBoxButtons.OK) '"画像ファイル数と表のデータ数が一致しません。"

                        Exit Sub

                    End If

                End If




            End If


            '■適切な解像度を入力しているか確認
            If (numcv_sizex.Value Mod 16 = 0 And numcv_sizey.Value Mod 9 = 0) Or (numcv_sizex.Value Mod 4 = 0 And numcv_sizey.Value Mod 3 = 0) Then

            Else

                MessageBox.Show(My.Resources.Message.msg52, messagebox_name) 'サイズは16:9または4:3の比で入力してください。

                Exit Sub

            End If


            '■キーコードが空欄になっていないか確認
            If lblkeysforsend.Text = "" Or lblkeysforsend_reset.Text = "" Or lblkeysforpause.Text = "" Or
               lblkeysforresume.Text = "" Or lblkeysforundo.Text = "" Or lblkeysforskip.Text = "" Then

                MessageBox.Show(My.Resources.Message.msge04, messagebox_name)

                Exit Sub 'キーコードが空欄になっています。Hotkeyの設定をし直して再度お試しください。


            End If


#End Region

            '■↑のExit Subを切り抜けたので監視処理開始■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

            '■一時的にDGTableのイベントを無効にする。監視終了時に有効にする。
            RemoveHandler DGtable.CellValueChanged, AddressOf DGtable_CellValueChanged




            '■Livesplitの名前付きパイプの接続状況表示。存在したら接続

            'タイマーのプロセスを探す
            Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

            If 0 < ps_timer1.Length Then

                If pipeServer.IsConnected = False Then
                    pipeServer.Connect()
                    livesplit_state = "[LiveSplit NamedPipe ON]"

                End If

            Else

                livesplit_state = "[LiveSplit NamedPipe OFF]"

            End If

            lbllivesplit_state.Text = livesplit_state


            lbllapcount.Text = 0 + (numgraph_first.Value - 1)


            '■ループのチェックの有無で進む、戻るボタンの有効/無効指定
            If chkcv_loop.Checked = False Then

                '進む、戻るボタンを有効に
                btncv_back.Enabled = True
                btncv_forward.Enabled = True
                btncv_first.Enabled = True

            ElseIf chkcv_loop.Checked = True Then

                '進む、戻るボタンを無効に
                btncv_back.Enabled = False
                btncv_forward.Enabled = False
                btncv_first.Enabled = False

            End If


            '■タイマーのインターバルを設定
            cvtimer.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Text - 1)
            cvsleep_split.Interval = New TimeSpan(0, 0, 0, 0, 15)
            cvtimer_change.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Text)
            cvtimer_changergb.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Text)
            cvtimer_load1.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load2.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load3.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load4.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load5.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load6.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load7.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load8.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load9.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_load10.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)

            cvtimer_loadremover1.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover2.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover3.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover4.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover5.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover6.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover7.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover8.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover9.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loadremover10.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)

            cvtimer_loaddelay1.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay2.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay3.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay4.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay5.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay6.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay7.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay8.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay9.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)
            cvtimer_loaddelay10.Interval = New TimeSpan(0, 0, 0, 0, numcv_interval.Value)

            cvtimer_ash_hotkey.Interval = New TimeSpan(0, 0, 0, 0, 100)


            lblcv_nowmaxval.Text = 0
            lblcv_maxval.Text = 0

            lblcv_maxval_reset.Text = 0
            lblcv_nowmaxval_reset.Text = 0

            lblcv_maxval_load.Text = 0
            lblcv_nowmaxval_load.Text = 0

            lblrecord_pause.Text = 0
            lblrecord_pause_total.Text = 0

            txtcv_antentime.Text = 0
            txtdelay_load.Text = 0

            lblcv_maxval_load1.Text = 0
            lblcv_maxval_load2.Text = 0
            lblcv_maxval_load3.Text = 0
            lblcv_maxval_load4.Text = 0
            lblcv_maxval_load5.Text = 0
            lblcv_maxval_load6.Text = 0
            lblcv_maxval_load7.Text = 0
            lblcv_maxval_load8.Text = 0
            lblcv_maxval_load9.Text = 0
            lblcv_maxval_load10.Text = 0

            lblcv_nowmaxval_load1.Text = 0
            lblcv_nowmaxval_load2.Text = 0
            lblcv_nowmaxval_load3.Text = 0
            lblcv_nowmaxval_load4.Text = 0
            lblcv_nowmaxval_load5.Text = 0
            lblcv_nowmaxval_load6.Text = 0
            lblcv_nowmaxval_load7.Text = 0
            lblcv_nowmaxval_load8.Text = 0
            lblcv_nowmaxval_load9.Text = 0
            lblcv_nowmaxval_load10.Text = 0

            txtdelay_load1.Text = 0
            txtdelay_load2.Text = 0
            txtdelay_load3.Text = 0
            txtdelay_load4.Text = 0
            txtdelay_load5.Text = 0
            txtdelay_load6.Text = 0
            txtdelay_load7.Text = 0
            txtdelay_load8.Text = 0
            txtdelay_load9.Text = 0
            txtdelay_load10.Text = 0

            'ループカウント用
            numnowloop.Value = 0
            lblloopcount.Text = numnowloop.Value & "/" & numloopcount.Value


            txtrecord_load.Text = 0.ToString("00:00.00")
            txtrecord_load_total.Text = 0.ToString("00:00.00")


            '■プレビュー画面の更新。Viewの解像度で表示
            capturecv.Read(frame) 'NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(Me.capturecv.CvPtr, Me.frame.CvPtr)

            If chkcv_crop.Checked = True Then

                '■先にクロップをする。
                dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

                Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

                dst_cropRect.CopyTo(dst_cropped)

                '■リサイズ
                dst_resize = New Mat()
                Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                picipl_cap.ImageIpl = dst_resize
                imgex = dst_resize

                dst_cropRect.Dispose()
                dst_cropped.Dispose()
                'dst_resize.Dispose()


            ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

                If numcv_sizex.Value = numcrop_resolution_x.Value And
                   numcv_sizey.Value = numcrop_resolution_y.Value Then

                    picipl_cap.ImageIpl = frame
                    imgex = frame

                Else

                    dst_resize = New Mat()
                    Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                    picipl_cap.ImageIpl = dst_resize
                    imgex = dst_resize

                    'dst_resize.Dispose()


                End If

            End If






            '■★Methodに番号を送る。どの方式で監視を行うか。
            cv_method = DGtable(send.Index, CInt(lblcv_lap.Text) - 0).Value '表の2行目のMethod値を取得。0/1:OpenCV、2/3:RGB、4/5:RGB(色の割合)

            '■画像読み込み用■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

            lblcv_lap.Text = 1 '開始時は必ず1。監視場所のチェック有り→1のまま。チェック無し→1,2,3,...

            lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value '表の2行目の文字を表示

            lblcv_sleepcount.Text = DGtable(sleep.Index, CInt(lblcv_lap.Text)).Value
            lblsleeptime.Text = DGtable(sleep.Index, CInt(lblcv_lap.Text)).Value

            txtcv_ikiti.Text = DGtable(rate.Index, CInt(lblcv_lap.Text)).Value
            txtcv_ikiti_reset.Text = DGtable(rate.Index, 0).Value
            txtcv_ikiti_load.Text = numload_rate1.Value

            lblloading.Text = "play"

            txtcv_ikiti_load1.Text = numload_rate1.Value
            txtcv_ikiti_load2.Text = numload_rate2.Value
            txtcv_ikiti_load3.Text = numload_rate3.Value
            txtcv_ikiti_load4.Text = numload_rate4.Value
            txtcv_ikiti_load5.Text = numload_rate5.Value
            txtcv_ikiti_load6.Text = numload_rate6.Value
            txtcv_ikiti_load7.Text = numload_rate7.Value
            txtcv_ikiti_load8.Text = numload_rate8.Value
            txtcv_ikiti_load9.Text = numload_rate9.Value
            txtcv_ikiti_load10.Text = numload_rate10.Value

            txtcv_color_r.Text = DGtable(color_r.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_g.Text = DGtable(color_g.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_b.Text = DGtable(color_b.Index, CInt(lblcv_lap.Text)).Value

            color_lower_limit_r = txtcv_color_r.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_g = txtcv_color_g.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_b = txtcv_color_b.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            color_upper_limit_r = txtcv_color_r.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_g = txtcv_color_g.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_b = txtcv_color_b.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            ColorAllowance = DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value


            If chkcv_monitor.Checked = True Then

                '■最初の画像の読み込み
                Dim aa As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                tplex = Cv2.ImRead(aa, ImreadModes.Color)

                '■最初の画像の読み込み（表示用）
                Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                    piccv_picture.Image = Image.FromStream(fs)
                End Using


                chknow_monitor.Checked = True


            ElseIf chkcv_monitor.Checked = False Then

                '■最初の画像の読み込み
                Dim aa As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                tplex = Cv2.ImRead(aa, ImreadModes.Color)

                '■最初の画像の読み込み（表示用）
                Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                    piccv_picture.Image = Image.FromStream(fs)
                End Using

            End If

            'tplex = tplex_temp.Clone()


            If chkcv_resetonoff.Checked = True Then

                '■リセット画像の読み込み
                Dim aa_reset As String = txtpass_picturefolder.Text & "\reset.bmp"
                tplex_r = Cv2.ImRead(aa_reset, ImreadModes.Color)

                '■リセット画像の読み込み（表示用）
                Using fs As FileStream = New FileStream(aa_reset, FileMode.Open, FileAccess.Read)
                    piccv_reset.Image = Image.FromStream(fs)
                End Using

                chknow_reset.Checked = True


            ElseIf chkcv_resetonoff.Checked = False Then '適当な画像(1.bmp)を読み込む。

                '■最初の画像の読み込み
                Dim aa_reset As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                tplex_r = Cv2.ImRead(aa_reset, ImreadModes.Color)

                '■リセット画像の読み込み（表示用）
                Using fs As FileStream = New FileStream(aa_reset, FileMode.Open, FileAccess.Read)
                    piccv_reset.Image = Image.FromStream(fs)
                End Using




            End If


            If chkcv_loadremover.Checked = True Then

                chknow_load.Checked = True



                If chkload1.Checked = True Then
                    '■ローディング画像1の読み込み
                    Dim aa_load1 As String = txtpass_picturefolder.Text & "\loading1.bmp"
                    tplex_load1 = Cv2.ImRead(aa_load1, ImreadModes.Color)

                    '■ローディング画像の読み込み（表示用）
                    Using fs As FileStream = New FileStream(aa_load1, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                    chknow_load1.Checked = True

                ElseIf chkload1.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load1 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load1 = Cv2.ImRead(aa_load1, ImreadModes.Color)

                    '■ローディング画像の読み込み（表示用）
                    Using fs As FileStream = New FileStream(aa_load1, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                End If


                If chkload2.Checked = True Then
                    '■ローディング画像2の読み込み
                    Dim aa_load2 As String = txtpass_picturefolder.Text & "\loading2.bmp"
                    tplex_load2 = Cv2.ImRead(aa_load2, ImreadModes.Color)

                    chknow_load2.Checked = True

                ElseIf chkload2.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load2 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load2 = Cv2.ImRead(aa_load2, ImreadModes.Color)


                End If


                If chkload3.Checked = True Then
                    '■ローディング画像3の読み込み
                    Dim aa_load3 As String = txtpass_picturefolder.Text & "\loading3.bmp"
                    tplex_load3 = Cv2.ImRead(aa_load3, ImreadModes.Color)


                    chknow_load3.Checked = True

                ElseIf chkload3.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load3 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load3 = Cv2.ImRead(aa_load3, ImreadModes.Color)


                End If


                If chkload4.Checked = True Then
                    '■ローディング画像4の読み込み
                    Dim aa_load4 As String = txtpass_picturefolder.Text & "\loading4.bmp"
                    tplex_load4 = Cv2.ImRead(aa_load4, ImreadModes.Color)


                    chknow_load4.Checked = True

                ElseIf chkload4.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load4 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load4 = Cv2.ImRead(aa_load4, ImreadModes.Color)


                End If


                If chkload5.Checked = True Then
                    '■ローディング画像5の読み込み
                    Dim aa_load5 As String = txtpass_picturefolder.Text & "\loading5.bmp"
                    tplex_load5 = Cv2.ImRead(aa_load5, ImreadModes.Color)


                    chknow_load5.Checked = True

                ElseIf chkload5.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load5 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load5 = Cv2.ImRead(aa_load5, ImreadModes.Color)


                End If


                If chkload6.Checked = True Then
                    '■ローディング画像6の読み込み
                    Dim aa_load6 As String = txtpass_picturefolder.Text & "\loading6.bmp"
                    tplex_load6 = Cv2.ImRead(aa_load6, ImreadModes.Color)


                    chknow_load6.Checked = True

                ElseIf chkload6.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load6 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load6 = Cv2.ImRead(aa_load6, ImreadModes.Color)


                End If


                If chkload7.Checked = True Then
                    '■ローディング画像7の読み込み
                    Dim aa_load7 As String = txtpass_picturefolder.Text & "\loading7.bmp"
                    tplex_load7 = Cv2.ImRead(aa_load7, ImreadModes.Color)


                    chknow_load7.Checked = True

                ElseIf chkload7.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load7 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load7 = Cv2.ImRead(aa_load7, ImreadModes.Color)


                End If


                If chkload8.Checked = True Then
                    '■ローディング画像8の読み込み
                    Dim aa_load8 As String = txtpass_picturefolder.Text & "\loading8.bmp"
                    tplex_load8 = Cv2.ImRead(aa_load8, ImreadModes.Color)


                    chknow_load8.Checked = True

                ElseIf chkload8.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load8 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load8 = Cv2.ImRead(aa_load8, ImreadModes.Color)


                End If


                If chkload9.Checked = True Then
                    '■ローディング画像9の読み込み
                    Dim aa_load9 As String = txtpass_picturefolder.Text & "\loading9.bmp"
                    tplex_load9 = Cv2.ImRead(aa_load9, ImreadModes.Color)


                    chknow_load9.Checked = True

                ElseIf chkload9.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load9 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load9 = Cv2.ImRead(aa_load9, ImreadModes.Color)


                End If


                If chkload10.Checked = True Then
                    '■ローディング画像10の読み込み
                    Dim aa_load10 As String = txtpass_picturefolder.Text & "\loading10.bmp"
                    tplex_load10 = Cv2.ImRead(aa_load10, ImreadModes.Color)


                    chknow_load10.Checked = True

                ElseIf chkload10.Checked = False Then '適当な画像を読み込む。

                    '■最初の画像の読み込み
                    Dim aa_load10 As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex_load10 = Cv2.ImRead(aa_load10, ImreadModes.Color)

                End If

                cmbloadno.SelectedIndex = 0



            ElseIf chkcv_loadremover.Checked = False Then
                'ローディング関連のもの全て無効にする（停止時に有効にするように）
                chknow_load.Checked = False

                cmbloadno.Enabled = False


            End If

            '■テキストファイルの読み込み
            If chkshow_text.Checked = True Then
                '■最初のリッチテキストファイルを読み込む
                Textwindow.rtxt1.LoadFile(txtpass_rtf.Text & "/1.rtf", RichTextBoxStreamType.RichText)

            End If

            '■★Methodに番号を送る。どの方式で監視を行うか。
            cv_method = DGtable(send.Index, CInt(lblcv_lap.Text) - 0).Value '表の2行目のMethod値を取得。0/1:OpenCV、2/3:RGB、4/5:RGB(色の割合)


            '■■監視スタート■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
            '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
            onetimematching()
            '■モニタリング画面に現在の設定を表示
            If chkcv_monitor.Checked = True Then
                chknow_monitor.Checked = True


            End If


            '開始時はオフにしておき、1度splitした時に監視をする。
            If chkcv_resetonoff.Checked = True Then
                'chknow_reset.Checked = True　
                'async_reset_onoff = 1

            End If

            '■Load removerを始める。
            If chkcv_loadremover.Checked = True Then

                If chkload1.Checked = True Then
                    chknow_load1.Checked = True
                    async_load1_onoff = 1

                End If

                If chkload2.Checked = True Then
                    chknow_load2.Checked = True
                    async_load2_onoff = 1

                End If

                If chkload3.Checked = True Then
                    chknow_load3.Checked = True
                    async_load3_onoff = 1

                End If

                If chkload4.Checked = True Then
                    chknow_load4.Checked = True
                    async_load4_onoff = 1

                End If

                If chkload5.Checked = True Then
                    chknow_load5.Checked = True
                    async_load5_onoff = 1

                End If

                If chkload6.Checked = True Then
                    chknow_load6.Checked = True
                    async_load6_onoff = 1

                End If

                If chkload7.Checked = True Then
                    chknow_load7.Checked = True
                    async_load7_onoff = 1

                End If

                If chkload8.Checked = True Then
                    chknow_load8.Checked = True
                    async_load8_onoff = 1

                End If

                If chkload9.Checked = True Then
                    chknow_load9.Checked = True
                    async_load9_onoff = 1

                End If

                If chkload10.Checked = True Then
                    chknow_load10.Checked = True
                    async_load10_onoff = 1

                End If


            End If



            'ビデオ再生なし                    →ビデオプレーヤー非表示、タイマースタートする（今まで通り）
            'ビデオ再生あり、かつ手動スタート  →ビデオプレーヤー表示、タイマースタートしない
            'ビデオ再生あり、かつ自動スタート  →ビデオプレーヤー表示、タイマースタートする



            If chkshowvideo.Checked = False Then
                Console.WriteLine("ビデオ再生なし")

                cvtimer.Start()
                cvtimer_ash_hotkey.Start()

                txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            ElseIf chkshowvideo.Checked = True Then
                '■Videoplayer_wincapにサイズデータを渡す
                Videoplayer_wincap.sizex = numvideo_sizex.Value
                Videoplayer_wincap.sizey = numvideo_sizey.Value

                If chkvideo_manualstart.Checked = False Then
                    Console.WriteLine("ビデオ再生あり、かつ自動スタート")
                    cvtimer.Start()
                    cvtimer_ash_hotkey.Start()

                    txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

                ElseIf chkvideo_manualstart.Checked = True Then
                    Console.WriteLine("ビデオ再生あり、かつ手動スタート")
                    cvtimer_manualstart.Interval = New TimeSpan(0, 0, 0, 0, 16)
                    cvtimer_manualstart.Start()

                    txtstate.Text = "RTAスタート待機中"


                End If


            End If






            '===========================================================================================================

            TabControl1.SelectedIndex = 1 'タブ移動

            btnstartopencv.Enabled = False

            If chkmonitor_sizestate.Checked = True Then

            Else
                btncv_downsize.PerformClick()

            End If



        Catch ex As Exception

            MessageBox.Show(My.Resources.Message.msge05, messagebox_name)
            rtxtlog.AppendText(Now & " " & My.Resources.Message.msge05 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)
            '不明なエラー。設定→インフォメーションのログの内容を確認し、製作者にお知らせください。

        End Try



        '■表示がバグることがあるのでリフレッシュ
        Me.Refresh()




    End Sub

    Private async_split_onoff = 0
    Private async_reset_onoff = 0
    Private async_load1_onoff = 0
    Private async_load2_onoff = 0
    Private async_load3_onoff = 0
    Private async_load4_onoff = 0
    Private async_load5_onoff = 0
    Private async_load6_onoff = 0
    Private async_load7_onoff = 0
    Private async_load8_onoff = 0
    Private async_load9_onoff = 0
    Private async_load10_onoff = 0


    'ASH本体のホットキー
    Private Sub cvtimer_ash_hotkey_Tick(sender As Object, e As EventArgs) Handles cvtimer_ash_hotkey.Tick

        If GetKeyPress(numreset_ash.Value) Then

            Console.WriteLine("ASH_reset")

            btncv_first.PerformClick()
            timash_hotkey_sleep.Enabled = True
            cvtimer_ash_hotkey.Stop()

        ElseIf GetKeyPress(numundo_ash.Value) Then

            Console.WriteLine("ASH_undo")

            btncv_back.PerformClick()
            timash_hotkey_sleep.Enabled = True
            cvtimer_ash_hotkey.Stop()

        ElseIf GetKeyPress(numskip_ash.Value) Then

            Console.WriteLine("ASH_skip")

            btncv_forward.PerformClick()
            timash_hotkey_sleep.Enabled = True
            cvtimer_ash_hotkey.Stop()

        End If

    End Sub

    Private Sub timash_hotkey_sleep_Tick(sender As Object, e As EventArgs) Handles timash_hotkey_sleep.Tick

        cvtimer_ash_hotkey.Start()
        timash_hotkey_sleep.Enabled = False

    End Sub

    Private Async Sub Async_split()

        Await Task.Run(Sub()

                           Using res1 As New Mat(imgex.Width - tplex.Width + 1, imgex.Height - tplex.Height + 1, MatType.CV_32FC1)
                               Cv2.MatchTemplate(imgex, tplex, res1, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res1, minval_split, maxval_split, minloc_split, maxloc_split, Nothing)

                           End Using

                       End Sub)
        If dst_resize.IsDisposed = False Then
            dst_resize.Dispose()
        End If


    End Sub

    Private Async Sub Async_reset()

        Await Task.Run(Sub()

                           Using res2 As New Mat(imgex.Width - tplex_r.Width + 1, imgex.Height - tplex_r.Height + 1, MatType.CV_32FC1)
                               Cv2.MatchTemplate(imgex, tplex_r, res2, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res2, minval_reset, maxval_reset, minloc_reset, maxloc_reset, Nothing)

                           End Using

                       End Sub)

    End Sub

    Private Async Sub Async_load1()

        Await Task.Run(Sub()
                           Using res_load1 As New Mat(imgex.Width - tplex_load1.Width + 1, imgex.Height - tplex_load1.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load1, res_load1, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load1, minval_load1, maxval_load1, minloc_load1, maxloc_load1, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load2()

        Await Task.Run(Sub()
                           Using res_load2 As New Mat(imgex.Width - tplex_load2.Width + 1, imgex.Height - tplex_load2.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load2, res_load2, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load2, minval_load2, maxval_load2, minloc_load2, maxloc_load2, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load3()

        Await Task.Run(Sub()
                           Using res_load3 As New Mat(imgex.Width - tplex_load3.Width + 1, imgex.Height - tplex_load3.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load3, res_load3, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load3, minval_load3, maxval_load3, minloc_load3, maxloc_load3, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load4()

        Await Task.Run(Sub()
                           Using res_load4 As New Mat(imgex.Width - tplex_load4.Width + 1, imgex.Height - tplex_load4.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load4, res_load4, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load4, minval_load4, maxval_load4, minloc_load4, maxloc_load4, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load5()

        Await Task.Run(Sub()
                           Using res_load5 As New Mat(imgex.Width - tplex_load5.Width + 1, imgex.Height - tplex_load5.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load5, res_load5, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load5, minval_load5, maxval_load5, minloc_load5, maxloc_load5, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load6()

        Await Task.Run(Sub()
                           Using res_load6 As New Mat(imgex.Width - tplex_load6.Width + 1, imgex.Height - tplex_load6.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load6, res_load6, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load6, minval_load6, maxval_load6, minloc_load6, maxloc_load6, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load7()

        Await Task.Run(Sub()
                           Using res_load7 As New Mat(imgex.Width - tplex_load7.Width + 1, imgex.Height - tplex_load7.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load7, res_load7, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load7, minval_load7, maxval_load7, minloc_load7, maxloc_load7, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load8()

        Await Task.Run(Sub()
                           Using res_load8 As New Mat(imgex.Width - tplex_load8.Width + 1, imgex.Height - tplex_load8.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load8, res_load8, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load8, minval_load8, maxval_load8, minloc_load8, maxloc_load8, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load9()

        Await Task.Run(Sub()
                           Using res_load9 As New Mat(imgex.Width - tplex_load9.Width + 1, imgex.Height - tplex_load9.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load9, res_load9, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load9, minval_load9, maxval_load9, minloc_load9, maxloc_load9, Nothing)
                           End Using

                       End Sub)


    End Sub

    Private Async Sub Async_load10()

        Await Task.Run(Sub()
                           Using res_load10 As New Mat(imgex.Width - tplex_load10.Width + 1, imgex.Height - tplex_load10.Height + 1, MatType.CV_32FC1)

                               Cv2.MatchTemplate(imgex, tplex_load10, res_load10, TemplateMatchModes.CCoeffNormed)
                               Cv2.MinMaxLoc(res_load10, minval_load10, maxval_load10, minloc_load10, maxloc_load10, Nothing)
                           End Using


                       End Sub)


    End Sub

    '■マッチングRGB通常
    Private Sub RGBmethod()

        Dim number As Integer = lblcv_lap.Text

        Dim ltx As Integer = DGtable(posx.Index, number).Value
        Dim lty As Integer = DGtable(posy.Index, number).Value
        Dim rbx As Integer = DGtable(sizex.Index, number).Value
        Dim rby As Integer = DGtable(sizey.Index, number).Value

        txtcompikiti.Text = rbx * rby

        Dim comptimer As Integer = 0

        '■画像の一部を切り取って（トリミングして）表示する■■■■■■■■■■■■■■■■

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(rbx, rby)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        '画像ファイルのImageオブジェクトを作成する
        Dim img As Bitmap = picipl_cap.Image

        '切り取る部分の範囲を決定する。ここでは、位置(10,10)、大きさ100x100
        Dim srcRect As New Rectangle(ltx, lty, rbx, rby)
        '描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
        Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
        '画像の一部を描画する
        g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel)

        'PictureBox1に表示する
        'picipl_foranten.Image = canvas

        'Graphicsオブジェクトのリソースを解放する
        g.Dispose()




        '#CaptureのRGB取得を行う■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        Dim cap As Bitmap = canvas 'picipl_foranten.Image
        Dim pic As Bitmap = piccv_picture.Image

        '##CaptureのRGB取得の準備を行う###################################################################
        Dim pixelFormat_cap As PixelFormat = cap.PixelFormat
        Dim pixelSize_cap As Integer = Image.GetPixelFormatSize(pixelFormat_cap) / 8
        If pixelSize_cap < 3 OrElse 4 < pixelSize_cap Then
            Throw New ArgumentException(
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。",
                "img")
        End If

        'Bitmapをロックする
        Dim bmpData_cap As BitmapData =
            cap.LockBits(New Rectangle(0, 0, cap.Width, cap.Height),
                         ImageLockMode.ReadWrite, pixelFormat_cap)

        If bmpData_cap.Stride < 0 Then
            cap.UnlockBits(bmpData_cap)
            Throw New ArgumentException(
                "ボトムアップ形式のイメージには対応していません。",
                "img")
        End If


        '##PictureのRGB取得の準備を行う■■■■■■■■

        Dim pixelFormat_pic As PixelFormat = pic.PixelFormat
        Dim pixelSize_pic As Integer = 0.125 * Image.GetPixelFormatSize(pixelFormat_pic) ' / 8
        If pixelSize_pic < 3 OrElse 4 < pixelSize_pic Then
            Throw New ArgumentException(
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。",
                "img")
        End If


        'Bitmapをロックする
        Dim bmpData_pic As BitmapData =
            pic.LockBits(New Rectangle(0, 0, pic.Width, pic.Height),
                         ImageLockMode.ReadWrite, pixelFormat_pic)

        If bmpData_pic.Stride < 0 Then
            pic.UnlockBits(bmpData_pic)
            Throw New ArgumentException(
                "ボトムアップ形式のイメージには対応していません。",
                "img")
        End If


        '#######################################################################################################################
        '##################PGB取得の準備が終了。px毎の色情報を取得し、差を取る。################################################
        '#######################################################################################################################

        '範囲内の全ピクセルの色を取得する
        For y As Integer = 0 To rby - 1 'bmpData.Height - 1 
            For x As Integer = 0 To rbx - 1 'bmpData.Width - 1

                'キャプチャ画像の全ピクセルの色を取得する
                Dim adr_cap As IntPtr = bmpData_cap.Scan0
                Dim pos_cap As Integer = y * bmpData_cap.Stride + x * pixelSize_cap
                Dim cap_b As Byte = Marshal.ReadByte(adr_cap, pos_cap + 0)
                Dim cap_g As Byte = Marshal.ReadByte(adr_cap, pos_cap + 1)
                Dim cap_r As Byte = Marshal.ReadByte(adr_cap, pos_cap + 2) 'System.Runtime.InteropServices.

                'ピクチャ画像の全ピクセルの色を取得する
                Dim adr_pic As IntPtr = bmpData_pic.Scan0
                Dim pos_pic As Integer = y * bmpData_pic.Stride + x * pixelSize_pic
                Dim pic_b As Byte = Marshal.ReadByte(adr_pic, pos_pic + 0)
                Dim pic_g As Byte = Marshal.ReadByte(adr_pic, pos_pic + 1)
                Dim pic_r As Byte = Marshal.ReadByte(adr_pic, pos_pic + 2)


                '2枚の画像のRGBの差を取る
                Dim distR As Integer = Math.Abs(CInt(cap_r) - CInt(pic_r))
                Dim distG As Integer = Math.Abs(CInt(cap_g) - CInt(pic_g))
                Dim distB As Integer = Math.Abs(CInt(cap_b) - CInt(pic_b))


                '色差が少ない場合、カウントプラス

                If distR <= ColorAllowance And'DGtable(darkthr.Index, number).Value
                   distG <= ColorAllowance And
                   distB <= ColorAllowance Then

                    comptimer += 1

                End If

            Next

        Next


        'ロックを解除する
        cap.UnlockBits(bmpData_cap)
        pic.UnlockBits(bmpData_pic)


        '■テンプレートマッチングの結果を表示
        lblcv_nowmaxval.Text = Math.Round(100 * (comptimer / txtcompikiti.Text), 2, MidpointRounding.AwayFromZero) '100 * maxval
        'Console.WriteLine("RGBnormal " & comptimer & "/" & txtcompikiti.Text & ",   " & lblcv_nowmaxval.Text)
        If CDbl(lblcv_maxval.Text) < lblcv_nowmaxval.Text Then
            lblcv_maxval.Text = lblcv_nowmaxval.Text

        End If

        canvas.Dispose()


    End Sub

    Private color_lower_limit_r As Integer = 0
    Private color_lower_limit_g As Integer = 0
    Private color_lower_limit_b As Integer = 0

    Private color_upper_limit_r As Integer = 0
    Private color_upper_limit_g As Integer = 0
    Private color_upper_limit_b As Integer = 0

    Private ColorAllowance As Integer = 0

    '■マッチングRGB色の割合
    'テンプレート情報は不要。表のR,G,Bを参照する。
    Private Sub RGBmethod_color()

        Dim number As Integer = lblcv_lap.Text

        Dim ltx As Integer = DGtable(posx.Index, number).Value
        Dim lty As Integer = DGtable(posy.Index, number).Value
        Dim rbx As Integer = DGtable(sizex.Index, number).Value
        Dim rby As Integer = DGtable(sizey.Index, number).Value

        txtcompikiti.Text = rbx * rby

        Dim comptimer As Integer = 0

        '■画像の一部を切り取って（トリミングして）表示する■■■■■■■■■■■■■■■■

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(rbx, rby)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        '画像ファイルのImageオブジェクトを作成する
        Dim img As Bitmap = picipl_cap.Image

        '切り取る部分の範囲を決定する。ここでは、位置(10,10)、大きさ100x100
        Dim srcRect As New Rectangle(ltx, lty, rbx, rby)
        '描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
        Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
        '画像の一部を描画する
        g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel)

        'PictureBox1に表示する
        picipl_foranten.Image = canvas

        'Graphicsオブジェクトのリソースを解放する
        g.Dispose()



        '#CaptureのRGB取得を行う■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        Dim cap As Bitmap = picipl_foranten.Image

        '##CaptureのRGB取得の準備を行う###################################################################
        Dim pixelFormat_cap As PixelFormat = cap.PixelFormat
        Dim pixelSize_cap As Integer = Image.GetPixelFormatSize(pixelFormat_cap) / 8
        If pixelSize_cap < 3 OrElse 4 < pixelSize_cap Then
            Throw New ArgumentException(
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。",
                "img")
        End If

        'Bitmapをロックする
        Dim bmpData_cap As BitmapData =
            cap.LockBits(New Rectangle(0, 0, cap.Width, cap.Height),
                         ImageLockMode.ReadWrite, pixelFormat_cap)

        If bmpData_cap.Stride < 0 Then
            cap.UnlockBits(bmpData_cap)
            Throw New ArgumentException(
                "ボトムアップ形式のイメージには対応していません。",
                "img")
        End If


        '#######################################################################################################################
        '##################PGB取得の準備が終了。px毎の色情報を取得し、差を取る。################################################
        '#######################################################################################################################

        '範囲内の全ピクセルの色を取得する
        For y As Integer = 0 To rby - 1 'bmpData.Height - 1 
            For x As Integer = 0 To rbx - 1 'bmpData.Width - 1

                'キャプチャ画像の全ピクセルの色を取得する
                Dim adr_cap As IntPtr = bmpData_cap.Scan0
                Dim pos_cap As Integer = y * bmpData_cap.Stride + x * pixelSize_cap
                Dim cap_b As Byte = Marshal.ReadByte(adr_cap, pos_cap + 0)
                Dim cap_g As Byte = Marshal.ReadByte(adr_cap, pos_cap + 1)
                Dim cap_r As Byte = Marshal.ReadByte(adr_cap, pos_cap + 2) 'System.Runtime.InteropServices.

                '2枚の画像のRGBの差を取る
                Dim distR As Integer = Math.Abs(CInt(cap_r))
                Dim distG As Integer = Math.Abs(CInt(cap_g))
                Dim distB As Integer = Math.Abs(CInt(cap_b))


                '色差が少ない場合、カウントプラス
                If distR >= color_lower_limit_r And
                   distR <= color_upper_limit_r And
                   distG >= color_lower_limit_g And
                   distG <= color_upper_limit_g And
                   distB >= color_lower_limit_b And
                   distB <= color_upper_limit_b Then

                    comptimer += 1

                End If


            Next
        Next


        'ロックを解除する
        cap.UnlockBits(bmpData_cap)



        '■テンプレートマッチングの結果を表示
        lblcv_nowmaxval.Text = Math.Round(100 * (comptimer / txtcompikiti.Text), 2, MidpointRounding.AwayFromZero)
        'Console.WriteLine("RGBcolor " & comptimer & "/" & txtcompikiti.Text & ",   " & lblcv_nowmaxval.Text)

        If CDbl(lblcv_maxval.Text) < lblcv_nowmaxval.Text Then
            lblcv_maxval.Text = lblcv_nowmaxval.Text

        End If

        canvas.Dispose()


    End Sub


    '最初のラップだけホットキー（Livesplit）で取る。
    Private Sub cvtimer_manualstart_Tick(sender As Object, e As EventArgs) Handles cvtimer_manualstart.Tick
        'RTAスタートのみでいいはず
        If GetKeyPress(lblkeysforsend.Text) Then

            Console.WriteLine("play")

            Videoplayer.playtime = txtvideo_startat.Text

            Videoplayer.videoplay()

            '■監視タイマースタート
            cvtimer.Start()
            cvtimer_ash_hotkey.Start()
            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            cvtimer_manualstart.Stop()


            'Videoplayer.Axwmp1.playState = Videoplayer.WMPPlayState.wmppsPlaying

        Else

        End If




    End Sub

    '■監視中■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub OpenCV_Monitor_Tick(sender As Object, e As EventArgs) Handles cvtimer.Tick

        'Try

        '■プレビュー画面の更新★
        capturecv.Read(frame) 'NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(Me.capturecv.CvPtr, Me.frame.CvPtr)

        If chkcv_crop.Checked = True Then

            '■先にクロップをする。
            dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

            Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

            dst_cropRect.CopyTo(dst_cropped)

            '■リサイズ
            dst_resize = New Mat()
            Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

            picipl_cap.ImageIpl = dst_resize
            imgex = dst_resize

            dst_cropRect.Dispose()
            dst_cropped.Dispose()
            'dst_resize.Dispose()はAsync内


        ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

            If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                picipl_cap.ImageIpl = frame
                imgex = frame


            Else

                dst_resize = New Mat()
                Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                picipl_cap.ImageIpl = dst_resize
                imgex = dst_resize
                'dst_resize.Dispose()はAsync内


            End If

        End If




        'テンプレートマッチングのみ非同期に行う。チェックが付いているもののみマッチングを行う。
        If async_split_onoff = 1 Then

            If cv_method = 0 Or cv_method = 1 Then
                Async_split()

            ElseIf cv_method = 2 Or cv_method = 3 Then
                RGBmethod()

            ElseIf cv_method = 4 Or cv_method = 5 Then
                RGBmethod_color()

            End If

        End If


        If async_reset_onoff = 1 Then
            Async_reset()
        End If

        If async_load1_onoff = 1 Then
            Async_load1()
        End If

        If async_load2_onoff = 1 Then
            Async_load2()
        End If

        If async_load3_onoff = 1 Then
            Async_load3()
        End If

        If async_load4_onoff = 1 Then
            Async_load4()
        End If

        If async_load5_onoff = 1 Then
            Async_load5()
        End If

        If async_load6_onoff = 1 Then
            Async_load6()
        End If

        If async_load7_onoff = 1 Then
            Async_load7()
        End If

        If async_load8_onoff = 1 Then
            Async_load8()
        End If

        If async_load9_onoff = 1 Then
            Async_load9()
        End If

        If async_load10_onoff = 1 Then
            Async_load10()
        End If



        '■Videoplayer_wincapに別タイマーで稼働させている。パフォーマンスが悪いようならこちらに書く★♥
        'Videoplayer_wincap.picVideo.Image = Videoplayer_wincap.bmp
        'Videoplayer_wincap.ltx = Videoplayer.Location.X
        'Videoplayer_wincap.lty = Videoplayer.Location.Y + Videoplayer.lbltitlebar.Height

        Dim number As Integer = lblcv_lap.Text


        '■テンプレートマッチング（スプリット）
        If chknow_monitor.Checked = True Then

            If async_split_onoff = 1 Then
                If cv_method = 0 Or cv_method = 1 Then

                    '■テンプレートマッチングの結果を表示
                    If Not maxval_split = 1 Then
                        lblcv_nowmaxval.Text = Math.Round(100 * maxval_split, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval.Text) < 100 * maxval_split Then
                            lblcv_maxval.Text = Math.Round(100 * maxval_split, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                End If



                '■マッチングされた。小数点以下まで加味。
                If CDbl(lblcv_maxval.Text) > CDbl(txtcv_ikiti.Text) Then

                    '一致した場所が指定範囲内にあるかどうか
                    If maxloc_split.X < DGtable(ltx.Index, number).Value Or
                       maxloc_split.X + tplex.Width > DGtable(rbx.Index, number).Value Or
                       maxloc_split.Y < DGtable(lty.Index, number).Value Or
                       maxloc_split.Y + tplex.Height > DGtable(rby.Index, number).Value Then

                        lblcv_maxval.Text = 0

                        Exit Sub

                    End If

                    Console.WriteLine("Match")
                    reflesh_img = 1

                    '■一致した場所に四角を描画
                    Dim g As Graphics = picipl_cap.CreateGraphics
                    Dim DrawPen As New Pen(Color.Red, 3)
                    g.DrawRectangle(DrawPen, maxloc_split.X, maxloc_split.Y, tplex.Width, tplex.Height)

                    '■プレビュー画面の更新
                    capturecv.Read(frame)

                    If chkcv_crop.Checked = True Then

                        '■先にクロップをする。
                        dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

                        Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

                        dst_cropRect.CopyTo(dst_cropped)

                        '■リサイズ
                        dst_resize = New Mat()
                        Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                        picipl_cap.ImageIpl = dst_resize
                        imgex = dst_resize

                        dst_cropRect.Dispose()
                        dst_cropped.Dispose()
                        'dst_resize.Dispose()


                    ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

                        If numcv_sizex.Value = numcrop_resolution_x.Value And
                           numcv_sizey.Value = numcrop_resolution_y.Value Then

                            picipl_cap.ImageIpl = frame
                            imgex = frame

                        Else

                            dst_resize = New Mat()
                            Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                            picipl_cap.ImageIpl = dst_resize
                            imgex = dst_resize
                            ' dst_resize.Dispose()


                        End If

                    End If



                    '■split用タイマー停止
                    async_split_onoff = 0


                    'txtcv_result_posx.Text = maxloc_split.X
                    'txtcv_result_posy.Text = maxloc_split.Y
                    'txtcv_result_sizex.Text = tplex.Width
                    'txtcv_result_sizey.Text = tplex.Height


                    '■Start②  監視場所が同一の場合______________________________________________________________________________________________________________
                    If chkcv_loop.Checked = True Then

                        lbllooptrigger.Text = 1

                        lblcv_lap.Text = 1 '常に最初の画像を表示

                        If DGtable(send.Index, CInt(lblcv_lap.Text - 0)).Value = 0 Or
                           DGtable(send.Index, CInt(lblcv_lap.Text - 0)).Value = 2 Or
                           DGtable(send.Index, CInt(lblcv_lap.Text - 0)).Value = 4 Then 'ホットキー送信をスルーする

                            txtstate.Text = My.Resources.Message.msg31 '"待機中"

                            msec = CDbl(timeGetTime)

                            cvsleep_split.Start()
                            lblcv_sendview.Visible = True
                            lblsleeptime.Visible = True




                        ElseIf DGtable(send.Index, CInt(lblcv_lap.Text - 0)).Value = 1 Or
                               DGtable(send.Index, CInt(lblcv_lap.Text - 0)).Value = 3 Or
                               DGtable(send.Index, CInt(lblcv_lap.Text - 0)).Value = 5 Then 'ホットキーを送信する。


                            If DGtable(timing.Index, CInt(lblcv_lap.Text - 0)).Value = 4 Then
                                txtstate.Text = My.Resources.Message.msg32 '"場面転換待機中"

                                cvtimer_changergb.Start()



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 0)).Value = 3 Then
                                txtstate.Text = My.Resources.Message.msg32 '"場面転換待機中"

                                cvtimer_change.Start()



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 0)).Value = 2 Then
                                txtstate.Text = My.Resources.Message.msg33 '"暗転待機中"


                                timcv_anten.Enabled = True
                                picipl_foranten.Size = New Drawing.Size(DGtable(sizex.Index, CInt(lblcv_lap.Text - 0)).Value, DGtable(sizey.Index, CInt(lblcv_lap.Text - 0)).Value)
                                timcv_forantencap.Enabled = True
                                timcv_forantencap.Interval = numcv_interval.Value



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 0)).Value = 1 Then
                                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                                msec = CDbl(timeGetTime)
                                timcv_perfectanten.Enabled = True



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 0)).Value = 0 Then

                                txtstate.Text = My.Resources.Message.msg31 '"待機中"

                                allkeysend()

                                msec = CDbl(timeGetTime)

                                cvsleep_split.Start()
                                lblcv_sendview.Visible = True
                                lblsleeptime.Visible = True

                                '♥
                                '■Videoplayerのシーク
                                If chkshowvideo.Checked = True Then

                                    If chkvideo_autoseek.Checked = True Then

                                        Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 0)).Value

                                        'Videoseekの値が"-1"ならば、シークなど何の操作もしない
                                        If Videoplayer.playtime = -1 Then

                                        Else

                                            Videoplayer.videoplay()

                                        End If


                                    Else '最初の反応時にのみplayする

                                        If numnowloop.Value = 0 Then
                                            Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text)).Value
                                            Videoplayer.videoplay()

                                        End If

                                    End If

                                End If

                            End If

                        End If




                        '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
                        'Middle②  監視場所が異なる場合■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■_________________________________________________________________________

                    ElseIf chkcv_loop.Checked = False Then

                        lblreload_graph.Text = 1

                        number += 1
                        lblcv_lap.Text += 1


                        'カラムS＝0の時、スルーする
                        If DGtable(send.Index, CInt(lblcv_lap.Text - 1)).Value = 0 Or
                           DGtable(send.Index, CInt(lblcv_lap.Text - 1)).Value = 2 Or
                           DGtable(send.Index, CInt(lblcv_lap.Text - 1)).Value = 4 Then 'ホットキー送信をスルーする

                            '■画像ファイルが存在するかどうかのチェック。■■■■■■■■■■■■■
                            If System.IO.File.Exists(txtpass_picturefolder.Text & "\" & number & ".bmp") Then
                                txtstate.Text = My.Resources.Message.msg31 '"待機中"

                                msec = CDbl(timeGetTime)

                                cvsleep_split.Start()
                                lblcv_sendview.Visible = True
                                lblsleeptime.Visible = True



                            Else '画像ファイルが存在しない＝終わり

                                'lblcv_lap.Text = 1★
                                show_finish()


                            End If




                        ElseIf DGtable(send.Index, CInt(lblcv_lap.Text - 1)).Value = 1 Or
                               DGtable(send.Index, CInt(lblcv_lap.Text - 1)).Value = 3 Or
                               DGtable(send.Index, CInt(lblcv_lap.Text - 1)).Value = 5 Then 'ホットキーを送信する



                            If DGtable(timing.Index, CInt(lblcv_lap.Text - 1)).Value = 4 Then
                                txtstate.Text = My.Resources.Message.msg32 '"場面転換待機中"

                                cvtimer_changergb.Start()



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 1)).Value = 3 Then
                                txtstate.Text = My.Resources.Message.msg32 '"場面転換待機中"

                                cvtimer_change.Start()



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 1)).Value = 2 Then 'モニタリングタブの右上が変わらない内に処理をする。■■■■■■■■■■

                                txtstate.Text = My.Resources.Message.msg33 '"暗転待機中"

                                timcv_anten.Enabled = True
                                picipl_foranten.Size = New Drawing.Size(DGtable(sizex.Index, CInt(lblcv_lap.Text - 1)).Value, DGtable(sizey.Index, CInt(lblcv_lap.Text - 1)).Value)

                                timcv_forantencap.Interval = numcv_interval.Value
                                timcv_forantencap.Enabled = True



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 1)).Value = 1 Then
                                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                                msec = CDbl(timeGetTime)
                                timcv_perfectanten.Enabled = True



                            ElseIf DGtable(timing.Index, CInt(lblcv_lap.Text - 1)).Value = 0 Then
                                txtstate.Text = My.Resources.Message.msg31 '"待機中"

                                '■StartA  ファイルが存在しているかどうか確認する■■■■■■
                                If System.IO.File.Exists(txtpass_picturefolder.Text & "\" & number & ".bmp") Then

                                    allkeysend()

                                    msec = CDbl(timeGetTime)

                                    cvsleep_split.Start()
                                    lblcv_sendview.Visible = True
                                    lblsleeptime.Visible = True

                                    '■Videoplayerのシーク★
                                    If chkshowvideo.Checked = True Then

                                        If chkvideo_autoseek.Checked = True Then

                                            Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 1)).Value

                                            'Videoseekの値が"-1"ならば、シークなど何の操作もしない
                                            If Videoplayer.playtime = -1 Then

                                            Else
                                                Videoplayer.videoplay()

                                            End If


                                        Else '最初の反応時にのみplayする

                                            If lblcv_lap.Text = 2 Then
                                                Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 1)).Value
                                                Videoplayer.videoplay()

                                            End If

                                        End If

                                    End If



                                Else ' ファイルが存在しない

                                    'lblcv_lap.Text = 1★
                                    allkeysend()

                                    If lblreload_graph.Text = 1 Then

                                        '■グラフ更新
                                        graph_split()

                                        lblreload_graph.Text = 0


                                    End If

                                    show_finish()


                                End If '■■■■■■

                            End If 'EndA■■■■■■■■■■

                        End If

                    End If







                    '■結果の初期化
                    lblcv_maxval_reset.Text = 0
                    lblcv_nowmaxval_reset.Text = 0

                    chknow_monitor.Checked = False

                    If chkcv_resetonoff.Checked = True Then

                        chknow_reset.Checked = True
                        onetimematching_reset() '♥'これを書かないと、前のデータが何故か残って誤判定となる。


                    End If

                End If

            End If

        End If





        '■テンプレートマッチング（リセット）
        If chknow_reset.Checked = True Then
            If async_reset_onoff = 1 Then '★

                '■リセット結果表示
                If Not maxval_reset = 1 Then
                    lblcv_nowmaxval_reset.Text = Math.Round(100 * maxval_reset, 2, MidpointRounding.AwayFromZero) '100 * maxval
                    If CDbl(lblcv_maxval_reset.Text) < 100 * maxval_reset Then
                        lblcv_maxval_reset.Text = Math.Round(100 * maxval_reset, 2, MidpointRounding.AwayFromZero) '100 * maxval
                    End If
                End If



                '■リセットが反応した。■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
                If CDbl(lblcv_maxval_reset.Text) > CDbl(txtcv_ikiti_reset.Text) Then


                    '■一致した場所が指定範囲内にあるかどうか

                    If maxloc_reset.X < DGtable(ltx.Index, 0).Value Or
                       maxloc_reset.X + tplex_r.Width > DGtable(rbx.Index, 0).Value Or
                       maxloc_reset.Y < DGtable(lty.Index, 0).Value Or
                       maxloc_reset.Y + tplex_r.Height > DGtable(rby.Index, 0).Value Then

                        lblcv_maxval_reset.Text = 0

                        Exit Sub


                    End If

                    '■グラフ更新
                    graph_reset()

                    lblcv_lap.Text = 1
                    number = 1
                    txtstate.Text = My.Resources.Message.msg30 '"画像認識中"


                    lblcv_sendview.Visible = False
                    lblsleeptime.Visible = False
                    cvsleep_split.Stop()

                    lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value '表の１列目の文字を表示
                    txtcv_ikiti.Text = DGtable(rate.Index, CInt(lblcv_lap.Text)).Value

                    txtcv_color_r.Text = DGtable(color_r.Index, CInt(lblcv_lap.Text)).Value
                    txtcv_color_g.Text = DGtable(color_g.Index, CInt(lblcv_lap.Text)).Value
                    txtcv_color_b.Text = DGtable(color_b.Index, CInt(lblcv_lap.Text)).Value

                    color_lower_limit_r = txtcv_color_r.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                    color_lower_limit_g = txtcv_color_g.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                    color_lower_limit_b = txtcv_color_b.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

                    color_upper_limit_r = txtcv_color_r.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                    color_upper_limit_g = txtcv_color_g.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                    color_upper_limit_b = txtcv_color_b.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

                    ColorAllowance = DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

                    '■★Methodに番号を送る。どの方式で監視を行うか。
                    cv_method = DGtable(send.Index, CInt(lblcv_lap.Text)).Value '表の2行目のMethod値を取得。0/1:OpenCV、2/3:RGB、4/5:RGB(色の割合)


                    lblcv_maxval_reset.Text = 0
                    lblcv_nowmaxval_reset.Text = 0


                    '■プレビュー画面の更新
                    'NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(Me.capturecv.CvPtr, Me.frame.CvPtr)
                    capturecv.Read(frame)

                    If chkcv_crop.Checked = True Then

                        '■先にクロップをする。
                        dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

                        Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

                        dst_cropRect.CopyTo(dst_cropped)

                        '■リサイズ
                        dst_resize = New Mat()
                        Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                        picipl_cap.ImageIpl = dst_resize
                        imgex = dst_resize

                        dst_cropRect.Dispose()
                        dst_cropped.Dispose()
                        'dst_resize.Dispose()


                    ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

                        If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                            picipl_cap.ImageIpl = frame
                            imgex = frame


                        Else

                            dst_resize = New Mat()
                            Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                            picipl_cap.ImageIpl = dst_resize
                            imgex = dst_resize

                            'dst_resize.Dispose()


                        End If

                    End If



                    'Picture画像を"1.bmp"に戻す■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■！

                    '■テンプレート画像の更新
                    Dim aa As String = txtpass_picturefolder.Text & "\" & 1 & ".bmp"
                    tplex = Cv2.ImRead(aa, ImreadModes.Color)

                    '■ローディング画像の読み込み（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_picture.Image = Image.FromStream(fs)
                    End Using

                    '■最初のリッチテキストファイルを表示
                    If chkshow_text.Checked = True Then
                        Textwindow.rtxt1.LoadFile(txtpass_rtf.Text & "/1.rtf", RichTextBoxStreamType.RichText)
                    End If


                    '■結果の初期化
                    lblcv_maxval.Text = 0
                    lblcv_maxval_reset.Text = 0

                    '■リセットキー送信

                    allkeysend_reset()

                    chknow_reset.Checked = False
                    async_reset_onoff = 0 '★
                    async_split_onoff = 1 '★

                    If chkcv_monitor.Checked = True Then

                        chknow_monitor.Checked = True


                    End If

                    If chkcv_loadremover.Checked = True Then

                        If chkload1.Checked = True Then
                            chknow_load1.Checked = True

                        End If

                        If chkload2.Checked = True Then
                            chknow_load2.Checked = True

                        End If

                        If chkload3.Checked = True Then
                            chknow_load3.Checked = True

                        End If

                        If chkload4.Checked = True Then
                            chknow_load4.Checked = True

                        End If

                        If chkload5.Checked = True Then
                            chknow_load5.Checked = True

                        End If

                        If chkload6.Checked = True Then
                            chknow_load6.Checked = True

                        End If

                        If chkload7.Checked = True Then
                            chknow_load7.Checked = True

                        End If

                        If chkload8.Checked = True Then
                            chknow_load8.Checked = True

                        End If

                        If chkload9.Checked = True Then
                            chknow_load9.Checked = True

                        End If

                        If chkload10.Checked = True Then
                            chknow_load10.Checked = True

                        End If


                    End If


                    '■Videoplayerの停止
                    If chkshowvideo.Checked = True Then

                        Videoplayer.videostop()

                        If chkvideo_manualstart.Checked = True Then '再び手動スタートに
                            txtstate.Text = "RTAスタート待機中"
                            cvtimer_manualstart.Start()
                            cvtimer.Stop()

                        End If

                    End If


                End If

            End If

        End If



        '■テンプレートマッチング（ロード）
        If chkcv_loadremover.Checked = True Then

            '■テンプレートマッチング（ロード1）
            If chknow_load1.Checked = True Then
                If async_load1_onoff = 1 Then
                    If Not maxval_load1 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load1.Text = Math.Round(100 * maxval_load1, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load1.Text) < 100 * maxval_load1 Then
                            lblcv_maxval_load1.Text = Math.Round(100 * maxval_load1, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If

                    End If


                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load1.Text) > CDbl(txtcv_ikiti_load1.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover1.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0



                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If


            End If

            '■テンプレートマッチング（ロード2）
            If chknow_load2.Checked = True Then
                If async_load2_onoff = 1 Then
                    If Not maxval_load2 = 1 Then


                        '■ローディング結果を表示
                        lblcv_nowmaxval_load2.Text = Math.Round(100 * maxval_load2, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load2.Text) < 100 * maxval_load2 Then
                            lblcv_maxval_load2.Text = Math.Round(100 * maxval_load2, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load2.Text) > CDbl(txtcv_ikiti_load2.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover2.Start()

                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。

                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0


                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If

            End If

            '■テンプレートマッチング（ロード3）
            If chknow_load3.Checked = True Then
                If async_load3_onoff = 1 Then
                    If Not maxval_load3 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load3.Text = Math.Round(100 * maxval_load3, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load3.Text) < 100 * maxval_load3 Then
                            lblcv_maxval_load3.Text = Math.Round(100 * maxval_load3, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load3.Text) > CDbl(txtcv_ikiti_load3.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover3.Start()

                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0

                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If

            End If

            '■テンプレートマッチング（ロード4）
            If chknow_load4.Checked = True Then
                If async_load4_onoff = 1 Then
                    If Not maxval_load4 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load4.Text = Math.Round(100 * maxval_load4, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load4.Text) < 100 * maxval_load4 Then
                            lblcv_maxval_load4.Text = Math.Round(100 * maxval_load4, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load4.Text) > CDbl(txtcv_ikiti_load4.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover4.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0

                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If

            End If

            '■テンプレートマッチング（ロード5）
            If chknow_load5.Checked = True Then
                If async_load5_onoff = 1 Then
                    If Not maxval_load5 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load5.Text = Math.Round(100 * maxval_load5, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load5.Text) < 100 * maxval_load5 Then
                            lblcv_maxval_load5.Text = Math.Round(100 * maxval_load5, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load5.Text) > CDbl(txtcv_ikiti_load5.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover5.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0

                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If

            End If

            '■テンプレートマッチング（ロード6）
            If chknow_load6.Checked = True Then
                If async_load6_onoff = 1 Then
                    If Not maxval_load6 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load6.Text = Math.Round(100 * maxval_load6, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load6.Text) < 100 * maxval_load6 Then
                            lblcv_maxval_load6.Text = Math.Round(100 * maxval_load6, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load6.Text) > CDbl(txtcv_ikiti_load6.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover6.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0

                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If

            End If

            '■テンプレートマッチング（ロード7）
            If chknow_load7.Checked = True Then
                If async_load7_onoff = 1 Then
                    If Not maxval_load7 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load7.Text = Math.Round(100 * maxval_load7, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load7.Text) < 100 * maxval_load7 Then
                            lblcv_maxval_load7.Text = Math.Round(100 * maxval_load7, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load7.Text) > CDbl(txtcv_ikiti_load7.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover7.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0

                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If

            End If

            '■テンプレートマッチング（ロード8）
            If chknow_load8.Checked = True Then
                If async_load8_onoff = 1 Then
                    If Not maxval_load8 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load8.Text = Math.Round(100 * maxval_load8, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load8.Text) < 100 * maxval_load8 Then
                            lblcv_maxval_load8.Text = Math.Round(100 * maxval_load8, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load8.Text) > CDbl(txtcv_ikiti_load8.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover8.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0

                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If


            End If

            '■テンプレートマッチング（ロード9）
            If chknow_load9.Checked = True Then
                If async_load9_onoff = 1 Then
                    If Not maxval_load9 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load9.Text = Math.Round(100 * maxval_load9, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load9.Text) < 100 * maxval_load9 Then
                            lblcv_maxval_load9.Text = Math.Round(100 * maxval_load9, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load9.Text) > CDbl(txtcv_ikiti_load9.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover9.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False

                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0

                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If

                End If

            End If

            '■テンプレートマッチング（ロード10）
            If chknow_load10.Checked = True Then
                If async_load10_onoff = 1 Then
                    If Not maxval_load10 = 1 Then

                        '■ローディング結果を表示
                        lblcv_nowmaxval_load10.Text = Math.Round(100 * maxval_load10, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        If CDbl(lblcv_maxval_load10.Text) < 100 * maxval_load10 Then
                            lblcv_maxval_load10.Text = Math.Round(100 * maxval_load10, 2, MidpointRounding.AwayFromZero) '100 * maxval

                        End If
                    End If

                    '■ローディングがマッチングされた。
                    If CDbl(lblcv_maxval_load10.Text) > CDbl(txtcv_ikiti_load10.Text) Then

                        Console.WriteLine("Show loading")


                        allkeysend_load() '[play→sleep]pauseを送る

                        txtstate.Text = My.Resources.Message.msg39 '"ロード中"
                        lblloading.Text = "loading"

                        msec_pause = CDbl(timeGetTime)

                        cvtimer_loadremover10.Start()


                        'ロード除去が1つ働いている時、他のLoading監視をすべて止める。
                        chknow_load1.Checked = False
                        chknow_load2.Checked = False
                        chknow_load3.Checked = False
                        chknow_load4.Checked = False
                        chknow_load5.Checked = False
                        chknow_load6.Checked = False
                        chknow_load7.Checked = False
                        chknow_load8.Checked = False
                        chknow_load9.Checked = False
                        chknow_load10.Checked = False


                        async_load1_onoff = 0
                        async_load2_onoff = 0
                        async_load3_onoff = 0
                        async_load4_onoff = 0
                        async_load5_onoff = 0
                        async_load6_onoff = 0
                        async_load7_onoff = 0
                        async_load8_onoff = 0
                        async_load9_onoff = 0
                        async_load10_onoff = 0


                        If chkcv_resetonoff.Checked = True Then

                            chknow_reset.Checked = True


                        End If

                    End If


                End If

            End If



            If cmbloadno.SelectedIndex = 1 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load1.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load1.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load1.Text

            ElseIf cmbloadno.SelectedIndex = 2 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load2.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load2.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load2.Text

            ElseIf cmbloadno.SelectedIndex = 3 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load3.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load3.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load3.Text

            ElseIf cmbloadno.SelectedIndex = 4 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load4.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load4.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load4.Text

            ElseIf cmbloadno.SelectedIndex = 5 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load5.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load5.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load5.Text

            ElseIf cmbloadno.SelectedIndex = 6 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load6.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load6.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load6.Text

            ElseIf cmbloadno.SelectedIndex = 7 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load7.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load7.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load7.Text

            ElseIf cmbloadno.SelectedIndex = 8 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load8.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load8.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load8.Text

            ElseIf cmbloadno.SelectedIndex = 9 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load9.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load9.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load9.Text

            ElseIf cmbloadno.SelectedIndex = 10 - 1 Then
                lblcv_maxval_load.Text = lblcv_maxval_load10.Text
                lblcv_nowmaxval_load.Text = lblcv_nowmaxval_load10.Text
                txtcv_ikiti_load.Text = txtcv_ikiti_load10.Text

            End If


        End If



        'Catch ex As Exception
        '    MessageBox.Show(My.Resources.Message.msg46, messagebox_name) '仮想カメラの接続エラー。仮想カメラの再接続や本体の再起動を試してみて下さい。
        '    rtxtlog.AppendText(Now & " " & My.Resources.Message.msg46 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        '    btncv_stop.PerformClick()

        'End Try



    End Sub


    Private Sub cmbloadno_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbloadno.SelectedIndexChanged

        Try


            If chkcv_loadremover.Checked = True Then

                If cmbloadno.SelectedIndex = 1 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading1.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using


                ElseIf cmbloadno.SelectedIndex = 2 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading2.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 3 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading3.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 4 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading4.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 5 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading5.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 6 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading6.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 7 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading7.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 8 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading8.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 9 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading9.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                ElseIf cmbloadno.SelectedIndex = 10 - 1 Then

                    '■画像の表示
                    Dim aa As String = txtpass_picturefolder.Text & "\loading10.bmp"

                    '■画像の表示（表示用）
                    Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                        piccv_load.Image = Image.FromStream(fs)
                    End Using

                End If

            End If

        Catch ex As Exception
            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try

    End Sub

    Private reflesh_img As Integer = 0
    '■Sleep(スプリット)■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub OpenCV_Sleep_split_Tick(sender As Object, e As EventArgs) Handles cvsleep_split.Tick
        Try


            If reflesh_img = 1 Then
                reflesh_img = 0
                '■テンプレート画像の更新
                Dim aa As String = txtpass_picturefolder.Text & "\" & lblcv_lap.Text & ".bmp"
                tplex = Cv2.ImRead(aa, ImreadModes.Color)

                '■テンプレート画像の更新（表示用）
                Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                    piccv_picture.Image = Image.FromStream(fs)
                End Using


                '■リッチテキストファイルの更新
                If chkshow_text.Checked = True Then
                    Textwindow.rtxt1.LoadFile(txtpass_rtf.Text & "/" & lblcv_lap.Text & ".rtf", RichTextBoxStreamType.RichText)
                End If

            End If



            If lblreload_graph.Text = 1 Then

                '■グラフ更新
                graph_split()

                lblreload_graph.Text = 0


            End If

            'ループカウント用
            If lbllooptrigger.Text = 1 Then

                numnowloop.Value += 1
                lblloopcount.Text = numnowloop.Value & "/" & numloopcount.Value
                lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value & " [" & lblloopcount.Text & "]"

                lbllooptrigger.Text = 0

                If numnowloop.Value = numloopcount.Value Then

                    show_finish()
                    'btncv_stop.PerformClick()
                    'MessageBox.Show("指定回数ループしました。")
                End If
            End If

            txtstate.Text = My.Resources.Message.msg31 '"待機中"

            Dim sleepcount As Integer = lblcv_sleepcount.Text

            lblsleeptime.Text = (sleepcount + (msec - timeGetTime) * 0.001).ToString("0.0")



            If lblsleeptime.Text <= 0 Then

                Dim number As Integer = lblcv_lap.Text

                '■★Methodに番号を送る。どの方式で監視を行うか。
                cv_method = DGtable(send.Index, CInt(lblcv_lap.Text) - 0).Value '表の2行目のMethod値を取得。0/1:OpenCV、2/3:RGB、4/5:RGB(色の割合)


                If chkcv_loop.Checked = False Then
                    lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value

                ElseIf chkcv_loop.Checked = True Then

                    lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value & " [" & lblloopcount.Text & "]"


                End If


                txtcv_ikiti.Text = DGtable(rate.Index, CInt(lblcv_lap.Text)).Value
                lblcv_sleepcount.Text = DGtable(sleep.Index, CInt(lblcv_lap.Text)).Value

                txtcv_color_r.Text = DGtable(color_r.Index, CInt(lblcv_lap.Text)).Value
                txtcv_color_g.Text = DGtable(color_g.Index, CInt(lblcv_lap.Text)).Value
                txtcv_color_b.Text = DGtable(color_b.Index, CInt(lblcv_lap.Text)).Value

                color_lower_limit_r = txtcv_color_r.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                color_lower_limit_g = txtcv_color_g.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                color_lower_limit_b = txtcv_color_b.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

                color_upper_limit_r = txtcv_color_r.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                color_upper_limit_g = txtcv_color_g.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
                color_upper_limit_b = txtcv_color_b.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

                ColorAllowance = DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value



                lblcv_maxval.Text = 0
                lblcv_maxval_reset.Text = 0

                txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

                '■プレビュー画面の更新
                capturecv.Read(frame)

                If chkcv_crop.Checked = True Then

                    '■先にクロップをする。
                    dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

                    Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

                    dst_cropRect.CopyTo(dst_cropped)

                    '■リサイズ
                    dst_resize = New Mat()
                    Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                    picipl_cap.ImageIpl = dst_resize
                    imgex = dst_resize

                    dst_cropRect.Dispose()
                    dst_cropped.Dispose()
                    'dst_resize.Dispose()


                ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

                    If numcv_sizex.Value = numcrop_resolution_x.Value And
                       numcv_sizey.Value = numcrop_resolution_y.Value Then

                        picipl_cap.ImageIpl = frame
                        imgex = frame


                    Else

                        dst_resize = New Mat()
                        Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                        picipl_cap.ImageIpl = dst_resize
                        imgex = dst_resize

                        'dst_resize.Dispose()


                    End If

                End If



                onetimematching()

                '===========================================================================================================


                lblcv_sendview.Visible = False
                lblsleeptime.Visible = False
                chknow_monitor.Checked = True

                cvsleep_split.Stop()



            End If

        Catch ex As Exception
            show_finish()
            MessageBox.Show(ex.Message, messagebox_name)
            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try

    End Sub

    Private Sub Getimgex()
        '■プレビュー画面の更新
        capturecv.Read(frame)

        If chkcv_crop.Checked = True Then

            '■先にクロップをする。
            dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

            Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

            dst_cropRect.CopyTo(dst_cropped)

            '■リサイズ
            dst_resize = New Mat()
            Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

            picipl_cap.ImageIpl = dst_resize
            imgex = dst_resize

            dst_cropRect.Dispose()
            dst_cropped.Dispose()
            'dst_resize.Dispose()


        ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

            If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                picipl_cap.ImageIpl = frame
                imgex = frame


            Else

                dst_resize = New Mat()
                Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                picipl_cap.ImageIpl = dst_resize
                imgex = dst_resize

                'dst_resize.Dispose()


            End If

        End If
    End Sub

    Private Sub onetimematching() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）

        '■プレビュー画面の更新
        Getimgex()

        Using res1 As New Mat(imgex.Width - tplex.Width + 1, imgex.Height - tplex.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex, res1, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res1, minval_split, maxval_split, minloc_split, maxloc_split, Nothing)

        End Using

        async_split_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_reset() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）

        Getimgex()


        Using res2 As New Mat(imgex.Width - tplex_r.Width + 1, imgex.Height - tplex_r.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_r, res2, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res2, minval_reset, maxval_reset, minloc_reset, maxloc_reset, Nothing)

        End Using

        async_reset_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load1() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load1 As New Mat(imgex.Width - tplex_load1.Width + 1, imgex.Height - tplex_load1.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load1, res_load1, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load1, minval_load1, maxval_load1, minloc_load1, maxloc_load1, Nothing)
        End Using

        async_load1_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load2() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load2 As New Mat(imgex.Width - tplex_load2.Width + 1, imgex.Height - tplex_load2.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load2, res_load2, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load2, minval_load2, maxval_load2, minloc_load2, maxloc_load2, Nothing)
        End Using

        async_load2_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load3() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load3 As New Mat(imgex.Width - tplex_load3.Width + 1, imgex.Height - tplex_load3.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load3, res_load3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load3, minval_load3, maxval_load3, minloc_load3, maxloc_load3, Nothing)
        End Using

        async_load3_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load4() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load4 As New Mat(imgex.Width - tplex_load4.Width + 1, imgex.Height - tplex_load4.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load4, res_load4, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load4, minval_load4, maxval_load4, minloc_load4, maxloc_load4, Nothing)
        End Using

        async_load4_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load5() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load5 As New Mat(imgex.Width - tplex_load5.Width + 1, imgex.Height - tplex_load5.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load5, res_load5, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load5, minval_load5, maxval_load5, minloc_load5, maxloc_load5, Nothing)
        End Using

        async_load5_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load6() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load6 As New Mat(imgex.Width - tplex_load6.Width + 1, imgex.Height - tplex_load6.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load6, res_load6, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load6, minval_load6, maxval_load6, minloc_load6, maxloc_load6, Nothing)
        End Using

        async_load6_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load7() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load7 As New Mat(imgex.Width - tplex_load7.Width + 1, imgex.Height - tplex_load7.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load7, res_load7, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load7, minval_load7, maxval_load7, minloc_load7, maxloc_load7, Nothing)
        End Using

        async_load7_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load8() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load8 As New Mat(imgex.Width - tplex_load8.Width + 1, imgex.Height - tplex_load8.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load8, res_load8, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load8, minval_load8, maxval_load8, minloc_load8, maxloc_load8, Nothing)
        End Using

        async_load8_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load9() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load9 As New Mat(imgex.Width - tplex_load9.Width + 1, imgex.Height - tplex_load9.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load9, res_load9, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load9, minval_load9, maxval_load9, minloc_load9, maxloc_load9, Nothing)
        End Using

        async_load9_onoff = 1 '♥

    End Sub

    Private Sub onetimematching_load10() 'なぜかマッチングを1回挟まないと、連続でマッチング判定が起こってしまう（誤判定）
        Getimgex()

        Using res_load10 As New Mat(imgex.Width - tplex_load10.Width + 1, imgex.Height - tplex_load10.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load10, res_load10, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res_load10, minval_load10, maxval_load10, minloc_load10, maxloc_load10, Nothing)
        End Using

        async_load10_onoff = 1 '♥

    End Sub



    '■loadremove1
    Private Sub OpenCV_loadremover1_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover1.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load1.Width + 1, imgex.Height - tplex_load1.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load1, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load1, maxval_load1, minloc_load1, maxloc_load1, Nothing)

            lblcv_nowmaxval_load1.Text = Math.Round(100 * maxval_load1, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load1.Text) > 100 * maxval_load1 Then

                lblcv_maxval_load1.Text = Math.Round(100 * maxval_load1, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load1.Text) < numload_rate1.Value Then

                lblcv_maxval_load1.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay1.Start()
                cvtimer_loadremover1.Stop()


            End If


        End Using


    End Sub

    '■loadremove2
    Private Sub OpenCV_loadremover2_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover2.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load2.Width + 1, imgex.Height - tplex_load2.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load2, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load2, maxval_load2, minloc_load2, maxloc_load2, Nothing)

            lblcv_nowmaxval_load2.Text = Math.Round(100 * maxval_load2, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load2.Text) > 100 * maxval_load2 Then

                lblcv_maxval_load2.Text = Math.Round(100 * maxval_load2, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load2.Text) < numload_rate2.Value Then

                lblcv_maxval_load2.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay2.Start()
                cvtimer_loadremover2.Stop()


            End If


        End Using


    End Sub

    '■loadremove3
    Private Sub OpenCV_loadremover3_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover3.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load3.Width + 1, imgex.Height - tplex_load3.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load3, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load3, maxval_load3, minloc_load3, maxloc_load3, Nothing)

            lblcv_nowmaxval_load3.Text = Math.Round(100 * maxval_load3, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load3.Text) > 100 * maxval_load3 Then

                lblcv_maxval_load3.Text = Math.Round(100 * maxval_load3, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load3.Text) < numload_rate3.Value Then

                lblcv_maxval_load3.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay3.Start()
                cvtimer_loadremover3.Stop()


            End If


        End Using


    End Sub

    '■loadremove4
    Private Sub OpenCV_loadremover4_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover4.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load4.Width + 1, imgex.Height - tplex_load4.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load4, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load4, maxval_load4, minloc_load4, maxloc_load4, Nothing)

            lblcv_nowmaxval_load4.Text = Math.Round(100 * maxval_load4, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load4.Text) > 100 * maxval_load4 Then

                lblcv_maxval_load4.Text = Math.Round(100 * maxval_load4, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load4.Text) < numload_rate4.Value Then

                lblcv_maxval_load4.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay4.Start()
                cvtimer_loadremover4.Stop()


            End If


        End Using


    End Sub

    '■loadremove5
    Private Sub OpenCV_loadremover5_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover5.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load5.Width + 1, imgex.Height - tplex_load5.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load5, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load5, maxval_load5, minloc_load5, maxloc_load5, Nothing)

            lblcv_nowmaxval_load5.Text = Math.Round(100 * maxval_load5, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load5.Text) > 100 * maxval_load5 Then

                lblcv_maxval_load5.Text = Math.Round(100 * maxval_load5, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load5.Text) < numload_rate5.Value Then

                lblcv_maxval_load5.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay5.Start()
                cvtimer_loadremover5.Stop()


            End If


        End Using


    End Sub

    '■loadremove6
    Private Sub OpenCV_loadremover6_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover6.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load6.Width + 1, imgex.Height - tplex_load6.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load6, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load6, maxval_load6, minloc_load6, maxloc_load6, Nothing)

            lblcv_nowmaxval_load6.Text = Math.Round(100 * maxval_load6, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load6.Text) > 100 * maxval_load6 Then

                lblcv_maxval_load6.Text = Math.Round(100 * maxval_load6, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load6.Text) < numload_rate6.Value Then

                lblcv_maxval_load6.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay6.Start()
                cvtimer_loadremover6.Stop()


            End If


        End Using


    End Sub

    '■loadremove7
    Private Sub OpenCV_loadremover7_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover7.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load7.Width + 1, imgex.Height - tplex_load7.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load7, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load7, maxval_load7, minloc_load7, maxloc_load7, Nothing)

            lblcv_nowmaxval_load7.Text = Math.Round(100 * maxval_load7, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load7.Text) > 100 * maxval_load7 Then

                lblcv_maxval_load7.Text = Math.Round(100 * maxval_load7, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load7.Text) < numload_rate7.Value Then

                lblcv_maxval_load7.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay7.Start()
                cvtimer_loadremover7.Stop()


            End If


        End Using


    End Sub

    '■loadremove8
    Private Sub OpenCV_loadremover8_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover8.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load8.Width + 1, imgex.Height - tplex_load8.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load8, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load8, maxval_load8, minloc_load8, maxloc_load8, Nothing)

            lblcv_nowmaxval_load8.Text = Math.Round(100 * maxval_load8, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load8.Text) > 100 * maxval_load8 Then

                lblcv_maxval_load8.Text = Math.Round(100 * maxval_load8, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load8.Text) < numload_rate8.Value Then

                lblcv_maxval_load8.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay8.Start()
                cvtimer_loadremover8.Stop()


            End If


        End Using


    End Sub

    '■loadremove9
    Private Sub OpenCV_loadremover9_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover9.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load9.Width + 1, imgex.Height - tplex_load9.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load9, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load9, maxval_load9, minloc_load9, maxloc_load9, Nothing)

            lblcv_nowmaxval_load9.Text = Math.Round(100 * maxval_load9, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load9.Text) > 100 * maxval_load9 Then

                lblcv_maxval_load9.Text = Math.Round(100 * maxval_load9, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load9.Text) < numload_rate9.Value Then

                lblcv_maxval_load9.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay9.Start()
                cvtimer_loadremover9.Stop()


            End If


        End Using


    End Sub

    '■loadremove10
    Private Sub OpenCV_loadremover10_Tick(sender As Object, e As EventArgs) Handles cvtimer_loadremover10.Tick


        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Using res3 As New Mat(imgex.Width - tplex_load10.Width + 1, imgex.Height - tplex_load10.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex_load10, res3, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res3, minval_load10, maxval_load10, minloc_load10, maxloc_load10, Nothing)

            lblcv_nowmaxval_load10.Text = Math.Round(100 * maxval_load10, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval_load10.Text) > 100 * maxval_load10 Then

                lblcv_maxval_load10.Text = Math.Round(100 * maxval_load10, 2, MidpointRounding.AwayFromZero) '100 * maxval

            End If


            '■マッチングされた→初期化＋ディレイ(cvtimer_loaddelay)
            If CInt(lblcv_maxval_load10.Text) < numload_rate10.Value Then

                lblcv_maxval_load10.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"

                msec_load = CDbl(timeGetTime)

                txtcv_antentime.Text = 0


                lblloading.Text = "sleep" '[loading→sleep]

                cvtimer_loaddelay10.Start()
                cvtimer_loadremover10.Stop()


            End If


        End Using


    End Sub


    '■chkload~chknow_load
    Private Sub chkload_chknow_load_on()

        If chkload1.Checked = True Then
            chknow_load1.Checked = True
            onetimematching_load1()
        End If

        If chkload2.Checked = True Then
            chknow_load2.Checked = True
            onetimematching_load2()
        End If

        If chkload3.Checked = True Then
            chknow_load3.Checked = True
            onetimematching_load3()
        End If

        If chkload4.Checked = True Then
            chknow_load4.Checked = True
            onetimematching_load4()
        End If

        If chkload5.Checked = True Then
            chknow_load5.Checked = True
            onetimematching_load5()
        End If

        If chkload6.Checked = True Then
            chknow_load6.Checked = True
            onetimematching_load6()
        End If

        If chkload7.Checked = True Then
            chknow_load7.Checked = True
            onetimematching_load7()
        End If

        If chkload8.Checked = True Then
            chknow_load8.Checked = True
            onetimematching_load8()
        End If

        If chkload9.Checked = True Then
            chknow_load9.Checked = True
            onetimematching_load9()
        End If

        If chkload10.Checked = True Then
            chknow_load10.Checked = True
            onetimematching_load10()
        End If

    End Sub


    '■loaddelay1
    Private Sub OpenCV_loaddelay1_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay1.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay1.Value

        txtdelay_load1.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load1.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load1.Text = 0
            lblcv_nowmaxval_load1.Text = 0

            txtdelay_load1.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay1.Stop()

        End If


    End Sub

    '■loaddelay2
    Private Sub OpenCV_loaddelay2_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay2.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay2.Value

        txtdelay_load2.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load2.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load2.Text = 0
            lblcv_nowmaxval_load2.Text = 0

            txtdelay_load2.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay2.Stop()

        End If


    End Sub

    '■loaddelay3
    Private Sub OpenCV_loaddelay3_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay3.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay3.Value

        txtdelay_load3.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load3.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load3.Text = 0
            lblcv_nowmaxval_load3.Text = 0

            txtdelay_load3.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay3.Stop()

        End If


    End Sub

    '■loaddelay4
    Private Sub OpenCV_loaddelay4_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay4.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay4.Value

        txtdelay_load4.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load4.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load4.Text = 0
            lblcv_nowmaxval_load4.Text = 0

            txtdelay_load4.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay4.Stop()

        End If


    End Sub

    '■loaddelay5
    Private Sub OpenCV_loaddelay5_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay5.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay5.Value

        txtdelay_load5.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load5.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load5.Text = 0
            lblcv_nowmaxval_load5.Text = 0

            txtdelay_load5.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay5.Stop()

        End If


    End Sub

    '■loaddelay6
    Private Sub OpenCV_loaddelay6_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay6.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay6.Value

        txtdelay_load6.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load6.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load6.Text = 0
            lblcv_nowmaxval_load6.Text = 0

            txtdelay_load6.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay6.Stop()

        End If


    End Sub

    '■loaddelay7
    Private Sub OpenCV_loaddelay7_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay7.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay7.Value

        txtdelay_load7.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load7.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load7.Text = 0
            lblcv_nowmaxval_load7.Text = 0

            txtdelay_load7.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay7.Stop()

        End If


    End Sub

    '■loaddelay8
    Private Sub OpenCV_loaddelay8_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay8.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay8.Value

        txtdelay_load8.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load8.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load8.Text = 0
            lblcv_nowmaxval_load8.Text = 0

            txtdelay_load8.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay8.Stop()

        End If


    End Sub

    '■loaddelay9
    Private Sub OpenCV_loaddelay9_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay9.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay9.Value

        txtdelay_load9.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load9.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load9.Text = 0
            lblcv_nowmaxval_load9.Text = 0

            txtdelay_load9.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay9.Stop()

        End If


    End Sub

    '■loaddelay10
    Private Sub OpenCV_loaddelay10_Tick(sender As Object, e As EventArgs) Handles cvtimer_loaddelay10.Tick

        lblrecord_pause.Text = ((timeGetTime - msec_pause))
        txtrecord_load.Text = CDbl(lblrecord_pause.Text * 0.001).ToString("00:00.00")


        Dim antencount As Integer = numload_delay10.Value

        txtdelay_load10.Text = antencount + (msec_load - timeGetTime)

        If txtdelay_load10.Text < 1 Then

            lblrecord_pause_total.Text += CInt(lblrecord_pause.Text)
            txtrecord_load_total.Text = CDbl(lblrecord_pause_total.Text * 0.001).ToString("00:00.00")

            allkeysend_load() '[sleep→play]resume送信

            lblloading.Text = "play"

            txtstate.Text = My.Resources.Message.msg30 '"画像認識中"

            lblcv_maxval_load10.Text = 0
            lblcv_nowmaxval_load10.Text = 0

            txtdelay_load10.Text = 0


            chkload_chknow_load_on()
            cvtimer_loaddelay10.Stop()

        End If


    End Sub





    '■場面転換OpenCV
    Private Sub OpenCV_change_Tick(sender As Object, e As EventArgs) Handles cvtimer_change.Tick

        Dim number As Integer = lblcv_lap.Text

        If chkcv_loop.Checked = False Then
            number -= 1
        End If



        Using res1 As New Mat(imgex.Width - tplex.Width + 1, imgex.Height - tplex.Height + 1, MatType.CV_32FC1)

            Cv2.MatchTemplate(imgex, tplex, res1, TemplateMatchModes.CCoeffNormed)
            Cv2.MinMaxLoc(res1, minval_split, maxval_split, minloc_split, maxloc_split, Nothing)

            lblcv_nowmaxval.Text = Math.Round(100 * maxval_split, 2, MidpointRounding.AwayFromZero) '100 * maxval

            If CDbl(lblcv_maxval.Text) > 100 * maxval_split Then
                lblcv_maxval.Text = Math.Round(100 * maxval_split, 2, MidpointRounding.AwayFromZero) '100 * maxval
            End If



            'マッチングされた。
            If CInt(lblcv_maxval.Text) < txtcv_ikiti.Text Then

                lblcv_maxval.Text = 0

                txtstate.Text = My.Resources.Message.msg34 '"指定時間待機中"


                'モニタリングタブの右上が変わらない内に処理をする。■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

                msec = CDbl(timeGetTime)

                txtcv_antentime.Text = 0

                timcv_perfectanten.Enabled = True
                cvtimer_change.Stop()
                timcv_forantencap.Enabled = False


            End If

        End Using


    End Sub

    '■場面転換RGB
    Private Sub OpenCV_changergb_Tick(sender As Object, e As EventArgs) Handles cvtimer_changergb.Tick

        Dim number As Integer = lblcv_lap.Text

        If chkcv_loop.Checked = False Then
            number -= 1
        End If

        '追従する場合、ltx,ltyを補正する。
        Dim ltx As Integer = maxloc_split.X 'DGtable(posx.Index, number).Value
        Dim lty As Integer = maxloc_split.Y 'DGtable(posy.Index, number).Value
        Dim rbx As Integer = tplex.Width 'DGtable(sizex.Index, number).Value
        Dim rby As Integer = tplex.Height 'DGtable(sizey.Index, number).Value

        txtcompikiti.Text = (rbx * rby) * (CInt(txtcv_ikiti.Text) * 0.01)


        Dim comptimer As Integer = 0



        '■画像の一部を切り取って（トリミングして）表示する■■■■■■■■■■■■■■■■

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(rbx, rby)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        '画像ファイルのImageオブジェクトを作成する
        Dim img As Bitmap = picipl_cap.Image

        '切り取る部分の範囲を決定する。ここでは、位置(10,10)、大きさ100x100
        Dim srcRect As New Rectangle(ltx, lty, rbx, rby)
        '描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
        Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
        '画像の一部を描画する
        g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel)

        'Graphicsオブジェクトのリソースを解放する
        g.Dispose()

        'PictureBox1に表示する
        picipl_foranten.Image = canvas




        '#CaptureのRGB取得を行う■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        Dim cap As Bitmap = picipl_foranten.Image
        Dim pic As Bitmap = piccv_picture.Image

        '##CaptureのRGB取得の準備を行う###################################################################
        Dim pixelFormat_cap As PixelFormat = cap.PixelFormat
        Dim pixelSize_cap As Integer = Image.GetPixelFormatSize(pixelFormat_cap) / 8
        If pixelSize_cap < 3 OrElse 4 < pixelSize_cap Then
            Throw New ArgumentException(
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。",
                "img")
        End If

        'Bitmapをロックする
        Dim bmpData_cap As BitmapData =
            cap.LockBits(New Rectangle(0, 0, cap.Width, cap.Height),
                         ImageLockMode.ReadWrite, pixelFormat_cap)

        If bmpData_cap.Stride < 0 Then
            cap.UnlockBits(bmpData_cap)
            Throw New ArgumentException(
                "ボトムアップ形式のイメージには対応していません。",
                "img")
        End If


        '##PictureのRGB取得の準備を行う■■■■■■■■

        Dim pixelFormat_pic As PixelFormat = pic.PixelFormat
        Dim pixelSize_pic As Integer = 0.125 * Image.GetPixelFormatSize(pixelFormat_pic) ' / 8
        If pixelSize_pic < 3 OrElse 4 < pixelSize_pic Then
            Throw New ArgumentException(
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。",
                "img")
        End If


        'Bitmapをロックする
        Dim bmpData_pic As BitmapData =
            pic.LockBits(New Rectangle(0, 0, pic.Width, pic.Height),
                         ImageLockMode.ReadWrite, pixelFormat_pic)

        If bmpData_pic.Stride < 0 Then
            pic.UnlockBits(bmpData_pic)
            Throw New ArgumentException(
                "ボトムアップ形式のイメージには対応していません。",
                "img")
        End If



        '#######################################################################################################################
        '##################PGB取得の準備が終了。px毎の色情報を取得し、差を取る。################################################
        '#######################################################################################################################

        '範囲内の全ピクセルの色を取得する
        For y As Integer = 0 To rby - 1 'bmpData.Height - 1 
            For x As Integer = 0 To rbx - 1 'bmpData.Width - 1

                'キャプチャ画像の全ピクセルの色を取得する
                Dim adr_cap As IntPtr = bmpData_cap.Scan0
                Dim pos_cap As Integer = y * bmpData_cap.Stride + x * pixelSize_cap
                Dim cap_b As Byte = Marshal.ReadByte(adr_cap, pos_cap + 0)
                Dim cap_g As Byte = Marshal.ReadByte(adr_cap, pos_cap + 1)
                Dim cap_r As Byte = Marshal.ReadByte(adr_cap, pos_cap + 2) 'System.Runtime.InteropServices.

                'ピクチャ画像の全ピクセルの色を取得する
                Dim adr_pic As IntPtr = bmpData_pic.Scan0
                Dim pos_pic As Integer = y * bmpData_pic.Stride + x * pixelSize_pic
                Dim pic_b As Byte = Marshal.ReadByte(adr_pic, pos_pic + 0)
                Dim pic_g As Byte = Marshal.ReadByte(adr_pic, pos_pic + 1)
                Dim pic_r As Byte = Marshal.ReadByte(adr_pic, pos_pic + 2)

                '2枚の画像のRGBの差を取る
                Dim distR As Integer = Math.Abs(CInt(cap_r) - CInt(pic_r))
                Dim distG As Integer = Math.Abs(CInt(cap_g) - CInt(pic_g))
                Dim distB As Integer = Math.Abs(CInt(cap_b) - CInt(pic_b))


                '色差が少ない場合、カウントプラス


                '完全に真っ暗にならなくても判定できるように…


                If distR <= DGtable(darkthr.Index, number).Value And
                    distG <= DGtable(darkthr.Index, number).Value And
                    distB <= DGtable(darkthr.Index, number).Value Then

                    comptimer += 1 '内部処理用

                End If



            Next
        Next


        'ロックを解除する
        cap.UnlockBits(bmpData_cap)
        pic.UnlockBits(bmpData_pic)

        'カウントが一定以上でSendkeyする########################################################################################
        txtcv_antenyn.Text = comptimer '画面表示用。

        '完全に暗転したら、このタイマーを止めて、完全な暗転までの時間を計るタイマーを動かす。
        If comptimer < CInt(txtcompikiti.Text) Then

            msec = CDbl(timeGetTime)

            comptimer = 0
            txtcv_antentime.Text = 0

            timcv_perfectanten.Enabled = True
            cvtimer_changergb.Stop()
            timcv_forantencap.Enabled = False




        End If


    End Sub




    '■暗転用のキャプチャ。■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub timcv_forantencap_Tick(sender As Object, e As EventArgs) Handles timcv_forantencap.Tick

        'NativeMethods.videoio_VideoCapture_operatorRightShift_Mat(Me.capturecv.CvPtr, Me.frame.CvPtr)
        capturecv.Read(frame)

        If chkcv_crop.Checked = True Then

            '■先にクロップをする。
            dst_cropRect = New Mat(frame, New OpenCvSharp.Rect(CInt(txtcv_crop_posx.Text), CInt(txtcv_crop_posy.Text),
                                   CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text)))

            Dim dst_cropped As Mat = New Mat(CInt(txtcv_crop_sizex.Text), CInt(txtcv_crop_sizey.Text), MatType.CV_32FC1)

            dst_cropRect.CopyTo(dst_cropped)

            '■リサイズ
            dst_resize = New Mat()
            Cv2.Resize(dst_cropped, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

            picipl_cap.ImageIpl = dst_resize
            imgex = dst_resize

            dst_cropRect.Dispose()
            dst_cropped.Dispose()
            'dst_resize.Dispose()


        ElseIf chkcv_crop.Checked = False Then 'クロップなし。リサイズ有無で分岐

            If numcv_sizex.Value = numcrop_resolution_x.Value And
               numcv_sizey.Value = numcrop_resolution_y.Value Then

                picipl_cap.ImageIpl = frame
                imgex = frame


            Else

                dst_resize = New Mat()
                Cv2.Resize(frame, dst_resize, New OpenCvSharp.Size(numcv_sizex.Value, numcv_sizey.Value), 0, 0, interpolation:=InterpolationFlags.Nearest)

                picipl_cap.ImageIpl = dst_resize
                imgex = dst_resize

                'dst_resize.Dispose()


            End If

        End If


    End Sub

    '■認識から暗転まで。■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub timcv_anten_Tick(sender As Object, e As EventArgs) Handles timcv_anten.Tick

        Dim number As Integer = lblcv_lap.Text

        If chkcv_loop.Checked = False Then
            number -= 1
        End If

        '追従する場合、ltx,ltyを補正する。
        Dim ltx As Integer = DGtable(posx.Index, number).Value 'txtcv_posx.Text
        Dim lty As Integer = DGtable(posy.Index, number).Value '.Text
        Dim rbx As Integer = DGtable(sizex.Index, number).Value
        Dim rby As Integer = DGtable(sizey.Index, number).Value

        Dim comptimer As Integer = 0



        '■画像の一部を切り取って（トリミングして）表示する■■■■■■■■■■■■■■■■

        '描画先とするImageオブジェクトを作成する
        Dim canvas As New Bitmap(rbx, rby)
        'ImageオブジェクトのGraphicsオブジェクトを作成する
        Dim g As Graphics = Graphics.FromImage(canvas)

        '画像ファイルのImageオブジェクトを作成する
        Dim img As Bitmap = picipl_cap.Image

        '切り取る部分の範囲を決定する。ここでは、位置(10,10)、大きさ100x100
        Dim srcRect As New Rectangle(ltx, lty, rbx, rby)
        '描画する部分の範囲を決定する。ここでは、位置(0,0)、大きさ100x100で描画する
        Dim desRect As New Rectangle(0, 0, srcRect.Width, srcRect.Height)
        '画像の一部を描画する
        g.DrawImage(img, desRect, srcRect, GraphicsUnit.Pixel)

        'Graphicsオブジェクトのリソースを解放する
        g.Dispose()

        'PictureBox1に表示する
        picipl_foranten.Image = canvas



        '#CaptureのRGB取得を行う■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        Dim cap As Bitmap = picipl_foranten.Image


        '##CaptureのRGB取得の準備を行う###################################################################
        Dim pixelFormat_cap As PixelFormat = cap.PixelFormat
        Dim pixelSize_cap As Integer = Image.GetPixelFormatSize(pixelFormat_cap) / 8
        If pixelSize_cap < 3 OrElse 4 < pixelSize_cap Then
            Throw New ArgumentException(
                "1ピクセルあたり24または32ビットの形式のイメージのみ有効です。",
                "img")
        End If

        'Bitmapをロックする
        Dim bmpData_cap As BitmapData =
            cap.LockBits(New Rectangle(0, 0, cap.Width, cap.Height),
                         ImageLockMode.ReadWrite, pixelFormat_cap)

        If bmpData_cap.Stride < 0 Then
            cap.UnlockBits(bmpData_cap)
            Throw New ArgumentException(
                "ボトムアップ形式のイメージには対応していません。",
                "img")
        End If


        '#######################################################################################################################
        '##################PGB取得の準備が終了。px毎の色情報を取得し、差を取る。################################################
        '#######################################################################################################################

        '範囲内の全ピクセルの色を取得する
        For y As Integer = 0 To rby - 1 'bmpData.Height - 1 
            For x As Integer = 0 To rbx - 1 'bmpData.Width - 1

                'キャプチャ画像の全ピクセルの色を取得する
                Dim adr_cap As IntPtr = bmpData_cap.Scan0
                Dim pos_cap As Integer = y * bmpData_cap.Stride + x * pixelSize_cap
                Dim cap_b As Byte = Marshal.ReadByte(adr_cap, pos_cap + 0)
                Dim cap_g As Byte = Marshal.ReadByte(adr_cap, pos_cap + 1)
                Dim cap_r As Byte = Marshal.ReadByte(adr_cap, pos_cap + 2) 'System.Runtime.InteropServices.


                '2枚の画像のRGBの差を取る
                Dim distR As Integer = Math.Abs(CInt(cap_r)) + Math.Abs(CInt(cap_g)) + Math.Abs(CInt(cap_b))


                '色差が少ない（黒に近い）場合、カウントプラス
                '完全に真っ暗にならなくても判定できるように…

                If chkcv_loop.Checked = False Then

                    If distR <= DGtable(darkthr.Index, number).Value * 5.8 + 13 Then

                        comptimer += 1 '内部処理用

                    Else

                    End If

                ElseIf chkcv_loop.Checked = True Then

                    If distR <= DGtable(darkthr.Index, number).Value * 5.8 + 13 Then

                        comptimer += 1 '内部処理用

                    Else

                    End If

                End If


            Next

        Next


        'ロックを解除する
        cap.UnlockBits(bmpData_cap)


        'カウントが一定以上でSendkeyする########################################################################################
        txtcv_antenyn.Text = comptimer '画面表示用。

        '完全に暗転したら、このタイマーを止めて、完全な暗転までの時間を計るタイマーを動かす。
        If txtcv_antenyn.Text = rbx * rby Then

            msec = CDbl(timeGetTime)

            comptimer = 0
            txtcv_antentime.Text = 0
            txtcv_antenyn.Text = 0

            timcv_perfectanten.Enabled = True

            timcv_anten.Enabled = False
            timcv_forantencap.Enabled = False

        End If

    End Sub

    '■暗転から指定時間待機■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub timcv_perfectanten_Tick(sender As Object, e As EventArgs) Handles timcv_perfectanten.Tick

        Dim number As Integer = lblcv_lap.Text

        'lbllapの値を調整する（何もなしだと、1番目のラップで0行目を参照してしまう）
        If chkcv_loop.Checked = False Then
            '何もしない
        ElseIf chkcv_loop.Checked = True Then
            '2-1で1とする。
            lblcv_lap.Text = 2
        End If

        Dim antencount As Integer = DGtable(darksleep.Index, CInt(lblcv_lap.Text - 1)).Value

        txtcv_antentime.Text = antencount + (msec - timeGetTime)

        If txtcv_antentime.Text < 1 Then

            If chkcv_loop.Checked = False Then
                '何もしない
            ElseIf chkcv_loop.Checked = True Then
                '2-1で1とする。
                lblcv_lap.Text = 1
            End If

            lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value '表の2列目の文字を表示



            ' StartA  ファイルが存在しているかどうか確認する
            If System.IO.File.Exists(txtpass_picturefolder.Text & "\" & lblcv_lap.Text & ".bmp") Then

                msec = CDbl(timeGetTime)

                allkeysend()


                '■Videoplayerのシーク'♥
                If chkshowvideo.Checked = True Then

                    If chkvideo_autoseek.Checked = True Then

                        If chkcv_loop.Checked = True Then

                            Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 0)).Value

                            'Videoseekの値が"-1"ならば、シークなど何の操作もしない
                            If Videoplayer.playtime = -1 Then

                            Else

                                Videoplayer.videoplay()


                            End If


                        ElseIf chkcv_loop.Checked = False Then
                            Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 1)).Value

                            'Videoseekの値が"-1"ならば、シークなど何の操作もしない
                            If Videoplayer.playtime = -1 Then

                            Else
                                Videoplayer.videoplay()

                            End If

                        End If



                    Else '最初の反応時にのみplayする

                        If chkcv_loop.Checked = True Then
                            If numnowloop.Value = 0 Then
                                Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text)).Value
                                Videoplayer.videoplay()

                            End If
                        ElseIf chkcv_loop.Checked = False Then

                            If lblcv_lap.Text = 2 Then
                                Videoplayer.playtime = DGtable(seektime.Index, CInt(lblcv_lap.Text - 1)).Value
                                Videoplayer.videoplay()

                            End If

                        End If

                    End If

                End If


            Else ' ファイルが存在していない時。

                lblcv_lap.Text = 1

                allkeysend()

                If lblreload_graph.Text = 1 Then

                    '■グラフ更新
                    graph_split()

                    lblreload_graph.Text = 0


                End If

                show_finish()

            End If

            txtcv_antentime.Text = 0

            cvsleep_split.Start()
            lblcv_sendview.Visible = True
            lblsleeptime.Visible = True

            timcv_perfectanten.Enabled = False

        End If

    End Sub

    '■終了の表示とタイマー停止
    Private Sub show_finish()
        cvtimer_change.Stop()
        cvtimer_changergb.Stop()
        cvtimer.Stop()
        cvtimer_ash_hotkey.Stop()

        cvsleep_split.Stop()
        cvtimer_loadremover1.Stop()
        cvtimer_loadremover2.Stop()
        cvtimer_loadremover3.Stop()
        cvtimer_loadremover4.Stop()
        cvtimer_loadremover5.Stop()
        cvtimer_loadremover6.Stop()
        cvtimer_loadremover7.Stop()
        cvtimer_loadremover8.Stop()
        cvtimer_loadremover9.Stop()
        cvtimer_loadremover10.Stop()
        cvtimer_loaddelay1.Stop()
        cvtimer_loaddelay2.Stop()
        cvtimer_loaddelay3.Stop()
        cvtimer_loaddelay4.Stop()
        cvtimer_loaddelay5.Stop()
        cvtimer_loaddelay6.Stop()
        cvtimer_loaddelay7.Stop()
        cvtimer_loaddelay8.Stop()
        cvtimer_loaddelay9.Stop()
        cvtimer_loaddelay10.Stop()

        lblloading.Text = "play"

        timcv_anten.Enabled = False
        timcv_perfectanten.Enabled = False
        timcv_forantencap.Enabled = False
        timopencvsleep.Enabled = False

        lblcv_sendview.Visible = True
        lblcv_sendview.Text = "Finish"

    End Sub

    '■監視の停止
    Private Sub btncv_stop_Click(sender As Object, e As EventArgs) Handles btncv_stop.Click

        lblreload_graph.Text = 0
        lbllooptrigger.Text = 0

        lblcv_lap.Text = 1
        cvtimer_change.Stop()
        cvtimer_changergb.Stop()
        cvtimer.Stop()
        cvtimer_ash_hotkey.Stop()
        cvtimer_loadremover1.Stop()
        cvtimer_loadremover2.Stop()
        cvtimer_loadremover3.Stop()
        cvtimer_loadremover4.Stop()
        cvtimer_loadremover5.Stop()
        cvtimer_loadremover6.Stop()
        cvtimer_loadremover7.Stop()
        cvtimer_loadremover8.Stop()
        cvtimer_loadremover9.Stop()
        cvtimer_loadremover10.Stop()
        cvtimer_loaddelay1.Stop()
        cvtimer_loaddelay2.Stop()
        cvtimer_loaddelay3.Stop()
        cvtimer_loaddelay4.Stop()
        cvtimer_loaddelay5.Stop()
        cvtimer_loaddelay6.Stop()
        cvtimer_loaddelay7.Stop()
        cvtimer_loaddelay8.Stop()
        cvtimer_loaddelay9.Stop()
        cvtimer_loaddelay10.Stop()

        lblloading.Text = "play"

        lblcv_sendview.Text = "Match"

        timcv_anten.Enabled = False
        timcv_perfectanten.Enabled = False
        timcv_forantencap.Enabled = False
        timopencvsleep.Enabled = False
        lblcv_sendview.Visible = False
        lblsleeptime.Visible = False

        btnstartopencv.Enabled = True

        chknow_monitor.Checked = False
        chknow_reset.Checked = False
        chknow_load.Checked = False
        chknow_load1.Checked = False
        chknow_load2.Checked = False
        chknow_load3.Checked = False
        chknow_load4.Checked = False
        chknow_load5.Checked = False
        chknow_load6.Checked = False
        chknow_load7.Checked = False
        chknow_load8.Checked = False
        chknow_load9.Checked = False
        chknow_load10.Checked = False

        async_split_onoff = 0
        async_reset_onoff = 0
        async_load1_onoff = 0
        async_load2_onoff = 0
        async_load3_onoff = 0
        async_load4_onoff = 0
        async_load5_onoff = 0
        async_load6_onoff = 0
        async_load7_onoff = 0
        async_load8_onoff = 0
        async_load9_onoff = 0
        async_load10_onoff = 0

        cmbloadno.Enabled = True






        '進む、戻るボタンを無効に
        btncv_back.Enabled = False
        btncv_forward.Enabled = False
        btncv_first.Enabled = False


        TabControl1.SelectedIndex = 0 'タブ移動

        btncv_downsize.Text = My.Resources.Message.msg35 '"たたむ"
        Me.Size = New Drawing.Size(800 * Dpi_rate, 562 * Dpi_rate)

        '■DGTableのイベントを有効にする。
        AddHandler DGtable.CellValueChanged, AddressOf DGtable_CellValueChanged


        '■表示がバグることがあるのでリフレッシュ
        Me.Refresh()


    End Sub

    '■監視画像の切り替え。■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub btncv_back_Click(sender As Object, e As EventArgs) Handles btncv_back.Click

        If Not lblloading.Text = "play" Then
            Exit Sub
        End If






        '監視範囲の更新#################################################################################################
        If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\" & lblcv_lap.Text - 1 & ".bmp") Then

            MessageBox.Show(My.Resources.Message.msg7, messagebox_name,
                   MessageBoxButtons.OK) '"画像が存在しません。"

        Else

            '■成功率カウントの修正
            Console.WriteLine("undo")

            lbllapcount.Text = CInt(lbllapcount.Text) - 1

            'If lbllapcount.Text = 1 + (numgraph_first.Value - 1) Then

            '    lblattemptcount.Text += 1

            'End If

            view_chart.lblcount.Text = lblattemptcount.Text

            DGtable(graph_count.Index, CInt(lbllapcount.Text)).Value = DGtable(graph_count.Index, CInt(lbllapcount.Text)).Value - 1 'カウント-1

            'ラップカウントの調整
            lbllapcount.Text += 1

            table_reload()

            lbllapcount.Text -= 1




            If chkundoskip.Checked = True Then

                If chknamedpipe.Checked = True Then

                    'タイマーのプロセスを探す
                    Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

                    If 0 < ps_timer1.Length Then

                        Try


                            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                            sw.AutoFlush = True
                            sw.WriteLine("unsplit" & vbCrLf)


                        Catch ex As Exception
                            MessageBox.Show(ex.ToString, messagebox_name)
                            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                        End Try

                    End If


                ElseIf chknamedpipe.Checked = False Then


                    If chkactiveapp.Checked = True Then

                        Dim key_undo As Short = lblkeysforundo.Text

                        'タイマーのプロセスを探す
                        Dim ps_timer2 As System.Diagnostics.Process() = Process.GetProcessesByName(cmbtimer.SelectedItem)

                        If 0 < ps_timer2.Length Then
                            '見つかった時は、アクティブにする
                            Microsoft.VisualBasic.Interaction.AppActivate(ps_timer2(0).Id)

                        End If

                        'タイマーが入力を受け付けるまでちょっと時間空ける
                        System.Threading.Thread.Sleep(numsendsleep.Value)

                        keydownAction_undo() 'Shift,Ctrl,Altキーを押す
                        Call KeyEvent(key_undo, KEY_DOWN) 'コントロールキーを押下
                        System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
                        keyupAction_undo()    'Shift,Ctrl,Altキーを離す
                        Call KeyEvent(key_undo, KEY_UP) 'コントロールキーを離す


                        'Start③' アクティブを元に戻すにチェックが入っている時
                        If chkactivesomeapp.Checked = True Then

                            'メモ帳のプロセスを探す
                            Dim app_someapp2 As String = cmbsomeapp.SelectedItem
                            Dim ps_someapp2 As System.Diagnostics.Process() = Process.GetProcessesByName(app_someapp2)

                            If 0 < ps_someapp2.Length Then
                                '見つかった時は、アクティブにする

                                Microsoft.VisualBasic.Interaction.AppActivate(ps_someapp2(0).Id)

                            End If

                        End If 'End③'

                    ElseIf chkactiveapp.Checked = False Then

                        Dim key_undo As Short = lblkeysforundo.Text

                        keydownAction_undo() 'Shift,Ctrl,Altキーを押す
                        Call KeyEvent(key_undo, KEY_DOWN) 'コントロールキーを押下
                        System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
                        keyupAction_undo()    'Shift,Ctrl,Altキーを離す
                        Call KeyEvent(key_undo, KEY_UP) 'コントロールキーを離す


                    End If

                End If

            End If


            'ラップを1つ元に戻す。
            lblcv_lap.Text -= 1
            lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value '表の2列目の文字を表示
            lblcv_sendview.Text = "Match"

            Dim number As String = lblcv_lap.Text


            '■テンプレート画像の更新
            Dim aa As String = txtpass_picturefolder.Text & "\" & number & ".bmp"
            tplex = Cv2.ImRead(aa, ImreadModes.Color)

            '■該当の画像をUIにも表示        
            Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                piccv_picture.Image = Image.FromStream(fs)
            End Using

            '■リッチテキストファイルの更新♥
            If chkshow_text.Checked = True Then
                Textwindow.rtxt1.LoadFile(txtpass_rtf.Text & "/" & number & ".rtf", RichTextBoxStreamType.RichText)
            End If

            '■★Methodに番号を送る。どの方式で監視を行うか。
            cv_method = DGtable(send.Index, CInt(lblcv_lap.Text) - 0).Value '表の2行目のMethod値を取得。0/1:OpenCV、2/3:RGB、4/5:RGB(色の割合)


            '後処理##########################################################################################
            cvtimer_change.Stop()
            cvtimer_changergb.Stop()
            cvtimer_loadremover1.Stop()
            cvtimer_loadremover2.Stop()
            cvtimer_loadremover3.Stop()
            cvtimer_loadremover4.Stop()
            cvtimer_loadremover5.Stop()
            cvtimer_loadremover6.Stop()
            cvtimer_loadremover7.Stop()
            cvtimer_loadremover8.Stop()
            cvtimer_loadremover9.Stop()
            cvtimer_loadremover10.Stop()
            cvtimer_loaddelay1.Stop()
            cvtimer_loaddelay2.Stop()
            cvtimer_loaddelay3.Stop()
            cvtimer_loaddelay4.Stop()
            cvtimer_loaddelay5.Stop()
            cvtimer_loaddelay6.Stop()
            cvtimer_loaddelay7.Stop()
            cvtimer_loaddelay8.Stop()
            cvtimer_loaddelay9.Stop()
            cvtimer_loaddelay10.Stop()
            timcv_anten.Enabled = False
            timcv_forantencap.Enabled = False
            timcv_perfectanten.Enabled = False


            txtcv_ikiti.Text = DGtable(rate.Index, CInt(lblcv_lap.Text)).Value
            lblcv_sleepcount.Text = DGtable(sleep.Index, CInt(lblcv_lap.Text)).Value

            txtcv_color_r.Text = DGtable(color_r.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_g.Text = DGtable(color_g.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_b.Text = DGtable(color_b.Index, CInt(lblcv_lap.Text)).Value

            color_lower_limit_r = txtcv_color_r.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_g = txtcv_color_g.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_b = txtcv_color_b.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            color_upper_limit_r = txtcv_color_r.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_g = txtcv_color_g.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_b = txtcv_color_b.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            ColorAllowance = DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            lblcv_maxval.Text = 0
            cvsleep_split.Stop()
            lblcv_sendview.Visible = False
            lblsleeptime.Visible = False

            lblcv_maxval_reset.Text = 0
            lblcv_nowmaxval_reset.Text = 0

            txtcv_antentime.Text = 0
            txtdelay_load.Text = 0




            If chkcv_monitor.Checked = True Then
                chknow_monitor.Checked = True
                onetimematching() '★
            End If

            If chkcv_resetonoff.Checked = True Then
                chknow_reset.Checked = True
                onetimematching_reset() '★
            End If

            If chkcv_loadremover.Checked = True Then

                If chkload1.Checked = True Then
                    chknow_load1.Checked = True

                End If

                If chkload2.Checked = True Then
                    chknow_load2.Checked = True

                End If

                If chkload3.Checked = True Then
                    chknow_load3.Checked = True

                End If

                If chkload4.Checked = True Then
                    chknow_load4.Checked = True

                End If

                If chkload5.Checked = True Then
                    chknow_load5.Checked = True

                End If

                If chkload6.Checked = True Then
                    chknow_load6.Checked = True

                End If

                If chkload7.Checked = True Then
                    chknow_load7.Checked = True

                End If

                If chkload8.Checked = True Then
                    chknow_load8.Checked = True

                End If

                If chkload9.Checked = True Then
                    chknow_load9.Checked = True

                End If

                If chkload10.Checked = True Then
                    chknow_load10.Checked = True

                End If

            End If

            If chkcv_monitor.Checked = True Then
                async_split_onoff = 1
                cvtimer.Start()
            End If

        End If

    End Sub

    Private Sub btncv_forward_Click(sender As Object, e As EventArgs) Handles btncv_forward.Click

        If Not lblloading.Text = "play" Then
            Exit Sub
        End If





        '監視範囲の更新#################################################################################################
        If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\" & lblcv_lap.Text + 1 & ".bmp") Then

            MessageBox.Show(My.Resources.Message.msg7, messagebox_name,
                   MessageBoxButtons.OK) '"画像が存在しません。"

        Else

            '■成功率カウントの修正
            Console.WriteLine("skip")

            lbllapcount.Text = CInt(lbllapcount.Text) + 1

            If lbllapcount.Text = 1 + (numgraph_first.Value - 1) Then

                lblattemptcount.Text += 1

            End If

            view_chart.lblcount.Text = lblattemptcount.Text

            DGtable(graph_count.Index, CInt(lbllapcount.Text) - 1).Value = DGtable(graph_count.Index, CInt(lbllapcount.Text) - 1).Value + 1 'カウント+1

            table_reload()



            If chkundoskip.Checked = True Then

                If chknamedpipe.Checked = True Then

                    Console.WriteLine("send_skip_livesplit")

                    'タイマーのプロセスを探す
                    Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

                    If 0 < ps_timer1.Length Then

                        Try


                            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                            sw.AutoFlush = True
                            sw.WriteLine("skipsplit" & vbCrLf)


                        Catch ex As Exception

                            MessageBox.Show(ex.ToString, messagebox_name)
                            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                        End Try

                    End If


                ElseIf chknamedpipe.Checked = False Then

                    If chkactiveapp.Checked = True Then

                        Dim key_skip As Short = lblkeysforskip.Text

                        'タイマーのプロセスを探す
                        Dim ps_timer2 As Process() = Process.GetProcessesByName(cmbtimer.SelectedItem)

                        If 0 < ps_timer2.Length Then

                            Microsoft.VisualBasic.Interaction.AppActivate(ps_timer2(0).Id)

                        End If

                        'タイマーが入力を受け付けるまでちょっと時間空ける
                        System.Threading.Thread.Sleep(numsendsleep.Value)

                        keydownAction_skip() 'Shift,Ctrl,Altキーを押す
                        Call KeyEvent(key_skip, KEY_DOWN) 'コントロールキーを押下
                        System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
                        keyupAction_skip()    'Shift,Ctrl,Altキーを離す
                        Call KeyEvent(key_skip, KEY_UP) 'コントロールキーを離す


                        'Start③' アクティブを元に戻すにチェックが入っている時
                        If chkactivesomeapp.Checked = True Then

                            'メモ帳のプロセスを探す
                            Dim app_someapp2 As String = cmbsomeapp.SelectedItem
                            Dim ps_someapp2 As Process() = Process.GetProcessesByName(app_someapp2)

                            If 0 < ps_someapp2.Length Then

                                Microsoft.VisualBasic.Interaction.AppActivate(ps_someapp2(0).Id)

                            End If

                        End If 'End③'


                    ElseIf chkactiveapp.Checked = False Then

                        Dim key_skip As Short = lblkeysforskip.Text

                        keydownAction_skip() 'Shift,Ctrl,Altキーを押す
                        Call KeyEvent(key_skip, KEY_DOWN) 'コントロールキーを押下
                        System.Threading.Thread.Sleep(1) '指定ミリ秒待つ
                        keyupAction_skip()    'Shift,Ctrl,Altキーを離す
                        Call KeyEvent(key_skip, KEY_UP) 'コントロールキーを離す


                    End If

                End If

            End If

            'ラップを1つ進ませる。
            lblcv_lap.Text += 1
            lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value '表の2列目の文字を表示
            lblcv_sendview.Text = "Match"

            Dim number As String = lblcv_lap.Text

            '■テンプレート画像の更新
            Dim aa As String = txtpass_picturefolder.Text & "\" & number & ".bmp"
            tplex = Cv2.ImRead(aa, ImreadModes.Color)

            '■該当の画像をUIにも表示        
            Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                piccv_picture.Image = Image.FromStream(fs)
            End Using

            '■リッチテキストファイルの更新♥
            If chkshow_text.Checked = True Then
                Textwindow.rtxt1.LoadFile(txtpass_rtf.Text & "/" & number & ".rtf", RichTextBoxStreamType.RichText)
            End If

            '■★Methodに番号を送る。どの方式で監視を行うか。
            cv_method = DGtable(send.Index, CInt(lblcv_lap.Text) - 0).Value '表の2行目のMethod値を取得。0/1:OpenCV、2/3:RGB、4/5:RGB(色の割合)

            '後処理##########################################################################################
            cvtimer_change.Stop()
            cvtimer_changergb.Stop()
            cvtimer_loadremover1.Stop()
            cvtimer_loadremover2.Stop()
            cvtimer_loadremover3.Stop()
            cvtimer_loadremover4.Stop()
            cvtimer_loadremover5.Stop()
            cvtimer_loadremover6.Stop()
            cvtimer_loadremover7.Stop()
            cvtimer_loadremover8.Stop()
            cvtimer_loadremover9.Stop()
            cvtimer_loadremover10.Stop()
            cvtimer_loaddelay1.Stop()
            cvtimer_loaddelay2.Stop()
            cvtimer_loaddelay3.Stop()
            cvtimer_loaddelay4.Stop()
            cvtimer_loaddelay5.Stop()
            cvtimer_loaddelay6.Stop()
            cvtimer_loaddelay7.Stop()
            cvtimer_loaddelay8.Stop()
            cvtimer_loaddelay9.Stop()
            cvtimer_loaddelay10.Stop()
            timcv_anten.Enabled = False
            timcv_forantencap.Enabled = False
            timcv_perfectanten.Enabled = False

            txtcv_ikiti.Text = DGtable(rate.Index, CInt(lblcv_lap.Text)).Value
            lblcv_sleepcount.Text = DGtable(sleep.Index, CInt(lblcv_lap.Text)).Value

            txtcv_color_r.Text = DGtable(color_r.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_g.Text = DGtable(color_g.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_b.Text = DGtable(color_b.Index, CInt(lblcv_lap.Text)).Value

            color_lower_limit_r = txtcv_color_r.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_g = txtcv_color_g.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_b = txtcv_color_b.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            color_upper_limit_r = txtcv_color_r.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_g = txtcv_color_g.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_b = txtcv_color_b.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            ColorAllowance = DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            lblcv_maxval.Text = 0
            cvsleep_split.Stop()
            lblcv_sendview.Visible = False
            lblsleeptime.Visible = False

            lblcv_maxval_reset.Text = 0
            lblcv_nowmaxval_reset.Text = 0

            txtcv_antentime.Text = 0
            txtdelay_load.Text = 0




            If chkcv_monitor.Checked = True Then
                chknow_monitor.Checked = True
                onetimematching() '★
            End If

            If chkcv_resetonoff.Checked = True Then
                chknow_reset.Checked = True
                onetimematching_reset() '★
            End If

            If chkcv_loadremover.Checked = True Then

                If chkload1.Checked = True Then
                    chknow_load1.Checked = True

                End If

                If chkload2.Checked = True Then
                    chknow_load2.Checked = True

                End If

                If chkload3.Checked = True Then
                    chknow_load3.Checked = True

                End If

                If chkload4.Checked = True Then
                    chknow_load4.Checked = True

                End If

                If chkload5.Checked = True Then
                    chknow_load5.Checked = True

                End If

                If chkload6.Checked = True Then
                    chknow_load6.Checked = True

                End If

                If chkload7.Checked = True Then
                    chknow_load7.Checked = True

                End If

                If chkload8.Checked = True Then
                    chknow_load8.Checked = True

                End If

                If chkload9.Checked = True Then
                    chknow_load9.Checked = True

                End If

                If chkload10.Checked = True Then
                    chknow_load10.Checked = True

                End If
            End If

            If chkcv_monitor.Checked = True Then
                async_split_onoff = 1
                cvtimer.Start() 'なくても良い
            End If

        End If

    End Sub

    Private Sub btncv_first_Click(sender As Object, e As EventArgs) Handles btncv_first.Click

        If Not lblloading.Text = "play" Then
            Exit Sub
        End If




        '監視範囲の更新#################################################################################################
        If Not System.IO.File.Exists(txtpass_picturefolder.Text & "\" & 1 & ".bmp") Then

            MessageBox.Show(My.Resources.Message.msg7, messagebox_name,
                   MessageBoxButtons.OK) '"画像が存在しません。"
        Else

            '■グラフ更新
            Console.WriteLine("Reset")

            lbllapcount.Text = 0 + (numgraph_first.Value - 1)

            lblresetcount.Text += 1


            view_chart.lblcount.Text = lblattemptcount.Text

            table_reload_reset()


            If chkundoskip.Checked = True Then

                If chknamedpipe.Checked = True Then

                    'タイマーのプロセスを探す
                    Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

                    If 0 < ps_timer1.Length Then

                        Try


                            Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                            sw.AutoFlush = True
                            sw.WriteLine("reset" & vbCrLf)


                        Catch ex As Exception
                            MessageBox.Show(ex.ToString, messagebox_name)
                            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                        End Try




                    End If


                ElseIf chknamedpipe.Checked = False Then

                    If chkactiveapp.Checked = True Then

                        'タイマーのプロセスを探す
                        Dim ps_timer2 As Process() = Process.GetProcessesByName(cmbtimer.SelectedItem)

                        If 0 < ps_timer2.Length Then
                            '見つかった時は、アクティブにする
                            Microsoft.VisualBasic.Interaction.AppActivate(ps_timer2(0).Id)

                        End If

                        'タイマーが入力を受け付けるまでちょっと時間空ける
                        System.Threading.Thread.Sleep(numsendsleep.Value)

                        keysending_reset()

                        'Start③' アクティブを元に戻すにチェックが入っている時■■
                        If chkactivesomeapp.Checked = True Then

                            'メモ帳のプロセスを探す
                            Dim app_someapp2 As String = cmbsomeapp.SelectedItem
                            Dim ps_someapp2 As Process() = Process.GetProcessesByName(app_someapp2)

                            If 0 < ps_someapp2.Length Then
                                '見つかった時は、アクティブにする

                                Microsoft.VisualBasic.Interaction.AppActivate(ps_someapp2(0).Id)

                            End If

                        End If 'End③'■■

                    ElseIf chkactiveapp.Checked = False Then

                        keysending_reset()

                    End If

                End If

            End If


            '■ラップ番号を1にする。
            lblcv_lap.Text = 1
            lblcv_comment.Text = "Next:" & DGtable(no.Index, CInt(lblcv_lap.Text) - 0).Value '表の2列目の文字を表示
            lblcv_sendview.Text = "Match"
            Dim number As String = lblcv_lap.Text

            '■テンプレート画像の更新
            Dim aa As String = txtpass_picturefolder.Text & "\" & number & ".bmp"
            tplex = Cv2.ImRead(aa, ImreadModes.Color)

            '■該当の画像をUIにも表示        
            Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
                piccv_picture.Image = Image.FromStream(fs)
            End Using

            '■リッチテキストファイルの更新
            If chkshow_text.Checked = True Then
                Textwindow.rtxt1.LoadFile(txtpass_rtf.Text & "/" & number & ".rtf", RichTextBoxStreamType.RichText)
            End If

            '■★Methodに番号を送る。どの方式で監視を行うか。
            cv_method = DGtable(send.Index, CInt(lblcv_lap.Text) - 0).Value '表の2行目のMethod値を取得。0/1:OpenCV、2/3:RGB、4/5:RGB(色の割合)

            '後処理##########################################################################################
            cvtimer_change.Stop()
            cvtimer_changergb.Stop()
            cvtimer_loadremover1.Stop()
            cvtimer_loadremover2.Stop()
            cvtimer_loadremover3.Stop()
            cvtimer_loadremover4.Stop()
            cvtimer_loadremover5.Stop()
            cvtimer_loadremover6.Stop()
            cvtimer_loadremover7.Stop()
            cvtimer_loadremover8.Stop()
            cvtimer_loadremover9.Stop()
            cvtimer_loadremover10.Stop()
            cvtimer_loaddelay1.Stop()
            cvtimer_loaddelay2.Stop()
            cvtimer_loaddelay3.Stop()
            cvtimer_loaddelay4.Stop()
            cvtimer_loaddelay5.Stop()
            cvtimer_loaddelay6.Stop()
            cvtimer_loaddelay7.Stop()
            cvtimer_loaddelay8.Stop()
            cvtimer_loaddelay9.Stop()
            cvtimer_loaddelay10.Stop()
            timcv_anten.Enabled = False
            timcv_forantencap.Enabled = False
            timcv_perfectanten.Enabled = False

            txtcv_ikiti.Text = DGtable(rate.Index, CInt(lblcv_lap.Text)).Value
            lblcv_sleepcount.Text = DGtable(sleep.Index, CInt(lblcv_lap.Text)).Value

            txtcv_color_r.Text = DGtable(color_r.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_g.Text = DGtable(color_g.Index, CInt(lblcv_lap.Text)).Value
            txtcv_color_b.Text = DGtable(color_b.Index, CInt(lblcv_lap.Text)).Value

            color_lower_limit_r = txtcv_color_r.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_g = txtcv_color_g.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_lower_limit_b = txtcv_color_b.Text - DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            color_upper_limit_r = txtcv_color_r.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_g = txtcv_color_g.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value
            color_upper_limit_b = txtcv_color_b.Text + DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            ColorAllowance = DGtable(darkthr.Index, CInt(lblcv_lap.Text)).Value

            lblcv_maxval.Text = 0
            cvsleep_split.Stop()
            lblcv_sendview.Visible = False
            lblsleeptime.Visible = False

            lblcv_maxval_reset.Text = 0
            lblcv_nowmaxval_reset.Text = 0

            txtcv_antentime.Text = 0
            txtdelay_load.Text = 0

            txtrecord_load.Text = 0.ToString("00:00.00")
            txtrecord_load_total.Text = 0.ToString("00:00.00")


            If chkcv_monitor.Checked = True Then
                chknow_monitor.Checked = True
                onetimematching() '★
            End If

            If chkcv_resetonoff.Checked = True Then
                chknow_reset.Checked = True

            End If

            If chkcv_loadremover.Checked = True Then
                If chkload1.Checked = True Then
                    chknow_load1.Checked = True

                End If

                If chkload2.Checked = True Then
                    chknow_load2.Checked = True

                End If

                If chkload3.Checked = True Then
                    chknow_load3.Checked = True

                End If

                If chkload4.Checked = True Then
                    chknow_load4.Checked = True

                End If

                If chkload5.Checked = True Then
                    chknow_load5.Checked = True

                End If

                If chkload6.Checked = True Then
                    chknow_load6.Checked = True

                End If

                If chkload7.Checked = True Then
                    chknow_load7.Checked = True

                End If

                If chkload8.Checked = True Then
                    chknow_load8.Checked = True

                End If

                If chkload9.Checked = True Then
                    chknow_load9.Checked = True

                End If

                If chkload10.Checked = True Then
                    chknow_load10.Checked = True

                End If

            End If

            async_reset_onoff = 0 '★

            If chkcv_monitor.Checked = True Then
                async_split_onoff = 1
                cvtimer.Start()
            End If





        End If

    End Sub

    '■監視中、場所を取らない用に必要最小限の情報だけ見れるようフォームサイズを設定。■■■■■■■■■■■■■■■■■■■■■

    '■ウィンドウ最小化
    Private Sub btnsaisyouka_Click(sender As Object, e As EventArgs) Handles btnsaisyouka.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub






    '======================================================================================================================


    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■その他色々■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    '■ラベルのドラッグでウィンドウを動かす■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private mousePoint As Point
    'Form1のMouseDownイベントハンドラ
    Private Sub Form1_MouseDown(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbltitlebar.MouseDown


        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    'Form1のMouseMoveイベントハンドラ
    Private Sub Form1_MouseMove(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbltitlebar.MouseMove


        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y

        End If

    End Sub

    '=====================================================================================================================


    '■フォームを閉じた時に、コンボボックスの内容と表の内容を保存したい。■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        '■ウィンドウ位置の保存
        Dim savex As Integer = Me.Location.X
        Dim savey As Integer = Me.Location.Y

        If savex <= -10000 Then

            savex = 100

        End If


        If savey <= -10000 Then

            savey = 100

        End If

        numsavex.Value = savex
        numsavey.Value = savey


        '■各情報の保存
        Using st1 As New System.IO.StreamWriter("./savedata/01_active1.txt", False, System.Text.Encoding.Default)
            For i As Integer = 0 To cmbtimer.Items.Count - 1
                st1.WriteLine(cmbtimer.Items(i))
            Next
        End Using



        Using st2 As New System.IO.StreamWriter("./savedata/02_active2.txt", False, System.Text.Encoding.Default)
            For ii As Integer = 0 To cmbsomeapp.Items.Count - 1
                st2.WriteLine(cmbsomeapp.Items(ii))
            Next
        End Using

        Using st5 As New System.IO.StreamWriter("./savedata/03_profilelist.txt", False, System.Text.Encoding.Default)
            For iiiii As Integer = 0 To cmbprofile.Items.Count - 1
                st5.WriteLine(cmbprofile.Items(iiiii))
            Next
        End Using

        'Using st6 As New System.IO.StreamWriter("./savedata/04_resolution.txt", False, System.Text.Encoding.Default)
        '    For iiiiii As Integer = 0 To cmbcv_resolution_view.Items.Count - 1
        '        st6.WriteLine(cmbcv_resolution_view.Items(iiiiii))
        '    Next
        'End Using


        '表1（設定タブ）の保存用##############################################################################

        DGtable.AllowUserToAddRows = False


        Dim errorcount1 As Integer = 0
        Dim rowcount1 As Integer = DGtable.Rows.Count
        Dim counttablex1 As Integer
        Dim counttabley1 As Integer

        For counttablex1 = 1 To 4
            For counttabley1 = 0 To rowcount1 - 1

                Dim numbercount1 As Integer
                Dim valuetable1 As String = DGtable(counttablex1, counttabley1).Value
                Dim result1 As Boolean = Double.TryParse(valuetable1, numbercount1)

                '正数が入っていない時
                If result1 Then
                    ' If DataGridView1(counttablex1, counttabley1).Value = "" Then
                    '何もしない

                Else
                    errorcount1 += 1
                End If

            Next
        Next


        Dim errorcount As Integer = 0
        For counttabley1 = 0 To rowcount1 - 1

            '  If CStr(Form1.DataGridView1(0, aaa).Value) = "" Then
            If DGtable(no.Index, counttabley1).Value = "" Then
                errorcount1 += 1

                '    Else


            End If
        Next


        ' 'エラーチェックをしたので、このまま通過していいかどうかを判別。################################################################
        If errorcount1 <> 0 Then
            MessageBox.Show(My.Resources.Message.msg14, messagebox_name)
            '"Settingタブの表に空欄、もしくはコメント列ではない箇所に数字以外が存在するようです。適切に入力後終了してください。また、最終行の空欄を削除してみてください。"
            DGtable.AllowUserToAddRows = True

            e.Cancel = True
        Else

            Dim sfd1 As New SaveFileDialog()
            'Dim myfilename1 = "./savedata/csvfile/default.csv"
            Dim myfilename1 = "./profile/default/table.csv" '♥ここdefaultでいいの？

            CsvFileSave1(myfilename1)

        End If


        '表2（位置タブ）の保存用##############################################################################

        dgv2_template.AllowUserToAddRows = False


        Dim errorcount2 As Integer = 0
        Dim rowcount2 As Integer = dgv2_template.Rows.Count
        Dim counttablex2 As Integer
        Dim counttabley2 As Integer
        For counttablex2 = 1 To 5
            For counttabley2 = 0 To rowcount2 - 1

                Dim numbercount2 As Integer
                Dim valueposition As String = dgv2_template(counttablex2, counttabley2).Value
                Dim result2 As Boolean = Int32.TryParse(valueposition, numbercount2)

                dgv2_template(0, counttabley2).Value = ""


                If dgv2_template(counttablex2, counttabley2).Value = "" Then
                    '何もしない
                    errorcount2 += 1
                Else

                End If

            Next
        Next

        ' 'エラーチェックをしたので、このまま通過していいかどうかを判別。################################################################
        If errorcount2 <> 0 Then
            MessageBox.Show(My.Resources.Message.msg15, messagebox_name) '
            '"Window Positionタブの表に空欄があるようです。入力後終了してください。"
            dgv2_template.AllowUserToAddRows = True
            e.Cancel = True
        Else


            Dim sfd2 As New SaveFileDialog()
            Dim myfilename2 = "./savedata/position.csv"

            CsvFileSave2(myfilename2)


        End If




    End Sub

    Private Sub CsvFileSave1(ByVal myfilename1 As String)

        Dim ii As Integer
        For ii = 0 To 0


            Try

                '表示中のデータをCSV形式で(上書き保存)保存
                'Dim FileName As String = myfilename ' SaveFileName
                '現在のファイルに上書き保存
                Using swCsv As New System.IO.StreamWriter(myfilename1,
                                          False, System.Text.Encoding.UTF8) '.GetEncoding("Shift_JIS"))
                    Dim sf As String = Chr(34)          'データの前側の括り
                    Dim se As String = Chr(34) & ","    'データの後ろの括りとデータの区切りの "," 
                    Dim i, j As Integer
                    Dim WorkText As String = ""         '1個分のデータ保持用
                    Dim LineText As String = ""         '1列分のデータ保持用

                    With DGtable
                        'ヘッダー部分の取得・保存(保存する必要がなければいらない）
                        'For i = 0 To .Columns.Count - 1
                        '    WorkText = .Columns.Item(i).HeaderText
                        '    If WorkText.IndexOf(Chr(34)) > -1 Then                'データ内に " があるか検索
                        '        WorkText = WorkText.Replace("""", """""")          'あれば " を "" に置換える
                        '    End If
                        '    If i = .Columns.Count - 1 Then                        'ヘッダー行を列分連結
                        '        LineText &= sf & .Columns.Item(i).HeaderText & sf  '最後の列の場合
                        '    Else
                        '        LineText &= sf & .Columns.Item(i).HeaderText & se
                        '    End If
                        'Next i
                        'swCsv.WriteLine(LineText)                                'ヘッダーの部分の書き込み

                        '最下部の新しい行（追加オプション）を非表示にする
                        DGtable.AllowUserToAddRows = False

                        '実データ部分の取得・保存処理
                        For i = 0 To .RowCount - 1
                            LineText = ""                                         '１行分のデータをクリア
                            For j = 0 To .Columns.Count - 1                       '１行分のデータを取得処理
                                WorkText = DGtable.Item(j, i).Value.ToString              '１個セルデータを取得
                                If WorkText.IndexOf(Chr(34)) > -1 Then             'データ内に " があるか検索
                                    WorkText = WorkText.Replace("""", """""")       'あれば " を "" に置換える
                                End If
                                If j = .Columns.Count - 1 Then                     '１行分の列データを連結
                                    LineText &= sf & WorkText & sf                  '最後の列の場合
                                Else
                                    LineText &= sf & WorkText & se
                                End If
                            Next j
                            swCsv.WriteLine(LineText)                             '1行分のデータを書き込み
                        Next i
                    End With

                End Using
                'MessageBox.Show("にゃー現在表示中のデータを " & myfilename1 & " に保存しました。", "AutoSplit Helper by Image")

                DGtable.AllowUserToAddRows = True

            Catch ex As Exception

                MsgBox(My.Resources.Message.msg16, MsgBoxStyle.Exclamation)
                '"Settingタブにある表の空欄を埋めてください。もしくは、設定ファイルが開かれた状態です。変更は保存されません。"
                rtxtlog.AppendText(Now & " " & My.Resources.Message.msg16 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                DGtable.AllowUserToAddRows = True

                ' Me.Close = False
            End Try

        Next
    End Sub


    Private Sub CsvFileSave2(ByVal myfilename2 As String)

        Dim ii As Integer
        For ii = 0 To 0


            Try

                '表示中のデータをCSV形式で(上書き保存)保存
                'Dim FileName As String = myfilename ' SaveFileName
                '現在のファイルに上書き保存
                Using swCsv As New System.IO.StreamWriter(myfilename2,
                                          False, System.Text.Encoding.UTF8) '.GetEncoding("Shift_JIS"))
                    Dim sf As String = Chr(34)          'データの前側の括り
                    Dim se As String = Chr(34) & ","    'データの後ろの括りとデータの区切りの "," 
                    Dim i, j As Integer
                    Dim WorkText As String = ""         '1個分のデータ保持用
                    Dim LineText As String = ""         '1列分のデータ保持用

                    With dgv2_template
                        'ヘッダー部分の取得・保存(保存する必要がなければいらない）
                        'For i = 0 To .Columns.Count - 1
                        '    WorkText = .Columns.Item(i).HeaderText
                        '    If WorkText.IndexOf(Chr(34)) > -1 Then                'データ内に " があるか検索
                        '        WorkText = WorkText.Replace("""", """""")          'あれば " を "" に置換える
                        '    End If
                        '    If i = .Columns.Count - 1 Then                        'ヘッダー行を列分連結
                        '        LineText &= sf & .Columns.Item(i).HeaderText & sf  '最後の列の場合
                        '    Else
                        '        LineText &= sf & .Columns.Item(i).HeaderText & se
                        '    End If
                        'Next i
                        'swCsv.WriteLine(LineText)                                'ヘッダーの部分の書き込み

                        '最下部の新しい行（追加オプション）を非表示にする
                        dgv2_template.AllowUserToAddRows = False

                        '実データ部分の取得・保存処理
                        For i = 0 To .RowCount - 1
                            LineText = ""                                         '１行分のデータをクリア
                            For j = 0 To .Columns.Count - 1                       '１行分のデータを取得処理
                                WorkText = dgv2_template.Item(j, i).Value.ToString              '１個セルデータを取得
                                If j = 0 Then
                                    WorkText = ""
                                End If
                                If WorkText.IndexOf(Chr(34)) > -1 Then             'データ内に " があるか検索
                                    WorkText = WorkText.Replace("""", """""")       'あれば " を "" に置換える
                                End If
                                If j = .Columns.Count - 1 Then                     '１行分の列データを連結
                                    LineText &= sf & WorkText & sf                  '最後の列の場合
                                Else
                                    LineText &= sf & WorkText & se
                                End If
                            Next j
                            swCsv.WriteLine(LineText)                             '1行分のデータを書き込み
                        Next i
                    End With

                End Using
                'MessageBox.Show("ぴゃー現在表示中のデータを " & myfilename2 & " に保存しました。", "AutoSplit Helper by Image")

                dgv2_template.AllowUserToAddRows = True

            Catch ex As Exception

                MsgBox(My.Resources.Message.msg16, MsgBoxStyle.Exclamation)
                '"Window Positionタブにある表の空欄を埋めてください。もしくは、設定ファイルが開かれた状態です。変更は保存されません。"
                rtxtlog.AppendText(Now & " " & My.Resources.Message.msg16 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                dgv2_template.AllowUserToAddRows = True

            End Try

        Next
    End Sub


    Private Sub CsvFileSave(ByVal myfilename As String)

        Dim ii As Integer
        For ii = 0 To 0

            Try


                '表示中のデータをCSV形式で(上書き保存)保存
                'Dim FileName As String = myfilename ' SaveFileName
                '現在のファイルに上書き保存
                Using swCsv As New System.IO.StreamWriter(txtpass_csv.Text,
                                          False, System.Text.Encoding.UTF8) '.GetEncoding("Shift_JIS"))
                    Dim sf As String = Chr(34)          'データの前側の括り
                    Dim se As String = Chr(34) & ","    'データの後ろの括りとデータの区切りの "," 
                    Dim i, j As Integer
                    Dim WorkText As String = ""         '1個分のデータ保持用
                    Dim LineText As String = ""         '1列分のデータ保持用

                    With DGtable
                        'ヘッダー部分の取得・保存(保存する必要がなければいらない）
                        'For i = 0 To .Columns.Count - 1
                        '    WorkText = .Columns.Item(i).HeaderText
                        '    If WorkText.IndexOf(Chr(34)) > -1 Then                'データ内に " があるか検索
                        '        WorkText = WorkText.Replace("""", """""")          'あれば " を "" に置換える
                        '    End If
                        '    If i = .Columns.Count - 1 Then                        'ヘッダー行を列分連結
                        '        LineText &= sf & .Columns.Item(i).HeaderText & sf  '最後の列の場合
                        '    Else
                        '        LineText &= sf & .Columns.Item(i).HeaderText & se
                        '    End If
                        'Next i
                        'swCsv.WriteLine(LineText)                                'ヘッダーの部分の書き込み

                        '最下部の新しい行（追加オプション）を非表示にする
                        DGtable.AllowUserToAddRows = False

                        '実データ部分の取得・保存処理
                        For i = 0 To .RowCount - 1
                            LineText = ""                                         '１行分のデータをクリア
                            For j = 0 To .Columns.Count - 1                       '１行分のデータを取得処理
                                WorkText = DGtable.Item(j, i).Value.ToString              '１個セルデータを取得
                                If WorkText.IndexOf(Chr(34)) > -1 Then             'データ内に " があるか検索
                                    WorkText = WorkText.Replace("""", """""")       'あれば " を "" に置換える
                                End If
                                If j = .Columns.Count - 1 Then                     '１行分の列データを連結
                                    LineText &= sf & WorkText & sf                  '最後の列の場合
                                Else
                                    LineText &= sf & WorkText & se
                                End If
                            Next j
                            swCsv.WriteLine(LineText)                             '1行分のデータを書き込み
                        Next i
                    End With

                End Using
                'MessageBox.Show("現在表示中のデータを " & cmbselectedcsv.SelectedItem & " に保存しました。", "AutoSplit Helper by Image")

                DGtable.AllowUserToAddRows = True



            Catch ex As Exception

                MsgBox(My.Resources.Message.msg25, MsgBoxStyle.Exclamation) '"行内の空欄を埋めてください。"
                rtxtlog.AppendText(Now & " " & My.Resources.Message.msg25 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                DGtable.AllowUserToAddRows = True
            End Try

        Next
    End Sub






    '監視タブから移動するとき、どういう状況でもウィンドウサイズを元に戻す■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        Console.WriteLine("Tab Changed")

        Me.Size = New Drawing.Point(800 * Dpi_rate, 600 * Dpi_rate)
        DGtable.Size = New Drawing.Point(785 * Dpi_rate, 146 * Dpi_rate)

        btncv_downsize.Text = My.Resources.Message.msg35 '"たたむ"

        btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
        btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)





        'If TabControl1.SelectedIndex <> 1 Then


        '    Me.Width = 800
        '    Me.Height = 566



        'End If

        '■表示がバグることがあるのでリフレッシュ
        Me.Refresh()



    End Sub

    '===========================================================================================================================


    '■タブの制御 by TabControl1のSelectingイベントハンドラ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub TabControl1_Selecting(ByVal sender As System.Object,
    ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting

        ''監視/プレビュー中は設定タブを選択できないようにする。■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        'If btnstartopencv.Enabled = False And e.TabPageIndex = 0 Then

        '    e.Cancel = True

        'End If

    End Sub



    '■ウィンドウを閉じる。
    Private Sub btnclosewindow_Click(sender As Object, e As EventArgs) Handles btnclosewindow.Click

        DGtable.AllowUserToAddRows = False 'Trueのままだと空白セルと判断される。

        Dim rowcount1 As Integer = DGtable.Rows.Count
        Dim errorcount As Integer = 0
        For counttabley1 = 0 To rowcount1 - 1

            'If  Is Nothing OrElse Str.Length    String.IsNullOrEmpty(DataGridView1(0, counttabley1).Value) Then
            If CStr(DGtable(no.Index, counttabley1).Value) = "" Then
                errorcount += 1

            End If

        Next


        If errorcount <> 0 Then
            MessageBox.Show(My.Resources.Message.msg14, messagebox_name)
            '"Settingタブの表に空欄、もしくはコメント列ではない箇所に数字以外が存在するようです。適切に入力後終了してください。また、最終行の空欄を削除してみてください"

        Else


            '■ログの内容を書き込む

            '書き込むファイルが既に存在している場合は、ファイルの末尾に追加する
            Dim sw As New System.IO.StreamWriter("./log.txt", True, System.Text.Encoding.GetEncoding("UTF-8"))

            sw.Write(rtxtlog.Text) 'ログの内容を書き込む

            sw.Close() '閉じる


            '■設定、表に変更がある場合、確認メッセージを表示。★

            'arrayprofile_saveに現在の設定を書き込む
            Createarrayprofile()

            Dim Setting_changeTF As Integer = 0

            For i = 0 To 128
                If Not arrayprofile_before(i) = arrayprofile_save(i) Then
                    Setting_changeTF = 1
                    Console.WriteLine("SettingTF array: " & i)

                End If
            Next

            If Setting_changeTF = 1 Or DGtable_changeTF = 1 Then
                Console.WriteLine("Setting: " & Setting_changeTF & ", DGTable: " & DGtable_changeTF)
                'メッセージボックスを表示する 
                Dim result As DialogResult = MessageBox.Show(My.Resources.Message.msge01,
                                             "質問",
                                             MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Exclamation,
                                             MessageBoxDefaultButton.Button2) '設定/表の内容が変更されています。上書きしますか？

                '何が選択されたか調べる 
                If result = DialogResult.Yes Then
                    '「はい」が選択された時 
                    Console.WriteLine("設定上書き「はい」が選択されました")
                    btnaddprofile.PerformClick()
                    Me.Close()

                ElseIf result = DialogResult.No Then
                    '「いいえ」が選択された時 
                    Console.WriteLine("設定上書き「いいえ」が選択されました")
                    Me.Close()

                ElseIf result = DialogResult.Cancel Then
                    '「キャンセル」が選択された時 
                    Console.WriteLine("設定上書き「キャンセル」が選択されました")
                    Exit Sub

                End If

            Else

                Me.Close()


            End If


        End If



    End Sub



    Private Sub btnaddprofile_Click(sender As Object, e As EventArgs) Handles btnaddprofile.Click

        'New profile/Add profileに類似記述
        Dim sameitem As Integer = cmbprofile.Items.IndexOf(cmbprofile.Text)
        If sameitem = -1 Then

            Console.Write("New!")
            cmbprofile.Items.Add(cmbprofile.Text)

            '♥
            'pictureフォルダのコピー
            My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, "./profile/" & cmbprofile.Text & "/picture/",
                FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            'textフォルダのコピー
            My.Computer.FileSystem.CopyDirectory(txtpass_rtf.Text, "./profile/" & cmbprofile.Text & "/text/",
                FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            'csvファイルのコピー
            System.IO.File.Copy(txtpass_csv.Text, "./profile/" & cmbprofile.Text & "/table.csv", True)

            txtpass_picturefolder.Text = "./profile/" & cmbprofile.Text & "/picture"
            txtpass_rtf.Text = "./profile/" & cmbprofile.Text & "/text"
            txtpass_csv.Text = "./profile/" & cmbprofile.Text & "/table.csv"

        End If


        cmbprofile.SelectedItem = cmbprofile.Text




        Createarrayprofile()


        txtprofile.Clear()
        For ii = 0 To arrayprofile_save.Count - 1
            txtprofile.AppendText(arrayprofile_save(ii) & vbCrLf)
        Next

        Dim sw As New System.IO.StreamWriter("./profile/" & cmbprofile.SelectedItem & "/data.txt", False,
                                             System.Text.Encoding.UTF8) '.GetEncoding("Shift_JIS"))

        sw.Write(txtprofile.Text)

        sw.Close()

        '■csvファイルの保存
        Dim sfd As New SaveFileDialog()
        Dim myfilename = sfd.FileName

        CsvFileSave(myfilename)


        DGtable_changeTF = 0 'CSV保存したので変更有無の初期化★

        For i = 0 To 128
            arrayprofile_before(i) = arrayprofile_save(i) '設定保存したのでarraybeforeを更新★
        Next
        Console.WriteLine("Arrayprofile_before更新")

        MessageBox.Show("Saved.", messagebox_name)





    End Sub

    Private Sub saveprofile_nomessage()


        'New profile/Add profileに類似記述
        Dim sameitem As Integer = cmbprofile.Items.IndexOf(cmbprofile.Text)
        If sameitem = -1 Then

            Console.Write("New!")
            cmbprofile.Items.Add(cmbprofile.Text)

            '♥
            'pictureフォルダのコピー
            My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, "./profile/" & cmbprofile.Text & "/picture/",
                FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            'textフォルダのコピー
            My.Computer.FileSystem.CopyDirectory(txtpass_rtf.Text, "./profile/" & cmbprofile.Text & "/text/",
                FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            'csvファイルのコピー
            System.IO.File.Copy(txtpass_csv.Text, "./profile/" & cmbprofile.Text & "/table.csv", True)

            txtpass_picturefolder.Text = "./profile/" & cmbprofile.Text & "/picture"
            txtpass_rtf.Text = "./profile/" & cmbprofile.Text & "/text"
            txtpass_csv.Text = "./profile/" & cmbprofile.Text & "/table.csv"

        End If

        cmbprofile.SelectedItem = cmbprofile.Text


        Createarrayprofile()


        txtprofile.Clear()
        For ii = 0 To arrayprofile_save.Count - 1
            txtprofile.AppendText(arrayprofile_save(ii) & vbCrLf)
        Next

        Dim sw As New System.IO.StreamWriter("./profile/" & cmbprofile.SelectedItem & "/data.txt", False,
                                             System.Text.Encoding.UTF8) '.GetEncoding("Shift_JIS"))

        sw.Write(txtprofile.Text)

        sw.Close()

        '■csvファイルの保存
        Dim sfd As New SaveFileDialog()
        Dim myfilename = sfd.FileName

        CsvFileSave(myfilename)





    End Sub



    Private Sub btndeleteprofile_Click(sender As Object, e As EventArgs) Handles btndeleteprofile.Click

        If cmbprofile.SelectedItem = "default" Then
            MessageBox.Show(My.Resources.Message.msg47, messagebox_name) 'defaultは削除できません。

            Exit Sub
        End If

        'メッセージボックスを表示する 
        Dim result As DialogResult = MessageBox.Show(My.Resources.Message.msg18,
                                                     My.Resources.Message.msg19,
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Exclamation,
                                                     MessageBoxDefaultButton.Button2) '"消去しますか？""質問"

        '何が選択されたか調べる 
        If result = DialogResult.Yes Then

            Try
                ' System.IO.File.Delete("./profile/" & cmbprofile.SelectedItem & "/data.txt")
                System.IO.File.Delete("./profile/" & cmbprofile.SelectedItem & "/data.txt")



                System.IO.Directory.Delete(txtpass_picturefolder.Text, True)
                System.IO.Directory.Delete(txtpass_rtf.Text, True)
                System.IO.File.Delete(txtpass_csv.Text)
                System.IO.Directory.Delete("./profile/" & cmbprofile.SelectedItem, True)

                cmbprofile.Items.RemoveAt(cmbprofile.SelectedIndex)
                cmbprofile.SelectedIndex = 0 '"default"

            Catch ex As Exception
                MessageBox.Show(My.Resources.Message.msg26 & vbCrLf & My.Resources.Message.msg27, messagebox_name)
                '"csvファイルor画像フォルダの消去に失敗しました。" "※1度でも監視を行った場合、再起動の後プロファイルを削除して下さい。"
                rtxtlog.AppendText(Now & " " & My.Resources.Message.msg26 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

            End Try

        End If



    End Sub

    Sub deleteprofile_nomessage()

        If cmbprofile.SelectedItem = "default" Then
            MessageBox.Show(My.Resources.Message.msg47, messagebox_name) 'defaultは削除できません。

            Exit Sub
        End If



        Try
            ' System.IO.File.Delete("./profile/" & cmbprofile.SelectedItem & "/data.txt")
            System.IO.File.Delete("./profile/" & cmbprofile.SelectedItem & "/data.txt")



            System.IO.Directory.Delete(txtpass_picturefolder.Text, True)
            System.IO.Directory.Delete(txtpass_rtf.Text, True)
            System.IO.File.Delete(txtpass_csv.Text)
            System.IO.Directory.Delete("./profile/" & cmbprofile.SelectedItem, True)

            cmbprofile.Items.RemoveAt(cmbprofile.SelectedIndex)
            cmbprofile.SelectedIndex = 0 '"default"

        Catch ex As Exception
            MessageBox.Show(My.Resources.Message.msg26 & vbCrLf & My.Resources.Message.msg27, messagebox_name)
            '"csvファイルor画像フォルダの消去に失敗しました。" "※1度でも監視を行った場合、再起動の後プロファイルを削除して下さい。"
            rtxtlog.AppendText(Now & " " & My.Resources.Message.msg26 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try





    End Sub



    Private Sub cmbprofile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbprofile.SelectedIndexChanged

        'コンボボックス読み込み3■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
        If System.IO.File.Exists("./profile/" & cmbprofile.SelectedItem & "/data.txt") Then

            '■設定、表に変更がある場合、確認メッセージを表示（起動時を除く）。★
            If ASH_state = 0 Then
                'チェックしない

            ElseIf ASH_state = 1 Then

                Createarrayprofile()  'arrayprofile_saveに現在の設定を書き込む

                Dim Setting_changeTF As Integer = 0

                For i = 0 To 128
                    If Not arrayprofile_before(i) = arrayprofile_save(i) Then
                        Setting_changeTF = 1

                    End If

                Next

                If Setting_changeTF = 1 Or DGtable_changeTF = 1 Then
                    'メッセージボックスを表示する 
                    Dim result As DialogResult = MessageBox.Show(My.Resources.Message.msge02,
                                                 "質問",
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxIcon.Exclamation,
                                                 MessageBoxDefaultButton.Button2) '設定/表の内容が変更されています。OKを押すと未保存のままプロファイルが変更されます。

                    '何が選択されたか調べる 
                    If result = DialogResult.OK Then
                        '「はい」が選択された時 
                        Console.WriteLine("設定変更「OK」が選択されました")


                    ElseIf result = DialogResult.Cancel Then
                        '「キャンセル」が選択された時 
                        Console.WriteLine("設定変更「キャンセル」が選択されました")
                        '一時的にコンボボックスのイベントを無効にする。
                        RemoveHandler cmbprofile.SelectedIndexChanged, AddressOf cmbprofile_SelectedIndexChanged
                        cmbprofile.SelectedIndex = numprofile.Value
                        AddHandler cmbprofile.SelectedIndexChanged, AddressOf cmbprofile_SelectedIndexChanged

                        Exit Sub

                    End If

                End If

            End If



            '■仮想カメラの切断
            If btnconnect_camera.Text = My.Resources.Message.msgc01 Then

            ElseIf btnconnect_camera.Text = My.Resources.Message.msgc02 Then

                btncur_webcamera.Enabled = False
                btnconnect_camera.Enabled = False
                btnresetup.Enabled = False

                btnconnect_camera.Text = My.Resources.Message.msgc01
                btncur_webcamera.Text = My.Resources.Message.msgc01

                capturecv.Release()

                btnstartopencv.Enabled = False

                btnconnect_camera.BackColor = Color.FromArgb(50, 52, 54)
                btncur_webcamera.BackColor = Color.FromArgb(50, 52, 54)

                webcam_sleep.Start()

            End If

            Dim loadtxt As String = "./profile/" & cmbprofile.SelectedItem & "/data.txt"

            cmbprofile.IntegralHeight = False

            cmbprofile.BeginUpdate()
            txtloadprofile.Clear()
            Dim st3 As New System.IO.StreamReader(loadtxt, System.Text.Encoding.Default)
            'ファイルの最後までループ
            Do Until st3.Peek = -1
                '１行づつ読込む
                txtloadprofile.AppendText(st3.ReadLine & vbCrLf)
            Loop
            ' txtloadprofile.Text = System.Text.RegularExpressions.Regex.Replace(txtloadprofile.Text & vbNewLine, "(\s+\r\n)+\z", "") '最後の空白行を取り除く
            st3.Close()              'ファイルを閉じる

            cmbprofile.EndUpdate()   'コントロールの描画を再開

            For i = 0 To 128
                arrayprofile_before(i) = txtloadprofile.Lines(i)
                'Console.WriteLine(arrayprofile_before(i))
            Next


            '各パラメーターを読む
            txtpass_csv.Text = txtloadprofile.Lines(1)
            txtpass_picturefolder.Text = txtloadprofile.Lines(2)
            txtpass_rtf.Text = txtloadprofile.Lines(3)

            numsavex.Value = txtloadprofile.Lines(6)
            numsavey.Value = txtloadprofile.Lines(7)

            chkcv_monitor.Checked = txtloadprofile.Lines(10)
            chkcv_loop.Checked = txtloadprofile.Lines(11)
            chkcv_resetonoff.Checked = txtloadprofile.Lines(12)
            chkcv_loadremover.Checked = txtloadprofile.Lines(13)
            numpercent.Value = txtloadprofile.Lines(14)
            numstop.Value = txtloadprofile.Lines(15)
            numanten.Value = txtloadprofile.Lines(16)
            numcv_interval.Value = txtloadprofile.Lines(17)

            cmbcv_device.SelectedIndex = txtloadprofile.Lines(20)
            cmbcv_resolution_input.SelectedIndex = txtloadprofile.Lines(21)
            cmbcv_resolution_view.SelectedIndex = txtloadprofile.Lines(22)
            numcv_framerate.Value = txtloadprofile.Lines(23)
            chkcv_crop.Checked = txtloadprofile.Lines(24)
            txtcv_crop_posx.Text = txtloadprofile.Lines(25)
            txtcv_crop_posy.Text = txtloadprofile.Lines(26)
            txtcv_crop_sizex.Text = txtloadprofile.Lines(27)
            txtcv_crop_sizey.Text = txtloadprofile.Lines(28)
            chkcv_grayscale.Checked = txtloadprofile.Lines(29)

            chkactiveapp.Checked = txtloadprofile.Lines(32)
            cmbtimer.SelectedItem = txtloadprofile.Lines(33)
            chkactivesomeapp.Checked = txtloadprofile.Lines(34)
            cmbsomeapp.SelectedItem = txtloadprofile.Lines(35)
            numsendsleep.Value = txtloadprofile.Lines(36)

            chkshift.Checked = txtloadprofile.Lines(39)
            chkctrl.Checked = txtloadprofile.Lines(40)
            chkalt.Checked = txtloadprofile.Lines(41)
            txtsplit_key.Text = txtloadprofile.Lines(42)
            lblkeysforsend.Text = txtloadprofile.Lines(43)
            chkshift_reset.Checked = txtloadprofile.Lines(44)
            chkctrl_reset.Checked = txtloadprofile.Lines(45)
            chkalt_reset.Checked = txtloadprofile.Lines(46)
            txtreset_key.Text = txtloadprofile.Lines(47)
            lblkeysforsend_reset.Text = txtloadprofile.Lines(48)
            chkshift_undo.Checked = txtloadprofile.Lines(49)
            chkctrl_undo.Checked = txtloadprofile.Lines(50)
            chkalt_undo.Checked = txtloadprofile.Lines(51)
            txtundo_key.Text = txtloadprofile.Lines(52)
            lblkeysforundo.Text = txtloadprofile.Lines(53)
            chkshift_skip.Checked = txtloadprofile.Lines(54)
            chkctrl_skip.Checked = txtloadprofile.Lines(55)
            chkalt_skip.Checked = txtloadprofile.Lines(56)
            txtskip_key.Text = txtloadprofile.Lines(57)
            lblkeysforskip.Text = txtloadprofile.Lines(58)
            chkshift_pause.Checked = txtloadprofile.Lines(59)
            chkctrl_pause.Checked = txtloadprofile.Lines(60)
            chkalt_pause.Checked = txtloadprofile.Lines(61)
            txtpause_key.Text = txtloadprofile.Lines(62)
            lblkeysforpause.Text = txtloadprofile.Lines(63)
            chkshift_resume.Checked = txtloadprofile.Lines(64)
            chkctrl_resume.Checked = txtloadprofile.Lines(65)
            chkalt_resume.Checked = txtloadprofile.Lines(66)
            txtresume_key.Text = txtloadprofile.Lines(67)
            lblkeysforresume.Text = txtloadprofile.Lines(68)
            txtreset_ash_key.Text = txtloadprofile.Lines(69)
            numreset_ash.Value = txtloadprofile.Lines(70)
            txtundo_ash_key.Text = txtloadprofile.Lines(71)
            numundo_ash.Value = txtloadprofile.Lines(72)
            txtskip_ash_key.Text = txtloadprofile.Lines(73)
            numskip_ash.Value = txtloadprofile.Lines(74)
            chkundoskip.Checked = txtloadprofile.Lines(75)
            chknamedpipe.Checked = txtloadprofile.Lines(76)
            numpresstime.Value = txtloadprofile.Lines(77)

            chkload1.Checked = txtloadprofile.Lines(80)
            chkload2.Checked = txtloadprofile.Lines(81)
            chkload3.Checked = txtloadprofile.Lines(82)
            chkload4.Checked = txtloadprofile.Lines(83)
            chkload5.Checked = txtloadprofile.Lines(84)
            chkload6.Checked = txtloadprofile.Lines(85)
            chkload7.Checked = txtloadprofile.Lines(86)
            chkload8.Checked = txtloadprofile.Lines(87)
            chkload9.Checked = txtloadprofile.Lines(88)
            chkload10.Checked = txtloadprofile.Lines(89)
            numload_rate1.Value = txtloadprofile.Lines(90)
            numload_rate2.Value = txtloadprofile.Lines(91)
            numload_rate3.Value = txtloadprofile.Lines(92)
            numload_rate4.Value = txtloadprofile.Lines(93)
            numload_rate5.Value = txtloadprofile.Lines(94)
            numload_rate6.Value = txtloadprofile.Lines(95)
            numload_rate7.Value = txtloadprofile.Lines(96)
            numload_rate8.Value = txtloadprofile.Lines(97)
            numload_rate9.Value = txtloadprofile.Lines(98)
            numload_rate10.Value = txtloadprofile.Lines(99)
            numload_delay1.Value = txtloadprofile.Lines(100)
            numload_delay2.Value = txtloadprofile.Lines(101)
            numload_delay3.Value = txtloadprofile.Lines(102)
            numload_delay4.Value = txtloadprofile.Lines(103)
            numload_delay5.Value = txtloadprofile.Lines(104)
            numload_delay6.Value = txtloadprofile.Lines(105)
            numload_delay7.Value = txtloadprofile.Lines(106)
            numload_delay8.Value = txtloadprofile.Lines(107)
            numload_delay9.Value = txtloadprofile.Lines(108)
            numload_delay10.Value = txtloadprofile.Lines(109)

            numgraph_first.Value = txtloadprofile.Lines(112)
            chkrename_livesplit.Checked = txtloadprofile.Lines(113)
            numloopcount.Value = txtloadprofile.Lines(114)

            chkshowvideo.Checked = txtloadprofile.Lines(117)
            chkvideo_autoseek.Checked = txtloadprofile.Lines(118)
            chkvideo_manualstart.Checked = txtloadprofile.Lines(119)
            txtvideo_pass.Text = txtloadprofile.Lines(120)
            txtvideo_startat.Text = txtloadprofile.Lines(121)
            numvideo_sizex.Value = txtloadprofile.Lines(122)
            numvideo_sizey.Value = txtloadprofile.Lines(123)
            chkvideo_showwinvideo.Checked = txtloadprofile.Lines(124)
            numwin_locx.Value = txtloadprofile.Lines(125)
            numwin_locy.Value = txtloadprofile.Lines(126)
            numwin_interval.Value = txtloadprofile.Lines(127)

            chkshow_text.Checked = txtloadprofile.Lines(130)
            numtextwindow_sizex.Value = txtloadprofile.Lines(131)
            numtextwindow_sizey.Value = txtloadprofile.Lines(132)

            chkmonitor_sizestate.Checked = txtloadprofile.Lines(135)




            Dim parser As TextFieldParser = New TextFieldParser(txtpass_csv.Text, Encoding.UTF8) '.GetEncoding("Shift_JIS"))
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",") ' 区切り文字はコンマ


            ' データをすべてクリア
            DGtable.Rows.Clear()

            While (Not parser.EndOfData)
                Dim row As String() = parser.ReadFields() ' 1行読み込み
                ' 読み込んだデータ(1行をDataGridViewに表示する)
                DGtable.Rows.Add(row)

            End While

            For Each c As DataGridViewColumn In DGtable.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c
            For Each c As DataGridViewColumn In DGtable.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c

            parser.Close()


            '■リセットの部分の背景変更
            DGtable.Rows(0).DefaultCellStyle.BackColor = Color.FromArgb(58, 16, 16) 'Color.MistyRose

            numprofile.Value = cmbprofile.SelectedIndex '選択保存用

            lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " AutoSplit Helper by Image " & lblversion.Text



            '■Current Settingに反映

            If chkcv_monitor.Checked = True Then
                lblcur_split.BackColor = Color.Maroon
            Else
                lblcur_split.BackColor = Color.FromArgb(80, 90, 95)

            End If


            If chkcv_resetonoff.Checked = True Then
                lblcur_reset.BackColor = Color.Maroon
            Else
                lblcur_reset.BackColor = Color.FromArgb(80, 90, 95)

            End If



            If chkcv_loop.Checked = True Then
                lblcur_loop.BackColor = Color.Maroon
                lblcur_loopcount.BackColor = Color.Maroon

            Else
                lblcur_loop.BackColor = Color.FromArgb(80, 90, 95)
                lblcur_loopcount.BackColor = Color.FromArgb(80, 90, 95)

            End If


            If chkcv_loadremover.Checked = True Then
                lblcur_load.BackColor = Color.Maroon
            Else
                lblcur_load.BackColor = Color.FromArgb(80, 90, 95)

            End If

            If chkload1.Checked = True Then
                lblcur_load1.BackColor = Color.Maroon
            Else
                lblcur_load1.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload2.Checked = True Then
                lblcur_load2.BackColor = Color.Maroon
            Else
                lblcur_load2.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload3.Checked = True Then
                lblcur_load3.BackColor = Color.Maroon
            Else
                lblcur_load3.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload4.Checked = True Then
                lblcur_load4.BackColor = Color.Maroon
            Else
                lblcur_load4.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload5.Checked = True Then
                lblcur_load5.BackColor = Color.Maroon
            Else
                lblcur_load5.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload6.Checked = True Then
                lblcur_load6.BackColor = Color.Maroon
            Else
                lblcur_load6.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload7.Checked = True Then
                lblcur_load7.BackColor = Color.Maroon
            Else
                lblcur_load7.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload8.Checked = True Then
                lblcur_load8.BackColor = Color.Maroon
            Else
                lblcur_load8.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload9.Checked = True Then
                lblcur_load9.BackColor = Color.Maroon
            Else
                lblcur_load9.BackColor = Color.FromArgb(80, 90, 95)
            End If

            If chkload10.Checked = True Then
                lblcur_load10.BackColor = Color.Maroon
            Else
                lblcur_load10.BackColor = Color.FromArgb(80, 90, 95)
            End If





            If chkvideo_manualstart.Checked = True Then '♥
                txtvideo_startat.Enabled = True

            ElseIf chkvideo_manualstart.Checked = False Then
                txtvideo_startat.Enabled = False

            End If

            If chkshowvideo.Checked = True Then
                lblcur_showvideo.BackColor = Color.Maroon
                lblcur_showvideo.Text = "Y"
            Else
                lblcur_showvideo.BackColor = Color.FromArgb(80, 90, 95)
                lblcur_showvideo.Text = "N"
            End If

            If chkshow_text.Checked = True Then
                lblcur_showtextwindow.BackColor = Color.Maroon
                lblcur_showtextwindow.Text = "Y"
            Else
                lblcur_showtextwindow.BackColor = Color.FromArgb(80, 90, 95)
                lblcur_showtextwindow.Text = "N"
            End If




            lblcur_loopcount.Text = "[" & numloopcount.Value & "]"

            lblcur_interval.Text = numcv_interval.Value & "ms"

            lblcur_device_name.Text = cmbcv_device.SelectedItem


            lblcur_device_res_fps.Text = cmbcv_resolution_view.SelectedItem & " - " & numcv_framerate.Value & "fps"

            If chkactiveapp.Checked = True Then
                lblcur_focus_before.Text = cmbtimer.SelectedItem

            Else
                lblcur_focus_before.Text = "None"

            End If


            If chkactivesomeapp.Checked = True Then
                lblcur_focus_after.Text = cmbsomeapp.SelectedItem

            Else
                lblcur_focus_after.Text = "None"

            End If


            If chkundoskip.Checked = True Then
                lblcur_rendou.Text = "ON"

            Else
                lblcur_rendou.Text = "OFF"

            End If

            If chknamedpipe.Checked = True Then
                lblcur_namedpipe.Text = "YES"

            Else
                lblcur_namedpipe.Text = "NO"

            End If

            If chkrename_livesplit.Checked = True Then
                lblcur_addcount.Text = "YES"
            Else
                lblcur_addcount.Text = "NO"

            End If

            DGtable_changeTF = 0 'DGTableの変更履歴リセット

        End If






    End Sub


    Private Sub btncv_downsize_Click(sender As Object, e As EventArgs) Handles btncv_downsize.Click
        If btncv_downsize.Text = My.Resources.Message.msg35 Then '"たたむ"
            btncv_downsize.Text = My.Resources.Message.msg36 '"広げる"
            Me.Size = New Drawing.Size(288 * Dpi_rate, 155 * Dpi_rate)


            btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
            btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)

            chkmonitor_sizestate.Checked = False

        ElseIf btncv_downsize.Text = My.Resources.Message.msg36 Then '"広げる"
            btncv_downsize.Text = My.Resources.Message.msg35 '"たたむ"

            Me.Size = New Drawing.Size(800 * Dpi_rate, 562 * Dpi_rate)

            btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
            btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)

            chkmonitor_sizestate.Checked = True

        End If

        '■表示がバグることがあるのでリフレッシュ
        Me.Refresh()

    End Sub

    Private Sub Newcsv()


        Dim inputText As String

        inputText = InputBox(My.Resources.Message.msg37, My.Resources.Message.msg38, "New", Me.Location.X + 50, Me.Location.Y + 95)
        '"プロファイル名を入力して下さい。""プロファイル新規作成"
        If inputText = "" Then
            'MessageBox.Show("キャンセルされました。", "AutoSplit Helper by Image")
            Exit Sub
        End If

        If System.IO.File.Exists("./profile/" & inputText & "/data.csv") Then
            MessageBox.Show(inputText & My.Resources.Message.msg20, messagebox_name) '"は既に存在しています。"
        Else

            ' フォルダ (ディレクトリ) を作成する
            System.IO.Directory.CreateDirectory("./profile/" & inputText & "/picture/")
            txtpass_picturefolder.Text = "./profile/" & inputText & "/picture"

            ' フォルダ (ディレクトリ) を作成する
            System.IO.Directory.CreateDirectory("./profile/" & inputText & "/text/")
            txtpass_rtf.Text = "./profile/" & inputText & "/text"



            ' 戻り値を格納する変数を宣言する
            Dim hStream As System.IO.FileStream

            ' hStream が破棄されることを保証するために Try ～ Finally を使用する
            Try
                ' hStream が閉じられることを保証するために Try ～ Finally を使用する
                Try
                    ' 指定したパスのファイルを作成する
                    hStream = System.IO.File.Create("./profile/" & inputText & "/table.csv")
                    txtpass_csv.Text = "./profile/" & inputText & "/table.csv"

                Finally
                    ' 作成時に返される FileStream を利用して閉じる
                    If Not hStream Is Nothing Then
                        hStream.Close()
                    End If
                End Try
            Finally
                ' hStream を破棄する
                If Not hStream Is Nothing Then
                    Dim cDisposable As System.IDisposable = hStream
                    cDisposable.Dispose()
                End If
            End Try

            '■ブランクファイルを読み込む
            Dim parser As TextFieldParser = New TextFieldParser("./savedata/blank.csv", Encoding.UTF8) '.GetEncoding("Shift_JIS"))
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",") ' 区切り文字はコンマ

            ' データをすべてクリア
            DGtable.Rows.Clear()




            While (Not parser.EndOfData)
                Dim row As String() = parser.ReadFields() ' 1行読み込み
                ' 読み込んだデータ(1行をDataGridViewに表示する)
                DGtable.Rows.Add(row)

            End While

            For Each c As DataGridViewColumn In DGtable.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c
            For Each c As DataGridViewColumn In DGtable.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c

            parser.Close()


            DGtable.Rows.Add()

            Adjust_table()


            '■表へ各パラメータを代入。
            DGtable(no.Index, 0).Value = "Reset"
            DGtable(send.Index, 0).Value = 1
            DGtable(key.Index, 0).Value = 0
            DGtable(rate.Index, 0).Value = 95
            DGtable(sleep.Index, 0).Value = numstop.Text
            DGtable(timing.Index, 0).Value = 0
            DGtable(posx.Index, 0).Value = (numcv_sizex.Text / 2) - 20 'lblform2_posx.Text
            DGtable(posy.Index, 0).Value = (numcv_sizey.Text / 2) - 20 'lblform2_posy.Text
            DGtable(sizex.Index, 0).Value = 40
            DGtable(sizey.Index, 0).Value = 40
            DGtable(darksleep.Index, 0).Value = 0
            DGtable(darkthr.Index, 0).Value = numanten.Text
            DGtable(ltx.Index, 0).Value = 0
            DGtable(lty.Index, 0).Value = 0
            DGtable(rbx.Index, 0).Value = 1000
            DGtable(rby.Index, 0).Value = 1000

            DGtable(graph_count.Index, 0).Value = 0
            DGtable(graph_rate.Index, 0).Value = 0
            DGtable(graph_view.Index, 0).Value = 0

            DGtable(color_r.Index, 0).Value = 0
            DGtable(color_g.Index, 0).Value = 0
            DGtable(color_b.Index, 0).Value = 0


            DGtable(seektime.Index, 0).Value = -1



            'プロファイルを作成
            cmbprofile.Text = inputText



            'New profile/Add profileに類似記述
            Dim sameitem As Integer = cmbprofile.Items.IndexOf(cmbprofile.Text)
            If sameitem = -1 Then
                cmbprofile.Items.Add(cmbprofile.Text)
            End If

            cmbprofile.SelectedItem = cmbprofile.Text


            Createarrayprofile()


            txtprofile.Clear()
            For ii = 0 To arrayprofile_save.Count - 1
                txtprofile.AppendText(arrayprofile_save(ii) & vbCrLf)
            Next

            Dim sw As New System.IO.StreamWriter("./profile/" & cmbprofile.SelectedItem & "/data.txt", False,
                                                 System.Text.Encoding.UTF8) '.GetEncoding("Shift_JIS"))

            sw.Write(txtprofile.Text)

            sw.Close()

            '■csvファイルの保存
            Dim sfd As New SaveFileDialog()
            Dim myfilename = sfd.FileName

            CsvFileSave(myfilename)


            '■リセットの部分の背景変更
            DGtable.Rows(0).DefaultCellStyle.BackColor = Color.FromArgb(58, 16, 16) 'Color.MistyRose

            lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " AutoSplit Helper by Image " & lblversion.Text

            MessageBox.Show("Created.", messagebox_name)



            numprofile.Value = cmbprofile.SelectedIndex '選択保存用




        End If

    End Sub


    Private Sub Tableview_()

        Me.Size = New Drawing.Point(1111 * Dpi_rate, 600 * Dpi_rate)

        btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
        btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)


        DGtable.Height = 457 '♥
        DGtable.Width = 1097



        tableview.Show()

    End Sub

    Private Sub btnclosetable_Click(sender As Object, e As EventArgs) Handles btnclosetable.Click

        Me.Size = New Drawing.Point(800 * Dpi_rate, 600 * Dpi_rate)
        DGtable.Size = New Drawing.Point(785 * Dpi_rate, 146 * Dpi_rate)

        btnclosewindow.Location = New Drawing.Point((Me.Width - btnclosewindow.Width), 0)
        btnsaisyouka.Location = New Drawing.Point((Me.Width - btnclosewindow.Width - btnsaisyouka.Width), 0)

    End Sub








    '■■■■ウィンドウ位置設定タブ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    '■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■


    Private Sub btn2_gethwnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2_gethwnd.Click
        Me.rich2_hwnddetail.Clear()
        Me.list2_hwnd.Items.Clear()
        Me.lbl2_parent_kid.Text = "-(親ハンドル)-"

        EnumWindows(AddressOf MakeList1, 0)
    End Sub

    Private Sub btn2_gethwnd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2_gethwnd2.Click
        Me.rich2_hwnddetail.Clear()
        Me.list2_hwnd2.Items.Clear()
        Me.lbl2_parent_kid.Text = "-(子ハンドル)-"

        Dim num As Integer
        If Me.list2_hwnd.Text = "" Then
            num = 0
        Else
            num = CInt(Me.list2_hwnd.Text)
        End If

        EnumChildWindows(num, AddressOf MakeList2, 0)
    End Sub

    Public Function MakeList1(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean
        result(hwnd, "parent")
        Return True
    End Function

    Public Function MakeList2(ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean
        result(hwnd, "child")
        Return True
    End Function

    Public Sub result(ByVal hwnd As IntPtr, ByVal mode As String)
        Dim length As Integer
        length = SendMessage(hwnd, WM_GETTEXTLENGTH, 0, 0)


        Dim Ret As Integer, sb = New StringBuilder
        sb = New StringBuilder("", length + 1)
        Ret = SendMessageStr(hwnd, WM_GETTEXT, length + 1, sb)


        Dim title As String
        If mode = "parent" Then
            title = txt2_Selectedwindowtitle.Text
        ElseIf mode = "child" Then
            title = txt2_windowtitle2.Text
        Else
            MessageBox.Show("ぱらめ異常", messagebox_name)
            Exit Sub
        End If


        If title <> "" AndAlso -1 < sb.ToString.IndexOf(title) Then
            If mode = "parent" Then
                Me.list2_hwnd.Items.Add(hwnd.ToString)
            ElseIf mode = "child" Then
                Me.list2_hwnd2.Items.Add(hwnd.ToString)
            Else
                MessageBox.Show("ぱらめ異常", messagebox_name)
                Exit Sub
            End If
        End If


        Dim Str As String
        If sb.ToString <> "" Then
            Str = String.Format("{0:D8}", CInt(hwnd.ToString)) & "：" & sb.ToString & vbCrLf
        Else
            Str = String.Format("{0:D8}", CInt(hwnd.ToString)) & "：" & vbCrLf
        End If

        Me.rich2_hwnddetail.Text = Me.rich2_hwnddetail.Text + Str


    End Sub

    Private Sub list2_hwnd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list2_hwnd.SelectedIndexChanged
        If list2_hwnd.Text <> "" Then
            Me.btn2_gethwnd2.Enabled = True
        End If


        txt2_selectedhwnd.Text = list2_hwnd.SelectedItem

    End Sub

    Private Sub txt2_Selectedwindowtitle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt2_Selectedwindowtitle.TextChanged
        Me.list2_hwnd.Items.Clear()
        Me.btn2_gethwnd2.Enabled = False
    End Sub

    Private Sub txt2_windowtitle2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt2_windowtitle2.TextChanged
        Me.list2_hwnd2.Items.Clear()
    End Sub

    Private Sub btn2_getwindowtitle_Click(sender As Object, e As EventArgs) Handles btn2_getwindowtitle.Click
        list2_alltitle.Items.Clear()


        '全てのプロセスを列挙する
        Dim p As System.Diagnostics.Process
        For Each p In System.Diagnostics.Process.GetProcesses()
            'メインウィンドウのタイトルがある時だけ列挙する
            If p.MainWindowTitle.Length <> 0 Then
                ' Console.WriteLine("プロセス名:" & p.ProcessName)
                'Console.WriteLine("タイトル名:" & p.MainWindowTitle)

                Dim results As String = p.MainWindowTitle
                list2_alltitle.Items.Add(results)
            End If
        Next

    End Sub

    Private Sub list2_alltitle_SelectedIndexChanged(sender As Object, e As EventArgs) Handles list2_alltitle.SelectedIndexChanged
        txt2_Selectedwindowtitle.Text = list2_alltitle.SelectedItem

        Dim hwndfind As Integer = FindWindow(vbNullString, list2_alltitle.SelectedItem)
        list2_hwnd.Items.Add(hwndfind)
        txt2_selectedhwnd.Text = hwndfind

        'Me.rich2_hwnddetail.Clear()
        'Me.list2_hwnd.Items.Clear()
        'Me.lbl2_parent_kid.Text = "-(親ハンドル)-"

        'EnumWindows(AddressOf MakeList1, 0)

        'ハンドルの1番目を選択。################################################################################################
        list2_hwnd.SelectedIndex = 0


        '指定したウィンドウの座標を取得。#######################################################################################
        Dim hwnd As Integer = list2_hwnd.SelectedItem

        Dim lpRect As RECT
        '取得
        GetWindowRect(hwnd, lpRect)

        txt2_ltx.Text = CInt(lpRect.Left.ToString())
        txt2_lty.Text = CInt(lpRect.Top.ToString())
        txt2_rbx.Text = CInt(lpRect.Right.ToString()) - CInt(lpRect.Left.ToString())
        txt2_rby.Text = CInt(lpRect.Bottom.ToString()) - CInt(lpRect.Top.ToString())

        If hwnd <> IntPtr.Zero Then
            'ウィンドウを作成したプロセスのIDを取得する
            Dim processId As Integer
            GetWindowThreadProcessId(hwnd, processId)
            'Processオブジェクトを作成する
            Dim p As Process = Process.GetProcessById(processId)

            Console.WriteLine("プロセス名:" & p.ProcessName)
            txtprocess.Text = p.ProcessName
        Else
            Console.WriteLine("見つかりませんでした。")
        End If






    End Sub

    'CellContentClickイベントハンドラ
    Private Sub dgv2_template_CellContentClick(ByVal sender As Object,
        ByVal e As DataGridViewCellEventArgs) Handles dgv2_template.CellContentClick

        Dim dgv As DataGridView = CType(sender, DataGridView)

        '"Button"列ならば、ボタンがクリックされた
        If dgv.Columns(e.ColumnIndex).Name = "applysize" Then

            If list2_alltitle.SelectedItems.Count <= 0 Then
                MessageBox.Show(My.Resources.Message.msg48, messagebox_name) 'リストからウィンドウタイトルを1つ選択してください。
            Else

                Dim count As Integer = 0
                Dim k As Integer
                For k = 2 To 5

                    If dgv2_template(k, e.RowIndex).Value Is Nothing Then
                        count += 1
                        MessageBox.Show(My.Resources.Message.msg28, messagebox_name) '"空欄が有ります。"
                        Exit For

                    ElseIf System.Text.RegularExpressions.Regex.IsMatch(dgv2_template(k, e.RowIndex).Value, "[^-?\d]+") Then
                        count += 1
                        MessageBox.Show(My.Resources.Message.msg29, messagebox_name) '"数字以外の文字は入力できません。"
                        Exit For

                    End If

                Next

                If count = 0 Then

                    num2_ltx.Value = dgv2_template(2, e.RowIndex).Value
                    num2_lty.Value = dgv2_template(3, e.RowIndex).Value
                    num2_rbx.Value = dgv2_template(4, e.RowIndex).Value
                    num2_rby.Value = dgv2_template(5, e.RowIndex).Value
                    'MessageBox.Show((e.RowIndex.ToString() + "行のボタンがクリックされました。"))
                    Applyxy()
                End If
            End If



        End If
    End Sub

    Sub Applyxy()


        Dim ltx As Integer = num2_ltx.Value
        Dim lty As Integer = num2_lty.Value
        Dim rbx As Integer = num2_rbx.Value
        Dim rby As Integer = num2_rby.Value

        Dim hwnd As Integer = CInt(txt2_selectedhwnd.Text)

        MoveWindow(hwnd, ltx, lty, rbx, rby, 1)

    End Sub

    '「ウィンドウ設定タブ」表に適用のボタンの設定■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub btninsertzahyou_Click_1(sender As Object, e As EventArgs) Handles btninsertzahyou.Click
        Dim selectedRowCount As Integer =
      dgv2_template.Rows.GetRowCount(DataGridViewElementStates.Selected)

        If selectedRowCount > 0 Then

            Dim sb As New System.Text.StringBuilder()


            sb.Append("Row: ")
            sb.Append(dgv2_template.SelectedRows(0).Index.ToString())
            sb.Append(Environment.NewLine)

            Dim aaa As Integer = dgv2_template.SelectedRows(0).Index.ToString()
            Label5.Text = aaa

            '   dgv2_template(0, aaa).Value = ""
            dgv2_template(1, aaa).Value = list2_alltitle.SelectedItem
            dgv2_template(2, aaa).Value = txt2_ltx.Text
            dgv2_template(3, aaa).Value = txt2_lty.Text
            dgv2_template(4, aaa).Value = txt2_rbx.Text
            dgv2_template(5, aaa).Value = txt2_rby.Text

        End If

        num2_ltx.Value = txt2_ltx.Text
        num2_lty.Value = txt2_lty.Text
        num2_rbx.Value = txt2_rbx.Text
        num2_rby.Value = txt2_rby.Text



    End Sub

    'ウィンドウを固定する■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private Sub chklockwindow_CheckedChanged(sender As Object, e As EventArgs) Handles chklockwindow.CheckedChanged
        If chklockwindow.Checked = True Then
            timlockwindow.Enabled = True

        ElseIf chklockwindow.Checked = False Then
            timlockwindow.Enabled = False
        End If
    End Sub

    Private Sub timlockwindow_Tick(sender As Object, e As EventArgs) Handles timlockwindow.Tick
        Dim ltx As Integer = num2_ltx.Value
        Dim lty As Integer = num2_lty.Value
        Dim rbx As Integer = num2_rbx.Value
        Dim rby As Integer = num2_rby.Value

        Try
            Dim hwnd As Integer = CInt(txt2_selectedhwnd.Text)
            MoveWindow(hwnd, ltx, lty, rbx, rby, 1)
        Catch ex As Exception
            timlockwindow.Enabled = False
            chklockwindow.Checked = False
            MessageBox.Show(My.Resources.Message.msg53, messagebox_name) 'ハンドルの取得がされていません
            rtxtlog.AppendText(Now & " " & My.Resources.Message.msg53 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try

    End Sub

    '======================================================================================================================

    '■ハイパーリンク。
    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        'リンク先に移動したことにする
        LinkLabel2.LinkVisited = True
        'ブラウザで開く
        System.Diagnostics.Process.Start("https://twitter.com/Iemonglass")

    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        'リンク先に移動したことにする
        LinkLabel3.LinkVisited = True
        'ブラウザで開く
        System.Diagnostics.Process.Start("https://frailleaves.com/myownsoftware/autosplit-helper/")

    End Sub













    Private Sub btnconnect_camera_Click(sender As Object, e As EventArgs) Handles btnconnect_camera.Click

        Connect_camera_main()

    End Sub

    Private Sub Connect_camera_cur()
        btncur_webcamera.Enabled = False
        btnconnect_camera.Enabled = False
        btnresetup.Enabled = False

        If btncur_webcamera.Text = My.Resources.Message.msgc01 Then

            btnconnect_camera.Text = My.Resources.Message.msgc02
            btncur_webcamera.Text = My.Resources.Message.msgc02

            capture_setup()

            btnstartopencv.Enabled = True

            btnconnect_camera.BackColor = Color.DarkRed
            btncur_webcamera.BackColor = Color.DarkRed


            webcam_sleep.Start()


        ElseIf btncur_webcamera.Text = My.Resources.Message.msgc02 Then

            btnconnect_camera.Text = My.Resources.Message.msgc01
            btncur_webcamera.Text = My.Resources.Message.msgc01

            capturecv.Release()

            btnstartopencv.Enabled = False

            btnconnect_camera.BackColor = Color.FromArgb(50, 52, 54)
            btncur_webcamera.BackColor = Color.FromArgb(50, 52, 54)

            webcam_sleep.Start()


        End If

    End Sub

    Private Sub Connect_camera_main()

        btncur_webcamera.Enabled = False
        btnconnect_camera.Enabled = False
        btnresetup.Enabled = False

        If btnconnect_camera.Text = My.Resources.Message.msgc01 Then

            btnconnect_camera.Text = My.Resources.Message.msgc02
            btncur_webcamera.Text = My.Resources.Message.msgc02

            capture_setup()

            btnstartopencv.Enabled = True

            btnconnect_camera.BackColor = Color.DarkRed
            btncur_webcamera.BackColor = Color.DarkRed


            webcam_sleep.Start()



        ElseIf btnconnect_camera.Text = My.Resources.Message.msgc02 Then

            btnconnect_camera.Text = My.Resources.Message.msgc01
            btncur_webcamera.Text = My.Resources.Message.msgc01

            capturecv.Release()

            btnstartopencv.Enabled = False

            btnconnect_camera.BackColor = Color.FromArgb(50, 52, 54)
            btncur_webcamera.BackColor = Color.FromArgb(50, 52, 54)

            webcam_sleep.Start()

        End If

    End Sub




    Private Sub Graph_setting()
        view_chart.Show()
    End Sub

    Private Sub Reset_count()
        lblattemptcount.Text = 0
        lblresetcount.Text = 0
        lbllapcount.Text = 0
    End Sub

    Private Sub Reset_table()

        Dim rowcount As Integer = DGtable.Rows.Count

        For aa = 1 To rowcount - 2
            DGtable(graph_count.Index, aa).Value = 0
            DGtable(graph_rate.Index, aa).Value = 0

        Next

        If view_chart.Visible = True Then

            view_chart.btnresponse.PerformClick()

        End If


    End Sub

    Private Sub Reset_livesplit()

        Dim rowcount As Integer = DGtable.Rows.Count
        'タイマーのプロセスを探す
        Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

        If 0 < ps_timer1.Length Then


            For aa = 1 To rowcount - 2

                Try
                    Dim sw As System.IO.StreamWriter = New System.IO.StreamWriter(pipeServer)
                    Dim sr As New IO.StreamReader(pipeServer)

                    sw.AutoFlush = True
                    sw.WriteLine("setsplitname " & aa - 1 & " " & DGtable(no.Index, aa + CInt(numgraph_first.Value) - 1).Value & vbCrLf)

                Catch ex As Exception

                    MessageBox.Show(My.Resources.Message.msg51, messagebox_name)
                    rtxtlog.AppendText(Now & " " & My.Resources.Message.msg51 & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

                End Try

            Next


        End If


    End Sub

    Private Sub btnreset_count_Click(sender As Object, e As EventArgs) Handles btnreset_count.Click

        Reset_count()

    End Sub

    Private Sub btnreset_table_Click(sender As Object, e As EventArgs) Handles btnreset_table.Click

        Reset_table()

    End Sub

    Private Sub btnreset_livesplit_Click(sender As Object, e As EventArgs) Handles btnreset_livesplit.Click

        Reset_livesplit()

    End Sub

    Private Sub btnrenameapp_Click(sender As Object, e As EventArgs) Handles btnrenameapp.Click
        Dim hWnd As IntPtr = FindWindow(Nothing, list2_alltitle.SelectedItem)

        If hWnd <> IntPtr.Zero Then

            SetWindowText(hWnd, txtrenameapp.Text)
        Else
            MessageBox.Show(My.Resources.Message.msg49, messagebox_name) '見つかりませんでした。

        End If

        'タイトルがrenameのウィンドウを探す
        Dim hWnd_multi As IntPtr = FindWindow(Nothing, txtrenameapp.Text)
        If hWnd_multi <> IntPtr.Zero Then
            'ウィンドウを作成したプロセスのIDを取得する
            Dim processId As Integer
            GetWindowThreadProcessId(hWnd_multi, processId)
            'Processオブジェクトを作成する
            Dim p As Process = Process.GetProcessById(processId)

            Console.WriteLine("nm:" & processId)
            txtpid_2nd.Text = processId
        Else
            Console.WriteLine("見つかりませんでした。")
        End If


        btn2_getwindowtitle.PerformClick()
    End Sub





    Private Sub cmbtimer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbtimer.SelectedIndexChanged
        'タイトルがrenameのウィンドウを探す
        Dim hWnd_multi As IntPtr = FindWindow(Nothing, cmbtimer.Text)
        If hWnd_multi <> IntPtr.Zero Then
            'ウィンドウを作成したプロセスのIDを取得する
            Dim processId As Integer
            GetWindowThreadProcessId(hWnd_multi, processId)
            'Processオブジェクトを作成する
            Dim p As Process = Process.GetProcessById(processId)

            Console.WriteLine("nm:" & processId)
            lblpid_1st.Text = processId

        Else

            Console.WriteLine("見つかりませんでした。")

        End If

        '■Current Settingへの反映
        lblcur_focus_before.Text = cmbtimer.SelectedItem


    End Sub

    Private Sub chknamedpipe_CheckedChanged(sender As Object, e As EventArgs) Handles chknamedpipe.CheckedChanged

        If chknamedpipe.Checked = True Then
            '■Livesplitの名前付きパイプの接続状況表示。

            If pipeServer.IsConnected = False Then

                'タイマーのプロセスを探す
                Dim ps_timer1 As Process() = Process.GetProcessesByName("LiveSplit")

                If 0 < ps_timer1.Length Then

                    pipeServer.Connect()
                    livesplit_state = "[LiveSplit NamedPipe ON]"

                Else

                    livesplit_state = "LiveSplit NamedPipe OFF]"


                End If

            End If

            '■Current Settingへの反映
            lblcur_namedpipe.Text = "YES"


        ElseIf chknamedpipe.Checked = False Then

            If pipeServer.IsConnected = True Then

                livesplit_state = "[LiveSplit NamedPipe ON]"

            ElseIf pipeServer.IsConnected = False Then

                livesplit_state = "[LiveSplit NamedPipe OFF]"


            End If

            '■Current Settingへの反映
            lblcur_namedpipe.Text = "NO"




        End If


        lbllivesplit_state.Text = livesplit_state
        lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " AutoSplit Helper by Image " & lblversion.Text

    End Sub

    Private Sub Mainwindow_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        pipeServer.Dispose()

    End Sub




    '■ToolStripMenu
    Private Sub NewProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewProfileToolStripMenuItem.Click
        Newcsv()

    End Sub

    Private Sub ImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem.Click
        profile_import()
    End Sub

    Private Sub PreviewGetTemplatePictureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewGetTemplatePictureToolStripMenuItem.Click
        If btncur_webcamera.BackColor = Color.DarkRed Then
            btndescription_table.Visible = False
            cv_prepare()

        Else
            MessageBox.Show(My.Resources.Message.msg50, messagebox_name) '仮想カメラとの接続を行って下さい。


        End If

    End Sub

    Private Sub CalibrationToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CalibrationToolStripMenuItem1.Click
        If btnconnect_camera.BackColor = Color.DarkRed Then
            ShowCalibration()

        Else
            MessageBox.Show(My.Resources.Message.msg50, messagebox_name) '仮想カメラとの接続を行って下さい。

        End If


    End Sub

    Private Sub PositionSettingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PositionSettingToolStripMenuItem.Click
        TabControl1.SelectedIndex = 2

    End Sub

    Private Sub InformationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InformationToolStripMenuItem.Click
        TabControl1.SelectedIndex = 5

    End Sub

    Private Sub ExpandTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpandTableToolStripMenuItem.Click
        Tableview_()

    End Sub

    Private Sub ViewTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewTableToolStripMenuItem.Click
        Graph_setting()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        btnclosewindow.PerformClick()

    End Sub

    Private Sub SaveProfileSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveProfileSToolStripMenuItem.Click
        btnaddprofile.PerformClick()
    End Sub

    Private Sub DeleteSelectedProfileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteSelectedProfileToolStripMenuItem.Click
        btndeleteprofile.PerformClick()
    End Sub


    Private Sub StartMonitoringMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StartMonitoringMToolStripMenuItem.Click
        btnstartopencv.PerformClick()
    End Sub







    Private Sub link_opencvsharp_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_opencvsharp.LinkClicked
        rtxtlicense.Clear()
        '現在のコードを実行しているAssemblyを取得
        Dim myAssembly As System.Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        '指定されたマニフェストリソースを読み込む
        Dim sr As New System.IO.StreamReader(
            myAssembly.GetManifestResourceStream("AutoSplitHelper_OpenCV.License[OpenCVsharp].txt"),
                System.Text.Encoding.UTF8)
        '内容を読み込む
        Dim s As String = sr.ReadToEnd()
        '後始末
        sr.Close()
        sr.Dispose()
        rtxtlicense.Text = s




    End Sub


    Private Sub link_directshowlib_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_directshowlib.LinkClicked
        rtxtlicense.Clear()
        '現在のコードを実行しているAssemblyを取得
        Dim myAssembly As System.Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        '指定されたマニフェストリソースを読み込む
        Dim sr As New System.IO.StreamReader(
            myAssembly.GetManifestResourceStream("AutoSplitHelper_OpenCV.License[Directshowlib-2005].txt"),
                System.Text.Encoding.UTF8)
        '内容を読み込む
        Dim s As String = sr.ReadToEnd()
        '後始末
        sr.Close()
        sr.Dispose()
        rtxtlicense.Text = s

    End Sub

    Private Sub link_dobon_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_dobon.LinkClicked
        rtxtlicense.Clear()
        '現在のコードを実行しているAssemblyを取得
        Dim myAssembly As System.Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        '指定されたマニフェストリソースを読み込む
        Dim sr As New System.IO.StreamReader(
            myAssembly.GetManifestResourceStream("AutoSplitHelper_OpenCV.License[DOBONNET].txt"),
                System.Text.Encoding.UTF8)
        '内容を読み込む
        Dim s As String = sr.ReadToEnd()
        '後始末
        sr.Close()
        sr.Dispose()
        rtxtlicense.Text = s

    End Sub


    Private Sub LicenseLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicenseLToolStripMenuItem.Click
        TabControl1.SelectedIndex = 6
    End Sub

    Private Sub UploadTheCurrentProfileUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadTheCurrentProfileUToolStripMenuItem.Click
        dialog_sharetemplate.Show()

    End Sub

    Private Sub chkshow_text_CheckedChanged(sender As Object, e As EventArgs) Handles chkshow_text.CheckedChanged

        If chkshow_text.Checked = True Then
            lblcur_showtextwindow.BackColor = Color.Maroon
            lblcur_showtextwindow.Text = "Y"
        Else
            lblcur_showtextwindow.BackColor = Color.FromArgb(80, 90, 95)
            lblcur_showtextwindow.Text = "N"
        End If

    End Sub

    Private Sub txtresume_key_MouseDown(sender As Object, e As MouseEventArgs) Handles txtresume_key.MouseDown

    End Sub

    Private Sub txtpause_key_MouseDown(sender As Object, e As MouseEventArgs) Handles txtpause_key.MouseDown

    End Sub

    Private Sub txtskip_key_MouseDown(sender As Object, e As MouseEventArgs) Handles txtskip_key.MouseDown

    End Sub

    Private Sub txtreset_key_MouseDown(sender As Object, e As MouseEventArgs) Handles txtreset_key.MouseDown

    End Sub

    Private Sub txtundo_key_MouseDown(sender As Object, e As MouseEventArgs) Handles txtundo_key.MouseDown

    End Sub

    Private Sub btncur_showtext_Click(sender As Object, e As EventArgs) Handles btncur_showtext.Click

        Textwindow.Show()


    End Sub

    '♥
    '常時作成にしたほうが良いかも知れない。
    Private Sub btntext_createtext_Click(sender As Object, e As EventArgs) Handles btntext_createtext.Click

        Dim rowcount As Integer = DGtable.Rows.Count
        Try

            For aa = 1 To rowcount - 2

                If Not System.IO.File.Exists(txtpass_rtf.Text & "/" & aa & ".rtf") Then

                    My.Computer.FileSystem.CopyFile("./savedata/blank.rtf", txtpass_rtf.Text & "/" & aa & ".rtf", False)


                End If


            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, messagebox_name)
            rtxtlog.AppendText(Now & " " & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

        End Try


    End Sub

    Private Sub btntext_openfolder_Click(sender As Object, e As EventArgs) Handles btntext_openfolder.Click

        '■相対パスから絶対パスを取得する
        Dim stFilePath As String = System.IO.Path.GetFullPath(txtpass_rtf.Text)

        'フォルダ"./profile/[profilename]/text"を開く
        System.Diagnostics.Process.Start(stFilePath)
    End Sub

    Private Sub OpenTextWindowWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTextWindowWToolStripMenuItem.Click
        Textwindow.Show()
    End Sub


    Private Sub OpenTextFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenTextFolderToolStripMenuItem.Click
        btntext_openfolder.PerformClick()
    End Sub

    Private Sub btnshow_chart_Click(sender As Object, e As EventArgs) Handles btnshow_chart.Click
        Textwindow.Show()
    End Sub







    'Arrayprofileの作成はここ
    Private arrayprofile_save(128) As String
    Private arrayprofile_before(128) As String



    Private Sub Createarrayprofile()

        arrayprofile_save = New String() {
"##########Path##########",
txtpass_csv.Text,
txtpass_picturefolder.Text,
txtpass_rtf.Text,
"-",
"##########Location##########",
numsavex.Value,
numsavey.Value,
"-",
"##########Monitoring##########",
CInt(chkcv_monitor.Checked),
CInt(chkcv_loop.Checked),
CInt(chkcv_resetonoff.Checked),
CInt(chkcv_loadremover.Checked),
numpercent.Value,
numstop.Value,
numanten.Value,
numcv_interval.Value,
"-",
"##########OpenCV Parameter##########",
cmbcv_device.SelectedIndex,
cmbcv_resolution_input.SelectedIndex,
cmbcv_resolution_view.SelectedIndex,
numcv_framerate.Value,
CInt(chkcv_crop.Checked),
txtcv_crop_posx.Text,
txtcv_crop_posy.Text,
txtcv_crop_sizex.Text,
txtcv_crop_sizey.Text,
CInt(chkcv_grayscale.Checked),
"-",
"##########Focus##########",
CInt(chkactiveapp.Checked),
cmbtimer.SelectedItem,
CInt(chkactivesomeapp.Checked),
cmbsomeapp.SelectedItem,
numsendsleep.Value,
"-",
"##########Hotkey##########",
CInt(chkshift.Checked),
CInt(chkctrl.Checked),
CInt(chkalt.Checked),
txtsplit_key.Text,
lblkeysforsend.Text,
CInt(chkshift_reset.Checked),
CInt(chkctrl_reset.Checked),
CInt(chkalt_reset.Checked),
txtreset_key.Text,
lblkeysforsend_reset.Text,
CInt(chkshift_undo.Checked),
CInt(chkctrl_undo.Checked),
CInt(chkalt_undo.Checked),
txtundo_key.Text,
lblkeysforundo.Text,
CInt(chkshift_skip.Checked),
CInt(chkctrl_skip.Checked),
CInt(chkalt_skip.Checked),
txtskip_key.Text,
lblkeysforskip.Text,
CInt(chkshift_pause.Checked),
CInt(chkctrl_pause.Checked),
CInt(chkalt_pause.Checked),
txtpause_key.Text,
lblkeysforpause.Text,
CInt(chkshift_resume.Checked),
CInt(chkctrl_resume.Checked),
CInt(chkalt_resume.Checked),
txtresume_key.Text,
lblkeysforresume.Text,
txtreset_ash_key.Text,
numreset_ash.Value,
txtundo_ash_key.Text,
numundo_ash.Value,
txtskip_ash_key.Text,
numskip_ash.Value,
CInt(chkundoskip.Checked),
CInt(chknamedpipe.Checked),
numpresstime.Value,
"-",
"##########Load remover##########",
CInt(chkload1.Checked),
CInt(chkload2.Checked),
CInt(chkload3.Checked),
CInt(chkload4.Checked),
CInt(chkload5.Checked),
CInt(chkload6.Checked),
CInt(chkload7.Checked),
CInt(chkload8.Checked),
CInt(chkload9.Checked),
CInt(chkload10.Checked),
numload_rate1.Value,
numload_rate2.Value,
numload_rate3.Value,
numload_rate4.Value,
numload_rate5.Value,
numload_rate6.Value,
numload_rate7.Value,
numload_rate8.Value,
numload_rate9.Value,
numload_rate10.Value,
numload_delay1.Value,
numload_delay2.Value,
numload_delay3.Value,
numload_delay4.Value,
numload_delay5.Value,
numload_delay6.Value,
numload_delay7.Value,
numload_delay8.Value,
numload_delay9.Value,
numload_delay10.Value,
"-",
"##########Graph##########",
numgraph_first.Value,
CInt(chkrename_livesplit.Checked),
numloopcount.Value,
"-",
"##########Video##########",
CInt(chkshowvideo.Checked),
CInt(chkvideo_autoseek.Checked),
CInt(chkvideo_manualstart.Checked),
txtvideo_pass.Text,
txtvideo_startat.Text,
numvideo_sizex.Value,
numvideo_sizey.Value,
CInt(chkvideo_showwinvideo.Checked),
numwin_locx.Value,
numwin_locy.Value,
numwin_interval.Value,
"-",
"##########Textwindow##########",
CInt(chkshow_text.Checked),
numtextwindow_sizex.Value,
numtextwindow_sizey.Value,
"-",
"##########Other##########",
CInt(chkmonitor_sizestate.Checked)
}

    End Sub




    '■Numericを全選択状態にする
    Private Sub numloopcount_Enter(sender As Object, e As EventArgs) Handles numloopcount.Enter
        numloopcount.Select(0, numloopcount.Text.Length)

    End Sub



    Private Sub numpercent_Enter(sender As Object, e As EventArgs) Handles numpercent.Enter
        numpercent.Select(0, numpercent.Text.Length)

    End Sub



    Private Sub numstop_Enter(sender As Object, e As EventArgs) Handles numstop.Enter
        numstop.Select(0, numstop.Text.Length)

    End Sub



    Private Sub numanten_Enter(sender As Object, e As EventArgs) Handles numanten.Enter
        numanten.Select(0, numanten.Text.Length)

    End Sub



    Private Sub numcv_interval_Enter(sender As Object, e As EventArgs) Handles numcv_interval.Enter
        numcv_interval.Select(0, numcv_interval.Text.Length)

    End Sub



    Private Sub numcv_framerate_Enter(sender As Object, e As EventArgs) Handles numcv_framerate.Enter
        numcv_framerate.Select(0, numcv_framerate.Text.Length)

    End Sub


    Private Sub numsendsleep_Enter(sender As Object, e As EventArgs) Handles numsendsleep.Enter
        numsendsleep.Select(0, numsendsleep.Text.Length)

    End Sub

    Private Sub numpresstime_Enter(sender As Object, e As EventArgs) Handles numpresstime.Enter
        numpresstime.Select(0, numpresstime.Text.Length)

    End Sub

    Private Sub numgraph_first_Enter(sender As Object, e As EventArgs) Handles numgraph_first.Enter
        numgraph_first.Select(0, numgraph_first.Text.Length)

    End Sub

    Private Sub numvideo_sizex_Enter(sender As Object, e As EventArgs) Handles numvideo_sizex.Enter
        numvideo_sizex.Select(0, numvideo_sizex.Text.Length)

    End Sub

    Private Sub numvideo_sizey_Enter(sender As Object, e As EventArgs) Handles numvideo_sizey.Enter
        numvideo_sizey.Select(0, numvideo_sizey.Text.Length)

    End Sub

    Private Sub numwin_locx_Enter(sender As Object, e As EventArgs) Handles numwin_locx.Enter
        numloopcount.Select(0, numloopcount.Text.Length)

    End Sub

    Private Sub numwin_locy_Enter(sender As Object, e As EventArgs) Handles numwin_locy.Enter
        numloopcount.Select(0, numloopcount.Text.Length)

    End Sub

    Private Sub numwin_interval_Enter(sender As Object, e As EventArgs) Handles numwin_interval.Enter
        numloopcount.Select(0, numloopcount.Text.Length)

    End Sub

    Private Sub btntosetting03_Click(sender As Object, e As EventArgs) Handles btntosetting03.Click

        '自分のディレクトリ内の「tempfiles」フォルダ以下にあるファイルをすべて削除。
        For Each tempFile As String In
      System.IO.Directory.GetFiles("./temp/temp1")
            System.IO.File.Delete(tempFile)
        Next

        timcamera.Enabled = False
        timcalib.Enabled = False

        TabControl1.SelectedIndex = 0

        lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & " AutoSplit Helper by Image " & lblversion.Text


    End Sub



    Private Sub DeleteAddTemplateImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteAddTemplateImageToolStripMenuItem.Click

        '■プロファイルのバックアップを作成
        '■ASH_stateを0にして上書き確認を消す
        ASH_state = 0

        Dim temp_profilename As String = cmbprofile.Text

        If Not cmbprofile.FindStringExact(cmbprofile.SelectedItem & "_backup") = -1 Then
            ' 存在します。
            cmbprofile.SelectedItem = cmbprofile.SelectedItem & "_backup"

            'プロファイルを削除
            btndeleteprofile.PerformClick()

        End If


        cmbprofile.Text = cmbprofile.SelectedItem & "_backup"
        saveprofile_nomessage() '複製

        MessageBox.Show(My.Resources.Message.msgd02 & "(" & temp_profilename & "_backup)", messagebox_name) '"プロファイルのバックアップを作成しました。"

        cmbprofile.SelectedItem = temp_profilename

        Del_Addimagewindow.Show()

        ASH_state = 1


    End Sub

    Private Sub SortTemplateImageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SortTemplateImageToolStripMenuItem.Click

        '■プロファイルのバックアップを作成
        'ASH_Stateを0にして上書きチェック回避
        ASH_state = 0

        Dim temp_profilename As String = cmbprofile.Text

        If Not cmbprofile.FindStringExact(cmbprofile.SelectedItem & "_backup") = -1 Then
            ' 存在します。
            cmbprofile.SelectedItem = cmbprofile.SelectedItem & "_backup"

            'プロファイルを削除
            btndeleteprofile.PerformClick()

        End If


        cmbprofile.Text = cmbprofile.SelectedItem & "_backup"
        saveprofile_nomessage() '複製

        MessageBox.Show(My.Resources.Message.msge03 & "(" & temp_profilename & "_backup)", messagebox_name)
        'プロファイルのバックアップを作成しました。
        cmbprofile.SelectedItem = temp_profilename

        Sortimagewindow.Show()

        ASH_state = 1


    End Sub


    Private Sub checkupdate()

        'ネットワークに接続されているか調べる★
        If System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable() Then
            Console.WriteLine("ネットワークに接続されています。")

            Try
                '■最新情報を受け取る
                Dim wc1 As WebClient = New WebClient()
                Dim st1 As Stream = wc1.OpenRead("https://mus.frailleaves.com/ash_update.html")

                Dim enc1 As Encoding = Encoding.UTF8
                Dim sr1 As StreamReader = New StreamReader(st1, enc1)
                Dim html As String = sr1.ReadToEnd()
                sr1.Close()
                st1.Close()


                '■ページの内容を取得♥
                Dim s1 As String = html
                Dim lefturl As String, righturl As String
                Dim filename As String

                filename = html
                lefturl = InStr(filename, "AutosplitterUpdatestart<br>") + 22  'Mid(filename, InStr(filename, "<url>") + 5)  '拡張子を返します

                Dim s2 As String = "" & filename.Substring(lefturl) ', righturl - lefturl - 1) & ""  '4文字目から3文字を取得する

                righturl = InStr(filename, "AutosplitterUpdateend")
                s2 = filename.Substring(lefturl, righturl - lefturl - 1) & ""  '4文字目から3文字を取得する

                Dim s3 As String = s2.Replace("<br>", "")
                Console.WriteLine("Now: " & lblversion.Text & ", New: " & s3)
                lblnewestver.Text = "Newest: " & s3


                '■バージョンが更新されていたら通知する。★♥
                If Not lblversion.Text = s3 Then
                    Dim leftcontent As String, rightcontent As String

                    leftcontent = InStr(filename, "Autosplittercontentstart") + 23  'Mid(filename, InStr(filename, "<url>") + 5)  '拡張子を返します
                    Dim s4 As String = "" & filename.Substring(leftcontent)
                    rightcontent = InStr(filename, "Autosplittercontentend")
                    s4 = filename.Substring(leftcontent, rightcontent - leftcontent - 1) & ""  '4文字目から3文字を取得する

                    lbltitlebar.Text = "[" & cmbprofile.SelectedItem & "]" & s3 & " is available! Details: Help -> Information."
                    rtxtlog.AppendText(s4 & vbCrLf)


                End If

            Catch ex As Exception

                Console.WriteLine("インターネットに接続されていないようです。")
            rtxtlog.AppendText(Now & " " & "インターネットに接続されていないようです。" & vbCrLf & ex.Message & vbCrLf & ex.StackTrace & vbCrLf)

            End Try

        Else
            Console.WriteLine("ネットワークに接続されていません。")
        End If



    End Sub


    Private DGtable_changeTF = 0

    Private Sub DGtable_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DGtable.CellValueChanged
        'Console.WriteLine("DGTableの内容が変更された。")
        DGtable_changeTF = 1
        'あっどはんどらで切る
    End Sub

    Private Sub btndescription_table_Click(sender As Object, e As EventArgs) Handles btndescription_table.Click
        Table_description.Show()
    End Sub


    Private Sub rdocapture_opencv_CheckedChanged(sender As Object, e As EventArgs) Handles rdocapture_opencv.CheckedChanged
        If rdocapture_opencv.Checked = True Then
            chklimit.Enabled = True
            chkloading.Enabled = True




        End If


    End Sub


    Private Sub rdocapture_rgb_CheckedChanged(sender As Object, e As EventArgs) Handles rdocapture_rgb.CheckedChanged
        If rdocapture_rgb.Checked = True Then
            chklimit.Checked = False
            chkloading.Checked = False

            chklimit.Enabled = False
            chkloading.Enabled = False
        Else



        End If
    End Sub

    Private Sub rdocapture_rgbfull_CheckedChanged(sender As Object, e As EventArgs) Handles rdocapture_rgbfull.CheckedChanged

        If rdocapture_rgbfull.Checked = True Then
            chklimit.Checked = False
            chkloading.Checked = False

            chklimit.Enabled = False
            chkloading.Enabled = False
        End If


    End Sub

    Private Sub btncv_crop_setting_Click(sender As Object, e As EventArgs) Handles btncv_crop_setting.Click
        If btncur_webcamera.BackColor = Color.DarkRed Then

            btndescription_table.Visible = False

            TabControl1.SelectedIndex = 4
            Crop_setup()

        Else
            MessageBox.Show(My.Resources.Message.msg50, messagebox_name) '仮想カメラとの接続を行って下さい。


        End If

    End Sub


    Private Sub cmbcv_resolution_input_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcv_resolution_input.SelectedIndexChanged
        '■コンボボックスの値を下に代入■■■■■■
        ' 必要な変数を宣言する
        Dim stCsvData As String = cmbcv_resolution_input.SelectedItem

        ' カンマ区切りで分割して配列に格納する
        Dim stArrayData As String() = stCsvData.Split("x"c)

        numcrop_resolution_x.Value = CInt(stArrayData(0))
        numcrop_resolution_y.Value = CInt(stArrayData(1))

        btnstartopencv.Enabled = False

        '■Current Settingへの反映
        lblcur_device_res_fps.Text = cmbcv_resolution_view.SelectedItem & " - " & numcv_framerate.Value & "fps"

    End Sub

End Class