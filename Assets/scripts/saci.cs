using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class saci : MonoBehaviour
{

    [SerializeField]
   private float range;
   [SerializeField]
   private GameObject jogador;
   private float tempo;
   private float direção;
   [SerializeField]
   private float velocidade;
   [SerializeField]
   private float tempoParaGirar;

   private Animator anim;
    // Start is called before the first frame update
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
        var dentroDaArea = Math.Abs(difjog)< range;

        if(dentroDaArea)
        { 
           anim.SetBool("atacando", true); 
           if(jogador.transform.position.x - transform.position.x >0 )
           {
             direção = 0.3f;
           } else {
               direção = -0.3f;
           }
           transform.position += movimento * Time.deltaTime * velocidade;
        } 
        else
        {
        anim.SetBool("atacando", false);
        } 
          

        if(tempo>tempoParaGirar*2 && !dentroDaArea)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            tempo = 0;
            direção = 1;
        }
        else
        {
            if(tempo>tempoParaGirar && !dentroDaArea)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                direção = -1;
            }
        }

        
        transform.position += movimento * Time.deltaTime * velocidade;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
