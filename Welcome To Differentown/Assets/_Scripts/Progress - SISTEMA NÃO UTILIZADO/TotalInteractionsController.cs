using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalInteractionsController : MonoBehaviour {

    public int maxInteractions;
    public int minInteractions;
    private int currentInteractions = 0;

    public void AddCurrentInteraction()
    {
        currentInteractions++;
    }

    public void FinishGame()
    {
        if(currentInteractions == maxInteractions)
        {
            //TODO - Chama final
            Debug.Log("FIM DE JOGO");
        }

        /* - ISSO PODE FAZER PARTE DE UM ATUALIZAÇÃO DO JOGO
        if(currentInteractions == maxInteractions)
        {
            //FAZ FINAL VERDADEIRO
        }else if(currentInteractions >= minInteractions)
        {
            //FAZ FINAL NORMAL
        }else
        {
            //NÃO PODE TERMINAR O JOGO
        }*/
    }

    private void Update()
    {
        FinishGame();
    }
}