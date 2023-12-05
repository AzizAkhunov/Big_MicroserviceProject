using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAI.Application.Interfaces
{
    public interface ITokenService
    {
        string Generate(string userName);
    }
}
