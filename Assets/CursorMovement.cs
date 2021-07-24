using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovement : MonoBehaviour
{
    public GameObject player;
    public float distance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 playerPosition = player.transform.position;
        Vector3 atan = mousePosition - playerPosition;

        atan = new Vector2(atan.x, atan.y).normalized;
        //Debug.Log("atan: " + atan);
        //float degree = Mathf.Atan2(atan.y, atan.x) * Mathf.Rad2Deg;
        //Debug.Log("Degree : " + degree);

        transform.position = player.transform.position + atan;
    }
}
