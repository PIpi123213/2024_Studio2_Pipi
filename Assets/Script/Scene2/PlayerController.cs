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
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
