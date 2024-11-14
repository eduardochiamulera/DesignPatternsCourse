namespace DesignPatterns.src.GOF.Creational.Factory_Method
{
	public interface RideRepository 
	{
		void Save(Ride ride);
		Ride GetById(Guid rideId);
	}
}
