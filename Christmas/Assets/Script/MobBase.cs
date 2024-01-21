using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed = 0;
    public Vector3 StartPosition;

    void OnEnable()
    {
        transform.position = StartPosition;
    }

    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * mobSpeed);

        if (transform.position.x < -11)
        {
            if (gameObject.activeSelf == true)
                gameObject.SetActive(false);
        }
    }

}
