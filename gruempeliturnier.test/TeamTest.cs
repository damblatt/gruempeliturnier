using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gruempeliturnier;

namespace gruempeliturnier.test
{
    [TestClass]
    public class TeamTest
    {
        [TestMethod]
        public void TestTeamInfo()
        {
            // Arrange
            var team = new Team(teamName: "Manuel", amountOfPlayers: 5);
            
            // Act
            var teamInfo = team.TeamInfo;
            Console.WriteLine(teamInfo);

            // Assert
            Assert.AreEqual("\n\tTeamname: Manuel\n\tAmount of players: 5", teamInfo);
        }
    }
}


// Test detail summary
/*

 TestTeamInfo
   Source: TeamTest.cs line 14
   Duration: 20 ms

  Message: 
Assert.AreEqual failed. Expected:<
	Teamname: Manuel
	Amount of players: 5 (System.String)>. Actual:<System.Action (System.Action)>. 

  Stack Trace: 
TeamTest.TestTeamInfo() line 24

  Standard Output: 
System.Action


 */