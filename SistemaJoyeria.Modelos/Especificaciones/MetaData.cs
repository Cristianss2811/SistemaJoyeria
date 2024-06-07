using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaJoyeria.Modelos.Especificaciones
{
	public class MetaData
	{
		public int TotalPages { get; set; } //total de tablas de mi tabla productos
		public int PageSize { get; set; }
		public int TotalCount { get; set; } //total de registros de productos
	}
}
