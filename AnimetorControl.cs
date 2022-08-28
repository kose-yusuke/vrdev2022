using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimetorControl : MonoBehaviour
{
    private Animator animator;
    // 設定したフラグの名前
    private const string key_isRun = "isRun";
    private const string key_isJump = "isJump";


    // Use this for initialization
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // 矢印下ボタンを押下している
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // WaitからRunに遷移する
            this.animator.SetBool(key_isRun, true);
            transform.position += transform.forward * 0.005f;
        }
        else
        {
            // RunからWaitに遷移する
            this.animator.SetBool(key_isRun, false);
        }


    }
}