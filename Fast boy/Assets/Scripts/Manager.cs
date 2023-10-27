using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    [SerializeField] private Text coinsCountText;
    [SerializeField] private Text distanceText;
    [SerializeField] private GameObject gameOverPanel;

    private bool addDistance;

    private int distance;
    private int coinsCount;

    private float disDelay = 0.15f;

    private void Start()
    {
        coinsCount = 0;
        addDistance = true;
    }

    private void Update()
    {
        coinsCountText.text = $"Coins: {coinsCount}";
        if (addDistance == true)
        {
            addDistance = false;
            StartCoroutine(AddDistance());
        }
    }

    IEnumerator AddDistance()
    {
        distance++;
        distanceText.text = ""+distance;
        yield return new WaitForSeconds(disDelay);
        addDistance = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.gameObject.GetComponent<Coin>();

        if (coin)
        {
            coinsCount++;
            coin.OnDestroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Barrier barrier = collision.gameObject.GetComponent<Barrier>();

        if (barrier)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }
}
