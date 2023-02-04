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
        <td class = "text-center"><button id=alquilar type="button" class="btn btn-success accion" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Alquilar</button></td>
    <tr>
    `
}
export default CardReservas;