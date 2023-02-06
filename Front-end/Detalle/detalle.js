// import fetchDetalle from "./fetchDetalle.js"
// import ArrayLibros from "../Inicio/js/fetchLibros.js"
// import CardStock from "../Inicio/js/cardStock.js"
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

async function actualizarDatos() {
    const nbsi = window.location.pathname.split("/")[2];
    const result = await fetchDetalle(nbsi);
    const {titulo, autor, isbn, edicion, editorial, stock, imagen} = result.message[0];
    const libro = document.getElementById("app");
    libro.innerHTML = CardDetalle(titulo, autor, isbn, edicion, editorial, stock, imagen);
  }


function mostrarModalAlquilar(accion) {
    // Obtiene el botón y el modal
    let modal = document.querySelector(".modal");
    // Obtiene los botones de aceptar y cancelar
    let acceptBtn = document.querySelector(".accept");
    let cancelBtn = document.querySelector(".cancel");
    modal.style.display = "block";
    // Cuando se haga clic en el botón de aceptar, muestra un mensaje
    acceptBtn.onclick = function() {
        switch (accion) 
        {
            case "alquilar":
                crearAlquiler();
                break;
            case "reservar":
                crearReserva();
                break;
        }
    }
    // Cuando se haga clic en el botón de cancelar, cierra el modal
    cancelBtn.onclick = function() {
    //    modal.style.display == "none"
        modal.style.display = "none";
        const botonesAccion = document.querySelectorAll(".accion");
        agregarEvento(botonesAccion);
    }
    // Cuando se haga clic fuera del modal, cierra el modal
    window.onclick = function(event) {
      if (event.target == modal) {
        modal.style.display = "none";
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


// async function buscarLibros(inputTitulo, inputAutor)
// {
//     const buscar = await ArrayLibros.libros(null, inputTitulo, inputAutor);
//     let imprimir = buscar.libros.map(libro => CardStock(libro.titulo, libro.autor, libro.isbn, libro.edicion, libro.stock, libro.imagen)).join("");
//     document.getElementById("app").innerHTML = imprimir; 
// }


 // const botonesAccion=document.querySelectorAll(".accion");
    // agregarEvento(botonesAccion);
    // document.getElementById("buscarBoton").onclick = async(e) => {
    //     e.preventDefault();
    //     const inputTitulo = document.barrasDeBusqueda.buscarTitulo.value;
    //     const inputAutor = document.barrasDeBusqueda.buscarAutor.value;
    //     await buscarLibros(inputTitulo, inputAutor);
    //     const botonesAccion=document.querySelectorAll(".accion");
    //     agregarEvento(botonesAccion);
    // }


    // async function refrescarCard(){
    //     let libro = document.getElementById("app");
    //     let algo = localStorage.getItem('isbn');
    
    //     console.log(algo)
    //     let result = await fetchDetalle(algo);
    //     let {titulo, autor, isbn, edicion, editorial, stock, imagen} = result.message[0]
    //     console.log(result.message[0])
    //     // libro.innerHTML = "";
    //     libro.innerHTML = CardDetalle(titulo, autor, isbn, edicion, editorial, stock, imagen);
    // }