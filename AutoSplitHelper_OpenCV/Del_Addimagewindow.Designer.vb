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
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Copytable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpass_picturefolder
        '
        Me.txtpass_picturefolder.Location = New System.Drawing.Point(12, 367)
        Me.txtpass_picturefolder.Name = "txtpass_picturefolder"
        Me.txtpass_picturefolder.Size = New System.Drawing.Size(209, 23)
        Me.txtpass_picturefolder.TabIndex = 0
        '
        'txtpass_csv
        '
        Me.txtpass_csv.Location = New System.Drawing.Point(12, 396)
        Me.txtpass_csv.Name = "txtpass_csv"
        Me.txtpass_csv.Size = New System.Drawing.Size(209, 23)
        Me.txtpass_csv.TabIndex = 1
        '
        'txtpass_rtf
        '
        Me.txtpass_rtf.Location = New System.Drawing.Point(12, 425)
        Me.txtpass_rtf.Name = "txtpass_rtf"
        Me.txtpass_rtf.Size = New System.Drawing.Size(209, 23)
        Me.txtpass_rtf.TabIndex = 2
        '
        'listnumber
        '
        Me.listnumber.FormattingEnabled = True
        Me.listnumber.ItemHeight = 15
        Me.listnumber.Location = New System.Drawing.Point(12, 12)
        Me.listnumber.Name = "listnumber"
        Me.listnumber.Size = New System.Drawing.Size(68, 319)
        Me.listnumber.TabIndex = 3
        '
        'btnok
        '
        Me.btnok.Location = New System.Drawing.Point(335, 222)
        Me.btnok.Name = "btnok"
        Me.btnok.Size = New System.Drawing.Size(75, 23)
        Me.btnok.TabIndex = 4
        Me.btnok.Text = "OK"
        Me.btnok.UseVisualStyleBackColor = True
        '
        'btninsert
        '
        Me.btninsert.Location = New System.Drawing.Point(293, 12)
        Me.btninsert.Name = "btninsert"
        Me.btninsert.Size = New System.Drawing.Size(75, 23)
        Me.btninsert.TabIndex = 5
        Me.btninsert.Text = "Insert"
        Me.btninsert.UseVisualStyleBackColor = True
        '
        'btndelete
        '
        Me.btndelete.Location = New System.Drawing.Point(293, 51)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(75, 23)
        Me.btndelete.TabIndex = 6
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.PictureBox1.Location = New System.Drawing.Point(293, 125)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(117, 91)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'listcomment
        '
        Me.listcomment.FormattingEnabled = True
        Me.listcomment.ItemHeight = 15
        Me.listcomment.Location = New System.Drawing.Point(131, 12)
        Me.listcomment.Name = "listcomment"
        Me.listcomment.Size = New System.Drawing.Size(68, 319)
        Me.listcomment.TabIndex = 10
        '
        'Copytable
        '
        Me.Copytable.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.Copytable.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Copytable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Copytable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Copytable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.no, Me.send, Me.key, Me.rate, Me.sleep, Me.timing, Me.darksleep, Me.darkthr, Me.seektime, Me.graph_count, Me.graph_rate, Me.graph_view, Me.posx, Me.posy, Me.sizex, Me.sizey, Me.ltx, Me.lty, Me.rbx, Me.rby})
        Me.Copytable.Location = New System.Drawing.Point(435, 51)
        Me.Copytable.Name = "Copytable"
        Me.Copytable.RowTemplate.Height = 21
        Me.Copytable.Size = New System.Drawing.Size(785, 146)
        Me.Copytable.TabIndex = 46
        '
        'no
        '
        Me.no.HeaderText = "Comment"
        Me.no.Name = "no"
        Me.no.Width = 156
        '
        'send
        '
        Me.send.HeaderText = "Snd"
        Me.send.Name = "send"
        Me.send.Width = 38
        '
        'key
        '
        Me.key.HeaderText = "Key"
        Me.key.Name = "key"
        Me.key.Width = 38
        '
        'rate
        '
        Me.rate.HeaderText = "Thr."
        Me.rate.Name = "rate"
        Me.rate.Width = 50
        '
        'sleep
        '
        Me.sleep.HeaderText = "Sleep"
        Me.sleep.Name = "sleep"
        Me.sleep.Width = 62
        '
        'timing
        '
        Me.timing.HeaderText = "T"
        Me.timing.Name = "timing"
        Me.timing.Width = 24
        '
        'darksleep
        '
        Me.darksleep.HeaderText = "Delay"
        Me.darksleep.Name = "darksleep"
        Me.darksleep.Width = 70
        '
        'darkthr
        '
        Me.darkthr.HeaderText = "C.Al."
        Me.darkthr.Name = "darkthr"
        Me.darkthr.Width = 46
        '
        'seektime
        '
        Me.seektime.HeaderText = "Seek"
        Me.seektime.Name = "seektime"
        Me.seektime.Width = 70
        '
        'graph_count
        '
        Me.graph_count.HeaderText = "G.C."
        Me.graph_count.Name = "graph_count"
        Me.graph_count.Width = 46
        '
        'graph_rate
        '
        Me.graph_rate.HeaderText = "G.R."
        Me.graph_rate.Name = "graph_rate"
        Me.graph_rate.Width = 53
        '
        'graph_view
        '
        Me.graph_view.HeaderText = "G.V."
        Me.graph_view.Name = "graph_view"
        Me.graph_view.Width = 46
        '
        'posx
        '
        Me.posx.HeaderText = "PX(D)"
        Me.posx.Name = "posx"
        Me.posx.Width = 46
        '
        'posy
        '
        Me.posy.HeaderText = "PY(D)"
        Me.posy.Name = "posy"
        Me.posy.Width = 46
        '
        'sizex
        '
        Me.sizex.HeaderText = "SX(D)"
        Me.sizex.Name = "sizex"
        Me.sizex.Width = 44
        '
        'sizey
        '
        Me.sizey.HeaderText = "SY(D)"
        Me.sizey.Name = "sizey"
        Me.sizey.Width = 44
        '
        'ltx
        '
        Me.ltx.HeaderText = "LTX"
        Me.ltx.Name = "ltx"
        Me.ltx.Width = 46
        '
        'lty
        '
        Me.lty.HeaderText = "LTY"
        Me.lty.Name = "lty"
        Me.lty.Width = 46
        '
        'rbx
        '
        Me.rbx.HeaderText = "RBX"
        Me.rbx.Name = "rbx"
        Me.rbx.Width = 46
        '
        'rby
        '
        Me.rby.HeaderText = "RBY"
        Me.rby.Name = "rby"
        Me.rby.Width = 46
        '
        'Del_Addimagewindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 465)
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
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Del_Addimagewindow"
        Me.Text = "Del_Addimagewindow"
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
    Friend WithEvents no As DataGridViewTextBoxColumn
    Friend WithEvents send As DataGridViewTextBoxColumn
    Friend WithEvents key As DataGridViewTextBoxColumn
    Friend WithEvents rate As DataGridViewTextBoxColumn
    Friend WithEvents sleep As DataGridViewTextBoxColumn
    Friend WithEvents timing As DataGridViewTextBoxColumn
    Friend WithEvents darksleep As DataGridViewTextBoxColumn
    Friend WithEvents darkthr As DataGridViewTextBoxColumn
    Friend WithEvents seektime As DataGridViewTextBoxColumn
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
