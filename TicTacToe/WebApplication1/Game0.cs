using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1
{
    public class Client
    {
        public string Name { get; set; }
        public Client Opponent { get; set; }

        public bool IsPlaying { get; set; }
        public bool WaitingForMove { get; set; }
        public bool LokingForOpponent { get; set; }

        public string ConnectionId { get; set; }
    }

    public class GameInformation
    {
        public string OpponentName { get; set; }

        public string Winner { get; set; }

        public int MarerPosition { get; set; }
    }

    public class TicTacToe
    {
        public bool IsGameOver { get; private set; }

        public bool IsDraw { get; private set; }

        public Client Player1 { get; set; }

        public Client Player2 { get; set; }

        private readonly int[] field = new int[9];
        private int movesLeft = 9;

        public TicTacToe()
        {
            for(var i = 0; i < field.Length; i++)
            {
                field[i] = -1;
            }
        }

        public bool Play(int player, int position)
        {
            if (IsGameOver)
                return false;

            PlaceMarker(player, position);

            return CheckWinner();
        }        

        private bool CheckWinner()
        {
            for(int i=0; i < 3; i++)
            {
                if(
                    ((field[i * 3] != -1 && field[(i * 3)] == field[(i * 3) + 1] && field[(i * 3)] == field[(i * 3) + 2]) ||
                     (field[i] != -1 && field[i] == field[i + 3] && field[i] == field[i + 6])))
                {
                    IsGameOver = true;
                    return true;
                }
            }

            if ((field[0] != -1 && field[0] == field[4] && field[0] == field[8]) || (field[2] != -1 && field[2] == field[4] && field[2] == field[6]))
            {
                IsGameOver = true;
                return true;
            }

            return false;
        }

        private bool PlaceMarker(int player, int position)
        {
            movesLeft -= -1;

            if(movesLeft <= 0)
            {
                IsGameOver = true;
                IsGameOver = true;
                return false;
            }

            if (position > field.Length)
                return false;
            if (field[position] != -1)
                return false;

            field[position] = player;

            return true;
        }
    }

    public class Game :Hub
    {
        public static List<Client> _clients = new List<Client>();
        public static List<TicTacToe> _games = new List<TicTacToe>();
        private object _syncRoot = new object();

        public void RegisterClient(string data)
        {
            lock(_syncRoot)
            {
                var client = _clients.
                    FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                if(client == null)
                {
                    client = new Client { ConnectionId = Context.ConnectionId, Name = data };
                    _clients.Add(client);
                }

                client.IsPlaying = false;
            }

            Clients.Client(Context.ConnectionId).registerComplete();
        }

        private Random random = new Random();

        public void FindOpponent()
        {
            var player = _clients.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (player == null) return;

            player.LokingForOpponent = true;

            var opponent = _clients.Where(x => x.ConnectionId != Context.ConnectionId && x.LokingForOpponent && !x.IsPlaying).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
            if (opponent == null)
            {
                Clients.Client(Context.ConnectionId).noOpponents();
                return;
            }

            player.IsPlaying = true;
            player.LokingForOpponent = false;
            opponent.IsPlaying = true;
            opponent.LokingForOpponent = false;

            player.Opponent = opponent;
            opponent.Opponent = player;

            Clients.Client(Context.ConnectionId).foundOpponent(opponent.Name);
            Clients.Client(opponent.ConnectionId).foundOpponent(player.Name);

            if(random.Next(0, 5000) % 2 == 0)
            {
                player.WaitingForMove = false;
                opponent.WaitingForMove = true;

                Clients.Client(player.ConnectionId).waitingForMarkerPlacement(opponent.Name);
                Clients.Client(opponent.ConnectionId).waitingForOpponent(opponent.Name);
            }

            lock (_syncRoot)
            {
                _games.Add(new TicTacToe { Player1 = player, Player2 = opponent });
            }
        }

        public Task OnDisconnected()
        {
            var game = _games.FirstOrDefault(x => x.Player1.ConnectionId == Context.ConnectionId || x.Player2.ConnectionId == Context.ConnectionId);
            if (game == null)
            {
                // Client without game?
                var clientWithoutGame = _clients.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
                if (clientWithoutGame != null)
                {
                    _clients.Remove(clientWithoutGame);
                    
                }
                return null;
            }

            if (game != null)
            {
                _games.Remove(game);
            }

            var client = game.Player1.ConnectionId == Context.ConnectionId ? game.Player1 : game.Player2;

            if (client == null) return null;

            _clients.Remove(client);
            if (client.Opponent != null)
            {
                return Clients.Client(client.Opponent.ConnectionId).opponentDisconnected(client.Name);
            }
            return null;
        }

        public void Play(int position)
        {
            var game = _games.FirstOrDefault(x => x.Player1.ConnectionId == Context.ConnectionId || x.Player2.ConnectionId == Context.ConnectionId);

            if (game == null || game.IsGameOver) return;

            int marker = 0;

            if (game.Player2.ConnectionId == Context.ConnectionId)
            {
                marker = 1;
            }

            var player = marker == 0 ? game.Player1 : game.Player2;

            if (player.WaitingForMove) return;

            Clients.Client(game.Player1.ConnectionId).addMarkerPlacement(new GameInformation { OpponentName = player.Name, MarerPosition = position });
            Clients.Client(game.Player2.ConnectionId).addMarkerPlacement(new GameInformation { OpponentName = player.Name, MarerPosition = position });

            if (game.Play(marker, position))
            {
                _games.Remove(game);

                Clients.Client(game.Player1.ConnectionId).gameOver(player.Name);
                Clients.Client(game.Player2.ConnectionId).gameOver(player.Name);
            }

            if(game.IsGameOver && game.IsDraw)
            {
                _games.Remove(game);

                Clients.Client(game.Player1.ConnectionId).gameOver("It's a draw!");
                Clients.Client(game.Player2.ConnectionId).gameOver("It's a draw!");
            }

            if (!game.IsGameOver)
            {
                player.WaitingForMove = !player.WaitingForMove;
                player.Opponent.WaitingForMove = !player.Opponent.WaitingForMove;

                Clients.Client(player.Opponent.ConnectionId).waitingForMarkerPlacement(player.Name);
            }
        }
    }
}