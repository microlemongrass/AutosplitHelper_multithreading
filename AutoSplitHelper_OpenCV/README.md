﻿直近の変更は★、気をつけたほうが良さそうなのは♥  

  
    
capture_setup()のサイズを変更
やったこと：  
temp_pictureフォルダとかの削除  
Croppingのタブ作成  
Croppingに必要なコントロール、フォーム追加  
CV Settingにコンボボックス追加  
やってないこと  
↑のコンボボックスの読み込み機能、保存機能l13087とか  
クロップ処理とかリサイズ処理とか  


2019/01/04　OpenCVSharp4に変更  
　　　　　　クロップ機能（→＋リサイズ機能）をつける  
　　　　　　グレースケール変換モードをつける  
  
2018/12/29　Intel-TBBは使っていないことがわかったので、ライセンス記述など削除  
　　　　　　テンプレートキャプチャの処理、仮想カメラからの映像取得(capturecv.read(frame))を中断させないようにしてみる。  
  
  
  
2018/12/27　判定方法にRGB追加。特定範囲or全範囲の通常監視/特定の色の割合  
　　　　　　back/forward/first押下時のリセットの対処修正  
　　　　　　表にrgb追加,sendの文字修正する  
　　　　　　table description修正する  
　　　　　　
  
2018/12/25  AutoSizeの設定をしてhighDPIに対応  
　　　　　　表の説明を表示するボタンを追加  
　　　　　　文字コードをShift-JIS→UTF8に。各自再保存してもらうよう促す  
　　　　　　
  
2018/12/20  
　　　　　　マッチング時にDGTableのCellValueChangedが動いて無駄に保存ダイアログが出るので、RemoveHandlerを追加  
　　　　　　監視開始時に2.bmpが参照されていた  
　　　　　　キーコードが空白になることがある。→マッチング時に落ちる  
  
2018/12/19  
			終　設定変更かつ保存していない場合、終了前に確認メッセージ  btnclosewindow.Click内  
			↑プロファイル変更時、プロファイル新規作成時にも確認すべき？  監視時のウィンドウサイズはとりあえずそのまま
			↑起動時、テンプレートの挿入辺りは除外    
			↑Datagridviewの変更確認はCellValueChanged?  プロファイル変更時、プロファイル新規作成時に確認＆初期化
			終　エラーログを残す。  ex.message & ex.StackTrace  
			終　仮想カメラ映像の切り出し方法を変更（videoio_... →capturecv.read(frame)  
			終　Update表示を消去。バージョン確認を任意に行う（起動時に確認のチェックを付けたほうがいい？）  
  
  
2018/08/09　　設定変更かつ保存していない場合、終了前に確認メッセージ  
　　　　　　終　監視リセットの挙動修正（Undo,skipをSleep中の途中で行うと止まる、Finish後にResetしても監視が再開されない）  
　　　　　　終　Rtfファイル周りいろいろ修正したい  
　　　　　　終　Sort Imagesを本体に移す  
　　　　　　　テンプレートマッチング確認用ソフトを作る。  
　　　　　　　savepicture()の.Saveがダブってるので見直す  
　　　　　　終　プロファイル削除時にプロファイルのフォルダだけ削除できていない。  
　　　　　　★　'■監視処理開始の一時フォルダ作るところをコメントアウト。  
  
2018/07/30　l6387書く場所がおかしい  
  
2018/05/22  
			終　NamedpipeON時、Resumeが動作していなかった  
			終　監視のマルチスレッド化  
			　　→インターバルを小さくするとmaxvalがバグる。原因不明  
			終　グラフ周りのcurボタンが効かなかった  
			終　Calibrationのアスペクト比変更を分かりやすく  
			終　モニタリングの進む、戻る、リセットのホットキーを作る  
			終　チャート表示機能  
  
			終　フォルダ構造について、  
			　現在　./savedata/csvfile/[profilename].csv  
			　　　　          /picture/[profilename]/n.bmp  
			　　　　          /textfile/[profilename]/n.rtf  
			　　　　          /profile/[profilename].txt  
  
			　を、  
			　　　　./savedata/[profilename]/[profilename].csv  
			　　　　                        /picture/n.bmp  
			　　　　                        /textfile/n.rtf  
			　　　　                        /[profilename].txt  
  
			終　現在のプロファイルを共有用に出力（ウィンドウは別に作ったのでそれを移す。あとzip化。ファイルパスを表示してコピーできるように）  
			終　textwindowのサイズ保存  
			終　Textwindow、Videoplayerを使用する設定にしている時、監視開始時に自動的に開くように  
			終　cvtimerとcvtimer_asyncをあわせられないか  
  
  
2018/05/20  
  
Todo  
			終　画像ディレクトリにThumb.dbが生成され、ファイル数の整合性が取れなくなる。  
			検　Reset有無とファイル数の整合性チェック  
			終　設定保存にマーク採用  
			終　接続ボタンの挙動が怪しい  
			終　接続ボタン、適用ボタン押下後、2秒程無反応時間を作る。  
			終　適用ボタンを接続中にのみ押せるようにする。  
			終　readme修正  
			終　メニューにプロファイル保存、削除、終了などの処理を書く。  
			終　Videoplayerで再生できない動画が選択されていた時の処理  
			終　プロファイル新規作成時、リセット行の色がおかしい  
			終　calibration　captureボタンの挙動見直し。  
			終　設定画面がブランクになる→非表示とか位置移動のあたりチェック  
			終　ウィンドウ位置の保存  
			無　Googleフォームをアプリ内に入れる。  
			終　新規プロファイル生成後、タイトルバーの名前が変わっていない。  
			無　Startボタンは常に押せるようにして、仮想カメラに接続しているかどうかのチェックを増やす。  
			　と思ったけど、解像度などの変更とかで開始時のチェック増やすのめんどいのでそのまま  
			うぃんどうきゃぷちゃ（平仮名）になっているのを直す  
  
2018/05/02  　
  
Todo		終　メインウィンドウのタイトルの表示バグを直す  
			終　csv,pictureのパスをメイン設定に移して場所を空ける  
			後　VLCをもっかい試す  
			終　メインウィンドウの高さを増やす（下部が途切れる報告有り）  
			終　Videoplayerのタイトルの設定書く  
			解　ウィンドウキャプチャはメインの方をSynclockしてもエラーが出るかどうか試してみる  
			終　テンプレートキャプチャ、キャリブレーション実行時、仮想カメラとの接続がされてなければエラーを出す。  
			　　設定変更後保存せずに終了しようとした時のメッセージを入れるかどうか（めんどい  
			終　Loop有時のTimeの参照先がずれている（1を見ようとすると0を見ている  
			終　Videoplayが、Delayなどを無視してマッチング時に行動を起こしてしまうのを直す（低  
			終　閾値の型をIntegerからDoubleにする（小数点以下まで見る  
			終　Viewsizeを埋め込む（最大サイズを640x360にする）  
			　　Visual Basic PowerPackで透明なコントロールを作れるらしい？  
			　https://blog.goo.ne.jp/ashm314/e/932755fa3ed6fcdd08d8867010c4d077  
			　http://butaryuu.web.fc2.com/vb_transparent.html  
			終　グラフが機能していない  
			終　英日訳  
			終　Calibrationを同一ウィンドウに埋め込む（安定性向上の為  
  
  
  
  　　　　　　
  
  
2018/05/01　別スレッドでのウィンドウキャプチャは諦めた  
			VLCPluginも上手くいかず（64bit版を試す）  
			Start時、ビデオプレイヤー表示にチェックを入れた状態でビデオプレイヤーを表示していない場合、エラーを表示させた。  
  
  			
Todo		終　numericを全選択状態にする  
			終　TabIndexの調整  
			終　Autoseek Offだと再生処理に行かない。txtlapcountで場合分け  
			Finish時に動画が最初から再生される？→-1にすればよいはず  
			無　Window Captureのタイマーを別スレッドで動かしたい（無理そう）  
			終　Expand Table時のウィンドウサイズ調整  
			終　lblcur~(current)の値が反映されていない（起動時のみ更新されている感）  
  
  
2018/04/30　Positionタブーウィンドウタイトルを何も選択していない状態でApplyを押すとエラーが出る不具合を修正  
  			
  
  
Todo		終　Video player用の設定項目のコードを書く  
			終　ウィンドウキャプチャ用のウィンドウを作成、コーディング  
			終　Video playerのコーディング  
			終　videoplayer設定項目などをプロファイル設定に追加、整理  
			終　表にラップ時間の列を増やす＋つじつまを合わせる。  
  
2018/04/26　デバイス一覧の取得方法を変更。GetDevice()  
			Video player用の設定項目を追加。形のみ。  
			Video playerウィンドウを追加。形のみ。  
  
  
  
2018/04/25　プロジェクトファイルがあぼーんしてどこまで戻ったのかよくわからなくなりました！Gitの元に戻すやつ（VS内でやってるので用語わからない）でもだめなやつ  
  
  
'2018/04/21 コードの整理  
'           追加：デバイス一覧取得をちゃんと実装  
'           追加：ビデオ再生機能を追加  
  
'2017/08/25 監視、リセット、ロードを完全分離  
  
'2017-08-21 待機時間の精度向上＋単位変更（1秒単位→0.1秒単位）  
'           loadremoverを画像1枚でするために、ループ有かつload remover有時、マッチング時にpause、アンマッチング時にresumeするようにする。  
'           追加：チェックボックス、マッチング、アンマッチングの状態表示、  
  
  
'2017-08-15 [Fix]MainwindowのAutoscaleプロパティをDpiに変更  
'           [New]キー送信にPauseを追加  
'           削除→監視/プレビュー中は設定タブを選択できないようにする。  
  
'2017/06/14     [Bug]Reset有り時、リセット後テンプレート画像が1に戻っていない  
'               [New]Livesplitの名前付きパイプを利用  
'2017/05/01　「画像の調整」のパスを、画像フォルダのパス→./[プロファイル名]　に変更。resizeフォルダを参照しないようにする。  
'            監視状況の表示  
'            プロファイルをリスト形式（編集不可）に。  
  
  
'2016/12/10 コンストラクタの使用を中止。Public Sub capture_setup()  
  
'2016/11/19 OpenCVstartにSleep追加  
  
  
'pic色情報取得は、キャプチャ画像との比較の際、毎インターバルで固定画像の色情報を取得するのは無駄であり、それを解決するためにある  
'今後の予定  
'●変数で対応できるラベルを削除して軽量化を図る  
'●対比画像のRGB値を1度だけ取得し、キャプチャ画像との比較をする。（△）  
'ok●対比画像はデスクトップ全体をキャプチャしたものと仮定し、各ラップで座標をソフト側で指定する。  
'●画像の比較をすべてのピクセルで行うのではなく、1pxないし2px飛ばしで比較をすることで軽量化を図る。（×）  
'●2枚の画像の差を検索する際、同一であるとき処理が遅くなる。余計な処理がないか確認  
'ok●監視場所、監視範囲が異なる場合、閾値の設定が絶対値だとパラメーターの設定が新たに必要になる。そのため、割合（0～100％）で設定できるようにする。  
'ok●監視範囲が異なる場合、閾値も異なる値にしなければならないこともある。Datagridviewに新たな閾値を設定する必要がある。  
'ok●監視場所が異なる場合の画像変更の条件。一番最後の画像を突破した時、Sendkeyを送って終了するようにする。（現状：ダイアログが出てそのまま何もせず終了）  
'ok●DatagridviewのRow(0)をRTAメモとして、監視中閲覧できるようにする。Next:xxxxxみたいな  
'ok●座標取得をソフトに組み込むか、別ソフトで作って同梱する。（パラメーター設定の補助）  
'okMsgBox("ウィンドウの存在を確認できませんでした。")は作業のじゃまとなるので、ウィンドウ上に表示する形式にする。  
'原因は不明だが、マルチディスプレイの場合メインではないディスプレイにタイマーがあると反応しないことがあるようだ。  