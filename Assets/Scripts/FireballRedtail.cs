using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballRedtail : MonoBehaviour
{
    public GameObject explosionFactory;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player")) //Player와 부딪혔다면
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            PlayerController.isDamagedByFireTail = 1;
            gameObject.SetActive(false);
        }
    }
}
