
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool alive;

    public bool shouldLive;

    Color color;

    float lifeColor = 1f;

    

    SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(lifeColor, lifeColor, lifeColor);

    }

    private void Update()
    {

        


        //if (alive)
        //{
        //    spriteRenderer.color = Color.white;   
        //}
        //if(!alive) 
        //{
        //    //SickCell();


        //}
        
    }

    public void UpdateStatus()
    {
        spriteRenderer ??= GetComponent<SpriteRenderer>();
        
        spriteRenderer.enabled = alive;
       
        
        

        



    }

    public void SickCell()
    {
        spriteRenderer.color = new Color(lifeColor, lifeColor, lifeColor);
        lifeColor -= 0.2f;
        //NewBornCell();

        //spriteRenderer.color = Color.red;
    }

    public void NewBornCell()
    {




        spriteRenderer.color = Color.white;



    }
}
