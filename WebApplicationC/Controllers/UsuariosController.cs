using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationC.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SampleDataBase _context;

        public UsuariosController(SampleDataBase context)
        {
            _context = context;
        }

        // GET api/usuarios
        //[Authorize("Bearer")]
        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return _context.Usuario.ToList();
        }

        // GET api/usuarios/5
        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public ActionResult<Usuario> Get(int id)
        {
            Usuario us = new Usuario();
            us = _context.Usuario.Where(x => x.Id == id).FirstOrDefault();

            if(us == null)
                return NotFound();

            return us;
        }

        // POST api/usuarios
        [Authorize("Bearer")]
        [HttpPost]
        public ActionResult<bool> Post(string nome, string email, string senha)
        {
            Usuario us = new Usuario();

            us.Nome = nome;
            us.Email = email;
            us.Senha = senha;
            us.DataRegistro = DateTime.Now;

            _context.Usuario.Add(us);
            _context.SaveChanges();

            return true;
        }

        // PUT api/usuarios/5
        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, string nome, string email)
        {
            Usuario us = _context.Usuario.Where(x => x.Id == id).FirstOrDefault();

            if (us == null)
            {
                return NotFound();
            }

            us.Nome = nome;
            us.Email = email;
            us.DataRegistro = DateTime.Now;

            _context.Entry(us).State = EntityState.Modified;
            _context.SaveChanges();

            return true;

        }

        // PUT api/usuarios/5
        [Authorize("Bearer")]
        [HttpPost("Password/{id}")]
        public ActionResult<bool> PostPassword(int id, string senha, string senhaNova)
        {
            Usuario us = _context.Usuario.Where(x => x.Id == id).FirstOrDefault();

            if (us == null)
            {
                return NotFound();
            }

            if (us.Senha != senha || senhaNova == us.Senha)
                return false;

            us.Senha = senhaNova;
            us.DataRegistro = DateTime.Now;

            _context.Entry(us).State = EntityState.Modified;
            _context.SaveChanges();

            return true;

        }

        // DELETE api/usuarios/5
        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            Usuario us = _context.Usuario.Where(x => x.Id == id).FirstOrDefault();

            if (us == null)
                return NotFound();

            _context.Usuario.Remove(us);
            _context.SaveChanges();
            return Ok();
        }
    }
}
