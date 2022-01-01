using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class handPresence : MonoBehaviour
{

    public bool controler = false;
    public InputDeviceCharacteristics ControllerCharacteristics;
    public List<GameObject> controllerPrefab;

    public GameObject handModelPrefab;
    private GameObject spawnedHandModel;
    private InputDevice targetDevice;
    private Animator handAnimator;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ControllerCharacteristics, devices);

        //foreach (var item in devices)
        //{
        //    Debug.Log(item.name + item.characteristics);
        //}

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefab.Find(controler => controler.name == targetDevice.name);
            if (prefab)
            {
                spawnedHandModel = Instantiate(prefab, transform);
            }
        }

        spawnedHandModel = Instantiate(handModelPrefab, transform);
        Debug.Log("ORI1");
        Debug.Log(spawnedHandModel);
        Debug.Log("ORI2");
        handAnimator = spawnedHandModel.GetComponent<Animator>();
    }
    void UpdateHandAnimation()
    {
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger,out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawnedHandModel.SetActive(true);
        UpdateHandAnimation();
    }
}
