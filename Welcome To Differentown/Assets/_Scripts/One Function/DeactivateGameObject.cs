using UnityEngine;

public class DeactivateGameObject : MonoBehaviour {

    public GameObject[] buttons;

    private void OnDisable()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
    }
}
