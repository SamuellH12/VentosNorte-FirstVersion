using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamarProximoNivel : MonoBehaviour
{
    public bool auto;
    public bool encontro;
    public string nomeDaFase;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            var player = collision.GetComponent<jogadorProximoNivel>();
            
            if(auto)
            {
                SceneManager.LoadScene(nomeDaFase);
                return;
            }
            if(encontro){
                player.encontro();
            }
            
            player.animPassaNivel();
        }
    }
}
