using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private Rigidbody rb;

    public GameObject dashesParent;
    public GameObject prevDash;

    public float speed;
    private bool isMoving = false; 


    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || MobileInput.Instance.swipeLeft && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.left * speed * Time.deltaTime; //Vector3.left = new Vector3(-1,0,0) sağ
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow) || MobileInput.Instance.swipeRight && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.right * speed * Time.deltaTime; //Vector3.right = new Vector3(1,0,0) sol
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow) || MobileInput.Instance.swipeUp && !isMoving)
        {
            isMoving = true;
            rb.velocity = Vector3.forward * speed * Time.deltaTime; //Vector3.forward = new Vector3(0,0,1) ileri
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || MobileInput.Instance.swipeDown && !isMoving)
        {
            isMoving = true;
            rb.velocity = -Vector3.forward * speed * Time.deltaTime; //-Vector3.forward = new Vector3(0,0,-1) geri
        }

        if (rb.velocity ==Vector3.zero)
        {
            isMoving = false; //stop
        }
    }

    public void TakeDashes(GameObject dash)
    {
        dash.transform.SetParent(dashesParent.transform);
        Vector3 pos = prevDash.transform.localPosition;
        pos.y -= 0.047f;
        dash.transform.localPosition = pos;

        Vector3 playerPos = transform.localPosition;
        playerPos.y += 0.047f;
        transform.localPosition = playerPos;
        prevDash = dash;

        prevDash.GetComponent<BoxCollider>().isTrigger = false;
    }

}
