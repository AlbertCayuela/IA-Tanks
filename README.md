# Artificial Intelligence - Assignment 1
### By Albert Cayuela Naval and Aleix Castillo Arrià.
You can check our GitHubs here: 

Project:  https://github.com/AlbertCayuela/IA-Tanks

Albert Cayuela: https://github.com/AlbertCayuela 

Aleix Castillo: https://github.com/AleixCas95 

Download latest release here:

https://github.com/AlbertCayuela/IA-Tanks/releases 

### Design of the game: 

In the game there are two tanks, blue and red, blue tank is going to be patrolling around the map following a known path and the red tank is going to be wandering around the map seeking random points. 

Once the both tanks get into a predefined range, they detect each other. When they detect each other, the blue tank is automatically going to seek the red one, meanwhile the red one is one to flee from the blue one, making like this a persecution around the map. Once they detect each other, they are going to start shooting each other too, using parabolic shot programmed script in order to make it more realistic. This persecution and shooting is going to be going on until one of the tanks has 0 points of life, then the game is ended.

### Important information:

*All the code is original and you can check our whole project (including, scripts, scenes, prefabs…) importing the package we provided you in the .zip or downloading our project from our GitHub repository.

*We used a different parabolic shot formula from the one provided in the course, this one worked better for us:

Knowing the distance and speed the formula is (You can check the implementation in the script called Shoot.cs): 

angle = (asin((g * x) / (v * v))/(2)

*In order to play the whole game loop from your unity project you will have to add our three scenes to your compiler -> Import our unitypackage to your project -> Open the three scenes we provide you -> File -> Build settings -> Add your scenes to the builder following this order MainMenu(0) -> Game(1) -> EndMenu(2) -> Play the game from the MainMenu scene.

*In case you are a teacher of the course and you cannot see our repository, check your email, we already sent you an invitation. If the invitation does not exist, contact us through a message and we will invite you as soon as possible.

### Game content:

One Main Menu Scene with:

-  	A Start Game button
-   GitHub button that leads you to the GitHub page
-  	Exit Game button

In Game Scene with:

-   A countdown timer at the start of the game
-   A timer that counts how many time each round has
-  	UI interactive features:
-  	Warning effect
-  	Health numbers and bar
-  	Reloading animation
-  	Shot particles
-  	Shell effects
-  	Explosion effect
-  	Interactive UI with who won

- Pause Menu with while pressing esc with:

-  	Resume button
-  	GitHub button
-  	Exit button

- End Game menu with:

-  	Play Again button
-  	GitHub button
-  	Exit button
