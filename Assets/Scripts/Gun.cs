using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //총알 오브젝트 맵핑
    public GameObject bullet;
    //총구
    GameObject muzzle;

    //유효 사거리
    [SerializeField] float effectiveRange = 100f;
    //발사 간격
    [SerializeField] float firingInterval = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // 총구 오브젝트를 가져옴
        muzzle = transform.GetChild(6).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 좌 클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            //현재 위치/회전에 bullet 클론 생성
            Instantiate(bullet, muzzle.transform.position, transform.rotation);
        }
    }
}
