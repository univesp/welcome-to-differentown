using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//Esse script chama o teclado virtual quando o inputfield está selecionado
public class CallVirtualKeyboard : MonoBehaviour {

    public InputField inputField;
    public UnityEvent action;

    private bool called;

    private void Update()
    {
        if(inputField.isFocused && !called)
        {
            called = true;
            action.Invoke();
        }
    }

    public void SetCalled(bool currentState)
    {
        called = currentState;
    }
}
