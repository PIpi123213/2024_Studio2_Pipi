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
        if (Timelinescene11.isGameStart)
        {
            if (isFind && isMoving && Timelinescene11.isWin_scene1!=2)
            {

                if (!isDiging)
                {
                    if (currentSaturation <= 0.95f)
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
                    }
                }
                else
                {
                    if (currentSaturation <= 0.95f)
                    {
                        Color originalColor = spriteRenderer.material.color;

                        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                        startSaturation += Rate * 3f;
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
