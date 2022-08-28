using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class GoalJudge : MonoBehaviour
{

    UIControl UIc;

    public AudioClip sound1;
    AudioSource audioSource;
    public GameObject FinishPanel;
    public GameObject NextPanel;
    public GameObject FinishLine;
    public GameObject Walking;
    public GameObject TexWalking;
    public GameObject FastRun;
    public GameObject TexFastRun;
    public GameObject OldMan;
    public GameObject TexOldMan;
    public GameObject Nothing;

    public GameObject SeniorPrimingEffect;

    public GameObject YouthPrimingEffect;
    //public Material trans;

    void Start()
    {
        UIc = GameObject.Find("UIControl").GetComponent<UIControl>();

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

            TexWalking.SetActive(false);
            TexFastRun.SetActive(false);
            TexOldMan.SetActive(false);
            Walking.SetActive(false);
            FastRun.SetActive(false);
            OldMan.SetActive(false);
            Nothing.SetActive(false);
            SeniorPrimingEffect.SetActive(false);
            YouthPrimingEffect.SetActive(false);

            audioSource.PlayOneShot(sound1);

        }
    }
}