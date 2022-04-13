using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaVertical : MonoBehaviour
{
    public float Velocidade;
    //public float TempoDeVolta;
    private float tempo;
    private int direção;
    private bool noLimite = false;

    [SerializeField]
    private float tempoParado;

    public int direçãoInicial;
    
    void Start()
    {
        direção = direçãoInicial;
    }

 
    void Update()
    {
        if(!noLimite){
            tempo = 0;
            Vector3 movimento = new Vector3(0f, direção, 0f);
            transform.position += movimento * Time.deltaTime * Velocidade;
        } else {
            tempo+=Time.deltaTime;
            if(tempo >= tempoParado){
                noLimite = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("limiteEsq"))
        {
            direção = 1;
            noLimite = true;
        }
        if(collision.gameObject.tag.Equals("limiteDirei"))
        {
            direção = -1;
            noLimite = true;
        }
    }

}
