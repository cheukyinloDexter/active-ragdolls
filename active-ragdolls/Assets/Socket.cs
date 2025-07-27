using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using ActiveRagdoll;

public class Socket : MonoBehaviour
{
    [SerializeField]
    bool socketDisabled = false;
    [SerializeField]
    Material socketMat;
    [SerializeField]
    UnityEvent OnSocketPluged;
    // Start is called before the first frame update
    void Start()
    {
        socketMat = GetComponentInParent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Socket") && !socketDisabled)
        {
            //check if they got the right color connection
            Material otherMat = other.GetComponent<Renderer>().material;
            Debug.Log("inside socket");
            if (otherMat.color == socketMat.color)
            {
                Debug.Log("correct socket");

                other.GetComponent<Rigidbody>().isKinematic = true;
                other.GetComponent<Collider>().enabled = false;
                other.GetComponent<Grippable>().enabled = false;

                other.transform.position = this.transform.position;
                other.transform.rotation = this.transform.rotation;
                other.transform.SetParent(this.transform);
                OnSocketPluged.Invoke();
                socketDisabled = true;
            }
            
            
        }
    }
}
