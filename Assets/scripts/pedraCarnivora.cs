using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedraCarnivora : MonoBehaviour
{
    [SerializeField]
    private float tempoEntreAtaques;
    [SerializeField]
    private float tempoPraIniciar = 0;

    private float tempo;
    private CapsuleCollider2D collid;
    private Animator anim;

    void Start()
    {
        collid= GetComponent<CapsuleCollider2D>();
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tempo = tempo + Time.deltaTime;    
    if(tempoPraIniciar <= tempo){  

        if(tempo>=tempoEntreAtaques)
        {
            anim.SetBool("atacando", true);
        }
        
        if(tempo>=tempoEntreAtaques + 4){
            anim.SetBool("atacando", false);
            tempo = 0;
        }
    }
    } 

    void coll()
    {
        collid.enabled = !collid.enabled;
    }
}
