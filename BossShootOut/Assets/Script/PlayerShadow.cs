using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    [SerializeField] Transform followThis;

  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.Lerp(transform.position, followThis.position, Time.deltaTime));
    }
}
