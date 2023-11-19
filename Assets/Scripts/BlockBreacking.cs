using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockBreacking : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Animator anim;

    public void OnPointerDown(PointerEventData eventData)
    {
        anim.SetBool("playBreack", true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        anim.SetBool("playBreack", false);
    }
}