using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Vector3 posInicial;
    private Rigidbody rigidBody;
    private float velX, velY, jump;
    private bool enPiso;
    private float tiempoDeJuego;
    private int puntaje;
   
     
    public float velocidad = 5.5f;
    public float fuerzaVertical = 2f;
    public float tiempoTranscurrido = 0f;
    public float tiempoLimite = 30f;
    

    public Text txt_tiempoTranscurrido, txt_puntajeActual, txt_limiteActual;
   

    // Start is called before the first frame update
    void Start()
    {

        
        puntaje = 0;
        rigidBody = this.GetComponent<Rigidbody>();
        posInicial = 
            new Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z
            );
    }//Fin Star

    // Update is called once per frame
    void Update()
    {
        //actualizar interfaces graficas
        txt_tiempoTranscurrido.text = this.tiempoTranscurrido.ToString();
        txt_puntajeActual.text = this.puntaje.ToString();
        txt_limiteActual.text = (tiempoLimite - tiempoDeJuego).ToString();
        //contador de tiempo
        tiempoTranscurrido += Time.deltaTime;
        tiempoDeJuego += Time.deltaTime;
       
        
        if (tiempoDeJuego > tiempoLimite)
        {
            FinDeJuego();
        }

        velX = Input.GetAxis("Horizontal");
        velY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");


        enPiso = Physics.Raycast(this.transform.position, Vector3.down, 1.05f);
        if (velX != 0||velY!=0)
        {
            rigidBody.velocity = (new Vector3(velX, 0, velY))* velocidad;
        }

        if (enPiso && jump >= 0.3f)
        {
            rigidBody.AddForce(Vector3.up * fuerzaVertical);
        }
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter ha sido presionado");

            transform.position = new Vector3(posInicial.x, posInicial.y, posInicial.z);

            rigidBody.velocity = Vector3.zero;

        }//Fin if
    }//Fin update

    public void IncrementarPuntos(int valor)
    {
        puntaje += valor;
        Debug.Log("puntaje Actual: "+puntaje.ToString());
    }
    public void ModificarTiempo(float valor)
    {
        Debug.Log("Tiempo Actual: " + tiempoDeJuego.ToString());
        tiempoDeJuego -= valor;
        Debug.Log("Tiempo con reduccion: " + tiempoDeJuego.ToString());

    }

    private void FinDeJuego()
    {
       
        GameManager.instancia.CambiarEscena("Perdida");
    }

    public void Alerta()
    {
        Debug.Log("Conexion con trigger ready");
    }

    public bool CalcularSuperPuntaje()
    {

        if((tiempoLimite-tiempoDeJuego)<=10)
        { 
            return true;
        }
        else
        {
            return false;
        }
        
    }

    

}
