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
    console.log(libros)
    if(Array.isArray(libros.message))
    {
        let inicio = libros.message.map(reserva => CardReservas(reserva.isbn, reserva.titulo, reserva.autor, reserva.edicion, 
                                        reserva.editorial, reserva.fechaReserva, reserva.descripcion)).join('');
        document.getElementById("tabla-reservas").innerHTML = inicio;
    }
    else{
        let inicio = "<span>Actualmente no se registran reservas.</span>" 
        document.getElementById("tabla-reservas").innerHTML = inicio;
    }
}

async function updateAlquiler()
{
    const DtoAlquiler = {
        cliente: 1,
        isbn: localStorage.getItem('isbn'),
    }
    await Reserva(DtoAlquiler);
    cargarReservas();

}
function mostrarModalAlquilar(accion) {
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
            modalAlquiler.style.display = "none";
            const botonesAccion = document.querySelectorAll(".accion");
            agregarEvento(botonesAccion);
        }
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