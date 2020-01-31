# UiPath.DesktopNotification.Activities

UiPath Custom Activities for notification window on desktop.

Uipath カスタムアクティビティ で、デスクトップに通知ウィンドウを表示します。

## Component Name

DesktopNotification

デスクトップ通知

## Primary Language Select

ja en

英 日

## Summary

Show notification window on the bottom-right corner.

デスクトップにメッセージやプログレスバー（進捗率）を表示します

## Benefits

Useful to inform process messsage and progress. 

UiPath の実行中の内容を画面に表示し、進捗を確認できるようになります。

## Description

This activitiy show a window that notice process message and progress on desktop.
You can use this activity to inform process messsage and progress.

There are some parameters:

- Title
- Message
- Progress (0-100)
- WindowPosition (TopLet/TopRight/BottomLeft/BottomRigh)
- FontSize
- ColorTheme (Blue/Black/White/Gray)

ロボットが現在実行中の処理内容や、処理進捗を示すプログレスバーをデスクトップにウィンドウで表示します。
ユーザーにメッセージを伝えたいときや、処理がどこまで終わっているかを確認したい時に利用できます。

通知系のカスタムアクティビティは他にもありますが、表示後にすぐに消えてしまったり、
待機状態で処理が中断したり、プログレスバーが無いなど、丁度良いものがなかったため作成しました。

指定できるパラメータは下記になります。

- タイトル
- メッセージ
- 進捗率（0-100）
- 表示位置（右上・左上・右下・左下）
- 文字サイズ（デフォルト：12px）
- 配色（青・黒・グレー・白）



## Process/Industry

金融 & 財務 法務 人事 IT 営業 & 販売

## Tags

Desktop Demo Debug

デスクトップ デモ デバッグ
  
## Compatibility

Tested with UiPath Studio 2018.4.5, UiPath Studio 2019.4 and UiPath Studio 2019.12.

UiPath Studio 2018.4.5, UiPath Studio 2019.4 UiPath Studio 2019.12 で動作確認済み

## Dependencies

No Dependencies

依存なし

## Media

<img src="/images/window.png" alt="">
<img src="/images/demo.gif" alt="">
<img src="/images/studio.png" alt="">
<img src="/images/studio-jp.png" alt="">
