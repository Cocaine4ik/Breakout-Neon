using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block {

    protected string color;

    protected virtual void Start() {

        points = ConfigurationUtils.StandardBlockPoints;
        color = "Magenta";

    }
    // if block is detroyed, paddle color and light chganges in addiction to block color
    protected virtual void OnDestroy() {

        if (GameObject.FindGameObjectWithTag("Paddle") != null) {
            switch (color) {

                case "Magenta":
                    SetPaddleLightColor(new Color(255, 0, 243, 255));
                    SetPaddleSprite(Resources.Load<Sprite>("Sprites/MagentaPaddle"));
                    break;
                case "Green":
                    SetPaddleLightColor(new Color(0, 217, 9, 255));
                    SetPaddleSprite(Resources.Load<Sprite>("Sprites/GreenPaddle"));
                    break;
                case "Red":
                    SetPaddleLightColor(new Color(255, 0, 12, 255));
                    SetPaddleSprite(Resources.Load<Sprite>("Sprites/RedPaddle"));
                    break;
                case "Blue":
                    SetPaddleLightColor(new Color(0, 76, 255, 255));
                    SetPaddleSprite(Resources.Load<Sprite>("Sprites/BluePaddle"));
                    break;

            }
        }
    }
    // set paddle light color
    private void SetPaddleLightColor(Color lightColor) {

        Light paddleLight = GameObject.FindGameObjectWithTag("Paddle").GetComponent<Light>();
        paddleLight.color = lightColor * Time.deltaTime;
        paddleLight.range = 7;
        paddleLight.intensity = 2;

    }

    // set paddle sprite 
    private void SetPaddleSprite(Sprite paddleSprite) {
        GameObject.FindGameObjectWithTag("Paddle").GetComponent<SpriteRenderer>().sprite = paddleSprite;
    }

}
