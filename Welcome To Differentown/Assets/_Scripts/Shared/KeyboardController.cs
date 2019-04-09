using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardController : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{

    //Esse script faz com que o teclado ou o mouse não consigam interagir com o diálogo enquanto estiverem interagindo com os elementos que contém esse script
    public CurrentDialogueController currentDialogueController;
    public bool isClicked = false;

    public void OnSelect(BaseEventData eventData)
    {
        if (!isClicked)
        {
            currentDialogueController.SetPauseKeyboard(true);
        }
    }

    public void OnDeselect(BaseEventData enventData)
    {
        if (!isClicked)
        {
            currentDialogueController.SetPauseKeyboard(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isClicked)
        {
            currentDialogueController.SetPauseKeyboard(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isClicked)
        {
            currentDialogueController.SetPauseKeyboard(false);
        }
    }

    public void SetIsClicked (bool currentState)
    {
        isClicked = currentState;
    }
}
