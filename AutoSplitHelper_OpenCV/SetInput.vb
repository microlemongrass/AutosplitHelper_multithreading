Imports System.Runtime.InteropServices

Module SetInput
    Public Const KEY_DOWN As Short = 0 'キー押下
    Public Const KEY_UP As Short = 1 'キーアップ


    Structure INPUT_PARAM
        Dim wVk As Short
        Dim wScan As Short
        Dim dwFlags As Integer
        Dim time As Integer
        Dim dwExtraInfo As Integer
        Dim no_use1 As Integer
        Dim no_use2 As Integer
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Structure INPUT_TYPE
        <FieldOffset(0)> Dim dwType As Integer
        <FieldOffset(4)> Dim xi As INPUT_PARAM
    End Structure


    ''仮想キーコード
    'Public Const VK_CTRL As Short = &H11S 'Contorol
    'Public Const VK_V As Short = &H56S '「V」

    'Public Const Break As Short = &H3
    'Public Const Backspace As Short = &H8
    'Public Const Tab As Short = &H9
    'Public Const Enter As Short = &HD
    Public Const Shift As Short = &H10
    Public Const Ctrl As Short = &H11
    Public Const Alt As Short = &H12
    'Public Const Pause As Short = &H13
    'Public Const Esc As Short = &H1B
    'Public Const スペース As Short = &H20
    'Public Const PgUp As Short = &H21
    'Public Const PgDn As Short = &H22
    'Public Const Home As Short = &H24
    'Public Const Left As Short = &H25
    'Public Const Up As Short = &H26
    'Public Const Right As Short = &H27
    'Public Const Down As Short = &H28
    'Public Const Insert As Short = &H2D
    'Public Const Delete As Short = &H2E
    'Public Const key0 As Short = &H30
    'Public Const key1 As Short = &H31
    'Public Const key2 As Short = &H32
    'Public Const key3 As Short = &H33
    'Public Const key4 As Short = &H34
    'Public Const key5 As Short = &H35
    'Public Const key6 As Short = &H36
    'Public Const key7 As Short = &H37
    'Public Const key8 As Short = &H38
    'Public Const key9 As Short = &H39
    'Public Const A As Short = &H41
    'Public Const B As Short = &H42
    'Public Const C As Short = &H43
    'Public Const D As Short = &H44
    'Public Const E As Short = &H45
    'Public Const F As Short = &H46
    'Public Const G As Short = &H47
    'Public Const H As Short = &H48
    'Public Const I As Short = &H49
    'Public Const J As Short = &H4A
    'Public Const K As Short = &H4B
    'Public Const L As Short = &H4C
    'Public Const M As Short = &H4D
    'Public Const N As Short = &H4E
    'Public Const O As Short = &H4F
    'Public Const P As Short = &H50
    'Public Const Q As Short = &H51
    'Public Const R As Short = &H52
    'Public Const S As Short = &H53
    'Public Const T As Short = &H54
    'Public Const U As Short = &H55
    'Public Const V As Short = &H56
    'Public Const W As Short = &H57
    'Public Const X As Short = &H58
    'Public Const Y As Short = &H59
    'Public Const Z As Short = &H5A
    'Public Const num0 As Short = &H60
    'Public Const num1 As Short = &H61
    'Public Const num2 As Short = &H62
    'Public Const num3 As Short = &H63
    'Public Const num4 As Short = &H64
    'Public Const num5 As Short = &H65
    'Public Const num6 As Short = &H66
    'Public Const num7 As Short = &H67
    'Public Const num8 As Short = &H68
    'Public Const num9 As Short = &H69
    'Public Const F1 As Short = &H70
    'Public Const F2 As Short = &H71
    'Public Const F3 As Short = &H72
    'Public Const F4 As Short = &H73
    'Public Const F5 As Short = &H74
    'Public Const F6 As Short = &H75
    'Public Const F7 As Short = &H76
    'Public Const F8 As Short = &H77
    'Public Const F9 As Short = &H78
    'Public Const F10 As Short = &H79
    'Public Const F11 As Short = &H7A
    'Public Const F12 As Short = &H7B
    'Public Const F13 As Short = &H7C
    'Public Const F14 As Short = &H7D
    'Public Const F15 As Short = &H7E
    'Public Const F16 As Short = &H7F
    'Public Const F17 As Short = &H80
    'Public Const F18 As Short = &H81
    'Public Const F19 As Short = &H82
    'Public Const F20 As Short = &H83
    'Public Const F21 As Short = &H84
    'Public Const F22 As Short = &H85
    'Public Const F23 As Short = &H86
    'Public Const F24 As Short = &H87
    'Public Const NumLock As Short = &H90
    'Public Const ScrollLock As Short = &H91




    Private Const KEYEVENTF_KEYUP As Short = &H2S 'キーアップ
    Private Const KEYEVENTF_EXTENDEDKEY As Short = &H1S 'スキャンコードは拡張コード
    Private Const INPUT_KEYBOARD As Short = 1 '入力タイプ：キーボード

    '仮想キーコード・ASCII値・スキャンコード間でコードを変換する
    Declare Function MapVirtualKey Lib "user32" Alias "MapVirtualKeyA" (ByVal wCode As Integer, ByVal wMapType As Integer) As Integer
    '
    ' 仮想キーコードをスキャンコード、または文字の値（ASCII 値）へ変換。
    ' また、スキャンコードを仮想コードへ変換も可。
    '
    '［入力]
    ' 　wCode：キーの仮想キーコード、またはスキャンコードを指定。
    '　　　　　この値の解釈方法は、wMapType パラメータの値に依存。
    '
    ' 　uMapType:実行したい変換の種類を指定。
    ' 　このパラメータの値に基づいて、uCode パラメータの値は次のように解釈。
    '
    '　　値 意味
    '0 wCode は仮想キーコードであり、スキャンコードへ変換。
    ' 　　　左右のキーを区別しない仮想キーコードのときは、関数は左側のスキャンコードを返却。
    ' 　　1 wCode はスキャンコードであり、仮想キーコードへ変換。
    ' 　　　この仮想キーコードは、左右のキーを区別。
    ' 　　2 wCode は仮想キーコードであり、戻り値の下位ワードにシフトなしの ASCII 値が格納。
    ' 　　　デッドキー（ 分音符号）は、戻り値の上位ビットをセットすることにより明示される。
    ' 　　3 Windows NT/2000：uCode はスキャンコードであり、左右のキーを区別する仮想キーコードへ変換。
    '
    ' 　　　いづれも、変換されないときは、関数は 0 を返す。



    'キーボード入力、マウスボタンのクリックをシミュレートする
    Declare Function SendInput Lib "user32.dll" (ByVal nInputs As Integer, ByRef pInputs As INPUT_TYPE, ByVal cbSize As Integer) As Integer
    '
    ' nInputs:構造体の数を指定
    ' pInputs:配列へのポインタ INPUT 構造
    ' 　　　　各構造体には、キーボードまたはマウス入力動作に対応するイベントを表す
    ' cbSize :構造体のサイズを指定


    Sub KeyEvent(ByRef VkKey As Short, ByRef UpDown As Short)
        '
        ' 簡略化のためにAPIへは1文字ずつ入力⇒構造体は１つ
        '
        ' VkKey:仮想キーコード
        ' UpDown:動作(KEY_DOWN/KEY_UP)
        '
        Dim inputevents As INPUT_TYPE
        With inputevents
            .dwType = INPUT_KEYBOARD
            With .xi
                .wVk = VkKey '操作キーコード
                .wScan = MapVirtualKey(VkKey, 0) 'スキャンコード
                If UpDown = KEY_DOWN Then 'キーDown
                    .dwFlags = KEYEVENTF_EXTENDEDKEY Or 0
                Else 'キーＵＰ
                    .dwFlags = KEYEVENTF_EXTENDEDKEY Or KEYEVENTF_KEYUP
                End If
                .time = 0
                .dwExtraInfo = 0
            End With
        End With
        Call SendInput(1, inputevents, Len(inputevents))
    End Sub
End Module
