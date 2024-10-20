# ProductApp

## Требования для запуска
```net 8.0.400```</br>
```Microsoft.EntityFrameworkCore.Design 8.0.10```</br>
```Microsoft.EntityFrameworkCore 8.0.10```</br>
```Microsoft.EntityFrameworkCore.Tools 8.0.10```</br>
```Npgsql.EntityFrameworkCore.PostgreSQL 8.0.8```</br>
```Swashbuckle.AspNetCore 6.4.0```</br>
```postgres (PostgreSQL) 16.2```</br>

## Среда разработки
Visual Studio 2022

## Миграции БД
Перед запуском нужно в директории ProductApp в терминале ввести команду ```dotnet ef database update -s .\ProductApp.API\ -p .\ProductApp.DataAccess\```

## Запуск
Командой ```dotnet run``` в проекте ProductApp.API

## Функционал API
```https://localhost:7194/swagger/index.html``` и ```http://localhost:5018/swagger/index.html```</br>

### Products
GET /Products - получение списка продуктов</br>
POST /Products - создание нового продукта</br>
PUT /Products/{id} - обновление продукта</br>
DELETE /Products/{id} - удаление продукта</br>

### ProductsCategories
GET /ProductsCategories - получение списка категорий</br>
POST /ProductsCategories - создание новой категории</br>
PUT /ProductsCategories/{id} - обновление категории</br>
DELETE /ProductsCategories/{id} - удаление категории</br>
