import CardStock from "../Inicio/Components/cardStock.js"
import CardDetalle from "./Components/cardDetalle.js"
import {Alquiler} from "../Services/serviceAlquiler.js"
import {fetchDetalle, ArrayLibro} from "../Services/serviceLibro.js"

window.onload = async () => {
    let nbsi = window.location.pathname.split("/")[2]
    let libro = document.getElementById("app");
    let result = await fetchDetalle(nbsi);
    let {titulo, autor, isbn, edicion, editorial, stock, imagen} =result.message[0]
    window.localStorage.setItem('isbn', isbn)
    libro.innerHTML += CardDetalle(titulo, autor, isbn, edicion, editorial, stock, imagen);

    let botonesAccion=document.querySelectorAll(".accion");
    agregarEvento(botonesAccion);
    document.getElementById("buscarBoton").onclick = async(e) => {
        e.preventDefault();
        let input = document.barrasDeBusqueda.buscarAutorTituloIsbn.value;
        await buscarLibros(input);
    }
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


//post
async function crearAlquiler()
{
    let fecha = new Date();
    let DtoAlquiler = {
        cliente: 1,
        isbn: localStorage.getItem('isbn'),
        fechaAlquiler: fecha
    }
    await Alquiler(DtoAlquiler);
    actualizarDatos();
}
async function crearReserva()
{
    let fecha = new Date();
    let DtoReserva = {
        cliente:1,
        isbn: localStorage.getItem("isbn"),
        fechaReserva : fecha.toJSON()
    }
    await Alquiler(DtoReserva);
    actualizarDatos();
}

async function buscarLibros(input)
{
    let buscar = await ArrayLibro.libros(input);
    if(Array.isArray(buscar.libros))
    {
        let imprimir = buscar.libros.map(libro => CardStock(libro.titulo, libro.autor, libro.isbn, libro.edicion, libro.stock, libro.imagen)).join("");
        document.getElementById("app").innerHTML = imprimir;
    }
    else{
        let vacio = "<span class='span'>No se han encontrado libros!</span>" 
        document.getElementById("app").innerHTML = vacio;
    }  
}

async function actualizarDatos() {
    let nbsi = window.location.pathname.split("/")[2];
    let result = await fetchDetalle(nbsi);
    let {titulo, autor, isbn, edicion, editorial, stock, imagen} = result.message[0];
    let libro = document.getElementById("app");
    libro.innerHTML = CardDetalle(titulo, autor, isbn, edicion, editorial, stock, imagen);
}

function mostrarModalAlquilar(accion){
    let modalAlquiler = document.querySelector(".modalAlquiler");
    let acceptBtnAlquiler = document.querySelector(".accept");
    let cancelBtnAlquiler = document.querySelector(".cancel");
    let modalReserva = document.querySelector(".modalReserva");
    let acceptBtnReserva = document.querySelector(".acceptt");
    let cancelBtnReserva = document.querySelector(".cancell");
    if (accion == "alquilar") {
        modalAlquiler.style.display = "block";
        acceptBtnAlquiler.onclick = function() 
        {
            crearAlquiler();
            modalAlquiler.style.display ="none";
        }
        cancelBtnAlquiler.onclick = function() 
        {
            modalAlquiler.style.display = "none";
        }
    } else {
        modalReserva.style.display = "block";
        acceptBtnReserva.onclick = function() 
        {
            crearReserva();
            modalReserva.style.display ="none";
        }
        cancelBtnReserva.onclick = function() 
        {
            modalReserva.style.display = "none";
        }
    }
    window.onclick = function(event) 
    {
        if (event.target == modalAlquiler || event.target == modalReserva) {
           modalAlquiler.style.display = "none";
           modalReserva.style.display = "none";
        }
        let botonesAccion = document.querySelectorAll(".accion");
        agregarEvento(botonesAccion);
    }
}

function agregarEvento(botones) {
	botones.forEach((boton) =>
		boton.addEventListener("click", () => {
			let accion = boton.id;
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