using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptble Object/Data")]
public class GameData : ScriptableObject
{
    //�� �ŷ� ȭ��
    [Header("# Star")]
    public float star;

    //���� ������Ʈ ����
    [Header("# Object buy check")]
    public bool isfloor;    //�ٴ�
    public bool iswallpaper;    //����
    public bool isTree;     //ũ�������� ���� Ʈ��
    public bool iswindow;   //â��
    public bool isgiftbox;  // ���� ����
    public bool iscurtain;  //Ŀư
    public bool issofa; //����
    public bool ismat;  //��Ʈ
    
    [Header("# Character imange change")]
    public int isemotion;

    public enum color
    {
        Unknown,
        Red,
        Blue,
        Yellow
    }

    [Header("# Object color check")]
    public color isfloorcolor;
    public color iswallpapercolor;
    public color isTreecolor;
    public color iswindowcolor;
    public color isgiftboxcolor;
    public color iscurtaincolor;
    public color issofacolor;
    public color ismatcolor;
    
    [Header("# story check")]
    public bool isfirststory;                 // ù Start���� Story�� �ѹ��� ���Եǰ� �ϱ�
    public bool isRoom_story;                 // Room�� ó�� ���丮 ���� üũ
    public bool isending_story;               // ���� üũ
    public bool isshop_story;               //shop���� ù ���Դ�� üũ

    [Header("# Sound Save")]
    public float bgm_save_volume;
    public float sfx_save_volume;

    [Header("# Story text")]
    public string[] RoomTutorial_text;  //ó�� Room ���� ������ �� ��µǴ� �ؽ�Ʈ
    public string[] Story_text;             //ù ���� ���丮
    public string[] Shop_First_Story;   //���� ó�� ������ ȯ���λ� �ؽ�Ʈ
    public string[] Shop_Event;         //���� ���Խ� ������ ���� ����
    public string[] Ending_text;        //���� ���丮

    [Header("# Story Image")]
    public Sprite[] Player;             // �÷��̾� �̹���
    public Sprite[] ShopNpc;        // ���� Npc �̹���
    public Sprite[] FirstStory_Image;   //Ʃ�丮�� �̹���
    public Sprite[] Ending_Image;       //  ���� �̹���
}
