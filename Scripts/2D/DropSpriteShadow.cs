using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]//[ExecuteInEditMode] // for ease of use s
public class DropSpriteShadow : MonoBehaviour
{
    [SerializeField]
    Vector2 ShadowOffset;
    [SerializeField]
    Material ShadowMaterial;
    [SerializeField]
    Vector2 scale;

    SpriteRenderer spriteRenderer;
    GameObject shadowGameobject;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        //create a new gameobject to be used as drop shadow
        shadowGameobject = new GameObject("Shadow");

        //create a new SpriteRenderer for Shadow gameobject
        SpriteRenderer shadowSpriteRenderer = shadowGameobject.AddComponent<SpriteRenderer>();

        //set the shadow gameobject's sprite to the original sprite
        shadowSpriteRenderer.sprite = spriteRenderer.sprite;
        //set the shadow gameobject's material to the shadow material we created
        shadowSpriteRenderer.material = ShadowMaterial;

        //update the sorting layer of the shadow to always lie behind the sprite
        shadowSpriteRenderer.sortingLayerName = spriteRenderer.sortingLayerName;
        shadowSpriteRenderer.sortingOrder = spriteRenderer.sortingOrder - 1;

        shadowGameobject.transform.parent = transform;
        UpdateShadow();
    }

    //private void OnDisable()
    //{
    //    DestroyImmediate(shadowGameobject);
    //}

    //void LateUpdate() // only for play testing
    //{
    //    UpdateShadow();
    //}

    void UpdateShadow()
    {
        shadowGameobject.transform.localScale = scale;                              // to scale as well, but offset and shadow gets smaller
        shadowGameobject.transform.localPosition = Vector3.zero + (Vector3)ShadowOffset;
        shadowGameobject.transform.localRotation = transform.localRotation;
    }
}
