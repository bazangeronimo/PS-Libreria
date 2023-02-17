import CardStock from "./Components/cardStock.js"
import {ArrayLibros, ArrayLibro} from "../Services/serviceLibro.js"
window.onload = async() => {
    await cargarLibros();
    document.getElementById("buscarBoton").onclick = async(e) => {
        e.preventDefault();
        let input = document.barrasDeBusqueda.buscarAutorTituloIsbn.value;
        await buscarLibros(input);
    }
}
async function cargarLibros()
{
    let libros = await ArrayLibros.libros(null,"","");
    let inicio = libros.libros.map(lib => CardStock(lib.titulo, lib.autor, lib.isbn, lib.edicion, lib.stock, lib.imagen)).join("");
    document.getElementById("app").innerHTML = inicio;
}
async function buscarLibros(input)
{
    let buscar = await ArrayLibro.libros(input);
    let imprimir = buscar.libros.map(libro => CardStock(libro.titulo, libro.autor, libro.isbn, libro.edicion, libro.stock, libro.imagen)).join("");
    document.getElementById("app").innerHTML = imprimir; 
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