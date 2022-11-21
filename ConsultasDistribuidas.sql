/* a) Determinar el total de las ventas de los productos con la categoría que se provea de argumento de entrada en la consulta,
   para cada uno de los territorios registrados en la base de datos. */ 
go

-- local 
select soh.TerritoryID, sum(t.LineTotal) as total_venta
from AdventureWorks2019.sales.SalesOrderHeader soh
inner join
(select salesorderid, productid, orderqty, linetotal
from AdventureWorks2019. sales.salesorderdetail sod
where ProductID in (
		select productid
		from AdventureWorks2019.Production.Product
		where ProductSubcategoryID in (
			select ProductSubcategoryID
			from AdventureWorks2019.Production.ProductSubcategory
			where ProductCategoryID in (
				select ProductCategoryID
				from AdventureWorks2019.Production.ProductCategory
				where ProductCategoryID = 1
				)
			)
	)
) as T
on soh.SalesOrderID = t.SalesOrderID
group by soh.TerritoryID
order by soh.TerritoryID
go

-- distribuida 
select soh.TerritoryID, sum(t.LineTotal) as total_venta
from Instancia1.AdventureWorks2019.sales.SalesOrderHeader soh
inner join
(select salesorderid, productid, orderqty, linetotal
from Instancia1.AdventureWorks2019. sales.salesorderdetail sod
where ProductID in (
		select productid
		from Instancia2.AdventureWorks2019.Production.Product
		where ProductSubcategoryID in (
			select ProductSubcategoryID
			from Instancia2.AdventureWorks2019.Production.ProductSubcategory
			where ProductCategoryID in (
				select ProductCategoryID
				from Instancia2.AdventureWorks2019.Production.ProductCategory
				where ProductCategoryID = 1
				)
			)
	)
) as T
on soh.SalesOrderID = t.SalesOrderID
group by soh.TerritoryID
order by soh.TerritoryID
go

-- procedimiento almacenado
create procedure consulta_a (@cat varchar(5)) as
begin
	declare @sql_string varchar(max)
	set @sql_string = 'select soh.TerritoryID, sum(t.LineTotal) as total_venta
		from AdventureWorks2019.sales.SalesOrderHeader soh
		inner join
		(select salesorderid, productid, orderqty, linetotal
		from AdventureWorks2019. sales.salesorderdetail sod
		where ProductID in (
				select productid
				from AdventureWorks2019.Production.Product
				where ProductSubcategoryID in (
					select ProductSubcategoryID
					from AdventureWorks2019.Production.ProductSubcategory
					where ProductCategoryID in (
						select ProductCategoryID
						from AdventureWorks2019.Production.ProductCategory
						where ProductCategoryID = '+ @cat +'
						)
					)
			)
		) as T
		on soh.SalesOrderID = t.SalesOrderID
		group by soh.TerritoryID
		order by soh.TerritoryID'
	exec(@sql_string)
end
go

exec consulta_a '1'
go

/* b) Determinar el producto más solicitado para la región (atributo group de salesterritory) 
   “Noth America” y en que territorio de la región tiene mayor demanda. */
select top 1 aux.ProductID,  solicitados from(
	select ProductID, count(*) as solicitados 
	from Sales.SalesOrderDetail
	where SalesOrderID = 
	(	select SalesOrderID from Sales.SalesOrderHeader
		where TerritoryID= (select TerritoryID from Sales.SalesTerritory where Group = "North America")
	)
) as aux 
order by aux.solicitados desc;

select top 1 aux.ProductID,  solicitados from(
	select ProductID, count(*) as solicitados 
	from Sales.SalesOrderDetail
	group by ProductID) as aux 
order by aux.solicitados desc;

/* c) Actualizar el stock disponible en un 5% de los productos de la categoría que se provea como argumento de entrada en una 
localidad que se provea como entrada en la instrucción de actualización. */ 


/* d) Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran. */ 
select *
from Sales.SalesOrderHeader

select count(*) as cuenta from(
select CustomerID
from Sales.SalesOrderHeader
where BillToAddressID != ShipToAddressID
group by CustomerID) as aux

/* e) Actualizar la cantidad de productos de una orden que se provea como argumento en la instrucción de actualización. */ 

/* f) Actualizar el método de envío de una orden que se reciba como argumento en la instrucción de actualización. */


/* g) Actualizar el correo electrónico de una cliente que se reciba como argumento en la instrucción de actualización. */
go
create procedure cg_updateEmail (@customerID int,@newEmail nvarchar(50)) as
begin
	if exists(select * from AdventureWorks2019.Sales.Customer
	where CustomerID = @customerID and PersonID is not null)
		begin
			update AdventureWorks2019.Person.EmailAddress	
			set EmailAddress = @newEmail
			where BusinessEntityID = (
					select PersonID from AdventureWorks2019.Sales.Customer
					where CustomerID = @customerID)
		end
	else
		begin
			select null
		end
end
go	

exec cg_updateEmail 11000,'adal@gmail.com'
