using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TheThing : MonoBehaviour
{
    public GameObject thing;

    public Vector3 currentEulerAngles;
    public Quaternion currentRotation;
    public Transform End;

    void Update()
    {
        LookRotation();
        transform.position = Vector3.MoveTowards(this.transform.position, End.position, 7.5f * Time.deltaTime);
    }

    //IT CONSUMES THE HALLS ! ! ! !
    void LookRotation()
    {
        Vector3 relativePos = End.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }

    //UH OH YOU DIED
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("THE THING CONSUMES YOU");
            Application.Quit();
        }
    } 
}
