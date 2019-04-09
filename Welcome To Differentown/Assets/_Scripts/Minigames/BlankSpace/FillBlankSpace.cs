using UnityEngine;

public class FillBlankSpace : MonoBehaviour {

    public bool isCompleted;
    public int index = 0;
    private FillBlankWordCard wordCard;

    public FillBlankSentenceController sentenceController;

    private bool isIn;


    private void Update()
    {
        if (isIn)
        {
            CheckWord();
        }
    }

    //Verifica se a palavra no espaço é a correta. Se for, ele verifica se a frase está completa. Se estiver, ele chama as ações pós minigame
    private void CheckWord()         
    {
        if (wordCard != null && Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space) && wordCard != null)
        {            
            if (wordCard.cardIndex == index)
            {
                isCompleted = true;
                wordCard.transform.position = transform.position;
                wordCard.col.enabled = false;
                wordCard.button.OnDeselect(null);

                if (sentenceController.CheckCompleteness())
                {
                    sentenceController.actions.Invoke();
                }
            }
            else
            {
                if (!isCompleted)
                {
                    wordCard.transform.localPosition = wordCard.initialPosition;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        wordCard = other.GetComponent<FillBlankWordCard>();
        isIn = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isIn = false;
    }
}
