using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Linq;
public class Manager : MonoBehaviour
{

    //Animator animator;

    public GameObject Walking;
    public GameObject TexWalking;
    public GameObject MyWalking;
    public GameObject ItoWalking;
    public GameObject OyanagiWalking;
    public GameObject KuritaWalking;
    public GameObject AoyamaWalking;
    public GameObject HayashiWalking;
    public GameObject AmemiyaWalking;

    public GameObject OldMan;
    public GameObject TexOldMan;
    public GameObject MyOldMan;
    public GameObject ItoOldMan;
    public GameObject OyanagiOldMan;
    public GameObject KuritaOldMan;
    public GameObject AoyamaOldMan;
    public GameObject HayashiOldMan;
    public GameObject AmemiyaOldMan;

    public GameObject Nothing;


/* 
    public GameObject FastRun;
    public GameObject TexFastRun;
    public GameObject MyFastRun;
    public GameObject SeniorPrimingEffect;
    public GameObject YouthPrimingEffect; */
    //public GameObject Patern;
    //private VideoPlayer[] VPs;

    //乱数、条件を格納する
    public List<int> conditions = new List<int>();
    int start = 1;
    int end = 7;  //組み合わせ回数分セットする
    public int index;
    public int ransu;

    //頭
    public GameObject head;

    //カウントダウン用
    public Text timerText;
    public float totalTime;
    int seconds;

    public float keika_time;//経過時間計測用
    public float progress_time;//処理時間計測用

    public float timeOut = 0.05f;//試行の間隔時間

    public int User_ID;
    public bool First= true;

    public Toggle Nothing_toggle;
    public Slider Nothing_slider;

    public float speed;
    public float interval = 5f;
    UIControl UIc;
    DataControl Datac;

    public Text ransutext;

    // Start is called before the first frame update
    void Start()
    {
        UIc = GameObject.Find("UIControl").GetComponent<UIControl>();
        Datac = GameObject.Find("DataControl").GetComponent<DataControl>();

        TexWalking.SetActive(false);
        TexOldMan.SetActive(false);
        Walking.SetActive(false);
        OldMan.SetActive(false);
        Nothing.SetActive(false);
        MyWalking.SetActive(false);
        ItoWalking.SetActive(false);
        OyanagiWalking.SetActive(false);
        KuritaWalking.SetActive(false);
        AoyamaWalking.SetActive(false);
        HayashiWalking.SetActive(false);
        AmemiyaWalking.SetActive(false);
        MyOldMan.SetActive(false);
        ItoOldMan.SetActive(false);
        OyanagiOldMan.SetActive(false);
        KuritaOldMan.SetActive(false);
        AoyamaOldMan.SetActive(false);
        HayashiOldMan.SetActive(false);
        AmemiyaOldMan.SetActive(false);

        User_ID = PlayerPrefs.HasKey("UserID") ? PlayerPrefs.GetInt("UserID") : 0;
        PlayerPrefs.SetInt("UserID", User_ID + 1);


        //もしベースラインを最初に取得するなら、先にconditionsに1を格納しておく
        for (int i = start; i <= end; i++)
        {
            conditions.Add(i); //通し番号が格納されたリストを用意
        }
        Debug.Log(string.Join(",",conditions.Select(n => n.ToString())));
        Debug.Log(conditions.Count);
        //最初だけ。後はUI Controlで更新している
        if (First == true)
        {
            if (conditions.Count > 0)
            {
                //indexは0―12
                index = Random.Range(0, conditions.Count);
                ransu = 1;

                Debug.Log("格納");
                Debug.Log(ransu);

                //conditions.RemoveAt(index);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (UIc.start == true) 
        {

            totalTime -= Time.deltaTime;
            seconds = (int)totalTime;
            timerText.text = seconds.ToString();

            keika_time += Time.deltaTime;

            if(seconds == 3)
            {
                ransutext.text = ransu.ToString();
                TexWalking.SetActive(false);
                TexOldMan.SetActive(false);
                Walking.SetActive(false);
                OldMan.SetActive(false);
                Nothing.SetActive(false);
                MyWalking.SetActive(false);
                ItoWalking.SetActive(false);
                OyanagiWalking.SetActive(false);
                KuritaWalking.SetActive(false);
                AoyamaWalking.SetActive(false);
                HayashiWalking.SetActive(false);
                MyOldMan.SetActive(false);
                ItoOldMan.SetActive(false);
                OyanagiOldMan.SetActive(false);
                KuritaOldMan.SetActive(false);
                AoyamaOldMan.SetActive(false);
                HayashiOldMan.SetActive(false);
                AmemiyaWalking.SetActive(false);
                AmemiyaOldMan.SetActive(false);
            }

            if (seconds == 2)
            {
                if (Nothing_slider.value<1f) 
                {
                    //オブジェクトが動き出す
                    Debug.Log(ransu);

                    if (ransu == 1)
                    {
                        Nothing.SetActive(true);      
                    }
                    if (ransu == 2)
                    {
                        Walking.SetActive(true);
                    }
                    else if (ransu == 3)
                    {
                        OldMan.SetActive(true);
                    }
                    else if (ransu == 4)
                    {
                        TexWalking.SetActive(true);
                    }
                    else if (ransu == 5)
                    {
                        TexOldMan.SetActive(true);
                    }
                    else if (ransu == 6)
                    {
                        MyWalking.SetActive(true);
                        //ItoWalking.SetActive(true);
                        //OyanagiWalking.SetActive(true);
                        //KuritaWalking.SetActive(true);
                        //AoyamaWalking.SetActive(true);
                        //HayashiWalking.SetActive(true);

                    }
                    else if (ransu == 7)
                    {
                        MyOldMan.SetActive(true);
                        
                        //ItoOldMan.SetActive(true);
                        //OyanagiOldMan.SetActive(true);
                        //KuritaOldMan.SetActive(true);
                        //AoyamaOldMan.SetActive(true);
                        //HayashiOldMan.SetActive(true);
                    }
                    /*
                    else if (ransu == 8)
                    {
                        MyWalking.SetActive(true);
                        //AmemiyaWalking.SetActive(true);
                    }
                    else if (ransu == 9)
                    {
                        MyOldMan.SetActive(true);
                        //AmemiyaOldMan.SetActive(true);
                    }
                    */
                    /*
                    else if (ransu == 11)
                    {
                        if (keika_time<interval)
                        {
                            YouthPrimingEffect.SetActive(true);
                        }
                    }
                    else if (ransu == 12)
                    {
                        TexWalking.SetActive(true);
                        if (keika_time<interval)
                        {
                            YouthPrimingEffect.SetActive(true);
                        }
                    }
                    else if (ransu == 13)
                    {
                        TexOldMan.SetActive(true);
                        if (keika_time<interval)
                        {
                            YouthPrimingEffect.SetActive(true);
                        }
                    }
                    */
                    /* else if (ransu == 14)
                    {
                        
                    }
                    else if (ransu == 15)
                    {
                        
                    }
                    */
                }
            }

            if (seconds == 0)
            {
                timerText.text = "GO!";
            }

            //カウントダウンを終えたら（ーになったら）文字を非表示
            if (seconds <= -1)
            {
                timerText.text = " ";
            }

            //カウントダウン開始後の経過時間
            progress_time += Time.deltaTime;

            //制限時間内の間計測
            if (progress_time >= timeOut)
            {
                Datac.Measure(User_ID.ToString(), keika_time.ToString(), head.transform.position.x.ToString(), head.transform.position.y.ToString(), head.transform.position.z.ToString(), head.transform.rotation.x.ToString(), head.transform.rotation.y.ToString(), head.transform.rotation.z.ToString(), ransu.ToString(), UIc.number.ToString());
                progress_time = 0.0f;
            }
        }
    }
}
