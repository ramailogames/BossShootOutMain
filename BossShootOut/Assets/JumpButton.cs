using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    PlayerMovement movement;
    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        movement.Jump();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      
    }
}
