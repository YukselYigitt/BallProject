using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torus4sc : MonoBehaviour
{

    public int minScore;

    private GameManager gameManager;

    public ParticleSystem collectEffect;

    // Start is called before the first frame update
    void Start()
    {

        
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.Rotate(180f * Time.deltaTime, 0f, 0f);  
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            minScore = minScore + 10;
            gameManager.AddScore(minScore);
            collectEffect.Play();
            
            Destroy(this.gameObject, 0.5f);
        }
        
    }




}
