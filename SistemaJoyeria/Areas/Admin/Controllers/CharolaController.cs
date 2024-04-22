using Microsoft.AspNetCore.Mvc;
using SistemaJoyeria.AccesoDatos.Repositorio.IRepositorio;
using SistemaJoyeria.Modelos;
using SistemaJoyeria.Utilidades;

namespace SistemaJoyeria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CharolaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public CharolaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Charola charola = new Charola();
            if (id == null)
            {
                //creamos un nuevo registro
                charola.Estado = true;
                return View(charola);

            }
            charola = await _unidadTrabajo.Charola.Obtener(id.GetValueOrDefault());
            if (charola == null)
            {
                return NotFound();
            }
            return View(charola);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Charola charola)
        {
            if (ModelState.IsValid)
            {
                if (charola.Id == 0)
                {
                    await _unidadTrabajo.Charola.Agregar(charola);
                    TempData[DS.Exitosa] = "La charola se creo con exito";
                }
                else
                {
                    _unidadTrabajo.Charola.Actualizar(charola);
                    TempData[DS.Exitosa] = "La charola se actualizo con exito";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar la charola";
            return View(charola);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var charolaDB = await _unidadTrabajo.Charola.Obtener(id);
            if (charolaDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la Base de datos" });
            }
            _unidadTrabajo.Charola.Remover(charolaDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Charola eliminada con exito" });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Charola.ObtenerTodos();
            return Json(new { data = todos });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Charola.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                                    == nombre.ToLower().Trim()
                                    && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }


        #endregion
    }
}
