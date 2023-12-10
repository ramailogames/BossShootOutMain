using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    [SerializeField] Transform spawnPos;
    [SerializeField] TextMeshProUGUI countDownTxt;

    [SerializeField]int currentIndex = 0;
    private void Start()
    {
        StartCoroutine(SpawnEnum());
    }

    public void Spawn()
    {
        switch (currentIndex)
        {
            case 0:
                Instantiate(enemy[0], spawnPos.position, Quaternion.identity);
                currentIndex = 1;
                break;

            case 1:
                Instantiate(enemy[1], spawnPos.position, Quaternion.identity);
                currentIndex = 2;
                break;

            case 2:
                Instantiate(enemy[2], spawnPos.position, Quaternion.identity);
                currentIndex = 0;
                break;

        }

       
    }

    public void EnumSpawn()
    {
        StartCoroutine(SpawnEnumAgain());
    }
    
    IEnumerator SpawnEnum()
    {
        countDownTxt.gameObject.SetActive(true);
        countDownTxt.text = "Ready";
        yield return new WaitForSeconds(1f);
        AudioManagerCS.instance.Play("3");
        countDownTxt.text = "3";
        yield return new WaitForSeconds(.8f);
        AudioManagerCS.instance.Play("2");
        countDownTxt.text = "2";
        yield return new WaitForSeconds(.8f);
        AudioManagerCS.instance.Play("1");
        countDownTxt.text = "1";
        yield return new WaitForSeconds(.8f);
        AudioManagerCS.instance.Play("go");
        countDownTxt.text = "Go...";
        yield return new WaitForSeconds(.8f);
        countDownTxt.gameObject.SetActive(false);

        Spawn();

        
    }


    IEnumerator SpawnEnumAgain()
    {
        countDownTxt.gameObject.SetActive(true);
        countDownTxt.text = "Nice...";
        yield return new WaitForSeconds(1f);
        countDownTxt.text = "Ready..";
        yield return new WaitForSeconds(1f);
        AudioManagerCS.instance.Play("3");
        countDownTxt.text = "3";
        yield return new WaitForSeconds(.8f);
        AudioManagerCS.instance.Play("2");
        countDownTxt.text = "2";
        yield return new WaitForSeconds(.8f);
        AudioManagerCS.instance.Play("1");
        countDownTxt.text = "1";
        yield return new WaitForSeconds(.8f);
        AudioManagerCS.instance.Play("go");
        countDownTxt.text = "Go...";
        yield return new WaitForSeconds(.8f);
        countDownTxt.gameObject.SetActive(false);

        Spawn();


    }


}
