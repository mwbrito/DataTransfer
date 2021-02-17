<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="teste_repeater.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

    <!-- Optional theme -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">





        <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                <ItemTemplate>

                    <div class="panel panel-default">
                        <div class="panel-heading" role="tab" id="heading<%# Eval("id") %>" style="height: 50px;">
                            <h4 class="panel-title" style="width: 100%;">
                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Eval("id") %>" aria-expanded="false" aria-controls="collapse<%# Eval("id") %>">
                                    <table class="table">
                                        <tbody>
                                            <tr>
                                                <td style="border: none; width: 50px;"><%# Eval("id") %></td>
                                                <td style="border: none; width: 150px;"><%# Eval("comprador") %></td>
                                                <td style="border: none; width: 50px;"><%# Eval("valor") %></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </a>
                            </h4>
                        </div>
                        <div id="collapse<%# Eval("id") %>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="heading<%# Eval("id") %>">
                            <div class="panel-body">
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>First Name</th>
                                            <th>Last Name</th>
                                            <th>Username</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <th scope="row">1</th>
                                                    <td><%# Eval("id") %></td>
                                                    <td><%# Eval("idCompra") %></td>
                                                    <td><%# Eval("nomeItem") %></td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" />
                                                        <asp:HiddenField ID="HiddenField1" Value='<%# ((teste_repeater.compraItem)Container.DataItem).id %>' runat="server" />
                                                        <asp:HiddenField ID="HiddenField2" Value='<%# ((teste_repeater.compraItem)Container.DataItem).id %>' runat="server" />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>


                                    </tbody>
                                </table>
                                <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" CommandArgument='<%# ((teste_repeater.compra)Container.DataItem).id %>' />

                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>




        </div>

        <script type="text/javascript">
            function Check_All(ChkBoxHeader,idGrid) {
                //First Access the GridView Control
                var gridview = document.getElementById(idGrid);

                //Now get the all the Input type elements in the GridView
                var AllInputsElements = gridview.getElementsByTagName('input');
                var TotalInputs = AllInputsElements.length;
                //Now we have to find the checkboxes in the rows.
                for (var i = 0; i < TotalInputs; i++) {
                    if (AllInputsElements[i].type == 'checkbox') {
                        AllInputsElements[i].checked = ChkBoxHeader.checked;
                    }
                }

            }
        </script>


    </form>
</body>
</html>
