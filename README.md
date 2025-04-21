# Game

## Table of Contents

- Requirements
- Installation
- Troubleshooting
- Graphical Abstract
- Software Development Process & Purpose
- Software Development Plan
- Extra

## Requirements
For developers/those who want to inspect the source code in an editor environment, the [Unity Hub Application](https://unity.com/unity-hub) is required.

In order to ensure smooth gameplay, the following specs (minimum) are highly recommended:  
OS: Windows 10 or later/macOS High Sierra 10+ or later  
Processor: Intel i5-8th Gen or equivalent  
Memory: 8GB RAM  
Graphics: GeForce GTX 950 or equivalent  
DirectX: Version 11/12 capable  
Storage: 5 GB available space  
Additional Notes: These are tentative and not final. Performance may vary from machine to machine.

## Installation
For the binaries, fork and clone this git repository via the SSH command as you would normally do.  
```git clone git@github.com:Web4iscoding/FPS-Game.git```  
For the game, please download via [here](https://mega.nz/file/huQR0L4J#uxirrVUltJPXVKJ0GhV3TBJSnUQsbzgcpLvE46DFOi8) (Windows) or [here](https://mega.nz/file/RihCjA6T#xQ0oEI1sCcRqXQ-RF8NnqnucYiQJNuuijYZe4JgbxyQ) (Apple Silicon) and run the game by clicking on the "Game Project" application.

## Troubleshooting
**Q: Error is reported upon running the macOS version: "Game Project” can’t be opened because Apple cannot check it for malicious software.**  
**A:** This error is commonly caused by an update in the way that gatekeeper works on Catalina+. To address this issue, hold control + right click the application, then click "open" to launch; if this still does not solve the issue, try the following command: sudo spctl --master-disable.

## Graphical Abstract
For this proposed project, a First Person Shooter (FPS) game is built using the Unity Engine.  
The game is a multi-platform First Person Shooter (FPS) game with multiple modes and can guarantee endless hours of replayability. With tutorial mode, the game’s basic mechanics can be thoroughly understood via the easy-to-follow on-screen instructions. The actual game is separated into 2 parts – Normal mode and Battle mode; with normal mode, the player can experience all the scenes independent to each other with a variety of difficulties; with battle mode, the level order is designed in a way to make the mode streamlined with an end after the boss battle.


![image](https://github.com/user-attachments/assets/59daeaad-0ef0-4763-bffb-8431710a2f06)
Player UI during gameplay.


![image](https://github.com/user-attachments/assets/3ad40c17-8064-4e05-946b-9349f2b065b3)
![image](https://github.com/user-attachments/assets/36dc67f2-d097-42c3-9f94-57ef88db0fdf)
![image](https://github.com/user-attachments/assets/26111644-08ed-482c-bc4f-3568570804de)
From top to bottom: Pistol, AK-47, bat melee.


<img width="131" alt="image" src="https://github.com/user-attachments/assets/bd83c8c3-4bdf-4e33-a05e-535f9c8f1b3e" />
<img width="128" alt="image" src="https://github.com/user-attachments/assets/5b2fb442-812a-4d78-9cc8-20245880a318" />
<img width="126" alt="image" src="https://github.com/user-attachments/assets/480a4a5b-d3b9-4842-be1f-9f4310e70010" />
HP UI’s color changing in action.


![image](https://github.com/user-attachments/assets/2c6dd09f-235a-4957-a159-5234460dba1c)
Upon triggering player death.


![image](https://github.com/user-attachments/assets/f0c97cc8-08fc-46a2-ad49-54a1415bce7c)
Main Menu.


![image](https://github.com/user-attachments/assets/f4175c48-68c2-4523-a759-4c2063e4c6d8)
Difficulty select screen.


![image](https://github.com/user-attachments/assets/e0362d18-855b-4056-aa33-0d7e1def84fb)
Settings menu as accessed from the main menu.


![image](https://github.com/user-attachments/assets/6ac31b6b-8b2b-46ad-99d2-b4d72d0786ce)
Settings menu as accessed during gameplay.


![image](https://github.com/user-attachments/assets/dda97f9c-bdfd-4e8f-80d0-9031abfe1665)
Select scenes screen.


![image](https://github.com/user-attachments/assets/5b16c986-4707-450c-ac3a-68f251dba414)
"Living Room" Scene.


![image](https://github.com/user-attachments/assets/f36e82e9-efa2-470a-8af8-a80c70b8b2b9)
"Domain" Scene.


![image](https://github.com/user-attachments/assets/79fcaa81-bfb0-4349-97a9-bb995941ae7d)
"City" Scene.


![image](https://github.com/user-attachments/assets/a5458cbb-3337-43c1-8e6a-6711e8784f4e)
"PreBoss" Scene.


![image](https://github.com/user-attachments/assets/9d3184a7-5a76-490c-8a3c-d2f4b6975410)
"Boss" Scene.


![image](https://github.com/user-attachments/assets/f8f14143-1590-4bfc-b084-a922c318db24)
From left to right: Mannequin, Prison Realm and Zombie. (enemy NPCs)


![image](https://github.com/user-attachments/assets/44b6d13c-ed49-4de0-a646-e99b824ddd0e)
Tutorial mode in-game screenshot. The player can progress by pressing the left mouse button.

## Software Development Process & Purpose
For the implementation of this project, an Agile approach was taken.  
With the nature of this project, an Agile approach is better understood as a more "agile" way to respond to market's needs. Moreover, the elements of a video game can undergo a series of changes during development, which may force developers to implement such features mid-development; the differences between the Waterfall and the Agile software development process for this project will be further expanded below to detail the advantages of using the latter approach.

### Waterfall
Waterfall development, which is defined as a "plan-driven" model, is one with separate and distinct phases of specification and development:
1. Requirements definition
2. System and software design
3. Implementation and unit testing
4. Integration and system testing
5. Operation and maintenance

For the development of this software, if it were to take on the approach of the Waterfall method, our team would have to focus immensely on both the requirements definition and system & software design stages to avoid the situation of accomodating change (new features) after the process is underway. However, the flexible nature of our software's changes makes it unfavorable in a plan-driven environment; combined with the need for a prioritized Time-to-Market approach, this method would make it difficult for the team to respond to changing customer requirements.

### Agile
Agile development, which is defined as engineering the software with the stages of Program Specification, Program Design and Program Implementation being inter-leaved, is viewed as more suitable for our development plan. As releasing prototypes or beta versions during the development of a video game is a must, it can only be achieved with an Agile approach. Moreover, the ever-changing of the features of this software makes it an absolute requirement to adopt a process which can respond to changes easily, which, with Agile, combined with a framework like Scrum, makes this possible via accomodating changes during sprints. Additionally, this approach is even more supported by the fact that the software requires a high Time-to-Market, which according to the strategy detailed in the paper [Strategic Decision Spectrum for Software Engineering](https://ieeexplore.ieee.org/document/10406807) by Dr. Song-Kyoo (Amang) Kim, the development method should shift its focus towards Agile on the Zone of Strategic Fit if we desire a good Time-to-Market, with one supporting example being the development of the APF (Action Puzzle Family) mobile game by South Korean company Com2uS.

**Q: What's the intending market of this software?**

**A:** The target market of this software is the FPS playerbase who seeks a game with simple but fun mechanics, with a high-score system that enables players to compete with others to keep on with the replayability, similar to the massively popular video game DOOM.

## Software Development Plan
### Development Process
As mentioned, an Agile approach is taken for the development of this project.

The stages of developement are defined by the time separated between sprint sessions, and daily communications in a private SNS group:
- Sprint Session: This is where the group gathers around to discuss the project in an overview-esque light. During one session, under the leadership of the Master, every member (including the Master himself) reports on the progess of their respective roles, as such, big updates for the software are often proposed here and are made a list of goals to be completed before the next sprint session.
- Daily Communication: This composes of the communication (usually between two members) that involves the casual reporting of real-time news such as game-breaking errors that need to be fixed immediately, or any other small suggestions that can be implemented into the software itself without altering the goalpost of the current sprint objectives.

For a more detailed view into the development process of this software, let's expand more into the "sprint" aspect.  
Our team adopted a lightweight approach similar to that of the Scrum framework, which can be separated into the following:  
1. The Initial Phase
2. Sprint Cycles
3. Project Closure  

#### The Initial Phase
This was the first ever group session during the first week, which was also one of the most important aspects to the development of this software.  
During this phase, the members are separated into two sub-teams, notably the Main Developers Team and the Design & Testing Team, for the ease of separation of work. Then, the general objectives for this project was first proposed, being defined as the features outlined below:
1. Main Character
2. Game Logic
3. Menu
4. Enemies
5. Timer
6. Difficulties
7. Different Scenes
8. Settings
9. Tutorial Mode
10. Advanced Game Mechanics
11. Battle Mode

These elements were first proposed with a general view for their functions, with more features and specifications in each element to be introduced in later sprints.  
Furthermore, the Design & Testing team co-operated with the design of 3D levels, characters, and game mechanics.

#### Sprint Cycles
After each sprint session every week, a sprint cycle begins.  
In each sprint cycle, the Main Developers Team becomes the main force for the implementation of the proposed features with the help of the Design & Testing Team for minor coding; the main focus of the latter team is to keep expanding on the requirements of each corresponding feature and be the tester for each feature once one requirement has been finished.

For the testing of feature, as the uploading of the entire project folder onto GitHub would exceed the size limit of a remote git repository and require Git LFS (Large File Storage), the finished snippets would be uploaded onto a Google Drive instead, and the Design & Testing Team would access the source code there and test directly; this approach works as our team is relatively small, so losing any feature that GitHub provides us is not necessary a big loss compared to when the development's handled by a large corporation.

Additionally, during requirement engineering, no actual documentation was produced, instead, our team communicated directly for any new features to be updated.

#### Project Closure
The Project Closure phase was reached during the last week of development, which wrapped up the project and decided the necessary pieces of files to be pushed onto this git repository. This documentation was also written during this phase.

### Members (Roles & Responsibilities & Portion)
The team is separated into two sub-teams: the Main Developers Team and the Design & Testing Team. The former, is the team of the developers that deal with the Program Implementation part of the Agile process, they might (using the C# language in this case) build features from the ground up or implement modules from external libraries; the latter, is the team that is involved in the Program Specification (requirement engineering), Program Design (3D modeling and design, architecture design), and Testing procedures, with its additional minor role being a support team to the Main Developers Team by implementing smaller and not as important features.

#### The Main Developers Team
**Chong Kuan Pok COMP2116-221 p2304402 (Scrum Master)**  
Responsible for the organziation of meetings and sprint sessions, and acts as the main force of this project. Contributed to the implementation of all of the features.  
**Lai Chon Hou COMP2116-221 p2304281**  
Acts as the secondary force of the engineering procedure; worked on the programming behind Main Character, Enemies, Different Scenes, Settings, Tutorial Mode and Battle Mode.

#### The Design & Testing Team
**Lin Wai Wa COMP2116-221 p2304127**  
Concerns with the design of the "Living Room" and "PreBoss" scene, UI, "Mannequin" enemy; responsible for the testing procedure.  
**Milena Li COMP2116-221 p2304415**  
Concerns with the design of the "Domain" and "Boss" scene, UI, "Prison Realm" enemy; responsible for the testing procedure.  
**Pong Nga Man COMP2116-223 p2303993**  
Concerns with the design of the "City" scene, UI, Settings, "Zombie" enemy; responsible for the testing procedure.

### Schedule
For the ease of comprehension, the schedule of the development process is presented in the form of a gantt chart.  
Do keep in mind each sprint meeting takes place between the subsequent weeks.

![image](https://github.com/user-attachments/assets/4b6bff95-6d28-4677-aea2-1c056c88651c)

### Algorithm
The software functions with a series of coded algorithms interacting with one another.  
For example, every model/mesh has its own logics written behind it, which is tied to a specific script file written in C#.  
To go more in-depth, take the enemies' AIs for instance, every enemy has their own finding path algorithm defined by the NavMesh API provided by Unity; the implementation behind the API is blackboxed, but the feature is achieved via the detection of NavMesh Surface by the NavMesh API, which provides a reliable method of chasing the Player via its path tracking.  
Moreover, the enemies' logics are bounded by the use of State Machines and Singletons, with states such as Idle, Walking, Running, Attacking, and Dying, which are triggered by their respective stimulus.  

![image](https://github.com/user-attachments/assets/fd9b020b-aedb-480e-9f5b-b8a1d476952a)

### Current Status
As of now (one month after the Initial Phase of the project), the team has fulfilled every features proposed initially.  

#### Development Phase
The game is released as an official stable release of v1.0.

#### Core Features
 - Main Character  
The main character includes various basic functions not limited to: Movement, shooting, close attack, silent walk and HP bar. The movement of the player character is achieved via the universal WASD keybinds, with W being forward, S being backward, A being to the left and D being to the right.  
Shooting is achieved via the standard left clicking of the mouse.  
Left clicking of the mouse functions differently according to the current selected weapon, for long-ranged weapons (Pistol and AK-47), the button will perform the shooting function; for short-ranged weapon (Bat melee), the button will perform the swing action and damage nearby enemies.  
Silent walk can be performed using the left CTRL button on the keyboard. When silent walk is toggled, player speed will be reduced by half of what was stored as the default speed, and the camera will be slightly pushed down to simulate the illusion of crouching.  
Sprinting can also be utilized via using the left Shift button on the keyboard. With sprinting, the player’s speed will be increased by 2 times that of the original moving speed.  
HP bar of the player can be found at the bottom left of the screen during gameplay. The UI changes color in accordance to the current health status: Green on full health, yellow when the health drops below 100, and red when it decreases near 40.  
 - Game Logic  
The game - during normal mode – is designed to be a loop. The enemy spawns are infinite and will not stop or interfere the game in any way, the only way for the game to end is to trigger the player death animation, which then makes the game to return to the main menu; from there, players can choose to continue the game, hence, creating a loop.
 - Menu  
The main menu of the game is relatively simple, with only three buttons to choose from: PLAY, SETTINGS, EXIT. They function exactly as the wordings say.
 - Enemies  
There are three main types of enemies present: Mannequin, Prison Realm and Zombie.  
Each enemy has their own unique animations, HP and models. Mannequin and Zombie are designed to be humanoid enemies which deal damages with their hands, each with different chasing speed, the former being faster and the latter being slower. Prison Realm is a unique enemy only present in the Domain scene, it is a cube-shaped monster with an extremely fast chasing speed; The damage dealt to the player can be exponentially high due to the implemented features of the enemy, as a result, only one Prison Realm enemy is present at a time.  
Other than the three mentioned standard enemies, a special Boss Mannequin can be found during the end of Battle mode. It is the boss version of the mannequin with increased size and damage.
 - Timer  
A simple timer can be found at the upper left of the screen during gameplay which indicates the current session’s playtime in simple {Minutes}:{Seconds} notation.
 - Difficulties  
After selecting the scene to be loaded into for Normal mode, three difficulties are provided for the player to choose from: Easy, Medium and Hard.  
As the wordings imply, the difficulty of the game scales up or down depending on the player’s choice. The effects of altering the difficulty include: changing of HP, chasing speed, damages and number of spawns per wave of enemies.
 - Scenes  
There are three main scenes: Living Room, Domain and City; each equipped with its own enemies and map.  
As the name implies, the Living Room scene takes place in a living room with Mannequins being the main enemies. The props in this map are entirety interactable, meaning that real-time physics will be applied to the items when they are moved by an external force (e.g. bullets).  
The Domain scene has its main stage set on a beach, with a temple on top of a hill surrounded by palm trees. The main enemy of this scene is the Prison Realm. It is a relatively small map which reduces walkable area and forces the player to engage with the enemy close-up.  
City, as the name suggests, is a map based on a city. The main enemies of this stage are Zombies. As the map’s size is comparably large, the enemy spawner is tied to the player’s location instead of being in fixed coordinates, so the Zombies will always spawn near the player in each wave.  
There are two more scenes that are exclusive to Battle mode: PreBoss and Boss Scenes. We will explore more of these scenes in the Battle mode section later on.
 - Settings  
The setting menu can be accessed from either in-game or the main menu. The settings consist of brightness, Dots Per Inch (DPI) and volume. The slider bars are adjustable from: 0.1 – 5 for brightness, 10 – 100 for DPI and 0 – 1 for volume.  
Once changed, the effects are applied throughout the entire game with the values stored using Unity’s PlayerPref.
 - Tutorial Mode  
Tutorial mode gives valuable intel to the player as to how the game functions, its mechanics and a general overview of how the game should be played.  
It is designed to be simple with the principle of hand-holding the player step by step in mind, with following the instructions presented on screen, we aim to explain the game in-depth.  
 - Advanced Game Mechanics  
As mentioned earlier, there are 3 weapons in the game: Pistol, AK-47 and bat melee.  
You can change between the weapons by pressing either: 1 for Pistol, 2 for AK-47 and Q for melee weapon.  
 - Battle Mode  
Battle mode is a mode that provides “levels” or “rounds” to complete with sub-rounds known as “waves” within each level; a boss can be found at the end which indicates an end to the mode.  
The order of this mode is of the following:  
Living Room (Wave 1)  
Living Room (Wave 2)  
Living Room (Wave 3)  
Domain (Wave 1)  
Domain (Wave 2)  
Domain (Wave 3)  
City (Wave 1)  
City (Wave 2)  
City (Wave 3)  
PreBoss  
Boss  
It should be noted that unlike Normal mode, each new wave doubles the number of enemies previously presented. (e.g. 4 Mannequins in Wave 1 → 8 Mannequins in Wave 2 → 16 Mannequins in Wave 3)  
The PreBoss scene is the second final scene just before the boss battle. It features a mixture of Mannequin and Zombie enemies, when all the enemies are defeated, it automatically transits to the final boss battle; this scene functions independently from the other scenes and does not contain waves.  
The Boss scene has 2 types of enemies: Mannequin Boss and Mannequins.  
The objective of this scene is to defeat the final boss of the mode; once Mannequin Boss is defeated, the mode ends and returns to the main menu automatically after displaying the winning screen.  

#### In-Progress Work
As of now, the multi-player feature and a leaderboard feature are being developed.

#### Supported Platform
Thanks to the flexibility of the Unity plaform, the game is easily supported on both Windows and macOS.

### Future Plan
For future iterations, the game will be refined to produce a more pleasant UI design.  
Additionally, multi-player and leaderboard features will be implemented to compete with the online gaming market; with Agile, these complex features will be pushed out via beta releases until a stable version is reached, which will be v2.0, the next big update.

## Extra
[Demo Video](https://youtu.be/HCXc2Tztb9c?si=dDflOQ1Kwmdkw8CY)
