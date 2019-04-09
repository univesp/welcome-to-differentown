using UnityEngine;
using UnityEngine.Events;

//Esse script contém as ações que vão acontecer quando o jogador escolher uma das opções
public class OptionActionController : MonoBehaviour
{

    public string optionText;
    public UnityEvent optionAction;

    public void CallOptionAction()
    {
        AudioPlayerController.instance.PlaySFX_OpcaoClick();
        optionAction.Invoke();
    }
}
