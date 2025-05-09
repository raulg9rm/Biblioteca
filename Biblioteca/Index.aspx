<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Biblioteca.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</head>
<body style="background-color: #eeeeee">
    <form id="form1" runat="server">
        <div>
            <br />
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <h2>Sistema de Biblioteca</h2>
                </div>
                <div class="col-sm-4"></div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10">
                            <a href="GestionAlumnos.aspx">
                                <img src="https://cdn-icons-png.flaticon.com/512/8093/8093497.png" width="50" height="50" />Alumnos</a>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10">
                            <a href="GestionLibros.aspx.aspx">
                                <img src="https://png.pngtree.com/png-clipart/20221219/original/pngtree-book-cartoon-illustration-vector-png-image_8780973.png" width="50" height="50" />Libros</a>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-10">
                            <a href="GestionAlumnos.aspx">
                                <img src="https://media.istockphoto.com/id/1364964018/es/vector/intercambio-intercambio-o-cruce-de-libros-fiesta-de-lectura-evento-de-literatura-escolar-la.jpg?s=612x612&w=0&k=20&c=tggELjSAOB6khaReTN6VnGlKNsQkUfcBDTrEzf9YrKQ=" width="50" height="50" />Prestamos</a>
                        </div>
                        <div class="col-sm-1"></div>
                    </div>
                </div>
                <div class="col-sm-2"></div>
            </div>
        </div>
    </form>
</body>
</html>
