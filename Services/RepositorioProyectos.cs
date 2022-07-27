using Portafolio.Models;

namespace Portafolio.Services
{
    public interface IRepositorioProyectos
    {
        List<Proyecto> ObtenerProyectos();
    }
    public class RepositorioProyectos : IRepositorioProyectos
    {
        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>
            {
                new Proyecto
                {
                    Titulo = "Web API library in .NET Core & Entity Framework",
                    Descripcion = "Basic-level Web API REST, built in .NET Core",
                    Link = "https://github.com/LuissanRubio-90/WebApiAutores",
                    ImagenURL = "/images/library_01.png"
                },
                new Proyecto
                {
                    Titulo = "Web API Cinema with .NET Core & Entity Framework",
                    Descripcion = "Medium-level Web API REST, built in .NET Core",
                    Link = "https://github.com/LuissanRubio-90/webapipeliculas",
                    ImagenURL = "/images/cinema_01.png"
                },
                new Proyecto
                {
                    Titulo = "Online market with HTML/CSS/Javascript",
                    Descripcion = "Store website built with HTML, CSS, Bootstrap and Javascript",
                    Link = "https://github.com/LuissanRubio-90/proyectoTiendaVirtual",
                    ImagenURL = "/images/store_01.png"
                },
                new Proyecto
                {
                    Titulo = "Pizza orders Web API + UI with Laravel",
                    Descripcion = "Mid-level project that includes Front-end and Back-end code",
                    Link = "https://github.com/LuissanRubio-90/pruebaPizzaUI",
                    ImagenURL = "/images/pizzaorder.jpg"
                },
                new Proyecto
                {
                    Titulo = "Pizza orders app (JUST the Web API)",
                    Descripcion = "Back-end application using Laravel/MySQL",
                    Link = "https://github.com/LuissanRubio-90/webAPI_PruebaPizzeria",
                    ImagenURL = "/images/orderpizza_webapi.png"
                }

            };
        }
    }
}
