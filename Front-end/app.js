const exp = require('constants');
const express = require('express')
const app = express();
const path = require('path')
const port = 3000

app.use(express.static(__dirname + '/'));
app.get('/inicio', function(req, res){
    res.sendFile(path.join(__dirname + '/Inicio/index.html'));
})
app.get('/libro/:isbn', function(req, res){
    res.sendFile(path.join(__dirname + '/Detalle/detalle.html'));
})
app.listen(port, () => console.log(`http://localhost:${port}/Inicio`))



