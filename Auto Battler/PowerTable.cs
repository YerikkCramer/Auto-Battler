using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Battler
{
    internal class PowerTable
    {
        // Returns total damage based on Power Table
        public static (int, bool) GetTotalDamage(int power, int crit)
        {
            var roll = 0;
            var dmg = 0;
            var rng = new Random();
            bool didCrit = false;

            do
            {
                roll = rng.Next(1, 12) + 1;
                dmg += getDamage(roll, power);

                if (roll >= crit)
                {
                    Console.WriteLine("CRIT!!");
                    didCrit = true;
                }

            } while (roll >= crit);

            Console.WriteLine($"Total damage: {dmg}");

            return (dmg, didCrit);
        }


        static int getDamage(int roll, int power)
        {
            var powerValues = new Dictionary<int, int[]>
    {
        {3, new int[] {9,22,31,38,50,73,85,92}},
        {4, new int[] {4,10,23,29,35,40,50,55,58,85,90,96}},
        {5, new int[] {2,7,12,23,30,36,41,49,52,54,82,86,90,94,97}},
        {6, new int[] {3,8,13,21,26,34,42,44,48,56,64,70,81,88,93,98,99}},
        {7, new int[] {5,11,16,20,28,32,39,43,51,57,61,67,71,74,80,87,95}},
        {8, new int[] {0,6,14,17,22,25,33,37,46,47,59,63,65,68,75,78,83,91}},
        {9, new int[] {1,9,15,18,24,27,31,38,45,53,58,62,66,69,73,77,79,84,92}},
        {10, new int[] {1,4,10,15,19,25,29,35,40,45,52,55,60,62,69,72,76,79,84,89,96}},
        {11, new int[] {3,7,12,18,19,27,33,36,41,48,49,54,60,64,66,72,76,77,82,86,89,94,97}},
        {12, new int[] {2,6,8,13,18,19,30,34,37,42,46,53,56,59,65,70,72,76,77,81,85,88,91,93,98,99}},
    };
            var powerAdjustment = new Dictionary<int, int>
    {
        {6, 1},
        {7, 2},
        {8, 2},
        {9, 3},
        {10, 3},
        {11, 4},
        {12, 4},
    };

            Console.WriteLine($"Power {power} Rolled {roll}");

            if (powerValues.TryGetValue(roll, out var values))
            {
                var ptResult = values.Count(v => power > v);

                var adj = powerAdjustment.TryGetValue(roll, out var a) ? a : 0;

                var totalDamage = ptResult + adj;

                return totalDamage;
            }

            return 0;
        }
    }
}
