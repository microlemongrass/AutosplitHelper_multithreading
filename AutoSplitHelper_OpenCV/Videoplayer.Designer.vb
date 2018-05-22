<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Videoplayer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Videoplayer))
        Me.Axwmp1 = New AxWMPLib.AxWindowsMediaPlayer()
        Me.lbltitlebar = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.閉じるToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Axwmp1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Axwmp1
        '
        Me.Axwmp1.Enabled = True
        Me.Axwmp1.Location = New System.Drawing.Point(0, 20)
        Me.Axwmp1.Name = "Axwmp1"
        Me.Axwmp1.OcxState = CType(resources.GetObject("Axwmp1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Axwmp1.Size = New System.Drawing.Size(320, 180)
        Me.Axwmp1.TabIndex = 0
        '
        'lbltitlebar
        '
        Me.lbltitlebar.AutoSize = True
        Me.lbltitlebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.lbltitlebar.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lbltitlebar.Font = New System.Drawing.Font("Meiryo UI", 9.0!)
        Me.lbltitlebar.ForeColor = System.Drawing.Color.Silver
        Me.lbltitlebar.Location = New System.Drawing.Point(0, 0)
        Me.lbltitlebar.Name = "lbltitlebar"
        Me.lbltitlebar.Padding = New System.Windows.Forms.Padding(0, 2, 1000, 3)
        Me.lbltitlebar.Size = New System.Drawing.Size(1072, 20)
        Me.lbltitlebar.TabIndex = 88
        Me.lbltitlebar.Text = "Game Title"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.閉じるToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(105, 26)
        '
        '閉じるToolStripMenuItem
        '
        Me.閉じるToolStripMenuItem.Name = "閉じるToolStripMenuItem"
        Me.閉じるToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.閉じるToolStripMenuItem.Text = "閉じる"
        '
        'Videoplayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(394, 261)
        Me.Controls.Add(Me.lbltitlebar)
        Me.Controls.Add(Me.Axwmp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Videoplayer"
        Me.Text = "Videoplayer"
        CType(Me.Axwmp1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Axwmp1 As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents lbltitlebar As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents 閉じるToolStripMenuItem As ToolStripMenuItem
End Class
