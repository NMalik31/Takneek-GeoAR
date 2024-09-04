// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class GPSManager : MonoBehaviour
// {
//     // Set your mission location (latitude and longitude)
//     public double missionLatitude = 37.7749; // Example latitude
//     public double missionLongitude = -122.4194; // Example longitude
//     public float startMissionDistance = 30f; // Distance to start the mission in meters
//     public Text directionText; // UI Text to show direction and distance to mission

//     private bool missionStarted = false;

//     void Start()
//     {
//         // Start the GPS service
//         StartCoroutine(StartLocationService());
//     }

//     IEnumerator StartLocationService()
//     {
//         // Check if the user has location services enabled
//         if (!Input.location.isEnabledByUser)
//         {
//             Debug.LogError("Location services are not enabled.");
//             yield break;
//         }

//         // Start the location service
//         Input.location.Start();

//         // Wait until the service initializes
//         int maxWait = 20;
//         while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
//         {
//             yield return new WaitForSeconds(1);
//             maxWait--;
//         }

//         // If the service failed to start
//         if (Input.location.status == LocationServiceStatus.Failed)
//         {
//             Debug.LogError("Unable to determine device location.");
//             yield break;
//         }

//         // Successfully started
//         Debug.Log("Location service started.");
//         yield break;
//     }

//     void Update()
//     {
//         if (Input.location.status == LocationServiceStatus.Running)
//         {
//             // Get the player's current location
//             double playerLatitude = Input.location.lastData.latitude;
//             double playerLongitude = Input.location.lastData.longitude;

//             // Calculate the distance from the player to the mission location
//             float distance = CalculateDistance(playerLatitude, playerLongitude, missionLatitude, missionLongitude);

//             // Check if the player is within the range to start the mission
//             if (distance <= startMissionDistance)
//             {
//                 if (!missionStarted)
//                 {
//                     StartMission();
//                 }
//                 else if (missionStarted && distance > startMissionDistance)
//                 {
//                     // Notify the player that they are leaving the mission area
//                     directionText.text = "You are leaving the mission area. Please go back.";
//                 }
//             }
//             else
//             {
//                 // Show direction and distance to the mission location
//                 ShowDirection(playerLatitude, playerLongitude, missionLatitude, missionLongitude, distance);
//             }
//         }
//     }

//     // Calculates the distance between two GPS coordinates using Haversine formula
//     float CalculateDistance(double lat1, double lon1, double lat2, double lon2)
//     {
//         double earthRadius = 6371000; // Radius of the earth in meters
//         double dLat = (lat2 - lat1) * Mathf.Deg2Rad;
//         double dLon = (lon2 - lon1) * Mathf.Deg2Rad;

//         double a = Mathf.Sin((float)dLat / 2) * Mathf.Sin((float)dLat / 2) +
//                    Mathf.Cos((float)lat1 * Mathf.Deg2Rad) * Mathf.Cos((float)lat2 * Mathf.Deg2Rad) *
//                    Mathf.Sin((float)dLon / 2) * Mathf.Sin((float)dLon / 2);

//         double c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
//         float distance = (float)(earthRadius * c);

//         return distance;
//     }

//     // Shows the direction and distance to the mission location
//     void ShowDirection(double playerLat, double playerLon, double missionLat, double missionLon, float distance)
//     {
//         Vector2 playerPosition = new Vector2((float)playerLat, (float)playerLon);
//         Vector2 missionPosition = new Vector2((float)missionLat, (float)missionLon);
//         Vector2 direction = (missionPosition - playerPosition).normalized;

//         // Display direction and distance
//         directionText.text = $"Go {GetDirection(direction)}.\nDistance: {distance:F2} meters.";
//     }

//     // Determines the cardinal direction (N, E, S, W) to the mission
//     string GetDirection(Vector2 direction)
//     {
//         if (direction.x > 0.5) return "East";
//         else if (direction.x < -0.5) return "West";
//         else if (direction.y > 0.5) return "North";
//         else if (direction.y < -0.5) return "South";
//         else return "Straight";
//     }

//     // Starts the mission by loading the mission scene
//     void StartMission()
//     {
//         missionStarted = true;
//         SceneManager.LoadScene("MissionScene"); // Replace with your mission scene name
//     }
// }

// using System.Collections; // Required for IEnumerator
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;

// public class GPSManager : MonoBehaviour
// {
//     // Set your mission location (latitude and longitude)
//     public float missionLatitude = 37.7749f; // Example latitude
//     public float missionLongitude = -122.4194f; // Example longitude
//     public float startMissionDistance = 30f; // Distance to start the mission in meters
//     public Text directionText; // UI Text to show direction and distance to mission

//     private bool missionStarted = false;

//     void Start()
//     {
//         // Start the GPS service
//         StartCoroutine(StartLocationService());
//     }

//     IEnumerator StartLocationService()
//     {
//         // Check if the user has location services enabled
//         if (!Input.location.isEnabledByUser)
//         {
//             Debug.LogError("Location services are not enabled.");
//             yield break;
//         }

//         // Start the location service
//         Input.location.Start();

//         // Wait until the service initializes
//         int maxWait = 20;
//         while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
//         {
//             yield return new WaitForSeconds(1);
//             maxWait--;
//         }

//         // If the service failed to start
//         if (Input.location.status == LocationServiceStatus.Failed)
//         {
//             Debug.LogError("Unable to determine device location.");
//             yield break;
//         }

//         // Successfully started
//         Debug.Log("Location service started.");
//         yield break;
//     }

//     void Update()
//     {
//         if (Input.location.status == LocationServiceStatus.Running)
//         {
//             // Get the player's current location
//             float playerLatitude = (float)Input.location.lastData.latitude;
//             float playerLongitude = (float)Input.location.lastData.longitude;

//             // Calculate the distance from the player to the mission location
//             float distance = CalculateDistance(playerLatitude, playerLongitude, missionLatitude, missionLongitude);

//             // Check if the player is within the range to start the mission
//             if (distance <= startMissionDistance)
//             {
//                 if (!missionStarted)
//                 {
//                     StartMission();
//                 }
//                 else if (missionStarted && distance > startMissionDistance)
//                 {
//                     // Notify the player that they are leaving the mission area
//                     directionText.text = "You are leaving the mission area. Please go back.";
//                 }
//             }
//             else
//             {
//                 // Show direction and distance to the mission location
//                 ShowDirection(playerLatitude, playerLongitude, missionLatitude, missionLongitude, distance);
//             }
//         }
//     }

//     // Calculates the distance between two GPS coordinates using Haversine formula
//     float CalculateDistance(float lat1, float lon1, float lat2, float lon2)
//     {
//         float earthRadius = 6371000f; // Radius of the earth in meters
//         float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
//         float dLon = (lon2 - lon1) * Mathf.Deg2Rad;

//         float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
//                    Mathf.Cos(lat1 * Mathf.Deg2Rad) * Mathf.Cos(lat2 * Mathf.Deg2Rad) *
//                    Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

//         float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
//         float distance = earthRadius * c;

//         return distance;
//     }

//     // Shows the direction and distance to the mission location
//     void ShowDirection(float playerLat, float playerLon, float missionLat, float missionLon, float distance)
//     {
//         Vector2 playerPosition = new Vector2(playerLat, playerLon);
//         Vector2 missionPosition = new Vector2(missionLat, missionLon);
//         Vector2 direction = (missionPosition - playerPosition).normalized;

//         // Display direction and distance
//         directionText.text = $"Go {GetDirection(direction)}.\nDistance: {distance:F2} meters.";
//     }

//     // Determines the cardinal direction (N, E, S, W) to the mission
//     string GetDirection(Vector2 direction)
//     {
//         if (direction.x > 0.5f) return "East";
//         else if (direction.x < -0.5f) return "West";
//         else if (direction.y > 0.5f) return "North";
//         else if (direction.y < -0.5f) return "South";
//         else return "Straight";
//     }

//     // Starts the mission by loading the mission scene
//     void StartMission()
//     {
//         missionStarted = true;
//         SceneManager.LoadScene("MissionScene"); // Replace with your mission scene name
//     }
// }

// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using TMPro;

// public class GPSManager : MonoBehaviour
// {
//     public float missionLatitude = 37.7749f; // Example latitude
//     public float missionLongitude = -122.4194f; // Example longitude
//     public float startMissionDistance = 30f; // Distance to start the mission in meters
//     public TextMeshProUGUI directionText; // UI Text to show direction and distance to mission

//     private bool missionStarted = false;

//     void Start()
//     {
//         StartCoroutine(RequestLocationPermissionAndStartService());
//     }

//     IEnumerator RequestLocationPermissionAndStartService()
//     {
//         // Request location permission explicitly
// #if UNITY_ANDROID
//         if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation))
//         {
//             UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);
//             yield return new WaitForSeconds(1); // Wait briefly for user input
//         }
// #endif

//         // Check if location services are enabled
//         if (!Input.location.isEnabledByUser)
//         {
//             directionText.text = "Location services are disabled. Please enable them in settings.";
//             yield break;
//         }

//         // Start the location service
//         Input.location.Start();

//         // Wait until the service initializes
//         int maxWait = 20;
//         while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
//         {
//             yield return new WaitForSeconds(1);
//             maxWait--;
//         }

//         // If the service failed to start
//         if (Input.location.status == LocationServiceStatus.Failed)
//         {
//             directionText.text = "Unable to determine device location.";
//             yield break;
//         }

//         // Successfully started
//         directionText.text = "Location service started.";
//     }

//     void Update()
//     {
//         if (Input.location.status == LocationServiceStatus.Running)
//         {
//             float playerLatitude = (float)Input.location.lastData.latitude;
//             float playerLongitude = (float)Input.location.lastData.longitude;

//             float distance = CalculateDistance(playerLatitude, playerLongitude, missionLatitude, missionLongitude);

//             if (distance <= startMissionDistance)
//             {
//                 if (!missionStarted)
//                 {
//                     StartMission();
//                 }
//                 else if (missionStarted && distance > startMissionDistance)
//                 {
//                     directionText.text = "You are leaving the mission area. Please go back.";
//                 }
//             }
//             else
//             {
//                 ShowDirection(playerLatitude, playerLongitude, missionLatitude, missionLongitude, distance);
//             }
//         }
//     }

//     float CalculateDistance(float lat1, float lon1, float lat2, float lon2)
//     {
//         float earthRadius = 6371000f;
//         float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
//         float dLon = (lon2 - lon1) * Mathf.Deg2Rad;

//         float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
//                    Mathf.Cos(lat1 * Mathf.Deg2Rad) * Mathf.Cos(lat2 * Mathf.Deg2Rad) *
//                    Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

//         float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
//         float distance = earthRadius * c;

//         return distance;
//     }

//     void ShowDirection(float playerLat, float playerLon, float missionLat, float missionLon, float distance)
//     {
//         Vector2 playerPosition = new Vector2(playerLat, playerLon);
//         Vector2 missionPosition = new Vector2(missionLat, missionLon);
//         Vector2 direction = (missionPosition - playerPosition).normalized;

//         directionText.text = $"Go {GetDirection(direction)}.\nDistance: {distance:F2} meters.";
//     }

//     string GetDirection(Vector2 direction)
//     {
//         if (direction.x > 0.5f) return "East";
//         else if (direction.x < -0.5f) return "West";
//         else if (direction.y > 0.5f) return "North";
//         else if (direction.y < -0.5f) return "South";
//         else return "Straight";
//     }

//     void StartMission()
//     {
//         missionStarted = true;
//         SceneManager.LoadScene("MissionScene");
//     }
// }

// using System.Collections;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using TMPro;

// public class GPSManager : MonoBehaviour
// {
//     // Coordinates for the two mission locations
//     public float mission1Latitude = 37.7749f; // Example coordinates for mission 1
//     public float mission1Longitude = -122.4194f;
//     public float mission2Latitude = 34.0522f; // Example coordinates for mission 2
//     public float mission2Longitude = -118.2437f;
//     public float startMissionDistance = 30f; // Distance to start the mission in meters

//     public TextMeshProUGUI directionText; // UI Text to show direction and distance to mission
//     public GameObject selectionCanvas; // Canvas for selecting mission location
//     public GameObject distanceCanvas; // Canvas for showing distance and direction

//     private bool missionStarted = false;
//     private float selectedMissionLatitude;
//     private float selectedMissionLongitude;

//     void Start()
//     {
//         // Initially show the selection canvas and hide the distance canvas
//         selectionCanvas.SetActive(true);
//         distanceCanvas.SetActive(false);

//         // Start location service
//         StartCoroutine(RequestLocationPermissionAndStartService());
//     }

//     IEnumerator RequestLocationPermissionAndStartService()
//     {
// #if UNITY_ANDROID
//         if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation))
//         {
//             UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);
//             yield return new WaitForSeconds(1);
//         }
// #endif

//         if (!Input.location.isEnabledByUser)
//         {
//             directionText.text = "Location services are disabled. Please enable them in settings.";
//             yield break;
//         }

//         Input.location.Start();
//         int maxWait = 20;
//         while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
//         {
//             yield return new WaitForSeconds(1);
//             maxWait--;
//         }

//         if (Input.location.status == LocationServiceStatus.Failed)
//         {
//             directionText.text = "Unable to determine device location.";
//             yield break;
//         }

//         directionText.text = "Location service started.";
//     }

//     void Update()
//     {
//         if (missionStarted && Input.location.status == LocationServiceStatus.Running)
//         {
//             float playerLatitude = (float)Input.location.lastData.latitude;
//             float playerLongitude = (float)Input.location.lastData.longitude;

//             float distance = CalculateDistance(playerLatitude, playerLongitude, selectedMissionLatitude, selectedMissionLongitude);

//             if (distance <= startMissionDistance)
//             {
//                 if (!missionStarted)
//                 {
//                     StartMission();
//                 }
//                 else if (missionStarted && distance > startMissionDistance)
//                 {
//                     directionText.text = "You are leaving the mission area. Please go back.";
//                 }
//             }
//             else
//             {
//                 ShowDirection(playerLatitude, playerLongitude, selectedMissionLatitude, selectedMissionLongitude, distance);
//             }
//         }
//     }

//     float CalculateDistance(float lat1, float lon1, float lat2, float lon2)
//     {
//         float earthRadius = 6371000f;
//         float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
//         float dLon = (lon2 - lon1) * Mathf.Deg2Rad;

//         float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
//                    Mathf.Cos(lat1 * Mathf.Deg2Rad) * Mathf.Cos(lat2 * Mathf.Deg2Rad) *
//                    Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

//         float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
//         float distance = earthRadius * c;

//         return distance;
//     }

//     void ShowDirection(float playerLat, float playerLon, float missionLat, float missionLon, float distance)
//     {
//         Vector2 playerPosition = new Vector2(playerLat, playerLon);
//         Vector2 missionPosition = new Vector2(missionLat, missionLon);
//         Vector2 direction = (missionPosition - playerPosition).normalized;

//         directionText.text = $"Go {GetDirection(direction)}.\nDistance: {distance:F2} meters.";
//     }

//     string GetDirection(Vector2 direction)
//     {
//         if (direction.x > 0.5f) return "East";
//         else if (direction.x < -0.5f) return "West";
//         else if (direction.y > 0.5f) return "North";
//         else if (direction.y < -0.5f) return "South";
//         else return "Straight";
//     }

//     void StartMission()
//     {
//         missionStarted = true;
//         SceneManager.LoadScene("MissionScene");
//     }

//     // Called when Mission 1 button is clicked
//     public void SelectMission1()
//     {
//         selectedMissionLatitude = mission1Latitude;
//         selectedMissionLongitude = mission1Longitude;
//         ActivateDistanceCanvas();
//     }

//     // Called when Mission 2 button is clicked
//     public void SelectMission2()
//     {
//         selectedMissionLatitude = mission2Latitude;
//         selectedMissionLongitude = mission2Longitude;
//         ActivateDistanceCanvas();
//     }

//     void ActivateDistanceCanvas()
//     {
//         selectionCanvas.SetActive(false);
//         distanceCanvas.SetActive(true);
//     }
// }

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GPSManager : MonoBehaviour
{
    public float mission1Latitude = 37.7749f; // Coordinates for mission 1
    public float mission1Longitude = -122.4194f;
    public float mission2Latitude = 34.0522f; // Coordinates for mission 2
    public float mission2Longitude = -118.2437f;
    public float startMissionDistance = 30f; // Distance to start the mission in meters

    public TextMeshProUGUI directionText; // UI Text to show direction and distance to mission
    public GameObject selectionCanvas; // Canvas for selecting mission location
    public GameObject distanceCanvas; // Canvas for showing distance and direction

    private bool missionStarted = false;
    private float selectedMissionLatitude;
    private float selectedMissionLongitude;

    void Start()
    {
        // Initially show the selection canvas and hide the distance canvas
        selectionCanvas.SetActive(true);
        distanceCanvas.SetActive(false);

        // Start the location permission request and location service
        StartCoroutine(RequestLocationPermissionAndStartService());
    }

    IEnumerator RequestLocationPermissionAndStartService()
    {
#if UNITY_ANDROID
        // Check if the permission has been granted
        if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation))
        {
            // Request the permission
            UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.FineLocation);

            // Wait until the user responds to the permission request
            while (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.FineLocation))
            {
                yield return null;
            }
        }
#endif

        // Check if location services are enabled by the user
        if (!Input.location.isEnabledByUser)
        {
            directionText.text = "Location services are disabled. Please enable them in settings.";
            yield break;
        }

        // Start the location service
        Input.location.Start();

        // Wait until the service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // If the service failed to start
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            directionText.text = "Unable to determine device location.";
            yield break;
        }

        // Successfully started
        //directionText.text = "Location service started.";
    }

    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        {
            float playerLatitude = (float)Input.location.lastData.latitude;
            float playerLongitude = (float)Input.location.lastData.longitude;

            float distance = CalculateDistance(playerLatitude, playerLongitude, selectedMissionLatitude, selectedMissionLongitude);

            if (distance <= startMissionDistance)
            {
                if (!missionStarted)
                {
                    StartMission();
                }
                else if (missionStarted && distance > startMissionDistance)
                {
                    directionText.text = "You are leaving the mission area. Please go back.";
                }
            }
            else
            {
                ShowDirection(playerLatitude, playerLongitude, selectedMissionLatitude, selectedMissionLongitude, distance);
            }
        }
        else
        {
            directionText.text = "Location service is not running.";
        }
    }

    float CalculateDistance(float lat1, float lon1, float lat2, float lon2)
    {
        float earthRadius = 6371000f; // meters
        float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
        float dLon = (lon2 - lon1) * Mathf.Deg2Rad;

        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
                   Mathf.Cos(lat1 * Mathf.Deg2Rad) * Mathf.Cos(lat2 * Mathf.Deg2Rad) *
                   Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        float distance = earthRadius * c;

        return distance;
    }

    void ShowDirection(float playerLat, float playerLon, float missionLat, float missionLon, float distance)
    {
        Vector2 playerPosition = new Vector2(playerLat, playerLon);
        Vector2 missionPosition = new Vector2(missionLat, missionLon);
        Vector2 direction = (missionPosition - playerPosition).normalized;

        directionText.text = $"Go {GetDirection(direction)}.\nDistance: {distance:F2} meters.";
    }

    string GetDirection(Vector2 direction)
    {
        if (direction.x > 0.5f) return "East";
        else if (direction.x < -0.5f) return "West";
        else if (direction.y > 0.5f) return "North";
        else if (direction.y < -0.5f) return "South";
        else return "Straight";
    }

    void StartMission()
    {
        missionStarted = true;
        SceneManager.LoadScene("MissionScene");
    }

    // Called when Mission 1 button is clicked
    public void SelectMission1()
    {
        selectedMissionLatitude = mission1Latitude;
        selectedMissionLongitude = mission1Longitude;
        ActivateDistanceCanvas();
    }

    // Called when Mission 2 button is clicked
    public void SelectMission2()
    {
        selectedMissionLatitude = mission2Latitude;
        selectedMissionLongitude = mission2Longitude;
        ActivateDistanceCanvas();
    }

    void ActivateDistanceCanvas()
    {
        selectionCanvas.SetActive(false);
        distanceCanvas.SetActive(true);
    }
}

