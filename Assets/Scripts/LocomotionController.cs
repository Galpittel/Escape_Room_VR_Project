using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour
{
    public XRController leftTelporterRay;
    public XRController rightTelporterRay;
    public InputHelpers.Button teleportActivateBtn;
    public float activationThreshold = 0.1f;

    public bool checkIfActivated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivateBtn, out bool isActivated, activationThreshold);
        return isActivated;
    }

    // Update is called once per frame
    void Update()
    {
        //if (leftTelporterRay)
        //{
        //    leftTelporterRay.gameObject.SetActive(checkIfActivated(leftTelporterRay));
        //}
        //if (rightTelporterRay)
        //{
        //    rightTelporterRay.gameObject.SetActive(checkIfActivated(rightTelporterRay));
        //}

    }
}
