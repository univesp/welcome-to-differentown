using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonExpandFillEffect : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler{

    //As interfaces controlam o momento em que o botão é selecionado/desselecionado ou quando o mouse entra/sai da área do botão
    public Button button;
    public GameObject effectImage;

    private bool fill;
    private bool empty;

    private bool buttonSelected;

    public void Update()
    {
        //Quando o botão for selecionado, o efeito de preencher o botão é ativado
        if (fill)
        {
            if (effectImage.transform.localScale.x < 1.0f)
            {
                effectImage.transform.localScale += new Vector3(Time.deltaTime * 3, Time.deltaTime * 3, Time.deltaTime * 3);
            }
            else
            {
                fill = false;
            }            
        }
        //Quando o botão for desselecionado, o efeito de preencher o botão é desativado
        if (empty)
        {
            if (effectImage.transform.localScale.x > 0.3f)
            {
                effectImage.transform.localScale -= new Vector3(Time.deltaTime * 3, Time.deltaTime * 3, Time.deltaTime * 3);
            }
        }

        //Se o botão for selecionado, ele toca som de clique ao ser pressionado
        if (buttonSelected)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                AudioPlayerController.instance.PlaySFX_MouseClick();
            }
        }

    }

    public void OnSelect(BaseEventData eventData)
    {
        buttonSelected = true;

        fill = true;
        empty = false;

        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    public void OnDeselect(BaseEventData enventData)
    {
        buttonSelected = false;

        fill = false;
        empty = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonSelected = true;

        fill = true;
        empty = false;

        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonSelected = false;

        fill = false;
        empty = true;
    }

    //Reinicia o efeito se o botão for desativado
    private void OnDisable()
    {        
        button.OnDeselect(null);

        effectImage.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }
}
