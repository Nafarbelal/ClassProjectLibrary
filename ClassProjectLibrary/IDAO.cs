using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassProjectLibrary
{
    public interface IDAO<T>
    {
        int delete(string Request);

        int insert(T M);

        ArrayList Select(string Request);

        int update(T M);
    }
}