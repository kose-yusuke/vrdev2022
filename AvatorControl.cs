using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatorControl : MonoBehaviour
{

    public float bio_speed2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0,0,  bio_speed2 * Time.deltaTime);
        //gameObject.transform.localScale -= new Vector3(bio_speed,0, bio_speed);
    }
}
