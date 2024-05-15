using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class arduino123 : MonoBehaviour
{
    public static float direction;
    public static float speed;

    public static float direction2;
    public static float speed2;

    // Start is called before the first frame update
    private static arduino123 instance;

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

    public void ReadComprateString(object data) {
        var text = data as string;
        speed = 0.0f;
        speed2 = 0.0f;
        if (!string.IsNullOrEmpty(text)) {
            string[] parts = text.Split(',');
            if (parts.Length == 2) {
                int value1, value2;
                // 尝试解析第一个部分的值
                if (int.TryParse(parts[0], out value1)) {
                    direction = -Mathf.Sign(value1);
                    speed = Mathf.Abs(value1);
                    speed = speed / 1.2f;
                    PlayerController.isMoveL = true;
                    if (speed <= 7.5f) {
                        speed = 0.0f;
                        PlayerController.isMoveL = false;

                    }
                }
                // 尝试解析第二个部分的值
                if (int.TryParse(parts[1], out value2)) {
                    direction2 = -Mathf.Sign(value2);
                    speed2 = Mathf.Abs(value2);
                    speed2 = speed2 / 1.05f;
                    PlayerController.isMoveR = true;
                    if (speed2 <= 7.5f) {
                        speed2 = 0.0f;
                        PlayerController.isMoveR = false;
                    }
                }
            }


           /* int value;
            
            if (int.TryParse(text, out value)) {
                // 根据值的正负来确定方向
                direction = -Mathf.Sign(value);
                // 使用绝对值作为速度的大小
                speed = Mathf.Abs(value);
                if (speed <= 7.5f) {
                    speed = 0.0f;
                }*/
                //Debug.Log("Horizontal Input: " + direction + ", Speed: " + speed);
                //Debug.Log("Horizontal Input2: " + direction2 + ", Speed2: " + speed2 );
                Player.horizontalInput1 = direction;
                Player.cspeed = speed;
                Player1.horizontalInput1 = direction2;
                Player1.cspeed = speed2;


            // 现在你可以使用 direction 和 speed 了
            // direction 表示方向，可以是 -1 或 1
            // speed 表示速度的大小
        }
        }





    }






