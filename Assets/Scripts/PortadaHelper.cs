using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortadaHelper : MonoBehaviour
{
    public string EscenaJuego, EscenaPuntaje;
    public float timer = 5f;

    void Start()
    {
        StartCoroutine(EsperarCambioEscena());
    }//Fin star

    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(timer);
        VerMejoresPuntajes();
    }
    public void IniciarJuego()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaJuego);
        }//Fin try
        catch (System.Exception ex)
        {
            Debug.Log("No hay GameManager en la escena "+ex);
        }//Fin catch
    }//Fin metodo

    public void VerMejoresPuntajes()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaPuntaje);
        }//Fin try
        catch (System.Exception ex)
        {
            Debug.Log("No hay GameManager en la escena " + ex);
        }//Fin catch
    }//Fin metodo

    public void Salir()
    {
        try
        {
            GameManager.instancia.Salir();
        }//Fin try
        catch (System.Exception ex)
        {
            Debug.Log("No hay GameManager en la escena " + ex);
        }//Fin catch
    }//Fin metodo

}
