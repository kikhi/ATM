CREATE DATABASE criptos;
USE criptos;

/*    ==== Tables ====    */
CREATE TABLE cajero
(
    id_cajero int NOT NULL PRIMARY KEY,
	id_cliente int FOREIGN KEY REFERENCES cliente(id_cliente),
    sucursal char(30)
);

CREATE TABLE cliente
(
	id_cliente int NOT NULL PRIMARY KEY,
	id_billetera int FOREIGN KEY REFERENCES billetera(id_billetera),
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

/*    ==== From Admin System ====    */
-- Insert ATM 
INSERT INTO cajero (id_cajero, sucursal)
VALUES ('001', 'Zona Rio');

-- Insert client and id wallet
-- Crear primero la billetera
INSERT INTO cliente (id_cliente, id_billetera, nip, nombre, apellido_paterno, apellido_materno)
VALUES ('0001', '001', '1234', 'Cesar', 'Trujillo', 'Garay');

INSERT INTO billetera (id_billetera, bitcoin, etherium, tusd, xrp)
VALUES ('001', '0', '0', '0', '0')

INSERT INTO cliente (id_cliente, id_billetera, nip, nombre, apellido_paterno, apellido_materno)
VALUES ('0002', '002','1234', 'Luis', 'Silva', 'Reyes');

INSERT INTO billetera (id_billetera, bitcoin, etherium, tusd, xrp)
VALUES ('002', '0', '0', '0', '0')

DELETE FROM cliente WHERE id_cliente = '002';
DELETE FROM billetera WHERE id_billetera = '002';


/*    ==== From ATM ====    */
-- Insert money in wallet (First time)
 UPDATE billetera SET xrp = xrp + 5 WHERE id_billetera = '001';
 UPDATE billetera SET xrp = xrp + 5 WHERE id_billetera = '002';
 SELECT * FROM billetera WHERE id_billetera = '002';

SELECT * FROM billetera
SELECT * FROM cliente