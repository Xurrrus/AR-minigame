using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    Vector3 wayPoint;
    public float distDeMoviment = 20f;

    public float valorCotxe;
    private bool pararCotxe = false;

    public AudioSource audioSource;
    public List<AudioClip> audiosHorn;

    void Start(){
        StartCoroutine(SonarAudio());
    }

    void Update()
    {
        if(!pararCotxe) Voltant();
    }

    void Voltant(){
        if(wayPoint == new Vector3(-100f, -100f, -100f)){
            wayPoint = TrobarPuntDinsNavMesh(new Vector3(-100f, -100f, -100f));
        }
        else{ 
            navMeshAgent.SetDestination(wayPoint);
            if(Vector3.Distance(wayPoint, transform.position) <= 1){
                wayPoint = new Vector3(-100f, -100f, -100f);
            }
        }
    }

    Vector3 TrobarPuntDinsNavMesh(Vector3 punt){
        if(punt == new Vector3(-100f, -100f, -100f)){
            punt = new Vector3(Random.Range(-distDeMoviment, distDeMoviment), 0f, Random.Range(-distDeMoviment, distDeMoviment));
        }

        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(punt, out hit, 10f, UnityEngine.AI.NavMesh.AllAreas);

        return hit.position;
    }

    public void pararUpdate()
    {
        pararCotxe = true;
    }

    IEnumerator SonarAudio()
    {
        float randomTime = Random.Range(3f, 8f);
        yield return new WaitForSeconds(randomTime);

        int randomAudio = (int)Random.Range(0, audiosHorn.Count);
        audioSource.clip = audiosHorn[randomAudio];
        audioSource.Play();
        StartCoroutine(SonarAudio());  
    }
}
