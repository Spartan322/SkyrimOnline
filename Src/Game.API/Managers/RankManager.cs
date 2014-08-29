
using System;
using System.Collections.Generic;
using System.Threading;
using Game.API;
using Game.API.Entities;
using Game.API.Events;
using Microsoft.Xna.Framework;

namespace Game.API.Managers
{
	public class RankManager
	{
		private Dictionary<Player, Rank> players = new Dictionary<Player, Rank>();
		private Dictionary<short, Rank> ranks = new List<short, Rank>();
		private static RankManager instance;
		
		public RankManager(short defaultLevel = 0, string defaultName = "Guest")
		{
			Rank rank = new Rank(defaultLevel, defaultName);
			ranks.Add(rank);
			IEnumerable<Player> plys = PlayerManager.Instance.Players;
			foreach(Player ply in plys)
			{
				players.Add(ply, ranks[0]);
			}
			instance = this;
		}
		
		public static RankManager Instance
		{
			get
			{
				if(!instance)
					RankManager();
				return instance;
			}
		}
		
		public Dictionary<Player, Rank> Players
		{
			get { return players; }
		}
		
		public Dictionary<short, Rank> Ranks
		{
			get { return ranks; }
		}
		
		public void AddRank(Rank rank)
		{
			if(ranks.ContainsKey(rank.Level))
			{
				ranks[rank.Level] = rank
				return;
			}
			ranks.Add(rank.Level, rank);
		}
		
		public void AddRank(string name, short level)
		{
			Rank rank = new Rank(level, name);
			this.AddRank(rank);
		}
		
		publi Player AddPlayer(Player player, Rank rank, bool isLocal)
		{
			PlayerManager.Instance.AddPlayer(player.Id, player.DisplayState.Position, player.DisplayState.Velocity, player.DisplayState.Rotation, isLocal);
			players.Add(player, rank);
			return player;
		}
		
		public Player AssignRank(Player player, Rank rank)
		{
			if(players.ContainsKey(player))
			{
				players[player] = rank;
			}
			return this.AddPlayer(player, rank, false);
		}
	}
}
