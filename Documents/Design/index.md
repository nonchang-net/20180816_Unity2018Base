# 設計: index

[戻る](../index.md)


## 概要: 2018現在、Unityプロジェクトはどうあるべきか

2018/08/18描きかけ



## 草稿




## セットアップメモ

2018/08/18試行

- Unity HubでUnity2018.2.3f1をインストール。
	- Proライセンスはない。`必要になれば本社負担でお願いできるだろう`。Unity5系の買い切りライセンスだからなぁ……。

- Android NDK r13bを落としておく。
	- これはUnity5と共通の設定項目かなぁ……。注意せねば。というか、**まだ設定書き換えるのはやめておこう**。

- 新規プロジェクト作成。
	- Build Setting → Player Setting
		- Script Runtime VersionをMono 4.xに変更、Editorリスタート。
	- Window → Package Manager
		- Package Manager UI以外をRemove。
			- Ads: 2.0.8
			- Analytics Library: 2.0.16
			- In App Purchasing: 2.0.3
			- TextMesh Pro: 1.2.4

		- 興味あるものを追加していく。
			- Asset Bundle Browser 1.7.0
			- Burst 0.2.4-preview.24
			- Cinemachine 2.2.7
			- Entities 0.0.12-preview.18
			- Incremental Compiler 0.0.42-preview.18
			- Oculus (Android) 1.24.0
				- (Standalone)じゃないので注意。これはRiftなどWin/OSXネイティブアプリ経由起動のものになるようだ。
				- OpenVR 1.0.0は保留。あとでVRビルドに必要なものは分けて調べていく。
			- ProBuilder 3.0.3-preview.0
			- Shadergraph 1.0.0-preview.15

	- UniRx導入。UniRx.asyncは有用。
		- Asset Storeから入れておくか。6.1.2。

	- とりあえずoculus GOに興味があるのでAndroidにswitch。
		- 普段はモバイルアプリ作成=iOSにswitchするところかなぁ。

- VSCodeがエラー検知してない。
	- Asset StoreにDOTBUNNYのVSCode Integrationがあるので導入。
	- Unity読み込み時に最新版に更新するか聞かれるのでyes。
	- よし、正常に。でもVSCodeのウインドウは新規で開くのね。
		- （一時期、unity側にプラグイン不要になってた気がするけど気のせいかな……？）

- 基本構成を検討。
	- まずはScenesフォルダにスクリプト含めてガツガツ入れていくか。
		- Top.unity
		- TopScene.cs
		- Common.unity
		- CommonScene.cs
		- まずはこの構成から。

	- メモ: Zenjectは導入しない。
		- ちょっと現場で疲れた。
		- 価値はある。商業でそれなりの規模の開発チームを構成するなら、Zenject入れる判断をすると思う。Zenject前提のコーディングルール作ると治安を保ちやすい。
		- ボイラープレート増えてるのがちょっと面倒だった。
		- 結局なんらかの形でグローバルオブジェクトを保有する形の実装なのが気になった。
		- また、初期化フロー制御についてはAsync/Awaitがある今はもっとシンプルにいけるんじゃないかなぁと。
	
	- 要件定義
		- 普通のUnity。コンポーネント志向。
		- どのシーンからでも起動できる。
			- 実装は？
				- Commonシーンが必ず読み込まれる形を担保する感じだろうか。

	- UIは？
		- reference resolution: 1024x2048
		- Screen Match Mode: Expand
			- この設定が、iPadからiPhoneXまで極端に縦長な端末にも耐える設定だと思う。
			- 2048としたのは背景画像が必要な際に、テクスチャ解像度の限界を考慮した数字。
				- iPhoneXには若干足りない。スケール対応することになる。
				- そもそもこの画質のテクスチャで埋める状況がおかしい。
		- iPhone5sは除外。iPhone6,iPhoneSEを最低スペックと考える。
			- この割り切りで、圧縮テクスチャにはASTCが使える想定。
			- Androidは要調査……。

- Unity落ちる……。
	- Mac環境に何か問題があるんだろうか？



`EOF`