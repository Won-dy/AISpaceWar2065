﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public float speed = 5.0f;
    public int randomNum = 8;
    Vector3 dir, tarPos;
    public float time;
    public GameObject vsBullet, vsPlayer;
    void OnEnable() // 객체가 활성화 될 때 호출되는 함수 //OnDisable -> 비활성화 될 때...
    {
        float randomX = Random.Range(-1.5f, 1.5f);
        int randValue = Random.Range(0, 10); // 0~9까지 10개의 값 중 하나를 랜덤으로..
        if (randValue < randomNum) // 0, 1, 2값이 나왔다면
        {
            // -3 -5 / 3 -5
            tarPos = new Vector3(randomX, -12f, 0f);
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
    {    transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bottle"))
            return;

        if (collision.gameObject.name.Contains("Bullet")) //Bullet과 부딪혔다면
        {
            GameObject vsB = Instantiate(vsBullet);
            vsB.transform.position = transform.position;
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // PlayerFire.cs의 총알 오브젝트풀 리스트객체를 사용하기 위해 PlayerFire 클래스 얻어오기
            player.bulletObjectPool.Add(collision.gameObject);
            ScoreManager1.Instance.Score1++; // 생글톤객체의 Score프로퍼티 호출
        }
        else if (collision.gameObject.name.Contains("newBull"))
        {
            GameObject vsB = Instantiate(vsBullet);
            vsB.transform.position = transform.position;
            collision.gameObject.SetActive(false);

            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool2.Add(collision.gameObject);
            ScoreManager1.Instance.Score1++; // 생글톤객체의 Score프로퍼티 호출
        }
        else if (collision.gameObject.name.Contains("Player")) //Player과 부딪혔다면
        { //플레이어
            GameObject vsP = Instantiate(vsPlayer);
            vsP.transform.position = transform.position;
            PlayerController.isDamaged = 1;
            Debug.Log("Enemy > isDamaged: " + PlayerController.isDamaged);
        }
        gameObject.SetActive(false);

        GameObject emObject = GameObject.Find("EnemyManager");
        EnemyManager manager = emObject.GetComponent<EnemyManager>(); //EnemyManager 클래스 얻어오기
        manager.enemyObjectPool.Add(gameObject); //리스트에 enemy 삽입

    }
}
