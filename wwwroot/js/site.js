// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



        //Datetime to now on user Interface

    $(document).ready(function(){
            

            var today = new Date();

    document.getElementById('txtPurchaseDate').valueAsDate = today;

            
    })



    //Funcion En Editar
function enviarFormulario(e) {
    //Evitando postear el formulario para el sweet alert
    e.preventDefault();

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btnConfirmButton",
            cancelButton: "btnCancelButton"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "Estas Seguro?",
        text: "Deseas Guardar Los Cambios?",
        icon: "question",
        showCancelButton: true,
        confirmButtonText: "Si Guardalo!",
        cancelButtonText: "No, Cancelalo!",
        reverseButtons: false,
        backdrop: `rgba(217,30,24,0.4)`,
        
    }).then((resultado) => {
        if (resultado.isConfirmed) {

            const formulario = document.getElementById('formulario');
            formulario.submit();
        }
    })
}






//Funcion En Borrar

function BorrarRegistro(e) {
    //Evitando postear el formulario para el sweet alert
    e.preventDefault();

    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: "btnConfirmButton",
            cancelButton: "btnCancelButton"
        },
        buttonsStyling: false
    });
    swalWithBootstrapButtons.fire({
        title: "Estas Seguro Que Deseas Borrar Esta Nota?",
        
        icon: "question",
        showCancelButton: true,
        confirmButtonText: "Si Borralo!",
        cancelButtonText: "No lo Borres!",
        reverseButtons: false,
        backdrop:`rgba(217,30,24,0.4)`
    }).then((resultado) => {
        if (resultado.isConfirmed) {
            const formulario = document.getElementById('formulario');
            formulario.submit();
        }
    })
}





//Funcion Para Mostrar Contrasena
function mostrarPassword() {
    var x = document.getElementById("passwordInput");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}



function mostrarSweetAlert() {
    Swal.fire({
        icon: 'error',
        title: 'Error',
        text: 'Correo o Password incorrectos!',
        color:"red",
        confirmButtonText: "Ok, Thanks!",
        backdrop: `
    rgba(255,0,0,0.2)
   
  `
        
    });

    buttonsStyling: false



}


document.addEventListener('DOMContentLoaded', function () {
    // Verifica si el elemento con la clase 'alert-danger' está presente
    var alertaLogin = document.querySelector('.AlertaLogin');

    // Si está presente, muestra la alerta de SweetAlert
    if (alertaLogin) {
        mostrarSweetAlert();
    }
});



























//FUNCIONES PARA CAMBIAR TIPO DE LETRA EN EL TEXT AREA


function makeBold(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


   var b =  t.style.fontWeight == 'bold';

    t.style.fontWeight = b ? 'normal' : 'bold';

}


function makeItalic(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.fontStyle == 'italic';


    t.style.fontStyle = b ? 'normal' : 'italic';
}



function makeUnderline(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.textDecoration == 'underline';


    t.style.textDecoration = b ? 'none' : 'underline';
}
function StrikeThrough(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.textDecoration == 'line-through';


    t.style.textDecoration = b ? 'none' : 'line-through';
}

function center(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.textAlign == 'center';


    t.style.textAlign = b ? 'center' : 'center';
}

function right(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.textAlign == 'right';


    t.style.textAlign = b ? 'right' : 'right';
}


function left(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.textAlign == 'left';


    t.style.textAlign = b ? 'left' : 'left';
}


function justify(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.textAlign == 'justify';


    t.style.textAlign = b ? 'justify' : 'justify';
}


function Size1(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.fontSize == '30px';


    t.style.fontSize = b ? '16px' : '30px';
}



function Color(elem) {

    elem.classList.toggle('active');

    /*document.getElementById('text-input').classList.toggle('bold');*/


    var t = document.getElementById('text-input');


    var b = t.style.color == 'white';


    t.style.color = b ? 'black' : 'white';
}







