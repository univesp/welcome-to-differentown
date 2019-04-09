using UnityEngine;
using UnityEngine.UI;

public class InputFieldManualInput : MonoBehaviour {

    public InputField inputField;

    public void AddLetter(string newLetter)
    {
        inputField.text = inputField.text + newLetter;
    }

    public void RemoveLetter()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Remove(inputField.text.Length - 1);
        }
    }
}
