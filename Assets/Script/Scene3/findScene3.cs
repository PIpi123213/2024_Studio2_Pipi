using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findScene3 : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    private Color startColor;
    public float Rate;
    private float startSaturation = 0f;
    private float currentSaturation = 0f;
    public bool isFind = false;
   
    
    //public Detection detection;
    public playerMovescene3 player1;
    public playerMovescene3 player2;


    public Transform Player1;            // ��һ�����
    public Transform Player2;            // �ڶ������
    public float detectionRange = 10f;   // ��ⷶΧ
    public float fieldOfView = 45f;      // ��Ұ�Ƕ�
    public LayerMask playerLayer;        // ��Ҳ�
    public LayerMask obstaclesLayer;

  











    void Start()
    {

        /*  startColor = Color.HSVToRGB(51f/255f, 0.03f, 1f); ;
          spriteRenderer.material.color = startColor;*/
        //detection = GetComponent<Detection>();
       

    }

    // Update is called once per frame
    void Update()
    {
      

        if (TimelineScene3.isGameStart && !TimelineScene3.isLose)
        {
            if (DetectPlayer(Player1) && !DetectPlayer(Player2))
            {
                if (!player1.isMoving)
                {
                    if (currentSaturation <= 0.9f)
                    {
                        Color originalColor = spriteRenderer.material.color;

                        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                        startSaturation += Rate * 0.2f;
                        startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                        currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                        currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                        Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                        spriteRenderer.material.color = newColor;


                    }
                    else
                    {
                        spriteRenderer.material.color = Color.red;
                        Debug.Log("LOSE");
                        //GameManager.instance.GameOver();
                        TimelineScene3.isLose = true;

                        isFind = true;
                    }
                }
                else
                {
                    if (player1.isMovingFast)
                    {
                        if (currentSaturation <= 0.9f)
                        {
                            Color originalColor = spriteRenderer.material.color;

                            Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                            startSaturation += Rate * 12f;
                            startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                            currentSaturation = Mathf.Lerp(s, startSaturation, 8f * Time.deltaTime);
                            currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                            Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                            spriteRenderer.material.color = newColor;


                        }
                        else
                        {
                            spriteRenderer.material.color = Color.red;
                            Debug.Log("LOSE");
                            //GameManager.instance.GameOver();
                            TimelineScene3.isLose = true; 
                            isFind = true;
                        }
                    }
                    else
                    {
                        if (currentSaturation <= 0.9f)
                        {
                            Color originalColor = spriteRenderer.material.color;

                            Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                            startSaturation += Rate * 9f;
                            startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                            currentSaturation = Mathf.Lerp(s, startSaturation, 5f * Time.deltaTime);
                            currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                            Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                            spriteRenderer.material.color = newColor;


                        }
                        else
                        {
                            spriteRenderer.material.color = Color.red;
                            Debug.Log("LOSE");
                            //GameManager.instance.GameOver();
                            TimelineScene3.isLose = true;
                            isFind = true;
                        }
                    }
                    
                }



            }
            else if (!DetectPlayer(Player1) && DetectPlayer(Player2))
            {
                if (!player2.isMoving)
                {
                    if (currentSaturation <= 0.9f)
                    {
                        Color originalColor = spriteRenderer.material.color;

                        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                        startSaturation += Rate * 0.2f;
                        startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                        currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                        currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                        Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                        spriteRenderer.material.color = newColor;


                    }
                    else
                    {
                        spriteRenderer.material.color = Color.red;
                        Debug.Log("LOSE");
                        //GameManager.instance.GameOver();
                        TimelineScene3.isLose = true;
                        isFind = true;
                    }
                }
                else
                {
                    if (player2.isMovingFast)
                    {
                        if (currentSaturation <= 0.9f)
                        {
                            Color originalColor = spriteRenderer.material.color;

                            Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                            startSaturation += Rate * 12f;
                            startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                            currentSaturation = Mathf.Lerp(s, startSaturation, 8f * Time.deltaTime);
                            currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                            Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                            spriteRenderer.material.color = newColor;


                        }
                        else
                        {
                            spriteRenderer.material.color = Color.red;
                            Debug.Log("LOSE");
                            //GameManager.instance.GameOver();
                            TimelineScene3.isLose = true;
                            isFind = true;
                        }
                    }
                    else
                    {
                        if (currentSaturation <= 0.9f)
                        {
                            Color originalColor = spriteRenderer.material.color;

                            Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                            startSaturation += Rate * 9f;
                            startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                            currentSaturation = Mathf.Lerp(s, startSaturation, 5f * Time.deltaTime);
                            currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                            Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                            spriteRenderer.material.color = newColor;


                        }
                        else
                        {
                            spriteRenderer.material.color = Color.red;
                            Debug.Log("LOSE");
                            //GameManager.instance.GameOver();
                            TimelineScene3.isLose = true;
                            isFind = true;
                        }
                    }
                }



            }
            else if (DetectPlayer(Player1) && DetectPlayer(Player2))
            {
                if (!player2.isMoving || !player1.isMoving)
                {
                    if (currentSaturation <= 0.9f)
                    {
                        Color originalColor = spriteRenderer.material.color;

                        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                        startSaturation += Rate * 0.2f;
                        startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                        currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                        currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                        Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                        spriteRenderer.material.color = newColor;


                    }
                    else
                    {
                        spriteRenderer.material.color = Color.red;
                        Debug.Log("LOSE");
                        //GameManager.instance.GameOver();
                        isFind = true;
                        TimelineScene3.isLose = true;
                    }
                }
                else
                {
                    if (player1.isMovingFast || player2.isMovingFast)
                    {
                        if (currentSaturation <= 0.9f)
                        {
                            Color originalColor = spriteRenderer.material.color;

                            Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                            startSaturation += Rate * 12f;
                            startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                            currentSaturation = Mathf.Lerp(s, startSaturation, 8f * Time.deltaTime);
                            currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                            Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                            spriteRenderer.material.color = newColor;


                        }
                        else
                        {
                            spriteRenderer.material.color = Color.red;
                            Debug.Log("LOSE");
                            //GameManager.instance.GameOver();
                            TimelineScene3.isLose = true;
                            isFind = true;
                        }
                    }
                    else
                    {
                        if (currentSaturation <= 0.9f)
                        {
                            Color originalColor = spriteRenderer.material.color;

                            Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                            startSaturation += Rate * 9f;
                            startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);

                            currentSaturation = Mathf.Lerp(s, startSaturation, 5f * Time.deltaTime);
                            currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                            Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                            spriteRenderer.material.color = newColor;


                        }
                        else
                        {
                            spriteRenderer.material.color = Color.red;
                            Debug.Log("LOSE");
                            //GameManager.instance.GameOver();
                            TimelineScene3.isLose = true;
                            isFind = true;
                        }
                    }
                }



            }
        else
        {

                Color originalColor = spriteRenderer.material.color;

                Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                startSaturation -= Rate * 1.5f;
                startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);
                currentSaturation = Mathf.Lerp(s, startSaturation, 2f * Time.deltaTime);
                currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                spriteRenderer.material.color = newColor;





        }

        }
    else if(TimelineScene3.isGameStart && TimelineScene3.isLose)
        {

        }


    }


    bool DetectPlayer(Transform player)
    {
        // ���㾯������֮��ľ���
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // �������ڼ�ⷶΧ��
        if (distanceToPlayer <= detectionRange)
        {
            // ����Ӿ��쵽��ҵķ���
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);

            // �������Ƿ�����Ұ׶��
            if (angleToPlayer <= fieldOfView / 2)
            {
                // ����һ���Ӿ��쵽��ҵ����ߣ�ֻ�����Ҳ���ϰ����
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, playerLayer | obstaclesLayer);

                // ������Ϣ����ʾ���߼����
                Debug.DrawLine(transform.position, player.position, Color.red);

                // ��������Ƿ�������κ�����
                if (hit.collider != null)
                {
                    //Debug.Log("���߻�����: " + hit.collider.gameObject.name);
                    // ��������Ƿ���������
                    if (((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
                    {
                        //Debug.Log($"��� {player.name} �����֣�");
                        // �����������ұ����ֺ�Ĵ����߼�
                        return true;
                    }
                    else
                    {
                        //Debug.Log("����δ������ң������������赲��");
                        return false;
                    }
                }
                else
                {
                   // Debug.Log("����û�л����κ�����");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    // ��ѡ���ڱ༭���л��Ƽ�ⷶΧ
    private void OnDrawGizmosSelected()
    {
        // �������ε���ɫΪ͸���ĺ�ɫ
        Color transparentRed = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.color = transparentRed;

        // ����������Ұ
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -fieldOfView / 2) * transform.right * detectionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, fieldOfView / 2) * transform.right * detectionRange;

        // ������������
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        // �������ε���Ҷ
        float step = fieldOfView / 20; // ÿ����Ҷ�ĽǶȼ��
        for (float angle = -fieldOfView / 2; angle <= fieldOfView / 2; angle += step)
        {
            Vector3 direction = Quaternion.Euler(0, 0, angle) * transform.right * detectionRange;
            Gizmos.DrawLine(transform.position, transform.position + direction);
        }
    }








    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("2");
       
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        
       /* if (other.gameObject.CompareTag("Player"))
        {
           
            if (player1.isHiding)
                {
                    isFind1 = false;
                    isMoving1 = false;
                }
                else
                {
                    isFind1 = true;
                
                    if (player1.isMoving)
                    {
                        isMoving1 = true;
                    }
                    else
                    {
                        isMoving1 = false;
                    }
                }
            
            //Debug.Log("1");
        }
        if (other.gameObject.CompareTag("Player2"))
        {

            if (player2.isHiding)
            {
                isFind2 = false;
                isMoving2 = false;
            }
            else
            {
                isFind2 = true;
              
                if (player2.isMoving)
                {
                    isMoving2 = true;
                }
                else
                {
                    isMoving2 = false;
                }
            }


        
        }*/
        

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("2");
        /*if (other.gameObject.CompareTag("Player"))
        {
            isFind1 = false;
            isMoving1 = false;
            //Debug.Log("1");
        }

        if (other.gameObject.CompareTag("Player2"))
        {
            isFind2 = false;
            isMoving2 = false;
            //Debug.Log("1");
        }*/

    }


}
