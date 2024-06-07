using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyeria.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IBodegaRepositorio Bodega { get; }

        ICategoriaRepositorio Categoria { get; }

        ICharolaRepositorio Charola { get; }

        IProductoRepositorio Producto { get; }

        IUsuarioAplicacionRepositorio UsuarioAplicacion { get; }

        Task Guardar();
    }
}
