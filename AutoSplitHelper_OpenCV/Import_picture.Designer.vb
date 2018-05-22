<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Import_picture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Import_picture))
        Me.lbltitlebar = New System.Windows.Forms.Label()
        Me.btnimport_picture = New System.Windows.Forms.Button()
        Me.btnimport_csv = New System.Windows.Forms.Button()
        Me.txtpass_csv = New System.Windows.Forms.TextBox()
        Me.txtpass_picturefolder = New System.Windows.Forms.TextBox()
        Me.txtname = New System.Windows.Forms.TextBox()
        Me.btnclosewindow = New System.Windows.Forms.Button()
        Me.btnimport_ok = New System.Windows.Forms.Button()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtinfo = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lbltitlebar
        '
        resources.ApplyResources(Me.lbltitlebar, "lbltitlebar")
        Me.lbltitlebar.BackColor = System.Drawing.Color.SteelBlue
        Me.lbltitlebar.ForeColor = System.Drawing.SystemColors.Control
        Me.lbltitlebar.Name = "lbltitlebar"
        '
        'btnimport_picture
        '
        resources.ApplyResources(Me.btnimport_picture, "btnimport_picture")
        Me.btnimport_picture.BackColor = System.Drawing.SystemColors.Control
        Me.btnimport_picture.Name = "btnimport_picture"
        Me.btnimport_picture.UseVisualStyleBackColor = False
        '
        'btnimport_csv
        '
        resources.ApplyResources(Me.btnimport_csv, "btnimport_csv")
        Me.btnimport_csv.BackColor = System.Drawing.SystemColors.Control
        Me.btnimport_csv.Name = "btnimport_csv"
        Me.btnimport_csv.UseVisualStyleBackColor = False
        '
        'txtpass_csv
        '
        resources.ApplyResources(Me.txtpass_csv, "txtpass_csv")
        Me.txtpass_csv.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtpass_csv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpass_csv.ForeColor = System.Drawing.SystemColors.Control
        Me.txtpass_csv.Name = "txtpass_csv"
        Me.txtpass_csv.ReadOnly = True
        '
        'txtpass_picturefolder
        '
        resources.ApplyResources(Me.txtpass_picturefolder, "txtpass_picturefolder")
        Me.txtpass_picturefolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtpass_picturefolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpass_picturefolder.ForeColor = System.Drawing.SystemColors.Control
        Me.txtpass_picturefolder.Name = "txtpass_picturefolder"
        Me.txtpass_picturefolder.ReadOnly = True
        '
        'txtname
        '
        resources.ApplyResources(Me.txtname, "txtname")
        Me.txtname.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtname.ForeColor = System.Drawing.SystemColors.Control
        Me.txtname.Name = "txtname"
        '
        'btnclosewindow
        '
        resources.ApplyResources(Me.btnclosewindow, "btnclosewindow")
        Me.btnclosewindow.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.btnclosewindow.ForeColor = System.Drawing.Color.Thistle
        Me.btnclosewindow.Name = "btnclosewindow"
        Me.btnclosewindow.UseVisualStyleBackColor = False
        '
        'btnimport_ok
        '
        resources.ApplyResources(Me.btnimport_ok, "btnimport_ok")
        Me.btnimport_ok.BackColor = System.Drawing.SystemColors.Control
        Me.btnimport_ok.Name = "btnimport_ok"
        Me.btnimport_ok.UseVisualStyleBackColor = False
        '
        'Label67
        '
        resources.ApplyResources(Me.Label67, "Label67")
        Me.Label67.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.Label67.ForeColor = System.Drawing.SystemColors.Control
        Me.Label67.Name = "Label67"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Name = "Label1"
        '
        'txtinfo
        '
        resources.ApplyResources(Me.txtinfo, "txtinfo")
        Me.txtinfo.Name = "txtinfo"
        Me.txtinfo.ReadOnly = True
        '
        'Import_picture
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.ControlBox = False
        Me.Controls.Add(Me.txtinfo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.btnimport_ok)
        Me.Controls.Add(Me.btnclosewindow)
        Me.Controls.Add(Me.txtname)
        Me.Controls.Add(Me.txtpass_csv)
        Me.Controls.Add(Me.txtpass_picturefolder)
        Me.Controls.Add(Me.btnimport_csv)
        Me.Controls.Add(Me.btnimport_picture)
        Me.Controls.Add(Me.lbltitlebar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Import_picture"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltitlebar As Label
    Friend WithEvents btnimport_picture As Button
    Friend WithEvents btnimport_csv As Button
    Friend WithEvents txtpass_csv As TextBox
    Friend WithEvents txtpass_picturefolder As TextBox
    Friend WithEvents txtname As TextBox
    Friend WithEvents btnclosewindow As Button
    Friend WithEvents btnimport_ok As Button
    Friend WithEvents Label67 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtinfo As TextBox
End Class
