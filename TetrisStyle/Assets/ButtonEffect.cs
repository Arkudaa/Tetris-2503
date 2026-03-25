using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private Vector3 normalScale;
    private Vector3 targetScale;

    public float hoverScale;
    public float pressedScale;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        normalScale = transform.localScale;
        targetScale = normalScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * speed);
    }



    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = normalScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = normalScale;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        targetScale = normalScale * pressedScale;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        targetScale = normalScale * hoverScale; 
    }


}
