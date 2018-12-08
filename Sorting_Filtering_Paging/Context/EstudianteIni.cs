using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Sorting_Filtering_Paging.Models;

namespace Sorting_Filtering_Paging.Context
{
    public class EstudianteIni : System.Data.Entity.DropCreateDatabaseIfModelChanges<EstudianteContext>
    {
        protected override void Seed(EstudianteContext Objcontext)
        {
            base.Seed(Objcontext);
            //LISTADO DE ESTUDIANTE
            var LstEstudiante = new List<Estudiante> {

                new Estudiante {
                nombreEstudiante = "Diego",
                apellidosEstudiante = "Chaves",
                edadEstudiante = 20,
                correoEstudiante = "diego@gmail.com"
                },
                new Estudiante
                {
                nombreEstudiante = "Pablo",
                apellidosEstudiante = "Azofeifa",
                edadEstudiante = 24,
                correoEstudiante = "pabloa@gmail.com"

                },
                new Estudiante {
                nombreEstudiante = "Sergio",
                apellidosEstudiante = "Calderon",
                edadEstudiante = 21,
                correoEstudiante = "sergio@gmail.com"
                },
                new Estudiante {
                nombreEstudiante = "Isabel",
                apellidosEstudiante = "Angulo",
                edadEstudiante = 22,
                correoEstudiante = "isabel@gmail.com"
                },
                new Estudiante {
                nombreEstudiante = "Juan",
                apellidosEstudiante = "Lopez",
                edadEstudiante = 26,
                correoEstudiante = "juan@gmail.com"
                },
                new Estudiante {
                nombreEstudiante = "Jose",
                apellidosEstudiante = "Nuñez",
                edadEstudiante = 18,
                correoEstudiante = "sergio@gmail.com"
                },
                new Estudiante {
                nombreEstudiante = "Maria",
                apellidosEstudiante = "Alvarez",
                edadEstudiante = 27,
                correoEstudiante = "maria@gmail.com"
                },
                new Estudiante {
                nombreEstudiante = "Nicole",
                apellidosEstudiante = "Monge",
                edadEstudiante = 19,
                correoEstudiante = "maria@gmail.com"
                },
                //fin de la lista
               //AGREGA LOS QUE REQUIERA
            };//Lista

            //REGISTRO DE ESTUDIANTES
            LstEstudiante.ForEach(reg => Objcontext.Estudiante.Add(reg));
            //No es necesario
            Objcontext.SaveChanges();
        }
    }
}