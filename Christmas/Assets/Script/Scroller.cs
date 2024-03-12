using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public int count;

    void Start()
    {
        count = transform.childCount;
        
    }

    void Update()
    {
        if (GameManager.instance.isPlay)
            transform.Translate(GameManager.instance.gameSpeed * Time.deltaTime * -1f, 0, 0);
    }
}
