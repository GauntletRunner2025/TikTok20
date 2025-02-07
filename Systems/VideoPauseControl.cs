// using Unity.Entities;
// using UnityEngine;
// using UnityEngine.UIElements;

// public partial class VideoPauseControl : SystemBase
// {
//     protected override void OnStartRunning()
//     {
//         // Find UIDocument in the scene
//         var uiDocument = Object.FindObjectOfType<UIDocument>();
//         if (uiDocument == null)
//         {
//             throw new System.Exception("No UIDocument found in scene");
//         }

//         // Get the pause button
//         var root = uiDocument.rootVisualElement;
//         var pauseButton = root.Q<Button>("PauseButton");
//         if (pauseButton == null)
//         {
//             throw new System.Exception("No Button with name 'PauseButton' found in UIDocument");
//         }

//         // Create entity to track button
//         var entity = EntityManager.CreateEntity();
//         EntityManager.AddComponentData(entity, new PauseButtonReference { Value = pauseButton });

//         // Register click handler
//         pauseButton.clicked += () =>
//         {
//             var requestEntity = EntityManager.CreateEntity();
//             EntityManager.AddComponent<PauseToggleRequest>(requestEntity);
//         };

//         RequireForUpdate<PauseButtonReference>();
//         RequireForUpdate<VideoPlayerReference>();
//     }

//     protected override void OnUpdate()
//     {
//         if (!SystemAPI.ManagedAPI.HasSingleton<PauseButtonReference>() ||
//             !SystemAPI.ManagedAPI.HasSingleton<VideoPlayerReference>())
//         {
//             return;
//         }

//         var pauseButton = SystemAPI.ManagedAPI.GetSingleton<PauseButtonReference>().Value;
//         var videoEntity = SystemAPI.ManagedAPI.GetSingletonEntity<VideoPlayerReference>();

//         if (pauseButton == null)
//         {
//             return;
//         }

//         // Update button text based on pause state
//         pauseButton.text = SystemAPI.HasComponent<IsPaused>(videoEntity) ? "Play" : "Pause";
//     }
// }
