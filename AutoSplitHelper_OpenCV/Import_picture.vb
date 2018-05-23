Imports System.Drawing.Imaging
Imports System.Text
Imports Microsoft.VisualBasic.FileIO
Imports System.IO

Public Class Import_picture


    Private Sub btnimport_picture_Click(sender As Object, e As EventArgs) Handles btnimport_picture.Click



        'FolderBrowserDialogクラスのインスタンスを作成
        Dim fbd As New FolderBrowserDialog

        '上部に表示する説明テキストを指定する
        'fbd.Description = My.Resources.Message.msg1 'フォルダを指定してください。
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

            btnimport_csv.Enabled = True

            '選択されたフォルダを表示する
            Console.WriteLine(fbd.SelectedPath)
            txtpass_picturefolder.Text = fbd.SelectedPath

            txtname.Text = System.IO.Path.GetFileNameWithoutExtension(fbd.SelectedPath)



            '            Dim Newfile As String = "./temp/" & txtname.Text
            '            Dim NewFolder As String = "./temp/" & txtname.Text & "/" & txtname.Text


            '            'パスからファイル/フォルダコピーする。コピー先フォルダの作成。
            '            System.IO.Directory.CreateDirectory("./temp/" & txtname.Text)
            '            System.IO.Directory.CreateDirectory("./temp/" & txtname.Text & "/" & txtname.Text)




            '            '画像フォルダを./temp/name/name以下に。
            '            My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, NewFolder,
            'FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)




            '同じ階層に同じ名前のcsvファイルがあったら選択。
            If System.IO.File.Exists(txtpass_picturefolder.Text & ".csv") Then
                txtpass_csv.Text = txtpass_picturefolder.Text & ".csv"

            End If



            '■info.txtがあれば表示する。
            '文字列を取得して、/{name}を削除する。

            Dim pass_original As String = txtpass_picturefolder.Text './{name}

            'sがNothingでないことを確認
            If Not pass_original Is Nothing Then
                '文字数を取得
                Dim len1 As Integer = pass_original.Length


                Dim _name As String = txtname.Text './{name}

                'sがNothingでないことを確認
                If Not _name Is Nothing Then
                    '文字数を取得
                    Dim len2 As Integer = _name.Length

                    Dim s1 As String = pass_original.Substring(0, len1 - len2) & "info.txt"
                    Console.WriteLine(s1)


                    If File.Exists(s1) Then

                        Dim loadtxt As String = s1

                        txtinfo.Clear()
                        Dim st3 As New System.IO.StreamReader(loadtxt, System.Text.Encoding.Default)
                        'ファイルの最後までループ
                        Do Until st3.Peek = -1
                            '１行づつ読込む
                            txtinfo.AppendText(st3.ReadLine & vbCrLf)
                        Loop
                        ' txtloadprofile.Text = System.Text.RegularExpressions.Regex.Replace(txtloadprofile.Text & vbNewLine, "(\s+\r\n)+\z", "") '最後の空白行を取り除く
                        st3.Close()              'ファイルを閉じる


                    End If



                End If

            End If



        End If


    End Sub



    '■ラベルのドラッグでウィンドウを動かす■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    Private mousePoint As Point
    'Form1のMouseDownイベントハンドラ
    Private Sub Import_picture_MouseDown(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbltitlebar.MouseDown


        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    'Form1のMouseMoveイベントハンドラ
    Private Sub Import_picture_MouseMove(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbltitlebar.MouseMove


        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y

        End If

    End Sub

    Private Sub btnclosewindow_Click(sender As Object, e As EventArgs) Handles btnclosewindow.Click
        Me.Close()
    End Sub

    Private Sub btnimport_ok_Click(sender As Object, e As EventArgs) Handles btnimport_ok.Click

        '■新規にプロファイルを作成する。同名チェック→プロファイル作成、フォルダ作成、パスのフォルダ/ファイルコピー
        '基本的にメインウィンドウのコントロールを使用するため、メインウィンドウ上で行う。
        'If System.IO.File.Exists("./savedata/csvfile/" & txtname.Text & ".csv") Then
        If System.IO.File.Exists("./profile/" & txtname.Text & "/table.csv") Then '★
            MessageBox.Show(txtname.Text & My.Resources.Message.msg20, "AutoSplit Helper by Image") '"は既に存在しています。"
        Else


            Mainwindow.import_ok()

            'MsgBox("Success.")

        End If

    End Sub

    Private Sub btnimport_profile_Click(sender As Object, e As EventArgs) Handles btnimport_profile.Click
        'FolderBrowserDialogクラスのインスタンスを作成
        Dim fbd As New FolderBrowserDialog

        '上部に表示する説明テキストを指定する
        'fbd.Description = My.Resources.Message.msg1 'フォルダを指定してください。
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

            btnimport_csv.Enabled = True

            '選択されたフォルダを表示する
            Console.WriteLine(fbd.SelectedPath)
            txtpass_profile.Text = fbd.SelectedPath

            txtname.Text = System.IO.Path.GetFileNameWithoutExtension(fbd.SelectedPath)



            '            Dim Newfile As String = "./temp/" & txtname.Text
            '            Dim NewFolder As String = "./temp/" & txtname.Text & "/" & txtname.Text


            '            'パスからファイル/フォルダコピーする。コピー先フォルダの作成。
            '            System.IO.Directory.CreateDirectory("./temp/" & txtname.Text)
            '            System.IO.Directory.CreateDirectory("./temp/" & txtname.Text & "/" & txtname.Text)




            '            '画像フォルダを./temp/name/name以下に。
            '            My.Computer.FileSystem.CopyDirectory(txtpass_picturefolder.Text, NewFolder,
            'FileIO.UIOption.AllDialogs, FileIO.UICancelOption.DoNothing)




            '同じ階層に同じ名前のcsvファイルがあったら選択。
            If System.IO.File.Exists(txtpass_profile.Text & "/table.csv") Then
                txtpass_csv.Text = txtpass_profile.Text & "/table.csv"

            End If

            '同じ階層に同じ名前のtextフォルダがあったら選択。
            If System.IO.Directory.Exists(txtpass_profile.Text & "/text") Then
                txtpass_rtf.Text = txtpass_profile.Text & "/text"

            End If

            '同じ階層に同じ名前のpictureフォルダがあったら選択。
            If System.IO.Directory.Exists(txtpass_profile.Text & "/picture") Then
                txtpass_picturefolder.Text = txtpass_profile.Text & "/picture"

            End If


            '■info.txtがあれば表示する。
            '文字列を取得して、/{name}を削除する。

            'Dim pass_original As String = txtpass_picturefolder.Text './{name}

            ''sがNothingでないことを確認
            'If Not pass_original Is Nothing Then
            '    '文字数を取得
            '    Dim len1 As Integer = pass_original.Length


            '    Dim _name As String = txtname.Text './{name}

            '    'sがNothingでないことを確認
            '    If Not _name Is Nothing Then
            '        '文字数を取得
            '        Dim len2 As Integer = _name.Length

            '        Dim s1 As String = pass_original.Substring(0, len1 - len2) & "info.txt"
            '        Console.WriteLine(s1)


            'If File.Exists(s1) Then
            If File.Exists(txtpass_profile.Text & "/info.txt") Then

                Dim loadtxt As String = txtpass_profile.Text & "/info.txt"

                txtinfo.Clear()
                Dim st3 As New System.IO.StreamReader(loadtxt, System.Text.Encoding.Default)
                'ファイルの最後までループ
                Do Until st3.Peek = -1
                    '１行づつ読込む
                    txtinfo.AppendText(st3.ReadLine & vbCrLf)
                Loop
                ' txtloadprofile.Text = System.Text.RegularExpressions.Regex.Replace(txtloadprofile.Text & vbNewLine, "(\s+\r\n)+\z", "") '最後の空白行を取り除く
                st3.Close()              'ファイルを閉じる


            End If
            'End If

            ' End If

        End If


    End Sub


End Class