using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArcherAttackController : MonoBehaviour
{
    public Text arrowText;
    public int arrowCount = 10;
    public float arrowForce = 500;
    private GameObject arrowPrefab;

    void Awake(){
        arrowPrefab = Resources.Load<GameObject>("arrowPrefab");
        updateArrowCount();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            Vector2 arrowF = new Vector2(Mathf.Cos(atan) * arrowForce, Mathf.Sin(atan) * arrowForce) ;
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
