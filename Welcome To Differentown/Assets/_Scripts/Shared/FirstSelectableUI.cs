using UnityEngine;
using UnityEngine.UI;

public class FirstSelectableUI : MonoBehaviour {

    public Selectable selectable;
    
    //Seleciona a UI assim que ela se torna ativa
    private void OnEnable()
    {
        selectable.Select();
    }
}
