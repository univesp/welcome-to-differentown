using System.Collections;
using UnityEngine;

//Animação de saída da caixa de diálogo
public class FilterFadeOut : MonoBehaviour {

    public GameObject dialogueBox;
    public GameObject npcDialogueBox;
    public Animator playerDialogueBoxAnimator;
    public Animator filterAnimator;

    public void CallCoroutine()
    {
        StartCoroutine(WaitToFadeOut());
    }

    private IEnumerator WaitToFadeOut()
    {
        playerDialogueBoxAnimator.Play("gameplay_pensamento_sai");
        yield return new WaitForSeconds(0.2f);
        filterAnimator.Play("fundo_filtro_sai");
        yield return new WaitForSeconds(0.5f);
        dialogueBox.SetActive(false);
        npcDialogueBox.SetActive(true);
    }
}
