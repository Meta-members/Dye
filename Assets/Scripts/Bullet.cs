using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //탄속
    [SerializeField] float speed = 0.01f;
    //유효사거리
    [SerializeField] float distance = 100f;
    //시작 위치
    private Vector3 startPosition;
    //목표 위치
    private Vector3 targetPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        // 생성 위치
        startPosition = transform.position;
        // Y각
        float angleY = transform.eulerAngles.y;
        // Y의 회전각
        if (angleY > 0)
            angleY = 90 - angleY;
        else
            angleY = 90 + Mathf.Abs(angleY);

        // X축 회전각
        float angleX = transform.eulerAngles.x + 90;
        

        Destroy(gameObject, 10f);

        //각도를 라디안으로 변환(
        angleY *= Mathf.Deg2Rad;
        angleX *= Mathf.Deg2Rad;
        //구면 좌표를 직교 좌표로 변환(거리 계산 좌표)
        Vector3 calcPosition = new Vector3(distance * Mathf.Sin(angleX) * Mathf.Cos(angleY),
            distance * Mathf.Cos(angleX),
            distance * Mathf.Sin(angleX) * Mathf.Sin(angleY));
        Debug.Log(calcPosition);
        //목표위치 = 시작위치 + 계산 위치
        targetPoint = startPosition + calcPosition;
    }

    // Update is called once per frame
    void Update()
    {
        //목표 좌표까지 speed 속도로 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, speed);
        //목표 좌표에 도달 시 오브젝트 삭제
        if (transform.position == targetPoint)
        {
            Debug.Log("소멸");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //벽과 부딪혔을 때 오브젝트 삭제
        if (other.gameObject.tag == "Wall")
        {
            Debug.Log("Bullt: hit wall");
            Destroy(gameObject);
        }
    }
}
