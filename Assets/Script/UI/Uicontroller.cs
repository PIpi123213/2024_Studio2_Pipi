using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uicontroller : MonoBehaviour
{
    // Start is called before the first frame update
    public static int playerReady = 0;
    public GameObject Firstcanvas;
    public float fadeDuration = 2.0f; // 渐隐持续时间
    private CanvasGroup canvasGroup;
    private bool isFading = false;
    public Camera _camera;
    public static bool isStart=false;

    public static bool isStartGame = false;



    private void Start()
    {
        canvasGroup = Firstcanvas.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup component is missing. Please add a CanvasGroup component to the Canvas.");
        }
    }

    private void Update()
    {
        if (playerReady>=2)
        {
            // 渐隐处理
            StartFading();
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, 25f, 0.03f);
            if (_camera.fieldOfView >= 24.9f)
            {
                isStart = true;
            }
        }
    }

    public void StartFading()
    {
        canvasGroup.alpha -= Time.deltaTime / fadeDuration;
        if (canvasGroup.alpha <= 0)
        {
            canvasGroup.alpha = 0;

            // 可选择在渐隐完成后禁用Canvas
            Firstcanvas.SetActive(false);
        }
    }
}
