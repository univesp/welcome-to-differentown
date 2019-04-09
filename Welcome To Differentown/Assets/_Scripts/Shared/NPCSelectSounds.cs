using UnityEngine;
using UnityEngine.EventSystems;

public class NPCSelectSounds : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{

    private bool isSelected;

    public void Update()
    {
        if(isSelected)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                AudioPlayerController.instance.PlaySFX_OpcaoClick();
            }
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    public void OnDeselect(BaseEventData enventData)
    {
        isSelected = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isSelected = true;
        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isSelected = false;
    }
}