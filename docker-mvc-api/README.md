Документация по проекту
Запуск проекта с помощью bash-скриптов
Для запуска проекта используются bash-скрипты, расположенные в папке scripts.
Файлы пронумерованы в соответствии с порядком выполнения.
Последовательность запуска:
1_network_create.bash
2_postgres_run.bash
3_api_build.bash
4_api_run.bash
5_mvc_build.bash
6_mvc_run.bash
Каждый скрипт содержит команды Docker для выполнения соответствующего этапа запуска проекта.
Перед первым запуском необходимо выдать права на выполнение bash-скриптов:
chmod +x scripts/*.bash
Работа с базой данных PostgreSQL
PostgreSQL запускается в отдельном Docker-контейнере и доступна только внутри Docker network.
Вход в контейнер PostgreSQL
docker exec -it postgres psql -U postgres -d appdb
После выполнения команды открывается консоль PostgreSQL.
Создание таблиц
Таблицы в базе данных создаются вручную после запуска контейнера PostgreSQL.
Пример создания таблицы:
CREATE TABLE users (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL
);
Заполнение таблиц данными
INSERT INTO users (name) VALUES
('Alice'),
('Bob'),
('Charlie');
Проверка данных
SELECT * FROM users;
Выход из консоли PostgreSQL:
\q
Проверка работы проекта
После запуска всех контейнеров необходимо открыть в браузере:
http://localhost:5001
На странице отображаются данные, полученные из базы данных PostgreSQL через Web API.
