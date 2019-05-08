using System;
using System.Collections.Generic;

namespace Dojodachi.Models
{
    public class Pet
    {
       public string Name {get; set;}
       public int Fullness {get; set;}
       public int Happiness {get; set;}
       public int Energy {get; set;}
       public int Meals {get; set;}
       public int Turns {get; set;}
       public List<String> ActionHistory;
       public bool isDead {
            get {
                if (Energy < 1 || Happiness < 1) { return true; } else { return false; }
            }
       }
       public bool isWinner {
           get {
               if (Fullness > 100 && Happiness > 100 && Energy > 100) { return true; } else { return false; }
           }
       }
       public string imageState {
           get {
               if (isDead) { return "dojodachi_dead.png"; }
               else if (Happiness < 10 || Fullness < 10 || Energy < 16) { return "dojodachi_sad.png"; }
               else return "dojodachi.png";
           }
       }
        public Pet() {
            Name = "Dojoachi";
            Fullness = 20;
            Happiness = 20;
            Energy = 50;
            Meals = 3;
            Turns = 0;
            ActionHistory = new List<string>();
        }
        public void Feed() {
            Turns += 1;
            Random rand = new Random();
            int Points = rand.Next(5,10);
            if (Meals < 1) {
                ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: Attempted to feed {Name} but there are no meals!");
            } else {
                if (rand.NextDouble() < 0.25) {
                    Meals -= 1;
                    ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: {Name} ate one meal but didn't like it! No happiness gained!");
                } else {
                    Meals -= 1;
                    Fullness += Points;
                    ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: {Name} ate one meal and gained {Points} fullness points!");
                }
            }
        }
        public void Play() {
            Turns += 1;
            Random rand = new Random();
            int Points = rand.Next(5,10);
            if (rand.NextDouble() < 0.25) {
                Energy -= 5;
                ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: You tried playing with {Name} but it was not effective. 5 points of energy were consumed but no happiness gained!");
            } else {
                Energy -= 5;
                Happiness += Points;
                ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: You played with {Name} burning 5 energy points but gaining {Points} happiness points!");
            }
        }
        public void Work() {
            Turns += 1;
            Random rand = new Random();
            int Points = rand.Next(1,3);
            Energy -= 5;
            Meals += Points;
            if (Points == 1) {
                ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: {Name} went to work and burned 5 energy points but earned one meal!");
            } else {
                ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: {Name} went to work and burned 5 energy points but earned {Points} meals!");
            }
        }
        public void Sleep() {
            Turns += 1;
            Random rand = new Random();
            int Points = rand.Next(1,3);
            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            ActionHistory.Insert(0, $"{ActionHistory.Count + 1}: {Name} went to sleep and gained 15 energy but lost 5 fullness and 5 happiness points.");
        }
    }
}