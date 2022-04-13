using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cactoAtacar : MonoBehaviour
{
    [SerializeField]
    private float raio;
    [SerializeField]
    private GameObject jogador;
    [SerializeField]
    private float tempoDeAtque;

    [SerializeField]
    private Transform origem;
    [SerializeField]
    private GameObject prefab;
    
    [SerializeField]
    private float tempo;
    
    [SerializeField]
    private float difjog;
    [SerializeField]
    private bool dentroDaArea;

     private Animator anim;
     

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
       difjog = jogador.gameObject.transform.position.x - transform.position.x;
     
        if(Math.Abs(difjog)< raio)
        {
            dentroDaArea = true;
            anim.SetBool("atacando", true); 
            
            if(difjog > 0){
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            } else
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        } else
        {
            dentroDaArea = false;
            anim.SetBool("atacando", false);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        } 

       
        
    }

    void FixedUpdate()
    {
        if(!dentroDaArea)
        {
            anim.SetBool("atacando", false);
        }
        else
        {
            tempo = tempo + Time.deltaTime;

            if(tempo>=tempoDeAtque)
            {
                tempo = 0f;
                Atirar();
            }
        }
    }

    private void Atirar()
    {
        Instantiate(prefab, origem.position,origem.rotation);
        fisicaEspinho.x =  jogador.gameObject.transform.position.x;
        fisicaEspinho.y =  jogador.gameObject.transform.position.y;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raio);
    }
}
