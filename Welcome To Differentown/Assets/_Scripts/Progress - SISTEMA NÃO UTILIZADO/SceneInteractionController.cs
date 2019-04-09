using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneInteractionController : MonoBehaviour {

    public TotalInteractionsController totalInteractionsController;
    public int totalSceneInteractions;
    private int completedInteractions = 0;

    public Image[] interactionSpriteRenderer;
    public Sprite completeInteractionSprite;

    public void AddCompleteInteraction()
    {
        completedInteractions++;
        if(completedInteractions <= totalSceneInteractions)
        {            
            interactionSpriteRenderer[completedInteractions - 1].sprite = completeInteractionSprite;
            totalInteractionsController.AddCurrentInteraction();
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            AddCompleteInteraction();
        }
    }
}
