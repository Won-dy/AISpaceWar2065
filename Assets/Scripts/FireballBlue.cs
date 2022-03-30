using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBlue : MonoBehaviour
{
    public GameObject explosionFactory;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player")) //Player와 부딪혔다면
        {
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;
            PlayerController.isDamagedByFlare = 1;
            gameObject.SetActive(false);
        }
    }
}
