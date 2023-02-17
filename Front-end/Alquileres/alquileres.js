import {ArrayAlquileres} from "../Services/serviceAlquiler.js"
import CardAlquileres from "./Components/cardAlquileres.js"
window.onload = async() => {
    let alquileres = await ArrayAlquileres.alquileres();
    console.log(alquileres)
    if(Array.isArray(alquileres.message))
    {
        let libros = alquileres.message.map(alquiler => CardAlquileres(alquiler.isbn, alquiler.titulo, alquiler.autor, alquiler.edicion, 
            alquiler.editorial, alquiler.fechaReserva, alquiler.fechaAlquiler, 
            alquiler.fechaDevolucion)).join("");
            document.getElementById("tabla-alquileres").innerHTML += libros;
    }
    else{
        let vacio = "<span>Actualmente no se registran alquileres.</span>" 
        document.getElementById("tabla-alquileres").innerHTML = vacio;
    }
}
