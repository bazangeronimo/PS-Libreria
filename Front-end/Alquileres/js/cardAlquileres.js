export const CardAlquileres = (isbn, titulo, autor, edicion, editorial, fecha_de_Reserva, fecha_de_Alquiler, fecha_de_Devolucion) => {
    if(fecha_de_Reserva === null && fecha_de_Alquiler !== null && fecha_de_Devolucion !== null)
    return `
    <tr>
        <td class = "text-center">${isbn}</td>
        <td class = "text-center">${titulo}</td>
        <td class = "text-center">${autor}</td>
        <td class = "text-center">${edicion}</td>
        <td class = "text-center">${editorial}</td>
        <td class = "text-center">-----------</td>
        <td class = "text-center">${new Date(fecha_de_Alquiler).toLocaleDateString()}</td>
        <td class = "text-center">${new Date(fecha_de_Devolucion).toLocaleDateString()}</td>
    <tr>
    `
    if(fecha_de_Reserva !== null && fecha_de_Alquiler === null && fecha_de_Devolucion === null)
    return `
    <tr>
        <td class = "text-center">${isbn}</td>
        <td class = "text-center">${titulo}</td>
        <td class = "text-center">${autor}</td>
        <td class = "text-center">${edicion}</td>
        <td class = "text-center">${editorial}</td>
        <td class = "text-center">${new Date(fecha_de_Reserva).toLocaleDateString()}</td>
        <td class = "text-center">-----------</td>
        <td class = "text-center">-----------</td>
    <tr>
    `
    if(fecha_de_Reserva !== null && fecha_de_Alquiler !==null && fecha_de_Devolucion !== null)
    return `
    <tr>
        <td class = "text-center">${isbn}</td>
        <td class = "text-center">${titulo}</td>
        <td class = "text-center">${autor}</td>
        <td class = "text-center">${edicion}</td>
        <td class = "text-center">${editorial}</td>
        <td class = "text-center">${new Date(fecha_de_Reserva).toLocaleDateString()}</td>
        <td class = "text-center">${new Date(fecha_de_Alquiler).toLocaleDateString()}</td>
        <td class = "text-center">${new Date(fecha_de_Devolucion).toLocaleDateString()}</td>
    <tr>
    `
}
export default CardAlquileres;

