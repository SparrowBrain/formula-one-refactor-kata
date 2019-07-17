// 1.0 Find warnings, clean up (Alt + Page Up / Alt + Page Down) (Alt + Enter)
// 1.1 Do automatic code clean-up (Ctrl + E, C)

// 2.0 Encapsulate fields for PilotPoints, RaceResult (convert to properties)
// 2.1 Move RaceResult and PilotPoints to separate files
// 2.2 Move new files to Data folder + namespace

// 3.0 Simplify the for in SeasonStandingsCalculator
// 3.1 Extract point addition into a separate method, class
// 3.2 Simplify the monster if

// 4.0 Create new class WinnerPrinter (see WinnerPrinterTests)
// 4.1 Add ctor parameter to WinnerPrinter to specify season

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FormulaOneCalculator
{
    public class SeasonStandingsCalculator
    {
        public IEnumerable<(string Pilot,int Points)> FromRaceResults(List<RaceResult> raceResults)
        {
            var pilotPoints = new Dictionary<string,PilotPoints>();
            for (var j=0 ;j<raceResults.Count;j++)
            {
                var race = raceResults[j];
                for (var i = 0;i<race.Pilots.Length; i++)
                {
                    var pilot = race.Pilots[i];
                    if (pilotPoints.ContainsKey(pilot))
                    {
                    }
                    else
                        pilotPoints.Add(pilot, new PilotPoints(pilot, 0));

                    if (CompareWithIndex(i, 0))
                    {
                        pilotPoints[pilot].points += 25;
                        pilotPoints[pilot].finishesInPosition[0]++;
                    }
                    else if (CompareWithIndex(i, 1))
                    {
                        pilotPoints[pilot].points += 18; 
                        pilotPoints[pilot].finishesInPosition[1]++;
                    }
                    else if (CompareWithIndex(i, 2))
                    {
                        pilotPoints[pilot].points += 15;
                        pilotPoints[pilot].finishesInPosition[2]++;
                    }
                    else if (CompareWithIndex(i, 3))
                    {
                        pilotPoints[pilot].points += 12;
                        pilotPoints[pilot].finishesInPosition[3]++;
                    }
                    else if (CompareWithIndex(i, 4))
                    {
                        pilotPoints[pilot].points += 10;
                        pilotPoints[pilot].finishesInPosition[4]++;
                    }
                    else if (CompareWithIndex(i, 5))
                    {
                        pilotPoints[pilot].points += 8;
                        pilotPoints[pilot].finishesInPosition[5]++;
                    }
                    else if (CompareWithIndex(i, 6))
                    {
                        pilotPoints[pilot].points += 6;
                        pilotPoints[pilot].finishesInPosition[6]++;
                    }
                    else if (CompareWithIndex(i, 7))
                    {
                        pilotPoints[pilot].points += 4;
                        pilotPoints[pilot].finishesInPosition[7]++;
                    }
                    else if (CompareWithIndex(i, 8))
                    {
                        pilotPoints[pilot].points += 2;
                        pilotPoints[pilot].finishesInPosition[8]++;
                    }
                    else if (CompareWithIndex(i, 9))
                    {
                        pilotPoints[pilot].points += 1;
                        pilotPoints[pilot].finishesInPosition[9]++;
                    }
                    else
                    {
                        pilotPoints[pilot].points += 0;
                        pilotPoints[pilot].finishesInPosition[i]++;
                    }


                }
            }

            
            var orderedByDescending = pilotPoints.Values.OrderByDescending(x => x.points).ToArray();
            return orderedByDescending.Select(x => (Pilot: x.pilot, Points: x.points));
        }

        private static bool CompareWithIndex(int i, int positionIndex)
        {
            return i == positionIndex;
        }
    }

    public class RaceResult
    {
        // Array index maps to a position in the race:
        // 0 - first
        // 1 - second, etc.
        public string[] Pilots;
        string raceName;
    }

    class PilotPoints
    {
        public string pilot;
        public int points;
        public int[] finishesInPosition;

        public PilotPoints(string pilot, int points)
        {
            this.pilot = pilot;
            finishesInPosition = Enumerable.Repeat(0, 20).ToArray();
        }


    }
}
