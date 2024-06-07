﻿using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaJoyeria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyeria.AccesoDatos.Repositorio.IRepositorio
{
    public interface IProductoRepositorio : IRepositorio<Producto>
    {
        void Actualizar(Producto producto);


        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);
    }
}
