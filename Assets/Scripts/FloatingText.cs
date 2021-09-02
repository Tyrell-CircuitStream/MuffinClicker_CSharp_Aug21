using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float speed;
    public float lifetime = 3;

    private TMP_Text floatingText;
    private Color initalColor;

    private float age = 0;

    public float tValue;
    // Start is called before the first frame update
    void Start()
    {
        floatingText = GetComponent<TMP_Text>();
        initalColor = floatingText.color;
    }

    // Update is called once per frame
    void Update()
    {
        //spinLights[i].Rotate(0, 0, spinLightSpeeds[i] *  Time.deltaTime);

        transform.Translate(0, speed * Time.deltaTime, 0);

        age += Time.deltaTime;

        floatingText.color = Color.Lerp(initalColor, Color.clear, age / lifetime);

        if (age > lifetime)
        {
            Destroy(gameObject);
        }
    }
}
