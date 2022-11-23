using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    private float time_current; // time_current의 값을 
    private float time_Max = 5f; // 효과 유지 시간
    private bool isEnded; // 타이머가 끝났는지 확인 여부

    // Start is called before the first frame update
    void Start()
    {   
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if(!isEnded){
            Check_Timer();
        }
    }
    
    void PrintInstruction()
    {
        Debug.Log("아이템에 부딪히면 효과가 나타납니다");
    }

    // 플레이어를 움직이게 만듦
    void MovePlayer()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") *  Time.deltaTime * moveSpeed;

        transform.Translate(xValue, 0, zValue);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        // 아이템에 부딪히면 5초동안 속도가 증가한다.
        if(other.gameObject.tag == "Item")
        {
            moveSpeed = 10f;
            Reset_Timer();
        }
    }


    // 타이머를 초기화
    private void Reset_Timer()
    {
        time_current = time_Max;
        isEnded = false;
        Debug.Log("Start");
    }
    

    private void Check_Timer()
    {
        if (0 < time_current)
        {
            time_current -= Time.deltaTime;
            Debug.Log(time_current);
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    private void End_Timer()
    {
        Debug.Log("End");
        time_current = 0;
        isEnded = true;
        moveSpeed=5f;
    }
}


