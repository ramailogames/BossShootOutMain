using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour
{
    [SerializeField] Transform enemyHead;

  
    private void UpdatePosition()
    {
        transform.position = enemyHead.position;
    }
    private void FixedUpdate()
    {
        UpdatePosition();
    }
}
