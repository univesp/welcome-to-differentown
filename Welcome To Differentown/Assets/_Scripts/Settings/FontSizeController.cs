using UnityEngine;
using UnityEngine.UI;

public class FontSizeController : MonoBehaviour {

    //Esse script vai em todos os textos que terão o tamanho ajustável pelas configurações
    private Text text;

    //Reinicia o tamanho da fonte se ele for menor que o mínimo ou maior que o máximo
    private void Start()
    {
        text = GetComponent<Text>();
        ApplyChange();

        if (text.fontSize < 124 || text.fontSize > 164)
        {
            text.fontSize = 124;
        }
    }

    //Atualiza o tamanho sempre que o texto se tornar visível
    private void OnEnable()
    {
        ApplyChange();
    }

    //Essa função é chamada pelo FontSizeSettings, pra definir o valor pelo slider
    public void ChangePlayerPref(float size)
    {
        PlayerPrefs.SetInt("fontSize", (int)size);
        ApplyChange();
    }

    public void ApplyChange()
    {
        if(text != null)
        {
            text.fontSize = PlayerPrefs.GetInt("fontSize");
        }
    }
}
