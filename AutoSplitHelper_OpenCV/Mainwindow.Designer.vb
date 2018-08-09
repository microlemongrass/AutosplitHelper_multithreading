<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mainwindow
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mainwindow))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtrowscount = New System.Windows.Forms.TextBox()
        Me.DGtable = New System.Windows.Forms.DataGridView()
        Me.no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.send = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.key = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sleep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.timing = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.darksleep = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.darkthr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seektime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.graph_count = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.graph_rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.graph_view = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.posx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.posy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sizex = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sizey = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ltx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rbx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlview_window = New System.Windows.Forms.Panel()
        Me.piccap = New System.Windows.Forms.PictureBox()
        Me.pictempipl = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.PictureBoxIpl1 = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.piczoom = New System.Windows.Forms.PictureBox()
        Me.picview_capture = New System.Windows.Forms.PictureBox()
        Me.pnlview_control = New System.Windows.Forms.Panel()
        Me.btntemp = New System.Windows.Forms.Button()
        Me.btncap = New System.Windows.Forms.Button()
        Me.btnforward = New System.Windows.Forms.Button()
        Me.btnback = New System.Windows.Forms.Button()
        Me.numloadno = New System.Windows.Forms.NumericUpDown()
        Me.txtno_comment = New System.Windows.Forms.TextBox()
        Me.chkloading = New System.Windows.Forms.CheckBox()
        Me.chklimit = New System.Windows.Forms.CheckBox()
        Me.chkoverwrite = New System.Windows.Forms.CheckBox()
        Me.trktemp = New System.Windows.Forms.TrackBar()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.grpgeneral = New System.Windows.Forms.GroupBox()
        Me.lblcur_load10 = New System.Windows.Forms.Label()
        Me.lblcur_load9 = New System.Windows.Forms.Label()
        Me.lblcur_load8 = New System.Windows.Forms.Label()
        Me.lblcur_load7 = New System.Windows.Forms.Label()
        Me.lblcur_load6 = New System.Windows.Forms.Label()
        Me.lblcur_load5 = New System.Windows.Forms.Label()
        Me.lblcur_load4 = New System.Windows.Forms.Label()
        Me.lblcur_load3 = New System.Windows.Forms.Label()
        Me.lblcur_load2 = New System.Windows.Forms.Label()
        Me.btncur_showtext = New System.Windows.Forms.Button()
        Me.lblcur_showtextwindow = New System.Windows.Forms.Label()
        Me.lblcur_showvideo = New System.Windows.Forms.Label()
        Me.lblset_text = New System.Windows.Forms.Label()
        Me.btncur_showvideo = New System.Windows.Forms.Button()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.lblset_video = New System.Windows.Forms.Label()
        Me.lblcur_firstsplit = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.lblcur_addcount = New System.Windows.Forms.Label()
        Me.lblcur_namedpipe = New System.Windows.Forms.Label()
        Me.lblcur_rendou = New System.Windows.Forms.Label()
        Me.lblcur_focus_after = New System.Windows.Forms.Label()
        Me.lblcur_focus_before = New System.Windows.Forms.Label()
        Me.lblcur_load1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblcur_interval = New System.Windows.Forms.Label()
        Me.lblcur_loopcount = New System.Windows.Forms.Label()
        Me.lblcur_split = New System.Windows.Forms.Label()
        Me.lblcur_load = New System.Windows.Forms.Label()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.lblcur_reset = New System.Windows.Forms.Label()
        Me.lblcur_loop = New System.Windows.Forms.Label()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.lblset_focus = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.lblset_hotkey = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.btncur_clear_live = New System.Windows.Forms.Button()
        Me.btncur_clear_table = New System.Windows.Forms.Button()
        Me.btncur_clear_count = New System.Windows.Forms.Button()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.lblset_graph = New System.Windows.Forms.Label()
        Me.btncur_webcamera = New System.Windows.Forms.Button()
        Me.lblset_road = New System.Windows.Forms.Label()
        Me.lblcur_device_res_fps = New System.Windows.Forms.Label()
        Me.lblset_device = New System.Windows.Forms.Label()
        Me.lblcur_device_name = New System.Windows.Forms.Label()
        Me.lblset_monitoring = New System.Windows.Forms.Label()
        Me.pnl_other = New System.Windows.Forms.Panel()
        Me.btntext_openfolder = New System.Windows.Forms.Button()
        Me.btntext_createtext = New System.Windows.Forms.Button()
        Me.txtpass_rtf = New System.Windows.Forms.TextBox()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.btnshow_chart = New System.Windows.Forms.Button()
        Me.chkshow_text = New System.Windows.Forms.CheckBox()
        Me.chkcreate_temppicture = New System.Windows.Forms.CheckBox()
        Me.txtpass_picturefolder = New System.Windows.Forms.TextBox()
        Me.txtpass_csv = New System.Windows.Forms.TextBox()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lbllivesplit_state = New System.Windows.Forms.Label()
        Me.pnl_video = New System.Windows.Forms.Panel()
        Me.chkvideo_manualstart = New System.Windows.Forms.CheckBox()
        Me.btnselectvideo = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkvideo_showwinvideo = New System.Windows.Forms.CheckBox()
        Me.numwin_interval = New System.Windows.Forms.NumericUpDown()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.numwin_locy = New System.Windows.Forms.NumericUpDown()
        Me.numwin_locx = New System.Windows.Forms.NumericUpDown()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.numvideo_sizey = New System.Windows.Forms.NumericUpDown()
        Me.numvideo_sizex = New System.Windows.Forms.NumericUpDown()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.txtvideo_startat = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.txtvideo_pass = New System.Windows.Forms.TextBox()
        Me.chkvideo_autoseek = New System.Windows.Forms.CheckBox()
        Me.chkshowvideo = New System.Windows.Forms.CheckBox()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.btnclosetable = New System.Windows.Forms.Button()
        Me.pnl_loadremover = New System.Windows.Forms.Panel()
        Me.chkload7 = New System.Windows.Forms.CheckBox()
        Me.chkload1 = New System.Windows.Forms.CheckBox()
        Me.chkload8 = New System.Windows.Forms.CheckBox()
        Me.chkload10 = New System.Windows.Forms.CheckBox()
        Me.chkload3 = New System.Windows.Forms.CheckBox()
        Me.chkload6 = New System.Windows.Forms.CheckBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.numload_rate1 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay1 = New System.Windows.Forms.NumericUpDown()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.numload_rate2 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay2 = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.numload_rate3 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay3 = New System.Windows.Forms.NumericUpDown()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.numload_rate4 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay4 = New System.Windows.Forms.NumericUpDown()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.numload_rate5 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay5 = New System.Windows.Forms.NumericUpDown()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TabPage10 = New System.Windows.Forms.TabPage()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.numload_rate6 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay6 = New System.Windows.Forms.NumericUpDown()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TabPage11 = New System.Windows.Forms.TabPage()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.numload_rate7 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay7 = New System.Windows.Forms.NumericUpDown()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.TabPage12 = New System.Windows.Forms.TabPage()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.numload_rate8 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay8 = New System.Windows.Forms.NumericUpDown()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.TabPage13 = New System.Windows.Forms.TabPage()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.numload_rate9 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay9 = New System.Windows.Forms.NumericUpDown()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.TabPage14 = New System.Windows.Forms.TabPage()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.numload_rate10 = New System.Windows.Forms.NumericUpDown()
        Me.numload_delay10 = New System.Windows.Forms.NumericUpDown()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.chkload5 = New System.Windows.Forms.CheckBox()
        Me.chkload4 = New System.Windows.Forms.CheckBox()
        Me.chkload2 = New System.Windows.Forms.CheckBox()
        Me.chkload9 = New System.Windows.Forms.CheckBox()
        Me.pnl_hotkey = New System.Windows.Forms.Panel()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.txtreset_ash_key = New System.Windows.Forms.TextBox()
        Me.txtundo_ash_key = New System.Windows.Forms.TextBox()
        Me.txtskip_ash_key = New System.Windows.Forms.TextBox()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.numpresstime = New System.Windows.Forms.NumericUpDown()
        Me.txtresume_key = New System.Windows.Forms.TextBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkalt_resume = New System.Windows.Forms.CheckBox()
        Me.chkctrl_resume = New System.Windows.Forms.CheckBox()
        Me.txtsplit_key = New System.Windows.Forms.TextBox()
        Me.chkctrl_reset = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkshift_resume = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkalt_reset = New System.Windows.Forms.CheckBox()
        Me.chkundoskip = New System.Windows.Forms.CheckBox()
        Me.txtpause_key = New System.Windows.Forms.TextBox()
        Me.txtreset_key = New System.Windows.Forms.TextBox()
        Me.chkalt = New System.Windows.Forms.CheckBox()
        Me.chkshift_undo = New System.Windows.Forms.CheckBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkctrl = New System.Windows.Forms.CheckBox()
        Me.chkctrl_undo = New System.Windows.Forms.CheckBox()
        Me.chkalt_pause = New System.Windows.Forms.CheckBox()
        Me.txtundo_key = New System.Windows.Forms.TextBox()
        Me.chkshift = New System.Windows.Forms.CheckBox()
        Me.chkalt_undo = New System.Windows.Forms.CheckBox()
        Me.chkctrl_pause = New System.Windows.Forms.CheckBox()
        Me.txtskip_key = New System.Windows.Forms.TextBox()
        Me.chkshift_pause = New System.Windows.Forms.CheckBox()
        Me.chkalt_skip = New System.Windows.Forms.CheckBox()
        Me.chkctrl_skip = New System.Windows.Forms.CheckBox()
        Me.chknamedpipe = New System.Windows.Forms.CheckBox()
        Me.chkshift_reset = New System.Windows.Forms.CheckBox()
        Me.chkshift_skip = New System.Windows.Forms.CheckBox()
        Me.listsetcontents = New System.Windows.Forms.ListBox()
        Me.pnl_cvparameter = New System.Windows.Forms.Panel()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me._moji6 = New System.Windows.Forms.Label()
        Me.numcv_framerate = New System.Windows.Forms.NumericUpDown()
        Me.btnconnect_camera = New System.Windows.Forms.Button()
        Me.cmbcv_resolution = New System.Windows.Forms.ComboBox()
        Me.numcv_device = New System.Windows.Forms.NumericUpDown()
        Me.btnresetup = New System.Windows.Forms.Button()
        Me._moji5 = New System.Windows.Forms.Label()
        Me.cmbcv_device = New System.Windows.Forms.ComboBox()
        Me.pnl_focus = New System.Windows.Forms.Panel()
        Me.lblpid_1st = New System.Windows.Forms.Label()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.chkactiveapp = New System.Windows.Forms.CheckBox()
        Me.cmbtimer = New System.Windows.Forms.ComboBox()
        Me.btnaddapp2 = New System.Windows.Forms.Button()
        Me.numsendsleep = New System.Windows.Forms.NumericUpDown()
        Me.btngetsomeactive = New System.Windows.Forms.Button()
        Me.chkactivesomeapp = New System.Windows.Forms.CheckBox()
        Me.btndeleteitem_someapp = New System.Windows.Forms.Button()
        Me.btngettimer = New System.Windows.Forms.Button()
        Me.btndelete_timer = New System.Windows.Forms.Button()
        Me.cmbsomeapp = New System.Windows.Forms.ComboBox()
        Me.btnaddapp1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnl_graph = New System.Windows.Forms.Panel()
        Me.chkrename_livesplit = New System.Windows.Forms.CheckBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.btnreset_livesplit = New System.Windows.Forms.Button()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.numgraph_first = New System.Windows.Forms.NumericUpDown()
        Me.btnreset_table = New System.Windows.Forms.Button()
        Me.btnreset_count = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkmonitor_sizestate = New System.Windows.Forms.CheckBox()
        Me.numtextwindow_sizex = New System.Windows.Forms.NumericUpDown()
        Me.lblcheckopening = New System.Windows.Forms.Label()
        Me.numtextwindow_sizey = New System.Windows.Forms.NumericUpDown()
        Me.numprofile = New System.Windows.Forms.NumericUpDown()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.txtclickcount = New System.Windows.Forms.TextBox()
        Me.txtprofile = New System.Windows.Forms.TextBox()
        Me.txtloadprofile = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.numskip_ash = New System.Windows.Forms.NumericUpDown()
        Me.numundo_ash = New System.Windows.Forms.NumericUpDown()
        Me.numreset_ash = New System.Windows.Forms.NumericUpDown()
        Me.lblkeysforresume = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.numcv_sizex = New System.Windows.Forms.NumericUpDown()
        Me.lblkeysforpause = New System.Windows.Forms.Label()
        Me.numcv_sizey = New System.Windows.Forms.NumericUpDown()
        Me.numsavex = New System.Windows.Forms.NumericUpDown()
        Me.numsavey = New System.Windows.Forms.NumericUpDown()
        Me.lblkeysforsend = New System.Windows.Forms.Label()
        Me.lblkeysforsend_reset = New System.Windows.Forms.Label()
        Me.lblkeysforskip = New System.Windows.Forms.Label()
        Me.lblkeysforundo = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtsavetempnumber = New System.Windows.Forms.TextBox()
        Me.numtemp = New System.Windows.Forms.NumericUpDown()
        Me.txt11 = New System.Windows.Forms.TextBox()
        Me.txt22 = New System.Windows.Forms.TextBox()
        Me.txt12 = New System.Windows.Forms.TextBox()
        Me.txt21 = New System.Windows.Forms.TextBox()
        Me.txttemp_picturepass = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.pnl_parameter = New System.Windows.Forms.Panel()
        Me._moji1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me._moji3 = New System.Windows.Forms.Label()
        Me.btninsertanten = New System.Windows.Forms.Button()
        Me.numanten = New System.Windows.Forms.NumericUpDown()
        Me.chkcv_loop = New System.Windows.Forms.CheckBox()
        Me.btninsertitti = New System.Windows.Forms.Button()
        Me.chkcv_resetonoff = New System.Windows.Forms.CheckBox()
        Me.btninsertsleep = New System.Windows.Forms.Button()
        Me.numstop = New System.Windows.Forms.NumericUpDown()
        Me.numloopcount = New System.Windows.Forms.NumericUpDown()
        Me.numcv_interval = New System.Windows.Forms.NumericUpDown()
        Me._moji2 = New System.Windows.Forms.Label()
        Me.chkcv_loadremover = New System.Windows.Forms.CheckBox()
        Me.numpercent = New System.Windows.Forms.NumericUpDown()
        Me.chkcv_monitor = New System.Windows.Forms.CheckBox()
        Me.btnstartopencv = New System.Windows.Forms.Button()
        Me.btndeleteprofile = New System.Windows.Forms.Button()
        Me.btnaddprofile = New System.Windows.Forms.Button()
        Me.cmbprofile = New System.Windows.Forms.ComboBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveProfileSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteSelectedProfileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.UploadTheCurrentProfileUToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartMonitoringMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.PreviewGetTemplatePictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalibrationToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PositionSettingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExpandTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ViewTableToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenTextWindowWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateTextFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenTextFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteAddTemplateImageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicenseLToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picunder = New System.Windows.Forms.PictureBox()
        Me.btnclose_general = New System.Windows.Forms.Button()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.lbllooptrigger = New System.Windows.Forms.Label()
        Me.numnowloop = New System.Windows.Forms.NumericUpDown()
        Me.lblloopcount = New System.Windows.Forms.Label()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.lblresetcount = New System.Windows.Forms.Label()
        Me.lblattemptcount = New System.Windows.Forms.Label()
        Me.lbllapcount = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.lblreload_graph = New System.Windows.Forms.Label()
        Me.txtsetsplitname = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.cmbloadno = New System.Windows.Forms.ComboBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtcv_ikiti_load10 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load9 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load8 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load7 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load6 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load5 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load4 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load3 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load2 = New System.Windows.Forms.TextBox()
        Me.txtcv_ikiti_load1 = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_load1 = New System.Windows.Forms.Label()
        Me.txtdelay_load10 = New System.Windows.Forms.TextBox()
        Me.lblcv_maxval_load2 = New System.Windows.Forms.Label()
        Me.txtdelay_load9 = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_load2 = New System.Windows.Forms.Label()
        Me.txtdelay_load8 = New System.Windows.Forms.TextBox()
        Me.lblcv_maxval_load3 = New System.Windows.Forms.Label()
        Me.txtdelay_load7 = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_load3 = New System.Windows.Forms.Label()
        Me.txtdelay_load6 = New System.Windows.Forms.TextBox()
        Me.lblcv_maxval_load4 = New System.Windows.Forms.Label()
        Me.txtdelay_load5 = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_load4 = New System.Windows.Forms.Label()
        Me.txtdelay_load4 = New System.Windows.Forms.TextBox()
        Me.lblcv_maxval_load5 = New System.Windows.Forms.Label()
        Me.txtdelay_load3 = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_load5 = New System.Windows.Forms.Label()
        Me.txtdelay_load2 = New System.Windows.Forms.TextBox()
        Me.lblcv_maxval_load6 = New System.Windows.Forms.Label()
        Me.txtdelay_load1 = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_load6 = New System.Windows.Forms.Label()
        Me.lblcv_maxval_load7 = New System.Windows.Forms.Label()
        Me.lblcv_maxval_load1 = New System.Windows.Forms.Label()
        Me.lblcv_nowmaxval_load7 = New System.Windows.Forms.Label()
        Me.lblcv_nowmaxval_load10 = New System.Windows.Forms.Label()
        Me.lblcv_maxval_load8 = New System.Windows.Forms.Label()
        Me.lblcv_maxval_load10 = New System.Windows.Forms.Label()
        Me.lblcv_nowmaxval_load8 = New System.Windows.Forms.Label()
        Me.lblcv_nowmaxval_load9 = New System.Windows.Forms.Label()
        Me.lblcv_maxval_load9 = New System.Windows.Forms.Label()
        Me.chknow_load10 = New System.Windows.Forms.CheckBox()
        Me.chknow_load9 = New System.Windows.Forms.CheckBox()
        Me.chknow_load8 = New System.Windows.Forms.CheckBox()
        Me.chknow_load7 = New System.Windows.Forms.CheckBox()
        Me.chknow_load6 = New System.Windows.Forms.CheckBox()
        Me.chknow_load5 = New System.Windows.Forms.CheckBox()
        Me.chknow_load4 = New System.Windows.Forms.CheckBox()
        Me.chknow_load3 = New System.Windows.Forms.CheckBox()
        Me.chknow_load2 = New System.Windows.Forms.CheckBox()
        Me.chknow_load1 = New System.Windows.Forms.CheckBox()
        Me.txtdelay_load = New System.Windows.Forms.TextBox()
        Me.chknow_monitor = New System.Windows.Forms.CheckBox()
        Me.chknow_load = New System.Windows.Forms.CheckBox()
        Me.chknow_reset = New System.Windows.Forms.CheckBox()
        Me.txtrecord_load = New System.Windows.Forms.TextBox()
        Me.lblrecord_pause_total = New System.Windows.Forms.Label()
        Me.lblrecord_pause = New System.Windows.Forms.Label()
        Me.txtrecord_load_total = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtcv_ikiti_load = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_load = New System.Windows.Forms.Label()
        Me.lblcv_maxval_load = New System.Windows.Forms.Label()
        Me.lblsleeptime = New System.Windows.Forms.Label()
        Me.lblloading = New System.Windows.Forms.Label()
        Me.txtcv_result_sizey = New System.Windows.Forms.TextBox()
        Me.txtcv_result_sizex = New System.Windows.Forms.TextBox()
        Me.txtcv_result_posy = New System.Windows.Forms.TextBox()
        Me.txtcv_result_posx = New System.Windows.Forms.TextBox()
        Me.txtcompikiti = New System.Windows.Forms.TextBox()
        Me.txtstate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcv_result = New System.Windows.Forms.TextBox()
        Me.btncv_downsize = New System.Windows.Forms.Button()
        Me.btncv_first = New System.Windows.Forms.Button()
        Me.lblcv_lap = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtcv_ikiti = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval = New System.Windows.Forms.Label()
        Me.lblcv_maxval = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.txtcv_ikiti_reset = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtcv_posy = New System.Windows.Forms.TextBox()
        Me.txtcv_posx = New System.Windows.Forms.TextBox()
        Me.txtcv_antenyn = New System.Windows.Forms.TextBox()
        Me.lblcv_nowmaxval_reset = New System.Windows.Forms.Label()
        Me.lblcv_maxval_reset = New System.Windows.Forms.Label()
        Me.btncv_stop = New System.Windows.Forms.Button()
        Me.lblcv_sendview = New System.Windows.Forms.Label()
        Me.lblcv_comment = New System.Windows.Forms.Label()
        Me.lblcv_sleepcount = New System.Windows.Forms.Label()
        Me.txtcv_antentime = New System.Windows.Forms.TextBox()
        Me.btncv_forward = New System.Windows.Forms.Button()
        Me.btncv_back = New System.Windows.Forms.Button()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.piccv_load = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.picipl_foranten = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.piccv_reset = New System.Windows.Forms.PictureBox()
        Me.piccv_picture = New System.Windows.Forms.PictureBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.picipl_cap = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.btntosetting01 = New System.Windows.Forms.Button()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.txtrenameapp = New System.Windows.Forms.TextBox()
        Me.chkmulti = New System.Windows.Forms.CheckBox()
        Me.txtpid_2nd = New System.Windows.Forms.TextBox()
        Me.btnrenameapp = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.lblm13 = New System.Windows.Forms.Label()
        Me.rich2_hwnddetail = New System.Windows.Forms.RichTextBox()
        Me.txt2_windowtitle2 = New System.Windows.Forms.TextBox()
        Me.btn2_gethwnd2 = New System.Windows.Forms.Button()
        Me.list2_hwnd2 = New System.Windows.Forms.ListBox()
        Me.lbl2_parent_kid = New System.Windows.Forms.Label()
        Me.txtprocess = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btninsertzahyou = New System.Windows.Forms.Button()
        Me.chklockwindow = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txt2_rby = New System.Windows.Forms.TextBox()
        Me.txt2_rbx = New System.Windows.Forms.TextBox()
        Me.txt2_lty = New System.Windows.Forms.TextBox()
        Me.txt2_ltx = New System.Windows.Forms.TextBox()
        Me.dgv2_template = New System.Windows.Forms.DataGridView()
        Me.applysize = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Comment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.windowltx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.windowlty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.windowrbx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.windowsrby = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txt2_selectedhwnd = New System.Windows.Forms.TextBox()
        Me.txt2_Selectedwindowtitle = New System.Windows.Forms.TextBox()
        Me.num2_rbx = New System.Windows.Forms.NumericUpDown()
        Me.num2_rby = New System.Windows.Forms.NumericUpDown()
        Me.num2_lty = New System.Windows.Forms.NumericUpDown()
        Me.num2_ltx = New System.Windows.Forms.NumericUpDown()
        Me.list2_alltitle = New System.Windows.Forms.ListBox()
        Me.list2_hwnd = New System.Windows.Forms.ListBox()
        Me.btn2_gethwnd = New System.Windows.Forms.Button()
        Me.btn2_getwindowtitle = New System.Windows.Forms.Button()
        Me.TabPage15 = New System.Windows.Forms.TabPage()
        Me.gbsetting = New System.Windows.Forms.GroupBox()
        Me.rdocalib_aspect_to43 = New System.Windows.Forms.RadioButton()
        Me.rdocalib_aspect_to169 = New System.Windows.Forms.RadioButton()
        Me.rdocalib_aspect_none = New System.Windows.Forms.RadioButton()
        Me.pgbcalib_1 = New System.Windows.Forms.ProgressBar()
        Me.btncalib_reset = New System.Windows.Forms.Button()
        Me.numcalib_hand_scaleheight = New System.Windows.Forms.NumericUpDown()
        Me.gbrgb = New System.Windows.Forms.GroupBox()
        Me.lblm1 = New System.Windows.Forms.Label()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.numcalib_hand_bright = New System.Windows.Forms.NumericUpDown()
        Me.btncalib_adjrgb = New System.Windows.Forms.Button()
        Me.btncalib_adjbright = New System.Windows.Forms.Button()
        Me.numcalib_hand_g = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_hand_r = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_hand_b = New System.Windows.Forms.NumericUpDown()
        Me.txtcalib_save_bright = New System.Windows.Forms.TextBox()
        Me.txtcalib_save_r = New System.Windows.Forms.TextBox()
        Me.txtcalib_save_g = New System.Windows.Forms.TextBox()
        Me.txtcalib_save_b = New System.Windows.Forms.TextBox()
        Me.btncalib_insert = New System.Windows.Forms.Button()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.numcalib_hand_scalewidth = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_hand_scale = New System.Windows.Forms.NumericUpDown()
        Me.txtcalib_save_scaleheight = New System.Windows.Forms.TextBox()
        Me.txtcalib_save_scalewidth = New System.Windows.Forms.TextBox()
        Me.txtcalib_save_scale = New System.Windows.Forms.TextBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.btncalib_adjaspect = New System.Windows.Forms.Button()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.btncalib_adjscale = New System.Windows.Forms.Button()
        Me.btncalib_resize = New System.Windows.Forms.Button()
        Me.btncalib_cap = New System.Windows.Forms.Button()
        Me.btntosetting03 = New System.Windows.Forms.Button()
        Me.numcalib_bright = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_r = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_scaleheight = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_g = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_b = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_scalewidth = New System.Windows.Forms.NumericUpDown()
        Me.numcalib_scale = New System.Windows.Forms.NumericUpDown()
        Me.txtcalib_count = New System.Windows.Forms.TextBox()
        Me.grpcalib_1 = New System.Windows.Forms.GroupBox()
        Me.listcalib_2 = New System.Windows.Forms.ListBox()
        Me.txtcalib_numbers = New System.Windows.Forms.TextBox()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.txtcalib_compfilename = New System.Windows.Forms.TextBox()
        Me.txtcalib_1 = New System.Windows.Forms.TextBox()
        Me.listcalib_1 = New System.Windows.Forms.ListBox()
        Me.btnpreview = New System.Windows.Forms.Button()
        Me.piccalib_resize = New System.Windows.Forms.PictureBox()
        Me.chkcalib_1 = New System.Windows.Forms.CheckBox()
        Me.chkcalib_2 = New System.Windows.Forms.CheckBox()
        Me.txtcalib_hand_name = New System.Windows.Forms.TextBox()
        Me.txtcalib_max = New System.Windows.Forms.TextBox()
        Me.txtcalib_scaleorcolor = New System.Windows.Forms.TextBox()
        Me.gbcalib_m1 = New System.Windows.Forms.GroupBox()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.txtcalib_bestvalue = New System.Windows.Forms.TextBox()
        Me.piccalib_bestresult = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.txtcalib_nowvalue = New System.Windows.Forms.TextBox()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.piccalib_handresult = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.piccalib_comp = New System.Windows.Forms.PictureBox()
        Me.piccalib_temp = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.piccamera = New OpenCvSharp.UserInterface.PictureBoxIpl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.btntosetting02 = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.rtxtupdate = New System.Windows.Forms.RichTextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblversion = New System.Windows.Forms.Label()
        Me.TabPage16 = New System.Windows.Forms.TabPage()
        Me.btntosetting04 = New System.Windows.Forms.Button()
        Me.rtxtlicense = New System.Windows.Forms.RichTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.link_dobon = New System.Windows.Forms.LinkLabel()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.link_directshowlib = New System.Windows.Forms.LinkLabel()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.link_opencvsharp = New System.Windows.Forms.LinkLabel()
        Me.link_inteltbb = New System.Windows.Forms.LinkLabel()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.btnview_close = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.lbltitlebar = New System.Windows.Forms.Label()
        Me.btnclosewindow = New System.Windows.Forms.Button()
        Me.btnsaisyouka = New System.Windows.Forms.Button()
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        Me.timopencvsleep = New System.Windows.Forms.Timer(Me.components)
        Me.timcv_perfectanten = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.timcv_cap = New System.Windows.Forms.Timer(Me.components)
        Me.timcv_anten = New System.Windows.Forms.Timer(Me.components)
        Me.timcv_forantencap = New System.Windows.Forms.Timer(Me.components)
        Me.timlockwindow = New System.Windows.Forms.Timer(Me.components)
        Me.timchecktimer = New System.Windows.Forms.Timer(Me.components)
        Me.timcamera = New System.Windows.Forms.Timer(Me.components)
        Me.timcalib = New System.Windows.Forms.Timer(Me.components)
        Me.timash_hotkey_sleep = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DGtable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlview_window.SuspendLayout()
        CType(Me.piccap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictempipl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxIpl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piczoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picview_capture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlview_control.SuspendLayout()
        CType(Me.numloadno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trktemp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpgeneral.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnl_other.SuspendLayout()
        Me.pnl_video.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.numwin_interval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numwin_locy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numwin_locx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numvideo_sizey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numvideo_sizex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_loadremover.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.numload_rate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.numload_rate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage7.SuspendLayout()
        CType(Me.numload_rate3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage8.SuspendLayout()
        CType(Me.numload_rate4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage9.SuspendLayout()
        CType(Me.numload_rate5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage10.SuspendLayout()
        CType(Me.numload_rate6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage11.SuspendLayout()
        CType(Me.numload_rate7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage12.SuspendLayout()
        CType(Me.numload_rate8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage13.SuspendLayout()
        CType(Me.numload_rate9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage14.SuspendLayout()
        CType(Me.numload_rate10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numload_delay10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_hotkey.SuspendLayout()
        CType(Me.numpresstime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_cvparameter.SuspendLayout()
        CType(Me.numcv_framerate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcv_device, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_focus.SuspendLayout()
        CType(Me.numsendsleep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_graph.SuspendLayout()
        CType(Me.numgraph_first, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numtextwindow_sizex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numtextwindow_sizey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numprofile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.numskip_ash, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numundo_ash, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numreset_ash, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcv_sizex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcv_sizey, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numsavex, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numsavey, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.numtemp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl_parameter.SuspendLayout()
        CType(Me.numanten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numstop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numloopcount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcv_interval, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numpercent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picunder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numnowloop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.piccv_load, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picipl_foranten, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piccv_reset, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piccv_picture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picipl_cap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.dgv2_template, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num2_rbx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num2_rby, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num2_lty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.num2_ltx, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage15.SuspendLayout()
        Me.gbsetting.SuspendLayout()
        CType(Me.numcalib_hand_scaleheight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbrgb.SuspendLayout()
        CType(Me.numcalib_hand_bright, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_hand_g, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_hand_r, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_hand_b, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_hand_scalewidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_hand_scale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_bright, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_r, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_scaleheight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_g, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_b, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_scalewidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numcalib_scale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpcalib_1.SuspendLayout()
        CType(Me.piccalib_resize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbcalib_m1.SuspendLayout()
        CType(Me.piccalib_bestresult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piccalib_handresult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piccalib_comp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piccalib_temp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.piccamera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabPage16.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage15)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage16)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Controls.Add(Me.txtrowscount)
        Me.TabPage1.Controls.Add(Me.DGtable)
        Me.TabPage1.Controls.Add(Me.pnlview_window)
        Me.TabPage1.Controls.Add(Me.pnlview_control)
        Me.TabPage1.Controls.Add(Me.PictureBox1)
        Me.TabPage1.Controls.Add(Me.grpgeneral)
        Me.TabPage1.Controls.Add(Me.pnl_other)
        Me.TabPage1.Controls.Add(Me.pnl_video)
        Me.TabPage1.Controls.Add(Me.btnclosetable)
        Me.TabPage1.Controls.Add(Me.pnl_loadremover)
        Me.TabPage1.Controls.Add(Me.pnl_hotkey)
        Me.TabPage1.Controls.Add(Me.listsetcontents)
        Me.TabPage1.Controls.Add(Me.pnl_cvparameter)
        Me.TabPage1.Controls.Add(Me.pnl_focus)
        Me.TabPage1.Controls.Add(Me.pnl_graph)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.pnl_parameter)
        Me.TabPage1.Controls.Add(Me.btnstartopencv)
        Me.TabPage1.Controls.Add(Me.btndeleteprofile)
        Me.TabPage1.Controls.Add(Me.btnaddprofile)
        Me.TabPage1.Controls.Add(Me.cmbprofile)
        Me.TabPage1.Controls.Add(Me.MenuStrip1)
        Me.TabPage1.Controls.Add(Me.picunder)
        Me.TabPage1.Controls.Add(Me.btnclose_general)
        Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TabPage1.Name = "TabPage1"
        '
        'txtrowscount
        '
        Me.txtrowscount.BackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.txtrowscount, "txtrowscount")
        Me.txtrowscount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtrowscount.Name = "txtrowscount"
        Me.txtrowscount.ReadOnly = True
        '
        'DGtable
        '
        Me.DGtable.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.DGtable.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Meiryo UI", 10.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGtable.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGtable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGtable.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.no, Me.send, Me.key, Me.rate, Me.sleep, Me.timing, Me.darksleep, Me.darkthr, Me.seektime, Me.graph_count, Me.graph_rate, Me.graph_view, Me.posx, Me.posy, Me.sizex, Me.sizey, Me.ltx, Me.lty, Me.rbx, Me.rby})
        resources.ApplyResources(Me.DGtable, "DGtable")
        Me.DGtable.Name = "DGtable"
        Me.DGtable.RowTemplate.Height = 21
        '
        'no
        '
        resources.ApplyResources(Me.no, "no")
        Me.no.Name = "no"
        '
        'send
        '
        resources.ApplyResources(Me.send, "send")
        Me.send.Name = "send"
        '
        'key
        '
        resources.ApplyResources(Me.key, "key")
        Me.key.Name = "key"
        '
        'rate
        '
        resources.ApplyResources(Me.rate, "rate")
        Me.rate.Name = "rate"
        '
        'sleep
        '
        resources.ApplyResources(Me.sleep, "sleep")
        Me.sleep.Name = "sleep"
        '
        'timing
        '
        resources.ApplyResources(Me.timing, "timing")
        Me.timing.Name = "timing"
        '
        'darksleep
        '
        resources.ApplyResources(Me.darksleep, "darksleep")
        Me.darksleep.Name = "darksleep"
        '
        'darkthr
        '
        resources.ApplyResources(Me.darkthr, "darkthr")
        Me.darkthr.Name = "darkthr"
        '
        'seektime
        '
        resources.ApplyResources(Me.seektime, "seektime")
        Me.seektime.Name = "seektime"
        '
        'graph_count
        '
        resources.ApplyResources(Me.graph_count, "graph_count")
        Me.graph_count.Name = "graph_count"
        '
        'graph_rate
        '
        resources.ApplyResources(Me.graph_rate, "graph_rate")
        Me.graph_rate.Name = "graph_rate"
        '
        'graph_view
        '
        resources.ApplyResources(Me.graph_view, "graph_view")
        Me.graph_view.Name = "graph_view"
        '
        'posx
        '
        resources.ApplyResources(Me.posx, "posx")
        Me.posx.Name = "posx"
        '
        'posy
        '
        resources.ApplyResources(Me.posy, "posy")
        Me.posy.Name = "posy"
        '
        'sizex
        '
        resources.ApplyResources(Me.sizex, "sizex")
        Me.sizex.Name = "sizex"
        '
        'sizey
        '
        resources.ApplyResources(Me.sizey, "sizey")
        Me.sizey.Name = "sizey"
        '
        'ltx
        '
        resources.ApplyResources(Me.ltx, "ltx")
        Me.ltx.Name = "ltx"
        '
        'lty
        '
        resources.ApplyResources(Me.lty, "lty")
        Me.lty.Name = "lty"
        '
        'rbx
        '
        resources.ApplyResources(Me.rbx, "rbx")
        Me.rbx.Name = "rbx"
        '
        'rby
        '
        resources.ApplyResources(Me.rby, "rby")
        Me.rby.Name = "rby"
        '
        'pnlview_window
        '
        Me.pnlview_window.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.pnlview_window.Controls.Add(Me.piccap)
        Me.pnlview_window.Controls.Add(Me.pictempipl)
        Me.pnlview_window.Controls.Add(Me.Label32)
        Me.pnlview_window.Controls.Add(Me.PictureBoxIpl1)
        Me.pnlview_window.Controls.Add(Me.piczoom)
        Me.pnlview_window.Controls.Add(Me.picview_capture)
        resources.ApplyResources(Me.pnlview_window, "pnlview_window")
        Me.pnlview_window.Name = "pnlview_window"
        '
        'piccap
        '
        Me.piccap.BackColor = System.Drawing.SystemColors.ControlDark
        resources.ApplyResources(Me.piccap, "piccap")
        Me.piccap.Name = "piccap"
        Me.piccap.TabStop = False
        '
        'pictempipl
        '
        resources.ApplyResources(Me.pictempipl, "pictempipl")
        Me.pictempipl.Name = "pictempipl"
        Me.pictempipl.TabStop = False
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.Label32.ForeColor = System.Drawing.SystemColors.Control
        Me.Label32.Name = "Label32"
        '
        'PictureBoxIpl1
        '
        resources.ApplyResources(Me.PictureBoxIpl1, "PictureBoxIpl1")
        Me.PictureBoxIpl1.Name = "PictureBoxIpl1"
        Me.PictureBoxIpl1.TabStop = False
        '
        'piczoom
        '
        Me.piczoom.BackColor = System.Drawing.SystemColors.ControlDark
        resources.ApplyResources(Me.piczoom, "piczoom")
        Me.piczoom.Name = "piczoom"
        Me.piczoom.TabStop = False
        '
        'picview_capture
        '
        Me.picview_capture.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.picview_capture, "picview_capture")
        Me.picview_capture.Name = "picview_capture"
        Me.picview_capture.TabStop = False
        '
        'pnlview_control
        '
        Me.pnlview_control.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.pnlview_control.Controls.Add(Me.btntemp)
        Me.pnlview_control.Controls.Add(Me.btncap)
        Me.pnlview_control.Controls.Add(Me.btnforward)
        Me.pnlview_control.Controls.Add(Me.btnback)
        Me.pnlview_control.Controls.Add(Me.numloadno)
        Me.pnlview_control.Controls.Add(Me.txtno_comment)
        Me.pnlview_control.Controls.Add(Me.chkloading)
        Me.pnlview_control.Controls.Add(Me.chklimit)
        Me.pnlview_control.Controls.Add(Me.chkoverwrite)
        Me.pnlview_control.Controls.Add(Me.trktemp)
        resources.ApplyResources(Me.pnlview_control, "pnlview_control")
        Me.pnlview_control.Name = "pnlview_control"
        '
        'btntemp
        '
        resources.ApplyResources(Me.btntemp, "btntemp")
        Me.btntemp.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.btntemp.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btntemp.Name = "btntemp"
        Me.btntemp.UseVisualStyleBackColor = False
        '
        'btncap
        '
        Me.btncap.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(12, Byte), Integer))
        resources.ApplyResources(Me.btncap, "btncap")
        Me.btncap.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncap.Name = "btncap"
        Me.btncap.UseVisualStyleBackColor = False
        '
        'btnforward
        '
        Me.btnforward.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnforward, "btnforward")
        Me.btnforward.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnforward.Name = "btnforward"
        Me.btnforward.UseVisualStyleBackColor = False
        '
        'btnback
        '
        Me.btnback.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnback, "btnback")
        Me.btnback.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnback.Name = "btnback"
        Me.btnback.UseVisualStyleBackColor = False
        '
        'numloadno
        '
        Me.numloadno.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.numloadno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numloadno, "numloadno")
        Me.numloadno.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numloadno.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numloadno.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numloadno.Name = "numloadno"
        Me.numloadno.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'txtno_comment
        '
        Me.txtno_comment.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.txtno_comment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtno_comment, "txtno_comment")
        Me.txtno_comment.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtno_comment.Name = "txtno_comment"
        Me.txtno_comment.ReadOnly = True
        '
        'chkloading
        '
        resources.ApplyResources(Me.chkloading, "chkloading")
        Me.chkloading.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.chkloading.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.chkloading.Name = "chkloading"
        Me.chkloading.UseVisualStyleBackColor = False
        '
        'chklimit
        '
        resources.ApplyResources(Me.chklimit, "chklimit")
        Me.chklimit.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.chklimit.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.chklimit.Name = "chklimit"
        Me.chklimit.UseVisualStyleBackColor = False
        '
        'chkoverwrite
        '
        resources.ApplyResources(Me.chkoverwrite, "chkoverwrite")
        Me.chkoverwrite.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.chkoverwrite.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.chkoverwrite.Name = "chkoverwrite"
        Me.chkoverwrite.UseVisualStyleBackColor = False
        '
        'trktemp
        '
        resources.ApplyResources(Me.trktemp, "trktemp")
        Me.trktemp.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        Me.trktemp.Maximum = 300
        Me.trktemp.Name = "trktemp"
        Me.trktemp.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(95, Byte), Integer))
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'grpgeneral
        '
        Me.grpgeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.grpgeneral.Controls.Add(Me.lblcur_load10)
        Me.grpgeneral.Controls.Add(Me.lblcur_load9)
        Me.grpgeneral.Controls.Add(Me.lblcur_load8)
        Me.grpgeneral.Controls.Add(Me.lblcur_load7)
        Me.grpgeneral.Controls.Add(Me.lblcur_load6)
        Me.grpgeneral.Controls.Add(Me.lblcur_load5)
        Me.grpgeneral.Controls.Add(Me.lblcur_load4)
        Me.grpgeneral.Controls.Add(Me.lblcur_load3)
        Me.grpgeneral.Controls.Add(Me.lblcur_load2)
        Me.grpgeneral.Controls.Add(Me.btncur_showtext)
        Me.grpgeneral.Controls.Add(Me.lblcur_showtextwindow)
        Me.grpgeneral.Controls.Add(Me.lblcur_showvideo)
        Me.grpgeneral.Controls.Add(Me.lblset_text)
        Me.grpgeneral.Controls.Add(Me.btncur_showvideo)
        Me.grpgeneral.Controls.Add(Me.Label97)
        Me.grpgeneral.Controls.Add(Me.lblset_video)
        Me.grpgeneral.Controls.Add(Me.lblcur_firstsplit)
        Me.grpgeneral.Controls.Add(Me.Label79)
        Me.grpgeneral.Controls.Add(Me.lblcur_addcount)
        Me.grpgeneral.Controls.Add(Me.lblcur_namedpipe)
        Me.grpgeneral.Controls.Add(Me.lblcur_rendou)
        Me.grpgeneral.Controls.Add(Me.lblcur_focus_after)
        Me.grpgeneral.Controls.Add(Me.lblcur_focus_before)
        Me.grpgeneral.Controls.Add(Me.lblcur_load1)
        Me.grpgeneral.Controls.Add(Me.Panel4)
        Me.grpgeneral.Controls.Add(Me.Label92)
        Me.grpgeneral.Controls.Add(Me.lblset_focus)
        Me.grpgeneral.Controls.Add(Me.Label94)
        Me.grpgeneral.Controls.Add(Me.Label90)
        Me.grpgeneral.Controls.Add(Me.lblset_hotkey)
        Me.grpgeneral.Controls.Add(Me.Label89)
        Me.grpgeneral.Controls.Add(Me.btncur_clear_live)
        Me.grpgeneral.Controls.Add(Me.btncur_clear_table)
        Me.grpgeneral.Controls.Add(Me.btncur_clear_count)
        Me.grpgeneral.Controls.Add(Me.Label86)
        Me.grpgeneral.Controls.Add(Me.lblset_graph)
        Me.grpgeneral.Controls.Add(Me.btncur_webcamera)
        Me.grpgeneral.Controls.Add(Me.lblset_road)
        Me.grpgeneral.Controls.Add(Me.lblcur_device_res_fps)
        Me.grpgeneral.Controls.Add(Me.lblset_device)
        Me.grpgeneral.Controls.Add(Me.lblcur_device_name)
        Me.grpgeneral.Controls.Add(Me.lblset_monitoring)
        resources.ApplyResources(Me.grpgeneral, "grpgeneral")
        Me.grpgeneral.ForeColor = System.Drawing.Color.FloralWhite
        Me.grpgeneral.Name = "grpgeneral"
        Me.grpgeneral.TabStop = False
        '
        'lblcur_load10
        '
        resources.ApplyResources(Me.lblcur_load10, "lblcur_load10")
        Me.lblcur_load10.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load10.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load10.Name = "lblcur_load10"
        '
        'lblcur_load9
        '
        resources.ApplyResources(Me.lblcur_load9, "lblcur_load9")
        Me.lblcur_load9.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load9.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load9.Name = "lblcur_load9"
        '
        'lblcur_load8
        '
        resources.ApplyResources(Me.lblcur_load8, "lblcur_load8")
        Me.lblcur_load8.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load8.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load8.Name = "lblcur_load8"
        '
        'lblcur_load7
        '
        resources.ApplyResources(Me.lblcur_load7, "lblcur_load7")
        Me.lblcur_load7.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load7.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load7.Name = "lblcur_load7"
        '
        'lblcur_load6
        '
        resources.ApplyResources(Me.lblcur_load6, "lblcur_load6")
        Me.lblcur_load6.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load6.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load6.Name = "lblcur_load6"
        '
        'lblcur_load5
        '
        resources.ApplyResources(Me.lblcur_load5, "lblcur_load5")
        Me.lblcur_load5.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load5.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load5.Name = "lblcur_load5"
        '
        'lblcur_load4
        '
        resources.ApplyResources(Me.lblcur_load4, "lblcur_load4")
        Me.lblcur_load4.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load4.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load4.Name = "lblcur_load4"
        '
        'lblcur_load3
        '
        resources.ApplyResources(Me.lblcur_load3, "lblcur_load3")
        Me.lblcur_load3.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load3.Name = "lblcur_load3"
        '
        'lblcur_load2
        '
        resources.ApplyResources(Me.lblcur_load2, "lblcur_load2")
        Me.lblcur_load2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load2.Name = "lblcur_load2"
        '
        'btncur_showtext
        '
        Me.btncur_showtext.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncur_showtext, "btncur_showtext")
        Me.btncur_showtext.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncur_showtext.Name = "btncur_showtext"
        Me.btncur_showtext.UseVisualStyleBackColor = False
        '
        'lblcur_showtextwindow
        '
        resources.ApplyResources(Me.lblcur_showtextwindow, "lblcur_showtextwindow")
        Me.lblcur_showtextwindow.BackColor = System.Drawing.Color.Crimson
        Me.lblcur_showtextwindow.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_showtextwindow.Name = "lblcur_showtextwindow"
        '
        'lblcur_showvideo
        '
        resources.ApplyResources(Me.lblcur_showvideo, "lblcur_showvideo")
        Me.lblcur_showvideo.BackColor = System.Drawing.Color.Crimson
        Me.lblcur_showvideo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_showvideo.Name = "lblcur_showvideo"
        '
        'lblset_text
        '
        resources.ApplyResources(Me.lblset_text, "lblset_text")
        Me.lblset_text.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_text.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_text.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_text.Name = "lblset_text"
        '
        'btncur_showvideo
        '
        Me.btncur_showvideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncur_showvideo, "btncur_showvideo")
        Me.btncur_showvideo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncur_showvideo.Name = "btncur_showvideo"
        Me.btncur_showvideo.UseVisualStyleBackColor = False
        '
        'Label97
        '
        resources.ApplyResources(Me.Label97, "Label97")
        Me.Label97.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label97.ForeColor = System.Drawing.SystemColors.Control
        Me.Label97.Name = "Label97"
        '
        'lblset_video
        '
        resources.ApplyResources(Me.lblset_video, "lblset_video")
        Me.lblset_video.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_video.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_video.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_video.Name = "lblset_video"
        '
        'lblcur_firstsplit
        '
        resources.ApplyResources(Me.lblcur_firstsplit, "lblcur_firstsplit")
        Me.lblcur_firstsplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_firstsplit.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_firstsplit.Name = "lblcur_firstsplit"
        '
        'Label79
        '
        resources.ApplyResources(Me.Label79, "Label79")
        Me.Label79.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label79.ForeColor = System.Drawing.SystemColors.Control
        Me.Label79.Name = "Label79"
        '
        'lblcur_addcount
        '
        resources.ApplyResources(Me.lblcur_addcount, "lblcur_addcount")
        Me.lblcur_addcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_addcount.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_addcount.Name = "lblcur_addcount"
        '
        'lblcur_namedpipe
        '
        resources.ApplyResources(Me.lblcur_namedpipe, "lblcur_namedpipe")
        Me.lblcur_namedpipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_namedpipe.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_namedpipe.Name = "lblcur_namedpipe"
        '
        'lblcur_rendou
        '
        resources.ApplyResources(Me.lblcur_rendou, "lblcur_rendou")
        Me.lblcur_rendou.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_rendou.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_rendou.Name = "lblcur_rendou"
        '
        'lblcur_focus_after
        '
        resources.ApplyResources(Me.lblcur_focus_after, "lblcur_focus_after")
        Me.lblcur_focus_after.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_focus_after.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_focus_after.Name = "lblcur_focus_after"
        '
        'lblcur_focus_before
        '
        resources.ApplyResources(Me.lblcur_focus_before, "lblcur_focus_before")
        Me.lblcur_focus_before.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_focus_before.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_focus_before.Name = "lblcur_focus_before"
        '
        'lblcur_load1
        '
        resources.ApplyResources(Me.lblcur_load1, "lblcur_load1")
        Me.lblcur_load1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_load1.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load1.Name = "lblcur_load1"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Panel4.Controls.Add(Me.lblcur_interval)
        Me.Panel4.Controls.Add(Me.lblcur_loopcount)
        Me.Panel4.Controls.Add(Me.lblcur_split)
        Me.Panel4.Controls.Add(Me.lblcur_load)
        Me.Panel4.Controls.Add(Me.Label76)
        Me.Panel4.Controls.Add(Me.lblcur_reset)
        Me.Panel4.Controls.Add(Me.lblcur_loop)
        resources.ApplyResources(Me.Panel4, "Panel4")
        Me.Panel4.Name = "Panel4"
        '
        'lblcur_interval
        '
        resources.ApplyResources(Me.lblcur_interval, "lblcur_interval")
        Me.lblcur_interval.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_interval.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_interval.Name = "lblcur_interval"
        '
        'lblcur_loopcount
        '
        resources.ApplyResources(Me.lblcur_loopcount, "lblcur_loopcount")
        Me.lblcur_loopcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.lblcur_loopcount.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_loopcount.Name = "lblcur_loopcount"
        '
        'lblcur_split
        '
        resources.ApplyResources(Me.lblcur_split, "lblcur_split")
        Me.lblcur_split.BackColor = System.Drawing.Color.Crimson
        Me.lblcur_split.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_split.Name = "lblcur_split"
        '
        'lblcur_load
        '
        resources.ApplyResources(Me.lblcur_load, "lblcur_load")
        Me.lblcur_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.lblcur_load.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_load.Name = "lblcur_load"
        '
        'Label76
        '
        resources.ApplyResources(Me.Label76, "Label76")
        Me.Label76.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label76.ForeColor = System.Drawing.SystemColors.Control
        Me.Label76.Name = "Label76"
        '
        'lblcur_reset
        '
        resources.ApplyResources(Me.lblcur_reset, "lblcur_reset")
        Me.lblcur_reset.BackColor = System.Drawing.Color.Crimson
        Me.lblcur_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_reset.Name = "lblcur_reset"
        '
        'lblcur_loop
        '
        resources.ApplyResources(Me.lblcur_loop, "lblcur_loop")
        Me.lblcur_loop.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.lblcur_loop.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_loop.Name = "lblcur_loop"
        '
        'Label92
        '
        resources.ApplyResources(Me.Label92, "Label92")
        Me.Label92.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label92.ForeColor = System.Drawing.SystemColors.Control
        Me.Label92.Name = "Label92"
        '
        'lblset_focus
        '
        resources.ApplyResources(Me.lblset_focus, "lblset_focus")
        Me.lblset_focus.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_focus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_focus.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_focus.Name = "lblset_focus"
        '
        'Label94
        '
        resources.ApplyResources(Me.Label94, "Label94")
        Me.Label94.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label94.ForeColor = System.Drawing.SystemColors.Control
        Me.Label94.Name = "Label94"
        '
        'Label90
        '
        resources.ApplyResources(Me.Label90, "Label90")
        Me.Label90.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label90.ForeColor = System.Drawing.SystemColors.Control
        Me.Label90.Name = "Label90"
        '
        'lblset_hotkey
        '
        resources.ApplyResources(Me.lblset_hotkey, "lblset_hotkey")
        Me.lblset_hotkey.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_hotkey.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_hotkey.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_hotkey.Name = "lblset_hotkey"
        '
        'Label89
        '
        resources.ApplyResources(Me.Label89, "Label89")
        Me.Label89.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label89.ForeColor = System.Drawing.SystemColors.Control
        Me.Label89.Name = "Label89"
        '
        'btncur_clear_live
        '
        Me.btncur_clear_live.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncur_clear_live, "btncur_clear_live")
        Me.btncur_clear_live.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncur_clear_live.Name = "btncur_clear_live"
        Me.btncur_clear_live.UseVisualStyleBackColor = False
        '
        'btncur_clear_table
        '
        Me.btncur_clear_table.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncur_clear_table, "btncur_clear_table")
        Me.btncur_clear_table.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncur_clear_table.Name = "btncur_clear_table"
        Me.btncur_clear_table.UseVisualStyleBackColor = False
        '
        'btncur_clear_count
        '
        Me.btncur_clear_count.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncur_clear_count, "btncur_clear_count")
        Me.btncur_clear_count.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncur_clear_count.Name = "btncur_clear_count"
        Me.btncur_clear_count.UseVisualStyleBackColor = False
        '
        'Label86
        '
        resources.ApplyResources(Me.Label86, "Label86")
        Me.Label86.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label86.ForeColor = System.Drawing.SystemColors.Control
        Me.Label86.Name = "Label86"
        '
        'lblset_graph
        '
        resources.ApplyResources(Me.lblset_graph, "lblset_graph")
        Me.lblset_graph.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_graph.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_graph.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_graph.Name = "lblset_graph"
        '
        'btncur_webcamera
        '
        Me.btncur_webcamera.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncur_webcamera, "btncur_webcamera")
        Me.btncur_webcamera.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncur_webcamera.Name = "btncur_webcamera"
        Me.btncur_webcamera.UseVisualStyleBackColor = False
        '
        'lblset_road
        '
        resources.ApplyResources(Me.lblset_road, "lblset_road")
        Me.lblset_road.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_road.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_road.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_road.Name = "lblset_road"
        '
        'lblcur_device_res_fps
        '
        resources.ApplyResources(Me.lblcur_device_res_fps, "lblcur_device_res_fps")
        Me.lblcur_device_res_fps.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_device_res_fps.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_device_res_fps.Name = "lblcur_device_res_fps"
        '
        'lblset_device
        '
        resources.ApplyResources(Me.lblset_device, "lblset_device")
        Me.lblset_device.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_device.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_device.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_device.Name = "lblset_device"
        '
        'lblcur_device_name
        '
        resources.ApplyResources(Me.lblcur_device_name, "lblcur_device_name")
        Me.lblcur_device_name.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblcur_device_name.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcur_device_name.Name = "lblcur_device_name"
        '
        'lblset_monitoring
        '
        resources.ApplyResources(Me.lblset_monitoring, "lblset_monitoring")
        Me.lblset_monitoring.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        Me.lblset_monitoring.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblset_monitoring.ForeColor = System.Drawing.Color.Gainsboro
        Me.lblset_monitoring.Name = "lblset_monitoring"
        '
        'pnl_other
        '
        Me.pnl_other.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_other.Controls.Add(Me.btntext_openfolder)
        Me.pnl_other.Controls.Add(Me.btntext_createtext)
        Me.pnl_other.Controls.Add(Me.txtpass_rtf)
        Me.pnl_other.Controls.Add(Me.Label112)
        Me.pnl_other.Controls.Add(Me.btnshow_chart)
        Me.pnl_other.Controls.Add(Me.chkshow_text)
        Me.pnl_other.Controls.Add(Me.chkcreate_temppicture)
        Me.pnl_other.Controls.Add(Me.txtpass_picturefolder)
        Me.pnl_other.Controls.Add(Me.txtpass_csv)
        Me.pnl_other.Controls.Add(Me.Label98)
        Me.pnl_other.Controls.Add(Me.Label26)
        Me.pnl_other.Controls.Add(Me.Label23)
        Me.pnl_other.Controls.Add(Me.lbllivesplit_state)
        resources.ApplyResources(Me.pnl_other, "pnl_other")
        Me.pnl_other.Name = "pnl_other"
        '
        'btntext_openfolder
        '
        Me.btntext_openfolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btntext_openfolder, "btntext_openfolder")
        Me.btntext_openfolder.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btntext_openfolder.Name = "btntext_openfolder"
        Me.btntext_openfolder.UseVisualStyleBackColor = False
        '
        'btntext_createtext
        '
        Me.btntext_createtext.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btntext_createtext, "btntext_createtext")
        Me.btntext_createtext.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btntext_createtext.Name = "btntext_createtext"
        Me.btntext_createtext.UseVisualStyleBackColor = False
        '
        'txtpass_rtf
        '
        Me.txtpass_rtf.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtpass_rtf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtpass_rtf, "txtpass_rtf")
        Me.txtpass_rtf.ForeColor = System.Drawing.SystemColors.Control
        Me.txtpass_rtf.Name = "txtpass_rtf"
        Me.txtpass_rtf.ReadOnly = True
        '
        'Label112
        '
        resources.ApplyResources(Me.Label112, "Label112")
        Me.Label112.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label112.ForeColor = System.Drawing.SystemColors.Control
        Me.Label112.Name = "Label112"
        '
        'btnshow_chart
        '
        Me.btnshow_chart.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnshow_chart, "btnshow_chart")
        Me.btnshow_chart.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnshow_chart.Name = "btnshow_chart"
        Me.btnshow_chart.UseVisualStyleBackColor = False
        '
        'chkshow_text
        '
        resources.ApplyResources(Me.chkshow_text, "chkshow_text")
        Me.chkshow_text.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkshow_text.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshow_text.Name = "chkshow_text"
        Me.chkshow_text.UseVisualStyleBackColor = False
        '
        'chkcreate_temppicture
        '
        resources.ApplyResources(Me.chkcreate_temppicture, "chkcreate_temppicture")
        Me.chkcreate_temppicture.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkcreate_temppicture.Checked = Global.AutoSplitHelper_OpenCV.My.MySettings.Default.chkcreate_temppicture
        Me.chkcreate_temppicture.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.AutoSplitHelper_OpenCV.My.MySettings.Default, "chkcreate_temppicture", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.chkcreate_temppicture.ForeColor = System.Drawing.SystemColors.Control
        Me.chkcreate_temppicture.Name = "chkcreate_temppicture"
        Me.chkcreate_temppicture.UseVisualStyleBackColor = False
        '
        'txtpass_picturefolder
        '
        Me.txtpass_picturefolder.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtpass_picturefolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtpass_picturefolder, "txtpass_picturefolder")
        Me.txtpass_picturefolder.ForeColor = System.Drawing.SystemColors.Control
        Me.txtpass_picturefolder.Name = "txtpass_picturefolder"
        Me.txtpass_picturefolder.ReadOnly = True
        '
        'txtpass_csv
        '
        Me.txtpass_csv.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtpass_csv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtpass_csv, "txtpass_csv")
        Me.txtpass_csv.ForeColor = System.Drawing.SystemColors.Control
        Me.txtpass_csv.Name = "txtpass_csv"
        Me.txtpass_csv.ReadOnly = True
        '
        'Label98
        '
        resources.ApplyResources(Me.Label98, "Label98")
        Me.Label98.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label98.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label98.Name = "Label98"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label26.ForeColor = System.Drawing.SystemColors.Control
        Me.Label26.Name = "Label26"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label23.ForeColor = System.Drawing.SystemColors.Control
        Me.Label23.Name = "Label23"
        '
        'lbllivesplit_state
        '
        resources.ApplyResources(Me.lbllivesplit_state, "lbllivesplit_state")
        Me.lbllivesplit_state.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lbllivesplit_state.ForeColor = System.Drawing.SystemColors.Control
        Me.lbllivesplit_state.Name = "lbllivesplit_state"
        '
        'pnl_video
        '
        Me.pnl_video.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_video.Controls.Add(Me.chkvideo_manualstart)
        Me.pnl_video.Controls.Add(Me.btnselectvideo)
        Me.pnl_video.Controls.Add(Me.GroupBox4)
        Me.pnl_video.Controls.Add(Me.Label91)
        Me.pnl_video.Controls.Add(Me.numvideo_sizey)
        Me.pnl_video.Controls.Add(Me.numvideo_sizex)
        Me.pnl_video.Controls.Add(Me.Label84)
        Me.pnl_video.Controls.Add(Me.txtvideo_startat)
        Me.pnl_video.Controls.Add(Me.Label83)
        Me.pnl_video.Controls.Add(Me.Label80)
        Me.pnl_video.Controls.Add(Me.txtvideo_pass)
        Me.pnl_video.Controls.Add(Me.chkvideo_autoseek)
        Me.pnl_video.Controls.Add(Me.chkshowvideo)
        Me.pnl_video.Controls.Add(Me.Label78)
        resources.ApplyResources(Me.pnl_video, "pnl_video")
        Me.pnl_video.Name = "pnl_video"
        '
        'chkvideo_manualstart
        '
        resources.ApplyResources(Me.chkvideo_manualstart, "chkvideo_manualstart")
        Me.chkvideo_manualstart.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkvideo_manualstart.ForeColor = System.Drawing.SystemColors.Control
        Me.chkvideo_manualstart.Name = "chkvideo_manualstart"
        Me.chkvideo_manualstart.UseVisualStyleBackColor = False
        '
        'btnselectvideo
        '
        Me.btnselectvideo.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me.btnselectvideo, "btnselectvideo")
        Me.btnselectvideo.Name = "btnselectvideo"
        Me.btnselectvideo.UseVisualStyleBackColor = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkvideo_showwinvideo)
        Me.GroupBox4.Controls.Add(Me.numwin_interval)
        Me.GroupBox4.Controls.Add(Me.Label95)
        Me.GroupBox4.Controls.Add(Me.numwin_locy)
        Me.GroupBox4.Controls.Add(Me.numwin_locx)
        Me.GroupBox4.Controls.Add(Me.Label93)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Snow
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'chkvideo_showwinvideo
        '
        resources.ApplyResources(Me.chkvideo_showwinvideo, "chkvideo_showwinvideo")
        Me.chkvideo_showwinvideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkvideo_showwinvideo.ForeColor = System.Drawing.SystemColors.Control
        Me.chkvideo_showwinvideo.Name = "chkvideo_showwinvideo"
        Me.chkvideo_showwinvideo.UseVisualStyleBackColor = False
        '
        'numwin_interval
        '
        Me.numwin_interval.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numwin_interval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numwin_interval, "numwin_interval")
        Me.numwin_interval.ForeColor = System.Drawing.SystemColors.Control
        Me.numwin_interval.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numwin_interval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numwin_interval.Name = "numwin_interval"
        Me.numwin_interval.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label95
        '
        resources.ApplyResources(Me.Label95, "Label95")
        Me.Label95.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label95.ForeColor = System.Drawing.SystemColors.Control
        Me.Label95.Name = "Label95"
        '
        'numwin_locy
        '
        Me.numwin_locy.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numwin_locy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numwin_locy, "numwin_locy")
        Me.numwin_locy.ForeColor = System.Drawing.SystemColors.Control
        Me.numwin_locy.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numwin_locy.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.numwin_locy.Name = "numwin_locy"
        Me.numwin_locy.Value = New Decimal(New Integer() {180, 0, 0, 0})
        '
        'numwin_locx
        '
        Me.numwin_locx.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numwin_locx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numwin_locx, "numwin_locx")
        Me.numwin_locx.ForeColor = System.Drawing.SystemColors.Control
        Me.numwin_locx.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numwin_locx.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.numwin_locx.Name = "numwin_locx"
        Me.numwin_locx.Value = New Decimal(New Integer() {320, 0, 0, 0})
        '
        'Label93
        '
        resources.ApplyResources(Me.Label93, "Label93")
        Me.Label93.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label93.ForeColor = System.Drawing.SystemColors.Control
        Me.Label93.Name = "Label93"
        '
        'Label91
        '
        resources.ApplyResources(Me.Label91, "Label91")
        Me.Label91.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label91.ForeColor = System.Drawing.SystemColors.Control
        Me.Label91.Name = "Label91"
        '
        'numvideo_sizey
        '
        Me.numvideo_sizey.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numvideo_sizey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numvideo_sizey, "numvideo_sizey")
        Me.numvideo_sizey.ForeColor = System.Drawing.SystemColors.Control
        Me.numvideo_sizey.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.numvideo_sizey.Name = "numvideo_sizey"
        Me.numvideo_sizey.Value = New Decimal(New Integer() {180, 0, 0, 0})
        '
        'numvideo_sizex
        '
        Me.numvideo_sizex.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numvideo_sizex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numvideo_sizex, "numvideo_sizex")
        Me.numvideo_sizex.ForeColor = System.Drawing.SystemColors.Control
        Me.numvideo_sizex.Maximum = New Decimal(New Integer() {640, 0, 0, 0})
        Me.numvideo_sizex.Name = "numvideo_sizex"
        Me.numvideo_sizex.Value = New Decimal(New Integer() {320, 0, 0, 0})
        '
        'Label84
        '
        resources.ApplyResources(Me.Label84, "Label84")
        Me.Label84.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label84.ForeColor = System.Drawing.SystemColors.Control
        Me.Label84.Name = "Label84"
        '
        'txtvideo_startat
        '
        Me.txtvideo_startat.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtvideo_startat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtvideo_startat, "txtvideo_startat")
        Me.txtvideo_startat.ForeColor = System.Drawing.SystemColors.Control
        Me.txtvideo_startat.Name = "txtvideo_startat"
        '
        'Label83
        '
        resources.ApplyResources(Me.Label83, "Label83")
        Me.Label83.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label83.ForeColor = System.Drawing.SystemColors.Control
        Me.Label83.Name = "Label83"
        '
        'Label80
        '
        resources.ApplyResources(Me.Label80, "Label80")
        Me.Label80.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label80.ForeColor = System.Drawing.SystemColors.Control
        Me.Label80.Name = "Label80"
        '
        'txtvideo_pass
        '
        Me.txtvideo_pass.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtvideo_pass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtvideo_pass, "txtvideo_pass")
        Me.txtvideo_pass.ForeColor = System.Drawing.SystemColors.Control
        Me.txtvideo_pass.Name = "txtvideo_pass"
        Me.txtvideo_pass.ReadOnly = True
        '
        'chkvideo_autoseek
        '
        resources.ApplyResources(Me.chkvideo_autoseek, "chkvideo_autoseek")
        Me.chkvideo_autoseek.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkvideo_autoseek.ForeColor = System.Drawing.SystemColors.Control
        Me.chkvideo_autoseek.Name = "chkvideo_autoseek"
        Me.chkvideo_autoseek.UseVisualStyleBackColor = False
        '
        'chkshowvideo
        '
        resources.ApplyResources(Me.chkshowvideo, "chkshowvideo")
        Me.chkshowvideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkshowvideo.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshowvideo.Name = "chkshowvideo"
        Me.chkshowvideo.UseVisualStyleBackColor = False
        '
        'Label78
        '
        resources.ApplyResources(Me.Label78, "Label78")
        Me.Label78.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label78.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label78.Name = "Label78"
        '
        'btnclosetable
        '
        Me.btnclosetable.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnclosetable, "btnclosetable")
        Me.btnclosetable.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnclosetable.Name = "btnclosetable"
        Me.btnclosetable.UseVisualStyleBackColor = False
        '
        'pnl_loadremover
        '
        Me.pnl_loadremover.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_loadremover.Controls.Add(Me.chkload7)
        Me.pnl_loadremover.Controls.Add(Me.chkload1)
        Me.pnl_loadremover.Controls.Add(Me.chkload8)
        Me.pnl_loadremover.Controls.Add(Me.chkload10)
        Me.pnl_loadremover.Controls.Add(Me.chkload3)
        Me.pnl_loadremover.Controls.Add(Me.chkload6)
        Me.pnl_loadremover.Controls.Add(Me.TabControl2)
        Me.pnl_loadremover.Controls.Add(Me.chkload5)
        Me.pnl_loadremover.Controls.Add(Me.chkload4)
        Me.pnl_loadremover.Controls.Add(Me.chkload2)
        Me.pnl_loadremover.Controls.Add(Me.chkload9)
        resources.ApplyResources(Me.pnl_loadremover, "pnl_loadremover")
        Me.pnl_loadremover.Name = "pnl_loadremover"
        '
        'chkload7
        '
        resources.ApplyResources(Me.chkload7, "chkload7")
        Me.chkload7.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload7.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload7.Name = "chkload7"
        Me.chkload7.UseVisualStyleBackColor = False
        '
        'chkload1
        '
        resources.ApplyResources(Me.chkload1, "chkload1")
        Me.chkload1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload1.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload1.Name = "chkload1"
        Me.chkload1.UseVisualStyleBackColor = False
        '
        'chkload8
        '
        resources.ApplyResources(Me.chkload8, "chkload8")
        Me.chkload8.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload8.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload8.Name = "chkload8"
        Me.chkload8.UseVisualStyleBackColor = False
        '
        'chkload10
        '
        resources.ApplyResources(Me.chkload10, "chkload10")
        Me.chkload10.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload10.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload10.Name = "chkload10"
        Me.chkload10.UseVisualStyleBackColor = False
        '
        'chkload3
        '
        resources.ApplyResources(Me.chkload3, "chkload3")
        Me.chkload3.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload3.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload3.Name = "chkload3"
        Me.chkload3.UseVisualStyleBackColor = False
        '
        'chkload6
        '
        resources.ApplyResources(Me.chkload6, "chkload6")
        Me.chkload6.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload6.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload6.Name = "chkload6"
        Me.chkload6.UseVisualStyleBackColor = False
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage4)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Controls.Add(Me.TabPage7)
        Me.TabControl2.Controls.Add(Me.TabPage8)
        Me.TabControl2.Controls.Add(Me.TabPage9)
        Me.TabControl2.Controls.Add(Me.TabPage10)
        Me.TabControl2.Controls.Add(Me.TabPage11)
        Me.TabControl2.Controls.Add(Me.TabPage12)
        Me.TabControl2.Controls.Add(Me.TabPage13)
        Me.TabControl2.Controls.Add(Me.TabPage14)
        resources.ApplyResources(Me.TabControl2, "TabControl2")
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage4.Controls.Add(Me.Label29)
        Me.TabPage4.Controls.Add(Me.Label87)
        Me.TabPage4.Controls.Add(Me.numload_rate1)
        Me.TabPage4.Controls.Add(Me.numload_delay1)
        Me.TabPage4.Controls.Add(Me.Label33)
        resources.ApplyResources(Me.TabPage4, "TabPage4")
        Me.TabPage4.Name = "TabPage4"
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label29.ForeColor = System.Drawing.SystemColors.Control
        Me.Label29.Name = "Label29"
        '
        'Label87
        '
        resources.ApplyResources(Me.Label87, "Label87")
        Me.Label87.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label87.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label87.Name = "Label87"
        '
        'numload_rate1
        '
        Me.numload_rate1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate1, "numload_rate1")
        Me.numload_rate1.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate1.Name = "numload_rate1"
        Me.numload_rate1.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay1
        '
        Me.numload_delay1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay1, "numload_delay1")
        Me.numload_delay1.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay1.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay1.Name = "numload_delay1"
        Me.numload_delay1.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label33.ForeColor = System.Drawing.SystemColors.Control
        Me.Label33.Name = "Label33"
        '
        'TabPage6
        '
        Me.TabPage6.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage6.Controls.Add(Me.Label15)
        Me.TabPage6.Controls.Add(Me.numload_rate2)
        Me.TabPage6.Controls.Add(Me.numload_delay2)
        Me.TabPage6.Controls.Add(Me.Label35)
        resources.ApplyResources(Me.TabPage6, "TabPage6")
        Me.TabPage6.Name = "TabPage6"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label15.ForeColor = System.Drawing.SystemColors.Control
        Me.Label15.Name = "Label15"
        '
        'numload_rate2
        '
        Me.numload_rate2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate2, "numload_rate2")
        Me.numload_rate2.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate2.Name = "numload_rate2"
        Me.numload_rate2.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay2
        '
        Me.numload_delay2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay2, "numload_delay2")
        Me.numload_delay2.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay2.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay2.Name = "numload_delay2"
        Me.numload_delay2.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label35.ForeColor = System.Drawing.SystemColors.Control
        Me.Label35.Name = "Label35"
        '
        'TabPage7
        '
        Me.TabPage7.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage7.Controls.Add(Me.Label36)
        Me.TabPage7.Controls.Add(Me.numload_rate3)
        Me.TabPage7.Controls.Add(Me.numload_delay3)
        Me.TabPage7.Controls.Add(Me.Label37)
        resources.ApplyResources(Me.TabPage7, "TabPage7")
        Me.TabPage7.Name = "TabPage7"
        '
        'Label36
        '
        resources.ApplyResources(Me.Label36, "Label36")
        Me.Label36.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label36.ForeColor = System.Drawing.SystemColors.Control
        Me.Label36.Name = "Label36"
        '
        'numload_rate3
        '
        Me.numload_rate3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate3, "numload_rate3")
        Me.numload_rate3.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate3.Name = "numload_rate3"
        Me.numload_rate3.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay3
        '
        Me.numload_delay3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay3, "numload_delay3")
        Me.numload_delay3.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay3.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay3.Name = "numload_delay3"
        Me.numload_delay3.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label37
        '
        resources.ApplyResources(Me.Label37, "Label37")
        Me.Label37.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label37.ForeColor = System.Drawing.SystemColors.Control
        Me.Label37.Name = "Label37"
        '
        'TabPage8
        '
        Me.TabPage8.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage8.Controls.Add(Me.Label40)
        Me.TabPage8.Controls.Add(Me.numload_rate4)
        Me.TabPage8.Controls.Add(Me.numload_delay4)
        Me.TabPage8.Controls.Add(Me.Label43)
        resources.ApplyResources(Me.TabPage8, "TabPage8")
        Me.TabPage8.Name = "TabPage8"
        '
        'Label40
        '
        resources.ApplyResources(Me.Label40, "Label40")
        Me.Label40.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label40.ForeColor = System.Drawing.SystemColors.Control
        Me.Label40.Name = "Label40"
        '
        'numload_rate4
        '
        Me.numload_rate4.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate4, "numload_rate4")
        Me.numload_rate4.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate4.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate4.Name = "numload_rate4"
        Me.numload_rate4.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay4
        '
        Me.numload_delay4.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay4, "numload_delay4")
        Me.numload_delay4.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay4.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay4.Name = "numload_delay4"
        Me.numload_delay4.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label43
        '
        resources.ApplyResources(Me.Label43, "Label43")
        Me.Label43.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label43.ForeColor = System.Drawing.SystemColors.Control
        Me.Label43.Name = "Label43"
        '
        'TabPage9
        '
        Me.TabPage9.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage9.Controls.Add(Me.Label44)
        Me.TabPage9.Controls.Add(Me.numload_rate5)
        Me.TabPage9.Controls.Add(Me.numload_delay5)
        Me.TabPage9.Controls.Add(Me.Label45)
        resources.ApplyResources(Me.TabPage9, "TabPage9")
        Me.TabPage9.Name = "TabPage9"
        '
        'Label44
        '
        resources.ApplyResources(Me.Label44, "Label44")
        Me.Label44.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label44.ForeColor = System.Drawing.SystemColors.Control
        Me.Label44.Name = "Label44"
        '
        'numload_rate5
        '
        Me.numload_rate5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate5, "numload_rate5")
        Me.numload_rate5.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate5.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate5.Name = "numload_rate5"
        Me.numload_rate5.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay5
        '
        Me.numload_delay5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay5, "numload_delay5")
        Me.numload_delay5.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay5.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay5.Name = "numload_delay5"
        Me.numload_delay5.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label45
        '
        resources.ApplyResources(Me.Label45, "Label45")
        Me.Label45.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label45.ForeColor = System.Drawing.SystemColors.Control
        Me.Label45.Name = "Label45"
        '
        'TabPage10
        '
        Me.TabPage10.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage10.Controls.Add(Me.Label47)
        Me.TabPage10.Controls.Add(Me.numload_rate6)
        Me.TabPage10.Controls.Add(Me.numload_delay6)
        Me.TabPage10.Controls.Add(Me.Label48)
        resources.ApplyResources(Me.TabPage10, "TabPage10")
        Me.TabPage10.Name = "TabPage10"
        '
        'Label47
        '
        resources.ApplyResources(Me.Label47, "Label47")
        Me.Label47.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label47.ForeColor = System.Drawing.SystemColors.Control
        Me.Label47.Name = "Label47"
        '
        'numload_rate6
        '
        Me.numload_rate6.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate6, "numload_rate6")
        Me.numload_rate6.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate6.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate6.Name = "numload_rate6"
        Me.numload_rate6.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay6
        '
        Me.numload_delay6.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay6, "numload_delay6")
        Me.numload_delay6.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay6.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay6.Name = "numload_delay6"
        Me.numload_delay6.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label48
        '
        resources.ApplyResources(Me.Label48, "Label48")
        Me.Label48.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label48.ForeColor = System.Drawing.SystemColors.Control
        Me.Label48.Name = "Label48"
        '
        'TabPage11
        '
        Me.TabPage11.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage11.Controls.Add(Me.Label50)
        Me.TabPage11.Controls.Add(Me.numload_rate7)
        Me.TabPage11.Controls.Add(Me.numload_delay7)
        Me.TabPage11.Controls.Add(Me.Label54)
        resources.ApplyResources(Me.TabPage11, "TabPage11")
        Me.TabPage11.Name = "TabPage11"
        '
        'Label50
        '
        resources.ApplyResources(Me.Label50, "Label50")
        Me.Label50.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label50.ForeColor = System.Drawing.SystemColors.Control
        Me.Label50.Name = "Label50"
        '
        'numload_rate7
        '
        Me.numload_rate7.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate7, "numload_rate7")
        Me.numload_rate7.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate7.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate7.Name = "numload_rate7"
        Me.numload_rate7.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay7
        '
        Me.numload_delay7.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay7, "numload_delay7")
        Me.numload_delay7.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay7.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay7.Name = "numload_delay7"
        Me.numload_delay7.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label54
        '
        resources.ApplyResources(Me.Label54, "Label54")
        Me.Label54.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label54.ForeColor = System.Drawing.SystemColors.Control
        Me.Label54.Name = "Label54"
        '
        'TabPage12
        '
        Me.TabPage12.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage12.Controls.Add(Me.Label55)
        Me.TabPage12.Controls.Add(Me.numload_rate8)
        Me.TabPage12.Controls.Add(Me.numload_delay8)
        Me.TabPage12.Controls.Add(Me.Label56)
        resources.ApplyResources(Me.TabPage12, "TabPage12")
        Me.TabPage12.Name = "TabPage12"
        '
        'Label55
        '
        resources.ApplyResources(Me.Label55, "Label55")
        Me.Label55.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label55.ForeColor = System.Drawing.SystemColors.Control
        Me.Label55.Name = "Label55"
        '
        'numload_rate8
        '
        Me.numload_rate8.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate8, "numload_rate8")
        Me.numload_rate8.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate8.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate8.Name = "numload_rate8"
        Me.numload_rate8.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay8
        '
        Me.numload_delay8.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay8, "numload_delay8")
        Me.numload_delay8.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay8.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay8.Name = "numload_delay8"
        Me.numload_delay8.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label56
        '
        resources.ApplyResources(Me.Label56, "Label56")
        Me.Label56.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label56.ForeColor = System.Drawing.SystemColors.Control
        Me.Label56.Name = "Label56"
        '
        'TabPage13
        '
        Me.TabPage13.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage13.Controls.Add(Me.Label57)
        Me.TabPage13.Controls.Add(Me.numload_rate9)
        Me.TabPage13.Controls.Add(Me.numload_delay9)
        Me.TabPage13.Controls.Add(Me.Label58)
        resources.ApplyResources(Me.TabPage13, "TabPage13")
        Me.TabPage13.Name = "TabPage13"
        '
        'Label57
        '
        resources.ApplyResources(Me.Label57, "Label57")
        Me.Label57.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label57.ForeColor = System.Drawing.SystemColors.Control
        Me.Label57.Name = "Label57"
        '
        'numload_rate9
        '
        Me.numload_rate9.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate9, "numload_rate9")
        Me.numload_rate9.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate9.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate9.Name = "numload_rate9"
        Me.numload_rate9.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay9
        '
        Me.numload_delay9.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay9, "numload_delay9")
        Me.numload_delay9.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay9.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay9.Name = "numload_delay9"
        Me.numload_delay9.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label58
        '
        resources.ApplyResources(Me.Label58, "Label58")
        Me.Label58.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label58.ForeColor = System.Drawing.SystemColors.Control
        Me.Label58.Name = "Label58"
        '
        'TabPage14
        '
        Me.TabPage14.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.TabPage14.Controls.Add(Me.Label59)
        Me.TabPage14.Controls.Add(Me.numload_rate10)
        Me.TabPage14.Controls.Add(Me.numload_delay10)
        Me.TabPage14.Controls.Add(Me.Label60)
        resources.ApplyResources(Me.TabPage14, "TabPage14")
        Me.TabPage14.Name = "TabPage14"
        '
        'Label59
        '
        resources.ApplyResources(Me.Label59, "Label59")
        Me.Label59.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label59.ForeColor = System.Drawing.SystemColors.Control
        Me.Label59.Name = "Label59"
        '
        'numload_rate10
        '
        Me.numload_rate10.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_rate10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_rate10, "numload_rate10")
        Me.numload_rate10.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_rate10.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numload_rate10.Name = "numload_rate10"
        Me.numload_rate10.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'numload_delay10
        '
        Me.numload_delay10.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numload_delay10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numload_delay10, "numload_delay10")
        Me.numload_delay10.ForeColor = System.Drawing.SystemColors.Control
        Me.numload_delay10.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numload_delay10.Name = "numload_delay10"
        Me.numload_delay10.Value = New Decimal(New Integer() {100000, 0, 0, 0})
        '
        'Label60
        '
        resources.ApplyResources(Me.Label60, "Label60")
        Me.Label60.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label60.ForeColor = System.Drawing.SystemColors.Control
        Me.Label60.Name = "Label60"
        '
        'chkload5
        '
        resources.ApplyResources(Me.chkload5, "chkload5")
        Me.chkload5.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload5.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload5.Name = "chkload5"
        Me.chkload5.UseVisualStyleBackColor = False
        '
        'chkload4
        '
        resources.ApplyResources(Me.chkload4, "chkload4")
        Me.chkload4.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload4.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload4.Name = "chkload4"
        Me.chkload4.UseVisualStyleBackColor = False
        '
        'chkload2
        '
        resources.ApplyResources(Me.chkload2, "chkload2")
        Me.chkload2.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload2.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload2.Name = "chkload2"
        Me.chkload2.UseVisualStyleBackColor = False
        '
        'chkload9
        '
        resources.ApplyResources(Me.chkload9, "chkload9")
        Me.chkload9.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkload9.ForeColor = System.Drawing.SystemColors.Control
        Me.chkload9.Name = "chkload9"
        Me.chkload9.UseVisualStyleBackColor = False
        '
        'pnl_hotkey
        '
        Me.pnl_hotkey.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_hotkey.Controls.Add(Me.Label119)
        Me.pnl_hotkey.Controls.Add(Me.txtreset_ash_key)
        Me.pnl_hotkey.Controls.Add(Me.txtundo_ash_key)
        Me.pnl_hotkey.Controls.Add(Me.txtskip_ash_key)
        Me.pnl_hotkey.Controls.Add(Me.Label96)
        Me.pnl_hotkey.Controls.Add(Me.numpresstime)
        Me.pnl_hotkey.Controls.Add(Me.txtresume_key)
        Me.pnl_hotkey.Controls.Add(Me.Label85)
        Me.pnl_hotkey.Controls.Add(Me.Label28)
        Me.pnl_hotkey.Controls.Add(Me.Label7)
        Me.pnl_hotkey.Controls.Add(Me.chkalt_resume)
        Me.pnl_hotkey.Controls.Add(Me.chkctrl_resume)
        Me.pnl_hotkey.Controls.Add(Me.txtsplit_key)
        Me.pnl_hotkey.Controls.Add(Me.chkctrl_reset)
        Me.pnl_hotkey.Controls.Add(Me.Label8)
        Me.pnl_hotkey.Controls.Add(Me.chkshift_resume)
        Me.pnl_hotkey.Controls.Add(Me.Label9)
        Me.pnl_hotkey.Controls.Add(Me.chkalt_reset)
        Me.pnl_hotkey.Controls.Add(Me.chkundoskip)
        Me.pnl_hotkey.Controls.Add(Me.txtpause_key)
        Me.pnl_hotkey.Controls.Add(Me.txtreset_key)
        Me.pnl_hotkey.Controls.Add(Me.chkalt)
        Me.pnl_hotkey.Controls.Add(Me.chkshift_undo)
        Me.pnl_hotkey.Controls.Add(Me.Label27)
        Me.pnl_hotkey.Controls.Add(Me.Label10)
        Me.pnl_hotkey.Controls.Add(Me.chkctrl)
        Me.pnl_hotkey.Controls.Add(Me.chkctrl_undo)
        Me.pnl_hotkey.Controls.Add(Me.chkalt_pause)
        Me.pnl_hotkey.Controls.Add(Me.txtundo_key)
        Me.pnl_hotkey.Controls.Add(Me.chkshift)
        Me.pnl_hotkey.Controls.Add(Me.chkalt_undo)
        Me.pnl_hotkey.Controls.Add(Me.chkctrl_pause)
        Me.pnl_hotkey.Controls.Add(Me.txtskip_key)
        Me.pnl_hotkey.Controls.Add(Me.chkshift_pause)
        Me.pnl_hotkey.Controls.Add(Me.chkalt_skip)
        Me.pnl_hotkey.Controls.Add(Me.chkctrl_skip)
        Me.pnl_hotkey.Controls.Add(Me.chknamedpipe)
        Me.pnl_hotkey.Controls.Add(Me.chkshift_reset)
        Me.pnl_hotkey.Controls.Add(Me.chkshift_skip)
        resources.ApplyResources(Me.pnl_hotkey, "pnl_hotkey")
        Me.pnl_hotkey.Name = "pnl_hotkey"
        '
        'Label119
        '
        resources.ApplyResources(Me.Label119, "Label119")
        Me.Label119.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label119.ForeColor = System.Drawing.SystemColors.Control
        Me.Label119.Name = "Label119"
        '
        'txtreset_ash_key
        '
        Me.txtreset_ash_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.txtreset_ash_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtreset_ash_key, "txtreset_ash_key")
        Me.txtreset_ash_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtreset_ash_key.Name = "txtreset_ash_key"
        Me.txtreset_ash_key.ReadOnly = True
        '
        'txtundo_ash_key
        '
        Me.txtundo_ash_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtundo_ash_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtundo_ash_key, "txtundo_ash_key")
        Me.txtundo_ash_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtundo_ash_key.Name = "txtundo_ash_key"
        Me.txtundo_ash_key.ReadOnly = True
        '
        'txtskip_ash_key
        '
        Me.txtskip_ash_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtskip_ash_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtskip_ash_key, "txtskip_ash_key")
        Me.txtskip_ash_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtskip_ash_key.Name = "txtskip_ash_key"
        Me.txtskip_ash_key.ReadOnly = True
        '
        'Label96
        '
        resources.ApplyResources(Me.Label96, "Label96")
        Me.Label96.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label96.ForeColor = System.Drawing.SystemColors.Control
        Me.Label96.Name = "Label96"
        '
        'numpresstime
        '
        Me.numpresstime.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numpresstime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numpresstime, "numpresstime")
        Me.numpresstime.ForeColor = System.Drawing.SystemColors.Control
        Me.numpresstime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numpresstime.Name = "numpresstime"
        Me.numpresstime.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'txtresume_key
        '
        Me.txtresume_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtresume_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtresume_key, "txtresume_key")
        Me.txtresume_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtresume_key.Name = "txtresume_key"
        Me.txtresume_key.ReadOnly = True
        '
        'Label85
        '
        resources.ApplyResources(Me.Label85, "Label85")
        Me.Label85.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label85.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label85.Name = "Label85"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label28.ForeColor = System.Drawing.SystemColors.Control
        Me.Label28.Name = "Label28"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.SystemColors.Control
        Me.Label7.Name = "Label7"
        '
        'chkalt_resume
        '
        resources.ApplyResources(Me.chkalt_resume, "chkalt_resume")
        Me.chkalt_resume.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkalt_resume.ForeColor = System.Drawing.SystemColors.Control
        Me.chkalt_resume.Name = "chkalt_resume"
        Me.chkalt_resume.UseVisualStyleBackColor = False
        '
        'chkctrl_resume
        '
        resources.ApplyResources(Me.chkctrl_resume, "chkctrl_resume")
        Me.chkctrl_resume.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkctrl_resume.ForeColor = System.Drawing.SystemColors.Control
        Me.chkctrl_resume.Name = "chkctrl_resume"
        Me.chkctrl_resume.UseVisualStyleBackColor = False
        '
        'txtsplit_key
        '
        Me.txtsplit_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtsplit_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtsplit_key, "txtsplit_key")
        Me.txtsplit_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtsplit_key.Name = "txtsplit_key"
        Me.txtsplit_key.ReadOnly = True
        '
        'chkctrl_reset
        '
        resources.ApplyResources(Me.chkctrl_reset, "chkctrl_reset")
        Me.chkctrl_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.chkctrl_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.chkctrl_reset.Name = "chkctrl_reset"
        Me.chkctrl_reset.UseVisualStyleBackColor = False
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label8.ForeColor = System.Drawing.SystemColors.Control
        Me.Label8.Name = "Label8"
        '
        'chkshift_resume
        '
        resources.ApplyResources(Me.chkshift_resume, "chkshift_resume")
        Me.chkshift_resume.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkshift_resume.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshift_resume.Name = "chkshift_resume"
        Me.chkshift_resume.UseVisualStyleBackColor = False
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.SystemColors.Control
        Me.Label9.Name = "Label9"
        '
        'chkalt_reset
        '
        resources.ApplyResources(Me.chkalt_reset, "chkalt_reset")
        Me.chkalt_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.chkalt_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.chkalt_reset.Name = "chkalt_reset"
        Me.chkalt_reset.UseVisualStyleBackColor = False
        '
        'chkundoskip
        '
        resources.ApplyResources(Me.chkundoskip, "chkundoskip")
        Me.chkundoskip.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkundoskip.ForeColor = System.Drawing.SystemColors.Control
        Me.chkundoskip.Name = "chkundoskip"
        Me.chkundoskip.UseVisualStyleBackColor = False
        '
        'txtpause_key
        '
        Me.txtpause_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtpause_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtpause_key, "txtpause_key")
        Me.txtpause_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtpause_key.Name = "txtpause_key"
        Me.txtpause_key.ReadOnly = True
        '
        'txtreset_key
        '
        Me.txtreset_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.txtreset_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtreset_key, "txtreset_key")
        Me.txtreset_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtreset_key.Name = "txtreset_key"
        Me.txtreset_key.ReadOnly = True
        '
        'chkalt
        '
        resources.ApplyResources(Me.chkalt, "chkalt")
        Me.chkalt.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkalt.ForeColor = System.Drawing.SystemColors.Control
        Me.chkalt.Name = "chkalt"
        Me.chkalt.UseVisualStyleBackColor = False
        '
        'chkshift_undo
        '
        resources.ApplyResources(Me.chkshift_undo, "chkshift_undo")
        Me.chkshift_undo.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkshift_undo.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshift_undo.Name = "chkshift_undo"
        Me.chkshift_undo.UseVisualStyleBackColor = False
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label27.ForeColor = System.Drawing.SystemColors.Control
        Me.Label27.Name = "Label27"
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label10.ForeColor = System.Drawing.SystemColors.Control
        Me.Label10.Name = "Label10"
        '
        'chkctrl
        '
        resources.ApplyResources(Me.chkctrl, "chkctrl")
        Me.chkctrl.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkctrl.ForeColor = System.Drawing.SystemColors.Control
        Me.chkctrl.Name = "chkctrl"
        Me.chkctrl.UseVisualStyleBackColor = False
        '
        'chkctrl_undo
        '
        resources.ApplyResources(Me.chkctrl_undo, "chkctrl_undo")
        Me.chkctrl_undo.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkctrl_undo.ForeColor = System.Drawing.SystemColors.Control
        Me.chkctrl_undo.Name = "chkctrl_undo"
        Me.chkctrl_undo.UseVisualStyleBackColor = False
        '
        'chkalt_pause
        '
        resources.ApplyResources(Me.chkalt_pause, "chkalt_pause")
        Me.chkalt_pause.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkalt_pause.ForeColor = System.Drawing.SystemColors.Control
        Me.chkalt_pause.Name = "chkalt_pause"
        Me.chkalt_pause.UseVisualStyleBackColor = False
        '
        'txtundo_key
        '
        Me.txtundo_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtundo_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtundo_key, "txtundo_key")
        Me.txtundo_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtundo_key.Name = "txtundo_key"
        Me.txtundo_key.ReadOnly = True
        '
        'chkshift
        '
        resources.ApplyResources(Me.chkshift, "chkshift")
        Me.chkshift.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkshift.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshift.Name = "chkshift"
        Me.chkshift.UseVisualStyleBackColor = False
        '
        'chkalt_undo
        '
        resources.ApplyResources(Me.chkalt_undo, "chkalt_undo")
        Me.chkalt_undo.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkalt_undo.ForeColor = System.Drawing.SystemColors.Control
        Me.chkalt_undo.Name = "chkalt_undo"
        Me.chkalt_undo.UseVisualStyleBackColor = False
        '
        'chkctrl_pause
        '
        resources.ApplyResources(Me.chkctrl_pause, "chkctrl_pause")
        Me.chkctrl_pause.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkctrl_pause.ForeColor = System.Drawing.SystemColors.Control
        Me.chkctrl_pause.Name = "chkctrl_pause"
        Me.chkctrl_pause.UseVisualStyleBackColor = False
        '
        'txtskip_key
        '
        Me.txtskip_key.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtskip_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtskip_key, "txtskip_key")
        Me.txtskip_key.ForeColor = System.Drawing.SystemColors.Control
        Me.txtskip_key.Name = "txtskip_key"
        Me.txtskip_key.ReadOnly = True
        '
        'chkshift_pause
        '
        resources.ApplyResources(Me.chkshift_pause, "chkshift_pause")
        Me.chkshift_pause.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkshift_pause.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshift_pause.Name = "chkshift_pause"
        Me.chkshift_pause.UseVisualStyleBackColor = False
        '
        'chkalt_skip
        '
        resources.ApplyResources(Me.chkalt_skip, "chkalt_skip")
        Me.chkalt_skip.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkalt_skip.ForeColor = System.Drawing.SystemColors.Control
        Me.chkalt_skip.Name = "chkalt_skip"
        Me.chkalt_skip.UseVisualStyleBackColor = False
        '
        'chkctrl_skip
        '
        resources.ApplyResources(Me.chkctrl_skip, "chkctrl_skip")
        Me.chkctrl_skip.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkctrl_skip.ForeColor = System.Drawing.SystemColors.Control
        Me.chkctrl_skip.Name = "chkctrl_skip"
        Me.chkctrl_skip.UseVisualStyleBackColor = False
        '
        'chknamedpipe
        '
        resources.ApplyResources(Me.chknamedpipe, "chknamedpipe")
        Me.chknamedpipe.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chknamedpipe.ForeColor = System.Drawing.SystemColors.Control
        Me.chknamedpipe.Name = "chknamedpipe"
        Me.chknamedpipe.UseVisualStyleBackColor = False
        '
        'chkshift_reset
        '
        resources.ApplyResources(Me.chkshift_reset, "chkshift_reset")
        Me.chkshift_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.chkshift_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshift_reset.Name = "chkshift_reset"
        Me.chkshift_reset.UseVisualStyleBackColor = False
        '
        'chkshift_skip
        '
        resources.ApplyResources(Me.chkshift_skip, "chkshift_skip")
        Me.chkshift_skip.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.chkshift_skip.ForeColor = System.Drawing.SystemColors.Control
        Me.chkshift_skip.Name = "chkshift_skip"
        Me.chkshift_skip.UseVisualStyleBackColor = False
        '
        'listsetcontents
        '
        Me.listsetcontents.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.listsetcontents.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.listsetcontents, "listsetcontents")
        Me.listsetcontents.ForeColor = System.Drawing.SystemColors.Control
        Me.listsetcontents.FormattingEnabled = True
        Me.listsetcontents.Items.AddRange(New Object() {resources.GetString("listsetcontents.Items"), resources.GetString("listsetcontents.Items1"), resources.GetString("listsetcontents.Items2"), resources.GetString("listsetcontents.Items3"), resources.GetString("listsetcontents.Items4"), resources.GetString("listsetcontents.Items5"), resources.GetString("listsetcontents.Items6"), resources.GetString("listsetcontents.Items7")})
        Me.listsetcontents.Name = "listsetcontents"
        '
        'pnl_cvparameter
        '
        Me.pnl_cvparameter.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_cvparameter.Controls.Add(Me.Label62)
        Me.pnl_cvparameter.Controls.Add(Me.Label81)
        Me.pnl_cvparameter.Controls.Add(Me.Label61)
        Me.pnl_cvparameter.Controls.Add(Me._moji6)
        Me.pnl_cvparameter.Controls.Add(Me.numcv_framerate)
        Me.pnl_cvparameter.Controls.Add(Me.btnconnect_camera)
        Me.pnl_cvparameter.Controls.Add(Me.cmbcv_resolution)
        Me.pnl_cvparameter.Controls.Add(Me.numcv_device)
        Me.pnl_cvparameter.Controls.Add(Me.btnresetup)
        Me.pnl_cvparameter.Controls.Add(Me._moji5)
        Me.pnl_cvparameter.Controls.Add(Me.cmbcv_device)
        resources.ApplyResources(Me.pnl_cvparameter, "pnl_cvparameter")
        Me.pnl_cvparameter.Name = "pnl_cvparameter"
        '
        'Label62
        '
        resources.ApplyResources(Me.Label62, "Label62")
        Me.Label62.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label62.ForeColor = System.Drawing.SystemColors.Control
        Me.Label62.Name = "Label62"
        '
        'Label81
        '
        resources.ApplyResources(Me.Label81, "Label81")
        Me.Label81.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label81.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label81.Name = "Label81"
        '
        'Label61
        '
        resources.ApplyResources(Me.Label61, "Label61")
        Me.Label61.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label61.ForeColor = System.Drawing.SystemColors.Control
        Me.Label61.Name = "Label61"
        '
        '_moji6
        '
        resources.ApplyResources(Me._moji6, "_moji6")
        Me._moji6.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me._moji6.ForeColor = System.Drawing.SystemColors.Control
        Me._moji6.Name = "_moji6"
        '
        'numcv_framerate
        '
        Me.numcv_framerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numcv_framerate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numcv_framerate, "numcv_framerate")
        Me.numcv_framerate.ForeColor = System.Drawing.SystemColors.Control
        Me.numcv_framerate.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.numcv_framerate.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numcv_framerate.Name = "numcv_framerate"
        Me.numcv_framerate.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'btnconnect_camera
        '
        Me.btnconnect_camera.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnconnect_camera, "btnconnect_camera")
        Me.btnconnect_camera.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnconnect_camera.Name = "btnconnect_camera"
        Me.btnconnect_camera.UseVisualStyleBackColor = False
        '
        'cmbcv_resolution
        '
        Me.cmbcv_resolution.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.cmbcv_resolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbcv_resolution, "cmbcv_resolution")
        Me.cmbcv_resolution.ForeColor = System.Drawing.SystemColors.Control
        Me.cmbcv_resolution.FormattingEnabled = True
        Me.cmbcv_resolution.Name = "cmbcv_resolution"
        '
        'numcv_device
        '
        Me.numcv_device.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.numcv_device.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numcv_device.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.AutoSplitHelper_OpenCV.My.MySettings.Default, "numcv_device", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.numcv_device, "numcv_device")
        Me.numcv_device.ForeColor = System.Drawing.SystemColors.Control
        Me.numcv_device.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numcv_device.Minimum = New Decimal(New Integer() {1920, 0, 0, -2147483648})
        Me.numcv_device.Name = "numcv_device"
        Me.numcv_device.Value = Global.AutoSplitHelper_OpenCV.My.MySettings.Default.numcv_device
        '
        'btnresetup
        '
        Me.btnresetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnresetup, "btnresetup")
        Me.btnresetup.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnresetup.Name = "btnresetup"
        Me.btnresetup.UseVisualStyleBackColor = False
        '
        '_moji5
        '
        resources.ApplyResources(Me._moji5, "_moji5")
        Me._moji5.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me._moji5.ForeColor = System.Drawing.SystemColors.Control
        Me._moji5.Name = "_moji5"
        '
        'cmbcv_device
        '
        Me.cmbcv_device.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.cmbcv_device.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbcv_device, "cmbcv_device")
        Me.cmbcv_device.ForeColor = System.Drawing.SystemColors.Control
        Me.cmbcv_device.FormattingEnabled = True
        Me.cmbcv_device.Items.AddRange(New Object() {resources.GetString("cmbcv_device.Items"), resources.GetString("cmbcv_device.Items1"), resources.GetString("cmbcv_device.Items2")})
        Me.cmbcv_device.Name = "cmbcv_device"
        '
        'pnl_focus
        '
        Me.pnl_focus.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_focus.Controls.Add(Me.lblpid_1st)
        Me.pnl_focus.Controls.Add(Me.Label82)
        Me.pnl_focus.Controls.Add(Me.chkactiveapp)
        Me.pnl_focus.Controls.Add(Me.cmbtimer)
        Me.pnl_focus.Controls.Add(Me.btnaddapp2)
        Me.pnl_focus.Controls.Add(Me.numsendsleep)
        Me.pnl_focus.Controls.Add(Me.btngetsomeactive)
        Me.pnl_focus.Controls.Add(Me.chkactivesomeapp)
        Me.pnl_focus.Controls.Add(Me.btndeleteitem_someapp)
        Me.pnl_focus.Controls.Add(Me.btngettimer)
        Me.pnl_focus.Controls.Add(Me.btndelete_timer)
        Me.pnl_focus.Controls.Add(Me.cmbsomeapp)
        Me.pnl_focus.Controls.Add(Me.btnaddapp1)
        Me.pnl_focus.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.pnl_focus, "pnl_focus")
        Me.pnl_focus.Name = "pnl_focus"
        '
        'lblpid_1st
        '
        resources.ApplyResources(Me.lblpid_1st, "lblpid_1st")
        Me.lblpid_1st.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblpid_1st.ForeColor = System.Drawing.Color.LightGray
        Me.lblpid_1st.Name = "lblpid_1st"
        '
        'Label82
        '
        resources.ApplyResources(Me.Label82, "Label82")
        Me.Label82.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label82.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label82.Name = "Label82"
        '
        'chkactiveapp
        '
        resources.ApplyResources(Me.chkactiveapp, "chkactiveapp")
        Me.chkactiveapp.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkactiveapp.ForeColor = System.Drawing.SystemColors.Control
        Me.chkactiveapp.Name = "chkactiveapp"
        Me.chkactiveapp.UseVisualStyleBackColor = False
        '
        'cmbtimer
        '
        Me.cmbtimer.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.cmbtimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbtimer, "cmbtimer")
        Me.cmbtimer.ForeColor = System.Drawing.SystemColors.Control
        Me.cmbtimer.FormattingEnabled = True
        Me.cmbtimer.Name = "cmbtimer"
        '
        'btnaddapp2
        '
        Me.btnaddapp2.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnaddapp2, "btnaddapp2")
        Me.btnaddapp2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnaddapp2.Name = "btnaddapp2"
        Me.btnaddapp2.UseVisualStyleBackColor = False
        '
        'numsendsleep
        '
        Me.numsendsleep.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numsendsleep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numsendsleep, "numsendsleep")
        Me.numsendsleep.ForeColor = System.Drawing.SystemColors.Control
        Me.numsendsleep.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numsendsleep.Name = "numsendsleep"
        Me.numsendsleep.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'btngetsomeactive
        '
        Me.btngetsomeactive.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btngetsomeactive, "btngetsomeactive")
        Me.btngetsomeactive.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btngetsomeactive.Name = "btngetsomeactive"
        Me.btngetsomeactive.UseVisualStyleBackColor = False
        '
        'chkactivesomeapp
        '
        resources.ApplyResources(Me.chkactivesomeapp, "chkactivesomeapp")
        Me.chkactivesomeapp.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.chkactivesomeapp.ForeColor = System.Drawing.SystemColors.Control
        Me.chkactivesomeapp.Name = "chkactivesomeapp"
        Me.chkactivesomeapp.UseVisualStyleBackColor = False
        '
        'btndeleteitem_someapp
        '
        Me.btndeleteitem_someapp.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btndeleteitem_someapp, "btndeleteitem_someapp")
        Me.btndeleteitem_someapp.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btndeleteitem_someapp.Name = "btndeleteitem_someapp"
        Me.btndeleteitem_someapp.UseVisualStyleBackColor = False
        '
        'btngettimer
        '
        Me.btngettimer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btngettimer, "btngettimer")
        Me.btngettimer.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btngettimer.Name = "btngettimer"
        Me.btngettimer.UseVisualStyleBackColor = False
        '
        'btndelete_timer
        '
        Me.btndelete_timer.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btndelete_timer, "btndelete_timer")
        Me.btndelete_timer.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btndelete_timer.Name = "btndelete_timer"
        Me.btndelete_timer.UseVisualStyleBackColor = False
        '
        'cmbsomeapp
        '
        Me.cmbsomeapp.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.cmbsomeapp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbsomeapp, "cmbsomeapp")
        Me.cmbsomeapp.ForeColor = System.Drawing.SystemColors.Control
        Me.cmbsomeapp.FormattingEnabled = True
        Me.cmbsomeapp.Name = "cmbsomeapp"
        '
        'btnaddapp1
        '
        Me.btnaddapp1.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnaddapp1, "btnaddapp1")
        Me.btnaddapp1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnaddapp1.Name = "btnaddapp1"
        Me.btnaddapp1.UseVisualStyleBackColor = False
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Name = "Label1"
        '
        'pnl_graph
        '
        Me.pnl_graph.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_graph.Controls.Add(Me.chkrename_livesplit)
        Me.pnl_graph.Controls.Add(Me.Label88)
        Me.pnl_graph.Controls.Add(Me.btnreset_livesplit)
        Me.pnl_graph.Controls.Add(Me.Label67)
        Me.pnl_graph.Controls.Add(Me.numgraph_first)
        Me.pnl_graph.Controls.Add(Me.btnreset_table)
        Me.pnl_graph.Controls.Add(Me.btnreset_count)
        resources.ApplyResources(Me.pnl_graph, "pnl_graph")
        Me.pnl_graph.Name = "pnl_graph"
        '
        'chkrename_livesplit
        '
        resources.ApplyResources(Me.chkrename_livesplit, "chkrename_livesplit")
        Me.chkrename_livesplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkrename_livesplit.ForeColor = System.Drawing.SystemColors.Control
        Me.chkrename_livesplit.Name = "chkrename_livesplit"
        Me.chkrename_livesplit.UseVisualStyleBackColor = False
        '
        'Label88
        '
        resources.ApplyResources(Me.Label88, "Label88")
        Me.Label88.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label88.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label88.Name = "Label88"
        '
        'btnreset_livesplit
        '
        Me.btnreset_livesplit.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnreset_livesplit, "btnreset_livesplit")
        Me.btnreset_livesplit.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnreset_livesplit.Name = "btnreset_livesplit"
        Me.btnreset_livesplit.UseVisualStyleBackColor = False
        '
        'Label67
        '
        resources.ApplyResources(Me.Label67, "Label67")
        Me.Label67.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label67.ForeColor = System.Drawing.SystemColors.Control
        Me.Label67.Name = "Label67"
        '
        'numgraph_first
        '
        Me.numgraph_first.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numgraph_first.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numgraph_first, "numgraph_first")
        Me.numgraph_first.ForeColor = System.Drawing.SystemColors.Control
        Me.numgraph_first.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numgraph_first.Name = "numgraph_first"
        Me.numgraph_first.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'btnreset_table
        '
        Me.btnreset_table.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnreset_table, "btnreset_table")
        Me.btnreset_table.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnreset_table.Name = "btnreset_table"
        Me.btnreset_table.UseVisualStyleBackColor = False
        '
        'btnreset_count
        '
        Me.btnreset_count.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnreset_count, "btnreset_count")
        Me.btnreset_count.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnreset_count.Name = "btnreset_count"
        Me.btnreset_count.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkmonitor_sizestate)
        Me.GroupBox2.Controls.Add(Me.numtextwindow_sizex)
        Me.GroupBox2.Controls.Add(Me.lblcheckopening)
        Me.GroupBox2.Controls.Add(Me.numtextwindow_sizey)
        Me.GroupBox2.Controls.Add(Me.numprofile)
        Me.GroupBox2.Controls.Add(Me.Label38)
        Me.GroupBox2.Controls.Add(Me.txtclickcount)
        Me.GroupBox2.Controls.Add(Me.txtprofile)
        Me.GroupBox2.Controls.Add(Me.txtloadprofile)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Controls.Add(Me.txttemp_picturepass)
        Me.GroupBox2.Controls.Add(Me.Label71)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Cornsilk
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'chkmonitor_sizestate
        '
        resources.ApplyResources(Me.chkmonitor_sizestate, "chkmonitor_sizestate")
        Me.chkmonitor_sizestate.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkmonitor_sizestate.Checked = True
        Me.chkmonitor_sizestate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkmonitor_sizestate.ForeColor = System.Drawing.SystemColors.Control
        Me.chkmonitor_sizestate.Name = "chkmonitor_sizestate"
        Me.chkmonitor_sizestate.UseVisualStyleBackColor = False
        '
        'numtextwindow_sizex
        '
        resources.ApplyResources(Me.numtextwindow_sizex, "numtextwindow_sizex")
        Me.numtextwindow_sizex.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numtextwindow_sizex.Name = "numtextwindow_sizex"
        Me.numtextwindow_sizex.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblcheckopening
        '
        resources.ApplyResources(Me.lblcheckopening, "lblcheckopening")
        Me.lblcheckopening.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcheckopening.Name = "lblcheckopening"
        '
        'numtextwindow_sizey
        '
        resources.ApplyResources(Me.numtextwindow_sizey, "numtextwindow_sizey")
        Me.numtextwindow_sizey.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numtextwindow_sizey.Name = "numtextwindow_sizey"
        Me.numtextwindow_sizey.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numprofile
        '
        Me.numprofile.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.numprofile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numprofile.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.AutoSplitHelper_OpenCV.My.MySettings.Default, "numprofile", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.numprofile, "numprofile")
        Me.numprofile.ForeColor = System.Drawing.SystemColors.Control
        Me.numprofile.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numprofile.Minimum = New Decimal(New Integer() {1920, 0, 0, -2147483648})
        Me.numprofile.Name = "numprofile"
        Me.numprofile.Value = Global.AutoSplitHelper_OpenCV.My.MySettings.Default.numprofile
        '
        'Label38
        '
        resources.ApplyResources(Me.Label38, "Label38")
        Me.Label38.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label38.ForeColor = System.Drawing.SystemColors.Control
        Me.Label38.Name = "Label38"
        '
        'txtclickcount
        '
        Me.txtclickcount.BackColor = System.Drawing.SystemColors.ButtonFace
        resources.ApplyResources(Me.txtclickcount, "txtclickcount")
        Me.txtclickcount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtclickcount.Name = "txtclickcount"
        Me.txtclickcount.ReadOnly = True
        '
        'txtprofile
        '
        resources.ApplyResources(Me.txtprofile, "txtprofile")
        Me.txtprofile.Name = "txtprofile"
        '
        'txtloadprofile
        '
        resources.ApplyResources(Me.txtloadprofile, "txtloadprofile")
        Me.txtloadprofile.Name = "txtloadprofile"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.numskip_ash)
        Me.GroupBox3.Controls.Add(Me.numundo_ash)
        Me.GroupBox3.Controls.Add(Me.numreset_ash)
        Me.GroupBox3.Controls.Add(Me.lblkeysforresume)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.numcv_sizex)
        Me.GroupBox3.Controls.Add(Me.lblkeysforpause)
        Me.GroupBox3.Controls.Add(Me.numcv_sizey)
        Me.GroupBox3.Controls.Add(Me.numsavex)
        Me.GroupBox3.Controls.Add(Me.numsavey)
        Me.GroupBox3.Controls.Add(Me.lblkeysforsend)
        Me.GroupBox3.Controls.Add(Me.lblkeysforsend_reset)
        Me.GroupBox3.Controls.Add(Me.lblkeysforskip)
        Me.GroupBox3.Controls.Add(Me.lblkeysforundo)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Cornsilk
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'numskip_ash
        '
        resources.ApplyResources(Me.numskip_ash, "numskip_ash")
        Me.numskip_ash.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numskip_ash.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numskip_ash.Name = "numskip_ash"
        Me.numskip_ash.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numundo_ash
        '
        resources.ApplyResources(Me.numundo_ash, "numundo_ash")
        Me.numundo_ash.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numundo_ash.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numundo_ash.Name = "numundo_ash"
        Me.numundo_ash.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numreset_ash
        '
        resources.ApplyResources(Me.numreset_ash, "numreset_ash")
        Me.numreset_ash.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numreset_ash.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
        Me.numreset_ash.Name = "numreset_ash"
        Me.numreset_ash.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'lblkeysforresume
        '
        resources.ApplyResources(Me.lblkeysforresume, "lblkeysforresume")
        Me.lblkeysforresume.BackColor = System.Drawing.Color.Maroon
        Me.lblkeysforresume.ForeColor = System.Drawing.SystemColors.Control
        Me.lblkeysforresume.Name = "lblkeysforresume"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label24.ForeColor = System.Drawing.SystemColors.Control
        Me.Label24.Name = "Label24"
        '
        'numcv_sizex
        '
        resources.ApplyResources(Me.numcv_sizex, "numcv_sizex")
        Me.numcv_sizex.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numcv_sizex.Name = "numcv_sizex"
        Me.numcv_sizex.Value = New Decimal(New Integer() {480, 0, 0, 0})
        '
        'lblkeysforpause
        '
        resources.ApplyResources(Me.lblkeysforpause, "lblkeysforpause")
        Me.lblkeysforpause.BackColor = System.Drawing.Color.Red
        Me.lblkeysforpause.ForeColor = System.Drawing.SystemColors.Control
        Me.lblkeysforpause.Name = "lblkeysforpause"
        '
        'numcv_sizey
        '
        resources.ApplyResources(Me.numcv_sizey, "numcv_sizey")
        Me.numcv_sizey.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numcv_sizey.Name = "numcv_sizey"
        Me.numcv_sizey.Value = New Decimal(New Integer() {270, 0, 0, 0})
        '
        'numsavex
        '
        Me.numsavex.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.AutoSplitHelper_OpenCV.My.MySettings.Default, "numsavex", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.numsavex, "numsavex")
        Me.numsavex.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numsavex.Minimum = New Decimal(New Integer() {99999, 0, 0, -2147483648})
        Me.numsavex.Name = "numsavex"
        Me.numsavex.Value = Global.AutoSplitHelper_OpenCV.My.MySettings.Default.numsavex
        '
        'numsavey
        '
        Me.numsavey.DataBindings.Add(New System.Windows.Forms.Binding("Value", Global.AutoSplitHelper_OpenCV.My.MySettings.Default, "numsavey", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        resources.ApplyResources(Me.numsavey, "numsavey")
        Me.numsavey.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numsavey.Minimum = New Decimal(New Integer() {99999, 0, 0, -2147483648})
        Me.numsavey.Name = "numsavey"
        Me.numsavey.Value = Global.AutoSplitHelper_OpenCV.My.MySettings.Default.numsavey
        '
        'lblkeysforsend
        '
        resources.ApplyResources(Me.lblkeysforsend, "lblkeysforsend")
        Me.lblkeysforsend.BackColor = System.Drawing.Color.Red
        Me.lblkeysforsend.ForeColor = System.Drawing.SystemColors.Control
        Me.lblkeysforsend.Name = "lblkeysforsend"
        '
        'lblkeysforsend_reset
        '
        resources.ApplyResources(Me.lblkeysforsend_reset, "lblkeysforsend_reset")
        Me.lblkeysforsend_reset.BackColor = System.Drawing.Color.Maroon
        Me.lblkeysforsend_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.lblkeysforsend_reset.Name = "lblkeysforsend_reset"
        '
        'lblkeysforskip
        '
        resources.ApplyResources(Me.lblkeysforskip, "lblkeysforskip")
        Me.lblkeysforskip.BackColor = System.Drawing.Color.Maroon
        Me.lblkeysforskip.ForeColor = System.Drawing.SystemColors.Control
        Me.lblkeysforskip.Name = "lblkeysforskip"
        '
        'lblkeysforundo
        '
        resources.ApplyResources(Me.lblkeysforundo, "lblkeysforundo")
        Me.lblkeysforundo.BackColor = System.Drawing.Color.Red
        Me.lblkeysforundo.ForeColor = System.Drawing.SystemColors.Control
        Me.lblkeysforundo.Name = "lblkeysforundo"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.txtsavetempnumber)
        Me.Panel5.Controls.Add(Me.numtemp)
        Me.Panel5.Controls.Add(Me.txt11)
        Me.Panel5.Controls.Add(Me.txt22)
        Me.Panel5.Controls.Add(Me.txt12)
        Me.Panel5.Controls.Add(Me.txt21)
        resources.ApplyResources(Me.Panel5, "Panel5")
        Me.Panel5.Name = "Panel5"
        '
        'txtsavetempnumber
        '
        resources.ApplyResources(Me.txtsavetempnumber, "txtsavetempnumber")
        Me.txtsavetempnumber.BackColor = System.Drawing.Color.Snow
        Me.txtsavetempnumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsavetempnumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtsavetempnumber.Name = "txtsavetempnumber"
        Me.txtsavetempnumber.ReadOnly = True
        '
        'numtemp
        '
        resources.ApplyResources(Me.numtemp, "numtemp")
        Me.numtemp.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.numtemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.numtemp.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.numtemp.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
        Me.numtemp.Name = "numtemp"
        '
        'txt11
        '
        Me.txt11.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        resources.ApplyResources(Me.txt11, "txt11")
        Me.txt11.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txt11.Name = "txt11"
        Me.txt11.ReadOnly = True
        '
        'txt22
        '
        Me.txt22.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        resources.ApplyResources(Me.txt22, "txt22")
        Me.txt22.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txt22.Name = "txt22"
        Me.txt22.ReadOnly = True
        '
        'txt12
        '
        Me.txt12.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        resources.ApplyResources(Me.txt12, "txt12")
        Me.txt12.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txt12.Name = "txt12"
        Me.txt12.ReadOnly = True
        '
        'txt21
        '
        Me.txt21.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(34, Byte), Integer))
        resources.ApplyResources(Me.txt21, "txt21")
        Me.txt21.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txt21.Name = "txt21"
        Me.txt21.ReadOnly = True
        '
        'txttemp_picturepass
        '
        Me.txttemp_picturepass.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txttemp_picturepass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txttemp_picturepass, "txttemp_picturepass")
        Me.txttemp_picturepass.ForeColor = System.Drawing.SystemColors.Control
        Me.txttemp_picturepass.Name = "txttemp_picturepass"
        Me.txttemp_picturepass.ReadOnly = True
        '
        'Label71
        '
        resources.ApplyResources(Me.Label71, "Label71")
        Me.Label71.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.Label71.ForeColor = System.Drawing.SystemColors.Control
        Me.Label71.Name = "Label71"
        '
        'pnl_parameter
        '
        Me.pnl_parameter.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnl_parameter.Controls.Add(Me._moji1)
        Me.pnl_parameter.Controls.Add(Me.Label2)
        Me.pnl_parameter.Controls.Add(Me.Label20)
        Me.pnl_parameter.Controls.Add(Me._moji3)
        Me.pnl_parameter.Controls.Add(Me.btninsertanten)
        Me.pnl_parameter.Controls.Add(Me.numanten)
        Me.pnl_parameter.Controls.Add(Me.chkcv_loop)
        Me.pnl_parameter.Controls.Add(Me.btninsertitti)
        Me.pnl_parameter.Controls.Add(Me.chkcv_resetonoff)
        Me.pnl_parameter.Controls.Add(Me.btninsertsleep)
        Me.pnl_parameter.Controls.Add(Me.numstop)
        Me.pnl_parameter.Controls.Add(Me.numloopcount)
        Me.pnl_parameter.Controls.Add(Me.numcv_interval)
        Me.pnl_parameter.Controls.Add(Me._moji2)
        Me.pnl_parameter.Controls.Add(Me.chkcv_loadremover)
        Me.pnl_parameter.Controls.Add(Me.numpercent)
        Me.pnl_parameter.Controls.Add(Me.chkcv_monitor)
        resources.ApplyResources(Me.pnl_parameter, "pnl_parameter")
        Me.pnl_parameter.Name = "pnl_parameter"
        '
        '_moji1
        '
        resources.ApplyResources(Me._moji1, "_moji1")
        Me._moji1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me._moji1.ForeColor = System.Drawing.SystemColors.Control
        Me._moji1.Name = "_moji1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Name = "Label2"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label20.Name = "Label20"
        '
        '_moji3
        '
        resources.ApplyResources(Me._moji3, "_moji3")
        Me._moji3.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me._moji3.ForeColor = System.Drawing.SystemColors.Control
        Me._moji3.Name = "_moji3"
        '
        'btninsertanten
        '
        Me.btninsertanten.BackColor = System.Drawing.Color.Lavender
        resources.ApplyResources(Me.btninsertanten, "btninsertanten")
        Me.btninsertanten.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btninsertanten.Name = "btninsertanten"
        Me.btninsertanten.UseVisualStyleBackColor = False
        '
        'numanten
        '
        Me.numanten.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numanten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numanten, "numanten")
        Me.numanten.ForeColor = System.Drawing.SystemColors.Control
        Me.numanten.Maximum = New Decimal(New Integer() {128, 0, 0, 0})
        Me.numanten.Name = "numanten"
        Me.numanten.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'chkcv_loop
        '
        resources.ApplyResources(Me.chkcv_loop, "chkcv_loop")
        Me.chkcv_loop.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkcv_loop.ForeColor = System.Drawing.SystemColors.Control
        Me.chkcv_loop.Name = "chkcv_loop"
        Me.chkcv_loop.UseVisualStyleBackColor = False
        '
        'btninsertitti
        '
        Me.btninsertitti.BackColor = System.Drawing.Color.Lavender
        resources.ApplyResources(Me.btninsertitti, "btninsertitti")
        Me.btninsertitti.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btninsertitti.Name = "btninsertitti"
        Me.btninsertitti.UseVisualStyleBackColor = False
        '
        'chkcv_resetonoff
        '
        resources.ApplyResources(Me.chkcv_resetonoff, "chkcv_resetonoff")
        Me.chkcv_resetonoff.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.chkcv_resetonoff.ForeColor = System.Drawing.SystemColors.Control
        Me.chkcv_resetonoff.Name = "chkcv_resetonoff"
        Me.chkcv_resetonoff.UseVisualStyleBackColor = False
        '
        'btninsertsleep
        '
        Me.btninsertsleep.BackColor = System.Drawing.Color.Lavender
        resources.ApplyResources(Me.btninsertsleep, "btninsertsleep")
        Me.btninsertsleep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btninsertsleep.Name = "btninsertsleep"
        Me.btninsertsleep.UseVisualStyleBackColor = False
        '
        'numstop
        '
        Me.numstop.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numstop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numstop, "numstop")
        Me.numstop.ForeColor = System.Drawing.SystemColors.Control
        Me.numstop.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numstop.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numstop.Name = "numstop"
        Me.numstop.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'numloopcount
        '
        Me.numloopcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numloopcount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numloopcount, "numloopcount")
        Me.numloopcount.ForeColor = System.Drawing.SystemColors.Control
        Me.numloopcount.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numloopcount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numloopcount.Name = "numloopcount"
        Me.numloopcount.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'numcv_interval
        '
        Me.numcv_interval.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numcv_interval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numcv_interval, "numcv_interval")
        Me.numcv_interval.ForeColor = System.Drawing.SystemColors.Control
        Me.numcv_interval.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numcv_interval.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numcv_interval.Name = "numcv_interval"
        Me.numcv_interval.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        '_moji2
        '
        resources.ApplyResources(Me._moji2, "_moji2")
        Me._moji2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me._moji2.ForeColor = System.Drawing.SystemColors.Control
        Me._moji2.Name = "_moji2"
        '
        'chkcv_loadremover
        '
        resources.ApplyResources(Me.chkcv_loadremover, "chkcv_loadremover")
        Me.chkcv_loadremover.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.chkcv_loadremover.ForeColor = System.Drawing.SystemColors.Control
        Me.chkcv_loadremover.Name = "chkcv_loadremover"
        Me.chkcv_loadremover.UseVisualStyleBackColor = False
        '
        'numpercent
        '
        Me.numpercent.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numpercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numpercent, "numpercent")
        Me.numpercent.ForeColor = System.Drawing.SystemColors.Control
        Me.numpercent.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numpercent.Name = "numpercent"
        Me.numpercent.Value = New Decimal(New Integer() {40, 0, 0, 0})
        '
        'chkcv_monitor
        '
        resources.ApplyResources(Me.chkcv_monitor, "chkcv_monitor")
        Me.chkcv_monitor.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkcv_monitor.ForeColor = System.Drawing.SystemColors.Control
        Me.chkcv_monitor.Name = "chkcv_monitor"
        Me.chkcv_monitor.UseVisualStyleBackColor = False
        '
        'btnstartopencv
        '
        Me.btnstartopencv.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(148, Byte), Integer))
        resources.ApplyResources(Me.btnstartopencv, "btnstartopencv")
        Me.btnstartopencv.Name = "btnstartopencv"
        Me.btnstartopencv.UseVisualStyleBackColor = False
        '
        'btndeleteprofile
        '
        Me.btndeleteprofile.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        resources.ApplyResources(Me.btndeleteprofile, "btndeleteprofile")
        Me.btndeleteprofile.ForeColor = System.Drawing.Color.DarkGray
        Me.btndeleteprofile.Image = Global.AutoSplitHelper_OpenCV.My.Resources.Resources.delete1
        Me.btndeleteprofile.Name = "btndeleteprofile"
        Me.btndeleteprofile.UseVisualStyleBackColor = False
        '
        'btnaddprofile
        '
        Me.btnaddprofile.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        resources.ApplyResources(Me.btnaddprofile, "btnaddprofile")
        Me.btnaddprofile.ForeColor = System.Drawing.Color.DarkGray
        Me.btnaddprofile.Image = Global.AutoSplitHelper_OpenCV.My.Resources.Resources.save2
        Me.btnaddprofile.Name = "btnaddprofile"
        Me.btnaddprofile.UseVisualStyleBackColor = False
        '
        'cmbprofile
        '
        Me.cmbprofile.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        resources.ApplyResources(Me.cmbprofile, "cmbprofile")
        Me.cmbprofile.ForeColor = System.Drawing.SystemColors.Control
        Me.cmbprofile.FormattingEnabled = True
        Me.cmbprofile.Name = "cmbprofile"
        '
        'MenuStrip1
        '
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.ToolToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewProfileToolStripMenuItem, Me.ImportToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveProfileSToolStripMenuItem, Me.DeleteSelectedProfileToolStripMenuItem, Me.ToolStripSeparator4, Me.UploadTheCurrentProfileUToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        resources.ApplyResources(Me.MenuToolStripMenuItem, "MenuToolStripMenuItem")
        '
        'NewProfileToolStripMenuItem
        '
        Me.NewProfileToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.NewProfileToolStripMenuItem.Name = "NewProfileToolStripMenuItem"
        resources.ApplyResources(Me.NewProfileToolStripMenuItem, "NewProfileToolStripMenuItem")
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        resources.ApplyResources(Me.ImportToolStripMenuItem, "ImportToolStripMenuItem")
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        resources.ApplyResources(Me.ToolStripSeparator1, "ToolStripSeparator1")
        '
        'SaveProfileSToolStripMenuItem
        '
        Me.SaveProfileSToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.SaveProfileSToolStripMenuItem.Name = "SaveProfileSToolStripMenuItem"
        resources.ApplyResources(Me.SaveProfileSToolStripMenuItem, "SaveProfileSToolStripMenuItem")
        '
        'DeleteSelectedProfileToolStripMenuItem
        '
        Me.DeleteSelectedProfileToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.DeleteSelectedProfileToolStripMenuItem.Name = "DeleteSelectedProfileToolStripMenuItem"
        resources.ApplyResources(Me.DeleteSelectedProfileToolStripMenuItem, "DeleteSelectedProfileToolStripMenuItem")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'UploadTheCurrentProfileUToolStripMenuItem
        '
        Me.UploadTheCurrentProfileUToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.UploadTheCurrentProfileUToolStripMenuItem.Name = "UploadTheCurrentProfileUToolStripMenuItem"
        resources.ApplyResources(Me.UploadTheCurrentProfileUToolStripMenuItem, "UploadTheCurrentProfileUToolStripMenuItem")
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        resources.ApplyResources(Me.ToolStripSeparator5, "ToolStripSeparator5")
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        resources.ApplyResources(Me.ExitToolStripMenuItem, "ExitToolStripMenuItem")
        '
        'ToolToolStripMenuItem
        '
        Me.ToolToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartMonitoringMToolStripMenuItem, Me.ToolStripSeparator6, Me.PreviewGetTemplatePictureToolStripMenuItem, Me.CalibrationToolStripMenuItem1, Me.PositionSettingToolStripMenuItem, Me.ToolStripSeparator3, Me.ExpandTableToolStripMenuItem, Me.ToolStripSeparator7, Me.ViewTableToolStripMenuItem, Me.ToolStripSeparator2, Me.OpenTextWindowWToolStripMenuItem, Me.CreateTextFileToolStripMenuItem, Me.OpenTextFolderToolStripMenuItem, Me.DeleteAddTemplateImageToolStripMenuItem})
        Me.ToolToolStripMenuItem.Name = "ToolToolStripMenuItem"
        resources.ApplyResources(Me.ToolToolStripMenuItem, "ToolToolStripMenuItem")
        '
        'StartMonitoringMToolStripMenuItem
        '
        Me.StartMonitoringMToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.StartMonitoringMToolStripMenuItem.Name = "StartMonitoringMToolStripMenuItem"
        resources.ApplyResources(Me.StartMonitoringMToolStripMenuItem, "StartMonitoringMToolStripMenuItem")
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        resources.ApplyResources(Me.ToolStripSeparator6, "ToolStripSeparator6")
        '
        'PreviewGetTemplatePictureToolStripMenuItem
        '
        Me.PreviewGetTemplatePictureToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.PreviewGetTemplatePictureToolStripMenuItem.Name = "PreviewGetTemplatePictureToolStripMenuItem"
        resources.ApplyResources(Me.PreviewGetTemplatePictureToolStripMenuItem, "PreviewGetTemplatePictureToolStripMenuItem")
        '
        'CalibrationToolStripMenuItem1
        '
        Me.CalibrationToolStripMenuItem1.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.CalibrationToolStripMenuItem1.Name = "CalibrationToolStripMenuItem1"
        resources.ApplyResources(Me.CalibrationToolStripMenuItem1, "CalibrationToolStripMenuItem1")
        '
        'PositionSettingToolStripMenuItem
        '
        Me.PositionSettingToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.PositionSettingToolStripMenuItem.Name = "PositionSettingToolStripMenuItem"
        resources.ApplyResources(Me.PositionSettingToolStripMenuItem, "PositionSettingToolStripMenuItem")
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        resources.ApplyResources(Me.ToolStripSeparator3, "ToolStripSeparator3")
        '
        'ExpandTableToolStripMenuItem
        '
        Me.ExpandTableToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ExpandTableToolStripMenuItem.Name = "ExpandTableToolStripMenuItem"
        resources.ApplyResources(Me.ExpandTableToolStripMenuItem, "ExpandTableToolStripMenuItem")
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        resources.ApplyResources(Me.ToolStripSeparator7, "ToolStripSeparator7")
        '
        'ViewTableToolStripMenuItem
        '
        Me.ViewTableToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.ViewTableToolStripMenuItem.Name = "ViewTableToolStripMenuItem"
        resources.ApplyResources(Me.ViewTableToolStripMenuItem, "ViewTableToolStripMenuItem")
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
        '
        'OpenTextWindowWToolStripMenuItem
        '
        Me.OpenTextWindowWToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.OpenTextWindowWToolStripMenuItem.Name = "OpenTextWindowWToolStripMenuItem"
        resources.ApplyResources(Me.OpenTextWindowWToolStripMenuItem, "OpenTextWindowWToolStripMenuItem")
        '
        'CreateTextFileToolStripMenuItem
        '
        Me.CreateTextFileToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.CreateTextFileToolStripMenuItem.Name = "CreateTextFileToolStripMenuItem"
        resources.ApplyResources(Me.CreateTextFileToolStripMenuItem, "CreateTextFileToolStripMenuItem")
        '
        'OpenTextFolderToolStripMenuItem
        '
        Me.OpenTextFolderToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.OpenTextFolderToolStripMenuItem.Name = "OpenTextFolderToolStripMenuItem"
        resources.ApplyResources(Me.OpenTextFolderToolStripMenuItem, "OpenTextFolderToolStripMenuItem")
        '
        'DeleteAddTemplateImageToolStripMenuItem
        '
        Me.DeleteAddTemplateImageToolStripMenuItem.Name = "DeleteAddTemplateImageToolStripMenuItem"
        resources.ApplyResources(Me.DeleteAddTemplateImageToolStripMenuItem, "DeleteAddTemplateImageToolStripMenuItem")
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InformationToolStripMenuItem, Me.LicenseLToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        resources.ApplyResources(Me.HelpToolStripMenuItem, "HelpToolStripMenuItem")
        '
        'InformationToolStripMenuItem
        '
        Me.InformationToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.InformationToolStripMenuItem.Name = "InformationToolStripMenuItem"
        resources.ApplyResources(Me.InformationToolStripMenuItem, "InformationToolStripMenuItem")
        '
        'LicenseLToolStripMenuItem
        '
        Me.LicenseLToolStripMenuItem.Margin = New System.Windows.Forms.Padding(0, 3, 0, 3)
        Me.LicenseLToolStripMenuItem.Name = "LicenseLToolStripMenuItem"
        resources.ApplyResources(Me.LicenseLToolStripMenuItem, "LicenseLToolStripMenuItem")
        '
        'picunder
        '
        Me.picunder.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(105, Byte), Integer))
        resources.ApplyResources(Me.picunder, "picunder")
        Me.picunder.Name = "picunder"
        Me.picunder.TabStop = False
        '
        'btnclose_general
        '
        Me.btnclose_general.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(47, Byte), Integer))
        resources.ApplyResources(Me.btnclose_general, "btnclose_general")
        Me.btnclose_general.ForeColor = System.Drawing.Color.LightGray
        Me.btnclose_general.Name = "btnclose_general"
        Me.btnclose_general.UseVisualStyleBackColor = False
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.TabPage5.Controls.Add(Me.PictureBox3)
        Me.TabPage5.Controls.Add(Me.PictureBox4)
        Me.TabPage5.Controls.Add(Me.Label77)
        Me.TabPage5.Controls.Add(Me.lbllooptrigger)
        Me.TabPage5.Controls.Add(Me.numnowloop)
        Me.TabPage5.Controls.Add(Me.lblloopcount)
        Me.TabPage5.Controls.Add(Me.Label73)
        Me.TabPage5.Controls.Add(Me.Label74)
        Me.TabPage5.Controls.Add(Me.lblresetcount)
        Me.TabPage5.Controls.Add(Me.lblattemptcount)
        Me.TabPage5.Controls.Add(Me.lbllapcount)
        Me.TabPage5.Controls.Add(Me.Label68)
        Me.TabPage5.Controls.Add(Me.Label69)
        Me.TabPage5.Controls.Add(Me.Label70)
        Me.TabPage5.Controls.Add(Me.lblreload_graph)
        Me.TabPage5.Controls.Add(Me.txtsetsplitname)
        Me.TabPage5.Controls.Add(Me.Label63)
        Me.TabPage5.Controls.Add(Me.cmbloadno)
        Me.TabPage5.Controls.Add(Me.GroupBox8)
        Me.TabPage5.Controls.Add(Me.chknow_load10)
        Me.TabPage5.Controls.Add(Me.chknow_load9)
        Me.TabPage5.Controls.Add(Me.chknow_load8)
        Me.TabPage5.Controls.Add(Me.chknow_load7)
        Me.TabPage5.Controls.Add(Me.chknow_load6)
        Me.TabPage5.Controls.Add(Me.chknow_load5)
        Me.TabPage5.Controls.Add(Me.chknow_load4)
        Me.TabPage5.Controls.Add(Me.chknow_load3)
        Me.TabPage5.Controls.Add(Me.chknow_load2)
        Me.TabPage5.Controls.Add(Me.chknow_load1)
        Me.TabPage5.Controls.Add(Me.txtdelay_load)
        Me.TabPage5.Controls.Add(Me.chknow_monitor)
        Me.TabPage5.Controls.Add(Me.chknow_load)
        Me.TabPage5.Controls.Add(Me.chknow_reset)
        Me.TabPage5.Controls.Add(Me.txtrecord_load)
        Me.TabPage5.Controls.Add(Me.lblrecord_pause_total)
        Me.TabPage5.Controls.Add(Me.lblrecord_pause)
        Me.TabPage5.Controls.Add(Me.txtrecord_load_total)
        Me.TabPage5.Controls.Add(Me.Label30)
        Me.TabPage5.Controls.Add(Me.Label34)
        Me.TabPage5.Controls.Add(Me.txtcv_ikiti_load)
        Me.TabPage5.Controls.Add(Me.lblcv_nowmaxval_load)
        Me.TabPage5.Controls.Add(Me.lblcv_maxval_load)
        Me.TabPage5.Controls.Add(Me.lblsleeptime)
        Me.TabPage5.Controls.Add(Me.lblloading)
        Me.TabPage5.Controls.Add(Me.txtcv_result_sizey)
        Me.TabPage5.Controls.Add(Me.txtcv_result_sizex)
        Me.TabPage5.Controls.Add(Me.txtcv_result_posy)
        Me.TabPage5.Controls.Add(Me.txtcv_result_posx)
        Me.TabPage5.Controls.Add(Me.txtcompikiti)
        Me.TabPage5.Controls.Add(Me.txtstate)
        Me.TabPage5.Controls.Add(Me.Label3)
        Me.TabPage5.Controls.Add(Me.txtcv_result)
        Me.TabPage5.Controls.Add(Me.btncv_downsize)
        Me.TabPage5.Controls.Add(Me.btncv_first)
        Me.TabPage5.Controls.Add(Me.lblcv_lap)
        Me.TabPage5.Controls.Add(Me.Label52)
        Me.TabPage5.Controls.Add(Me.Label53)
        Me.TabPage5.Controls.Add(Me.txtcv_ikiti)
        Me.TabPage5.Controls.Add(Me.lblcv_nowmaxval)
        Me.TabPage5.Controls.Add(Me.lblcv_maxval)
        Me.TabPage5.Controls.Add(Me.Label46)
        Me.TabPage5.Controls.Add(Me.Label49)
        Me.TabPage5.Controls.Add(Me.txtcv_ikiti_reset)
        Me.TabPage5.Controls.Add(Me.Label39)
        Me.TabPage5.Controls.Add(Me.Label41)
        Me.TabPage5.Controls.Add(Me.txtcv_posy)
        Me.TabPage5.Controls.Add(Me.txtcv_posx)
        Me.TabPage5.Controls.Add(Me.txtcv_antenyn)
        Me.TabPage5.Controls.Add(Me.lblcv_nowmaxval_reset)
        Me.TabPage5.Controls.Add(Me.lblcv_maxval_reset)
        Me.TabPage5.Controls.Add(Me.btncv_stop)
        Me.TabPage5.Controls.Add(Me.lblcv_sendview)
        Me.TabPage5.Controls.Add(Me.lblcv_comment)
        Me.TabPage5.Controls.Add(Me.lblcv_sleepcount)
        Me.TabPage5.Controls.Add(Me.txtcv_antentime)
        Me.TabPage5.Controls.Add(Me.btncv_forward)
        Me.TabPage5.Controls.Add(Me.btncv_back)
        Me.TabPage5.Controls.Add(Me.Label51)
        Me.TabPage5.Controls.Add(Me.Label42)
        Me.TabPage5.Controls.Add(Me.Label64)
        Me.TabPage5.Controls.Add(Me.Label65)
        Me.TabPage5.Controls.Add(Me.Label66)
        Me.TabPage5.Controls.Add(Me.piccv_load)
        Me.TabPage5.Controls.Add(Me.PictureBox2)
        Me.TabPage5.Controls.Add(Me.picipl_foranten)
        Me.TabPage5.Controls.Add(Me.piccv_reset)
        Me.TabPage5.Controls.Add(Me.piccv_picture)
        Me.TabPage5.Controls.Add(Me.PictureBox17)
        Me.TabPage5.Controls.Add(Me.picipl_cap)
        Me.TabPage5.Controls.Add(Me.PictureBox18)
        Me.TabPage5.Controls.Add(Me.PictureBox19)
        resources.ApplyResources(Me.TabPage5, "TabPage5")
        Me.TabPage5.Name = "TabPage5"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(95, Byte), Integer))
        resources.ApplyResources(Me.PictureBox3, "PictureBox3")
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(105, Byte), Integer))
        resources.ApplyResources(Me.PictureBox4, "PictureBox4")
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.TabStop = False
        '
        'Label77
        '
        resources.ApplyResources(Me.Label77, "Label77")
        Me.Label77.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label77.ForeColor = System.Drawing.SystemColors.Control
        Me.Label77.Name = "Label77"
        '
        'lbllooptrigger
        '
        resources.ApplyResources(Me.lbllooptrigger, "lbllooptrigger")
        Me.lbllooptrigger.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lbllooptrigger.ForeColor = System.Drawing.SystemColors.Control
        Me.lbllooptrigger.Name = "lbllooptrigger"
        '
        'numnowloop
        '
        Me.numnowloop.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.numnowloop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numnowloop, "numnowloop")
        Me.numnowloop.ForeColor = System.Drawing.SystemColors.Control
        Me.numnowloop.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        Me.numnowloop.Name = "numnowloop"
        Me.numnowloop.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'lblloopcount
        '
        resources.ApplyResources(Me.lblloopcount, "lblloopcount")
        Me.lblloopcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblloopcount.ForeColor = System.Drawing.Color.White
        Me.lblloopcount.Name = "lblloopcount"
        '
        'Label73
        '
        resources.ApplyResources(Me.Label73, "Label73")
        Me.Label73.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label73.ForeColor = System.Drawing.SystemColors.Control
        Me.Label73.Name = "Label73"
        '
        'Label74
        '
        resources.ApplyResources(Me.Label74, "Label74")
        Me.Label74.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label74.ForeColor = System.Drawing.SystemColors.Control
        Me.Label74.Name = "Label74"
        '
        'lblresetcount
        '
        resources.ApplyResources(Me.lblresetcount, "lblresetcount")
        Me.lblresetcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblresetcount.ForeColor = System.Drawing.Color.White
        Me.lblresetcount.Name = "lblresetcount"
        '
        'lblattemptcount
        '
        resources.ApplyResources(Me.lblattemptcount, "lblattemptcount")
        Me.lblattemptcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblattemptcount.ForeColor = System.Drawing.Color.White
        Me.lblattemptcount.Name = "lblattemptcount"
        '
        'lbllapcount
        '
        resources.ApplyResources(Me.lbllapcount, "lbllapcount")
        Me.lbllapcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lbllapcount.ForeColor = System.Drawing.Color.White
        Me.lbllapcount.Name = "lbllapcount"
        '
        'Label68
        '
        resources.ApplyResources(Me.Label68, "Label68")
        Me.Label68.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label68.ForeColor = System.Drawing.SystemColors.Control
        Me.Label68.Name = "Label68"
        '
        'Label69
        '
        resources.ApplyResources(Me.Label69, "Label69")
        Me.Label69.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label69.ForeColor = System.Drawing.SystemColors.Control
        Me.Label69.Name = "Label69"
        '
        'Label70
        '
        resources.ApplyResources(Me.Label70, "Label70")
        Me.Label70.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label70.ForeColor = System.Drawing.SystemColors.Control
        Me.Label70.Name = "Label70"
        '
        'lblreload_graph
        '
        resources.ApplyResources(Me.lblreload_graph, "lblreload_graph")
        Me.lblreload_graph.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblreload_graph.ForeColor = System.Drawing.SystemColors.Control
        Me.lblreload_graph.Name = "lblreload_graph"
        '
        'txtsetsplitname
        '
        Me.txtsetsplitname.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtsetsplitname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtsetsplitname, "txtsetsplitname")
        Me.txtsetsplitname.ForeColor = System.Drawing.SystemColors.Control
        Me.txtsetsplitname.Name = "txtsetsplitname"
        Me.txtsetsplitname.ReadOnly = True
        '
        'Label63
        '
        resources.ApplyResources(Me.Label63, "Label63")
        Me.Label63.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label63.ForeColor = System.Drawing.SystemColors.Control
        Me.Label63.Name = "Label63"
        '
        'cmbloadno
        '
        Me.cmbloadno.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.cmbloadno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cmbloadno, "cmbloadno")
        Me.cmbloadno.ForeColor = System.Drawing.SystemColors.Control
        Me.cmbloadno.FormattingEnabled = True
        Me.cmbloadno.Items.AddRange(New Object() {resources.GetString("cmbloadno.Items"), resources.GetString("cmbloadno.Items1"), resources.GetString("cmbloadno.Items2"), resources.GetString("cmbloadno.Items3"), resources.GetString("cmbloadno.Items4"), resources.GetString("cmbloadno.Items5"), resources.GetString("cmbloadno.Items6"), resources.GetString("cmbloadno.Items7"), resources.GetString("cmbloadno.Items8"), resources.GetString("cmbloadno.Items9")})
        Me.cmbloadno.Name = "cmbloadno"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load10)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load9)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load8)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load7)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load6)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load5)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load4)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load3)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load2)
        Me.GroupBox8.Controls.Add(Me.txtcv_ikiti_load1)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load1)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load10)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load2)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load9)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load2)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load8)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load3)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load7)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load3)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load6)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load4)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load5)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load4)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load4)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load5)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load3)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load5)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load2)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load6)
        Me.GroupBox8.Controls.Add(Me.txtdelay_load1)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load6)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load7)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load1)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load7)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load10)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load8)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load10)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load8)
        Me.GroupBox8.Controls.Add(Me.lblcv_nowmaxval_load9)
        Me.GroupBox8.Controls.Add(Me.lblcv_maxval_load9)
        resources.ApplyResources(Me.GroupBox8, "GroupBox8")
        Me.GroupBox8.ForeColor = System.Drawing.Color.PeachPuff
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.TabStop = False
        '
        'txtcv_ikiti_load10
        '
        Me.txtcv_ikiti_load10.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load10, "txtcv_ikiti_load10")
        Me.txtcv_ikiti_load10.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load10.Name = "txtcv_ikiti_load10"
        Me.txtcv_ikiti_load10.ReadOnly = True
        '
        'txtcv_ikiti_load9
        '
        Me.txtcv_ikiti_load9.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load9, "txtcv_ikiti_load9")
        Me.txtcv_ikiti_load9.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load9.Name = "txtcv_ikiti_load9"
        Me.txtcv_ikiti_load9.ReadOnly = True
        '
        'txtcv_ikiti_load8
        '
        Me.txtcv_ikiti_load8.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load8, "txtcv_ikiti_load8")
        Me.txtcv_ikiti_load8.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load8.Name = "txtcv_ikiti_load8"
        Me.txtcv_ikiti_load8.ReadOnly = True
        '
        'txtcv_ikiti_load7
        '
        Me.txtcv_ikiti_load7.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load7, "txtcv_ikiti_load7")
        Me.txtcv_ikiti_load7.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load7.Name = "txtcv_ikiti_load7"
        Me.txtcv_ikiti_load7.ReadOnly = True
        '
        'txtcv_ikiti_load6
        '
        Me.txtcv_ikiti_load6.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load6, "txtcv_ikiti_load6")
        Me.txtcv_ikiti_load6.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load6.Name = "txtcv_ikiti_load6"
        Me.txtcv_ikiti_load6.ReadOnly = True
        '
        'txtcv_ikiti_load5
        '
        Me.txtcv_ikiti_load5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load5, "txtcv_ikiti_load5")
        Me.txtcv_ikiti_load5.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load5.Name = "txtcv_ikiti_load5"
        Me.txtcv_ikiti_load5.ReadOnly = True
        '
        'txtcv_ikiti_load4
        '
        Me.txtcv_ikiti_load4.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load4, "txtcv_ikiti_load4")
        Me.txtcv_ikiti_load4.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load4.Name = "txtcv_ikiti_load4"
        Me.txtcv_ikiti_load4.ReadOnly = True
        '
        'txtcv_ikiti_load3
        '
        Me.txtcv_ikiti_load3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load3, "txtcv_ikiti_load3")
        Me.txtcv_ikiti_load3.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load3.Name = "txtcv_ikiti_load3"
        Me.txtcv_ikiti_load3.ReadOnly = True
        '
        'txtcv_ikiti_load2
        '
        Me.txtcv_ikiti_load2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load2, "txtcv_ikiti_load2")
        Me.txtcv_ikiti_load2.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load2.Name = "txtcv_ikiti_load2"
        Me.txtcv_ikiti_load2.ReadOnly = True
        '
        'txtcv_ikiti_load1
        '
        Me.txtcv_ikiti_load1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_ikiti_load1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load1, "txtcv_ikiti_load1")
        Me.txtcv_ikiti_load1.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_ikiti_load1.Name = "txtcv_ikiti_load1"
        Me.txtcv_ikiti_load1.ReadOnly = True
        '
        'lblcv_nowmaxval_load1
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load1, "lblcv_nowmaxval_load1")
        Me.lblcv_nowmaxval_load1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load1.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load1.Name = "lblcv_nowmaxval_load1"
        '
        'txtdelay_load10
        '
        Me.txtdelay_load10.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load10, "txtdelay_load10")
        Me.txtdelay_load10.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load10.Name = "txtdelay_load10"
        Me.txtdelay_load10.ReadOnly = True
        '
        'lblcv_maxval_load2
        '
        resources.ApplyResources(Me.lblcv_maxval_load2, "lblcv_maxval_load2")
        Me.lblcv_maxval_load2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load2.Name = "lblcv_maxval_load2"
        '
        'txtdelay_load9
        '
        Me.txtdelay_load9.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load9, "txtdelay_load9")
        Me.txtdelay_load9.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load9.Name = "txtdelay_load9"
        Me.txtdelay_load9.ReadOnly = True
        '
        'lblcv_nowmaxval_load2
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load2, "lblcv_nowmaxval_load2")
        Me.lblcv_nowmaxval_load2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load2.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load2.Name = "lblcv_nowmaxval_load2"
        '
        'txtdelay_load8
        '
        Me.txtdelay_load8.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load8, "txtdelay_load8")
        Me.txtdelay_load8.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load8.Name = "txtdelay_load8"
        Me.txtdelay_load8.ReadOnly = True
        '
        'lblcv_maxval_load3
        '
        resources.ApplyResources(Me.lblcv_maxval_load3, "lblcv_maxval_load3")
        Me.lblcv_maxval_load3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load3.Name = "lblcv_maxval_load3"
        '
        'txtdelay_load7
        '
        Me.txtdelay_load7.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load7, "txtdelay_load7")
        Me.txtdelay_load7.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load7.Name = "txtdelay_load7"
        Me.txtdelay_load7.ReadOnly = True
        '
        'lblcv_nowmaxval_load3
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load3, "lblcv_nowmaxval_load3")
        Me.lblcv_nowmaxval_load3.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load3.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load3.Name = "lblcv_nowmaxval_load3"
        '
        'txtdelay_load6
        '
        Me.txtdelay_load6.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load6, "txtdelay_load6")
        Me.txtdelay_load6.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load6.Name = "txtdelay_load6"
        Me.txtdelay_load6.ReadOnly = True
        '
        'lblcv_maxval_load4
        '
        resources.ApplyResources(Me.lblcv_maxval_load4, "lblcv_maxval_load4")
        Me.lblcv_maxval_load4.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load4.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load4.Name = "lblcv_maxval_load4"
        '
        'txtdelay_load5
        '
        Me.txtdelay_load5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load5, "txtdelay_load5")
        Me.txtdelay_load5.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load5.Name = "txtdelay_load5"
        Me.txtdelay_load5.ReadOnly = True
        '
        'lblcv_nowmaxval_load4
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load4, "lblcv_nowmaxval_load4")
        Me.lblcv_nowmaxval_load4.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load4.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load4.Name = "lblcv_nowmaxval_load4"
        '
        'txtdelay_load4
        '
        Me.txtdelay_load4.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load4, "txtdelay_load4")
        Me.txtdelay_load4.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load4.Name = "txtdelay_load4"
        Me.txtdelay_load4.ReadOnly = True
        '
        'lblcv_maxval_load5
        '
        resources.ApplyResources(Me.lblcv_maxval_load5, "lblcv_maxval_load5")
        Me.lblcv_maxval_load5.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load5.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load5.Name = "lblcv_maxval_load5"
        '
        'txtdelay_load3
        '
        Me.txtdelay_load3.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load3, "txtdelay_load3")
        Me.txtdelay_load3.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load3.Name = "txtdelay_load3"
        Me.txtdelay_load3.ReadOnly = True
        '
        'lblcv_nowmaxval_load5
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load5, "lblcv_nowmaxval_load5")
        Me.lblcv_nowmaxval_load5.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load5.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load5.Name = "lblcv_nowmaxval_load5"
        '
        'txtdelay_load2
        '
        Me.txtdelay_load2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load2, "txtdelay_load2")
        Me.txtdelay_load2.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load2.Name = "txtdelay_load2"
        Me.txtdelay_load2.ReadOnly = True
        '
        'lblcv_maxval_load6
        '
        resources.ApplyResources(Me.lblcv_maxval_load6, "lblcv_maxval_load6")
        Me.lblcv_maxval_load6.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load6.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load6.Name = "lblcv_maxval_load6"
        '
        'txtdelay_load1
        '
        Me.txtdelay_load1.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load1, "txtdelay_load1")
        Me.txtdelay_load1.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load1.Name = "txtdelay_load1"
        Me.txtdelay_load1.ReadOnly = True
        '
        'lblcv_nowmaxval_load6
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load6, "lblcv_nowmaxval_load6")
        Me.lblcv_nowmaxval_load6.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load6.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load6.Name = "lblcv_nowmaxval_load6"
        '
        'lblcv_maxval_load7
        '
        resources.ApplyResources(Me.lblcv_maxval_load7, "lblcv_maxval_load7")
        Me.lblcv_maxval_load7.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load7.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load7.Name = "lblcv_maxval_load7"
        '
        'lblcv_maxval_load1
        '
        resources.ApplyResources(Me.lblcv_maxval_load1, "lblcv_maxval_load1")
        Me.lblcv_maxval_load1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load1.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load1.Name = "lblcv_maxval_load1"
        '
        'lblcv_nowmaxval_load7
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load7, "lblcv_nowmaxval_load7")
        Me.lblcv_nowmaxval_load7.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load7.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load7.Name = "lblcv_nowmaxval_load7"
        '
        'lblcv_nowmaxval_load10
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load10, "lblcv_nowmaxval_load10")
        Me.lblcv_nowmaxval_load10.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load10.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load10.Name = "lblcv_nowmaxval_load10"
        '
        'lblcv_maxval_load8
        '
        resources.ApplyResources(Me.lblcv_maxval_load8, "lblcv_maxval_load8")
        Me.lblcv_maxval_load8.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load8.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load8.Name = "lblcv_maxval_load8"
        '
        'lblcv_maxval_load10
        '
        resources.ApplyResources(Me.lblcv_maxval_load10, "lblcv_maxval_load10")
        Me.lblcv_maxval_load10.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load10.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load10.Name = "lblcv_maxval_load10"
        '
        'lblcv_nowmaxval_load8
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load8, "lblcv_nowmaxval_load8")
        Me.lblcv_nowmaxval_load8.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load8.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load8.Name = "lblcv_nowmaxval_load8"
        '
        'lblcv_nowmaxval_load9
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load9, "lblcv_nowmaxval_load9")
        Me.lblcv_nowmaxval_load9.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load9.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load9.Name = "lblcv_nowmaxval_load9"
        '
        'lblcv_maxval_load9
        '
        resources.ApplyResources(Me.lblcv_maxval_load9, "lblcv_maxval_load9")
        Me.lblcv_maxval_load9.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load9.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load9.Name = "lblcv_maxval_load9"
        '
        'chknow_load10
        '
        Me.chknow_load10.AutoCheck = False
        resources.ApplyResources(Me.chknow_load10, "chknow_load10")
        Me.chknow_load10.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load10.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load10.Name = "chknow_load10"
        Me.chknow_load10.UseVisualStyleBackColor = False
        '
        'chknow_load9
        '
        Me.chknow_load9.AutoCheck = False
        resources.ApplyResources(Me.chknow_load9, "chknow_load9")
        Me.chknow_load9.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load9.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load9.Name = "chknow_load9"
        Me.chknow_load9.UseVisualStyleBackColor = False
        '
        'chknow_load8
        '
        Me.chknow_load8.AutoCheck = False
        resources.ApplyResources(Me.chknow_load8, "chknow_load8")
        Me.chknow_load8.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load8.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load8.Name = "chknow_load8"
        Me.chknow_load8.UseVisualStyleBackColor = False
        '
        'chknow_load7
        '
        Me.chknow_load7.AutoCheck = False
        resources.ApplyResources(Me.chknow_load7, "chknow_load7")
        Me.chknow_load7.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load7.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load7.Name = "chknow_load7"
        Me.chknow_load7.UseVisualStyleBackColor = False
        '
        'chknow_load6
        '
        Me.chknow_load6.AutoCheck = False
        resources.ApplyResources(Me.chknow_load6, "chknow_load6")
        Me.chknow_load6.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load6.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load6.Name = "chknow_load6"
        Me.chknow_load6.UseVisualStyleBackColor = False
        '
        'chknow_load5
        '
        Me.chknow_load5.AutoCheck = False
        resources.ApplyResources(Me.chknow_load5, "chknow_load5")
        Me.chknow_load5.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load5.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load5.Name = "chknow_load5"
        Me.chknow_load5.UseVisualStyleBackColor = False
        '
        'chknow_load4
        '
        Me.chknow_load4.AutoCheck = False
        resources.ApplyResources(Me.chknow_load4, "chknow_load4")
        Me.chknow_load4.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load4.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load4.Name = "chknow_load4"
        Me.chknow_load4.UseVisualStyleBackColor = False
        '
        'chknow_load3
        '
        Me.chknow_load3.AutoCheck = False
        resources.ApplyResources(Me.chknow_load3, "chknow_load3")
        Me.chknow_load3.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load3.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load3.Name = "chknow_load3"
        Me.chknow_load3.UseVisualStyleBackColor = False
        '
        'chknow_load2
        '
        Me.chknow_load2.AutoCheck = False
        resources.ApplyResources(Me.chknow_load2, "chknow_load2")
        Me.chknow_load2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load2.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load2.Name = "chknow_load2"
        Me.chknow_load2.UseVisualStyleBackColor = False
        '
        'chknow_load1
        '
        Me.chknow_load1.AutoCheck = False
        resources.ApplyResources(Me.chknow_load1, "chknow_load1")
        Me.chknow_load1.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_load1.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load1.Name = "chknow_load1"
        Me.chknow_load1.UseVisualStyleBackColor = False
        '
        'txtdelay_load
        '
        Me.txtdelay_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtdelay_load.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtdelay_load, "txtdelay_load")
        Me.txtdelay_load.ForeColor = System.Drawing.Color.Snow
        Me.txtdelay_load.Name = "txtdelay_load"
        Me.txtdelay_load.ReadOnly = True
        '
        'chknow_monitor
        '
        Me.chknow_monitor.AutoCheck = False
        resources.ApplyResources(Me.chknow_monitor, "chknow_monitor")
        Me.chknow_monitor.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.chknow_monitor.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_monitor.Name = "chknow_monitor"
        Me.chknow_monitor.UseVisualStyleBackColor = False
        '
        'chknow_load
        '
        Me.chknow_load.AutoCheck = False
        resources.ApplyResources(Me.chknow_load, "chknow_load")
        Me.chknow_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.chknow_load.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_load.Name = "chknow_load"
        Me.chknow_load.UseVisualStyleBackColor = False
        '
        'chknow_reset
        '
        Me.chknow_reset.AutoCheck = False
        resources.ApplyResources(Me.chknow_reset, "chknow_reset")
        Me.chknow_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.chknow_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.chknow_reset.Name = "chknow_reset"
        Me.chknow_reset.UseVisualStyleBackColor = False
        '
        'txtrecord_load
        '
        Me.txtrecord_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtrecord_load.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtrecord_load, "txtrecord_load")
        Me.txtrecord_load.ForeColor = System.Drawing.SystemColors.Control
        Me.txtrecord_load.Name = "txtrecord_load"
        Me.txtrecord_load.ReadOnly = True
        '
        'lblrecord_pause_total
        '
        resources.ApplyResources(Me.lblrecord_pause_total, "lblrecord_pause_total")
        Me.lblrecord_pause_total.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblrecord_pause_total.ForeColor = System.Drawing.SystemColors.Control
        Me.lblrecord_pause_total.Name = "lblrecord_pause_total"
        '
        'lblrecord_pause
        '
        resources.ApplyResources(Me.lblrecord_pause, "lblrecord_pause")
        Me.lblrecord_pause.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblrecord_pause.ForeColor = System.Drawing.SystemColors.Control
        Me.lblrecord_pause.Name = "lblrecord_pause"
        '
        'txtrecord_load_total
        '
        Me.txtrecord_load_total.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtrecord_load_total.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtrecord_load_total, "txtrecord_load_total")
        Me.txtrecord_load_total.ForeColor = System.Drawing.SystemColors.Control
        Me.txtrecord_load_total.Name = "txtrecord_load_total"
        Me.txtrecord_load_total.ReadOnly = True
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label30.ForeColor = System.Drawing.SystemColors.Control
        Me.Label30.Name = "Label30"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Label34.ForeColor = System.Drawing.SystemColors.Control
        Me.Label34.Name = "Label34"
        '
        'txtcv_ikiti_load
        '
        Me.txtcv_ikiti_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtcv_ikiti_load.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_load, "txtcv_ikiti_load")
        Me.txtcv_ikiti_load.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_ikiti_load.Name = "txtcv_ikiti_load"
        Me.txtcv_ikiti_load.ReadOnly = True
        '
        'lblcv_nowmaxval_load
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_load, "lblcv_nowmaxval_load")
        Me.lblcv_nowmaxval_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_nowmaxval_load.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_load.Name = "lblcv_nowmaxval_load"
        '
        'lblcv_maxval_load
        '
        resources.ApplyResources(Me.lblcv_maxval_load, "lblcv_maxval_load")
        Me.lblcv_maxval_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lblcv_maxval_load.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_load.Name = "lblcv_maxval_load"
        '
        'lblsleeptime
        '
        resources.ApplyResources(Me.lblsleeptime, "lblsleeptime")
        Me.lblsleeptime.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblsleeptime.ForeColor = System.Drawing.Color.Silver
        Me.lblsleeptime.Name = "lblsleeptime"
        '
        'lblloading
        '
        resources.ApplyResources(Me.lblloading, "lblloading")
        Me.lblloading.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblloading.ForeColor = System.Drawing.SystemColors.Control
        Me.lblloading.Name = "lblloading"
        '
        'txtcv_result_sizey
        '
        Me.txtcv_result_sizey.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        resources.ApplyResources(Me.txtcv_result_sizey, "txtcv_result_sizey")
        Me.txtcv_result_sizey.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_result_sizey.Name = "txtcv_result_sizey"
        Me.txtcv_result_sizey.ReadOnly = True
        '
        'txtcv_result_sizex
        '
        Me.txtcv_result_sizex.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        resources.ApplyResources(Me.txtcv_result_sizex, "txtcv_result_sizex")
        Me.txtcv_result_sizex.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_result_sizex.Name = "txtcv_result_sizex"
        Me.txtcv_result_sizex.ReadOnly = True
        '
        'txtcv_result_posy
        '
        Me.txtcv_result_posy.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        resources.ApplyResources(Me.txtcv_result_posy, "txtcv_result_posy")
        Me.txtcv_result_posy.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_result_posy.Name = "txtcv_result_posy"
        Me.txtcv_result_posy.ReadOnly = True
        '
        'txtcv_result_posx
        '
        Me.txtcv_result_posx.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        resources.ApplyResources(Me.txtcv_result_posx, "txtcv_result_posx")
        Me.txtcv_result_posx.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_result_posx.Name = "txtcv_result_posx"
        Me.txtcv_result_posx.ReadOnly = True
        '
        'txtcompikiti
        '
        Me.txtcompikiti.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcompikiti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcompikiti, "txtcompikiti")
        Me.txtcompikiti.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtcompikiti.Name = "txtcompikiti"
        Me.txtcompikiti.ReadOnly = True
        '
        'txtstate
        '
        resources.ApplyResources(Me.txtstate, "txtstate")
        Me.txtstate.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtstate.ForeColor = System.Drawing.SystemColors.Control
        Me.txtstate.Name = "txtstate"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Name = "Label3"
        '
        'txtcv_result
        '
        Me.txtcv_result.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtcv_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_result, "txtcv_result")
        Me.txtcv_result.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_result.Name = "txtcv_result"
        Me.txtcv_result.ReadOnly = True
        '
        'btncv_downsize
        '
        Me.btncv_downsize.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncv_downsize, "btncv_downsize")
        Me.btncv_downsize.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncv_downsize.Name = "btncv_downsize"
        Me.btncv_downsize.UseVisualStyleBackColor = False
        '
        'btncv_first
        '
        Me.btncv_first.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncv_first, "btncv_first")
        Me.btncv_first.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncv_first.Name = "btncv_first"
        Me.btncv_first.UseVisualStyleBackColor = False
        '
        'lblcv_lap
        '
        resources.ApplyResources(Me.lblcv_lap, "lblcv_lap")
        Me.lblcv_lap.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_lap.Name = "lblcv_lap"
        '
        'Label52
        '
        resources.ApplyResources(Me.Label52, "Label52")
        Me.Label52.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label52.ForeColor = System.Drawing.SystemColors.Control
        Me.Label52.Name = "Label52"
        '
        'Label53
        '
        resources.ApplyResources(Me.Label53, "Label53")
        Me.Label53.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.Label53.ForeColor = System.Drawing.SystemColors.Control
        Me.Label53.Name = "Label53"
        '
        'txtcv_ikiti
        '
        Me.txtcv_ikiti.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.txtcv_ikiti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti, "txtcv_ikiti")
        Me.txtcv_ikiti.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_ikiti.Name = "txtcv_ikiti"
        Me.txtcv_ikiti.ReadOnly = True
        '
        'lblcv_nowmaxval
        '
        resources.ApplyResources(Me.lblcv_nowmaxval, "lblcv_nowmaxval")
        Me.lblcv_nowmaxval.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblcv_nowmaxval.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval.Name = "lblcv_nowmaxval"
        '
        'lblcv_maxval
        '
        resources.ApplyResources(Me.lblcv_maxval, "lblcv_maxval")
        Me.lblcv_maxval.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblcv_maxval.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval.Name = "lblcv_maxval"
        '
        'Label46
        '
        resources.ApplyResources(Me.Label46, "Label46")
        Me.Label46.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.Label46.ForeColor = System.Drawing.SystemColors.Control
        Me.Label46.Name = "Label46"
        '
        'Label49
        '
        resources.ApplyResources(Me.Label49, "Label49")
        Me.Label49.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.Label49.ForeColor = System.Drawing.SystemColors.Control
        Me.Label49.Name = "Label49"
        '
        'txtcv_ikiti_reset
        '
        Me.txtcv_ikiti_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.txtcv_ikiti_reset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_ikiti_reset, "txtcv_ikiti_reset")
        Me.txtcv_ikiti_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_ikiti_reset.Name = "txtcv_ikiti_reset"
        Me.txtcv_ikiti_reset.ReadOnly = True
        '
        'Label39
        '
        resources.ApplyResources(Me.Label39, "Label39")
        Me.Label39.ForeColor = System.Drawing.SystemColors.Control
        Me.Label39.Name = "Label39"
        '
        'Label41
        '
        resources.ApplyResources(Me.Label41, "Label41")
        Me.Label41.ForeColor = System.Drawing.SystemColors.Control
        Me.Label41.Name = "Label41"
        '
        'txtcv_posy
        '
        Me.txtcv_posy.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        resources.ApplyResources(Me.txtcv_posy, "txtcv_posy")
        Me.txtcv_posy.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_posy.Name = "txtcv_posy"
        Me.txtcv_posy.ReadOnly = True
        '
        'txtcv_posx
        '
        Me.txtcv_posx.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        resources.ApplyResources(Me.txtcv_posx, "txtcv_posx")
        Me.txtcv_posx.ForeColor = System.Drawing.SystemColors.Control
        Me.txtcv_posx.Name = "txtcv_posx"
        Me.txtcv_posx.ReadOnly = True
        '
        'txtcv_antenyn
        '
        Me.txtcv_antenyn.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_antenyn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_antenyn, "txtcv_antenyn")
        Me.txtcv_antenyn.ForeColor = System.Drawing.Color.Aquamarine
        Me.txtcv_antenyn.Name = "txtcv_antenyn"
        Me.txtcv_antenyn.ReadOnly = True
        '
        'lblcv_nowmaxval_reset
        '
        resources.ApplyResources(Me.lblcv_nowmaxval_reset, "lblcv_nowmaxval_reset")
        Me.lblcv_nowmaxval_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.lblcv_nowmaxval_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_nowmaxval_reset.Name = "lblcv_nowmaxval_reset"
        '
        'lblcv_maxval_reset
        '
        resources.ApplyResources(Me.lblcv_maxval_reset, "lblcv_maxval_reset")
        Me.lblcv_maxval_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        Me.lblcv_maxval_reset.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_maxval_reset.Name = "lblcv_maxval_reset"
        '
        'btncv_stop
        '
        Me.btncv_stop.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(255, Byte), Integer))
        resources.ApplyResources(Me.btncv_stop, "btncv_stop")
        Me.btncv_stop.Name = "btncv_stop"
        Me.btncv_stop.UseVisualStyleBackColor = False
        '
        'lblcv_sendview
        '
        resources.ApplyResources(Me.lblcv_sendview, "lblcv_sendview")
        Me.lblcv_sendview.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblcv_sendview.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_sendview.Name = "lblcv_sendview"
        '
        'lblcv_comment
        '
        resources.ApplyResources(Me.lblcv_comment, "lblcv_comment")
        Me.lblcv_comment.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblcv_comment.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_comment.Name = "lblcv_comment"
        '
        'lblcv_sleepcount
        '
        resources.ApplyResources(Me.lblcv_sleepcount, "lblcv_sleepcount")
        Me.lblcv_sleepcount.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.lblcv_sleepcount.ForeColor = System.Drawing.SystemColors.Control
        Me.lblcv_sleepcount.Name = "lblcv_sleepcount"
        '
        'txtcv_antentime
        '
        Me.txtcv_antentime.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtcv_antentime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtcv_antentime, "txtcv_antentime")
        Me.txtcv_antentime.ForeColor = System.Drawing.Color.Snow
        Me.txtcv_antentime.Name = "txtcv_antentime"
        Me.txtcv_antentime.ReadOnly = True
        '
        'btncv_forward
        '
        Me.btncv_forward.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncv_forward, "btncv_forward")
        Me.btncv_forward.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncv_forward.Name = "btncv_forward"
        Me.btncv_forward.UseVisualStyleBackColor = False
        '
        'btncv_back
        '
        Me.btncv_back.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncv_back, "btncv_back")
        Me.btncv_back.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncv_back.Name = "btncv_back"
        Me.btncv_back.UseVisualStyleBackColor = False
        '
        'Label51
        '
        resources.ApplyResources(Me.Label51, "Label51")
        Me.Label51.ForeColor = System.Drawing.SystemColors.Control
        Me.Label51.Name = "Label51"
        '
        'Label42
        '
        resources.ApplyResources(Me.Label42, "Label42")
        Me.Label42.ForeColor = System.Drawing.SystemColors.Control
        Me.Label42.Name = "Label42"
        '
        'Label64
        '
        resources.ApplyResources(Me.Label64, "Label64")
        Me.Label64.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label64.ForeColor = System.Drawing.SystemColors.Control
        Me.Label64.Name = "Label64"
        '
        'Label65
        '
        resources.ApplyResources(Me.Label65, "Label65")
        Me.Label65.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label65.ForeColor = System.Drawing.SystemColors.Control
        Me.Label65.Name = "Label65"
        '
        'Label66
        '
        resources.ApplyResources(Me.Label66, "Label66")
        Me.Label66.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label66.ForeColor = System.Drawing.SystemColors.Control
        Me.Label66.Name = "Label66"
        '
        'piccv_load
        '
        Me.piccv_load.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer))
        resources.ApplyResources(Me.piccv_load, "piccv_load")
        Me.piccv_load.Name = "piccv_load"
        Me.piccv_load.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(60, Byte), Integer))
        resources.ApplyResources(Me.PictureBox2, "PictureBox2")
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.TabStop = False
        '
        'picipl_foranten
        '
        Me.picipl_foranten.BackColor = System.Drawing.Color.SlateGray
        resources.ApplyResources(Me.picipl_foranten, "picipl_foranten")
        Me.picipl_foranten.Name = "picipl_foranten"
        Me.picipl_foranten.TabStop = False
        '
        'piccv_reset
        '
        Me.piccv_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer))
        resources.ApplyResources(Me.piccv_reset, "piccv_reset")
        Me.piccv_reset.Name = "piccv_reset"
        Me.piccv_reset.TabStop = False
        '
        'piccv_picture
        '
        Me.piccv_picture.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer))
        resources.ApplyResources(Me.piccv_picture, "piccv_picture")
        Me.piccv_picture.Name = "piccv_picture"
        Me.piccv_picture.TabStop = False
        '
        'PictureBox17
        '
        Me.PictureBox17.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        resources.ApplyResources(Me.PictureBox17, "PictureBox17")
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.TabStop = False
        '
        'picipl_cap
        '
        Me.picipl_cap.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer), CType(CType(13, Byte), Integer))
        resources.ApplyResources(Me.picipl_cap, "picipl_cap")
        Me.picipl_cap.Name = "picipl_cap"
        Me.picipl_cap.TabStop = False
        '
        'PictureBox18
        '
        Me.PictureBox18.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(2, Byte), Integer))
        resources.ApplyResources(Me.PictureBox18, "PictureBox18")
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.TabStop = False
        '
        'PictureBox19
        '
        Me.PictureBox19.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(50, Byte), Integer))
        resources.ApplyResources(Me.PictureBox19, "PictureBox19")
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.TabPage2.Controls.Add(Me.PictureBox7)
        Me.TabPage2.Controls.Add(Me.PictureBox8)
        Me.TabPage2.Controls.Add(Me.btntosetting01)
        Me.TabPage2.Controls.Add(Me.GroupBox9)
        Me.TabPage2.Controls.Add(Me.GroupBox7)
        Me.TabPage2.Controls.Add(Me.txtprocess)
        Me.TabPage2.Controls.Add(Me.Label19)
        Me.TabPage2.Controls.Add(Me.btninsertzahyou)
        Me.TabPage2.Controls.Add(Me.chklockwindow)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.Label22)
        Me.TabPage2.Controls.Add(Me.txt2_rby)
        Me.TabPage2.Controls.Add(Me.txt2_rbx)
        Me.TabPage2.Controls.Add(Me.txt2_lty)
        Me.TabPage2.Controls.Add(Me.txt2_ltx)
        Me.TabPage2.Controls.Add(Me.dgv2_template)
        Me.TabPage2.Controls.Add(Me.txt2_selectedhwnd)
        Me.TabPage2.Controls.Add(Me.txt2_Selectedwindowtitle)
        Me.TabPage2.Controls.Add(Me.num2_rbx)
        Me.TabPage2.Controls.Add(Me.num2_rby)
        Me.TabPage2.Controls.Add(Me.num2_lty)
        Me.TabPage2.Controls.Add(Me.num2_ltx)
        Me.TabPage2.Controls.Add(Me.list2_alltitle)
        Me.TabPage2.Controls.Add(Me.list2_hwnd)
        Me.TabPage2.Controls.Add(Me.btn2_gethwnd)
        Me.TabPage2.Controls.Add(Me.btn2_getwindowtitle)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(95, Byte), Integer))
        resources.ApplyResources(Me.PictureBox7, "PictureBox7")
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(105, Byte), Integer))
        resources.ApplyResources(Me.PictureBox8, "PictureBox8")
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.TabStop = False
        '
        'btntosetting01
        '
        Me.btntosetting01.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btntosetting01, "btntosetting01")
        Me.btntosetting01.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btntosetting01.Name = "btntosetting01"
        Me.btntosetting01.UseVisualStyleBackColor = False
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.GroupBox9.Controls.Add(Me.txtrenameapp)
        Me.GroupBox9.Controls.Add(Me.chkmulti)
        Me.GroupBox9.Controls.Add(Me.txtpid_2nd)
        Me.GroupBox9.Controls.Add(Me.btnrenameapp)
        resources.ApplyResources(Me.GroupBox9, "GroupBox9")
        Me.GroupBox9.ForeColor = System.Drawing.Color.PeachPuff
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.TabStop = False
        '
        'txtrenameapp
        '
        Me.txtrenameapp.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.txtrenameapp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtrenameapp, "txtrenameapp")
        Me.txtrenameapp.ForeColor = System.Drawing.SystemColors.Control
        Me.txtrenameapp.Name = "txtrenameapp"
        '
        'chkmulti
        '
        resources.ApplyResources(Me.chkmulti, "chkmulti")
        Me.chkmulti.BackColor = System.Drawing.Color.FromArgb(CType(CType(38, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.chkmulti.ForeColor = System.Drawing.SystemColors.Control
        Me.chkmulti.Name = "chkmulti"
        Me.chkmulti.UseVisualStyleBackColor = False
        '
        'txtpid_2nd
        '
        Me.txtpid_2nd.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.txtpid_2nd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtpid_2nd, "txtpid_2nd")
        Me.txtpid_2nd.ForeColor = System.Drawing.SystemColors.Control
        Me.txtpid_2nd.Name = "txtpid_2nd"
        '
        'btnrenameapp
        '
        Me.btnrenameapp.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btnrenameapp, "btnrenameapp")
        Me.btnrenameapp.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnrenameapp.Name = "btnrenameapp"
        Me.btnrenameapp.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.lblm13)
        Me.GroupBox7.Controls.Add(Me.rich2_hwnddetail)
        Me.GroupBox7.Controls.Add(Me.txt2_windowtitle2)
        Me.GroupBox7.Controls.Add(Me.btn2_gethwnd2)
        Me.GroupBox7.Controls.Add(Me.list2_hwnd2)
        Me.GroupBox7.Controls.Add(Me.lbl2_parent_kid)
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'lblm13
        '
        resources.ApplyResources(Me.lblm13, "lblm13")
        Me.lblm13.ForeColor = System.Drawing.SystemColors.Control
        Me.lblm13.Name = "lblm13"
        '
        'rich2_hwnddetail
        '
        Me.rich2_hwnddetail.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        resources.ApplyResources(Me.rich2_hwnddetail, "rich2_hwnddetail")
        Me.rich2_hwnddetail.ForeColor = System.Drawing.SystemColors.Control
        Me.rich2_hwnddetail.Name = "rich2_hwnddetail"
        '
        'txt2_windowtitle2
        '
        Me.txt2_windowtitle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        resources.ApplyResources(Me.txt2_windowtitle2, "txt2_windowtitle2")
        Me.txt2_windowtitle2.ForeColor = System.Drawing.SystemColors.Control
        Me.txt2_windowtitle2.Name = "txt2_windowtitle2"
        '
        'btn2_gethwnd2
        '
        Me.btn2_gethwnd2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        resources.ApplyResources(Me.btn2_gethwnd2, "btn2_gethwnd2")
        Me.btn2_gethwnd2.Name = "btn2_gethwnd2"
        Me.btn2_gethwnd2.UseVisualStyleBackColor = False
        '
        'list2_hwnd2
        '
        Me.list2_hwnd2.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        resources.ApplyResources(Me.list2_hwnd2, "list2_hwnd2")
        Me.list2_hwnd2.ForeColor = System.Drawing.SystemColors.Control
        Me.list2_hwnd2.FormattingEnabled = True
        Me.list2_hwnd2.Name = "list2_hwnd2"
        '
        'lbl2_parent_kid
        '
        resources.ApplyResources(Me.lbl2_parent_kid, "lbl2_parent_kid")
        Me.lbl2_parent_kid.ForeColor = System.Drawing.SystemColors.Control
        Me.lbl2_parent_kid.Name = "lbl2_parent_kid"
        '
        'txtprocess
        '
        Me.txtprocess.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txtprocess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtprocess, "txtprocess")
        Me.txtprocess.ForeColor = System.Drawing.SystemColors.Control
        Me.txtprocess.Name = "txtprocess"
        Me.txtprocess.ReadOnly = True
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.ForeColor = System.Drawing.SystemColors.Control
        Me.Label19.Name = "Label19"
        '
        'btninsertzahyou
        '
        Me.btninsertzahyou.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btninsertzahyou, "btninsertzahyou")
        Me.btninsertzahyou.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btninsertzahyou.Name = "btninsertzahyou"
        Me.btninsertzahyou.UseVisualStyleBackColor = False
        '
        'chklockwindow
        '
        resources.ApplyResources(Me.chklockwindow, "chklockwindow")
        Me.chklockwindow.ForeColor = System.Drawing.SystemColors.Control
        Me.chklockwindow.Name = "chklockwindow"
        Me.chklockwindow.UseVisualStyleBackColor = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Name = "Label4"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.ForeColor = System.Drawing.SystemColors.Control
        Me.Label5.Name = "Label5"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ForeColor = System.Drawing.SystemColors.Control
        Me.Label6.Name = "Label6"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.ForeColor = System.Drawing.SystemColors.Control
        Me.Label11.Name = "Label11"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.ForeColor = System.Drawing.SystemColors.Control
        Me.Label12.Name = "Label12"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.ForeColor = System.Drawing.SystemColors.Control
        Me.Label13.Name = "Label13"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.ForeColor = System.Drawing.SystemColors.Control
        Me.Label21.Name = "Label21"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.ForeColor = System.Drawing.SystemColors.Control
        Me.Label22.Name = "Label22"
        '
        'txt2_rby
        '
        Me.txt2_rby.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txt2_rby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt2_rby, "txt2_rby")
        Me.txt2_rby.ForeColor = System.Drawing.SystemColors.Control
        Me.txt2_rby.Name = "txt2_rby"
        Me.txt2_rby.ReadOnly = True
        '
        'txt2_rbx
        '
        Me.txt2_rbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txt2_rbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt2_rbx, "txt2_rbx")
        Me.txt2_rbx.ForeColor = System.Drawing.SystemColors.Control
        Me.txt2_rbx.Name = "txt2_rbx"
        Me.txt2_rbx.ReadOnly = True
        '
        'txt2_lty
        '
        Me.txt2_lty.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txt2_lty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt2_lty, "txt2_lty")
        Me.txt2_lty.ForeColor = System.Drawing.SystemColors.Control
        Me.txt2_lty.Name = "txt2_lty"
        Me.txt2_lty.ReadOnly = True
        '
        'txt2_ltx
        '
        Me.txt2_ltx.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.txt2_ltx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt2_ltx, "txt2_ltx")
        Me.txt2_ltx.ForeColor = System.Drawing.SystemColors.Control
        Me.txt2_ltx.Name = "txt2_ltx"
        Me.txt2_ltx.ReadOnly = True
        '
        'dgv2_template
        '
        Me.dgv2_template.BackgroundColor = System.Drawing.SystemColors.GrayText
        Me.dgv2_template.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2_template.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.applysize, Me.Comment, Me.windowltx, Me.windowlty, Me.windowrbx, Me.windowsrby})
        resources.ApplyResources(Me.dgv2_template, "dgv2_template")
        Me.dgv2_template.Name = "dgv2_template"
        Me.dgv2_template.RowTemplate.Height = 21
        '
        'applysize
        '
        Me.applysize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        resources.ApplyResources(Me.applysize, "applysize")
        Me.applysize.Name = "applysize"
        '
        'Comment
        '
        resources.ApplyResources(Me.Comment, "Comment")
        Me.Comment.Name = "Comment"
        '
        'windowltx
        '
        resources.ApplyResources(Me.windowltx, "windowltx")
        Me.windowltx.Name = "windowltx"
        '
        'windowlty
        '
        resources.ApplyResources(Me.windowlty, "windowlty")
        Me.windowlty.Name = "windowlty"
        '
        'windowrbx
        '
        resources.ApplyResources(Me.windowrbx, "windowrbx")
        Me.windowrbx.Name = "windowrbx"
        '
        'windowsrby
        '
        resources.ApplyResources(Me.windowsrby, "windowsrby")
        Me.windowsrby.Name = "windowsrby"
        '
        'txt2_selectedhwnd
        '
        Me.txt2_selectedhwnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        resources.ApplyResources(Me.txt2_selectedhwnd, "txt2_selectedhwnd")
        Me.txt2_selectedhwnd.ForeColor = System.Drawing.SystemColors.Control
        Me.txt2_selectedhwnd.Name = "txt2_selectedhwnd"
        '
        'txt2_Selectedwindowtitle
        '
        Me.txt2_Selectedwindowtitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.txt2_Selectedwindowtitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txt2_Selectedwindowtitle, "txt2_Selectedwindowtitle")
        Me.txt2_Selectedwindowtitle.ForeColor = System.Drawing.SystemColors.Control
        Me.txt2_Selectedwindowtitle.Name = "txt2_Selectedwindowtitle"
        '
        'num2_rbx
        '
        Me.num2_rbx.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.num2_rbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.num2_rbx, "num2_rbx")
        Me.num2_rbx.ForeColor = System.Drawing.SystemColors.Control
        Me.num2_rbx.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.num2_rbx.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.num2_rbx.Name = "num2_rbx"
        Me.num2_rbx.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'num2_rby
        '
        Me.num2_rby.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.num2_rby.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.num2_rby, "num2_rby")
        Me.num2_rby.ForeColor = System.Drawing.SystemColors.Control
        Me.num2_rby.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.num2_rby.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.num2_rby.Name = "num2_rby"
        Me.num2_rby.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'num2_lty
        '
        Me.num2_lty.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.num2_lty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.num2_lty, "num2_lty")
        Me.num2_lty.ForeColor = System.Drawing.SystemColors.Control
        Me.num2_lty.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.num2_lty.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.num2_lty.Name = "num2_lty"
        Me.num2_lty.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'num2_ltx
        '
        Me.num2_ltx.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.num2_ltx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.num2_ltx, "num2_ltx")
        Me.num2_ltx.ForeColor = System.Drawing.SystemColors.Control
        Me.num2_ltx.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.num2_ltx.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.num2_ltx.Name = "num2_ltx"
        Me.num2_ltx.Value = New Decimal(New Integer() {500, 0, 0, 0})
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
        'list2_hwnd
        '
        Me.list2_hwnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.list2_hwnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.list2_hwnd, "list2_hwnd")
        Me.list2_hwnd.ForeColor = System.Drawing.SystemColors.Control
        Me.list2_hwnd.FormattingEnabled = True
        Me.list2_hwnd.Name = "list2_hwnd"
        '
        'btn2_gethwnd
        '
        Me.btn2_gethwnd.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        resources.ApplyResources(Me.btn2_gethwnd, "btn2_gethwnd")
        Me.btn2_gethwnd.Name = "btn2_gethwnd"
        Me.btn2_gethwnd.UseVisualStyleBackColor = False
        '
        'btn2_getwindowtitle
        '
        Me.btn2_getwindowtitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btn2_getwindowtitle, "btn2_getwindowtitle")
        Me.btn2_getwindowtitle.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btn2_getwindowtitle.Name = "btn2_getwindowtitle"
        Me.btn2_getwindowtitle.UseVisualStyleBackColor = False
        '
        'TabPage15
        '
        Me.TabPage15.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.TabPage15.Controls.Add(Me.gbsetting)
        Me.TabPage15.Controls.Add(Me.btncalib_resize)
        Me.TabPage15.Controls.Add(Me.btncalib_cap)
        Me.TabPage15.Controls.Add(Me.btntosetting03)
        Me.TabPage15.Controls.Add(Me.numcalib_bright)
        Me.TabPage15.Controls.Add(Me.numcalib_r)
        Me.TabPage15.Controls.Add(Me.numcalib_scaleheight)
        Me.TabPage15.Controls.Add(Me.numcalib_g)
        Me.TabPage15.Controls.Add(Me.numcalib_b)
        Me.TabPage15.Controls.Add(Me.numcalib_scalewidth)
        Me.TabPage15.Controls.Add(Me.numcalib_scale)
        Me.TabPage15.Controls.Add(Me.txtcalib_count)
        Me.TabPage15.Controls.Add(Me.grpcalib_1)
        Me.TabPage15.Controls.Add(Me.gbcalib_m1)
        Me.TabPage15.Controls.Add(Me.piccalib_temp)
        Me.TabPage15.Controls.Add(Me.piccamera)
        resources.ApplyResources(Me.TabPage15, "TabPage15")
        Me.TabPage15.Name = "TabPage15"
        '
        'gbsetting
        '
        Me.gbsetting.Controls.Add(Me.rdocalib_aspect_to43)
        Me.gbsetting.Controls.Add(Me.rdocalib_aspect_to169)
        Me.gbsetting.Controls.Add(Me.rdocalib_aspect_none)
        Me.gbsetting.Controls.Add(Me.pgbcalib_1)
        Me.gbsetting.Controls.Add(Me.btncalib_reset)
        Me.gbsetting.Controls.Add(Me.numcalib_hand_scaleheight)
        Me.gbsetting.Controls.Add(Me.gbrgb)
        Me.gbsetting.Controls.Add(Me.btncalib_insert)
        Me.gbsetting.Controls.Add(Me.Label103)
        Me.gbsetting.Controls.Add(Me.numcalib_hand_scalewidth)
        Me.gbsetting.Controls.Add(Me.numcalib_hand_scale)
        Me.gbsetting.Controls.Add(Me.txtcalib_save_scaleheight)
        Me.gbsetting.Controls.Add(Me.txtcalib_save_scalewidth)
        Me.gbsetting.Controls.Add(Me.txtcalib_save_scale)
        Me.gbsetting.Controls.Add(Me.Label105)
        Me.gbsetting.Controls.Add(Me.btncalib_adjaspect)
        Me.gbsetting.Controls.Add(Me.Label104)
        Me.gbsetting.Controls.Add(Me.Label102)
        Me.gbsetting.Controls.Add(Me.btncalib_adjscale)
        resources.ApplyResources(Me.gbsetting, "gbsetting")
        Me.gbsetting.ForeColor = System.Drawing.Color.Snow
        Me.gbsetting.Name = "gbsetting"
        Me.gbsetting.TabStop = False
        '
        'rdocalib_aspect_to43
        '
        resources.ApplyResources(Me.rdocalib_aspect_to43, "rdocalib_aspect_to43")
        Me.rdocalib_aspect_to43.Name = "rdocalib_aspect_to43"
        Me.rdocalib_aspect_to43.TabStop = True
        Me.rdocalib_aspect_to43.UseVisualStyleBackColor = True
        '
        'rdocalib_aspect_to169
        '
        resources.ApplyResources(Me.rdocalib_aspect_to169, "rdocalib_aspect_to169")
        Me.rdocalib_aspect_to169.Name = "rdocalib_aspect_to169"
        Me.rdocalib_aspect_to169.TabStop = True
        Me.rdocalib_aspect_to169.UseVisualStyleBackColor = True
        '
        'rdocalib_aspect_none
        '
        resources.ApplyResources(Me.rdocalib_aspect_none, "rdocalib_aspect_none")
        Me.rdocalib_aspect_none.Name = "rdocalib_aspect_none"
        Me.rdocalib_aspect_none.TabStop = True
        Me.rdocalib_aspect_none.UseVisualStyleBackColor = True
        '
        'pgbcalib_1
        '
        Me.pgbcalib_1.ForeColor = System.Drawing.Color.LightSalmon
        resources.ApplyResources(Me.pgbcalib_1, "pgbcalib_1")
        Me.pgbcalib_1.Name = "pgbcalib_1"
        Me.pgbcalib_1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'btncalib_reset
        '
        Me.btncalib_reset.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        resources.ApplyResources(Me.btncalib_reset, "btncalib_reset")
        Me.btncalib_reset.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncalib_reset.Name = "btncalib_reset"
        Me.btncalib_reset.UseVisualStyleBackColor = False
        '
        'numcalib_hand_scaleheight
        '
        Me.numcalib_hand_scaleheight.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.numcalib_hand_scaleheight.DecimalPlaces = 3
        resources.ApplyResources(Me.numcalib_hand_scaleheight, "numcalib_hand_scaleheight")
        Me.numcalib_hand_scaleheight.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numcalib_hand_scaleheight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numcalib_hand_scaleheight.Name = "numcalib_hand_scaleheight"
        Me.numcalib_hand_scaleheight.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'gbrgb
        '
        Me.gbrgb.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.gbrgb.Controls.Add(Me.lblm1)
        Me.gbrgb.Controls.Add(Me.Label101)
        Me.gbrgb.Controls.Add(Me.numcalib_hand_bright)
        Me.gbrgb.Controls.Add(Me.btncalib_adjrgb)
        Me.gbrgb.Controls.Add(Me.btncalib_adjbright)
        Me.gbrgb.Controls.Add(Me.numcalib_hand_g)
        Me.gbrgb.Controls.Add(Me.numcalib_hand_r)
        Me.gbrgb.Controls.Add(Me.numcalib_hand_b)
        Me.gbrgb.Controls.Add(Me.txtcalib_save_bright)
        Me.gbrgb.Controls.Add(Me.txtcalib_save_r)
        Me.gbrgb.Controls.Add(Me.txtcalib_save_g)
        Me.gbrgb.Controls.Add(Me.txtcalib_save_b)
        resources.ApplyResources(Me.gbrgb, "gbrgb")
        Me.gbrgb.ForeColor = System.Drawing.Color.Snow
        Me.gbrgb.Name = "gbrgb"
        Me.gbrgb.TabStop = False
        '
        'lblm1
        '
        resources.ApplyResources(Me.lblm1, "lblm1")
        Me.lblm1.Name = "lblm1"
        '
        'Label101
        '
        resources.ApplyResources(Me.Label101, "Label101")
        Me.Label101.Name = "Label101"
        '
        'numcalib_hand_bright
        '
        Me.numcalib_hand_bright.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.numcalib_hand_bright, "numcalib_hand_bright")
        Me.numcalib_hand_bright.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numcalib_hand_bright.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_hand_bright.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_hand_bright.Name = "numcalib_hand_bright"
        '
        'btncalib_adjrgb
        '
        Me.btncalib_adjrgb.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncalib_adjrgb, "btncalib_adjrgb")
        Me.btncalib_adjrgb.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncalib_adjrgb.Name = "btncalib_adjrgb"
        Me.btncalib_adjrgb.UseVisualStyleBackColor = False
        '
        'btncalib_adjbright
        '
        Me.btncalib_adjbright.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncalib_adjbright, "btncalib_adjbright")
        Me.btncalib_adjbright.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncalib_adjbright.Name = "btncalib_adjbright"
        Me.btncalib_adjbright.UseVisualStyleBackColor = False
        '
        'numcalib_hand_g
        '
        Me.numcalib_hand_g.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.numcalib_hand_g, "numcalib_hand_g")
        Me.numcalib_hand_g.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numcalib_hand_g.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_hand_g.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_hand_g.Name = "numcalib_hand_g"
        '
        'numcalib_hand_r
        '
        Me.numcalib_hand_r.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.numcalib_hand_r, "numcalib_hand_r")
        Me.numcalib_hand_r.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numcalib_hand_r.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_hand_r.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_hand_r.Name = "numcalib_hand_r"
        '
        'numcalib_hand_b
        '
        Me.numcalib_hand_b.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.numcalib_hand_b, "numcalib_hand_b")
        Me.numcalib_hand_b.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numcalib_hand_b.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_hand_b.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_hand_b.Name = "numcalib_hand_b"
        '
        'txtcalib_save_bright
        '
        Me.txtcalib_save_bright.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.txtcalib_save_bright, "txtcalib_save_bright")
        Me.txtcalib_save_bright.Name = "txtcalib_save_bright"
        Me.txtcalib_save_bright.ReadOnly = True
        '
        'txtcalib_save_r
        '
        Me.txtcalib_save_r.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.txtcalib_save_r, "txtcalib_save_r")
        Me.txtcalib_save_r.Name = "txtcalib_save_r"
        Me.txtcalib_save_r.ReadOnly = True
        '
        'txtcalib_save_g
        '
        Me.txtcalib_save_g.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.txtcalib_save_g, "txtcalib_save_g")
        Me.txtcalib_save_g.Name = "txtcalib_save_g"
        Me.txtcalib_save_g.ReadOnly = True
        '
        'txtcalib_save_b
        '
        Me.txtcalib_save_b.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.txtcalib_save_b, "txtcalib_save_b")
        Me.txtcalib_save_b.Name = "txtcalib_save_b"
        Me.txtcalib_save_b.ReadOnly = True
        '
        'btncalib_insert
        '
        Me.btncalib_insert.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        resources.ApplyResources(Me.btncalib_insert, "btncalib_insert")
        Me.btncalib_insert.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncalib_insert.Name = "btncalib_insert"
        Me.btncalib_insert.UseVisualStyleBackColor = False
        '
        'Label103
        '
        resources.ApplyResources(Me.Label103, "Label103")
        Me.Label103.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label103.Name = "Label103"
        '
        'numcalib_hand_scalewidth
        '
        Me.numcalib_hand_scalewidth.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.numcalib_hand_scalewidth.DecimalPlaces = 3
        resources.ApplyResources(Me.numcalib_hand_scalewidth, "numcalib_hand_scalewidth")
        Me.numcalib_hand_scalewidth.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numcalib_hand_scalewidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numcalib_hand_scalewidth.Name = "numcalib_hand_scalewidth"
        Me.numcalib_hand_scalewidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numcalib_hand_scale
        '
        Me.numcalib_hand_scale.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.numcalib_hand_scale.DecimalPlaces = 3
        resources.ApplyResources(Me.numcalib_hand_scale, "numcalib_hand_scale")
        Me.numcalib_hand_scale.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.numcalib_hand_scale.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numcalib_hand_scale.Name = "numcalib_hand_scale"
        Me.numcalib_hand_scale.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txtcalib_save_scaleheight
        '
        Me.txtcalib_save_scaleheight.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.txtcalib_save_scaleheight, "txtcalib_save_scaleheight")
        Me.txtcalib_save_scaleheight.Name = "txtcalib_save_scaleheight"
        Me.txtcalib_save_scaleheight.ReadOnly = True
        '
        'txtcalib_save_scalewidth
        '
        Me.txtcalib_save_scalewidth.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.txtcalib_save_scalewidth, "txtcalib_save_scalewidth")
        Me.txtcalib_save_scalewidth.Name = "txtcalib_save_scalewidth"
        Me.txtcalib_save_scalewidth.ReadOnly = True
        '
        'txtcalib_save_scale
        '
        Me.txtcalib_save_scale.BackColor = System.Drawing.Color.LightSteelBlue
        resources.ApplyResources(Me.txtcalib_save_scale, "txtcalib_save_scale")
        Me.txtcalib_save_scale.Name = "txtcalib_save_scale"
        Me.txtcalib_save_scale.ReadOnly = True
        '
        'Label105
        '
        resources.ApplyResources(Me.Label105, "Label105")
        Me.Label105.Name = "Label105"
        '
        'btncalib_adjaspect
        '
        Me.btncalib_adjaspect.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncalib_adjaspect, "btncalib_adjaspect")
        Me.btncalib_adjaspect.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncalib_adjaspect.Name = "btncalib_adjaspect"
        Me.btncalib_adjaspect.UseVisualStyleBackColor = False
        '
        'Label104
        '
        resources.ApplyResources(Me.Label104, "Label104")
        Me.Label104.Name = "Label104"
        '
        'Label102
        '
        resources.ApplyResources(Me.Label102, "Label102")
        Me.Label102.Name = "Label102"
        '
        'btncalib_adjscale
        '
        Me.btncalib_adjscale.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncalib_adjscale, "btncalib_adjscale")
        Me.btncalib_adjscale.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncalib_adjscale.Name = "btncalib_adjscale"
        Me.btncalib_adjscale.UseVisualStyleBackColor = False
        '
        'btncalib_resize
        '
        Me.btncalib_resize.BackColor = System.Drawing.Color.Wheat
        resources.ApplyResources(Me.btncalib_resize, "btncalib_resize")
        Me.btncalib_resize.Name = "btncalib_resize"
        Me.btncalib_resize.UseVisualStyleBackColor = False
        '
        'btncalib_cap
        '
        Me.btncalib_cap.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btncalib_cap, "btncalib_cap")
        Me.btncalib_cap.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btncalib_cap.Name = "btncalib_cap"
        Me.btncalib_cap.UseVisualStyleBackColor = False
        '
        'btntosetting03
        '
        Me.btntosetting03.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btntosetting03, "btntosetting03")
        Me.btntosetting03.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btntosetting03.Name = "btntosetting03"
        Me.btntosetting03.UseVisualStyleBackColor = False
        '
        'numcalib_bright
        '
        resources.ApplyResources(Me.numcalib_bright, "numcalib_bright")
        Me.numcalib_bright.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_bright.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_bright.Name = "numcalib_bright"
        '
        'numcalib_r
        '
        resources.ApplyResources(Me.numcalib_r, "numcalib_r")
        Me.numcalib_r.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_r.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_r.Name = "numcalib_r"
        '
        'numcalib_scaleheight
        '
        Me.numcalib_scaleheight.DecimalPlaces = 3
        resources.ApplyResources(Me.numcalib_scaleheight, "numcalib_scaleheight")
        Me.numcalib_scaleheight.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numcalib_scaleheight.Name = "numcalib_scaleheight"
        Me.numcalib_scaleheight.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numcalib_g
        '
        resources.ApplyResources(Me.numcalib_g, "numcalib_g")
        Me.numcalib_g.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_g.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_g.Name = "numcalib_g"
        '
        'numcalib_b
        '
        resources.ApplyResources(Me.numcalib_b, "numcalib_b")
        Me.numcalib_b.Maximum = New Decimal(New Integer() {256, 0, 0, 0})
        Me.numcalib_b.Minimum = New Decimal(New Integer() {256, 0, 0, -2147483648})
        Me.numcalib_b.Name = "numcalib_b"
        '
        'numcalib_scalewidth
        '
        Me.numcalib_scalewidth.DecimalPlaces = 3
        resources.ApplyResources(Me.numcalib_scalewidth, "numcalib_scalewidth")
        Me.numcalib_scalewidth.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numcalib_scalewidth.Name = "numcalib_scalewidth"
        Me.numcalib_scalewidth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numcalib_scale
        '
        Me.numcalib_scale.DecimalPlaces = 3
        resources.ApplyResources(Me.numcalib_scale, "numcalib_scale")
        Me.numcalib_scale.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numcalib_scale.Name = "numcalib_scale"
        Me.numcalib_scale.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'txtcalib_count
        '
        resources.ApplyResources(Me.txtcalib_count, "txtcalib_count")
        Me.txtcalib_count.Name = "txtcalib_count"
        '
        'grpcalib_1
        '
        Me.grpcalib_1.Controls.Add(Me.listcalib_2)
        Me.grpcalib_1.Controls.Add(Me.txtcalib_numbers)
        Me.grpcalib_1.Controls.Add(Me.Label106)
        Me.grpcalib_1.Controls.Add(Me.Label107)
        Me.grpcalib_1.Controls.Add(Me.Label108)
        Me.grpcalib_1.Controls.Add(Me.txtcalib_compfilename)
        Me.grpcalib_1.Controls.Add(Me.txtcalib_1)
        Me.grpcalib_1.Controls.Add(Me.listcalib_1)
        Me.grpcalib_1.Controls.Add(Me.btnpreview)
        Me.grpcalib_1.Controls.Add(Me.piccalib_resize)
        Me.grpcalib_1.Controls.Add(Me.chkcalib_1)
        Me.grpcalib_1.Controls.Add(Me.chkcalib_2)
        Me.grpcalib_1.Controls.Add(Me.txtcalib_hand_name)
        Me.grpcalib_1.Controls.Add(Me.txtcalib_max)
        Me.grpcalib_1.Controls.Add(Me.txtcalib_scaleorcolor)
        resources.ApplyResources(Me.grpcalib_1, "grpcalib_1")
        Me.grpcalib_1.Name = "grpcalib_1"
        Me.grpcalib_1.TabStop = False
        '
        'listcalib_2
        '
        Me.listcalib_2.FormattingEnabled = True
        resources.ApplyResources(Me.listcalib_2, "listcalib_2")
        Me.listcalib_2.Name = "listcalib_2"
        '
        'txtcalib_numbers
        '
        resources.ApplyResources(Me.txtcalib_numbers, "txtcalib_numbers")
        Me.txtcalib_numbers.Name = "txtcalib_numbers"
        '
        'Label106
        '
        resources.ApplyResources(Me.Label106, "Label106")
        Me.Label106.Name = "Label106"
        '
        'Label107
        '
        resources.ApplyResources(Me.Label107, "Label107")
        Me.Label107.Name = "Label107"
        '
        'Label108
        '
        resources.ApplyResources(Me.Label108, "Label108")
        Me.Label108.Name = "Label108"
        '
        'txtcalib_compfilename
        '
        resources.ApplyResources(Me.txtcalib_compfilename, "txtcalib_compfilename")
        Me.txtcalib_compfilename.Name = "txtcalib_compfilename"
        '
        'txtcalib_1
        '
        resources.ApplyResources(Me.txtcalib_1, "txtcalib_1")
        Me.txtcalib_1.Name = "txtcalib_1"
        '
        'listcalib_1
        '
        Me.listcalib_1.FormattingEnabled = True
        resources.ApplyResources(Me.listcalib_1, "listcalib_1")
        Me.listcalib_1.Name = "listcalib_1"
        '
        'btnpreview
        '
        resources.ApplyResources(Me.btnpreview, "btnpreview")
        Me.btnpreview.Name = "btnpreview"
        Me.btnpreview.UseVisualStyleBackColor = True
        '
        'piccalib_resize
        '
        Me.piccalib_resize.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.piccalib_resize, "piccalib_resize")
        Me.piccalib_resize.Name = "piccalib_resize"
        Me.piccalib_resize.TabStop = False
        '
        'chkcalib_1
        '
        resources.ApplyResources(Me.chkcalib_1, "chkcalib_1")
        Me.chkcalib_1.Name = "chkcalib_1"
        Me.chkcalib_1.UseVisualStyleBackColor = True
        '
        'chkcalib_2
        '
        resources.ApplyResources(Me.chkcalib_2, "chkcalib_2")
        Me.chkcalib_2.Name = "chkcalib_2"
        Me.chkcalib_2.UseVisualStyleBackColor = True
        '
        'txtcalib_hand_name
        '
        Me.txtcalib_hand_name.BackColor = System.Drawing.Color.Yellow
        resources.ApplyResources(Me.txtcalib_hand_name, "txtcalib_hand_name")
        Me.txtcalib_hand_name.Name = "txtcalib_hand_name"
        '
        'txtcalib_max
        '
        Me.txtcalib_max.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
        resources.ApplyResources(Me.txtcalib_max, "txtcalib_max")
        Me.txtcalib_max.ForeColor = System.Drawing.SystemColors.Info
        Me.txtcalib_max.Name = "txtcalib_max"
        '
        'txtcalib_scaleorcolor
        '
        Me.txtcalib_scaleorcolor.BackColor = System.Drawing.Color.Yellow
        resources.ApplyResources(Me.txtcalib_scaleorcolor, "txtcalib_scaleorcolor")
        Me.txtcalib_scaleorcolor.Name = "txtcalib_scaleorcolor"
        '
        'gbcalib_m1
        '
        Me.gbcalib_m1.Controls.Add(Me.Label111)
        Me.gbcalib_m1.Controls.Add(Me.Label110)
        Me.gbcalib_m1.Controls.Add(Me.Label109)
        Me.gbcalib_m1.Controls.Add(Me.txtcalib_bestvalue)
        Me.gbcalib_m1.Controls.Add(Me.piccalib_bestresult)
        Me.gbcalib_m1.Controls.Add(Me.Label75)
        Me.gbcalib_m1.Controls.Add(Me.txtcalib_nowvalue)
        Me.gbcalib_m1.Controls.Add(Me.Label99)
        Me.gbcalib_m1.Controls.Add(Me.piccalib_handresult)
        Me.gbcalib_m1.Controls.Add(Me.Label100)
        Me.gbcalib_m1.Controls.Add(Me.piccalib_comp)
        resources.ApplyResources(Me.gbcalib_m1, "gbcalib_m1")
        Me.gbcalib_m1.Name = "gbcalib_m1"
        Me.gbcalib_m1.TabStop = False
        '
        'Label111
        '
        resources.ApplyResources(Me.Label111, "Label111")
        Me.Label111.ForeColor = System.Drawing.Color.Snow
        Me.Label111.Name = "Label111"
        '
        'Label110
        '
        resources.ApplyResources(Me.Label110, "Label110")
        Me.Label110.ForeColor = System.Drawing.Color.Snow
        Me.Label110.Name = "Label110"
        '
        'Label109
        '
        resources.ApplyResources(Me.Label109, "Label109")
        Me.Label109.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.Label109.ForeColor = System.Drawing.Color.Snow
        Me.Label109.Name = "Label109"
        '
        'txtcalib_bestvalue
        '
        Me.txtcalib_bestvalue.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer))
        resources.ApplyResources(Me.txtcalib_bestvalue, "txtcalib_bestvalue")
        Me.txtcalib_bestvalue.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtcalib_bestvalue.Name = "txtcalib_bestvalue"
        '
        'piccalib_bestresult
        '
        Me.piccalib_bestresult.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.piccalib_bestresult, "piccalib_bestresult")
        Me.piccalib_bestresult.Name = "piccalib_bestresult"
        Me.piccalib_bestresult.TabStop = False
        '
        'Label75
        '
        resources.ApplyResources(Me.Label75, "Label75")
        Me.Label75.ForeColor = System.Drawing.Color.Snow
        Me.Label75.Name = "Label75"
        '
        'txtcalib_nowvalue
        '
        Me.txtcalib_nowvalue.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.txtcalib_nowvalue.BorderStyle = System.Windows.Forms.BorderStyle.None
        resources.ApplyResources(Me.txtcalib_nowvalue, "txtcalib_nowvalue")
        Me.txtcalib_nowvalue.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtcalib_nowvalue.Name = "txtcalib_nowvalue"
        '
        'Label99
        '
        resources.ApplyResources(Me.Label99, "Label99")
        Me.Label99.ForeColor = System.Drawing.Color.Snow
        Me.Label99.Name = "Label99"
        '
        'piccalib_handresult
        '
        Me.piccalib_handresult.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.piccalib_handresult, "piccalib_handresult")
        Me.piccalib_handresult.Name = "piccalib_handresult"
        Me.piccalib_handresult.TabStop = False
        '
        'Label100
        '
        resources.ApplyResources(Me.Label100, "Label100")
        Me.Label100.ForeColor = System.Drawing.Color.Snow
        Me.Label100.Name = "Label100"
        '
        'piccalib_comp
        '
        Me.piccalib_comp.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(40, Byte), Integer))
        resources.ApplyResources(Me.piccalib_comp, "piccalib_comp")
        Me.piccalib_comp.Name = "piccalib_comp"
        Me.piccalib_comp.TabStop = False
        '
        'piccalib_temp
        '
        Me.piccalib_temp.BackColor = System.Drawing.Color.Snow
        resources.ApplyResources(Me.piccalib_temp, "piccalib_temp")
        Me.piccalib_temp.Name = "piccalib_temp"
        Me.piccalib_temp.TabStop = False
        '
        'piccamera
        '
        Me.piccamera.BackColor = System.Drawing.Color.Snow
        resources.ApplyResources(Me.piccamera, "piccamera")
        Me.piccamera.Name = "piccamera"
        Me.piccamera.TabStop = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.TabPage3.Controls.Add(Me.PictureBox11)
        Me.TabPage3.Controls.Add(Me.PictureBox12)
        Me.TabPage3.Controls.Add(Me.btntosetting02)
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Controls.Add(Me.Label25)
        Me.TabPage3.Controls.Add(Me.Label18)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.Panel1)
        resources.ApplyResources(Me.TabPage3, "TabPage3")
        Me.TabPage3.Name = "TabPage3"
        '
        'PictureBox11
        '
        Me.PictureBox11.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(95, Byte), Integer))
        resources.ApplyResources(Me.PictureBox11, "PictureBox11")
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.TabStop = False
        '
        'PictureBox12
        '
        Me.PictureBox12.BackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(105, Byte), Integer))
        resources.ApplyResources(Me.PictureBox12, "PictureBox12")
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.TabStop = False
        '
        'btntosetting02
        '
        Me.btntosetting02.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btntosetting02, "btntosetting02")
        Me.btntosetting02.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btntosetting02.Name = "btntosetting02"
        Me.btntosetting02.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label72)
        Me.Panel3.Controls.Add(Me.rtxtupdate)
        resources.ApplyResources(Me.Panel3, "Panel3")
        Me.Panel3.Name = "Panel3"
        '
        'Label72
        '
        resources.ApplyResources(Me.Label72, "Label72")
        Me.Label72.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label72.ForeColor = System.Drawing.SystemColors.Control
        Me.Label72.Name = "Label72"
        '
        'rtxtupdate
        '
        Me.rtxtupdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.rtxtupdate.ForeColor = System.Drawing.Color.Snow
        resources.ApplyResources(Me.rtxtupdate, "rtxtupdate")
        Me.rtxtupdate.Name = "rtxtupdate"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label25.ForeColor = System.Drawing.SystemColors.Control
        Me.Label25.Name = "Label25"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label18.ForeColor = System.Drawing.SystemColors.Control
        Me.Label18.Name = "Label18"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label16.ForeColor = System.Drawing.SystemColors.Control
        Me.Label16.Name = "Label16"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label17.ForeColor = System.Drawing.SystemColors.Control
        Me.Label17.Name = "Label17"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LinkLabel3)
        Me.Panel1.Controls.Add(Me.Label31)
        Me.Panel1.Controls.Add(Me.LinkLabel2)
        Me.Panel1.Controls.Add(Me.LinkLabel1)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.lblversion)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'LinkLabel3
        '
        resources.ApplyResources(Me.LinkLabel3, "LinkLabel3")
        Me.LinkLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LinkLabel3.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label31.ForeColor = System.Drawing.SystemColors.Control
        Me.Label31.Name = "Label31"
        '
        'LinkLabel2
        '
        resources.ApplyResources(Me.LinkLabel2, "LinkLabel2")
        Me.LinkLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'LinkLabel1
        '
        resources.ApplyResources(Me.LinkLabel1, "LinkLabel1")
        Me.LinkLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label14.ForeColor = System.Drawing.SystemColors.Control
        Me.Label14.Name = "Label14"
        '
        'lblversion
        '
        resources.ApplyResources(Me.lblversion, "lblversion")
        Me.lblversion.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.lblversion.ForeColor = System.Drawing.SystemColors.Control
        Me.lblversion.Name = "lblversion"
        '
        'TabPage16
        '
        Me.TabPage16.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.TabPage16.Controls.Add(Me.btntosetting04)
        Me.TabPage16.Controls.Add(Me.rtxtlicense)
        Me.TabPage16.Controls.Add(Me.Panel2)
        resources.ApplyResources(Me.TabPage16, "TabPage16")
        Me.TabPage16.Name = "TabPage16"
        '
        'btntosetting04
        '
        Me.btntosetting04.BackColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(54, Byte), Integer))
        resources.ApplyResources(Me.btntosetting04, "btntosetting04")
        Me.btntosetting04.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btntosetting04.Name = "btntosetting04"
        Me.btntosetting04.UseVisualStyleBackColor = False
        '
        'rtxtlicense
        '
        Me.rtxtlicense.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(30, Byte), Integer))
        Me.rtxtlicense.ForeColor = System.Drawing.Color.Snow
        resources.ApplyResources(Me.rtxtlicense, "rtxtlicense")
        Me.rtxtlicense.Name = "rtxtlicense"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Panel2.Controls.Add(Me.link_dobon)
        Me.Panel2.Controls.Add(Me.Label118)
        Me.Panel2.Controls.Add(Me.Label117)
        Me.Panel2.Controls.Add(Me.Label116)
        Me.Panel2.Controls.Add(Me.link_directshowlib)
        Me.Panel2.Controls.Add(Me.Label113)
        Me.Panel2.Controls.Add(Me.link_opencvsharp)
        Me.Panel2.Controls.Add(Me.link_inteltbb)
        Me.Panel2.Controls.Add(Me.Label114)
        Me.Panel2.Controls.Add(Me.Label115)
        resources.ApplyResources(Me.Panel2, "Panel2")
        Me.Panel2.Name = "Panel2"
        '
        'link_dobon
        '
        resources.ApplyResources(Me.link_dobon, "link_dobon")
        Me.link_dobon.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.link_dobon.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.link_dobon.Name = "link_dobon"
        Me.link_dobon.TabStop = True
        Me.link_dobon.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Label118
        '
        resources.ApplyResources(Me.Label118, "Label118")
        Me.Label118.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label118.ForeColor = System.Drawing.SystemColors.Control
        Me.Label118.Name = "Label118"
        '
        'Label117
        '
        resources.ApplyResources(Me.Label117, "Label117")
        Me.Label117.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label117.ForeColor = System.Drawing.SystemColors.Control
        Me.Label117.Name = "Label117"
        '
        'Label116
        '
        resources.ApplyResources(Me.Label116, "Label116")
        Me.Label116.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label116.ForeColor = System.Drawing.SystemColors.Control
        Me.Label116.Name = "Label116"
        '
        'link_directshowlib
        '
        resources.ApplyResources(Me.link_directshowlib, "link_directshowlib")
        Me.link_directshowlib.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.link_directshowlib.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.link_directshowlib.Name = "link_directshowlib"
        Me.link_directshowlib.TabStop = True
        Me.link_directshowlib.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Label113
        '
        resources.ApplyResources(Me.Label113, "Label113")
        Me.Label113.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label113.ForeColor = System.Drawing.SystemColors.Control
        Me.Label113.Name = "Label113"
        '
        'link_opencvsharp
        '
        resources.ApplyResources(Me.link_opencvsharp, "link_opencvsharp")
        Me.link_opencvsharp.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.link_opencvsharp.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.link_opencvsharp.Name = "link_opencvsharp"
        Me.link_opencvsharp.TabStop = True
        Me.link_opencvsharp.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'link_inteltbb
        '
        resources.ApplyResources(Me.link_inteltbb, "link_inteltbb")
        Me.link_inteltbb.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.link_inteltbb.LinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.link_inteltbb.Name = "link_inteltbb"
        Me.link_inteltbb.TabStop = True
        Me.link_inteltbb.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        'Label114
        '
        resources.ApplyResources(Me.Label114, "Label114")
        Me.Label114.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label114.ForeColor = System.Drawing.SystemColors.Control
        Me.Label114.Name = "Label114"
        '
        'Label115
        '
        resources.ApplyResources(Me.Label115, "Label115")
        Me.Label115.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Label115.ForeColor = System.Drawing.SystemColors.Control
        Me.Label115.Name = "Label115"
        '
        'btnview_close
        '
        Me.btnview_close.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.btnview_close, "btnview_close")
        Me.btnview_close.ForeColor = System.Drawing.Color.Thistle
        Me.btnview_close.Name = "btnview_close"
        Me.btnview_close.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lbltitlebar
        '
        resources.ApplyResources(Me.lbltitlebar, "lbltitlebar")
        Me.lbltitlebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.lbltitlebar.ForeColor = System.Drawing.SystemColors.Control
        Me.lbltitlebar.Name = "lbltitlebar"
        '
        'btnclosewindow
        '
        Me.btnclosewindow.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.btnclosewindow, "btnclosewindow")
        Me.btnclosewindow.ForeColor = System.Drawing.Color.Thistle
        Me.btnclosewindow.Name = "btnclosewindow"
        Me.btnclosewindow.UseVisualStyleBackColor = False
        '
        'btnsaisyouka
        '
        Me.btnsaisyouka.BackColor = System.Drawing.Color.FromArgb(CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer), CType(CType(10, Byte), Integer))
        resources.ApplyResources(Me.btnsaisyouka, "btnsaisyouka")
        Me.btnsaisyouka.ForeColor = System.Drawing.Color.Thistle
        Me.btnsaisyouka.Name = "btnsaisyouka"
        Me.btnsaisyouka.UseVisualStyleBackColor = False
        '
        'timopencvsleep
        '
        Me.timopencvsleep.Interval = 10
        '
        'timcv_perfectanten
        '
        Me.timcv_perfectanten.Interval = 1
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 20000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'timcv_cap
        '
        Me.timcv_cap.Interval = 16
        '
        'timcv_anten
        '
        Me.timcv_anten.Interval = 10
        '
        'timcv_forantencap
        '
        '
        'timlockwindow
        '
        '
        'timchecktimer
        '
        '
        'timcamera
        '
        Me.timcamera.Interval = 33
        '
        'timcalib
        '
        '
        'timash_hotkey_sleep
        '
        Me.timash_hotkey_sleep.Interval = 300
        '
        'Mainwindow
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.btnview_close)
        Me.Controls.Add(Me.btnsaisyouka)
        Me.Controls.Add(Me.btnclosewindow)
        Me.Controls.Add(Me.lbltitlebar)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Mainwindow"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DGtable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlview_window.ResumeLayout(False)
        Me.pnlview_window.PerformLayout()
        CType(Me.piccap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictempipl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxIpl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piczoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picview_capture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlview_control.ResumeLayout(False)
        Me.pnlview_control.PerformLayout()
        CType(Me.numloadno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trktemp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpgeneral.ResumeLayout(False)
        Me.grpgeneral.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.pnl_other.ResumeLayout(False)
        Me.pnl_other.PerformLayout()
        Me.pnl_video.ResumeLayout(False)
        Me.pnl_video.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.numwin_interval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numwin_locy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numwin_locx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numvideo_sizey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numvideo_sizex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_loadremover.ResumeLayout(False)
        Me.pnl_loadremover.PerformLayout()
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        CType(Me.numload_rate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        CType(Me.numload_rate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        CType(Me.numload_rate3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        CType(Me.numload_rate4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage9.ResumeLayout(False)
        Me.TabPage9.PerformLayout()
        CType(Me.numload_rate5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage10.ResumeLayout(False)
        Me.TabPage10.PerformLayout()
        CType(Me.numload_rate6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage11.ResumeLayout(False)
        Me.TabPage11.PerformLayout()
        CType(Me.numload_rate7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage12.ResumeLayout(False)
        Me.TabPage12.PerformLayout()
        CType(Me.numload_rate8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage13.ResumeLayout(False)
        Me.TabPage13.PerformLayout()
        CType(Me.numload_rate9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage14.ResumeLayout(False)
        Me.TabPage14.PerformLayout()
        CType(Me.numload_rate10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numload_delay10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_hotkey.ResumeLayout(False)
        Me.pnl_hotkey.PerformLayout()
        CType(Me.numpresstime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_cvparameter.ResumeLayout(False)
        Me.pnl_cvparameter.PerformLayout()
        CType(Me.numcv_framerate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcv_device, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_focus.ResumeLayout(False)
        Me.pnl_focus.PerformLayout()
        CType(Me.numsendsleep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_graph.ResumeLayout(False)
        Me.pnl_graph.PerformLayout()
        CType(Me.numgraph_first, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numtextwindow_sizex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numtextwindow_sizey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numprofile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.numskip_ash, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numundo_ash, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numreset_ash, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcv_sizex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcv_sizey, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numsavex, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numsavey, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.numtemp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl_parameter.ResumeLayout(False)
        Me.pnl_parameter.PerformLayout()
        CType(Me.numanten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numstop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numloopcount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcv_interval, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numpercent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picunder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numnowloop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.piccv_load, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picipl_foranten, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piccv_reset, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piccv_picture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picipl_cap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.dgv2_template, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num2_rbx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num2_rby, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num2_lty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.num2_ltx, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage15.ResumeLayout(False)
        Me.TabPage15.PerformLayout()
        Me.gbsetting.ResumeLayout(False)
        Me.gbsetting.PerformLayout()
        CType(Me.numcalib_hand_scaleheight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbrgb.ResumeLayout(False)
        Me.gbrgb.PerformLayout()
        CType(Me.numcalib_hand_bright, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_hand_g, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_hand_r, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_hand_b, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_hand_scalewidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_hand_scale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_bright, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_r, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_scaleheight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_g, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_b, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_scalewidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numcalib_scale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpcalib_1.ResumeLayout(False)
        Me.grpcalib_1.PerformLayout()
        CType(Me.piccalib_resize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbcalib_m1.ResumeLayout(False)
        Me.gbcalib_m1.PerformLayout()
        CType(Me.piccalib_bestresult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piccalib_handresult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piccalib_comp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piccalib_temp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.piccamera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabPage16.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGtable As DataGridView
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents chkactiveapp As CheckBox
    Friend WithEvents cmbtimer As ComboBox
    Friend WithEvents chkactivesomeapp As CheckBox
    Friend WithEvents cmbsomeapp As ComboBox
    Friend WithEvents btndeleteitem_someapp As Button
    Friend WithEvents btngetsomeactive As Button
    Friend WithEvents chkalt As CheckBox
    Friend WithEvents chkshift As CheckBox
    Friend WithEvents chkctrl As CheckBox
    Friend WithEvents lblkeysforsend As Label
    Friend WithEvents lblcheckopening As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents txtpass_picturefolder As TextBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Label17 As Label
    Friend WithEvents lblversion As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btngettimer As Button
    Friend WithEvents btndelete_timer As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents lbltitlebar As Label
    Friend WithEvents btnclosewindow As Button
    Friend WithEvents chkalt_reset As CheckBox
    Friend WithEvents chkshift_reset As CheckBox
    Friend WithEvents chkctrl_reset As CheckBox
    Friend WithEvents lblkeysforsend_reset As Label
    Friend WithEvents btnsaisyouka As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents picunder As PictureBox
    Friend WithEvents DirectoryEntry1 As DirectoryServices.DirectoryEntry
    Friend WithEvents timopencvsleep As Timer
    Friend WithEvents timcv_perfectanten As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents cmbprofile As ComboBox
    Friend WithEvents btnaddprofile As Button
    Friend WithEvents btndeleteprofile As Button
    Friend WithEvents txtprofile As TextBox
    Friend WithEvents txtloadprofile As TextBox
    Friend WithEvents numprofile As NumericUpDown
    Friend WithEvents Label38 As Label
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents picipl_cap As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents timcv_cap As Timer
    Friend WithEvents btncv_back As Button
    Friend WithEvents btncv_stop As Button
    Friend WithEvents piccv_picture As PictureBox
    Friend WithEvents lblcv_sendview As Label
    Friend WithEvents lblcv_comment As Label
    Friend WithEvents lblcv_sleepcount As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents txtcv_antentime As TextBox
    Friend WithEvents Label52 As Label
    Friend WithEvents txtcv_ikiti As TextBox
    Friend WithEvents lblcv_nowmaxval As Label
    Friend WithEvents lblcv_maxval As Label
    Friend WithEvents PictureBox17 As PictureBox
    Friend WithEvents btncv_forward As Button
    Friend WithEvents piccv_reset As PictureBox
    Friend WithEvents lblcv_nowmaxval_reset As Label
    Friend WithEvents lblcv_maxval_reset As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents txtcv_posy As TextBox
    Friend WithEvents txtcv_posx As TextBox
    Friend WithEvents timcv_anten As Timer
    Friend WithEvents Label42 As Label
    Friend WithEvents txtcv_antenyn As TextBox
    Friend WithEvents timcv_forantencap As Timer
    Friend WithEvents txtcv_ikiti_reset As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents lblcv_lap As Label
    Friend WithEvents PictureBox18 As PictureBox
    Friend WithEvents btncv_first As Button
    Friend WithEvents picipl_foranten As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents PictureBox19 As PictureBox
    Friend WithEvents btncv_downsize As Button
    Friend WithEvents btnstartopencv As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkcv_resetonoff As CheckBox
    Friend WithEvents chkcv_loop As CheckBox
    Friend WithEvents cmbcv_resolution As ComboBox
    Friend WithEvents _moji5 As Label
    Friend WithEvents _moji6 As Label
    Friend WithEvents numcv_framerate As NumericUpDown
    Friend WithEvents btnresetup As Button
    Friend WithEvents cmbcv_device As ComboBox
    Friend WithEvents numcv_device As NumericUpDown
    Friend WithEvents Label24 As Label
    Friend WithEvents numcv_interval As NumericUpDown
    Friend WithEvents numcv_sizey As NumericUpDown
    Friend WithEvents numcv_sizex As NumericUpDown
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtrowscount As TextBox
    Friend WithEvents numsendsleep As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents btnaddapp1 As Button
    Friend WithEvents btnaddapp2 As Button
    Friend WithEvents btninsertitti As Button
    Friend WithEvents numstop As NumericUpDown
    Friend WithEvents numpercent As NumericUpDown
    Friend WithEvents _moji2 As Label
    Friend WithEvents _moji1 As Label
    Friend WithEvents btninsertsleep As Button
    Friend WithEvents _moji3 As Label
    Friend WithEvents numanten As NumericUpDown
    Friend WithEvents btninsertanten As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnclosetable As Button
    Friend WithEvents txtcv_result As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblkeysforskip As Label
    Friend WithEvents lblkeysforundo As Label
    Friend WithEvents chkshift_undo As CheckBox
    Friend WithEvents chkctrl_undo As CheckBox
    Friend WithEvents chkalt_undo As CheckBox
    Friend WithEvents chkalt_skip As CheckBox
    Friend WithEvents chkctrl_skip As CheckBox
    Friend WithEvents chkshift_skip As CheckBox
    Friend WithEvents chkundoskip As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtpass_csv As TextBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents lblm13 As Label
    Friend WithEvents rich2_hwnddetail As RichTextBox
    Friend WithEvents txt2_windowtitle2 As TextBox
    Friend WithEvents btn2_gethwnd2 As Button
    Friend WithEvents list2_hwnd2 As ListBox
    Friend WithEvents lbl2_parent_kid As Label
    Friend WithEvents txtprocess As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents btninsertzahyou As Button
    Friend WithEvents chklockwindow As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents txt2_rby As TextBox
    Friend WithEvents txt2_rbx As TextBox
    Friend WithEvents txt2_lty As TextBox
    Friend WithEvents txt2_ltx As TextBox
    Friend WithEvents dgv2_template As DataGridView
    Friend WithEvents txt2_selectedhwnd As TextBox
    Friend WithEvents txt2_Selectedwindowtitle As TextBox
    Friend WithEvents num2_rbx As NumericUpDown
    Friend WithEvents num2_rby As NumericUpDown
    Friend WithEvents num2_lty As NumericUpDown
    Friend WithEvents num2_ltx As NumericUpDown
    Friend WithEvents list2_alltitle As ListBox
    Friend WithEvents list2_hwnd As ListBox
    Friend WithEvents btn2_gethwnd As Button
    Friend WithEvents btn2_getwindowtitle As Button
    Friend WithEvents timlockwindow As Timer
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents Label23 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents txtstate As Label
    Friend WithEvents txtskip_key As TextBox
    Friend WithEvents txtundo_key As TextBox
    Friend WithEvents txtreset_key As TextBox
    Friend WithEvents txtsplit_key As TextBox
    Friend WithEvents txtcompikiti As TextBox
    Friend WithEvents txtcv_result_sizey As TextBox
    Friend WithEvents txtcv_result_sizex As TextBox
    Friend WithEvents txtcv_result_posy As TextBox
    Friend WithEvents txtcv_result_posx As TextBox
    Friend WithEvents chknamedpipe As CheckBox
    Friend WithEvents btnconnect_camera As Button
    Friend WithEvents txtpause_key As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents chkalt_pause As CheckBox
    Friend WithEvents chkctrl_pause As CheckBox
    Friend WithEvents chkshift_pause As CheckBox
    Friend WithEvents lblkeysforpause As Label
    Friend WithEvents txtresume_key As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents chkalt_resume As CheckBox
    Friend WithEvents chkctrl_resume As CheckBox
    Friend WithEvents chkshift_resume As CheckBox
    Friend WithEvents lblkeysforresume As Label
    Friend WithEvents lblloading As Label
    Friend WithEvents lblsleeptime As Label
    Friend WithEvents chkcv_loadremover As CheckBox
    Friend WithEvents timchecktimer As Timer
    Friend WithEvents numload_delay1 As NumericUpDown
    Friend WithEvents Label33 As Label
    Friend WithEvents numload_rate1 As NumericUpDown
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents txtcv_ikiti_load As TextBox
    Friend WithEvents lblcv_nowmaxval_load As Label
    Friend WithEvents lblcv_maxval_load As Label
    Friend WithEvents piccv_load As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents txtrecord_load_total As TextBox
    Friend WithEvents lblrecord_pause_total As Label
    Friend WithEvents lblrecord_pause As Label
    Friend WithEvents txtrecord_load As TextBox
    Friend WithEvents chkcv_monitor As CheckBox
    Friend WithEvents chknow_monitor As CheckBox
    Friend WithEvents chknow_load As CheckBox
    Friend WithEvents chknow_reset As CheckBox
    Friend WithEvents txtdelay_load As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents TabPage10 As TabPage
    Friend WithEvents TabPage11 As TabPage
    Friend WithEvents TabPage12 As TabPage
    Friend WithEvents TabPage13 As TabPage
    Friend WithEvents TabPage14 As TabPage
    Friend WithEvents chkload7 As CheckBox
    Friend WithEvents chkload8 As CheckBox
    Friend WithEvents chkload9 As CheckBox
    Friend WithEvents chkload10 As CheckBox
    Friend WithEvents chkload2 As CheckBox
    Friend WithEvents chkload3 As CheckBox
    Friend WithEvents chkload4 As CheckBox
    Friend WithEvents chkload6 As CheckBox
    Friend WithEvents chkload5 As CheckBox
    Friend WithEvents chkload1 As CheckBox
    Friend WithEvents Label15 As Label
    Friend WithEvents numload_rate2 As NumericUpDown
    Friend WithEvents numload_delay2 As NumericUpDown
    Friend WithEvents Label35 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents numload_rate3 As NumericUpDown
    Friend WithEvents numload_delay3 As NumericUpDown
    Friend WithEvents Label37 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents numload_rate4 As NumericUpDown
    Friend WithEvents numload_delay4 As NumericUpDown
    Friend WithEvents Label43 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents numload_rate5 As NumericUpDown
    Friend WithEvents numload_delay5 As NumericUpDown
    Friend WithEvents Label45 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents numload_rate6 As NumericUpDown
    Friend WithEvents numload_delay6 As NumericUpDown
    Friend WithEvents Label48 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents numload_rate7 As NumericUpDown
    Friend WithEvents numload_delay7 As NumericUpDown
    Friend WithEvents Label54 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents numload_rate8 As NumericUpDown
    Friend WithEvents numload_delay8 As NumericUpDown
    Friend WithEvents Label56 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents numload_rate9 As NumericUpDown
    Friend WithEvents numload_delay9 As NumericUpDown
    Friend WithEvents Label58 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents numload_rate10 As NumericUpDown
    Friend WithEvents numload_delay10 As NumericUpDown
    Friend WithEvents Label60 As Label
    Friend WithEvents chknow_load10 As CheckBox
    Friend WithEvents chknow_load9 As CheckBox
    Friend WithEvents chknow_load8 As CheckBox
    Friend WithEvents chknow_load7 As CheckBox
    Friend WithEvents chknow_load6 As CheckBox
    Friend WithEvents chknow_load5 As CheckBox
    Friend WithEvents chknow_load4 As CheckBox
    Friend WithEvents chknow_load3 As CheckBox
    Friend WithEvents chknow_load2 As CheckBox
    Friend WithEvents chknow_load1 As CheckBox
    Friend WithEvents lblcv_nowmaxval_load10 As Label
    Friend WithEvents lblcv_maxval_load10 As Label
    Friend WithEvents lblcv_nowmaxval_load9 As Label
    Friend WithEvents lblcv_maxval_load9 As Label
    Friend WithEvents lblcv_nowmaxval_load8 As Label
    Friend WithEvents lblcv_maxval_load8 As Label
    Friend WithEvents lblcv_nowmaxval_load7 As Label
    Friend WithEvents lblcv_maxval_load7 As Label
    Friend WithEvents lblcv_nowmaxval_load6 As Label
    Friend WithEvents lblcv_maxval_load6 As Label
    Friend WithEvents lblcv_nowmaxval_load5 As Label
    Friend WithEvents lblcv_maxval_load5 As Label
    Friend WithEvents lblcv_nowmaxval_load4 As Label
    Friend WithEvents lblcv_maxval_load4 As Label
    Friend WithEvents lblcv_nowmaxval_load3 As Label
    Friend WithEvents lblcv_maxval_load3 As Label
    Friend WithEvents lblcv_nowmaxval_load2 As Label
    Friend WithEvents lblcv_maxval_load2 As Label
    Friend WithEvents lblcv_nowmaxval_load1 As Label
    Friend WithEvents lblcv_maxval_load1 As Label
    Friend WithEvents txtdelay_load4 As TextBox
    Friend WithEvents txtdelay_load3 As TextBox
    Friend WithEvents txtdelay_load2 As TextBox
    Friend WithEvents txtdelay_load1 As TextBox
    Friend WithEvents txtdelay_load10 As TextBox
    Friend WithEvents txtdelay_load9 As TextBox
    Friend WithEvents txtdelay_load8 As TextBox
    Friend WithEvents txtdelay_load7 As TextBox
    Friend WithEvents txtdelay_load6 As TextBox
    Friend WithEvents txtdelay_load5 As TextBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents txtcv_ikiti_load10 As TextBox
    Friend WithEvents txtcv_ikiti_load9 As TextBox
    Friend WithEvents txtcv_ikiti_load8 As TextBox
    Friend WithEvents txtcv_ikiti_load7 As TextBox
    Friend WithEvents txtcv_ikiti_load6 As TextBox
    Friend WithEvents txtcv_ikiti_load5 As TextBox
    Friend WithEvents txtcv_ikiti_load4 As TextBox
    Friend WithEvents txtcv_ikiti_load3 As TextBox
    Friend WithEvents txtcv_ikiti_load2 As TextBox
    Friend WithEvents txtcv_ikiti_load1 As TextBox
    Friend WithEvents cmbloadno As ComboBox
    Friend WithEvents Label62 As Label
    Friend WithEvents Label61 As Label
    Friend WithEvents btnreset_count As Button
    Friend WithEvents txtsetsplitname As TextBox
    Friend WithEvents Label63 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents lblresetcount As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents lblattemptcount As Label
    Friend WithEvents lbllapcount As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents numgraph_first As NumericUpDown
    Friend WithEvents btnreset_table As Button
    Friend WithEvents btnreset_livesplit As Button
    Friend WithEvents lblreload_graph As Label
    Friend WithEvents chkrename_livesplit As CheckBox
    Friend WithEvents txtrenameapp As TextBox
    Friend WithEvents btnrenameapp As Button
    Friend WithEvents Label68 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents txttemp_picturepass As TextBox
    Friend WithEvents Label71 As Label
    Friend WithEvents numsavey As NumericUpDown
    Friend WithEvents numsavex As NumericUpDown
    Friend WithEvents numloopcount As NumericUpDown
    Friend WithEvents lblloopcount As Label
    Friend WithEvents Label73 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents numnowloop As NumericUpDown
    Friend WithEvents lbllooptrigger As Label
    Friend WithEvents chkmulti As CheckBox
    Friend WithEvents lblpid_1st As Label
    Friend WithEvents txtpid_2nd As TextBox
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lbllivesplit_state As Label
    Friend WithEvents chkcreate_temppicture As CheckBox
    Friend WithEvents grpgeneral As GroupBox
    Friend WithEvents lblcur_device_res_fps As Label
    Friend WithEvents lblcur_device_name As Label
    Friend WithEvents Label76 As Label
    Friend WithEvents Label90 As Label
    Friend WithEvents lblset_hotkey As Label
    Friend WithEvents Label89 As Label
    Friend WithEvents btncur_clear_live As Button
    Friend WithEvents btncur_clear_table As Button
    Friend WithEvents btncur_clear_count As Button
    Friend WithEvents Label86 As Label
    Friend WithEvents lblset_graph As Label
    Friend WithEvents btncur_webcamera As Button
    Friend WithEvents lblset_road As Label
    Friend WithEvents lblset_device As Label
    Friend WithEvents lblset_monitoring As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewProfileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblcur_load As Label
    Friend WithEvents lblcur_reset As Label
    Friend WithEvents lblcur_loop As Label
    Friend WithEvents lblcur_split As Label
    Friend WithEvents Label92 As Label
    Friend WithEvents lblset_focus As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents Label97 As Label
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreviewGetTemplatePictureToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalibrationToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InformationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnclose_general As Button
    Friend WithEvents PositionSettingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnl_parameter As Panel
    Friend WithEvents Label20 As Label
    Friend WithEvents pnl_hotkey As Panel
    Friend WithEvents Label85 As Label
    Friend WithEvents pnl_loadremover As Panel
    Friend WithEvents Label87 As Label
    Friend WithEvents pnl_graph As Panel
    Friend WithEvents Label88 As Label
    Friend WithEvents pnl_cvparameter As Panel
    Friend WithEvents pnl_focus As Panel
    Friend WithEvents Label82 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents listsetcontents As ListBox
    Friend WithEvents btntosetting01 As Button
    Friend WithEvents btntosetting02 As Button
    Friend WithEvents lblcur_focus_after As Label
    Friend WithEvents lblcur_focus_before As Label
    Friend WithEvents lblcur_load1 As Label
    Friend WithEvents lblcur_loopcount As Label
    Friend WithEvents lblcur_interval As Label
    Friend WithEvents lblcur_addcount As Label
    Friend WithEvents lblcur_namedpipe As Label
    Friend WithEvents lblcur_rendou As Label
    Friend WithEvents pnlview_window As Panel
    Friend WithEvents btnforward As Button
    Friend WithEvents piccap As PictureBox
    Friend WithEvents btnback As Button
    Friend WithEvents PictureBoxIpl1 As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents numloadno As NumericUpDown
    Friend WithEvents piczoom As PictureBox
    Friend WithEvents chkloading As CheckBox
    Friend WithEvents btncap As Button
    Friend WithEvents chkoverwrite As CheckBox
    Friend WithEvents txtclickcount As TextBox
    Friend WithEvents chklimit As CheckBox
    Friend WithEvents txt11 As TextBox
    Friend WithEvents txtno_comment As TextBox
    Friend WithEvents txt12 As TextBox
    Friend WithEvents txt21 As TextBox
    Friend WithEvents picview_capture As PictureBox
    Friend WithEvents txt22 As TextBox
    Friend WithEvents pnlview_control As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label32 As Label
    Friend WithEvents txtsavetempnumber As TextBox
    Friend WithEvents numtemp As NumericUpDown
    Friend WithEvents btntemp As Button
    Friend WithEvents trktemp As TrackBar
    Friend WithEvents pictempipl As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents btnview_close As Button
    Friend WithEvents applysize As DataGridViewButtonColumn
    Friend WithEvents Comment As DataGridViewTextBoxColumn
    Friend WithEvents windowltx As DataGridViewTextBoxColumn
    Friend WithEvents windowlty As DataGridViewTextBoxColumn
    Friend WithEvents windowrbx As DataGridViewTextBoxColumn
    Friend WithEvents windowsrby As DataGridViewTextBoxColumn
    Friend WithEvents Label77 As Label
    Friend WithEvents lblcur_firstsplit As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ExpandTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewTableToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtvideo_pass As TextBox
    Friend WithEvents pnl_video As Panel
    Friend WithEvents btnselectvideo As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents chkvideo_showwinvideo As CheckBox
    Friend WithEvents numwin_interval As NumericUpDown
    Friend WithEvents Label95 As Label
    Friend WithEvents numwin_locy As NumericUpDown
    Friend WithEvents numwin_locx As NumericUpDown
    Friend WithEvents Label93 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents numvideo_sizey As NumericUpDown
    Friend WithEvents numvideo_sizex As NumericUpDown
    Friend WithEvents Label84 As Label
    Friend WithEvents txtvideo_startat As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents Label80 As Label
    Friend WithEvents chkvideo_autoseek As CheckBox
    Friend WithEvents chkshowvideo As CheckBox
    Friend WithEvents Label78 As Label
    Friend WithEvents numpresstime As NumericUpDown
    Friend WithEvents Label96 As Label
    Friend WithEvents lblset_video As Label
    Friend WithEvents btncur_showvideo As Button
    Friend WithEvents chkvideo_manualstart As CheckBox
    Friend WithEvents Label72 As Label
    Friend WithEvents rtxtupdate As RichTextBox
    Friend WithEvents pnl_other As Panel
    Friend WithEvents Label98 As Label
    Friend WithEvents TabPage15 As TabPage
    Friend WithEvents gbcalib_m1 As GroupBox
    Friend WithEvents txtcalib_bestvalue As TextBox
    Friend WithEvents piccalib_bestresult As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents Label75 As Label
    Friend WithEvents txtcalib_nowvalue As TextBox
    Friend WithEvents Label99 As Label
    Friend WithEvents piccalib_handresult As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents Label100 As Label
    Friend WithEvents piccalib_comp As PictureBox
    Friend WithEvents btncalib_cap As Button
    Friend WithEvents btncalib_resize As Button
    Friend WithEvents gbsetting As GroupBox
    Friend WithEvents btncalib_reset As Button
    Friend WithEvents numcalib_hand_scaleheight As NumericUpDown
    Friend WithEvents gbrgb As GroupBox
    Friend WithEvents lblm1 As Label
    Friend WithEvents Label101 As Label
    Friend WithEvents numcalib_hand_bright As NumericUpDown
    Friend WithEvents btncalib_adjrgb As Button
    Friend WithEvents btncalib_adjbright As Button
    Friend WithEvents numcalib_hand_g As NumericUpDown
    Friend WithEvents numcalib_hand_r As NumericUpDown
    Friend WithEvents numcalib_hand_b As NumericUpDown
    Friend WithEvents txtcalib_save_bright As TextBox
    Friend WithEvents txtcalib_save_r As TextBox
    Friend WithEvents txtcalib_save_g As TextBox
    Friend WithEvents txtcalib_save_b As TextBox
    Friend WithEvents numcalib_hand_scalewidth As NumericUpDown
    Friend WithEvents btncalib_insert As Button
    Friend WithEvents numcalib_hand_scale As NumericUpDown
    Friend WithEvents btncalib_adjaspect As Button
    Friend WithEvents btncalib_adjscale As Button
    Friend WithEvents Label102 As Label
    Friend WithEvents Label103 As Label
    Friend WithEvents Label104 As Label
    Friend WithEvents Label105 As Label
    Friend WithEvents txtcalib_save_scale As TextBox
    Friend WithEvents txtcalib_save_scalewidth As TextBox
    Friend WithEvents txtcalib_save_scaleheight As TextBox
    Friend WithEvents pgbcalib_1 As ProgressBar
    Friend WithEvents piccalib_temp As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents piccamera As OpenCvSharp.UserInterface.PictureBoxIpl
    Friend WithEvents numcalib_bright As NumericUpDown
    Friend WithEvents numcalib_r As NumericUpDown
    Friend WithEvents numcalib_scaleheight As NumericUpDown
    Friend WithEvents numcalib_g As NumericUpDown
    Friend WithEvents numcalib_b As NumericUpDown
    Friend WithEvents numcalib_scalewidth As NumericUpDown
    Friend WithEvents numcalib_scale As NumericUpDown
    Friend WithEvents txtcalib_count As TextBox
    Friend WithEvents grpcalib_1 As GroupBox
    Friend WithEvents listcalib_2 As ListBox
    Friend WithEvents txtcalib_numbers As TextBox
    Friend WithEvents Label106 As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents Label108 As Label
    Friend WithEvents txtcalib_compfilename As TextBox
    Friend WithEvents txtcalib_1 As TextBox
    Friend WithEvents listcalib_1 As ListBox
    Friend WithEvents btnpreview As Button
    Friend WithEvents piccalib_resize As PictureBox
    Friend WithEvents chkcalib_1 As CheckBox
    Friend WithEvents chkcalib_2 As CheckBox
    Friend WithEvents txtcalib_hand_name As TextBox
    Friend WithEvents txtcalib_max As TextBox
    Friend WithEvents txtcalib_scaleorcolor As TextBox
    Friend WithEvents timcamera As Timer
    Friend WithEvents timcalib As Timer
    Friend WithEvents btntosetting03 As Button
    Friend WithEvents Label110 As Label
    Friend WithEvents Label109 As Label
    Friend WithEvents Label111 As Label
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox8 As PictureBox
    Friend WithEvents PictureBox11 As PictureBox
    Friend WithEvents PictureBox12 As PictureBox
    Friend WithEvents SaveProfileSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteSelectedProfileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents StartMonitoringMToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents no As DataGridViewTextBoxColumn
    Friend WithEvents send As DataGridViewTextBoxColumn
    Friend WithEvents key As DataGridViewTextBoxColumn
    Friend WithEvents rate As DataGridViewTextBoxColumn
    Friend WithEvents sleep As DataGridViewTextBoxColumn
    Friend WithEvents timing As DataGridViewTextBoxColumn
    Friend WithEvents darksleep As DataGridViewTextBoxColumn
    Friend WithEvents darkthr As DataGridViewTextBoxColumn
    Friend WithEvents seektime As DataGridViewTextBoxColumn
    Friend WithEvents graph_count As DataGridViewTextBoxColumn
    Friend WithEvents graph_rate As DataGridViewTextBoxColumn
    Friend WithEvents graph_view As DataGridViewTextBoxColumn
    Friend WithEvents posx As DataGridViewTextBoxColumn
    Friend WithEvents posy As DataGridViewTextBoxColumn
    Friend WithEvents sizex As DataGridViewTextBoxColumn
    Friend WithEvents sizey As DataGridViewTextBoxColumn
    Friend WithEvents ltx As DataGridViewTextBoxColumn
    Friend WithEvents lty As DataGridViewTextBoxColumn
    Friend WithEvents rbx As DataGridViewTextBoxColumn
    Friend WithEvents rby As DataGridViewTextBoxColumn
    Friend WithEvents rdocalib_aspect_to43 As RadioButton
    Friend WithEvents rdocalib_aspect_to169 As RadioButton
    Friend WithEvents rdocalib_aspect_none As RadioButton
    Friend WithEvents btnshow_chart As Button
    Friend WithEvents chkshow_text As CheckBox
    Friend WithEvents txtpass_rtf As TextBox
    Friend WithEvents Label112 As Label
    Friend WithEvents btntext_createtext As Button
    Friend WithEvents TabPage16 As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label118 As Label
    Friend WithEvents Label117 As Label
    Friend WithEvents Label116 As Label
    Friend WithEvents link_directshowlib As LinkLabel
    Friend WithEvents Label113 As Label
    Friend WithEvents link_opencvsharp As LinkLabel
    Friend WithEvents link_inteltbb As LinkLabel
    Friend WithEvents Label114 As Label
    Friend WithEvents Label115 As Label
    Friend WithEvents rtxtlicense As RichTextBox
    Friend WithEvents link_dobon As LinkLabel
    Friend WithEvents btntosetting04 As Button
    Friend WithEvents LicenseLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UploadTheCurrentProfileUToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents numtextwindow_sizex As NumericUpDown
    Friend WithEvents numtextwindow_sizey As NumericUpDown
    Friend WithEvents OpenTextWindowWToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblcur_showvideo As Label
    Friend WithEvents lblset_text As Label
    Friend WithEvents btncur_showtext As Button
    Friend WithEvents lblcur_showtextwindow As Label
    Friend WithEvents Label119 As Label
    Friend WithEvents txtreset_ash_key As TextBox
    Friend WithEvents txtundo_ash_key As TextBox
    Friend WithEvents txtskip_ash_key As TextBox
    Friend WithEvents numskip_ash As NumericUpDown
    Friend WithEvents numundo_ash As NumericUpDown
    Friend WithEvents numreset_ash As NumericUpDown
    Friend WithEvents timash_hotkey_sleep As Timer
    Friend WithEvents lblcur_load10 As Label
    Friend WithEvents lblcur_load9 As Label
    Friend WithEvents lblcur_load8 As Label
    Friend WithEvents lblcur_load7 As Label
    Friend WithEvents lblcur_load6 As Label
    Friend WithEvents lblcur_load5 As Label
    Friend WithEvents lblcur_load4 As Label
    Friend WithEvents lblcur_load3 As Label
    Friend WithEvents lblcur_load2 As Label
    Friend WithEvents btntext_openfolder As Button
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CreateTextFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenTextFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents chkmonitor_sizestate As CheckBox
    Friend WithEvents DeleteAddTemplateImageToolStripMenuItem As ToolStripMenuItem
End Class
