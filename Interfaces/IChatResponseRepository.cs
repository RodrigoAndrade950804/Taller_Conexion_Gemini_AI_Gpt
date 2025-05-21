namespace Taller_Conexion_Gemini_Ai_Gpt.Interfaces

{

    public interface IChatResponseRepository

    {

        Task SaveResponseAsync(Models.ChatResponse response);

    }

}

