using System.Collections;
using UnityEngine;

//Esse script chama a animação de sair da tela de transição quando a cena começa
public class StarterAnimation : MonoBehaviour {

    public Animator animator;
    public bool isEnd;

    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("ScreenTransition").GetComponent<Animator>();
        if (isEnd)
        {
            StartCoroutine(WaitToStart());
        }
        else
        {
            animator.Play("transicao_tela_sai");
        }
    }

    private IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(1.0f);
        animator.Play("transicao_tela_sai");
    }
}
