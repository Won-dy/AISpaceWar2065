using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // 체력바
    public static int hp = 100;
    private int initHp;
    public Image imgHpBar;
    public Material Material, Material2;
    public static int isDamaged = 0;
    public static int getChargeHP = 0;
    public static int getItemStar = 0;
    public static int isDamagedByFlare = 0;
    public static int isDamagedByFireTail = 0;
    public static GameObject HPBar, Player ,Plane1;
    public float starTime = 5.0f;
    public int stageNum;

    // Start is called before the first frame update
    void Start()
    {
        initHp = 100;
        hp = 100;
        starTime = 5.0f;
        HPBar = GameObject.Find("Canvas/HPBar_bg");
        Player = GameObject.Find("Player");
        Plane1 = GameObject.Find("Player/Plane1");
    }
    public void PlayerDie()
    {
        Destroy(Player);
        Destroy(HPBar);
        print("Die");
        StageManager.nowScene();
    }
    // Update is called once per frame
    void Update()
    {
        if (hp <= 20) {
            GetComponent<AudioSource>().Play();
            GameObject.Find("Background").GetComponent<AudioSource>().volume = 0.2f;
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else {
            GetComponent<AudioSource>().Stop();
            GameObject.Find("Background").GetComponent<AudioSource>().volume = 0.5f;
            transform.GetChild(2).gameObject.SetActive(false);
        }
        if (isDamaged == 1 || isDamaged == 2)  // 적에게 맞으면 체력 감소
        {
            if (getItemStar == 1)  // 무적이면 체력 유지
            { 
                print("안줄어" + hp);
                isDamaged = 0;
            }
            else
            {
                //Debug.Log("PC1 > isDamaged: " + isDamaged);
                if (isDamaged == 1)
                    hp -= 25;
                else
                    hp -= 40;
                //Debug.Log("Minus hp: " + hp);
                imgHpBar.fillAmount = (float)hp / (float)initHp;
                if (hp <= 0)
                    PlayerDie();
                isDamaged = 0;
               //Debug.Log("PC2 > isDamaged: " + isDamaged);
            }
        }
        if(getChargeHP == 1)  // 체력 충전 아이템 먹으면 체력 증가
        {
            hp += 20;
            if (hp > 100)
                hp = 100;
            imgHpBar.fillAmount = (float)hp / (float)initHp;
            getChargeHP = 0;
        }
        if(getItemStar == 1)  // 무적 아이템 먹으면 몇초간 무적
        {
            if (starTime > 0.0f)  // 무적 상태
            {
                starTime -= Time.deltaTime;
                Plane1.GetComponent<MeshRenderer>().material = Material2;  // 매터리얼 변경                
		        GameObject.Find("Background").GetComponent<AudioSource>().Stop();
            }
            else
            {
                Plane1.GetComponent<MeshRenderer>().material = Material;
                GameObject.Find("Background").GetComponent<AudioSource>().Play();
                Item_Star.explosion2.SetActive(false);
                getItemStar = 0;
                starTime = 5.0f;
            }
        } 
        if(isDamagedByFlare == 1)
        {
            if (getItemStar == 1)  // 무적이면 체력 유지
                isDamagedByFlare = 0;
            else
            {   
                hp -= 10;
                Debug.Log("Minus hp: " + hp);
                imgHpBar.fillAmount = (float)hp / (float)initHp;
                if (hp <= 0)
                    PlayerDie();
                isDamagedByFlare = 0;
            }
        }
        if(isDamagedByFireTail == 1)
        {
            if (getItemStar == 1)  // 무적이면 체력 유지
                isDamagedByFireTail = 0;
            else
            {
                hp -= 20;
                imgHpBar.fillAmount = (float)hp / (float)initHp;
                if (hp <= 0)
                    PlayerDie();
                isDamagedByFireTail = 0;
            }
        }
    }
}
