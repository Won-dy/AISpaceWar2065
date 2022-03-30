using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public int BossHp = 100;
    private int initHp;
    public Image imgHpBar;
    public static GameObject BossHPBar, Boss;
    public GameObject vsBullet, vsNewBullet;
    public GameObject HPBar, Player, Exp;
    int isBullet = 0;
    float starTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        initHp = 100;
        BossHp = 100;
        BossHPBar = GameObject.Find("Canvas/BossHPBar_bg");
        Boss = GameObject.Find("Boss");
        HPBar = GameObject.Find("Canvas/HPBar_bg");
        Player = GameObject.Find("Player");
        Exp = GameObject.Find("Explosion");
    }
    public void BossDie()
    {
        // Destroy(Boss);
        print("Boss Die");
        GameObject.Find("Background").GetComponent<AudioSource>().Stop();
        Boss.GetComponent<SpriteRenderer>().color = new Color(150 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
        Destroy(Player);
        Destroy(HPBar);

        GameObject.Find("Spawns").SetActive(false);
        GameObject.Find("System").SetActive(false);
        //Exp.SetActive(true);

        transform.GetChild(6).gameObject.SetActive(true);
        GameObject.Find("Background").GetComponent<Background>().scrollSpeed = 2.5f;

        Invoke("LoadEnding", 3f);
    }
    public void LoadEnding()
    {
        SceneManager.LoadScene("Ending_Complete");
    }
    private void Update()
    {
        if (isBullet == 1)
        {
            if (starTime > 0.0f)
            {
                starTime -= Time.deltaTime;
            }
            else
            {
                if (BossHp > 50)
                    Boss.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 255 / 255f, 255 / 255f, 255 / 255f);
                else if(BossHp > 20)
                    Boss.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 200 / 255f, 200 / 255f, 255 / 255f);
                else
                    Boss.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 100 / 255f, 100 / 255f, 255 / 255f);
                starTime = 0.3f;
                isBullet = 0;
            }
        }
        if (BossHp <= 50)
        {
            /*            GetComponent<AudioSource>().Play();
                        GameObject.Find("Background").GetComponent<AudioSource>().volume = 0.2f;
             */
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(5).gameObject.SetActive(true);
            GameObject.Find("Background").GetComponent<Background>().scrollSpeed = 0.7f;
        }
        if(BossHp <= 20)
        {
            transform.GetChild(3).gameObject.SetActive(true);
            transform.GetChild(4).gameObject.SetActive(true);
            GameObject.Find("Background").GetComponent<Background>().scrollSpeed = 1f;
        }

        if (BossHp <= 0)
            transform.position = Vector3.Lerp(transform.position, new Vector3(0f, -15f, 0f), 0.007f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Bullet")) //Bullet과 부딪혔다면
        {
            isBullet = 1;
            GameObject vsB = Instantiate(vsBullet);
            vsB.transform.position = transform.position;
            collision.gameObject.SetActive(false);
            Boss.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 170 / 255f, 170 / 255f, 255 / 255f);
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool.Add(collision.gameObject);
            BossHp -= 1;
        }
        else if (collision.gameObject.name.Contains("newBull"))
        {
            isBullet = 1;
            GameObject vsNB = Instantiate(vsNewBullet);
            vsNB.transform.position = transform.position;
            collision.gameObject.SetActive(false);
            Boss.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 140 / 255f, 140 / 255f, 255 / 255f);
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            player.bulletObjectPool2.Add(collision.gameObject);
            BossHp -= 2;
        }
        imgHpBar.fillAmount = (float)BossHp / (float)initHp;
        //print(BossHp);
        if (BossHp <= 0)
        {
            BossDie();
        }
    }
}
