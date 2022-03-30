using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeHP : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir, tarPos;
    public GameObject explosionFactory;

    void OnEnable() // 객체가 활성화 될 때 호출되는 함수 //OnDisable -> 비활성화 될 때...
    {
        float randomX = Random.Range(-0.8f, 0.8f);
        int randValue = Random.Range(0, 10); // 0~9까지 10개의 값 중 하나를 랜덤으로..
        if (randValue < 5) // 0~4 값이 나왔다면
        {
            tarPos = new Vector3(randomX, -15f, 0f);
            dir = tarPos - transform.position; // 방향을 구한 후
            dir.Normalize(); // 정규화 
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            PlayerController.getChargeHP = 1;


            Debug.Log("ChargeHP > getChargeHP: " + PlayerController.getChargeHP);
            gameObject.SetActive(false);
            GameObject whatObj = GameObject.Find("ChargeHPManager");
            EnemyManager manager = whatObj.GetComponent<EnemyManager>(); //ChargeHPManager 클래스 얻어오기
            manager.enemyObjectPool.Add(gameObject); //리스트에 ChargeHP 삽입
            
        }
    }

}
