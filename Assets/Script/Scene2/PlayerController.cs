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

    private void Start() {
        currentLives = maxLives;
        rb = GetComponent<Rigidbody2D>();
        audio1 =GetComponent<playerAudio>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateLifeSprite();
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
        Debug.Log("speed: " + speed);

    }

    private void OnCollisionEnter2D(Collision2D collision) {
       

        if (speed >= 0.45f&& collision.gameObject.CompareTag("Stone"))
        {
            audio1.playhit(2f);
            
            
                Debug.Log("over");
                TakeDamage(1);
                


        }

        if (speed >= 0.9f && collision.gameObject.CompareTag("Stone"))
        {
            audio1.playhit(3f);


            Debug.Log("over");
            TakeDamage(2);
            

        }


        if (collision.gameObject.CompareTag("Police"))
        {
            Debug.Log("catched");
            GameOver();
        }



    }

    private void TakeDamage(int damage) {
        currentLives = currentLives - damage;
        UpdateLifeSprite();
        if (currentLives <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("Game Over");
        // �����ﴦ����Ϸ�������߼����������¼��س���������ʾ��Ϸ���������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameWin()
    {
        Debug.Log("Game Win");
        // �����ﴦ����Ϸ�������߼����������¼��س���������ʾ��Ϸ���������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    private void UpdateLifeSprite()
    {
        if (currentLives >= 1 && currentLives <= lifeSprites.Length)
        {
            spriteRenderer.sprite = lifeSprites[currentLives - 1];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Waterfall")) // �������������
        {
            GameWin();
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
