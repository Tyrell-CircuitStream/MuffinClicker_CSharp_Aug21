using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOverTime : MonoBehaviour
{
    private float speed;

    [SerializeField] private float minRotSpeed = -45f;
    [SerializeField] private float maxRotSpeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minRotSpeed, maxRotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
