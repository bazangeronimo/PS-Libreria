export const CardDetalle= (titulo, autor, isbn, edicion, editorial, stock, imagen) => {
    if(stock>0)
    return `
    <div class = "cardDetalle">
        <div class = "dividir">
            <div class = "imagenDetalle">
                <img id="portada" src = ${imagen} alt="imagen de portada de libro">
            </div>
            <div class = "detallesLibro">
                <h1 class = "titulo"> <strong>"${titulo}"</strong> </h1>
                <h5 class = "titulo"> <strong>Autor: ${autor}</strong> </h5>
                <hr/>
                <p class = "texto"> ISBN: ${isbn} </p>
                <p class = "texto"> Editorial: ${editorial} </p>
                <p class = "texto"> Edición: ${edicion} </p>
                <p class = "texto"> Stock: ${stock} </p>
            </div>
        </div>
        <div class = "buton-card">
            <div class = "boton-centro">
                <div id="alquilar" type="button" class="btn btn-success accion" >Alquilar</div>
                <div class="modal">
                  <div class="modal-content">
                    <p> ¿Desea alquilar el libro "${titulo}"?<p>
                    <button id="alquilar" class="accept" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Aceptar</button>
                    <button class="cancel">Cancelar</button>
                  </div>
                </div>
                <div id="reservar" type="button" class="btn btn-success accion" >Reservar</div>
                <div class="modal">
                  <div class="modal-content">
                    <p> ¿Desea reservar el libro "${titulo}"?<p>
                    <button id="reservar" class="accept" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Aceptar</button>
                    <button class="cancel">Cancelar</button>
                  </div>
                </div>
            </div>
        </div>
    </div>
   `
   else
   return `
   <div class = "cardDetalle">
       <div class = "dividir">
           <div class = "imagenDetalle">
               <img id="portada" src = ${imagen} alt="imagen de portada de libro">
           </div>
           <div class = "detallesLibro">
               <h1 class = "titulo"> <strong>"${titulo}"</strong> </h1>
               <h5 class = "titulo"> <strong>Autor: ${autor}</strong> </h5>
               <hr/>
               <p class = "texto"> ISBN: ${isbn} </p>
               <p class = "texto"> Editorial: ${editorial} </p>
               <p class = "texto"> Edición: ${edicion} </p>
           </div>
       </div>
       <div class = "buton-card">
           <div class = "boton-centro">
               <div id="agotado" class="btn btn-danger accion" >Agotado</div>
           </div>
       </div>
   </div>
  `
   
}
export default CardDetalle;


/* <div id="alquilar" type="button" class="btn btn-success accion" >Reservar</div>
<div class="modal">
  <div class="modal-content">
    <p> ¿Desea reservar el libro "${titulo}"?<p>
    <button id="reservarr" class="acceptt" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Aceptar</button>
    <button class="cancel">Cancelar</button>
  </div>
</div> */




//<button id="reservar" type="button" class="btn btn-primary accion" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Reservar</button>    

// export const CardDetalle= ({titulo, autor, isbn, edicion, editorial, stock, imagen}) => {
//     return `
//     <div class = "card">
//         <div class = "dividir">
//             <div class = "imagen">
//                 <img src = ${imagen}>
//             </div>
//             <div class = "Detalle-Alquiler-Reserva">
//                 <p class = "titulo"> Título: ${titulo} </p>
//                 <p class = "titulo"> Autor: ${autor} </p>
//                 <p class = "texto"> ISBN: ${isbn} </p>
//                 <p class = "texto"> Editorial: ${editorial} </p>
//                 <p class = "texto"> Edición: ${edicion} </p>
//                 <p class = "texto"> Stock: ${stock} </p>
//             </div>
//         </div>
//         <div class = "buton-card">
//             <div class = "boton-centro">
//                 <button id="alquilar" type="button" class="btn btn-success accion" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Alquilar</button>
//                 <button id="reservar" type="button" class="btn btn-primary accion" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Reservar</button>    
//                 <!-- Botón para abrir el modal -->
//                 <button id="open-modal-btn">Crear Alquiler/Reserva</button>
//             </div>
//         </div>
//         <!-- Modal -->
//         <div class="modal-overlay">
//             <div class="modal">
//                 <div class="modal-header">
//                     <h3>Crear Alquiler/Reserva</h3>
//                     <span class="close-modal">&times;</span>
//                 </div>
//                 <div class="modal-body">
//                     <p>¿Estás seguro de que deseas crear un alquiler o reserva?</p>
//                 </div>
//                 <div class="modal-footer">
//                     <button class="modal-btn accept-btn">Aceptar</button>
//                     <button class="modal-btn cancel-btn">Cancelar</button>
//                 </div>
//             </div>
//         </div>
//     </div>
//    `
// }
// export default CardDetalle;