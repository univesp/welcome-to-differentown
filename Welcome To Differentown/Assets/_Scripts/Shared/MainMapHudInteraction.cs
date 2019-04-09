using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Esse script gerencia as animações do mapa geral
public class MainMapHudInteraction : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject information;
    public Animator animator;
    public ScreenTransition screenTransition;
    public GameObject screenTransitionImage;

    private Button button;
    private bool clickedOnce;
    private bool isIn;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClickEvent);
    }
    
    private void ClickEvent()
    {
        if(!clickedOnce)
        {
            clickedOnce = true;
            information.SetActive(true);
            animator.SetFloat("Direction", 1.0f);
            animator.Play("Show Up");
        }
        else
        {
            screenTransition.CallHalfTransition();
            screenTransitionImage.SetActive(true);
            clickedOnce = false;
        }
    }
    
    private void Update()
    {
        if(animator.isActiveAndEnabled)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Off Screen"))
            {
                information.SetActive(false);
            }
        }

        if(isIn)
        {
            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                AudioPlayerController.instance.PlaySFX_MouseClick();
            }
        }       
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetFloat("Direction", -1.0f);
                animator.Play("Show Up", -1, float.NegativeInfinity);
                button.OnDeselect(null);
                clickedOnce = false;
            }
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        AudioPlayerController.instance.PlaySFX_MouseOver();
        isIn = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {        
        isIn = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioPlayerController.instance.PlaySFX_MouseOver();
        isIn = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isIn = false;
    }
}
