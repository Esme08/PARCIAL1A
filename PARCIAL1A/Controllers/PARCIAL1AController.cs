using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PARCIAL1AController : ControllerBase
    {
        private readonly PARCIAL1AContext _PARCIAL1AContexto;

        public PARCIAL1AController(PARCIAL1AContext PARCIAL1AContexto)
        {
            _PARCIALContexto = PARCIAL1AContexto;
        }

        /// <summary>
        /// EndPoint que retorna el listado de todos los equipos existentes
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {
            List<Autores> ListadoAutores = (from e in _PARCIAL1AContexto.Autores
                                           select e).ToList();

            if (ListadoAutores.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoAutores);

        }

        public IActionResult Get()
        {
            List<AutorLibro> ListadoAutorLibro = (from e in _PARCIAL1AContexto.AutorLibro
                                            select e).ToList();

            if (ListadoAutorLibro.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoAutorLibro);

        }

        public IActionResult Get()
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
    }
}
