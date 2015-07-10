using System.Collections.Generic;
using PGE.Core.Models;

namespace PGE.Fantasy_World.Models.Life
{
    // Chief drivers of history
    public class Humanoid : Model
    {
        public string Name;
        public string Ideals;
        public string Alignment;
        public string HighAbility;
        public string LowAbility;
        public string Talents;
        public string Mannerisms;
        public string InteractionTraits;
        public string Bonds;
        public string FlawOrSecret;

        // Appearance
        public string Hair; // Includes Color AND Length
        public double SkinMelatoninDensity; // 0 == Completely Pale, 1 = Completely Dark
        public string EyeColor;
        public double Height;
        public double BodyFat; // In gross percentages (e.g. 12 or lower for athletic, 15 for average, 20 for obese, etc)
        public string Disfigurements; // Includes scars, missing teeth, etc; the only non-Genetic appearance trait

        public bool IsMale = false;

        // A list of different traits inherited from parents. Heredity is determined
        // based on that trait's HereditaryNature (Dominant, Recessive, X-Only, etc)
        public List<Trait> Traits;
    }
}
