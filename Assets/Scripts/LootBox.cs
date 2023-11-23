using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    // Chest Drop rate variables
    public int WoodDropRate; 
    private float WoodChance;
    public int BronzeDropRate; 
    private float BronzeChance;
    public int SilverDropRate; 
    private float SilverChance;
    public int GoldDropRate;
    private float GoldChance;
    public int PlatinumDropRate; 
    private float PlatinumChance;
    // Loot Drop rate Variables
    public float commonChance;
    public float uncommonChance;
    public float rareChance;
    public float epicChance;
    public float legendaryChance;
    public float uniqueChance;
    [Header("Rarity")]
    [SerializeField]
    private List<string> LootRarity;
    [Header("Wood Chance")]
    public float[] WLootChance = new float[6];
    [Header("Bronze Chance")]
    public float[] BLootChance = new float[6];
    [Header("Silver Chance")]
    public float[] SLootChance = new float[6];
    [Header("Gold Chance")]
    public float[] GLootChance = new float[6];
    [Header("Platinum Chance")]
    public float[] PLootChance = new float[6];
    private string ChestOutput;
    private string RarityOutput;
    private int ChestRoll;
    private int RarityRoll;
    
    // Start is called before the first frame update
    void Start()
    {
        SetChestList();
        SetRarityList();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GetChestOutput();
        }
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
    void GetChestOutput()
    {
        ChestRoll = Random.Range(0,100);
        RarityRoll = Random.Range(0,100);
        Debug.Log("Chest Roll = " + ChestRoll);
        Debug.Log("Rarity roll = " + RarityRoll);
        ChancePercent();
        RollChest();
        RollLoot(ChestOutput);
        SetHUDText();
    }
    void RollChest()
    {
        if(ChestRoll <= WoodChance)
        {
            ChestOutput = ChestTypes[0];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= BronzeChance && ChestRoll > WoodChance)
        {
            ChestOutput = ChestTypes[1];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= SilverChance && ChestRoll > BronzeChance)
        {
            ChestOutput = ChestTypes[2];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= GoldChance && ChestRoll > SilverChance)
        {
            ChestOutput = ChestTypes[3];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= PlatinumChance && ChestRoll > GoldChance)
        {
            ChestOutput = ChestTypes[4];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
    }
    void RollLoot(string ChestType)
    {
        if(ChestType == "Wood")
        {
            commonChance = WLootChance[0];
            uncommonChance = commonChance + WLootChance[1];
            rareChance = uncommonChance + WLootChance[2];
            epicChance = rareChance + WLootChance[3];
            legendaryChance = epicChance + WLootChance[4];
            uniqueChance = WLootChance[5];
            if(RarityRoll <= commonChance)
            {
                RarityOutput = LootRarity[0];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uncommonChance && RarityRoll > commonChance)
            {
                RarityOutput = LootRarity[1];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= rareChance && RarityRoll > uncommonChance)
            {
                RarityOutput = LootRarity[2];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= epicChance && RarityRoll > rareChance)
            {
                RarityOutput = LootRarity[3];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= legendaryChance && RarityRoll > epicChance)
            {
                RarityOutput = LootRarity[4];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uniqueChance)
            {
                RarityOutput = LootRarity[5];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
        }
        if(ChestType == "Bronze")
        {
            commonChance = BLootChance[0];
            uncommonChance = commonChance + BLootChance[1];
            rareChance = uncommonChance + BLootChance[2];
            epicChance = rareChance + BLootChance[3];
            legendaryChance = epicChance + BLootChance[4];
            uniqueChance = legendaryChance + BLootChance[5];
            if(RarityRoll <= commonChance)
            {
                RarityOutput = LootRarity[0];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uncommonChance && RarityRoll > commonChance)
            {
                RarityOutput = LootRarity[1];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= rareChance && RarityRoll > uncommonChance)
            {
                RarityOutput = LootRarity[2];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= epicChance && RarityRoll > rareChance)
            {
                RarityOutput = LootRarity[3];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= legendaryChance && RarityRoll > epicChance)
            {
                RarityOutput = LootRarity[4];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uniqueChance)
            {
                RarityOutput = LootRarity[5];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
        }
        if(ChestType == "Silver")
        {
            commonChance = SLootChance[0];
            uncommonChance = commonChance + SLootChance[1];
            rareChance = uncommonChance + SLootChance[2];
            epicChance = rareChance + SLootChance[3];
            legendaryChance = epicChance + SLootChance[4];
            uniqueChance = legendaryChance + SLootChance[5];
            if(RarityRoll <= commonChance)
            {
                RarityOutput = LootRarity[0];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uncommonChance && RarityRoll > commonChance)
            {
                RarityOutput = LootRarity[1];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= rareChance && RarityRoll > uncommonChance)
            {
                RarityOutput = LootRarity[2];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= epicChance && RarityRoll > rareChance)
            {
                RarityOutput = LootRarity[3];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= legendaryChance && RarityRoll > epicChance)
            {
                RarityOutput = LootRarity[4];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uniqueChance)
            {
                RarityOutput = LootRarity[5];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
        }
        if(ChestType == "Gold")
        {
            commonChance = GLootChance[0];
            uncommonChance = commonChance + GLootChance[1];
            rareChance = uncommonChance + GLootChance[2];
            epicChance = rareChance + GLootChance[3];
            legendaryChance = epicChance + GLootChance[4];
            uniqueChance = legendaryChance + GLootChance[5];
            if(RarityRoll <= commonChance)
            {
                RarityOutput = LootRarity[0];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uncommonChance && RarityRoll > commonChance)
            {
                RarityOutput = LootRarity[1];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= rareChance && RarityRoll > uncommonChance)
            {
                RarityOutput = LootRarity[2];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= epicChance && RarityRoll > rareChance)
            {
                RarityOutput = LootRarity[3];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= legendaryChance && RarityRoll > epicChance)
            {
                RarityOutput = LootRarity[4];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uniqueChance)
            {
                RarityOutput = LootRarity[5];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
        }
        if(ChestType == "Platinum")
        {
            commonChance = PLootChance[0];
            uncommonChance = commonChance + PLootChance[1];
            rareChance = uncommonChance + PLootChance[2];
            epicChance = rareChance + PLootChance[3];
            legendaryChance = epicChance + PLootChance[4];
            uniqueChance = legendaryChance + PLootChance[5];
            if(RarityRoll <= commonChance)
            {
                RarityOutput = LootRarity[0];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uncommonChance && RarityRoll > commonChance)
            {
                RarityOutput = LootRarity[1];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= rareChance && RarityRoll > uncommonChance)
            {
                RarityOutput = LootRarity[2];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= epicChance && RarityRoll > rareChance)
            {
                RarityOutput = LootRarity[3];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= legendaryChance && RarityRoll > epicChance)
            {
                RarityOutput = LootRarity[4];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
            if(RarityRoll <= uniqueChance)
            {
                RarityOutput = LootRarity[5];
                Debug.Log("Loot Rarity:" + RarityOutput);
                return;
            }
        }
    }
    void ChancePercent()
    {
        WoodChance = WoodDropRate;
        //Debug.Log(WoodChance);
        BronzeChance = WoodChance + BronzeDropRate;
        //Debug.Log(BronzeChance);
        SilverChance = BronzeChance + SilverDropRate;
        //Debug.Log(SilverChance);
        GoldChance = SilverChance + GoldDropRate;
        //Debug.Log(GoldChance);
        PlatinumChance = GoldChance + PlatinumDropRate;
        //Debug.Log(PlatinumChance);
    }
    void SetHUDText()
    {
        HUDText.text = string.Format("You got a {0} item from a {1} Chest.",RarityOutput, ChestOutput);
    }
}
