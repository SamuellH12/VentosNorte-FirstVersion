using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ficarNaPlataforma : MonoBehaviour
{
    public bool plat;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("plataforma"))
        {
            this.transform.parent = collision.transform;
            plat = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("plataforma"))
        {
            this.transform.parent = null;
            plat = false;
        }
    }
}
