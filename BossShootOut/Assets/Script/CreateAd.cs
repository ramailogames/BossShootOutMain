using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAd : MonoBehaviour
{
    private void OnEnable()
    {
        FindObjectOfType<JsFuncManager>().CreateAd();
        FindObjectOfType<JsFuncManager>().CreateAd();
    }

    private void Start()
    {
        Invoke("CreateAd_", 1f);
    }

    void CreateAd_()
    {
        FindObjectOfType<JsFuncManager>().CreateAd();
        FindObjectOfType<JsFuncManager>().CreateAd();
    }
}
