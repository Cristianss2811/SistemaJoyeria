using SistemaJoyeria.AccesoDatos.Data;
using SistemaJoyeria.AccesoDatos.Repositorio.IRepositorio;
using SistemaJoyeria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyeria.AccesoDatos.Repositorio
{
    public class CharolaRepositorio : Repositorio<Charola>, ICharolaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public CharolaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Charola charola)
        {
            var charolaBD = _db.Charolas.FirstOrDefault(b => b.Id == charola.Id);
            if (charolaBD != null)
            {
                charolaBD.Nombre = charola.Nombre;
                charolaBD.Descripcion = charola.Descripcion;
                charolaBD.Estado = charola.Estado;

                _db.SaveChanges();
            }
        }
    }
}
