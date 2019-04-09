using UnityEngine;
using UnityEngine.UI;
public class ScrollFix : MonoBehaviour {

    //Esse script força o tamanho do scrollbar para o handle customizado ficar na posição correta
    public Scrollbar sb;

    void Start()
    {
        sb.value = 1;
        sb.size = 0;
    }

    void Update()
    {
        sb.size = 0;
    }
}
