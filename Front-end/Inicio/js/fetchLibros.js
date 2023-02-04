export const ArrayLibros = {}
ArrayLibros.libros = async(stock, titulo, autor) => {
    const config = {
        method: 'GET',
        headers:{
            'Content-Type':'application/json'
        }
    }
    ;
    try{
        const response = await fetch (`https://localhost:7113/api/libros?autor=${autor}&titulo=${titulo}`, config);
        const result = await response.json();
        return result; 
    }catch(error){
        console.log(error);
    }
}
export default ArrayLibros;


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









