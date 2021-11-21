using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WBL;

namespace WebApp.Pages.Orden
{
    public class EditModel : PageModel
    {
        private readonly IOrdenService ordenService;
        private readonly IProductoService productoService;

        public EditModel(IOrdenService ordenService, IProductoService productoService)
        {
            this.ordenService = ordenService;
            this.productoService = productoService;
        }

        [BindProperty]
        public OrdenEntity Entity { get; set; } = new OrdenEntity();
        public IEnumerable<ProductoEntity> ProductoLista { get; set; } = new List<ProductoEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }


        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await ordenService.GetById(new() { IdOrden = id });
                }
                ProductoLista = await productoService.GetLista();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                //Metodo Actualizar
                if (Entity.IdOrden.HasValue)
                {
                    var result = await ordenService.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha actualizado";
                }
                else
                {
                    var result = await ordenService.Create(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha insertado";
                }
                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Contrato
{
    public class EditModel : PageModel
    {
        private readonly IContratoService contratoService;
        private readonly IEmpleadoService empleadoService;

        public EditModel(IContratoService contratoService, IEmpleadoService empleadoService)
        {
            this.contratoService = contratoService;
            this.empleadoService = empleadoService;
        }

        [BindProperty]
        [FromBody]

        public ContratoEntity Entity { get; set; } = new ContratoEntity();

        public IEnumerable<EmpleadoEntity> EmpleadoLista { get; set; } = new List<EmpleadoEntity>();

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await contratoService.GetById(new() { IdContrato = id });
                }

                EmpleadoLista = await empleadoService.GetLista();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }


        }

        public async Task<IActionResult> OnPost()
        {

            try
            {
                var result = new DBEntity();
                if (Entity.IdContrato.HasValue)
                {
                    result = await contratoService.Update(Entity);


                }
                else
                {
                    result = await contratoService.Create(Entity);

                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }


        }

    }
}
