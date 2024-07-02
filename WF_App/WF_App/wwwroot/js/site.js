// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

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

})

function SubmitValue(id) {
    let value = document.getElementById("serviceId")

    value.value = id

    setCookie("Action", "Finalizar", 15)

    document.forms[1].submit()
}

function PutAction() {
    let action = document.getElementById("ActionValue")

    if (action.value.length <= 0) {
        action.value = "Create"
    }

    document.forms[0].submit()
}

function setCookie(name, value, seconds) {
    const date = new Date();
    date.setTime(date.getTime() + (seconds * 1000)); // Convertir segundos a milisegundos
    document.cookie = name + "=" + (value || "") + "; expires=" + date.toUTCString() + "; path=/";
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