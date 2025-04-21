using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int HP = 100, totalHP;
    public GameObject bloodyScreen;
    public TextMeshProUGUI playerHealthUI;
    public GameObject gameOverUI;

    public bool isDead;

    private void Start()
    {
        // initializing total health of player
        totalHP = HP;
        playerHealthUI.text = $"Health: {HP}";
        
    }

    private void Update()
    {
        // handling of player HP UI according to health status

        if ((double) HP / totalHP > 0.5)
            playerHealthUI.color = new Color(0, 255, 0);
        else if ((double) HP / totalHP <= 0.5 && (double) HP / totalHP > 0.2)
            playerHealthUI.color = new Color(255, 216, 0);
        else if ((double) HP / totalHP <= 0.2)
            playerHealthUI.color = new Color(255, 0, 0);
        playerHealthUI.text = $"Health: {HP}";
    }

    // take damage method
    // die when damage reaches 0
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;

        if (HP <= 0)
        {
            print("Player Dead");
            PlayerDead();
            isDead = true;
        }
        else
        {
            print("Player Hit");
            StartCoroutine(BloodEffect());
        }
    }

    // checks collision from enemy and takes damage correspondingly
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MannequinHand"))
        {
            if (isDead == false)
                TakeDamage(other.gameObject.GetComponent<MannequinHand>().damage);
        }

        if (other.CompareTag("PrisonRealm"))
        {
            if (isDead == false)
                TakeDamage(other.gameObject.GetComponent<PrisonRealm>().damage);
        }

        if (other.CompareTag("ZombieHand"))
        {
            if (isDead == false)
                TakeDamage(other.gameObject.GetComponent<ZombieHand>().damage);
        }
    }

    private IEnumerator BloodEffect()
    {
        if (bloodyScreen.activeInHierarchy == false)
            bloodyScreen.SetActive(true);

        var image = bloodyScreen.GetComponentInChildren<Image>();
 
        // Set the initial alpha value to 1 (fully visible).
        Color startColor = image.color;
        startColor.a = 1f;
        image.color = startColor;
 
        float duration = 3f;
        float elapsedTime = 0f;
 
        while (elapsedTime < duration)
        {
            // Calculate the new alpha value using Lerp.
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
 
            // Update the color with the new alpha value.
            Color newColor = image.color;
            newColor.a = alpha;
            image.color = newColor;
 
            // Increment the elapsed time.
            elapsedTime += Time.deltaTime;
 
            yield return null; ; // Wait for the next frame.
        }

        if (bloodyScreen.activeInHierarchy)
            bloodyScreen.SetActive(false);
    }

    // handling player's death
    private void PlayerDead()
    {
        GetComponent<PlayerMotor>().enabled = false;
        GetComponent<InputManager>().enabled = false;
        GetComponent<PlayerLook>().enabled = false;
        GameObject.Find("Weapons").SetActive(false);


        GetComponentInChildren<Animator>().enabled = true;
        playerHealthUI.gameObject.SetActive(false);

        GetComponent<Fainting>().StartFade();
        StartCoroutine(GameOver());
    }

    // game over screen
    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOverUI.gameObject.SetActive(true);

        StartCoroutine(ReturnToMainMenu());
    }

    // load Menu scene after death
    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("Menu");
    }

}
