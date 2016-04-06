using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ToDoListIterative.Models;

namespace ToDoListIterative.Controllers
{
    public class AtividadesController : ApiController
    {
        private ToDoListIterativeContext db = new ToDoListIterativeContext();

        // GET: api/Atividades
        public IEnumerable<Atividade> GetAtividades()
        {
            return db.Atividades;
        }

        // PUT: api/Atividades/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAtividade(int id, Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != atividade.Id)
            {
                return BadRequest();
            }

            db.Entry(atividade).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtividadeExists(id))
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

        [ResponseType(typeof(Atividade))]
        public async Task<IHttpActionResult> PostAtividade(Atividade atividade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Atividades.Add(atividade);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = atividade.Id }, atividade);
        }

        // DELETE: api/Atividades/5
        [ResponseType(typeof(void))]
        public void DeleteAtividade()
        {
            db.Atividades.RemoveRange(db.Atividades.Where(a => a.StatusConclusao));

            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AtividadeExists(int id)
        {
            return db.Atividades.Count(e => e.Id == id) > 0;
        }
    }
}