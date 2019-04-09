using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Esse script ativa e desativa o efeito do passaporte selecionado
public class PassportButtonSelect : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public Sprite selectedSprite;

    public Button button;

    public void OnSelect(BaseEventData eventData)
    {
        spriteRenderer.sprite = selectedSprite;        
    }

    public void OnDeselect(BaseEventData eventData)
    {
        spriteRenderer.sprite = normalSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        spriteRenderer.sprite = selectedSprite;
        button.Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        spriteRenderer.sprite = normalSprite;
        button.OnDeselect(null);
    }

}
