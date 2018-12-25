Public Class Table_description
    Private Sub Table_description_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        '現在のコードを実行しているAssemblyを取得
        Dim myAssembly As System.Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        '指定されたマニフェストリソースを読み込む
        Dim sr As New System.IO.StreamReader(
            myAssembly.GetManifestResourceStream("AutoSplitHelper_OpenCV.Description_Table.txt"),
                System.Text.Encoding.GetEncoding("Shift-JIS"))
        '内容を読み込む
        Dim s As String = sr.ReadToEnd()
        '後始末
        sr.Close()
        sr.Dispose()
        rtxtdescription_table.Text = s
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        '現在のコードを実行しているAssemblyを取得
        Dim myAssembly As System.Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
        '指定されたマニフェストリソースを読み込む
        Dim sr As New System.IO.StreamReader(
            myAssembly.GetManifestResourceStream("AutoSplitHelper_OpenCV.Description_Table_en.txt"),
                System.Text.Encoding.UTF8)
        '内容を読み込む
        Dim s As String = sr.ReadToEnd()
        '後始末
        sr.Close()
        sr.Dispose()
        rtxtdescription_table.Text = s
    End Sub
End Class