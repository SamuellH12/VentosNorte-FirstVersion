using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    private bool botaoAtivado = false;
    [SerializeField]
    GameObject _joystick;
    [SerializeField]
    GameObject pulaBotao;
    
    public void MostrarJoystic()
    {
        _joystick.SetActive(!botaoAtivado);
        pulaBotao.SetActive(!botaoAtivado);
        botaoAtivado = !botaoAtivado;
    }

    public void Recomeco(string lvelName)
    {
        SceneManager.LoadScene(lvelName);
    }

    

}
