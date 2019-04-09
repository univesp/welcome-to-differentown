using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Esse script guarda informações sobre cada card. Eles devem ser configurados individualmente no inspector
public class FillBlankWordCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
    
    public Vector3 initialPosition;
    public int cardIndex;
    public Collider2D col;
    public Button button;

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.OnDeselect(null);
    }

    public void OnMouseUp()
    {
        transform.localPosition = initialPosition;
    }
}
