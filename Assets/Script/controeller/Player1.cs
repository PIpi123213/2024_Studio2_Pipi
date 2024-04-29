using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float minX, maxX, minY, maxY;
    public float moveSpeed = 10f;
    public static float horizontalInput1;
    public static float cspeed;
    public float smoothness = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //MoveWithMouse();
        //MoveWithKeyboard();
        MoveWithController();
    }

    
    private void Move()
    {
        var dx = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var dy = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var x = Mathf.Clamp(transform.position.x, minX, maxX);
        var y = Mathf.Clamp(transform.position.y, minY, maxY);

        var nx = x + dx;
        var ny = y + dy;

        transform.position = new Vector3(nx, ny);
    }

    private void MoveWithMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        var clampedX = Mathf.Clamp(mousePosition.x, minX, maxX);
        var clampedY = Mathf.Clamp(mousePosition.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
    private void MoveWithKeyboard() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }

    private void MoveWithController() {
        float verticalInput = Input.GetAxis("Vertical");
        float distanceToMove = horizontalInput1 * cspeed *10  * Time.deltaTime;

        // 创建一个新的位置向量
        Vector3 newPosition = transform.position + new Vector3(distanceToMove, 0f, 0f);

        // 通过插值方法逐渐改变角色位置
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        // 限制角色移动范围
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    }
    private void MoveWithController2() {
        float verticalInput = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(horizontalInput1, 0f, 0f) * cspeed * Time.deltaTime;
        // transform.Translate(distanceToMove, 0f, 0f);
        //transform.Translate(movement);
        //UnityEngine.Debug.Log("Horizontal Input: " + horizontalInput1 + ", Speed: " + cspeed);

        //transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        float distanceToMove = horizontalInput1 * cspeed / 8 * Time.deltaTime;

        // 创建一个新的位置向量
        Vector3 newPosition = transform.position + new Vector3(distanceToMove, 0f, 0f);

        // 通过插值方法逐渐改变角色位置
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * smoothness);
        // 限制角色移动范围
        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
     
    }
}
