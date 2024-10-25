document.getElementById('toggle-btn').addEventListener('click', function(){
    const sidebar = document.getElementById('sidebar');
    sidebar.classList.toggle('collapsed');
});


// Arreglo de objetos turno
const turnos = [
    { id: 1, nombreCliente: 'Juan Pérez', fecha: new Date().toISOString().split('T')[0], hora: new Date().getHours().toString().padStart(2, '0') + ':' + new Date().getMinutes().toString().padStart(2, '0')},
    { id: 2, nombreCliente: 'María López', fecha: new Date().toISOString().split('T')[0], hora: new Date().getHours().toString().padStart(2, '0') + ':' + new Date().getMinutes().toString().padStart(2, '0')},
    { id: 3, nombreCliente: 'Carlos García', fecha: new Date().toISOString().split('T')[0], hora: new Date().getHours().toString().padStart(2, '0') + ':' + new Date().getMinutes().toString().padStart(2, '0')},
    { id: 4, nombreCliente: 'Ana Martínez', fecha: new Date().toISOString().split('T')[0], hora: new Date().getHours().toString().padStart(2, '0') + ':' + new Date().getMinutes().toString().padStart(2, '0')},
    { id: 5, nombreCliente: 'Luis Fernández', fecha: new Date().toISOString().split('T')[0], hora: new Date().getHours().toString().padStart(2, '0') + ':' + new Date().getMinutes().toString().padStart(2, '0')}
];

// Crear section para listar los turnos
function listarTurnos() {
    // Obtengo la etiqueta padre
    const section = document.getElementById('turnos-cliente');
    section.innerHTML = "";

    // Creo una etiqueta table y le agrego un tabla
    const table = document.createElement('table');
    table.classList.add('table', 'table-bordered', 'table-striped', 'table-success', 'table-hover', 'turnos'); // agrego las clases
    table.id = 'tabla1' // agrego id
    table.innerHTML = `
                <thead>
                        <tr>
                            <th scope="col">ID</th>
                            <th scope="col">Cliente</th>
                            <th scope="col">Fecha</th>
                            <th scope="col">Hora</th>
                        </tr>
                </thead>
                <tbody id="tbody">
                </tbody>
    `
    section.appendChild(table);

    turnos.forEach(turno => {
        const tbody = document.getElementById('tbody');
        const id = document.createElement('td');
        const cliente = document.createElement('td');
        const fecha = document.createElement('td');
        const hora = document.createElement('td');
        const row = document.createElement('tr');

        id.textContent = turno.id;
        cliente.textContent = turno.nombreCliente;
        fecha.textContent = turno.fecha;
        hora.textContent = turno.hora;

        row.appendChild(id);
        row.appendChild(cliente);
        row.appendChild(fecha);
        row.appendChild(hora);
        tbody.appendChild(row);

    })

}

// Crear section para listar los turnos y cantidad
function listarCantTurnos() {
    // Obtengo la etiqueta padre
    const section = document.getElementById('turnos-cliente');
    section.innerHTML = "";

    // Creo una etiqueta table y le agrego un tabla
    const table = document.createElement('table');
    table.classList.add('table', 'table-bordered', 'table-striped', 'table-success', 'table-hover', 'turnos'); // agrego las clases
    table.id = 'tabla2' // agrego id
    table.innerHTML = `
                <thead>
                        <tr>
                            <th scope="col">Cliente</th>
                            <th scope="col">Cantidad Turnos</th>
                        </tr>
                </thead>
                <tbody id="tbody">
                </tbody>
    `
    section.appendChild(table);

    turnos.forEach(turno => {
        const tbody = document.getElementById('tbody');
        const cliente = document.createElement('td');
        const cantTurnos = document.createElement('td');
        const row = document.createElement('tr');

        cliente.textContent = turno.nombreCliente;
        cantTurnos.textContent = turno.numeroTurno;

        row.appendChild(cliente);
        row.appendChild(cantTurnos);
        tbody.appendChild(row);

    })

}

// Crear section formulario para agregar turnos
function mostrarFormulario() {
    // Obtengo la etiqueta padre
    const section = document.getElementById('turnos-cliente');
    section.innerHTML = "";

    const form = document.createElement('form');
    form.id = 'form';
    form.innerHTML = `
            <div class="mb-3">
                <label for="idCliente" class="form-label">ID:</label>
                <input type="text" class="form-control" id="idCliente" placeholder="id">
            </div>
            <div class="mb-3">
                <label for="cliente" class="form-label">Cliente</label>
                <input type="text" class="form-control" id="cliente" placeholder="Nombre del cliente">
            </div>
            <div class="mb-3">
                <label for="fecha" class="form-label">Fecha</label>
                <input type="text" class="form-control" id="fecha" readonly>
            </div>
            <div class="mb-3">
                <label for="hora" class="form-label">Hora</label>
                <input type="text" class="form-control" id="hora" readonly>
            </div>
            <div>
                <button onclick="agregarCliente();" class="btn btn-success mb-3">Agregar Cliente</button>
            </div>
    `

    section.appendChild(form);
}

const sections = [listarTurnos, listarCantTurnos, mostrarFormulario];
let indiceActual = 0;

function mostrarSeccion(indice){
    sections[indice]();
}

// Evento para el botón "Siguiente"
document.getElementById('siguiente-btn').addEventListener('click', () => {
    indiceActual = (indiceActual + 1) % sections.length; // Incrementa y cicla al inicio si llega al final
    mostrarSeccion(indiceActual);
});

// Evento para el botón "Anterior"
document.getElementById('anterior-btn').addEventListener('click', () => {
    indiceActual = (indiceActual - 1 + sections.length) % sections.length; // Decrementa y cicla al final si llega al inicio
    mostrarSeccion(indiceActual);
});

mostrarSeccion(indiceActual);

// Función de agregar un cliente
function agregarCliente() {
    const $id = document.getElementById('idCliente');
    const $cliente = document.getElementById('cliente');
    const $fecha = document.getElementById('fecha');
    const $hora = document.getElementById('hora');

    let id = $id.value;
    let cliente = $cliente.value;
    let fecha = new Date().toISOString().split('T')[0];
    let hora = new Date().getHours().toString().padStart(2, '0') + ':' + new Date().getMinutes().toString().padStart(2, '0');

    const turno = {
        'id' : id,
        'cliente' : cliente,
        'fecha' : fecha,
        'hora' : hora
    }

    turnos.push(turno);
}