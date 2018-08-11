Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO

'バックアップ用のプロファイルが作られている（「プロファイル名_backup」）。
'複製前のプロファイルのcsvファイルを読み込む。

'temp/temp_deladd以下に2つのフォルダ（copy、nbmp）がある。
'起動時に内容全削除、copyにpictureフォルダ内の画像を全コピー
'copyフォルダ内のreset/loadingを除いたファイル数をカウントし、list_numberに反映。
'copyフォルダから、n.bmpをnbmpフォルダに移動、copyフォルダに残ったものがreset+loadingになる。

'テキストファイルのコピー（n.bmp分のみ存在）

'Insert、Deleteを1回するたびに表に反映、bmpファイルのリネーム、list_numberへ反映する。
'表について、Insert時は指定された行に1行追加して、上の値をコピーする。コメントは
'del_addの確定時、
'キャンセル時、複製したプロファイルを削除し、元々選択していたプロファイル名にする。
Public Class Del_Addimagewindow

    Function DeleteFolder(ByVal astrDesFolderName As String) As Boolean
        '戻り値初期化
        DeleteFolder = False
        Try
            '指定フォルダ内の全ファイルを取得
            Dim arrFiles() As String = System.IO.Directory.GetFiles(astrDesFolderName)

            '全ファイル削除
            For Each strFile As String In arrFiles
                System.IO.File.Delete(strFile)
            Next

            '正常終了
            Return True

        Catch ex As Exception
            'エラー処理が必要な場合は、ここに記述する
        End Try
    End Function


    Private Sub Del_Addimagewindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '■ウィンドウ位置調整
        Me.Location = New Drawing.Point(Mainwindow.Location.X + 20, Mainwindow.Location.Y + 20)


        '■フォルダ内ファイル削除
        DeleteFolder("./temp/temp_deladd/copy")
        DeleteFolder("./temp/temp_deladd/nbmp")
        DeleteFolder("./temp/temp_deladd/text")

        Console.WriteLine("temp/temp_deladd/以下のファイルを削除")

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

        Console.WriteLine("画像ファイル数（reset、loading除く）：" & FileCount_bmponly)


        '→FileCount_bmponlyは、全てのbmpファイルからreset/loadingxx.bmpを取り除いた数になる。
        '■n.bmpのファイル数だけlistnumberに連番追加。
        For i = 0 To FileCount_bmponly - 1
            listnumber.Items.Add(i + 1)
            listcomment.Items.Add(Mainwindow.DGtable(0, i + 1).Value)
        Next


        '■画像フォルダのコピー
        My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, "./temp/temp_deladd/copy",
            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        'n.bmpをnフォルダにコピー
        For i = 0 To FileCount_bmponly - 1

            System.IO.File.Move("./temp/temp_deladd/copy/" & i + 1 & ".bmp", "./temp/temp_deladd/nbmp/" & i + 1 & ".bmp")


        Next

        '■テキストファイルのコピー
        My.Computer.FileSystem.CopyDirectory(txtpass_rtf.Text, "./temp/temp_deladd/text",
    FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)



        '■表の読み込み（コピーしたプロファイル/table.csv）
        Dim ii As Integer
        For ii = 0 To 0

            Try

                Dim myfilename_table1 As String = "./profile/" & Mainwindow.cmbprofile.SelectedItem & "/table.csv"

                Dim parser As TextFieldParser = New TextFieldParser(myfilename_table1, Encoding.GetEncoding("Shift_JIS"))
                parser.TextFieldType = FieldType.Delimited
                parser.SetDelimiters(",") ' 区切り文字はコンマ

                ' データをすべてクリア
                Copytable.Rows.Clear()

                While (Not parser.EndOfData)
                    Dim row As String() = parser.ReadFields() ' 1行読み込み
                    ' 読み込んだデータ(1行をDataGridViewに表示する)
                    Copytable.Rows.Add(row)

                End While

                For Each c As DataGridViewColumn In Copytable.Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c

                For Each c As DataGridViewColumn In Copytable.Columns
                    c.SortMode = DataGridViewColumnSortMode.NotSortable
                Next c

                parser.Close()


            Catch
                MessageBox.Show(My.Resources.Message.msg1, "messagebox_name")
                '"表の読み込みに失敗しました。savefileフォルダに[table1.csv(カンマ区切り)]を作成してください。"
            End Try

        Next

        Console.WriteLine("temp_deladdフォルダへのコピー終了/起動終了")




    End Sub


    Private bmpview_onoff As Integer = 1

    Private Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        bmpview_onoff = 0

        If Not listnumber.SelectedItems.Count = 0 Then


            Try

                Dim addpoint As Integer = listnumber.SelectedIndex + 1

                '■表への反映
                Copytable.Rows.Insert(addpoint + 1)

                For j = 0 To 20 - 1 '列数実数指定。どうやればよいのか♥

                    Copytable(j, addpoint + 1).Value = Copytable(j, addpoint).Value

                Next

                Copytable(no.Index, addpoint + 1).Value = Copytable(no.Index, addpoint).Value & "_add"




                '■画像とlistへの反映
                listnumber.Items.Add(listnumber.Items.Count + 1) 'Insert(addpoint, listnumber.SelectedIndex + 1 & "_add")
                listcomment.Items.Insert(addpoint, listcomment.SelectedItem) '(addpoint, listnumber.SelectedIndex + 1 & "_add")

                '画像ファイル複製＋リネーム
                Dim copybmp_pass As String = "./temp/temp_deladd/nbmp/" & addpoint & ".bmp"
                Dim copybmp_pass_add As String = "./temp/temp_deladd/nbmp/" & addpoint & "_add.bmp"

                System.IO.File.Copy(copybmp_pass, copybmp_pass_add)



                'xxx_add以外をリネーム
                For i = listnumber.Items.Count - 1 To addpoint + 1 Step -1
                    System.IO.File.Move("./temp/temp_deladd/nbmp/" & i & ".bmp", "./temp/temp_deladd/nbmp/" & i + 1 & ".bmp")

                Next

                Application.DoEvents()

                'xxx_addをリネーム
                System.IO.File.Move("./temp/temp_deladd/nbmp/" & addpoint & "_add.bmp", "./temp/temp_deladd/nbmp/" & addpoint + 1 & ".bmp")
                Console.WriteLine(addpoint & "_add.bmpリネーム")



                '■テキストファイルへの反映
                'テキストファイル複製＋リネーム
                Dim copytext_pass As String = "./temp/temp_deladd/text/" & addpoint & ".rtf"
                Dim copytext_pass_add As String = "./temp/temp_deladd/text/" & addpoint & "_add.rtf"

                System.IO.File.Copy(copytext_pass, copytext_pass_add)

                'xxx_add以外をリネーム
                For i = listnumber.Items.Count - 1 To addpoint + 1 Step -1
                    System.IO.File.Move("./temp/temp_deladd/text/" & i & ".rtf", "./temp/temp_deladd/text/" & i + 1 & ".rtf")

                Next

                Application.DoEvents()

                'xxx_addをリネーム
                System.IO.File.Move("./temp/temp_deladd/text/" & addpoint & "_add.rtf", "./temp/temp_deladd/text/" & addpoint + 1 & ".rtf")
                Console.WriteLine(addpoint & "_add.rtfリネーム")




            Catch ex As Exception

            End Try

            Console.WriteLine("Insert終了")
            bmpview_onoff = 1
            View_bmp()

        Else
            Console.WriteLine("リストボックス選択されていない")

        End If



    End Sub



    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        bmpview_onoff = 0

        If Not listnumber.SelectedItems.Count = 0 Then


            Try

                Dim deletepoint As Integer = listnumber.SelectedIndex + 1

                '■表への反映
                Copytable.Rows.RemoveAt(deletepoint)

                Console.WriteLine("deletepoint：" & deletepoint)

                '■画像ファイル、リストへの反映
                listnumber.Items.RemoveAt(listnumber.Items.Count - 1)
                listcomment.Items.RemoveAt(deletepoint - 1)


                'ファイルの削除
                File.Delete("./temp/temp_deladd/nbmp/" & deletepoint & ".bmp")

                'リネーム
                For i = deletepoint To listnumber.Items.Count Step 1
                    System.IO.File.Move("./temp/temp_deladd/nbmp/" & i + 1 & ".bmp", "./temp/temp_deladd/nbmp/" & i & ".bmp")

                Next


                '■テキストファイルへの反映
                'ファイルの削除
                File.Delete("./temp/temp_deladd/text/" & deletepoint & ".rtf")

                'リネーム
                For i = deletepoint To listnumber.Items.Count Step 1
                    System.IO.File.Move("./temp/temp_deladd/text/" & i + 1 & ".rtf", "./temp/temp_deladd/text/" & i & ".rtf")

                Next



                Console.WriteLine("Delete終了")
                bmpview_onoff = 1
                View_bmp()

            Catch ex As Exception

            End Try

        Else
            Console.WriteLine("リストボックス選択されていない")



        End If


    End Sub


    '画像ファイルの表示
    Private Sub View_bmp()
        '■画像の読み込み（表示用）※ADD/DELETE時画像の参照先が狂うので一旦無し
        Dim aa As String = "./temp/temp_deladd/nbmp/" & listnumber.SelectedItem & ".bmp"
        Using fs As FileStream = New FileStream(aa, FileMode.Open, FileAccess.Read)
            PictureBox1.Image = Image.FromStream(fs)
        End Using
    End Sub

    Private Sub listnumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listnumber.SelectedIndexChanged

        listcomment.SelectedIndex = listnumber.SelectedIndex
        If bmpview_onoff = 1 Then
            View_bmp()
        End If


    End Sub

    '表のデータを複製前のプロファイルのtable.csvに保存。
    'nbmpフォルダ内の画像をcopyフォルダに移動
    'copuフォルダ内の画像を複製前のプロファイル/pictureフォルダにコピー

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click

        '■csvファイルの保存
        Dim sfd As New SaveFileDialog()
        Dim myfilename = sfd.FileName

        CsvFileSave(myfilename) 'myfilename機能してない。

        '■プロファイルの変更イベントが起こっていないので、強制的に表を書き換える。
        '■表の読み込み（プロファイル/table.csv）
        Try



            Dim myfilename_table1 As String = "./profile/" & Mainwindow.cmbprofile.SelectedItem & "/table.csv"

            Dim parser As TextFieldParser = New TextFieldParser(myfilename_table1, Encoding.GetEncoding("Shift_JIS"))
            parser.TextFieldType = FieldType.Delimited
            parser.SetDelimiters(",") ' 区切り文字はコンマ

            ' データをすべてクリア
            Mainwindow.DGtable.Rows.Clear()

            While (Not parser.EndOfData)
                Dim row As String() = parser.ReadFields() ' 1行読み込み
                ' 読み込んだデータ(1行をDataGridViewに表示する)
                Mainwindow.DGtable.Rows.Add(row)

            End While

            For Each c As DataGridViewColumn In Mainwindow.DGtable.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c

            For Each c As DataGridViewColumn In Mainwindow.DGtable.Columns
                c.SortMode = DataGridViewColumnSortMode.NotSortable
            Next c

            parser.Close()


        Catch ex As Exception
            MessageBox.Show(My.Resources.Message.msg1, "messagebox_name")
            '"表の読み込みに失敗しました。savefileフォルダに[table1.csv(カンマ区切り)]を作成してください。"

        End Try







        '■画像ファイル複製

        'n.bmpをnbmpフォルダからcopyフォルダに移動
        For i = 0 To listnumber.Items.Count - 1

            System.IO.File.Move("./temp/temp_deladd/nbmp/" & i + 1 & ".bmp", "./temp/temp_deladd/copy/" & i + 1 & ".bmp")

        Next

        '複製元のpictureフォルダ内のファイルを削除
        DeleteFolder(txtpass_picturefolder.Text)

        '全てのbmpファイルををcopyフォルダからpictureフォルダに移動
        My.Computer.FileSystem.CopyDirectory("./temp/temp_deladd/copy/", txtpass_picturefolder.Text & "/",
    FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)


        '■テキストファイル移動
        '複製元のtextフォルダ内のファイルを削除
        DeleteFolder(txtpass_rtf.Text)

        '全てのrtfファイルををtextフォルダからプロファイルのtextフォルダに移動
        My.Computer.FileSystem.CopyDirectory("./temp/temp_deladd/text/", txtpass_rtf.Text & "/",
    FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)



        Console.WriteLine("終了")
        MessageBox.Show("出力終了")
        Me.Close()


    End Sub


    Private Sub CsvFileSave(ByVal myfilename As String)

        Dim ii As Integer
        For ii = 0 To 0

            Try


                '表示中のデータをCSV形式で(上書き保存)保存
                'Dim FileName As String = myfilename ' SaveFileName
                '現在のファイルに上書き保存
                Using swCsv As New System.IO.StreamWriter(txtpass_csv.Text,
                                          False, System.Text.Encoding.GetEncoding("SHIFT_JIS"))
                    Dim sf As String = Chr(34)          'データの前側の括り
                    Dim se As String = Chr(34) & ","    'データの後ろの括りとデータの区切りの "," 
                    Dim i, j As Integer
                    Dim WorkText As String = ""         '1個分のデータ保持用
                    Dim LineText As String = ""         '1列分のデータ保持用

                    With Copytable
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
                        Copytable.AllowUserToAddRows = False

                        '実データ部分の取得・保存処理
                        For i = 0 To .RowCount - 1
                            LineText = ""                                         '１行分のデータをクリア
                            For j = 0 To .Columns.Count - 1                       '１行分のデータを取得処理
                                WorkText = Copytable.Item(j, i).Value.ToString              '１個セルデータを取得
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

                Copytable.AllowUserToAddRows = True



            Catch ex As Exception

                MsgBox(My.Resources.Message.msg25, MsgBoxStyle.Exclamation) '"行内の空欄を埋めてください。"
                Copytable.AllowUserToAddRows = True
            End Try

        Next
    End Sub



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

    Private Sub btnclosewindow_Click(sender As Object, e As EventArgs) Handles btnclosewindow.Click
        Me.Close()
    End Sub
End Class