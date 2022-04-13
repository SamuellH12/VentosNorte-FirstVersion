using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma : MonoBehaviour
{
    public float Velocidade;
    //public float TempoDeVolta;
    private float tempo;
    private int direção;

    public int direçãoInicial;
    
    void Start()
    {
        direção = direçãoInicial;
    }

 
    void Update()
    {
        Vector3 movimento = new Vector3(direção, 0f, 0f);
        transform.position += movimento * Time.deltaTime * Velocidade; 
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("limiteEsq"))
        {
            direção = 1;
        }
        if(collision.gameObject.tag.Equals("limiteDirei"))
        {
            direção = -1;
        }
    }

}
