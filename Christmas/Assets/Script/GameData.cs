using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptble Object/Data")]
public class GameData : ScriptableObject
{
    //샵 거래 화폐
    [Header("# Star")]
    public float star;

    //상점 오브젝트 구매
    [Header("# Object buy check")]
    public bool isfloor;    //바닥
    public bool iswallpaper;    //벽지
    public bool isTree;     //크리스마스 나무 트리
    public bool iswindow;   //창문
    public bool isgiftbox;  // 선물 상자
    public bool iscurtain;  //커튼
    public bool issofa; //쇼파
    public bool ismat;  //매트
    
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
    public bool isfirststory;                 // 첫 Start에서 Story로 한번만 진입되게 하기
    public bool isRoom_story;                 // Room에 처음 스토리 진행 체크
    public bool isending_story;               // 엔딩 체크
    public bool isshop_story;               //shop에서 첫 진입대사 체크

    [Header("# Sound Save")]
    public float bgm_save_volume;
    public float sfx_save_volume;

    [Header("# Story text")]
    public string[] RoomTutorial_text;  //처음 Room 씬에 들어왔을 때 출력되는 텍스트
    public string[] Story_text;             //첫 시작 스토리
    public string[] Shop_First_Story;   //샵에 처음 들어오면 환영인사 텍스트
    public string[] Shop_Event;         //상점 진입시 나오는 랜덤 대사들
    public string[] Ending_text;        //엔딩 스토리

    [Header("# Story Image")]
    public Sprite[] Player;             // 플레이어 이미지
    public Sprite[] ShopNpc;        // 상점 Npc 이미지
    public Sprite[] FirstStory_Image;   //튜토리얼 이미지
    public Sprite[] Ending_Image;       //  엔딩 이미지
}
