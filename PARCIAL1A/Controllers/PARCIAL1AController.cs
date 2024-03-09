using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet]
        [Route("GetAllPosts")]
        public IActionResult GetPosts()
        {
            List<Posts> ListadoPosts = (from e in _PARCIAL1AContexto.Posts
                                          select e).ToList();

            if (ListadoPosts.Count == 0)
            {
                return NotFound();
            }

            return Ok(ListadoPosts);

        }

        //Métodos para crear registros

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

        //Métodos para actualizar registros

        [HttpPut]
        [Route("actualizarAutores/{id}")]

        public IActionResult ActualizarEquipo(int id, [FromBody] Autores AutorMod)
        {
            try
            {
                /*Para actualizar un registro, se obtiene el registro original de la base de datos 
             al cual alteramos alguna propiedad*/

                Autores? AutorActual = (from e in _PARCIAL1AContexto.Autores
                                         where e.Id == id
                                         select e).FirstOrDefault();

                /*Verificamos que el registro exista según ID*/
                if (AutorActual == null)
                {
                    return NotFound();
                }

                /*Si se  encuentra el registro, se alteran los campos modificables*/

                AutorActual.Nombre = AutorMod.Nombre;
                

                /*Se marca el registro como modificado en el contexto y se envía la modificación a la base de datos*/

                _PARCIAL1AContexto.Entry(AutorActual).State = EntityState.Modified;
                _PARCIAL1AContexto.SaveChanges();

                return Ok(AutorMod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        [Route("actualizarLibros/{id}")]

        public IActionResult ActualizarLibros(int id, [FromBody] Libros LibroModif)
        {
            try
            {
                /*Para actualizar un registro, se obtiene el registro original de la base de datos 
             al cual alteramos alguna propiedad*/

                Libros? Librosactual = (from e in _PARCIAL1AContexto.Libros
                                       where e.Id == id
                                        select e).FirstOrDefault();

                /*Verificamos que el registro exista según ID*/
                if (Librosactual == null)
                {
                    return NotFound();
                }

                /*Si se  encuentra el registro, se alteran los campos modificables*/

                Librosactual.Titulo = LibroModif.Titulo;


                /*Se marca el registro como modificado en el contexto y se envía la modificación a la base de datos*/

                _PARCIAL1AContexto.Entry(Librosactual).State = EntityState.Modified;
                _PARCIAL1AContexto.SaveChanges();

                return Ok(LibroModif);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        [Route("actualizarAutoresLibros/{idAutor}")]

        public IActionResult ActualizarAutoresLibros(int idAutor, [FromBody] AutorLibro AutorLibroModif)
        {
            try
            {
                /*Para actualizar un registro, se obtiene el registro original de la base de datos 
             al cual alteramos alguna propiedad*/

                AutorLibro? AutorLibrosactual = (from e in _PARCIAL1AContexto.AutorLibro
                                        where e.AutorId == idAutor
                                                 select e).FirstOrDefault();

                /*Verificamos que el registro exista según ID*/
                if (AutorLibrosactual == null)
                {
                    return NotFound();
                }

                /*Si se  encuentra el registro, se alteran los campos modificables*/

                AutorLibrosactual.Orden = AutorLibroModif.Orden;


                /*Se marca el registro como modificado en el contexto y se envía la modificación a la base de datos*/

                _PARCIAL1AContexto.Entry(AutorLibrosactual).State = EntityState.Modified;
                _PARCIAL1AContexto.SaveChanges();

                return Ok(AutorLibroModif);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpPut]
        [Route("actualizarPost/{id}")]

        public IActionResult ActualizarPost(int id, [FromBody] Posts PostModif)
        {
            try
            {
                /*Para actualizar un registro, se obtiene el registro original de la base de datos 
             al cual alteramos alguna propiedad*/

                Posts? Postactual = (from e in _PARCIAL1AContexto.Posts
                                     where e.Id == id
                                                 select e).FirstOrDefault();

                /*Verificamos que el registro exista según ID*/
                if (Postactual == null)
                {
                    return NotFound();
                }

                /*Si se  encuentra el registro, se alteran los campos modificables*/

                Postactual.Titulo = PostModif.Titulo;
                Postactual.Contenido = PostModif.Contenido;
                Postactual.FechaPublicacion = PostModif.FechaPublicacion;
                Postactual.AutorId = PostModif.AutorId;


                /*Se marca el registro como modificado en el contexto y se envía la modificación a la base de datos*/

                _PARCIAL1AContexto.Entry(Postactual).State = EntityState.Modified;
                _PARCIAL1AContexto.SaveChanges();

                return Ok(PostModif);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

    }
}
