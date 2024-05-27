using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    // 初始化
    void Start()
    {
        // 获取 Animator 组件
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        















    }
    // 检测碰撞进入
    void OnTriggerEnter(Collider other)
    {
        // 检查碰撞对象是否是目标（可以根据实际需求调整）
        if (other.CompareTag("DiggingArea"))
        {
            // 设置 isDiging 参数为 true
            animator.SetBool("isDiging", true);
        }
    }

    // 检测碰撞退出
    void OnTriggerExit(Collider other)
    {
        // 离开挖掘区域时，将 isDiging 参数设为 false
        if (other.CompareTag("DiggingArea"))
        {
            animator.SetBool("isDiging", false);
        }
    }
}
