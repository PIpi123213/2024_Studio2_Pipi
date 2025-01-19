using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // 隐藏鼠标光标
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // 显示鼠标光标
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu(string sceneName)
    {
        StartCoroutine(LoadMenuCoroutine(sceneName));
    }
    private IEnumerator LoadMenuCoroutine(string sceneName)
    {
        // 重置检查点
        SaveManager.Instance.ResetCheckpoints();

        // 清理时间轴触发器
        if (Timelinetrigger.Instance != null)
        {
            Timelinetrigger.Instance.clear();
        }

        // 恢复游戏时间
        Resume();
        //Time.timeScale = 1f;
       
            yield return null;
        

        // 加载场景
        SceneManager.LoadScene(sceneName); // 替换成你的主菜单场景的名称
    }
    public async void LoadMenuAsync(string sceneName)
    {
        // 重置检查点，等待操作完成
        await SaveManager.Instance.ResetCheckpointsAsync();

        if (Timelinetrigger.Instance != null)
        {
            Timelinetrigger.Instance.clear();
        }

        // 恢复游戏时间
        Resume();
        Time.timeScale = 1f;

        // 加载场景
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
