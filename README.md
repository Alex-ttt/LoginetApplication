# Net core web application

Приложение предоставляет доступ к пользователям и их альбомам. Является веб-сервисом. Для реализации использовались следующие средства:
  - Visual Studio 2017
  - [Apse.Net Core 2.0](https://www.microsoft.com/net/download/core) 
  - Библиотека EntityFrameworkCore
  - SQLite в качестве базы данных

## О приложении
  - При первом запуске создаётся встраиваемая (_embedded_) база данных SQlite согласно модели предметной области. База данных инициализируется данными публичного api [JSONPlaceholder ](http://jsonplaceholder.typicode.com/).
  - Существует 2 типа сущностей - пользователи и альбомы. Любой альбом должен принадлежать одному пользователю.
  - Данные предоставляются в двух форматах - JSON (_**по умолчанию**_) и XML.


## Использование
Ниже приведены способы обращения к запущенному приложению.

 Роутинг | Результат | Пример
 ------ | ------ | ------ |
 */api/users | Получить всех пользователей |http://localhost:63523/api/users/ |
 */api/users/{id:int} | Получить пользователя по его целочисленному id | http://localhost:63523/api/users/1 |
 */api/albums | Получить все альбомы | http://localhost:63523/api/albums/ |
 */api/albums/{id:int} | Получить альбом по его целочисленному id | http://localhost:63523/api/albums/5 |
 */api/users/{id:int}/albums | Получить все альбомы пользователя по его id | http://localhost:63523/api/users/4/albums |

#### **Форматы данных:**

> По умолчанию все данные предоставляются в формате JSON, но также есть возможность явно указать формат.
> Для этого необходимо добавить в конец адреса формат через слэш: xml или js. 
> Например, чтобы получить список пользователей в формате XML нужно обратиться по адресу http://localhost:63523/api/users/xml; чтобы получить пользователя с идентификатором 1 в формате JSON, можно обратиться по адресу http://localhost:63523/api/users/1 или http://localhost:63523/api/users/1/js 
