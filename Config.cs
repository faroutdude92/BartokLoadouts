using System.IO;

namespace BartokLoadouts
{
    public class Config
    {
        public int GuardChieftainChance = 10;
        public int SeniorResearcherChance = 15;
        public int ClassEChance = 25;

        public static Config Load()
        {
            string path = "BartokLoadouts.yml";

            if (!File.Exists(path))
            {
                File.WriteAllText(path,
@"guard_chieftain_chance: 10
senior_researcher_chance: 15
class_e_chance: 25");
            }

            Config config = new Config();

            foreach (string line in File.ReadAllLines(path))
            {
                if (line.StartsWith("guard_chieftain_chance:"))
                    config.GuardChieftainChance = int.Parse(line.Split(':')[1].Trim());

                if (line.StartsWith("senior_researcher_chance:"))
                    config.SeniorResearcherChance = int.Parse(line.Split(':')[1].Trim());

                if (line.StartsWith("class_e_chance:"))
                    config.ClassEChance = int.Parse(line.Split(':')[1].Trim());
            }

            return config;
        }
    }
}