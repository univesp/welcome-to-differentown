using UnityEngine;
using UnityEngine.UI;

public class RearrangePhraseButtonWordController : MonoBehaviour {

    private bool isInPhrase;

    [Header("Button Variables")]
    public ColorBlock color;
    public ColorBlock usedColor;
    public Button button;

    [Header("Word list")]
    public RearrangePhraseController phraseController;
    public int wordIndex;
    public Text phraseText;
    public Text cardWord;

    public void MoveWord()
    {
        //Se a palavra já estiver na frase, ele vai retirá-la de lá
        if(isInPhrase)
        {
            isInPhrase = false;
            //Aqui vai a busca da palavra na lista. Ele puxa pelo index do botão na lista. Se achar, ele tira a palavra da lista e apaga a palavra da frase
            foreach (RearrangePhraseButtonWordController wordButton in phraseController.wordList)
            {
                if (wordButton.wordIndex == wordIndex)
                {
                    phraseController.wordList.Remove(wordButton);
                    button.colors = color;
                    phraseText.text = phraseText.text.Replace(cardWord.text + " ", "");

                    if(phraseController.okButton.activeSelf)
                    {
                        phraseController.okButton.SetActive(false);
                    }

                    break;
                }
            }
        }
        else
        {
            //Adiciona a palavra à lista de palavras e imprime a palavra na frase
            isInPhrase = true;
            phraseController.wordList.Add(this);
            button.colors = usedColor;
            phraseText.text += cardWord.text + " ";

            if(phraseController.wordList.Count == phraseController.wordQuantity)
            {
                phraseController.okButton.SetActive(true);
            }
        }
    }
}
