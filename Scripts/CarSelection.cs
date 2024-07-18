using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarSelection : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Cars;
    public Button Next;
    public Button Prev;
    int index;


    // Start is called before the first frame update
    void Start()
    {

        index = PlayerPrefs.GetInt("CarIndex");

        for (int i = 0; i < Cars.Length; i++)
        {
            Cars[i].SetActive(false);
            Cars[index].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (index > Cars.Length)
        {
            Next.interactable = false;

        }
        else
        {
            Next.interactable = true;
        }
        if (index <= 0)
        {
            Prev.interactable = false;
        }
        else
        {
            Prev.interactable = true;
        }
    }
    public void next()
    {
        if (index + 1 < Cars.Length)
        {
            index++;
            for (int i = 0; i < Cars.Length; i++)
            {
                Cars[i].SetActive(false);
                Cars[index].SetActive(true);

            }
            PlayerPrefs.SetInt("CarIndex", index);
            PlayerPrefs.Save();
        }
    }
    public void Prevs()
    {
        if (index - 1 >= 0)
        {
            index--;
            for (int i = 0; i < Cars.Length; i++)
            {
                Cars[i].SetActive(false);
                Cars[index].SetActive(true);

            }
            PlayerPrefs.SetInt("CarIndex", index);
            PlayerPrefs.Save();
        }
    }
    public void race()
    {
        SceneManager.LoadSceneAsync("Level2");
    }
}
