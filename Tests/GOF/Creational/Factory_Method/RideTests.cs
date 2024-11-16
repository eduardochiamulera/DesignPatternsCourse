using DesignPatterns.src.GOF.Creational.Factory_Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.GOF.Creational.Factory_Method
{
	public class RideTests
	{
		[Fact]
		public void Deve_Criar_Uma_Ride() 
		{ 
			var ride = new Ride(-27.584905257808835, -48.545022195325124, new DateTime(2021, 03, 01, 10, 00, 00));

			Location from = new Location(-27.584905257808835, -48.545022195325124, new DateTime(2021, 03, 01, 10, 00, 00));
			Location to = new Location(-27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00));

			var segment = new Segment(ride.RideId, from, to);

			ride.UpdateLocation(new Location(-27.496887588317275, -48.522234807851476, new DateTime(2021, 03, 01, 12, 00, 00)));

			var fare = ride.CalculateFare([segment]);

			Assert.True(fare == 40m);
		}
	}
}
