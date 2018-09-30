using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationC.Models;

namespace WebApplication.Services
{
    public class UsuarioService : IUsuarioService
    {
        public IConfiguration Configuration { get; }

        public Usuario Add(Usuario newItem)
        {
            
            throw new NotImplementedException();
        }

        public List<Usuario> GetAllItems()
        {
            List<Usuario> lista = new List<Usuario>();

            var optionsBuilder = new DbContextOptionsBuilder<SampleDataBase>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SampleDataBase"));

            using (var context = new SampleDataBase(optionsBuilder.Options))
            {
                lista = context.Usuario.ToList();
            }

            return lista;
            //throw new NotImplementedException();
        }

        public Usuario GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
