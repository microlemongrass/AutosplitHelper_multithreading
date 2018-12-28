<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Del_Addimagewindow
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Del_Addimagewindow))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtpass_picturefolder = New System.Windows.Forms.TextBox()
        Me.txtpass_csv = New System.Windows.Forms.TextBox()
        Me.txtpass_rtf = New System.Windows.Forms.TextBox()
        Me.listnumber = New System.Windows.Forms.ListBox()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btninsert = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.listcomment = New System.Windows.Forms.ListBox()
        Me.Copytable = New System.Windows.Forms.DataGridView()
        Me.no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.send = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.key = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sleep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.darksleep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.darkthr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seektime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.graph_count = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.graph_rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.graph_view = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.posx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.posy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sizex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sizey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ltx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbltitlebar = New System.Windows.Forms.Label()
        Me.btnclosewindow = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Copytable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpass_picturefolder
        '
        resources.ApplyResources(Me.txtpass_picturefolder, "txtpass_picturefolder")
        Me.txtpass_picturefolder.Name = "txtpass_picturefolder"
        '
        'txtpass_csv
        '
        resources.ApplyResources(Me.txtpass_csv, "txtpass_csv")
        Me.txtpass_csv.Name = "txtpass_csv"
        '
        'txtpass_rtf
        '
        resources.ApplyResources(Me.txtpass_rtf, "txtpass_rtf")
        Me.txtpass_rtf.Name = "txtpass_rtf"
        '
        'listnumber
        '
        Me.listnumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.listnumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.listnumber, "listnumber")
        Me.listnumber.ForeColor = System.Drawing.SystemColors.Control
        Me.listnumber.FormattingEnabled = True
        Me.listnumber.Name = "listnumber"
        '
        'btnok
        '
        Me.btnok.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(55, Byte), Integer))
        resources.ApplyResources(Me.btnok, "btnok")
        Me.btnok.ForeColor = System.Drawing.SystemColors.Control
        Me.btnok.Name = "btnok"
        Me.btnok.UseVisualStyleBackColor = False
        '
        'btninsert
        '
        Me.btninsert.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btninsert, "btninsert")
        Me.btninsert.ForeColor = System.Drawing.SystemColors.Control
        Me.btninsert.Name = "btninsert"
        Me.btninsert.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btndelete, "btndelete")
        Me.btndelete.ForeColor = System.Drawing.SystemColors.Control
        Me.btndelete.Name = "btndelete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DimGray
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'listcomment
        '
        Me.listcomment.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.listcomment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.listcomment, "listcomment")
        Me.listcomment.ForeColor = System.Drawing.SystemColors.Control
        Me.listcomment.FormattingEnabled = True
        Me.listcomment.Name = "listcomment"
        '
        'Copytable
        '
        Me.Copytable.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Copytable.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Meiryo UI", 9.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Copytable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Copytable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Copytable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.no, Me.send, Me.key, Me.rate, Me.sleep, Me.timing, Me.darksleep, Me.darkthr, Me.seektime, Me.Column1, Me.Column2, Me.Column3, Me.graph_count, Me.graph_rate, Me.graph_view, Me.posx, Me.posy, Me.sizex, Me.sizey, Me.ltx, Me.lty, Me.rbx, Me.rby})
        resources.ApplyResources(Me.Copytable, "Copytable")
        Me.Copytable.Name = "Copytable"
        Me.Copytable.RowTemplate.Height = 21
        '
        'no
        '
        resources.ApplyResources(Me.no, "no")
        Me.no.Name = "no"
        '
        'send
        '
        resources.ApplyResources(Me.send, "send")
        Me.send.Name = "send"
        '
        'key
        '
        resources.ApplyResources(Me.key, "key")
        Me.key.Name = "key"
        '
        'rate
        '
        resources.ApplyResources(Me.rate, "rate")
        Me.rate.Name = "rate"
        '
        'sleep
        '
        resources.ApplyResources(Me.sleep, "sleep")
        Me.sleep.Name = "sleep"
        '
        'timing
        '
        resources.ApplyResources(Me.timing, "timing")
        Me.timing.Name = "timing"
        '
        'darksleep
        '
        resources.ApplyResources(Me.darksleep, "darksleep")
        Me.darksleep.Name = "darksleep"
        '
        'darkthr
        '
        resources.ApplyResources(Me.darkthr, "darkthr")
        Me.darkthr.Name = "darkthr"
        '
        'seektime
        '
        resources.ApplyResources(Me.seektime, "seektime")
        Me.seektime.Name = "seektime"
        '
        'Column1
        '
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        '
        'Column3
        '
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        '
        'graph_count
        '
        resources.ApplyResources(Me.graph_count, "graph_count")
        Me.graph_count.Name = "graph_count"
        '
        'graph_rate
        '
        resources.ApplyResources(Me.graph_rate, "graph_rate")
        Me.graph_rate.Name = "graph_rate"
        '
        'graph_view
        '
        resources.ApplyResources(Me.graph_view, "graph_view")
        Me.graph_view.Name = "graph_view"
        '
        'posx
        '
        resources.ApplyResources(Me.posx, "posx")
        Me.posx.Name = "posx"
        '
        'posy
        '
        resources.ApplyResources(Me.posy, "posy")
        Me.posy.Name = "posy"
        '
        'sizex
        '
        resources.ApplyResources(Me.sizex, "sizex")
        Me.sizex.Name = "sizex"
        '
        'sizey
        '
        resources.ApplyResources(Me.sizey, "sizey")
        Me.sizey.Name = "sizey"
        '
        'ltx
        '
        resources.ApplyResources(Me.ltx, "ltx")
        Me.ltx.Name = "ltx"
        '
        'lty
        '
        resources.ApplyResources(Me.lty, "lty")
        Me.lty.Name = "lty"
        '
        'rbx
        '
        resources.ApplyResources(Me.rbx, "rbx")
        Me.rbx.Name = "rbx"
        '
        'rby
        '
        resources.ApplyResources(Me.rby, "rby")
        Me.rby.Name = "rby"
        '
        'lbltitlebar
        '
        resources.ApplyResources(Me.lbltitlebar, "lbltitlebar")
        Me.lbltitlebar.BackColor = System.Drawing.Color.DarkGray
        Me.lbltitlebar.ForeColor = System.Drawing.Color.Black
        Me.lbltitlebar.Name = "lbltitlebar"
        '
        'btnclosewindow
        '
        Me.btnclosewindow.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.btnclosewindow, "btnclosewindow")
        Me.btnclosewindow.ForeColor = System.Drawing.Color.Thistle
        Me.btnclosewindow.Name = "btnclosewindow"
        Me.btnclosewindow.UseVisualStyleBackColor = False
        '
        'Del_Addimagewindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Controls.Add(Me.btnclosewindow)
        Me.Controls.Add(Me.lbltitlebar)
        Me.Controls.Add(Me.Copytable)
        Me.Controls.Add(Me.listcomment)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btninsert)
        Me.Controls.Add(Me.btnok)
        Me.Controls.Add(Me.listnumber)
        Me.Controls.Add(Me.txtpass_rtf)
        Me.Controls.Add(Me.txtpass_csv)
        Me.Controls.Add(Me.txtpass_picturefolder)
        Me.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Del_Addimagewindow"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Copytable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtpass_picturefolder As TextBox
    Friend WithEvents txtpass_csv As TextBox
    Friend WithEvents txtpass_rtf As TextBox
    Friend WithEvents listnumber As ListBox
    Friend WithEvents btnok As Button
    Friend WithEvents btninsert As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents listcomment As ListBox
    Friend WithEvents Copytable As DataGridView
    Friend WithEvents lbltitlebar As Label
    Friend WithEvents btnclosewindow As Button
    Friend WithEvents no As DataGridViewTextBoxColumn
    Friend WithEvents send As DataGridViewTextBoxColumn
    Friend WithEvents key As DataGridViewTextBoxColumn
    Friend WithEvents rate As DataGridViewTextBoxColumn
    Friend WithEvents sleep As DataGridViewTextBoxColumn
    Friend WithEvents timing As DataGridViewTextBoxColumn
    Friend WithEvents darksleep As DataGridViewTextBoxColumn
    Friend WithEvents darkthr As DataGridViewTextBoxColumn
    Friend WithEvents seektime As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents graph_count As DataGridViewTextBoxColumn
    Friend WithEvents graph_rate As DataGridViewTextBoxColumn
    Friend WithEvents graph_view As DataGridViewTextBoxColumn
    Friend WithEvents posx As DataGridViewTextBoxColumn
    Friend WithEvents posy As DataGridViewTextBoxColumn
    Friend WithEvents sizex As DataGridViewTextBoxColumn
    Friend WithEvents sizey As DataGridViewTextBoxColumn
    Friend WithEvents ltx As DataGridViewTextBoxColumn
    Friend WithEvents lty As DataGridViewTextBoxColumn
    Friend WithEvents rbx As DataGridViewTextBoxColumn
    Friend WithEvents rby As DataGridViewTextBoxColumn
End Class
