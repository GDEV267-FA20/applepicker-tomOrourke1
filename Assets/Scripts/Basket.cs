using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    private void Start()
    {
        //Find a reference to the ScoreCOunter GameOBject
        GameObject scoreGo = GameObject.Find("ScoreCounter");

        // Get the Text Component of that GameObject
        scoreGT = scoreGo.GetComponent<Text>();

        // Set the starting numbert of points to 0
        scoreGT.text = "0";
    }
    private void Update()
    {
        //Get the current screen position of the mouse from input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera's z position sets how far to puch the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D space into 3D game world space

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of this Basket to the x position of the mouse
        Vector3 pos = this.transform.position;

        pos.x = mousePos3D.x;

        this.transform.position = pos;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Find out what hit this basket
        GameObject collidedWith = collision.gameObject;

        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            // Parse the text of the scoreGT into an int
            int score = int.Parse(scoreGT.text);

            //add points for catching the apple
            score += 100;

            //convert the score back to a string and display it
            scoreGT.text = score.ToString();



            // Track the high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
