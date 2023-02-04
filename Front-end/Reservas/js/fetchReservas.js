const url = "https://localhost:7113/api/alquiler/reservas/cliente/1"
const ArrayReservas = {}

ArrayReservas.reservas = async() => {
    const config ={
        method: 'GET',
        headers:{
            'Content-Type':'application/json'
        }
    }
    ;
    try{
        const respuesta = await fetch (url, config);
        const fin = await respuesta.json();
        return fin; 
    }catch(error){
        console.log(error);
    }
}
export default ArrayReservas;

export async function Reserva(DtoAlquiler) {
    const url = "https://localhost:7113/api/alquiler"   
    const config = {
        method: 'PUT',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify(
            DtoAlquiler
        )
    }
    ;
    try{
        const response = await fetch (url, config);
        console.log(response);
        if(response.status !== 201)
        {
            alert("Error al actualizar el estado.");
        }
        const result = await response.json();
        return result; 
    }catch(error){
        console.log(error);
    }
}