using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DialogueBoxController : MonoBehaviour {

    //Esse script guarda todas as informações pra mudar os diálogos ao longo do jogo
    public GameObject npcDialogueBox;
    public Text npcDialogueTxt;
    public Text npcName;
    public Image npcImage;
    public SpriteAtlas spriteAtlas;

    public Animator npcAnimator;
    public Animator boxAnimator;

    public GameObject previousButton;
    public Image previousButtonEffect;

    public GameObject playerDialogueBox;
    public Text playerDialogueTxt;

    //Atualiza as falas do NPC
    public void SetNPCText(string text)
    {
        npcDialogueTxt.text = text;
    }

    //Atualizada as falas do jogador
    public void SetPlayerText(string text)
    {
        playerDialogueTxt.text = text;
    }

    //Inicia animação pra troca de sprite do NPC
    public void CallSwitchAnimation()
    {
        boxAnimator.Play("gameplay_fala_sai", -1, 0f);
        npcAnimator.Play("NPC_conversa_troca", -1, 0f);
    }
}
