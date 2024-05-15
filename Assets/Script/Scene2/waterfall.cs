using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterfall : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // Ŀ������
    public float forceMultiplier = 1f; // ���ı���

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")) // �������������
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null && target != null)
            {
                Vector2 direction = target.position - other.transform.position;
                float distance = direction.magnitude;
                direction.Normalize();
                rb.AddForce(direction * forceMultiplier / distance, ForceMode2D.Impulse);
                //Debug.Log("11");
            }
        }
    }
}
