<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sortimage_input_info
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
        Me.btnzipok = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnzipok
        '
        Me.btnzipok.Font = New System.Drawing.Font("Meiryo UI", 9.0!)
        Me.btnzipok.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnzipok.Location = New System.Drawing.Point(251, 236)
        Me.btnzipok.Name = "btnzipok"
        Me.btnzipok.Size = New System.Drawing.Size(100, 26)
        Me.btnzipok.TabIndex = 43
        Me.btnzipok.Text = "ok"
        Me.btnzipok.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 9.0!)
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 15)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Please enter information such as resolution and notes."
        '
        'txtinfo
        '
        Me.txtinfo.Font = New System.Drawing.Font("Meiryo UI", 9.0!)
        Me.txtinfo.Location = New System.Drawing.Point(12, 40)
        Me.txtinfo.Multiline = True
        Me.txtinfo.Name = "txtinfo"
        Me.txtinfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtinfo.Size = New System.Drawing.Size(340, 180)
        Me.txtinfo.TabIndex = 41
        '
        'Sortimage_input_info
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnzipok)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtinfo)
        Me.Name = "Sortimage_input_info"
        Me.Text = "Sortimage_input_info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnzipok As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtinfo As TextBox
End Class
