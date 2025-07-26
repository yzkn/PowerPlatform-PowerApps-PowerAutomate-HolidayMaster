# PowerPlatform-PowerApps-PowerAutomate-HolidayMaster

Power Automate で実装した祝日マスタ更新バッチと Power Apps キャンバスアプリで実装したカレンダーアプリ

---

## 備考

- [「国民の祝日」について](https://www8.cao.go.jp/chosei/shukujitsu/gaiyou.html) から直接ではなく、e-Govデータポータルのカタログから [メタデータ](https://data.e-gov.go.jp/data/api/action/package_show?id=cao_20190522_0002) を取得してから、CSVファイルのURLを取得する
- 文字コードがShift_JISのため、ラベル（「国民の祝日・休日名称」列）には未対応
  - カスタムコネクタで解決しようとしたが、実行基盤が.NET Coreのため、NuGetパッケージなしにShift_JIS対応させることができない

---

Copyright (c) 2025 YA-androidapp(https://github.com/yzkn) All rights reserved.
