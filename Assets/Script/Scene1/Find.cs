using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Find : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;
    private Color startColor;
    public float Rate;
    private float startSaturation = 0f;
    private float currentSaturation = 0f;
    private bool isFind = true;

    public static bool isMoving;
    public static bool isDiging;
   
    void Start()
    {
        startColor = spriteRenderer.material.color;
       
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Timelinescene11.isGameStart&& Timelinescene11.isLose== false)
        {
            if (isFind && isMoving && !Timelinescene11.player1win)
            {

                if (!isDiging)
                {
                    if (currentSaturation <= 0.9f)
                    {
                        Color originalColor = spriteRenderer.material.color;

                        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                        startSaturation += Rate*0.3f;
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
                        Timelinescene11.isLose1 = true;
                        Timelinescene11.isLose = true;
                    }
                }
                else
                {
                    if (currentSaturation <= 0.9f)
                    {
                        Color originalColor = spriteRenderer.material.color;

                        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                        startSaturation += Rate * 5f;
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
                        Timelinescene11.isLose1 = true;
                        Timelinescene11.isLose = true;

                    }
                }



            }
            else
            {

                Color originalColor = spriteRenderer.material.color;

                Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                startSaturation -= Rate *1.5f;
                startSaturation = Mathf.Clamp(startSaturation, 0f, 1f);
                currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                Color newColor = Color.HSVToRGB(48f / 255f, currentSaturation, v);

                spriteRenderer.material.color = newColor;





            }

        }



        if (Timelinescene11.isLose == true)
        {
            spriteRenderer.material.color = Color.red;
        }


















    }

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("2");
        if (other.gameObject.CompareTag("Player")) {
            isFind = true;
            //Debug.Log("1");
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        //Debug.Log("2");
        if (other.gameObject.CompareTag("Player")) {
            isFind = true;
            //Debug.Log("1");
        }



    }

    private void OnTriggerExit2D(Collider2D other) {
        //Debug.Log("2");
        if (other.gameObject.CompareTag("Player")) {
            isFind = false;
            //Debug.Log("1");
        }



    }






}
