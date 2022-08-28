using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_primingUIControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject StartPanel;

    public GameObject PrimingPanel;

    public float timer = 1f;
    void Start()
    {
        PrimingPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (StartPanel.activeSelf == false){
            Destroy(PrimingPanel,timer);
        }
    }
}
