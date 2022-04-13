using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cactomovel : MonoBehaviour
{
    [SerializeField]
    private float raio;
    [SerializeField]
   private GameObject jogador;
    [SerializeField]
    private float tempoPraVirar;
    [SerializeField]
    private float velocidade;

    private float direção;
    [SerializeField]
    private float tempo;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movimento = new Vector3(direção, 0f, 0f);
        tempo = tempo + Time.deltaTime;
        var difjog = jogador.gameObject.transform.position.x - transform.position.x;
        var dentroDaArea = Math.Abs(difjog)< raio;
         
        if(dentroDaArea)
        {
            if(jogador.transform.position.x - transform.position.x >0 )
           {
             direção = 0.3f;
             transform.eulerAngles = new Vector3(0f, 180f, 0f);
           } else {
               direção = -0.3f;
               transform.eulerAngles = new Vector3(0f, 0f, 0f);
           } 

           anim.SetBool("atacando", true);
        } 
         
        if(!dentroDaArea && tempoPraVirar*2<=tempo)
        {
            tempo = 0;
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            direção = 1;
        } else
        {
            if(!dentroDaArea && tempoPraVirar<=tempo)
            {
                direção= -1;
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
        
        transform.position += movimento * Time.deltaTime * velocidade;

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, raio);
    }

}
