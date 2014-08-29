
using System;
using System.Collections.Generic;
using System.Threading;
using Game.API.Entities;
using Game.API.Events;
using Game.API.Managers;
using Microsoft.Xna.Framework;

namespace Game.API
{
	public class Rank
	{
		private short rankLevel;
		private string name;
		
		public Rank(short rankLevel, string name)
		{
			this.rankLevel = rankLevel;
			this.name = name;
		}
		
		public short Level
		{
			get { return rankLevel; }
		}
		
		public string Name
		{
			get { return name; }
		}
		
		public void AssignRank(Player player)
		{
			PlayerRank(player, this);
		}
	}
	
	public class PlayerRank
	{
		private Player player;
		private Rank rank;
		
		public PlayerRank(Player player, Rank rank)
		{
			this.player;
			this.rank;
		}
		
		public Player PlayerOwner
		{
			get { return player; }
		}
		
		public Rank PlayerRank
		{
			get { return rank; }
		}
	}
}
