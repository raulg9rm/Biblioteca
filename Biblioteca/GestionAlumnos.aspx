<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionAlumnos.aspx.cs" Inherits="Biblioteca.GestionAlumnos" %>

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
                <div class="col-sm-4">
                    <a href="Index.aspx">Regresar</a>
                </div>
                <div class="col-sm-4">
                    <h1>Gestion de alumnos</h1>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-3">
                    <div class="row">
                        <div class="col-sm-12">
                            <label>Matricula: </label>
                            <asp:TextBox runat="server" ID="txtMatricula"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <label>Nombre: </label>
                            <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <label>Edad: </label>
                            <asp:TextBox runat="server" ID="txtEdad"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-sm-12">
                            <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn btn-success" OnClick="lknAltaAlumno_Click">Guardar</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lknEditar" CssClass="btn btn-secondary" OnClick="lknEditar_Click1">Editar</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="col-sm-7">
                    <asp:DataGrid runat="server" ID="gridAlumnos" AutoGenerateColumns="false" DataKeyField="Matricula" Width="100%">
                        <Columns>
                            <asp:BoundColumn DataField="Matricula" HeaderText="Matricula"></asp:BoundColumn>
                            <asp:BoundColumn DataField="NombreAlumno" HeaderText="Alumno"></asp:BoundColumn>
                            <asp:BoundColumn DataField="Edad" HeaderText="Edad"></asp:BoundColumn>
                            <asp:TemplateColumn>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lknEditar" OnClick="lknEditar_Click">Editar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn>
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="lknEliminar" OnClick="lknEliminar_Click">Eliminar</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                    </asp:DataGrid>

                </div>
                <div class="col-sm-1"></div>
            </div>
        </div>
    </form>
</body>
</html>
