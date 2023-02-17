export const CardStock = (titulo, autor, isbn, edicion, stock, imagen) => {
    if(stock>0 || stock==0)
    return `
        <div class = "flip-card">
            <div class = "flip-card-inner">
                <div class = "flip-card-front">
                    <div class = "imagen">
                        <img src = ${imagen}>
                    </div>
                </div>
                <div class = "flip-card-back">
                    <p class = "titulo"> Título: ${titulo} </p>
                    <p class = "titulo"> Autor: ${autor} </p>
                    <p class = "texto"> ISBN: ${isbn} </p>
                    <p class = "texto"> Edición: ${edicion} </p>
                    <hr class="line">
                    <div class="link"><a href="/libro/${isbn}" id ="asd"  onclick="javascript:window.location.pathname='/libro/${isbn}">Details</a></div>
                </div>
            </div>
        </div>
   `
};
export default CardStock;