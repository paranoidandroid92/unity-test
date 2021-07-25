using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootPowerController : MonoBehaviour
{
    public Image image;

    public float percentage;
    public int spriteCount = 9;
    
    public bool isPressing = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressing){
            int spriteNo = (int) Mathf.Floor( percentage * (spriteCount-1)) ;
            image.sprite = Resources.Load<Sprite>("PB_" + spriteNo.ToString());
        }
    }

    public void setPressStatus(bool status){
        this.isPressing = status;
    }

    public void setPercentage(float percentage){
        this.percentage = percentage;
    }
}
