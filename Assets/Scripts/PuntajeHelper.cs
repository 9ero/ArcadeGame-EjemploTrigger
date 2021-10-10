using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeHelper : MonoBehaviour
{
    public string EscenaPortada;
    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EsperarCambioEscena());
    }//Fin star

    private IEnumerator EsperarCambioEscena()
    {
        yield return new WaitForSeconds(timer);
        VolverPortada();
    }

    // Update is called once per frame
    void Update()
    {
        
    }//Fin updates

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
    }//Fin metodo

}//Fin clase
