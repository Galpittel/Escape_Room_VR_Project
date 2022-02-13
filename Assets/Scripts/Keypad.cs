using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    public UnityEvent onPressed, onReleased;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;

    private Animator fountainAnimator;
    private GameObject fountain;

    private GameObject userPassword;
    private string password = "0000";

    // Start is called before the first frame update
    void Start()
    {
        fountain = GameObject.Find("Fountain_01");
        fountainAnimator = fountain.GetComponent<Animator>();
        userPassword = GameObject.Find("Input_menu_obj");
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }

        if (isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if (Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        isPressed = true;

        if (transform.tag.Equals("number"))
        {
            userPassword.GetComponent<UnityEngine.UI.Text>().text += transform.name;
        }
        if(transform.name.Equals("Reset"))
        {
            ClearButtonPushed();
        }
        if(transform.name.Equals("Accept"))
        {
            VerifyButtonPushed();
        }
        onPressed.Invoke();
        Debug.Log("is pressed");

    }

    private void Released()
    {
        isPressed = false;
        onPressed.Invoke();
        Debug.Log("is released");

    }

    void ClearButtonPushed()
    {
        userPassword.GetComponent<UnityEngine.UI.Text>().text = "";

    }

    void VerifyButtonPushed()
    {
        if (password.Equals(userPassword.GetComponent<UnityEngine.UI.Text>().text))
        {
            userPassword.GetComponent<UnityEngine.UI.Text>().text = "Correct Password";
            fountainAnimator.SetTrigger("fountainTrigger");
            //correct password
        }
        else
        {
            //incorrect password
            ClearButtonPushed();
        }
    }

}