using System.Collections;
using UnityEngine;
using UnityEngine.Events;

//Esse script chama a transição de tela e executa as ações antes da tela tornar a ficar visível
public class ScreenTransition : MonoBehaviour {

    public UnityEvent action;
    public Animator animator;

    public void CallTransition()
    {
        StartCoroutine(CallAction(0.8f));
    }

    public void CallTransitionWithDelay(float delayTime)
    {
        StartCoroutine(CallAction(delayTime));
    }

    public void CallHalfTransition()
    {
        StartCoroutine(CallHalfAction(0.8f));
    }

    private IEnumerator CallAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        action.Invoke();
        animator.Play("transicao_tela_sai");
    }

    private IEnumerator CallHalfAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        action.Invoke();
    }
}
