using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Star : MonoBehaviour
{
    public static GameObject explosion2;
    public float speed = 4.5f;
    Vector3 dir, tarPos;
    public GameObject explosionFactory, explosionFactory2;

    void OnEnable()
    {
        float randomX = Random.Range(-0.8f, 0.8f);
        int randValue = Random.Range(0, 10); // 0~9까지 10개의 값 중 하나를 랜덤으로..
        if (randValue < 5)
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
        if (collision.gameObject.name.Contains("Player")) //Player와 부딪혔다면
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion2 = Instantiate(explosionFactory2);
            explosion.transform.position = transform.position;
            PlayerController.getItemStar = 1;
            gameObject.SetActive(false);

            GameObject itemStarObject = GameObject.Find("Item_Star_Manager");
            EnemyManager manager = itemStarObject.GetComponent<EnemyManager>();
            manager.enemyObjectPool.Add(gameObject);
        }
    }
}
