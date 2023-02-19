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
                <div class="modalAlquiler">
                  <div class="modal-content">
                    <p> ¿Desea alquilar el libro "${titulo}"?<p>
                    <button id="alquilar" class="accept" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Aceptar</button>
                    <button class="cancel">Cancelar</button>
                  </div>
                </div>
                <div id="reservar" type="button" class="btn btn-success accion" >Reservar</div>
                <div class="modalReserva">
                  <div class="modal-content">
                    <p> ¿Desea reservar el libro "${titulo}"?<p>
                    <button id="reservar" class="acceptt" onclick="javascript:window.localStorage.setItem('isbn',${isbn})">Aceptar</button>
                    <button class="cancell">Cancelar</button>
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
               <label id="agotado" class="item-agotado">Agotado</label>
           </div>
       </div>
   </div>
  `
}
export default CardDetalle;