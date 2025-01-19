using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Line : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform hookTransform; // 鱼钩的 Transform
    public Transform fishTransform; // 鱼的 Transform
    public LineRenderer lineRenderer;
    public float ropeLength;
    public float currentropeLength;
    public float fishLength;



    public float duration = 1.0f;
    private float timer = 0.0f; // 计时器
    // 颜色
    private Color startColor;
    private Color startColor2;

    // Renderer组件
    private Material lineMaterial;
    public Transform point;
    public Transform movepoint;
    private float currentSaturation;
    private float currentSaturation2;

    public Slider score;
    public Transform handTransform;
    public float sRate = 1.0f;

    public GameObject key;
    public LineRenderer lineRenderer2;

    public LineRenderer lineRenderer3;
    public GameObject up;
    public GameObject down;


    
    void Start()
    {
        // 获取 LineRenderer 组件
        timer = 0.0f;
        if (lineRenderer != null && lineRenderer.material != null)
        {
            lineMaterial = lineRenderer.materials[0];
            // 初始化起始颜色
            startColor = lineMaterial.color;
            //startColor2 = lineMaterial.GetColor("_Color2"); ;
        }
        // 设置 LineRenderer 的顶点数
        lineRenderer2.positionCount = 2;
        lineRenderer.positionCount = 2;
        lineRenderer3.positionCount = 2;
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position) * 100f;
        currentropeLength = 230f;
        score.value = 0.1f;
        currentSaturation = 0f;
        Color.RGBToHSV(lineMaterial.color, out float h, out float s, out float v);
        Color newColor = Color.HSVToRGB(0, 0, v);
        lineMaterial.color = newColor;
        lineRenderer2.materials[0].color = newColor;
        lineRenderer3.materials[0].color = newColor;
        Debug.Log(s);
        up.SetActive(false);
        down.SetActive(false);
    }

    void Update()
    {
        ropeLength = Vector2.Distance(hookTransform.position, fishTransform.position) * 100f;

        // 设置 LineRenderer 的起点和终点位置
        lineRenderer.SetPosition(0, hookTransform.position);

        lineRenderer.SetPosition(1, fishTransform.position);
        lineRenderer2.SetPosition(1, movepoint.position);
        lineRenderer2.SetPosition(0, hookTransform.position);


        lineRenderer3.SetPosition(1, movepoint.position);
        lineRenderer3.SetPosition(0, handTransform.position);
        //Debug.Log(Mathf.Abs(ropeLength - currentropeLength));
        Color originalColor = lineMaterial.color;
        Color originalColor2 = startColor2;
        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

        //Color.RGBToHSV(originalColor2, out float h2, out float s2, out float v2);
        float startSaturation = Mathf.Abs(ropeLength - currentropeLength) * 0.05f * sRate;
        //Debug.Log(currentSaturation);
        if ((Timelinescene11.isGameStart || Timelinescene1.isGameStart) && score.value < 1)
        {
            if (ropeLength - currentropeLength >= 0)
            {
                if (startSaturation > 0.18f)
                {
                    currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                    currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                    Color newColor = Color.HSVToRGB(0, currentSaturation, v);
                    //lineMaterial.SetColor("_Color1", newColor);
                    lineMaterial.color = newColor;
                    lineRenderer2.materials[0].color = newColor;
                    lineRenderer3.materials[0].color = newColor;

                    up.SetActive(true);
                    down.SetActive(false);
                }
                else
                {
                    currentSaturation = Mathf.Lerp(s, 0f, 3f * Time.deltaTime);
                    currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                    Color newColor = Color.HSVToRGB(0, currentSaturation, v);
                    //lineMaterial.SetColor("_Color1", newColor);
                    lineMaterial.color = newColor;
                    lineRenderer2.materials[0].color = newColor;
                    lineRenderer3.materials[0].color = newColor;
                    up.SetActive(false);
                    down.SetActive(false);
                }





            }
            else
            {
                if (startSaturation > 0.18f)
                {
                    currentSaturation = Mathf.Lerp(s, startSaturation, 1f * Time.deltaTime);
                    currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                    Color newColor = Color.HSVToRGB(206f / 255f, currentSaturation, v);
                    //lineMaterial.SetColor("_Color1", newColor);
                    lineMaterial.color = newColor;
                    lineRenderer2.materials[0].color = newColor;
                    lineRenderer3.materials[0].color = newColor;
                    up.SetActive(false);
                    down.SetActive(true);
                }
                else
                {
                    currentSaturation = Mathf.Lerp(s, 0f, 3f * Time.deltaTime);
                    currentSaturation = Mathf.Clamp(currentSaturation, 0f, 1f);
                    Color newColor = Color.HSVToRGB(206f / 255f, currentSaturation, v);
                    //lineMaterial.SetColor("_Color1", newColor);
                    lineMaterial.color = newColor;
                    lineRenderer2.materials[0].color = newColor;
                    lineRenderer3.materials[0].color = newColor;
                    up.SetActive(false);
                    down.SetActive(false);
                }
            }
        }







        /*if (Mathf.Abs(ropeLength - currentropeLength) >= fishLength)
        {
             currentSaturation = Mathf.Lerp(s, startSaturation * 1.3f, 10f * Time.deltaTime);
             currentSaturation2 = Mathf.Lerp(s2, 0f, 10f * Time.deltaTime);
            Color newColor = Color.HSVToRGB(h, currentSaturation, v);
            lineMaterial.SetColor("_Color1", newColor);

            Color newColor2 = Color.HSVToRGB(h2, currentSaturation2, v2);


            lineMaterial.SetColor("_Color2", newColor2);

        }
        else if (Mathf.Abs(ropeLength - currentropeLength) >= 0f && Mathf.Abs(ropeLength - currentropeLength) <fishLength)
        {
            currentSaturation = Mathf.Lerp(s, 0f, 10f * Time.deltaTime);
             currentSaturation2 = Mathf.Lerp(s2, startSaturation * 1f, 10f * Time.deltaTime);
            Color newColor = Color.HSVToRGB(h, currentSaturation, v);
            lineMaterial.SetColor("_Color1", newColor);
            Color newColor2 = Color.HSVToRGB(h2, currentSaturation2, v2);


            lineMaterial.SetColor("_Color2", newColor2);
        }*/





        // 线性插值计算当前饱和度


        //currentH = Mathf.Clamp(currentH, 8f, 55f);


        //lineMaterial.color = newColor;
        //Debug.Log("23123");
        //Debug.Log(h);






        // Debug.Log(currentSaturation);

        if (Timelinescene11.isGameStart  && score.value != 1)
        {
            if (currentSaturation <= 0.18f)
            {
                score.value += 0.0008f;

            }
            else
            {
                score.value -= 0.0006f;
            }
        }

        if (score.value >= 1)
        {
            up.SetActive(false);
            down.SetActive(false);
            key.transform.SetParent(null);
            key.transform.position = Vector3.MoveTowards(key.transform.position, point.transform.position, 1.3f * Time.deltaTime);
            if (key.transform.position == point.transform.position)
            {
                Timelinescene11.player2win = true;
            }




        }
        else if(Timelinescene11.isGameStart && score.value < 1)
        {
            if (currentSaturation >= 0.5f)

            {
                timer += Time.deltaTime;

                // 检查计时器是否达到阈值时长
                if (timer >= duration && currentSaturation >= 0.8f)
                {
                    Debug.Log("Saturation has been above the threshold for 1 second");
                    lineMaterial.color = Color.red;
                    lineRenderer2.materials[0].color = Color.red;
                    // 触发你需要的逻辑，例如重置计时器
                    //GameManager.instance.GameOver();
                    Timelinescene11.isLose = true;
                    Timelinescene11.isLose2 = true;
                    lineRenderer3.materials[0].color = Color.red;
                    timer = 0.0f;
                    if (GameManager.instance.scenename == "1.1")
                    {
                        lineRenderer.enabled = false;
                    }
                    up.SetActive(false);
                    down.SetActive(false);



                }
                else
                {
                    // 如果条件不再满足，重置计时器
                    //timer = 0.0f;
                }
            }

        }














    }


    public void dis()
    {
        lineRenderer.SetPosition(0, hookTransform.position);
    }
    public void dontdis()
    {
        lineRenderer.SetPosition(0, fishTransform.position);
    }
}
