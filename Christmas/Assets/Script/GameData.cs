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
