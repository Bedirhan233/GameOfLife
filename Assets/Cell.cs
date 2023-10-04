
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool alive;

    public bool shouldLive;

    Color32 color;

    float alivelifeColor = 1f;

    


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
            alivelifeColor -= Time.deltaTime / 2;
        }
    }

    public void SickCell()
    {
        spriteRenderer.color = new Color(alivelifeColor, alivelifeColor, alivelifeColor);
        alivelifeColor -= 0.2f;
        //NewBornCell();

        //spriteRenderer.color = Color.red;
    }

    public void NewBornCell()
    {
        spriteRenderer.color = Color.white;
    }
}
