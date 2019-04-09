using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Esse script gerencia todas as ações desse minigame usando o teclado
public class KeyboardFillInTheBlanksController : MonoBehaviour {
    
    [Header("Space Positions")]
    public List<FillBlankSpace> blankSpacePos;
    private int blankSpacePosIndex = 0;

    [Header("Words")]
    public List<FillBlankWordCard> wordPile;    
    public List<Button> button;
    private int wordPileIndex = 0;

    private FillBlankWordCard currentWord;
    private bool isHoldingWord;
    private bool canPressSpace = true;

    public Scrollbar scrollbar;
    private bool isScrollbar;

    private void LateUpdate()
    {
        if (!OptionsState.instance.isInOptionsScreen)
        {
            ChangeSelectedWord();
            ChangeSelectedBlankSpace();
            GetWord();
            DropWord();
        }
    }

    private void ChangeSelectedWord()
    {
        if (!isHoldingWord && !isScrollbar)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                button[wordPileIndex].OnDeselect(null);

                wordPileIndex++;
                if (wordPileIndex >= wordPile.Count)
                {
                    wordPileIndex = 0;
                }

                button[wordPileIndex].Select();
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                button[wordPileIndex].OnDeselect(null);

                wordPileIndex--;
                if (wordPileIndex < 0)
                {
                    wordPileIndex = wordPile.Count - 1;
                }

                button[wordPileIndex].Select();
            }
        }
    }

    private void ChangeSelectedBlankSpace()
    {
        if(isHoldingWord && !isScrollbar)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                blankSpacePosIndex++;
                if (blankSpacePosIndex >= blankSpacePos.Count)
                {
                    blankSpacePosIndex = 0;
                }
                currentWord.transform.position = blankSpacePos[blankSpacePosIndex].transform.position;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                blankSpacePosIndex--;
                if (blankSpacePosIndex < 0)
                {
                    blankSpacePosIndex = blankSpacePos.Count - 1;
                }
                currentWord.transform.position = blankSpacePos[blankSpacePosIndex].transform.position;
            }
        }
    }

    private void GetWord()
    {        
        if(!canPressSpace && !isScrollbar && Input.GetKeyUp(KeyCode.Space))
        {
            canPressSpace = true;
        }

        if (!isHoldingWord && canPressSpace && Input.GetKeyDown(KeyCode.Space))
        {
            isHoldingWord = true;
            canPressSpace = false;
            currentWord = wordPile[wordPileIndex];

            blankSpacePosIndex = 0;
            currentWord.transform.position = blankSpacePos[blankSpacePosIndex].transform.position;
        }
    }

    private void DropWord()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && currentWord != null)
        {
            isHoldingWord = false;
            currentWord.transform.localPosition = currentWord.initialPosition;
            currentWord = null;
        }

        if (!canPressSpace && Input.GetKeyUp(KeyCode.Space))
        {
            canPressSpace = true;
        }

        if (isHoldingWord)
        {
            if(canPressSpace && Input.GetKeyDown(KeyCode.Space))
            {                
                currentWord = null;
                isHoldingWord = false;
                canPressSpace = false;

                if (blankSpacePos[blankSpacePosIndex].isCompleted)
                {
                    blankSpacePos.Remove(blankSpacePos[blankSpacePosIndex]);
                    wordPile.Remove(wordPile[wordPileIndex]);
                    button[wordPileIndex].OnDeselect(null);
                    button.Remove(button[wordPileIndex]);
                    wordPileIndex = 0;
                }
            }
        }
    }
}
