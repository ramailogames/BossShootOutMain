using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheme : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManagerCS.instance.Play("theme");
    }

   
}
