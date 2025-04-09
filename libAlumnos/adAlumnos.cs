using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libAlumnos
{
    public class adAlumnos : entAlumnos, IDisposable
    {
        public string Bandera { get; set; }
        public string sJSON { get; set; }
        public Dictionary<string, object> Propiedades { get; set; }
        public Errores objError { get; set; } = new Errores() { bError = false, uException = null };

        private string sConex;

        protected adAlumnos(string sConex)
        {
            this.sConex = sConex;
        }

        private object CheckDBNull(object value)
        {
            return value == null ? DBNull.Value : value;
        }

        private void AddCommonParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Matricula", CheckDBNull(Matricula));
            cmd.Parameters.AddWithValue("@NombreAlumno", CheckDBNull(NombreAlumno));
            cmd.Parameters.AddWithValue("@Edad", CheckDBNull(Edad));
            cmd.Parameters.AddWithValue("@sXML", CheckDBNull(sJSON));
            cmd.Parameters.AddWithValue("@Bandera", CheckDBNull(Bandera));
        }

        protected DataTable Listar()
        {
            DataTable dt = new DataTable("Datos");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[sConex].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspAlumnos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        AddCommonParameters(cmd);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }

                        if (dt.Rows.Count == 1)
                        {
                            Propiedades = new Dictionary<string, object>(); // Usamos Dictionary en vez de PropertyCollection
                            foreach (DataColumn cols in dt.Columns)
                            {
                                Propiedades.Add(cols.ColumnName, Convert.IsDBNull(dt.Rows[0][cols.ColumnName]) ? "" : dt.Rows[0][cols.ColumnName]);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                objError.bError = true;
                objError.uException = sqlEx;
            }
            catch (Exception ex)
            {
                objError.bError = true;
                objError.uException = ex;
            }

            return dt;
        }

        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~adAlumnos()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        public class Errores
        {
            public bool bError { get; set; }
            public Exception uException { get; set; }
            public string Mensaje => uException?.Message;
        }
    }
}
