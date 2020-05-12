using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MarlinAPI.Models;
using MarlinAPI.Repository;

namespace MarlinAPI.Controllers
{
    public class TurmasController : ApiController
    {
        private MARLIN_DbContext db = new MARLIN_DbContext();

        Usuario usuarios = null;
        Aluno alunoModel = null;

        // GET: api/Turmas
        public IQueryable<Turma> GetTurmas()
        {
            return db.Turmas;
        }

        // GET: api/Turmas/5
        [ResponseType(typeof(Turma))]
        public IHttpActionResult GetTurma(int id)
        {
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return NotFound();
            }

            return Ok(turma);
        }

        // PUT: api/Turmas/5
        [ResponseType(typeof(void))]
        [HttpPut()]
        public IHttpActionResult PutTurma(int id, string nome, string senha, [FromBody]Turma turma)
        {
            usuarios = new Usuario();

            if (nome != null && senha != null)
            {
                string nomeModel = nome;
                string senhaModel = senha;
                usuarios = db.Usuarios.SingleOrDefault(x => x.Nome == nomeModel && x.Senha == senhaModel);
                if (usuarios.Nome == nomeModel && usuarios.Senha == senhaModel)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    if (id != turma.ID)
                    {
                        return BadRequest();
                    }

                    db.Entry(turma).State = EntityState.Modified;

                    try
                    {
                        db.SaveChanges();

                        return Ok(turma);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TurmaExists(id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Turmas
        [ResponseType(typeof(Turma))]
        [HttpPost()]
        public IHttpActionResult PostTurma(string nome, string senha, [FromBody]Turma turma)
        {
            usuarios = new Usuario();

            if (nome != null && senha != null)
            {
                string nomeModel = nome;
                string senhaModel = senha;
                usuarios = db.Usuarios.SingleOrDefault(x => x.Nome == nomeModel && x.Senha == senhaModel);
                if (usuarios.Nome == nomeModel && usuarios.Senha == senhaModel)
                {
                    if (!ModelState.IsValid)
                    {
                        return BadRequest(ModelState);
                    }

                    db.Turmas.Add(turma);
                    db.SaveChanges();

                    return CreatedAtRoute("DefaultApi", new { id = turma.ID }, turma);
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Turmas/5
        [ResponseType(typeof(Turma))]
        [HttpDelete()]
        public IHttpActionResult DeleteTurma(int id, string nome, string senha)
        {
            usuarios = new Usuario();
            alunoModel = new Aluno();

            var retorno = false;
            
            if (nome != null && senha != null)
            {
                string nomeModel = nome;
                string senhaModel = senha;
                usuarios = db.Usuarios.SingleOrDefault(x => x.Nome == nomeModel && x.Senha == senhaModel);
                if (usuarios.Nome == nomeModel && usuarios.Senha == senhaModel)
                {
                    Turma turma = db.Turmas.Find(id);
                    if (turma == null)
                    {
                        return NotFound();
                    }

                    foreach (var row in db.Alunos)
                        if (row.numTurma.Equals(turma.numTurma))
                        {
                            retorno = true;
                        }
                        
                    
                    if (retorno)
                    {
                        throw new ArgumentException("Turma não pode ser excluida pois possui aluno");
                    }
                    else
                    {
                       
                        db.Turmas.Remove(turma);
                        db.SaveChanges();
                    }

                    return Ok(turma);
                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return NotFound();
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurmaExists(int id)
        {
            return db.Turmas.Count(e => e.ID == id) > 0;
        }

    }
}