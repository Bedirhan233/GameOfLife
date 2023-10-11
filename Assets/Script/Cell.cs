
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool alive;

    public bool shouldLive;

    Color32 color;

    float alivelifeColor = 1f;

    public Color testcolor;



    


    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.black;
    }

    private void Update()
    {
        
    }

    public void UpdateStatus()
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();
        
        //spriteRenderer.enabled = alive;

        if(alive)
        {
            spriteRenderer.color = Color.white;
            alivelifeColor = 1f;
        }
        else
        {
            spriteRenderer.color = color;
            color = new Color(alivelifeColor, alivelifeColor, alivelifeColor);
            
            alivelifeColor -= 0.5f;
        }
    }

   
}
