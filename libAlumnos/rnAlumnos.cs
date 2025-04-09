using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libAlumnos
{
    public class rnAlumnos : adAlumnos
    {
        public DataTable dt { get; set; }
        public entAlumnos entAlumnos { get; set; }
        public rnAlumnos(string sConex = "Biblio") : base(sConex)
        {
        }

        public DataTable ListarDatos()
        {
            Bandera = "s1";
            dt = Listar();
            return dt;
        }

        public DataTable InsertarDatos()
        {
            Bandera = "i1";
            dt = Listar();
            Propiedades = Propiedades;
            return dt;
        }

        public DataTable ActualizarDatos()
        {
            Bandera = "u1";
            dt = Listar();
            return dt;
        }

        public DataTable EliminarDatos()
        {
            Bandera = "u2";
            dt = Listar();
            return dt;
        }
    }
}
