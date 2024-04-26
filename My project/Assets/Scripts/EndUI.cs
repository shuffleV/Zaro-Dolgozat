using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;

public class EndUI : MonoBehaviour
{

    string connStr = "server=localhost;user=RIV;database=riv_zarodolgozat;port=3306;password=Admin123";

    List<string> username = new List<string>();

    public static int score = 0;
    public TMP_Text FinalScoreText;

    public GameObject UserError = default;
    string text;
    bool vane = false;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
        FinalScoreText.text = $"Your Score: {score}";
        Debug.Log(score);

        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            string sql = "SELECT `Username`, `Highscore` FROM `highscore` WHERE 1";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                username.Add(rdr[0].ToString() + " " + rdr[1].ToString());
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpecialChar(string user)
    {
        bool specialchar = false;
        text = user;
        Debug.Log(text);
        string specialChar = @"\|Ä€Í÷×äðÐ[]í³£$ß¤<>#&@{}<;>*~¡^¢°²`ÿ´½¨¸§'+!%/=()?:_,.-éáíóöõúüûÉÁÍÓÖÕÚÜÛ ";
        foreach (var item in specialChar)
        {
            if (text.Contains(item))
                specialchar = true;
        }
        if (specialchar||text==""||text.Length<3||text.Length>9)
        {
            UserError.SetActive(true);
        }
        else
        {
            UserError.SetActive(false);
        }
    }

    public void SaveHighscore()
    {
        MySqlConnection conn = new MySqlConnection(connStr);
        if (!UserError.activeInHierarchy)
        {
            foreach (var item in username)
            {
                if (item.Split(' ')[0]==text)
                {
                    if (score>Convert.ToInt32(item.Split(' ')[1]))
                    {
                        try
                        {
                            conn.Open();
                            string sql = $"UPDATE `highscore` SET `Highscore`={score} WHERE `Username`='{text}'";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                        }
                        catch (System.Exception ex)
                        {
                            Debug.Log(ex.ToString());
                        }
                    }
                    vane = true;
                }
            }
            if (vane==false)
            {
                try
                {
                    conn.Open();
                    string sql = $"INSERT INTO `highscore` (`Username`, `Highscore`) VALUES ('{text}','{score}')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    Debug.Log(ex.ToString());
                }
            }
            SceneManager.LoadScene(3);
        }
    }
}
