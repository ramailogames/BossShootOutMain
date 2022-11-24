using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnPos;
    [SerializeField] TextMeshProUGUI countDownTxt;


    private void Start()
    {
        StartCoroutine(SpawnEnum());
    }
    public void Spawn()
    {
        Instantiate(enemy, spawnPos.position, Quaternion.identity);
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
        countDownTxt.text = "3";
        yield return new WaitForSeconds(.8f);
        countDownTxt.text = "2";
        yield return new WaitForSeconds(.8f);
        countDownTxt.text = "1";
        yield return new WaitForSeconds(.8f);
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
        countDownTxt.text = "3";
        yield return new WaitForSeconds(.8f);
        countDownTxt.text = "2";
        yield return new WaitForSeconds(.8f);
        countDownTxt.text = "1";
        yield return new WaitForSeconds(.8f);
        countDownTxt.text = "Go...";
        yield return new WaitForSeconds(.8f);
        countDownTxt.gameObject.SetActive(false);

        Spawn();


    }


}
