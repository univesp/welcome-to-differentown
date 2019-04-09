using UnityEngine;

//Esse script reseta o texto dos minigames quando eles são ativados
public class ResetObject : MonoBehaviour {

    private bool refresh;

    public GameObject objectToRefresh;

    private void Update()
    {
        if (!refresh)
        {
            objectToRefresh.SetActive(false);
            objectToRefresh.SetActive(true);
            refresh = true;
        }
    }
}
