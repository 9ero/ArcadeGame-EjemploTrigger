using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerdidaHelper : MonoBehaviour
{
    public string EscenaPortada;
    
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
