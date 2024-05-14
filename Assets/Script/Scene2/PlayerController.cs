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
        // ��ȡ������ٶ�
        Vector2 velocity = rb.velocity;

        // �����ٶȵĴ�С�����ٶȵı���ֵ��
        speed = velocity.magnitude;

        // ��ӡ������ٶ�
        float totalForceMagnitude = GetTotalForceMagnitude();

        // ��ӡʩ���������ϵ��������Ĵ�С
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
        // �����ﴦ����Ϸ�������߼����������¼��س���������ʾ��Ϸ���������
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
