using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class BikeDependencyException : Xeption
{
	public BikeDependencyException(Xeption innerException)
		:base("Bike dependency error occurred, contact support.", innerException)
	{
        
	}

}
