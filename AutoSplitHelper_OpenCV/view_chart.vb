Imports System.Windows.Forms.DataVisualization.Charting

Public Class view_chart
    Private Sub view_chart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' チャート表示エリア周囲の余白をカットする
        Chart1.ChartAreas(0).InnerPlotPosition.Auto = False
        Chart1.ChartAreas(0).InnerPlotPosition.Width = 100 ' 100%
        Chart1.ChartAreas(0).InnerPlotPosition.Height = 90 ' 90%(横軸のメモリラベル印字分の余裕を設ける)
        Chart1.ChartAreas(0).InnerPlotPosition.X = 10
        Chart1.ChartAreas(0).InnerPlotPosition.Y = 0

        Chart1.ChartAreas.Clear()

        reloadchart()
    End Sub

    '■ラベルのドラッグでウィンドウを動かす■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
    Private mousePoint As Point
    'Form1のMouseDownイベントハンドラ
    Private Sub Form1_MouseDown(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles Chart1.MouseDown

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            '位置を記憶する
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    'Form1のMouseMoveイベントハンドラ
    Private Sub Form1_MouseMove(ByVal sender As Object,
        ByVal e As System.Windows.Forms.MouseEventArgs) _
        Handles Chart1.MouseMove

        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y

        End If

    End Sub

    Private Sub btnresponse_Click(sender As Object, e As EventArgs) Handles btnresponse.Click

        reloadchart()

    End Sub

    Private Sub reloadchart()

        Chart1.ChartAreas.Clear()
        Dim ch1 As Chart = Chart1
        Dim chare As ChartArea = New ChartArea
        ch1.ChartAreas.Add(chare)
        ch1.Series.Clear()

        Dim se1 As Series = New Series(0)


        se1.BorderWidth = 1.5 '線の太さ
        se1.ChartType = SeriesChartType.Line '線の描画方法
        se1.Color = ColorTranslator.FromHtml("#0CC1BE") '線の色

        ch1.Series.Add(se1)

        Dim se2 As Series = New Series(1)

        se2.BorderWidth = 0 '線の太さ
        se2.ChartType = SeriesChartType.Line '線の描画方法
        se2.Color = Color.White '線の色

        ch1.Series.Add(se2)



        Chart1.BackColor = ColorTranslator.FromHtml("#0B120B") 'チャートエリアの背景色
        Chart1.ChartAreas(0).BackColor = Color.Transparent 'グラフエリアの背景色

        Chart1.Legends(0).Enabled = False        '凡例を消す


        'グラフの細かい設定
        With Chart1.ChartAreas(0)        'Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = True

            With .AxisX
                .Interval = 1    '点数のメモリ間隔(２０点毎)

                .LabelAutoFitMaxFontSize = 10                'ラベルのフォントの最大値
                .LabelAutoFitMinFontSize = 10                'ラベルのフォントの最小値

                .LineColor = Color.White                '境界線の色
                .LineWidth = 1

                .MajorGrid.Enabled = False               'ラベル毎の区切り線を区切らない

                '.TitleForeColor = Color.Pink                'X軸ラベルの色
                .LabelStyle.ForeColor = Color.White

                '主線
                .MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid

                .MajorGrid.Interval = 1
                .MajorGrid.LineColor = Color.LightGray


                '補助線
                .MinorGrid.Enabled = False  'True に設定しないと表示しない
                .MinorGrid.Interval = 10
                .MinorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                .MinorGrid.LineColor = Color.White

            End With

            With .AxisY

                '.Title = "Clear rate"
                '.TitleForeColor = Color.White
                '.TitleFont = New Font("Meiryo UI", 12)

                .Maximum = 100    '最大値。0-100%で表示したい。
                .Minimum = 0      '最小値

                .Interval = 100    'メモリ間隔
                .LineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid

                .LabelAutoFitMaxFontSize = 10 'ラベルのフォントの最大値
                .LabelAutoFitMinFontSize = 10 'ラベルのフォントの最小値

                .LineColor = Color.White '境界線の色
                .LineWidth = 1

                .LabelStyle.ForeColor = Color.White

                '主線
                .MajorGrid.LineColor = Color.Gray
                .MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Solid

                .MajorGrid.Interval = 50

                '補助線
                .MinorGrid.Enabled = False  'True に設定しないと表示しない
                .MinorGrid.Interval = 10
                .MinorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dash
                .MinorGrid.LineColor = Color.White

                '.LabelStyle.Format = "#,###"  '桁区切りで表示の場合

            End With


        End With


        'DataGridView上の列数取得
        Dim XDataCount = Mainwindow.DGtable.Rows.Count - 2

        For j As Integer = 0 To (XDataCount)

            If Mainwindow.DGtable(Mainwindow.graph_view.Index, j).Value = 1 Then

                '列名取得
                Dim currentColumnNameJ = Mainwindow.DGtable(0, j).Value
                'データ取得
                Dim YVal As String = Mainwindow.DGtable(Mainwindow.graph_rate.Index, j).Value
                'If InStr(mainDv.Table.Columns(j).ColumnName, "20") <> 0 Then
                'データをグラフに当てはめる
                se1.Points.AddXY(currentColumnNameJ, YVal)
                se1.LabelForeColor = Color.White
                'se1.Label = "#VALY"

                se2.Points.AddXY(Mainwindow.DGtable(Mainwindow.graph_count.Index, j).Value.ToString, 100)
                se2.LabelForeColor = Color.White
                se2.Font = New Font("Meiryo UI", 12)
                se2.Label = "#VALX"
                'End If

            End If

        Next j


    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub


End Class