using UnityEngine;
using UnityEngine.Events;
using UnityEditor;
using System.Collections;

public class DialogueController : MonoBehaviour {       

    [Header("JSON")]
    public TextAsset json;

    public Dialogue[] dialogues;
    private int dialogueIndex = 0;
    private int falaIndex = 0;
    public bool isLastLine; //Se tiver minigame e esse dialogue controller for reutilizado, tem que deixar esse bool falso

    public DialogueBoxController dialogueBox;

    [Header("Dialogue Trigger")]
    public UnityEvent dialogueAction;
    private Sprite sprite;

    //Avisa que esse diálogo vai ativar ações quando ele terminar
    [Header("If have action")]
    public bool haveAction;

    private void Start()
    {        
        if (json != null)
        {
            LoadJson();
        }
    }

    //Mostra na tela o diálogo anterior
    public void ShowPreviousDialogue()
    {
        if(falaIndex >= 2)
        {
            falaIndex -= 2;

            if (falaIndex < 1)
            {
                dialogueBox.previousButton.SetActive(false);
                dialogueBox.previousButtonEffect.fillAmount = 0f;
            }

            if (!dialogues[dialogueIndex].jogadorFala)
            {
                dialogueBox.playerDialogueBox.SetActive(false);
                dialogueBox.npcDialogueBox.SetActive(true);
                dialogueBox.SetNPCText(dialogues[dialogueIndex].fala[falaIndex]);
            }
            else
            {
                dialogueBox.playerDialogueBox.SetActive(true);
                dialogueBox.SetPlayerText(dialogues[dialogueIndex].fala[falaIndex]);
            }

            falaIndex++;
        }
    }

    public void DialogueTrigger()
    {
        if(dialogueIndex <= 0 && falaIndex <= 0)
        {
            SetPlayerName();            
        }        
        
        //Ativa a caixa de diálogo e mostra o texto fazendo a leitura do Json
        dialogueBox.gameObject.SetActive(true);
        if (dialogues[dialogueIndex].fala.Length > falaIndex)
        {            
            if(falaIndex == 1)
            {
                dialogueBox.previousButton.SetActive(true);
                dialogueBox.previousButtonEffect.fillAmount = 0f;
            }else if(falaIndex < 1)
            {
                dialogueBox.previousButton.SetActive(false);
                dialogueBox.previousButtonEffect.fillAmount = 0f;
            }

            if(!dialogues[dialogueIndex].jogadorFala)
            {
                dialogueBox.playerDialogueBox.SetActive(false);
                dialogueBox.npcDialogueBox.SetActive(true);
                dialogueBox.SetNPCText(dialogues[dialogueIndex].fala[falaIndex]);

                dialogueBox.npcName.text = dialogues[dialogueIndex].nomePersonagem;

                sprite = dialogueBox.spriteAtlas.GetSprite(dialogues[dialogueIndex].expressao);
                dialogueBox.npcImage.sprite = sprite;
                dialogueBox.npcImage.SetNativeSize();
            }
            else
            {
                dialogueBox.playerDialogueBox.SetActive(true);
                dialogueBox.SetPlayerText(dialogues[dialogueIndex].fala[falaIndex]);
            }
            falaIndex++;            
        }
        else
        {
            falaIndex = 0;
            dialogueIndex++;            
            if (dialogues.Length > dialogueIndex)
            {
                if (dialogues[dialogueIndex].expressao != dialogues[dialogueIndex - 1].expressao && dialogues[dialogueIndex].expressao != "" && dialogues[dialogueIndex-1].expressao != "")
                {
                    StartCoroutine(WaitAnimation());
                }
                else
                {
                    DialogueTrigger();
                }
            }
            else
            {
                dialogueIndex = 0;                   

                if(haveAction)
                {
                    isLastLine = true;
                    dialogueAction.Invoke();
                }
                else
                {
                    dialogueBox.gameObject.SetActive(false);
                }
            }
        }
    }

    private IEnumerator WaitAnimation()
    {
        dialogueBox.CallSwitchAnimation();
        yield return new WaitForSeconds(0.5f);
        sprite = dialogueBox.spriteAtlas.GetSprite(dialogues[dialogueIndex].expressao);
        dialogueBox.npcImage.sprite = sprite;
        dialogueBox.npcImage.SetNativeSize();
        DialogueTrigger();     
    }

    public void SetIsLastLine(bool currentState)
    {
        isLastLine = currentState;
    }

    //Carrega o Json
    private void LoadJson()
    {
        dialogues = JsonHelper.getJsonArray<Dialogue>(json.text);        
    }

    //Troca os % pelo nome do jogador assim que inicia a primeira fala
    private void SetPlayerName()
    {
        for (int i = 0; i < dialogues.Length; i++)
        {
            for (int j = 0; j < dialogues[i].fala.Length; j++)
            {
                if (dialogues[i].fala[j].Contains("%"))
                {
                    dialogues[i].fala[j] = dialogues[i].fala[j].Replace("%", PlayerPrefs.GetString("PlayerName"));
                }
            }
        }
    }
}