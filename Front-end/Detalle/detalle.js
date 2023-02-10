import {ArrayLibro} from "../Inicio/js/fetchLibros.js"
import CardStock from "../Inicio/js/cardStock.js"
import CardDetalle from './cardDetalle.js'
import {fetchDetalle, Alquiler} from "./fetchDetalle.js"
window.onload = async () => {
    const nbsi = window.location.pathname.split("/")[2]
    const libro = document.getElementById("app");
    const result = await fetchDetalle(nbsi);
    const {titulo, autor, isbn, edicion, editorial, stock, imagen} =result.message[0]
    window.localStorage.setItem('isbn', isbn)
    libro.innerHTML += CardDetalle(titulo, autor, isbn, edicion, editorial, stock, imagen);

    const botonesAccion=document.querySelectorAll(".accion");
    agregarEvento(botonesAccion);
    document.getElementById("buscarBoton").onclick = async(e) => {
        e.preventDefault();
        const input = document.barrasDeBusqueda.buscarAutorTituloIsbn.value;
        await buscarLibros(input);
    }
}

//post
async function crearAlquiler()
{
    const fecha = new Date();
    const DtoAlquiler = {
        cliente: 1,
        isbn: localStorage.getItem('isbn'),
        fechaAlquiler: fecha
    }
    await Alquiler(DtoAlquiler);
    actualizarDatos();
}
async function crearReserva()
{
    const fecha = new Date();
    const DtoReserva = {
        cliente:1,
        isbn: localStorage.getItem("isbn"),
        fechaReserva : fecha.toJSON()
    }
    await Alquiler(DtoReserva);
    actualizarDatos();
}

async function buscarLibros(input)
{
    const buscar = await ArrayLibro.libros(input);
    let imprimir = buscar.libros.map(libro => CardStock(libro.titulo, libro.autor, libro.isbn, libro.edicion, libro.stock, libro.imagen)).join("");
    document.getElementById("app").innerHTML = imprimir; 
}

async function actualizarDatos() {
    const nbsi = window.location.pathname.split("/")[2];
    const result = await fetchDetalle(nbsi);
    const {titulo, autor, isbn, edicion, editorial, stock, imagen} = result.message[0];
    const libro = document.getElementById("app");
    libro.innerHTML = CardDetalle(titulo, autor, isbn, edicion, editorial, stock, imagen);
}

function mostrarModalAlquilar(accion){
    let modalAlquiler = document.querySelector(".modalAlquiler");
    let acceptBtnAlquiler = document.querySelector(".accept");
    let cancelBtnAlquiler = document.querySelector(".cancel");
    modalAlquiler.style.display = "block";
    acceptBtnAlquiler.onclick = function() 
    {
        accion == "alquilar" ? crearAlquiler() : crearReserva();
        modalAlquiler.style.display ="none";
    }
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

function agregarEvento(botones) {
	botones.forEach((boton) =>
		boton.addEventListener("click", () => {
			const accion = boton.id;
			switch (accion) 
            {
				case "alquilar":
                    mostrarModalAlquilar("alquilar");
                    break;
                case "reservar":
                    mostrarModalAlquilar("reservar");
                    break;
            }
        })
    );
}