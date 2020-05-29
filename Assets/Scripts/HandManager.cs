using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject hand;
    private OVRHand ovrHand;
    public GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
        ovrHand = hand.GetComponent<OVRHand>();
    }

    void Update() {
        if (ovrHand.IsTracked) {
            hand.transform.GetChild(0).gameObject.SetActive(true);
            controller.SetActive(false);
        } else if (OVRInput.IsControllerConnected(OVRInput.Controller.LTouch)) {
            controller.SetActive(true);
            hand.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
