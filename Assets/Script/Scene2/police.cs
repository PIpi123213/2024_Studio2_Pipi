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



    public float wanderRadius = 10f; // �뾶��Χ������ƶ�
    public float wanderTimer = 5f; // �ƶ���һ�����ʱ��
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
        // ��������������� Collider2D ���
        foreach (Collider2D collider in childColliders)
        {
            // ȷ��������� Collider2D �������Ϊ trigger
            if (collider.isTrigger)
            {
                // ������������ײ��ⷽ��
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
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // ���� Y ��������ָ��Ŀ�귽��

        float rotationSpeed = Quaternion.Angle(transform.rotation, targetRotation) / rotationDuration; // ������ת�ٶ�
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
            // ��ȡ�������ϵ� police �ű�
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
