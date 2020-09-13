using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;

    public List<GameObject> basketList;

  

    private void Start()
    {

        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGo = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);

            tBasketGo.transform.position = pos;
            basketList.Add(tBasketGo);
        }
    }

    public void AppleDestroyed()
    {
        // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }


        // Destroy one of the baskets
        // Get the INdex of the last basket in basketList

        int basketIndex = basketList.Count - 1;

        //get a reference to that basket gameobject

        GameObject tBasketGO = basketList[basketIndex];

        // Remove the basket from the list and destroy the gameobject

        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        //if there are no baskets left, restart the game
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene(2); // loads game over screen
        }
    }

}
