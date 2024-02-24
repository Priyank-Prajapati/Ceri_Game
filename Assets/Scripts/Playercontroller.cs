using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playercontroller : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isTouched;
    private int jump;
    public int jumpvalue;
    public Transform check;
    public float checkradius;
    public LayerMask whatisTouched;
    public Text text;
    public int counter=0;
    public GameObject l1, l2, l3;
    // Start is called before the first frame update
    void Start()
    {
        jump = jumpvalue;

        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if(isTouched == true)
        {
            jump = jumpvalue;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && jump > 0)
        {
            rb.velocity = Vector2.up * jumpforce;
            jump--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && jump==0 && isTouched == true)
            {
            rb.velocity = Vector2.up * jumpforce;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isTouched = Physics2D.OverlapCircle(check.position, checkradius, whatisTouched);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Platform")
        {
            jump = jumpvalue;
        }
        if (collision.gameObject.tag == "Bowl")
        {
            SceneManager.LoadScene("Win");
        }
        if (collision.gameObject.tag == "Crock")
        {
            GetComponent<AudioSource>().Play();
            counter++;
            if (counter == 1)
                l1.SetActive(false);
            else if (counter == 2)
                l2.SetActive(false);
            else if (counter == 3)
                l3.SetActive(false);
            if (counter != 3)
                StartCoroutine(ExampleCoroutine());
            else
            {
                SceneManager.LoadScene("GameOver");
                
                //gameObject.SetActive(false);
            }
            
        }
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
       gameObject.transform.position = new Vector2(-17.24f, -5.53f);
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        
        

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
