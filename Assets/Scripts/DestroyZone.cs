using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //     Destroy(other.gameObject);
        if (other.gameObject.name.Contains("Bullet") || other.gameObject.name.Contains("newBull") || other.gameObject.name.Contains("Enemy") || other.gameObject.name.Contains("Bottle") || other.gameObject.name.Contains("Item") || other.gameObject.name.Contains("Flare") || other.gameObject.name.Contains("Rocket")) //총알 또는 에너미와 충돌시
        {
            other.gameObject.SetActive(false); // 비활성화
            if (other.gameObject.name.Contains("Bullet")) //부딪힌게 총알이라면
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                // PlayerFire.cs의 총알 오브젝트풀 리스트객체를 얻어오기 위해..
                    player.bulletObjectPool.Add(other.gameObject);
                    print("총알 1 충전");
            }
            else if (other.gameObject.name.Contains("newBull"))
            {
                PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
                player.bulletObjectPool2.Add(other.gameObject);
                print("총알 2 충전");
            }
            else if (other.gameObject.name.Contains("Enemy") || other.gameObject.name.Contains("Rocket"))
            {
                GameObject emObject;
                if (other.gameObject.name == "Enemy2")
                    emObject = GameObject.Find("EnemyManager2");
                else
                    emObject = GameObject.Find("EnemyManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>(); //EnemyManager 클래스 얻어오기
                manager.enemyObjectPool.Add(other.gameObject); //리스트에 enemy 삽입
            }
            else if (other.gameObject.name.Contains("Bottle"))  
            {
                GameObject emObject;
                if (other.gameObject.name == "Bottle_PowerUp")  // 공격력 강화 아이템
                    emObject = GameObject.Find("PowerUpManager");
                else
                    emObject = GameObject.Find("ChargeHPManager");  // 체력 아이템
                EnemyManager manager = emObject.GetComponent<EnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Item"))  // 무적아이템
            {
                GameObject emObject = GameObject.Find("Item_Star_Manager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.name.Contains("Flare"))  // 불꽃 장애물
            {
                GameObject emObject = GameObject.Find("FlareObstacleManager");
                EnemyManager manager = emObject.GetComponent<EnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
    }
}
