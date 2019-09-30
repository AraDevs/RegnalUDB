use ElSalvadorRegistroScouts;


INSERT INTO Secciones(Nombre, Descripcion,baja,rangoInicio,rangoFin,sexo) VALUES
					('Lobato','Miembros varones con hasta 10 a�os cumplidos.',1,1,10,'m'),
					('Lobezna','Miembros hembras con hasta 10 a�os cumplidos.',1,1,10,'f'),
					('Scout masculino','Miembros varones entre los 11 y 14 a�os cumplidos.',1,11,14,'m'),
					('Scout femenino','Miembros hembras entre los 11 y 14 a�os cumplidos.',1,11,14,'f'),
					('Caminante masculino','Miembros varones entre los 15 y 17 a�os cumplidos.',1,15,17,'m'),
					('Caminante femenino','Miembros hembras entre los 15 y 17 a�os cumplidos.',1,15,17,'f'),
					('Rover masculino','Miembros varones entre los 18 y 22 a�os cumplidos.',1,18,22,'m'),
					('Rover femenino','Miembros hembras entre los 18 y 22 a�os cumplidos.',1,18,22,'f'),
					('Scouter masculino','Miembros varones mayores de 22 a�os.',1,23,null,'m'),
					('Scouter femenino','Miembros hembras mayores de 22 a�os.',1,23,null,'f'),
					('Padre Scout','Miembro reconocido.',1,23,null,'m')

INSERT INTO Religion(nombre,baja) VALUES
					('Cristiano Cat�lico',1),
					('Cristiano Evang�lico',1),
					('Testigo de Jehov�',1),
					('Budista',1),
					('Ateo',1)

INSERT INTO Escolaridad(grado,baja) VALUES
					('Primer ciclo',1),
					('Segundo ciclo',1),
					('Tercer ciclo',1),
					('Bachiller',1),
					('Universitario',1)

INSERT INTO EstadoCivil(estadoCivil,baja) VALUES
					('Soltero',1),
					('Casado',1),
					('Divorciado',1),
					('Viudo',1)


-- Comienzan inserts cuyos datos me he inventado
INSERT INTO Provincias(nombre,baja,clave,idRegion) VALUES
					('Scouts Occidente',1,'001',1),
					('Scouts Centro',1,'002',1),
					('Scouts Oriente',1,'003',1)

INSERT INTO Distritos(nombre,numero,baja,idProvincia) VALUES
					('Occidente 1',1,1,1),
					('Occidente 2',2,1,1),
					('Centro 1',1,2,1),
					('Centro 2',2,2,1),
					('Oriente 1',1,3,1),
					('Oriente 2',2,3,1)

INSERT INTO Localidades(nombre, domicilioCorrespondencia, baja) VALUES
					('Casa Scout', 'Avenida Baden Powell, 281, San Salvador',1),
					('Instituto T�cnico Ricaldone', 'Avenida Aguilares, 218, San Salvador', 1)
-- Terminan inserts cuyos datos me he inventado

INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Ahuachap�n', N'SV-AH', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Santa Ana', N'SV-SA', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Sonsonate', N'SV-SO', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'La Libertad', N'SV-LI', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Chalatenango', N'SV-CH', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'San Salvador', N'SV-SS', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Cuscatl�n', N'SV-CU', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'La Paz', N'SV-PA', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Caba�as', N'SV-CA', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'San Vicente', N'SV-SV', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Usulut�n', N'SV-US', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'Moraz�n', N'SV-MO', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'San Miguel', N'SV-SM', 1)
INSERT INTO Departamentos(nombre, clave, baja) VALUES (N'La Uni�n', N'SV-UN', 1)


INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ahuachap�n', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jujutla', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Atiquizaya', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Concepci�n de Ataco', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Refugio', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Guaymango', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Apaneca', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Francisco Men�ndez', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Lorenzo (Ahuachap�n)', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Pedro Puxtla', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tacuba', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tur�n', 1, 1)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Candelaria de la Frontera', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Chalchuapa', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Coatepeque', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Congo', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Porvenir', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Masahuat', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Metap�n', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Antonio Pajonal', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Sebasti�n Salitrillo', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Ana', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Rosa Guachipil�n', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santiago de la Frontera', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Texistepeque', 1, 2)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Acajutla', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Armenia', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Caluco', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cuisnahuat', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Izalco', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Juay�a', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nahuizalco', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nahulingo', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Salcoatit�n', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Antonio del Monte', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Juli�n', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Catarina Masahuat', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Isabel Ishuat�n', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santo Domingo de Guzm�n', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Sonsonate', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Sonzacate', 1, 3)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Alegr�a', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Berl�n', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'California', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Concepci�n Batres', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Triunfo', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ereguayqu�n', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Estanzuelas', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jiquilisco', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jucuapa', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jucuar�n', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Mercedes Uma�a', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nueva Granada', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ozatl�n', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Puerto El Triunfo', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Agust�n', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Buenaventura', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Dionisio', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Francisco Javier', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Elena', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Mar�a', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santiago de Mar�a', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tecap�n', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Usulut�n', 1, 11)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Carolina', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Chapeltique', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Chinameca', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Chirilagua', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ciudad Barrios', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Comacar�n', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Tr�nsito', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Lolotique', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Moncagua', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nueva Guadalupe', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nuevo Ed�n de San Juan', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Quelepa', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Antonio del Mosco', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Gerardo', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Jorge', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Luis de la Reina', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Miguel', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Rafael Oriente', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Sesori', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Uluazapa', 1, 13)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Arambala', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cacaopera', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Chilanga', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Corinto', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Delicias de Concepci�n', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Divisadero', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Rosario (Moraz�n)', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Gualococti', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Guatajiagua', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Joateca', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jocoaitique', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jocoro', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Lolotiquillo', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Meanguera', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Osicala', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Perqu�n', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Carlos', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Fernando (Moraz�n)', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Francisco Gotera', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Isidro (Moraz�n)', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Sim�n', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Sensembra', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Sociedad', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Torola', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Yamabal', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Yoloaiqu�n', 1, 12)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'La Uni�n', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Alejo', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Yucuaiqu�n', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Conchagua', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Intipuc�', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Jos�', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Carmen (La Uni�n)', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Yayantique', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Bol�var', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Meanguera del Golfo', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Rosa de Lima', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Pasaquina', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Anamoros', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nueva Esparta', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Sauce', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Concepci�n de Oriente', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Polor�s', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Lislique', 1, 14)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Antiguo Cuscatl�n', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Chiltiup�n', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ciudad Arce', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Col�n', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Comasagua', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Huiz�car', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jayaque', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jicalapa', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'La Libertad', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Tecla', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nuevo Cuscatl�n', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Juan Opico', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Quezaltepeque', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Sacacoyo', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Jos� Villanueva', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Mat�as', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Pablo Tacachico', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Talnique', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tamanique', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Teotepeque', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tepecoyo', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Zaragoza', 1, 4)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Agua Caliente', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Arcatao', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Azacualpa', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cancasque', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Chalatenango', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cital�', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Comapala', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Concepci�n Quezaltepeque', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Dulce Nombre de Mar�a', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Carrizal', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Para�so', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'La Laguna', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'La Palma', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'La Reina', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Las Vueltas', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nueva Concepci�n', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nueva Trinidad', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nombre de Jes�s', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ojos de Agua', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Potonico', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Antonio de la Cruz', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Antonio Los Ranchos', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Fernando (Chalatenango)', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Francisco Lempa', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Francisco Moraz�n', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Ignacio', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Isidro Labrador', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Las Flores', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Luis del Carmen', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Miguel de Mercedes', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Rafael', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Rita', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tejutla', 1, 5)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cojutepeque', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Candelaria', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Carmen (Cuscatl�n)', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Rosario (Cuscatl�n)', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Monte San Juan', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Oratorio de Concepci�n', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Bartolom� Perulap�a', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Crist�bal', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Jos� Guayabal', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Pedro Perulap�n', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Rafael Cedros', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Ram�n', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Cruz Analquito', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Cruz Michapa', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Suchitoto', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tenancingo', 1, 7)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Aguilares', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Apopa', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ayutuxtepeque', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cuscatancingo', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ciudad Delgado', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Paisnal', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Guazapa', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ilopango', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Mejicanos', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Nejapa', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Panchimalco', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Rosario de Mora', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Marcos', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Mart�n', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Salvador', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santiago Texacuangos', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santo Tom�s', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Soyapango', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tonacatepeque', 1, 6)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Zacatecoluca', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cuyultit�n', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'El Rosario (La Paz)', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jerusal�n', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Mercedes La Ceiba', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Olocuilta', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Para�so de Osorio', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Antonio Masahuat', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Emigdio', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Francisco Chinameca', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Pedro Masahuat', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Juan Nonualco', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Juan Talpa', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Juan Tepezontes', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Luis La Herradura', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Luis Talpa', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Miguel Tepezontes', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Pedro Nonualco', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Rafael Obrajuelo', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Mar�a Ostuma', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santiago Nonualco', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tapalhuaca', 1, 8)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Cinquera', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Dolores', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Guacotecti', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Ilobasco', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Jutiapa', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Isidro (Caba�as)', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Sensuntepeque', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tejutepeque', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Victoria', 1, 9)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Apastepeque', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Guadalupe', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Cayetano Istepeque', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Esteban Catarina', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Ildefonso', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Lorenzo (San Vicente)', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Sebasti�n', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'San Vicente', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santa Clara', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Santo Domingo', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tecoluca', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Tepetit�n', 1, 10)
INSERT INTO Municipios(nombre, baja, idDepartamento) VALUES (N'Verapaz', 1, 10)