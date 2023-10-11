using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GameForLife gameForLife;
    public int speed = 4;
    bool calculating;

    public Slider slider;
    public TextMeshProUGUI speedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        speed = (int)slider.value;
        
        speedText.text = "Speed is: " + speed;

        Application.targetFrameRate = speed;
    }

    public void Pause()
    {
        gameForLife.isRuning = false;

    }

    public void Resume()
    {
        gameForLife.isRuning = true;
    }

}
