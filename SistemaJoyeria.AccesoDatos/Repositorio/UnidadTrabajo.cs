﻿using SistemaJoyeria.AccesoDatos.Data;
using SistemaJoyeria.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyeria.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; private set; }

        public ICategoriaRepositorio Categoria { get; private set; }

        public ICharolaRepositorio Charola { get; private set; }

        public IProductoRepositorio Producto { get; private set; }

        public IUsuarioAplicacionRepositorio UsuarioAplicacion { get; private set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);

            Categoria = new CategoriaRepositorio(_db);

            Charola = new CharolaRepositorio(_db);

            Producto = new ProductoRepositorio(_db);

            UsuarioAplicacion = new UsuarioAplicacionRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
