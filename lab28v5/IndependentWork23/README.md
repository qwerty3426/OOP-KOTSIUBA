# IndependentWork23

## Тема
Adapter + Facade + Proxy: кеш і ліміти

## Варіант
19 — Управління доступом до ресурсів

## Реалізовані патерни

### Adapter
- IResourceAccessor
- LegacyResourceHandler
- ResourceAccessAdapter

### Facade
- AuthenticationService
- AuthorizationService
- ResourceFacade

### Proxy
- IFileDownloader
- RealFileDownloader
- LoggingFileDownloaderProxy

## Опис роботи
Програма демонструє використання трьох структурних патернів:

Adapter використовується для сумісності старої системи доступу до ресурсів із новим інтерфейсом.

Facade спрощує процес авторизації та перевірки доступу до ресурсів через один метод.

Proxy додає контроль доступу до завантаження файлів, реалізує кешування, логування та обмеження кількості запитів.

## Запуск

```bash
dotnet run