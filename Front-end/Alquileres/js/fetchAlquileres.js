const url = "https://localhost:7113/api/alquiler/cliente/1"
const ArrayAlquileres = {}

ArrayAlquileres.alquileres = async() => {
    const config ={
        method: 'GET',
        headers:{
            'Content-Type':'application/json'
        }
    }
    ;
    try{
        const response = await fetch (url, config);
        const result = await response.json();
        return result; 
    }catch(error){
        console.log(error);
    }
}
export default ArrayAlquileres;