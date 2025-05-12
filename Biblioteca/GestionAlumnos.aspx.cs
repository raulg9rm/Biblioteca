using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblioteca
{
    public partial class GestionAlumnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillAlumnos();
            }
        }

        private void FillAlumnos()
        {
            using (var objVerAlumnos = new libAlumnos.rnAlumnos())
            {
                DataTable dt = new DataTable();
                //dt = objVerAlumnos.ListarDatos();
                dt = CrearTablaFicticia();
                gridAlumnos.DataSource = dt;
                gridAlumnos.DataBind();
            }

        }


        public DataTable CrearTablaFicticia()
        {
            DataTable alumnos = new DataTable();

            // Definir las columnas
            alumnos.Columns.Add("Matricula", typeof(int));
            alumnos.Columns.Add("NombreAlumno", typeof(string));
            alumnos.Columns.Add("Edad", typeof(int));

            // Agregar filas
            alumnos.Rows.Add(2024001, "Araceli Adriana Garcia Lopez", 25);
            alumnos.Rows.Add(2024002, "Raul Garcia Maturana", 26);
            alumnos.Rows.Add(2024003, "Sofia Garcia Garcia", 4);
            alumnos.Rows.Add(2024006, "Alumno ya editado", 1);
            alumnos.Rows.Add(2024007, "Emily", 4);
            alumnos.Rows.Add(2024008, "Alumno para eliminar", 88);
            alumnos.Rows.Add(2024009, "ALUMNA 1", 25);
            alumnos.Rows.Add(2024010, "ALUMNA 2", 26);
            alumnos.Rows.Add(2024011, "ALUMNA 3", 26);
            alumnos.Rows.Add(2024012, "otro alumno", 15);

            return alumnos;
        }

        protected void lknEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;

            // Obtén la fila contenedora del botón
            DataGridItem row = (DataGridItem)btn.NamingContainer;

            // Obtén la matrícula usando DataKeys con el índice de la fila
            string matricula = gridAlumnos.DataKeys[row.ItemIndex].ToString();
            string edad = row.Cells[2].Text.ToString();
            string nombre = row.Cells[1].Text.ToString();

            txtMatricula.Text = matricula;
            txtNombre.Text = nombre;
            txtEdad.Text = edad;

            txtMatricula.Enabled = false;
        }

        protected void lknAltaAlumno_Click(object sender, EventArgs e)
        {
            using (var objVerAlumnos = new libAlumnos.rnAlumnos() { Matricula = int.Parse(txtMatricula.Text.Trim()), NombreAlumno = txtNombre.Text.Trim(), Edad = int.Parse(txtEdad.Text.Trim()) })
            {
                DataTable dt = new DataTable();
                //dt = objVerAlumnos.InsertarDatos();
                objVerAlumnos.InsertarDatos();

                //Response.Write(dt.Rows[0]["Mensaje"].ToString());
                Response.Write(objVerAlumnos.Propiedades["Mensaje"].ToString());
                FillAlumnos();
            }
        }

        protected void lknEditar_Click1(object sender, EventArgs e)
        {
            using (var objVerAlumnos = new libAlumnos.rnAlumnos() { Matricula = int.Parse(txtMatricula.Text.Trim()), NombreAlumno = txtNombre.Text.Trim(), Edad = int.Parse(txtEdad.Text.Trim()) })
            {
                DataTable dt = new DataTable();
                dt = objVerAlumnos.ActualizarDatos();
                Response.Write(dt.Rows[0]["Mensaje"].ToString());
                FillAlumnos();
                txtMatricula.Enabled = true;
            }
        }

        protected void lknEliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            DataGridItem row = (DataGridItem)btn.NamingContainer;
            string matricula = gridAlumnos.DataKeys[row.ItemIndex].ToString();
            using (var objVerAlumnos = new libAlumnos.rnAlumnos() { Matricula = int.Parse(matricula) })
            {
                DataTable dt = new DataTable();
                dt = objVerAlumnos.EliminarDatos();
                Response.Write(dt.Rows[0]["Mensaje"].ToString());
                FillAlumnos();
                txtMatricula.Enabled = true;
            }
        }
    }
}