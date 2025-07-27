using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBoolParameter(bool value)
    {
        transform.GetComponent<Animator>().SetBool("isMoving", value);
    }
}
