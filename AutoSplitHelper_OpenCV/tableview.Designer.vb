<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class tableview
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txttable_picpass = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.listname = New System.Windows.Forms.ListBox()
        Me.txtnumbers = New System.Windows.Forms.TextBox()
        Me.dgpic = New System.Windows.Forms.DataGridView()
        Me.nameonly = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgpicture = New System.Windows.Forms.DataGridViewImageColumn()
        CType(Me.dgpic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txttable_picpass
        '
        Me.txttable_picpass.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txttable_picpass.Font = New System.Drawing.Font("Century Gothic", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttable_picpass.ForeColor = System.Drawing.Color.Snow
        Me.txttable_picpass.Location = New System.Drawing.Point(488, 190)
        Me.txttable_picpass.Name = "txttable_picpass"
        Me.txttable_picpass.ReadOnly = True
        Me.txttable_picpass.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txttable_picpass.Size = New System.Drawing.Size(315, 24)
        Me.txttable_picpass.TabIndex = 219
        Me.txttable_picpass.Text = "0"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(412, 190)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(72, 172)
        Me.ListBox1.TabIndex = 222
        '
        'listname
        '
        Me.listname.FormattingEnabled = True
        Me.listname.ItemHeight = 12
        Me.listname.Location = New System.Drawing.Point(412, 12)
        Me.listname.Name = "listname"
        Me.listname.Size = New System.Drawing.Size(72, 172)
        Me.listname.TabIndex = 223
        '
        'txtnumbers
        '
        Me.txtnumbers.Location = New System.Drawing.Point(490, 250)
        Me.txtnumbers.Name = "txtnumbers"
        Me.txtnumbers.Size = New System.Drawing.Size(55, 19)
        Me.txtnumbers.TabIndex = 224
        '
        'dgpic
        '
        Me.dgpic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgpic.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nameonly, Me.dgpicture})
        Me.dgpic.Location = New System.Drawing.Point(12, 12)
        Me.dgpic.Name = "dgpic"
        Me.dgpic.RowTemplate.Height = 21
        Me.dgpic.Size = New System.Drawing.Size(295, 475)
        Me.dgpic.TabIndex = 225
        '
        'nameonly
        '
        Me.nameonly.HeaderText = "No."
        Me.nameonly.Name = "nameonly"
        Me.nameonly.Width = 30
        '
        'dgpicture
        '
        Me.dgpicture.HeaderText = "イメージ"
        Me.dgpicture.Name = "dgpicture"
        Me.dgpicture.Width = 200
        '
        'tableview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 502)
        Me.Controls.Add(Me.dgpic)
        Me.Controls.Add(Me.txtnumbers)
        Me.Controls.Add(Me.listname)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.txttable_picpass)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tableview"
        Me.Text = "Template Picture"
        CType(Me.dgpic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txttable_picpass As TextBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents listname As ListBox
    Friend WithEvents txtnumbers As TextBox
    Friend WithEvents dgpic As DataGridView
    Friend WithEvents nameonly As DataGridViewTextBoxColumn
    Friend WithEvents dgpicture As DataGridViewImageColumn
End Class
