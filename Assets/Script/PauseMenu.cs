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

        // ���������
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // ��ʾ�����
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void LoadMenu(string sceneName)
    {
        StartCoroutine(LoadMenuCoroutine(sceneName));
    }
    private IEnumerator LoadMenuCoroutine(string sceneName)
    {
        // ���ü���
        SaveManager.Instance.ResetCheckpoints();

        // ����ʱ���ᴥ����
        if (Timelinetrigger.Instance != null)
        {
            Timelinetrigger.Instance.clear();
        }

        // �ָ���Ϸʱ��
        Resume();
        //Time.timeScale = 1f;
       
            yield return null;
        

        // ���س���
        SceneManager.LoadScene(sceneName); // �滻��������˵�����������
    }
    public async void LoadMenuAsync(string sceneName)
    {
        // ���ü��㣬�ȴ��������
        await SaveManager.Instance.ResetCheckpointsAsync();

        if (Timelinetrigger.Instance != null)
        {
            Timelinetrigger.Instance.clear();
        }

        // �ָ���Ϸʱ��
        Resume();
        Time.timeScale = 1f;

        // ���س���
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
