using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class fisicaEspinho : MonoBehaviour
{
    [SerializeField]
    private GameObject jogador;
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private Vector3 movimento;

    private float time;
     
    public static float x;
    public static float y;
    
    void Start()
    {   
        movimento = new Vector3((x - transform.position.x), (1 + y - transform.position.y), 0f);
    //    Vector3 movimento = new Vector3(jogador.gameObject.transform.position.x, jogador.gameObject.transform.position.y, 0f);
    } 

    void Update()
    { 
        transform.position += movimento * Time.deltaTime * velocidade;
        time = time + Time.deltaTime;
        if(time>4)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            var player = collision.GetComponent<vidasDoJogador>();
            player.Dano(1);

        }

        if(collision.gameObject.tag.Equals("inimigo"))
        {

        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
