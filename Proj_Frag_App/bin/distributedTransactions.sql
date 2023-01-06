use AW_Sales

--Para la consulta E: al actualizar la cantidad de productos de una orden que se provea como 
--argumento, tambien se debe de actualizar el stock en el esquema "Producción"
GO
create OR ALTER trigger te_updateSalesProd
on AW_Sales.Sales.SalesOrderDetail 
for update as
   if exists(	select top 1 LocationID from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
				where ProductID in (select productid from inserted)
			)
		BEGIN

			declare @locationID int
			set @locationID = (select top 1 LocationID from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
				where ProductID in (select productid from inserted)) --asignando a que locación se le retirará stock

			update [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
			set Quantity = Quantity - 1
			where ProductID = (select productid   
								from inserted)  and LocationID = @locationID

		END
    else 
		BEGIN
			rollback
		END
go