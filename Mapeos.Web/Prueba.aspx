<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prueba.aspx.cs" Inherits="Mapeos.Web.Prueba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="Scripts/script.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).on("click", ".deleteContact", function () {
            $(this).closest("tr").remove(); // closest used to remove the respective 'tr' in which I have my controls   
        });
        $(document).ready(function () {
            $(document).on("click", ".classAdd", function () { //
                var num = parseInt($('tr:last td:first').text());
                var rowCount = $('.data-contact-person').length + 1;
                var contactdiv = '<tr class="data-contact-person">' +
                    '<td>' + (num+1) + '</td>' +
                    '<td><input type="text" name="f-name' + rowCount + '" class="form-control f-name01" /></td>' +
                    '<td><select name="s-name"'+ rowCount +'> <option>Varchar</option><option>Int</option><option>Decimal</option><option>Char</option><option>Int</option>" name="email' + rowCount + '" class="form-control email01" /></td>' +
                    '<td><input type="text" name="l-name' + rowCount + '" class="form-control l-name01" /></td>' +
                    '<td><input type="checkbox" name="c-name' + rowCount + '" class="form-control l-name01" /></td>' +
                    '<td><input type="checkbox" name="csel-name' + rowCount + '" class="form-control l-name01" /></td>' +
                    '<td><button type="button" id="btnAdd" name="f2-name' + rowCount +'" class="btn btn-xs btn-primary classAdd">+</button>' +
                    '<button type="button" id="btnDelete" class="deleteContact btn btn btn-danger btn-xs">-</button></td>' +
                    '</tr>';
                $('#maintable').append(contactdiv); // Adding these controls to Main table class  
            });
        });
        $(document).ready(function () {
            $("select").searchable({
                maxListSize: 200, // if list size are less than maxListSize, show them all
                maxMultiMatch: 300, // how many matching entries should be displayed
                exactMatch: false, // Exact matching on search
                wildcards: true, // Support for wildcard characters (*, ?)
                ignoreCase: true, // Ignore case sensitivity
                latency: 200, // how many millis to wait until starting search
                warnMultiMatch: 'top {0} matches ...',
                warnNoMatch: 'no matches ...',
                zIndex: 'auto'
            });
        });

     </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <h2>Basic Table</h2>  
            <table class="table" id="maintable">  
                <thead>  
                    <tr id="somerow">  
                        <th>Número</th>  
                        <th>Nombre</th>  
                        <th>Tipo</th>  
                        <th>Descripción</th>
                        <th>Null</th>
                        <th>Eliminar</th>
                    </tr>  
                </thead>  
                <tbody>  
                    <tr class="data-contact-person">  
                        <td>
                            1
                        </td>
                        <td>  
                            <input type="text" name="f-name" class="form-control f-name01" />
                        </td>  
                        <td>  
                            <select id="tipo">
                                <option>Varchar</option>
                                <option>Int</option>
                                <option>Decimal</option>
                                <option>Char</option>
                                <option>Int</option>
                            </select>
                        </td>  
                        <td>  
                            <input type="text" name="l-name" class="form-control l-name01" />
                        </td>
                        <td>
                            <input id="chk" type="checkbox" />
                        </td>
                        <td>
                            <input id="chkSel" name="csel-name" type="checkbox" />
                        </td>
                        <td>  
                            <button type="button" id="btnAdd" class="btn btn-xs btn-primary classAdd">+</button>  
                        </td>
                    </tr>  
                </tbody>  
            </table>  
            <button type="button" id="btnSubmit" class="btn btn-primary btn-md pull-right btn-sm">Aceptar</button>  
    </div>
    </form>
</body>
</html>
