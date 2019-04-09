using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

//Esse script chama o teclado virtual
public class VirtualKeyboardController : MonoBehaviour, ISelectHandler, IPointerEnterHandler
{

    private bool isActive;
    public PlayableDirector enterAnimation;
    public PlayableDirector exitAnimation;

    public void ControlKeyboard()
    {
        AudioPlayerController.instance.PlaySFX_MouseClick();
        if(isActive)
        {
            exitAnimation.Play();
            isActive = false;
        }
        else
        {
            enterAnimation.Play();
            isActive = true;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayerController.instance.PlaySFX_MouseOver();
    }
}
