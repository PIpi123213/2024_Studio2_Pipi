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
        // ���ʵ���Ѿ����ڣ��������µ�ʵ��
        if (instance != null) {
            Destroy(gameObject);
            return;
        }

        // ����ǰʵ������Ϊ��̬ʵ��
        instance = this;

        // ȷ�������������ڼ����³���ʱ��������
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
                // ���Խ�����һ�����ֵ�ֵ
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
                // ���Խ����ڶ������ֵ�ֵ
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
                // ����ֵ��������ȷ������
                direction = -Mathf.Sign(value);
                // ʹ�þ���ֵ��Ϊ�ٶȵĴ�С
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


            // ���������ʹ�� direction �� speed ��
            // direction ��ʾ���򣬿����� -1 �� 1
            // speed ��ʾ�ٶȵĴ�С
        }
        }





    }






