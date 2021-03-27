using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{   public float speed=0;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    public GameObject winText;
    public GameObject loseText;
    public TextMeshProUGUI countText;
 
    // Start is called before the first frame update
    void Start()
    {   winText.SetActive(false);
        loseText.SetActive(false);
        count=0;
        rb=GetComponent<Rigidbody>();
        SetCountText();
    }
    void SetCountText() {

            countText.text= "Count: " + count.ToString();
            if(count>=8){

                winText.SetActive(true);
                Time.timeScale = 0;
                Application.Quit();
            }
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector=movementValue.Get<Vector2>();
        movementX=movementVector.x;
        movementY=movementVector.y;

    }
    void FixedUpdate() 
    {
        Vector3 movement=new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement*speed);

    }
    private void OnTriggerEnter(Collider other ){
        if(other.gameObject.tag=="PickUp" ){
            other.gameObject.SetActive(false);
           count++;
           SetCountText();
        }
        if( other.gameObject.tag=="Koruma"){
                loseText.SetActive(true);
                Time.timeScale = 0; 
                Application.Quit();
        }


    }

}
