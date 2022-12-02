/*procedimiento almacenado para creacion de los 3 servidores vinculados*/
create or alter procedure crear_servidores as
begin 
	IF 'LS_AW_PRODUCTION' NOT IN (SELECT NAME FROM sys.servers)
	begin
		/* Creación del servidor vinculado para el esquema production*/
		exec sp_addlinkedserver  
		  @server='LS_AW_PRODUCTION', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc='ls-1.database.windows.net',   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Production'; 
		exec sp_addlinkedsrvlogin  
		  @rmtsrvname = 'LS_AW_PRODUCTION',  
		  @useself = 'false',  
		  @rmtuser = 'itzeeel_cava',
		  @rmtpassword = 'itzelCV2020.';
		exec sp_serveroption 'LS_AW_PRODUCTION', 'rpc out', true;  
	end

	IF 'LS_AW_SALES' NOT IN (SELECT NAME FROM sys.servers)
	begin
		 /* Creación del servidor vinculado para el esquema sales*/
		exec sp_addlinkedserver  
		  @server='LS_AW_SALES', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc='ls-2.database.windows.net',   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Sales'; 
		exec sp_addlinkedsrvlogin  
		  @rmtsrvname = 'LS_AW_SALES',  
		  @useself = 'false',  
		  @rmtuser = 'itzeeel_cava',
		  @rmtpassword = 'itzelCV2020.';
		exec sp_serveroption 'LS_AW_SALES', 'rpc out', true;  
	end

	IF 'LS_AW_OTHERS' NOT IN (SELECT NAME FROM sys.servers)
	begin
		 /* Creación del servidor vinculado para los esquemas restantes*/
		exec sp_addlinkedserver  
		  @server='LS_AW_OTHERS', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc='ls-3.database.windows.net',   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Others'; 
		exec sp_addlinkedsrvlogin  
		  @rmtsrvname = 'LS_AW_OTHERS',  
		  @useself = 'false',  
		  @rmtuser = 'itzeeel_cava',
		  @rmtpassword = 'itzelCV2020.';
		exec sp_serveroption 'LS_AW_OTHERS', 'rpc out', true;  
	end

end
go

exec crear_servidores
go


/* a) Determinar el total de las ventas de los productos con la categoría que se provea de argumento de entrada en la consulta,
   para cada uno de los territorios registrados en la base de datos. */ 
   
create or alter procedure ca_selectTotalProd (@cat int) as
begin
if exists(
	select soh.TerritoryID, sum(t.LineTotal) as total_venta
	from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader soh
	inner join
	(select salesorderid, productid, orderqty, linetotal
	from [LS_AW_SALES].AW_Sales.Sales.salesorderdetail sod
	where ProductID in (
			select productid
			from [LS_AW_PRODUCTION].AW_Production.Production.Product 
			where ProductSubcategoryID in (
				select ProductSubcategoryID
				from [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory
				where ProductCategoryID in (
					select ProductCategoryID
					from [LS_AW_PRODUCTION].AW_Production.Production.ProductCategory
					where ProductCategoryID = @cat 
					)
				)
		)
	) as T
	on soh.SalesOrderID = t.SalesOrderID
	group by soh.TerritoryID
	order by soh.TerritoryID)
    else
		begin
			SELECT 1
		end
        
end
go

exec ca_selectTotalProd 1
go



/* b) Determinar el producto más solicitado para la región (atributo group de salesterritory) 
   “Noth America” y en que territorio de la región tiene mayor demanda. */
create or alter procedure cb_selectMostProd as
begin
	select top 1 sum(T.lineTotal) as total_ventas, p.[Name] as Nombre, p.ProductID
	from [LS_AW_PRODUCTION].AW_Production.Production.Product p
	inner join (
		select ProductID, lineTotal
		from [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail sod
		where SalesOrderID in (
			select SalesOrderID 
			from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader soh
			where TerritoryID in (
				select TerritoryID 
				from [LS_AW_SALES].AW_Sales.Sales.SalesTerritory st
				where [Group] = 'North America' )
				)
	) as T 
	on 
	p.ProductID = T.ProductID
	group by p.[Name], p.ProductID
	order by total_ventas desc
end
go 

exec cb_selectMostProd
go



/* c) Actualizar el stock disponible en un 5% de los productos de la categoría que se provea como argumento de entrada en una 
localidad que se provea como entrada en la instrucción de actualización. */ 
create or alter procedure cc_updateLocation (@localidad int, @cat int) as
begin
	if exists(select *
		from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii
		where pii.LocationID = @localidad and
		ProductID in (
			select ProductID
			from [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory
			where ProductCategoryID = @cat
		)) 
		begin
			update [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
			set Quantity = Quantity + ROUND((Quantity * 0.05), 0)
			from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii
			where pii.LocationID = @localidad and
			ProductID in (
				select ProductID
				from [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory
				where ProductCategoryID = @cat
			)

			-- Mostrar cambio
			select *
			from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii
			where pii.LocationID = @localidad and
			ProductID in (
				select ProductID
				from [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory
				where ProductCategoryID = @cat
			)
		end
	else
		begin
			if exists(select * from Production.ProductInventory as pii
					where pii.LocationID = @localidad)
				select 3 -- No existe la Categoria
			else
				select 2 -- No existe lalocalidad
		end
end
go

exec cc_updateLocation @localidad = 60, @cat = 1
go

select *
from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii
where pii.LocationID = 60 and
ProductID in (
	select ProductID
	from [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory
	where ProductCategoryID = 1
)
go



/* d) Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran. */ 
create or alter procedure cd_TerritoryCli as
begin
	select c.TerritoryID as Territorio_Cli, soh.TerritoryID as Territorio_Ord
	from [LS_AW_SALES].AW_Sales.Sales.Customer c
	inner join 
	[LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader soh
	on c.CustomerID != soh.CustomerID
	where soh.SalesOrderID in (select SalesOrderID from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader 
		where CustomerID = c.CustomerID)
	group by c.TerritoryID, soh.TerritoryID
end
go

exec cd_TerritoryCli
go



/* e) Actualizar la cantidad de productos de una orden que se provea como argumento en la instrucción de actualización. */ 
create or alter procedure ce_updateSales (@qty int, @salesID int, @productID int) as
begin
	
	if exists(select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail 
		where SalesOrderID = @salesID and ProductID = @productID)
		begin
			if exists(select top 1 LocationID from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
						where ProductID = @productID and Quantity >= @qty )
				begin
					--actualizando venta
					update [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail 
					set OrderQty = OrderQty + @qty
					where SalesOrderID = @salesID and ProductID = @productID

					declare @locationID int
					set @locationID = (select top 1 LocationID from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
						where ProductID = @productID and Quantity >= @qty) --asignando a que locación se le retirará stock

					--actualizando stock
					update [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
					set Quantity = Quantity - @qty
					where ProductID = @productID and LocationID = @locationID

					select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail 
					where SalesOrderID = @salesID and ProductID = @productID
				end
			else
				begin 
					select 4 --en el caso de que no existan productos en existencia
				end

		end
	else
		begin
			select 5 --en caso de que el producto u orden no existen
		end
end
go

exec ce_updateSales 1,43659,776
go

/* f) Actualizar el método de envío de una orden que se reciba como argumento en la instrucción de actualización. */
create or alter procedure cf_updateShip (@method int,@salesID int) as
begin
	if exists(select * from [LS_AW_OTHERS].AW_Others.Purchasing.ShipMethod
		where ShipMethodID = @method)
		begin
		if exists(select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
				where SalesOrderID = @salesID)
				begin
					update [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
					set ShipMethodID = @method
					where SalesOrderID = @salesID

					select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
					where SalesOrderID = @salesID
				end
		else
			begin 
				select 7
			end
		end
	else
		begin
			select 6
		end
end
go	

exec cf_updateShip 3,43659
go

/* g) Actualizar el correo electrónico de una cliente que se reciba como argumento en la instrucción de actualización. */
create or alter procedure cg_updateEmail (@customerID int,@newEmail nvarchar(50)) as
begin
	if exists(select * from [LS_AW_SALES].AW_Sales.Sales.Customer
	where CustomerID = @customerID and PersonID is not null)
		begin
			update [LS_AW_OTHERS].AW_Others.Person.EmailAddress	
			set EmailAddress = @newEmail
			where BusinessEntityID = (
					select PersonID from [LS_AW_SALES].AW_Sales.Sales.Customer
					where CustomerID = @customerID)

			select * from [LS_AW_OTHERS].AW_Others.Person.EmailAddress
			where BusinessEntityID = (
				select PersonID from [LS_AW_SALES].AW_Sales.Sales.Customer
				where CustomerID = @customerID)
		end
	else
		begin
			select 8
		end
end
go	

exec cg_updateEmail 11000,'skrr@gmail.com'
go

