using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public float scoreRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("2");
        if (other.gameObject.CompareTag("Hand"))     
        {
            slider.value += scoreRate;
            //Debug.Log("1");
        }

      

    }

















}
