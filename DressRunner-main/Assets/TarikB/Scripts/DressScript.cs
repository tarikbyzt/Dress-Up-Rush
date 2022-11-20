using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressScript : MonoBehaviour
{
    private GameObject dressBlue;
    private GameObject dressRed;
    private GameObject dressGreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GateGreen")
        {

            Debug.Log("yeþilkapý");
            dressBlue.name = "Enemy";
            dressRed.name = "Enemy";
        }

    }
}
