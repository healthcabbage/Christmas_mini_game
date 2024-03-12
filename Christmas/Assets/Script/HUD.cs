using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public enum InfoType { Score, Hp, Dash}
    public InfoType type;

    TMP_Text mytext;
    Image[] image;


    void Awake()
    {
        mytext = GetComponent<TMP_Text>();
        image = GetComponentsInChildren<Image>();
    }

    void LateUpdate()
    {
        switch(type)
        {
            case InfoType.Score:
                mytext.text = GameManager.instance.score.ToString();
                break;
            case InfoType.Hp:
                if (GameManager.instance.hp == 2)
                {
                    image[2].enabled = false;
                }
                else if (GameManager.instance.hp == 1)
                {
                    image[1].enabled = false;
                }
                else if (GameManager.instance.hp == 0)
                {
                    image[0].enabled = false;
                }

                if (GameManager.instance.hp == 3)
                {
                    image[2].enabled = true;
                }
                else if (GameManager.instance.hp == 2)
                {
                    image[1].enabled = true;
                }
                else if (GameManager.instance.hp == 1)
                {
                    image[0].enabled = true;
                }
                break;
            case InfoType.Dash:
                switch(GameManager.instance.stack)
                {
                    case 0:
                        if (image[0].enabled == true)
                            for (int i = 0; i < 5; i++)
                            {
                                image[i].enabled = false;
                            }
                        break;
                    case 1:
                        image[0].enabled = true;
                        break;
                    case 2:
                        image[1].enabled = true;
                        break;
                    case 3:
                        image[2].enabled = true;
                        break;
                    case 4:
                        image[3].enabled = true;
                        break;
                    case 5:
                        image[4].enabled = true;
                        break;
                }
                break;
        }
    }


}
