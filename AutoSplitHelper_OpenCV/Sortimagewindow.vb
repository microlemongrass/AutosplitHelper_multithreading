Imports System.Drawing.Imaging
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.IO

Public Class Sortimagewindow


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '■表の見た目を変更
        dg1.DefaultCellStyle.ForeColor = Color.Black
        dg1.DefaultCellStyle.Font = New Font("Meiryo UI", 10)
        dg1.ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9)
        dg1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dg1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dg1.RowHeadersWidth = 30

        dgad.DefaultCellStyle.ForeColor = Color.Black
        dgad.DefaultCellStyle.Font = New Font("Meiryo UI", 10)
        dgad.ColumnHeadersDefaultCellStyle.Font = New Font("Meiryo UI", 9)
        dgad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgad.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        dgad.RowHeadersWidth = 30


        txtaddcount.Text = 0


        Dim delDir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo("./temp")

        Try

            'If System.IO.Directory.Exists("./temp") Then
            delDir.Delete(True)
            'System.IO.Directory.Delete("./temp", True)
            'End If

        Catch
            Console.Write("Tempファイル削除できず")
        End Try


        '■tempフォルダ作成
        System.IO.Directory.CreateDirectory("./temp")

        count_list()


    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click

        Dim aaa As String = "Sort images"
        Dim p As System.Diagnostics.Process =
        System.Diagnostics.Process.Start(aaa)
        Me.Close()


    End Sub


    Private Sub btnload_profile_Click(sender As Object, e As EventArgs) Handles btnload_profile.Click

        If Not File.Exists("./temp") Then
            System.IO.Directory.CreateDirectory("./temp")
        End If

        txtimageheight.Text = 0


        'FolderBrowserDialogクラスのインスタンスを作成
        Dim fbd As New FolderBrowserDialog

        '上部に表示する説明テキストを指定する
        fbd.Description = My.Resources.Message.msg1 'フォルダを指定してください。
        'ルートフォルダを指定する
        'デフォルトでDesktop
        fbd.RootFolder = Environment.SpecialFolder.Desktop
        '最初に選択するフォルダを指定する
        'RootFolder以下にあるフォルダである必要がある
        Dim stCurrentDir As String = System.IO.Directory.GetCurrentDirectory()

        fbd.SelectedPath = stCurrentDir


        'ユーザーが新しいフォルダを作成できるようにする
        'デフォルトでTrue
        fbd.ShowNewFolderButton = True

        'ダイアログを表示する
        If fbd.ShowDialog(Me) = DialogResult.OK Then

            '選択されたフォルダを表示する
            Console.WriteLine(fbd.SelectedPath)
            txtpass_profile.Text = fbd.SelectedPath

            txtname.Text = System.IO.Path.GetFileNameWithoutExtension(fbd.SelectedPath)
            txtoutputname.Text = System.IO.Path.GetFileNameWithoutExtension(fbd.SelectedPath)


            '同じ階層に同じ名前のcsvファイルがあったら選択。
            If System.IO.File.Exists(txtpass_profile.Text & "/table.csv") Then
                txtpass_csv.Text = txtpass_profile.Text & "/table.csv"
                txtpass_csv.BackColor = Color.FromArgb(180, 252, 180)
            Else
                MessageBox.Show("Not found: " & txtpass_profile.Text & "/table.csv")
                Exit Sub

            End If

            '同じ階層に同じ名前のpictureフォルダがあったら選択。
            If System.IO.Directory.Exists(txtpass_profile.Text & "/picture/") Then
                txtpass_picturefolder.Text = txtpass_profile.Text & "/picture"
                txtpass_picturefolder.BackColor = Color.FromArgb(180, 252, 180)
            Else
                MessageBox.Show("Not found: " & txtpass_profile.Text & "/picture/")
                Exit Sub

            End If

            '同じ階層に同じ名前のtextフォルダがあったら選択。
            If System.IO.Directory.Exists(txtpass_profile.Text & "/text/") Then
                txtpass_text.Text = txtpass_profile.Text & "/text"
                txtpass_text.BackColor = Color.FromArgb(180, 252, 180)
            Else
                MessageBox.Show("Not found: " & txtpass_profile.Text & "/text/")
                Exit Sub

            End If




            Dim di_picture1 As New System.IO.DirectoryInfo(txtpass_profile.Text & "/picture")
            Dim files_picture1 As System.IO.FileInfo() = di_picture1.GetFiles("*.bmp", System.IO.SearchOption.TopDirectoryOnly)
            Dim FileCount_bmponly As Integer

            For Each f_picture1 As System.IO.FileInfo In files_picture1
                FileCount_bmponly += 1
            Next

            Dim di_text1 As New System.IO.DirectoryInfo(txtpass_profile.Text & "/text")
            Dim files_text1 As System.IO.FileInfo() = di_text1.GetFiles("*.rtf", System.IO.SearchOption.TopDirectoryOnly)
            Dim FileCount_text As Integer

            For Each f_text1 As System.IO.FileInfo In files_text1
                FileCount_text += 1
            Next



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




            If System.IO.File.Exists(txtpass_picturefolder.Text & "/reset.bmp") Then
                chkreset.Checked = True
            End If




            Dim Newfile As String = "./temp/" & txtname.Text 'profile大元
            Dim NewFolder_picture As String = "./temp/" & txtname.Text & "/picture"
            Dim NewFolder_text As String = "./temp/" & txtname.Text & "/text"



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





            'パスからファイル/フォルダコピーする。コピー先フォルダの作成。
            System.IO.Directory.CreateDirectory("./temp/" & txtname.Text)
            System.IO.Directory.CreateDirectory("./temp/" & txtname.Text & "/picture")
            System.IO.Directory.CreateDirectory("./temp/" & txtname.Text & "/text")




            '画像フォルダを./temp/name/picture以下に。
            My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, NewFolder_picture,
            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)

            'テキストフォルダを./temp/name/text以下に。
            My.Computer.FileSystem.CopyDirectory(txtpass_text.Text, NewFolder_text,
            FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)



            '■名前変更(picture)3桁にする。
            If chkreset.Checked = False Then

                For ii = 1 To CInt(txtcount_picture.Text)

                    System.IO.File.Move(NewFolder_picture & "\" & ii & ".bmp", NewFolder_picture & "\" & CStr(ii).PadLeft(3, "0"c) & ".bmp")

                Next



            ElseIf chkreset.Checked = True Then 'countがResetの分多いので、1減らす。

                For ii = 1 To CInt(txtcount_picture.Text) - 1

                    System.IO.File.Move(NewFolder_picture & "\" & ii & ".bmp", NewFolder_picture & "\" & CStr(ii).PadLeft(3, "0"c) & ".bmp")

                Next

                System.IO.File.Move(NewFolder_picture & "\reset.bmp", NewFolder_picture & "\000reset.bmp")


            End If



            '■名前変更(text)3桁にする。
            For ii = 1 To FileCount_text

                System.IO.File.Move(NewFolder_text & "\" & ii & ".rtf", NewFolder_text & "\" & CStr(ii).PadLeft(3, "0"c) & ".rtf")

            Next







            '■Textフォルダの記述
            ' ファイルが存在しているかどうか確認する
            Dim di_text As New System.IO.DirectoryInfo(NewFolder_text)
            Dim files_text As System.IO.FileInfo() = di_text.GetFiles("*.rtf", System.IO.SearchOption.TopDirectoryOnly)

            'listpassに結果を表示する
            listfullpass_text.Items.Clear()
            listname_text.Items.Clear()

            For Each f_text As System.IO.FileInfo In files_text
                listfullpass_text.Items.Add(f_text.FullName)
                listname_text.Items.Add(System.IO.Path.GetFileNameWithoutExtension(f_text.FullName))

            Next




            ' ファイルが存在しているかどうか確認する
            Dim di_2 As New System.IO.DirectoryInfo(NewFolder_picture)
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


                ' 画像の幅と高さの取得■■■■■■■■
                Dim imagew, imageh As Integer
                Dim fs As System.IO.FileStream
                ' Specify a valid picture file path on your computer.
                fs = New System.IO.FileStream(listfullpass_picture.Items(i), IO.FileMode.Open, IO.FileAccess.Read)
                imagew = System.Drawing.Image.FromStream(fs).Width
                imageh = System.Drawing.Image.FromStream(fs).Height
                fs.Close()

                Dim rowfull_text As String
                Dim rowname_text As String

                If System.IO.File.Exists(txtpass_picturefolder.Text & "/reset.bmp") Then

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
            Next


            listname_picture.SelectedIndex = 0

            '■csvデータ更新
            txtpass_csv_TextChanged()


        End If


    End Sub

    Sub txtpass_csv_TextChanged()

        'csvファイルコピー
        Dim NewFolder As String = "./temp/" & txtname.Text & "/table"
        System.IO.File.Copy(txtpass_csv.Text, NewFolder & ".csv", True)


        Dim parser As TextFieldParser = New TextFieldParser(NewFolder & ".csv", Encoding.GetEncoding("Shift_JIS"))
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



    Private Sub btnoutput_Click(sender As Object, e As EventArgs) Handles btnoutput.Click

        Try
            If listselect_pass_picture.Items.Count <> 0 Then

                If System.IO.Directory.Exists("./output/" & txtoutputname.Text) Then
                    MessageBox.Show(My.Resources.Message.msg2) '"フォルダが既に存在しています。"
                Else


                    'output以下にプロファイルフォルダを作成
                    System.IO.Directory.CreateDirectory("./output/" & txtoutputname.Text) '大元
                    System.IO.Directory.CreateDirectory("./output/" & txtoutputname.Text & "/picture") '画像フォルダ
                    System.IO.Directory.CreateDirectory("./output/" & txtoutputname.Text & "/text") 'テキストフォルダ

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
                        CsvFileSave()

                        MsgBox(My.Resources.Message.msg3) '"現在表示中のデータを保存しました。"






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
                        CsvFileSave()

                        MsgBox(My.Resources.Message.msg3) '"現在表示中のデータを保存しました。"


                    End If




                End If

            End If





        Catch
            MsgBox(My.Resources.Message.msg4)
            '"エラー。csv等が保存されていない可能性があります。空欄がないか確かめてみて下さい。"
        End Try

    End Sub

    Private Sub btnzip_Click(sender As Object, e As EventArgs) Handles btnzip.Click

        If listselect_pass_picture.Items.Count <> 0 Then

            If System.IO.Directory.Exists("./output/" & txtoutputname.Text) Then
                MessageBox.Show(My.Resources.Message.msg2) '"フォルダが既に存在しています。"
            Else

                Sortimage_input_info.Show()

            End If
        End If

    End Sub

    Private Sub btnzipok_Click(sender As Object, e As EventArgs) Handles btnzipok.Click

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
            CsvFileSave()

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
            CsvFileSave()

            'MsgBox("現在表示中のデータを保存しました。")


        End If

        'zipファイルの作成


        System.IO.Compression.ZipFile.CreateFromDirectory("./output/" & txtoutputname.Text & "/",
                                                                  "./output/" & txtoutputname.Text & ".zip")

        MsgBox(My.Resources.Message.msg3) '"現在表示中のデータを保存しました。"

    End Sub


    Private Sub CsvFileSave()

        Dim ii As Integer
        For ii = 0 To 0

            ' 戻り値を格納する変数を宣言する
            Dim hStream As System.IO.FileStream

            ' hStream が破棄されることを保証するために Try ～ Finally を使用する
            Try
                ' hStream が閉じられることを保証するために Try ～ Finally を使用する
                Try
                    ' 指定したパスのファイルを作成する
                    hStream = System.IO.File.Create("./output/" & txtoutputname.Text & "/table.csv")

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

            Using swCsv As New System.IO.StreamWriter("./output/" & txtoutputname.Text & "/table.csv",
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






    '■ZIPファイル作成の詳細設定
    'System.IO.Compression.ZipFile.CreateFromDirectory(
    '    "./output/" & txtoutputname.Text & "/",
    '    "./output/" & txtoutputname.Text & "/" & txtoutputname.Text & ".zip",
    '    System.IO.Compression.CompressionLevel.Optimal,
    '    False,
    '    System.Text.Encoding.GetEncoding("shift_jis"))




End Class