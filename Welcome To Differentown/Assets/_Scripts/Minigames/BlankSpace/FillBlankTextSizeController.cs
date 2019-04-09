using UnityEngine;
using UnityEngine.UI;

//Esse script regula o tamanho do colisor que recebe as palavras de acordo com o tamanho da fonte do texto
public class FillBlankTextSizeController : MonoBehaviour {
    
    private float currentScale;
    private float minScale = 1;

    public Text currentFontSize;
    private float minFontSize = 124;

    public GameObject colliderObject;

    private void OnEnable()
    {
        /*Eu sempre chego nessa fórmula usando regra de três, onde:
         currentScale = currentFontSize
         minScale     =     minFontSize
         */
        currentScale = (minScale * currentFontSize.fontSize) / minFontSize;
        //Atualiza o tamanho do colisor
        colliderObject.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
