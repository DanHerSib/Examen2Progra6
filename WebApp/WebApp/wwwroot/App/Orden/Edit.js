"use strict";
var OrdenEdit;
(function (OrdenEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit",
            Entity: Entity
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando");
                    App.AxiosProvider.ProductoGuardar(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodeError == 0) {
                            Toast.fire({ title: "Se guardo correctamente", icon: "success" })
                                .then(function () { return window.location.href = "Producto/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
                else {
                    Toast.fire({ title: "Por favor complete los campos requeridos" });
                }
            }
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(OrdenEdit || (OrdenEdit = {}));
/*   var Formulario = new Vue(
       {
           data:
           {
               Formulario: "#FormEdit"
           },
           mounted() {
               CreateValidator(this.Formulario)
           }
       }
   );

   Formulario.$mount("#AppEdit")
}

namespace ProductoEdit {*/ 
//# sourceMappingURL=Edit.js.map