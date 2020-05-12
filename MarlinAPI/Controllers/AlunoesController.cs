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
    public class AlunoesController : ApiController
    {
        private MARLIN_DbContext db = new MARLIN_DbContext();

        Usuario usuarios = null;
        Aluno alunoModel = null;

        // GET: api/Alunoes
        public IQueryable<Aluno> GetAlunos()
        {
            return db.Alunos;
        }

        // GET: api/Alunoes/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult GetAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Alunoes/5
        [ResponseType(typeof(void))]
        [HttpPut()]
        public IHttpActionResult PutAluno(int id, string nome, string senha, [FromBody]Aluno aluno)
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

                    if (id != aluno.Matricula)
                    {
                        return BadRequest();
                    }

                    db.Entry(aluno).State = EntityState.Modified;

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AlunoExists(id))
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

        // POST: api/Alunoes
        [ResponseType(typeof(Aluno))]
        [HttpPost()]
        public IHttpActionResult PostAluno(string nome, string senha, [FromBody]Aluno aluno)
        {
            usuarios = new Usuario();
            var qtd = 0;

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

                    foreach (var row in db.Alunos)                   
                        if (row.numTurma.Equals(aluno.numTurma))
                        {
                            qtd = qtd + 1;

                        }

                    if (qtd >= 5)
                    {
                        throw new ArgumentException("Uma turma não pode ter mais de 5 alunos.");
                    }
                    else
                    {
                        db.Alunos.Add(aluno);
                        db.SaveChanges();                        
                        return CreatedAtRoute("DefaultApi", new { id = aluno.Matricula }, aluno);
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

        // DELETE: api/Alunoes/5
        [ResponseType(typeof(Aluno))]
        [HttpDelete()]
        public IHttpActionResult DeleteAluno(int id, string nome, string senha)
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
                    Aluno aluno = db.Alunos.Find(id);
                    if (aluno == null)
                    {
                        return NotFound();
                    }

                    foreach (var row in db.Turmas)
                        if (row.numTurma.Equals(aluno.numTurma))
                        {
                            retorno = true;
                        }


                    if (retorno)
                    {
                        throw new ArgumentException("Aluno não pode ser excluido, pois está em uma Turma");
                    }
                    else
                    {

                        db.Alunos.Remove(aluno);
                        db.SaveChanges();

                    }

                    return Ok(aluno);
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

        private bool AlunoExists(int id)
        {
            return db.Alunos.Count(e => e.Matricula == id) > 0;
        }
    }
}