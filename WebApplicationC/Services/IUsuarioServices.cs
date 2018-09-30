using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationC.Models;

namespace WebApplication.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetAllItems();
        Usuario Add(Usuario newItem);
        Usuario GetById(Guid id);
        void Remove(Guid id);
    }
}
