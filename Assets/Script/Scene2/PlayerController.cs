using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxLives = 3;
    private int currentLives;
    private Rigidbody2D rb;
    public static float speed;


    public Sprite[] lifeSprites; // ����״̬�� Sprite
    private SpriteRenderer spriteRenderer;
    public static bool isMoveL = false;
    public static bool isMoveR = false;
    public playerAudio audio1;
    private bool isHit=false;

    private GameObject childObject;
    private void Start() {
        Transform childTransform = transform.Find("wave");
        childObject = childTransform.gameObject;

        
        rb = GetComponent<Rigidbody2D>();
        audio1 =GetComponent<playerAudio>();
        currentLives = maxLives;
        spriteRenderer = GetComponent<SpriteRenderer>();
        //UpdateLifeSprite();
    }

    void Update()
    {
        // ��ȡ������ٶ�
        Vector2 velocity = rb.velocity;

        // �����ٶȵĴ�С�����ٶȵı���ֵ��
        speed = velocity.magnitude;

        // ��ӡ������ٶ�
        float totalForceMagnitude = GetTotalForceMagnitude();

        // ��ӡʩ���������ϵ��������Ĵ�С
        //Debug.Log("speed: " + speed);
        if (speed >=0.03f)
        {
            childObject.SetActive(true);
        }
        else
        {
            childObject.SetActive(false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision) {
       

        if (collision.gameObject.CompareTag("Stone")&&!isHit)
        {
            
            if (speed >= 0.9f )
            {
                audio1.playhit(3f);
                TakeDamage(2);


            }
            else if(speed >= 0.45f)
            {
                audio1.playhit(2f);
                TakeDamage(1);

            }
            isHit = true;

        }


        

        if (collision.gameObject.CompareTag("Police"))
        {
            Debug.Log("catched");
            if (!waterfall.iswin)
            {
                GameOver();
            }
            
        }



    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Stone") )
        {

            isHit = false;

        }
    }

    private void TakeDamage(int damage) {
        currentLives = currentLives - damage;
        UpdateLifeSprite();
        if (currentLives <= 0) {
            GameOver();
        }
    }
    private void UpdateLifeSprite()
    {
        if (currentLives >= 1 && currentLives <= lifeSprites.Length)
        {
            spriteRenderer.sprite = lifeSprites[currentLives ];
        }
        if (currentLives == 0 && currentLives <= lifeSprites.Length)
        {
            spriteRenderer.sprite = lifeSprites[0];
        }
    }
    private void GameOver() {
      TimelineControllerScene2.isLose = true;
    }

    private void GameWin()
    {
        TimelineControllerScene2.isWin = true;
    }


    

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Waterfall")) // �������������
        {
           
        }
    }




    float GetTotalForceMagnitude()
    {
        // ��ȡ���������
        float mass = rb.mass;

        // ��ȡ����������ʩ�����ĵ�
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int count = rb.GetContacts(contacts);

        // ��ʼ��������С
        float totalForceMagnitude = 0f;

        // ����ÿ��ʩ�����ĵ�
        for (int i = 0; i < count; i++)
        {
            // ��ȡ�������ϵ��ٶ�
            Vector2 pointVelocity = rb.GetPointVelocity(contacts[i].point);

            // ����ʩ���������ϵ����Ĵ�С���ۼӵ�������
            totalForceMagnitude += pointVelocity.magnitude * mass;
        }

        return totalForceMagnitude;
    }

}
