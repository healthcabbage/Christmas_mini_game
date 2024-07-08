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
    [Header("# Object")]
    public bool isfloor;
    public bool isTree;
    public bool iswindow;
    public bool isgiftbox;
    public bool iscurtain;
    public bool issofa;
    public int isemotion;

    [Header("# text check")]
    public bool istutorial;

}
