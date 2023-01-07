exec crear_servidores_local 'PC28-LABTELE2', 'PC27-LABTELE2', 'PC30-LABTELE2' -- production / sales / others
go

exec ca_selectTotalProd 1;
go

exec cb_selectMostProd;
go

exec cc_updateLocation 10, 1
go

exec cd_TerritoryCli;
go

exec ce_updateSales 1,43659,776;
go

exec cf_updateShip 5,43659;
go

exec cg_updateEmail 11000,'it@gmail.com';
go

begin tran			
begin try
	update [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
	set Quantity = Quantity + ROUND((Quantity * 0.05), 0)
	from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory as pii
	where pii.LocationID = 10 and
	ProductID in (
		select ProductID
		from [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory
		where ProductCategoryID = 1
	)
	commit tran
end try
begin catch
	ROLLBACK tran
end catch
go

-----------------------------------------------------------------------------------
-- STORED PROCEDURE 1
CREATE OR ALTER PROCEDURE sp_updateQuantity(@p_location int, @p_category int) AS
BEGIN 
	BEGIN TRAN 
		UPDATE [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory 
		set Quantity = Quantity + ROUND(Quantity * .05,0)
		FROM [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory pi3 
		WHERE pi3.LocationID = @p_location AND pi3.ProductID in (SELECT p.ProductID
																 FROM [LS_AW_PRODUCTION].AW_Production.Production.Product p 
											                     WHERE p.ProductSubcategoryID in (SELECT ps2.ProductSubcategoryID  
																	   			 			      FROM [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory ps2
																			                      WHERE ps2.ProductCategoryID =@p_category)									
																)

	IF EXISTS (SELECT *
				FROM [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory pi2 
				WHERE pi2.LocationID = @p_location and pi2.ProductID in (SELECT p.ProductID 
																		 FROM [LS_AW_PRODUCTION].AW_Production.Production.Product p 
																		 WHERE p.ProductSubcategoryID in (SELECT ps2.ProductSubcategoryID  
																								   		  FROM [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory ps2
																										  WHERE ps2.ProductCategoryID = @p_category)
																			)		
	            )
	            BEGIN 
	            	SELECT *
					FROM [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory pi2 
					WHERE pi2.LocationID = @p_location and pi2.ProductID in (SELECT p.ProductID 
																   FROM [LS_AW_PRODUCTION].AW_Production.Production.Product p 
																   WHERE p.ProductSubcategoryID in (SELECT ps2.ProductSubcategoryID  
																						   			 FROM [LS_AW_PRODUCTION].AW_Production.Production.ProductSubcategory ps2
																								     WHERE ps2.ProductCategoryID = @p_category)
																	)
	            	COMMIT TRAN
	            END
	 ELSE    
	 	BEGIN 	 	
	 		PRINT 'NO SE PUDO EJECUTAR LA TRANSACCION'
			ROLLBACK TRAN
		END
END	
GO
												
-- STORED PROCEDURE 2											
CREATE OR ALTER PROCEDURE sp_orderQty(@p_SalesOrderDetailID int,@p_OrderQty int)
AS 
BEGIN 
	BEGIN TRAN 
		declare @v_productid as INT;
		declare @v_locationid as INT;
		update [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail set OrderQty = @p_OrderQty where SalesOrderDetailID = @p_SalesOrderDetailID
		--Guardando el ProductID del producto de dicha orden
		SELECT @v_productid = sod1.ProductID 
		FROM [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail sod1 
		WHERE SalesOrderDetailID = @p_SalesOrderDetailID
		--Guardando la locacion del producto de dicha orden
		select @v_locationid = pi2.LocationID 
		from [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory pi2 
		where pi2.ProductID = @v_productid
		-- Actualizando la cantidad del inventario del producto de dicha orden
		update [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory
		set Quantity = Quantity - @p_OrderQty
		where productID = @v_productid
		IF EXISTS (SELECT *
			       FROM [LS_AW_SALES].AW_Sales.Sales.SalesOrderDetail sod
			       inner join [LS_AW_PRODUCTION].AW_Production.Production.Product p 
			       on sod.ProductID = p.ProductID and sod.SalesOrderDetailID = @p_SalesOrderDetailID)
			BEGIN 
				COMMIT TRAN 
				-- Mostrando el Inventario Actulizado
				SELECT * 
				FROM  [LS_AW_PRODUCTION].AW_Production.Production.ProductInventory pii4 
				WHERE pii4.ProductID = @v_productid 
				AND pii4.LocationID = @v_locationid
			END
		ELSE    
	 	BEGIN 	 	
	 		PRINT 'NO SE PUDO EJECUTAR LA TRANSACCION'
			ROLLBACK TRAN
		END
END
GO

-- EJECUCION DE PRUEBA
EXEC sp_orderQty 2995, 11		
GO

-- AUMENTAR CANTIDAD AL STOCK 
EXEC sp_updateQuantity 60, 1
GO
