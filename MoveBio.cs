using UnityEngine;

public class MoveBio : MonoBehaviour
{
    //public float bio_speed;
    public float bio_speed2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(0, -1* bio_speed2 * Time.deltaTime,0);
        //gameObject.transform.localScale -= new Vector3(bio_speed,0, bio_speed);
    }
}
