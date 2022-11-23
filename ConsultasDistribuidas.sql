/* a) Determinar el total de las ventas de los productos con la categor�a que se provea de argumento de entrada en la consulta,
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

/* b) Determinar el producto m�s solicitado para la regi�n (atributo group de salesterritory) 
   �Noth America� y en que territorio de la regi�n tiene mayor demanda. */
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

/* c) Actualizar el stock disponible en un 5% de los productos de la categor�a que se provea como argumento de entrada en una 
localidad que se provea como entrada en la instrucci�n de actualizaci�n. */ 

select *
from Production.ProductInventory as pii
where pii.LocationID = @localidad and
ProductID in (
	select ProductID
	from Production.ProductSubcategory
	where ProductCategoryID = @cat
)

/* d) Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran. */ 
select [name]
from Sales.SalesTerritory

select * from(
(select ShipToAddressID, TerritoryID
from Sales.SalesOrderHeader) as soh
inner join
	(select AddressID, StateProvinceID
	from Person.Address) as pa
on soh.ShipToAddressID = pa.AddressID
inner join 
	(select StateProvinceID, TerritoryID
	from Person.StateProvince) as ps
on pa.StateProvinceID = ps.StateProvinceID)
where soh.TerritoryID != ps.TerritoryID

/* e) Actualizar la cantidad de productos de una orden que se provea como argumento en la instrucci�n de actualizaci�n. */ 


/* f) Actualizar el m�todo de env�o de una orden que se reciba como argumento en la instrucci�n de actualizaci�n. */


/* g) Actualizar el correo electr�nico de una cliente que se reciba como argumento en la instrucci�n de actualizaci�n. */


