using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    //hp
    private static int hp = 30;
    public static int takeDmgMult = 1;
    public static int maxHp = 30;
    public static Text hpText;
    public static GameObject healthBar;



    //dmg
    private static int dmg = 5;
    public static int dmgAdd = 0;
    public static int dmgMult = 1;
    public static Text dmgText;
    //coins
    public static int coins = 0;
    public Text coinsText;

    //Skills
    public static int numsOfSlots = 3;
    public static Skill[] ActiveItemsSlots = new Skill[numsOfSlots];

    //openTiles
    public static int openTiles = 0;
    public static bool openBlock;
    public static int maxOpenTiles = 3;
    public static int currentTiles = 0;
    public static bool isAnyTileExist = true;
    public static Text currenTilesText;
    public static Text openTilesText;

    //XP and lvl
    private static int XP = 0;
    private static int lvlUpXP = 100;
    public static int lvl = 1;
    public static Tile lvlUpPan;
    public static Text XPtext;
    private void Start()
    {
       // XPtext = GameObject.Find("XPtext").GetComponent<Text>();
        healthBar = GameObject.Find("HealthBarGO");
        openTilesText = GameObject.Find("OpenTilesText").GetComponent<Text>();
        currenTilesText = GameObject.Find("CurrentTilesText").GetComponent<Text>();
        hpText = GameObject.Find("PlayerHp").GetComponent<Text>();
        dmgText = GameObject.Find("DmgText").GetComponent<Text>();
        hpText.text = "HP " + hp.ToString() + "/" + maxHp.ToString();
       // XPtext.text = XP.ToString() + "/" + lvlUpXP.ToString();
        dmgText.text = "DMG " + dmg.ToString();
        OpenTilesCheck();
    }

    public static void TakeDamage(int dmg)
    {
        hp -= dmg * takeDmgMult;
        HpCheck();
    }
    public static void Heal(int heal)
    {
        hp += heal;
        HpCheck();
    }
    public static int DealDamage(int hp)
    {
        hp -= dmg * dmgMult;
        return hp;
    }
    private static void HpCheck()
    {
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (hp <= 0)
        {
            print("dead");
            ResetAllStats();
            SceneChanger.LoseMenuLoad();
        }
        hpText.text = hp.ToString() + "/" + maxHp.ToString();
        float hpFloat = (float)hp;
        float maxHpFloat = (float)maxHp;
        float hpScale = hpFloat / maxHpFloat;
        healthBar.transform.localScale = new Vector3(hpScale, 1.0f);
    }
    public static void OpenTilesCheck()
    {
        openTiles = 0;
        currentTiles = 0;
        for (int i = 0; i < TileMap.tiles.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < TileMap.tiles.GetUpperBound(1) + 1; j++)
            {
                try
                {
                    if (TileMap.tiles[i, j] != null)
                    {
                        isAnyTileExist = true;
                        currentTiles++;
                        if (!TileMap.tiles[i, j].isUnknown)
                            openTiles++;
                    }
                }
                catch { }
            }
        }

        if (openTiles >= maxOpenTiles)
            openBlock = true;
        if (openTiles < maxOpenTiles)
            openBlock = false;
        currenTilesText.text = "total tiles " + currentTiles.ToString();
        openTilesText.text = "open tiles " + openTiles.ToString();
    }

    public static void AddItemOnSlot(Skill itemGO)
    {
        for (int i = 0; i < ActiveItemsSlots.Length; i++)
        {
            if (ActiveItemsSlots[i] == null)
            {
                ActiveItemsSlots[i] = itemGO;
                ActiveItemsSlots[i].isInSlot = true;
                Vector2 pos = new Vector2(8.5f + 1.25f * i, -0.75f);
                ActiveItemsSlots[i] = Instantiate(itemGO, pos, Quaternion.identity);
                ActiveItemsSlots[i].isUnknown = false;
                //---------------костыль пиздец---------------
                ActiveItemsSlots[i].posX = 11;
                ActiveItemsSlots[i].posY = 11;
                //---------------костыль пиздец---------------
                TileMap.tiles[itemGO.posX, itemGO.posY] = null;
                Destroy(itemGO.gameObject);

                ActiveItemsSlots[i].gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
                OpenTilesCheck();
                break;
            }
        }

    }

    public static void DmgAdd(int add)
    {
        dmg += add;
        if (dmg < 0)
        {
            dmg = 1;
        }
        dmgText.text = "DMG " + dmg.ToString();
    }
    public static void MaxHpAdd(int add)
    {
        maxHp += add;
        if (maxHp <= 0)
        {
            maxHp = 1;
        }
    }

    //ref -------------------------------------------------
    public static void ResetAllStats()
    {
        maxHp = 30;
        hp = maxHp;
        openTiles = 0;
        openBlock = false;
        dmg = 5;
    }
}
