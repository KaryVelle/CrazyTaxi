using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiadorDeEscena : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreDeEscena;

    // Método que se llama cuando se presiona el botón
    public void CambiarEscena()
    {
        // Cambiar a la escena con el nombre proporcionado
        SceneManager.LoadScene(nombreDeEscena);
    }
}
