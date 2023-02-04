import fetchDetalle from "./fetchDetalle.js"
import CardDetalle from './cardDetalle.js'
import {Alquiler} from "./fetchDetalle.js"
import ArrayLibros from "../Inicio/js/fetchLibros.js"
import CardStock from "../Inicio/js/cardStock.js"

window.onload = async () => {

    const isbn = window.location.pathname.split("/")
    // console.log(isbn)
    const nbsi = isbn[2]
    // console.log(typeof(nbsi))
    const libro = document.getElementById("app");
    const result = await fetchDetalle(nbsi);
    // console.log(result)
    libro.innerHTML += CardDetalle(result.message[0]);

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


function showModal() {
    // Obtiene el botón y el modal
    var btn = document.getElementById("myBtn");
    var modal = document.querySelector(".modal");
  
    // Obtiene los botones de aceptar y cancelar
    var acceptBtn = document.querySelector(".accept");
    var cancelBtn = document.querySelector(".cancel");
  
    // Cuando se haga clic en el botón, muestra el modal
    btn.onclick = function() {
      modal.style.display = "block";
    }
  
    // Cuando se haga clic en el botón de aceptar, muestra un mensaje
    acceptBtn.onclick = function() {
        crearAlquiler();
        location.reload ();
        //   alert("Has aceptado");
      modal.style.display = "none";
    }
  
    // Cuando se haga clic en el botón de cancelar, cierra el modal
    cancelBtn.onclick = function() {
      modal.style.display = "none";
    }
  
    // Cuando se haga clic fuera del modal, cierra el modal
    window.onclick = function(event) {
      if (event.target == modal) {
        modal.style.display = "none";
      }
    }
  }




function agregarEvento(botones) {
	botones.forEach((boton) =>
		boton.addEventListener("click", () => {
			const accion = boton.id;
			switch (accion) 
            {
				case "myBtn":
                    showModal();
					// crearAlquiler();
					// alert("Libro alquilado correctamente.");
                    // location.reload ();
                    break;
				case "reservar":
                    crearReserva();
                    alert("Libro reservado correctamente.");
                    location.reload ();
                break;
				case "agotado":
                    alert("Libro actualmente sin stock.")
                break;
				default:
					alert("error");
                break;
			}
		})
	);
}