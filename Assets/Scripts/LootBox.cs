using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LootBox : MonoBehaviour
{
    [Header("HUD")]
    public TextMeshProUGUI HUDText;
    [Header("Chests")]
    [SerializeField]
    private List<string> ChestTypes;
    private int ChestLength;
    [Header("Rarity")]
    [SerializeField]
    private List<string> LootRarity;
    private int RarityLength;
    // Start is called before the first frame update
    void Start()
    {
        SetChestList();
        SetRarityList();
        ChestLength = ChestTypes.Count;
        RarityLength = LootRarity.Count;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SetChestList()
    {
        ChestTypes.Clear();
        ChestTypes.Add("Wood");
        ChestTypes.Add("Bronze");
        ChestTypes.Add("Silver");
        ChestTypes.Add("Gold");
        ChestTypes.Add("Platinum");
    }
    void SetRarityList()
    {
        LootRarity.Clear();
        LootRarity.Add("Common");
        LootRarity.Add("Uncommon");
        LootRarity.Add("Rare");
        LootRarity.Add("Epic");
        LootRarity.Add("Legendary");
        LootRarity.Add("Unique");
    }
}
