# Proj_Frag_BDD
Proyecto sobre fragmentación por esquemas y consultas distribuidas

## Equipo 8
- Benitez Quiroz Karla Denisse
- Cabrera Vazquez Itzel Berenice 
- Gallegos Salinas Emilio 
- Hernandez Rodriguez Isaac Zuriel (oyente)

## Instrucciones
Ejecutar la aplicación localizada en \Proj_Frag_App\bin\Debug\Proj_Frag_App.exe.

## Observaciones del módulo de transacciones distribuidas
A lo largo de la practica se aplicaron transacción distribuidas dadas las consultas de la practica previa, se aplicaron a todas ya que se buscaba solucionar los problemas de concurrencia dado el sistema distribuido planteado.
El primer inconveniente de esto fue que anteriormente se utilizaron servidores vinculados a servidores en Azure, esta solución en la nube no permite ejecutar correctamente transacciones distribuidas. 
Un primer factor se debe a que no se permite realizar transacciones distribuidas a servidores autoreferenciados; se planteó resolver esto al correr las consultas conectándose a tres máquinas distintas, cada una con un fragmento de la base de datos. 
A pesar de ello, se tuvieron problemas con el coordinador de transacciones distribuidas de Microsoft y aunque se configuraron los procesos/propiedades pertinentes, seguía marcando un error al realizar las transacciones distribuidas.
El posible causante de este problema podría ser el NAT y que los puertos involucrados estén bloqueados para realizar dichas transacciones. 

## Especificaciones del proyecto

1. Considerando el modelo relacional de la base de datos AdventureWorks.

2. Genere una copia de seguridad de la base de datos y restaure dos instancias de SQL Server diferente 
a donde se generó la copia de seguridad, de tal forma que en total se tengan 3 instancias SQL Server.
 
3. Considerando las 3 instancias del punto anterior, seleccione y de preferencia utilice un nombre 
representativo de los esquemas que se accederán en cada instancia. 

4. Se debe programar los objetos de bases de datos necesarios para implementar las relaciones de FK y 
garantizar la integridad de datos entre las tablas que se accedan de las bases de datos salesAW, productionAW y otrosAW.

5. Al implementar las siguientes consultas, se debe acceder solamente a la(s) base(s) de dato(s)  necesarias  para  
resolver  cada  consulta. Para  ello, se  debe  configurar  los servidores vinculados necesarios:

  a) Determinar el total de las ventas de los productos con la categoría que se provea de argumento de entrada en la consulta,
  para cada uno de los territorios registrados en la base de datos.
  b) Determinar el producto más solicitado para la región (atributo group de salesterritory) “Noth America” y en que territorio 
  de la región tiene mayor demanda.
  c) Actualizar el stock disponible en un 5% de los productos de la categoría que se provea como argumento de entrada en una 
  localidad que se provea como entrada en la instrucción de actualización.
  d) Determinar si hay clientes que realizan ordenes en territorios diferentes al que se encuentran. 
  e) Actualizar la cantidad de productos de una orden que se provea como argumento en la instrucción de actualización.
  f) Actualizar el método de envío de una orden que se reciba como argumento en la instrucción de actualización.
  g) Actualizar el correo electrónico de una cliente que se reciba como argumento en la instrucción de actualización.
  
Desarrollar una aplicaciónen el lenguaje de programación de su elección que permita ejecutar las consultas del punto 5 
en la instanciaque corresponda. Se debe accedera la instancia o instancias en donde se encuentran los datos. 
Adicional a la aplicación,se puede solicitar en la revisión del proyecto la programación de consultas desde el gestor 
de bases de datos a las diferentes instancias. 

## License

[MIT](https://choosealicense.com/licenses/mit/)
