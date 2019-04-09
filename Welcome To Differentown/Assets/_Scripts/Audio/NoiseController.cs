using UnityEngine;

//Esse script diminui e aumenta o som de fundo. Ele é colocado no objeto da caixa de texto do diálogo
public class NoiseController : MonoBehaviour {

    public AudioSource audioSource;
    private bool isActive;

    private void OnEnable()
    {
        isActive = true;
    }

    private void OnDisable()
    {
        if (audioSource != null)
        {
            audioSource.volume = 0.7f;
        }
    }

    private void Update()
    {
        if (isActive)
        {
            if (audioSource.volume >= 0.3)
            {
                audioSource.volume -= Time.deltaTime / 2;
            }
            else
            {
                isActive = false;
            }
        }
    }
}
