using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treat : MonoBehaviour
{
    public int pointsPerClick = 50;
    public GameManager gameManager;

    private Vector3 startScale;

    private float scaleDuration = 2f;


    public float minDuration, maxDuration;
    public float minScale, maxScale;
    public float minSpeed, maxSpeed;
    public float minRotSpeed, maxRotSpeed;

    private float currentTime = 0;
    private float tValue;

    private Vector3 dir;
    private float speed;
    private float rotSpeed;

    private void Start()
    {
        transform.localScale =  Vector3.one * Random.Range(minScale, maxScale);
        startScale = transform.localScale;

        speed = Random.Range(minSpeed, maxSpeed);
        dir = Random.insideUnitCircle;

        scaleDuration = Random.Range(minDuration, maxDuration);

        rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);

    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(startScale, Vector3.zero, currentTime);

        currentTime += Time.deltaTime / scaleDuration;


        transform.position += dir * speed * Time.deltaTime;

        transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

        if (currentTime > scaleDuration)
        {
            Destroy(gameObject);
        }
    }

    public void OnTreatClicked()
    {
        gameManager.TreatClicked(pointsPerClick);
        Destroy(gameObject);
    }
}
