import {ArrayReservas, Reserva} from "../Services/serviceReserva.js"
import CardReservas from "./Components/cardReservas.js"
window.onload = async() => {
    await cargarReservas();
    let botonesAccion=document.querySelectorAll(".accion");
    agregarEvento(botonesAccion);
}


window.onscroll = function(){
    if(document.documentElement.scrollTop >100){
        document.querySelector('.go-top-container').classList.add('show');
    }else{
        document.querySelector('.go-top-container').classList.remove('show');
    }
}
document.querySelector('.go-top-container').addEventListener('click', () =>{
    window.scrollTo({
        top:0,
        behavior: 'smooth'
    });
});

async function cargarReservas()
{
    let libros = await ArrayReservas.reservas();
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
    let DtoAlquiler = {
        cliente: 1,
        isbn: localStorage.getItem('isbn'),
    }
    await Reserva(DtoAlquiler);
    cargarReservas();

}

function mostrarModalAlquilar(accion) {
    let modalAlquiler = document.querySelector(".modalAlquiler");
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
        }
        window.onclick = function(event) 
        {
          if (event.target == modalAlquiler) {
            modalAlquiler.style.display = "none";
          }
          let botonesAccion = document.querySelectorAll(".accion");
          agregarEvento(botonesAccion);
        }
    }
}

function agregarEvento(botones) {
	botones.forEach((boton) =>
		boton.addEventListener("click", () => {
            let accion = boton.id;
			switch (accion) 
            {
				case "reservaalquilar":
                    mostrarModalAlquilar("reservaalquilar");
                    break;
            }
        })
    );
}