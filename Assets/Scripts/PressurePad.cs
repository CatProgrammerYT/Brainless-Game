using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{

    [SerializeField]
    protected GameObject ThingToActivate;
    [SerializeField]
    private Transform pressurePadposition;

    [SerializeField]
    private float cooldown;

    [SerializeField]
    private bool activateOrDeactivate;

    [SerializeField]
    private Vector3 defaultPosition;
    [SerializeField]
    private Vector3 pressedPosition;

    private void Start()
    {
        pressurePadposition = pressurePadposition.gameObject.GetComponent<Transform>();
    }

    private void OnCollisionStay(Collision collision)
    {

        if(collision.gameObject != null)
        {
            pressurePadposition.Translate(pressedPosition);
            ThingToActivate.SetActive(activateOrDeactivate);
            StartCoroutine(OnPressurePadExit(cooldown));
        }
    }
    IEnumerator OnPressurePadExit(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        pressurePadposition.Translate(defaultPosition);
        ThingToActivate.SetActive(!activateOrDeactivate);
    }
}
