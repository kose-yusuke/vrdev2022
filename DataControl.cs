using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//データを計測し、csvに出力するための諸々の設定
public class DataControl : MonoBehaviour
{

    private StreamWriter sw;

    public string LogFilenamePrefix = "log_";
    public string ResultFilenamePrefix = "result_";

    public string Extension = ".csv";

    UIControl UIc;
    Manager manager;

    public string baseFilePath;
    public string filePath;
    string FilePath;

    public Text Pathtext;

    public int Number;

    public bool SWfirst=true;

    public string CreateFileName = DateTime.Now.ToString("yyMMdd-HHmmss") + ".csv";

    // Start is called before the first frame update
    void Start()
    {
        UIc = GameObject.Find("UIControl").GetComponent<UIControl>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SWfirst == true) 
        {
            SWfirst = false;
            filePath = Path.Combine(Application.persistentDataPath, CreateFileName);

            sw = new StreamWriter(filePath, true, Encoding.UTF8);

            string[] s1 = { "UserID", "time", "posx", "posy", "posz", "rotx", "roty", "rotz", "Condition", "Number" };
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
        }

        //Pathtext.text = File.Exists("/storage/emulated/0/Android/data/com.DefaultCompany.New Unity Project (2)/files/result_200210-175315.csv").ToString();
        //Pathtext.text = File.Exists("/sdcard/Android/data/com.DefaultCompany.GaitVR/files/result_200210-175315.csv").ToString();


        if (UIc.goal == true) {

            sw.Close();
            Debug.Log("終了!!");

        }
    }

    public void OnSWClose() {
        sw.Close();
    }

    public void Measure(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9, string txt10) 
    {
        string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10 };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        //sw.Flush();

    }


}
