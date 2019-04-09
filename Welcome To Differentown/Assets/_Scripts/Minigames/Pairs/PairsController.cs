using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Esse script pega referência de dois cards selecionados pelo jogador. 
//Ao pegar o segundo card, ele faz a comparação entre os cards e libera os dois espaços novamente para o jogador selecionar mais dois cards
public class PairsController : MonoBehaviour {

    public int pairsQtd;
    private int currentQtd = 0;

    private bool refresh;

    [Header("Layout group")]
    public GameObject layoutGroupObject;

    [Header("Normal Color")]
    public ColorBlock normalColor;
    [Header("Wrong Color")]
    public ColorBlock wrongColor;
    [Header("Selected Color")]
    public ColorBlock selectedColor;

    public bool isChecking;

    [HideInInspector]
    public PairsWordCard wordCard1, wordCard2;

    public UnityEvent actions;

    //Esse update é para atualizar o tamanho do texto quando o minigame começa
    private void Update()
    {
        if (!refresh)
        {
            layoutGroupObject.SetActive(false);
            layoutGroupObject.SetActive(true);
            refresh = true;
        }
    }

    public bool CompareCards()
    {
        isChecking = true;

        if(wordCard1.index == wordCard2.index)
        {
            StartCoroutine(ChangeColorRight());
            
            return true;
        }
        else
        {
            StartCoroutine(ChangeColorWrong());

            return false;
        }
    }

    private IEnumerator ChangeColorRight()
    {
        wordCard1.button.interactable = false;
        wordCard2.button.interactable = false;

        yield return new WaitForSeconds(0.3f);

        wordCard1.button.colors = normalColor;
        wordCard2.button.colors = normalColor;

        yield return new WaitForSeconds(0.3f);

        wordCard1.button.colors = selectedColor;
        wordCard2.button.colors = selectedColor;
        AudioPlayerController.instance.PlaySFX_Acerto();
        currentQtd++;

        wordCard1 = null;
        wordCard2 = null;

        isChecking = false;
        if (currentQtd == pairsQtd)
        {
            actions.Invoke();
        }
    }

    private IEnumerator ChangeColorWrong()
    {
        wordCard1.button.interactable = false;
        wordCard2.button.interactable = false;

        yield return new WaitForSeconds(0.3f);

        wordCard1.button.colors = normalColor;
        wordCard2.button.colors = normalColor;

        yield return new WaitForSeconds(0.3f);

        wordCard1.button.colors = wrongColor;
        wordCard2.button.colors = wrongColor;
        AudioPlayerController.instance.PlaySFX_Erro();

        yield return new WaitForSeconds(0.3f);

        wordCard1.button.interactable = true;
        wordCard2.button.interactable = true;
        wordCard1.button.colors = normalColor;
        wordCard2.button.colors = normalColor;
        wordCard1.buttonSelected = false;
        wordCard2.buttonSelected = false;
        wordCard1 = null;
        wordCard2 = null;

        isChecking = false;
    }
}
