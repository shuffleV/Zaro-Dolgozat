using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MySql.Data;
using MySql.Data.MySqlClient;

public class Leaderboard1 : MonoBehaviour
{

    string connStr = "server=localhost;user=RIV;database=riv_zarodolgozat;port=3306;password=Admin123";
    public TMP_Text LeaderboardTextName;
    public TMP_Text LeaderboardTextScore;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            conn.Open();
            string sql = "SELECT `Username`, `Highscore` FROM `highscore` ORDER BY `Highscore` DESC LIMIT 5;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                LeaderboardTextName.text += (rdr[0].ToString() + "\n");
                LeaderboardTextScore.text += (rdr[1].ToString() + "\n");
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex.ToString());
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
