export const CardReservas = (isbn, titulo, autor, edicion, editorial, fecha_de_Reserva, descripcion) => {
    return `
    <tr>
        <td class = "text-center">${isbn}</td>
        <td class = "text-center">${titulo}</td>
        <td class = "text-center">${autor}</td>
        <td class = "text-center">${edicion}</td>
        <td class = "text-center">${editorial}</td>
        <td class = "text-center">${new Date(fecha_de_Reserva).toLocaleDateString()}</td>
        <td class = "text-center">${descripcion}</td>
        <td class = "text-center">
            <div class = "boton-centro">
            <div id="reservaalquilar" type="button" class="btn btn-success accion" onclick="javascript:window.localStorage.setItem('isbn',${isbn})" >Alquilar</div>
                <div class="modalAlquiler">
                    <div class="modal-content">
                        <p> ¿Desea realizar el alquiler del libro "${titulo}"?<p>
                        <button class="accept">Aceptar</button>
                        <button class="cancel">Cancelar</button>    
                    </div>
                </div> 
            </div>      
        </td>
    <tr>
    `
}
export default CardReservas;



