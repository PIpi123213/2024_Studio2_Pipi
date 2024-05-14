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

    private void Start() {
        currentLives = maxLives;
        rb = GetComponent<Rigidbody2D>();
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
        //Debug.Log("speed: " + speed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
       

        if (speed >= 0.6f&& collision.gameObject.CompareTag("Stone"))
        {

            
            
                Debug.Log("over");
                TakeDamage();
            

        }
    }

    private void TakeDamage() {
        currentLives--;

        if (currentLives <= 0) {
            GameOver();
        }
    }

    private void GameOver() {
        Debug.Log("Game Over");
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
