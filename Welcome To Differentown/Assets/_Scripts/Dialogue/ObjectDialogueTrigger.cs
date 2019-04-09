using UnityEngine;

//Esse script vai em todos os objetos que iniciam um diálogo
public class ObjectDialogueTrigger : MonoBehaviour {

    public DialogueController dialogueController;
    private CurrentDialogueController activeDialogue;

    public void OnEnable()
    {
        activeDialogue = GameObject.FindGameObjectWithTag("CoreScripts").GetComponent<CurrentDialogueController>();
    }

    //Atualiza o Dialogue Controller desse objeto. O Dialogue Controller é o script que contém o Json
    public void SetDialogueController(DialogueController newDialogueController)
    {
        dialogueController = newDialogueController;
    }

    //Define o diálogo atual e inicia as falas
    public void StartDialogue()
    {
        activeDialogue.SetActiveDialogue(dialogueController);
        dialogueController.DialogueTrigger();
    }
}
