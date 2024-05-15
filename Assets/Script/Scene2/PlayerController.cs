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


    public Sprite[] lifeSprites; // 生命状态的 Sprite
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
        // 获取物体的速度
        Vector2 velocity = rb.velocity;

        // 计算速度的大小（即速度的标量值）
        speed = velocity.magnitude;

        // 打印物体的速度
        float totalForceMagnitude = GetTotalForceMagnitude();

        // 打印施加在物体上的所有力的大小
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
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameWin()
    {
        Debug.Log("Game Win");
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等
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
       
        if (other.CompareTag("Waterfall")) // 假设是玩家物体
        {
            GameWin();
        }
    }




    float GetTotalForceMagnitude()
    {
        // 获取物体的质量
        float mass = rb.mass;

        // 获取物体上所有施加力的点
        ContactPoint2D[] contacts = new ContactPoint2D[10];
        int count = rb.GetContacts(contacts);

        // 初始化总力大小
        float totalForceMagnitude = 0f;

        // 遍历每个施加力的点
        for (int i = 0; i < count; i++)
        {
            // 获取给定点上的速度
            Vector2 pointVelocity = rb.GetPointVelocity(contacts[i].point);

            // 计算施加在物体上的力的大小并累加到总力中
            totalForceMagnitude += pointVelocity.magnitude * mass;
        }

        return totalForceMagnitude;
    }

}
