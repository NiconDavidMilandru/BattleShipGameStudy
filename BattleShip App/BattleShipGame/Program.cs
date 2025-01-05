using BattleShipLibrary;

UserMessages.GreetUser();

UserMessages.Mode3();

UserMessages.InfoAboutDiff();
string player1 = UserMessages.ChooseDiff(1);
string player2 = UserMessages.ChooseDiff(2);

int rounds=UserMessages.Rounds();

int wins1 = 0;
int wins2 = 0;
int draws=0;
int moves1 = 0;
int moves2 = 0;
for (int i = 0; i < rounds; i++)
{
    int curent_round1 = 0;
    int curent_round2 = 0;

        if (player1 == "easy")
        curent_round1 = Gameplay.EasyBot();
    else
        if(player1=="medium")
        curent_round1=Gameplay.MediumBot();
    else
       if(player1=="impossible")
        curent_round1 = Gameplay.ImpossibleBot();
    else
        curent_round1=Gameplay.HardBot();

    if (player2 == "easy")
        curent_round2 = Gameplay.EasyBot();
    else
         if (player2 == "medium")
        curent_round2 = Gameplay.MediumBot();
    else
        if (player2 == "impossible")
        curent_round2 = Gameplay.ImpossibleBot();
    else
        curent_round2 = Gameplay.HardBot();

    if (curent_round1 < curent_round2)
    {
        wins1++;
        moves1 = moves1 + curent_round1;
    }
    else
        if (curent_round1 > curent_round2)
    {
        wins2++;
        moves2 = moves2 + curent_round2;
    }
    else
        draws++;
}
UserMessages.Statistics(wins1, wins2, moves1, moves2, draws);

