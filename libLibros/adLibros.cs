using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libLibros
{
    public class adLibros : entLibros, IDisposable
    {
        public adLibros(string sConex)
        {
            this.sConex = sConex;
        }

        string sConex;

        public string Bandera { get; set; }
        public string sJSON { get; set; }
        public Dictionary<string, object> Property { get; set; }
        public Errores objError { get; set; } = new Errores() { bError = false, uException = null, sMensaje = "" };

        private object DBCheckIsNull(object value)
        {
            return value == null ? DBNull.Value : value;
        }

        private void AddCommonValues(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@IdLibro", DBCheckIsNull(IdLibro));
            cmd.Parameters.AddWithValue("@Titulo", DBCheckIsNull(Titulo));
            cmd.Parameters.AddWithValue("@IdGeneroLiterario", DBCheckIsNull(IdGeneroLiterario));
            cmd.Parameters.AddWithValue("@IdAutor", DBCheckIsNull(IdAutor));
            cmd.Parameters.AddWithValue("@NoEjemplares", NoEjemplares);
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable("Datos");
            try
            {
                using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings[sConex].ConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspLibros", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        AddCommonValues(cmd);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            dt.Load(rd);
                        }

                        if (dt.Rows.Count == 1)
                        {
                            foreach (DataColumn column in dt.Columns)
                            {
                                Property.Add(column.ColumnName, Convert.IsDBNull(dt.Rows[0][column.ColumnName]) ? "" : dt.Rows[0][column.ColumnName]);
                            }
                        }
                    }

                }
            }j
            catch (SqlException SqlEx)
            {
                objError.uException = SqlEx;
                
            }
            catch (Exception Ex)
            {

            }

            return dt;
        }

        public class Errores
        {
            public bool bError { get; set; }
            public Exception uException { get; set; }
            public string sMensaje { get; set; }
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
        // ~adLibros()
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
    }
}
