using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RearrangePhraseController : MonoBehaviour {

    [HideInInspector]
    public List<RearrangePhraseButtonWordController> wordList;

    [Header("Layout Group")]
    public GameObject layoutGroup;
    private bool refresh;

    [Header("Phrase Variable")]
    public int wordQuantity;
    public int index;

    [Header("Events")]
    public UnityEvent rightActions;
    public UnityEvent[] wrongActions;
    private int wrongActionsIndex = 0;

    [Header("Ok Button")]
    public GameObject okButton;

    public void Update()
    {
        if(!refresh)
        {
            layoutGroup.SetActive(false);
            layoutGroup.SetActive(true);
            refresh = true;
        }
    }

    public void CheckWordOrder()
    {        
        if (wordList.Count == wordQuantity)
        {
            index = 0;
            foreach (RearrangePhraseButtonWordController word in wordList)
            {
                if (word.wordIndex != index)
                {
                    wrongActions[wrongActionsIndex].Invoke();
                    wrongActionsIndex++;
                    break;
                }
                index++;
            }

            if(index == wordQuantity)
            {
                rightActions.Invoke();
            }
        }
    }
}
