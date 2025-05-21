namespace Taller_Conexion_Gemini_Ai_Gpt.Models

{

    public class ChatRequestDTO

    {

        public string Prompt { get; set; }

        public string Proveedor { get; set; }  // Asegúrate que el nombre coincide con el que usas aquí

        public string Usuario { get; set; }    // Si quieres guardar quién envía el mensaje

    }

}
