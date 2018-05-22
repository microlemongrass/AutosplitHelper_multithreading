Imports Microsoft.VisualBasic.FileIO
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Windows.Threading


Public Class getprocesswindow2

    'ウィンドウタイトルからハンドル値を取得するためのAPI■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Declare Function EnumWindows Lib "User32.dll" _
        (ByVal Proc As EnumWinProc, ByVal lParam As Integer) As Boolean

    Delegate Function EnumWinProc _
        (ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean

    Declare Function EnumChildWindows Lib "User32.dll" _
        (ByVal hWndParent As Integer, ByVal Proc As EnumChildProc, ByVal lParam As Integer) As Boolean

    Delegate Function EnumChildProc _
        (ByVal hwnd As IntPtr, ByVal lParam As Integer) As Boolean

    Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" _
        (ByVal hWnd As Integer, ByVal MSG As Integer,
        ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Declare Function SendMessageStr Lib "user32.dll" Alias "SendMessageA" _
        (ByVal hWnd As Integer, ByVal MSG As Integer,
        ByVal wParam As Integer, ByVal lParam As StringBuilder) As Integer

    Declare Function FindWindow Lib "user32" Alias "FindWindowA" _
(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer




    'ウィンドウタイトル取得用のAPI■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetWindowText(hWnd As IntPtr,
        lpString As StringBuilder, nMaxCount As Integer) As Integer
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function GetWindowTextLength(hWnd As IntPtr) As Integer
    End Function


    'ウィンドウ位置を指定するためのAPI■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■

    'MoveWindow関数の宣言
    Private Declare Function MoveWindow Lib "user32" Alias "MoveWindow" _
    (ByVal hwnd As IntPtr, ByVal x As Integer, ByVal y As Integer,
    ByVal nWidth As Integer, ByVal nHeight As Integer,
    ByVal bRepaint As Integer) As Integer


    ''' <summary>
    ''' GetWindowRect（Window の位置等を取得）の宣言
    ''' </summary>
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function GetWindowRect(ByVal hWnd As IntPtr,
                                          ByRef lpRect As RECT) _
                                          As Boolean
    End Function


    <DllImport("user32.dll", SetLastError:=True)>
    Public Shared Function GetWindowThreadProcessId(hWnd As IntPtr,
        ByRef lpdwProcessId As Integer) As Integer
    End Function




    ''' <summary>
    ''' RECT 構造体
    ''' </summary>
    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure


    Public Const WM_GETTEXT = &HD
    Public Const WM_GETTEXTLENGTH = &HE

    Private Sub getprocesswindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getwindowtitle()
        Me.Location = New Point(Mainwindow.Location.X + 100, Mainwindow.Location.Y + 100)
        ' このフォームを常に最前面に表示する
        Me.TopMost = True
    End Sub

    Private Sub btn2_getwindowtitle_Click(sender As Object, e As EventArgs) Handles btn2_getwindowtitle.Click
        getwindowtitle()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim sameitem As Integer = Mainwindow.cmbsomeapp.Items.IndexOf(Mainwindow.cmbsomeapp.Text) 'コンボボックスに同じものがあるか
        If sameitem <> -1 Then 'あったら
            Mainwindow.cmbsomeapp.Items.Remove(txtprocess.Text)
            Mainwindow.cmbsomeapp.Items.Insert(0, txtprocess.Text)
            Mainwindow.cmbsomeapp.SelectedIndex = 0
        Else
            Mainwindow.cmbsomeapp.Items.Insert(0, txtprocess.Text)
            Mainwindow.cmbsomeapp.SelectedIndex = 0
        End If

        'Mainwindow.cmbsomeapp.Items.Add(txtprocess.Text)
        'Mainwindow.cmbsomeapp.SelectedItem = txtprocess.Text


        Me.Close()

    End Sub

    Sub getwindowtitle()
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

        Dim hwndfind As Integer = FindWindow(vbNullString, list2_alltitle.SelectedItem)
        list2_hwnd.Items.Clear()
        list2_hwnd.Items.Add(hwndfind)

        'ハンドルの1番目を選択。################################################################################################
        list2_hwnd.SelectedIndex = 0

        '指定したウィンドウの座標を取得。#######################################################################################
        Dim hwnd As Integer = list2_hwnd.SelectedItem

        Dim lpRect As RECT
        '取得
        GetWindowRect(hwnd, lpRect)

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
End Class