using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float Health;
    private float lerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 1.0f;
    public Image frontHealthBar;
    public Image backHealthBar;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        UpdateHealthUI();
        Health = Mathf.Clamp(Health, 0, maxHealth);
        //UpdateHealthUI();
        if(Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(Random.Range(5, 20));
            
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(Random.Range(5,10));
        }
    }

    public void UpdateHealthUI()
    {
        
        float fillFront = frontHealthBar.fillAmount;
        float fillBack = backHealthBar.fillAmount;
        float hFraction = Health / maxHealth;
        if(fillBack > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.gold;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillBack, hFraction, percentComplete);
        }

        if(fillFront < hFraction) 
        {
            backHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;

            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillFront, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;
        lerpTimer = 0f;
    }

    public void Heal(float healAmount)
    {
        Health += healAmount;
        lerpTimer = 0f;
    }
}
