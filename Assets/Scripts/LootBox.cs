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
    public int WoodDropRate; //% Chance
    private int WoodChance;
    public int BronzeDropRate; //% Chance
    private int BronzeChance;
    public int SilverDropRate; //% Chance
    private int SilverChance;
    public int GoldDropRate; //% Chance
    private int GoldChance;
    public int PlatinumDropRate; //% Chance
    private int PlatinumChance;
    private int ChestTotalRate;
    private int ChestLength;
    [Header("Rarity")]
    [SerializeField]
    private List<string> LootRarity;
    [Header("Wood Chance")]
    public int[] WLootChance = new int[6];
    [Header("Bronze Chance")]
    public int[] BLootChance = new int[6];
    [Header("Silver Chance")]
    public int[] SLootChance = new int[6];
    [Header("Gold Chance")]
    public int[] GLootChance = new int[6];
    [Header("Platinum Chance")]
    public int[] PLootChance = new int[6];
    private int RarityLength;
    private string ChestOutput;
    private string RarityOutput;
    private int ChestRoll;
    private int RarityRoll;
    
    // Start is called before the first frame update
    void Start()
    {
        SetChestList();
        SetRarityList();
        ChestLength = ChestTypes.Count;
        RarityLength = LootRarity.Count;
        GetChestOutput();
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
    void GetChestOutput()
    {
        ChestRoll = Random.Range(0,100);
        RarityRoll = Random.Range(0,100);
        Debug.Log("Chest Roll = " + ChestRoll);
        Debug.Log("Rarity roll = " + RarityRoll);
        ChancePercent();
        RollChest();
    }
    void RollChest()
    {
        if(ChestRoll <= WoodChance)
        {
            ChestOutput = ChestTypes[0];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= BronzeChance)
        {
            ChestOutput = ChestTypes[1];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= SilverDropRate)
        {
            ChestOutput = ChestTypes[2];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= GoldDropRate)
        {
            ChestOutput = ChestTypes[3];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
        if(ChestRoll <= PlatinumDropRate)
        {
            ChestOutput = ChestTypes[4];
            Debug.Log("Chest Type:" + ChestOutput);
            return;
        }
    }
    void RollLoot()
    {

    }
    void ChancePercent()
    {
        ChestTotalRate = WoodDropRate + BronzeDropRate + SilverDropRate + GoldDropRate + PlatinumDropRate;
        WoodChance = WoodDropRate / ChestTotalRate*100;
        Debug.Log("Wood Chance = " + WoodDropRate);
        BronzeChance = BronzeDropRate / ChestTotalRate*100;
        BronzeChance += WoodChance;
        Debug.Log("Bronze Chance = " + BronzeDropRate);
        SilverChance = SilverDropRate / ChestTotalRate*100;
        SilverChance += BronzeChance;
        Debug.Log("Silver Chance = " + SilverDropRate);
        GoldChance = GoldDropRate / ChestTotalRate*100;
        GoldChance += SilverChance;
        Debug.Log("Gold Chance = " + GoldDropRate);
        PlatinumChance = PlatinumDropRate / ChestTotalRate*100;
        PlatinumChance += GoldChance;
        Debug.Log("Platinum Chance = " + PlatinumDropRate);
    }
}
