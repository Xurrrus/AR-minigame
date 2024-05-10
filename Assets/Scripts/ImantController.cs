using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImantController : MonoBehaviour
{
    public Transform posAvall;
    Vector3 initialPos;
    public bool avall = false;
    public float velocitat = 2f;
    public float valorDeAcc = 0.25f;
    Vector3 acceleracio;
    bool estemPosInicial = true;
    public bool testing = false;
    public TMP_Text accelerationText;

    void Start(){
        initialPos = transform.position;
    }

    void Update(){
        //acceleracio = Input.acceleration;
        acceleracio.x = -Input.acceleration.y;
        acceleracio.z = Input.acceleration.x;

        accelerationText.text = acceleracio.sqrMagnitude.ToString();

        //ComprovarClick();
        ComprovarAccelerometre();
        MoureImant();
    }

    void ComprovarClick(){
        if(Input.GetMouseButton(0) || Input.touchCount > 0){
            avall = true;
        }
        else{
            avall = false;
        }
    }

    void MoureImant(){
        if(avall){
            estemPosInicial = false;
            Vector3 dir = posAvall.position - transform.position;
            if(Vector3.Distance(transform.position, posAvall.position) >= 0.5f){
                transform.Translate(dir * velocitat * Time.deltaTime, Space.World);
            }
            else avall = false;
        }
        else{
            Vector3 dir = initialPos - transform.position;
            if(Vector3.Distance(transform.position, initialPos) >= 0.5f){
                transform.Translate(dir * velocitat * Time.deltaTime, Space.World);
            }
            else estemPosInicial = true;
        }
    }

    void ComprovarAccelerometre(){
        if(acceleracio.sqrMagnitude < valorDeAcc || (testing && (Input.GetMouseButton(0) || Input.touchCount > 0))){
            if(estemPosInicial) avall = true;
        }
        //else avall = false;
    }    
}
