<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cropping_preview
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
        Me.picipl_crop = New OpenCvSharp.UserInterface.PictureBoxIpl()
        CType(Me.picipl_crop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picipl_crop
        '
        Me.picipl_crop.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.picipl_crop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.picipl_crop.Location = New System.Drawing.Point(0, 0)
        Me.picipl_crop.Name = "picipl_crop"
        Me.picipl_crop.Size = New System.Drawing.Size(800, 450)
        Me.picipl_crop.TabIndex = 270
        Me.picipl_crop.TabStop = False
        '
        'Cropping_preview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.picipl_crop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Cropping_preview"
        Me.Text = "Cropping_preview"
        CType(Me.picipl_crop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picipl_crop As OpenCvSharp.UserInterface.PictureBoxIpl
End Class
