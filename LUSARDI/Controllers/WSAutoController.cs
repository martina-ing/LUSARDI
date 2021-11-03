using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LUSARDI.Models;
using LUSARDI.Data;


namespace LUSARDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WSAutoController : ControllerBase
    {

        private readonly DBContextWSAuto context;

        public WSAutoController(DBContextWSAuto context)
        {
            this.context = context;
        }


        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return context.Vehiculo.ToList();
        }//---->Traer todos los Autos


        [HttpGet("TraerModelo/{modelo}")]
        public IEnumerable<Auto> GetByModelo(string modelo)
        {
            var autos = (from a in context.Vehiculo
                         where a.Modelo == modelo
                         select a).ToList();
            return autos;
        }  //---->Traer autos por modelo

        [HttpGet("TraerModeloMarca/{modelo}/{marca}")]
        public IEnumerable<Auto> GetByModeloMarca(string modelo, string marca)
        {
            var autos = (from a in context.Vehiculo
                         where a.Modelo == modelo
                         && a.Marca== marca
                         select a).ToList();
            return autos;
        }  //---->Traer autos por modelo y marca


        [HttpGet("{id}")]
        public ActionResult<Auto> Get(int id)
        {
            return context.Vehiculo.Find(id);
        } //---->Traer Autos por id


        [HttpGet("TraerColor/{color}")]
        public IEnumerable<Auto> GetByColor(string color)
        {
            var auto = (from a in context.Vehiculo
                        where a.Color == color
                        select a).ToList();
            return auto;
        }  //---->Traer autos por color


        [HttpPost]
        public ActionResult Post(Auto auto)
        {
            context.Vehiculo.Add(auto);
            context.SaveChanges();
            return Ok();
        }  //---->Insertar un Auto


        [HttpPut("{id}")]
        public ActionResult Put(int id, Auto auto)
        {

            if (id != auto.Id)
            {
                return BadRequest();
            }
            context.Entry(auto).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok();

        }  //---->Modificar un Auto



        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            Auto auto = context.Vehiculo.Find(id);
            if (auto == null)
            {
                return NotFound();
            }

            context.Vehiculo.Remove(auto);
            context.SaveChanges();

            return auto;
        }  //---->Eliminar un auto



    }
}
