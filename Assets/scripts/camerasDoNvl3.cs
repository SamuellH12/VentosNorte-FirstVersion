using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasDoNvl3 : MonoBehaviour
{
    [SerializeField]
    private GameObject camera_boss;
    [SerializeField]
    private GameObject camera_obst;
    [SerializeField]
    private GameObject camera_luta;
    [SerializeField]
    private float tempoDeTransicao;

    public float tempo;
    private bool ativar;
 
    void Update()
    {

        if(ativar)
        {
            tempo += Time.deltaTime;

            if(tempo >= tempoDeTransicao * 3){
                camera_luta.SetActive(true);
                camera_obst.SetActive(false);
            }else
            if(tempo >= tempoDeTransicao * 2){
                camera_obst.SetActive(true);
                camera_boss.SetActive(false);
            } else
            if(tempo >= 1){
                camera_boss.SetActive(true);
            } 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            ativar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            camera_luta.SetActive(false);
        }
    }

}
