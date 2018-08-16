# Unity2018個人用テンプレート

## 概要

- 個人用Unityテンプレートを検討する練習リポジトリです。


## 考えてること、要件メモ

- 全体

	- やること多すぎ

	- まず小目標決めて妥協していく

	- 無理しない


- Unity側

	- 極力Unity標準から外れないやり方で
		- ECS,Job System,Burstコンパイラ使っていく
		- 

	- Async/Await前提で
		- UniRx.asyncでUniTask使っていく

	- シーン間管理をシンプルに

	- トランジションも複雑なフックなく管理できるように

	- AssetBundle運用も整理
		- 最近のやり方どんな感じなのかチェック

	- iPhoneXのUI対応を考慮（？）

	- Oculus Goビルドを考慮（？）

- 運用面

	- ローカルMac miniでJenkinsによるABビルド、developブランチビルドの運用
	- HockeyAppのアップロード自動化
	- IAP課金対応も整備しておく

- APIサーバ
	- AWS API Gateway/Lambda/DynamoDBでゲームサーバを安く簡略に実装する手順を整理



`EOF`
