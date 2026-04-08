# Area Player Count

コライダー内のプレイヤーを数えてText/TextMeshPro/TextMeshProUGUIに人数をセット

## Install

### VCC用インストーラーunitypackageによる方法（おすすめ）

https://github.com/Narazaka/AreaPlayerCount/releases/latest から `net.narazaka.vrchat.area-player-count-installer.zip` をダウンロードして解凍し、対象のプロジェクトにインポートする。

### VCCによる方法

1. https://vpm.narazaka.net/ から「Add to VCC」ボタンを押してリポジトリをVCCにインストールします。
2. VCCでSettings→Packages→Installed Repositoriesの一覧中で「Narazaka VPM Listing」にチェックが付いていることを確認します。
3. アバタープロジェクトの「Manage Project」から「Area Player Count」をインストールします。

## Usage

コライダーに加えて`Area Player Count`をAdd Component。

プレイヤーの足下で判定しているので床より少し下側にまでコライダー範囲をもたせておくとよい。

## License

[Zlib License](LICENSE.txt)
