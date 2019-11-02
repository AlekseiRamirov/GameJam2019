using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatMain : MonoBehaviour
{

    public float speed = 0.0125f, startX, startY;
    public LayerMask stopper;


    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
            if (transform.position.x == startX && transform.position.y == startY
            /*Physics.CheckBox(new Vector3(transform.position.x,transform.position.y,transform.position.z), new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z), new Quaternion(), stopper)*/)
                speed *= -1;

           // if (Physics.CheckBox(GetComponent<BoxCollider>().center, GetComponent<BoxCollider>().size / 2))
                transform.position += new Vector3(speed, 0, 0);
        
    }

    void OnCollisionEnter(Collision col)
    {
        foreach (ContactPoint contact in col.contacts)
        {
            speed *= -1;
        }
    }
}
