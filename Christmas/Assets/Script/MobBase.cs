using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public Vector3 StartPosition;

    void OnEnable()
    {
        transform.position = StartPosition;
    }

    void Update()
    {
        if (GameManager.instance.isPlay)
        {
            transform.Translate(Vector3.left * Time.deltaTime * GameManager.instance.mobSpeed);

            if (transform.position.x < -11)
            {
                if (gameObject.activeSelf == true)
                    gameObject.SetActive(false);
            }
        }
    }

}
