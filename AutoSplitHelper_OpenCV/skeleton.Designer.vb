<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class skeleton
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txt22 = New System.Windows.Forms.TextBox()
        Me.txt21 = New System.Windows.Forms.TextBox()
        Me.txt12 = New System.Windows.Forms.TextBox()
        Me.txt11 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'txt22
        '
        Me.txt22.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txt22.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt22.Location = New System.Drawing.Point(47, 42)
        Me.txt22.Name = "txt22"
        Me.txt22.ReadOnly = True
        Me.txt22.Size = New System.Drawing.Size(29, 24)
        Me.txt22.TabIndex = 225
        Me.txt22.Text = "0"
        Me.txt22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt22.Visible = False
        '
        'txt21
        '
        Me.txt21.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txt21.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt21.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt21.Location = New System.Drawing.Point(12, 42)
        Me.txt21.Name = "txt21"
        Me.txt21.ReadOnly = True
        Me.txt21.Size = New System.Drawing.Size(29, 24)
        Me.txt21.TabIndex = 224
        Me.txt21.Text = "0"
        Me.txt21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt21.Visible = False
        '
        'txt12
        '
        Me.txt12.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txt12.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt12.Location = New System.Drawing.Point(47, 12)
        Me.txt12.Name = "txt12"
        Me.txt12.ReadOnly = True
        Me.txt12.Size = New System.Drawing.Size(29, 24)
        Me.txt12.TabIndex = 223
        Me.txt12.Text = "0"
        Me.txt12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt12.Visible = False
        '
        'txt11
        '
        Me.txt11.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.txt11.Font = New System.Drawing.Font("Meiryo UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txt11.Location = New System.Drawing.Point(12, 12)
        Me.txt11.Name = "txt11"
        Me.txt11.ReadOnly = True
        Me.txt11.Size = New System.Drawing.Size(29, 24)
        Me.txt11.TabIndex = 222
        Me.txt11.Text = "0"
        Me.txt11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txt11.Visible = False
        '
        'skeleton
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.txt22)
        Me.Controls.Add(Me.txt21)
        Me.Controls.Add(Me.txt12)
        Me.Controls.Add(Me.txt11)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimumSize = New System.Drawing.Size(1, 1)
        Me.Name = "skeleton"
        Me.Opacity = 0.6R
        Me.Text = "skeleton"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents txt22 As TextBox
    Friend WithEvents txt21 As TextBox
    Friend WithEvents txt12 As TextBox
    Friend WithEvents txt11 As TextBox
End Class
