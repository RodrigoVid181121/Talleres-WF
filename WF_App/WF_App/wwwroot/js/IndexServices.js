
function SubmitValue(id) {
    let value = document.getElementById("serviceId")

    value.value = id

    setCookie("Action", "Finalizar", 15)

    document.forms[1].submit()
}

function setCookie(name, value, seconds) {
    const date = new Date();
    date.setTime(date.getTime() + (seconds * 1000)); // Convertir segundos a milisegundos
    document.cookie = name + "=" + (value || "") + "; expires=" + date.toUTCString() + "; path=/; SameSite=Lax";
}

function AnularService(id) {
    $.ajax({
        type: 'POST',
        url: 'https://localhost:7019/Servicios/Anulation',
        data: { id },
        success: function (response) {
            if (response === 'Anulada') {
                location.reload()
            }            
        }        
    })
}