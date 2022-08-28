/*using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        UIc = GameObject.Find("UIControl").GetComponent<UIControl>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();

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
            filePath = Path.Combine(Application.persistentDataPath, CreateFileName(ResultFilenamePrefix,manager.ransu));

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


    string CreateFileName(string prefix,int R)
    {
        if ( R==1 || R== 31) 
        {
            return "Bio_"+ "PFASTMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 2 || R == 32)
        {
            return "Bio_" + "PMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 3 || R == 33)
        {
            return "Bio_" + "PSLOWMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 4 || R == 34)
        {
            return "Bio_" + "PFASTM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 5 || R == 35)
        {
            return "Bio_" + "PM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 6 || R == 36)
        {
            return "Bio_" + "PSLOWM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 7 || R == 37)
        {
            return "Bio_" + "PFASTMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 8 || R == 38)
        {
            return "Bio_" + "PMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }

        else if (R == 9 || R == 39)
        {
            return "Bio_" + "PSLOWMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 10 || R == 40)
        {
            return "Scr_" + "PFASTMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 11 || R == 41)
        {
            return "Scr_" + "PMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 12 || R == 42)
        {
            return "Scr_" + "PSLOWMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 13 || R == 43)
        {
            return "Scr_" + "PFASTM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 14 || R == 44)
        {
            return "Scr_" + "PM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 15 || R == 45)
        {
            return "Scr_" + "PSLOWM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 16 || R == 46)
        {
            return "Scr_" + "PFASTMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 17 || R == 47)
        {
            return "Scr_" + "PMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 18 || R == 48)
        {
            return "Scr_" + "PSLOWMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 19 || R == 49)
        {
            return "Ava_" + "PFASTMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 20 || R == 50)
        {
            return "Ava_" + "PMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 21 || R == 51)
        {
            return "Ava_" + "PSLOWMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 22 || R == 52)
        {
            return "Ava_" + "PFASTM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 23 || R == 53)
        {
            return "Ava_" + "PM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 24 || R == 54)
        {
            return "Ava_" + "PSLOWM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 25 || R == 55)
        {
            return "Ava_" + "PFASTMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 26 || R == 56)
        {
            return "Ava_" + "PMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 27 || R == 57)
        {
            return "Ava_" + "PSLOWMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 28 || R == 58)
        {
            return "of_" + "PMFAST_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 29 || R == 59)
        {
            return "of_" + "PM_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
        }
        else if (R == 30 || R == 60)
        {
            return "of_" + "PMSLOW_" + prefix + DateTime.Now.ToString("yyMMdd-HHmmss") + Extension;
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
*/