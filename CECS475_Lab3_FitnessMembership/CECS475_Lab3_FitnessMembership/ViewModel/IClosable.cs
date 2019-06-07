/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CECS475_Lab3_FitnessMembership.ViewModel
{
    class IClosable
    {
    }
}*/
namespace CECS475_Lab3_FitnessMembership
{
    /// <summary>
    /// An interface that lets objects be closed.
    /// </summary>
    public interface IClosable
    {
        /// <summary>
        /// Closes this object.
        /// </summary>
        void Close();
    }
}
