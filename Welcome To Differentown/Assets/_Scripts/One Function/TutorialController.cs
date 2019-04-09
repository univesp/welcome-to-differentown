using System.Collections;
using UnityEngine;

//Esse script chama a tela de tutorial no início da cena do aeroporto
public class TutorialController : MonoBehaviour {

    public GameObject tutorialScreen;
    private bool wasActive;

    private void OnEnable()
    {
        if (!wasActive)
        {
            StartCoroutine(CallTutorialScreen());
        }
    }

    private IEnumerator CallTutorialScreen()
    {
        yield return new WaitForSeconds(2.0f);
        tutorialScreen.SetActive(true);
        wasActive = true;
    }
}
