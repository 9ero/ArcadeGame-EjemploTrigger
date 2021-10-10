using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instancia;
    public static GameManager instancia
    {
        get
        {
            return _instancia;
        }//Fin get
    }//Fin

    private int _puntaje;

    public int ObtenerPuntaje()
    {
        return _puntaje;
    }
    public void RestaurarPuntaje()
    {
        _puntaje = 0;
    }

    public void SumarPuntaje(int valor)
    {
        _puntaje += valor;
    }

    public void Awake()
    {
        if (_instancia == null)
        {
            _instancia = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }//Fin awake

    public void CambiarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }//Fin metodo

    public void Salir()
    {
        Application.Quit();
    }//Fin metodo

    private void OnApplicationQuit()
    {

    }//Fin metodo

    public bool GuardarPuntaje(int posicion, int valor)
    {
        try
        {
            PlayerPrefs.SetInt("Pos"+posicion.ToString(), valor);
        }//Fin try
        catch (System.Exception ex)
        {
            return false;
        }//Fin catch

        return true;
    }//Fin metodo

    public int ObtenerPuntaje(int posicion)
    {
        return PlayerPrefs.GetInt("Pos" + posicion.ToString(),0);
    }//Fin metodo

}//Fin clase
