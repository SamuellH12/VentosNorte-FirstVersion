using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virarLadoDaPlat : MonoBehaviour
{
    private PlatformEffector2D platEffector;
    [SerializeField]
    private Joystick joystick;
    [SerializeField]
    private float sensibilidadeDoBotao;
    private float time;
    private bool ativo = false;
    private float botaoVertical;
    void Start()
    {
        platEffector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
         botaoVertical = Input.GetAxisRaw("Vertical");
         if(joystick.Vertical<=sensibilidadeDoBotao){
         botaoVertical = -1;
        }
        //botaoVertical = joystick.Vertical;
        //sensibilidadeDoBotao = botaoVertical;
        if(ativo){
        time = time + Time.deltaTime;
        }
        if( botaoVertical < 0f)
        {
            platEffector.rotationalOffset = 180f;
            ativo = true;
        }
        if(time>=0.5f && ativo)
        {
            platEffector.rotationalOffset = 0f;
            time = 0f;
            ativo = false;
        }
        
    }
}
