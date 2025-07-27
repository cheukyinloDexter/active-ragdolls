using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject body, parent;

    [SerializeField]
    [Range(1, 1000)]
    int length = 1;

    [SerializeField]
    float bodyDistance = 0.21f;

    [SerializeField]
    bool reset, spawn, snapeFirst, snapeLast;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(reset)
        {
            foreach (GameObject tmp in GameObject.FindGameObjectsWithTag("Player"))
            {
                Destroy(tmp);
            }
            reset = false;
        }

        if (spawn)
        {
            Spawn();
            spawn = false;
        }
    }

    public void Spawn()
    {
        int count = (int)(length / bodyDistance);

        for (int x = 0; x < count; x++)
        {
            GameObject tmp;
            // maybe change the direction here? to follow the mouse target
            tmp = Instantiate(body, new Vector3(transform.position.x, transform.position.y + bodyDistance * (x + 1), transform.position.z), Quaternion.identity, parent.transform);
            tmp.transform.eulerAngles = new Vector3(180, 0, 0);
            
            tmp.name = parent.transform.childCount.ToString();

            if (x == 0)
            {
                Destroy(tmp.GetComponent<CharacterJoint>());
                if (snapeFirst)
                {
                    //changes the first rope object to freeze in place, maybe change it to a diffrent prefab is better customization?
                    tmp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }
            else
            {
                tmp.GetComponent<CharacterJoint>().connectedBody = parent.transform.Find((parent.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }

        if (snapeLast)
        {
            parent.transform.Find((parent.transform.childCount).ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
