using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTiendas.Models;
using WSTiendas.Models.Response;
using WSTiendas.Models.Request;

namespace WSTiendas.Controllers
{
    [Route("api/[controller]")] //ME QUEDE EN EL VIDEO 5 DEL CURSO DE HDELEON
    [ApiController]
    public class UsuariosController : ControllerBase
    {   //Consultar Usuarios
        [HttpGet]
        public IActionResult GetUser()
        {
            Respuesta ORespuesta = new Respuesta();
            
            try
            {
                //Contexto de la db
                using (TiendasMapContext db = new TiendasMapContext())
                {
                    var lista = db.Usuarios.OrderByDescending(d => d.Id).ToList();
                    ORespuesta.Exito = 1;
                    ORespuesta.Data = lista;
                    ORespuesta.Mensaje = "Usuario Consultado Exitosamente";
                }
            }
            catch (Exception ex) { ORespuesta.Mensaje = ex.Message; }
            return Ok(ORespuesta);
        }
        //Consultar Usuario por ID
        [HttpGet("{Id}")]
        public IActionResult GetUserById(long Id)
        {
            Respuesta ORespuesta = new Respuesta();

            try
            {
                //Contexto de la db
                using (TiendasMapContext db = new TiendasMapContext())
                {
                    Usuario OUsuario = db.Usuarios.Find(Id);                    
                    ORespuesta.Exito = 1;                    
                    ORespuesta.Mensaje = "Usuario Consultado Exitosamente";
                    ORespuesta.Data = OUsuario;
                }
            }
            catch (Exception ex) { ORespuesta.Mensaje = ex.Message; }
            return Ok(ORespuesta);
        }

        //Agregar Usuario
        [HttpPost]
        public IActionResult AddUser(UsuarioRequest OModel)
        { Respuesta ORespuesta = new Respuesta();
            
            try
            {
                //abrimos contexto con using
                using (TiendasMapContext db = new TiendasMapContext())
                {
                    Usuario OUsuario = new Usuario();
                    OUsuario.Nombre = OModel.Nombre;
                    OUsuario.Apellido = OModel.Apellido;
                    OUsuario.TipoUsuario = OModel.TipoUsuario;
                    OUsuario.Email = OModel.Email;

                    db.Usuarios.Add(OUsuario);
                    db.SaveChanges();
                    ORespuesta.Exito = 1;
                    ORespuesta.Mensaje = "Usuario Insertado Exitosamente";
                    ORespuesta.Data = OUsuario;
                }
            }
            catch (Exception ex) { ORespuesta.Mensaje = ex.Message; }
            return Ok(ORespuesta);
        }

        //Editar Usuario
        [HttpPut]
        public IActionResult EditUser(UsuarioRequest OModel)
        {
            Respuesta ORespuesta = new Respuesta();

            try
            {
                //abrimos contexto con using
                using (TiendasMapContext db = new TiendasMapContext())
                {
                    Usuario OUsuario = db.Usuarios.Find(OModel.Id);
                    OUsuario.Nombre = OModel.Nombre;
                    OUsuario.Apellido = OModel.Apellido;
                    OUsuario.TipoUsuario = OModel.TipoUsuario;
                    OUsuario.Email = OModel.Email;

                    db.Entry(OUsuario).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    ORespuesta.Exito = 1;
                    ORespuesta.Mensaje = "Usuario Modificado Exitosamente";
                    ORespuesta.Data = OUsuario;
                }
            }
            catch (Exception ex) { ORespuesta.Mensaje = ex.Message; }
            return Ok(ORespuesta);
        }

        //Eliminar Usuario
        [HttpDelete("{Id}")]
        public IActionResult DeleteUser(long Id)
        {
            Respuesta ORespuesta = new Respuesta();

            try
            {
                //abrimos contexto con using
                using (TiendasMapContext db = new TiendasMapContext())
                {
                    Usuario OUsuario = db.Usuarios.Find(Id);

                    db.Remove(OUsuario);
                    db.SaveChanges();
                    ORespuesta.Exito = 1;
                    ORespuesta.Mensaje = "Usuario Eliminado Exitosamente";
                    ORespuesta.Data = OUsuario;
                }
            }
            catch (Exception ex) { ORespuesta.Mensaje = ex.Message; }
            return Ok(ORespuesta);
        }
    }
}
