using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarColision : MonoBehaviour
{

    public Material materialResaltado;
    public Material materialOriginal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("un objeto a entrado");
        if (other.CompareTag("Player"))
        {
            Debug.Log("es un player");

            try
            {
                var player = other.GetComponent<Player>();
                player.Alerta();

                var rigitbd = other.GetComponent<Rigidbody>();
                //rigitbd.AddTorque(new Vector3(Random.Range(0f, 100f), Random.Range(0f, 100f), Random.Range(0f, 100f)));
                rigitbd.AddForce(new Vector3(Random.Range(-1000f, 1000f), Random.Range(1f, 1000f), Random.Range(-1000f, 1000f)));

            }//Fin try
            catch(System.Exception ex)
            {
                Debug.LogError("olvido poner un componente player, en el objeto que tiene la etiqueta player: "+ex.Message);
            }//Fin catch

        }//fin if

    }// este metodo es para colision

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("un objeto esta dentro del trigger");

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialResaltado;
        }
    }// este metodo se ejecuta cada frame mientras haya una colision

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("un objeto a salido del trigger");

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = materialOriginal;
        }

    }// este metodo se ejecuta cuando ya no hay colision

}//Fin clase
