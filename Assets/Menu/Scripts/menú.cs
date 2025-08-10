using UnityEngine.SceneManagement;
using UnityEngine;

public class Boton : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Pasar a la siguiente escena tomando el número de la actualmente activa
    }

    public void Options () 
    {

    }
    public void Salir()
    {
        Debug.Log("Cerrando...");
        Application.Quit(); //Funciona si tenemos la aplicacion creada
    }
}
