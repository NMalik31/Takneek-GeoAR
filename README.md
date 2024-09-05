# Invasion AR
# Vision
The AR Shooter Game aims to bring an immersive Augmented Reality (AR) experience to mobile devices using Unity, ARCore, and Cesium. The game combines real-world location data with engaging shooting mechanics, creating a dynamic environment where players interact with virtual enemies in real-world locations. The main objective is to blend the digital and physical worlds, making the player's surroundings an integral part of the gameplay.

## Features
Geospatial Integration: The game uses real-world GPS coordinates to determine player proximity to mission locations, guiding players with directional prompts based on their current location.
Mission-Based Gameplay: Players can select from multiple mission locations, each with unique coordinates and objectives. When close to a mission location, a specific mission scene will load, creating a dynamic narrative.
Shooting Mechanics: Players can engage with enemies using AR shooting mechanics. The game includes realistic gunshot sounds and shooting effects, enhancing the immersive experience.
Enemy Spawning: Enemies appear in AR space, moving and attacking the player. The game implements enemy behavior such as patrolling, attacking, and spawning in specific areas, adding challenge and excitement.
Proximity Alerts: The game monitors the player’s location relative to mission areas. If a player moves too far from the mission location, a warning prompts them to return, maintaining gameplay within the designated area.
Audio Experience: Background music and sound effects enhance the atmosphere, from the start menu to in-game actions, providing an engaging and immersive audio experience.
Alien-Themed Enemies: Enemies have an alien texture, distinguishing them visually and thematically, and adding a unique element to the gameplay.
Game Flow
Start Menu: The game begins with a start menu where players can select their mission.
Mission Selection: Players choose between different mission locations via a canvas with interactive buttons.
Proximity Detection: Upon selecting a mission, the game displays the player's distance and direction to the chosen mission location.
Mission Activation: When within the mission range, a mission-specific scene starts, populated with enemies and interactive gameplay.
Gameplay: Players engage with enemies using shooting mechanics. If players stray too far from the mission, a warning is triggered.
Completion: Players complete objectives within mission areas, progressing the game narrative.

## Technologies Used
Unity: Primary game engine used for development.
ARCore: Used for tracking, environment recognition, and interaction with real-world coordinates.
Cesium for Unity: Provides accurate geospatial data, enhancing ARCore’s capabilities with high-precision real-world positioning.
XR Origin: Instead of AR Session Origin, XR Origin manages AR interactions and positioning.

## Setup and Installation
Clone the repository to your local machine.
Open the project in Unity (ensure you have the latest ARCore and Cesium for Unity packages installed).
Build and run the project on an Android device with ARCore support to experience the game.
Or you can use the apk file if provided.

## Future Development
Expanded Mission Content: Add more mission locations and unique objectives to enhance replayability.
Enhanced Enemy AI: Further development of enemy behaviors, including strategic movement and varied attack patterns.
Multiplayer Integration: Explore the possibility of adding multiplayer features for cooperative or competitive gameplay.
Visual Enhancements: Improved textures, shaders, and visual effects to further immerse players in the AR environment.

## Contributions
Game made by Aryans GeoMatrix Team!
