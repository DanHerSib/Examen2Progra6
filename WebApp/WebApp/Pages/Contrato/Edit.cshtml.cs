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
