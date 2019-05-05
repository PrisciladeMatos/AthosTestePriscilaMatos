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
    public class CondominiosController : ApiController
    {
        private AthosTestePriscilaMatosContext db = new AthosTestePriscilaMatosContext();

        // GET: api/Condominios
        public IQueryable<Condominio> GetCondominios()
        {
            return db.Condominios;
        }

        // GET: api/Condominios/5
        [ResponseType(typeof(Condominio))]
        public async Task<IHttpActionResult> GetCondominio(int id)
        {
            Condominio condominio = await db.Condominios.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }

            return Ok(condominio);
        }

        // PUT: api/Condominios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCondominio(int id, Condominio condominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != condominio.Id)
            {
                return BadRequest();
            }

            db.Entry(condominio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondominioExists(id))
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

        // POST: api/Condominios
        [ResponseType(typeof(Condominio))]
        public async Task<IHttpActionResult> PostCondominio(Condominio condominio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Condominios.Add(condominio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = condominio.Id }, condominio);
        }

        // DELETE: api/Condominios/5
        [ResponseType(typeof(Condominio))]
        public async Task<IHttpActionResult> DeleteCondominio(int id)
        {
            Condominio condominio = await db.Condominios.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }

            db.Condominios.Remove(condominio);
            await db.SaveChangesAsync();

            return Ok(condominio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CondominioExists(int id)
        {
            return db.Condominios.Count(e => e.Id == id) > 0;
        }
    }
}