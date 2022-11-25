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
create procedure ca_selectTotalProd (@cat varchar(5)) as
begin
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
	order by soh.TerritoryID
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
		where TerritoryID= (select TerritoryID from Sales.SalesTerritory where [Group] = "North America")
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
go



/* e) Actualizar la cantidad de productos de una orden que se provea como argumento en la instrucción de actualización. */ 
create procedure ce_updateSales (@qty int,@salesID int, @productID int) as
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
				end
			else
				begin 
					select null --en el caso de que no existan productos en existencia
				end

		end
	else
		begin
			select null --en caso de que el producto u orden no existen
		end
end
go

exec ce_updateSales 1,43659,776
go

select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail 
where SalesOrderID = 43659 and ProductID = 776
go



/* f) Actualizar el método de envío de una orden que se reciba como argumento en la instrucción de actualización. */
create procedure cf_updateShip (@method int,@salesID int) as
begin
	if exists(select * from [LS_AW_OTHERS].AW_Others.Purchasing.ShipMethod
		where ShipMethodID = @method)
		begin
			update [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
			set ShipMethodID = @method
			where SalesOrderID = @salesID
		end
	else
		begin
			select null
		end
end
go	

exec cf_updateShip 3,43659
go

select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
where SalesOrderID = 43659
go



/* g) Actualizar el correo electrónico de una cliente que se reciba como argumento en la instrucción de actualización. */
create procedure cg_updateEmail (@customerID int,@newEmail nvarchar(50)) as
begin
	if exists(select * from [LS_AW_SALES].AW_Sales.Sales.Customer
	where CustomerID = @customerID and PersonID is not null)
		begin
			update [LS_AW_OTHERS].AW_Others.Person.EmailAddress	
			set EmailAddress = @newEmail
			where BusinessEntityID = (
					select PersonID from [LS_AW_SALES].AW_Sales.Sales.Customer
					where CustomerID = @customerID)
		end
	else
		begin
			select null
		end
end
go	

exec cg_updateEmail 11000,'skrr@gmail.com'
go

select * from [LS_AW_OTHERS].AW_Others.Person.EmailAddress
where BusinessEntityID = (
	select PersonID from [LS_AW_SALES].AW_Sales.Sales.Customer
	where CustomerID = 11000)
go