using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class PersonaService
    {
        public Persona obtenerPersona()
        {
            return new Persona()
            {
                Codigo = 1,
                Nombre = "Elver",
                Apellido = "Galarga"
            };
        }
        public List<Persona> obtenerPersonas()
        {
            Persona p1 = new Persona()
            {
                Codigo = 2,
                Nombre = "Aquiles",
                Apellido = "Castro"
            };
            Persona p2 = new Persona()
            {
                Codigo = 3,
                Nombre = "Venito",
                Apellido = "Camelas"
            };
            return new List<Persona>
            {
                p1,p2
            };

        }
    }
}