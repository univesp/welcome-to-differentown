using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PairsWordCard : MonoBehaviour, IPointerEnterHandler, ISelectHandler {

    public PairsController pairsController;

    public int index;
    public Button button;

    public bool buttonSelected;
    private int wordCardIndex;

    public void SetWordCard()
    {
        if (!pairsController.isChecking)
        {
            AudioPlayerController.instance.PlaySFX_MouseClick();
            if (buttonSelected)
            {
                buttonSelected = false;
                if (wordCardIndex == 1)
                {
                    pairsController.wordCard1.button.colors = pairsController.normalColor;
                    pairsController.wordCard1 = null;
                }
                else if (wordCardIndex == 2)
                {
                    pairsController.wordCard2.button.colors = pairsController.normalColor;
                    pairsController.wordCard2 = null;
                }
            }
            else
            {
                buttonSelected = true;
                if (pairsController.wordCard1 == null)
                {
                    pairsController.wordCard1 = this;
                    wordCardIndex = 1;
                    pairsController.wordCard1.button.colors = pairsController.selectedColor;
                }
                else if (pairsController.wordCard2 == null)
                {
                    pairsController.wordCard2 = this;
                    wordCardIndex = 2;
                    pairsController.wordCard2.button.colors = pairsController.selectedColor;
                    pairsController.CompareCards();
                }

            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayerController.instance.PlaySFX_MouseOver();
    }

    public void OnSelect(BaseEventData eventData)
    {
        AudioPlayerController.instance.PlaySFX_MouseOver();
    }
}
