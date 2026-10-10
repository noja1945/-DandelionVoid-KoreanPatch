# Dandelion Void (Demo) 비공식 한글패치

Steam 게임 **Dandelion Void Demo**의 비공식 한국어 패치입니다.
게임 원본 파일을 수정하거나 덮어쓰지 않고, 파일을 추가하는 방식으로 동작합니다.

## 다운로드

👉 **[최신 버전 받기 (Releases)](../../releases/latest)**

`DandelionVoid_KoreanPatch_vX.X.zip` 파일을 받으세요.

## 설치 방법

1. 스팀 라이브러리 → Dandelion Void Demo 우클릭 → 관리 → **로컬 파일 보기**
2. 받은 압축 파일의 내용물을 전부 그 게임 폴더에 **덮어쓰기**
3. 게임 실행 → Settings → Language → **Korean** 선택 → 재시작

- 첫 실행은 몇 초 늦게 시작될 수 있습니다.
- 관리자 권한은 필요 없습니다.

## 삭제 방법

게임 폴더에서 아래 항목을 지우면 원래대로 돌아갑니다.

- `winhttp.dll`, `doorstop_config.ini`, `.doorstop_version`
- `BepInEx` 폴더
- `Dandelion Void_Data\StreamingAssets\mods\loading\lua\korean_patch.lua`
- `Dandelion Void_Data\StreamingAssets\mods\loading\data\ko-KR_1.csv` 와 `*_2.csv` 6개

## 대응 버전

| 패치 | 게임 빌드 |
|---|---|
| v1.0 | Demo 빌드 45.9784 (2026-10-08) |

게임이 업데이트되면 새로 추가된 문장은 영어로 나올 수 있습니다.

## 저장소 구성

| 폴더 | 내용 |
|---|---|
| `translation/` | 번역 데이터 (`ko-KR_1.csv`), 언어 메뉴 표시용 파일 |
| `lua/` | 게임 언어 목록에 한국어를 추가하는 스크립트 |
| `plugin/` | 한글 폰트를 게임에 등록하는 BepInEx 플러그인 소스 코드 |

## 알려진 사항

- 터미널 명령어(`help`, `dvcs`, `open` 등)와 파일 이름은 게임 동작을 위해 영어로 두었습니다.
- 생물·식물 이름(Uproot, Stranglecord, Ponic 등)은 원어를 유지했습니다.
- 일부 백신이 `winhttp.dll`(BepInEx 로더)을 오탐할 수 있습니다. BepInEx 공식 파일입니다.

## 오역 제보

[Issues](../../issues)에 문장 위치와 내용을 남겨 주세요.

## 크레딧 및 라이선스

- 번역: 노자 (AI Claude의 도움을 받아 작업 후 검수)
- [BepInEx](https://github.com/BepInEx/BepInEx) 5.4.23.2 — MIT License
- [Noto Sans KR](https://fonts.google.com/noto/specimen/Noto+Sans+KR) — SIL Open Font License 1.1
- Dandelion Void의 모든 권리는 원 개발사에 있습니다. 이 패치는 개발사와 무관한 비공식 팬 패치입니다.
