﻿CREATE PROCEDURE [dbo].[OrdenInsertar]
	@IdProducto int,
	@NombreProducto VARCHAR(50),
	@PrecioProducto FLOAT,
	@CantidadProducto int,
	@Estado varchar(30)
AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
    BEGIN TRY
	INSERT INTO dbo.Orden
	(IdProducto, NombreProducto, PrecioProducto, CantidadProducto, Estado)
	VALUES
	(@IdProducto, @NombreProducto, @PrecioProducto, @CantidadProducto, @Estado)
  COMMIT TRANSACTION TRASA
  SELECT 0 AS CodeError, '' AS MsgError
  END TRY
  BEGIN CATCH
   SELECT 
         ERROR_NUMBER() AS CodeError,
		 ERROR_MESSAGE() AS MsgError
   ROLLBACK TRANSACTION TRASA
   END CATCH
END