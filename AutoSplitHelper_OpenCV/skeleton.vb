Public Class skeleton


    Private Sub skeleton_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = New Point(0, 0)
        Me.Location = New Point(CInt(System.Windows.Forms.Cursor.Position.X.ToString()), CInt(System.Windows.Forms.Cursor.Position.Y.ToString()))

        txt11.Text = CInt(System.Windows.Forms.Cursor.Position.X.ToString()) - CType(Me.Owner, Mainwindow).Location.X
        txt12.Text = CInt(System.Windows.Forms.Cursor.Position.Y.ToString()) - CType(Me.Owner, Mainwindow).Location.Y - CType(Me.Owner, Mainwindow).lbltitlebar.Height


    End Sub


    Private Sub skeleton_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated

        Dim pltx As Integer = CInt(Cursor.Position.X.ToString())
        Dim plty As Integer = CInt(Cursor.Position.Y.ToString())
        Dim prbx As Integer = Mainwindow.numcv_sizex.Text - txt11.Text
        Dim prby As Integer = Mainwindow.numcv_sizey.Text - txt12.Text

        Dim limitRect As Rectangle = New Rectangle(pltx, plty, prbx, prby)
        Cursor.Clip = limitRect


    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        txt21.Text = CInt(Cursor.Position.X.ToString()) - CType(Me.Owner, Mainwindow).Location.X
        txt22.Text = CInt(Cursor.Position.Y.ToString()) - CType(Me.Owner, Mainwindow).Location.Y - CType(Me.Owner, Mainwindow).lbltitlebar.Height


        Me.Size = New Point(CInt(txt21.Text - txt11.Text), CInt(txt22.Text - txt12.Text))
        Me.MaximumSize = New Size(Mainwindow.numcv_sizex.Text - txt11.Text, Mainwindow.numcv_sizey.Text - txt12.Text)

        'If cv_capturewindow2.txtclickcount.Text = 10 Then
        '    Me.Close()
        'End If

    End Sub



End Class