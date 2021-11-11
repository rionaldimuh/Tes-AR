using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceObject : MonoBehaviour {
	
  // If tap doesn't hit a surface, how far object should be placed in front of camera
  public float distanceFromCamera = 1.0f;

  // Adjust this if the transform isn't at the bottom edge of the object
  public float heightAdjustment = 0.0f;

  // Prefab to instantiate.  If null, the script will instantiate a Cube
    public GameObject prefab;
    public Vector3 position,lastPos;

    public bool isInstantiated;
    public Button buttonSummon, buttonUnsummon;
  // Scale factor for instantiated GameObject
  public float objectScale = 1.0f;
  
  private GameObject myObj, myObject;
    private void Start()
    {
        myObject = Instantiate(prefab);
        myObject.gameObject.SetActive(false);
    }
    void Update() {
        if(myObject.activeInHierarchy)
            myObject.transform.position = lastPos;
    }

    public void SummonAR()
    {
        Vector3 cameraPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, distanceFromCamera));
        Debug.Log(cameraPosition);
        myObject.SetActive(true) ;
        myObject.transform.position = cameraPosition;
        lastPos = cameraPosition;
        buttonSummon.gameObject.SetActive(false);
        buttonUnsummon.gameObject.SetActive(true);
    }

    public void UnsummonAR()
    {
        myObject.SetActive(false);
        buttonSummon.gameObject.SetActive(true);
        buttonUnsummon.gameObject.SetActive(false);
    }

}
