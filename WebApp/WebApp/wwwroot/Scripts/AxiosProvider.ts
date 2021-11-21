
namespace App.AxiosProvider   {

    //export const GuardarEmpleado = () => axios.get<Entity.DBEntity>("aplicacion").then(({data})=>data );
    export const ContratoEliminar = (id) => axios.delete<DBEntity>("Contrato/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);
    export const ContratoGuardar = (entity) => axios.post<DBEntity>("Contrato/Edit", entity).then(({ data }) => data);


}




