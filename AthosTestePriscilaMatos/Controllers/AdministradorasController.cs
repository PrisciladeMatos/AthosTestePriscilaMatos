using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AthosTestePriscilaMatos.Models;

namespace AthosTestePriscilaMatos.Controllers
{
    public class AdministradorasController : ApiController
    {
        private AthosTestePriscilaMatosContext db = new AthosTestePriscilaMatosContext();

        // GET: api/Administradoras
        public IQueryable<Administradora> GetAdministradoras()
        {
            return db.Administradoras;

        }

        // GET: api/Administradoras/5
        [ResponseType(typeof(Administradora))]
        public async Task<IHttpActionResult> GetAdministradora(int id)
        {
            Administradora administradora = await db.Administradoras.FindAsync(id);
            if (administradora == null)
            {
                return NotFound();
            }

            return Ok(administradora);
        }

        // PUT: api/Administradoras/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdministradora(int id, Administradora administradora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradora.Id)
            {
                return BadRequest();
            }

            db.Entry(administradora).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradoraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Administradoras
        [ResponseType(typeof(Administradora))]
        public async Task<IHttpActionResult> PostAdministradora(Administradora administradora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administradoras.Add(administradora);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = administradora.Id }, administradora);
        }

        // DELETE: api/Administradoras/5
        [ResponseType(typeof(Administradora))]
        public async Task<IHttpActionResult> DeleteAdministradora(int id)
        {
            Administradora administradora = await db.Administradoras.FindAsync(id);
            if (administradora == null)
            {
                return NotFound();
            }

            db.Administradoras.Remove(administradora);
            await db.SaveChangesAsync();

            return Ok(administradora);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradoraExists(int id)
        {
            return db.Administradoras.Count(e => e.Id == id) > 0;
        }
    }
}