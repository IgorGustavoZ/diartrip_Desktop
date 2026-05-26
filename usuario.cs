using System.Net.Http;
using System.Text.Json;

public class Usuario
{
    private readonly HttpClient client = new HttpClient();

    public async Task<List<Usuario>> GetUsuarios()
    {
        string url = "http://127.0.0.1:8000/usuarios";

        HttpResponseMessage resposta = await client.GetAsync(url);

        if (!resposta.IsSuccessStatusCode)
        {
            return new List<Usuario>();
        }

        string json = await resposta.Content.ReadAsStringAsync();

        List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

        return usuarios;
    }
}