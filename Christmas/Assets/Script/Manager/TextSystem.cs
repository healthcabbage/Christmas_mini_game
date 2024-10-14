using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using KoreanTyper;

public class TextSystem : MonoBehaviour
{
    public string originText;
    public TMP_Text Text;
    public IEnumerator TypingRoutine(TMP_Text w_text)
    {
        int typingLength = originText.GetTypingLength();

        for (int index = 0; index <= typingLength; index++)
        {
            w_text.text = originText.Typing(index);
            yield return new WaitForSeconds(0.01f);
        }
    }

    void RoomTutorial(int tuto_num)
    {
        switch(tuto_num)
        {

        }
    }

}
