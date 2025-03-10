using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Jatekos : MonoBehaviour
{
    public float sebesseg;
    public float maxx;
    public float minx;
    public float xvalt;
    private Vector3 cel;
    public GameObject szamlalo;
    public TextMeshProUGUI szoveg;
    private float ido = 0;
    private float mp;
    public GameObject gameover;
    public GameObject menu;
    public TextMeshProUGUI HighScoreText1;
    public TextMeshProUGUI HighScoreText2;
    private void Start()
    {
        szoveg = szamlalo.GetComponent<TextMeshProUGUI>();
        UpdateHighScoreText();
        Time.timeScale = 1;
    }
    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, cel, sebesseg * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < maxx)
        {
            cel = new Vector3(transform.position.x + xvalt, transform.position.y, transform.position.z);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > minx)
        {
            cel = new Vector3(transform.position.x - xvalt, transform.position.y, transform.position.z);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        ido += Time.deltaTime;
        if(ido >= 1)
        {
            mp++;
            ido = 0;
        }
        szoveg.text = mp.ToString();
        CheckHighScore();
    }
    void CheckHighScore()
    {
        if(mp>PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore", (int)mp);
        }
        UpdateHighScoreText();
    }
    void UpdateHighScoreText()
    {
        HighScoreText1.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
        HighScoreText2.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Akadaly"))
        {
            gameover.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

}
