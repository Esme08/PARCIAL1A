using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PARCIAL1AController : ControllerBase
    {
        private readonly PARCIAL1AContext _PARCIAL1AContexto;

        public PARCIAL1AController(PARCIAL1AContext PARCIAL1AContexto)
        {
            _PARCIAL1AContexto = PARCIAL1AContexto;
        }

        /// <summary>
        /// EndPoint que retorna el listado de todos los equipos existentes
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAllAutores")]

        public IActionResult GetAutores()
        {
            List<Autores> ListadoAutores = (from e in _PARCIAL1AContexto.Autores
                                           select e).ToList();

            if (ListadoAutores.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoAutores);

        }


        [HttpGet]
        [Route("GetAllAutorLibro")]
        public IActionResult GetAutorLibro()
        {
            List<AutorLibro> ListadoAutorLibro = (from e in _PARCIAL1AContexto.AutorLibro
                                            select e).ToList();

            if (ListadoAutorLibro.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoAutorLibro);

        }

        [HttpGet]
        [Route("GetAllLibros")]
        public IActionResult GetLibros()
        {
            List<Libros> ListadoLibros = (from e in _PARCIAL1AContexto.Libros
                                                  select e).ToList();

            if (ListadoLibros.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoLibros);

        }

        public IActionResult Get()
        {
            List<Posts> ListadoPosts = (from e in _PARCIAL1AContexto.Posts
                                          select e).ToList();

            if (ListadoPosts.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoPosts);

        }

        //Método para crear registros

        [HttpPost]
        [Route("AddAutores")]

        public IActionResult GuardarAutor([FromBody] Autores Autores)
        {
            try
            {
                _PARCIAL1AContexto.Autores.Add(Autores);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(Autores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddLibros")]

        public IActionResult GuardarLibro([FromBody] Libros Libro)
        {
            try
            {
                _PARCIAL1AContexto.Libros.Add(Libro);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(Libro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddAutoresLibros")]

        public IActionResult GuardarAutoresLibros([FromBody] AutorLibro AutorLibro)
        {
            try
            {
                _PARCIAL1AContexto.AutorLibro.Add(AutorLibro);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(AutorLibro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddPost")]

        public IActionResult GuardarPost([FromBody] Posts Post)
        {
            try
            {
                _PARCIAL1AContexto.Posts.Add(Post);
                _PARCIAL1AContexto.SaveChanges();
                return Ok(Post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
