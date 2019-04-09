using UnityEngine;
using UnityEngine.UI;

//Esse script gerencia as ações do teclado no menu de opções
public class KeyboardMenu : MonoBehaviour{

    public Selectable[] selectableObject;
    public Scrollbar scrollbar;

    public int index = 0;
    private bool isSelected;

    private void Update()
    {
        if (!OptionsState.instance.isInOptionsScreen)
        {
            if (scrollbar.isActiveAndEnabled && Input.GetKeyDown(KeyCode.Tab))
            {
                if (index == 0)
                {
                    selectableObject[0].OnDeselect(null);
                    selectableObject[1].Select();
                    index = 1;
                }
                else
                {
                    selectableObject[0].Select();
                    selectableObject[1].OnDeselect(null);
                    index = 0;
                }
            }
        }
    }
}
