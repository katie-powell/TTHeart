using UnityEngine;
using System.Collections;

public class HeartLocationMngrScript : MonoBehaviour {
   
    Rigidbody[] HeartContainers;
    int numContainers = 0;
   

   
    // Use this for initialization
    void Start () {
        HeartContainers = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody body in HeartContainers)
        {
            numContainers++;
        }
        setHeartLocation ();
        setPhase (2);
    }
   
    // Update is called once per frame
    void Update () {
   
    }
   
    void setHeartLocation()
    {
        //choose random child object, set its hasheart == 1
        int randomNumber = (int)Random.Range(0, numContainers);
        HeartContainers[randomNumber].GetComponent<HeartContainerScript>().setAsHeart();
    }
   
    void setPhase(int n)
    {
        foreach(Rigidbody container in HeartContainers)
        {
            container.GetComponent<HeartContainerScript>().setPhase(n);
        }
    }
}
