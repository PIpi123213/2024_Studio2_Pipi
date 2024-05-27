using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
   
    
    public enum Char {
        Option1 = 1,
        Option2 = 2
    }
    public Char characterChoice;
    public float speedRate;
    private float horizontalInput1;
    private float cspeed;

    public float speedRate_Joystick;
    private float horizontalInput1_Joystick;
    private float cspeed_Joystick;

    public float smoothness = 10.0f;
    private float forceCurrent;
    private Rigidbody2D rb;
    public float forceMagnitude = 0f;
    // Start is called before the first frame update
    public float forceIncreaseRate = 1f; // 力的增加速率
    private float forceIncreaseRateTemp = 1f;
    private float currentForce = 5f;

    public float rotationSpeed = 1f;
    public float rotationSpeed_Joystick = 1f;
    private float returnSpeed = 0.5f;

    public Sprite[] lifeSprites; // 生命状态的 Sprite
    private SpriteRenderer spriteRenderer;
    public int maxLives = 3;
    private int currentLives;
    private GameObject childObject;
    public playerAudio audio1;
    private float speed;
    private bool isHit = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        forceIncreaseRateTemp = forceIncreaseRate;
        Transform childTransform = transform.Find("wave");
        childObject = childTransform.gameObject;
        currentLives = maxLives;
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateLifeSprite();
        audio1 = GetComponent<playerAudio>();


        GameManager.iswinscene2=0;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed >= 0.03f)
        {
            childObject.SetActive(true);
        }
        else
        {
            childObject.SetActive(false);
        }
        if (characterChoice == Char.Option1) {
            cspeed = arduino123.speed / speedRate;
            horizontalInput1 = arduino123.direction;
        }
        else {
            cspeed = arduino123.speed2 / speedRate;
            horizontalInput1 = arduino123.direction2;

        }

        if (characterChoice == Char.Option1)
        {
            cspeed_Joystick = input11.speed / speedRate_Joystick;
            horizontalInput1_Joystick = input11.direction;
        }
        else
        {
            cspeed_Joystick = input11.speed2 / speedRate_Joystick;
            horizontalInput1_Joystick = input11.direction2;

        }



        


        Vector2 velocity = rb.velocity;

        // 计算速度的大小（即速度的标量值）
        speed = velocity.magnitude;

        // 打印物体的速度


        // 打印施加在物体上的所有力的大小
        UnityEngine.Debug.Log("speed: " + speed);

        Quaternion currentRotation = transform.rotation;
        float currentZ = currentRotation.eulerAngles.z;
        Quaternion targetRotation;
        // 计算目标旋转角度
        if (cspeed != 0) {
            // 当 cspeed 非零时，按固定速度调整 z 轴旋转，方向由 cspeed 的正负决定
            float targetZ = currentZ + (-horizontalInput1 * rotationSpeed * Time.deltaTime);
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, targetZ);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, 1); // 直接设置为目标旋转，避免 Lerp 的缓动效果
        }
        //UnityEngine.Debug.Log(cspeed);


        if (cspeed_Joystick != 0)
        {
            // 当 cspeed 非零时，按固定速度调整 z 轴旋转，方向由 cspeed 的正负决定
            float targetZ = currentZ + (-horizontalInput1_Joystick * rotationSpeed_Joystick * Time.deltaTime);
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, targetZ);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, 1); // 直接设置为目标旋转，避免 Lerp 的缓动效果
        }
        //UnityEngine.Debug.Log(cspeed_Joystick);

        if (cspeed_Joystick <= 0.3f && horizontalInput1 == 0f)
        {
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, returnSpeed * Time.deltaTime);
        }



        if (cspeed <= 0.04f&&horizontalInput1_Joystick==0f) {
            targetRotation = Quaternion.Euler(currentRotation.eulerAngles.x, currentRotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, returnSpeed * Time.deltaTime);
        }
        // 当 cspeed 为零时，平滑地将 z 轴旋转恢复到 0
        //

       



       
        
        
    }

    private void FixedUpdate()
    {
        //UnityEngine.Debug.Log(currentForce);

        currentForce += forceIncreaseRate * Time.deltaTime;

        // 限制当前施加的力不超过最大值
        currentForce = Mathf.Clamp(currentForce, 4f, forceMagnitude);



        // 施加力，方向为世界空间中的 Y 轴正方向，大小为 currentForce
        rb.AddForce(Vector3.up * currentForce);
        //UnityEngine.Debug.Log(currentForce);
        if (horizontalInput1 != 0)
        {
            MoveWithController();
        }
        if (horizontalInput1_Joystick != 0)
        {
            MoveWithController_Joystick();
        }




    }

    private void GameOver()
    {
        UnityEngine.Debug.Log("Game Over");
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameWin()
    {
        UnityEngine.Debug.Log("Game Win");
        // 在这里处理游戏结束的逻辑，例如重新加载场景或者显示游戏结束画面等
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void TakeDamage(int damage)
    {
        currentLives = currentLives - damage;
        UpdateLifeSprite();
        if (currentLives <= 0)
        {
            GameOver();
        }
    }
    private void UpdateLifeSprite()
    {
        if (currentLives >= 1 && currentLives <= lifeSprites.Length)
        {
            spriteRenderer.sprite = lifeSprites[currentLives - 1];
        }
    }





    private void MoveWithController() {
        
       
        float distanceToMove = horizontalInput1 * cspeed *10  * Time.deltaTime;

        // 创建一个新的位置向量
        Vector3 newPosition = transform.position + new Vector3(distanceToMove, 0f, 0f);

        // 通过插值方法逐渐改变角色位置
        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        // 限制角色移动范围
       
        Vector2 forceDirection = Vector3.right * horizontalInput1;
        rb.AddForce(forceDirection.normalized * cspeed, ForceMode2D.Impulse);

    }


    private void MoveWithController_Joystick()
    {


        float distanceToMove = horizontalInput1_Joystick * cspeed_Joystick * 10 * Time.deltaTime;

        // 创建一个新的位置向量
        Vector3 newPosition = transform.position + new Vector3(distanceToMove, 0f, 0f);

        // 通过插值方法逐渐改变角色位置
        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        // 限制角色移动范围

        Vector2 forceDirection = Vector3.right * horizontalInput1_Joystick;
        rb.AddForce(forceDirection.normalized * cspeed_Joystick, ForceMode2D.Impulse);

    }




    private void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Current")) {
            ApplyForceTowardsPlant(other.transform);
        }

        if (other.gameObject.CompareTag("Plant")) {
            
            currentForce = 0f;
            //forceIncreaseRate = -forceIncreaseRate*20;
        }


        if (other.gameObject.CompareTag("END")) 
        {
            GameManager.iswinscene2++;
        }

    }
    private void OnTriggerExit2D(Collider2D other) {
        
        if (other.CompareTag("Plant")) {
            
            forceIncreaseRate = forceIncreaseRateTemp;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Stone"))
        {
            forceIncreaseRate = -forceIncreaseRate * 5;

        }


        if (collision.gameObject.CompareTag("Stone") && !isHit)
        {

            if (speed >= 1.2f)
            {
                audio1.playhit(3f);
                TakeDamage(2);


            }
            else if (speed >= 0.7f)
            {
                audio1.playhit(2f);
                TakeDamage(1);

            }
            isHit = true;

        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {

            forceIncreaseRate = forceIncreaseRateTemp;

        }
    }



    void ApplyForceTowardsPlant(Transform current) {
        currentforce currentForceScript = current.GetComponent<currentforce>();
        forceCurrent = currentForceScript.force;
        Vector2 forceDirection = current.up;
        GetComponent<Rigidbody2D>().AddForce(forceDirection * forceCurrent, ForceMode2D.Impulse);


    }

}
