using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewItem",menuName ="Items/New Item"),System.Serializable]
public class Item :ScriptableObject{

    public new string name = "New Item";
    [SerializeField]
    public Sprite icon = null;
    public float goldMult;
    public bool isSword;
    public int succesModifier;
}
