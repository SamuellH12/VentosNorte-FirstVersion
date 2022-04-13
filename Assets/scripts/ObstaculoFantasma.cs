using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoFantasma : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objetosParaDestruir;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            for(int i=0; i<objetosParaDestruir.Length; i++){
                Destroy(objetosParaDestruir[i]);
            }
        }
    }
}
