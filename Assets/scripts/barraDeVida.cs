using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class barraDeVida : MonoBehaviour
{
    [SerializeField]
    private Sprite vidaCheia;
    [SerializeField]
    private Sprite vidaVazia;
    [SerializeField]
    private GameObject vidaPrefab;

    private List<GameObject> corações = new List<GameObject>();

    public void atualizarBarraDeVida(int vidaAtual, int totalDeVidas)
    {
        resetarLista();

        int qtdVidas = totalDeVidas;
        if(vidaAtual > qtdVidas){ qtdVidas = vidaAtual; }

        for(int i = 0; i<qtdVidas; i++)
        {
            if(vidaAtual<=i)
            {
                vidaPrefab.GetComponent<Image>().sprite = vidaVazia;
            }
            else
            {
                vidaPrefab.GetComponent<Image>().sprite = vidaCheia;
            }
            var posicaoDeX = transform.position.x + (35 * i);
            var go = Instantiate(vidaPrefab, new Vector3( posicaoDeX ,transform.position.y, 0), Quaternion.identity, this.transform);
            corações.Add(go);
        }
    }

    private void resetarLista()
    {
        foreach (var cora in corações)
        {
            Destroy(cora);
        }
    }
}
