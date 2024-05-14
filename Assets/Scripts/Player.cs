using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 450;
    CurrentDirection cr;
    public bool isPlayerDead;

    public float guc = 10.0f;
    

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        cr = CurrentDirection.left;
        isPlayerDead = false;
        gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {   
        
    


        if (!isPlayerDead)
        {
                RayCastDetector();
                if (Input.GetKeyDown("d"))
                {
                     ChangeDirectionD();
                     
                     PlayerStop();
                }

                if (Input.GetKeyDown("a"))
                {
                     ChangeDirectionA();
                     
                     PlayerStop();
                }

                if (Input.GetKeyDown("s"))
                {
                     ChangeDirectionS();
                     
                     PlayerStop();
                }
                if (Input.GetKeyDown("w"))
                {
                     ChangeDirectionW();
                     
                     PlayerStop();
                }



        }
        else
        {
            return; 
        }
        
    }



    private void RayCastDetector()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            MovePlayer();
        }
        else
        {
            PlayerStop();
            isPlayerDead = true;
            this.gameObject.SetActive(false);
            gameManager.LevelEnd(); 

        }
    }
    private enum CurrentDirection
    {
        right, 
        left,
        forward,
        back
    }

   


    private void ChangeDirectionD()
    {
        MovePlayer();
        cr = CurrentDirection.right;
        
        
    }

      private void ChangeDirectionA()
    {
        MovePlayer();
        cr = CurrentDirection.left;
        
        
    }

    private void ChangeDirectionS()
    {
        MovePlayer();
        cr = CurrentDirection.back;
        
    }

    private void ChangeDirectionW()
    {
        MovePlayer();
        cr = CurrentDirection.forward;
         
        
    }

    private void MovePlayer()
    {
        if (cr == CurrentDirection.right)
        {
           rb.AddForce((Vector3.right).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.left)
        {
           rb.AddForce((Vector3.left).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.back)
        {
           rb.AddForce((Vector3.back).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }
        else if (cr == CurrentDirection.forward)
        {
           rb.AddForce((Vector3.forward).normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
        }

   
   
    }

    private void PlayerStop()
    {
        rb.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EndTrigger"))
        {
            gameManager.WinLevel();
            PlayerStop();
            this.gameObject.SetActive(false);
        }
    }
    
    
}
