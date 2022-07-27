using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xeptions;

namespace BikeRental.Portal.Web.Models.Bikes.Exceptions;
public class FailedBikeDependencyException : Xeption
{
	public FailedBikeDependencyException(Exception innerException)
		:base("Failed bike dependency error occurred, contact support.",innerException)	
	{
        
	}

}
