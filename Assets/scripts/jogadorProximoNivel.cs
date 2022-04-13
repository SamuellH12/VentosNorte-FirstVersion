using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogadorProximoNivel : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private GameObject vitoria;
    [SerializeField]
    private GameObject desativarQndChamarAFunção;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void animPassaNivel()
    {
        anim.SetBool("vitoria", true);
    }

    public void Vitoria()
    {
        vitoria.SetActive(true);
        desativarQndChamarAFunção.SetActive(false);
    }

    public void encontro()
    {
        anim.SetBool("encontro", true);
    }

    
}
