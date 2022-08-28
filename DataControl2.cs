using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//データを計測し、csvに出力するための諸々の設定
public class DataControl2 : MonoBehaviour
{

    private StreamWriter sw;

    public string LogFilenamePrefix = "log_";
    public string ResultFilenamePrefix = "result_";

    public string Extension = ".csv";

    UIControl2 UIc;
    Manager2 manager;

    public string baseFilePath;
    public string filePath;
    string FilePath;

    public Text Pathtext;

    public int Number;

    public bool SWfirst = true;

    // Start is called before the first frame update
    void Start()
    {
        UIc = GameObject.Find("UIControl").GetComponent<UIControl2>();
        manager = GameObject.Find("Manager").GetComponent<Manager2>();

        //filePath = Path.Combine("/sdcard/Android/data/com.DefaultCompany.GaitVR/files", CreateFileName(ResultFilenamePrefix));


        //sw = new StreamWriter(filePath, true, Encoding.GetEncoding("Shift_JIS"));


        //filePath = Path.Combine(Application.persistentDataPath, CreateFileName(ResultFilenamePrefix));
        //sw = new StreamWriter(filePath, true, Encoding.UTF8);
        //string[] s1 = { "UserID", "time", "posx", "posy", "posz", "rotx", "roty", "rotz", "Condition", "Number" };
        //string s2 = string.Join(",", s1);
        //sw.WriteLine(s2);



    }

    // Update is called once per frame
    void Update()
    {
        if (SWfirst == true)
        {
            SWfirst = false;
            filePath = Path.Combine(Application.persistentDataPath, CreateFileName(ResultFilenamePrefix, manager.ransu));

            sw = new StreamWriter(filePath, true, Encoding.UTF8);

            string[] s1 = { "UserID", "time", "posx", "posy", "posz", "rotx", "roty", "rotz", "Condition", "Number" };
            string s2 = string.Join(",", s1);
            sw.WriteLine(s2);
        }

        //Pathtext.text = File.Exists("/storage/emulated/0/Android/data/com.DefaultCompany.New Unity Project (2)/files/result_200210-175315.csv").ToString();
        //Pathtext.text = File.Exists("/sdcard/Android/data/com.DefaultCompany.GaitVR/files/result_200210-175315.csv").ToString();


        if (UIc.goal == true)
        {

            sw.Close();
            Debug.Log("終了!!");

        }
    }

    public void OnSWClose()
    {
        sw.Close();
    }


    string CreateFileName(string prefix, int R)
    {
        if (R == 1 || R == 10)
        {
            return "Bio_" + "MFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 2 || R == 11)
        {
            return "Bio_" + "M_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 3 || R == 12)
        {
            return "Bio_" + "MSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 4 || R == 13)
        {
            return "Scr_" + "MFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 5 || R == 14)
        {
            return "Scr_" + "M_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 6 || R == 15)
        {
            return "Scr_" + "MSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 7 || R == 16)
        {
            return "Ava_" + "MFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 8 || R == 17)
        {
            return "Ava_" + "M_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 9 || R == 18)
        {
            return "Ava_" + "MSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else
        {
            return "error";
        }


        //return prefix + manager.ransu.ToString() + Extension;
    }

    public void Measure(string txt1, string txt2, string txt3, string txt4, string txt5, string txt6, string txt7, string txt8, string txt9, string txt10)
    {
        string[] s1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10 };
        string s2 = string.Join(",", s1);
        sw.WriteLine(s2);
        //sw.Flush();

    }


}
