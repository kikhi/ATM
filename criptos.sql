CREATE DATABASE criptos;
USE criptos;

CREATE TABLE cajero
(
    id_cajero int NOT NULL PRIMARY KEY,
	id_cliente int FOREIGN KEY REFERENCES cliente(id_cliente),
	id_billetera int FOREIGN KEY REFERENCES billetera(id_billetera),
    sucursal char(30)
);

CREATE TABLE cliente
(
	id_cliente int NOT NULL PRIMARY KEY,
	nip int,
	nombre char(20),
	apellido_paterno char(20),
	apellido_materno char(20)
);

CREATE TABLE billetera
(
	id_billetera int NOT NULL PRIMARY KEY,
	xrp int,
	bitcoin int,
	etherium int,
	tusd int
);


