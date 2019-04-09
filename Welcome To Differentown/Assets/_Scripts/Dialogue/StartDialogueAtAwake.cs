using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartDialogueAtAwake : MonoBehaviour {

    //Esse script faz com que um diálogo aconteça assim que a cena começa, sem precisar da interação do jogador
    public ObjectDialogueTrigger objectDialogueTrigger;
    public DialogueController nextDialogue;
    public Button[] interactables;

    //Desativa botões para o jogador não correr risco de ativar mais de uma fala ao mesmo tempo
    private void OnEnable()
    {
        for(int i = 0; i < interactables.Length; i++)
        {
            interactables[i].enabled = false;
        }

        StartCoroutine(WaitToStart());
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1.5f);
        objectDialogueTrigger.StartDialogue();
    }

    //Essa função é chamada no final da fala. Reativa os botões
    public void EnableInteractables()
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            interactables[i].enabled = true;
        }
    }
    
    public void SetNextDialogue(DialogueController dialogue)
    {
        nextDialogue = dialogue;        
    }

    public void SetObjectDialogue()
    {
        objectDialogueTrigger.SetDialogueController(nextDialogue);
    }
}
