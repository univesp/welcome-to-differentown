using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineTransitionController : MonoBehaviour {

    //Esse script pega referência de uma timeline e espera o tempo total (ou parcial) da animação para trocar para a próxima tela
    public PlayableDirector transitionTimeline;
    public GameObject nextScreen;
    public GameObject currentScreen;

    public void CallNextScreen(float hasteTime)
    {
        StartCoroutine(WaitAnimationTransition(hasteTime));
    }

    private IEnumerator WaitAnimationTransition(float hasteTime)
    {
        transitionTimeline.Play();
        //O "hasteTime" adianta a troca das telas antes da animação acabar
        yield return new WaitForSeconds((float)transitionTimeline.duration - hasteTime);
        nextScreen.SetActive(true);
        //Se tiver adiantar o tempo na espera anterior, se desconta esse tempo aqui. Assim a tela atual não desativa antes do término da animação
        yield return new WaitForSeconds(hasteTime);
        currentScreen.SetActive(false);
    }
}
