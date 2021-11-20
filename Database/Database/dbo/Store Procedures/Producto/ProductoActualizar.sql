CREATE PROCEDURE [dbo].[ProductoActualizar]
    @IdContrato int,	
	@IdEmpleado int,
	@TipoContrato varchar(50),
	@FechaInicio Datetime,
	@FechaFin Datetime


AS BEGIN
SET NOCOUNT ON

  BEGIN TRANSACTION TRASA

    BEGIN TRY
	
	UPDATE acc.Contrato SET
	 IdEmpleado= @IdEmpleado,
	 TipoContrato= @TipoContrato,
	 FechaInicio= @FechaInicio,
	 FechaFin=@FechaFin
	WHERE 
	       IdContrato=@IdContrato
	
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