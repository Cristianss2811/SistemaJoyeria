using SistemaJoyeria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyeria.AccesoDatos.Repositorio.IRepositorio
{
    public interface ICharolaRepositorio : IRepositorio<Charola>
    {
        void Actualizar(Charola charola);
    }
}
