using System;
using System.Collections.Generic;
using System.Linq;
using FormulaOneCalculator;
using Xunit;

namespace FormulaOneCalculatorTests
{
    public class SeasonStandingsCalculatorTests
    {
        [Fact]
        public void SeasonStandingsMatchRaceStandings_When_TwoIdenticalRaces()
        {
            var race = new RaceResult();
            var racePilots = new string[]
            {
                "Lewis Hamilton",
                "Valtteri Bottas",
                "Max Verstappen",
                "Sebastian Vettel",
                "Charles Leclerc",
                "Pierre Gasly",
                "Carlos Sainz Jr.",
                "Kimi Räikkönen",
                "Lando Norris",
                "Daniel Ricciardo",
                "Nico Hülkenberg",
                "Kevin Magnussen",
                "Sergio Pérez",
                "Daniil Kvyat",
                "Alexander Albon",
                "Lance Stroll",
                "Romain Grosjean",
                "Antonio Giovinazzi",
                "George Russell",
                "Robert Kubica",
            };

            race.Pilots= racePilots;

            var races = new List<RaceResult> {race, race};
            var seasonStandingsCalculator = new SeasonStandingsCalculator();

            // Act
            var standings = seasonStandingsCalculator.FromRaceResults(races);

            // Assert
            var seasonPilots = standings.Select(x => x.Pilot).ToArray();
            Assert.Equal(racePilots, seasonPilots);
        }

        [Fact]
        public void LeaderHas50Points_When_TwoIdenticalRaces()
        {
            var race = new RaceResult();
            var racePilots = new string[]
            {
                "Lewis Hamilton",
                "Valtteri Bottas",
                "Max Verstappen",
                "Sebastian Vettel",
                "Charles Leclerc",
                "Pierre Gasly",
                "Carlos Sainz Jr.",
                "Kimi Räikkönen",
                "Lando Norris",
                "Daniel Ricciardo",
                "Nico Hülkenberg",
                "Kevin Magnussen",
                "Sergio Pérez",
                "Daniil Kvyat",
                "Alexander Albon",
                "Lance Stroll",
                "Romain Grosjean",
                "Antonio Giovinazzi",
                "George Russell",
                "Robert Kubica",
            };

            race.Pilots = racePilots;

            var races = new List<RaceResult> { race, race };
            var seasonStandingsCalculator = new SeasonStandingsCalculator();

            // Act
            var standings = seasonStandingsCalculator.FromRaceResults(races);

            // Assert
            var leaderPoints = standings.First().Points;
            Assert.Equal(50, leaderPoints);
        }
    }
}
