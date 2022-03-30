using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareObstacle : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir, tarPos;
    public GameObject explosionFactory;
    public Material Material, Material2;
    GameObject Flare;
    private void Start()
    {
        Flare = transform.GetChild(0).gameObject;
    }
    IEnumerator timer()
    {
        int time = 0;
        WaitForSeconds wfs = new WaitForSeconds(0.2f);
        while (true)
        {
            time++;
            //print("time " + time);
            if (time % 2 == 0)
                Flare.GetComponent<MeshRenderer>().material = Material;
            else
                Flare.GetComponent<MeshRenderer>().material = Material2;

            yield return wfs;
        }
    }
    void OnEnable() // 객체가 활성화 될 때 호출되는 함수 //OnDisable -> 비활성화 될 때...
    {
        float randomX = Random.Range(-1.5f, 1.5f);
        int randValue = Random.Range(0, 10); // 0~9까지 10개의 값 중 하나를 랜덤으로..
        if (randValue < 9) // 0~8 값이 나왔다면
        {
            tarPos = new Vector3(randomX, -10f, 0f);
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
        StartCoroutine(timer());
        transform.position += dir * speed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player")) //Player와 부딪혔다면
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            PlayerController.isDamagedByFlare = 1;
            Debug.Log("isDamagedByFlare " + PlayerController.isDamagedByFlare);
            gameObject.SetActive(false);
            GameObject whatObj = GameObject.Find("FlareObstacleManager");
            EnemyManager manager = whatObj.GetComponent<EnemyManager>(); //ChargeHPManager 클래스 얻어오기
            manager.enemyObjectPool.Add(gameObject); //리스트에 ChargeHP 삽입

        }
    }

}
