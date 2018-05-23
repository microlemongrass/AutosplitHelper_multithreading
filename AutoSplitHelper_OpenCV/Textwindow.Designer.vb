<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Textwindow
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
        Me.rtxt1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'rtxt1
        '
        Me.rtxt1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtxt1.Location = New System.Drawing.Point(0, 0)
        Me.rtxt1.Name = "rtxt1"
        Me.rtxt1.Size = New System.Drawing.Size(456, 495)
        Me.rtxt1.TabIndex = 0
        Me.rtxt1.Text = ""
        '
        'Textwindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 495)
        Me.Controls.Add(Me.rtxt1)
        Me.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Textwindow"
        Me.Text = "Chart"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rtxt1 As RichTextBox
End Class
