using UnityEngine;
using UnityEngine.UI;

public class NextButtonInputField : MonoBehaviour {

    public InputField inputField;
    public GameObject nextButton;
    public Animator animator;

    public void CheckInputFieldLenght()
    {
        if(inputField.text.Length >= 3)
        {
            nextButton.SetActive(true);
            animator.Play("gameplay_proximo_entra");            
        }
        else
        {
            if (animator.gameObject.activeSelf)
            {
                animator.Play("gameplay_proximo_sai");
            }
        }
    }
}
