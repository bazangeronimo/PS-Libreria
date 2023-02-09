import {ArrayLibros, ArrayLibro} from "./fetchLibros.js"
import CardStock from "./cardStock.js"
window.onload = async() => {
    await cargarLibros();
    document.getElementById("buscarBoton").onclick = async(e) => {
        e.preventDefault();
        const input = document.barrasDeBusqueda.buscarAutorTituloIsbn.value;
        await buscarLibros(input);
    }
}
async function cargarLibros()
{
    const libros = await ArrayLibros.libros(null,"","");
    let inicio = libros.libros.map(lib => CardStock(lib.titulo, lib.autor, lib.isbn, lib.edicion, lib.stock, lib.imagen)).join("");
    document.getElementById("app").innerHTML = inicio;
}
async function buscarLibros(input)
{
    const buscar = await ArrayLibro.libros(input);
    let imprimir = buscar.libros.map(libro => CardStock(libro.titulo, libro.autor, libro.isbn, libro.edicion, libro.stock, libro.imagen)).join("");
    document.getElementById("app").innerHTML = imprimir; 
}