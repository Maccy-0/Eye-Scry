using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverConfirm : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button buttonToPress;
    public GameObject myTarget;
    public Slider mySlider;

    [SerializeField]
    private bool isHovered = false;
    public float secondsToConfirm = 2f;

    [SerializeField]
    private float timer;

    public Sprite targetImage;
    private CircleCollider2D myCollider;
    public bool offToggle = false;

    private void Start()
    {
        if (this.gameObject.GetComponent<CircleCollider2D>() != null)
        {
            myCollider = this.gameObject.GetComponent<CircleCollider2D>();
        }
    }

    private void Update()
    {
        if (isHovered)
        {
            timer += Time.deltaTime;
            if(timer >= secondsToConfirm)
            {
                isHovered = false;
                timer = 0;

                ClickButton();
            }

            mySlider.value = timer / secondsToConfirm;

        }
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        timer = 0;
        if (mySlider != null)
        {
         mySlider.value = 0;
        }
        
    }

    public void ClickButton()
    {
        buttonToPress.onClick.Invoke();
        if (offToggle)
        {
          TargetToggle();
        }
        
        //myTarget.SetActive(false);
    }

    public void TargetToggle()
    {
        if (myTarget.activeSelf)
        {
            myTarget.SetActive(false);
        }
        else if (!myTarget.activeSelf)
        {
            myTarget.SetActive(true);
        }
    }

}
