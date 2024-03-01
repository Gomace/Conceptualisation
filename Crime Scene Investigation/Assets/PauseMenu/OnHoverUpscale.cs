using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverUpscale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 OriginalScale;
    private Vector3 ChangedScale;
    public bool isHover;
    public void Awake()
    {
        ChangedScale = new Vector3(1.2f, 1.2f, 1f);
        OriginalScale = new Vector3(1f, 1f, 1f);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = ChangedScale;
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = OriginalScale;
        isHover = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown("escape") && isHover == false)
        {
            transform.localScale = OriginalScale;
        }
    }
}