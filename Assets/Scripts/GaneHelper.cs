using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaneHelper : MonoBehaviour
{
    public string EscenaPortada, PuntajeFinal = "1000";
    public Text txtPuntajeFinal;

    private void Start()
    {
        PuntajeFinal = GameManager.instancia.ObtenerPuntaje().ToString();
        txtPuntajeFinal.text = PuntajeFinal;
    }
    public void VolverPortada()
    {
        try
        {
            GameManager.instancia.CambiarEscena(EscenaPortada);
        }//Fin try
        catch (System.Exception ex)
        {
            Debug.Log("No hay GameManager en la escena " + ex);
        }//Fin catch
    }


}
