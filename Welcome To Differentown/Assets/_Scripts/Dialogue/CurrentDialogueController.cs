using UnityEngine;

public class CurrentDialogueController : MonoBehaviour {

    public DialogueController activeDialogue;
    public GameObject dialogueBox;    

    public bool pauseKeyboard;

    private bool firstDialogue = true;

    private void Update()
    {
        CallNextDialogueOnTouch();
    }

    //Essa função permite avançar o texto clicando em qualquer lugar da tela, exceto nas caixas de diálogo
    public void CallNextDialogueOnTouch()
    {
        if (dialogueBox.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !pauseKeyboard)
            {
                if (!activeDialogue.isLastLine)
                {
                    activeDialogue.DialogueTrigger();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && !pauseKeyboard)
            {
                if (firstDialogue)
                {
                    firstDialogue = false;
                }
                else
                {
                    if (!activeDialogue.isLastLine)
                    {
                        activeDialogue.DialogueTrigger();
                    }
                }
            }
        }
        else
        {
            firstDialogue = true;
        }
    }

    //Chama o próximo diálogo ao pressionar o botão de "próximo"
    public void CallNextDialogue()
    {
        if (dialogueBox.activeSelf)
        {
            if (!activeDialogue.isLastLine)
            {
                activeDialogue.DialogueTrigger();
            }            
        }
        else
        {
            firstDialogue = true;
        }        
    }

    //Chama o diálogo anterior ao pressionar o botão de "anterior"
    public void CallPreviousDialogue()
    {
        activeDialogue.ShowPreviousDialogue();
        if(!activeDialogue.dialogueBox.previousButton.activeSelf)
        {
            pauseKeyboard = false;
        }
    }

    public void SetPauseKeyboard(bool currentState)
    {
        pauseKeyboard = currentState;
    }

    public void SetFirstDialogue(bool currentState)
    {
        firstDialogue = currentState;
    }

    //Define o diálogo que está acontecendo agora
    public void SetActiveDialogue(DialogueController currentDialogue)
    {
        activeDialogue = currentDialogue;
    }
}
