using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidasDoJogador : MonoBehaviour
{  [SerializeField]
    private int vidaTotal;
    [SerializeField]
    private int vidaAtual;
    [SerializeField]
    private barraDeVida barravida;

    [SerializeField]
    private float tempo;
    public GameObject gameOver;
    private bool inimigo;
    private Animator anim;

    private void Start()
    {
        AtualizarVida();
        anim = GetComponent<Animator>();
    } 

    void Update()
    {
        tempo = tempo + Time.deltaTime;
        if(inimigo && tempo>2)
        {
            Dano(1);
        }
        if(vidaAtual<=0)
        {
            anim.SetBool("gameOver", true);
        }
    }

    public void Dano(int dano)
    {
        if(tempo>2)
        {
           vidaAtual = vidaAtual - dano;
           AtualizarVida();
           tempo = 0;
        }
    }

    public void AtualizarVida()
    {
        barravida.atualizarBarraDeVida(vidaAtual, vidaTotal);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("inimigo") && tempo>2)
        {
            Dano(1);
            
           inimigo = true;
        }
        if(collision.gameObject.tag.Equals("boss") && tempo>2)
        {
            Dano(3);
            
           inimigo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("inimigo"))
        {
            inimigo = false;
        }
        if(collision.gameObject.tag.Equals("boss"))
        {
            inimigo = false;
        }
    }

    public void TelaGameOver()
    {
        gameOver.SetActive(true);
    }

    public void Morre()
    {
        Destroy(gameObject);
    }

}
