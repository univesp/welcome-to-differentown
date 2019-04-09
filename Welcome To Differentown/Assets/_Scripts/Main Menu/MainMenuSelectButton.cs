using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuSelectButton : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;

    [Header("Selected color")]
    public Color selectedColor;
    [Header("Unselected text color")]
    public Color unselectedTextColor;
    [Header("Unselected image color")]
    public Color unselectedImageColor;

    public Text text;
    public Image[] image;

    private bool buttonSelected;

    private void Update()
    {
        //Toca som de clique se clicar no botão
        if(buttonSelected)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                AudioPlayerController.instance.PlaySFX_MouseClick();
            }
        }
    }

    //Muda as cores e avisa que o botão está selecionado
    public void OnSelect(BaseEventData eventData)
    {
        buttonSelected = true;

        text.color = selectedColor;
        image[0].color = selectedColor;
        image[1].color = selectedColor;

        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    //Muda as cores das imagens e avisa que o botão não está selecionado
    public void OnDeselect(BaseEventData eventData)
    {
        buttonSelected = false;

        text.color = unselectedTextColor;
        image[0].color = unselectedImageColor;
        image[1].color = unselectedImageColor;
    }

    //Muda as cores das imagens e avisa que o botão está selecionado
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonSelected = true;

        text.color = selectedColor;
        image[0].color = selectedColor;
        image[1].color = selectedColor;

        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    //Muda as cores das imagens e avisa que o botão não está selecionado
    public void OnPointerExit(PointerEventData eventData)
    {
        buttonSelected = false;

        text.color = unselectedTextColor;
        image[0].color = unselectedImageColor;
        image[1].color = unselectedImageColor;
    }

    //Ao desativar, ele tira a seleção do botão e reseta as cores
    private void OnDisable()
    {
        button.OnDeselect(null);
        buttonSelected = false;

        text.color = unselectedTextColor;
        image[0].color = unselectedImageColor;
        image[1].color = unselectedImageColor;
    }
}
