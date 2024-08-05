document.addEventListener('DOMContentLoaded', function () {
    document.getElementById("inputImagen").addEventListener('change', function (event) {
        var file = event.target.files[0]

        if (file) {
            var reader = new FileReader()

            reader.onload = function (event) {
                var base64 = event.target.result.split(',')[1]
                var hidden = document.getElementById('ImagenID')
                hidden.value = base64

                console.log(hidden.value)
            }

            reader.readAsDataURL(file)
        }
        else {
            console.log('No file selected')
        }
    })

    document.getElementById("Reestablecer").addEventListener("click", function () {
        var elements = document.querySelectorAll("input[type='text']")
        var radio = document.querySelectorAll("input[type='radio']")

        elements.values = ''

        radio.checked = false;
    })

    //obteniendo la cookie y asignandola al input de action

    let cookie = getCookie("Action")
    if (cookie) {
        document.getElementById("ActionValue").value = cookie
    }

    let value = document.getElementById("serviceId")
    if (value.value.length < 0) {
        value.value = 0
    }

})



function PutAction() {
    let action = document.getElementById("ActionValue")

    if (action.value.length <= 0 || action.value == "SearchPlaca") {
        action.value = "Create"
    }
    document.forms[1].submit()

}


function getCookie(name) {
    const nameEQ = name + "=";
    const ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function FillData() {
    var placa = document.getElementById('PlacaSearch').value

    if (placa.length <= 0) {
        placa = 0
        document.forms[0].submit()
    }
    else {
        document.forms[0].submit()
    }


}

var services = []
function SaveServices() {
    var put = document.getElementById("KeyValue")
    var combo = document.getElementById("servicios").value;

    const buffer = new Uint8Array(16)

    services.push(combo)
    console.log(combo)

    let serviciosJSON = [];

    services.forEach(servicio => {
        serviciosJSON.push({ Id: servicio })
    })

    console.log(serviciosJSON)
    window.crypto.getRandomValues(buffer)
    let key = ''

    buffer.forEach(byte => {
        key += byte.toString(16).padStart(2, '0')
    })

    const iv = CryptoJS.lib.WordArray.random(16);

    const encrypted = CryptoJS.AES.encrypt(JSON.stringify(serviciosJSON), CryptoJS.enc.Hex.parse(key), { iv: iv }).toString()
    const ivBase64 = CryptoJS.enc.Base64.stringify(iv);

    put.value = key + "," + ivBase64 + "," + encrypted
    console.log(put.value)
}
