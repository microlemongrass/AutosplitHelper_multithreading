Imports System.Drawing.Imaging
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.IO



'バックアップフォルダが作成されている。
'選択されているのは元のプロファイル
'元のプロファイル全てをtemp_sortにコピーしている状態。
Public Class Sortimagewindow


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '■ウィンドウ位置調整
        Me.Location = New Drawing.Point(Mainwindow.Location.X + 20, Mainwindow.Location.Y + 20)



        '■表の見た目を変更
        dg1.AllowUserToResizeRows = False

        dg1.EnableHeadersVisualStyles = False
        dg1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dg1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single

        dg1.DefaultCellStyle.ForeColor = Color.WhiteSmoke
        dg1.DefaultCellStyle.Font = New Font("Meiryo UI", 10)
        dg1.DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)

        dg1.ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9)
        dg1.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke

        dg1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)
        dg1.RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke

        dg1.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)
        dg1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.RowHeadersWidth = 30


        dg1.AllowUserToResizeRows = False

        dgad.EnableHeadersVisualStyles = False
        dgad.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dgad.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single
        dgad.DefaultCellStyle.ForeColor = Color.WhiteSmoke
        dgad.DefaultCellStyle.Font = New Font("Meiryo UI", 10)
        dgad.DefaultCellStyle.BackColor = Color.FromArgb(40, 42, 44)

        dgad.ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9)
        dg1.ColumnHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke

        dgad.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)
        dgad.RowHeadersDefaultCellStyle.ForeColor = Color.WhiteSmoke
        dgad.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(84, 86, 88)
        dgad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgad.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgad.RowHeadersWidth = 30


        txtaddcount.Text = 0

        '■temp/temp_sort/temp_outputフォルダ削除
        'Dim delDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("./temp/temp_sort")
        'delDir.Delete(True)
        Try

            If System.IO.Directory.Exists("./temp/temp_sort/temp_output") Then
                System.IO.Directory.Delete("./temp/temp_sort/temp_output", True)

            End If

        Catch
            Console.Write("temp/temp_sort/temp_outputファイル削除できず")
        End Try

        count_list()


        '■pass指定（バックアッププロファイルを選択）
        txtpass_picturefolder.Text = Mainwindow.txtpass_picturefolder.Text & "_backup"
        txtpass_csv.Text = Mainwindow.txtpass_csv.Text & "_backup"
        txtpass_rtf.Text = Mainwindow.txtpass_rtf.Text & "_backup"
        txtpass_profile.Text = "./profile/" & Mainwindow.cmbprofile.SelectedItem & "_backup"

        load_profile()


    End Sub



    Private temp_date As String

    Private Sub load_profile()

        '■temp/temp_sortフォルダを作成。
        If Not File.Exists("./temp/temp_sort") Then
            System.IO.Directory.CreateDirectory("./temp/temp_sort")
        End If

        txtimageheight.Text = 0





        '■選択されたフォルダを表示する（元のフォルダ）
        Console.WriteLine("./profile/" & Mainwindow.cmbprofile.SelectedItem)

        txtname.Text = System.IO.Path.GetFileNameWithoutExtension("./profile/" & Mainwindow.cmbprofile.SelectedItem)
        txtoutputname.Text = System.IO.Path.GetFileNameWithoutExtension("./profile/" & Mainwindow.cmbprofile.SelectedItem)


        '■同じ階層に同じ名前のcsvファイルがあったら選択。不要かもだがチェック機構もあるのでとりあえず残す。
        '■バックアップフォルダから選択
        If System.IO.File.Exists(txtpass_profile.Text & "/table.csv") Then
            txtpass_csv.Text = txtpass_profile.Text & "/table.csv"
            txtpass_csv.BackColor = Color.FromArgb(180, 252, 180)
        Else
            MessageBox.Show("Not found: " & txtpass_profile.Text & "/table.csv")
            Exit Sub

        End If

        '■同じ階層に同じ名前のpictureフォルダがあったら選択。
        If System.IO.Directory.Exists(txtpass_profile.Text & "/picture/") Then
            txtpass_picturefolder.Text = txtpass_profile.Text & "/picture"
            txtpass_picturefolder.BackColor = Color.FromArgb(180, 252, 180)
        Else
            MessageBox.Show("Not found: " & txtpass_profile.Text & "/picture/")
            Exit Sub

        End If

        '■同じ階層に同じ名前のtextフォルダがあったら選択。
        If System.IO.Directory.Exists(txtpass_profile.Text & "/text/") Then
            txtpass_rtf.Text = txtpass_profile.Text & "/text"
            txtpass_rtf.BackColor = Color.FromArgb(180, 252, 180)
        Else
            MessageBox.Show("Not found: " & txtpass_profile.Text & "/text/")
            Exit Sub

        End If



        '■全bmpファイル数取得
        Dim di_picture1 As New System.IO.DirectoryInfo(txtpass_profile.Text & "/picture")
        Dim files_picture1 As System.IO.FileInfo() = di_picture1.GetFiles("*.bmp", System.IO.SearchOption.TopDirectoryOnly)
        Dim FileCount_bmponly As Integer

        For Each f_picture1 As System.IO.FileInfo In files_picture1
            FileCount_bmponly += 1
        Next


        '■全テキストファイル数取得
        Dim di_text1 As New System.IO.DirectoryInfo(txtpass_profile.Text & "/text")
        Dim files_text1 As System.IO.FileInfo() = di_text1.GetFiles("*.rtf", System.IO.SearchOption.TopDirectoryOnly)
        Dim FileCount_text As Integer

        For Each f_text1 As System.IO.FileInfo In files_text1
            FileCount_text += 1
        Next


        '■n.bmpのファイル数取得
        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading1.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading2.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading3.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading4.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading5.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading6.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading7.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading8.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading9.bmp") Then
            FileCount_bmponly -= 1
        End If

        If System.IO.File.Exists(txtpass_profile.Text & "/picture/loading10.bmp") Then
            FileCount_bmponly -= 1
        End If


        txtcount_picture.Text = FileCount_bmponly



        '■ちょっと存在がよく分からない
        If System.IO.File.Exists(txtpass_picturefolder.Text & "/reset.bmp") Then
            chkreset.Checked = True
        End If



        '■ファイル数チェック。画像ファイル数（除Reset）=テキストファイル数★

        If chkreset.Checked = False Then 'リセット画像なし
            If Not FileCount_bmponly = FileCount_text Then
                MessageBox.Show("画像ファイル数とテキストファイル数が一致しません。" & vbCrLf &
                                    "Template file number(s):" & FileCount_bmponly & " ,Textfile number(s):" & FileCount_text)
                Exit Sub

            End If

        ElseIf chkreset.Checked = True Then 'リセット画像なし
            If Not FileCount_bmponly - 1 = FileCount_text Then
                MessageBox.Show("画像ファイル数とテキストファイル数が一致しません。" & vbCrLf &
                                        "Template file number(s, exclude reset.bmp):" & FileCount_bmponly - 1 & " ,Textfile number(s):" & FileCount_text)
                Exit Sub

            End If


        End If




        '■temp/temp_sort以下にフォルダ作成（Sortを開くたびに行う→数がどんどん増える）

        ' 必要な変数を宣言する
        Dim dtNow As DateTime = DateTime.Now
        ' 時刻の部分だけを取得する
        Dim tsNow As TimeSpan = dtNow.TimeOfDay

        temp_date = tsNow.ToString().Replace(":", "-")

        Dim Newfile_temp As String = "./temp/temp_sort/" & temp_date
        Dim NewFolder_picture_temp As String = "./temp/temp_sort/" & temp_date & "/picture"
        Dim NewFolder_text_temp As String = "./temp/temp_sort/" & temp_date & "/text"





        '■パスからファイル/フォルダコピーする。
        '■コピー先フォルダの作成。tableはあと
        System.IO.Directory.CreateDirectory(Newfile_temp)
        System.IO.Directory.CreateDirectory(NewFolder_picture_temp)
        System.IO.Directory.CreateDirectory(NewFolder_text_temp)

        System.IO.Directory.CreateDirectory("./temp/temp_sort/temp_output") '一時出力用
        System.IO.Directory.CreateDirectory("./temp/temp_sort/temp_output/picture")
        System.IO.Directory.CreateDirectory("./temp/temp_sort/temp_output/text")





        '■画像フォルダを./temp/name/picture以下に。
        My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, NewFolder_picture_temp,
            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

        '■テキストフォルダを./temp/name/text以下に。
        My.Computer.FileSystem.CopyDirectory(txtpass_rtf.Text, NewFolder_text_temp,
            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)



        '■名前変更(picture)3桁にする。
        If chkreset.Checked = False Then

            For ii = 1 To CInt(txtcount_picture.Text)

                System.IO.File.Move(NewFolder_picture_temp & "\" & ii & ".bmp", NewFolder_picture_temp & "\" & CStr(ii).PadLeft(3, "0"c) & ".bmp")

            Next


        ElseIf chkreset.Checked = True Then 'countがResetの分多いので、1減らす。

            For ii = 1 To CInt(txtcount_picture.Text) - 1

                System.IO.File.Move(NewFolder_picture_temp & "\" & ii & ".bmp", NewFolder_picture_temp & "\" & CStr(ii).PadLeft(3, "0"c) & ".bmp")

            Next

            System.IO.File.Move(NewFolder_picture_temp & "\reset.bmp", NewFolder_picture_temp & "\000reset.bmp")


        End If



        '■名前変更(text)3桁にする。
        For ii = 1 To FileCount_text

            System.IO.File.Move(NewFolder_text_temp & "\" & ii & ".rtf", NewFolder_text_temp & "\" & CStr(ii).PadLeft(3, "0"c) & ".rtf")

        Next







        '■Textフォルダの記述
        '■ファイルが存在しているかどうか確認する
        Dim di_text As New System.IO.DirectoryInfo(NewFolder_text_temp)
        Dim files_text As System.IO.FileInfo() = di_text.GetFiles("*.rtf", System.IO.SearchOption.TopDirectoryOnly)

        '■listpassに結果を表示する
        listfullpass_text.Items.Clear()
        listname_text.Items.Clear()

        For Each f_text As System.IO.FileInfo In files_text
            listfullpass_text.Items.Add(f_text.FullName)
            listname_text.Items.Add(System.IO.Path.GetFileNameWithoutExtension(f_text.FullName))

        Next




        '■ファイルが存在しているかどうか確認する
        Dim di_2 As New System.IO.DirectoryInfo(NewFolder_picture_temp)
        Dim files_2 As System.IO.FileInfo() =
            di_2.GetFiles("*.bmp", System.IO.SearchOption.TopDirectoryOnly)

        'listpassに結果を表示する
        listfullpass_picture.Items.Clear()
        listname_picture.Items.Clear()

        For Each f_2 As System.IO.FileInfo In files_2
            listfullpass_picture.Items.Add(f_2.FullName)
            listname_picture.Items.Add(System.IO.Path.GetFileNameWithoutExtension(f_2.FullName))

        Next



        '■Pictureの表への記述(Reset有無で場合分け)
        For i = 0 To txtcount_picture.Text - 1


            '■画像の幅と高さの取得■■■■■■■■
            Dim imagew, imageh As Integer
            Dim fs As System.IO.FileStream
            ' Specify a valid picture file path on your computer.
            fs = New System.IO.FileStream(listfullpass_picture.Items(i), IO.FileMode.Open, IO.FileAccess.Read)
            imagew = System.Drawing.Image.FromStream(fs).Width
            imageh = System.Drawing.Image.FromStream(fs).Height
            fs.Close()

            Dim rowfull_text As String
            Dim rowname_text As String

            If System.IO.File.Exists(NewFolder_picture_temp & "\000reset.bmp") Then

                If i = 0 Then
                    rowfull_text = listfullpass_text.Items(i)
                    rowname_text = listname_text.Items(i)

                Else
                    rowfull_text = listfullpass_text.Items(i - 1)
                    rowname_text = listname_text.Items(i - 1)


                End If


            Else
                rowfull_text = listfullpass_text.Items(i)
                rowname_text = listname_text.Items(i)


            End If


            Dim rowfull As String = listfullpass_picture.Items(i)
            Dim rowname As String = listname_picture.Items(i)
            dg1.Rows.Add(rowfull, rowname, "", "", New Bitmap(rowfull), rowfull_text, rowname_text)

            dg1.Rows(i).Height = imageh + 6
            If dg1.Rows(i).Height <= 20 Then
                dg1.Rows(i).Height = 20
            End If
        Next


        listname_picture.SelectedIndex = 0

        '■csvデータ読み込み
        txtpass_csv_read()





    End Sub


    Sub txtpass_csv_read()

        ''■csvファイルをバックアップフォルダのものからtemp/temp_sort/以下へコピー
        'Dim NewFolder As String = "./temp/temp_sort/" & txtname.Text & "/table"
        'System.IO.File.Copy(txtpass_csv.Text, NewFolder & ".csv", True)


        '■複製先のtable.csvを読み込み
        Dim parser As TextFieldParser = New TextFieldParser(txtpass_csv.Text, Encoding.GetEncoding("Shift_JIS"))
        parser.TextFieldType = FieldType.Delimited
        parser.SetDelimiters(",") ' 区切り文字はコンマ

        ' データをすべてクリア
        dgload.Rows.Clear()

        While (Not parser.EndOfData)
            Dim row As String() = parser.ReadFields() ' 1行読み込み
            ' 読み込んだデータ(1行をDataGridViewに表示する)
            dgload.Rows.Add(row)

        End While

        For Each c As DataGridViewColumn In dgload.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        For Each c As DataGridViewColumn In dgload.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        parser.Close()


        'dg1.Sort(dg1.Columns(1), System.ComponentModel.ListSortDirection.Descending)

        For ii = 0 To CInt(txtcount_picture.Text) 'CInt(listfullpass.Items.Count)
            dg1(2, ii).Value = dgload(0, ii).Value
        Next

    End Sub


    Private Sub dg1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles dg1.CellContentClick

        Try

            Dim count As Integer = txtaddcount.Text

            Dim dgv As DataGridView = CType(sender, DataGridView)
            '"Button"列ならば、ボタンがクリックされた
            If dgv.Columns(e.ColumnIndex).Name = "dgadd" Then
                'MessageBox.Show((e.RowIndex.ToString() +"行のボタンがクリックされました。"))

                listselect_pass_picture.Items.Add(dg1(0, CInt(e.RowIndex.ToString())).Value)
                listselect_picture.Items.Add(dg1(1, CInt(e.RowIndex.ToString())).Value)

                listselect_pass_text.Items.Add(dg1(dg_textfullpass.Index, CInt(e.RowIndex.ToString())).Value)
                listselect_text.Items.Add(dg1(dg_textnumber.Index, CInt(e.RowIndex.ToString())).Value)

                listcsvname.Items.Add(dg1(2, CInt(e.RowIndex.ToString())).Value)


                dgad.Rows.Add(1)
                dgad(0, count).Value = dgload(0, CInt(e.RowIndex.ToString())).Value
                dgad(1, count).Value = dgload(1, CInt(e.RowIndex.ToString())).Value
                dgad(2, count).Value = dgload(2, CInt(e.RowIndex.ToString())).Value
                dgad(3, count).Value = dgload(3, CInt(e.RowIndex.ToString())).Value
                dgad(4, count).Value = dgload(4, CInt(e.RowIndex.ToString())).Value
                dgad(5, count).Value = dgload(5, CInt(e.RowIndex.ToString())).Value
                dgad(6, count).Value = dgload(6, CInt(e.RowIndex.ToString())).Value
                dgad(7, count).Value = dgload(7, CInt(e.RowIndex.ToString())).Value
                dgad(8, count).Value = dgload(8, CInt(e.RowIndex.ToString())).Value
                dgad(9, count).Value = dgload(9, CInt(e.RowIndex.ToString())).Value
                dgad(10, count).Value = dgload(10, CInt(e.RowIndex.ToString())).Value
                dgad(11, count).Value = dgload(11, CInt(e.RowIndex.ToString())).Value
                dgad(12, count).Value = dgload(12, CInt(e.RowIndex.ToString())).Value
                dgad(13, count).Value = dgload(13, CInt(e.RowIndex.ToString())).Value
                dgad(14, count).Value = dgload(14, CInt(e.RowIndex.ToString())).Value
                dgad(15, count).Value = dgload(15, CInt(e.RowIndex.ToString())).Value
                dgad(16, count).Value = dgload(16, CInt(e.RowIndex.ToString())).Value
                dgad(17, count).Value = dgload(17, CInt(e.RowIndex.ToString())).Value
                dgad(18, count).Value = dgload(18, CInt(e.RowIndex.ToString())).Value
                dgad(19, count).Value = dgload(19, CInt(e.RowIndex.ToString())).Value

                '表をスクロールさせる
                dgad.FirstDisplayedScrollingRowIndex = txtaddcount.Text
                '最終行を選択している状態の場合、1行追加する。
                'If dgad.RowCount - 1 <= txtaddcount.Text Then
                '    dgad.Rows.Add(1)
                'End If




                listcsvname.SelectedIndex = txtaddcount.Text
                ' dg1.Rows(txtaddcount.Text).Selected = True

                txtaddcount.Text += 1
                btn1clear.Enabled = True




            End If

            count_list()

        Catch
            'MsgBox("画像もしくはcsvファイルが読み込まれていません。")
        End Try


    End Sub




    Private Sub btnzip_Click(sender As Object, e As EventArgs) Handles btnzip.Click

        If listselect_pass_picture.Items.Count <> 0 Then

            Sortimage_input_info.Show()


        End If


    End Sub

    Private Sub btnzipok_Click(sender As Object, e As EventArgs) Handles btnzipok.Click

        '■zipファイルと、確認用に通常のフォルダも作っておく。

        'プロファイルフォルダの作成は"input_info"にて。
        If chkreset_.Checked = False Then

            '■picture
            For ii = 0 To listselect_pass_picture.Items.Count - 1
                Dim img As Bitmap = System.Drawing.Image.FromFile(listselect_pass_picture.Items(ii))

                img.Save("./output/" & txtoutputname.Text & "/picture/" & ii + 1 & ".bmp", ImageFormat.Bmp)

            Next

            '■text
            For ii = 0 To listselect_pass_text.Items.Count - 1

                My.Computer.FileSystem.CopyFile(listselect_pass_text.Items(ii), "./output/" & txtoutputname.Text & "/text/" & ii + 1 & ".rtf",
                                       FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            Next


            '■csvファイルの保存
            CsvFileSave("./output/" & txtoutputname.Text & "/table.csv")

            'MsgBox("現在表示中のデータを保存しました。")


        ElseIf chkreset_.Checked = True Then
            ' フォルダ (ディレクトリ) を作成する


            '■picture
            For ii = 1 To listselect_pass_picture.Items.Count - 1
                Dim img As Bitmap = System.Drawing.Image.FromFile(listselect_pass_picture.Items(ii))

                img.Save("./output/" & txtoutputname.Text & "/picture/" & ii & ".bmp", ImageFormat.Bmp)

            Next

            Dim itemcount As Integer = 0
            Dim img_reset As Bitmap = System.Drawing.Image.FromFile(listselect_pass_picture.Items(itemcount))

            img_reset.Save("./output/" & txtoutputname.Text & "/picture/reset.bmp", ImageFormat.Bmp)

            '■text resetは飛ばす
            For ii = 0 To listselect_pass_text.Items.Count - 1
                If ii = 0 Then

                Else
                    My.Computer.FileSystem.CopyFile(listselect_pass_text.Items(ii), "./output/" & txtoutputname.Text & "/text/" & ii & ".rtf",
                                       FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                End If

            Next




            '■csvファイルの保存
            CsvFileSave("./output/" & txtoutputname.Text & "/table.csv")

            'MsgBox("現在表示中のデータを保存しました。")


        End If

        'zipファイルの作成


        System.IO.Compression.ZipFile.CreateFromDirectory("./output/" & txtoutputname.Text & "/",
                                                                  "./output/" & txtoutputname.Text & ".zip")


        '■バックアッププロファイルの削除
        'xxx_backupを選択し削除。defaultに戻るのでxxxに合わせる。

        Mainwindow.cmbprofile.SelectedItem = txtname.Text & "_backup"
        Mainwindow.deleteprofile_nomessage()
        Mainwindow.cmbprofile.SelectedItem = txtname.Text





        MsgBox("ZIP終わり") '(My.Resources.Message.msg3) '"現在表示中のデータを保存しました。"

        Me.Close()

    End Sub


    Private Sub CsvFileSave(filename As String)

        Dim ii As Integer
        For ii = 0 To 0

            ' 戻り値を格納する変数を宣言する
            Dim hStream As System.IO.FileStream

            ' hStream が破棄されることを保証するために Try ～ Finally を使用する
            Try
                ' hStream が閉じられることを保証するために Try ～ Finally を使用する
                Try
                    ' 指定したパスのファイルを作成する
                    hStream = System.IO.File.Create(filename)

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




            '表示中のデータをCSV形式で(上書き保存)保存
            'Dim FileName As String = myfilename ' SaveFileName
            '現在のファイルに上書き保存

            Using swCsv As New System.IO.StreamWriter(filename,
                                          False, System.Text.Encoding.GetEncoding("SHIFT_JIS"))
                Dim sf As String = Chr(34)          'データの前側の括り
                Dim se As String = Chr(34) & ","    'データの後ろの括りとデータの区切りの "," 
                Dim i, j As Integer
                Dim WorkText As String = ""         '1個分のデータ保持用
                Dim LineText As String = ""         '1列分のデータ保持用

                With dgad
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
                    dgad.AllowUserToAddRows = False

                    '実データ部分の取得・保存処理
                    For i = 0 To .RowCount - 1
                        LineText = ""                                         '１行分のデータをクリア
                        For j = 0 To .Columns.Count - 1                       '１行分のデータを取得処理
                            WorkText = dgad.Item(j, i).Value.ToString              '１個セルデータを取得
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

            dgad.AllowUserToAddRows = True


        Next


    End Sub


    Private Sub listselect_picture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listselect_picture.SelectedIndexChanged
        Try
            listselect_pass_picture.SelectedIndex = listselect_picture.SelectedIndex
            dgad.ClearSelection()
            dgad.Rows(listselect_picture.SelectedIndex).Selected = True
            '表をスクロールさせる
            dgad.FirstDisplayedScrollingRowIndex = txtaddcount.Text
        Catch
        End Try

    End Sub



    Private Sub btnclear_Click(sender As Object, e As EventArgs) Handles btnclear.Click
        listcsvname.Items.Clear()

        listselect_picture.Items.Clear()
        listselect_pass_picture.Items.Clear()

        listselect_text.Items.Clear()
        listselect_pass_text.Items.Clear()

        dgad.SelectAll()
        Dim r As DataGridViewRow
        For Each r In dgad.SelectedRows
            If Not r.IsNewRow Then
                dgad.Rows.Remove(r)
            End If
        Next r

        txtaddcount.Text = 0

        count_list()

    End Sub

    Private Sub btn1clear_Click(sender As Object, e As EventArgs) Handles btn1clear.Click
        dgad.Rows.RemoveAt(CInt(txtaddcount.Text - 1))
        listcsvname.Items.RemoveAt(CInt(txtaddcount.Text - 1))

        listselect_picture.Items.RemoveAt(CInt(txtaddcount.Text - 1))
        listselect_pass_picture.Items.RemoveAt(CInt(txtaddcount.Text - 1))

        listselect_text.Items.RemoveAt(CInt(txtaddcount.Text - 1))
        listselect_pass_text.Items.RemoveAt(CInt(txtaddcount.Text - 1))

        txtaddcount.Text -= 1

        If txtaddcount.Text = 0 Then
            btn1clear.Enabled = False

        End If

        count_list()

    End Sub

    Private Sub count_list()
        txtlistcount.Text = listcsvname.Items.Count
    End Sub

    Private Sub btnok_Click(sender As Object, e As EventArgs) Handles btnok.Click

        Try
            '必ず1つは選択している状態
            If listselect_pass_picture.Items.Count <> 0 Then

                '■現在の状態…画像ファイル、テキストファイルはリネームされていない、表は保存されていない。
                '■得ているパスの情報をtemp以下に保存する。その後バックアップ元のプロファイルにコピーする。



                '■リセット画像なしの場合。
                If chkreset_.Checked = False Then
                    '■picture
                    For ii = 0 To listselect_pass_picture.Items.Count - 1
                        Dim img As Bitmap = System.Drawing.Image.FromFile(listselect_pass_picture.Items(ii))

                        img.Save("./temp/temp_sort/temp_output/picture/" & ii + 1 & ".bmp", ImageFormat.Bmp)

                    Next

                    '■text
                    For ii = 0 To listselect_pass_text.Items.Count - 1

                        My.Computer.FileSystem.CopyFile(listselect_pass_text.Items(ii), "./temp/temp_sort/temp_output/text/" & ii + 1 & ".rtf",
                                       FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                    Next







                ElseIf chkreset_.Checked = True Then
                    ' フォルダ (ディレクトリ) を作成する

                    '■picture
                    For ii = 1 To listselect_pass_picture.Items.Count - 1
                        Dim img As Bitmap = System.Drawing.Image.FromFile(listselect_pass_picture.Items(ii))

                        img.Save("./temp/temp_sort/temp_output/picture/" & ii & ".bmp", ImageFormat.Bmp)

                    Next

                    Dim itemcount As Integer = 0
                    Dim img_reset As Bitmap = System.Drawing.Image.FromFile(listselect_pass_picture.Items(itemcount))

                    img_reset.Save("./temp/temp_sort/temp_output/picture/reset.bmp", ImageFormat.Bmp)


                    '■text resetは飛ばす
                    For ii = 0 To listselect_pass_text.Items.Count - 1
                        If ii = 0 Then

                        Else
                            My.Computer.FileSystem.CopyFile(listselect_pass_text.Items(ii), "./temp/temp_sort/temp_output/text/" & ii & ".rtf",
                                       FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                        End If

                    Next





                End If


                '■csvファイルの保存
                CsvFileSave("./temp/temp_sort/temp_output/table.csv")


                '■temp/temp_output以下の各ファイルを元プロファイルに移動
                '■元プロファイルの画像フォルダ、テキストフォルダ、csvを削除
                Directory.Delete("./profile/" & Mainwindow.cmbprofile.SelectedItem & "/picture", True)
                Directory.Delete("./profile/" & Mainwindow.cmbprofile.SelectedItem & "/text", True)
                File.Delete("./profile/" & Mainwindow.cmbprofile.SelectedItem & "/table.csv")

                '■temp/temp_output以下の各ファイルを元プロファイルに移動
                My.Computer.FileSystem.CopyDirectory("./temp/temp_sort/temp_output/picture",
                                                         "./profile/" & Mainwindow.cmbprofile.SelectedItem & "/picture/",
                                                            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                My.Computer.FileSystem.CopyDirectory("./temp/temp_sort/temp_output/text",
                                                         "./profile/" & Mainwindow.cmbprofile.SelectedItem & "/text/",
                                                            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                My.Computer.FileSystem.CopyFile("./temp/temp_sort/temp_output/table.csv",
                                                         "./profile/" & Mainwindow.cmbprofile.SelectedItem & "/table.csv",
                                                            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

                Console.WriteLine("ファイル/フォルダをtemp_outputからプロファイルへコピー")





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

                    Console.WriteLine("表の書き換え終わり")

                Catch ex As Exception
                    MessageBox.Show(My.Resources.Message.msg1, "messagebox_name")
                    '"表の読み込みに失敗しました。savefileフォルダに[table1.csv(カンマ区切り)]を作成してください。"

                End Try




                MsgBox("現在表示中のデータを保存しました。") '(My.Resources.Message.msg3) '"現在表示中のデータを保存しました。"

                Me.Close()

            End If




        Catch
            MsgBox(My.Resources.Message.msg4)
            '"エラー。csv等が保存されていない可能性があります。空欄がないか確かめてみて下さい。"
        End Try



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




    '■ZIPファイル作成の詳細設定
    'System.IO.Compression.ZipFile.CreateFromDirectory(
    '    "./output/" & txtoutputname.Text & "/",
    '    "./output/" & txtoutputname.Text & "/" & txtoutputname.Text & ".zip",
    '    System.IO.Compression.CompressionLevel.Optimal,
    '    False,
    '    System.Text.Encoding.GetEncoding("shift_jis"))




End Class