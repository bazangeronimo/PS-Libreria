import ArrayLibros from "./fetchLibros.js"
import {Alquiler} from "./fetchLibros.js"
import CardStock from "./cardStock.js"

window.onload = async() => {
    const asd = document.getElementById("asd")
    console.log(asd+window.location.href);
    await cargarLibros();
    const botonesAccion=document.querySelectorAll(".accion");
    agregarEvento(botonesAccion);
    
    document.getElementById("buscarBoton").onclick = async(e) => {
        e.preventDefault();
        const inputTitulo = document.barrasDeBusqueda.buscarTitulo.value;
        const inputAutor = document.barrasDeBusqueda.buscarAutor.value;
        
        await buscarLibros(inputTitulo, inputAutor);
        const botonesAccion=document.querySelectorAll(".accion");
        agregarEvento(botonesAccion);
    }
}

async function cargarLibros()
{
    const libros = await ArrayLibros.libros(null,"","");
    let inicio = libros.libros.map(lib => CardStock(lib.titulo, lib.autor, lib.isbn, lib.edicion, lib.stock, lib.imagen)).join("");
    document.getElementById("app").innerHTML = inicio;
}

async function buscarLibros(inputTitulo, inputAutor)
{
    const buscar = await ArrayLibros.libros(null, inputTitulo, inputAutor);
    let imprimir = buscar.libros.map(libro => CardStock(libro.titulo, libro.autor, libro.isbn, libro.edicion, libro.stock, libro.imagen)).join("");
    document.getElementById("app").innerHTML = imprimir; 
}



//post
async function crearAlquiler()
{
    const fecha = new Date();
    const DtoAlquiler = {
        cliente:1,
        isbn: localStorage.getItem("isbn"),
        fechaAlquiler : fecha.toJSON(),
    }
    await Alquiler(DtoAlquiler);
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
}

function agregarEvento(botones) {
	botones.forEach((boton) =>
		boton.addEventListener("click", () => {
			const accion = boton.id;
			switch (accion) 
            {
				case "alquilar":
					crearAlquiler();
					alert("Libro alquilado correctamente.");
                    location.reload ();
                    break;
				case "reservar":
                    crearReserva();
                    alert("Libro reservado correctamente.");
                    location.reload ();
                break;
				case "agotado":
                    alert("Libro actualmente sin stock.")
                    location.reload ();
                break;
				default:
					alert("error");
                break;
			}
		})
	);
}

