using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public float speed_value;
    public float pitch_value;//１秒に1回
    public float height_value;//身長
    public Slider speedSlider;
    public Text SpeedText;
    public Slider pitchSlider;
    public Text PitchText;


    //パネル
    public GameObject SettingPanel;
    public GameObject StartPanel;
    public GameObject PrimingPanel;
    public GameObject FinishPanel; 
    public GameObject NextPanel;
    public GameObject FinishLine;

    public GameObject Contents;

    public GameObject Walking;
    public GameObject TexWalking;
    public GameObject FastRun;
    public GameObject TexFastRun;
    public GameObject OldMan;
    public GameObject TexOldMan;
    public GameObject Nothing;

    public GameObject SeniorPrimingEffect;

    public GameObject YouthPrimingEffect;

    public Slider num_slider;
    public Text numText;

    public Text DebugText;

    //スタート・ゴール判定(時間の計測に活用)
    public bool start = false;
    public bool goal = false;

    //public static bool first =true;
    public int number = 1;//試行回数カウント用

    //頭
    public GameObject head;

    bool isCalledOnce = false;

    Manager manager;
    DataControl Datac;

    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<Manager>();
        Datac = GameObject.Find("DataControl").GetComponent<DataControl>();
        StartPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //finishpanelの進捗メータ用
        numText.text = number.ToString();
        num_slider.value = number;


        speed_value = speedSlider.value * 0.01f;
        pitch_value = pitchSlider.value*0.01f;
        SpeedText.text = (speedSlider.value * 0.01f).ToString();
        PitchText.text = (pitchSlider.value * 0.01f).ToString();


        if (number == 18) 
        {
            numText.text = "これにて終了です。お疲れさまでした。";
        }

        if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch))
        {
            FinishPanel.SetActive(true);
            NextPanel.SetActive(true);
        }
    }
    public void OnChoice()
    {

        SettingPanel.SetActive(false);
        //head.transform.position = new Vector3(0, height_value * 0.9f, 0);//頭の初期位置
        StartPanel.SetActive(true);

    }
    public void OnStart()
    {
        start = true;
        StartPanel.SetActive(false);
    }

    public void OnFinish()
    {
        goal = false;
        manager.First = false;
        number += 1;

        if(manager.conditions.Count > 0 &&  number>4 && number % 2 ==1)
        {
            manager.index = Random.Range(0, manager.conditions.Count);
            manager.ransu = manager.conditions[manager.index];

            Debug.Log("格納");
            DebugText.text="格納";

            manager.conditions.RemoveAt(manager.index);
        }

        StartPanel.SetActive(true);
        FinishPanel.SetActive(false);
        FinishLine.SetActive(false);
        NextPanel.SetActive(false);
        
        Vector3 pos = head.transform.position;

        if (number % 2 == 0)
        {
            Contents.transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 1, 0));

        }
        if (number % 2 == 1)
        {
            Contents.transform.rotation = Quaternion.AngleAxis(360, new Vector3(0, 1, 0));
        }

        Contents.transform.position = pos;
        Vector3 Cpos = Contents.transform.position;
        Cpos.x = pos.x;
        Cpos.z = pos.z;
        Cpos.y = 0f;
        Contents.transform.position = Cpos;

        //manager.Patern.transform.localPosition = new Vector3(0, 0, 0);
        //manager.Patern.SetActive(false);

        //時間リセット
        manager.totalTime = 4;
        manager.keika_time = 0;

        Datac.SWfirst = true;
    }
}

