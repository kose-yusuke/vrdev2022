using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Manager2 : MonoBehaviour
{
    public GameObject _Bio_wall2;//０倍条件
    public GameObject _Scramble_wall2;
    public GameObject _Avator_wall2;
    public GameObject _Nothing;

    public GameObject Patern;
    private VideoPlayer[] VPs;

    //乱数、条件を格納する
    public List<int> conditions = new List<int>();
    int start = 1;
    int end = 18;
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
    public bool First = true;

  
    public Slider Nothing_slider;

    //モード格納変数
    public int mode = 0;//パターン
    public int Pmode = 0;//ピッチ

    UIControl2 UIc;
    DataControl2 Datac;

    public Text ransutext;

    // Start is called before the first frame update
    void Start()
    {
        UIc = GameObject.Find("UIControl").GetComponent<UIControl2>();
        Datac = GameObject.Find("DataControl").GetComponent<DataControl2>();

        _Avator_wall2.SetActive(false);
        _Bio_wall2.SetActive(false);
        _Scramble_wall2.SetActive(false);

        User_ID = PlayerPrefs.HasKey("UserID") ? PlayerPrefs.GetInt("UserID") : 0;
        PlayerPrefs.SetInt("UserID", User_ID + 1);

        //First = UIControl.getFirst();
        //if (First == true)
        //{
        //    for (int i = start; i <= end; i++)
        //    {
        //        conditions.Add(i); //通し番号が格納されたリストを用意
        //    }
        //}


        for (int i = start; i <= end; i++)
        {
            conditions.Add(i); //通し番号が格納されたリストを用意
        }

        if (First == true)
        {
            if (conditions.Count > 0)
            {
                index = Random.Range(0, conditions.Count);
                ransu = conditions[index];

                Debug.Log("格納");

                conditions.RemoveAt(index);
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


            if (seconds == 1)
            {

                Patern = _Nothing;

                if (Nothing_slider.value < 1f)
                {
                    //オブジェクトが動き出す
                    Debug.Log(ransu);
                    ransutext.text = ransu.ToString();

                    if (ransu == 1 || ransu == 10)
                    {
                        Patern = _Bio_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = 1.3f * UIc.speed_value;//移動1.3倍
                        Patern.SetActive(true);
                    }
                    else if (ransu == 2 || ransu == 11)
                    {
                        Patern = _Bio_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = UIc.speed_value;//移動1倍
                        Patern.SetActive(true);
                    }
                    else if (ransu == 3 || ransu == 12)
                    {
                        Patern = _Bio_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = 0.7f * UIc.speed_value;//移動0.7倍
                        Patern.SetActive(true);
                    }
                    else if (ransu == 4 || ransu == 13)
                    {
                        Patern = _Scramble_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = 1.3f * UIc.speed_value;//移動1.3倍
                        Patern.SetActive(true);
                    }
                    else if (ransu == 5 || ransu == 14)
                    {
                        Patern = _Scramble_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed =  UIc.speed_value;
                        Patern.SetActive(true);
                    }
                    else if (ransu == 6 || ransu == 15)
                    {
                        Patern = _Scramble_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = 0.7f * UIc.speed_value;
                        Patern.SetActive(true);
                    }
                    else if (ransu == 7 || ransu == 16)
                    {
                        Patern = _Avator_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = 1.3f * UIc.speed_value;//移動1.3倍
                        Patern.SetActive(true);
                    }
                    else if (ransu == 8 || ransu == 17)
                    {
                        Patern = _Avator_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = UIc.speed_value;
                        Patern.SetActive(true);
                    }
                    else if (ransu == 9 || ransu == 18)
                    {
                        Patern = _Avator_wall2;
                        Patern.GetComponent<BioMoveWall>().bio_speed = 0.7f * UIc.speed_value;
                        Patern.SetActive(true);
                    }
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

    //public static List<int> getConditions()
    //{
    //    return conditions;
    //}
}
