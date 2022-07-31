
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
Принимает login и password
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

------------------------------------------------—

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
Служит для изменения информации о конкретном пользователе
Нужна авторизация принимает JWT токен
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
Служит для удаления текущего аккаунта
Нужна авторизация принимает JWT токен
Принимает id
Возвращает true или false в зависимости от исхода операции

GET /api/User/{id}
Нужна авторизация
Служит для удаления текущего аккаунта
Нужна авторизация принимает JWT токен
Принимает id
Возвращает true или false в зависимости от исхода операции

--------------------------------------—

GET /api/Category/{id}
Служит для выдачи списка конкретной категории
Нужна авторизация принимает JWT токен
Возвращает категорию в виде
{
"id": 1008,
"name": "Без категории"
}

GET /api/Category/{userId}
Служит для выдачи списка всех категорий конкретного пользователя
Нужна авторизация принимает JWT токен
Возвращает список категорий в виде
[
{
"id": 1008,
"name": "Без категории"
},
{
"id": 1009,
"name": "string"
},
{
"id": 1011,
"name": "categorystring23"
},
{
"id": 1012,
"name": "categorystring4"
},
{
"id": 1016,
"name": "string"
}
]

GET /api/Category
Служит для выдачи списка всех категорий текущего пользователя
Нужна авторизация принимает JWT токен
Возвращает список категорий в виде
[
{
"id": 1008,
"name": "Без категории"
},
{
"id": 1009,
"name": "string"
},
{
"id": 1011,
"name": "categorystring23"
},
{
"id": 1012,
"name": "categorystring4"
},
{
"id": 1016,
"name": "string"
}
]

POST /api/Category
Служит для создания новой категории для текущего пользователя
Нужна авторизация принимает JWT токен
Принимает данные в виде
{
"id": 0,
"name": "string"
}
Возвращает true или false в зависимости от исхода операции

PUT /api/Category
Служит для изменения категории
Нужна авторизация принимает JWT токен
Принимает данные в виде
{
"id": 0,
"name": "string"
}
Возвращает true или false в зависимости от исхода операции

DELETE /api/Category
Служит для удаления категории
Нужна авторизация принимает JWT токен
Принимает id
Возвращает true или false в зависимости от исхода операции

POST /api/Category/{userId}
Служит для создания новой категории для конкретного пользователя
Нужна авторизация принимает JWT токен
Принимает userId и данные в виде
{
"id": 0,
"name": "string"
}
Возвращает true или false в зависимости от исхода операции
