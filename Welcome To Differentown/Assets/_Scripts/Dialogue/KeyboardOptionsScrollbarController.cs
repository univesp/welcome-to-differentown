using UnityEngine;
using UnityEngine.UI;

//Esse script gerencia as ações do teclado quando no diálogo tiver opções para escolher
public class KeyboardOptionsScrollbarController : MonoBehaviour {

    public Button[] button;
    public Scrollbar[] optionScrollbar;
    public Scrollbar textScrollbar;

    private int index;
    private int instance;

    private void OnEnable()
    {
        index = -1;
        instance = 0;
    }

    private void Update()
    {
        if (!OptionsState.instance.isInOptionsScreen)
        {
            ChangeInstance();
        }
    }

    private void ChangeInstance()
    {
        if(instance == 0)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                index--;
                if(index < 0)
                {
                    index = 2;
                }
            }

            if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                index++;
                if(index > 2)
                {
                    index = 0;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.Tab) && index >= 0)
        {
            switch(instance)
            {
                case 0:
                    if (optionScrollbar[index].isActiveAndEnabled)
                    {
                        instance = 1;
                        button[index].OnDeselect(null);
                        optionScrollbar[index].Select();
                    }else if(textScrollbar.isActiveAndEnabled)
                    {
                        instance = 2;
                        button[index].OnDeselect(null);
                        textScrollbar.Select();
                    }
                    break;

                case 1:
                    optionScrollbar[index].OnDeselect(null);
                    if(textScrollbar.isActiveAndEnabled)
                    {
                        instance = 2;
                        textScrollbar.Select();
                    }
                    else
                    {
                        instance = 0;
                        button[index].Select();
                    }
                    break;

                case 2:
                    instance = 0;
                    textScrollbar.OnDeselect(null);
                    button[index].Select();
                    break;
            }
        }
    }
}
