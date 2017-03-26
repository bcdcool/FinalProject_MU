using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class _PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public AudioSource saw;
    //public Slider healthSlider;
    //public Image damageImage;
    //public AudioClip deathClip;
    //public float flashSpeed = 5f;
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    //Animator anim;
    //AudioSource playerAudio;
    _PlayerController playerController;
    _PlayerShoot playerShooting;
    bool isDead;
    bool damaged;

    GameController gameController;

    void Awake()
    {
        //anim = GetComponent<Animator>();
        //playerAudio = GetComponent<AudioSource>();
        playerController = GetComponent<_PlayerController>();
        playerShooting = GetComponentInChildren<_PlayerShoot>();
        currentHealth = startingHealth;
    }

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }


    void Update()
    {
        if (damaged)
        {
            //damageImage.color = flashColour;
            saw.Play();
            saw.SetScheduledEndTime(AudioSettings.dspTime + (1));
        }
        else
        {
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        //saw.Stop(); 
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        //healthSlider.value = currentHealth;

        //playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;

        //playerShooting.DisableEffects();

        //anim.SetTrigger("Die");

        //playerAudio.clip = deathClip;
        //playerAudio.Play();

        playerController.enabled = false;
        playerShooting.enabled = false;

        

        gameController.GameOver();
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}
