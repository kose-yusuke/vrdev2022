using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalJudge2 : MonoBehaviour
{

    UIControl2 UIc;

    public AudioClip sound1;
    AudioSource audioSource;


    public GameObject FinishPanel;
    public GameObject NextPanel;
    public GameObject FinishLine;

    //public Material trans;

    void Start()
    {
        UIc = GameObject.Find("UIControl").GetComponent<UIControl2>();

        audioSource = GetComponent<AudioSource>();
        FinishPanel.SetActive(false);
        NextPanel.SetActive(false);
        FinishLine.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //オブジェクトの色を赤に変更する
            //GetComponent<Renderer>().material.color = Color.red;

            //goal bool値をtrueに
            UIc.goal = true;
            UIc.start = false;


            FinishPanel.SetActive(true);
            NextPanel.SetActive(true);
            FinishLine.SetActive(true);

            audioSource.PlayOneShot(sound1);

        }
    }
}