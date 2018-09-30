using System;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace WebApplicationC.Models
{
    public class UsuarioDAO
    {
        private IConfiguration _configuration;
        private readonly SampleDataBase _context;

        public UsuarioDAO(IConfiguration configuration, SampleDataBase context)
        {
            _configuration = configuration;
            _context = context;
        }

        public Usuario Find(int userID)
        {
            return _context.Usuario.Where(x => x.Id == Convert.ToInt32(userID)).FirstOrDefault();
        }
    }

}
