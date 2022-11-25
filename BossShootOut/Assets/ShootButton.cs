using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    PlayerMovement movement;
    void Start()
    {
        movement = FindObjectOfType<PlayerMovement>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // gameControl.x = -1;
        // movement.movementInputDirection = -1;
        movement.Shoot();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // gameControl.x = 0;
       // movement.movementInputDirection = 0;

    }
}
