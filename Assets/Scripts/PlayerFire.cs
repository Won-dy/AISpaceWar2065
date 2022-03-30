using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public static int setBullet2 = 0;
    int cnt = 0;
    public GameObject bulletFactory, bulletFactory2; //총알 프리팹
    public GameObject firePosition; // 발사 위치

    public int poolSize = 10;
    public int poolSize2 = 5;
    // GameObject[] bulletObjectPool; // 총알 오브젝트 풀
    public List<GameObject> bulletObjectPool;// 총알 오브젝트 풀 배열을 리스트로...
    public List<GameObject> bulletObjectPool2;// 총알 오브젝트 풀 배열을 리스트로...
    // Start is called before the first frame update
    void Start()
    {
        //  bulletObjectPool = new GameObject[poolSize]; //오브젝트 풀을 생성한다.
        bulletObjectPool = new List<GameObject>();
        bulletObjectPool2 = new List<GameObject>();
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject bullet = Instantiate(bulletFactory); // 오브젝트 풀에 등록할 총알 생성
           // bulletObjectPool[i] = bullet; //오브젝트풀에 등록
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false); // 비활성화
        }
        for (int i = 0; i < poolSize2; i++)
        {
            GameObject bullet2 = Instantiate(bulletFactory2); // 오브젝트 풀에 등록할 총알 생성
            bulletObjectPool2.Add(bullet2);
            bullet2.SetActive(false); // 비활성화
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //마우스 왼쪽버튼 눌렀을 때
        {
            Debug.Log("Fire > setBullet2: " + setBullet2);
            if (setBullet2 == 0)  // 평소
            {
                if (bulletObjectPool.Count > 0) //오브젝트풀에 총알이 있다면
                {
                    GameObject bullet = bulletObjectPool[0]; // 비활성화된 총알을 하나 가져옴
                    bullet.SetActive(true); // 활성화
                    bulletObjectPool.Remove(bullet); // 오브젝트 풀에서 제거
                    bullet.transform.position = transform.position; //총알을 위치
                }
            }
            else if (setBullet2 == 1)  // 공격력 증가
            {
                if (cnt < poolSize2) { 
                    if (bulletObjectPool2.Count > 0) //오브젝트풀에 총알이 있다면
                    {
                        print(cnt);
                        GameObject bullet2 = bulletObjectPool2[0]; // 비활성화된 총알을 하나 가져옴
                        bullet2.SetActive(true); // 활성화
                        bulletObjectPool2.Remove(bullet2); // 오브젝트 풀에서 제거
                        bullet2.transform.position = transform.position; //총알을 위치
                        cnt++;
                    }
                }
                else
                {
                    setBullet2 = 0;
                    cnt = 0;
                    if (bulletObjectPool.Count > 0) //오브젝트풀에 총알이 있다면
                    {
                        GameObject bullet = bulletObjectPool[0]; // 비활성화된 총알을 하나 가져옴
                        bullet.SetActive(true); // 활성화
                        bulletObjectPool.Remove(bullet); // 오브젝트 풀에서 제거
                        bullet.transform.position = transform.position; //총알을 위치
                    }
                }
            }
            /* for (int i = 0; i < poolSize; i++)
             {
                 GameObject bullet = bulletObjectPool[i];
                 if (bullet.activeSelf == false)
                 {
                     bullet.SetActive(true);
                     bullet.transform.position = transform.position;
                     break;
                 }
             }
            */
        }
    }
}
