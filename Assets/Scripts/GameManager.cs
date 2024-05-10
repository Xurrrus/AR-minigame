using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float puntsActuals;
    public float maxPunts = 100f;

    public TMP_Text textPunts;
    public GameObject[] cotxesSpawnejables;
    public Transform spawnManagerPare;

    private int interval = 3;
    public float rangSpawn = 15;

    public AudioSource audioCoins;

    void Start()
    {
        puntsActuals = 0f;
        InvokeRepeating("InstanciarModel", 5f, 15);
    }

    void Update()
    {
        if(Time.frameCount % interval == 0){
            if(puntsActuals < maxPunts)
            {
                textPunts.text = puntsActuals + "/" + maxPunts;
            }
            else 
            { 
                textPunts.text = "HAS GUANYAT!";
                GameObject[] llistatCotxes = GameObject.FindGameObjectsWithTag("Vehicle");
                CancelInvoke("InstanciarModel");
                for (int i = 0; i < llistatCotxes.Length; i++)
                {
                    llistatCotxes[i].GetComponent<CarController>().pararUpdate();
                }
                enabled = false;
            }
        }
    }

    public void InstanciarModel()
    {
        int randomNumero = Random.Range(0, 5);
        Vector3 randomPos = new Vector3(Random.Range(-rangSpawn, rangSpawn), 0f, Random.Range(-rangSpawn, rangSpawn));
        Instantiate(cotxesSpawnejables[randomNumero], randomPos, Quaternion.identity, spawnManagerPare);
    }

    public void sumarPunts(float punts){
        audioCoins.Play();
        puntsActuals += punts;
    }
}
