using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animacaoInicial : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Ativar(){
        anim.SetBool("iniciar", true);
    }
}
