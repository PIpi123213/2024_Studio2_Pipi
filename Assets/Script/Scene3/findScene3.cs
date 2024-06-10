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


    public Transform Player1;            // 第一个玩家
    public Transform Player2;            // 第二个玩家
    public float detectionRange = 10f;   // 检测范围
    public float fieldOfView = 45f;      // 视野角度
    public LayerMask playerLayer;        // 玩家层
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
        // 计算警察和玩家之间的距离
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 如果玩家在检测范围内
        if (distanceToPlayer <= detectionRange)
        {
            // 计算从警察到玩家的方向
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);

            // 检查玩家是否在视野锥内
            if (angleToPlayer <= fieldOfView / 2)
            {
                // 发射一条从警察到玩家的射线，只检测玩家层和障碍物层
                RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, detectionRange, playerLayer | obstaclesLayer);

                // 调试信息：显示射线检测结果
                Debug.DrawLine(transform.position, player.position, Color.red);

                // 检查射线是否击中了任何物体
                if (hit.collider != null)
                {
                    //Debug.Log("射线击中了: " + hit.collider.gameObject.name);
                    // 检查射线是否击中了玩家
                    if (((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
                    {
                        //Debug.Log($"玩家 {player.name} 被发现！");
                        // 在这里添加玩家被发现后的处理逻辑
                        return true;
                    }
                    else
                    {
                        //Debug.Log("射线未击中玩家，被其他物体阻挡。");
                        return false;
                    }
                }
                else
                {
                   // Debug.Log("射线没有击中任何物体");
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

    // 可选：在编辑器中绘制检测范围
    private void OnDrawGizmosSelected()
    {
        // 设置扇形的颜色为透明的红色
        Color transparentRed = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.color = transparentRed;

        // 绘制扇形视野
        Vector3 leftBoundary = Quaternion.Euler(0, 0, -fieldOfView / 2) * transform.right * detectionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, 0, fieldOfView / 2) * transform.right * detectionRange;

        // 绘制扇形区域
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        // 绘制扇形的扇叶
        float step = fieldOfView / 20; // 每个扇叶的角度间隔
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
