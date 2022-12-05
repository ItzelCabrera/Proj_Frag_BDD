use master
go

/*procedimiento almacenado para borrar los 3 servidores vinculados*/
create or alter procedure borrar_servidores as
begin 
	IF 'LS_AW_PRODUCTION' IN (SELECT NAME FROM sys.servers)
	begin
	    exec sp_dropserver 'LS_AW_PRODUCTION', 'droplogins';
	end

	IF 'LS_AW_SALES' IN (SELECT NAME FROM sys.servers)
	begin
		exec sp_dropserver 'LS_AW_SALES', 'droplogins';
	end

	IF 'LS_AW_OTHERS' IN (SELECT NAME FROM sys.servers)
	begin
		exec sp_dropserver 'LS_AW_OTHERS', 'droplogins';
	end

end
go

exec borrar_servidores
go

create or alter procedure crear_servidores_local (@ds_1 NVARCHAR(100),@ds_2 NVARCHAR(100),@ds_3 NVARCHAR(100)) as
begin 
		IF 'LS_AW_PRODUCTION' NOT IN (SELECT NAME FROM sys.servers)
	begin
		/* Creación del servidor vinculado para el esquema production*/
		exec sp_addlinkedserver  
		  @server='LS_AW_PRODUCTION', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc=@ds_1,   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Production'; 
	end

	IF 'LS_AW_SALES' NOT IN (SELECT NAME FROM sys.servers)
	begin
		 /* Creación del servidor vinculado para el esquema sales*/
		exec sp_addlinkedserver  
		  @server='LS_AW_SALES', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc=@ds_2,   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Sales'; 
	end

	IF 'LS_AW_OTHERS' NOT IN (SELECT NAME FROM sys.servers)
	begin
		 /* Creación del servidor vinculado para los esquemas restantes*/
		exec sp_addlinkedserver  
		  @server='LS_AW_OTHERS', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc=@ds_3,   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Others'; 
	end

end
go

/*procedimiento almacenado para creacion de los 3 servidores vinculados*/
create or alter procedure crear_servidores (@ds_1 NVARCHAR(100),@ds_2 NVARCHAR(100),@ds_3 NVARCHAR(100),@user nvarchar(100), @passw nvarchar(100)) as
begin 
	IF 'LS_AW_PRODUCTION' NOT IN (SELECT NAME FROM sys.servers)
	begin
		/* Creación del servidor vinculado para el esquema production*/
		exec sp_addlinkedserver  
		  @server='LS_AW_PRODUCTION', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc=@ds_1,   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Production'; 
		exec sp_addlinkedsrvlogin  
		  @rmtsrvname = 'LS_AW_PRODUCTION',  
		  @useself = 'false',  
		  @rmtuser = @user,
		  @rmtpassword = @passw;
		exec sp_serveroption 'LS_AW_PRODUCTION', 'rpc out', true;  
	end

	IF 'LS_AW_SALES' NOT IN (SELECT NAME FROM sys.servers)
	begin
		 /* Creación del servidor vinculado para el esquema sales*/
		exec sp_addlinkedserver  
		  @server='LS_AW_SALES', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc=@ds_2,   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Sales'; 
		exec sp_addlinkedsrvlogin  
		  @rmtsrvname = 'LS_AW_SALES',  
		  @useself = 'false',  
		  @rmtuser = @user,
		  @rmtpassword = @passw;
		exec sp_serveroption 'LS_AW_SALES', 'rpc out', true;  
	end

	IF 'LS_AW_OTHERS' NOT IN (SELECT NAME FROM sys.servers)
	begin
		 /* Creación del servidor vinculado para los esquemas restantes*/
		exec sp_addlinkedserver  
		  @server='LS_AW_OTHERS', 
		  @srvproduct='',       
		  @provider='MSOLEDBSQL', 
		  @datasrc=@ds_3,   
		  @location='',  
		  @provstr='',  
		  @catalog='AW_Production'; 
		exec sp_addlinkedsrvlogin  
		  @rmtsrvname = 'LS_AW_OTHERS',  
		  @useself = 'false',  
		  @rmtuser = @user,
		  @rmtpassword = @passw;
		exec sp_serveroption 'LS_AW_OTHERS', 'rpc out', true;  
	end

end
go

--exec crear_servidores 'ls-1.database.windows.net','ls-2.database.windows.net','ls-3.database.windows.net','itzeeel_cava','itzelCV2020.'
exec crear_servidores_local '.','.','.'
go