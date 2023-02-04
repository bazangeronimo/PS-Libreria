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

function agregarEvento(botones) {
	botones.forEach((boton) =>
		boton.addEventListener("click", () => {
			const accion = boton.id;
            if(accion === "alquilar"){
                updateAlquiler();
                alert("El estado se actualizó correctamente.");
                location.reload ();
            }
        })
    );
}

async function updateAlquiler()
{
    const fecha = new Date();
    const DtoAlquiler = {
        cliente:1,
        isbn: localStorage.getItem("isbn"),
    }
    await Reserva(DtoAlquiler);
}