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
        Me.txtpass_picturefolder = New System.Windows.Forms.TextBox()
        Me.txtpass_csv = New System.Windows.Forms.TextBox()
        Me.txtpass_rtf = New System.Windows.Forms.TextBox()
        Me.listnumber = New System.Windows.Forms.ListBox()
        Me.btnok = New System.Windows.Forms.Button()
        Me.btninsert = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtselectednumber = New System.Windows.Forms.TextBox()
        Me.listcomment = New System.Windows.Forms.ListBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 337)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(59, 19)
        Me.CheckBox1.TabIndex = 8
        Me.CheckBox1.Text = "Reset"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'txtselectednumber
        '
        Me.txtselectednumber.Location = New System.Drawing.Point(293, 96)
        Me.txtselectednumber.Name = "txtselectednumber"
        Me.txtselectednumber.Size = New System.Drawing.Size(117, 23)
        Me.txtselectednumber.TabIndex = 9
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
        'Del_Addimagewindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 465)
        Me.Controls.Add(Me.listcomment)
        Me.Controls.Add(Me.txtselectednumber)
        Me.Controls.Add(Me.CheckBox1)
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
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents txtselectednumber As TextBox
    Friend WithEvents listcomment As ListBox
End Class
