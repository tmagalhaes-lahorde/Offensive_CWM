using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.AI;

public class TriggerEnter : MonoBehaviour
{
    public TextMeshProUGUI text;
   
    private void Update()
    {
      
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {  
        //if (other.gameObject.GetComponent<PlayerComponent>() != null)
        //{
        //    Debug.Log("tu me captee bb ?");
        //    text.text = "1";
        //    activelife = 1;
        //    GameObject.Destroy(this.gameObject);
        //    Debug.Log(activelife);
        //}

        if(other.gameObject.GetComponent<PVScript>() != null)
        {
            text.text = "1";

            GameObject.Destroy(this.gameObject);
        }
    }
} 