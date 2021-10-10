using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoPuntaje : Objetivo
{
    // Start is called before the first frame update

    public int puntos=1;
    public GameObject prefabTiempoNegativo;
   
    public float tiempoLimite = 30f;

    private bool modoSuperPuntaje=false;
    private float tiempoTranscurrido;
    

   




    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            var player = other.GetComponent<Player>();

            GameObject.Instantiate(prefabTiempoNegativo);
            var objetivoTiempo = prefabTiempoNegativo.GetComponent<ObjetivoTiempo>();
            objetivoTiempo.ReposicionarNuevo();
            if (player.CalcularSuperPuntaje())
            {
                player.IncrementarPuntos((puntos * 10));
              

            }
            else
            {
                player.IncrementarPuntos(puntos);
               
               
            }

        }
            base.OnTriggerEnter(other);
    }

   

  






}
