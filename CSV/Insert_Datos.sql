BULK INSERT
	ListaServicios
FROM 
	'C:\Users\navas\Downloads\Pasantias\CSV\Listado_Servicios.csv'
WITH(
	FIELDTERMINATOR = ';',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)

BULK INSERT
	Marcas
FROM 
	'C:\Users\navas\Downloads\Pasantias\CSV\Listado_Marcas.csv'
WITH(
	FIELDTERMINATOR = ';',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)

BULK INSERT
	Categorias
FROM 
	'C:\Users\navas\Downloads\Pasantias\CSV\Listado_Categorias.csv'
WITH(
	FIELDTERMINATOR = ';',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)

BULK INSERT
	Productos
FROM 
	'C:\Users\navas\Downloads\Pasantias\CSV\Listado_Productos.csv'
WITH(
	FIELDTERMINATOR = ';',
	ROWTERMINATOR = '\n',
	FIRSTROW = 2
)

select*from Productos