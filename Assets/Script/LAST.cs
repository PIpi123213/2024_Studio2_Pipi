using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LAST : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider1;
    public Slider slider2;

  
    public float speedRate = 1000f;
   

    private float leftforce = 0f;
  
    private float rightforce = 0f;

    public LoadScene scene;
    public float speedRate_Joystick = 4f;
    private float rspeedRate_Joystick = 4f;


    private float leftforce_Joystick = 0f;
 
    private float rightforce_Joystick = 0f;


    private bool isready1 = false;
    private bool isready2 = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        leftforce_Joystick = input11.speed * 0.9f / speedRate_Joystick;
       
        rightforce_Joystick = input11.speed2 / speedRate_Joystick;
     





        leftforce = arduino123.speed / speedRate;
        rightforce = arduino123.speed2 / speedRate;
    













        if (slider1.value < 1f)
        {
            slider1.value = slider1.value + (leftforce * 20f / speedRate) + (leftforce_Joystick * 20f / speedRate_Joystick) * Time.deltaTime;

        }
        else
        {
            if (!isready1)
            {
                
                isready1 = true;
            }



        }

        if (slider2.value < 1f)
        {
            slider2.value = slider2.value + (rightforce * 20f / speedRate) + (rightforce_Joystick * 20f / speedRate_Joystick) * Time.deltaTime;

        }
        else
        {
            if (!isready2)
            {
                
                isready2 = true;
            }



        }
        if (isready1&&isready2)
        {
            scene.SwitchToScene("0");




        }







    }
    





   
}
