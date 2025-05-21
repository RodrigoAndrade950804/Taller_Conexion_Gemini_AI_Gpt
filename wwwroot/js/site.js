$(document).ready(function () {
    $('#chatForm').submit(function (e) {
        e.preventDefault();

        var provider = $('#provider').val();
        var prompt = $('#prompt').val();
        var guardadoPor = $('#guardadoPor').val();

        if (!provider || !prompt) {
            alert('Por favor selecciona un proveedor y escribe una pregunta.');
            return;
        }

        // Muestra el mensaje del usuario en el chat
        $('#chatHistory').append(
            `<div class="d-flex justify-content-end mb-2">
                <div class="chat-bubble-user" style="max-width: 75%;">
                    <strong>Tú:</strong><br />${$('<div>').text(prompt).html()}
                </div>
            </div>`
        );
        // Agrega el bubble de cargando del bot
        $('#chatHistory').append(
            `<div class="d-flex justify-content-start mb-2" id="loading-bubble">
                <div class="chat-bubble-bot" style="max-width: 75%;">
                    <strong>${$('#provider option:selected').text()}:</strong><br />
                    <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Escribiendo...
                </div>
            </div>`
        );
        $('#chatHistory').scrollTop($('#chatHistory')[0].scrollHeight);


        // Limpia el textarea
        $('#prompt').val('');

        // Llama al backend usando AJAX
        $.ajax({

            url: '/api/chat/enviar', // ✅ esta es la ruta correcta

            type: 'POST',

            contentType: 'application/json',

            data: JSON.stringify({

                Proveedor: provider,

                Prompt: prompt,

                Usuario: guardadoPor

            }),

            success: function (data) {

                $('#loading-bubble').remove();

                $('#chatHistory').append(

                    `<div class="d-flex justify-content-start mb-2">
<div class="chat-bubble-bot" style="max-width: 75%;">
<strong>${provider}:</strong><br />

                    ${$('<div>').text(data.respuesta).html()}
</div>
</div>`

                );

                $('#chatHistory').scrollTop($('#chatHistory')[0].scrollHeight);

            },

            error: function () {

                $('#loading-bubble').remove();

                $('#chatHistory').append(

                    `<div class="alert alert-danger mt-2">Error al obtener respuesta del servidor.</div>`

                );

            }

        });


    });
});
