using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using MySql.Data.MySqlClient;

public class EndUI : MonoBehaviour
{

    /*scene bet�lt�sekor k�rdezze le az adatb�zist �s �rja be a usereket egy list�ba
     * a gomb lenyom�sakor egy if-ben n�zze meg hogy a user szerepel-e a list�ba
     * ha igen akkor update, ha nem akkor isert
    */

    private string connStr;
    private MySqlConnection MySqlConnection;
    private MySqlCommand MySqlCommand;
    string query;

    public GameObject UserError = default;
    string text;

    public void sendInfo()
    {
        connection();

        query = "INSERT INTO `highscore`(`Username`, `Highscore`) VALUES ('Test','35000')";

        MySqlCommand = new MySqlCommand(query, MySqlConnection);

        MySqlCommand.ExecuteNonQuery();

        MySqlConnection.Close();
    }

    public void connection()
    {
        connStr = "server=localhost;user=RIV;database=riv_zarodolgozat;port=3306;passwordAdmin123";
        MySqlConnection = new MySqlConnection(connStr);

        MySqlConnection.Open();
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
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
        string specialChar = @"\|Ā������[]�$ߤ<>#&@{}<;>*~�^���`������'+!%/=()?:_,.-������������������ ";
        foreach (var item in specialChar)
        {
            if (text.Contains(item))
                specialchar = true;
        }
        if (specialchar||text==""||text.Length<3)
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
        if (!UserError.activeInHierarchy)
        {
            SceneManager.LoadScene(3);
        }
    }
}
