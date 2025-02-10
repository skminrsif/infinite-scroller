# Project: Photo (not the final name)
## Instructions to Run
The game is both able to run in Unity editor (Unity 2022.3.7f1) and as an executable.

### Unity Editor Way:
1. Install Unity 2022.3.7f1.
2. Import 'infinite-scroller' folder from Unity Hub.
3. Press play.

### Executable way:
1. Go into the 'Builds' folder.
2. Go into the 'Downloadv2' folder.
3. Open 'infinite-scroller.exe.

If all comes to worse, and those do not work, I also uploaded it on itch.io. However, the controls are buggy and/or laggy on itch.io for some browsers.
Link: https://siffedup.itch.io/project-photo
Password: picturesarenice

## Game Instructions
Movement: W/S keys or Up/Down arrow keys
Change Camera Views: RMB

## Status
The game is still being developed. I still have yet to implement the final biggest mechanic: taking pictures - but it is being developed right now.
The game does have minor, major and game-breaking bugs. I have only listed the game-breaking ones. **None of these bugs prevent the game from running.** 
There are some comments on my code that signifies what I intend on fixing, in terms of code optimization - I found that I have been reusing code a lot, so I
intend on separating some classes into different classes.

### Features that are currently in the game:
- Able to move.
- Able to switch cameras from isometric view to POV view.
- Lives and survival time score on the top left corner (working as intended).
- End game condition: lives = 0 > the player will be forced to quit, as the game timer will pause.
- Enemy and pick-ups are able to move towards the player.
- Enemy and pick-ups are able to collide with the player.
- Player rag-doll when being hit by an enemy car.
- Enemy, scenery and pick-ups spawner working as intended.
- Scenery boards are moving in a scrolling fashion as intended.

### Features that are still being developed:
- Being able to take pictures
- Storing those pictures temporarily
- Pop-up menu that shows temporarily stored pictures (like a journal)
- Ability to choose to permanently save chosen pictures.
- Ability to honk at enemy cars to make them go faster (despawning them)
- Number of enemies ramping up as the game goes on.

### Game-breaking Bug
- If player were to get launched in the air by some objects, they will get locked out of quitting via game controls on the executable. These objects include:
    - Weird scenery blocks spawning near upper boundary of the game.
    - Bad collisions with enemy car objects.
- If this were to happen, please exit via Alt-F4.


