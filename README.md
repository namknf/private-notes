# PrivateNotes

Представляю вашему вниманию созданное мной приложение для сохранения приватных заметок пользователя.

## Стек технологий

_Backend:_

- Язык программирования C#;
- Фреймворк ASP.NET Core;
- PostgreSQL в качестве СУБД.

_Frontend:_

- HTML и CSS;
- Библиотека Bootstrap для упрощения работы над внешним видом.

## Используемые инструменты

- Visual Studio 2019 - среда разработки;
- Postman - для тестирования API;
- Docker - для развертывания окружения базы данных;
- pgAdmin 4 и консоль для работы с базой данных.

### Для регистрации и авторизации были использованы следующие библиотеки:

- `System.IdentityModel.Tokens.Jwt` (для работы с Jwt)
- `Npgsql.EntityFrameworkCore.PostgreSQL`
  `Microsoft.EntityFrameworkCore.Tools` (для подключения базы данных и работы с ней)
- `BCrypt.Net-Next` (для одностороннего шифрования данных)
- `AutoMapper.Extensions.MicrosoftDependencyInjection` (для проецирования одной модели на другую)
