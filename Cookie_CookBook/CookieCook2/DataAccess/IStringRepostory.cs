using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCook2.DataAccess;

public interface IStringRepostory
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}
