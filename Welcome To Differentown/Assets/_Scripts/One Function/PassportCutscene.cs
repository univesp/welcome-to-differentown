using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PassportCutscene : MonoBehaviour {

    //Esse script faz a UI interagível aparecer para o jogador após clicar para abrir o passaporte
    public Animator animator;
    public GameObject[] ui;
    public GameObject sprites;
    public Button button;

    public void CallAnimation()
    {
        StartCoroutine(WaitAnimation());
    }

    private IEnumerator WaitAnimation()
    {
        button.interactable = false;
        animator.Play("airport_cena1b_passaporte_clica");
        yield return new WaitForSeconds(0.2f);
        AudioPlayerController.instance.PlaySFX_Passaporte();
        yield return new WaitForSeconds(1.88f);
        ui[0].SetActive(true);
        ui[1].SetActive(true);
        sprites.SetActive(false);
    }
}
