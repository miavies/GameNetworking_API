using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public static class APIManager
{
    public const string BASE_URL = "https://dogapi.dog/api/v2/breeds?page%5Bnumber%5D=";
    public const string CONT_URL = "&page%5Bsize%5D=10";
    public static IEnumerator Get<T>(string route, Action<T> OnSuccess, Action<string> OnError)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(BASE_URL + route))
        {
            yield return webRequest.SendWebRequest();
            
            if(webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.downloadHandler.text);
                try
                {
                    var objData = JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text);
                    OnSuccess?.Invoke(objData);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            }
            else
            {
                Debug.LogError($"Unsuccessfully sent a request to {BASE_URL + route}");
                OnError?.Invoke(webRequest.error);
            }
        }
    }   
}