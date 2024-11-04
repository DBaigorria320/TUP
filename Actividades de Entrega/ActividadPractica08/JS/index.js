async function verServicios(){
    $section = document.getElementById('section');
    $section.innerHTML = '';
    try{
        const response = fetch('http://localhost:5500/lista_servicios.html');
        const data = await response.then((rta) => {return rta.text()});
        $section.innerHTML = data;
        listarServicios();
    }catch (error){
        console.log(error);
    }
}

async function listarServicios(){
    $tbody = document.getElementById('tbody');
    $tbody.innerHTML = '';

    try{
        const response = await fetch('https://localhost:7173/api/Turnos');
        const data = await response.json();
        
        data.forEach(element => {
            const $tr = document.createElement('tr');
            const $tdCliente = document.createElement('td');
            const $tdFecha = document.createElement('td');
            const $tdHora = document.createElement('td');
            const $tdServicio = document.createElement('td');

            $tdCliente.innerHTML = element.cliente.nombre + ' ' + element.cliente.apellido;
            $tdFecha.innerHTML = element.fecha;
            $tdHora.innerHTML = element.hora;
            $tdServicio.innerHTML = element.servicio.servicio1;

            $tr.appendChild($tdCliente);
            $tr.appendChild($tdFecha);
            $tr.appendChild($tdHora);
            $tr.appendChild($tdServicio);


            $tbody.appendChild($tr);
        });


    }catch(error){
        console.log(error);
    }
}

async function cargarServicios(select){
    try{
        response = await fetch('https://localhost:7173/api/Servicios');
        data = await response.json();

        data.forEach(servicio => {
            $option = document.createElement('option');

            $option.value = servicio.idServicio;
            $option.innerText = servicio.servicio1;

            select.appendChild($option);
        })

    }catch(error){
        console.log(error);
    }
} 

async function nuevoTurno(){
    $section = document.getElementById('section');
    $section.innerHTML = '';
    
    try{
        response = fetch('http://localhost:5500/nuevo_turno.html');
        data = await response.then((rta) => {return rta.text()});
        $section.innerHTML = data;
        $select = document.getElementById('servicios_select');
        
        cargarServicios($select);

        $btnCargarTurno = document.getElementById('boton_turno').addEventListener('click', (e)=>{
            e.preventDefault();
        })
    }catch(error){
        console.log(error);
    }
}

async function cargarTurno(){
    $fecha = document.getElementById('fecha');
    $hora = document.getElementById('hora');
    $nombre = document.getElementById('nombre');
    $apellido = document.getElementById('apellido');
    $dni = document.getElementById('dni');
    $servicio = document.getElementById('servicios_select');

    turno = {
        fecha : $fecha.value,
        hora : $hora.value,
        cliente : {
            nombre : $nombre.value,
            apellido : $apellido.value,
            dni : $dni.value
        },
        servicio : { id : $servicio.value}
    }

    try{
        fetch('https://localhost:7173/api/Turnos',{
            method:'POST',
            headers:{
                'Content-Type' : 'application/json'
            },
            body : JSON.stringify(turno)
        }).then(rta => {
            if(rta.ok){
                return rta.text();
            }
        }).then(msg => {
            console.log("Respuesta: ", msg);
        })
    }catch(error){
        console.log(error);
    }
} 