using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont : MonoBehaviour
{
    // Start is called before the first frame update
    private static dont instance;

    void Awake() {
        // 如果实例已经存在，则销毁新的实例
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        // 将当前实例设置为静态实例
        instance = this;

        // 确保控制器对象在加载新场景时不被销毁
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
