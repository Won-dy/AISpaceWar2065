using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy") || other.gameObject.name.Contains("Bottle") || other.gameObject.name.Contains("Item")) //총알 또는 에너미와 충돌시
        {
            if (other.gameObject.name.Contains("Enemy"))
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
        }
    }
}
