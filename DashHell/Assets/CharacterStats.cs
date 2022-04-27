using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[CreateAssetMenu(fileName = "newCharacter", menuName = "GameData/Character")]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    public int[] inventory;
    public float maxHealth;
    public float maxCharge; //for dash length decision
    public float maxDashLength;//might not need
    public Image image;

    [Header("Starting Settings")]
    [SerializeField] float startingHealth;
    [SerializeField] float startingCharge;//should be 0, charge goes up for as long as a button is pressed

    [ExecuteInEditMode]
    public void Awake()
    {
        maxHealth = startingHealth;
        maxCharge = 100f;
        startingCharge = 0f;
    }
}
