using UnityEngine;
using UnityEngine.UI;

public class KeyboardNavigation : MonoBehaviour {

    public Selectable[] selectableObject;

    private int index = -1;
    private int auxQtd;
    private bool keyboardIsActive;

    //Quando o script começa, ele pega referência da atividade da janela de opções. Esse script não funciona enquanto a janela de opções estiver ativa
    private void Start()
    {
        keyboardIsActive = true;        
    }

    private void Update()
    {
        ChangeSelectableSelected();
    }

    public void SetActive(bool currentState)
    {
        keyboardIsActive = currentState;
    }

    //Muda a seleção entre os elementos ativos no array
    private void ChangeSelectableSelected()
    {
        if (keyboardIsActive && !OptionsState.instance.isInOptionsScreen && Input.GetKeyDown(KeyCode.Tab) && CheckActiveSelectables())
        {
            index++;
            
            if(index >= selectableObject.Length)
            {
                index = 0;
            }

            //Recursão para pular o elemento inativo. Se for ativo, o elemento é selecionado
            if(!selectableObject[index].isActiveAndEnabled || !selectableObject[index].interactable)
            {
                ChangeSelectableSelected();
            }
            else
            {
                selectableObject[index].Select();
            }
        }        
    }

    //Checa o array de selecionáveis e retorna verdadeiro se houver algum ativo
    private bool CheckActiveSelectables()
    {
        foreach(Selectable selectable in selectableObject)
        {
            if(selectable.isActiveAndEnabled)
            {
                return true;
            }
        }
        return false;
    }
}