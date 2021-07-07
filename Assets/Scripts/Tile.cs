using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour

{
    [Header("Set in inspector")]
    public static Text tileInfoText;
    public string tileInfoStr;
    public bool isUnknown = true;
    public bool isTileInitialised = false;
    public Type typeOfTile;
    [Header("Set for use")]
    public int posX;
    public int posY;
    public SpriteRenderer sr;
    private Sprite defaultSprite;
    private Sprite spriteOfTile;
    public virtual void Start()
    {
        if (!isTileInitialised)
            TileInitialisation();


    }
    public void TileInitialisation()
    {
        defaultSprite = Resources.Load<Sprite>("Sprites/UnknownTile");
        tileInfoText = GameObject.Find("TileInfo").GetComponent<Text>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        spriteOfTile = sr.sprite;
        if (isUnknown)
        {
            sr.sprite = defaultSprite;
        }
        isTileInitialised = true;
    }

    public void OnMouseEnter()
    {
        this.gameObject.transform.localScale *= 1.5f;
        sr.sortingOrder = 1;
        if (!isUnknown)
        {
            TileInfoUpdate();
            Tile.tileInfoText.text = tileInfoStr;
        }
    }
    public void OnMouseExit()
    {
        this.gameObject.transform.localScale /= 1.5f;
        sr.sortingOrder = 0;
        if (!isUnknown)
            Tile.tileInfoText.text = " ";
    }
    public virtual void OpenTile()
    {
        sr.sprite = spriteOfTile;
        isUnknown = false;
        TileInfoUpdate();
        tileInfoText.text = tileInfoStr;
        Player.OpenTilesCheck();
    }

    public enum Type
    {
        Enemy,
        Loot,
        Skill
    }
    public virtual void TileInfoUpdate()
    {

    }
  
    public void CloseTile()
    {
        isUnknown = true;
        sr.sprite = defaultSprite;
        Player.OpenTilesCheck();
    }
    public void Update()
    {
        try
        {
            while (TileMap.tiles[posX, posY + 1] == null)
            {
                posY++;
                this.gameObject.transform.position = new Vector2(-11.0f + 1.25f * posX, 4.25f - 1.25f * posY);
                TileMap.tiles[posX, posY - 1] = null;
                TileMap.tiles[posX, posY] = this;
            }
        }
        catch { }
    }
    

}
