using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

    public float shakeScale = 1.0f; //how far the camera shakes
    public float incrementFactor = 1.0f; //multiplier of shake added by scripts
    public float decrementFactor = 1.0f; //amount of shake decremented per frame
    public float randomIntensity = 10.0f; //how erratic the camera shakes

    private float shakeX = 0.0f;
    private float shakeY = 0.0f;
    public float shakeLeft = 0.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        undoScreenShake(); // reset camera transform to actual position
        // do movement that follows the player here
        applyScreenShake(); //apply the scary screen shake (if any)
    }

    private void applyScreenShake()
    {
        if (shakeLeft > 0)
        {
            //Add perlin noise to the current camera position
            shakeX = (2 * Mathf.PerlinNoise(Time.time * randomIntensity, 0.0f) - 1) * shakeLeft * shakeScale;
            shakeY = (2 * Mathf.PerlinNoise(0.0f, Time.time * randomIntensity) - 1) * shakeLeft * shakeScale;
            shakeLeft -= decrementFactor;

            transform.position = new Vector3(transform.position.x + shakeX, transform.position.y + shakeY, transform.position.z);

            if (shakeLeft <= 0.0f)
            {
                shakeLeft = 0.0f;
            }
        }
    }

    private void undoScreenShake()
    {
        if (shakeX != 0.0f || shakeY != 0.0f)
        {
            transform.position = new Vector3(transform.position.x - shakeX, transform.position.y - shakeY, transform.position.z);
            shakeX = 0.0f; shakeY = 0.0f;
        }
    }

    public void addScreenShake(float shakeAmount) //Call this to begin the screen shaking
    {
        shakeLeft += incrementFactor * shakeAmount;
    }
}
