using UnityEngine;

public class BioMoveWall : MonoBehaviour
{
    //public float bio_speed;
    public float bio_speed;
    //public float speed_value;


    // Start is called before the first frame update
    void Start()
    {
        //bio_speed = speed_value;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate( 0,0, bio_speed * Time.deltaTime);
        //gameObject.transform.localScale -= new Vector3(bio_speed,0, bio_speed);
    }

}
