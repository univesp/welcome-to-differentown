using UnityEngine;
using UnityEngine.UI;

//Esse script define qyaus botões de opção o botão de opção atual vai pressionar
public class CurrentOptionsController : MonoBehaviour {
    
    public OptionActionController[] optionsAction;
    public Button[] button;
    public Text[] buttonText;

    //Isso é chamado pelo dialogue controller
    #region Set Current Options
    public void SetCurrentOption1(OptionActionController currentOptionAction)
    {
        optionsAction[0] = currentOptionAction;
    }

    public void SetCurrentOption2(OptionActionController currentOptionAction)
    {
        optionsAction[1] = currentOptionAction;
    }

    public void SetCurrentOption3(OptionActionController currentOptionAction)
    {
        optionsAction[2] = currentOptionAction;
    }
    #endregion

    //Isso é chamado pelo dialogue controller
    public void SetOptionsText()
    {
        for(int i = 0; i < 3; i++)
        {
            if (optionsAction[i] != null)
            {
                buttonText[i].text = optionsAction[i].optionText;
                button[i].gameObject.transform.parent.gameObject.SetActive(true);
            }
            else
            {
                break;
            }
        }        
    }

    #region METHODS THE OPTIONS BUTTONS WILL CALL WHEN PRESSED
    public void PressButton1()
    {
        optionsAction[0].CallOptionAction();
    }

    public void PressButton2()
    {
        optionsAction[1].CallOptionAction();
    }

    public void PressButton3()
    {
        optionsAction[2].CallOptionAction();
    }
    #endregion

    public void DisableButtons()
    {
        for(int i = 0; i < 3; i++)
        {
            if(optionsAction[i] != null)
            {
                optionsAction[i] = null;
                button[i].gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
