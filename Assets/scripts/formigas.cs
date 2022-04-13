using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class formigas : MonoBehaviour
{
    [SerializeField]
   private float veloci = 20f;
    [SerializeField]
   private LayerMask layer;
   [SerializeField]
   private Vector2 raycastposition;

   private Rigidbody2D rigi;
   private Controle2D _controle;
   private int andireita;
   private float movhori;

    private void OnEnable()
    {
        rigi = GetComponent<Rigidbody2D>();
        _controle = GetComponent<Controle2D>();
        andireita = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movhori = andireita * veloci;
    }

    void FixedUpdate()
    {
        _controle.Movimento(movhori* Time.deltaTime, false);

        var origemx = transform.position.x + raycastposition.x;
        var origemy = transform.position.y + raycastposition.y;
        var raydirei = Physics2D.Raycast(new Vector2(origemx, origemy), Vector2.right,0.5f, layer);

        Debug.DrawRay(new Vector2(transform.position.x, origemy), Vector2.right, Color.blue);

        if(raydirei.collider != null)
        {
            andireita = -1;
        }

        var rayesq = Physics2D.Raycast(new Vector2(transform.position.x - raycastposition.x, origemy), Vector2.left, 0.4f, layer);
        Debug.DrawRay(new Vector2(transform.position.x, origemy), Vector2.right, Color.red);

        if(rayesq.collider != null)
        {
            andireita = 1;
        }
    }

}

