using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jogador : MonoBehaviour
{

    public float Speed;
    public float ForçaPulo;
    public float forçapulo2;
    public bool pulando;
  

    private Rigidbody2D rigib;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {
      rigib = GetComponent<Rigidbody2D>();
      anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Pulo();
    }

    void Move(){
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * Speed;
        if(Input.GetAxis("Horizontal")>0f)
        {
          transform.eulerAngles = new Vector3(0f, 0f, 0f);
          anime.SetBool("correndo", true);
        }
        if(Input.GetAxis("Horizontal")<0f)
        {
          transform.eulerAngles = new Vector3(0f, 180f, 0f);
          anime.SetBool("correndo", true);
        }
        if(Input.GetAxis("Horizontal")==0f)
        {
          anime.SetBool("correndo", false);
        }
     }
     
     void Pulo()
     {
         if(Input.GetButtonDown("Jump") && pulando==false)
         {
           rigib.AddForce(new Vector2(0f, ForçaPulo), ForceMode2D.Impulse);
           anime.SetBool("pulando", true);
         }
         
     }  

    void OnColsionEnter2D(Collision2D colisor)
    {
      if(colisor.gameObject.layer == 8)
      {
        pulando = false;
        anime.SetBool("pulando", false);
      }
    }
    void OnColsionExit2D(Collision2D colisor)
    {
        if(colisor.gameObject.layer == 8)
      {
        pulando = true;
      }
    }

}
