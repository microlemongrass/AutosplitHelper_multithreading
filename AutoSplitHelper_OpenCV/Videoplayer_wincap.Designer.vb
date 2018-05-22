<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Videoplayer_wincap
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
        Me.picVideo = New System.Windows.Forms.PictureBox()
        CType(Me.picVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picVideo
        '
        Me.picVideo.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picVideo.Location = New System.Drawing.Point(0, 0)
        Me.picVideo.Name = "picVideo"
        Me.picVideo.Size = New System.Drawing.Size(320, 180)
        Me.picVideo.TabIndex = 1
        Me.picVideo.TabStop = False
        '
        'Videoplayer_wincap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(320, 180)
        Me.Controls.Add(Me.picVideo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Videoplayer_wincap"
        Me.Text = "Videoplayer_wincap"
        CType(Me.picVideo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picVideo As PictureBox
End Class
