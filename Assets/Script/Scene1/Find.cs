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
      

        if (isFind && isMoving) {

            if (! isDiging) {
                if (currentSaturation <= 0.95f) {
                    Color originalColor = startColor;

                    Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                    startSaturation += Rate;
                    startSaturation = Mathf.Clamp(startSaturation, 0f, 50f);

                    currentSaturation = Mathf.Lerp(s, startSaturation, 10f * Time.deltaTime);
                    currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                    Color newColor = Color.HSVToRGB(h, currentSaturation, v);

                    spriteRenderer.material.color = newColor;


                }
                else {
                    //spriteRenderer.material.color = Color.red;
                    Debug.Log("LOSE");
                    //GameManager.instance.GameOver();
                }
            }
            else {
                if (currentSaturation <= 0.95f) {
                    Color originalColor = startColor;

                    Color.RGBToHSV(originalColor, out float h, out float s, out float v);

                    startSaturation += Rate*5;
                    startSaturation = Mathf.Clamp(startSaturation, 0f, 50f);

                    currentSaturation = Mathf.Lerp(s, startSaturation, 10f * Time.deltaTime);
                    currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                    Color newColor = Color.HSVToRGB(h, currentSaturation, v);

                    spriteRenderer.material.color = newColor;


                }
                else {
                    //spriteRenderer.material.color = Color.red;
                    Debug.Log("LOSE");
                    //GameManager.instance.GameOver();
                }
            }



        }
       else {

            Color originalColor = startColor;

            Color.RGBToHSV(originalColor, out float h, out float s, out float v);

            startSaturation -= Rate * 2f;
            startSaturation = Mathf.Clamp(startSaturation, 0f, 50f);
            currentSaturation = Mathf.Lerp(s, startSaturation, 10f * Time.deltaTime);
            currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
            Color newColor = Color.HSVToRGB(h, currentSaturation, v);

            spriteRenderer.material.color = newColor;





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
