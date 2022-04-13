using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float comprimento;
    private float posiçãoInicial;


    private Transform camer;

    public float parallaxEffect;

    void Start()
    {
        posiçãoInicial = transform.position.x;
        comprimento = GetComponent<SpriteRenderer>().bounds.size.x;
        camer = Camera.main.transform;
        
    }
    void Update()
    {
        float reposicionar = camer.transform.position.x * (1-parallaxEffect);

        float distancia = camer.transform.position.x * parallaxEffect;

        transform.position = new Vector3(posiçãoInicial + distancia, transform.position.y, transform.position.z);

        if(reposicionar > posiçãoInicial + comprimento)
        {
            posiçãoInicial += comprimento;
        }
        else if(reposicionar < posiçãoInicial - comprimento)
        {
            posiçãoInicial -= comprimento;
        }
    }
}
