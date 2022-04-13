using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaExtra : MonoBehaviour
{

    private bool destruir = false;

    void Update(){

        if(destruir){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            var player = collision.GetComponent<vidasDoJogador>();
            player.Dano(-1);
            destruir = true;
            
        }
        
    }
}
