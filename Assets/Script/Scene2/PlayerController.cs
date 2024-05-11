using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxLives = 3;
    private int currentLives;

    private void Start() {
        currentLives = maxLives;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Stone")) {
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
}
