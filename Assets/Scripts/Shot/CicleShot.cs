using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicleShot : MonoBehaviour {

    //발사될 총알 오브젝트
    public GameObject bullet;
    private void Start()
    {
        StartCoroutine(cntTime2(3.0f));
    }
    IEnumerator cntTime2(float delayT)
    {
        float randomTime = Random.Range(3f, 6f);

        shot();
        yield return new WaitForSeconds(delayT);
        StartCoroutine(cntTime2(randomTime));
    }
    void shot()
    {
        for (int i = 0; i < 360; i += 13)
        {
            GameObject temp = Instantiate(bullet); //총알 생성
            Destroy(temp, 2f); //2초마다 삭제
            temp.transform.position = new Vector2(0f, 5.5f); //총알 생성 위치
            temp.transform.rotation = Quaternion.Euler(0, 0, i); //Z에 값이 변해야 회전
        }
    }
}
