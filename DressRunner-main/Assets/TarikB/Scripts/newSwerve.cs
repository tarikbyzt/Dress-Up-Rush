using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSwerve : MonoBehaviour
{
    private Touch touch;
    [SerializeField]private float speedModifier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase==TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x *Time.deltaTime* speedModifier,transform.position.y,transform.position.z);
            }
        }
    }
}
