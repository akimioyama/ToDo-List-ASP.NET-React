GET /api/Account
Принимает JWT токен
Выдаёт информацию о текущем пользователе в виде
{
"login": "string",
"password": "string",
"email": "string",
"fio": "string"
}

POST /api/Account
Служит для входа в учётную запись.
Принимает логин и пароль
{
"login": "string",
"password": "string",
}
Выдаёт JWT токен, например "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zaWQiOiIxMDA4IiwibmJmIjoxNjU5MjkwODY3LCJleHAiOjE2NTk4OTA4NjcsImlzcyI6IlRvZG9MaXN0U2VydmVyIiwiYXVkIjoiVG9kb0xpc3RDbGllbnQifQ.LZ-7mNfDmlwpEWEwuNumEDuCI6IdQG9QjQqNZKQ_V-k"

PUT /api/Account
Служит для изменения информации о текущем пользователе
Принимает JWT токен и новую информацию
{
"login": "string",
"password": "string",
"email": "string",
"fio": "string"
}
Возвращает true или false в зависимости от исхода операции

DELETE /api/Account
Служит для удаления текущего аккаунта
Принимает JWT токен
Возвращает true или false в зависимости от исхода операции






POST /api/User
Служит для создания нового пользователя (Регистрация)
Принимает данные
{
"id": 0,
"login": "string",
"password": "string",
"email": "string",
"fio": "string"
}
Возвращает true или false в зависимости от исхода операции

PUT /api/User
Нужна авторизация
Служит для изменения информации о конкретном пользователе
Принимает информацию
{
"id": 0,
"login": "string",
"password": "string",
"email": "string",
"fio": "string"
}
Возвращает true или false в зависимости от исхода операции

DELETE /api/User
Нужна авторизация
Служит для удаления текущего аккаунта
Принимает id
Возвращает true или false в зависимости от исхода операции

GET /api/User/{id}
Нужна авторизация
Служит для удаления текущего аккаунта
Принимает id
Возвращает true или false в зависимости от исхода операции
