﻿CREATE PROCEDURE [dbo].[OrdenActualizar]
    @IdOrden int,
	@IdProducto int,
	@NombreProducto VARCHAR(50),
	@PrecioProducto FLOAT,
	@CantidadProducto int,
	@Estado varchar(30)
AS BEGIN
SET NOCOUNT ON
  BEGIN TRANSACTION TRASA
    BEGIN TRY
	UPDATE dbo.Orden SET
	IdProducto = @IdProducto,
	NombreProducto = @NombreProducto,
	PrecioProducto = @PrecioProducto,
	CantidadProducto = @CantidadProducto,
	Estado = @Estado
	WHERE 
	       IdOrden = @IdOrden
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