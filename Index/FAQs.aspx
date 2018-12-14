<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="FAQs.aspx.vb" Inherits="Index.FAQs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container">
  <h3>FAQs</h3>

    <div class="" id="accordion">
        <div class="faqHeader">Preguntas generales</div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">¿Es necesario registrarme?</a>
                </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse in">
                <div class="card-block">
                    Un registro de cuenta en  <strong>Golftracking</strong> solo es necesario para aquellos que deseen comprar, vender o hacer uso de las funcionalidades de la plataforma. 
                </div>
            </div>
        </div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTen">¿La registracion tiene costo?</a>
                </h4>
            </div>
            <div id="collapseTen" class="panel-collapse collapse">
                <div class="card-block">
                   La registracion de una nueva cuenta de usuario dentro de la plataforma no tiene costo alguno.
                </div>
            </div>
        </div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseEleven">¿Es necesario estar registrado para subscribirse al newsletter?</a>
                </h4>
            </div>
            <div id="collapseEleven" class="panel-collapse collapse">
                <div class="card-block">
                    No, no es necesario. Cualquiera se puede subscribir ingresando su mail desde la parte de noticias.
                </div>
            </div>
        </div>

        <div class="faqHeader">Vendedores</div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">¿Quienes pueden vender items?</a>
                </h4>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse">
                <div class="card-block">
                    Cualquier usuario registrado con el perfil de vendedor dentro de la plataforma.
                </div>
            </div>
        </div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Quiero vender mis palos que ya no uso, ¿Que pasos deberia seguir?</a>
                </h4>
            </div>
            <div id="collapseThree" class="panel-collapse collapse">
                <div class="card-block">
                    Es realmente sensilo, solamente debes seguir estos pasos:
                    <ul>
                        <li>Registrarte</li>
                        <li>Activar tu cuenta</li>
                        <li>Ir a <strong>Mis publicaciones</strong></li>
                        <li>Completar los datos de la plublicacion y listo.</li>
                    </ul>
                </div>
            </div>
        </div>
       
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseSix">¿Que puedo vender?</a>
                </h4>
            </div>
            <div id="collapseSix" class="panel-collapse collapse">
                <div class="card-block">
                   Dentro de la plataforma podes publicar cualquier producto relacionado con el mundo del golf.
                </div>
            </div>
        </div>
    

        <div class="faqHeader">Jugadores</div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">Quiero comprar un producto, ¿Como hago?</a>
                </h4>
            </div>
            <div id="collapseFour" class="panel-collapse collapse">
                <div class="card-block">
                   Comprar un producto en <strong>Golftracking</strong> es realmente sencillo, solamente debes registrarte, y encontrar el producto que te guste.
                
                </div>
            </div>
        </div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseSeven">¿Cuales son los medios de pago?</a>
                </h4>
            </div>
            <div id="collapseSeven" class="panel-collapse collapse">
                <div class="card-block">
                    Aceptamos cualquier tarjeta de credito, VISA, MasterCard y AMEX
                </div>
            </div>
        </div>
    </div>
</div>

<style>
    .faqHeader {
        font-size: 27px;
        margin: 20px;
    }

    .panel-heading [data-toggle="collapse"]:after {
        font-family: 'Glyphicons Halflings';
        content: "e072"; /* "play" icon */
        float: right;
        color: #F58723;
        font-size: 18px;
        line-height: 22px;
        /* rotate "play" icon from > (right arrow) to down arrow */
        -webkit-transform: rotate(-90deg);
        -moz-transform: rotate(-90deg);
        -ms-transform: rotate(-90deg);
        -o-transform: rotate(-90deg);
        transform: rotate(-90deg);
    }

    .panel-heading [data-toggle="collapse"].collapsed:after {
        /* rotate "play" icon from > (right arrow) to ^ (up arrow) */
        -webkit-transform: rotate(90deg);
        -moz-transform: rotate(90deg);
        -ms-transform: rotate(90deg);
        -o-transform: rotate(90deg);
        transform: rotate(90deg);
        color: #454444;
    }
</style>

</asp:Content>
