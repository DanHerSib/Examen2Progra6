"use strict";
var OrdenGrid;
(function (OrdenGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando");
                App.AxiosProvider.ProductoEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "Se elimino correctamente", icon: "success" }).then(function () { return window.location.reload(); });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    OrdenGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(OrdenGrid || (OrdenGrid = {}));
/*   declare var MensajeApp;

   if (MensajeApp != "") {
       Toast.fire({
           icon: "success", title: MensajeApp
       });
   }

   export function OnClickEliminar(id) {
       ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "d33")
           .then(result => {
               if (result.isConfirmed) {
                   window.location.href = "Orden/Grid?handler=Eliminar&id=" + id;
               }
           });
   }
   $("#GridView").DataTable();
}

namespace ProductoGrid {*/ 
//# sourceMappingURL=Grid.js.map