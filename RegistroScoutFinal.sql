use master
go
drop database if exists ElSalvadorRegistroScouts
go
create database ElSalvadorRegistroScouts
go
use ElSalvadorRegistroScouts
GO



CREATE TABLE Religion
(idReligion int identity(1,1) primary key not null,
nombre varchar(45),
baja tinyint)

CREATE TABLE EstadoCivil
(idEstadoCivil int identity(1,1) primary key not null,
estadoCivil varchar(45),
baja tinyint)

CREATE TABLE Escolaridad
(idEscolaridad int identity(1,1) primary key not null,
grado varchar(45),
baja tinyint)

CREATE TABLE Departamentos
(idDepartamento int  identity(1,1) primary key not null,
nombre varchar(45) not null,
clave varchar(5) not null,
baja tinyint)

CREATE TABLE Municipios
(idMunicipio int identity(1,1) primary key not null,
nombre varchar(45) not null,
baja tinyint,
idDepartamento int not null references Departamentos(idDepartamento))

CREATE TABLE Domicilios
(idDomicilio int identity(1,1) primary key not null,
calleNumero varchar(200) not null,
colonia varchar(80) not null,
codigoPostal varchar(5),
baja tinyint,
idMunicipio int not null references Municipios(idMunicipio),
entreCalles varchar(80),
referencia varchar(80),
contacto varchar(50) not null,
telefono varchar(20) not null)


CREATE TABLE Provincias
(idProvincia int identity(1,1) not null primary key,
nombre varchar(45) not null,
baja tinyint,
clave varchar(3) not null,
idRegion int not null)

CREATE TABLE Anuncios
(idAnuncio int identity(1,1) not null primary key,
mensaje varchar(100) not null,
vigencia date not null,
baja tinyint,
idProvincia int not null references Provincias(idProvincia))

CREATE TABLE Distritos
(idDistrito int identity(1,1) not null primary key,
nombre varchar(45) not null,
numero smallint not null,
baja tinyint,
idProvincia int not null references Provincias(idProvincia))

CREATE TABLE Localidades
(idLocalidad int identity(1,1) not null primary key,
nombre varchar(45) not null,
domicilioCorrespondencia varchar(50) not null, 
baja tinyint)

CREATE TABLE Grupos
(idGrupo int identity(1,1) not null primary key,
nombre varchar(70) not null,
fundacion date not null,
grupoNum smallint not null CHECK (grupoNum > 0),
horario varchar(120),
baja tinyint,
idDistrito int not null references Distritos(idDistrito),
idLocalidad int not null references Localidades(idLocalidad),
fechaRegistro date not null,
registrado tinyint)

CREATE TABLE TotalSeccion
(idTotalSeccion int identity(1,1) not null primary key,
lobeznas int,
scoutFemeninos int,
caminanteFemeninos int,
roverFemeninos int,
lobatos int,
scoutMasculinos int,
caminanteMasculinos int,
roverMasculinos int,
scouter int,
dirigente int,
padreScout int,
idGrupo int not null references Grupos(idGrupo),
mes tinyint CHECK(mes>=0),
anio smallint CHECK(anio>=0))

CREATE TABLE Secciones
(idSeccion int identity(1,1) NOT NULL primary key,
Nombre varchar(50) not null,
Descripcion varchar(80),
baja tinyint,
rangoInicio int not null CHECK (rangoInicio > 0),
rangoFin tinyint CHECK (rangoFin > 0),
sexo char(1) not null)

CREATE TABLE Miembros
(idMiembro int identity(1,1) not null primary key,
cum varchar(10) UNIQUE,
nombre varchar(50) not null,
paterno varchar(45),
materno varchar(45),
estatus tinyint,
baja tinyint,
idDatoPersonal int not null ,
idSeccion int not null references Secciones(idSeccion),
idGrupo int not null references Grupos(idGrupo),
fotoFileName varchar(100),
fechaNacimiento date not null,
sexo char(1) not null,
particular varchar(30),
oficina varchar(30),
movil varchar(30) not null,
email varchar(45),
ocupaci�n VARCHAR(45) not null,
observaci�n varchar(200),
idDomicilio int not null references Domicilios(idDomicilio),
idReligion int not null references Religion(idReligion), 
idEscolaridad int not null references Escolaridad(idEscolaridad),
idEstadoCivil int not null references EstadoCivil(idEstadoCivil))


CREATE TABLE FichasMedicas
(idFichas int not null identity(1,1) primary key,
idMiembro int not null references Miembros(idMiembro),
contacto1 varchar(100) not null,
contacto2 varchar(100),
parentesco1 varchar(30) not null,
parentesco2 varchar(30),
telefono1 varchar(20) not null,
telefono2 varchar(20),
email varchar(50),
sangre varchar(50),
peso decimal(4,2), check (peso > 0),
estatura decimal(4,2), check (estatura > 0),
noafilacion varchar(25),
ss tinyint,
ssOtro varchar(20),
piePlano varchar(2),
ortopedico varchar(2),
operacion varchar(2),
operacionObs varchar(50),
limitacion varchar(2),
limitacionObs varchar(50),
transfusion varchar(2),
transfunsionObs varchar(50),
alergia varchar(2),
alergiaObs varchar(50),
cronica varchar(2),
cronicaObs varchar(50),
tratamiento varchar(5),
tratamientoObs varchar(50),
Oido varchar(2),
OidoObs varchar(50),
protesis varchar(2),
protesisObs varchar(50),
dieta varchar(2),
dietaObs varchar(50),
tabaco varchar(2),
varcharObs varchar(50),
vacunacion varchar(2),
mujer varchar(2),
natacion tinyint,
fecha date,
imagen varchar(50))

CREATE TABLE Eventos
(idEvento int identity(1,1) NOT NULL primary key,
fechaInicio date not null,
fechaFin date,
numResponsables smallint not null CHECK (numResponsables > 0),
numIntagrantes smallint not null CHECK (numIntagrantes > 0),
minIntegrantes smallint not null CHECK (minIntegrantes > 0),
baja tinyint,
nombre varchar(100) not null,
esDolar tinyint not null CHECK (esDolar>0),
importe money not null CHECK (importe > 0),
descripcion varchar(200))

CREATE TABLE Funciones
(idFuncion int identity(1,1) not null primary key,
nombre varchar(45) not null,
baja tinyint,
idNivel int not null)

CREATE TABLE EventosFunciones
(idEventosFunciones int not null identity(1,1) primary key,
idFuncion int not null references Funciones(idFuncion),
idEvento int not null references Eventos(idEvento))

CREATE TABLE Perfiles
(idPerfil int identity(1,1) not null primary key,
nombre varchar(45) not null,
baja tinyint)

CREATE TABLE Inscripciones
(idInscripcion int identity(1,1) not null primary key,
fechaInicio date not null,
fechaFin date,
baja tinyint,
idMiembro int not null references Miembros(idMiembro)) 

CREATE TABLE Usuarios
(idUsuario int identity(1,1) not null primary key,
pass varchar(500) not null,
estatus tinyint not null,
baja tinyint,
idMiembro int not null references Miembros(idMiembro),
idPerfil int not null references Perfiles(idPerfil))

CREATE TABLE Movimientos
(idMovimiento int identity(1,1) not null primary key,
descripcion varchar(50),
baja tinyint)

CREATE TABLE Bitacora
(idBitcora int identity(1,1) not null primary key,
idMiembro int not null references Miembros(idMiembro),
fecha date not null,
idMovimiento int not null references Movimientos(idMovimiento))

CREATE TABLE EventoSeccion
(idEventoSeccion int not null identity(1,1) primary key,
idEvento int not null references Eventos(idEvento),
idSeccion int not null references Secciones(idSeccion))


CREATE TABLE MiembroEvento
(idMiembroEvento int not null identity(1,1) primary key,
idMiembro int not null references Miembros(idMiembro),
idEvento int not null references Eventos(idEvento),
pagoPendiente tinyint)

CREATE TABLE MiembroFuncion
(idMiembroFuncion int not null identity(1,1) primary key,
idMiembro int not null references Miembros(idMiembro),
idFuncion int not null references Funciones(idFuncion),
fechaInicio date not null,
fechaFin date)


CREATE TABLE ListaNegra
(idListaNegra int identity(1,1) not null primary key,
motivo varchar(80) not null,
responsable int foreign key references Miembros(idMiembro),
baja tinyint,
idMiembro int foreign key references Miembros(idMiembro))

CREATE TABLE Cargos
(idCargo int identity(1,1) not null primary key,
nombre varchar(50) not null,
siglas varchar(50) not null,
total smallint not null,
baja smallint,
idNivel int not null,
idPerfil int not null)

CREATE TABLE EventoCargo
(idEventoCargo int not null identity(1,1) primary key,
idEvento int not null references Eventos(idEvento),
idCargo int not null references Cargos(idcargo))

CREATE TABLE MiembroCargo
(idMiembroCargo int not null identity(1,1) primary key,
idMembro int not null references Miembros(idMiembro),
idCargo int not null references Cargos(idCargo),
fecha date not null)
