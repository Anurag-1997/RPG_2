using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    RawImage healthbarImage;
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player=FindObjectOfType<PlayerMovement>();
        healthbarImage=GetComponent<RawImage>();  
    }

    // Update is called once per frame
    void Update()
    {
        float healthValue = (player.health / 2f) - 0.5f;
        healthbarImage.uvRect = new Rect(healthValue, 0f, 0.5f, 1f);
    }
}
