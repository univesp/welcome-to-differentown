using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RearrangePhraseReset : MonoBehaviour {

    public RearrangePhraseButtonWordController[] wordCard;
    public Text text;

    public void ResetMinigame()
    {
        for(int i = 0; i < wordCard.Length; i++)
        {
            wordCard[i].MoveWord();
        }
        text.text = "";
    }
}
