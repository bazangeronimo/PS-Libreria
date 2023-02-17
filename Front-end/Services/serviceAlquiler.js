export const ArrayAlquileres = {}
ArrayAlquileres.alquileres = async() => {
    const config ={
        method: 'GET',
        headers:{
            'Content-Type':'application/json'
        }
    }
    ;
    try{
        const response = await fetch ("https://localhost:7113/api/alquiler/cliente/1", config);
        const result = await response.json();
        return result; 
    }catch(error){
        console.log(error);
    }
}

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
        const respuesta = await fetch ("https://localhost:7113/api/alquiler/reservas/cliente/1", config);
        const fin = await respuesta.json();
        return fin; 
    }catch(error){
        console.log(error);
        
    }
}
export default {ArrayAlquileres,ArrayReservas};

export async function Alquiler(DtoAlquilerReserva) {
    const url = "https://localhost:7113/api/alquiler"   
    const config = {
        method: 'POST',
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify(
            DtoAlquilerReserva
        )
    }
    ;
    try{
        const response = await fetch (url, config);
        console.log(response);
        if(response.status !== 201)
        {
            alert("Error al intentar alquilar libro.");
        }
        const result = await response.json();
        return result; 
    }catch(error){
        console.log(error);
    }
}

export async function Reserva(DtoAlquiler) {
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
        const response = await fetch ("https://localhost:7113/api/alquiler", config);
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