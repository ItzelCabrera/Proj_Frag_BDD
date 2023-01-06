use master
go

/* a) Determinar el total de las ventas de los productos con la categor�a que se provea de argumento de entrada en la consulta,
   para cada uno de los territorios registrados en la base de datos. */ 
create or alter procedure ca_selectTotalProd (@cat int) as
begin
	BEGIN TRANSACTION 
	BEGIN TRY
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

		--confirmamos la transaccion
		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		--ocurri� un error, deshacemos los cambios 
		ROLLBACK TRANSACTION
		if not exists(select * from [LS_AW_PRODUCTION].AW_Production.Production.ProductCategory
					  where ProductCategoryID = @cat )
			select -1 -- no existe la categoria
	END CATCH
end
go

/* b) Determinar el producto m�s solicitado para la regi�n (atributo group de salesterritory) 
   �Noth America� y en que territorio de la regi�n tiene mayor demanda. */
create or alter procedure cb_selectMostProd as
begin
	BEGIN TRANSACTION 
	BEGIN TRY
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

		--confirmamos la transaccion
		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		--ocurri� un error, deshacemos los cambios 
		ROLLBACK TRANSACTION
	END CATCH
end
go

/* c) Actualizar el stock disponible en un 5% de los productos de la categor�a que se provea como argumento de entrada en una 
localidad que se provea como entrada en la instrucci�n de actualizaci�n. */ 
create or alter procedure cc_updateLocation (@localidad int, @cat int) as
begin
	BEGIN TRANSACTION 
	BEGIN TRY
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

		--confirmamos la transaccion
		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		--ocurri� un error, deshacemos los cambios 
		ROLLBACK TRANSACTION
		if not exists(select *
		from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii
		where pii.LocationID = @localidad and
		ProductID in (
			select ProductID
			from [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory
			where ProductCategoryID = @cat
		)) 
		begin
			if exists(select * from	 [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii
					  where pii.LocationID = @localidad)
				select -3 -- No existe la Categoria
			else
				select -2 -- No existe la localidad
		end
	END CATCH
end
go

/* d) Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran. */ 
create or alter procedure cd_TerritoryCli as
begin
	BEGIN TRANSACTION 
	BEGIN TRY
		select c.TerritoryID as Territorio_Cli, soh.TerritoryID as Territorio_Ord
		from [LS_AW_SALES].AW_Sales.Sales.Customer c
		inner join 
		[LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader soh
		on c.CustomerID != soh.CustomerID
		where soh.SalesOrderID in (select SalesOrderID from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader 
			where CustomerID = c.CustomerID)
		group by c.TerritoryID, soh.TerritoryID

		--confirmamos la transaccion
		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		--ocurri� un error, deshacemos los cambios 
		ROLLBACK TRANSACTION
	END CATCH
end
go

/* e) Actualizar la cantidad de productos de una orden que se provea como argumento en la instrucci�n de actualizaci�n. */ 
create or alter procedure ce_updateSales (@qty int, @salesID int, @productID int) as
begin
	BEGIN TRANSACTION 
	BEGIN TRY
		--actualizando venta
		update [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail 
		set OrderQty = OrderQty + @qty
		where SalesOrderID = @salesID and ProductID = @productID

		declare @locationID int
		set @locationID = (select top 1 LocationID from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
			where ProductID = @productID and Quantity >= @qty) --asignando a que locaci�n se le retirar� stock

		--actualizando stock
		update [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
		set Quantity = Quantity - @qty
		where ProductID = @productID and LocationID = @locationID

		--mostramos los cambios
		select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail 
		where SalesOrderID = @salesID and ProductID = @productID

		--confirmamos la transaccion
		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		--ocurri� un error, deshacemos los cambios 
		ROLLBACK TRANSACTION
		if not exists(select top 1 LocationID from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
	                  where ProductID = @productID and Quantity >= @qty )
			select -4 --en el caso de que no existan productos en existencia
		if not exists(select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail 
		              where SalesOrderID = @salesID and ProductID = @productID)
			select -5 --en caso de que el producto u orden no existen
	END CATCH
end
go

/* f) Actualizar el m�todo de env�o de una orden que se reciba como argumento en la instrucci�n de actualizaci�n. */
create or alter procedure cf_updateShip (@method int,@salesID int) as
begin
	BEGIN TRANSACTION 
	BEGIN TRY
		update [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
		set ShipMethodID = @method
		where SalesOrderID = @salesID

		select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
		where SalesOrderID = @salesID

		--confirmamos la transaccion
		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		--ocurri� un error, deshacemos los cambios 
		ROLLBACK TRANSACTION
		if not exists(select * from [LS_AW_SALES].AW_Sales.Sales.SalesOrderHeader
				      where SalesOrderID = @salesID)
			select -7
		if not exists(select * from [LS_AW_OTHERS].AW_Others.Purchasing.ShipMethod
				  where ShipMethodID = @method)
		    select -6
	END CATCH
end
go

/* g) Actualizar el correo electr�nico de una cliente que se reciba como argumento en la instrucci�n de actualizaci�n. */
create or alter procedure cg_updateEmail (@customerID int,@newEmail nvarchar(50)) as
begin
	BEGIN TRANSACTION 
	BEGIN TRY
		update [LS_AW_OTHERS].AW_Others.Person.EmailAddress	
		set EmailAddress = @newEmail
		where BusinessEntityID = (
				select PersonID from [LS_AW_SALES].AW_Sales.Sales.Customer
				where CustomerID = @customerID)

		select * from [LS_AW_OTHERS].AW_Others.Person.EmailAddress
		where BusinessEntityID = (
			select PersonID from [LS_AW_SALES].AW_Sales.Sales.Customer
			where CustomerID = @customerID)

		--confirmamos la transaccion
		COMMIT TRANSACTION 
	END TRY

	BEGIN CATCH
		--ocurri� un error, deshacemos los cambios 
		ROLLBACK TRANSACTION
		if not exists(select * from [LS_AW_SALES].AW_Sales.Sales.Customer
				  where CustomerID = @customerID and PersonID is not null)
			select -8
	END CATCH
end
go