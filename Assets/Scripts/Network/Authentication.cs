using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
 
public class Authentication : MonoBehaviour
{
    private string secretKey = "lostintranslation"; // Edit this value and make sure it's the same as the one stored on the server
    public string serverURL = "thousandstorms.com/scripts/fotr.php"; //be sure to add a ? to your url
 	
 	public Text username;
	public Text password;
	public Button loginButton;

    void Start()
    {
        loginButton.onClick.AddListener(TaskOnClick);

    }
 
 	void TaskOnClick(){
 	        StartCoroutine(CheckLogin());
 	}
 	
    // remember to use StartCoroutine when calling this function!
   
   /*IEnumerator NewLogin(string name, int score)
    {
        //This connects to a server side php script that will add the name and score to a MySQL DB.
        // Supply it with a string representing the players name and the players score.
        //string hash = Md5Sum(name + score + secretKey);
 
        string post_url = serverURL + "name=" + WWW.EscapeURL(name) + "&score=" + score;
        // + "&hash=" + hash;
 
        // Post the URL to the site and create a download object to get the result.
        WWW postConnection = new WWW(post_url);
        yield return postConnection; // Wait until the download is done
 
        if (postConnection.error != null)
        {
            print("There was an error posting the high score: " + postConnection.error);
        }
    }*/
 
    // Get the scores from the MySQL DB to display in a GUIText.
    // remember to use StartCoroutine when calling this function!
    IEnumerator CheckLogin()
    {
    	string postURL = serverURL + "?username=" + WWW.EscapeURL(username.text) + "&password=" + password.text;
        WWW getConnection = new WWW(postURL);
        yield return getConnection;
 
        if (getConnection.error != null)
        {
            print("There was an error logging you in.  Please try again later or contact your administrator.");
        }
        else
        {
            Debug.Log(getConnection.text);
            SceneManager.LoadScene("Client");
        }
    }

	string Md5Sum(string strToEncrypt)
	{
		System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
		byte[] bytes = ue.GetBytes(strToEncrypt);

		// encrypt bytes
		System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
		byte[] hashBytes = md5.ComputeHash(bytes);

		// Convert the encrypted bytes back to a string (base 16)
		string hashString = "";

		for (int i = 0; i < hashBytes.Length; i++)
		{
			hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
		}

		return hashString.PadLeft(32, '0');
	}
 
}