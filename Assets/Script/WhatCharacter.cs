using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatCharacter : MonoBehaviour
{
    private SpriteRenderer charSprite;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        charSprite = GetComponent<SpriteRenderer>();
        
        if(character.charData.characters == 0 && character.charData.weapons == 0)
        {
            charSprite.sprite = sprites[0];
        }
        else if(character.charData.characters == 0 && character.charData.weapons == 1)
        {
            charSprite.sprite = sprites[1];
        }
        else if (character.charData.characters == 0 && character.charData.weapons == 2)
        {
            charSprite.sprite = sprites[2];
        }
        else if (character.charData.characters == 1 && character.charData.weapons == 0)
        {
            charSprite.sprite = sprites[3];
        }
        else if (character.charData.characters == 1 && character.charData.weapons == 1)
        {
            charSprite.sprite = sprites[4];
        }
        else if (character.charData.characters == 1 && character.charData.weapons == 2)
        {
            charSprite.sprite = sprites[5];
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
