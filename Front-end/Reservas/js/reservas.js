import ArrayReservas from "./fetchReservas.js"
import {Reserva} from "./fetchReservas.js"
import CardReservas from "./cardReservas.js"

window.onload = async() => {
    await cargarReservas();
    const botonesAccion=document.querySelectorAll(".accion");
    agregarEvento(botonesAccion);
}

async function cargarReservas()
{
    const libros = await ArrayReservas.reservas();
    let inicio = libros.message.map(reserva => CardReservas(reserva.isbn, reserva.titulo, reserva.autor, reserva.edicion, 
                                                            reserva.editorial, reserva.fechaReserva, reserva.descripcion)).join('');
    document.getElementById("tabla-reservas").innerHTML = inicio;
}

async function updateAlquiler()
{
    const DtoAlquiler = {
        cliente: 1,
        isbn: localStorage.getItem('isbn'),
    }
    await Reserva(DtoAlquiler);
    const libros = await ArrayReservas.reservas();
    let inicio = libros.message.map(reserva => CardReservas(reserva.isbn, reserva.titulo, reserva.autor, reserva.edicion, 
                                                            reserva.editorial, reserva.fechaReserva, reserva.descripcion)).join('');
    document.getElementById("tabla-reservas").innerHTML = inicio;
}

function mostrarModalAlquilar(accion) {
    // Obtiene el botón y el modal
    let modalAlquiler = document.querySelector(".modalAlquiler");
    // Obtiene los botones de aceptar y cancelar
    let acceptBtnAlquiler = document.querySelector(".accept");
    
    if(accion == "reservaalquilar"){
        modalAlquiler.style.display = "block";
        acceptBtnAlquiler.onclick = function() 
        {
            updateAlquiler();
            modalAlquiler.style.display ="none";
        }
        let cancelBtnAlquiler = document.querySelector(".cancel");
        cancelBtnAlquiler.onclick = function() 
        {
            //modal.style.display == "none"
            modalAlquiler.style.display = "none";
            const botonesAccion = document.querySelectorAll(".accion");
            agregarEvento(botonesAccion);
        }
            // Cuando se haga clic fuera del modal, cierra el modal
        window.onclick = function(event) 
        {
          if (event.target == modalAlquiler) {
            modalAlquiler.style.display = "none";
          }
          const botonesAccion = document.querySelectorAll(".accion");
          agregarEvento(botonesAccion);
        }
    }
}
function agregarEvento(botones) {
	botones.forEach((boton) =>
		boton.addEventListener("click", () => {
            const accion = boton.id;
			switch (accion) 
            {
				case "reservaalquilar":
                    mostrarModalAlquilar("reservaalquilar");
                    break;
            }
        })
    );
}