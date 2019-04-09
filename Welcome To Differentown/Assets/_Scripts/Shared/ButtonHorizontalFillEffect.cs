using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHorizontalFillEffect : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler{

    //As interfaces controlam o momento em que o botão é selecionado/desselecionado ou quando o mouse entra/sai da área do botão
    public Button button;
    public Image effectImage;

    private float currentTime = 0;
    private bool fill;
    private bool empty;

    private bool buttonSelected;

    public void Update()
    {
        //Quando o botão for selecionado, o efeito de preencher o botão é ativado
        if(fill)
        {
            if (effectImage.fillAmount < 1.0f)
            {
                currentTime += Time.deltaTime * 4;
                effectImage.fillAmount = currentTime;
            }
            else
            {
                fill = false;
            }
        }

        //Quando o botão for desselecionado, o efeito de preencher o botão é desativado
        if(empty)
        {
            if(effectImage.fillAmount > 0)
            {
                currentTime -= Time.deltaTime * 4;
                effectImage.fillAmount = currentTime;
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
        currentTime = 0;
        effectImage.fillAmount = currentTime;
    }
}
