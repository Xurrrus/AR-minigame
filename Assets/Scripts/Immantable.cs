using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immantable : MonoBehaviour
{
    

    void OnTriggerEnter(Collider coll){
        if(coll.CompareTag("Imant")){
            GetComponent<UnityEngine.AI.NavMeshAgent>().Stop();
            GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
            GetComponent<CarController>().enabled = false;
            
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            transform.position = coll.transform.position;
            transform.parent = coll.transform;
            Debug.Log("Imantat");

            float vCotxe = gameObject.GetComponent<CarController>().valorCotxe;
            GameManager gameManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
            gameManager.sumarPunts(vCotxe);

            Debug.Log("Imantat");

            StartCoroutine(DeleteCotxe());
        }
    }

    IEnumerator DeleteCotxe()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);        
    }
}
