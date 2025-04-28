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
                dt = objVerAlumnos.ListarDatos();
                gridAlumnos.DataSource = dt;
                gridAlumnos.DataBind();
            }

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