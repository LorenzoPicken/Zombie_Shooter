<h1>Zombie Shooter</h1>
<p>Zombie Shooter is a placeholder name for this small unity project. Heavily inspired by the likes of the Call of Duty Zombies mode, this is an endless zombie horde shooter where the player must try and survive for as many rounds as possible against waves of monsters. As the rounds go by the foes will grow stronger and more numerous, making it harder for the player to uncover new areas and obtain new weapons. This project was our first foret into video game creation and the unity engine. As a team of two, we were able to put together this game within aproximately 3 months. Originally planned to be a rouge like arena shooter with gun mechanics reminissant of doom, then changed to be an rpg, wave shooter with a looting and crafting system, we eventually scaled down the project to the current simple hoard shooter that it is now.</p>
<br>

<h1>Gameplay</h1>
<p>The gameplay loop is quite simple. The player will kill zombies to gain points. Using these points the player can purchase more powerful weapons and unlock new areas of the map to explore. As the rounds go on, the difficulty will increase making it harder and harder for the player to survive. The zombies will continuously chase the player, attempting to get within melee range in order to do damage to them. If the player takes too many hits in quick succession, they will die causing the game to end and displaying statistics such as game length, total kills and number of rounds completed. Gameplay has three main components, the weapons, the map and the zombies which the player interacts with throughout a playthrough.</p>
<br>

<h2>Weapons</h2>
<p>Starting with the weapons, there are four that the player will be able to use during the game, these are the baseball bat, the pistol, the rifle and the smg. The player will start with the bat and will need to collect more points in order to unlock the other weapons. The bat is the weakest and will loose its edge very quickly as the zombies get stronger and faster. After that, the pistol is the next weapon the player unlocks with a small magazine and low damage. After that, it goes to the rifle with high damage but a slow fire rate. Finally, the smg is the strongest weapon, offering a high fire rate, great damage and a large magazine capacity. The player will have access to an unlimited supply of reserve ammunition and will only need to buy new weapons in order to make progression easier. Only one weapon can be carried at any time however, once unlocked, a weapon can be reaquired at its purchase station for free at any time if it isnt the current equipped weapon.</p>



<h2>The Map</h2>
<p>The castle is the only map available in the game and was designed by Matteo who worked on level design for this project. The castle is a medium size map consiting of spacious outdoor courtyards, cramped hallways and a messy dining hall where the player can explore and loop foes. To give a sense of progression, areas of the map are blocked off by default and will need to be unlocked by paying with points. The courtyard is the starting spawn point for the player and is where the bat can be aquired, from here, the player can purchase access to the castle rampart, where they can find the first part of the armour set and the pistol. After aquiring more funds, the castle can be unlocked granting access to another two pieces of the armour set and the rifle found next to the dining hall. Finally, the final location containing the smg and the final armour piece is the townhouse area, a secondary external courtyard with a nice looping spot.</p>


<h2>The Zombies</h2>
<p>Being the players main threat aside from a lack of funds, a lot of care was put into ensuring the zombies felt challenging but fair. As the game progresses, zombies will become more and more overwelming. Each round, their stats go up. This includes:</p>
<ul>
  <li>Increasing health</li>
  <li>Reducing time between spawns (Capped after a certain level)</li>
  <li>Increasing chances of running zombies (Capped after a certain level)</li>
  <li>Increasing maximum amount of zombies that can be active on the map (Capped after a certain level)</li>
</ul>
<br>

<p>The player position is also tracked to ensure that zombies always spawn nearby keeping the presure on. Besides this, zombies have weak points like the head and neck as well as less vulnerable areas like arms and legs which either increase the players damage or decrease it depending on which parts are shot. Finally, there are three types of zombies that can spawn. The first is very slow and is more common in the early game. The next is a slightly faster zombie that is faster than the previously mentioned one but not quicker than the player. Finally, the runner which starts spawning later in the game is the fastest of the zombies and is as fast as the player so long as they are not sprinting. Running out of sprint around them is a sure fire way to get swarmed and trapped.</p>
<br><br>


<h1>Additional Mechanics</h1>
<p>Some other mechanics include a simple stamina system for the player and an armour system which was partially implemented. The stamina system is pretty straight forward and basically only affects the player's sprint. An invisible bar of stamina will regenrate overtime and depleets whenever the player chooses to use their sprint. If they run out of stamina, the camera will darken and a vignette will blur and obscure the corners of the screen for a short duration. During this time, the player will be unable to sprint until, the regeneration begins.</p>
<p>As for the armour system, 5 pieces of body armour are hidden throughout the map. Finding them and equipping them will apply damage reduction multiplier to the player which increases with each equipped piece. A full set of armor will increase the amount of hits the player can take from 3 to 5.</p>


<h1>Planned feature that were never added</h1>
<p>As this was our first game, we had planned to have many feature that we just werent able to add with the time we had requiring us to downscale the scope multiple times. This section is dedicated to all those features and ideas that we couldnt implement.</p>
<br>

<h2>The Hub</h2>
<p>The hub was supposed to be a small village that the player could travel to via a portal which would spawn in the castle at random every few rounds. This was planned to be a market area where the player would be able to interact with numerous npcs to trade, purchase and craft equippment and much more.</p>

<h2>Powerups</h2>
<p>Powerups were rare temporary player buffs that had a small chance of spawning every time the player killed a monster. This included a speed boost, extra damage, time stop, elemental damage, etc. Currently in the gamefiles, the powerup spawn system as well as the speed boost buff are present, however due to not having an in game model, we chose to disabled it.</p>



