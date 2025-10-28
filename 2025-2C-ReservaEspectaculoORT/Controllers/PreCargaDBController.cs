using _2025_2C_ReservaEspectaculoORT.Data;
using _2025_2C_ReservaEspectaculoORT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace _2025_2C_ReservaEspectaculoORT.Controllers
{
    public class PreCargaDBController : Controller
    {
        private readonly ReservaEspectaculoContext _context;

        public PreCargaDBController(ReservaEspectaculoContext context)
        {
            _context = context;
        }

        private List<Cliente> clientes = new List<Cliente>
        {
            new Cliente {}
        };
    }
}
