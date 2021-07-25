using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherAttackController : MonoBehaviour
{
    public Text arrowText;
    public int arrowCount = 10;
    public float arrowBaseForce = 100;
    public ShootPowerController powerController;
    private Animator anim;
    private GameObject arrowPrefab;

    public float maxPowerTime = 2;
    public float powerTimer;
    public float powerPercentage;
    public float extraPower = 100;
    private bool isAttacking = false;

    void Awake(){
        anim = GetComponent<Animator>();
        arrowPrefab = Resources.Load<GameObject>("arrowPrefab");
        updateArrowCount();
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetMouseButtonDown(0))
        {
            isAttacking = true;
            anim.SetBool("isAttacking", true);
            powerController.setPressStatus(true);
           
        }
        if (Input.GetMouseButtonUp(0))
        {
            isAttacking = false;
            powerTimer = 0;
            anim.SetBool("isAttacking", false);
            powerController.setPressStatus(false);
            powerController.setPercentage(0);
            fireArrow();
        }
        if(isAttacking){
            if(powerTimer >= maxPowerTime){
                powerTimer = maxPowerTime;
            }
            powerPercentage = powerTimer / maxPowerTime;
            powerTimer += Time.deltaTime;
            powerController.setPercentage(powerPercentage);
        }else{
            
        }
    }

    public void fireArrow()
    {
        if(arrowCount > 0){

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 diff = mousePosition - transform.position;
            float atan = Mathf.Atan2(diff.y,diff.x);
            Debug.Log("Angle :" + atan);

            GameObject arrow = Instantiate(arrowPrefab);
            arrow.transform.position = transform.position;

            Rigidbody2D arrowBody = arrow.GetComponent<Rigidbody2D>();
            float finalForce = arrowBaseForce + powerPercentage * extraPower;
            Vector2 arrowF = new Vector2(Mathf.Cos(atan) * finalForce, Mathf.Sin(atan) * finalForce) ;
            arrowBody.AddForce(arrowF);

            Debug.Log("sin :" + Mathf.Sin(atan) + " cos: " + Mathf.Cos(atan));
            Debug.Log(arrowF);
            arrowCount--;
            updateArrowCount();
        }
    }

    private void updateArrowCount(){
        arrowText.text = arrowCount.ToString();
    }
}
