<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Biblioteca.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <h3>Sistema de Biblioteca</h3>
                </div>
                <div class="col-sm-4"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <a href="GestionAlumnos.aspx">Ver Alumno</a>
                    <a href="GestionAlumnos.aspx">Ver Libros</a>
                    <a href="GestionAlumnos.aspx">Registrar Nuevo Prestamo</a>
                </div>
                <div class="col-sm-2"></div>
            </div>
        </div>
    </form>
</body>
</html>
