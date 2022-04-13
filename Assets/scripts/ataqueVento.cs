using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueVento : MonoBehaviour
{
    private BoxCollider2D ataquin;
    private Animator anim;
    [SerializeField]
    private GameObject particulas;
    private bool parti =true;

    void Start()
    {
        ataquin = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    public void Ataque()
    {
        ataquin.enabled = parti;

        anim.SetBool("ataque", false);

        particulas.SetActive(parti);

        parti = !parti;
    }
}
