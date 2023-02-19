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

export const ArrayLibro = {}
ArrayLibro.libros = async(input) => {
    const config = {
        method: 'GET',
        headers:{
            'Content-Type':'application/json'
        }
    }
    ;
    try{
        const response = await fetch (`https://localhost:7113/api/libro?input=${input}`, config);
        const result = await response.json();
        return result; 
    }catch(error){
        console.log(error);
    }
}
export const fetchDetalle = async (isbn) => {
    const config = {
        method: 'GET',
        headers:{
            'Content-Type':'application/json'
        }
    }
    ;
    try {
        const response = await fetch(`https://localhost:7113/api/libros/isbn?isbn=${isbn}`, config);
        const result = await response.json();
        return result;
    }catch(error){
        console.log(error);
    }
}
export const fetchAutores= async (autor) => {
    const config = {
        method: 'GET',
        headers:{
            'Content-Type':'application/json'
        }
    }
    ;
    try {
        const response = await fetch(`https://localhost:7113/api/libros/isbn?isbn=${autor}`, config);
        const result = await response.json();
        return result;
    }catch(error){
        console.log(error);
    }
}
export default {ArrayLibros,ArrayLibro,fetchDetalle,fetchAutores};