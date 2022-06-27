using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public List<Key> keys = new List<Key>();
    private bool isUnlocked;
    public int collected;

    // Start is called before the first frame update
    void Start()
    {
        isUnlocked = false;
        collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected == keys.Count) {
            for(int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.SetActive(false);
            }
            unlock();
        }
    }

   
    public void addToCollected() {
        collected = collected + 1;
    }

    public void unlock() {
        isUnlocked = true;
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player") {
            if (isUnlocked == true) 
            {   
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }

}
