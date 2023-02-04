import ArrayAlquileres from "./fetchAlquileres.js"
import CardAlquileres from "./cardAlquileres.js"

window.onload = async() => {
    const alquileres = await ArrayAlquileres.alquileres();
    console.log(alquileres)
    let aux = alquileres.message.map(alquiler => CardAlquileres(alquiler.isbn, alquiler.titulo, alquiler.autor, alquiler.edicion, 
                                                                alquiler.editorial, alquiler.fechaReserva, alquiler.fechaAlquiler, 
                                                                alquiler.fechaDevolucion)).join("");
    document.getElementById("tabla-alquileres").innerHTML += aux;
}
