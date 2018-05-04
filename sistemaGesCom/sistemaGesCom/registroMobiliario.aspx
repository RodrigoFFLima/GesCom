<%@ Page Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="registroMobiliario.aspx.cs" Inherits="sistemaGesCom.registroMobiliario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- **********************************************************************************************************************************************************
      MAIN CONTENT
      *********************************************************************************************************************************************************** -->
    <!--main content start-->
    <section id="main-content">
        <section class="wrapper">
            <h3><i class="fa fa-angle-right"></i> Mobilias <i class="fa fa-angle-right"></i> Cadastro de Mobilias</h3>

            <!-- BASIC FORM ELELEMNTS -->
            <div class="row mt">
                <div class="col-lg-12">
                    <div class="form-panel">
                        <h4 class="mb"><i class="fa fa-angle-right"></i> Cadastro</h4>
                        <h6 style="font-weight: bold">Para a realização do cadastro é necessário o preenchimento de todos os campos</h6>
                        <form class="form-horizontal style-form" method="get" runat="server">
                            <div class="form-group">
                                <label class="col-sm-2 col-sm-2 control-label"> Descrição do Movel</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDescricaoMovel" class="form-control" placeholder="Descrição" MaxLength="200" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtDescricaoMovel" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-sm-2 col-sm-2 control-label">Data da Compra</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtDataCompra" class="form-control" placeholder="Data da Compra" runat="server" type="date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtDataCompra" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-sm-2 col-sm-2 control-label">Valor</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtValorCompra" class="money form-control" placeholder="Valor da Compra" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtValorCompra" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <label class="col-sm-2 col-sm-2 control-label">Quantidade</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="txtQuantidade" type="number" class="form-control bfh-number" placeholder="Quantidade de Itens" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo obrigatório" ControlToValidate="txtQuantidade" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-10">
                                    <asp:Button ID="btnCadastrar" class="btn btn-success" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" />
                                </div>

                            </div>
                        </form>
                    </div>
                </div>
                <!-- col-lg-12-->
            </div>
            <!-- /row -->
        </section>
        <!--/wrapper -->
    </section>
    <!-- /MAIN CONTENT -->

    <!--main content end-->

</asp:Content>

