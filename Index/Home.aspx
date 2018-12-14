<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/masterPrincipal.Master" CodeBehind="Home.aspx.vb" Inherits="Index.Home" %>
<%@ MasterType virtualpath="~/masterPrincipal.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>GolfTracking</title>
      <!-- Bootstrap core CSS-->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

    <!-- Page level plugin CSS-->
    <link href="vendor/datatables/dataTables.bootstrap4.css" rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <main role="main">
       
          <div class="py-5 text-center" style="background-image: url('https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRcFbd5_lk1TpzbsEUmrk4hn51QiWKyUzzswFy-ruu9loqTFAVu1Q');background-size:cover;background-repeat:no-repeat;">
    <div class="container py-5" >
      <div class="row">
        <div class="col-md-12">
          <h1 class="display-3 mb-4 text-secondary">GolfTracking</h1>
          <p class="lead mb-5">Somos la primera plataforma web de Argentina dedicada exclusivamente a los amantes del deporte del Golf.</p>
          <a href="#mision" class="btn btn-lg mx-1 btn-secondary">Mision</a>
          <a href="#vision" class="btn btn-lg btn-primary mx-1">Vision</a>
        </div>
      </div>
    </div>
  </div>
  <div class="py-5">
    <div class="container"  id="quienessomos">
      <div class="row">
        <div class="col-md-12">
          <h1 class="text-center display-3 text-primary">¿Quienes somos?</h1>
          <p class="">GolfTracking, es una start-up que nace de la mano de 2 amigos con 2 pasiones en común: las nuevas tecnologías y el golf.
              Actualmente los practicantes del deporte de golf, deben anotar sus golpes en una tarjeta para su registro personal. Estas tarjetas de juego en papel, son difíciles de perdurar en el tiempo, si el papel es de mala calidad se arruina rápidamente sino, se pueden perder fácilmente, además cuesta tiempo y espacio en archivarlas de manera prolija para poder compararlas en un futuro y poder sacar conclusiones sobre el juego. 
Nuestro negocio apunta a brindar un servicio a todos los jugadores y aficionados al golf, facilitándoles el registro del juego y ofreciendo un espacio a la comunidad golfista de intercambio de productos. 
Se ofrece la posibilidad de digitalizar estas anotaciones a través de una aplicación para dispositivos móviles, en la cual cada jugador podrá llevar registro de sus juegos, ver su progreso en el tiempo. 
De manera ampliada sobre una  plataforma web podrá a la vez, publicar su equipamiento de golf que ya no utilice (Palos, guantes, carros, etc).
          </p>
        </div>
      </div>
    </div>
  </div>
  <div class="py-5 text-center bg-secondary" >
    <div class="container" id="mision">
      <div class="row">
        <div class="col-md-12">
          <div class="row">
            <div class="col-md-12">
              <h1 class="text-light">Mision</h1>
              <p class="text-light">Poder promover la práctica del deporte del golf, inspirar aquellos quienes lo practican, fomentar y hacer más inclusivo su ambiente. GolfTracking, nace de la mano de unos amigos amantes de golf, jugadores aficionados que se propusieron mejorar la práctica del golf.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="py-5">
    <div class="container" id="vision">
      <div class="row">
        <div class="col-md-12">
          <h1 class="text-center display-3 text-primary">Vision</h1>
          <p class="">Generando una plataforma amigable con el usuario, fácil de usar e intuitiva. Nos posicionaremos como la plataforma Nro 1 del ambiente del golf, y desarrollaremos más y mejores funcionalidades y servicios para ofrecer a los jugadores.</p>
        </div>
      </div>
    </div>
  </div>
        
        <!-- Sticky Footer -->
      
          <div class="container my-auto">
            <div class="copyright text-center my-auto">
              <span>Copyright © GolfTracking 2018</span>
               
            </div>
              <div class="text-center my-auto">
                   <a runat="server" class="small mt-3" href="#" id="tycBtn" data-toggle="modal" data-target="#TyCModal">Terminos y condiciones</a>
                  
                   <a runat="server" class="small mt-3" href="#" id="A1" data-toggle="modal" data-target="#polPrivModal">Politicas de seguridad y privacidad</a>
              </div>
          </div>
        
 <%-- <div class="py-5 bg-light">
    <div class="container">
      <div class="row text-center">
        <div class="col-md-12">
          <h1 class="mb-4 text-primary">Benefits and features</h1>
          <p class="lead">Design unique interfaces by customizing Bootstrap theme with Pingendo.
            <br>Modify colors, fonts and grid setting without opening any CSS file.</p>
          <div class="row text-left mt-5">
            <div class="col-md-4 my-3">
              <div class="row mb-3">
                <div class="text-center col-2">
                  <i class="d-block mx-auto fa fa-3x fa-mars"></i>
                </div>
                <div class="align-self-center col-10">
                  <h5 class="text-secondary">
                    <b>For him</b>
                  </h5>
                </div>
              </div>
              <p>Based on fluid design principles. Works with screen resolution. &nbsp;In-app chat panel 24/7 active. The support you need, right there.</p>
            </div>
            <div class="col-md-4 my-3">
              <div class="row mb-3">
                <div class="text-center col-2">
                  <i class="d-block mx-auto fa fa-3x fa-venus"></i>
                </div>
                <div class="align-self-center col-10">
                  <h5 class="text-secondary">
                    <b>For her</b>
                  </h5>
                </div>
              </div>
              <p>Help us spreading the word. Tell your friends with just one-click.&nbsp;Work simultaneously on different panels with the switcher</p>
            </div>
            <div class="col-md-4 my-3">
              <div class="row mb-3">
                <div class="text-center col-2">
                  <i class="d-block mx-auto fa fa-3x fa-neuter"></i>
                </div>
                <div class="align-self-center col-10">
                  <h5 class="text-secondary">
                    <b>For its</b>
                  </h5>
                </div>
              </div>
              <p>You are working with plain HTML and SASS files on your computer, so extending and integrating Javascript is a breeze.</p>
            </div>
            <div class="col-md-4 my-3">
              <div class="row mb-3">
                <div class="text-center col-2">
                  <i class="d-block mx-auto fa fa-3x fa-mars-stroke"></i>
                </div>
                <div class="align-self-center col-10">
                  <h5 class="text-secondary">
                    <b>For anyone</b>
                  </h5>
                </div>
              </div>
              <p>Based on fluid design principles. Works with screen resolution.&nbsp;Choose settings depending on the criteria you value the most.</p>
            </div>
            <div class="col-md-4 my-3">
              <div class="row mb-3">
                <div class="text-center col-2">
                  <i class="d-block mx-auto fa fa-3x fa-mars-double"></i>
                </div>
                <div class="align-self-center col-10">
                  <h5 class="text-secondary">
                    <b>Even couples</b>
                  </h5>
                </div>
              </div>
              <p>In-app chat panel 24/7 active. The support you need, right there. Pingendo enhance the battery duration and the quality of your life.&nbsp;</p>
            </div>
            <div class="col-md-4 my-3">
              <div class="row mb-3">
                <div class="text-center col-2">
                  <i class="d-block mx-auto fa fa-3x fa-genderless"></i>
                </div>
                <div class="align-self-center col-10">
                  <h5 class="text-secondary">
                    <b>Any other?</b>
                  </h5>
                </div>
              </div>
              <p>Help us spreading the word. Tell your friends with just one-click.&nbsp;Work simultaneously on different panels. Share the work with teammates.</p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>--%>
    
    </main>



    
</asp:Content>
