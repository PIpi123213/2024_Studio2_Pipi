using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class police : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    private UnityEngine.AI.NavMeshAgent agent;
    private Collider2D[] childColliders;
    private AudioPolice audioPolice;



    public float wanderRadius = 10f; // 半径范围内随机移动
    public float wanderTimer = 5f; // 移动到一个点的时间
    private float timer;

    private bool ischase = false;


    private SpriteRenderer spriteRenderer;
    

    public float rotationDuration = 1f;
    private GameObject childObject;

    void Start()
    {
        Transform childTransform = transform.Find("effectLight");
        childObject = childTransform.gameObject;

        audioPolice = GetComponent<AudioPolice>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        childColliders = GetComponentsInChildren<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 遍历所有子物体的 Collider2D 组件
        foreach (Collider2D collider in childColliders)
        {
            // 确保子物体的 Collider2D 组件设置为 trigger
            if (collider.isTrigger)
            {
                // 添加子物体的碰撞监测方法
                collider.gameObject.AddComponent<ChildTriggerHandler>();
            }
        }


        timer = wanderTimer;

    }

    // Update is called once per frame
    void Update()
    {
        if (!waterfall.iswin)
        {

            if (ischase)
            {
                agent.SetDestination(target.position);

                RotateTowards(target.position);
                audioPolice.playAudio();
                childObject.SetActive(true);
            }
            else
            {
                timer += Time.deltaTime;

                if (timer >= wanderTimer)
                {
                    Vector2 newPos = RandomNavSphere(transform.position, wanderRadius);
                    agent.SetDestination(new Vector3(newPos.x, newPos.y, transform.position.z));
                    timer = 0;
                }
                audioPolice.stopAudio();
                RotateTowards(agent.destination);
                childObject.SetActive(false);
            }
        }

       


    }

    private void RotateTowards(Vector3 target)
    {
        Vector2 direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // 调整 Y 轴正方向指向目标方向

        float rotationSpeed = Quaternion.Angle(transform.rotation, targetRotation) / rotationDuration; // 计算旋转速度
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }



    public static Vector2 RandomNavSphere(Vector2 origin, float dist)
    {
        Vector2 randDirection = Random.insideUnitCircle * dist;
        randDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(new Vector3(randDirection.x, randDirection.y, 0), out navHit, dist, NavMesh.AllAreas);

        return new Vector2(navHit.position.x, navHit.position.y);
    }

    public class ChildTriggerHandler : MonoBehaviour
    {
        private police parentPoliceScript;
        void Start()
        {
            // 获取父对象上的 police 脚本
            parentPoliceScript = GetComponentInParent<police>();
            if (parentPoliceScript == null)
            {
                Debug.LogError("Parent object does not have a police script attached.");
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                parentPoliceScript.ischase = true;
            }
            
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                parentPoliceScript.ischase = false;
            }
        }
    }




}
