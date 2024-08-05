

var services = []
var products = []
var costosProd = []
var tot =0
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById("searchButton").addEventListener('click', function () {
        var servicios = document.getElementById("ServiciosArea")
        var placa = document.getElementById("PlacaSearch").value
        $.ajax({
            type: 'POST',
            data: { placa: placa },
            url : 'https://localhost:7019/Facturacion/SearchPlaca',
            success: function (response) {
                console.log(response)
                document.getElementById("ClientName").value = response.arrayInfo[0].nombre
                document.getElementById("EncargadoName").value = response.arrayInfo[0].encargado
                for (var i = 0; i < response.arrayInfo.length; i++) {
                    servicios.value += response.arrayInfo[i].servicio + '\n'                    
                    services.push({ servicio: response.arrayInfo[i].servicio })
                }

                for (var i = 0; i < response.arrayCostos.length; i++) {
                    costosProd.push({ ID: response.arrayCostos[i].id, Costos: response.arrayCostos[i].costo })
                }
                console.log(costosProd)
            },
            error: function (xhr, status, error) {
                console.error('Error:', error);
            }
        })
    })

    document.getElementById("AddService").addEventListener("click", function () {
        var servicio = document.getElementById("ServicioNew").value

        if (servicio.length <= 0) {
            alert("Debe ingresar un servicio antes de continuar")
        } else {
            services.push({ servicio: servicio })
            document.getElementById("ServiciosArea").value = ""
            servicio = ""

            for (var i = 0; i < services.length; i++) {
                document.getElementById("ServiciosArea").value += services[i].servicio + '\n'
            }
        }
    })

    document.getElementById("AddProduct").addEventListener("click", function () {
        var product = document.getElementById("Products")
        var area = document.getElementById("ProductosArea")
       
        products.push({ Id: product.value, Producto: product.options[product.selectedIndex].text })

        for (var i = 0; i < costosProd.length; i++) {
            if (product.value == costosProd[i].ID) {
                tot += redondearDecimales(costosProd[i].Costos,2)
                console.log(tot)
                document.getElementById("MontoTotal").innerHTML = redondearDecimales(tot, 2)
                document.getElementById("HiddenMonto").value = redondearDecimales(tot, 2)
                break
            }
        }

        area.value = ""
        for (var i = 0; i < products.length; i++) {
            area.value += products[i].Producto + '\n'
        }
        
    })

    document.getElementById("SubmitButton").addEventListener("click", function () {
        var sendData = document.getElementById("cryptoSend")
        var sendProducts = document.getElementById("cryptoSendProducts")
        encrypt(sendData, services)
        encrypt(sendProducts, products)
        document.getElementById("FormPrin").submit()
        
    })
})

function encrypt(element,array) {
    const buffer = new Uint8Array(16)
    window.crypto.getRandomValues(buffer)
    let key = ''

    buffer.forEach(byte => {
        key += byte.toString(16).padStart(2, '0')
    })

    const iv = CryptoJS.lib.WordArray.random(16);

    const encrypted = CryptoJS.AES.encrypt(JSON.stringify(array), CryptoJS.enc.Hex.parse(key), { iv: iv }).toString()
    const ivBase64 = CryptoJS.enc.Base64.stringify(iv);

    element.value = key + "," + ivBase64 + "," + encrypted
    console.log(element.value)
}

function redondearDecimales(numero, decimales) {
    numeroRegexp = new RegExp('\\d\\.(\\d){' + decimales + ',}');   // Expresion regular para numeros con un cierto numero de decimales o mas
    if (numeroRegexp.test(numero)) {         // Ya que el numero tiene el numero de decimales requeridos o mas, se realiza el redondeo
        return Number(numero.toFixed(decimales));
    } else {
        return Number(numero.toFixed(decimales)) === 0 ? 0 : numero;  // En valores muy bajos, se comprueba si el numero es 0 (con el redondeo deseado), si no lo es se devuelve el numero otra vez.
    }
}