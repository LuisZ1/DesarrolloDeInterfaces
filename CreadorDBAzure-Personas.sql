--USE personasDB
GO

CREATE TABLE Departamentos(
	IDDepartamento int IDENTITY(1,1)
	,nombreDepartamento varchar(25)

	,CONSTRAINT PK_Departamentos PRIMARY KEY (IDDepartamento)
)

CREATE TABLE Personas (
	IDPersona int IDENTITY(1,1)
	,nombrePersona varchar(30)
	,apellidosPersona varchar(30)
	,fechaNacimiento date
	,telefono varchar(12)
	,direccion varchar(50)
	,IDDepartamento int

	,CONSTRAINT PK_IDPersonas PRIMARY KEY (IDPersona)
	,CONSTRAINT FK_Departamentos FOREIGN KEY (IDDepartamento) REFERENCES Departamentos(IDDepartamento)
)
