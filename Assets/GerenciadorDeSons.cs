using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeSons : MonoBehaviour
{
    [SerializeField]
    private AudioClip correndo;

    private List<AudioSource>  audios;

    private void Awake()
    {
        audios = new List<AudioSource>();
        if(correndo != null)
        {
            var ac= gameObject.AddComponent<AudioSource>();
            ac.clip = correndo;
            ac.name = "correndo";
            audios.Add(ac);
        }
    }

    public void TocaAudo(string nome)
    {
        foreach(var audio in audios)
        {
            if(audio.name.Equals(nome))
            {
                audio.Play();
                break;
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
