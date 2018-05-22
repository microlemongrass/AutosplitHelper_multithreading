<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class getprocesswindow2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(getprocesswindow2))
        Me.btnadd = New System.Windows.Forms.Button()
        Me.txtprocess = New System.Windows.Forms.TextBox()
        Me.list2_hwnd = New System.Windows.Forms.ListBox()
        Me.btn2_getwindowtitle = New System.Windows.Forms.Button()
        Me.list2_alltitle = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnadd
        '
        Me.btnadd.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        resources.ApplyResources(Me.btnadd, "btnadd")
        Me.btnadd.Name = "btnadd"
        Me.btnadd.UseVisualStyleBackColor = False
        '
        'txtprocess
        '
        Me.txtprocess.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtprocess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtprocess, "txtprocess")
        Me.txtprocess.ForeColor = System.Drawing.SystemColors.Control
        Me.txtprocess.Name = "txtprocess"
        '
        'list2_hwnd
        '
        Me.list2_hwnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.list2_hwnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.list2_hwnd, "list2_hwnd")
        Me.list2_hwnd.ForeColor = System.Drawing.SystemColors.Control
        Me.list2_hwnd.FormattingEnabled = True
        Me.list2_hwnd.Name = "list2_hwnd"
        '
        'btn2_getwindowtitle
        '
        Me.btn2_getwindowtitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        resources.ApplyResources(Me.btn2_getwindowtitle, "btn2_getwindowtitle")
        Me.btn2_getwindowtitle.Name = "btn2_getwindowtitle"
        Me.btn2_getwindowtitle.UseVisualStyleBackColor = False
        '
        'list2_alltitle
        '
        Me.list2_alltitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.list2_alltitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.list2_alltitle, "list2_alltitle")
        Me.list2_alltitle.ForeColor = System.Drawing.SystemColors.Control
        Me.list2_alltitle.FormattingEnabled = True
        Me.list2_alltitle.Name = "list2_alltitle"
        '
        'getprocesswindow2
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.txtprocess)
        Me.Controls.Add(Me.list2_hwnd)
        Me.Controls.Add(Me.btn2_getwindowtitle)
        Me.Controls.Add(Me.list2_alltitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "getprocesswindow2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnadd As Button
    Friend WithEvents txtprocess As TextBox
    Friend WithEvents list2_hwnd As ListBox
    Friend WithEvents btn2_getwindowtitle As Button
    Friend WithEvents list2_alltitle As ListBox
End Class
