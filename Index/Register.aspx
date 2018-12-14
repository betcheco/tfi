<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="Index.Register" %>
<%@ Register Src="~/UserControls/ModalError.ascx" TagPrefix="userControl" TagName="ModalError" %>

<%@ Register Assembly="GoogleReCaptcha" Namespace="GoogleReCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>GolfTracking - Registro</title>

     <!-- Bootstrap core CSS-->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">

    <!-- Custom styles for this template-->
    <link href="css/sb-admin.css" rel="stylesheet">

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <script type="text/javascript">
        function openModalSuc() {
            //debugger;
            console.log(1)
            $('#exitoModal').modal('show');
        }

        function errorRegistro() {
            alert("Hubo un eror durante el proceso de registracion");
        }
        function setAlertText(id, text) {
            console.log("Estoy en la funcion");
            switch (id) {
                case "success":
                    $("#textAlertSuccess").text(text);
                    $("#textAlertSuccess").alert();
                    break;
                case "warning":
                    $("#textAlertWarning").text(text);
                    $("#textAlertWarning").alert();
                    break;
                case "danger":
                    $("#textAlertDanger").text(text);
                    $("#textAlertDanger").alert();
            };

        };
    </script>
</head>
<body class="bg-dark">
    <form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
               <!--Mensajes de alerta-->
            <div runat="server" id="alertWarning" class="alert alert-warning alert-dismissible fade show" role="alert" visible="false">
                <h4 class="alert-heading">Cuidado!</h4>
                <p id="textAlertWarning" runat="server"></p>
  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
      <span aria-hidden="true">&times;</span>
  </button>
            </div>

                   <div runat="server" id="alertDanger" class="alert alert-danger alert-dismissible fade show" role="alert" visible="false">
                <h4 class="alert-heading">ERROR!</h4>
                <p id="textAlertDanger" runat="server"></p>
  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
      <span aria-hidden="true">&times;</span>
  </button>
            </div>
        <!--modal-->
        <userControl:ModalError ID="modalMsg" runat="server"/>

                   <div runat="server" id="alertSuccess" class="alert alert-success alert-dismissible fade show" role="alert" visible="false">
                <h4 class="alert-heading">Exito!</h4>
                <p id="textAlertSuccess" runat="server"></p>
  <button type="button" class="close" data-dismiss="alert" aria-label="Close">
      <span aria-hidden="true">&times;</span>
  </button>
            </div>
      <div class="card card-register mx-auto mt-5">
          
        <div class="card-header">Registrar cuenta</div>
        <div class="card-body">
          
            <div class="form-group">
              <div class="form-row">
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="text" id="inputfirstName" class="form-control" placeholder="Nombre" required="required" autofocus="autofocus"/>
                    <label for="firstName">Nombre</label>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="text" id="inputlastName" class="form-control" placeholder="Apellido" required="required">
                    <label for="lastName">Apellido</label>
                  </div>
                </div>
              </div>
            </div>
            <div class="form-group">
              <div class="form-label-group">
                <input runat="server" type="email" id="inputEmail" class="form-control" placeholder="Email" required="required">
                <label for="inputEmail">Email</label>
              </div>
            </div>
            <div class="form-group">
              <div class="form-row">
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="password" id="inputPassword" class="form-control" placeholder="Contraseña" required="required">
                    <label for="inputPassword">Contraseña</label>
                  </div>
                </div>
                <div class="col-md-6">
                  <div class="form-label-group">
                    <input runat="server" type="password" id="inputconfirmPassword" class="form-control" placeholder="Confirmar contraseña" required="required">
                    <label for="confirmPassword">Confirmar contraseña</label>
                  </div>
                </div>
              </div>
            </div>
                <div class="form-group">
                    <div class="form-row">
                        <div class="col-md-6">
                            <div class="form-label-group">
                                <p>Seleccione el tipo de perfil deseado:</p>
                            </div>
                        </div>


                        <div class="col-md-6">
                            <div class="form-label-group">
                                <asp:DropDownList ID="profileDropdownlist" runat="server" Class=" form-control btn-primary btn-group-toggle">
                                    <asp:ListItem>Jugador</asp:ListItem>
                                    <asp:ListItem>Anunciante</asp:ListItem>
                                    </asp:DropDownList>
                            </div>

                        </div>
                    </div>
            </div>
            <div class="text-center">
                <p class="small mt-3">
                    <asp:CheckBox runat="server" ID="tycCheck"/>
                    Aceptar los
                    <a runat="server" class="small mt-3" href="#" id="tycBtn" data-toggle="modal" data-target="#TyCModal">Terminos y condiciones</a>
                    
                </p>
            </div>
            <div class="form-group">
              <div class="form-label-group">
                    <cc1:googlerecaptcha ID="ctrlGoogleReCaptcha" runat="server" PublicKey="6LepOW8UAAAAAFwZFhj-UoOlcaIMriOVt6mUledX" PrivateKey="6LepOW8UAAAAAN9LCwQMTTyC3B4Vfqyenfc59V5E" />
</div>
                </div>
            <asp:button ID="btnRegistrar" runat="server" class="btn btn-primary btn-block" Text="Registrar"/>
          
          <div class="text-center">
            <a class="d-block small mt-3" href="Home.aspx">Ir a inicio</a>
            <a class="d-block small" href="ForgotPassword.aspx">¿Olvidaste tu contraseña?</a>
          </div>
        </div>
      </div>
    </div>

     <!-- Term y Condiciones Modal-->
    <div class="modal fade" id="TyCModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">Terminos y condiciones</h5>
            <button class="close" type="button" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">×</span>
            </button>
          </div>
          <div class="modal-body">
              TERMINOS Y CONDICIONES DE USO
1. ACEPTACION DE LAS CONDICIONES GENERALES DE CONTRATACION: Estas son las Condiciones Generales de Contratación que regulan la relación contractual por la que los usuarios de Internet acceden a los contenidos y servicios que DIGITAL GOLF GROUP S.A. (En adelante DIGITAL GOLF) pone a su disposición a través de los sitios www.digitalgolftour.com . (En adelante LOS SITIOS) El usuario admite haber leído las presentes Condiciones del Registro y Contratación y expresa su adhesión plena y sin reservas a todas y cada una de ellas. Asimismo, debido a que ciertos servicios y contenidos ofrecidos por DIGITAL GOLF pueden contener normas específicas que reglamentan y complementan a las presentes Condiciones Generales de Contratación, se recomienda a los usuarios tomar conocimiento específico de ellas. 2. OBJETO: El objeto de las presentes Condiciones Generales de Registro y Contratación es la regulación de la relación entre los usuarios de Internet que accedan a LOS SITIOS y contraten servicios y/o adquieran productos a través de los mismos. 3. PARTES CONTRATANTES: De una parte, DIGITAL GOLF GROUP S.A. con domicilio a estos efectos en la calle Corrientes 785, Rafaela, República Argentina cuya actividad principal consiste en desarrollar para sí o para terceros, por cuenta propia, ajena o asociada a terceros, dentro o fuera del país, toda actividad relacionada con la industria del Golf, contando con los medios y autorizaciones necesarios. Y de otra, cualquier persona física, de 21 años en adelante, o jurídica, destinataria de los contenidos, productos y servicios de DIGITAL GOLF a cambio de las contraprestaciones económicas que en cada caso se establecieran, según lo dispuesto en el presente Contrato y en las normas específicas que reglamentan y complementan a las presentes Condiciones Generales de Contratación. 4. CONTENIDOS DE LOS SITIOS: Los contenidos, servicios y productos a los que se refiere el objeto del presente contrato son todos los que se incluyen en LOS SITIOS a los que el usuario accede directamente desde dichas direcciones. Los contenidos a los que el usuario accede mediante enlace desde LOS SITIOS se regirán por sus propias condiciones de registro y contratación. El acceso a cada contenido, servicio o adquisición de productos requerirá o no una contraprestación económica por parte del usuario en los términos establecidos en las propias condiciones de registro y contratación. 5. TARIFAS Y PAGOS: El usuario siempre conocerá el precio y la modalidad de contratación de cada producto o servicio en el momento en el que proceda a su adquisición, viniendo éstos determinados de manera clara en LOS SITIOS. DIGITAL GOLF puede optar en cualquier momento por modificar las tarifas o términos de comercialización vigentes. En todo caso, siempre regirán para el usuario el precio y condiciones que vengan determinadas en el momento en que preste su consentimiento al contratar. El usuario que desee contratar el acceso a los contenidos y servicios de pago de DIGITAL GOLF deberá abonar la tarifa correspondiente a través de los medios que a tal efecto se le indican en el website en cada momento. El cargo le será cobrado, tal como consta en las condiciones de cada producto, según el medio utilizado para el pago. Con carácter general, los cargos se realizarán al inicio de la contratación que realice el usuario. DIGITAL GOLF no asume responsabilidad alguna por el medio de pago elegido por los usuarios. Los medios de pago son elegidos libremente por los usuarios, por lo que cada uno de ellos renuncia a efectuarle a DIGITAL GOLF cualquier tipo de reclamo que tuviera algún tipo de relación con el medio de pago elegido. Asimismo, los usuarios reconocen que DIGITAL GOLF se reserva el derecho a no brindar los servicios y entregar los productos que no hayan sido efectivamente cobrados, debido a la falta de pago de cualquiera de las empresas prestadoras de los medios de pago. Ello, independientemente que los usuarios hubieren efectivamente realizado el pago a través del medio de pago en cuestión. Si el usuario tiene alguna duda referente al pago, si se han producido modificaciones en el medio de pago empleado, si cree que alguien ha utilizado sus datos de pago indebidamente o que alguien ha accedido al producto que hubiera contratado en LOS SITIOS sin su consentimiento, deberá ponerse en contacto con el Centro de Atención al Cliente a través de los canales que se ponen a su disposición indicados en los distintos websites, según corresponda. 6. RENOVACION AUTOMATICA DE LA CONTRATACION: DIGITAL GOLF procederá a renovar automáticamente la contratación de los usuarios. Para evitar contrataciones no deseadas, los usuarios serán convenientemente informados con carácter previo a la renovación. Los usuarios podrán cancelar la renovación de la contratación con anterioridad a que la misma sea efectivizada. 7. CANCELACION DE LA CONTRATACION: El usuario podrá proceder a cancelar unilateralmente la contratación de servicios de DIGITAL GOLF que hubiera realizado en LOS SITIOS, en cualquier momento durante la vigencia de la misma, para lo cual deberá comunicar su petición de forma clara e inequívoca al Centro de Atención al Cliente de DIGITAL GOLF a través de los canales que a tal efecto se ponen a su disposición en cada uno de LOS SITIOS, según corresponda. No obstante lo anterior, y sin perjuicio de las implicaciones relativas al acceso del usuario a LOS SITIOS y al tratamiento de sus datos de carácter personal, dicha cancelación por el usuario no supondrá en ningún momento el reembolso de los importes que hubiera abonado como contraprestación para el acceso a los contenidos y servicios de DIGITAL GOLF en cualquiera de sus modalidades de contratación. Dichos importes tienen carácter de no reembolsables. 8. RESTRICCIONES DE USO: 8.1.- Se permite únicamente un uso personal e intransferible de las claves de acceso a LOS SITIOS. 8.2.- Todos los contenidos de LOS SITIOS pertenecen a DIGITAL GOLF o, en su caso, a terceras personas y están protegidos por la legislación sobre propiedad intelectual. Ningún contenido de LOS SITIOS, cualquiera que sea su naturaleza, podrá ser publicado, emitido, retransmitido directa o indirectamente en ningún medio o soporte para uso distinto del estrictamente personal, sin contar con la autorización expresa de DIGITAL GOLF. Por tanto, queda terminantemente prohibida su utilización con fines comerciales, su distribución, así como su modificación, alteración o descompilación. Tal como establece el Reglamento general de DIGITAL GOLF los servicios y contenidos de LOS SITIOS son para uso exclusivo del usuario registrado y no pueden ser divulgados ni cedidos a terceros. 8.3.- El usuario, en función de su modalidad de contratación, podrá disponer de dichos contenidos e imprimirlos para uso estrictamente personal, no comercial. Al acceder a LOS SITIOS el usuario acepta no vender, no publicar, no distribuir, no retransmitir ni facilitar ningún acceso a los contenidos a terceros. 8.4.- El usuario acepta no utilizar LOS SITIOS para ningún propósito ilegal. DIGITAL GOLF se reserva el derecho de restringir o cancelar el acceso a LOS SITIOS si, en su opinión, el usuario utiliza LOS SITIOS para infringir alguna ley, violar derechos de terceros o incumplir las presentes condiciones de contratación. En caso de producirse descargas masivas de contenidos por parte de un usuario, DIGITAL GOLF se reserva el derecho de cancelar el acceso a LOS SITIOS de dicho usuario, anular su suscripción, y/o adoptar las acciones legales que estime oportunas. DIGITAL GOLF no se responsabiliza de los nombres de usuarios que afectan a personas ajenas, están protegidos por marcas registradas u otras leyes o que resultaren vulgares u ofensivos. 8.5.- LOS SITIOS puede facilitar enlaces, websites o servicios de otras compañías a través de LOS SITIOS, así como facilitar al usuario la descarga de softwares de terceros. El usuario entiende y acepta que LOS SITIOS no controla y no es responsable de estos servicios y productos. 8.6.- Los usuarios aceptan y reconocen que DIGITAL GOLF no controla, ni supervisa, ni asume responsabilidad alguna por la calidad, seguridad, características y demás elementos de los productos y/o servicios promocionados u ofrecidos en LOS SITIOS. Asimismo, aceptan y reconocen que DIGITAL GOLF no controla, ni supervisa, ni asume responsabilidad acerca de la veracidad y exactitud de la descripción efectuada por aquellos que promocionan u ofrecen sus productos o servicios (en adelante los "Oferentes"), ni acerca del cumplimiento de los requisitos legales para ofrecer y vender los productos o servicios, ni sobre la capacidad y legitimación de los Oferentes para promocionar, ofrecer y/o vender sus bienes o servicios. El material publicitario es propiedad de los solicitantes del espacio. DIGITAL GOLF no es responsable del contenido y al respecto rigen las mismas exclusiones que para el material editorial. 9. RESPONSABILIDAD DEL USUARIO: 9.1.- El usuario es responsable de todos los datos y manifestaciones que incluya en los formularios que envíe a DIGITAL GOLF así como del contenido de cualquier otra comunicación que emita a éste. El usuario responderá de la veracidad de los datos facilitados, reservándose DIGITAL GOLF el derecho a excluir de los servicios registrados a todo usuario que haya facilitado datos falsos, sin perjuicio de las demás acciones que procedan en derecho. 9.2.- Mediante el envío del formulario de contratación correspondiente, el usuario acepta las condiciones de registro y contratación aquí expuestas y se compromete a respetar el uso y las prohibiciones establecidas en las mismas. 9.3.- Asimismo, al enviar el formulario de contratación, el usuario se compromete al pago correspondiente al producto y servicio adquirido. El usuario acepta que, si sus datos de pago no permiten la facturación y/o cobro por parte de DIGITAL GOLF, el servicio pedido no le sea otorgado o será cancelado si lo tuviera activo. 9.4.- Sólo podrán contratar las personas físicas mayores de 21 años, en su propio nombre y derecho, o en el de la persona jurídica a la que represente con poder suficiente. 10. RESPONSABILIDAD DE LOS SITIOS: 10.1.- DIGITAL GOLF se compromete a poner a disposición del cliente en LOS SITIOS la información necesaria relativa a los productos que ofrece y las condiciones de contratación. 10.2.- El usuario acepta que el acceso a LOS SITIOS y el contenido de dichos sitios es el existente en cada momento. DIGITAL GOLF no aceptará reclamación alguna por los contenidos, actualizaciones o conexiones a LOS SITIOS 10.3.- DIGITAL GOLF hará todo lo posible por asegurar de buena fe, con todos los medios a su alcance, el acceso al servicio contratado por el usuario. No obstante lo anterior, DIGITAL GOLF no se responsabiliza de los fallos técnicos de conexión de red que puedan provocar daños en los equipos, impedir la conexión o limitar total o parcialmente el acceso del usuario a LOS SITIOS. DIGITAL GOLF no se responsabilizará de las averías que se produzcan por sus empresas suministradoras de servicio y que puedan impedir el acceso a LOS SITIOS y en ningún caso asegurará el reembolso del importe pagado en caso de reclamación. DIGITAL GOLF únicamente responderá por aquellos daños o perjuicios que le puedan ser imputados a la sociedad DIGITAL GOLF a título de dolo o culpa grave. En dichos supuestos de responsabilidad de DIGITAL GOLF, la indemnización no comprenderá el lucro cesante. 11. RESOLUCION DEL CONTRATO: 11.1.- LOS SITIOS se reservan el derecho a retirar de forma inmediata el acceso al servicio y a los contenidos de pago contratados a aquellos clientes que a criterio de LOS SITIOS contravengan lo dispuesto en las presentes condiciones, sin posibilidad de reembolso en caso de haberse efectuado el pago. Concretamente, LOS SITIOS podrá anular la contratación: a.- cuando el acceso se utilice con fines ilegítimos, incluyendo por tales los enumerados en este contrato y en el Reglamento general de LOS SITIOS b.- cuando los datos de cobro proporcionados en la contratación sean erróneos o imposibiliten la facturación y/o cobro del servicio contratado. c.- en caso de inutilización prolongada y continua o inadecuada de cualquiera de los contenidos o servicios que hubieran sido contratados, indicando en este caso al usuario, claramente los términos en los que aplicará dicha cancelación. d.- en caso de usos fraudulentos del producto o contrarios a la buena fe. 11.2.- El usuario tiene derecho a revocar la contratación de servicios o productos de LOS SITIOS durante el plazo de CINCO (5) días corridos, contados a partir de la fecha en que se entregue el producto o se celebre el contrato, lo último que ocurra, sin responsabilidad alguna. Esta facultad no puede ser dispensada ni renunciada. El usuario deberá comunicar fehacientemente dicha revocación a DIGITAL GOLF. Adquisición de productos: Los gastos de devolución son por cuenta de DIGITAL GOLF. Para ejercer el derecho de revocación el consumidor deberá poner el producto a disposición de DIGITAL GOLF sin haberlo usado y manteniéndolo en el mismo estado en que lo recibió. De verificarse estas condiciones DIGITAL GOLF restituirá al usuario los importes percibidos. 12. PROTECCION DE DATOS: VER Políticas de Privacidad del Sitio 13. CONTRATO: El documento del contrato entre el usuario y DIGITAL GOLF está compuesto por las presentes condiciones de contratación, el formulario enviado por el usuario con sus datos personales y de pago, y los datos ubicados en DIGITAL GOLF que completan el presente documento, prevaleciendo frente a cualquier otro acuerdo verbal o escrito previo o simultáneo. 14. LEY APLICABLE Y JURISDICCION: El presente contrato se interpretará y regirá conforme a la legislación argentina. DIGITAL GOLF y el usuario se comprometen a intentar resolver de manera amistosa cualquier desacuerdo que pudiera surgir en el desarrollo del presente Contrato, previamente a acudir a la jurisdicción contemplada.
          </div>
          <div class="modal-footer">
            <button class="btn btn-secondary" type="button" data-dismiss="modal">Aceptar</button>
          </div>
        </div>
      </div>
    </div>                


        <!--Modal registro exitoso-->
        <div class="modal fade" id="exitoModal" runat="server" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Registro exitoso </h5>

                    </div>
                    <div class="modal-body" id="modalTexto" runat="server">
                        
                    <asp:HyperLink ID="linkConfirm" runat="server">Click aqui para confirmar usuario</asp:HyperLink>
                        Gracias por registrarse, en instantes recibira un mail a la direccion registrada para finalizar el proceso.
                    </div>
                    <div class="modal-footer">
                        <a class="btn btn-secondary" type="button" data-dismiss="modal" href="Home.aspx">Aceptar</a>
                    </div>
                </div>
            </div>
        </div>


        
       

   
    </form>
     
</body>
</html>
