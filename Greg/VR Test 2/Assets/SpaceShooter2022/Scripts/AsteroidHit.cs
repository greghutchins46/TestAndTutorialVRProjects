using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AsteroidHit : MonoBehaviour
{
    [SerializeField] private GameObject asteroidExplosion;
    private GameController gameController;
    [SerializeField] private GameObject popupCanvas;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void AsteroidDestroyed()
    {
        Instantiate(asteroidExplosion, transform.position, transform.rotation);

        if (GameController.currentGameStatus == GameController.GameState.Playing)
        {
            // Calculate the score for hitting the asteroid
            float distanceFromPlayer = Vector3.Distance(transform.position, Vector3.zero);
            int bonusPoints = (int)distanceFromPlayer;
            int asteroidScore = 10 * bonusPoints;

            // Set our text for the popup and instantiate popup canvas
            // Quaternion.identity is the default rotation of the canvas
            popupCanvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = asteroidScore.ToString();
            GameObject asteroidPopup = Instantiate(popupCanvas, transform.position, Quaternion.identity);

            // Adjust the scale of the popup
            asteroidPopup.transform.localScale = new Vector3(transform.localScale.x * (distanceFromPlayer / 10),
                transform.localScale.y * (distanceFromPlayer / 10),
                transform.localScale.z * (distanceFromPlayer / 10));

            // pass score to GameController
            gameController.UpdatePlayerScore(asteroidScore);
        }

        Destroy(this.gameObject);
    }
}
