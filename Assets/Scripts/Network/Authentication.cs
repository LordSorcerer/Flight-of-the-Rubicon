using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;
 
public class Authentication : MonoBehaviour
{
    private string secretKey = "lostintranslation"; // Edit this value and make sure it's the same as the one stored on the server
    public string serverURL = "thousandstorms.com/scripts/fotr.php"; //be sure to add a ? to your url
 	//Public extrusions
 	public Text usernameText;
	public InputField passwordText;
    public Text resultText;
	public Button loginButton;
    public Button newUserButton;

    void Start()
    {
        loginButton.onClick.AddListener(LoginClick);
        newUserButton.onClick.AddListener(NewUserClick);
    }
 
 	void LoginClick(){
 	    StartCoroutine(CheckLogin());
 	}

    void NewUserClick(){
        StartCoroutine(NewLogin());
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
    	string getURL = serverURL + "?username=" + WWW.EscapeURL(usernameText.text) + "&password=" +  WWW.EscapeURL(passwordText.text);
        WWW getConnection = new WWW(getURL);
        yield return getConnection;
 
        if (getConnection.error != null)
        {
            print("There was an error logging you in.  Please try again later or contact your administrator.");
        }
        else if (getConnection.text != null)
        {
            Debug.Log(getConnection.text.Trim());
            string result = getConnection.text.Trim();
            if (result.Contains("successcode01")) {
                resultText.text = "SUCCESS.  LOGGING INTO THE SERVER.";
                SceneManager.LoadScene("Mars"); 
            } else {
                resultText.text = "ERROR. USERNAME AND/OR PASSWORD INCORRECT.  PLEASE TRY AGAIN.";
            }

        }
    }

IEnumerator NewLogin()
    {
        string postURL = serverURL;
        string newUsername = WWW.EscapeURL(usernameText.text);
        string newPassword = WWW.EscapeURL(passwordText.text);
        Debug.Log(newUsername);
        Debug.Log(newPassword);
        WWWForm postData = new WWWForm();
        postData.AddField("newusername", newUsername);
        postData.AddField("newpassword", newPassword);
        WWW postConnection = new WWW(postURL, postData);
        yield return postConnection;
		if (string.IsNullOrEmpty(postConnection.error)){
		    resultText.text = "SUCCESS. YOUR NEW ACCOUNT HAS BEEN CREATED. YOU MAY LOG IN NOW.";
		} else {
            resultText.text = "ERROR. YOUR ACCOUNT COULD NOT BE CREATED AT THIS TIME.  PLEASE TRY AGAIN LATER OR CONTACT YOUR ADMINISTRATOR.";
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