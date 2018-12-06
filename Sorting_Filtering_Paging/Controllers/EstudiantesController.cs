using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sorting_Filtering_Paging.Context;
using Sorting_Filtering_Paging.Models;
using PagedList;

namespace Sorting_Filtering_Paging.Controllers
{
    public class EstudiantesController : Controller
    {
        private EstudianteContext db = new EstudianteContext();

        // GET: Estudiantes
        public ActionResult Index(string sortOrder, string buscar, string currentFilter, int? page, string BuscarPor)
        {
            ViewBag.CurrentSort = sortOrder; // ViewBag Encargado de guardar el parametro actual del orden Ya sea por nombre, apellido o edad
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "nombre_desc" : ""; // ViewBag encargado de guardar como se va a ordenar, va a validar si es Nulo y le va a asignar ""
            ViewBag.ApellidoSortParm = sortOrder == "apellido" ? "apellido_desc" : "apellido";
            ViewBag.EdadSortParm = sortOrder == "edad" ? "edad_desc" : "edad";

            if(buscar != null)
            {
                page = 1; 
            }
            else
            {
                buscar = currentFilter; //ViewBag encargado de guardar el filtro que se utilizó 
            }

            ViewBag.currentFilter = buscar;

            var Estudiantes = from s in db.Estudiante select s; //Va a realizar la busqueda de los caracteres que se digiten en el textbox
            if (!String.IsNullOrEmpty(buscar))
            {
                
                if (BuscarPor == "Nombre")
                    Estudiantes = Estudiantes.Where(s => s.nombreEstudiante.Contains(buscar)); //Realiza la busqueda por Nombre
                else if (BuscarPor == "Apellido")
                    Estudiantes = Estudiantes.Where(s => s.apellidosEstudiante.Contains(buscar)); //Realiza la busqueda por Apellido
                if (BuscarPor == null) BuscarPor = "";
            }

            switch (sortOrder) //Este Switch va a ser encargado de capturar como se debe acomodar la vista
            {
                case "nombre_desc":
                    Estudiantes = Estudiantes.OrderByDescending(s => s.nombreEstudiante);
                    break;
                case "edad":
                    Estudiantes = Estudiantes.OrderBy(s => s.edadEstudiante);
                    break;
                case "edad_desc":
                    Estudiantes = Estudiantes.OrderByDescending(s => s.edadEstudiante);
                    break;
                case "apellido":
                    Estudiantes = Estudiantes.OrderBy(s => s.apellidosEstudiante);
                    break;
                case "apellido_desc":
                    Estudiantes = Estudiantes.OrderByDescending(s => s.apellidosEstudiante);
                    break;
                default:
                    Estudiantes = Estudiantes.OrderBy(s => s.nombreEstudiante);
                    break;
            }
            int pageSize = 4; // Cantidad de Datos por pagina
            int pageNumber = (page ?? 1); //Valida que sea por lo menos 1 
            return View(Estudiantes.ToPagedList(pageNumber, pageSize));
        }

        // GET: Estudiantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "estudianteID,nombreEstudiante,apellidosEstudiante,correoEstudiante,edadEstudiante")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Estudiante.Add(estudiante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estudianteID,nombreEstudiante,apellidosEstudiante,correoEstudiante,edadEstudiante")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudiante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudiante estudiante = db.Estudiante.Find(id);
            if (estudiante == null)
            {
                return HttpNotFound();
            }
            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudiante estudiante = db.Estudiante.Find(id);
            db.Estudiante.Remove(estudiante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
