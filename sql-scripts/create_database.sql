ventas_dbCREATE DATABASE IF NOT EXISTS ventas_db;
USE ventas_db;

CREATE USER IF NOT EXISTS 'ventas_owner'@'localhost' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON ventas_db.* TO 'ventas_owner'@'localhost';
FLUSH PRIVILEGES;
