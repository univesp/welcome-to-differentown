using UnityEngine;
using UnityEngine.UI;

public class FontSizeSettings : MonoBehaviour {

    public FontSizeController fontSizeController;
    public Slider fontSizeSlider;

    //Inicia o slider na última posição deixada pelo jogador
    private void OnEnable()
    {
        fontSizeSlider.value = PlayerPrefs.GetInt("fontSize");
    }

    //Ao iniciar o script, ele seta o tamanho da fonte pra um tamanho inicial se ele for menor que o mínimo ou maior que o máximo e delega essa função ao slider
    private void Start()
    {
        InitialFontSize();
        fontSizeSlider.onValueChanged.AddListener(delegate { CallChangeFontSize(); });
    }

    private void CallChangeFontSize()
    {
        fontSizeController.ChangePlayerPref(fontSizeSlider.value);
    }
    
    private void InitialFontSize()
    {
        if (PlayerPrefs.GetInt("fontSize") < 124 || PlayerPrefs.GetInt("fontSize") > 164)
        {
            PlayerPrefs.SetInt("fontSize", 124);
        }
    }
}
