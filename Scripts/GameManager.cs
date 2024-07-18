using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    public GameObject[] Cars;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CarIndex");
        GameObject car = Instantiate(Cars[index], Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
