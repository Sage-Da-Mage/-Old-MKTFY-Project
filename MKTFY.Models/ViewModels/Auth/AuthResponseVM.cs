using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKTFY.Models.ViewModels.Auth
{
    /// <summary>
    /// The View Model for Authorization done through Auth0
    /// </summary>
    public class AuthResponseVM
    {
        /// <summary>
        /// The AccessToken is what proves to Auth0 that you are a 
        /// valid user, that you are authorized.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// ExpiresIn represents how long (in seconds) that the AccessToken will be valid for.
        /// </summary>
        public int ExpiresIn { get; set; }


    }
}
