using DevTalles.Data;
using DevTalles.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevTalles.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly AppDbContext _db;


        //por medio de inyeccion de dependencia accedemos al DbContext para manipular los datos
        public CategoriaController(AppDbContext db)
        {
            _db = db;
        }

        //Get Mostramos la lista de Categoriass en la vista index
        public async Task<IActionResult> Index()
        {
            var ListaCategoria =await _db.Categoriass.ToListAsync();

            return View(ListaCategoria);
        }


        //Get Mostramos el formulario para crear categoria
        public  IActionResult Crear()
        {
            

            return View();
        }

        //Esta Accion Agrega el Registro en la base de datos


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult>Crear(Categoria model)
        {
            if (!ModelState.IsValid) { return NotFound(); }

           await _db.Categoriass.AddAsync(model);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");



        }
        //Esta Accion muestra el Registro en la vista
        public IActionResult Editar(int? id)
        {
            if (id is null || id == 0 )
            {
                return NotFound();
            }

            var categoriadb =_db.Categoriass.Find(id);
            if (categoriadb is null)
            {
                return NotFound();
            }

            return View(categoriadb);
        }


        //Esta Accion Actualiza el Registro en la base de datos
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult>Editar(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _db.Categoriass.Update(categoria);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        //get Esta Accion muestra la vista eliminar con los datos del modelo a eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id is null || id == 0)
            {
                return NotFound();
            }

            var categoriadb = _db.Categoriass.Find(id);
            if (categoriadb is null)
            {
                return NotFound();
            }

            return View(categoriadb);
        }
        

        //Esta Accion Elimina el Registro en la base de datos

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(Categoria model)
        {
            if (model is null) { return NotFound(); }

            

             _db.Categoriass.Remove(model);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");



        }



        [HttpGet]
        public async Task<IActionResult> ValidarNombre(string NombreCategoria)
        {

            var existe = await _db.Categoriass.AnyAsync(name => name.NombreCategoria == NombreCategoria);

            if (existe)
            {
                return Json($"El nombre {NombreCategoria} Ya Existe");
            }
            return Json(true);
        }



    }
}
