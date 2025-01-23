<h1>Zombie Shooter</h1>
<p>Zombie Shooter is a placeholder name for this small unity project. Heavily inspired by the likes of the Call of Duty Zombies mode, this is an endless zombie horde shooter where the player must try and survive for as many rounds as possible against waves of monsters. As the rounds go by the foes will grow stronger and more numerous, making it harder for the player to uncover new areas and obtain new weapons. This project was our first foray into video game creation and the unity engine. As a team of two, we were able to put together this game within approximately 3 months. Originally planned to be a roguelike arena shooter with gun mechanics reminiscent of doom, then changed to be an rpg, wave shooter with a looting and crafting system, we eventually scaled down the project to the current simple hoard shooter that it is now.</p>
<br>

<h1>Gameplay</h1>
<p>The gameplay loop is quite simple. The player will kill zombies to gain points. Using these points the player can purchase more powerful weapons and unlock new areas of the map to explore. As the rounds go on, the difficulty will increase making it harder and harder for the player to survive. The zombies will continuously chase the player, attempting to get within melee range in order to do damage to them. If the player takes too many hits in quick succession, they will die causing the game to end and displaying statistics such as game length, total kills and number of rounds completed. Gameplay has three main components, the weapons, the map and the zombies which the player interacts with throughout a playthrough.</p>
<br>

<h2>Weapons</h2>
<p>Starting with the weapons, there are four that the player will be able to use during the game, these are the baseball bat, the pistol, the rifle and the SMG. The player will start with the bat and will need to collect more points in order to unlock the other weapons. The bat is the weakest and will lose its edge very quickly as the zombies get stronger and faster. After that, the pistol is the next weapon the player unlocks with a small magazine and low damage. After that, it goes to the rifle with high damage but a slow fire rate. Finally, the SMGis the strongest weapon, offering a high fire rate, great damage and a large magazine capacity. The player will have access to an unlimited supply of reserve ammunition and will only need to buy new weapons in order to make progression easier. Only one weapon can be carried at any time however, once unlocked, a weapon can be reaquired at its purchase station for free at any time if it isn't the current equipped weapon.</p>



<h2>The Map</h2>
<p>The castle is the only map available in the game and was designed by Matteo who worked on level design for this project. The castle is a medium size map consisting of spacious outdoor courtyards, cramped hallways and a messy dining hall where the player can explore and loop foes. To give a sense of progression, areas of the map are blocked off by default and will need to be unlocked by paying with points. The courtyard is the starting spawn point for the player and is where the bat can be acquired, from here, the player can purchase access to the castle rampart, where they can find the first part of the armour set and the pistol. After acquiring more funds, the castle can be unlocked granting access to another two pieces of the armour set and the rifle found next to the dining hall. Finally, the final location containing the SMG and the final armour piece is the townhouse area, a secondary external courtyard with a nice looping spot.</p>


<h2>The Zombies</h2>
<p>Being the player's main threat aside from a lack of funds, a lot of care was put into ensuring the zombies felt challenging but fair. As the game progresses, zombies will become more and more overwhelming. Each round, their stats go up. This includes:</p>
<ul>
  <li>Increasing health</li>
  <li>Reducing time between spawns (Capped after a certain level)</li>
  <li>Increasing chances of running zombies (Capped after a certain level)</li>
  <li>Increasing maximum amount of zombies that can be active on the map (Capped after a certain level)</li>
</ul>
<br>

<p>The player position is also tracked to ensure that zombies always spawn nearby keeping the pressure on. Besides this, zombies have weak points like the head and neck as well as less vulnerable areas like arms and legs which either increase the player's damage or decrease it depending on which parts are shot. Finally, there are three types of zombies that can spawn. The first is very slow and is more common in the early game. The next is a slightly faster zombie that is faster than the previously mentioned one but not quicker than the player. Finally, the runner which starts spawning later in the game is the fastest of the zombies and is as fast as the player so long as they are not sprinting. Running out of sprint around them is a sure fire way to get swarmed and trapped.</p>
<br><br>


<h1>Additional Mechanics</h1>
<p>Some other mechanics include a simple stamina system for the player and an armour system which was partially implemented. The stamina system is pretty straight forward and basically only affects the player's sprint. An invisible bar of stamina will regenerate overtime and depletes whenever the player chooses to use their sprint. If they run out of stamina, the camera will darken and a vignette will blur and obscure the corners of the screen for a short duration. During this time, the player will be unable to sprint until the regeneration begins.</p>
<p>As for the armour system, 5 pieces of body armour are hidden throughout the map. Finding them and equipping them will apply a damage reduction multiplier to the player which increases with each equipped piece. A full set of armor will increase the amount of hits the player can take from 3 to 5.</p>
<br><br>


<h1>Planned feature that were never added</h1>
<p>As this was our first game, we had planned to have many features that we just weren't able to add with the time we had required us to downscale the scope multiple times. This section is dedicated to all those features and ideas that we couldn't implement.</p>
<br>

<h2>The Hub</h2>
<p>The hub was supposed to be a small village that the player could travel to via a portal which would spawn in the castle at random every few rounds. This was planned to be a market area where the player would be able to interact with numerous npcs to trade, purchase and craft equipment and much more.</p>

<h2>Power Ups</h2>
<p>Power Ups were rare temporary player buffs that had a small chance of spawning every time the player killed a monster. This included a speed boost, extra damage, time stop, elemental damage, etc. Currently in the gamefiles, the powerup spawn system as well as the speed boost buff are present, however due to not having an in-game model, we chose to disabled it.</p>


<h2>Special Enemy Types</h2>
<p>Besides the regular zombies currently in the game, there were also plans to have a few other enemy types as well as mini bosses. Crawling monsters that would actively dodge out of the player's crosshair as well as ranged foes that would lob fireballs from a distance were all planned. Additionally, one miniboss that we had debated implementing was a magical knight armour enemy that would either wield a halberd or a longsword and would be very resistant to regular bullets but weaker to melee based attacks.</p>

<h2>Additional Weapons and Different Weapon System</h2>
<p>In its current state, the player can only carry one weapon at a time but always has unlimited ammunition. Originally however, the player was supposed to spawn in with the pistol and would have 3 additional weapon slots, one reserved for a melee weapon and the other two for additional guns. The pistol was planned to be the only gun with unlimited ammo and a low powered option that the player could fall back on in the case that they run out of bullets in their other weapons. Having its own dedicated inventory slot, the pistol would be with the player from start to finish.</p>
<p>Aside from this change, additional weapons were planned to be implemented. Things such as a heavy crossbow, a battlehammer, explosive items, etc were all supposed to be able to be crafted by the player.</p>


<h2>Revamped Currency System</h2>
<p>The current purchasing system is a placeholder for the first idea we had which was one based on collecting monster parts. Whenever the player killed a monster they would automatically collect a random body part from that monster. Things such as limbs, bone fragments, teeth, heads, etc would all have different drop rates and upon being collected would go into the player's duffle bag. From here, going back to the hub, the player can either trade these body parts in for gold (the rarer the part, the more gold it yields) or use them for crafting items and resources. This gold can afterwards be used to purchase upgrades, buy some items that can't be crafted or purchase bounties.</p>

<h2>Runes</h2>
<p>Runes grant the player active or passive power ups that work separately from the powerups dropped by monsters. Only one rune can be carried at any time and must be purchased from a designated npc in the hub. When purchasing a rune, the player will be given one at random. In the case that they don't like the one they received, they can pay an increased cost to reroll. Each time this is done, the cost will increase only resetting once the player leaves the hub. Some of the powerups include instant regeneration, the ability to dash, invisibility, and so on. Each rune is unique, excluding the different power ups that they grant. Things such as the number of uses it grants, or the cooldown between uses, if the ability can be activated by the player or automatically activates itself or both. </p>



<h2>Upgrades</h2>
<p>Upgrades were supposed to be purchased by the player to either increase their own stats, such as health, luck (Affects likelihood of higher rarity monster drops/ increases chance of powerup spawns), stamina, or to upgrade their equipment which includes weapons, armour, inventory room. Some upgrades just cost gold while others require certain items to be collected as well.</p>


<h2>Armour</h2>
<p>While armour is currently in the game, it was supposed to have an additional mechanic needing to be repaired over time. Armour was going to have a certain amount of hits it could take before breaking, after which the player would need to repair it at the blacksmith in the hub in order to reactivate the damage negation multiplier that it offers.</p>


<h2>The Gambler</h2>
<p>The Gambler was supposed to be an npc present at the hub that the player could challenge to a game of dice. The player would challenge them by placing down a bet, of which the gambler would match. Winner would take all. The player could play up to three rounds, wagering the first two rounds at any price they wanted, however the third and last round would always be an all in game. This rule resets every time the player returns to the hub.</p>



<h2>Sly and endgame progression</h2>
<p>The main gameplay loop for the game was always planned to be an endless loop of killing swarms of monsters while offering the player a variety of weapons, powers and upgrades to be able to diversify their approach from playthrough to playthrough. A player could play for as long as they wanted until either they lost or until they decided to shut the game down. However, we had also wanted to add a secret ending in the form of a final boss fight that could be unlocked by completing quests, unlocked by talking to a certain NPC at the hub. Sly was the name we were going to give to this NPC and they were going to appear at the hub on the player's third visit. Sly would offer time sensitive contracts for the player to complete. These contracts could be bought for a small price and could reward additional gold, or monster parts, or even pieces to craft new weapons. These contracts would be challenges such as getting a certain number of headshots or not taking damage for a full round, etc, however, every so often, a special contract could present itself and if purchased would cause certain events to unfold that don't usually take place. This would eventually lead to unlocking a secret boss fight. Completing this would then end the game prematurely if a player chose to or offer special benefits if they choose to continue the game afterwards.</p>




