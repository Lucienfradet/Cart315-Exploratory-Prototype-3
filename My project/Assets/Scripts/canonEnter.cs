using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonEnter : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject enteringTextObj;
    public GameObject UIOverlay;
    public GameObject UIFire;
    public GameObject UICam;

    public GameObject player;

    public Camera playerCam;
    public Camera cannonCam;

    public static bool inside = false;


    void Start()
    {
        playerCam.enabled = true;
        cannonCam.enabled = false;
        enteringTextObj.SetActive(false);

        UIOverlay.SetActive(false);
        UIFire.SetActive(false);
        UICam.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.E) && enteringTextObj.activeSelf && !inside) {
            inside = true;
            //get inside
            FirstPersonMovement.movementIsActive = false;
            enteringTextObj.SetActive(false);

            UIOverlay.SetActive(true);
            UIFire.SetActive(true);
            UICam.SetActive(true);

            playerCam.enabled = false;
            cannonCam.enabled = true;
            Debug.Log("getting inside");
        }
        else if (Input.GetKeyUp(KeyCode.E) && inside) {
            inside = false;
            //get outisde
            FirstPersonMovement.movementIsActive = true;

            UIOverlay.SetActive(false);
            UIFire.SetActive(false);
            UICam.SetActive(false);

            playerCam.enabled = true;
            cannonCam.enabled = false;
            Debug.Log("getting out!");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            enteringTextObj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            enteringTextObj.SetActive(false);
        }
    }
}
