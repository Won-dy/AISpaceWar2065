using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    float speed = 5.0f;
    float topPos;
    private GameObject HPBar;

    // Start is called before the first frame update
    void Start()
    {
        HPBar = GameObject.Find("Canvas/HPBar_bg");
        if (SceneManager.GetActiveScene().name == "BossStage")
            topPos = 0.7f;
        else
            topPos = 0.97f;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0.07f)  // 왼쪽 화면 밖으로나감 > 아무리 왼쪽으로 이동해도 0.0f
            pos.x = 0.07f;
        if (pos.x > 0.93f)  // 오른쪽 화면 밖으로 나감
            pos.x = 0.93f;
        if (pos.y < 0.04f)  // 아래쪽 화면 밖으로 나감
            pos.y = 0.04f;
        if (pos.y > topPos)  // 윗쪽 화면 밖으로 나감
            pos.y = topPos;

        transform.position = Camera.main.ViewportToWorldPoint(pos);

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v, 0);
        transform.position += dir * speed * Time.deltaTime;
        // P = P0 + vt ( 미래위치 = 현재위치 + 속도X시간 )

        // HPBar 이동
        HPBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.35f, 0));
    }
}
