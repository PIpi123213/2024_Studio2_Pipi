using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fontMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float frequency = 1.0f; // 频率，决定放大缩小的速度
    public float minScaleMultiplier = 0.5f; // 最小缩放倍数
    public float maxScaleMultiplier = 1.5f; // 最大缩放倍数

    private bool scalingUp = true; // 是否在放大
    private float timer = 0.0f;
    private Vector3 originalScale; // 初始缩放值

    private void Start()
    {
        // 记录初始缩放值
        originalScale = transform.localScale;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0f / frequency)
        {
            timer = 0.0f;

            // 切换缩放状态
            if (scalingUp)
            {
                transform.localScale = originalScale * maxScaleMultiplier;
            }
            else
            {
                transform.localScale = originalScale * minScaleMultiplier;
            }

            scalingUp = !scalingUp;
        }
    }

}
